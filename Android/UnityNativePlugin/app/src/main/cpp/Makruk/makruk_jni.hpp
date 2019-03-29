//
//  makruk_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 7/24/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef makruk_jni_hpp
#define makruk_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace Makruk
{
    extern "C"
    {
        
        EXPORTED void makruk_initCore();
        
        EXPORTED void makruk_printMove(int32_t move);
        
        EXPORTED int32_t makruk_makePositionByFen(const char* strFen, bool isChess960, uint8_t* &outRet);
        
        EXPORTED void makruk_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED void makruk_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED bool makruk_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// LetComputerThink /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        EXPORTED int32_t makruk_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t makruk_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration);
        
        EXPORTED bool makruk_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);
        
        EXPORTED int32_t makruk_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
        EXPORTED int32_t makruk_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED int32_t makruk_position_to_fen(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrFen);
        
    }
}

#endif /* makruk_jni_hpp */
