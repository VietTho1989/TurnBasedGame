//
//  main.cpp
//  TestXiangqi
//
//  Created by Viet Tho on 3/6/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <stdio.h>
// #include <pthread.h>
#include <boost/thread.hpp>
#include "xiangqi_jni.hpp"

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include "../Platform.h"
#include "base/xiangqi_base2.hpp"
#include "base/xiangqi_parse.hpp"
#include "eleeye/xiangqi_ucci.hpp"
#include "eleeye/xiangqi_pregen.hpp"
#include "eleeye/xiangqi_position.hpp"
#include "eleeye/xiangqi_hash.hpp"
#include "eleeye/xiangqi_search.hpp"

namespace Xiangqi
{
    
    // void *threadTest(void *vargp)
    void threadTest()
    {
        uint8_t* startPositionBytes;
        int32_t length = xiangqi_makePositionByFen("rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w", startPositionBytes);
        // int32_t length = makePositionByFen("rnbkkabnk/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w", startPositionBytes);
        printf("makePositionByFen: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                {
                    xiangqi_printPosition(positionBytes, positionLength, true);
                    xiangqi_printPositionFen(positionBytes, positionLength, true);
                }
                // legalMoves
                {
                    uint8_t* outLegalMoves;
                    int32_t outLegalMovesLength = xiangqi_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                    if(outLegalMovesLength!=0){
                        free(outLegalMoves);
                    }else{
                        printf("error, don't have have legal moves\n");
                    }
                    printf("outLegalMoves: %d\n", outLegalMovesLength);
                }
                // evaluate position
                /*{
                    printf("\nevaluate position in turn: %d\n", turn);
                    evaluatePosition(positionBytes, positionLength, true, 20, 2000, true, ChosenTypeNormal, 0);
                    printf("\n");
                }*/
                int32_t gameFinish = xiangqi_isGameFinish(positionBytes, positionLength, true);
                printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    int32_t pickBestMove = 95;
                    int32_t lngLimitTime = 10000;
                    uint32_t move = xiangqi_letComputerThink(positionBytes, positionLength, true, 20, lngLimitTime, true, pickBestMove);
                    if(move!=0){
                        // print move to string
                        xiangqi_printMove(move);
                        // check legal move
                        if(xiangqi_isLegalMove(positionBytes, positionLength, true, move)){
                            // do move
                            uint8_t* newOutRet;
                            int32_t newLength = xiangqi_doMove(positionBytes, positionLength, true, move, newOutRet);
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
                        printf("why don't find any move: turn: %d\n", turn);
                        free(positionBytes);
                        break;
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d\n", turn);
                    switch (gameFinish) {
                        case 1:
                            printf("red win: %d\n", turn);
                            break;
                        case 2:
                            printf("black win: %d\n", turn);
                            break;
                        case 3:
                            printf("the game is draw: %d\n", turn);
                            break;
                        default:
                            break;
                    }
                    // print
                    {
                        xiangqi_printPosition(positionBytes, positionLength, true);
                        xiangqi_printPositionFen(positionBytes, positionLength, true);
                    }
                    free(positionBytes);
                    break;
                }
                boost::this_thread::sleep_for (boost::chrono::seconds(1));
            }while (true);
        }
        
        // return NULL;
    }
    
    bool alreadyInitXiangqiMain = false;

    int32_t xiangqi_main(int matchCount, std::string ResourcePath)
    {
        printf("hello world\n");
        
        if(!alreadyInitXiangqiMain){
            alreadyInitXiangqiMain = true;
            xiangqi_setBookPath((ResourcePath + "/AlwaysIn/Xiangqi/BOOK.DAT").c_str());
            xiangqi_initCore();
        }
        
        {
            /*pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, Xiangqi::threadTest, NULL);
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
                if(strcmp(buf, "q\n")==0){
                    break;
                }
                for(int32_t i=0; i<10; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, Xiangqi::threadTest, NULL);
                }
            }*/
        }
        
        return 0;
        
    }
}

/*

rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w
rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR/ w
RNBAKABNR/9/1C5C1/P1P1P1P1P/9/9/p1p1p1p1p/1c5c1/9/rnbakabnr/ w
 
39: Black Chariot
 
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0 
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
0   0   0   39  37  35  33  32  34  36  38  40  0   0   0   0 
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0 
0   0   0   0   41  0   0   0   0   0   42  0   0   0   0   0 
0   0   0   43  0   44  0   45  0   46  0   47  0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0 
0   0   0   27  0   28  0   29  0   30  0   31  0   0   0   0
0   0   0   0   25  0   0   0   0   0   26  0   0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0 
0   0   0   23  21  19  17  16  18  20  22  24  0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0 
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
 
*/

/*
`  a  b  c  d  e  f  g  h  i
9 _c__n__p__c_ k _p__n__r__a_
8  *  *  *  *  *  *  *  *  *
7  * _p_ *  *  *  *  * _a_ *
6 _r_ * _p_ * _p_ * _b_ * _b_
5  *  *  *  *  *  *  *  *  *
4  *  *  *  *  *  *  *  *  *
3 _P_ * _P_ * _P_ * _P_ * _P_
2  * _N_ *  *  *  *  * _A_ *
1  *  *  *  *  *  *  *  *  *
0 _R__R__C__B_ K _B__C__N__A_
*/

/*
'  A   B   C   D   E   F   G   H   I
9 _p_ _p_ _n_ _p_  k  _b_ _r_ _r_ _b_
8  *   *   *   *   *   *   *   *   *
7  *   +   *   *   *   *   *  _n_  *
6 _p_  +  _c_  *  _a_  *  _p_  *  _a_
5  *   +   *   *   *   *   *   *   *
4  *   +   *   *   *   *   *   *   *
3 _P_  +  _N_  *  _R_  *  _R_  *  _C_
2  +  _P_  +   +   +   +   +  _A_  *
1  *   +   *   *   *   *   *   *   *
0 _C_ _P_ _A_ _B_  K  _P_ _N_ _B_ _P_
*/

/*
 '   A   B   C   D   E   F   G   H   I
 9 _c_ _r_ _n_ _p_  k  _p_ _p_ _b_ _p_
 8  *   *   *   *   *   *   *   *   *
 7  *  _p_  *   *   *   *   *  _n_  *
 6 _r_  *  _a_  *  _c_  *  _a_  *  _b_
 5  *   *   *   *   *   *   *   *   *
 4  *   *   *   *   *   *   *   *   *
 3 _C_  *  _B_  *  _R_  *  _A_  *  _P_
 2  *  _P_  *   *   *   *   *  _R_  *
 1  *   *   *   *   *   +   *   *   *
 0 _B_ _P_ _A_ _N_  K  _C_ _P_ _P_ _N_
*/
