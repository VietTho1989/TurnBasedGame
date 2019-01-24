//
//  position.hpp
//  TestOthello
//
//  Created by Viet Tho on 3/20/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef reversi_position_hpp
#define reversi_position_hpp

#include <stdio.h>
#include "reversi_common.hpp"

namespace Reversi
{
    struct PositionStruct
    {
        int32_t side = BLACK;
        bitbrd white;
        bitbrd black;
        
        // history
        int8_t nMoveNum = 0;
        int8_t moves[64];
        bitbrd changes[64];
        int32_t oldSides[64];
        
        bool isOK();

        int32_t getByteSize();
        
        static int32_t convertToByteArray(PositionStruct* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(PositionStruct* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
    public:
        void rotatePos(PositionStruct* pos, RotateType rotateType);
    };
}

#endif /* position_hpp */
