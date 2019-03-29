//
//  Jni.hpp
//  StockFishChess
//
//  Created by Viet Tho on 1/22/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef CHESS_STOCK_FISH_Jni_hpp
#define CHESS_STOCK_FISH_Jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace StockFishChess
{
    extern "C"
    {
        
        EXPORTED void chess_initCore();
        
        EXPORTED void chess_printMove(int32_t move, bool chess960);

        EXPORTED int32_t chess_makePositionByFen(const char* strFen, bool isChess960, uint8_t* &outRet);
        
        EXPORTED void chess_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED void chess_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED bool chess_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        /////////////////////////////////////////////////////////////////////////////
        //////////////////// LetComputerThink /////////////////////
        /////////////////////////////////////////////////////////////////////////////

        EXPORTED int32_t chess_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t chess_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration);
        
        EXPORTED bool chess_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move);

        EXPORTED int32_t chess_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet);

        EXPORTED int32_t chess_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// Print ///////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED int32_t chess_position_to_fen(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrFen);
        
    }
}

#endif /* Jni_hpp */
