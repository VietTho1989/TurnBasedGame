/*
    board.cpp   
   
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

// Gui Checkers by Jonathan Kreuzer
// copyright 2005

// =================================================
// BOARD Representation. I changed to this representation after seeing code by Martin Fierz
// everything else in this file I believe was made without looking at other checkers source of any kind.
/*              37  38  39  40
              32  33  34  35
                28  29  30  31
              23  24  25  26
                19  20  21  22
              14  15  16  17
                10  11  12  13
               5   6   7   8         */
//
// I also use my own bitboard representation: See http://www.3dkingdoms.com/checkers/bitboards.htm
//
// =================================================

#include <time.h>
#include "english_draught_board.hpp"
#include "english_draught_movegen.hpp"
#include "english_draught_database.hpp"

namespace EnglishDraught
{
    //#define KING_VAL 33
    
    int32_t g_bDatabases;
    int32_t g_nMoves;
    char cpath[10];
    
    const char* EnglishDraughtStartFen = "B:W24,23,22,21,28,27,26,25,32,31,30,29:B4,3,2,1,8,7,6,5,12,11,10,9.";
    
#define PD 0
    const int32_t KV = KING_VAL;
    const int32_t KBoard[64] = { PD, PD, PD, PD, PD,
        KV-3,  KV+0,  KV+0,  KV+0, PD,
        KV+0,  KV+1,  KV+1,  KV+0,
        KV+1,  KV+3,  KV+3,  KV+2, PD,
        KV+3,  KV+5,  KV+5,  KV+1,
        KV+1,  KV+5,  KV+5,  KV+3, PD,
        KV+2,  KV+3,  KV+3,  KV+1,
        KV+0,  KV+1,  KV+1,  KV+0, PD,
        KV+0,  KV+0,  KV+0, KV-3};
    
    
    //void DrawBoard (const CBoard &board);
    //int32_t QueryDatabase( CBoard &Board);
    
    int32_t BoardLoc[66] =
    {   0, 37, 0, 38, 0, 39, 0, 40, 32, 0, 33, 0, 34, 0, 35, 0, 0, 28, 0, 29, 0 ,30, 0, 31, 23, 0, 24, 0, 25, 0, 26, 0,
        0, 19, 0, 20, 0, 21, 0, 22, 14, 0, 15, 0, 16, 0, 17, 0, 0, 10, 0, 11, 0, 12, 0, 13, 5, 0, 6, 0, 7, 0, 8, 0};
    
    // =================================================
    //
    //              TRANSPOSITION TABLE
    //
    // =================================================
    unsigned char g_ucAge = 0;
    
    // ------------------
    //  Hash Board
    //
    //  HashBoard is called to get the hash value of the start board.
    // ------------------
    uint64_t HashFunction[48][12], HashSTM;
    
    int randSeed=0;
    
    int myRand()
    {
        randSeed++;
        return randSeed;
    }
    
    void TEntry::Create_HashFunction()
    {
        for (int32_t i = 0; i <48; i++)
            for (int32_t x = 0; x < 9; x++) {
                HashFunction [i][x]  = myRand() + (myRand()*256) + (myRand()*65536);
                HashFunction [i][x] <<= 32;
                HashFunction [i][x]  += myRand() + (myRand()*256) + (myRand()*65536);
            }
        HashSTM = HashFunction[0][0];
    }
    
    uint64_t TEntry::HashBoard(const CBoard &Board ) {
        uint64_t CheckSum = 0;
        
        for(int32_t index = 5; index <= 40; index++) {
            int32_t nPiece =  Board.Sqs[index];
            if (nPiece != EMPTY)
                CheckSum ^= HashFunction[index][nPiece];
        }
        if (Board.SideToMove == BLACK) {
            CheckSum ^= HashSTM;
        }
        return CheckSum;
    }
    
    // Check for a repeated board
    // (only checks every other move, because side to move must be the same)
    int64_t RepNum[MAX_GAMEMOVES];
    
    // =================================================
    //
    //              BOARD FUNCTIONS
    //
    // =================================================
    void CBoard::Clear() {
        int32_t i;
        for (i = 0; i< 48; i++)
            Sqs [i] = EMPTY;
        for (i = 0; i < 5; i++)
            Sqs [i] = INVALID;
        for (i = 41; i <  48; i++)
            Sqs [i] = INVALID;
        Sqs[9] = INVALID;
        Sqs[18] = INVALID;
        Sqs[27] = INVALID;
        Sqs[36] = INVALID;
        SetFlags();
    }
    
    void CBoard::StartPosition(int32_t bResetRep) {
        Clear ();
        int32_t i;
        for (i = 5; i <= 8; i++)
            Sqs [i] = BPIECE;
        for (i = 10; i <= 17; i++)
            Sqs [i] = BPIECE;
        for (i = 28; i <= 35; i++)
            Sqs [i] = WPIECE;
        for (i = 37; i <= 40; i++)
            Sqs [i] = WPIECE;
        
        SideToMove = BLACK;
        if (bResetRep)
            g_nMoves = 0;
        
        SetFlags ();
    }
    
    void CBoard::SetFlags() {
        nWhite = 0; nBlack = 0;
        nPSq = 0;
        for (int32_t i = 5; i < 41; i++) {
            if ((Sqs[i]&WHITE) && Sqs[i]<INVALID) {
                nWhite++;
                if (Sqs[i] == WKING) {nPSq += KBoard[i];}
            }
            if ((Sqs[i]&BLACK) && Sqs[i]<INVALID) {
                nBlack++;
                if (Sqs[i] == BKING) {nPSq -= KBoard[i];}
            }
        }
        HashKey = TEntry::HashBoard( *this );
        C.ConvertFromSqs( Sqs );
    }
    
    // ------------------
    //  Evaluate Board
    //
    //  I don't know much about checkers, this is the best I could do for an evaluation function
    // ------------------
    const int32_t LAZY_EVAL_MARGIN = 64;
    
    int32_t CBoard::EvaluateBoard (int32_t pickBestMove, int32_t ahead, int32_t alpha, int32_t beta) {
        // printf("evaluateBoard: %d, %d, %d\n", ahead, alpha, beta);
        // Game is over?
        if (C.WP == 0)
            return -2001 + ahead;
        if (C.BP == 0)
            return 2001 - ahead;
        //
        int32_t eval, square;
        
        // Number of pieces present. Scaled higher for less material
        if ((nWhite+nBlack) > 12 )
            eval = (nWhite-nBlack) * 100;
        else
            eval = (nWhite-nBlack) * (160 - (nWhite + nBlack) * 5 );
        eval+=nPSq;
        
        // Probe the W/L/D bitbase
        if (InDatabase()) {
            int32_t Result = QueryDatabase( *this );
            if (Result == 2) eval+=400;
            if (Result == 1) eval-=400;
            if (Result == 0) return 0;
        } else {
            if (nWhite == 1 && nBlack >= 3 && nBlack < 8) eval = eval + (eval>>1); // surely winning advantage
            if (nBlack == 1 && nWhite >= 3 && nWhite < 8) eval = eval + (eval>>1);
        }
        
        // Too far from the alpha beta window? Forget about the rest of the eval, it probably won't get value back within the window
        if (eval+LAZY_EVAL_MARGIN < alpha)
            return eval;
        if (eval-LAZY_EVAL_MARGIN > beta)
            return eval;
        
        // Keeping checkers off edges
        eval -= 2 * (BitCount(C.WP & ~C.K & MASK_EDGES) - BitCount(C.BP & ~C.K & MASK_EDGES) );
        // Mobility
        eval += 2 * ( C.GetWhiteMoves( ) - C.GetBlackMoves( ) );
        
        // The losing side can make it tough to win the game by moving a King back and forth on the double corner squares.
        if (eval > 18)
        {if ((C.BP & C.K & MASK_2CORNER1)) {eval-=8; if ((MASK_2CORNER1 & ~C.BP &~C.WP)) eval-=10;}
            if ((C.BP & C.K & MASK_2CORNER2)) {eval-=8; if ((MASK_2CORNER2 & ~C.BP &~C.WP)) eval-=10;}
        }
        if (eval < -18)
        {if ((C.WP & C.K & MASK_2CORNER1)) {eval+=8; if ((MASK_2CORNER1 & ~C.BP &~C.WP)) eval+=10;}
            if ((C.WP & C.K & MASK_2CORNER2)) {eval+=8; if ((MASK_2CORNER2 & ~C.BP &~C.WP)) eval+=10;}
        }
        
        int32_t nWK = BitCount( C.WP & C.K );
        int32_t nBK = BitCount( C.BP & C.K );
        int32_t WPP = C.WP & ~C.K;
        int32_t BPP = C.BP & ~C.K;
        // Advancing checkers in endgame
        if ((nWK*2) >= nWhite || (nBK*2) >= nBlack || (nBK+nWK)>=4) {
            int32_t Mul;
            if (nWK == nBK && (nWhite+nBlack) < (nWK+nBK+2))
                Mul = 8; else Mul = 2;
            eval -=  Mul * ( BitCount( (WPP & MASK_TOP) ) - BitCount( (WPP & MASK_BOTTOM) )
                            -BitCount( (BPP & MASK_BOTTOM) ) + BitCount( (BPP & MASK_TOP) ) );
        }
        
        static int32_t BackRowGuardW[8] = { 0, 4, 5, 13, 4, 20, 18, 25 };
        static int32_t BackRowGuardB[8] = { 0, 4, 5, 20, 4, 18, 13, 25 };
        int32_t nBackB = 0, nBackW = 0;
        if ((nWK*2) < nWhite) {
            nBackB = (( BPP ) >> 1) & 7;
            eval -= BackRowGuardB[ nBackB ];
        }
        if ((nBK*2) < nBlack ) {
            nBackW = (( WPP ) >> 28) & 7;
            eval += BackRowGuardW[nBackW];
        }
        
        // Number of Active Kings
        int32_t nAWK = nWK, nABK = nBK;
        // Kings trapped on back row
        if (C.WP & C.K & MASK_TRAPPED_W) {
            if (Sqs[5]  == WKING && Sqs[6] == BPIECE) {
                eval-=22; nAWK--;
                if (Sqs[14] != EMPTY) eval+=7;
            }
            if (Sqs[10] == WKING && Sqs[14] !=EMPTY && Sqs[6]  == BPIECE) {
                eval-=10;
                nAWK--;
            }
            if (Sqs[6]  == WKING && Sqs[15] == EMPTY && Sqs[5] == BPIECE && Sqs[7] == BPIECE) {
                eval-=14;
                nAWK--;
            }
            if (Sqs[7]  == WKING && Sqs[16] == EMPTY && Sqs[6] == BPIECE && Sqs[8] == BPIECE) {
                eval-=14;
                nAWK--;
            }
            if (Sqs[8]  == WKING && Sqs[13] != EMPTY && Sqs[7] == BPIECE && Sqs[17] == EMPTY) {
                eval-=16;
                nAWK--;
            }
        }
        if ( C.BP & C.K & MASK_TRAPPED_B ) {
            if (Sqs[37] == BKING && Sqs[32] != EMPTY && Sqs[38] == WPIECE && Sqs[28] == EMPTY) {
                eval+=16;
                nABK--;
            }
            if (Sqs[38] == BKING && Sqs[29] == EMPTY && Sqs[37] == WPIECE && Sqs[39] == WPIECE) {
                eval+=14;
                nABK--;
            }
            if (Sqs[39] == BKING && Sqs[30] == EMPTY && Sqs[40] == WPIECE && Sqs[38] == WPIECE) {
                eval+=14;
                nABK--;
            }
            if (Sqs[40] == BKING && Sqs[39] == WPIECE) {
                eval+=22;
                nABK--;
                if (Sqs[31] != EMPTY)
                    eval-=7;
            }
            if (Sqs[35] == BKING && Sqs[39] == WPIECE && Sqs[31] != EMPTY) {
                eval+=10;
                nABK--;
            }
        }
        
        // Reward checkers that will king on the next move
        int32_t KSQ = 0;
        if ((BPP & MASK_7TH)) {
            for (square = 32; square <= 35; square++) {
                if (Sqs[ square ] == BPIECE) {
                    if (Sqs[ square + 4] == EMPTY) {
                        KSQ = square+4;
                        eval-=(KBoard [square+4] - 6);
                        break;
                    }
                    if (Sqs[ square + 5] == EMPTY) {
                        KSQ = square+5;
                        eval-=(KBoard [square+5] - 6);
                        break;
                    }
                }
            }
        } else
            square = 36;
        // Opponent has no Active Kings and backrow is still protected, so give a bonus
        if (nAWK > 0 && (square == 36 || KSQ == 40) && nABK == 0) {
            eval+=20;
            if (nAWK > 1)
                eval+=10;
            if (BackRowGuardW[ nBackW ] > 10)
                eval += 15;
            if (BackRowGuardW[ nBackW ] > 20)
                eval += 20;
        }
        
        if ((WPP & MASK_2ND)) {
            for (square = 13; square >= 10; square--) {
                if (Sqs[ square ] == WPIECE) {
                    if (Sqs[ square - 4] == EMPTY) {
                        KSQ = square-4;
                        eval+=(KBoard[square-4] - 6);
                        break;
                    }
                    if (Sqs[ square - 5] == EMPTY ) {
                        KSQ = square-5;
                        eval+=(KBoard[square-5] - 6);
                        break;
                    }
                }
            }
        } else
            square = 9;
        if (nABK > 0 && (square == 9 || KSQ == 5) && nAWK == 0) {
            eval-=20;
            if (nABK > 1)
                eval-=10;
            if (BackRowGuardB[ nBackB ] > 10)
                eval -= 15;
            if (BackRowGuardB[ nBackB ] > 20)
                eval -= 20;
        }
        
        if (nWhite == nBlack ) // equal number of pieces, but one side has all kinged versus all but one kinged (or all kings)
        {// score should be about equal, unless it's in a database, then don't reduce
            if (eval > 0 && eval < 200  && nWK >= nBK && nBK >= nWhite-1)
                eval = (eval>>1) + (eval>>3);
            if (eval < 0 && eval > -200 && nBK >= nWK && nWK >= nBlack-1)
                eval = (eval>>1) + (eval>>3);
        }
        // printf("eval board: %d\n", eval);
        {
            if(pickBestMove>=0 && pickBestMove<100){
                int32_t random = rand() % (100-pickBestMove);
                int32_t newEval = eval*(100-random)/100;
                // printf("random: %d, %d, %d\n", eval, newEval, random);
                return newEval;
            }
        }
        return eval;
    }
    
    //
    // MOVE EXECUTION
    //
    // ---------------------
    //  Helper Functions for DoMove
    // ---------------------
    void inline CBoard::DoSingleJump(const int32_t src, const int32_t dst, const int32_t nPiece )
    {
        int32_t jumpedSq = (dst + src) >> 1;
        int32_t jumpedPiece = Sqs[ jumpedSq ];
        if (jumpedPiece == WPIECE) {
            nWhite--;
        }
        else if (jumpedPiece == BPIECE) {
            nBlack--;
        } else if (jumpedPiece == BKING) {
            nBlack--;
            nPSq += KBoard[jumpedSq];
        } else if (jumpedPiece == WKING) {
            nWhite--;
            nPSq -= KBoard[jumpedSq];
        }
        
        HashKey ^= HashFunction[src][nPiece] ^ HashFunction[dst][nPiece] ^ HashFunction[ jumpedSq ][ jumpedPiece ];
        
        // Update the board array
        Sqs[ dst ] = nPiece;
        Sqs[ jumpedSq ] = EMPTY;
        Sqs[ src ] = EMPTY;
        
        // Update the bitboards
        uint32_t BitMove = (S[ BoardLocTo32[src] ] | S[ BoardLocTo32[dst] ]);
        if (SideToMove == BLACK) {
            C.WP ^= BitMove;
            C.BP &= ~S[BoardLocTo32[jumpedSq]];
            C.K  &= ~S[BoardLocTo32[jumpedSq]];
        } else {
            C.BP ^= BitMove;
            C.WP &= ~S[BoardLocTo32[jumpedSq]];
            C.K  &= ~S[BoardLocTo32[jumpedSq]];
        }
        if (nPiece & KING) C.K ^= BitMove;
    }
    
    // This function will test if a checker needs to be upgraded to a king, and upgrade if necessary
    void inline CBoard::CheckKing (const int32_t src, const int32_t dst, const int32_t nPiece)
    {
        if (dst <= 8)
        {Sqs[ dst ] = WKING;
            nPSq += KBoard[dst];
            HashKey  ^= HashFunction[dst][nPiece] ^ HashFunction[dst][WKING];
            C.K |= S[BoardLocTo32[dst]];
        }
        if (dst >= 37)
        {Sqs[ dst ] = BKING;
            nPSq -= KBoard[dst];
            HashKey ^= HashFunction[dst][nPiece] ^ HashFunction[dst][BKING];
            C.K |= S[BoardLocTo32[dst]];
        }
    }
    
    void inline CBoard::UpdateSqTable(const int32_t nPiece, const int32_t src, const int32_t dst )
    {
        switch (nPiece) {
            case BKING:
                nPSq -= KBoard[ dst ] - KBoard[ src ];
                return;
            case WKING:
                nPSq += KBoard[ dst ] - KBoard[ src ];
                return;
        }
    }
    
    // ---------------------
    //  Execute a Move
    // ---------------------
    int32_t CBoard::DoMove(SMove &Move, int32_t nType) {
        uint32_t src = (Move.SrcDst&63);
        uint32_t dst = (Move.SrcDst>>6)&63;
        uint32_t bJump = (Move.SrcDst>>12);
        uint32_t nPiece = Sqs[src];
        
        // TODO tu them vao
        if(nType==MAKEMOVE){
            printf("bJump: %d, nPiece: %d\n", bJump, nPiece);
            turn++;
            if(bJump==0 && (nPiece==BKING || nPiece==WKING)){
                printf("increase ply\n");
                if(ply<MAX_GAMEMOVES){
                    RepNum[ply] = HashKey;
                } else {
                    printf("error, turn wrong: %d\n", ply);
                }
                ply++;
            } else {
                ply = 0;
            }
        }
        
        SideToMove ^=3;
        HashKey ^= HashSTM; // Flip hash stm
        
        if (bJump == 0) {
            // Update the board array
            Sqs[ dst ] = Sqs[ src ];
            Sqs[ src ] = EMPTY;
            
            // Update the bitboards
            uint32_t BitMove = (S[ BoardLocTo32[src] ] | S[ BoardLocTo32[dst] ]);
            if (SideToMove == BLACK) C.WP ^= BitMove; else C.BP ^= BitMove;
            if (nPiece & KING) C.K ^= BitMove;
            
            // Update hash values
            HashKey ^= HashFunction[ src ][ nPiece ] ^ HashFunction[ dst ][ nPiece ];
            
            UpdateSqTable( nPiece, src, dst );
            
            if (nPiece < KING)  {
                CheckKing( src, dst, nPiece );
                return 1;
            }
            // printf("error, return 0\n");
            return 0;
        }
        
        DoSingleJump ( src, dst, nPiece);
        if (nPiece < KING) CheckKing( src, dst, nPiece );
        
        // Double Jump?
        if (Move.cPath[0] == 0) {
            UpdateSqTable ( nPiece, src, dst );
            return 1;
        }
        if (nType == HUMAN) return DOUBLEJUMP;
        
        for (int32_t i = 0; i < 8; i++) {
            int32_t nDst = Move.cPath[i];
            if (nDst == 0) break;
            
            if (nType == MAKEMOVE) // pause a bit on displaying double jumps
            {
                if (i == 0) {
                    cpath[0] = src;
                    cpath[1] = dst;
                }
                cpath[i + 2] = nDst; // set variable in enginemodule for python gui
                //DrawBoard ( *this );
                // Sleep (300);
                //sleep (1);
            }
            DoSingleJump( dst, nDst, nPiece);
            dst = nDst;
        }
        if (nPiece < KING)
            CheckKing(src, dst, nPiece);
        else
            UpdateSqTable ( nPiece, src, dst );
        return 1;
    }
    
    // Flip square horizontally because the internal board is flipped.
    int64_t FlipX(int32_t x)
    {
        int32_t y = x&3;
        x ^= y;
        x += 3-y;
        return x;
    }
    // ------------------
    // Position Copy & Paste Functions
    // ------------------
    
    void CBoard::ToFen(char *sFEN )
    {
        char buffer[80];
        {
            buffer[0] = 0;
        }
        int32_t i;
        if (SideToMove == WHITE)
            strcpy(sFEN, "W:");
        else
            strcpy(sFEN, "B:");
        
        strcat(sFEN, "W");
        for (i = 0; i < 32; i++) {
            if (Sqs[BoardLoc32[i]] == WKING)
                strcat(sFEN, "K");
            if (Sqs[ BoardLoc32[i] ]&WPIECE)  {
                //strcat( sFEN, _ltoa (FlipX(i)+1, buffer, 10) );
                //strcat( sFEN, ltoa (FlipX(i)+1, buffer, 10) );
                //char test[10];
                //sprintf(test,"%l",fsize);
                sprintf(buffer,"%ld",FlipX(i)+1);
                strcat(sFEN, buffer);
                strcat( sFEN, ",");
            }
        }
        if (strlen(sFEN) > 3)
            sFEN [ strlen(sFEN)-1 ] = NULL;
        strcat( sFEN, ":B");
        for (i = 0; i < 32; i++) {
            if (Sqs[ BoardLoc32[i] ] == BKING)
                strcat(sFEN, "K");
            if ( Sqs[ BoardLoc32[i] ]&BPIECE)  {
                //strcat( sFEN, _ltoa (FlipX(i)+1, buffer, 10) );
                sprintf(buffer,"%ld",FlipX(i)+1);
                strcat(sFEN, buffer);
                strcat( sFEN, ",");
            }
        }
        sFEN[ strlen(sFEN)-1 ] = '.';
    }
    
    int32_t CBoard::FromFen(const char *sFEN)
    {
        //DisplayText( sFEN );
        if ((sFEN[0] != 'W' && sFEN[0]!='B') || sFEN[1]!=':') {
            return 0;
        }
        Clear ();
        if (sFEN[0] == 'W')
            SideToMove = WHITE;
        if (sFEN[0] == 'B')
            SideToMove = BLACK;
        
        int32_t nColor=0, i=0;
        while (sFEN[i] != 0 && sFEN[i]!= '.' && sFEN[i-1]!= '.') {
            int32_t nKing = 0;
            if (sFEN[i] == 'W')
                nColor = WPIECE;
            if (sFEN[i] == 'B')
                nColor = BPIECE;
            if (sFEN[i] == 'K') {
                nKing = 4;
                i++;
            }
            if (sFEN[i] >= '0' && sFEN[i] <= '9') {
                int32_t sq = sFEN[i]-'0';
                i++;
                if (sFEN[i] >= '0' && sFEN[i] <= '9')
                    sq = sq*10 + sFEN[i]-'0';
                Sqs[BoardLoc32[FlipX(sq-1)]] = nColor | nKing;
            }
            i++;
        }
        
        SetFlags();
        return 1;
    }
    
    // For PDN support
    //
    int32_t GetFinalDst(SMove &Move)
    {
        int32_t sq = ((Move.SrcDst>>6)&63);
        if ((Move.SrcDst>>12))
            for (int32_t i = 0; i < 8; i++) {
                if (Move.cPath[i] == 0)
                    break;
                sq = Move.cPath[i];
            }
        return sq;
    }
    
    int32_t getIndexFromXY(int32_t x, int32_t y)
    {
        /* indexes to be updated
         #            37  38  39  40
         #          32  33  34  35
         #            28  29  30  31
         #          23  24  25  26
         #            19  20  21  22
         #          14  15  16  17
         #            10  11  12  13
         #           5   6   7   8
         */
        /* indexes to be updated
         #            32  31  30  29
         #          28  27  26  25
         #            24  23  22  21
         #          20  19  18  17
         #            16  15  14  13
         #           12  11  10  9
         #            8  7  6  5
         #           4   3   2   1
         */
        /* indexes to be updated
         #            28  29  30  31
         #          24  25  26  27
         #            20  21  22  23
         #          16  17  18  19
         #            12  13  14  15
         #          08  09  10  11
         #            04  05  06  07
         #          00  01  02  03
         */
        return x/2 + 4*(7-y);
    }
    
    void CBoard::print(char* ret, SMove* lastMove)
    {
        ret[0] = 0;
        // turn
        {
            switch (SideToMove) {
                case BLACK:
                    sprintf(ret, "%sTurn: %d, Black\n", ret, turn);
                    break;
                case WHITE:
                    sprintf(ret, "%sTurn: %d, White\n", ret, turn);
                    break;
                default:
                    printf("error, unknown turn\n");
                    break;
            }
        }
        // Board
        {
            int32_t from = -1;
            int32_t dest = -1;
            if(lastMove->SrcDst!=0){
                from = (int32_t)FlipX (BoardLocTo32[lastMove->SrcDst&63])+1;
                dest = (int32_t)FlipX (BoardLocTo32[(lastMove->SrcDst>>6)&63])+1;
                printf("from: %d, dest: %d, lastMove: %lu, %lu, %lu\n", from, dest, lastMove->SrcDst, lastMove->SrcDst&63, (lastMove->SrcDst>>6)&63);
            }
            // print top
            sprintf(ret, "%s\n    A  B  C  D  E  F  G  H  I\n", ret);
            // print piece
            for (int32_t y = 0; y < 8; y++) {// Square.Rank_Size
                sprintf(ret, "%s%2d ", ret, 8-y);
                for (int32_t x = 0; x < 8; x++) {// Square.File_Size
                    if((x+y)%2==1){
                        int32_t index = getIndexFromXY(x, y);
                        if(index>=0 && index<32) {
                            char t = ' ';
                            {
                                if (from>=0 && dest>=0){
                                    if (((from-1)/4)*4 +(3 - (from-1)%4) == index){
                                        t = '-';
                                    } else if(((dest-1)/4)*4 +(3 - (dest-1)%4) == index){
                                        t = '+';
                                    }
                                } else {
                                    // printf("don't have last move\n");
                                }
                            }
                            switch (Sqs[BoardLoc32[index]]) {
                                case BPIECE:
                                    sprintf(ret, "%s%cm%c", ret, t, t);
                                    break;
                                case BKING:
                                    sprintf(ret, "%s%ck%c", ret, t, t);
                                    break;
                                case WPIECE:
                                    sprintf(ret, "%s%cM%c", ret, t, t);
                                    break;
                                case WKING:
                                    sprintf(ret, "%s%cK%c", ret, t, t);
                                    break;
                                default:
                                    sprintf(ret, "%s%c.%c", ret, t, t);
                                    break;
                            }
                        } else {
                            printf("error, index error: %d\n", index);
                        }
                    }else{
                        sprintf(ret, "%s   ", ret);
                    }
                }
                sprintf(ret, "%s %2d\n", ret, 8-y);
            }
            // print bottom
            sprintf(ret, "%s    A  B  C  D  E  F  G  H  I\n", ret);
        }
        // Fen
        {
            char fen[200];
            fen[0] = 0;
            this->ToFen(fen);
            sprintf(ret, "%sFen: %s\n", ret, fen);
        }
        // GamePly
        sprintf(ret, "%sPly: %d\n", ret, this->ply);
        // HashKey
        sprintf(ret, "%sHashKey: %lld\n", ret, HashKey);
    }
    
    //////////////////////////////////////////////////////////////////
    ////////////// Convert ////////////////
    //////////////////////////////////////////////////////////////////
    
    int32_t CBoard::getByteSize()
    {
        int32_t ret = 0;
        {
            // Data
            // char Sqs[48];
            ret+=48;
            // SCheckerBoard C;
            ret+=SCheckerBoard::getByteSize();
            // int16_t nPSq, eval;
            ret+=2*sizeof(int16_t);
            // char nWhite, nBlack, SideToMove, extra;
            ret+=4;
            // uint64_t HashKey;
            ret+=sizeof(uint64_t);
            
            // int64_t RepNum[MAX_GAMEMOVES];
            {
                if(ply>=0 && ply<MAX_GAMEMOVES){
                    ret+=ply*sizeof(int64_t);
                } else {
                    printf("error, ply error: %d\n", ply);
                }
            }
            // uint32_t ply = 0;
            ret+=sizeof(uint32_t);
            // uint32_t maxPly = 100;
            ret+=sizeof(uint32_t);
            // uint32_t turn = 0;
            ret+=sizeof(uint32_t);
        }
        return ret;
    }
    
    int32_t CBoard::convertToByteArray(struct CBoard* cBoard, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = cBoard->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // char Sqs[48]
                {
                    int32_t size = 48;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->Sqs, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: Sqs: %d, %d\n", pointerIndex, length);
                    }
                }
                // SCheckerBoard C
                {
                    uint8_t* sCheckerBoardByteArray;
                    int32_t size = SCheckerBoard::convertToByteArray(&cBoard->C, sCheckerBoardByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, sCheckerBoardByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: C: %d, %d\n", pointerIndex, length);
                    }
                    free(sCheckerBoardByteArray);
                }
                // int16_t nPSq
                {
                    int32_t size = sizeof(int16_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->nPSq, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nPSq: %d, %d\n", pointerIndex, length);
                    }
                }
                // int16_t eval
                {
                    int32_t size = sizeof(int16_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->eval, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: eval: %d, %d\n", pointerIndex, length);
                    }
                }
                // char nWhite
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->nWhite, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nWhite: %d, %d\n", pointerIndex, length);
                    }
                }
                // char nBlack
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->nBlack, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nBlack: %d, %d\n", pointerIndex, length);
                    }
                }
                // char SideToMove
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->SideToMove, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: SideToMove: %d, %d\n", pointerIndex, length);
                    }
                }
                // char extra
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->extra, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: extra: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint64_t HashKey
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->HashKey, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: HashKey: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint32_t ply = 0
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->ply, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: ply: %d, %d\n", pointerIndex, length);
                    }
                }
                // int64_t RepNum[MAX_GAMEMOVES];
                {
                    if(cBoard->ply>=0 && cBoard->ply<MAX_GAMEMOVES){
                        int32_t size = cBoard->ply*sizeof(int64_t);
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, &cBoard->RepNum, size);
                            pointerIndex+=size;
                        } else {
                            printf("length error: RepNum: %d, %d\n", pointerIndex, length);
                        }
                    } else {
                        printf("error, ply error: %d\n", cBoard->ply);
                    }
                }
                // uint32_t maxPly = 100
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->maxPly, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: maxPly: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint32_t turn = 0
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &cBoard->turn, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: turn: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check convert correct
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }
    
    int32_t CBoard::parseByteArray(struct CBoard* cBoard, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // char Sqs[48]
                {
                    int32_t size = 48;
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->Sqs, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: Sqs: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // SCheckerBoard C
                {
                    int32_t sCheckerBoardByteLength = SCheckerBoard::parseByteArray(&cBoard->C, positionBytes, length, pointerIndex, canCorrect);
                    if (sCheckerBoardByteLength > 0) {
                        pointerIndex+= sCheckerBoardByteLength;
                    } else {
                        printf("error, cannot parse: sCheckerBoard\n");
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // int16_t nPSq
                {
                    int32_t size = sizeof(int16_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->nPSq, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nPSq: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // int16_t eval
                {
                    int32_t size = sizeof(int16_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->eval, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: eval: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // char nWhite
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->nWhite, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nWhite: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                    // char nBlack
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->nBlack, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: nBlack: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                    // char SideToMove
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->SideToMove, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: SideToMove: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                    // char extra
                {
                    int32_t size = 1;
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->extra, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: extra: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                    // uint64_t HashKey
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->HashKey, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: HashKey: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                    // uint32_t ply = 0
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->ply, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: ply: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 10:
                    // int64_t RepNum[MAX_GAMEMOVES];
                {
                    if(cBoard->ply>=0 && cBoard->ply<MAX_GAMEMOVES){
                        int32_t size =  cBoard->ply*sizeof(int64_t);
                        if(pointerIndex+size<=length) {
                            memcpy(&cBoard->RepNum, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        } else {
                            printf("length error: RepNum: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }else{
                        printf("error, ply: %d\n", cBoard->ply);
                    }
                }
                    break;
                case 11:
                    // uint32_t maxPly = 100
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->maxPly, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: maxPly: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 12:
                    // uint32_t turn = 0
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&cBoard->turn, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: turn: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        {
            if(canCorrect){
                
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error position parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
}
