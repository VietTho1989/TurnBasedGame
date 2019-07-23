//
//  main.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include <iostream>
// #include <pthread.h>
#include <boost/thread.hpp>

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include "international_draught_common.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_search.hpp"
#include "international_draught_jni.hpp"

namespace InternationalDraught
{
    
    // void *threadTest(void *vargp)
    void threadTest()
    {
        // make default position
        uint8_t* startPositionBytes;
        // get variantType
        Variant_Type variantType = Normal;
        {
            // variantType = (Variant_Type)fastRandom(2);
        }
        const char* fen = "W:W31-50:B1-20";
        int32_t length = international_draught_makeDefaultPosition(variantType, fen, startPositionBytes);
        printf("make default position: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                international_draught_printPosition(positionBytes, positionLength, true);
                int32_t gameFinish = international_draught_isGameFinish(positionBytes, positionLength, true);
                printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // letComputerThink
                    bool bMove = true;
                    bool book = true;
                    int32_t depth = 12;
                    float time = 20000;
                    bool input = true;
                    bool useEndGameDatabase = true;
                    int32_t pickBestMove = 100;
                    {
                        /*if(turn%2==0){
                         pickBestMove = 0;
                         }else{
                         pickBestMove = 100;
                         }*/
                    }
                    uint64 move = international_draught_letComputerThink(positionBytes, positionLength, true, bMove, book, depth, time,input, useEndGameDatabase, pickBestMove);
                    // do move
                    {
                        // print move to string
                        {
                            printf("letComputerThink: move: %llu\n", move);
                            international_draught_printMove(move);
                        }
                        // legalMoves
                        {
                            uint8_t* outLegalMoves;
                            int32_t outLegalMovesLength = international_draught_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                            if(outLegalMovesLength!=0){
                                free(outLegalMoves);
                            }
                            printf("outLegalMoves: %d\n", outLegalMovesLength);
                        }
                        // check legal move
                        if(international_draught_isLegalMove(positionBytes, positionLength, true, move)){
                            // do move
                            uint8_t* newOutRet;
                            int32_t newLength = international_draught_doMove(positionBytes, positionLength, true, move, newOutRet);
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
                    printf("game finish in turn: %d\n", turn);
                    international_draught_printPosition(positionBytes, positionLength, true);
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
                boost::this_thread::sleep_for (boost::chrono::seconds(1));
            }while (true);
            if(positionBytes!=NULL){
                printf("error, why positionBytes!=NULL\n");
                free(positionBytes);
            }
        }
        
        // return NULL;
    }
    
    void *threadSetBB(void *vargp)
    {
        int32_t count = 0;
        while (true) {
            count++;
            int32_t r = fastRandom(100);
            if(r<90){
                if(r<40){
                    printf("set bb file wrong\n");
                    international_draught_setBBPath("");
                }else{
                    printf("set bb file correct\n");
                    international_draught_setBBPath("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/InternationalDraught/InternationalDraught/Resources/data/bb");
                }
            }
            if(count>=5){
                break;
            }
            std::this_thread::sleep_for (std::chrono::seconds(60*3));
        }
        
        return NULL;
    }
    
    bool alreadyInitInternationalDraughtMain = false;

    int32_t international_draught_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        std::cout << "Hello, World!\n";
        
        // init
        if(!alreadyInitInternationalDraughtMain){
            alreadyInitInternationalDraughtMain = true;
            international_draught_initCore();
            
            printf("squareToStd: %d, %d, %d\n", square_to_std(Square(10)), square_file(Square(10)), square_rank(Square(10)));
            
            // set path
            {
                international_draught_setBBPath((ResourcePath + "/NotAlwaysIn/InternationalDraught/data/bb").c_str());
                international_draught_setBookPath((ResourcePath + "/AlwaysIn/InternationalDraught/book").c_str());
                international_draught_setEvalPath((ResourcePath + "/AlwaysIn/InternationalDraught").c_str());
            }
            
            // init low
            {
                
            }
        }
        
        {
            /*pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            // Ko can nua pthread_attr_setstacksize(&attr, 10*1048576);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadTest, NULL);
            }*/
            
            boost::thread_group threads;
            boost::thread::attributes attrs;
            {
                // attrs.set_stack_size(10*1048576);
            }
            for (int i=0; i<matchCount; i++)
            {
                boost::thread* t= new boost::thread(attrs, threadTest);
                threads.add_thread(t);
            }
            // Wait till they are finished
            threads.join_all();
            
            /*char buf[4096];
            while (fgets(buf, 4096, stdin)) {
                printf("buf: %s\n", buf);
                if(strcmp(buf, "q\n")==0){
                    break;
                }
                {
                 pthread_t tid;
                 pthread_create(&tid, &attr, threadSetBB, NULL);
                 }
                for(int32_t i=0; i<12; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, threadTest, NULL);
                }
            }*/
        }
        
        return 0;
    }
}
// 131.1
