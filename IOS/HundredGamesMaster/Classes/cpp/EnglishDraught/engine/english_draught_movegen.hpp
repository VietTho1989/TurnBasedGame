//
//  movegen.h
//  EnglishDraught
//
//  Created by Viet Tho on 7/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef english_draught_movegen_hpp
#define english_draught_movegen_hpp

#include <cstdint>

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
    
    // Convert between 32 square board and internal 44 square board
    extern int32_t BoardLocTo32[48];
    extern int32_t BoardLoc32[32];
    
    void InitBitTables();
    
    // =================================================
    //
    //              MOVE GENERATION
    //
    // =================================================
    struct SMove
    {
        uint64_t SrcDst;
        char cPath[12];
        
        //////////////////////////////////////////////////////////////////
        ////////////// Convert ////////////////
        //////////////////////////////////////////////////////////////////
        
    public:
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(struct SMove* sMove, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct SMove* sMove, uint8_t* moveBytes, int32_t moveLength, int32_t start, bool canCorrect);
        
        void print(char* ret);
    };
    
    struct SCheckerBoard
    {
        uint64_t WP, BP, K;
        
        int32_t GetBlackMoves();
        int32_t GetWhiteMoves( );
        uint32_t GetJumpersWhite( );
        uint32_t GetJumpersBlack( );
        uint32_t GetMoversWhite( );
        uint32_t GetMoversBlack( );
        void ConvertFromSqs(char sqs[]);
        
        //////////////////////////////////////////////////////////////////
        ////////////// Convert ////////////////
        //////////////////////////////////////////////////////////////////
    public:
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(struct SCheckerBoard* sCheckerBoard, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct SCheckerBoard* sCheckerBoard, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
    };
    
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
    
    extern uint32_t MASK_L3, MASK_L5, MASK_R3, MASK_R5, MASK_TOP, MASK_BOTTOM, MASK_TRAPPED_W, MASK_TRAPPED_B, MASK_2ND, MASK_7TH;
    extern uint32_t MASK_EDGES, MASK_2CORNER1, MASK_2CORNER2;
    extern uint32_t S[32];
    extern unsigned char aBitCount[65536];
    extern unsigned char aLowBit[65536];
    extern unsigned char aHighBit[65536];
    
    uint32_t inline BitCount(uint32_t Moves )
    {
        if (Moves == 0) return 0;
        return aBitCount[ (Moves & 65535) ] + aBitCount[ ((Moves>>16) & 65535) ];
    }
    
    uint32_t inline FindLowBit(uint32_t Moves )
    {
        if ( (Moves & 65535) ) return aLowBit[ (Moves & 65535) ];
        if ( ((Moves>>16) & 65535) ) return aLowBit[ ((Moves>>16) & 65535) ] + 16;
        return 0;
    }
    
    uint32_t inline FindHighBit(uint32_t Moves )
    {
        if ( ((Moves>>16) & 65535) ) return aHighBit[ ((Moves>>16) & 65535) ] + 16;
        if ( (Moves & 65535) ) return aHighBit[ (Moves & 65535) ];
        return 0;
    }
    
    struct CMoveList {
        
        // FUNCTIONS
        void inline Clear() {
            nJumps = 0;
            nMoves = 0;
        }
        
        void inline SetMove( SMove &Move, int32_t src, int32_t dst)
        {
            Move.SrcDst = (src)+(dst<<6) + (1<<12);
        }
        
        void inline AddJump(SMove &Move, int32_t pathNum)
        {
            Move.cPath[pathNum] = 0;
            Moves[ ++nJumps ] = Move;
        }
        
        void inline AddMove (int32_t src, int32_t dst)
        {
            Moves[ ++nMoves ].SrcDst = (src)+(dst<<6);
            return;
        }
        
        void inline AddSqDir(char board[], int32_t square, int32_t &nSqMoves, int32_t nPiece, int32_t pathNum, const int32_t DIR, const int32_t OPP_PIECE );
        
        void inline CheckJumpDir(char board[], int32_t square, const int32_t DIR, const int32_t nOppPiece);
        
        void FindMovesBlack(char board[], SCheckerBoard &C);
        void FindMovesWhite(char board[], SCheckerBoard &C);
        void FindJumpsBlack(char board[], int32_t Movers);
        void FindJumpsWhite(char board[], int32_t Movers);
        void FindNonJumpsBlack(char board[], int32_t Movers);
        void FindNonJumpsWhite(char board[], int32_t Movers);
        void inline FindSqJumpsBlack(char board[], int32_t square, int32_t nPiece, int32_t pathNum, int32_t nJumpSq);
        void inline FindSqJumpsWhite(char board[], int32_t square, int32_t nPiece, int32_t pathNum, int32_t nJumpSq);
        
        // DATA
        int32_t nMoves, nJumps;
        SMove Moves[36];
        SMove m_JumpMove;
    };
}

#endif /* movegen_hpp */
