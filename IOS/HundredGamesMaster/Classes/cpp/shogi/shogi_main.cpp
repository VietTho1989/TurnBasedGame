//
//  main.cpp
//  TestShogi
//
//  Created by Viet Tho on 11/29/17.
//  Copyright © 2017 Viet Tho. All rights reserved.
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

#include "shogi_jni.hpp"
#include "core/shogi_common.hpp"
#include "core/shogi_position.hpp"
#include "core/shogi_usi.hpp"
#include "core/shogi_evaluate.hpp"

namespace Shogi
{
    // void *threadMyTest(void *vargp)
    void threadMyTest()
    {
        {
            u8* startPositionBytes = NULL;
            int32_t length = shogi_makePositionByFen("lnsgkgsnl/1r5b1/ppppppppp/9/9/9/PPPPPPPPP/1B5R1/LNSGKGSNL b - 1", startPositionBytes);
            printf("makePositionByFen: %d\n", length);
            // Make a match
            {
                int32_t turn = 0;
                u8* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("shogi evaluator allocated: %d, %lu, %lu\n", Evaluator::allocated, sizeof(KPPEvalElementType1), sizeof(KKPEvalElementType1));
                    {
                        printf("before letComputerThink: %d %d\n", turn, positionLength);
                        shogi_printPosition(positionBytes, positionLength, true);
                        shogi_printPositionFen(positionBytes, positionLength, true);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = shogi_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = shogi_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        u32 move = shogi_letComputerThink(positionBytes, positionLength, true, 19, 18, 0, 2000, false);
                        if(move!=0){
                            // print move to string
                            shogi_printMove(move);
                            Move mv(move);
                            // check legal move
                            if(shogi_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                u8* newOutRet;
                                int32_t newLength = shogi_doMove(positionBytes, positionLength, true, move, newOutRet);
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
                            printf("why don't find any move, break\n");
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        switch (gameFinish) {
                            case 1:
                                printf("white win\n");
                                break;
                            case 2:
                                printf("black win\n");
                                break;
                            case 3:
                                printf("the game is draw\n");
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                    boost::this_thread::sleep_for (boost::chrono::seconds(1));
                }while (true);
                if(positionBytes!=NULL){
                    printf("need free positionBytes\n");
                    free(positionBytes);
                    positionBytes = NULL;
                }
            }
        }
        // return NULL;
    }
    
    void *threadSetEvaluatorPath(void *vargp)
    {
        int32_t count = 0;
        while (true) {
            count++;
            int32_t r = fastRandom(100);
            if(r<90){
                if(r<40){
                    printf("set evaluator file wrong\n");
                    shogi_setEvaluatorPath("");
                }else{
                    printf("set evaluator file correct\n");
                    shogi_setEvaluatorPath("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Shogi/TestShogi/TestShogi/bin/20171106");
                }
            }
            if(count>=30){
                break;
            }
            std::this_thread::sleep_for (std::chrono::seconds(60*3));
        }
        
        return NULL;
    }
    
    bool alreadyInitShogiMain = false;

    int32_t shogi_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        printf("size of StateInfo: %lu\n", sizeof(StateInfo));
        
        if(!alreadyInitShogiMain){
            alreadyInitShogiMain = true;
            if(shogi_setBookPath((ResourcePath + "/AlwaysIn/shogi/book.bin").c_str())){
                printf("book exist\n");
            }else{
                printf("book not exist\n");
            }
            if(shogi_setEvaluatorPath("")){
                printf("evaluator exist\n");
             }else{
                 printf("evaluator not exist\n");
             }
            shogi_initCore();
            shogi_changeEvaluatorPath((ResourcePath + "/NotAlwaysIn/shogi/20171106").c_str());
        }
        
        {
            /*pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadMyTest, NULL);
            }*/
            
            boost::thread_group threads;
            boost::thread::attributes attrs;
            {
                // attrs.set_stack_size(10*1048576);
            }
            for (int i=0; i<matchCount; i++)
            {
                boost::thread* t= new boost::thread(attrs, threadMyTest);
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
                // set evaluatorPath
                {
                 pthread_t tid;
                 pthread_create(&tid, &attr, threadSetEvaluatorPath, NULL);
                 }
                // set test match
                for(int32_t i=0; i<8; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, threadMyTest, NULL);
                }
            }*/
        }
        
        return 0;
    }
}
// 926.9
