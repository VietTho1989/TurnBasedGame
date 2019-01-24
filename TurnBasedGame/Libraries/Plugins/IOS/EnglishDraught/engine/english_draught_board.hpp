//
//  board.h
//  EnglishDraught
//
//  Created by Viet Tho on 7/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef english_draught_board_hpp
#define english_draught_board_hpp

#include <cstdlib>

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include <cstring>
#include <cstdio>
#include "english_draught_movegen.hpp"

namespace EnglishDraught
{
#define TRUE 1
#define FALSE 0
    
    //#define KING_VAL 33
    
    extern int32_t g_bDatabases;
    // extern const uint32_t HASHTABLESIZE;
    #define HASHTABLESIZE 100000 // 700,000 entries * 12 bytes per entry
    
    extern const char* EnglishDraughtStartFen;
    
    struct CBoard
    {
    public:
        void StartPosition(int32_t bResetRep);
        void Clear();
        void SetFlags();
        int32_t EvaluateBoard (int32_t pickBestMove, int32_t ahead, int32_t alpha, int32_t beta);
        int32_t InDatabase() {
            if (!g_bDatabases || nWhite > 2 || nBlack > 2 ) return 0;
            return 1;
        }
        void ToFen(char *sFEN);
        int32_t FromFen(const char *sFEN);
        
        int32_t DoMove(SMove &Move, int32_t nType);
        void DoSingleJump(int32_t src, int32_t dst, int32_t nPiece);
        void CheckKing(int32_t src, int32_t dst, int32_t nPiece);
        void UpdateSqTable(int32_t nPiece, int32_t src, int32_t dst );
        
    public:
        void print(char* ret, SMove* lastMove);
        
    public:
        // Data
        char Sqs[48];
        SCheckerBoard C;
        int16_t nPSq, eval;
        char nWhite, nBlack, SideToMove, extra;
        uint64_t HashKey;
        
        // Check for a repeated board
        // (only checks every other move, because side to move must be the same)
        uint32_t ply = 0;
        int64_t RepNum[MAX_GAMEMOVES];
        uint32_t maxPly = 100;
        uint32_t turn = 0;
        
        //////////////////////////////////////////////////////////////////
        ////////////// Convert ////////////////
        //////////////////////////////////////////////////////////////////
        
    public:
        int32_t getByteSize();
        
        static int32_t convertToByteArray(struct CBoard* cBoard, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct CBoard* cBoard, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
        //////////////////////////////////////////////////////////////////
        ////////////// Repetition ////////////////
        //////////////////////////////////////////////////////////////////
        
        // with Hashvalue passed
        int32_t inline Repetition(const int64_t HashKey, int32_t nStart, int32_t ahead) {
            // printf("check repetion: %lld, %d, %d\n", HashKey, nStart, ahead);
            ahead+=ply;
            // TODO tu them vao
            int32_t i;
            if (nStart > 0)
                i = nStart;
            else
                i = 0;
            
            if ((i&1) != (ahead&1))
                i++;
            
            ahead-=2;
            for ( ; i < ahead; i+=2)
                if (RepNum[i] == HashKey) {
                    // printf("repetition true: %lld, %d, %d\n", HashKey, nStart, ahead);
                    return TRUE;
                }
            // printf("repetion false\n");
            return FALSE;
        }
        
        void inline AddRepBoard(const int64_t HashKey, int32_t ahead) {
            // printf("AddRepBoard: %lld, %d\n", HashKey, ahead);
            int32_t turnAhead = ply + ahead;
            if(turnAhead>=0 && turnAhead<MAX_GAMEMOVES){
                RepNum[ply + ahead] = HashKey;
            } else {
                printf("error, turn ahead error: %d, %d\n", ply, ahead);
            }
        }
    };
    
    // =================================================
    //
    //              TRANSPOSITION TABLE
    //
    // =================================================
    extern unsigned char g_ucAge;
    
    struct TEntry
    {
        // FUNCTIONS
    public:
        void inline Read(uint64_t CheckSum, int16_t alpha, int16_t beta, int32_t &bestmove, int32_t &value, int32_t depth, int32_t ahead)
        {
            if (m_checksum == CheckSum ) //To be almost totally sure these are really the same position.
            {
                int32_t tempVal = 0;
                // Get the Value if the search was deep enough, and bounds usable
                if (m_depth >= depth)
                {
                    if (abs(m_eval) > 1800) // This is a game ending value, must adjust it since it depends on the variable ahead
                    {
                        if (m_eval > 0) tempVal = m_eval - ahead + m_ahead;
                        if (m_eval < 0) tempVal = m_eval + ahead - m_ahead;
                    }
                    else tempVal = m_eval;
                    switch ( m_failtype )
                    {
                        case 0: value = tempVal;  // Exact value
                            break;
                        case 1: if (tempVal <= alpha) value = tempVal; // Alpha Bound (check to make sure it's usuable)
                            break;
                        case 2: if (tempVal >= beta) value = tempVal; //  Beta Bound (check to make sure it's usuable)
                            break;
                    }
                }
                // Otherwise take the best move from Transposition Table
                bestmove = m_bestmove;
            }
        }
        
        void inline Write(uint64_t CheckSum, int16_t alpha, int16_t beta, int32_t &bestmove, int32_t &value, int32_t depth, int32_t ahead)
        {
            if (m_age == g_ucAge && m_depth > depth && m_depth > 14)
                return; // Don't write over deeper entries from same search
            m_checksum = CheckSum;
            m_eval = value;
            m_ahead = ahead;
            m_depth = depth;
            m_bestmove = bestmove;
            m_age = g_ucAge;
            if (value <= alpha)
                m_failtype = 1;
            else if (value >= beta)
                m_failtype = 2;
            else
                m_failtype = 0;
        }
        
        static void Create_HashFunction();
        static uint64_t HashBoard( const CBoard &Board );
        
        // DATA
    private:
        uint64_t m_checksum;
        int16_t m_eval;
        int16_t m_bestmove;
        char m_depth;
        char m_failtype, m_ahead;
        unsigned char m_age;
    };
    
    // Flip square horizontally because the internal board is flipped.
    int64_t FlipX(int32_t x);
}

#endif /* board_h */
