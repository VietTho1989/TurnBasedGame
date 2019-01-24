//
//  main.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>

#ifndef _MSC_VER
#include <unistd.h>
#else
#include <io.h>
#endif

#include <thread>
#include <pthread.h>
#include "weiqi_jni.hpp"
#include "weiqi_random.hpp"
#include "weiqi_pattern.hpp"
#include "weiqi_patternprob.hpp"
#include "weiqi_mq.hpp"
#include "weiqi_timeinfo.hpp"
#include "weiqi_main.hpp"

namespace weiqi
{
    void *threadTest(void *vargp)
    {
        uint8_t* startPositionBytes;
        int32_t size = 19;
        floating_t komi = 5.5f;
        go_ruleset rule = RULES_JAPANESE;
        int32_t handicap = 0;
        int32_t length = weiqi_makeDefaultPosition(size, komi, rule, handicap, startPositionBytes);
        printf("makeDefaultPosition: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                {
                    weiqi_printPosition(positionBytes, positionLength, true);
                }
                int32_t gameFinish = weiqi_isGameFinish(positionBytes, positionLength, true);
                // printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // letComputerThink
                    bool canResign = false;
                    bool useBook = false;
                    int32_t time = 100;
                    int32_t games = -1;
                    uint8_t* moveBytes;
                    engine_id engine = E_UCT;
                    {
                        if(turn%2==0){
                            engine = E_UCT;
                        }else{
                            engine = E_UCT;
                        }
                    }
                    int32_t moveLength = weiqi_letComputerThink(positionBytes, positionLength, true, canResign, useBook, time, games, engine, moveBytes);
                    // do move
                    {
                        // print move to string
                        weiqi_printMove(positionBytes, positionLength, true, moveBytes, moveLength);
                        // check legal move
                        if(weiqi_isLegalMove(positionBytes, positionLength, true, moveBytes, moveLength)){
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = weiqi_doMove(positionBytes, positionLength, true, moveBytes, moveLength, false, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                                // delete move
                                {
                                    free(moveBytes);
                                }
                            }
                            // update score
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = weiqi_updateScore(positionBytes, positionLength, true, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }
                        }else{
                            printf("error: why not legal move\n");
                            // delete move
                            {
                                free(moveBytes);
                            }
                            break;
                        }
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d\n", turn);
                    weiqi_printPosition(positionBytes, positionLength, true);
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
    
    void *threadSetBook(void *vargp)
    {
        while (true) {
            time_sleep(60);
            int32_t r = fast_random(100);
            if(r<90){
                if(r<40){
                    printf("set book file wrong\n");
                    weiqi_setFileName("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Go/oldweiqi/Resources/spat.txt", "/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Go/oldweiqi/Resources/prob.txt");
                }else{
                    printf("set book file correct\n");
                    weiqi_setFileName("/Users/viettho/Desktop/NewProject/TurnbaseGame/Assets/Plugins/Weiqi/Weiqi.bundle/Contents/Resources/patterns.spat", "/Users/viettho/Desktop/NewProject/TurnbaseGame/Assets/Plugins/Weiqi/Weiqi.bundle/Contents/Resources/patterns.prob");
                }
            }
        }
        
        return NULL;
    }

    int32_t weiqi_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        printf("size of pthashes: %lu\n", sizeof(pthashes));
        
        weiqi_initCore();
        // set file
        {
            weiqi_setBookPath((ResourcePath + "/AlwaysIn/weiqi/book.dat").c_str());
            weiqi_setFileName((ResourcePath + "/NotAlwaysIn/weiqi/patterns.spat").c_str(), (ResourcePath + "/NotAlwaysIn/weiqi/patterns.prob").c_str());
        }
        
        // random seed
        /*{
         int64_t seed = time(NULL) ^ getpid();
         printf("random seed: %ld\n", seed);
         fast_srandom(seed);
         }*/
        
        {
            pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            pthread_attr_setstacksize(&attr, 10*1048576);
            
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
                // random set file
                {
                 pthread_t tid;
                 pthread_create(&tid, &attr, threadSetBook, NULL);
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
// 539.8
// 540
// 540
