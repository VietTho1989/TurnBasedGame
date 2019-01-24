//
//  shatranj.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_jni_hpp
#define shatranj_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace Shatranj
{
    extern "C"
    {
        void shatranj_initCore();
        
        void shatranj_printMove(int32_t move);
        
        int32_t shatranj_makePositionByFen(const char* strFen, bool isChess960, uint8_t* &outRet);
        
        void shatranj_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        void shatranj_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        bool shatranj_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// LetComputerThink /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        int32_t shatranj_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t shatranj_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration);
        
        bool shatranj_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);
        
        int32_t shatranj_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
        int32_t shatranj_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        int32_t shatranj_position_to_fen(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrFen);
        
    }
}

#endif /* shatranj_hpp */
