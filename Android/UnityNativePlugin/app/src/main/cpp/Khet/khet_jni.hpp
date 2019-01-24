//
//  khet_jni.hpp
//  NativeCore
//
//  Created by Viet Tho on 12/19/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef khet_jni_hpp
#define khet_jni_hpp

#include <stdio.h>
#include "../Platform.h"

namespace Khet
{
    extern "C"
    {
        
        void khet_initCore();
        
        int32_t khet_makePositionByFen(const char* strFen, uint8_t* &outRet);
        
        int32_t khet_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        uint32_t khet_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool infinite, int32_t moveTime, int32_t depth, int32_t pickBestMove);
        
        bool khet_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move);
        
        int32_t khet_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move, uint8_t* &outRet);
        
        int32_t khet_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);
        
        int32_t khet_position_to_fen(uint8_t* positionBytes, int32_t positionLength, bool canCorrect, uint8_t* &outStrFen);
        
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////// print /////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        
        int32_t khet_getStrPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition);
        
        int32_t khet_getStrMove(uint32_t move, uint8_t* &outStrMove);
        
        int32_t khet_getLaserPath(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLaserPath);
        
        int32_t khet_getMyLaserPath(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t player, uint8_t* &outLaserPath);
        
    }
}

#endif /* khet_jni_hpp */
