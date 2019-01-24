//
//  fairy_chess_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 8/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef fairy_chess_jni_hpp
#define fairy_chess_jni_hpp

#include <stdio.h>
#include "../Platform.h"
#include "fairy_chess_position.hpp"

namespace FairyChess
{
    extern "C"
    {
        
        void fairy_chess_initCore();
        
        void fairy_chess_printMove(int32_t move, Position* position);
        
        int32_t fairy_chess_makePositionByFen(VariantType variantType, const char* strFen, bool isChess960, uint8_t* &outRet);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// Print /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        void fairy_chess_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t fairy_chess_getStrPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition);
        
        void fairy_chess_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t fairy_chess_getPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen);
        
        int32_t fairy_chess_getStrMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int move, uint8_t* &outStrMove);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// LetComputerThink /////////////////////
        /////////////////////////////////////////////////////////////////////////////
        
        bool fairy_chess_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t fairy_chess_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t fairy_chess_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration);
        
        bool fairy_chess_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);
        
        int32_t fairy_chess_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
        int32_t fairy_chess_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
    }
}

#endif /* fairy_chess_jni_hpp */
