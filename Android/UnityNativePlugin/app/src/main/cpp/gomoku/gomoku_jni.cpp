//
//  jni.cpp
//  gomoku
//
//  Created by Viet Tho on 4/12/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstring>
#include "../Platform.h"

#include "gomoku_jni.hpp"
#include "gomoku_position.hpp"
#include "ai/gomoku_eval.hpp"
#include "api/gomoku_renju_api.hpp"

namespace gomoku
{
    void gomoku_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        {
            char* strPosition = (char*)calloc((3*pos.boardSize+1)*pos.boardSize+200, sizeof(char));
            pos.print(strPosition);
            printf("Position: \n%s\n", strPosition);
            free(strPosition);
        }
    }

    int32_t gomoku_makeDefaultPosition(int32_t size, uint8_t* &outRet)
    {
        // correct parameter
        {
            if(size<=5) {
                printf("error, size not correct\n");
                size = 5;
            } else if(size>=1000) {
                size = 1000;
            }
        }
        // make position
        struct Position position;
        {
            position.boardSize = size;
            {
                position.gs = (char*)calloc(size*size+1, sizeof(char));
                position.gs[size*size] = 0;
                for(int32_t i=0; i<size*size; i++){
                    position.gs[i] = '0';
                }
            }
            position.player = 1;
            position.winningPlayer = 0;
            // lastMove
            for (int32_t i=0; i<LastMoveCount; i++) {
                position.lastMove[i] = -1;
            }
            
            position.winSize = 0;
            for(int32_t i=0; i<100; i++){
                position.winCoord[i] = 0;
            }
        }
        // convert
        int32_t length = Position::convertToByteArray(&position, outRet);
        // return
        return length;
    }

    int32_t gomoku_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            {
                if(pos.gs && strlen(pos.gs)==pos.boardSize*pos.boardSize && pos.boardSize>=3){
                    int32_t winPlayer = 0;
                    {
                        // Copy game state
                        int32_t g_gs_size = pos.boardSize*pos.boardSize;
                        char *gs = new char[g_gs_size];
                        std::memcpy(gs, pos.gs, g_gs_size);
                        // Convert from string
                        gsFromString(pos.gs, gs, g_gs_size);
                        // check win
                        winPlayer = winningPlayer(gs, pos.boardSize);
                        // release data
                        delete [] gs;
                    }
                    // printf("\ncheck winPlayer: %d\n\n", winPlayer);
                    if(winPlayer==1 || winPlayer==2){
                        ret = winPlayer;
                    }else{
                        // fill all
                        bool fillAll = true;
                        {
                            for (int32_t i=0; i<pos.boardSize*pos.boardSize; i++) {
                                if(pos.gs[i]!='1' && pos.gs[i]!='2'){
                                    fillAll = false;
                                    break;
                                }
                            }
                        }
                        if(fillAll){
                            // fill all, so draw
                            ret = 3;
                        }
                    }
                }else{
                    printf("error, board error\n");
                }
            }
        }
        return ret;
    }

    int32_t gomoku_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t searchDepth, int32_t timeLimit, int32_t level)
    {
        int32_t ret = -1;
        {
            {
                if(searchDepth<0){
                    printf("error, searchDepth < 0: %d\n", searchDepth);
                    searchDepth = 1;
                }else if(searchDepth>10){
                    printf("error, searchDepth too large: %d\n", searchDepth);
                    searchDepth = 10;
                }
            }
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // find ai move
            {
                bool isEmpty = true;
                {
                    if(pos.gs && strlen(pos.gs)==pos.boardSize*pos.boardSize && pos.boardSize>=3){
                        for (int32_t i=0; i<pos.boardSize*pos.boardSize; i++) {
                            if(pos.gs[i]=='1' || pos.gs[i]=='2'){
                                isEmpty = false;
                                break;
                            }
                        }
                    }else{
                        printf("error, board error\n");
                    }
                }
                if(isEmpty){
                    int32_t move_r = pos.boardSize / 2;
                    int32_t move_c = pos.boardSize / 2;
                    ret = pos.boardSize * move_r + move_c;
                }else{
                    RenjuAPI api;
                    {
                        api.level = level;
                    }
                    int32_t move_r, move_c, winning_player, actual_depth;
                    uint32_t node_count, eval_count, pm_count;
                    bool success = api.generateMove(pos.gs, pos.boardSize, pos.player, searchDepth, timeLimit, 1, &actual_depth, &move_r, &move_c, &winning_player, &node_count, &eval_count, &pm_count);
                    if (success) {
                        // Write MESSAGE
                        printf("d= %d, node_cnt= %d, eval_cnt= %d, pm_count= %d\n", actual_depth, node_count, eval_count, pm_count);
                        ret = pos.boardSize * move_r + move_c;
                    } else {
                        printf("Error\n");
                    }
                }
            }
        }
        return ret;
    }
    
    bool gomoku_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move)
    {
        bool ret = false;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // check
            if(move>=0 && move<pos.boardSize*pos.boardSize){
                if(pos.gs && move<strlen(pos.gs)){
                    if(pos.gs[move]!='1' && pos.gs[move]!='2'){
                        ret = true;
                    }
                }else{
                    printf("error, gs error\n");
                }
            }else{
                printf("error, move index error: %d\n", move);
            }
        }
        return ret;
    }

    int32_t gomoku_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet)
    {
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // play move
        {
            if(move>=0 && move<pos.boardSize*pos.boardSize){
                if(pos.gs && move<strlen(pos.gs)){
                    if(pos.gs[move]!='1' && pos.gs[move]!='2'){
                        if(pos.player==1){
                            pos.gs[move] = '1';
                            pos.player = 2;
                        }else if(pos.player==2){
                            pos.gs[move] = '2';
                            pos.player = 1;
                        }else{
                            printf("error, pos player: %d\n", pos.player);
                        }
                        // lastMove
                        pos.setLastMove(move);
                        // winingMove
                        {
                            // Copy game state
                            int32_t g_gs_size = pos.boardSize*pos.boardSize;
                            char *gs = new char[g_gs_size];
                            std::memcpy(gs, pos.gs, g_gs_size);
                            // Convert from string
                            gsFromString(pos.gs, gs, g_gs_size);
                            // check win
                            myWinningPlayer(gs, pos.boardSize, &pos);
                            printf("myWinningPlayer: %d\n", pos.winSize);
                            // release data
                            delete [] gs;
                        }
                    }
                }else{
                    printf("error, gs error\n");
                }
            }else{
                printf("error, move index error: %d\n", move);
            }
        }
        // return
        int32_t newLength = Position::convertToByteArray(&pos, outRet);
        return newLength;
    }
}
