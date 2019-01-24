//
//  jni.hpp
//  TestOthello
//
//  Created by Viet Tho on 3/20/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef reversi_jni_hpp
#define reversi_jni_hpp

#include <stdio.h>
#include "reversi_common.hpp"

namespace Reversi
{
    extern "C"
    {
        
        void reversi_setBookPath(const char* newBookPath);

        int32_t reversi_makeDefaultPosition(uint8_t* &outRet);
        
        void reversi_printMove(int8_t move, char* result);
        
        void reversi_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);

        int32_t reversi_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int8_t reversi_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t sort, int32_t min, int32_t max, int32_t end, int32_t msLeft, bool useBook, int32_t percent);
        
        bool reversi_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int8_t move);

        int32_t reversi_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int8_t move, uint8_t* &outRet);
    }
}

#endif /* jni_hpp */
