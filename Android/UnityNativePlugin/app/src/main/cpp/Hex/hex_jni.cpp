//
//  hex_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 9/12/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "hex_jni.hpp"
#include "../Platform.h"
#include "fhcore/hex_board.hpp"
#include "fhcore/hex_mcts.hpp"

namespace Hex
{
    using namespace board;
    using namespace color;
    using namespace engine;
    
    int32_t hex_makeDefaultPosition(uint16_t boardSize, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // correct input
            {
                if(boardSize<4){
                    boardSize = 4;
                }
                if(boardSize>=MAX_BOARD_SIZE){
                    boardSize = MAX_BOARD_SIZE;
                }
            }
            // Make position
            IBoard* pos = IBoard::create(boardSize);
            // return
            ret = IBoard::convertToByteArray(pos, outRet);
            // free data
            delete pos;
        }
        return ret;
    }
    
    int32_t hex_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        IBoard* pos = NULL;
        {
            IBoard::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        int32_t ret = 0;
        {
            switch (pos->winner()) {
                case color::Color::Empty:
                    ret = 0;
                    break;
                case color::Color::Red:
                    ret = 1;
                    break;
                case color::Color::Blue:
                    ret = 2;
                    break;
                default:
                    printf("error, unknown winner: %hhd\n", pos->winner());
                    break;
            }
        }
        // free data
        delete pos;
        return ret;
    }
    
    uint16_t hex_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t limitTime, bool firstMoveCenter)
    {
        // correct input
        {
            if(limitTime<1){
                limitTime = 1;
            }
            if(limitTime>120){
                limitTime = 120;
            }
        }
        // make pos
        IBoard* pos = NULL;
        {
            IBoard::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // find result
        pos_t result;
        {
            // config
            EngineCfg cfg;
            cfg.colorAI = pos->color();
            cfg.pBoard = pos;
            // engine
            MCTSEngine* pEngine = new MCTSEngine(std::chrono::seconds(limitTime));
            {
                pEngine->firstMoveCenter = firstMoveCenter;
            }
            pEngine->configure(cfg);
            // find
            pEngine->compute_sync(result);
            cout << result << std::endl;
            // free data
            delete pEngine;
        }
        uint16_t ret = result.row*pos->boardsize() + result.col;
        // free data
        delete pos;
        // return
        return ret;
    }
    
    bool hex_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint16_t move)
    {
        IBoard* pos = NULL;
        {
            IBoard::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // check
        bool ret = false;
        {
            uint16_t row = move/pos->boardsize();
            uint16_t col = move%pos->boardsize();
            if(row>=0 && row<pos->boardsize() && col>=0 && col<pos->boardsize()){
                if((*pos)(row, col)==color::Color::Empty){
                    ret = true;
                }else{
                    printf("error, why not legal move: %d, %d\n", row, col);
                }
            }else{
                printf("error, outside board\n");
            }
        }
        // free data
        delete pos;
        // return
        return ret;
    }
    
    int32_t hex_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint16_t move, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // make position
        IBoard* pos = NULL;
        {
            IBoard::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // doMove
        {
            uint16_t row = move/pos->boardsize();
            uint16_t col = move%pos->boardsize();
            Color color = pos->color();
            if(row>=0 && row<pos->boardsize() && col>=0 && col<pos->boardsize()){
                (*pos)(row, col) = color;
            }else{
                printf("error, outside board\n");
            }
            // convert to return value
            ret = IBoard::convertToByteArray(pos, outRet);
        }
        // free data
        delete pos;
        // return
        return ret;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////// Print ///////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    int32_t hex_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        IBoard* pos = NULL;
        {
            IBoard::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char* ret = (char*)calloc(1, MAX_BOARD_SIZE*MAX_BOARD_SIZE*20);
            {
                print(pos, ret);
#ifdef Debug
                printf("\n%s\n", ret);
#endif
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outStrPosition = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrPosition, ret, outLength);
                }
            }
            free(ret);
        }
        // free data
        delete pos;
        // return
        return outLength;
    }
    
}
