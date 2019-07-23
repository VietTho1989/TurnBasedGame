/*
    ai.cpp   
   
    This file is part of Samuel. 

    This file comes from the guicheckers project.
    See http://www.3dkingdoms.com/checkers.htm

    It has been amended for use in Samuel.

    Samuel is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Samuel is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Samuel.  If not, see <http://www.gnu.org/licenses/>.
   
 */

#include <iostream>
using namespace std;

#include "english_draught_ai.hpp"
#include "english_draught_movegen.hpp"
#include "english_draught_database.hpp"
#include "../../Platform.h"

namespace EnglishDraught
{
    
    int32_t BEGINNER_DEPTH = 2;
    int32_t NORMAL_DEPTH = 8;
    int32_t EXPERT_DEPTH = 52;
    
    // ===============================================
    //                   SEARCH
    // ===============================================
    
    // -------------------------------------------------
    // Quiescence Search... Search all jumps, if there are no jumps, stop the search
    // -------------------------------------------------
    int32_t AI::QuiesceBoard(int32_t color, int32_t ahead, int32_t alpha, int32_t beta) {
        int32_t value;
        
        if (color == WHITE) {
            g_Movelist[ahead].nJumps = g_Boardlist[ahead-1].C.GetJumpersWhite( );
            if (g_Movelist[ahead].nJumps)
                g_Movelist[ahead].FindJumpsWhite( g_Boardlist[ahead-1].Sqs, g_Movelist[ahead].nJumps );
        } else {
            g_Movelist[ahead].nJumps = g_Boardlist[ahead-1].C.GetJumpersBlack( );
            if (g_Movelist[ahead].nJumps)
                g_Movelist[ahead].FindJumpsBlack( g_Boardlist[ahead-1].Sqs, g_Movelist[ahead].nJumps );
        }
        
        // No more jump moves, return evaluation
        if (g_Movelist[ahead].nJumps == 0 || (ahead+1) >= MAX_SEARCHDEPTH) {
            if (ahead > g_SelectiveDepth)
                g_SelectiveDepth = ahead-1;
            return g_Boardlist[ahead-1].EvaluateBoard (pickBestMove, ahead-1, alpha, beta);
        }
        
        // There were jump moves, so we keep searching.
        for (int32_t i = 1; i <= g_Movelist[ahead].nJumps; i++) {
            g_Boardlist[ahead] = g_Boardlist[ahead-1];
            g_Boardlist[ahead].DoMove(g_Movelist[ahead].Moves[i] , SEARCHED );
            nodes++;
            // Recursive Call
            value = QuiesceBoard( (color^3) , ahead+1 , alpha, beta);
            
            // Keep Track of Best Move and Alpha-Beta Prune
            if (color == WHITE && value > alpha )
            {
                alpha = value;
                if (alpha >= beta )
                {
                    return beta;
                }
            }
            if (color == BLACK && value < beta )
            {
                beta = value;
                if (alpha >= beta )
                {
                    return alpha;
                }
            }
        }
        
        if (color == WHITE)
        {
            return alpha;
        }
        else
        {
            return beta;
        }
    }
    
    //
    // Extensions
    // fracDepth unit = 1/32 of a ply
    //
    void inline AI::DoExtensions(int32_t &nextDepth, int32_t &fracDepth, int32_t ahead, uint64_t nMove)
    {
        uint32_t dst = (nMove>>6)&63;
        if (g_Movelist[ahead].nJumps == 1)  {       // Single move
            if (ahead>1 && g_Movelist[ahead-1].nJumps!=0) fracDepth+=22; // after opponent jump
            else if (ahead >2 && g_Movelist[ahead-2].nJumps == 1) fracDepth+=17; // we had to jump last move, now this move to
            else fracDepth+=8;
        }
        // Extend if the checker moves close to promotion (2 moves)
        else if ( dst >= 28 && dst <= 31 && g_Boardlist[ahead].Sqs[dst] == BPIECE && g_Boardlist[ahead].Sqs[dst+9] == EMPTY ) fracDepth+=17;
        else if ( dst >= 14 && dst <= 17 && g_Boardlist[ahead].Sqs[dst] == WPIECE && g_Boardlist[ahead].Sqs[dst-9] == EMPTY ) fracDepth+=17;
        // 2 Moves after opponent jump
        else if (g_Movelist[ahead].nJumps == 2 && ahead>1 && g_Movelist[ahead-1].nJumps!=0)     {
            fracDepth+= 16;
        }
        // Checker moves to 1 move from promotion
        else if ( (dst > 31 && g_Boardlist[ahead].Sqs[dst] == BPIECE ) || (dst < 14 && g_Boardlist[ahead].Sqs[dst] == WPIECE )) fracDepth+=8;
        
        // increment nextDepth if extensions are over a ply
        if (fracDepth > 31) {
            fracDepth -= 32;
            nextDepth++;
        }
    }
    
    // -------------------------------------------------
    //  Alpha Beta Search with Transposition(Hash) Table
    // -------------------------------------------------
    int16_t AI::ABSearch(CBoard &g_CBoard, int32_t color, int32_t ahead, int32_t depth, int32_t fracDepth, int16_t alpha, int16_t beta, int32_t &bestmove)
    {
        // printf("ABSearch: %d, %d\n", depth, ahead);
        int32_t i, value, nextbest, nM;
        uint64_t indexTT = 0, checksumTT = 0;
        int16_t temp;
        
        // Check to see if move time has run out every 50,000 nodes
        if (nodes > nodes2 + 45000 ) {
            if ( bCheckerBoard && g_pbPlayNow ) {
                return TIMEOUT;
            }
            if ( g_bStopThinking ) {
                return TIMEOUT;
            }
            endtime = clock();
            nodes2 = nodes;
            // If time has run out, we allow running up to 2*Time if g_bEndHard == FALSE and we are still searching a depth
            if ((endtime - starttime) > (CLOCKS_PER_SEC * fMaxSeconds))
                if ((endtime - starttime) > (2* CLOCKS_PER_SEC * fMaxSeconds * g_fPanic) || g_bEndHard == TRUE || g_SearchingMove == 0 || abs(g_SearchEval) > 1500) {
                    printf("ABSearch: timeout\n");
                    return TIMEOUT;
                }
            if ((endtime - lastTime) > (CLOCKS_PER_SEC * .4f)) {
                lastTime = endtime;
                // RunningDisplay(g_CBoard, -1, 1 );
            }
        }
        
        // Use Internal Iterative Deepening to set bestmove if there's no best move
        if (bestmove == NONE && depth > 4) {
            ABSearch(g_CBoard, color, ahead, depth-4, 0, alpha, beta, bestmove);
        }
        
        // TODO Test g_BoardList[0]
        /*{
         char fen[100];
         fen[0] = 0;
         g_Boardlist[0].ToFen(fen);
         printf("g_BoardList[0] fen: %s\n", fen);
         }*/
        
        // Find possible moves (and set a couple variables)
        if (color == WHITE) {
            g_Movelist[ahead].FindMovesWhite(g_Boardlist[ahead-1].Sqs, g_Boardlist[ahead-1].C );
        } else {
            g_Movelist[ahead].FindMovesBlack( g_Boardlist[ahead-1].Sqs, g_Boardlist[ahead-1].C );
        }
        
        // If you can't move, you lose the game
        if (g_Movelist[ahead].nMoves == 0) {
            if (color == WHITE) {
                // printf("ABSearch you can't move: white\n");
                return -2001+ahead;
            } else {
                // printf("ABSearch you can't move: black\n");
                return 2001 - ahead;
            }
        }
        
        // Run through the g_Movelist, doing each move
        for (i = 0; i <= g_Movelist[ahead].nMoves; i++) {
            // if bestmove is set, try Best Move at i=0, and skip it later
            if (i == bestmove) continue;
            if (i == 0) {
                if (bestmove == NONE) continue;
                nM = bestmove;
            } else
                nM = i;
            
            if (ahead == 1) {
                g_SearchingMove = i;
                if (i > bestmove) g_SearchingMove--;
                // On dramatic changes (such as fail lows) make sure to finish the iteration
                int32_t g_NewEval = (color == WHITE) ? alpha : beta;
                if (abs (g_NewEval) < 3000) {
                    if (abs(g_NewEval-g_SearchEval) >= 26) g_fPanic = 1.8f;
                    if (abs(g_NewEval-g_SearchEval) >= 50) g_fPanic = 2.5f;
                    g_SearchEval = g_NewEval;
                }
                if (SearchDepth > 11 && !g_bStopThinking) {
                    // RunningDisplay(g_CBoard, bestmove, 1);
                }
            }
            
            // Reset the move board to the one it was called with, then do the move # nM in the Movelist
            g_Boardlist[ahead] = g_Boardlist[ahead-1];
            temp = g_Boardlist[ahead].DoMove( g_Movelist[ahead].Moves[nM], SEARCHED);
            g_Boardlist[ahead].AddRepBoard(g_Boardlist[ahead].HashKey, g_nMoves + ahead);
            nodes++;
            
            // If the game is over, return a gameover value now
            if (g_Boardlist[ahead].C.WP == 0 || g_Boardlist[ahead].C.BP == 0) {
                bestmove = nM;
                return g_Boardlist[ahead].EvaluateBoard(pickBestMove, ahead, -100000, 100000);
            }
            
            // If this is the max depth, quiesce then evaluate the board position
            if ((depth <= 1 || ahead >= MAX_SEARCHDEPTH)) {
                value = QuiesceBoard( (color^3) , ahead+1, alpha, beta );
            }
            // If this is the reptition of a position that has occured already in the search, return a draw score
            else if (depth >=4 && ahead>1 && g_Boardlist[ahead].Repetition(g_Boardlist[ahead].HashKey, g_nMoves-24, g_nMoves+ahead)) {
                value = 0;
            }
            //If this isn't the max depth continue to look ahead
            else {
                value = -9999; nextbest = NONE;
                int32_t nextDepth = depth - 1;
                DoExtensions( nextDepth, fracDepth, ahead, g_Movelist[ahead].Moves[nM].SrcDst);
                
                // First look up the this Position in the Transposition Table
                if (nextDepth > 1 && hashing == 1 ) {
                    indexTT = ((unsigned long)g_Boardlist[ahead].HashKey) % HASHTABLESIZE;
                    checksumTT = (unsigned long)(g_Boardlist[ahead].HashKey>>32);
                    TTable[ indexTT ].Read( checksumTT, alpha, beta, nextbest, value, nextDepth, ahead);
                }
                
                // Then try Forward Pruning
                if (value == -9999 && nextDepth > 2) {
                    int32_t bForced = false;
                    if (ahead > 1 && g_Movelist[ahead-1].nMoves ==1 && g_Movelist[ahead].nMoves ==1) bForced = true;
                    const int32_t nMargin = 32, R = 3;
                    g_Boardlist[ahead].eval = g_Boardlist[ahead].EvaluateBoard(pickBestMove, ahead, alpha-100, beta+100);
                    if (g_Boardlist[ahead].InDatabase() && g_Boardlist[ahead].eval == 0)
                        value = 0; // Database draw, stop searching
                    switch (color) {
                        case BLACK:
                            if ( g_Boardlist[ahead].eval < alpha && alpha < 1500 && !bForced) {
                                value = ABSearch(g_CBoard, (color^3), ahead+1, nextDepth-R, fracDepth+4, alpha-nMargin-1, alpha-nMargin,  nextbest);
                                
                                if (value >= alpha-nMargin) value = -9999;
                            }
                            break;
                        case WHITE:
                            if (g_Boardlist[ahead].eval > beta && beta > -1500 && !bForced ) {
                                value = ABSearch(g_CBoard, (color^3), ahead+1, nextDepth-R, fracDepth+4, beta+nMargin, beta+nMargin+1,  nextbest);
                                
                                if (value <= beta+nMargin) value = -9999;
                            }
                            break;
                    }
                }
                
                // If value wasn't set from the Transposition Table or Pruning, look ahead nextDepth with a recursive call
                if (value == -9999 || ahead < 3) {
                    // call ABSearch with opposite color & ahead incremented
                    value = ABSearch(g_CBoard, (color^3), ahead+1, nextDepth, fracDepth, alpha, beta,  nextbest);
                    
                    if (value == TIMEOUT) {
                        return value;
                    }
                    
                    // Store for the search info for this position in the Transposition Table
                    if (nextDepth > 1 && hashing == 1) {
                        TTable[ indexTT ].Write( checksumTT, alpha, beta, nextbest, value, nextDepth, ahead);
                    }
                }
            }
            
            // Penalize moves at root that repeat positions, so hopefully the computer will always make progress if possible
            if (ahead == 1 && abs(value)<1000) {
                if (g_Boardlist[ahead].Repetition(g_Boardlist[ahead].HashKey, 0, g_nMoves+1)) {
                    value = (value>>1) + (value>>2);
                } else {
                    if (temp == 0) {
                        if (color == WHITE)
                            value-=1;
                        else
                            value+=1;
                    } // if moves are the same, prefer the non-repeatable move
                }
            }
            
            // Keep Track of Best Move and Alpha-Beta Prune
            if (color==WHITE && value > alpha) {
                bestmove = nM;
                alpha = value;
                if (alpha >= beta) {
                    return beta;
                }
            }
            if (color==BLACK && value < beta) {
                bestmove = nM;
                beta = value;
                if (alpha >= beta) {
                    return alpha;
                }
            }
        } // end for
        
        if (color == WHITE) {
            return alpha;
        } else {
            return beta;
        }
    }
    
    // -------------------------------------------------
    // The computer calculates a move then updates g_CBoard.
    // -------------------------------------------------
    int32_t AI::ComputerMove(char cColor, CBoard &InBoard) {
        // correct pickBestMove
        {
            if(pickBestMove<0){
                printf("error, why pickBestMove < 0\n");
                pickBestMove = 0;
            }
            if(pickBestMove>100){
                printf("error, why pickBest > 100\n");
                pickBestMove = 100;
            }
        }
        
        CBoard beforeBoard = InBoard;
        int32_t LastEval = 0, Eval, nDoMove = NONE, bestmove = NONE;
        CBoard TempBoard;
        g_ucAge++; // TT
        
        // return if game is over
        if (InBoard.C.WP == 0) {
            return 0;
        }
        // Find Move
        {
            if (cColor == BLACK) {
                g_Movelist[1].FindMovesBlack(InBoard.Sqs, InBoard.C);
                // printf("find moves black: %d\n", g_Movelist[1].nMoves);
            }
            if (cColor == WHITE) {
                g_Movelist[1].FindMovesWhite(InBoard.Sqs, InBoard.C);
                // printf("find moves white: %d\n", g_Movelist[1].nMoves);
            }
        }
        
        if (g_Movelist[1].nMoves == 0) {
            printf("gameover, don't have move\n");
            return 0; // game over
        }
        
        {
            uint64_t timeNow = now();
            // printf("now: %llu, %d\n", timeNow, (uint32_t)timeNow);
            srand((uint32_t)timeNow);
        }
        bestmove = rand() % g_Movelist[1].nMoves + 1;
        
        starttime = clock();
        endtime = starttime;
        nodes = 0;
        nodes2 = 0;
        g_SelectiveDepth = 0;
        
        if (bestmove != NONE) {
            // printf("find book move: %d, %d\n", bestmove, g_SearchEval);
            nDoMove = bestmove;
            SearchDepth = 0;
            g_SearchingMove = 0;
        } else {
            // printf("not find book move\n");
        }
        
        if(threeMoveRandom && InBoard.turn<=2){
            printf("use three move random\n");
        } else {
            // Make sure the repetition checker has all the values needed.
            if (!bCheckerBoard) ReplayGame( g_nMoves, InBoard);
            
            // Initialize variables (node count, start time, search depth)
            if (g_MaxDepth < 4) SearchDepth = g_MaxDepth-2;
            else SearchDepth = 0;
            Eval = 0;
            
            // Iteratively deepen until until the computer runs out of time, or reaches g_MaxDepth ply
            while ( SearchDepth < g_MaxDepth && Eval!=TIMEOUT) {
                // printf("search ai\n");
                g_fPanic = 1.0f; // multiplied max time by this, increased when search fails low
                SearchDepth +=2;
                
                g_Boardlist[0] = beforeBoard;// TODO InBoard;
                g_Boardlist[0].HashKey = TEntry::HashBoard(g_Boardlist[0]);
                
                Eval = ABSearch (InBoard, cColor, 1, SearchDepth, 0, -4000, 4000,  bestmove);
                
                if (bestmove!=NONE)
                    nDoMove = bestmove;
                
                if (Eval!=TIMEOUT) {
                    g_SearchEval = LastEval = Eval;
                    TempBoard = g_Boardlist[0];
                    // Check if there is only one legal move, if so don't keep searching
                    if (g_Movelist[1].nMoves == 1 && g_MaxDepth > 6) {
                        Eval = TIMEOUT;
                    }
                    if ((clock() - starttime) > (CLOCKS_PER_SEC * fMaxSeconds *.75f)  // probably won't get any useful info before timeup
                        || (abs(Eval) > 2001-SearchDepth) ) // found a win, can stop searching now)
                    {
                        if(abs(Eval) > 2001-SearchDepth){
                            printf("found a win, can stop searching now: %d, %d\n", Eval, SearchDepth);
                        }
                        printf("conputer move: eval timeout\n");
                        Eval = TIMEOUT;
                        g_SearchingMove++;
                    }
                } else {
                    if (abs(g_SearchEval) < 3000) LastEval = g_SearchEval;
                }
            }
        }
        
        //if ( (clock ()-starttime) < (CLOCKS_PER_SEC/4) && !bCheckerBoard) sleep(2); // pause a bit if move is really quick
        
        if (bCheckerBoard && nDoMove == NONE) {
            nDoMove = 1;
        }
        if (nDoMove != NONE) {
            printf("computerMove: nDoMove: %d, %d\n", nDoMove, g_Movelist[1].nMoves);
            bestMove = g_Movelist[1].Moves[nDoMove];
            /*InBoard = beforeBoard;
             InBoard.DoMove(g_Movelist[1].Moves[nDoMove], MAKEMOVE);
             g_GameMoves[g_nMoves++] = g_Movelist[1].Moves[nDoMove];
             g_GameMoves[g_nMoves].SrcDst = 0;*/
        }
        
        if (!g_bStopThinking)
            RunningDisplay(InBoard, bestmove, 0 );
        
        if (!bCheckerBoard) {
            // DrawBoard( InBoard );
        }
        printf("bestMove: %d, %d\n", bestmove, LastEval);
        return LastEval;
    }
    
    void AI::RunningDisplay (CBoard &g_CBoard, int32_t bestMove, int32_t bSearching)
    {
        char msg[1024];
        static int32_t LastEval = 0, nps = 0;
        static int32_t LastBest;
        int32_t j = 0;
        if ( bestMove != -1 ) {	LastBest = bestMove; }
        bestMove = g_Movelist[1].Moves[ LastBest ].SrcDst;
        if (!bCheckerBoard) {
            j+=sprintf(msg+j,"Red: %d   White: %d  ",  g_CBoard.nBlack, g_CBoard.nWhite);
            if (g_MaxDepth == BEGINNER_DEPTH)
                j+=sprintf(msg+j, "Level: Beginner  %ds  ", (int)fMaxSeconds);
            else if (g_MaxDepth == EXPERT_DEPTH)
                j+=sprintf(msg+j, "Level: Expert  %ds  ", (int)fMaxSeconds);
            else if (g_MaxDepth == NORMAL_DEPTH)
                j+=sprintf(msg+j, "Level: Advanced  %ds  ", (int)fMaxSeconds);
            else
                j+=sprintf(msg+j, "Level: U/Def (%d) %ds  ", g_MaxDepth, (int)fMaxSeconds);
            
            if (bSearching)
                j+=sprintf (msg+j, "(searching...)\n");
            else
                j+=sprintf (msg+j,"\n");
        }
        
        clock_t end;
        end = clock();
        
        double elapsed = ((double) (end - starttime)) / CLOCKS_PER_SEC;
        
        if ( elapsed > 0.0) nps = int32_t((double(nodes) / elapsed) / 1000); else nps = 0;
        
        if (abs (g_SearchEval) < 3000) LastEval = g_SearchEval;
        char cCap = (bestMove>>12) ? 'x' : '-';
        j+=sprintf( msg+j, "Depth: %d/%d (%d/%d)   Eval: %d  ", SearchDepth, g_SelectiveDepth, g_SearchingMove, g_Movelist[1].nMoves, -LastEval);
        if ( !bCheckerBoard ) j+=sprintf( msg+j, "\n" );
        
        printf("bestMove display: %d\n", bestMove);
        j+=sprintf (msg+j, "Move: %ld%c%ld Time: %.2fs  KNodes: %ld KN/Sec: %d", FlipX (BoardLocTo32[bestMove&63])+1, cCap, FlipX (BoardLocTo32[(bestMove>>6)&63])+1, elapsed, (nodes/1000), nps);
        
        //DisplayText (msg);
        printf("%s\n", msg);
    }
    
    void AI::NewGame()
    {
        g_nMoves = 0;
        g_GameMoves[ g_nMoves ].SrcDst = 0;
    }
    
    // ------------------
    // Replay Game from Game Move History up to nMove
    // ------------------
    void AI::ReplayGame(int32_t nMove, CBoard &Board)
    {
        Board = g_StartBoard;
        g_nMoves = 0;
        
        int32_t i = 0;
        while (g_GameMoves[i].SrcDst != 0 && i < nMove) {
            Board.AddRepBoard (Board.HashKey, i);
            Board.DoMove (g_GameMoves[i], SEARCHED);
            i++;
        }
        g_nMoves = i;
    }
    
    // ---------------------------------------------
    //  Check Possiblity/Execute Move from one selected square to another
    //  returns 0 if the move is not possible, otherwise 1, or a double jump value the move is an uncompleted jump
    // ---------------------------------------------
    int32_t AI::SquareMove(CBoard &Board, int32_t src , int32_t dst, char cColor)
    {
        int32_t i, nMSrc, nMDst;
        CMoveList MoveList;
        
        if (cColor == BLACK)
            MoveList.FindMovesBlack( Board.Sqs, Board.C );
        else
            MoveList.FindMovesWhite( Board.Sqs, Board.C );
        
        for (i = 1; i <= MoveList.nMoves; i++) {
            nMSrc = MoveList.Moves[i].SrcDst&63;
            nMDst = (MoveList.Moves[i].SrcDst>>6)&63;
            if ( nMSrc == src && nMDst == dst )  // Check if the src & dst match a move from the generated movelist
            {
                if (g_nDouble > 0) {
                    g_GameMoves[g_nMoves-1].cPath[ g_nDouble-1] = nMDst;
                    g_GameMoves[g_nMoves-1].cPath[ g_nDouble  ] = 0;
                } else {
                    g_GameMoves[ g_nMoves ].SrcDst = MoveList.Moves[i].SrcDst;
                    g_GameMoves[ g_nMoves++ ].cPath[0] = 0;
                    g_GameMoves[ g_nMoves ].SrcDst = 0;
                }
                if (Board.DoMove (MoveList.Moves[i], HUMAN) == DOUBLEJUMP) {
                    g_nDouble++;
                    Board.SideToMove ^=3;
                    return DOUBLEJUMP;
                }
                g_nDouble = 0;
                return 1;
            }
        }
        return 0;
    }
    
    //
    // Routines Called by enginemodule
    //
    
    // Initialise Engine
    void InitEngine(char *endgame2pcpath, char *endgame3pcpath, char *endgame4pcpath)
    {
        InitBitTables( );
        TEntry::Create_HashFunction();
        LoadAllDatabases(endgame2pcpath, endgame3pcpath, endgame4pcpath);
    }
    
    // returns the side that has won the game
    int32_t CheckForGameOver(CBoard& g_CBoard)
    {
        CMoveList MoveList;
        
        // check if computer (white) has lost
        if (g_CBoard.C.WP == 0) {
            return BLACK;       // white has no pieces left - red wins        
        } else {
            MoveList.FindMovesWhite( g_CBoard.Sqs, g_CBoard.C );  
            if (MoveList.nMoves == 0 && g_CBoard.SideToMove == WHITE) {
                return BLACK;       // white has no moves available - red wins            
            } 
        }  
        
        // check if human (red) has lost
        if (g_CBoard.C.BP == 0) {
            return WHITE;       // red has no pieces left - white wins        
        } else {
            MoveList.FindMovesBlack( g_CBoard.Sqs, g_CBoard.C );  
            if (MoveList.nMoves == 0 && g_CBoard.SideToMove == BLACK) {
                return WHITE;   // red has no moves available - white wins            
            } 
        }
        
        // check game draw
        {
            // too many moves
            if(g_CBoard.turn>=MAX_GAMEMOVES){
                printf("game draw: %d\n", g_CBoard.turn);
                return 3;
            }
            // repetion
            {
                int32_t count = 0;
                for (int32_t i=g_CBoard.ply-2; i >= 0; i-=2)
                    if (g_CBoard.RepNum[i] == g_CBoard.HashKey) {
                        count++;
                        printf("repetition true: %d, %lld\n", i, g_CBoard.HashKey);
                        if(count>=2){
                            return 3;
                        }
                    }
            }
            {
                int32_t maxPly = g_CBoard.ply>=100 ? g_CBoard.ply : 100;
                if(g_CBoard.ply>=maxPly){
                    printf("maxPly: draw\n");
                    return 3;
                }
            }
        }
        
        return 0;       // No winner yet
    }
    
    void SetBoard(CBoard& g_CBoard, int32_t i, int32_t piece)
    {    
        g_CBoard.Sqs[i] = piece;
        g_CBoard.SetFlags( );
    }
    
    void SetSideToMove(CBoard& g_CBoard, int32_t stm)
    {
        g_CBoard.SideToMove = stm;
    }
    
    int32_t flip(int32_t src)
    {
        int32_t flipped[41] = {
            0, 0, 0, 0, 0, 40, 39, 38, 37, 0,   \
            35, 34, 33, 32, 31, 30, 29, 28, 0, 26,   \
            25, 24, 23, 22, 21, 20, 19, 0, 17, 16,   \
            15, 14, 13, 12, 11, 10, 0, 8, 7, 6, 5    \
        };
        
        return flipped[src];
    }
}
