//
//  russian_draught_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 8/22/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef russian_draught_jni_hpp
#define russian_draught_jni_hpp

#include <stdio.h>
#include <cstdint>
#include "../Platform.h"

namespace RussianDraught
{
    
    extern "C"
    {
        
        EXPORTED void russian_draught_initCore();
        
        EXPORTED int32_t russian_draught_makePositionByFen(const char* strFen, uint8_t* &outRet);
        
        EXPORTED int32_t russian_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t russian_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t timeLimit, int32_t pickBestMove, uint8_t* &outRet);
        
        EXPORTED bool russian_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);
        
        EXPORTED int32_t russian_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
        EXPORTED int32_t russian_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED int32_t russian_draught_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
        
        EXPORTED int32_t russian_draught_printMove(uint8_t* moveBytes, int32_t moveLength, bool canCorrect, uint8_t* &outStrMove);
        
        EXPORTED int32_t russian_draught_position_to_fen(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrFen);
        
    }
    
}

#endif /* russian_draught_jni_hpp */
