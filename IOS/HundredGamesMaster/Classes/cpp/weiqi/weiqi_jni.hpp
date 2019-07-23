//
//  jni.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_jni_hpp
#define weiqi_jni_hpp

#include <stdio.h>
#include <mutex>
#include "../Platform.h"
#include "weiqi_board.hpp"
#include "weiqi_engine.hpp"

extern "C"
{
    namespace weiqi
    {
        
        EXPORTED void weiqi_initCore();
        
        extern std::mutex weiqi_prepareMutex;
        extern int32_t weiqi_prepareCount;
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////// set file /////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        extern std::mutex weiqi_fileMutext;
    
        extern bool weiqi_alreadyInitSpatialDict;
        extern bool weiqi_alreadyInitPatternFile;
        
        EXPORTED bool weiqi_setFileName(const char* newSpatialDictFileName, const char* newPatternFileName);
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////// set book  /////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        extern char bookPath[500];
        
        extern std::mutex initBookMtx;
        
        EXPORTED bool weiqi_setBookPath(const char* newBookPath);
        
        struct BookCache
        {
            // TODO khi doi ten book thi ko biet phai lam gi
            struct fbook* fbook = NULL;
            int32_t use = 0;
        };
        
        extern struct BookCache bookCaches[21];
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////// normal method /////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        EXPORTED int32_t weiqi_makeDefaultPosition(int32_t size, floating_t komi, go_ruleset rule, int32_t handicap, uint8_t* &outRet);
        
        EXPORTED int32_t weiqi_makeCustomPosition(int32_t size, floating_t komi, go_ruleset rule, int32_t* board, int32_t captureBlack, int32_t captureWhite, int lastMoveColor, uint8_t* &outRet);
        
        EXPORTED void weiqi_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t weiqi_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect);

        EXPORTED int32_t weiqi_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool canResign, bool usebook, int64_t time, int32_t games, engine_id engine, uint8_t* &outRet);
        
        EXPORTED void weiqi_printMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);
        
        EXPORTED bool weiqi_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength);

        EXPORTED int32_t weiqi_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, bool needUpdateScore, uint8_t* &outRet);

        EXPORTED int32_t weiqi_updateScore(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet);
        
    }
}

#endif /* jni_hpp */
