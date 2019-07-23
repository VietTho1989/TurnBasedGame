/*
    movegen.cpp   
   
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

#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "english_draught_movegen.hpp"
#include "english_draught_board.hpp"

namespace EnglishDraught
{
    // Convert between 32 square board and internal 44 square board
    int32_t BoardLocTo32[48] = { 0, 0, 0, 0, 0, 0, 1, 2, 3, 0, 4, 5, 6, 7, 8,  9, 10, 11, 0, 12, 13, 14, 15, 16, 17, 18, 19, 0, 20, 21, 22, 23, 24, 25, 26, 27, 0, 28, 29, 30, 31};
    int32_t BoardLoc32[32] = { 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 31, 32, 33, 34, 35, 37, 38, 39, 40};
    
    //
    // BITBOARD INITILIZATION
    //
    
    //  28 29 30 31
    // 24 25 26 27
    //  20 21 22 23
    // 16 17 18 19
    //  12 13 14 15
    // 08 09 10 11
    //  04 05 06 07
    // 00 01 02 03
    
    uint32_t MASK_L3, MASK_L5, MASK_R3, MASK_R5, MASK_TOP, MASK_BOTTOM, MASK_TRAPPED_W, MASK_TRAPPED_B, MASK_2ND, MASK_7TH;
    uint32_t MASK_EDGES, MASK_2CORNER1, MASK_2CORNER2;
    uint32_t S[32];
    unsigned char aBitCount[65536];
    unsigned char aLowBit[65536];
    unsigned char aHighBit[65536];
    
    void InitBitTables()
    {
        S[0] = 1;
        for (int32_t i = 1; i < 32; i++)
            S[i] = S[i-1] * 2;
        
        MASK_L3 = S[1] | S[2] | S[3] | S[9] | S[10] | S[11] | S[17] | S[18] | S[19] | S[25] | S[26] | S[27];
        MASK_L5 = S[4] | S[5] | S[6] | S[12] | S[13] | S[14] | S[20] | S[21] | S[22];
        MASK_R3 = S[28] | S[29] | S[30] | S[20] | S[21] | S[22] | S[12] | S[13] | S[14] | S[4] | S[5] | S[6];
        MASK_R5 = S[25] | S[26] | S[27] | S[17] | S[18] | S[19] | S[9] | S[10] | S[11];
        MASK_TOP = S[28] | S[29] | S[30] | S[31] | S[24] | S[25] | S[26] | S[27] | S[20] | S[21] | S[22] | S[23];
        MASK_BOTTOM = S[0] | S[1] | S[2] | S[3] | S[4] | S[5] | S[6] | S[7] | S[8] | S[9] | S[10] | S[11];
        MASK_TRAPPED_W = S[0] | S[1] | S[2] | S[3] | S[4];
        MASK_TRAPPED_B = S[28] | S[29] | S[30] | S[31] | S[27];
        MASK_2ND = S[4] | S[5] | S[6] | S[7];
        MASK_7TH = S[24] | S[25] | S[26] | S[27];
        MASK_EDGES = S[24] | S[20] | S[16] | S[12] | S[8] | S[4] | S[0] | S[7] | S[11] | S[15] | S[19] | S[23] | S[27] | S[31];
        MASK_2CORNER1 = S[3] | S[7];
        MASK_2CORNER2 = S[24] | S[28];
        
        for (int32_t Moves = 0; Moves < 65536; Moves++) {
            int32_t nMoves = 0, nLow = 255, nHigh = 255;
            for (int32_t i = 0; i < 16; i++) {
                if (Moves & S[i]) {
                    nMoves++;
                    if (nLow == 255)
                        nLow = i;
                    nHigh = i;
                }
            }
            aLowBit[ Moves ] = nLow;
            aHighBit[ Moves ] = nHigh;
            aBitCount[ Moves ] = nMoves;
        }
    }
    
    //
    // BIT BOARD FUNCTIONS
    //
    uint32_t SCheckerBoard::GetMoversWhite()
    {
        const uint32_t nOcc = ~(WP | BP); // Not Occupied
        uint32_t Moves = (nOcc << 4);
        const uint32_t WK = WP&K;         // Kings
        Moves |= ((nOcc&MASK_L3) << 3);
        Moves |= ((nOcc&MASK_L5) << 5);
        Moves &= WP;
        if ( WK ) {
            Moves |= (nOcc >> 4) & WK;
            Moves |= ((nOcc&MASK_R3) >> 3) & WK;
            Moves |= ((nOcc&MASK_R5) >> 5) & WK;
        }
        return Moves;
    }
    
    uint32_t SCheckerBoard::GetMoversBlack()
    {
        const uint32_t nOcc = ~(WP | BP);
        uint32_t Moves = (nOcc >> 4) & BP;
        const uint32_t BK = BP&K;
        Moves |= ((nOcc&MASK_R3) >> 3) & BP;
        Moves |= ((nOcc&MASK_R5) >> 5) & BP;
        if (BK) {
            Moves |= (nOcc << 4) & BK;
            Moves |= ((nOcc&MASK_L3) << 3) & BK;
            Moves |= ((nOcc&MASK_L5) << 5) & BK;
        }
        return Moves;
    }
    
    int32_t SCheckerBoard::GetWhiteMoves()
    {
        const uint32_t nOcc = ~(WP | BP);
        int32_t nMoves = BitCount((nOcc << 4) & WP);
        nMoves += BitCount((((nOcc&MASK_L3) << 3) | ((nOcc&MASK_L5) << 5) ) & WP);
        const uint32_t WK = WP&K;
        if (WK) {
            nMoves += BitCount((nOcc >> 4) & WK);
            nMoves += BitCount((((nOcc&MASK_R3) >> 3) | ((nOcc&MASK_R5) >> 5) ) & WK);
        }
        return nMoves;
    }
    
    int32_t SCheckerBoard::GetBlackMoves( )
    {
        const uint32_t nOcc = ~(WP | BP);
        int32_t nMoves = BitCount( (nOcc >> 4) & BP );
        nMoves += BitCount( ( ((nOcc&MASK_R3) >> 3) | ((nOcc&MASK_R5) >> 5) ) & BP );
        const uint32_t BK = BP&K;
        if (BK) {
            nMoves += BitCount( (nOcc << 4) & BK );
            nMoves += BitCount( ( ((nOcc&MASK_L3) << 3) | ((nOcc&MASK_L5) << 5) ) & BK );
        }
        return nMoves;
    }
    
    uint32_t SCheckerBoard::GetJumpersWhite()
    {
        const uint32_t nOcc = ~(WP | BP);
        const uint32_t WK = WP&K;
        uint32_t Movers = 0;
        uint32_t Temp = (nOcc << 4) & BP;
        if (Temp)
            Movers |= (((Temp&MASK_L3) << 3) | ((Temp&MASK_L5) << 5)) & WP;
        Temp = (((nOcc&MASK_L3) << 3) | ((nOcc&MASK_L5) << 5) ) & BP;
        Movers |= (Temp << 4) & WP;
        if (WK) {
            Temp = (nOcc>> 4) & BP;
            if (Temp)
                Movers |= (((Temp&MASK_R3) >> 3) | ((Temp&MASK_R5) >> 5)) & WK;
            Temp = (((nOcc&MASK_R3) >> 3) | ((nOcc&MASK_R5) >> 5) ) & BP;
            if (Temp)
                Movers |= (Temp >> 4) & WK;
        }
        return Movers;
    }
    
    uint32_t SCheckerBoard::GetJumpersBlack()
    {
        const uint32_t nOcc = ~(WP | BP);
        const uint32_t BK = BP&K;
        uint32_t Movers = 0;
        uint32_t Temp = (nOcc >> 4) & WP;
        if (Temp) Movers |= (((Temp&MASK_R3) >> 3) | ((Temp&MASK_R5) >> 5)) & BP;
        Temp = ( ((nOcc&MASK_R3) >> 3) | ((nOcc&MASK_R5) >> 5) ) & WP;
        Movers |= (Temp >> 4) & BP;
        if (BK) {
            Temp = (nOcc<< 4) & WP;
            if (Temp) Movers |= (((Temp&MASK_L3) << 3) | ((Temp&MASK_L5) << 5)) & BK;
            Temp = ( ((nOcc&MASK_L3) << 3) | ((nOcc&MASK_L5) << 5) ) & WP;
            if (Temp) Movers |= (Temp << 4) & BK;
        }
        return Movers;
    }
    
    void SCheckerBoard::ConvertFromSqs(char Sq[])
    {
        WP = 0;
        BP = 0;
        K = 0;
        for (int32_t i = 0; i < 32; i++) {
            switch (Sq[ BoardLoc32[i] ]) {
                case WPIECE: WP |= S[i]; break;
                case BPIECE: BP |= S[i]; break;
                case WKING:  K |= S[i]; WP |= S[i]; break;
                case BKING:  K |= S[i]; BP |= S[i]; break;
            }
        }
    }
    //
    //  E N D    B I T B O A R D S
    //
    
    // ------------------------------ FUNCTIONS --------------------------------
    // Check for a normal move in DIR, then if a normal move is not possible, check for a jump
    void inline CMoveList::CheckJumpDir(char board[], int32_t square, const int32_t DIR, const int32_t nOppPiece)
    {
        if ((board[square + DIR ]&nOppPiece) && board[square + 2*DIR ] == EMPTY)
        {// A jump is possible, call FindSqJumps to detect double/triple/etc. jumps
            SetMove (m_JumpMove, square, square + 2*DIR);
            if (nOppPiece == WPIECE) FindSqJumpsBlack( board, square + 2*DIR, board[ square ], 0, square + DIR);
            if (nOppPiece == BPIECE) FindSqJumpsWhite( board, square + 2*DIR, board[ square ], 0, square + DIR);
        }
    }
    // -------------------------------------------------
    // Find the Moves available on board, and store them in Movelist
    // -------------------------------------------------
    void CMoveList::FindMovesBlack(char board[], SCheckerBoard &C)
    {
        uint32_t Movers = C.GetJumpersBlack();
        if (Movers)
            FindJumpsBlack( board, Movers );
        else {
            FindNonJumpsBlack( board, C.GetMoversBlack() );
        }
    }
    
    void CMoveList::FindMovesWhite(char board[], SCheckerBoard &C)
    {
        uint32_t Movers = C.GetJumpersWhite( );
        
        
        if ( Movers ) {
            FindJumpsWhite( board, Movers );
        } else {
            FindNonJumpsWhite( board, C.GetMoversWhite( ) );
        }
    }
    
    void CMoveList::FindNonJumpsWhite(char board[], int Movers)
    {
        Clear( );
        while (Movers)
        {
            uint32_t sq = FindLowBit( Movers );
            Movers &= ~S[sq];
            int32_t square = BoardLoc32[ sq ];
            
            if ( board[square-5 ] == EMPTY ) AddMove( square, square-5);
            if ( board[square-4 ] == EMPTY ) AddMove( square, square-4);
            
            if (board[ square ] == WKING  ) {
                if ( board[square+4 ] == EMPTY ) AddMove( square, square+4);
                if ( board[square+5 ] == EMPTY ) AddMove( square, square+5);
            }
        }
    }
    
    void CMoveList::FindNonJumpsBlack(char board[], int32_t Movers)
    {
        Clear( );
        while (Movers) {
            uint32_t sq = FindHighBit( Movers );
            Movers &= ~S[sq];
            int32_t square = BoardLoc32[ sq ];
            
            if (board[square+4 ] == EMPTY) AddMove( square, square+4);
            if (board[square+5 ] == EMPTY) AddMove( square, square+5);
            
            if (board[ square ] == BKING) {
                if (board[square-5 ] == EMPTY)
                    AddMove(square, square-5);
                if (board[square-4 ] == EMPTY)
                    AddMove(square, square-4);
            }
        }
    }
    
    // -------------------------------------------------
    // These two functions only add jumps
    // -------------------------------------------------
    void CMoveList::FindJumpsBlack(char board[], int Movers)
    {
        Clear( );
        while (Movers) {
            uint32_t sq = FindHighBit( Movers );
            Movers &= ~S[sq];
            int square = BoardLoc32[ sq ];
            
            CheckJumpDir( board, square, 4, WPIECE );
            CheckJumpDir( board, square, 5, WPIECE );
            
            if (board[ square ] == BKING  ) {
                CheckJumpDir( board, square, -5, WPIECE );
                CheckJumpDir( board, square, -4, WPIECE );
            }
        }
        nMoves = nJumps;
    }
    
    void CMoveList::FindJumpsWhite(char board[], int32_t Movers )
    {
        Clear( );
        while (Movers) {
            uint32_t sq = FindLowBit( Movers );
            Movers &= ~ S[sq];
            int32_t square = BoardLoc32[ sq ];
            
            CheckJumpDir( board, square, -5, BPIECE );
            CheckJumpDir( board, square, -4, BPIECE );
            
            if (board[ square ] == WKING  ) {
                CheckJumpDir( board, square, 4, BPIECE );
                CheckJumpDir( board, square, 5, BPIECE );
            }
        }
        nMoves = nJumps;
    }
    
    // -------------
    //  If a jump move was possible, we must make the jump then check to see if the same piece can jump again.
    //  There might be multiple paths a piece can take on a double jump, these functions store each possible path as a move.
    // -------------
    void inline CMoveList::AddSqDir(char board[], int32_t square, int32_t &nSqMoves, int32_t nPiece, int32_t pathNum, const int32_t DIR, const int32_t OPP_PIECE )
    {
        if ((board[square + DIR ]&OPP_PIECE) && board[square + 2*DIR ] == EMPTY) {
            m_JumpMove.cPath[ pathNum ] = square + 2*DIR;
            nSqMoves++;
            if (OPP_PIECE == WPIECE) FindSqJumpsBlack( board, square+2*DIR, nPiece, pathNum+1, square + DIR);
            if (OPP_PIECE == BPIECE) FindSqJumpsWhite( board, square+2*DIR, nPiece, pathNum+1, square + DIR);
        }
    }
    
    void CMoveList::FindSqJumpsBlack(char board[], int32_t square, int32_t nPiece, int32_t pathNum, int32_t nJumpSq)
    {
        int32_t nSqMoves = 0;
        // Remove the jumped piece (until the end of this function), so we can't jump it again
        int32_t nJumpPiece = board[ nJumpSq ];
        board[ nJumpSq ] = EMPTY;
        
        // Now see if a piece on this square has more jumps
        AddSqDir ( board, square, nSqMoves, nPiece, pathNum, 4, WPIECE );
        AddSqDir ( board, square, nSqMoves, nPiece, pathNum, 5, WPIECE );
        if ( nPiece == BKING) 
        {// If this piece is a king, it can also jump backwards 
            AddSqDir ( board, square, nSqMoves, nPiece, pathNum, -5, WPIECE );
            AddSqDir ( board, square, nSqMoves, nPiece, pathNum, -4, WPIECE );
        }
        if (nSqMoves == 0) AddJump( m_JumpMove, pathNum); // this is a leaf, so store the move
        // Put back the jumped piece
        board[ nJumpSq ] = nJumpPiece;
    }
    
    void CMoveList::FindSqJumpsWhite(char board[], int32_t square, int32_t nPiece, int32_t pathNum, int32_t nJumpSq)
    {
        int32_t nSqMoves = 0;
        int32_t nJumpPiece = board[ nJumpSq ];
        board[ nJumpSq ] = EMPTY;
        
        AddSqDir ( board, square, nSqMoves, nPiece, pathNum, -4, BPIECE );
        AddSqDir ( board, square, nSqMoves, nPiece, pathNum, -5, BPIECE );  
        if ( nPiece == WKING) 
        {
            AddSqDir ( board, square, nSqMoves, nPiece, pathNum, 5, BPIECE );
            AddSqDir ( board, square, nSqMoves, nPiece, pathNum, 4, BPIECE );   
        }
        if (nSqMoves == 0) AddJump( m_JumpMove, pathNum );
        board[ nJumpSq ] = nJumpPiece;
    }
    
    //////////////////////////////////////////////////////////////////
    ////////////// Convert SMove ////////////////
    //////////////////////////////////////////////////////////////////
    
    int32_t SMove::getByteSize()
    {
        return sizeof(uint64_t) + 12;
    }
    
    int32_t SMove::convertToByteArray(struct SMove* sMove, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = SMove::getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // uint64_t SrcDst
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &sMove->SrcDst, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: sMove: %d, %d\n", pointerIndex, length);
                    }
                }
                // char cPath[12]
                {
                    int32_t size = 12;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &sMove->cPath, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: cPath: %d, %d\n", pointerIndex, length);
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
    
    int32_t SMove::parseByteArray(struct SMove* sMove, uint8_t* moveBytes, int32_t moveLength, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < moveLength) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // uint64_t SrcDst
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=moveLength){
                        memcpy(&sMove->SrcDst, moveBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: SrcDst: %d, %d\n", pointerIndex, moveLength);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // char cPath[12]
                {
                    int32_t size = 12;
                    if(pointerIndex+size<=moveLength){
                        memcpy(&sMove->cPath, moveBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: cPath: %d, %d\n", pointerIndex, moveLength);
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
            printf("error position parse fail: %d; %d; %d\n", pointerIndex, moveLength, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
    void SMove::print(char* ret)
    {
        ret[0] = 0;
        char cCap = (SrcDst>>12) ? 'x' : '-';
        sprintf(ret, "%s%ld%c%ld", ret, FlipX (BoardLocTo32[SrcDst&63])+1, cCap, FlipX (BoardLocTo32[(SrcDst>>6)&63])+1);
    }
    
    //////////////////////////////////////////////////////////////////
    ////////////// Convert ////////////////
    //////////////////////////////////////////////////////////////////
    
    int32_t SCheckerBoard::getByteSize()
    {
        return 3*sizeof(uint64_t);
    }
    
    int32_t SCheckerBoard::convertToByteArray(struct SCheckerBoard* sCheckerBoard, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = SCheckerBoard::getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // uint64_t WP
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &sCheckerBoard->WP, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: WP: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint64_t BP
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &sCheckerBoard->BP, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: BP: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint64_t K
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &sCheckerBoard->K, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: K: %d, %d\n", pointerIndex, length);
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
    
    int32_t SCheckerBoard::parseByteArray(struct SCheckerBoard* sCheckerBoard, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // uint64_t WP
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(&sCheckerBoard->WP, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: WP: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // uint64_t BP
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(&sCheckerBoard->BP, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: BP: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // uint64_t K
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length) {
                        memcpy(&sCheckerBoard->K, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    } else {
                        printf("length error: K: %d, %d\n", pointerIndex, length);
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
