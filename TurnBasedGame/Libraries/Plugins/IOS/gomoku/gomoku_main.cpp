//
//  main.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include <iostream>
#include <thread>
#include <pthread.h>

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include "gomoku_position.hpp"
#include "gomoku_jni.hpp"

namespace gomoku
{
    void *threadTest(void *vargp)
    {
        uint8_t* startPositionBytes;
        int32_t size = 19;
        {
            size = fastRandom(30) + 5;
        }
        int32_t level = 18;
        {
            level = fastRandom(20) + 5;
        }

        int32_t length = gomoku_makeDefaultPosition(size, startPositionBytes);
        printf("makeDefaultPosition: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                {
                    gomoku_printPosition(positionBytes, positionLength, true);
                }
                int32_t gameFinish = gomoku_isGameFinish(positionBytes, positionLength, true);
                // printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // letComputerThink
                    int32_t searchDepth = 8;
                    int32_t timeLimit = 10000;
                    int32_t move = gomoku_letComputerThink(positionBytes, positionLength, true, searchDepth, timeLimit, level);
                    // do move
                    {
                        // check legal move
                        if(gomoku_isLegalMove(positionBytes, positionLength, true, move)){
                            // do move
                            uint8_t* newOutRet;
                            int32_t newLength = gomoku_doMove(positionBytes, positionLength, true, move, newOutRet);
                            // set new position bytes
                            {
                                free(positionBytes);
                                positionBytes = newOutRet;
                                positionLength = newLength;
                            }
                        }else{
                            printf("error: why not legal move\n");
                            break;
                        }
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d, %d\n", turn, level);
                    gomoku_printPosition(positionBytes, positionLength, true);
                    switch (gameFinish) {
                        case 1:
                            // black move first
                            printf("black win: %d\n", turn);
                            break;
                        case 2:
                            // white move after
                            printf("white win: %d\n", turn);
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
            if(positionBytes!=NULL){
                printf("error, why positionBytes!=NULL\n");
                free(positionBytes);
            }
        }
        
        return NULL;
    }

    int32_t gomoku_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        std::cout << "Hello, World!\n";
        
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
                for(int32_t i=0; i<15; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, threadTest, NULL);
                }
            }*/
        }
        
        return 0;
    }
}
