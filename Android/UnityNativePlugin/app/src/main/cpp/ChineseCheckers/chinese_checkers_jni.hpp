//
//  chinese_checkers_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 1/31/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#ifndef chinese_checkers_jni_hpp
#define chinese_checkers_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace ChineseCheckers
{
    extern "C"
    {
        
        EXPORTED int32_t chinese_checkers_makePositionByFen(const char* strFen, uint8_t* &outRet);
        
        EXPORTED int32_t chinese_checkers_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t chinese_checkers_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t type, int32_t depth, int32_t time, int32_t node, int32_t pickBestMove, uint8_t* &outRet);
        
        EXPORTED bool chinese_checkers_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);
        
        EXPORTED int32_t chinese_checkers_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
        EXPORTED int32_t chinese_checkers_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        EXPORTED int32_t chinese_checkers_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
        
    }
}

#endif /* chinese_checkers_jni_hpp */
