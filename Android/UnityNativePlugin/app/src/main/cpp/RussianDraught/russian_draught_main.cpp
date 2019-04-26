//
//  russian_draught_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 8/22/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "russian_draught_main.hpp"
#include "russian_draught_jni.hpp"
#include "russian_draught_KALLISTO.hpp"
#include "../Platform.h"
#include <iostream>
#include <sstream>
#include <pthread.h>
#include <vector>
#include <thread>

namespace RussianDraught
{
    
    void *threadTest(void *vargp)
    {
        uint8_t* startPositionBytes;
        int32_t length = russian_draught_makePositionByFen(StartFen, startPositionBytes);
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
                    russian_draught_printPosition(positionBytes, positionLength, true, outStrPosition);
                    free(outStrPosition);
                }
                // legalMoves
                {
                    uint8_t* outLegalMoves;
                    int32_t outLegalMovesLength = russian_draught_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                    if(outLegalMovesLength!=0){
                        free(outLegalMoves);
                    }
                    printf("outLegalMoves: %d\n", outLegalMovesLength);
                }
                // printFen
                {
                    uint8_t* outStrFen;
                    russian_draught_position_to_fen(positionBytes, positionLength, true, outStrFen);
                    free(outStrFen);
                }
                int32_t gameFinish = russian_draught_isGameFinish(positionBytes, positionLength, true);
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
                    int32_t moveLength = russian_draught_letComputerThink(positionBytes, positionLength, true, 5000, 90, moveBytes);
                    // do move
                    {
                        // print move to string
                        {
                            uint8_t* outStrMove;
                            russian_draught_printMove(moveBytes, moveLength, true, outStrMove);
                            free(outStrMove);
                        }
                        // check legal move
                        if(russian_draught_isLegalMove(positionBytes, positionLength, true, moveBytes, moveLength)){
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = russian_draught_doMove(positionBytes, positionLength, true, moveBytes, moveLength, newOutRet);
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
                        russian_draught_printPosition(positionBytes, positionLength, true, outStrPosition);
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
                std::this_thread::sleep_for (std::chrono::seconds(1));
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
    
    int32_t russian_draught_main(int32_t matchCount, std::string ResourcePath)
    {
        russian_draught_initCore();
        {
            pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadTest, NULL);
            }
            
            /*char buf[4096];
             while (fgets(buf, 4096, stdin)) {
             printf("buf: %s\n", buf);
             if(strcmp(buf, "q\n")==0){
             break;
             }
             for(int32_t i=0; i<12; i++){
             pthread_t tid;
             pthread_create(&tid, &attr, threadMyTest, NULL);
             }
             }*/
        }
        
        return 0;
    }
    
}
