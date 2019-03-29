//
//  shogi_jni.hpp
//  TestShogi
//
//  Created by Viet Tho on 2/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shogi_jni_hpp
#define shogi_jni_hpp

#include "../Platform.h"
#include <stdio.h>
#include "core/shogi_position.hpp"

namespace Shogi {
    extern "C"
    {

        EXPORTED void shogi_printMove(uint32_t move);
        
        EXPORTED void shogi_printPosition(u8* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED void shogi_printPositionFen(u8* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t shogi_getCheckersFromBitBoard(u8* bitboardBytes, u8* &outRet);

        EXPORTED int32_t shogi_checkMyPositionIsOk(u8* positionBytes, int32_t length);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////// set path ////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED bool shogi_setBookPath(const char* newBookPath);
        
        EXPORTED bool shogi_setEvaluatorPath(const char* newEvaluatorPath);
        
        extern std::mutex shogi_prepareMutex;
        extern int32_t shogi_prepareCount;
        extern volatile bool shogi_isWaitSetFile;
        
        extern std::mutex evaluatorMutex;
        
        EXPORTED bool shogi_changeEvaluatorPath(const char* newEvaluatorPath);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////// core /////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        EXPORTED void shogi_initCore();

        EXPORTED int32_t shogi_makePositionByFen(const char* strFen, u8* &outRet);

        EXPORTED int32_t shogi_isGameFinish(u8* positionBytes, int32_t length, bool canCorrect);
        
        EXPORTED u32 shogi_letComputerThink(u8* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int32_t mr, int32_t duration, bool useBook);
        
        EXPORTED bool shogi_isLegalMove(u8* positionBytes, int32_t length, bool canCorrect, u32 move);

        EXPORTED int32_t shogi_doMove(u8* positionBytes, int32_t length, bool canCorrect, u32 move, u8* &outRet);

        EXPORTED int32_t shogi_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);

    }
}

#endif /* shogi_jni_hpp */
