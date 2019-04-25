//
//  main.cpp
//  TestOthello
//
//  Created by Viet Tho on 11/21/17.
//  Copyright © 2017 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include <iostream>
#include <fstream>
#include <thread>
#include <vector>
// #include <pthread.h>
#include "reversi_player.hpp"
#include "reversi_jni.hpp"
#include "reversi_position.hpp"

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

namespace Reversi
{
    // void *threadTest(void *vargp)
    void threadTest()
    {
        uint8_t* startPositionBytes;
        int32_t length = reversi_makeDefaultPosition(startPositionBytes);
        printf("makePositionByFen: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                {
                    reversi_printPosition(positionBytes, positionLength, true);
                }
                int32_t gameFinish = reversi_isGameFinish(positionBytes, positionLength, true);
                printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    int32_t sort = 4;
                    int32_t min = 4;
                    int32_t max = 8;
                    int32_t end = 4;
                    int32_t msLeft = 240*1000;
                    bool useBook = false;
                    int32_t percent = 95;
                    int8_t move = reversi_letComputerThink(positionBytes, positionLength, true, sort, min, max, end, msLeft, useBook, percent);
                    // print move to string
                    {
                        char strMove[3];
                        reversi_printMove(move, strMove);
                        printf("find ai move: %s\n", strMove);
                    }
                    {
                        // check legal move
                        if(reversi_isLegalMove(positionBytes, positionLength, true, move)){
                            // do move
                            uint8_t* newOutRet;
                            int32_t newLength = reversi_doMove(positionBytes, positionLength, true, move, newOutRet);
                            // set new position bytes
                            if(newLength!=0){
                                free(positionBytes);
                                positionBytes = newOutRet;
                                positionLength = newLength;
                            }else{
                                printf("error, do move\n");
                                break;
                            }
                        }else{
                            printf("error: why not legal move: %d\n", move);
                            break;
                        }
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d\n", turn);
                    switch (gameFinish) {
                        case 1:
                            printf("black win: %d\n", turn);
                            break;
                        case 2:
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
                free(positionBytes);
            }
        }
        
        // return NULL;
    }
    
    bool alreadyInitReversiMain = false;

    int32_t reversi_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        std::cout << "Hello, World!\n";
        
        if(!alreadyInitReversiMain){
            alreadyInitReversiMain = true;
            reversi_setBookPath((ResourcePath + "/AlwaysIn/Reversi").c_str());
        }
        {
            /*pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadTest, NULL);
            }*/
            
            std::vector<std::thread> threads;
            for(int32_t i=0; i<matchCount; i++){
                threads.push_back(std::thread(threadTest));
            }
            for(auto& t : threads)
            {
                t.join();
            }
            
            /*char buf[4096];
            while (fgets(buf, 4096, stdin)) {
                printf("buf: %s\n", buf);
                if(strcmp(buf, "q\n")==0){
                    break;
                }
                for(int32_t i=0; i<10; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, threadTest, NULL);
                }
            }*/
        }
        
        return 0;
    }
}


// 23.2
