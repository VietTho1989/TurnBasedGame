/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2018 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

  Stockfish is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Stockfish is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#include <algorithm>
#include <cassert>
#include <cmath>
#include <cstring>   // For std::memset
#include <iostream>
#include <sstream>

#include "fairy_chess_evaluate.hpp"
#include "fairy_chess_misc.hpp"
#include "fairy_chess_movegen.hpp"
#include "fairy_chess_movepick.hpp"
#include "fairy_chess_position.hpp"
#include "fairy_chess_search.hpp"
#include "fairy_chess_thread.hpp"
#include "fairy_chess_timeman.hpp"
#include "fairy_chess_tt.hpp"
#include "fairy_chess_uci.hpp"
#include "syzygy/fairy_chess_tbprobe.hpp"

using namespace std;

namespace FairyChess
{
    
    namespace Tablebases {

        int32_t Cardinality;
        bool RootInTB;
        bool UseRule50;
        Depth ProbeDepth;
    }
    
    namespace TB = Tablebases;
    
    using std::string;
    using Eval::evaluate;
    using namespace Search;
    
    namespace {
        
        // Different node types, used as a template parameter
        enum NodeType { NonPV, PV };
        
        // Sizes and phases of the skip-blocks, used for distributing search depths across the threads
        constexpr int32_t SkipSize[]  = { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4 };
        constexpr int32_t SkipPhase[] = { 0, 1, 0, 1, 2, 3, 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // Razor and futility margins
        constexpr int32_t RazorMargin[] = {0, 590, 604};
        Value futility_margin(Depth d, bool improving) {
            return Value((175 - 50 * improving) * d / ONE_PLY);
        }
        
        // Futility and reductions lookup tables, initialized at startup
        int32_t FutilityMoveCounts[2][16]; // [improving][depth]
        int32_t Reductions[2][2][64][64];  // [pv][improving][depth][moveNumber]
        
        template <bool PvNode> Depth reduction(bool i, Depth d, int32_t mn) {
            return Reductions[PvNode][i][min(d / ONE_PLY, 63)][min(mn, 63)] * ONE_PLY;
        }
        
        // History and stats update bonus, based on depth
        int32_t stat_bonus(Depth depth) {
            int32_t d = depth / ONE_PLY;
            return d > 17 ? 0 : 32 * d * d + 64 * d - 64;
        }
        
        // Skill structure is used to implement strength limit
        struct Skill {
            explicit Skill(int32_t l) : level(l) {}
            bool enabled() const { return level < 20; }
            bool time_to_pick(Depth depth) const { return depth / ONE_PLY == 1 + level; }
            Move pick_best(Thread* th, size_t multiPV);

            int32_t level;
            Move best = MOVE_NONE;
        };
        
        template <NodeType NT> Value search(Position* pos, Stack* ss, Value alpha, Value beta, Depth depth, bool cutNode);
        
        template <NodeType NT>
        Value qsearch(Position* pos, Stack* ss, Value alpha, Value beta, Depth depth = DEPTH_ZERO);
        
        Value value_to_tt(Value v, int32_t ply);
        Value value_from_tt(Value v, int32_t ply);
        void update_pv(Move* pv, Move move, Move* childPv);
        void update_continuation_histories(Stack* ss, Piece pc, Square to, int32_t bonus);
        void update_quiet_stats(Position* pos, Stack* ss, Move move, Move* quiets, int32_t quietsCnt, int32_t bonus);
        void update_capture_stats(Position* pos, Move move, Move* captures, int32_t captureCnt, int32_t bonus);
        
        inline bool gives_check(Position* pos, Move move) {
            Color us = pos->side_to_move();
            return  type_of(move) == NORMAL && !(pos->blockers_for_king(~us) & pos->pieces(us))
            ? pos->check_squares(type_of(pos->moved_piece(move))) & to_sq(move)
            : pos->gives_check(move);
        }
        
        // perft() is our utility to verify move generation. All the leaf nodes up
        // to the given depth are generated and counted, and the sum is returned.
        template<bool Root> uint64_t perft(Position* pos, Depth depth) {
            
            StateInfo st;
            uint64_t cnt, nodes = 0;
            const bool leaf = (depth == 2 * ONE_PLY);
            
            for (const auto& m : MoveList<LEGAL>(pos))
            {
                if (Root && depth <= ONE_PLY)
                    cnt = 1, nodes++;
                else
                {
                    pos->do_move(m, st);
                    cnt = leaf ? MoveList<LEGAL>(pos).size() : perft<false>(pos, depth - ONE_PLY);
                    nodes += cnt;
                    pos->undo_move(m);
                }
                if (Root) {
                    // sync_cout << UCI::move(pos, m) << ": " << cnt << sync_endl;
                }
            }
            return nodes;
        }
        
    } // namespace
    
    
    /// Search::init() is called at startup to initialize various lookup tables
    
    void Search::init() {
        
        for (int32_t imp = 0; imp <= 1; ++imp)
            for (int32_t d = 1; d < 64; ++d)
                for (int32_t mc = 1; mc < 64; ++mc)
                {
                    double r = log(d) * log(mc) / 1.95;
                    
                    Reductions[NonPV][imp][d][mc] = int(std::round(r));
                    Reductions[PV][imp][d][mc] = max(Reductions[NonPV][imp][d][mc] - 1, 0);
                    
                    // Increase reduction for non-PV nodes when eval is not improving
                    if (!imp && r > 1.0)
                        Reductions[NonPV][imp][d][mc]++;
                }
        
        for (int32_t d = 0; d < 16; ++d)
        {
            FutilityMoveCounts[0][d] = int(2.4 + 0.74 * pow(d, 1.78));
            FutilityMoveCounts[1][d] = int(5.0 + 1.00 * pow(d, 2.00));
        }
    }
    
    /// Thread::search() is the main iterative deepening loop. It calls search()
    /// repeatedly with increasing depth until the allocated thinking time has been
    /// consumed, the user stops the search, or the maximum search depth is reached.
    
    void Thread::search() {
        
        Stack stack[MAX_PLY+7], *ss = stack+4; // To reference from (ss-4) to (ss+2)
        Value bestValue, alpha, beta, delta;
        Move  lastBestMove = MOVE_NONE;
        Depth lastBestMoveDepth = DEPTH_ZERO;
        Color us = rootPos->side_to_move();
        
        std::memset(ss-4, 0, 7 * sizeof(Stack));
        for (int32_t i = 4; i > 0; i--)
            (ss-i)->contHistory = (*this->contHistory1)[NO_PIECE][0].get(); // Use as sentinel
        
        bestValue = delta = alpha = -VALUE_INFINITE;
        beta = VALUE_INFINITE;
        
        size_t multiPV = Options["MultiPV"];
        Skill skill(this->skillLevel);
        
        // When playing with strength handicap enable MultiPV search that we will
        // use behind the scenes to retrieve a set of possible moves.
        if (skill.enabled())
            multiPV = max(multiPV, (size_t)4);
        
        multiPV = min(multiPV, rootMoves.size());

        int32_t ct = int(Options["Contempt"]) * PawnValueEg / 100; // From centipawns
        
        // In analysis mode, adjust contempt in accordance with user preference
        /*if (lms.infinite || Options["UCI_AnalyseMode"])
            ct =  Options["Analysis Contempt"] == "Off"  ? 0
            : Options["Analysis Contempt"] == "Both" ? ct
            : Options["Analysis Contempt"] == "White" && us == BLACK ? -ct
            : Options["Analysis Contempt"] == "Black" && us == WHITE ? -ct
            : ct;*/
        
        // In evaluate.cpp the evaluation is from the white point of view
        contempt = (us == WHITE ?  make_score(ct, ct / 2)
                    : -make_score(ct, ct / 2));
        
        // Iterative deepening loop until requested to stop or the target depth is reached
        while (   (rootDepth += ONE_PLY) < DEPTH_MAX
               && !stop
               && !(lms.depth && rootDepth / ONE_PLY > lms.depth))
        {
            // Distribute search depths across the helper threads
            if (idx > 0)
            {
                int32_t i = (idx - 1) % 20;
                if (((rootDepth / ONE_PLY + rootPos->game_ply() + SkipPhase[i]) / SkipSize[i]) % 2)
                    continue;  // Retry with an incremented rootDepth
            }
            
            // Save the last iteration's scores before first PV line is searched and
            // all the move scores except the (new) PV are set to -VALUE_INFINITE.
            for (RootMove& rm : rootMoves)
                rm.previousScore = rm.score;
            
            size_t pvFirst = 0;
            pvLast = 0;
            
            // MultiPV loop. We perform a full root search for each PV line
            for (pvIdx = 0; pvIdx < multiPV && !stop; ++pvIdx)
            {
                if (pvIdx == pvLast)
                {
                    pvFirst = pvLast;
                    for (pvLast++; pvLast < rootMoves.size(); pvLast++)
                        if (rootMoves[pvLast].tbRank != rootMoves[pvFirst].tbRank)
                            break;
                }
                
                // Reset UCI info selDepth for each depth and each PV line
                selDepth = 0;
                
                // Reset aspiration window starting size
                if (rootDepth >= 5 * ONE_PLY)
                {
                    Value previousScore = rootMoves[pvIdx].previousScore;
                    delta = Value(18);
                    alpha = max(previousScore - delta,-VALUE_INFINITE);
                    beta  = min(previousScore + delta, VALUE_INFINITE);
                    
                    // Adjust contempt based on root move's previousScore (dynamic contempt)
                    int32_t dct = ct + 88 * previousScore / (abs(previousScore) + 200);
                    
                    contempt = (us == WHITE ?  make_score(dct, dct / 2)
                                : -make_score(dct, dct / 2));
                }
                
                // Start with a small aspiration window and, in the case of a fail
                // high/low, re-search with a bigger window until we don't fail
                // high/low anymore.
                while (true)
                {
                    bestValue = FairyChess::search<PV>(rootPos, ss, alpha, beta, rootDepth, false);
                    
                    // Bring the best move to the front. It is critical that sorting
                    // is done with a stable algorithm because all the values but the
                    // first and eventually the new best one are set to -VALUE_INFINITE
                    // and we want to keep the same order for all the moves except the
                    // new PV that goes to the front. Note that in case of MultiPV
                    // search the already searched PV lines are preserved.
                    std::stable_sort(rootMoves.begin() + pvIdx, rootMoves.begin() + pvLast);
                    
                    // If search has been stopped, we break immediately. Sorting is
                    // safe because RootMoves is still valid, although it refers to
                    // the previous iteration.
                    if (stop){
                        printf("thread search: stop 1\n");
                        break;
                    }
                    
                    // In case of failing low/high increase aspiration window and
                    // re-search, otherwise exit the loop.
                    if (bestValue <= alpha)
                    {
                        beta = (alpha + beta) / 2;
                        alpha = max(bestValue - delta, -VALUE_INFINITE);
                    } else if (bestValue >= beta)
                        beta = min(bestValue + delta, VALUE_INFINITE);
                    else
                        break;
                    
                    delta += delta / 4 + 5;
                    
                    // assert(alpha >= -VALUE_INFINITE && beta <= VALUE_INFINITE);
                    if(!(alpha >= -VALUE_INFINITE && beta <= VALUE_INFINITE)){
                        printf("error, assert(alpha >= -VALUE_INFINITE && beta <= VALUE_INFINITE)\n");
                    }
                }
                
                // Sort the PV lines searched so far and update the GUI
                std::stable_sort(rootMoves.begin() + pvFirst, rootMoves.begin() + pvIdx + 1);
            }
            
            if (!stop)
                completedDepth = rootDepth;
            
            if (rootMoves[0].pv[0] != lastBestMove) {
                lastBestMove = rootMoves[0].pv[0];
                lastBestMoveDepth = rootDepth;
            }
            
            // Have we found a "mate in x"?
            if (   lms.mate
                && bestValue >= VALUE_MATE_IN_MAX_PLY
                && VALUE_MATE - bestValue <= 2 * lms.mate) {
                printf("thread search found a mate: stop\n");
                this->stop = true;
            }
            
            // If skill level is enabled and time is up, pick a sub-optimal best move
            if (skill.enabled() && skill.time_to_pick(rootDepth))
                skill.pick_best(this, multiPV);
            
            // Do we have time for the next iteration? Can we stop searching now?
            {
                
            }
        }
        
        // If skill level is enabled, swap best PV line with the sub-optimal one
        if (skill.enabled()){
            if(rootMoves.size()>0){
                std::swap(rootMoves[0], *std::find(rootMoves.begin(), rootMoves.end(), skill.best ? skill.best : skill.pick_best(this, multiPV)));
            }else{
                printf("don't have any root move.\n");
            }
        }
    }
    
    namespace {
        
        // search<>() is the main search function for both PV and non-PV nodes
        
        template <NodeType NT> Value search(Position* pos, Stack* ss, Value alpha, Value beta, Depth depth, bool cutNode) {
            
            constexpr bool PvNode = NT == PV;
            const bool rootNode = PvNode && ss->ply == 0;
            
            // Check if we have an upcoming move which draws by repetition, or
            // if the opponent had an alternative move earlier to this position.
            if (   pos->rule50_count() >= 3
                && alpha < VALUE_DRAW
                && !rootNode
                && pos->has_game_cycle(ss->ply))
            {
                alpha = VALUE_DRAW;
                if (alpha >= beta)
                    return alpha;
            }
            
            // Dive into quiescence search when the depth reaches zero
            if (depth < ONE_PLY)
                return qsearch<NT>(pos, ss, alpha, beta);
            
            // assert(-VALUE_INFINITE <= alpha && alpha < beta && beta <= VALUE_INFINITE);
            if(!(-VALUE_INFINITE <= alpha && alpha < beta && beta <= VALUE_INFINITE)){
                printf("error, assert(-VALUE_INFINITE <= alpha && alpha < beta && beta <= VALUE_INFINITE)\n");
            }
            // assert(PvNode || (alpha == beta - 1));
            if(!(PvNode || (alpha == beta - 1))){
                printf("error, assert(PvNode || (alpha == beta - 1))\n");
            }
            // assert(DEPTH_ZERO < depth && depth < DEPTH_MAX);
            if(!(DEPTH_ZERO < depth && depth < DEPTH_MAX)){
                printf("error, assert(DEPTH_ZERO < depth && depth < DEPTH_MAX)\n");
            }
            // assert(!(PvNode && cutNode));
            if(PvNode && cutNode){
                printf("error, assert(!(PvNode && cutNode))\n");
            }
            // assert(depth / ONE_PLY * ONE_PLY == depth);
            if(depth / ONE_PLY * ONE_PLY != depth){
                printf("error, assert(depth / ONE_PLY * ONE_PLY == depth)\n");
            }
            
            Move pv[MAX_PLY+1], capturesSearched[32], quietsSearched[64];
            StateInfo st;
            TTEntry* tte;
            Key posKey;
            Move ttMove, move, excludedMove, bestMove;
            Depth extension, newDepth;
            Value bestValue, value, ttValue, eval, maxValue;
            bool ttHit, inCheck, givesCheck, improving;
            bool captureOrPromotion, doFullDepthSearch, moveCountPruning, skipQuiets, ttCapture, pvExact;
            Piece movedPiece;
            int32_t moveCount, captureCount, quietCount;
            
            // Step 1. Initialize node
            Thread* thisThread = pos->this_thread();
            inCheck = pos->checkers();
            Color us = pos->side_to_move();
            moveCount = captureCount = quietCount = ss->moveCount = 0;
            bestValue = -VALUE_INFINITE;
            maxValue = VALUE_INFINITE;
            
            // Check for the available remaining time
            // TODO cai check time nay phai xem xet lai: de cho chon duoc khong phai luong chinh
            {
                /*if (thisThread == Threads.main())
                 static_cast<MainThread*>(thisThread)->check_time();*/
                // TODO test
                {
                    int64_t duration = pos->this_thread()->lms.duration;
                    if(duration>0){
                        TimePoint current = now();
                        TimePoint lastTime = pos->this_thread()->lms.startTime;
                        if(current-lastTime>=duration){
                            // printf("search: timeout: %lld, %lld, %lld\n", current, lastTime, current - lastTime);
                            pos->this_thread()->stop = true;
                        }
                    }else{
                        printf("Don't have any duration, so not check time: \n");
                    }
                }
            }
            
            // Used to send selDepth info to GUI (selDepth counts from 1, ply from 0)
            if (PvNode && thisThread->selDepth < ss->ply + 1)
                thisThread->selDepth = ss->ply + 1;
            
            if (!rootNode)
            {
                Value variantResult;
                if (pos->is_variant_end(variantResult, ss->ply))
                    return variantResult;
                
                // Step 2. Check for aborted search and immediate draw
                if (pos->is_draw(ss->ply) || ss->ply >= MAX_PLY)
                    return ss->ply >= MAX_PLY && !inCheck ? evaluate(pos) : VALUE_DRAW;
                
                // Step 3. Mate distance pruning. Even if we mate at the next move our score
                // would be at best mate_in(ss->ply+1), but if alpha is already bigger because
                // a shorter mate was found upward in the tree then there is no need to search
                // because we will never beat the current alpha. Same logic but with reversed
                // signs applies also in the opposite condition of being mated instead of giving
                // mate. In this case return a fail-high score.
                alpha = max(mated_in(ss->ply), alpha);
                beta = min(mate_in(ss->ply+1), beta);
                if (alpha >= beta)
                    return alpha;
            }
            
            // assert(0 <= ss->ply && ss->ply < MAX_PLY);
            if(!(0 <= ss->ply && ss->ply < MAX_PLY)){
                printf("error, assert(0 <= ss->ply && ss->ply < MAX_PLY)\n");
            }
            
            (ss+1)->ply = ss->ply + 1;
            ss->currentMove = (ss+1)->excludedMove = bestMove = MOVE_NONE;
            ss->contHistory = (*thisThread->contHistory1)[NO_PIECE][0].get();
            (ss+2)->killers[0] = (ss+2)->killers[1] = MOVE_NONE;
            Square prevSq = to_sq((ss-1)->currentMove);
            
            // Initialize statScore to zero for the grandchildren of the current position.
            // So statScore is shared between all grandchildren and only the first grandchild
            // starts with statScore = 0. Later grandchildren start with the last calculated
            // statScore of the previous grandchild. This influences the reduction rules in
            // LMR which are based on the statScore of parent position.
            (ss+2)->statScore = 0;
            
            // Step 4. Transposition table lookup. We don't want the score of a partial
            // search to overwrite a previous full search TT value, so we use a different
            // position key in case of an excluded move.
            excludedMove = ss->excludedMove;
            posKey = pos->key() ^ Key(excludedMove << 16); // Isn't a very good hash
            tte = pos->thisThread->TT->probe(posKey, ttHit);
            ttValue = ttHit ? value_from_tt(tte->value(), ss->ply) : VALUE_NONE;
            ttMove =  rootNode ? thisThread->rootMoves[thisThread->pvIdx].pv[0]
            : ttHit    ? tte->move() : MOVE_NONE;
            
            // At non-PV nodes we check for an early TT cutoff
            if (  !PvNode
                && ttHit
                && tte->depth() >= depth
                && ttValue != VALUE_NONE // Possible in case of TT access race
                && (ttValue >= beta ? (tte->bound() & BOUND_LOWER)
                    : (tte->bound() & BOUND_UPPER)))
            {
                // If ttMove is quiet, update move sorting heuristics on TT hit
                if (ttMove)
                {
                    if (ttValue >= beta)
                    {
                        if (!pos->capture_or_promotion(ttMove))
                            update_quiet_stats(pos, ss, ttMove, nullptr, 0, stat_bonus(depth));
                        
                        // Extra penalty for a quiet TT move in previous ply when it gets refuted
                        if ((ss-1)->moveCount == 1 && !pos->captured_piece())
                            update_continuation_histories(ss-1, pos->piece_on(prevSq), prevSq, -stat_bonus(depth + ONE_PLY));
                    }
                    // Penalty for a quiet ttMove that fails low
                    else if (!pos->capture_or_promotion(ttMove))
                    {
                        int32_t penalty = -stat_bonus(depth);
                        (*(thisThread->mainHistory))[us][from_to(ttMove)] << penalty;
                        update_continuation_histories(ss, pos->moved_piece(ttMove), to_sq(ttMove), penalty);
                    }
                }
                return ttValue;
            }
            
            // Step 5. Tablebases probe
            if (!rootNode && TB::Cardinality)
            {
                int32_t piecesCount = pos->count<ALL_PIECES>();
                
                if (    piecesCount <= TB::Cardinality
                    && (piecesCount <  TB::Cardinality || depth >= TB::ProbeDepth)
                    &&  pos->rule50_count() == 0
                    && !pos->can_castle(ANY_CASTLING))
                {
                    TB::ProbeState err;
                    TB::WDLScore wdl = Tablebases::probe_wdl(pos, &err);
                    
                    if (err != TB::ProbeState::FAIL)
                    {
                        thisThread->tbHits.fetch_add(1, std::memory_order_relaxed);

                        int32_t drawScore = TB::UseRule50 ? 1 : 0;
                        
                        value =  wdl < -drawScore ? -VALUE_MATE + MAX_PLY + ss->ply + 1
                        : wdl >  drawScore ?  VALUE_MATE - MAX_PLY - ss->ply - 1
                        :  VALUE_DRAW + 2 * wdl * drawScore;
                        
                        Bound b =  wdl < -drawScore ? BOUND_UPPER
                        : wdl >  drawScore ? BOUND_LOWER : BOUND_EXACT;
                        
                        if (    b == BOUND_EXACT
                            || (b == BOUND_LOWER ? value >= beta : value <= alpha))
                        {
                            tte->save(posKey, value_to_tt(value, ss->ply), b,
                                      min(DEPTH_MAX - ONE_PLY, depth + 6 * ONE_PLY),
                                      MOVE_NONE, VALUE_NONE, pos->thisThread->TT->generation());
                            
                            return value;
                        }
                        
                        if (PvNode)
                        {
                            if (b == BOUND_LOWER)
                                bestValue = value, alpha = max(alpha, bestValue);
                            else
                                maxValue = value;
                        }
                    }
                }
            }
            
            // Step 6. Static evaluation of the position
            if (inCheck)
            {
                ss->staticEval = eval = VALUE_NONE;
                improving = false;
                goto moves_loop;  // Skip early pruning when in check
            }
            else if (ttHit)
            {
                // Never assume anything on values stored in TT
                if ((ss->staticEval = eval = tte->eval()) == VALUE_NONE)
                    eval = ss->staticEval = evaluate(pos);
                
                // Can ttValue be used as a better position evaluation?
                if (    ttValue != VALUE_NONE
                    && (tte->bound() & (ttValue > eval ? BOUND_LOWER : BOUND_UPPER)))
                    eval = ttValue;
            }
            else
            {
                ss->staticEval = eval =
                (ss-1)->currentMove != MOVE_NULL ? evaluate(pos)
                : -(ss-1)->staticEval + 2 * Eval::Tempo;
                
                tte->save(posKey, VALUE_NONE, BOUND_NONE, DEPTH_NONE, MOVE_NONE,
                          ss->staticEval, pos->thisThread->TT->generation());
            }
            
            // Step 7. Razoring (~2 Elo)
            if (  !PvNode
                && depth < 3 * ONE_PLY
                && eval <= alpha - RazorMargin[depth / ONE_PLY])
            {
                Value ralpha = alpha - (depth >= 2 * ONE_PLY) * RazorMargin[depth / ONE_PLY];
                Value v = qsearch<NonPV>(pos, ss, ralpha, ralpha+1);
                if (depth < 2 * ONE_PLY || v <= ralpha)
                    return v;
            }
            
            improving =   ss->staticEval >= (ss-2)->staticEval
            || (ss-2)->staticEval == VALUE_NONE;
            
            // Skip early pruning in case of mandatory capture
            if (pos->must_capture() && MoveList<CAPTURES>(pos).size())
                goto moves_loop;
            
            // Step 8. Futility pruning: child node (~30 Elo)
            if (   !rootNode
                &&  depth < 7 * ONE_PLY
                &&  eval - futility_margin(depth, improving) >= beta
                &&  eval < VALUE_KNOWN_WIN) // Do not return unproven wins
                return eval;
            
            // Step 9. Null move search with verification search (~40 Elo)
            if (   !PvNode
                && (ss-1)->currentMove != MOVE_NULL
                && (ss-1)->statScore < 22500
                &&  eval >= beta
                &&  ss->staticEval >= beta - 36 * depth / ONE_PLY + 225
                && !excludedMove
                &&  pos->non_pawn_material(us)
                && (ss->ply >= thisThread->nmpMinPly || us != thisThread->nmpColor))
            {
                // assert(eval - beta >= 0);
                if(!(eval - beta >= 0)){
                    printf("error, assert(eval - beta >= 0)\n");
                }
                
                // Null move dynamic reduction based on depth and value
                Depth R = ((823 + 67 * depth / ONE_PLY) / 256 + min((eval - beta) / PawnValueMg, 3)) * ONE_PLY;
                
                ss->currentMove = MOVE_NULL;
                ss->contHistory = (*thisThread->contHistory1)[NO_PIECE][0].get();
                
                pos->do_null_move(st);
                
                Value nullValue = -search<NonPV>(pos, ss+1, -beta, -beta+1, depth-R, !cutNode);
                
                pos->undo_null_move();
                
                if (nullValue >= beta)
                {
                    // Do not return unproven mate scores
                    if (nullValue >= VALUE_MATE_IN_MAX_PLY)
                        nullValue = beta;
                    
                    if (thisThread->nmpMinPly || (abs(beta) < VALUE_KNOWN_WIN && depth < 12 * ONE_PLY))
                        return nullValue;
                    
                    // assert(!thisThread->nmpMinPly); // Recursive verification is not allowed
                    if(thisThread->nmpMinPly){
                        printf("error, assert(!thisThread->nmpMinPly)\n");
                    }
                    
                    // Do verification search at high depths, with null move pruning disabled
                    // for us, until ply exceeds nmpMinPly.
                    thisThread->nmpMinPly = ss->ply + 3 * (depth-R) / 4;
                    thisThread->nmpColor = us;
                    
                    Value v = search<NonPV>(pos, ss, beta-1, beta, depth-R, false);
                    
                    thisThread->nmpMinPly = 0;
                    
                    if (v >= beta)
                        return nullValue;
                }
            }
            
            // Step 10. ProbCut (~10 Elo)
            // If we have a good enough capture and a reduced search returns a value
            // much above beta, we can (almost) safely prune the previous move.
            if (   !PvNode
                &&  depth >= 5 * ONE_PLY
                &&  abs(beta) < VALUE_MATE_IN_MAX_PLY)
            {
                Value rbeta = min(beta + 216 - 48 * improving, VALUE_INFINITE);
                MovePicker mp(pos, ttMove, rbeta - ss->staticEval, thisThread->captureHistory);
                int32_t probCutCount = 0;
                
                while (  (move = mp.next_move()) != MOVE_NONE
                       && probCutCount < 3)
                    if (pos->legal(move))
                    {
                        probCutCount++;
                        
                        ss->currentMove = move;
                        ss->contHistory = (*thisThread->contHistory1)[pos->moved_piece(move)][to_sq(move)].get();
                        
                        // assert(depth >= 5 * ONE_PLY);
                        if(!(depth >= 5 * ONE_PLY)){
                            printf("error, assert(depth >= 5 * ONE_PLY)\n");
                        }
                        
                        pos->do_move(move, st);
                        
                        // Perform a preliminary qsearch to verify that the move holds
                        value = -qsearch<NonPV>(pos, ss+1, -rbeta, -rbeta+1);
                        
                        // If the qsearch held perform the regular search
                        if (value >= rbeta)
                            value = -search<NonPV>(pos, ss+1, -rbeta, -rbeta+1, depth - 4 * ONE_PLY, !cutNode);
                        
                        pos->undo_move(move);
                        
                        if (value >= rbeta)
                            return value;
                    }
            }
            
            // Step 11. Internal iterative deepening (~2 Elo)
            if (    depth >= 8 * ONE_PLY
                && !ttMove)
            {
                search<NT>(pos, ss, alpha, beta, depth - 7 * ONE_PLY, cutNode);
                
                tte = pos->thisThread->TT->probe(posKey, ttHit);
                ttValue = ttHit ? value_from_tt(tte->value(), ss->ply) : VALUE_NONE;
                ttMove = ttHit ? tte->move() : MOVE_NONE;
            }
            
        moves_loop: // When in check, search starts from here
            
            const PieceToHistory* contHist[] = { (ss-1)->contHistory, (ss-2)->contHistory, nullptr, (ss-4)->contHistory };
            Move countermove = (*(thisThread->counterMoves))[pos->piece_on(prevSq)][prevSq];
            
            MovePicker mp(pos, ttMove, depth, thisThread->mainHistory,
                          thisThread->captureHistory,
                          contHist,
                          countermove,
                          ss->killers);
            value = bestValue; // Workaround a bogus 'uninitialized' warning under gcc
            
            skipQuiets = false;
            ttCapture = false;
            pvExact = PvNode && ttHit && tte->bound() == BOUND_EXACT;
            
            // Step 12. Loop through all pseudo-legal moves until no moves remain
            // or a beta cutoff occurs.
            while ((move = mp.next_move(skipQuiets)) != MOVE_NONE)
            {
                // assert(is_ok(move));
                if(!is_ok(move)){
                    printf("error, assert(is_ok(move))\n");
                }
                
                if (move == excludedMove)
                    continue;
                
                // At root obey the "searchmoves" option and skip moves not listed in Root
                // Move List. As a consequence any illegal move is also skipped. In MultiPV
                // mode we also skip PV moves which have been already searched and those
                // of lower "TB rank" if we are in a TB root position.
                if (rootNode && !std::count(thisThread->rootMoves.begin() + thisThread->pvIdx,
                                            thisThread->rootMoves.begin() + thisThread->pvLast, move))
                    continue;
                
                ss->moveCount = ++moveCount;
                
                /*if (rootNode && thisThread == Threads.main() && Time.elapsed() > 3000)
                    sync_cout << "info depth " << depth / ONE_PLY
                    << " currmove " << UCI::move(pos, move)
                    << " currmovenumber " << moveCount + thisThread->pvIdx << sync_endl;*/
                if (PvNode) {
                    (ss+1)->pv = nullptr;
                }
                
                extension = DEPTH_ZERO;
                captureOrPromotion = pos->capture_or_promotion(move);
                movedPiece = pos->moved_piece(move);
                givesCheck = gives_check(pos, move);
                
                moveCountPruning =   depth < 16 * ONE_PLY
                && moveCount >= FutilityMoveCounts[improving][depth / ONE_PLY];
                
                // Step 13. Extensions (~70 Elo)
                
                // Singular extension search (~60 Elo). If all moves but one fail low on a
                // search of (alpha-s, beta-s), and just one fails high on (alpha, beta),
                // then that move is singular and should be extended. To verify this we do
                // a reduced search on on all the other moves but the ttMove and if the
                // result is lower than ttValue minus a margin then we will extend the ttMove.
                if (    depth >= 8 * ONE_PLY
                    &&  move == ttMove
                    && !rootNode
                    && !excludedMove // Recursive singular search is not allowed
                    &&  ttValue != VALUE_NONE
                    && (tte->bound() & BOUND_LOWER)
                    &&  tte->depth() >= depth - 3 * ONE_PLY
                    &&  pos->legal(move))
                {
                    Value rBeta = max(ttValue - 2 * depth / ONE_PLY, -VALUE_MATE);
                    ss->excludedMove = move;
                    value = search<NonPV>(pos, ss, rBeta - 1, rBeta, depth / 2, cutNode);
                    ss->excludedMove = MOVE_NONE;
                    
                    if (value < rBeta)
                        extension = ONE_PLY;
                }
                else if (    givesCheck // Check extension (~2 Elo)
                         && !moveCountPruning
                         &&  pos->see_ge(move))
                    extension = ONE_PLY;
                
                // Calculate new depth for this move
                newDepth = depth - ONE_PLY + extension;
                
                // Step 14. Pruning at shallow depth (~170 Elo)
                if (  !rootNode
                    && pos->non_pawn_material(us)
                    && bestValue > VALUE_MATED_IN_MAX_PLY)
                {
                    if (   !captureOrPromotion
                        && !givesCheck
                        && (!pos->advanced_pawn_push(move) || pos->non_pawn_material() >= Value(5000)))
                    {
                        // Move count based pruning (~30 Elo)
                        if (moveCountPruning)
                        {
                            skipQuiets = true;
                            continue;
                        }
                        
                        // Reduced depth of the next LMR search
                        int32_t lmrDepth = max(newDepth - reduction<PvNode>(improving, depth, moveCount), DEPTH_ZERO) / ONE_PLY;
                        
                        // Countermoves based pruning (~20 Elo)
                        if (   lmrDepth < 3
                            && (*contHist[0])[movedPiece][to_sq(move)] < CounterMovePruneThreshold
                            && (*contHist[1])[movedPiece][to_sq(move)] < CounterMovePruneThreshold)
                            continue;
                        
                        // Futility pruning: parent node (~2 Elo)
                        if (   lmrDepth < 7
                            && !inCheck
                            && ss->staticEval + 256 + 200 * lmrDepth <= alpha)
                            continue;
                        
                        // Prune moves with negative SEE (~10 Elo)
                        if (!pos->see_ge(move, Value(-29 * lmrDepth * lmrDepth)))
                            continue;
                    }
                    else if (   !extension // (~20 Elo)
                             && !pos->see_ge(move, -Value((int)PawnValueEg * ((int)depth / (int)ONE_PLY))))
                        continue;
                }
                
                // Speculative prefetch as early as possible
                prefetch(pos->thisThread->TT->first_entry(pos->key_after(move)));
                
                // Check for legality just before making the move
                if (!rootNode && !pos->legal(move))
                {
                    ss->moveCount = --moveCount;
                    continue;
                }
                
                if (move == ttMove && captureOrPromotion)
                    ttCapture = true;
                
                // Update the current move (this must be done after singular extension search)
                ss->currentMove = move;
                ss->contHistory = (*thisThread->contHistory1)[movedPiece][to_sq(move)].get();
                
                // Step 15. Make the move
                pos->do_move(move, st, givesCheck);
                
                // Step 16. Reduced depth search (LMR). If the move fails high it will be
                // re-searched at full depth.
                if (    depth >= 3 * ONE_PLY
                    &&  moveCount > 1
                    && (!captureOrPromotion || moveCountPruning))
                {
                    Depth r = reduction<PvNode>(improving, depth, moveCount);
                    
                    if (captureOrPromotion) // (~5 Elo)
                    {
                        // Increase reduction by comparing opponent's stat score
                        if ((ss-1)->statScore >= 0)
                            r += ONE_PLY;
                        
                        r -= r ? ONE_PLY : DEPTH_ZERO;
                    }
                    else
                    {
                        // Decrease reduction if opponent's move count is high (~5 Elo)
                        if ((ss-1)->moveCount > 15)
                            r -= ONE_PLY;
                        
                        // Decrease reduction for exact PV nodes (~0 Elo)
                        if (pvExact)
                            r -= ONE_PLY;
                        
                        // Increase reduction if ttMove is a capture (~0 Elo)
                        if (ttCapture)
                            r += ONE_PLY;
                        
                        // Increase reduction for cut nodes (~5 Elo)
                        if (cutNode)
                            r += 2 * ONE_PLY;
                        
                        // Decrease reduction for moves that escape a capture. Filter out
                        // castling moves, because they are coded as "king captures rook" and
                        // hence break make_move(). (~5 Elo)
                        else if (    type_of(move) == NORMAL
                                 && !pos->see_ge(make_move(to_sq(move), from_sq(move))))
                            r -= 2 * ONE_PLY;
                        
                        ss->statScore =  (*(thisThread->mainHistory))[us][from_to(move)]
                        + (*contHist[0])[movedPiece][to_sq(move)]
                        + (*contHist[1])[movedPiece][to_sq(move)]
                        + (*contHist[3])[movedPiece][to_sq(move)]
                        - 4000;
                        
                        // Decrease/increase reduction by comparing opponent's stat score (~10 Elo)
                        if (ss->statScore >= 0 && (ss-1)->statScore < 0)
                            r -= ONE_PLY;
                        
                        else if ((ss-1)->statScore >= 0 && ss->statScore < 0)
                            r += ONE_PLY;
                        
                        // Decrease/increase reduction for moves with a good/bad history (~30 Elo)
                        r = max(DEPTH_ZERO, (r / ONE_PLY - ss->statScore / 20000) * ONE_PLY);
                    }
                    
                    Depth d = max(newDepth - r, ONE_PLY);
                    
                    value = -search<NonPV>(pos, ss+1, -(alpha+1), -alpha, d, true);
                    
                    doFullDepthSearch = (value > alpha && d != newDepth);
                }
                else
                    doFullDepthSearch = !PvNode || moveCount > 1;
                
                // Step 17. Full depth search when LMR is skipped or fails high
                if (doFullDepthSearch)
                    value = -search<NonPV>(pos, ss+1, -(alpha+1), -alpha, newDepth, !cutNode);
                
                // For PV nodes only, do a full PV search on the first move or after a fail
                // high (in the latter case search only if value < beta), otherwise let the
                // parent node fail low with value <= alpha and try another move.
                if (PvNode && (moveCount == 1 || (value > alpha && (rootNode || value < beta))))
                {
                    (ss+1)->pv = pv;
                    (ss+1)->pv[0] = MOVE_NONE;
                    
                    value = -search<PV>(pos, ss+1, -beta, -alpha, newDepth, false);
                }
                
                // Step 18. Undo move
                pos->undo_move(move);
                
                // assert(value > -VALUE_INFINITE && value < VALUE_INFINITE);
                if(!(value > -VALUE_INFINITE && value < VALUE_INFINITE)){
                    printf("error, assert(value > -VALUE_INFINITE && value < VALUE_INFINITE)\n");
                }
                
                // Step 19. Check for a new best move
                // Finished searching the move. If a stop occurred, the return value of
                // the search cannot be trusted, and we return immediately without
                // updating best move, PV and TT.
                if (thisThread->stop){
                    // printf("thisThread stop\n");
                    return VALUE_ZERO;
                } else {
                    // printf("thisThread not stop\n");
                }
                
                if (rootNode)
                {
                    RootMove& rm = *std::find(thisThread->rootMoves.begin(),
                                              thisThread->rootMoves.end(), move);
                    
                    // PV move or new best move?
                    if (moveCount == 1 || value > alpha)
                    {
                        rm.score = value;
                        rm.selDepth = thisThread->selDepth;
                        rm.pv.resize(1);
                        
                        // assert((ss+1)->pv);
                        if(!(ss+1)->pv){
                            printf("error, assert((ss+1)->pv)\n");
                        }
                        
                        for (Move* m = (ss+1)->pv; *m != MOVE_NONE; ++m)
                            rm.pv.push_back(*m);
                        
                        // We record how often the best move has been changed in each
                        // iteration. This information is used for time management: When
                        // the best move changes frequently, we allocate some more time.
                        /*if (moveCount > 1 && thisThread == Threads.main())
                            ++static_cast<MainThread*>(thisThread)->bestMoveChanges;*/
                    }
                    else
                        // All other moves but the PV are set to the lowest value: this
                        // is not a problem when sorting because the sort is stable and the
                        // move position in the list is preserved - just the PV is pushed up.
                        rm.score = -VALUE_INFINITE;
                }
                
                if (value > bestValue)
                {
                    bestValue = value;
                    
                    if (value > alpha)
                    {
                        bestMove = move;
                        
                        if (PvNode && !rootNode) // Update pv even in fail-high case
                            update_pv(ss->pv, move, (ss+1)->pv);
                        
                        if (PvNode && value < beta) // Update alpha! Always alpha < beta
                            alpha = value;
                        else
                        {
                            // assert(value >= beta); // Fail high
                            if(!(value >= beta)){
                                printf("error, assert(value >= beta)\n");
                            }
                            ss->statScore = 0;
                            break;
                        }
                    }
                }
                
                if (move != bestMove)
                {
                    if (captureOrPromotion && captureCount < 32)
                        capturesSearched[captureCount++] = move;
                    
                    else if (!captureOrPromotion && quietCount < 64)
                        quietsSearched[quietCount++] = move;
                }
            }
            
            // The following condition would detect a stop only after move loop has been
            // completed. But in this case bestValue is valid because we have fully
            // searched our subtree, and we can anyhow save the result in TT.
            /*if (thisThread->stop){
                printf("thisThread stop: draw\n");
                return VALUE_DRAW;
            }*/
            
            
            // Step 20. Check for mate and stalemate
            // All legal moves have been searched and if there are no legal moves, it
            // must be a mate or a stalemate. If we are in a singular extension search then
            // return a fail low score.
            
            // assert(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size());
            if(!(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size())){
                printf("error, assert(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size())\n");
            }
            
            if (!moveCount)
                bestValue = excludedMove ? alpha
                :     inCheck ? pos->checkmate_value(ss->ply) : pos->stalemate_value(ss->ply);
            else if (bestMove)
            {
                // Quiet best move: update move sorting heuristics
                if (!pos->capture_or_promotion(bestMove))
                    update_quiet_stats(pos, ss, bestMove, quietsSearched, quietCount,
                                       stat_bonus(depth + (bestValue > beta + PawnValueMg ? ONE_PLY : DEPTH_ZERO)));
                else
                    update_capture_stats(pos, bestMove, capturesSearched, captureCount, stat_bonus(depth + ONE_PLY));
                
                // Extra penalty for a quiet TT move in previous ply when it gets refuted
                if ((ss-1)->moveCount == 1 && !pos->captured_piece())
                    update_continuation_histories(ss-1, pos->piece_on(prevSq), prevSq, -stat_bonus(depth + ONE_PLY));
            }
            // Bonus for prior countermove that caused the fail low
            else if (   (depth >= 3 * ONE_PLY || PvNode)
                     && !pos->captured_piece()
                     && is_ok((ss-1)->currentMove))
                update_continuation_histories(ss-1, pos->piece_on(prevSq), prevSq, stat_bonus(depth));
            
            if (PvNode)
                bestValue = min(bestValue, maxValue);
            
            if (!excludedMove)
                tte->save(posKey, value_to_tt(bestValue, ss->ply),
                          bestValue >= beta ? BOUND_LOWER :
                          PvNode && bestMove ? BOUND_EXACT : BOUND_UPPER,
                          depth, bestMove, ss->staticEval, pos->thisThread->TT->generation());
            
            // assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE);
            if(!(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)){
                printf("error, assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)\n");
            }
            
            return bestValue;
        }
        
        
        // qsearch() is the quiescence search function, which is called by the main
        // search function with depth zero, or recursively with depth less than ONE_PLY.
        template <NodeType NT> Value qsearch(Position* pos, Stack* ss, Value alpha, Value beta, Depth depth) {
            // printf("qsearch: %d, %d %d\n", depth, alpha, beta);
            
            constexpr bool PvNode = NT == PV;
            
            // assert(alpha >= -VALUE_INFINITE && alpha < beta && beta <= VALUE_INFINITE);
            if(!(alpha >= -VALUE_INFINITE && alpha < beta && beta <= VALUE_INFINITE)){
                printf("error, assert(alpha >= -VALUE_INFINITE && alpha < beta && beta <= VALUE_INFINITE)\n");
            }
            // assert(PvNode || (alpha == beta - 1));
            if(!(PvNode || (alpha == beta - 1))){
                printf("error, assert(PvNode || (alpha == beta - 1))\n");
            }
            // assert(depth <= DEPTH_ZERO);
            if(!(depth <= DEPTH_ZERO)){
                printf("error, assert(depth <= DEPTH_ZERO)\n");
            }
            // assert(depth / ONE_PLY * ONE_PLY == depth);
            if(depth / ONE_PLY * ONE_PLY != depth){
                printf("error, assert(depth / ONE_PLY * ONE_PLY == depth)\n");
            }
            
            Move pv[MAX_PLY+1];
            StateInfo st;
            TTEntry* tte;
            Key posKey;
            Move ttMove, move, bestMove;
            Depth ttDepth;
            Value bestValue, value, ttValue, futilityValue, futilityBase, oldAlpha;
            bool ttHit, inCheck, givesCheck, evasionPrunable;
            int32_t moveCount;
            
            if (PvNode)
            {
                oldAlpha = alpha; // To flag BOUND_EXACT when eval above alpha and no available moves
                (ss+1)->pv = pv;
                ss->pv[0] = MOVE_NONE;
            }
            
            (ss+1)->ply = ss->ply + 1;
            ss->currentMove = bestMove = MOVE_NONE;
            inCheck = pos->checkers();
            moveCount = 0;
            
            Value variantResult;
            if (pos->is_variant_end(variantResult, ss->ply))
                return variantResult;
            
            // Check for an immediate draw or maximum ply reached
            if (   pos->is_draw(ss->ply)
                || ss->ply >= MAX_PLY)
                return (ss->ply >= MAX_PLY && !inCheck) ? evaluate(pos) : VALUE_DRAW;
            
            // assert(0 <= ss->ply && ss->ply < MAX_PLY);
            if(!(0 <= ss->ply && ss->ply < MAX_PLY)){
                printf("error, assert(0 <= ss->ply && ss->ply < MAX_PLY)\n");
            }
            
            // Decide whether or not to include checks: this fixes also the type of
            // TT entry depth that we are going to use. Note that in qsearch we use
            // only two types of depth in TT: DEPTH_QS_CHECKS or DEPTH_QS_NO_CHECKS.
            ttDepth = inCheck || depth >= DEPTH_QS_CHECKS ? DEPTH_QS_CHECKS
            : DEPTH_QS_NO_CHECKS;
            // Transposition table lookup
            posKey = pos->key();
            tte = pos->thisThread->TT->probe(posKey, ttHit);
            ttValue = ttHit ? value_from_tt(tte->value(), ss->ply) : VALUE_NONE;
            ttMove = ttHit ? tte->move() : MOVE_NONE;
            
            if (  !PvNode
                && ttHit
                && tte->depth() >= ttDepth
                && ttValue != VALUE_NONE // Only in case of TT access race
                && (ttValue >= beta ? (tte->bound() &  BOUND_LOWER)
                    : (tte->bound() &  BOUND_UPPER)))
                return ttValue;
            
            // Evaluate the position statically
            if (inCheck)
            {
                ss->staticEval = VALUE_NONE;
                bestValue = futilityBase = -VALUE_INFINITE;
            }
            else
            {
                if (ttHit)
                {
                    // Never assume anything on values stored in TT
                    if ((ss->staticEval = bestValue = tte->eval()) == VALUE_NONE)
                        ss->staticEval = bestValue = evaluate(pos);
                    
                    // Can ttValue be used as a better position evaluation?
                    if (   ttValue != VALUE_NONE
                        && (tte->bound() & (ttValue > bestValue ? BOUND_LOWER : BOUND_UPPER)))
                        bestValue = ttValue;
                }
                else
                    ss->staticEval = bestValue =
                    (ss-1)->currentMove != MOVE_NULL ? evaluate(pos)
                    : -(ss-1)->staticEval + 2 * Eval::Tempo;
                
                // Stand pat. Return immediately if static value is at least beta
                if (bestValue >= beta)
                {
                    if (!ttHit)
                        tte->save(posKey, value_to_tt(bestValue, ss->ply), BOUND_LOWER,
                                  DEPTH_NONE, MOVE_NONE, ss->staticEval, pos->thisThread->TT->generation());
                    
                    return bestValue;
                }
                
                if (PvNode && bestValue > alpha)
                    alpha = bestValue;
                
                futilityBase = bestValue + 128;
            }
            
            // Initialize a MovePicker object for the current position, and prepare
            // to search the moves. Because the depth is <= 0 here, only captures,
            // queen promotions and checks (only if depth >= DEPTH_QS_CHECKS) will
            // be generated.
            MovePicker mp(pos, ttMove, depth, pos->this_thread()->mainHistory,
                          pos->this_thread()->captureHistory,
                          to_sq((ss-1)->currentMove));
            
            // Loop through the moves until no moves remain or a beta cutoff occurs
            while ((move = mp.next_move()) != MOVE_NONE)
            {
                // assert(is_ok(move));
                if(!is_ok(move)){
                    printf("error, assert(is_ok(move))\n");
                }
                
                givesCheck = gives_check(pos, move);
                
                moveCount++;
                
                // Futility pruning
                if (   !inCheck
                    && !givesCheck
                    &&  futilityBase > -VALUE_KNOWN_WIN
                    && !pos->advanced_pawn_push(move))
                {
                    // assert(type_of(move) != ENPASSANT); // Due to !pos.advanced_pawn_push
                    if(type_of(move) == ENPASSANT){
                        printf("error, assert(type_of(move) != ENPASSANT)\n");
                    }
                    
                    futilityValue = futilityBase + PieceValue[EG][pos->piece_on(to_sq(move))];
                    
                    if (futilityValue <= alpha)
                    {
                        bestValue = max(bestValue, futilityValue);
                        continue;
                    }
                    
                    if (futilityBase <= alpha && !pos->see_ge(move, VALUE_ZERO + 1))
                    {
                        bestValue = max(bestValue, futilityBase);
                        continue;
                    }
                }
                
                // Detect non-capture evasions that are candidates to be pruned
                evasionPrunable =    inCheck
                &&  (depth != DEPTH_ZERO || moveCount > 2)
                &&  bestValue > VALUE_MATED_IN_MAX_PLY
                && !pos->capture(move);
                
                // Don't search moves with negative SEE values
                if (  (!inCheck || evasionPrunable)
                    && !pos->see_ge(move))
                    continue;
                
                // Speculative prefetch as early as possible
                if(pos->thisThread!=NULL){
                    prefetch(pos->thisThread->TT->first_entry(pos->key_after(move)));
                }else{
                    printf("error, thisThread null\n");
                }
                
                // Check for legality just before making the move
                // printf("beforeCheckLegal: %d\n", pos.gamePly);
                if (!pos->legal(move))
                {
                    moveCount--;
                    continue;
                }
                // printf("afterCheckLegal\n");
                
                ss->currentMove = move;
                
                // Make and search the move
                pos->do_move(move, st, givesCheck);
                value = -qsearch<NT>(pos, ss+1, -beta, -alpha, depth - ONE_PLY);
                pos->undo_move(move);
                
                // assert(value > -VALUE_INFINITE && value < VALUE_INFINITE);
                if(!(value > -VALUE_INFINITE && value < VALUE_INFINITE)){
                    printf("error, assert(value > -VALUE_INFINITE && value < VALUE_INFINITE)\n");
                }
                
                // Check for a new best move
                if (value > bestValue)
                {
                    bestValue = value;
                    
                    if (value > alpha)
                    {
                        if (PvNode) // Update pv even in fail-high case
                            update_pv(ss->pv, move, (ss+1)->pv);
                        
                        if (PvNode && value < beta) // Update alpha here!
                        {
                            alpha = value;
                            bestMove = move;
                        }
                        else // Fail high
                        {
                            tte->save(posKey, value_to_tt(value, ss->ply), BOUND_LOWER,
                                      ttDepth, move, ss->staticEval, pos->thisThread->TT->generation());
                            
                            return value;
                        }
                    }
                }
            }
            
            // All legal moves have been searched. A special case: If we're in check
            // and no legal moves were found, it is checkmate.
            if (inCheck && bestValue == -VALUE_INFINITE)
                return mated_in(ss->ply); // Plies to mate from the root
            
            tte->save(posKey, value_to_tt(bestValue, ss->ply),
                      PvNode && bestValue > oldAlpha ? BOUND_EXACT : BOUND_UPPER,
                      ttDepth, bestMove, ss->staticEval, pos->thisThread->TT->generation());
            
            // assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE);
            if(!(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)){
                printf("error, assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)\n");
            }
            
            return bestValue;
        }
        
        
        // value_to_tt() adjusts a mate score from "plies to mate from the root" to
        // "plies to mate from the current position". Non-mate scores are unchanged.
        // The function is called before storing a value in the transposition table.
        
        Value value_to_tt(Value v, int32_t ply) {
            
            // assert(v != VALUE_NONE);
            if(v == VALUE_NONE){
                printf("error, assert(v != VALUE_NONE)\n");
            }
            
            return  v >= VALUE_MATE_IN_MAX_PLY  ? v + ply
            : v <= VALUE_MATED_IN_MAX_PLY ? v - ply : v;
        }
        
        
        // value_from_tt() is the inverse of value_to_tt(): It adjusts a mate score
        // from the transposition table (which refers to the plies to mate/be mated
        // from current position) to "plies to mate/be mated from the root".
        
        Value value_from_tt(Value v, int32_t ply) {
            
            return  v == VALUE_NONE             ? VALUE_NONE
            : v >= VALUE_MATE_IN_MAX_PLY  ? v - ply
            : v <= VALUE_MATED_IN_MAX_PLY ? v + ply : v;
        }
        
        
        // update_pv() adds current move and appends child pv[]
        
        void update_pv(Move* pv, Move move, Move* childPv) {
            
            for (*pv++ = move; childPv && *childPv != MOVE_NONE; )
                *pv++ = *childPv++;
            *pv = MOVE_NONE;
        }
        
        
        // update_continuation_histories() updates histories of the move pairs formed
        // by moves at ply -1, -2, and -4 with current move.
        
        void update_continuation_histories(Stack* ss, Piece pc, Square to, int32_t bonus) {
            
            for (int32_t i : {1, 2, 4})
                if (is_ok((ss-i)->currentMove))
                    (*(ss-i)->contHistory)[pc][to] << bonus;
        }
        
        
        // update_capture_stats() updates move sorting heuristics when a new capture best move is found
        
        void update_capture_stats(Position* pos, Move move,
                                  Move* captures, int32_t captureCnt, int32_t bonus) {
            
            CapturePieceToHistory& captureHistory =  *(pos->this_thread()->captureHistory);
            Piece moved_piece = pos->moved_piece(move);
            PieceType captured = type_of(pos->piece_on(to_sq(move)));
            captureHistory[moved_piece][to_sq(move)][captured] << bonus;
            
            // Decrease all the other played capture moves
            for (int32_t i = 0; i < captureCnt; ++i)
            {
                moved_piece = pos->moved_piece(captures[i]);
                captured = type_of(pos->piece_on(to_sq(captures[i])));
                captureHistory[moved_piece][to_sq(captures[i])][captured] << -bonus;
            }
        }
        
        
        // update_quiet_stats() updates move sorting heuristics when a new quiet best move is found
        
        void update_quiet_stats(Position* pos, Stack* ss, Move move,
                                Move* quiets, int32_t quietsCnt, int32_t bonus) {
            
            if (ss->killers[0] != move)
            {
                ss->killers[1] = ss->killers[0];
                ss->killers[0] = move;
            }
            
            Color us = pos->side_to_move();
            Thread* thisThread = pos->this_thread();
            (*(thisThread->mainHistory))[us][from_to(move)] << bonus;
            update_continuation_histories(ss, pos->moved_piece(move), to_sq(move), bonus);
            
            if (is_ok((ss-1)->currentMove))
            {
                Square prevSq = to_sq((ss-1)->currentMove);
                (*(thisThread->counterMoves))[pos->piece_on(prevSq)][prevSq] = move;
            }
            
            // Decrease all the other played quiet moves
            for (int32_t i = 0; i < quietsCnt; ++i)
            {
                (*(thisThread->mainHistory))[us][from_to(quiets[i])] << -bonus;
                update_continuation_histories(ss, pos->moved_piece(quiets[i]), to_sq(quiets[i]), -bonus);
            }
        }
        
        // When playing with strength handicap, choose best move among a set of RootMoves
        // using a statistical rule dependent on 'level'. Idea by Heinz van Saanen.
        
        Move Skill::pick_best(Thread* th, size_t multiPV) {
            
            const RootMoves& rootMoves = th->rootMoves;
            static PRNG rng(now()); // PRNG sequence should be non-deterministic
            
            // RootMoves are already sorted by score in descending order
            Value topScore = rootMoves[0].score;
            int32_t delta = min(topScore - rootMoves[multiPV - 1].score, PawnValueMg);
            int32_t weakness = 120 - 2 * level;
            int32_t maxScore = -VALUE_INFINITE;
            
            // Choose best move. For each move score we add two terms, both dependent on
            // weakness. One is deterministic and bigger for weaker levels, and one is
            // random. Then we choose the move with the resulting highest score.
            for (size_t i = 0; i < multiPV; ++i)
            {
                // This is our magic formula
                int32_t push = (  weakness * int(topScore - rootMoves[i].score)
                            + delta * (rng.rand<uint32_t>() % weakness)) / 128;
                
                if (rootMoves[i].score + push >= maxScore)
                {
                    maxScore = rootMoves[i].score + push;
                    best = rootMoves[i].pv[0];
                }
            }
            
            return best;
        }
        
    } // namespace
    
    /// RootMove::extract_ponder_from_tt() is called in case we have no ponder move
    /// before exiting the search, for instance, in case we stop the search during a
    /// fail high at root. We try hard to have a ponder move to return to the GUI,
    /// otherwise in case of 'ponder on' we have nothing to think on.
    
    bool RootMove::extract_ponder_from_tt(Position* pos) {
        
        StateInfo st;
        bool ttHit;
        
        // assert(pv.size() == 1);
        if(pv.size() != 1){
            printf("error, assert(pv.size() == 1)\n");
        }
        
        if (!pv[0])
            return false;
        
        pos->do_move(pv[0], st);
        TTEntry* tte = pos->thisThread->TT->probe(pos->key(), ttHit);
        
        if (ttHit)
        {
            Move m = tte->move(); // Local copy to be SMP safe
            if (MoveList<LEGAL>(pos).contains(m))
                pv.push_back(m);
        }
        
        pos->undo_move(pv[0]);
        return pv.size() > 1;
    }
    
    void Tablebases::rank_root_moves(Position* pos, Search::RootMoves& rootMoves) {
        
        RootInTB = false;
        UseRule50 = bool(Options["Syzygy50MoveRule"]);
        ProbeDepth = int(Options["SyzygyProbeDepth"]) * ONE_PLY;
        Cardinality = int(Options["SyzygyProbeLimit"]);
        bool dtz_available = true;
        
        // Tables with fewer pieces than SyzygyProbeLimit are searched with
        // ProbeDepth == DEPTH_ZERO
        if (Cardinality > MaxCardinality)
        {
            Cardinality = MaxCardinality;
            ProbeDepth = DEPTH_ZERO;
        }
        
        if (Cardinality >= popcount(pos->pieces()) && !pos->can_castle(ANY_CASTLING))
        {
            // Rank moves using DTZ tables
            RootInTB = root_probe(pos, rootMoves);
            
            if (!RootInTB)
            {
                // DTZ tables are missing; try to rank moves using WDL tables
                dtz_available = false;
                RootInTB = root_probe_wdl(pos, rootMoves);
            }
        }
        
        if (RootInTB)
        {
            // Sort moves according to TB rank
            std::sort(rootMoves.begin(), rootMoves.end(),
                      [](const RootMove &a, const RootMove &b) { return a.tbRank > b.tbRank; } );
            
            // Probe during search only if DTZ is not available and we are winning
            if (dtz_available || rootMoves[0].tbScore <= VALUE_DRAW)
                Cardinality = 0;
        }
        else
        {
            // Assign the same rank to all moves
            for (auto& m : rootMoves)
                m.tbRank = 0;
        }
    }
}
