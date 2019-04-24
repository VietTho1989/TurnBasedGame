//
//  chinese_checkers_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 1/31/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include <iostream>
#include <string>
#include <pthread.h>
#include <thread>
#include "chinese_checkers_main.hpp"
#include "chinese_checkers_board.hpp"
#include "chinese_checkers_interface.hpp"
#include "chinese_checkers_jni.hpp"

namespace ChineseCheckers
{
    
    void *threadTest(void *vargp)
    {
        // Board board;
        // self_play(board);
        uint8_t* startPositionBytes;
        int32_t length = chinese_checkers_makePositionByFen(Positions::INITIAL_POSITION.c_str(), startPositionBytes);
        printf("makeDefaultPosition: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            uint8_t* moveBytes = NULL;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                // print position
                {
                    uint8_t* outStrPosition;
                    chinese_checkers_printPosition(positionBytes, positionLength, true, outStrPosition);
                    free(outStrPosition);
                }
                // legalMoves
                {
                    uint8_t* outLegalMoves;
                    int32_t outLegalMovesLength = chinese_checkers_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                    if(outLegalMovesLength!=0){
                        free(outLegalMoves);
                    }
                    printf("outLegalMoves: %d\n", outLegalMovesLength);
                }
                int32_t gameFinish = chinese_checkers_isGameFinish(positionBytes, positionLength, true);
                // printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // delete move
                    {
                        if(moveBytes!=NULL){
                            free(moveBytes);
                            moveBytes = NULL;
                        }else{
                            // printf("error, why moveBytes NULL\n");
                        }
                    }
                    // letComputerThink
                    int32_t moveLength = chinese_checkers_letComputerThink(positionBytes, positionLength, true, 1, 5, 5000, 1000, 90, moveBytes);
                    // do move
                    {
                        // print move to string
                        /*{
                         uint8_t* outStrMove;
                         russian_draught_printMove(moveBytes, moveLength, true, outStrMove);
                         free(outStrMove);
                         }*/
                        // check legal move
                        if(chinese_checkers_isLegalMove(positionBytes, positionLength, true, moveBytes, moveLength)){
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = chinese_checkers_doMove(positionBytes, positionLength, true, moveBytes, moveLength, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                                // delete move
                                {
                                    if(moveBytes!=NULL){
                                        free(moveBytes);
                                        moveBytes = NULL;
                                    }else{
                                        // printf("error, why moveBytes NULL\n");
                                    }
                                }
                            }
                        }else{
                            printf("error: why not legal move\n");
                            // delete move
                            {
                                if(moveBytes!=NULL){
                                    free(moveBytes);
                                    moveBytes = NULL;
                                }else{
                                    printf("error, why moveBytes NULL\n");
                                }
                            }
                            break;
                        }
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d\n", turn);
                    // print position
                    {
                        uint8_t* outStrPosition;
                        chinese_checkers_printPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    switch (gameFinish) {
                        case 1:
                            // white move first
                            printf("white win: %d\n", turn);
                            break;
                        case 2:
                            // black move after
                            printf("black win: %d\n", turn);
                            break;
                        case 3:
                            printf("the game is draw: %d\n", turn);
                            break;
                        default:
                            break;
                    }
                    free(positionBytes);
                    positionBytes = NULL;
                    break;
                }
                // std::this_thread::sleep_for (std::chrono::seconds(1));
            }while (true);
            // free data
            {
                // free position
                if(positionBytes!=NULL){
                    printf("error, why positionBytes!=NULL\n");
                    free(positionBytes);
                    positionBytes = NULL;
                }
                // delete move
                {
                    if(moveBytes!=NULL){
                        free(moveBytes);
                        moveBytes = NULL;
                    }else{
                        // printf("error, why moveBytes NULL\n");
                    }
                }
            }
        }
        
        return NULL;
    }
    
    int32_t chinese_checkers_main(int32_t matchCount, std::string ResourcePath)
    {
        pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        pthread_attr_setstacksize(&attr, 10*1048576);
        
        matchCount = 5;
        for(int32_t i=0; i<matchCount; i++){
            pthread_t tid;
            pthread_create(&tid, &attr, threadTest, NULL);
        }
        
        return 0;
    }
    
}
