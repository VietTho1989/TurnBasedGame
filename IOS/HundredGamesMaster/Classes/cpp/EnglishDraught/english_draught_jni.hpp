//
//  english_draught_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 7/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef english_draught_jni_hpp
#define english_draught_jni_hpp

#include <stdio.h>
#include <stdint.h>
#include "../Platform.h"
#include "engine/english_draught_board.hpp"

extern "C"
{
    namespace EnglishDraught
    {
        
        extern char englishDraughtPath[];
        
        EXPORTED bool english_draught_setPath(const char* newPath);
        
        EXPORTED void english_draught_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, SMove* lastMove);
        
        EXPORTED void english_draught_printMove(uint8_t* moveBytes, int32_t moveLength);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// Match /////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED void english_draught_initCore();
        
        EXPORTED int32_t english_draught_makeDefaultPosition(const char* englishDraughtFen, int maxPly, uint8_t* &outRet);
        
        EXPORTED int32_t english_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        
        EXPORTED int32_t english_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool threeMoveRandom, float fMaxSeconds, int32_t g_MaxDepth, int32_t pickBestMove, uint8_t* &outMove);
        
        EXPORTED bool english_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);
        
        EXPORTED int32_t english_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
        EXPORTED int32_t english_draught_getFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet);
        
        EXPORTED int32_t english_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
    }
}

#endif /* english_draught_jni_hpp */
