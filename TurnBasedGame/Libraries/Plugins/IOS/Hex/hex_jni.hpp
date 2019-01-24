//
//  hex_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 9/12/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef hex_jni_hpp
#define hex_jni_hpp

#include <stdio.h>
#include <cstdint>
#include "fhcore/hex_board.hpp"

namespace Hex
{
    extern "C"
    {
        
        int32_t hex_makeDefaultPosition(uint16_t boardSize, uint8_t* &outRet);
        
        int32_t hex_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        uint16_t hex_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t limitTime, bool firstMoveCenter);
        
        bool hex_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint16_t move);
        
        int32_t hex_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint16_t move, uint8_t* &outRet);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        int32_t hex_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
        
    }
}

#endif /* hex_jni_hpp */
