//
//  jni.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_jni_hpp
#define international_draught_jni_hpp

#include <stdio.h>
#include <stdint.h>
#include "international_draught_common.hpp"
#include "international_draught_var.hpp"

extern "C"
{
    namespace InternationalDraught
    {
        void international_draught_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        void international_draught_printMove(uint64 move);
        
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////// set bb multithread ///////////////////
        ///////////////////////////////////////////////////////////////////////////////
        
        extern std::mutex international_draught_prepareMutex;
        extern int32_t international_draught_prepareCount;
        extern volatile bool international_draught_isWaitSetFile;
        
        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// set path /////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        bool international_draught_setBookPath(const char* newBookPath);
        
        extern std::mutex bbMutex;
        
        bool international_draught_setBBPath(const char* newBBPath);
        
        bool international_draught_setEvalPath(const char* newEvalPath);
        
        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// Match /////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        
        void international_draught_initCore();

        int32_t international_draught_makeDefaultPosition(Variant_Type variantType, const char* fen, uint8_t* &outRet);

        int32_t international_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);
        
        uint64 international_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool move, bool book, int32_t depth, float time, bool input, bool useEndGameDatabase, int32_t pickBestMove);
        
        bool international_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint64 move);

        int32_t international_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint64 move, uint8_t* &outRet);

        int32_t international_draught_getFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet);

        int32_t international_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves);

        int32_t international_draught_getMoveSquareList(uint64 move, uint8_t* &outMoveSquareList);
    }
}

#endif /* jni_hpp */
