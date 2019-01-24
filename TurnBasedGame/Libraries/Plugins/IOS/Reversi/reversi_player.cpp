#include <algorithm>
#include <cmath>
#include <iostream>
#include "reversi_player.hpp"
#include "reversi_jni.hpp"
#include "reversi_PRNG.hpp"

using namespace std;

namespace Reversi
{
    const int32_t TIMEOUT = (1 << 21);
    const int32_t EVAL_SCALE_FACTOR = 2000;
    
    /**
     * @brief Constructor for the player.
     *
     * This constructor initializes the depths, timing variables, and the array
     * used to convert move indices to move objects.
     *
     * @param side The side the AI is playing as.
     */
    Player::Player(Side side) {
        maxDepth = 28;
        minDepth = 4;
        sortDepth = 2;
        endgameDepth = 36;
        lastMaxDepth = 0;
        
        mySide = (side == BLACK) ? CBLACK : CWHITE;
        turn = 4;
        
        // initialize the evaluation functions
        evaluater = new Eval();
        otherHeuristic = false;
        
        // Initialize transposition table with 2^20 = 1 million array slots and
        // 2 * 2^20 = 2 million entries
        transpositionTable = new Hash(20);
        
        // Set to false to turn on book
        bookExhausted = false;
    }
    
    /**
     * @brief Destructor for the player.
     */
    Player::~Player() {
        delete evaluater;
        delete transpositionTable;
    }
    
    /**
     * @brief Processes opponent's last move and selects a best move to play.
     *
     * This function delegates all necessary tasks to the appropriate helper
     * functions. It first processes the opponent's move. It then checks the opening
     * book for a move, then the endgame solver, and finally begins an iterative
     * deepening principal variation null window search.
     *
     * @param opponentsMove The last move the opponent made.
     * @param msLeft Total milliseconds left for the game, -1 if untimed.
     * @return The move the AI chose to play.
     */
    Move *Player::doMove(Move *opponentsMove, int32_t msLeft) {
#if PRINT_SEARCH_INFO
        printf("\n");
#endif
        // register opponent's move
        if (opponentsMove != NULL)
            game.doMove(opponentsMove->getX() + 8*opponentsMove->getY(), mySide^1);
        // If opponent is passing and it isn't the start of the game
        else if (turn != 4) {
            // TODO a temporary hack to prevent opening book from crashing
            bookExhausted = true;
        }
        
        // We can easily count how many moves have been made from the number of
        // empty squares
        int32_t empties = game.countEmpty();
        turn = 64 - empties;
        // Reset node count. Nodes are counted in the most conservative way (only
        // when doMove() is called), so that pruning does not inflate node counts.
        nodes = 0;
        
        // Timing
        if (msLeft != -1) {
            // Time odds, if desired
            //msLeft -= 600000;
            // Buffer time: to prevent losses on time at short time controls
            if (empties > 14) {
                msLeft -= 500 + 120*empties;
                msLeft = max(1, msLeft);
            }
            
            // Base fair time usage off of number of moves left
            int32_t movesLeft = min(max(1, empties / 2), 20);
            // Use up to 3x "fair" time
            timeLimit = 6 * msLeft / (2 * movesLeft);
#if PRINT_SEARCH_INFO
            printf("Time limit: %f s\n", timeLimit / 1000.0);
#endif
        }
        else {
            // 10 min per move for "infinite" time
            timeLimit = 600000;
        }
        
        // check opening book
        if (!bookExhausted) {
            int32_t openMove = openingBook.get(game.getTaken(), game.getBits(CBLACK));
            if (openMove != OPENING_NOT_FOUND) {
#if PRINT_SEARCH_INFO
                printf("Opening book: bestmove ");
                printMove(openMove);
                printf("\n\n");
#endif
                game.doMove(openMove, mySide);
                return indexToMove(openMove);
            }
            else
                bookExhausted = true;
        }
        
        
        // find and test all legal moves
        MoveList legalMoves = game.getLegalMoves(mySide);
        if (legalMoves.size <= 0) {
            // TODO a temporary hack to prevent opening book from crashing
            bookExhausted = true;
#if PRINT_SEARCH_INFO
            printf("No legal moves. Passing.\n\n");
#endif
            return NULL;
        }
        
        if (legalMoves.size == 1) {
#if PRINT_SEARCH_INFO
            printf("One legal move: ");
            printMove(legalMoves.get(0));
            printf("\n\n");
#endif
            game.doMove(legalMoves.get(0), mySide);
            return indexToMove(legalMoves.get(0));
        }


        int32_t myMove = MOVE_BROKEN;
        
        // Endgame solver: if we are within sight of the end and we have enough
        // time to do a perfect solve (estimated by lastMaxDepth) or have unlimited
        // time. Always use endgame solver for the last 14 plies since it is faster
        // and for more accurate results.
        if (empties <= endgameDepth
            && (lastMaxDepth + 4 >= empties || msLeft == -1 || empties <= 14)) {
            // Timing: use a quarter of remaining time for the endgame solve attempt
            int32_t endgameLimit = (msLeft == -1) ? 100000000
            : msLeft / 4;
#if PRINT_SEARCH_INFO
            printf("Endgame solver: depth %d\n", empties);
#endif
            
            myMove = endgameSolver.solveEndgame(game, legalMoves, false, mySide,
                                                empties, endgameLimit, evaluater);
            
            if (myMove != MOVE_BROKEN) {
                game.doMove(myMove, mySide);
                return indexToMove(myMove);
            }
            // Otherwise, we broke out of the endgame solver.
            endgameDepth -= 2;
            timeLimit = 2 * timeLimit / 3;
        }
        
        // Start timers
        auto startTime = OthelloClock::now();
        timeElapsed = OthelloClock::now();
        double timeSpan = 0.0;
        
        // Root move ordering: sort search
        MoveList scores;
        sortSearch(game, legalMoves, scores, mySide, sortDepth);
        sort(legalMoves, scores, 0, legalMoves.size-1);
        scores.clear();
        
        // Iterative deepening
        int32_t rootDepth = minDepth;
        lastMaxDepth = minDepth;
        int32_t newBest;
        // Estimate of next branch factor
        int32_t nextBF;
        do {
            printf("Depth: %d\n", rootDepth);
            
            newBest = getBestMoveIndex(game, legalMoves, scores, mySide,
                                       rootDepth);
            if (newBest == MOVE_BROKEN) {
#if PRINT_SEARCH_INFO
                printf(" Broken out of search!\n");
#endif
                timeSpan = getTimeElapsed(startTime);
                break;
            }
            lastMaxDepth = rootDepth;
            
            // Switch new PV to be searched first
            legalMoves.swap(0, newBest);
            scores.swap(0, newBest);
            rootDepth += 2;
            myMove = legalMoves.get(0);
            
#if PRINT_SEARCH_INFO
            printf("bestmove ");
            printMove(myMove);
            printf(" score %f\n", ((double) scores.get(0)) / EVAL_SCALE_FACTOR);
#endif
            
            // Estimate next move's branch factor
            Board copy = game.copy();
            copy.doMove(legalMoves.get(0), mySide);
            nextBF = copy.numLegalMoves(mySide^1);
            
            timeSpan = getTimeElapsed(startTime);
            
            // print score
            /*{
             for(int32_t i=0; i<legalMoves.size; i++){
             char strMove[3];
             int32_t move = legalMoves.moves[i];
             printMove(move, strMove);
             int32_t score = scores.get(i);
             float fScore = ((double) score) / EVAL_SCALE_FACTOR;
             printf("print score: %d(%s): %d, %f\n", move, strMove, score, fScore);
             }
             }*/
            // Continue while we think we can finish the next depth within our
            // allotted time for this move. Based on a crude estimate of branch factor.
        } while ((timeLimit > timeSpan * 1000.0 * sqrt(legalMoves.size * nextBF) * 3 / 4)
                 && rootDepth <= maxDepth);
        
        // The best move should be at the front of the list.
        myMove = legalMoves.get(0);
        
        // WLD confirmation at high depths
        if (empties <= endgameDepth + 2
            && (lastMaxDepth + 6 >= empties || msLeft == -1)
            && empties > 14
            && timeSpan < timeLimit) {
            // Timing: use 1/6 of remaining time for the WLD solve
            int32_t endgameLimit = (msLeft == -1) ? 100000000
            : msLeft / 6;
            int32_t WLDMove = endgameSolver.solveWLD(game, legalMoves, true, mySide,
                                                 empties, endgameLimit, evaluater);
            
            if (WLDMove != MOVE_BROKEN) {
                if (WLDMove != -1 && myMove != WLDMove) {
#if PRINT_SEARCH_INFO
                    printf("Move changed to ");
                    printMove(WLDMove);
                    printf("\n");
#endif
                    myMove = WLDMove;
                }
            }
            // If we broke out of WLD here next move's endgame solver isn't likely
            // to be successful...
            else {
                lastMaxDepth -= 4;
            }
        }
        
        // Heh. Heh. Heh.
        if (scores.get(0) > 60 * EVAL_SCALE_FACTOR)
            lastMaxDepth += 6;
        
        timeSpan = getTimeElapsed(startTime);
/*#if PRINT_SEARCH_INFO
        printf("Time spent: %f s\n", timeSpan);
        printf("Nodes searched: %llu | NPS: %d\n", nodes, (int) ((double) nodes / timeSpan));
        printf("Table contains %d entries.\n", transpositionTable->keys);
        printf("Playing ");
        printMove(myMove);
        printf(". Score: %f\n\n", ((double) scores.get(0)) / EVAL_SCALE_FACTOR);
#endif*/
        
        game.doMove(myMove, mySide);
        
        return indexToMove(myMove);
    }
    
    int8_t Player::myDoMove(int32_t msLeft) {
#if PRINT_SEARCH_INFO
        printf("\n");
#endif
        // If opponent is passing and it isn't the start of the game
        /*if (turn != 4) {
         // TODO a temporary hack to prevent opening book from crashing
         bookExhausted = true;
         }*/
        
        // We can easily count how many moves have been made from the number of
        // empty squares
        int32_t empties = game.countEmpty();
        turn = 64 - empties;
        // Reset node count. Nodes are counted in the most conservative way (only
        // when doMove() is called), so that pruning does not inflate node counts.
        nodes = 0;
        
        // Timing
        if (msLeft != -1) {
            // Time odds, if desired
            //msLeft -= 600000;
            // Buffer time: to prevent losses on time at short time controls
            if (empties > 14) {
                msLeft -= 500 + 120*empties;
                msLeft = max(1, msLeft);
            }
            
            // Base fair time usage off of number of moves left
            int32_t movesLeft = min(max(1, empties / 2), 20);
            // Use up to 3x "fair" time
            timeLimit = 6 * msLeft / (2 * movesLeft);
#if PRINT_SEARCH_INFO
            printf("Time limit: %f s\n", timeLimit / 1000.0);
#endif
        }
        else {
            // 10 min per move for "infinite" time
            timeLimit = 600000;
        }
        
        // check opening book
        if(useBook){
            if (!bookExhausted) {
                int32_t openMove = openingBook.get(game.getTaken(), game.getBits(CBLACK));
                if (openMove != OPENING_NOT_FOUND) {
#if PRINT_SEARCH_INFO
                    printf("Opening book: bestmove ");
                    printMove(openMove);
                    printf("\n\n");
#endif
                    return openMove;
                }
                else
                    bookExhausted = true;
            }
        }
        
        // find and test all legal moves
        MoveList legalMoves = game.getLegalMoves(mySide);
        if (legalMoves.size <= 0) {
            // TODO a temporary hack to prevent opening book from crashing
            bookExhausted = true;
/*#if PRINT_SEARCH_INFO
            printf("No legal moves. Passing.\n\n");
#endif*/
            return 0;
        }
        
        if (legalMoves.size == 1) {
#if PRINT_SEARCH_INFO
            printf("One legal move: ");
            printMove(legalMoves.get(0));
            printf("\n\n");
#endif
            game.doMove(legalMoves.get(0), mySide);
            return legalMoves.get(0);
        }


        int32_t myMove = MOVE_BROKEN;
        
        // Endgame solver: if we are within sight of the end and we have enough
        // time to do a perfect solve (estimated by lastMaxDepth) or have unlimited
        // time. Always use endgame solver for the last 14 plies since it is faster
        // and for more accurate results.
        if (empties <= endgameDepth
            && (lastMaxDepth + 4 >= empties || msLeft == -1 || empties <= 14)) {
            // Timing: use a quarter of remaining time for the endgame solve attempt
            int32_t endgameLimit = (msLeft == -1) ? 100000000
            : msLeft / 4;
#if PRINT_SEARCH_INFO
            printf("Endgame solver: depth %d\n", empties);
#endif
            
            myMove = endgameSolver.solveEndgame(game, legalMoves, false, mySide,
                                                empties, endgameLimit, evaluater);
            
            if (myMove != MOVE_BROKEN) {
                game.doMove(myMove, mySide);
                return myMove;
            }
            // Otherwise, we broke out of the endgame solver.
            endgameDepth -= 2;
            timeLimit = 2 * timeLimit / 3;
        }
        
        // Start timers
        auto startTime = OthelloClock::now();
        timeElapsed = OthelloClock::now();
        double timeSpan = 0.0;
        
        // Root move ordering: sort search
        MoveList scores;
        sortSearch(game, legalMoves, scores, mySide, sortDepth);
        sort(legalMoves, scores, 0, legalMoves.size-1);
        scores.clear();
        
        // Iterative deepening
        int32_t rootDepth = minDepth;
        lastMaxDepth = minDepth;
        int32_t newBest;
        // Estimate of next branch factor
        int32_t nextBF;
        do {
            printf("Depth %d:\n", rootDepth);
            
            newBest = getBestMoveIndex(game, legalMoves, scores, mySide,
                                       rootDepth);
            if (newBest == MOVE_BROKEN) {
#if PRINT_SEARCH_INFO
                printf(" Broken out of search!\n");
#endif
                timeSpan = getTimeElapsed(startTime);
                break;
            }
            lastMaxDepth = rootDepth;
            
            // Switch new PV to be searched first
            legalMoves.swap(0, newBest);
            scores.swap(0, newBest);
            rootDepth += 2;
            myMove = legalMoves.get(0);
            
#if PRINT_SEARCH_INFO
            printf("bestmove ");
            printMove(myMove);
            printf(" score %f\n", ((double) scores.get(0)) / EVAL_SCALE_FACTOR);
#endif
            
            // Estimate next move's branch factor
            Board copy = game.copy();
            copy.doMove(legalMoves.get(0), mySide);
            nextBF = copy.numLegalMoves(mySide^1);
            
            timeSpan = getTimeElapsed(startTime);
            
            // print score
            /*{
             for(int32_t i=0; i<legalMoves.size; i++){
             char strMove[3];
             int32_t move = legalMoves.moves[i];
             printMove(move, strMove);
             int32_t score = scores.get(i);
             float fScore = ((double) score) / EVAL_SCALE_FACTOR;
             printf("print score: %d(%s): %d, %f\n", move, strMove, score, fScore);
             }
             }*/
            
            // Continue while we think we can finish the next depth within our
            // allotted time for this move. Based on a crude estimate of branch factor.
        } while ((timeLimit > timeSpan * 1000.0 * sqrt(legalMoves.size * nextBF) * 3 / 4)
                 && rootDepth <= maxDepth);
        
        // The best move should be at the front of the list.
        myMove = legalMoves.get(0);
        
        // WLD confirmation at high depths
        if (empties <= endgameDepth + 2
            && (lastMaxDepth + 6 >= empties || msLeft == -1)
            && empties > 14
            && timeSpan < timeLimit) {
            // Timing: use 1/6 of remaining time for the WLD solve
            int32_t endgameLimit = (msLeft == -1) ? 100000000
            : msLeft / 6;
            int32_t WLDMove = endgameSolver.solveWLD(game, legalMoves, true, mySide,
                                                 empties, endgameLimit, evaluater);
            
            if (WLDMove != MOVE_BROKEN) {
                if (WLDMove != -1 && myMove != WLDMove) {
#if PRINT_SEARCH_INFO
                    printf("Move changed to ");
                    printMove(WLDMove);
                    printf("\n");
#endif
                    myMove = WLDMove;
                }
            }
            // If we broke out of WLD here next move's endgame solver isn't likely
            // to be successful...
            else {
                lastMaxDepth -= 4;
            }
        }
        
        // Heh. Heh. Heh.
        if (scores.get(0) > 60 * EVAL_SCALE_FACTOR)
            lastMaxDepth += 6;
        
        timeSpan = getTimeElapsed(startTime);
/*#if PRINT_SEARCH_INFO
        printf("Time spent: %f s\n", timeSpan);
        printf("Nodes searched: %llu | NPS: %d\n", nodes, (int) ((double) nodes / timeSpan));
        printf("Table contains %d entries.\n", transpositionTable->keys);
        printf("Playing ");
        printMove(myMove);
        printf(". Score: %f\n\n", ((double) scores.get(0)) / EVAL_SCALE_FACTOR);
#endif*/
        
        game.doMove(myMove, mySide);
        
        return myMove;
    }

    int32_t Player::randomScore(int32_t score)
    {
        static PRNG rng(now());
        if(percent>=100 || percent<0){
            return score;
        }else{
            int32_t changePercent = 100 - this->percent;
            int32_t temp = rng.rand<int>()%changePercent;
            int32_t newScore = score + temp*score/100;
            // printf("random score: %d, %d, %d\n", temp, score, newScore);
            return newScore;
        }
    }
    
    /**
     * @brief Performs a principal variation null-window search.
     * Returns the index of the best move.
     */
    int32_t Player::getBestMoveIndex(Board &b, MoveList &moves, MoveList &scores, int32_t s,
                                     int32_t depth) {
        int32_t score;
        int32_t bestMove = MOVE_BROKEN;
        int32_t alpha = -INFTY;
        int32_t beta = INFTY;
        
        for (uint32_t i = 0; i < moves.size; i++) {
            Board copy = b.copy();
            copy.doMove(moves.get(i), s);
            nodes++;
            if (i != 0) {
                score = -pvs(copy, s^1, depth-1, -alpha-1, -alpha, false);
                // TODO test
                score = randomScore(score);
                // alpha, beta
                if (alpha < score && score < beta){
                    score = -pvs(copy, s^1, depth-1, -beta, -alpha, false);
                }
            }
            else{
                score = -pvs(copy, s^1, depth-1, -beta, -alpha, false);
            }
            // Handle timeouts
            if (score == TIMEOUT)
                return MOVE_BROKEN;
            
            scores.set(i, score);
            if (score > alpha) {
                // print score
                /*{
                 char strMove[3];
                 printMove(moves.get(i), strMove);
                 printf("new score: %d(%s): %d, %d, %d\n", moves.get(i), strMove, score, i, bestMove);
                 }*/
                alpha = score;
                bestMove = i;
            }else if(score==alpha){
                // print = score
                /*{
                 char strMove[3];
                 printMove(moves.get(i), strMove);
                 printf("new same score: %d(%s): %d, %d\n", moves.get(i), strMove, score, i);
                 }*/
            } else if(score<alpha){
                // print < score
                /*{
                 char strMove[3];
                 printMove(moves.get(i), strMove);
                 printf("new < score: %d(%s): %d, %d, %d\n", moves.get(i), strMove, score, i, bestMove);
                 }*/
            }
        }
        
        // print score
        /*{
         for(int32_t i=0; i<moves.size; i++){
         char strMove[3];
         int32_t move = moves.moves[i];
         printMove(move, strMove);
         int32_t score = scores.get(i);
         float fScore = ((double) score) / EVAL_SCALE_FACTOR;
         printf("print score: %d(%s): %d, %f\n", move, strMove, score, fScore);
         }
         }*/
        
        return bestMove;
    }
    
    /**
     * @brief Helper function for the principal variation search.
     *
     * Uses alpha-beta pruning with a null-window search, a transposition table that
     * stores moves from at least depth 4, and internal iterative deepening,
     * fastest first, and a piece-square table for move ordering.
     */
    int32_t Player::pvs(Board &b, int32_t s, int32_t depth, int32_t alpha, int32_t beta, bool passedLast) {
        if (depth <= 0) {
            if (otherHeuristic)
                return evaluater->heuristic2(b, s);
            else
                return evaluater->heuristic(b, s);
        }

        int32_t score, bestScore = -INFTY;
        int32_t prevAlpha = alpha;
        int32_t hashed = MOVE_NULL;
        int32_t toHash = MOVE_NULL;
        
        // We want to do better move ordering at PV nodes where alpha != beta - 1
        bool isPVNode = (alpha != beta - 1);
        
        // Probe transposition table for a score or move
        // Do this only at depth 3 and above for efficiency
        if (depth >= 3) {
            BoardData *entry = transpositionTable->get(b, s);
            if (entry != NULL) {
                // For all-nodes, we only have an upper bound score
                if (entry->nodeType == ALL_NODE) {
                    if (entry->depth >= depth && entry->score <= alpha)
                        return entry->score;
                }
                else {
                    if (entry->depth >= depth) {
                        // For cut-nodes, we have a lower bound score
                        if (entry->nodeType == CUT_NODE && entry->score >= beta)
                            return entry->score;
                        // For PV-nodes, we have an exact score we can return
                        else if (entry->nodeType == PV_NODE && !isPVNode)
                            return entry->score;
                    }
                    // Try the hash move first
                    hashed = entry->move;
                    Board copy = b.copy();
                    copy.doMove(hashed, s);
                    nodes++;
                    score = -pvs(copy, s^1, depth-1, -beta, -alpha, false);
                    
                    // If we received a timeout signal, propagate it upwards
                    if (score == TIMEOUT)
                        return -TIMEOUT;
                    if (score >= beta)
                        return score;
                    if (score > bestScore) {
                        bestScore = score;
                        if (alpha < score)
                            alpha = score;
                    }
                }
            }
        }
        
        // Prob-cut
        if (!isPVNode
            && depth >= 6) {
            int32_t mpcAlpha = alpha - 2*EVAL_SCALE_FACTOR - abs(alpha)/4;
            int32_t mpcScore = pvs(b, s, depth-4, mpcAlpha, mpcAlpha+1, passedLast);
            if (mpcScore <= mpcAlpha)
                return alpha;
        }
        
        MoveList legalMoves = b.getLegalMoves(s);
        if (legalMoves.size <= 0) {
            if (passedLast) {
                int32_t ourCt = b.count(s);
                int32_t theirCt = b.count(s^1);
                if (ourCt > theirCt)
                    return WIPEOUT + ourCt - theirCt;
                else if (ourCt < theirCt)
                    return -WIPEOUT + ourCt - theirCt;
                else return 0;
            }
            
            score = -pvs(b, s^1, depth, -beta, -alpha, true);
            
            // If we received a timeout signal, propagate it upwards
            if (score == TIMEOUT)
                return -TIMEOUT;
            
            return score;
        }
        
        // Move ordering
        // Don't waste time sorting at depth 1.
        if (depth >= 2) {
            sortMoves(b, legalMoves, s, depth, alpha, isPVNode);
        }
        
        for (uint32_t i = 0; i < legalMoves.size; i++) {
            // Check for a timeout
            if (getTimeElapsed(timeElapsed) * 1000 > timeLimit)
                return -TIMEOUT;
            
            if (legalMoves.get(i) == hashed)
                continue;
            Board copy = b.copy();
            copy.doMove(legalMoves.get(i), s);
            nodes++;

            int32_t reduction = 0;
            if (!isPVNode && depth >= 5 && i > 2) {
                reduction = 1 + (depth-5) / 5 + (i-3) / 6;
            }
            
            if (depth > 2 && i != 0) {
                score = -pvs(copy, s^1, depth-1-reduction, -alpha-1, -alpha, false);
                if (reduction > 0 && score > alpha)
                    score = -pvs(copy, s^1, depth-1, -alpha-1, -alpha, false);
                if (alpha < score && score < beta)
                    score = -pvs(copy, s^1, depth-1, -beta, -alpha, false);
            }
            else
                score = -pvs(copy, s^1, depth-1, -beta, -alpha, false);
            
            // If we received a timeout signal, propagate it upwards
            if (score == TIMEOUT)
                return -TIMEOUT;
            if (score >= beta) {
                if(depth >= 4)
                    transpositionTable->add(b, score, legalMoves.get(i), s,
                                            turn, depth, CUT_NODE);
                return score;
            }
            if (score > bestScore) {
                bestScore = score;
                if (alpha < score) {
                    alpha = score;
                    toHash = legalMoves.get(i);
                }
            }
        }
        
        if (depth >= 4 && toHash != MOVE_NULL && prevAlpha < alpha && alpha < beta)
            transpositionTable->add(b, alpha, toHash, s, turn, depth, PV_NODE);
        else if (depth >= 4 && alpha <= prevAlpha)
            transpositionTable->add(b, bestScore, MOVE_NULL, s, turn, depth, ALL_NODE);
        
        return bestScore;
    }
    
    /**
     * @brief Sorts moves based on depth and whether the moves came from a PV node.
     * A shallow sort search (a form of internal iterative deepening) is used along
     * with fastest first (restricting opponent's mobility to reduce branch factor
     * and get the cheapest possible cutoff).
     */
    void Player::sortMoves(Board &b, MoveList &legalMoves, int32_t s, int32_t depth,
                           int32_t alpha, bool isPVNode) {
        // internal iterative deepening
        MoveList scores;
        
        if (depth >= 4 && isPVNode)
            sortSearch(b, legalMoves, scores, s, (depth-1)/2);
        else if (depth >= 5) {
            sortSearch(b, legalMoves, scores, s, (depth-1)/3);
            // Fastest first
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
    
    void Player::sortSearch(Board &b, MoveList &moves, MoveList &scores, int32_t side,
                            int32_t depth) {
        
        for (uint32_t i = 0; i < moves.size; i++) {
            Board copy = b.copy();
            copy.doMove(moves.get(i), side);
            nodes++;
            scores.add(-pvs(copy, side^1, depth-1, -INFTY, INFTY, false));
        }
    }
    
    void Player::setDepths(int32_t sort, int32_t min, int32_t max, int32_t end) {
        maxDepth = max;
        minDepth = min;
        sortDepth = sort;
        endgameDepth = end;
    }
    
    uint64_t Player::getNodes() {
        return nodes;
    }
    
    void Player::setPosition(bitbrd takenBits, bitbrd blackBits) {
        game = Board(takenBits & ~blackBits, blackBits);
        bookExhausted = true;
        turn = 64 - game.countEmpty();
    }
    
    Move *Player::indexToMove(int32_t m) {
        printf("indexToMove: %d %d %d\n", m, m%8, m/8);
        return new Move(m % 8, m / 8);
    }
}
