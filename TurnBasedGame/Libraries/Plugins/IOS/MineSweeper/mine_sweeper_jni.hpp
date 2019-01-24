//
//  mine_sweeper_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 9/4/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef mine_sweeper_jni_hpp
#define mine_sweeper_jni_hpp

#include <stdio.h>
#include <cstdint>

namespace MineSweeper
{
    extern "C"
    {
        
        int32_t mine_sweeper_makeDefaultPosition(int32_t N, int32_t M, int32_t K, uint8_t* &outRet);
        
        int32_t mine_sweeper_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        int32_t mine_sweeper_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t firstMoveType);
        
        bool mine_sweeper_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);
        
        int32_t mine_sweeper_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        int32_t mine_sweeper_printPosition(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrPosition);
        
    }
}

#endif /* mine_sweeper_jni_hpp */
