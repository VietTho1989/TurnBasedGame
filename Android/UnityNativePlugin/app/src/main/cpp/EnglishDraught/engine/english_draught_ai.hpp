//
//  ai.h
//  EnglishDraught
//
//  Created by Viet Tho on 7/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef english_draught_ai_hpp
#define english_draught_ai_hpp

#include <ctime>
#include "english_draught_board.hpp"

namespace EnglishDraught
{
    void InitEngine(char *endgame2pcpath, char *endgame3pcpath, char *endgame4pcpath);
    
    extern int32_t BEGINNER_DEPTH;
    extern int32_t NORMAL_DEPTH;
    extern int32_t EXPERT_DEPTH;
    
    struct AI
    {
        bool threeMoveRandom = true;
        
        int32_t g_SelectiveDepth;
        int64_t nodes;
        int64_t nodes2;
        int32_t bCheckerBoard = 0;
        int32_t g_pbPlayNow = 0;
        int32_t g_bStopThinking = 0;
        clock_t starttime, endtime, lastTime = 0;
        float fMaxSeconds = 15.0f, g_fPanic;
        int32_t g_bEndHard = true;
        int32_t g_SearchingMove = 0, g_SearchEval = 0;
        int32_t SearchDepth;
        int32_t g_MaxDepth = 12;
        int32_t g_nMoves = 0;
        int32_t g_nDouble = 0;
        
        int32_t hashing;
        
        int32_t pickBestMove = 90;
    public:
        CMoveList* g_Movelist = (CMoveList*)calloc(sizeof(CMoveList)*(MAX_SEARCHDEPTH + 1), sizeof(uint8_t));
        SMove* g_GameMoves = (SMove*)calloc(sizeof(SMove)*MAX_GAMEMOVES, sizeof(uint8_t));
        
        CBoard* g_Boardlist = (CBoard*)calloc(sizeof(CBoard)*(MAX_SEARCHDEPTH + 1), sizeof(uint8_t));
        // CBoard g_CBoard;
        CBoard g_StartBoard;
        
        // Declare and allocate the transposition table
        TEntry* TTable = (TEntry*)calloc(sizeof(TEntry)*HASHTABLESIZE + 2, sizeof(uint8_t));
        
        ~AI()
        {
            free(g_Movelist);
            free(g_GameMoves);
            free(g_Boardlist);
            free(TTable);
        }
        
    public:
        int32_t QuiesceBoard(int32_t color, int32_t ahead, int32_t alpha, int32_t beta);
        
        void inline DoExtensions(int32_t &nextDepth, int32_t &fracDepth, int32_t ahead, uint64_t nMove);
        
        int16_t ABSearch(CBoard &g_CBoard, int32_t color, int32_t ahead, int32_t depth, int32_t fracDepth, int16_t alpha, int16_t beta, int32_t &bestmove);
        
        int32_t ComputerMove(char cColor, CBoard &InBoard);
        
        void RunningDisplay(CBoard &g_CBoard, int32_t bestMove, int32_t bSearching);
        
        void NewGame();
        
        void ReplayGame(int32_t nMove, CBoard &Board);
        
        int32_t SquareMove(CBoard &Board, int32_t src , int32_t dst, char cColor);
        
    public:
        SMove bestMove;
        
    };
    
    int32_t CheckForGameOver(CBoard& g_CBoard);
}

#endif /* english_draught_ai_h */
