//
//  nmm_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 1/3/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#ifndef nmm_jni_hpp
#define nmm_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace NMM
{
    extern "C"
    {
        
        const int32_t DrawTurn = 2000;
        
        int32_t nmm_makeDefaultPosition(uint8_t* &outRet);
        
        int32_t nmm_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t nmm_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t MaxNormal, int32_t MaxPositioning, int32_t MaxBlackAndWhite3, int32_t MaxBlackOrWhite3, int32_t pickBestMove, uint8_t* &outRet);
        
        bool nmm_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);
        
        int32_t nmm_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet);
        
        int32_t nmm_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        int32_t nmm_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
    
    }
}

#endif /* nmm_jni_hpp */
