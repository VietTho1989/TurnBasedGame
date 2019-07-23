//
//  solitaire_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 12/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef solitaire_jni_hpp
#define solitaire_jni_hpp

#include <stdio.h>
#include <cstdint>
#include "../Platform.h"

namespace Solitaire
{
    extern "C"
    {
        
        EXPORTED int32_t solitaire_makeDefaultPosition(int32_t drawCount, uint8_t* &outRet);
        
        EXPORTED int32_t solitaire_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED int32_t solitaire_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int multiThreaded, int maxClosedCount, bool fastMode, uint8_t* &outRet);
        
        EXPORTED int32_t solitaire_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
        EXPORTED int32_t solitaire_reset(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED int32_t solitaire_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
        
        EXPORTED int32_t solitaire_printMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
    }
}

#endif /* solitaire_jni_hpp */
