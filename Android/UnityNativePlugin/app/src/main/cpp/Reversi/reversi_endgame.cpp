#include <iostream>
#include <algorithm>
#include "reversi_endgame.hpp"

using namespace std;

namespace Reversi
{
    const int32_t STAB_THRESHOLD[40] = {
        /*
         64, 64, 64, 64, 64,
         12, 14, 16, 18, 20,
         22, 24, 26, 28, 30,
         32, 34, 36, 38, 40,
         42, 44, 46, 48, 50,
         52, 54, 56, 58, 58,
         60, 60, 62, 62, 64,
         64, 64, 64, 64, 64
         */
        64, 64, 64, 64, 64,
        14, 16, 18, 20, 22,
        24, 26, 28, 30, 32,
        34, 36, 38, 40, 42,
        44, 46, 48, 50, 52,
        54, 56, 56, 58, 58,
        60, 60, 62, 62, 64,
        64, 64, 64, 64, 64
    };
    
    const int32_t ROOT_SORT_DEPTHS[38] = { 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 2, 2, 4, 4, 6, 6, 8,
        8, 10, 10, 12, 12, 12, 12, 12, 12, 12,
        12, 12, 12, 12, 12, 12, 12
    };
    
    // Depths for sort searching. Indexed by depth.
    const int32_t ENDGAME_SORT_DEPTHS[38] = { 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 2, 2, 2, 2, 4, 4,
        4, 4, 6, 6, 6, 6, 8, 8, 8, 8,
        10, 10, 10, 10, 12, 12, 12
    };
    
    const int32_t END_SHALLOW = 12;
    const int32_t MIN_TT_DEPTH = 9;
    
    const int32_t SCORE_TIMEOUT = 65;
    const int32_t MOVE_FAIL_LOW = -1;
    const int32_t EG_SCALE_FACTOR = 600;
    
    struct EndgameStatistics {
        uint64_t hashHits, hashCuts;
        uint64_t hashMoveAttempts, hashMoveCuts;
        uint64_t firstFailHighs, failHighs;
        uint64_t sortSearchNodes;
        
        void reset() {
            hashHits = 0;
            hashCuts = 0;
            hashMoveAttempts = 0;
            hashMoveCuts = 0;
            firstFailHighs = 0;
            failHighs = 0;
            sortSearchNodes = 0;
        }
    };
    
    Endgame::Endgame() {
        // 16384 entries
        endgameTable = new EndHash(14);
        // 2^23 entries * 20 bytes/entry = 168 MB
        killerTable = new EndHash(23);
        // 2^22 entries * 20 bytes/entry = 84 MB
        allTable = new EndHash(22);
        // 2^20 array slots (2^21 entries) * 64 bytes/slot = 67 MB
        transpositionTable = new Hash(20);
        
        egStats = new EndgameStatistics();
    }
    
    Endgame::~Endgame() {
        delete endgameTable;
        delete killerTable;
        delete allTable;
        delete transpositionTable;
        
        delete egStats;
    }
    /**
     * @brief Solves the endgame for perfect play.
     * @param b The board to solve
     * @param moves The list of legal moves for the side to move
     * @param isSorted Whether the legal moves list is already sorted or not. If not,
     * it must be sorted within the endgame solver.
     * @param s The side to move
     * @param depth The number of empty squares left on the board
     * @param timeLimit The time limit in milliseconds
     * @param eval A pointer to the evaluater object
     * @param exactScore An optional parameter to also get the exact score
     * @return The index of the best move
     */
    int32_t Endgame::solveEndgame(Board &b, MoveList &moves, bool isSorted, int32_t s,
                                  int32_t depth, int32_t timeLimit, Eval *eval, int32_t *exactScore) {
        return solveEndgameWithWindow(b, moves, isSorted, s, depth, -64, 64,
                                      timeLimit, eval, exactScore);
    }
    
    /**
     * @brief Solve the game for final result: win, loss, or draw.
     */
    int32_t Endgame::solveWLD(Board &b, MoveList &moves, bool isSorted, int32_t s,
                              int32_t depth, int32_t timeLimit, Eval *eval, int32_t *exactScore) {
        printf("WLD solver: depth %d\n", depth);
        int32_t gameResult = -2;
        int32_t bestMove = solveEndgameWithWindow(b, moves, isSorted, s, depth, -1, 1,
                                              timeLimit, eval, &gameResult);
        
#if PRINT_SEARCH_INFO
        if (bestMove != MOVE_BROKEN) {
            if (gameResult == 0) {
                printf("Game is draw\n");
            }
            else if (gameResult <= -1) {
                printf("Game is loss\n");
            }
            else {
                printf("Game is win\n");
            }
        }
#endif
        if (exactScore != NULL)
            *exactScore = gameResult;
        
        return bestMove;
    }
    
    /**
     * @brief "Solve" the game for a result based on the given alpha-beta window.
     * A window of -64, 64 is exact result.
     * A window of -1, 1 is win/loss/draw.
     */
    int32_t Endgame::solveEndgameWithWindow(Board &b, MoveList &moves, bool isSorted,
                                            int32_t s, int32_t depth, int32_t alpha, int32_t beta, int32_t timeLimit, Eval *eval,
                                            int32_t *exactScore) {
        // if best move for this position has already been found and stored
        EndgameEntry *entry = endgameTable->get(b, s);
        if(entry != NULL) {
#if PRINT_SEARCH_INFO
            printf("Endgame hashtable hit. Best move: ");
            printMove(entry->move);
            printf("Score: %d\n", (int) (entry->score));
#endif
            if (exactScore != NULL)
                *exactScore = entry->score;
            return entry->move;
        }
        
        auto startTime = OthelloClock::now();
        double timeSpan = 0.0;
        
        nodes = 0;
        sortBranch = 0;
        egStats->reset();
        evaluater = eval;
        timeElapsed = OthelloClock::now();
        timeout = timeLimit;
        
        MoveList scores;
        // Initial sorting of moves
        if (!isSorted && depth > 13) {
            sortSearch(b, moves, scores, s, ROOT_SORT_DEPTHS[depth]);
            
            sort(moves, scores, 0, moves.size-1);
            
            timeSpan = getTimeElapsed(startTime);
            printf("Sort search took: %f sec", timeSpan);
            printf("PV: ");
            printMove(moves.get(0));
            printf(" Score: %d\n", scores.get(0) / EG_SCALE_FACTOR);
        }
        
        startTime = OthelloClock::now();
        
        // Playing with aspiration windows...
        int32_t score;
        int32_t aspAlpha = alpha;
        int32_t aspBeta = beta;
        int32_t bestIndex = MOVE_FAIL_LOW;
        if (!isSorted && depth > 13) {
            aspAlpha = max(scores.get(0) / EG_SCALE_FACTOR - 4, alpha);
            aspBeta = min(scores.get(0) / EG_SCALE_FACTOR + 4, beta);
            // To prevent errors if our sort search score was outside [alpha, beta]
            if (aspAlpha >= beta)
                aspAlpha = beta - 2;
            if (aspBeta <= alpha)
                aspBeta = alpha + 2;
        }
        while (true) {
            // Try a search
            bestIndex = endgameAspiration(b, moves, s, depth, aspAlpha, aspBeta,
                                          score);
            // If we got broken out
            if (bestIndex == MOVE_BROKEN)
                return MOVE_BROKEN;
            // If we failed low. This is really bad :(
            if (bestIndex == MOVE_FAIL_LOW && aspAlpha > alpha) {
                // We were < than the lower bound, so this is the new upper bound
                aspBeta = score + 1;
                // Using 8 wide windows for now...
                aspAlpha = max(score - 7, alpha);
            }
            // If we failed high.
            else if (score >= aspBeta && aspBeta < beta) {
                // We were > than the upper bound, so this is the new lower bound
                aspAlpha = score - 1;
                // Using 8 wide windows for now...
                aspBeta = min(score + 7, beta);
                // Swap the cut move to the front, it's the best we have right now
                moves.swap(bestIndex, 0);
            }
            // Otherwise we are done
            else {
                break;
            }
        }
        // Retrieve the best move
        int32_t bestMove = MOVE_FAIL_LOW;
        if (bestIndex != MOVE_FAIL_LOW)
            bestMove = moves.get(bestIndex);
        
#if PRINT_SEARCH_INFO
        printf("Hashtable keys: PV=%d | A=%d | B=%d", endgameTable->keys, killerTable->keys, allTable->keys);
        
        timeSpan = getTimeElapsed(startTime);
        printf("Nodes searched: %lu | NPS: %d\n", nodes, (int32_t) ((double) nodes / timeSpan));
        
        printf("Time spent: %f\n", timeSpan);
        printf("Best move: ");
        // If we failed low on the bounds we were given, that isn't our business
        if (bestMove == MOVE_FAIL_LOW)
            printf("N/A");
        else
            printMove(bestMove);
        printf(" Score: %d\n", score);
#endif
        
        if (exactScore != NULL)
            *exactScore = score;
        return bestMove;
    }
    
    // Performs an aspiration search. Returns the index of the best move.
    int32_t Endgame::endgameAspiration(Board &b, MoveList &moves, int32_t s, int32_t depth,
                                       int32_t alpha, int32_t beta, int32_t &exactScore) {
#if PRINT_SEARCH_INFO
        printf("Aspiration search: [%d, %d]\n", alpha, beta);
#endif
        int32_t score, bestScore = -INFTY;
        // If this doesn't change, we failed low
        int32_t bestIndex = MOVE_FAIL_LOW;
        for (uint32_t i = 0; i < moves.size; i++) {
            Board copy = b.copy();
            copy.doMove(moves.get(i), s);
            nodes++;
            sortBranch = i;
            
            if (i != 0) {
                score = -dispatch(copy, s^1, depth-1, -alpha-1, -alpha);
                if (alpha < score && score < beta)
                    score = -dispatch(copy, s^1, depth-1, -beta, -alpha);
            }
            else
                score = -dispatch(copy, s^1, depth-1, -beta, -alpha);
            
            if (score == SCORE_TIMEOUT) {
#if PRINT_SEARCH_INFO
                printf("Breaking out of endgame solver.\n");
#endif
                // If we have already found a winning move, mind as well take it.
                if (bestIndex != MOVE_FAIL_LOW && alpha > 0) {
                    exactScore = alpha;
                    return bestIndex;
                }
                else
                    return MOVE_BROKEN;
            }
            
#if PRINT_SEARCH_INFO
            if (depth >= 20) {
                printf("Searched move: ");
                printMove(moves.get(i));
                printf(" | best score: %d\n", score);
            }
#endif
            
            if (score >= beta) {
                exactScore = score;
                return i;
            }
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score) {
                    alpha = score;
                    bestIndex = i;
                }
            }
        }
        
        exactScore = bestScore;
        return bestIndex;
    }
    
    // From root, this function chooses the correct helper to call.
    int32_t Endgame::dispatch(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta) {
        int32_t score;
        switch(depth) {
            case 4:
                score = endgame4(b, s, alpha, beta, false);
                break;
            case 3:
                score = endgame3(b, s, alpha, beta, false);
                break;
            case 2:
                score = endgame2(b, s, alpha, beta);
                break;
            default:
                score = endgameDeep(b, s, depth, alpha, beta, false);
                break;
        }
        return score;
    }
    
    /**
     * @brief Function for endgame solver. Used when many empty squares remain.
     * A best move table, stability cutoff, killer heuristic cutoff, sort search,
     * and fastest first are used to reduce nodes searched.
     */
    int32_t Endgame::endgameDeep(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta,
                             bool passedLast) {
        if(depth <= END_SHALLOW)
            return endgameShallow(b, s, depth, alpha, beta, passedLast);

        int32_t score, bestScore = -INFTY;
        int32_t prevAlpha = alpha;
        
        // play best move, if recorded
        EndgameEntry *exactEntry = endgameTable->get(b, s);
        if(exactEntry != NULL) {
            return exactEntry->score;
        }
        
        // Stability cutoff: if the current position is hopeless compared to a
        // known lower bound, then we need not waste time searching it.
#if USE_STABILITY
        if(alpha >= STAB_THRESHOLD[depth]) {
            score = 64 - 2*b.getStability(s^1);
            if(score <= alpha) {
                return score;
            }
        }
#endif
        
        EndgameEntry *allEntry = allTable->get(b, s);
        if(allEntry != NULL) {
            if (allEntry->score <= alpha)
                return allEntry->score;
            if (beta > allEntry->score)
                beta = allEntry->score;
        }
        
        // attempt killer heuristic cutoff, using saved alpha
        int32_t hashMove = MOVE_NULL;
        EndgameEntry *killerEntry = killerTable->get(b, s);
        if(killerEntry != NULL) {
            egStats->hashHits++;
            if (killerEntry->score >= beta) {
                egStats->hashCuts++;
                return killerEntry->score;
            }
            // Fail high is lower bound on score so this is valid
            if (alpha < killerEntry->score)
                alpha = killerEntry->score;
            hashMove = killerEntry->move;
            
            // Try the move for a cutoff before move generation
            egStats->hashMoveAttempts++;
            Board copy = b.copy();
            copy.doMove(hashMove, s);
            nodes++;
            
            score = -endgameDeep(copy, s^1, depth-1, -beta, -alpha, false);
            // If we received a timeout signal, propagate it upwards
            if (score == SCORE_TIMEOUT)
                return -SCORE_TIMEOUT;
            
            if (score >= beta) {
                egStats->hashMoveCuts++;
                return score;
            }
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score) {
                    alpha = score;
                }
            }
        }
        
        MoveList legalMoves = b.getLegalMoves(s);
        if(legalMoves.size <= 0) {
            if(passedLast) {
                return (2 * b.count(s) - 64 + depth);
            }
            
            score = -endgameDeep(b, s^1, depth, -beta, -alpha, true);
            // If we received a timeout signal, propagate it upwards
            if (score == SCORE_TIMEOUT)
                return -SCORE_TIMEOUT;
            
            return score;
        }
        
        MoveList priority;
        // Do better move ordering for PV nodes where alpha != beta - 1
        if (alpha != beta - 1) {
            // Use a shallow search for move ordering
            MoveList scores;
            sortSearch(b, legalMoves, scores, s, ENDGAME_SORT_DEPTHS[depth+2]);
            for(uint32_t i = 0; i < legalMoves.size; i++) {
                int32_t m = legalMoves.get(i);
                Board copy = b.copy();
                copy.doMove(m, s);

                int32_t p = SQ_VAL[m];
                if (m == hashMove)
                    p += 1 << 20;
                
                priority.add(scores.get(i) - 128*copy.numLegalMoves(s^1) + 8*p);
            }
        }
        // Otherwise, we focus more on fastest first for a cheaper fail-high
        else {
            MoveList scores;
            sortSearch(b, legalMoves, scores, s, ENDGAME_SORT_DEPTHS[depth]);
            // Restrict opponent's mobility and potential mobility
            for(uint32_t i = 0; i < legalMoves.size; i++) {
                int32_t m = legalMoves.get(i);
                Board copy = b.copy();
                copy.doMove(m, s);

                int32_t p = 8 * SQ_VAL[m];
                if (m == hashMove)
                    p += 1 << 20;
                
                priority.add(scores.get(i) - 2304*copy.numLegalMoves(s^1) + 32*p);
            }
        }

        int32_t tempMove = MOVE_NULL;
        uint32_t i = 0;
        for (int32_t m = nextMove(legalMoves, priority, i); m != MOVE_NULL;
             m = nextMove(legalMoves, priority, ++i)) {
            // Check for a timeout
            double timeSpan = getTimeElapsed(timeElapsed);
            if (timeSpan * 1000 > timeout)
                return -SCORE_TIMEOUT;
            // We already tried the hash move
            if (legalMoves.get(i) == hashMove)
                continue;
            Board copy = b.copy();
            copy.doMove(m, s);
            nodes++;
            
            if (i != 0) {
                score = -endgameDeep(copy, s^1, depth-1, -alpha-1, -alpha, false);
                if (alpha < score && score < beta)
                    score = -endgameDeep(copy, s^1, depth-1, -beta, -alpha, false);
            }
            else
                score = -endgameDeep(copy, s^1, depth-1, -beta, -alpha, false);
            
            // If we received a timeout signal, propagate it upwards
            if (score == SCORE_TIMEOUT)
                return -SCORE_TIMEOUT;
            if (score >= beta) {
                egStats->failHighs++;
                if (i == 0)
                    egStats->firstFailHighs++;
                killerTable->add(b, score, m, s, depth);
                return score;
            }
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score) {
                    alpha = score;
                    tempMove = m;
                }
            }
        }
        
        // Best move with exact score if alpha < score < beta
        if (tempMove != MOVE_NULL && prevAlpha < alpha && alpha < beta)
            endgameTable->add(b, alpha, tempMove, s, depth);
        else if (alpha <= prevAlpha)
            allTable->add(b, bestScore, MOVE_NULL, s, depth);
        
        return bestScore;
    }
    
    /**
     * @brief Endgame solver, to be used with about 12 or less empty squares.
     * Here, it is no longer efficient to use heavy sorting.
     * The MoveList is dropped in favor of a faster array on the stack.
     * The hash table is used until about depth 9.
     * Fastest first is used until depth 7, otherwise, moves are just sorted by
     * hole parity and piece square tables.
     */
    int32_t Endgame::endgameShallow(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta,
                                bool passedLast) {
        if(depth == 4)
            return endgame4(b, s, alpha, beta, passedLast);
        
        // Immediately return an exact score, if available
        EndgameEntry *exactEntry = endgameTable->get(b, s);
        if(exactEntry != NULL) {
            return exactEntry->score;
        }

        int32_t score, bestScore = -INFTY;
        int32_t prevAlpha = alpha;
        
#if USE_STABILITY
        if(alpha >= STAB_THRESHOLD[depth]) {
            score = 64 - 2*b.getStability(s^1);
            if(score <= alpha) {
                return score;
            }
        }
#endif

        int32_t hashMove = MOVE_NULL;
        // Probe hash tables
        if (depth >= MIN_TT_DEPTH) {
            EndgameEntry *allEntry = allTable->get(b, s);
            if(allEntry != NULL) {
                if (allEntry->score <= alpha)
                    return allEntry->score;
                if (beta > allEntry->score)
                    beta = allEntry->score;
            }
            
            EndgameEntry *killerEntry = killerTable->get(b, s);
            if(killerEntry != NULL) {
                egStats->hashHits++;
                if (killerEntry->score >= beta) {
                    egStats->hashCuts++;
                    return killerEntry->score;
                }
                if (alpha < killerEntry->score)
                    alpha = killerEntry->score;
                
                // If no score cutoff, try the hash move before move generation
                egStats->hashMoveAttempts++;
                hashMove = killerEntry->move;
                Board copy = b.copy();
                copy.doMove(hashMove, s);
                nodes++;
                
                score = -endgameShallow(copy, s^1, depth-1, -beta, -alpha, false);
                
                if (score >= beta) {
                    egStats->hashMoveCuts++;
                    egStats->failHighs++;
                    egStats->firstFailHighs++;
                    return score;
                }
                if (score > bestScore) {
                    bestScore = score;
                    if (alpha < score) {
                        alpha = score;
                    }
                }
            }
        }
        
        bitbrd legal = b.getLegal(s);
        if(!legal) {
            if(passedLast)
                return (2 * b.count(s) - 64 + depth);
            
            return -endgameShallow(b, s^1, depth, -beta, -alpha, true);
        }
        
        if (hashMove != MOVE_NULL)
            legal ^= MOVEMASK[hashMove];
        
        // create array of legal moves
        int32_t moves[END_SHALLOW];
        int32_t priority[END_SHALLOW];
        int32_t n = 0;
        
        bitbrd empty = ~b.getTaken();
        while (legal) {
            int32_t m = bitScanForward(legal);
            legal &= legal-1;
            
            priority[n] = SQ_VAL[m];
            if(!(NEIGHBORS[m] & empty))
                priority[n] += 64;
            moves[n] = m;
            n++;
        }
        
        // Only do fastest first on null window searches (non-PV nodes)
        if (depth >= 7 && (alpha == beta - 1)) {
            for(int32_t i = 0; i < n; i++) {
                Board copy = b.copy();
                copy.doMove(moves[i], s);
                
                priority[i] += -128*copy.numLegalMoves(s^1);
            }
        }
        
        // search all moves
        int32_t i = 0;
        int32_t tempMove = MOVE_NULL;
        for (int32_t move = nextMoveShallow(moves, priority, n, i); move != MOVE_NULL;
             move = nextMoveShallow(moves, priority, n, ++i)) {
            Board copy = b.copy();
            copy.doMove(move, s);
            nodes++;
            
            if (i != 0 || hashMove != MOVE_NULL) {
                score = -endgameShallow(copy, s^1, depth-1, -alpha-1, -alpha, false);
                if (alpha < score && score < beta)
                    score = -endgameShallow(copy, s^1, depth-1, -beta, -alpha, false);
            }
            else
                score = -endgameShallow(copy, s^1, depth-1, -beta, -alpha, false);
            
            if (score >= beta) {
                egStats->failHighs++;
                if (i == 0)
                    egStats->firstFailHighs++;
                if (depth >= MIN_TT_DEPTH)
                    killerTable->add(b, score, move, s, depth);
                return score;
            }
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score) {
                    alpha = score;
                    tempMove = move;
                }
            }
        }
        
        // Best move with exact score if alpha < score < beta
        if (tempMove != MOVE_NULL && prevAlpha < alpha && alpha < beta)
            endgameTable->add(b, alpha, tempMove, s, depth);
        else if (depth >= MIN_TT_DEPTH && prevAlpha == alpha)
            allTable->add(b, bestScore, MOVE_NULL, s, depth);
        
        return bestScore;
    }
    
    /**
     * @brief Endgame solver, to be used with exactly 4 empty squares.
     * Starting with 4 moves left, a special legal moves generator that sorts by
     * hole parity is called.
     */
    int32_t Endgame::endgame4(Board &b, int32_t s, int32_t alpha, int32_t beta, bool passedLast) {
        int32_t score, bestScore = -INFTY;
        int32_t legalMoves[4];
        int32_t n = b.getLegalMoves4(s, legalMoves);
        
        if (n == 0) {
            if (passedLast)
                return (2 * b.count(s) - 60);
            
            return -endgame4(b, s^1, -beta, -alpha, true);
        }
        
        for (int32_t i = 0; i < n; i++) {
            Board copy = b.copy();
            copy.doMove(legalMoves[i], s);
            nodes++;
            
            if (i != 0) {
                score = -endgame3(copy, s^1, -alpha-1, -alpha, false);
                if (alpha < score && score < beta)
                    score = -endgame3(copy, s^1, -beta, -alpha, false);
            }
            else
                score = -endgame3(copy, s^1, -beta, -alpha, false);
            
            if (score >= beta)
                return score;
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score)
                    alpha = score;
            }
        }
        
        return bestScore;
    }
    
    /**
     * @brief Endgame solver, to be used with exactly 3 empty squares.
     */
    int32_t Endgame::endgame3(Board &b, int32_t s, int32_t alpha, int32_t beta, bool passedLast) {
        int32_t score, bestScore = -INFTY;
        int32_t legalMoves[3];
        int32_t n = b.getLegalMoves3(s, legalMoves);
        
        if (n == 0) {
            if (passedLast)
                return (2 * b.count(s) - 61);
            
            return -endgame3(b, s^1, -beta, -alpha, true);
        }
        
        for (int32_t i = 0; i < n; i++) {
            Board copy = b.copy();
            copy.doMove(legalMoves[i], s);
            nodes++;
            
            if (i != 0) {
                score = -endgame2(copy, s^1, -alpha-1, -alpha);
                if (alpha < score && score < beta)
                    score = -endgame2(copy, s^1, -beta, -alpha);
            }
            else
                score = -endgame2(copy, s^1, -beta, -alpha);
            
            if (score >= beta)
                return score;
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score)
                    alpha = score;
            }
        }
        
        return bestScore;
    }
    
    /**
     * @brief Endgame solver, to be used with exactly 2 empty squares.
     * Null window searches are no longer performed here.
     */
    int32_t Endgame::endgame2(Board &b, int32_t s, int32_t alpha, int32_t beta) {
        int32_t score = -INFTY, bestScore = -INFTY;
        bitbrd empty = ~b.getTaken();
        bitbrd opp = b.getBits(s^1);
        
        // At 2 squares left, it is more efficient to simply try moves on both
        // squares. This approach was based on Richard Delorme's Edax-Reversi.
        int32_t lm1 = bitScanForward(empty);
        empty &= empty-1;
        int32_t lm2 = bitScanForward(empty);
        
        bitbrd changeMask;
        
        if ((opp & NEIGHBORS[lm1]) && (changeMask = b.getDoMove(lm1, s))) {
            b.makeMove(lm1, changeMask, s);
            nodes++;
            score = -endgame1(b, s^1, -beta, lm2);
            b.undoMove(lm1, changeMask, s);
            
            if (score >= beta)
                return score;
            if (score > bestScore)
                bestScore = score;
        }
        
        if ((opp & NEIGHBORS[lm2]) && (changeMask = b.getDoMove(lm2, s))) {
            b.makeMove(lm2, changeMask, s);
            nodes++;
            score = -endgame1(b, s^1, -beta, lm1);
            b.undoMove(lm2, changeMask, s);
            
            if (score >= beta)
                return score;
            if (score > bestScore)
                bestScore = score;
        }
        
        // if no legal moves... try other player
        if (score == -INFTY) {
            bestScore = INFTY;
            opp = b.getBits(s);
            
            if ((opp & NEIGHBORS[lm1]) && (changeMask = b.getDoMove(lm1, s^1))) {
                b.makeMove(lm1, changeMask, s^1);
                nodes++;
                score = endgame1(b, s, alpha, lm2);
                b.undoMove(lm1, changeMask, s^1);
                
                if (alpha >= score)
                    return score;
                if (score < bestScore)
                    bestScore = score;
            }
            
            if ((opp & NEIGHBORS[lm2]) && (changeMask = b.getDoMove(lm2, s^1))) {
                b.makeMove(lm2, changeMask, s^1);
                nodes++;
                score = endgame1(b, s, alpha, lm1);
                b.undoMove(lm2, changeMask, s^1);
                
                if (alpha >= score)
                    return score;
                if (score < bestScore)
                    bestScore = score;
            }
            
            // if both players passed, game over
            if (score == -INFTY)
                return (2 * b.count(s) - 62);
        }
        
        return bestScore;
    }
    
    /**
     * @brief Endgame solver, to be used with exactly 1 empty square.
     */
    int32_t Endgame::endgame1(Board &b, int32_t s, int32_t alpha, int32_t legalMove) {
        // Get a stand pat score
        int32_t score = 2 * b.count(s) - 63;
        
        bitbrd changeMask = b.getDoMove(legalMove, s);
        nodes++;
        // If the player "s" can move, calculate final score
        if (changeMask) {
            score += 2 * countSetBits(changeMask) + 1;
        }
        // Otherwise, it is the opponent's move. If the opponent can stand pat,
        // we don't need to calculate the final score.
        else if (score >= alpha) {
            bitbrd otherMask = b.getDoMove(legalMove, s^1);
            nodes++;
            if (otherMask)
                score -= 2 * countSetBits(otherMask) + 1;
        }
        // If both players passed, the empty square should not count against us
        //else
        //    score++;
        
        return score;
    }
    
    //--------------------------------Sort Search-----------------------------------
    
    // Performs an alpha-beta search on each legal move to get a score.
    void Endgame::sortSearch(Board &b, MoveList &moves, MoveList &scores, int32_t side,
                             int32_t depth) {
        for (uint32_t i = 0; i < moves.size; i++) {
            Board copy = b.copy();
            copy.doMove(moves.get(i), side);
            egStats->sortSearchNodes++;
            scores.add(-pvs(copy, side^1, depth-1, -INFTY, INFTY));
        }
    }
    
    // Helper function for the alpha-beta search.
    int32_t Endgame::pvs(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta) {
        if (depth <= 0) {
            return (s == CBLACK) ? evaluater->end_heuristic(b)
            : -evaluater->end_heuristic(b);
        }

        int32_t score;
        int32_t prevAlpha = alpha;
        int32_t hashed = MOVE_NULL;
        int32_t toHash = MOVE_NULL;
        
        // Probe transposition table for a score or move
        // Only do this at and above depth 3 for speed
        if (depth >= 3) {
            BoardData *entry = transpositionTable->get(b, s);
            if (entry != NULL) {
                if (entry->nodeType == ALL_NODE) {
                    if (entry->depth >= depth && entry->score <= alpha)
                        return alpha;
                }
                else {
                    if (entry->depth >= depth) {
                        if (entry->nodeType == CUT_NODE && entry->score >= beta)
                            return beta;
                        else if (entry->nodeType == PV_NODE)
                            return entry->score;
                    }
                    
                    hashed = entry->move;
                    Board copy = b.copy();
                    copy.doMove(hashed, s);
                    egStats->sortSearchNodes++;
                    
                    score = -pvs(copy, s^1, depth-1, -beta, -alpha);
                    
                    if (alpha < score)
                        alpha = score;
                    if (alpha >= beta)
                        return beta;
                }
            }
        }
        
        // We want to do better move ordering at PV nodes where alpha != beta - 1
        bool isPVNode = (alpha != beta - 1);
        
        MoveList legalMoves = b.getLegalMoves(s);
        if (legalMoves.size <= 0) {
            score = -pvs(b, s^1, depth-1, -beta, -alpha);
            
            if (alpha < score)
                alpha = score;
            
            return alpha;
        }
        
        // Do internal iterative deepening
        if (depth >= 2) {
            MoveList scores;
            if (depth >= 4 && isPVNode)
                sortSearch(b, legalMoves, scores, s, (depth-1)/2);
            else if (depth >= 5) {
                sortSearch(b, legalMoves, scores, s, (depth-1)/3);
                // Apparently fastest first works in sort searches too...
                for (uint32_t i = 0; i < legalMoves.size; i++) {
                    Board copy = b.copy();
                    copy.doMove(legalMoves.get(i), s);
                    scores.set(i, scores.get(i) - 1024*copy.numLegalMoves(s^1));
                }
            }
            else if (depth >= 3) {
                for (uint32_t i = 0; i < legalMoves.size; i++) {
                    Board copy = b.copy();
                    copy.doMove(legalMoves.get(i), s);
                    scores.add(SQ_VAL[legalMoves.get(i)] - 16*copy.numLegalMoves(s^1));
                }
            }
            else {
                for (uint32_t i = 0; i < legalMoves.size; i++)
                    scores.add(SQ_VAL[legalMoves.get(i)]);
            }
            sort(legalMoves, scores, 0, legalMoves.size-1);
        }
        
        for (uint32_t i = 0; i < legalMoves.size; i++) {
            int32_t m = legalMoves.get(i);
            /*uint32_t i = 0;
             for (int32_t m = nextMove(legalMoves, scores, i); m != MOVE_NULL;
             m = nextMove(legalMoves, scores, ++i)) {*/
            if (hashed == m)
                continue;
            Board copy = b.copy();
            copy.doMove(m, s);
            egStats->sortSearchNodes++;
            
            if (depth > 2 && i != 0) {
                score = -pvs(copy, s^1, depth-1, -alpha-1, -alpha);
                if (alpha < score && score < beta)
                    score = -pvs(copy, s^1, depth-1, -beta, -alpha);
            }
            else
                score = -pvs(copy, s^1, depth-1, -beta, -alpha);
            
            if (alpha < score) {
                alpha = score;
                toHash = m;
            }
            if (alpha >= beta) {
                if(depth >= 4)
                    transpositionTable->add(b, beta, m, s, sortBranch, depth,
                                            CUT_NODE);
                return beta;
            }
        }
        
        if (depth >= 4 && toHash != MOVE_NULL && prevAlpha < alpha && alpha < beta)
            transpositionTable->add(b, alpha, toHash, s, sortBranch, depth, PV_NODE);
        else if (depth >= 4 && alpha <= prevAlpha)
            transpositionTable->add(b, alpha, MOVE_NULL, s, sortBranch, depth, ALL_NODE);
        
        return alpha;
    }
    
    //--------------------------------Utilities-------------------------------------
    
    // Retrieves the next move with the highest score, starting from index using a
    // partial selection sort. This way, the entire list does not have to be sorted
    // if an early cutoff occurs.
    int32_t Endgame::nextMoveShallow(int32_t *moves, int32_t *scores, int32_t size, int32_t index) {
        if (index >= size)
            return MOVE_NULL;
        // Find the index of the next best move/score
        int32_t bestIndex = index;
        for (int32_t i = index + 1; i < size; i++) {
            if (scores[i] > scores[bestIndex]) {
                bestIndex = i;
            }
        }
        // swap to the correct position
        int32_t tempMove = moves[bestIndex];
        moves[bestIndex] = moves[index];
        moves[index] = tempMove;
        int32_t tempScore = scores[bestIndex];
        scores[bestIndex] = scores[index];
        scores[index] = tempScore;
        // return the move
        return moves[index];
    }
}
