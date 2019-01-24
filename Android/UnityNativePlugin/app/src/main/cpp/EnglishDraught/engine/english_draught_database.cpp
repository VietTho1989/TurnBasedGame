/*
    database.cpp   
   
    This file is part of Samuel

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

//
// Checkers Win/Loss/Draw Database Generation & Probing
// by Jonathan Kreuzer
//
// note: This is rather poor database code in most ways...
//
//#include "uncompress.cpp"

#include <iostream>
#include <cstdint>
#include <cstring>
#include "english_draught_database.hpp"
#include "english_draught_board.hpp"
#include "../../Platform.h"

namespace EnglishDraught
{
#define WHITE 2
#define BLACK 1 // Black == Red
#define EMPTY 0
#define BPIECE 1
#define WPIECE 2
#define KING 4
#define BKING  5
#define WKING  6
#define INVALID 8
#define NONE 255
#define TIMEOUT 31000
#define DOUBLEJUMP 2000
#define HUMAN 128
#define MAKEMOVE 129
#define SEARCHED 127
#define MAX_SEARCHDEPTH 96
#define MAX_GAMEMOVES 2048
#define KING_VAL 33
    
    const uint32_t SIZE2 = 32/4 * 32 * 2;
    const uint32_t SIZE3 = SIZE2 * 32;
    uint32_t SIZE4 = 0;
    unsigned char ResultsTwo  [ 4 * SIZE2 ];
    unsigned char ResultsThree[ 6 * SIZE3 ];
    unsigned char *ResultsFour;
    unsigned char *pResults;
    
    int32_t PC2[4*4] = { WKING, BKING, EMPTY, EMPTY,    WKING, BPIECE, EMPTY, EMPTY,
        WPIECE, BKING, EMPTY, EMPTY,   WPIECE, BPIECE, EMPTY, EMPTY};
    int32_t PC3[4*12] = {WKING, WKING, BKING, EMPTY,    WKING, BKING, BKING, EMPTY,
        WKING, WKING, BPIECE, EMPTY,   WPIECE, BKING, BKING, EMPTY,
        WKING, WPIECE, BKING, EMPTY,   WKING, BKING, BPIECE, EMPTY,
        WPIECE, WPIECE, BKING, EMPTY,  WKING, BPIECE, BPIECE, EMPTY,
        WKING, WPIECE, BPIECE, EMPTY,  WPIECE, BKING, BPIECE, EMPTY,
        WPIECE, WPIECE, BPIECE, EMPTY, WPIECE, BPIECE, BPIECE, EMPTY};
    int32_t PC4[4*9] =  {WKING, WKING, BKING, BKING,    WKING, WPIECE, BKING, BKING ,   WKING, WKING, BKING, BPIECE,
        WKING, WPIECE, BKING, BPIECE,  WPIECE, WPIECE, BKING, BKING,   WKING, WKING, BPIECE, BPIECE,
        WPIECE, WPIECE, BKING, BPIECE, WKING, WPIECE, BPIECE, BPIECE,  WPIECE, WPIECE, BPIECE, BPIECE };
    int32_t FourIndex[9] = { 0, 1, 9, 2, 3, 11, 4, 12, 5};
    int32_t ThreeIndex[12]= { 0, 8, 1, 9, 2, 10, 3, 11, 4, 12, 5, 13};
    int32_t FlipResult[9] = { 0, 2, 1, 3 };
    
    int32_t GetResult(unsigned char *pResults, int32_t Index ){
        return( pResults[ Index/4 ] >> ((Index&3)*2) ) & 3;
    }
    
    void SetResult(int32_t Index, int32_t Result ){
        pResults[ Index/4 ] ^= (GetResult(pResults, Index) << ((Index&3)*2));
        pResults[ Index/4 ] |= (Result << ((Index&3)*2));
    }
    
    struct SDatabase
    {
        int32_t nStart, nSizeW, nSizeB;
        int32_t Pieces[4];
        int32_t IndW[32*32], IndB[32*32];
        
        int32_t inline GetIndex(int32_t nW, int32_t nB, int32_t stm )
        {
            return nStart + stm + 2*IndW[ nW ] + 2*nSizeW*IndB[ nB ];
        }
    };
    
    SDatabase FourPc[12];
    
    void Compute2PieceIndices(int32_t pData[], int32_t &nSize, int32_t nP[])
    {
        int32_t nSq1, nSq2;
        int32_t bSame = (nP[0] == nP[1]) ? 1: 0;
        nSize = 0;
        
        for (nSq1 = 0; nSq1 < 32; nSq1++)
            for (nSq2 = 0; nSq2 < 32; nSq2++) {
                if ((nSq2 < nSq1 && bSame))
                    pData[ nSq1 + nSq2*32 ] = pData[ nSq2 + nSq1*32 ];
                else if (nSq1 == nSq2)
                    pData[ nSq1 + nSq2*32 ] = 0;
                else if ((nSq1 < 4 && nP[0] == WPIECE) || (nSq2 < 4 && nP[1] == WPIECE) || (nSq1 > 27 && nP[0] == BPIECE) || (nSq2 > 27 && nP[1] == BPIECE)) {
                    pData[ nSq1 + nSq2*32 ] = 0;
                } else {
                    pData[ nSq1 + nSq2*32 ] = nSize;
                    nSize++;
                }
            }
    }
    
    int32_t ComputeAllIndices( ){
        
        int32_t nStart = 0;
        for (int32_t i = 0; i < 9; i++) {
            int32_t n = FourIndex[i];
            if (n > 8)
                continue;
            memcpy( &FourPc[n].Pieces[0], &PC4[4*i] , 4*sizeof(int32_t));
            FourPc[n].nStart = nStart;
            Compute2PieceIndices( FourPc[n].IndW, FourPc[n].nSizeW, &FourPc[n].Pieces[0] );
            Compute2PieceIndices( FourPc[n].IndB, FourPc[n].nSizeB, &FourPc[n].Pieces[2] );
            nStart += FourPc[n].nSizeW * FourPc[n].nSizeB * 2;
        }
        SIZE4 = nStart/4+1;
        ResultsFour = (unsigned char*) malloc ( nStart/4 + 4  );
        memset (ResultsFour,  0, SIZE4);
        memset (ResultsThree, 0, 6*SIZE3);
        memset (ResultsTwo,   0, 4*SIZE2);
        return SIZE4;
    }
    
    //
    //
    int32_t ComputeIndex(int32_t WS[], int32_t BS[], int32_t &nPieces, int32_t stm, int32_t &bFlip){
        int32_t Index, i;
        nPieces = 0;
        bFlip = 0;
        if (WS[0] == -1) {
            nPieces = 1;
            return 1;
        }
        if (BS[0] == -1) {
            nPieces = 1;
            return 2;
        }
        
        int32_t Sqs[4];
        Sqs[ nPieces++ ] = (WS[0]>>4);
        WS[0] = (WS[0]&15);
        if (WS[1] >= 0) {Sqs[ nPieces++ ]=(WS[1]>>4); WS[1] = (WS[1]&15); }
        Sqs[ nPieces++ ] = (BS[0]>>4);
        BS[0] = (BS[0]&15);
        if (BS[1] >= 0) {Sqs[ nPieces++ ]=(BS[1]>>4); BS[1] = (BS[1]&15); }
        
        if (nPieces == 2) {
            for (i = 0; i < 4; i++)
                if (WS[0] == PC2[0 + i*4] && BS[0] == PC2[0 + i*4+1]) break;
            Index = Sqs[0] + Sqs[1]*32 + stm*1024 + i*(32*32*2);
            return Index;
        }
        if (nPieces == 3) {
            for (i = 0; i < 12; i++)
                if ((WS[0] == PC3[0 + i*4] && WS[1] == PC3[1 + i*4] && BS[0] == PC3[2 + i*4]) ||
                    ( WS[0] == PC3[0 + i*4] && BS[0] == PC3[1 + i*4] && BS[1] == PC3[2 + i*4])) break;
            if (ThreeIndex[i] < 8 )
                Index = Sqs[0] + Sqs[1]*32 + Sqs[2]*32*32 + stm*32*32*32;
            else {
                Index = (31-Sqs[1]) + (31-Sqs[2])*32 + (31-Sqs[0])*32*32 + (stm^1)*32*32*32;
                bFlip = 1;
            }
            return Index + (ThreeIndex[i]&7) * (32*32*32*2);
        }
        if (nPieces == 4) {
            for (i = 0; i < 9; i++)
                if (WS[0] == PC4[0 + i*4] && WS[1] == PC4[1 + i*4] && BS[0] == PC4[2 + i*4] && BS[1] == PC4[3 + i*4]) break;
            if (FourIndex[i]<8)
                Index = FourPc[ FourIndex[i] ].GetIndex( Sqs[0]+Sqs[1]*32, Sqs[2]+Sqs[3]*32, stm );
            else {
                Index = FourPc[ FourIndex[i]&7 ].GetIndex( (31-Sqs[2]) + (31-Sqs[3])*32 , (31-Sqs[0]) + (31-Sqs[1])*32, stm^1 );
                bFlip = 1;
            }
            return Index;
        }
        return 0;
    }
    
    //
    // Get Index From Board
    // Should be 2 of a color at most
    //
    int32_t GetIndexFromBoard(CBoard &Board, int32_t &bFlip, int32_t &nPieces ){
        
        int32_t WSqs[2], BSqs[2], Piece;
        int32_t stm = Board.SideToMove - 1;
        
        WSqs[0] = -1; WSqs[1] = -1;
        BSqs[0] = -1; BSqs[1] = -1;
        
        uint32_t WPieces = Board.C.WP;
        while (WPieces) {
            uint32_t sq = FindLowBit( WPieces );
            WPieces &= ~S[sq];
            Piece = Board.Sqs[ BoardLoc32[sq] ];
            if (WSqs[0]==-1) {
                WSqs[0] = Piece + sq*16;
            } else if (Board.C.K & S[sq]) {
                WSqs[1] = WSqs[0];
                WSqs[0] = Piece + sq*16;
            } else
                WSqs[1] = Piece + sq*16;
        }
        uint32_t BPieces = Board.C.BP;
        while (BPieces) {
            uint32_t sq = FindLowBit( BPieces );
            BPieces &= ~S[sq];
            Piece = Board.Sqs[ BoardLoc32[sq] ];
            if (BSqs[0]==-1) {
                BSqs[0] = Piece+ sq*16;
            }
            else if (Board.C.K & S[sq]) {
                BSqs[1] = BSqs[0];
                BSqs[0] = Piece + sq*16;
            } else
                BSqs[1] = Piece + sq*16;
        }
        return ComputeIndex( WSqs, BSqs, nPieces, stm, bFlip);
    }
    
    //
    // Return a Win/Loss/Draw value for the board
    //
    int32_t QueryDatabase(CBoard &Board)
    {
        
        int32_t bFlip, nPieces, Result = 3;
        int32_t Index = GetIndexFromBoard (Board, bFlip, nPieces);
        
        if (nPieces == 1)
            return Index;
        if (nPieces == 2)
            Result = GetResult( ResultsTwo  , Index );
        if (nPieces == 3)
            Result = GetResult( ResultsThree, Index );
        if (nPieces == 4)
            Result = GetResult( ResultsFour , Index );
        if (bFlip)
            return FlipResult[ Result ];
        return Result;
    }
    
    //
    //
    //
    int32_t inline TestBoard(CBoard &Board, int32_t nPieces, int32_t np1, int32_t np2, int32_t np3, int32_t RIndex ){
        
        CMoveList Moves;
        CBoard OldBoard = Board;
        int32_t Result, nLosses, Win, Loss, Index, i, bFlip;
        int32_t nTotalWins = 0;
        
        for (int32_t stm = 0; stm < 2; stm++) {
            Board.SideToMove = stm+1;
            OldBoard.SideToMove = stm+1;
            
            Index = GetIndexFromBoard(Board, bFlip, nPieces);
            if (nPieces == 2)
                pResults = ResultsTwo;
            else if (nPieces == 3)
                pResults = ResultsThree;
            else if (nPieces == 4)
                pResults = ResultsFour;
            if (nPieces == 3) {
                Index = np1 + np2*32 + np3*32*32 + stm*32*32*32 + (RIndex) * (32*32*32*2);
            }
            
            if (GetResult(pResults, Index) != 0) {
                nTotalWins++;
                continue;
            }
            
            if (Board.SideToMove == WHITE) {
                Moves.FindMovesWhite(Board.Sqs, Board.C);
                Win = 2;
                Loss = 1;
            } else {
                Moves.FindMovesBlack(Board.Sqs, Board.C);
                Win = 1;
                Loss = 2;
            }
            
            if (Moves.nMoves == 0) {
                SetResult( Index, Loss );
                nTotalWins++;
            } // Can't move, so it's a loss
            else if (Moves.nMoves != 0) {
                nLosses = 0;
                // Check the moves. If a move wins this is a win, if they all lose it's a loss, otherwise it's a draw
                for (i = 1; i <= Moves.nMoves; i++) {
                    Board.DoMove( Moves.Moves[i], SEARCHED);
                    Result = QueryDatabase( Board );
                    Board  = OldBoard;
                    if ( Result == Win ) {
                        SetResult(Index, Win);
                        nTotalWins++;
                        break;
                    }
                    if (Result == Loss)
                        nLosses++;
                }
                if (nLosses == Moves.nMoves) {
                    SetResult (Index, Loss);
                    nTotalWins++;
                }
            }
        }
        return nTotalWins;
    }
    //
    // This function will generate a win/loss/draw database. It's actually not hard to generate such a database.
    // Doing a good job is the tough part, but since I only want small databases for now, this is at least works.
    //
    void GenDatabase(int32_t Piece1, int32_t Piece2, int32_t Piece3, int32_t Piece4, int32_t RIndex ){
        
        CBoard Board;
        
        int32_t nLastTotalWins = -1, nTotalWins = 0;
        int32_t it = 0, nPieces = -1, bFlip;
        
        while (nTotalWins != nLastTotalWins) // Keep going until we reach a plateau
        {
            nLastTotalWins = nTotalWins;
            nTotalWins = 0;
            
            // Loop through every possible position
            for (int32_t np1 = 0; np1 < 32; np1++)
                for (int32_t np2 = 0; np2 < 32; np2++)
                    for (int32_t np3 = 0; np3 < 32; np3++) {
                        for (int32_t np4 = 0; np4 < 32; np4++) {
                            // Skip Illegal Positions
                            if (np1 == np2) continue;
                            if (Piece3 != EMPTY)
                                if (np1 == np3 || np2 == np3) continue;
                            if (Piece4 != EMPTY)
                                if (np4 == np3 || np4 == np2 || np4 == np1) continue;
                            
                            // Setup the board
                            Board.Clear( );
                            Board.Sqs[ BoardLoc32[np4] ] = Piece4;
                            Board.Sqs[ BoardLoc32[np3] ] = Piece3;
                            Board.Sqs[ BoardLoc32[np2] ] = Piece2;
                            Board.Sqs[ BoardLoc32[np1] ] = Piece1;
                            Board.C.ConvertFromSqs( Board.Sqs );
                            // Skip illegal positions( checker on back row )
                            if (Board.C.WP & ~Board.C.K & (S[0]|S[1]|S[2]|S[3]))
                                continue;
                            if (Board.C.BP & ~Board.C.K & (S[28]|S[29]|S[30]|S[31]))
                                continue;
                            
                            if (nPieces == -1) {
                                GetIndexFromBoard( Board, bFlip, nPieces );
                                if (bFlip)
                                    return;
                            }
                            nTotalWins += TestBoard( Board, nPieces, np1, np2, np3, RIndex );
                            
                            if (Piece4 == EMPTY)
                                break;
                        }
                        if (Piece3 == EMPTY)
                            break;
                    }
            it++;
        }
    }
    
    void LoadAllDatabases(char *endgame2pcpath, char *endgame3pcpath, char *endgame4pcpath)
    {    
        ComputeAllIndices();
        g_bDatabases = 1;

#ifndef Android
        FILE *FP;
        if ((FP = fopen (endgame2pcpath, "rb"))) {
            if (fread (ResultsTwo , 4, SIZE2, FP ) != SIZE2) {
                printf("error reading 2pc database from %s\n", endgame2pcpath);
            } else {
                printf("2pc database loaded from %s\n", endgame2pcpath);
            }
            fclose (FP);         
        } else
            g_bDatabases = 0;
        
        if((FP = fopen (endgame3pcpath, "rb"))) {
            if (fread (ResultsThree, 6, SIZE3, FP ) != SIZE3) {
                printf("error reading 3pc database from %s\n", endgame3pcpath);
            } else {
                printf("3pc database loaded from %s\n", endgame3pcpath);
            }
            fclose (FP);        
        } else
            g_bDatabases = 0;
        
        if ((FP = fopen (endgame4pcpath, "rb"))) {
            if (fread (ResultsFour, 1, SIZE4 , FP ) != SIZE4) {
                printf("error reading 4pc database from %s\n", endgame4pcpath);
            } else {
                printf("4pc database loaded from %s\n", endgame4pcpath);
            }
            fclose (FP);         
        } else
            g_bDatabases = 0;
#else
        {
            AAsset *FP = AAssetManager_open(assetManager, endgame2pcpath, AASSET_MODE_BUFFER);
            if ((FP != NULL)) {
                if (AAsset_read(FP, ResultsTwo , 4 * SIZE2) != SIZE2) {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error reading 2pc database from %s\n", endgame2pcpath);
                } else {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "2pc database loaded from %s\n", endgame2pcpath);
                }
                AAsset_close(FP);
            } else
                g_bDatabases = 0;
        }
        {
            AAsset *FP = AAssetManager_open(assetManager, endgame3pcpath, AASSET_MODE_BUFFER);
            if((FP != NULL)) {
                if (AAsset_read(FP, ResultsThree , 6* SIZE3) != SIZE3) {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error reading 3pc database from %s\n", endgame3pcpath);
                } else {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "3pc database loaded from %s\n", endgame3pcpath);
                }
                AAsset_close(FP);
            } else
                g_bDatabases = 0;
        }
        {
            AAsset *FP = AAssetManager_open(assetManager, endgame4pcpath, AASSET_MODE_BUFFER);
            if ((FP != NULL)) {
                if (AAsset_read(FP, ResultsFour , 1 * SIZE4) != SIZE4) {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error reading 4pc database from %s\n", endgame4pcpath);
                } else {
                    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "4pc database loaded from %s\n", endgame4pcpath);
                }
                AAsset_close(FP);
            } else
                g_bDatabases = 0;
        }
#endif
        
        if (g_bDatabases == 1)
            printf("Endgame databases loaded\n");
        else
            printf("Endgame databases NOT loaded\n");
        
    }
}
