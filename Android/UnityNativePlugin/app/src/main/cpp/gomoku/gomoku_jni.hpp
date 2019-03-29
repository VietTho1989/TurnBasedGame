//
//  jni.hpp
//  gomoku
//
//  Created by Viet Tho on 4/12/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_jni_hpp
#define gomoku_jni_hpp

#include <stdio.h>
#include <stdint.h>
#include "../Platform.h"

extern "C"
{
    namespace gomoku
    {
        
        EXPORTED void gomoku_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t gomoku_makeDefaultPosition(int32_t size, uint8_t* &outRet);

        EXPORTED int32_t gomoku_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t gomoku_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t searchDepth, int32_t timeLimit, int32_t level);
        
        EXPORTED bool gomoku_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);

        EXPORTED int32_t gomoku_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
    }
}

#endif /* jni_hpp */
