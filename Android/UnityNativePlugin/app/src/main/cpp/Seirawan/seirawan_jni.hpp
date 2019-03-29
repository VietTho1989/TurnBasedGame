//
//  seirawan_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 8/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef seirawan_jni_hpp
#define seirawan_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace Seirawan
{
    extern "C"
    {
        
        EXPORTED void seirawan_initCore();
        
        EXPORTED void seirawan_printMove(int32_t move);
        
        EXPORTED int32_t seirawan_makePositionByFen(const char* strFen, bool isChess960, uint8_t* &outRet);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// Print Position /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        EXPORTED void seirawan_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t seirawan_getStrPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition);
        
        EXPORTED void seirawan_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t seirawan_getPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// LetComputerThink /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        EXPORTED bool seirawan_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t seirawan_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t seirawan_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration);
        
        EXPORTED bool seirawan_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);
        
        EXPORTED int32_t seirawan_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
        EXPORTED int32_t seirawan_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
    
    }
}

#endif /* seirawan_jni_hpp */
