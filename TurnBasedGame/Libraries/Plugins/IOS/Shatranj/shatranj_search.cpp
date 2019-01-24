//
//  search.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_search.hpp"
#include <algorithm>
#include <cassert>
#include <cmath>
#include <cstring>   // For std::memset
#include <iostream>
#include <sstream>

#include "shatranj_evaluate.hpp"
#include "shatranj_misc.hpp"
#include "shatranj_movegen.hpp"
#include "shatranj_movepick.hpp"
#include "shatranj_position.hpp"
#include "shatranj_timeman.hpp"
#include "shatranj_thread.hpp"
#include "shatranj_tt.hpp"
#include "shatranj_uci.hpp"
#include "shatranj_tbprobe.hpp"

using namespace std;

namespace Shatranj
{
    namespace Search {
        
        LimitsType Limits;
    }
    
    namespace Tablebases {

        int32_t Cardinality;
        bool RootInTB;
        bool UseRule50;
        Depth ProbeDepth;
        Value Score;
    }
    
    namespace TB = Tablebases;
    
    using std::string;
    using Eval::evaluate;
    using namespace Search;
    
    namespace {
        
        // Different node types, used as a template parameter
        enum NodeType { NonPV, PV };
        
        // Sizes and phases of the skip-blocks, used for distributing search depths across the threads
        const int32_t skipSize[]  = { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4 };
        const int32_t skipPhase[] = { 0, 1, 0, 1, 2, 3, 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // Razoring and futility margin based on depth
        // razor_margin[0] is unused as long as depth >= ONE_PLY in search
        const int32_t razor_margin[] = { 0, 570, 603, 554 };
        Value futility_margin(Depth d) { return Value(150 * d / ONE_PLY); }
        
        // Futility and reductions lookup tables, initialized at startup
        int32_t FutilityMoveCounts[2][16]; // [improving][depth]
        int32_t Reductions[2][2][64][64];  // [pv][improving][depth][moveNumber]
        
        template <bool PvNode> Depth reduction(bool i, Depth d, int32_t mn) {
            return Reductions[PvNode][i][min(d / ONE_PLY, 63)][min(mn, 63)] * ONE_PLY;
        }
        
        // History and stats update bonus, based on depth
        int32_t stat_bonus(Depth depth) {
            int32_t d = depth / ONE_PLY;
            return d > 17 ? 0 : d * d + 2 * d - 2;
        }
        
        // Skill structure is used to implement strength limit
        struct Skill {
            explicit Skill(int32_t l) : level(l) {}
            bool enabled() const { return level < 20; }
            bool time_to_pick(Depth depth) const { return depth / ONE_PLY == 1 + level; }
            Move pick_best(size_t multiPV, Thread* thread);

            int32_t level;
            Move best = MOVE_NONE;
        };
        
        // EasyMoveManager structure is used to detect an 'easy move'. When the PV is stable
        // across multiple search iterations, we can quickly return the best move.
        struct EasyMoveManager {
            
            void clear() {
                stableCnt = 0;
                expectedPosKey = 0;
                pv[0] = pv[1] = pv[2] = MOVE_NONE;
            }
            
            Move get(Key key) const {
                return expectedPosKey == key ? pv[2] : MOVE_NONE;
            }
            
            void update(Position& pos, const std::vector<Move>& newPv) {
                
                // assert(newPv.size() >= 3);
                if(!(newPv.size() >= 3)){
                    printf("error, assert(newPv.size() >= 3)\n");
                }
                
                // Keep track of how many times in a row the 3rd ply remains stable
                stableCnt = (newPv[2] == pv[2]) ? stableCnt + 1 : 0;
                
                if (!std::equal(newPv.begin(), newPv.begin() + 3, pv))
                {
                    std::copy(newPv.begin(), newPv.begin() + 3, pv);
                    
                    StateInfo st[2];
                    pos.do_move(newPv[0], st[0]);
                    pos.do_move(newPv[1], st[1]);
                    expectedPosKey = pos.key();
                    pos.undo_move(newPv[1]);
                    pos.undo_move(newPv[0]);
                }
            }
            
            Key expectedPosKey;
            int32_t stableCnt;
            Move pv[3];
        };
        
        // EasyMoveManager EasyMove;
        Value DrawValue[COLOR_NB];
        
        template <NodeType NT>
        Value search(Position& pos, Stack* ss, Value alpha, Value beta, Depth depth, bool cutNode, bool skipEarlyPruning);
        
        template <NodeType NT, bool InCheck>
        Value qsearch(Position& pos, Stack* ss, Value alpha, Value beta, Depth depth = DEPTH_ZERO);
        
        Value value_to_tt(Value v, int32_t ply);
        Value value_from_tt(Value v, int32_t ply);
        void update_pv(Move* pv, Move move, Move* childPv);
        void update_continuation_histories(Stack* ss, Piece pc, Square to, int32_t bonus);
        void update_stats(const Position& pos, Stack* ss, Move move, Move* quiets, int32_t quietsCnt, int32_t bonus);
        
        // perft() is our utility to verify move generation. All the leaf nodes up
        // to the given depth are generated and counted, and the sum is returned.
        template<bool Root> uint64_t perft(Position& pos, Depth depth) {
            
            StateInfo st;
            uint64_t cnt, nodes = 0;
            const bool leaf = (depth == 2 * ONE_PLY);
            
            for (const auto& m : MoveList<LEGAL>(pos))
            {
                if (Root && depth <= ONE_PLY)
                    cnt = 1, nodes++;
                else
                {
                    pos.do_move(m, st);
                    cnt = leaf ? MoveList<LEGAL>(pos).size() : perft<false>(pos, depth - ONE_PLY);
                    nodes += cnt;
                    pos.undo_move(m);
                }
                if (Root)
                    sync_cout << UCI::move(m) << ": " << cnt << sync_endl;
            }
            return nodes;
        }
        
    } // namespace
    
    
    /// Search::init() is called during startup to initialize various lookup tables
    
    void Search::init() {
        
        for (int32_t imp = 0; imp <= 1; ++imp)
            for (int32_t d = 1; d < 64; ++d)
                for (int32_t mc = 1; mc < 64; ++mc)
                {
                    double r = log(d) * log(mc) / 1.6;
                    
                    Reductions[NonPV][imp][d][mc] = int(std::round(r));
                    Reductions[PV][imp][d][mc] = max(Reductions[NonPV][imp][d][mc] - 1, 0);
                    
                    // Increase reduction for non-PV nodes when eval is not improving
                    if (!imp && Reductions[NonPV][imp][d][mc] >= 2)
                        Reductions[NonPV][imp][d][mc]++;
                }
        
        for (int32_t d = 0; d < 16; ++d)
        {
            FutilityMoveCounts[0][d] = int(2.0 + 0.74 * pow(d, 1.78));
            FutilityMoveCounts[1][d] = int(4.0 + 1.00 * pow(d, 2.00));
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
        
        Skill skill = Skill(this->skillLevel);
        
        std::memset(ss-4, 0, 7 * sizeof(Stack));
        for (int32_t i = 4; i > 0; i--)
            (ss-i)->contHistory = &this->contHistory[NO_PIECE][0]; // Use as sentinel
        
        bestValue = delta = alpha = -VALUE_INFINITE;
        beta = VALUE_INFINITE;
        
        size_t multiPV = Options["MultiPV"];
        
        // When playing with strength handicap enable MultiPV search that we will
        // use behind the scenes to retrieve a set of possible moves.
        if (skill.enabled())
            multiPV = max(multiPV, (size_t)4);
        
        multiPV = min(multiPV, rootMoves.size());
        
        // Iterative deepening loop until requested to stop or the target depth is reached
        while (   (rootDepth += ONE_PLY) < DEPTH_MAX
               && !stop
               && !(lms.depth && rootDepth / ONE_PLY > lms.depth)) {
            // printf("thread: search: while loop: rootDepth %d %d %d\n", rootDepth, ONE_PLY, Limits.depth);
            // Distribute search depths across the threads
            if (idx) {
                int32_t i = (idx - 1) % 20;
                if (((rootDepth / ONE_PLY + rootPos->game_ply() + skipPhase[i]) / skipSize[i]) % 2){
                    // printf("thread search: contine 1\n");
                    continue;
                }
            }
            
            // Save the last iteration's scores before first PV line is searched and
            // all the move scores except the (new) PV are set to -VALUE_INFINITE.
            for (RootMove& rm : rootMoves)
                rm.previousScore = rm.score;
            
            // MultiPV loop. We perform a full root search for each PV line
            for (PVIdx = 0; PVIdx < multiPV && !stop; ++PVIdx) {
                // Reset UCI info selDepth for each depth and each PV line
                selDepth = 0;
                
                // Reset aspiration window starting size
                if (rootDepth >= 5 * ONE_PLY) {
                    delta = Value(18);
                    alpha = max(rootMoves[PVIdx].previousScore - delta,-VALUE_INFINITE);
                    beta  = min(rootMoves[PVIdx].previousScore + delta, VALUE_INFINITE);
                }
                
                // Start with a small aspiration window and, in the case of a fail
                // high/low, re-search with a bigger window until we're not failing
                // high/low anymore.
                while (true) {
                    bestValue = Shatranj::search<PV>(*rootPos, ss, alpha, beta, rootDepth, false, false);
                    
                    // Bring the best move to the front. It is critical that sorting
                    // is done with a stable algorithm because all the values but the
                    // first and eventually the new best one are set to -VALUE_INFINITE
                    // and we want to keep the same order for all the moves except the
                    // new PV that goes to the front. Note that in case of MultiPV
                    // search the already searched PV lines are preserved.
                    std::stable_sort(rootMoves.begin() + PVIdx, rootMoves.end());
                    
                    // If search has been stopped, we break immediately. Sorting and
                    // writing PV back to TT is safe because RootMoves is still
                    // valid, although it refers to the previous iteration.
                    if (stop){
                        printf("thread search: stop 1\n");
                        break;
                    }
                    
                    // In case of failing low/high increase aspiration window and
                    // re-search, otherwise exit the loop.
                    if (bestValue <= alpha) {
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
                std::stable_sort(rootMoves.begin(), rootMoves.begin() + PVIdx + 1);
            }
            
            if (!stop)
                completedDepth = rootDepth;
            
            if(rootMoves.size()>0){
                if (rootMoves[0].pv[0] != lastBestMove) {
                    lastBestMove = rootMoves[0].pv[0];
                    lastBestMoveDepth = rootDepth;
                }
            } else {
                printf("why don't have rootMove, may be mate: %s\n", rootPos->fen().c_str());
            }
            
            // Have we found a "mate in x"?
            if (   Limits.mate
                && bestValue >= VALUE_MATE_IN_MAX_PLY
                && VALUE_MATE - bestValue <= 2 * Limits.mate){
                printf("thread search found a mate: stop\n");
                this->stop = true;
            }
            
            // If skill level is enabled and time is up, pick a sub-optimal best move
            if (skill.enabled() && skill.time_to_pick(rootDepth))
                skill.pick_best(multiPV, this);
            
            // Do we have time for the next iteration? Can we stop searching now?
            {
                // TODO can hoan thien
            }
        }
        
        // If skill level is enabled, swap best PV line with the sub-optimal one
        if (skill.enabled()){
            if(rootMoves.size()>0){
                std::swap(rootMoves[0], *std::find(rootMoves.begin(), rootMoves.end(), skill.best ? skill.best : skill.pick_best(multiPV, this)));
            }else{
                printf("don't have any root move.\n");
            }
        }
    }
    
    
    namespace {
        
        // search<>() is the main search function for both PV and non-PV nodes
        
        template <NodeType NT> Value search(Position& pos, Stack* ss, Value alpha, Value beta, Depth depth, bool cutNode, bool skipEarlyPruning) {
            
            const bool PvNode = NT == PV;
            const bool rootNode = PvNode && ss->ply == 0;
            
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
            if(!(depth / ONE_PLY * ONE_PLY == depth)){
                printf("error, assert(depth / ONE_PLY * ONE_PLY == depth)\n");
            }
            
            Move pv[MAX_PLY+1], quietsSearched[64];
            StateInfo st;
            TTEntry* tte;
            Key posKey;
            Move ttMove, move, excludedMove, bestMove;
            Depth extension, newDepth;
            Value bestValue, value, ttValue, eval;
            bool ttHit, inCheck, givesCheck, singularExtensionNode, improving;
            bool captureOrPromotion, doFullDepthSearch, moveCountPruning, skipQuiets, ttCapture, pvExact;
            Piece movedPiece;
            int32_t moveCount, quietCount;
            
            // Step 1. Initialize node
            Thread* thisThread = pos.this_thread();
            inCheck = pos.checkers();
            moveCount = quietCount = ss->moveCount = 0;
            ss->statScore = 0;
            bestValue = -VALUE_INFINITE;
            
            // Check for the available remaining time
            {
                /*if (thisThread == Threads.main())
                    static_cast<MainThread*>(thisThread)->check_time();*/
                // TODO test
                {
                    int64_t duration = pos.this_thread()->lms.duration;
                    if(duration>0){
                        TimePoint current = now();
                        TimePoint lastTime = pos.this_thread()->lms.startTime;
                        if(current-lastTime>=duration){
                            // printf("search: timeout: %lld, %lld, %lld\n", current, lastTime, current - lastTime);
                            pos.this_thread()->stop = true;
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
                // Step 2. Check for aborted search and immediate draw
                if (pos.is_draw(ss->ply) || ss->ply >= MAX_PLY) {
                    // printf("pos is draw: %d\n", ss->ply);
                    return ss->ply >= MAX_PLY && !inCheck ? evaluate(pos) : DrawValue[pos.side_to_move()];
                }
                
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
            ss->contHistory = &thisThread->contHistory[NO_PIECE][0];
            (ss+2)->killers[0] = (ss+2)->killers[1] = MOVE_NONE;
            Square prevSq = to_sq((ss-1)->currentMove);
            
            // Step 4. Transposition table lookup. We don't want the score of a partial
            // search to overwrite a previous full search TT value, so we use a different
            // position key in case of an excluded move.
            excludedMove = ss->excludedMove;
            posKey = pos.key() ^ Key(excludedMove);
            tte = pos.thisThread->TT.probe(posKey, ttHit);
            ttValue = ttHit ? value_from_tt(tte->value(), ss->ply) : VALUE_NONE;
            ttMove =  rootNode ? thisThread->rootMoves[thisThread->PVIdx].pv[0]
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
                        if (!pos.capture_or_promotion(ttMove))
                            update_stats(pos, ss, ttMove, nullptr, 0, stat_bonus(depth));
                        
                        // Extra penalty for a quiet TT move in previous ply when it gets refuted
                        if ((ss-1)->moveCount == 1 && !pos.captured_piece())
                            update_continuation_histories(ss-1, pos.piece_on(prevSq), prevSq, -stat_bonus(depth + ONE_PLY));
                    }
                    // Penalty for a quiet ttMove that fails low
                    else if (!pos.capture_or_promotion(ttMove))
                    {
                        int32_t penalty = -stat_bonus(depth);
                        thisThread->mainHistory.update(pos.side_to_move(), ttMove, penalty);
                        update_continuation_histories(ss, pos.moved_piece(ttMove), to_sq(ttMove), penalty);
                    }
                }
                return ttValue;
            }
            
            // Step 4a. Tablebase probe
            if (!rootNode && TB::Cardinality)
            {
                int32_t piecesCount = pos.count<ALL_PIECES>();
                
                if (    piecesCount <= TB::Cardinality
                    && (piecesCount <  TB::Cardinality || depth >= TB::ProbeDepth)
                    &&  pos.rule50_count() == 0)
                {
                    TB::ProbeState err;
                    TB::WDLScore v = Tablebases::probe_wdl(pos, &err);
                    
                    if (err != TB::ProbeState::FAIL)
                    {
                        thisThread->tbHits.fetch_add(1, std::memory_order_relaxed);

                        int32_t drawScore = TB::UseRule50 ? 1 : 0;
                        
                        value =  v < -drawScore ? -VALUE_MATE + MAX_PLY + ss->ply + 1
                        : v >  drawScore ?  VALUE_MATE - MAX_PLY - ss->ply - 1
                        :  VALUE_DRAW + 2 * v * drawScore;
                        
                        tte->save(posKey, value_to_tt(value, ss->ply), BOUND_EXACT,
                                  min(DEPTH_MAX - ONE_PLY, depth + 6 * ONE_PLY),
                                  MOVE_NONE, VALUE_NONE, pos.thisThread->TT.generation());
                        
                        return value;
                    }
                }
            }
            
            // Step 5. Evaluate the position statically
            if (inCheck)
            {
                ss->staticEval = eval = VALUE_NONE;
                goto moves_loop;
            }
            
            else if (ttHit)
            {
                // Never assume anything on values stored in TT
                if ((ss->staticEval = eval = tte->eval()) == VALUE_NONE)
                    eval = ss->staticEval = evaluate(pos);
                
                // Can ttValue be used as a better position evaluation?
                if (   ttValue != VALUE_NONE
                    && (tte->bound() & (ttValue > eval ? BOUND_LOWER : BOUND_UPPER)))
                    eval = ttValue;
            }
            else
            {
                eval = ss->staticEval =
                (ss-1)->currentMove != MOVE_NULL ? evaluate(pos)
                : -(ss-1)->staticEval + 2 * Eval::Tempo;
                
                tte->save(posKey, VALUE_NONE, BOUND_NONE, DEPTH_NONE, MOVE_NONE,
                          ss->staticEval, pos.thisThread->TT.generation());
            }
            
            if (skipEarlyPruning)
                goto moves_loop;
            
            // Step 6. Razoring (skipped when in check)
            if (   !PvNode
                &&  depth < 4 * ONE_PLY
                &&  eval + razor_margin[depth / ONE_PLY] <= alpha)
            {
                if (depth <= ONE_PLY)
                    return qsearch<NonPV, false>(pos, ss, alpha, alpha+1);
                
                Value ralpha = alpha - razor_margin[depth / ONE_PLY];
                Value v = qsearch<NonPV, false>(pos, ss, ralpha, ralpha+1);
                if (v <= ralpha)
                    return v;
            }
            
            // Step 7. Futility pruning: child node (skipped when in check)
            if (   !rootNode
                &&  depth < 7 * ONE_PLY
                &&  eval - futility_margin(depth) >= beta
                &&  eval < VALUE_KNOWN_WIN  // Do not return unproven wins
                &&  pos.non_pawn_material(pos.side_to_move()))
                return eval;
            
            // Step 8. Null move search with verification search (is omitted in PV nodes)
            if (   !PvNode
                &&  eval >= beta
                && (ss->staticEval >= beta - 35 * (depth / ONE_PLY - 6) || depth >= 13 * ONE_PLY)
                &&  pos.non_pawn_material(pos.side_to_move()))
            {
                
                // assert(eval - beta >= 0);
                if(!(eval - beta >= 0)){
                    printf("error, assert(eval - beta >= 0)\n");
                }
                
                // Null move dynamic reduction based on depth and value
                Depth R = ((823 + 67 * depth / ONE_PLY) / 256 + min((eval - beta) / PawnValueMg, 3)) * ONE_PLY;
                
                ss->currentMove = MOVE_NULL;
                ss->contHistory = &thisThread->contHistory[NO_PIECE][0];
                
                pos.do_null_move(st);
                Value nullValue = depth-R < ONE_PLY ? -qsearch<NonPV, false>(pos, ss+1, -beta, -beta+1)
                : - search<NonPV>(pos, ss+1, -beta, -beta+1, depth-R, !cutNode, true);
                pos.undo_null_move();
                
                if (nullValue >= beta)
                {
                    // Do not return unproven mate scores
                    if (nullValue >= VALUE_MATE_IN_MAX_PLY)
                        nullValue = beta;
                    
                    if (depth < 12 * ONE_PLY && abs(beta) < VALUE_KNOWN_WIN)
                        return nullValue;
                    
                    // Do verification search at high depths
                    Value v = depth-R < ONE_PLY ? qsearch<NonPV, false>(pos, ss, beta-1, beta)
                    :  search<NonPV>(pos, ss, beta-1, beta, depth-R, false, true);
                    
                    if (v >= beta)
                        return nullValue;
                }
            }
            
            // Step 9. ProbCut (skipped when in check)
            // If we have a good enough capture and a reduced search returns a value
            // much above beta, we can (almost) safely prune the previous move.
            if (   !PvNode
                &&  depth >= 5 * ONE_PLY
                &&  abs(beta) < VALUE_MATE_IN_MAX_PLY)
            {
                Value rbeta = min(beta + 200, VALUE_INFINITE);
                
                // assert(is_ok((ss-1)->currentMove));
                if(!is_ok((ss-1)->currentMove)){
                    printf("error, assert(is_ok((ss-1)->currentMove))\n");
                }
                
                MovePicker mp(pos, ttMove, rbeta - ss->staticEval);
                
                while ((move = mp.next_move()) != MOVE_NONE)
                    if (pos.legal(move))
                    {
                        ss->currentMove = move;
                        ss->contHistory = &thisThread->contHistory[pos.moved_piece(move)][to_sq(move)];
                        
                        // assert(depth >= 5 * ONE_PLY);
                        if(!(depth >= 5 * ONE_PLY)){
                            printf("error, assert(depth >= 5 * ONE_PLY)\n");
                        }
                        
                        pos.do_move(move, st);
                        value = -search<NonPV>(pos, ss+1, -rbeta, -rbeta+1, depth - 4 * ONE_PLY, !cutNode, false);
                        pos.undo_move(move);
                        if (value >= rbeta)
                            return value;
                    }
            }
            
            // Step 10. Internal iterative deepening (skipped when in check)
            if (    depth >= 6 * ONE_PLY
                && !ttMove
                && (PvNode || ss->staticEval + 256 >= beta))
            {
                Depth d = (3 * depth / (4 * ONE_PLY) - 2) * ONE_PLY;
                search<NT>(pos, ss, alpha, beta, d, cutNode, true);
                
                tte = pos.thisThread->TT.probe(posKey, ttHit);
                ttMove = ttHit ? tte->move() : MOVE_NONE;
            }
            
        moves_loop: // When in check search starts from here
            
            const PieceToHistory* contHist[] = { (ss-1)->contHistory, (ss-2)->contHistory, nullptr, (ss-4)->contHistory };
            Move countermove = thisThread->counterMoves[pos.piece_on(prevSq)][prevSq];
            
            MovePicker mp(pos, ttMove, depth, &thisThread->mainHistory, contHist, countermove, ss->killers);
            value = bestValue; // Workaround a bogus 'uninitialized' warning under gcc
            improving =   ss->staticEval >= (ss-2)->staticEval
            /* || ss->staticEval == VALUE_NONE Already implicit in the previous condition */
            ||(ss-2)->staticEval == VALUE_NONE;
            
            singularExtensionNode =   !rootNode
            &&  depth >= 8 * ONE_PLY
            &&  ttMove != MOVE_NONE
            &&  ttValue != VALUE_NONE
            && !excludedMove // Recursive singular search is not allowed
            && (tte->bound() & BOUND_LOWER)
            &&  tte->depth() >= depth - 3 * ONE_PLY;
            skipQuiets = false;
            ttCapture = false;
            pvExact = PvNode && ttHit && tte->bound() == BOUND_EXACT;
            
            // Step 11. Loop through moves
            // Loop through all pseudo-legal moves until no moves remain or a beta cutoff occurs
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
                // mode we also skip PV moves which have been already searched.
                if (rootNode && !std::count(thisThread->rootMoves.begin() + thisThread->PVIdx,
                                            thisThread->rootMoves.end(), move))
                    continue;
                
                ss->moveCount = ++moveCount;
                
                if (PvNode)
                    (ss+1)->pv = nullptr;
                
                extension = DEPTH_ZERO;
                captureOrPromotion = pos.capture_or_promotion(move);
                movedPiece = pos.moved_piece(move);
                
                givesCheck =  type_of(move) == NORMAL && !pos.discovered_check_candidates()
                ? pos.check_squares(type_of(pos.piece_on(from_sq(move)))) & to_sq(move)
                : pos.gives_check(move);
                
                moveCountPruning =   depth < 16 * ONE_PLY
                && moveCount >= FutilityMoveCounts[improving][depth / ONE_PLY];
                
                // Step 12. Singular and Gives Check Extensions
                
                // Singular extension search. If all moves but one fail low on a search of
                // (alpha-s, beta-s), and just one fails high on (alpha, beta), then that move
                // is singular and should be extended. To verify this we do a reduced search
                // on all the other moves but the ttMove and if the result is lower than
                // ttValue minus a margin then we will extend the ttMove.
                if (    singularExtensionNode
                    &&  move == ttMove
                    &&  pos.legal(move))
                {
                    Value rBeta = max(ttValue - 2 * depth / ONE_PLY, -VALUE_MATE);
                    Depth d = (depth / (2 * ONE_PLY)) * ONE_PLY;
                    ss->excludedMove = move;
                    value = search<NonPV>(pos, ss, rBeta - 1, rBeta, d, cutNode, true);
                    ss->excludedMove = MOVE_NONE;
                    
                    if (value < rBeta)
                        extension = ONE_PLY;
                }
                else if (    givesCheck
                         && !moveCountPruning
                         &&  pos.see_ge(move))
                    extension = ONE_PLY;
                
                // Calculate new depth for this move
                newDepth = depth - ONE_PLY + extension;
                
                // Step 13. Pruning at shallow depth
                if (  !rootNode
                    && pos.non_pawn_material(pos.side_to_move())
                    && bestValue > VALUE_MATED_IN_MAX_PLY)
                {
                    if (   !captureOrPromotion
                        && !givesCheck
                        && (!pos.advanced_pawn_push(move) || pos.non_pawn_material() >= Value(5000)))
                    {
                        // Move count based pruning
                        if (moveCountPruning)
                        {
                            skipQuiets = true;
                            continue;
                        }
                        
                        // Reduced depth of the next LMR search
                        int32_t lmrDepth = max(newDepth - reduction<PvNode>(improving, depth, moveCount), DEPTH_ZERO) / ONE_PLY;
                        
                        // Countermoves based pruning
                        if (   lmrDepth < 3
                            && (*contHist[0])[movedPiece][to_sq(move)] < CounterMovePruneThreshold
                            && (*contHist[1])[movedPiece][to_sq(move)] < CounterMovePruneThreshold)
                            continue;
                        
                        // Futility pruning: parent node
                        if (   lmrDepth < 7
                            && !inCheck
                            && ss->staticEval + 256 + 200 * lmrDepth <= alpha)
                            continue;
                        
                        // Prune moves with negative SEE
                        if (   lmrDepth < 8
                            && !pos.see_ge(move, Value(-35 * lmrDepth * lmrDepth)))
                            continue;
                    }
                    else if (    depth < 7 * ONE_PLY
                             && !extension
                             && !pos.see_ge(move, -PawnValueEg * (depth / ONE_PLY)))
                        continue;
                }
                
                // Speculative prefetch as early as possible
                prefetch(pos.thisThread->TT.first_entry(pos.key_after(move)));
                
                // Check for legality just before making the move
                if (!rootNode && !pos.legal(move))
                {
                    ss->moveCount = --moveCount;
                    continue;
                }
                
                if (move == ttMove && captureOrPromotion)
                    ttCapture = true;
                
                // Update the current move (this must be done after singular extension search)
                ss->currentMove = move;
                ss->contHistory = &thisThread->contHistory[movedPiece][to_sq(move)];
                
                // Step 14. Make the move
                pos.do_move(move, st, givesCheck);
                
                // Step 15. Reduced depth search (LMR). If the move fails high it will be
                // re-searched at full depth.
                if (    depth >= 3 * ONE_PLY
                    &&  moveCount > 1
                    && (!captureOrPromotion || moveCountPruning))
                {
                    Depth r = reduction<PvNode>(improving, depth, moveCount);
                    
                    if (captureOrPromotion)
                        r -= r ? ONE_PLY : DEPTH_ZERO;
                    else
                    {
                        // Decrease reduction if opponent's move count is high
                        if ((ss-1)->moveCount > 15)
                            r -= ONE_PLY;
                        
                        // Decrease reduction for exact PV nodes
                        if (pvExact)
                            r -= ONE_PLY;
                        
                        // Increase reduction if ttMove is a capture
                        if (ttCapture)
                            r += ONE_PLY;
                        
                        // Increase reduction for cut nodes
                        if (cutNode)
                            r += 2 * ONE_PLY;
                        
                        // Decrease reduction for moves that escape a capture.
                        else if (!pos.see_ge(make_move(to_sq(move), from_sq(move))))
                            r -= 2 * ONE_PLY;
                        
                        ss->statScore =  thisThread->mainHistory[~pos.side_to_move()][from_to(move)]
                        + (*contHist[0])[movedPiece][to_sq(move)]
                        + (*contHist[1])[movedPiece][to_sq(move)]
                        + (*contHist[3])[movedPiece][to_sq(move)]
                        - 4000;
                        
                        // Decrease/increase reduction by comparing opponent's stat score
                        if (ss->statScore >= 0 && (ss-1)->statScore < 0)
                            r -= ONE_PLY;
                        
                        else if ((ss-1)->statScore >= 0 && ss->statScore < 0)
                            r += ONE_PLY;
                        
                        // Decrease/increase reduction for moves with a good/bad history
                        r = max(DEPTH_ZERO, (r / ONE_PLY - ss->statScore / 20000) * ONE_PLY);
                    }
                    
                    Depth d = max(newDepth - r, ONE_PLY);
                    
                    value = -search<NonPV>(pos, ss+1, -(alpha+1), -alpha, d, true, false);
                    
                    doFullDepthSearch = (value > alpha && d != newDepth);
                }
                else
                    doFullDepthSearch = !PvNode || moveCount > 1;
                
                // Step 16. Full depth search when LMR is skipped or fails high
                if (doFullDepthSearch)
                    value = newDepth <   ONE_PLY ?
                    givesCheck ? -qsearch<NonPV,  true>(pos, ss+1, -(alpha+1), -alpha)
                    : -qsearch<NonPV, false>(pos, ss+1, -(alpha+1), -alpha)
                    : - search<NonPV>(pos, ss+1, -(alpha+1), -alpha, newDepth, !cutNode, false);
                
                // For PV nodes only, do a full PV search on the first move or after a fail
                // high (in the latter case search only if value < beta), otherwise let the
                // parent node fail low with value <= alpha and try another move.
                if (PvNode && (moveCount == 1 || (value > alpha && (rootNode || value < beta))))
                {
                    (ss+1)->pv = pv;
                    (ss+1)->pv[0] = MOVE_NONE;
                    
                    value = newDepth <   ONE_PLY ?
                    givesCheck ? -qsearch<PV,  true>(pos, ss+1, -beta, -alpha)
                    : -qsearch<PV, false>(pos, ss+1, -beta, -alpha)
                    : - search<PV>(pos, ss+1, -beta, -alpha, newDepth, false, false);
                }
                
                // Step 17. Undo move
                pos.undo_move(move);
                
                // assert(value > -VALUE_INFINITE && value < VALUE_INFINITE);
                if(!(value > -VALUE_INFINITE && value < VALUE_INFINITE)){
                    printf("error, assert(value > -VALUE_INFINITE && value < VALUE_INFINITE)\n");
                }
                
                // Step 18. Check for a new best move
                // Finished searching the move. If a stop occurred, the return value of
                // the search cannot be trusted, and we return immediately without
                // updating best move, PV and TT.
                /*if (Threads.stop.load(std::memory_order_relaxed))
                    return VALUE_ZERO;*/
                
                if (rootNode)
                {
                    RootMove& rm = *std::find(thisThread->rootMoves.begin(),
                                              thisThread->rootMoves.end(), move);
                    
                    // PV move or new best move ?
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
                            break;
                        }
                    }
                }
                
                if (!captureOrPromotion && move != bestMove && quietCount < 64)
                    quietsSearched[quietCount++] = move;
            }
            
            // The following condition would detect a stop only after move loop has been
            // completed. But in this case bestValue is valid because we have fully
            // searched our subtree, and we can anyhow save the result in TT.
            
             if (pos.thisThread->stop)
                 return VALUE_DRAW;
            
            
            // Step 20. Check for mate and stalemate
            // All legal moves have been searched and if there are no legal moves, it
            // must be a mate or a stalemate. If we are in a singular extension search then
            // return a fail low score.
            
            // assert(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size());
            if(!(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size())){
                printf("error, assert(moveCount || !inCheck || excludedMove || !MoveList<LEGAL>(pos).size())\n");
            }
            
            if (!moveCount)
                bestValue =  excludedMove ? alpha
                : pos.count<ALL_PIECES>() == 2 ? DrawValue[pos.side_to_move()]
                : mated_in(ss->ply);
            else if (bestMove)
            {
                // Quiet best move: update move sorting heuristics
                if (!pos.capture_or_promotion(bestMove))
                    update_stats(pos, ss, bestMove, quietsSearched, quietCount, stat_bonus(depth));
                
                // Extra penalty for a quiet TT move in previous ply when it gets refuted
                if ((ss-1)->moveCount == 1 && !pos.captured_piece())
                    update_continuation_histories(ss-1, pos.piece_on(prevSq), prevSq, -stat_bonus(depth + ONE_PLY));
            }
            // Bonus for prior countermove that caused the fail low
            else if (    depth >= 3 * ONE_PLY
                     && !pos.captured_piece()
                     && is_ok((ss-1)->currentMove))
                update_continuation_histories(ss-1, pos.piece_on(prevSq), prevSq, stat_bonus(depth));
            
            if (!excludedMove)
                tte->save(posKey, value_to_tt(bestValue, ss->ply),
                          bestValue >= beta ? BOUND_LOWER :
                          PvNode && bestMove ? BOUND_EXACT : BOUND_UPPER,
                          depth, bestMove, ss->staticEval, pos.thisThread->TT.generation());
            
            // assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE);
            if(!(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)){
                printf("error, assert(bestValue > -VALUE_INFINITE && bestValue < VALUE_INFINITE)\n");
            }
            
            return bestValue;
        }
        
        
        // qsearch() is the quiescence search function, which is called by the main
        // search function with depth zero, or recursively with depth less than ONE_PLY.
        
        template <NodeType NT, bool InCheck>
        Value qsearch(Position& pos, Stack* ss, Value alpha, Value beta, Depth depth) {
            
            const bool PvNode = NT == PV;
            
            // assert(InCheck == !!pos.checkers());
            if(!(InCheck == !!pos.checkers())){
                printf("error, assert(InCheck == !!pos.checkers())\n");
            }
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
            if(!(depth / ONE_PLY * ONE_PLY == depth)){
                printf("error, assert(depth / ONE_PLY * ONE_PLY == depth)\n");
            }
            
            Move pv[MAX_PLY+1];
            StateInfo st;
            TTEntry* tte;
            Key posKey;
            Move ttMove, move, bestMove;
            Value bestValue, value, ttValue, futilityValue, futilityBase, oldAlpha;
            bool ttHit, givesCheck, evasionPrunable;
            Depth ttDepth;
            int32_t moveCount;
            
            if (PvNode)
            {
                oldAlpha = alpha; // To flag BOUND_EXACT when eval above alpha and no available moves
                (ss+1)->pv = pv;
                ss->pv[0] = MOVE_NONE;
            }
            
            ss->currentMove = bestMove = MOVE_NONE;
            (ss+1)->ply = ss->ply + 1;
            moveCount = 0;
            
            // Check for an instant draw or if the maximum ply has been reached
            if (pos.is_draw(ss->ply) || ss->ply >= MAX_PLY)
                return ss->ply >= MAX_PLY && !InCheck ? evaluate(pos)
                : DrawValue[pos.side_to_move()];
            
            // assert(0 <= ss->ply && ss->ply < MAX_PLY);
            if(!(0 <= ss->ply && ss->ply < MAX_PLY)){
                printf("error, assert(0 <= ss->ply && ss->ply < MAX_PLY)\n");
            }
            
            // Decide whether or not to include checks: this fixes also the type of
            // TT entry depth that we are going to use. Note that in qsearch we use
            // only two types of depth in TT: DEPTH_QS_CHECKS or DEPTH_QS_NO_CHECKS.
            ttDepth = InCheck || depth >= DEPTH_QS_CHECKS ? DEPTH_QS_CHECKS
            : DEPTH_QS_NO_CHECKS;
            // Transposition table lookup
            posKey = pos.key();
            tte = pos.thisThread->TT.probe(posKey, ttHit);
            ttMove = ttHit ? tte->move() : MOVE_NONE;
            ttValue = ttHit ? value_from_tt(tte->value(), ss->ply) : VALUE_NONE;
            
            if (  !PvNode
                && ttHit
                && tte->depth() >= ttDepth
                && ttValue != VALUE_NONE // Only in case of TT access race
                && (ttValue >= beta ? (tte->bound() &  BOUND_LOWER)
                    : (tte->bound() &  BOUND_UPPER)))
                return ttValue;
            
            // Evaluate the position statically
            if (InCheck)
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
                        tte->save(pos.key(), value_to_tt(bestValue, ss->ply), BOUND_LOWER,
                                  DEPTH_NONE, MOVE_NONE, ss->staticEval, pos.thisThread->TT.generation());
                    
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
            MovePicker mp(pos, ttMove, depth, &pos.this_thread()->mainHistory, to_sq((ss-1)->currentMove));
            
            // Loop through the moves until no moves remain or a beta cutoff occurs
            while ((move = mp.next_move()) != MOVE_NONE)
            {
                // assert(is_ok(move));
                if(!is_ok(move)){
                    printf("error, assert(is_ok(move))\n");
                }
                
                givesCheck =  type_of(move) == NORMAL && !pos.discovered_check_candidates()
                ? pos.check_squares(type_of(pos.piece_on(from_sq(move)))) & to_sq(move)
                : pos.gives_check(move);
                
                moveCount++;
                
                // Futility pruning
                if (   !InCheck
                    && !givesCheck
                    &&  futilityBase > -VALUE_KNOWN_WIN
                    && !pos.advanced_pawn_push(move))
                {
                    futilityValue = futilityBase + PieceValue[EG][pos.piece_on(to_sq(move))];
                    
                    if (futilityValue <= alpha)
                    {
                        bestValue = max(bestValue, futilityValue);
                        continue;
                    }
                    
                    if (futilityBase <= alpha && !pos.see_ge(move, VALUE_ZERO + 1))
                    {
                        bestValue = max(bestValue, futilityBase);
                        continue;
                    }
                }
                
                // Detect non-capture evasions that are candidates to be pruned
                evasionPrunable =    InCheck
                &&  (depth != DEPTH_ZERO || moveCount > 2)
                &&  bestValue > VALUE_MATED_IN_MAX_PLY
                && !pos.capture(move);
                
                // Don't search moves with negative SEE values
                if (  (!InCheck || evasionPrunable)
                    &&  type_of(move) != PROMOTION
                    &&  !pos.see_ge(move))
                    continue;
                
                // Speculative prefetch as early as possible
                prefetch(pos.thisThread->TT.first_entry(pos.key_after(move)));
                
                // Check for legality just before making the move
                if (!pos.legal(move))
                {
                    moveCount--;
                    continue;
                }
                
                ss->currentMove = move;
                
                // Make and search the move
                pos.do_move(move, st, givesCheck);
                value = givesCheck ? -qsearch<NT,  true>(pos, ss+1, -beta, -alpha, depth - ONE_PLY)
                : -qsearch<NT, false>(pos, ss+1, -beta, -alpha, depth - ONE_PLY);
                pos.undo_move(move);
                
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
                                      ttDepth, move, ss->staticEval, pos.thisThread->TT.generation());
                            
                            return value;
                        }
                    }
                }
            }
            
            // All legal moves have been searched. A special case: If we're in check
            // and no legal moves were found, it is checkmate.
            if (InCheck && bestValue == -VALUE_INFINITE)
                return mated_in(ss->ply); // Plies to mate from the root
            
            tte->save(posKey, value_to_tt(bestValue, ss->ply),
                      PvNode && bestValue > oldAlpha ? BOUND_EXACT : BOUND_UPPER,
                      ttDepth, bestMove, ss->staticEval, pos.thisThread->TT.generation());
            
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
            if(!(v != VALUE_NONE)){
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
                    (ss-i)->contHistory->update(pc, to, bonus);
        }
        
        
        // update_stats() updates move sorting heuristics when a new quiet best move is found
        
        void update_stats(const Position& pos, Stack* ss, Move move, Move* quiets, int32_t quietsCnt, int32_t bonus) {
            
            if (ss->killers[0] != move)
            {
                ss->killers[1] = ss->killers[0];
                ss->killers[0] = move;
            }
            
            Color c = pos.side_to_move();
            Thread* thisThread = pos.this_thread();
            thisThread->mainHistory.update(c, move, bonus);
            update_continuation_histories(ss, pos.moved_piece(move), to_sq(move), bonus);
            
            if (is_ok((ss-1)->currentMove))
            {
                Square prevSq = to_sq((ss-1)->currentMove);
                thisThread->counterMoves[pos.piece_on(prevSq)][prevSq] = move;
            }
            
            // Decrease all the other played quiet moves
            for (int32_t i = 0; i < quietsCnt; ++i)
            {
                thisThread->mainHistory.update(c, quiets[i], -bonus);
                update_continuation_histories(ss, pos.moved_piece(quiets[i]), to_sq(quiets[i]), -bonus);
            }
        }
        
        
        // When playing with strength handicap, choose best move among a set of RootMoves
        // using a statistical rule dependent on 'level'. Idea by Heinz van Saanen.
        
        Move Skill::pick_best(size_t multiPV, Thread* thread) {
            
            const RootMoves& rootMoves = thread->rootMoves;
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
    
    bool RootMove::extract_ponder_from_tt(Position& pos) {
        
        StateInfo st;
        bool ttHit;
        
        // assert(pv.size() == 1);
        if(!(pv.size() == 1)){
            printf("error, assert(pv.size() == 1)\n");
        }
        
        if (!pv[0])
            return false;
        
        pos.do_move(pv[0], st);
        TTEntry* tte = pos.thisThread->TT.probe(pos.key(), ttHit);
        
        if (ttHit)
        {
            Move m = tte->move(); // Local copy to be SMP safe
            if (MoveList<LEGAL>(pos).contains(m))
                pv.push_back(m);
        }
        
        pos.undo_move(pv[0]);
        return pv.size() > 1;
    }
    
    void Tablebases::filter_root_moves(Position& pos, Search::RootMoves& rootMoves) {
        
        RootInTB = false;
        UseRule50 = Options["Syzygy50MoveRule"];
        ProbeDepth = Options["SyzygyProbeDepth"] * ONE_PLY;
        Cardinality = Options["SyzygyProbeLimit"];
        
        // Skip TB probing when no TB found: !TBLargest -> !TB::Cardinality
        if (Cardinality > MaxCardinality)
        {
            Cardinality = MaxCardinality;
            ProbeDepth = DEPTH_ZERO;
        }
        
        if (Cardinality < popcount(pos.pieces()))
            return;
        
        // If the current root position is in the tablebases, then RootMoves
        // contains only moves that preserve the draw or the win.
        RootInTB = root_probe(pos, rootMoves, TB::Score);
        
        if (RootInTB)
            Cardinality = 0; // Do not probe tablebases during the search
        
        else // If DTZ tables are missing, use WDL tables as a fallback
        {
            // Filter out moves that do not preserve the draw or the win.
            RootInTB = root_probe_wdl(pos, rootMoves, TB::Score);
            
            // Only probe during search if winning
            if (RootInTB && TB::Score <= VALUE_DRAW)
                Cardinality = 0;
        }
        
        if (RootInTB && !UseRule50)
            TB::Score =  TB::Score > VALUE_DRAW ?  VALUE_MATE - MAX_PLY - 1
            : TB::Score < VALUE_DRAW ? -VALUE_MATE + MAX_PLY + 1
            :  VALUE_DRAW;
    }
}
