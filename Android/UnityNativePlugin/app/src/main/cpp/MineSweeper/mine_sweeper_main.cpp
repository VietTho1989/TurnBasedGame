//
//  main.cpp
//  MineSweeper
//
//  Created by Viet Tho on 9/4/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <sstream>
#include <pthread.h>
#include <vector>
#include <thread>
#include <pthread.h>
#include "../Platform.h"
#include "mine_sweeper_main.hpp"
#include "mine_sweeper_board.hpp"
#include "mine_sweeper_Solver.hpp"
#include "mine_sweeper_jni.hpp"

namespace MineSweeper
{
    
    void *threadTest(void *vargp)
    {
        {
            uint8_t* startPositionBytes;
            int32_t N = 12;// fastRandom(MAX_DIMENSION);
            int32_t M = 13;// fastRandom(MAX_DIMENSION);
            int32_t K = (M*N)/10;
            int32_t length = mine_sweeper_makeDefaultPosition(N, M, K, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        uint8_t* outStrPosition;
                        mine_sweeper_printPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    int32_t gameFinish = mine_sweeper_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t firstMoveType = 1;
                        int32_t move = mine_sweeper_letComputerThink(positionBytes, positionLength, true, firstMoveType);
                        if(move>=0){
                            // print move to string
                            {
                                
                            }
                            // check legal move
                            if(mine_sweeper_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = mine_sweeper_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            // chess_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        {
                            uint8_t* outStrPosition;
                            mine_sweeper_printPosition(positionBytes, positionLength, true, outStrPosition);
                            free(outStrPosition);
                        }
                        switch (gameFinish) {
                            case 1:
                                printf("you win\n");
                                break;
                            case 2:
                                printf("you lose\n");
                                break;
                            default:
                                printf("error, unknown gameFinish: %d\n", gameFinish);
                                break;
                        }
                        break;
                    }
                    // std::this_thread::sleep_for (std::chrono::seconds(1));
                }while (true);
                // free data
                if(positionBytes!=NULL){
                    free(positionBytes);
                }
            }
        }
        return NULL;
    }
    
    int32_t mine_sweeper_main(int32_t matchCount, std::string ResourcePath)
    {
        {
            pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            pthread_attr_setstacksize(&attr, 1048576);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadTest, NULL);
            }
        }
        
        return 0;
    }
}
