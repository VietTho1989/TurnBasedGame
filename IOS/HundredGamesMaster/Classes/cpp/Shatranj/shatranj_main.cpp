//
//  main.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
// #include <pthread.h>
#include <boost/thread.hpp>
#include "shatranj_main.hpp"
#include "shatranj_jni.hpp"
#include "shatranj_position.hpp"
#include "shatranj_search.hpp"
#include "../Platform.h"
#include "shatranj_tbprobe.hpp"
#include "shatranj_thread.hpp"
#include "shatranj_uci.hpp"

namespace Shatranj
{
    // void *threadMyTest(void *vargp)
    void threadMyTest()
    {
        {
            uint8_t* startPositionBytes;
            bool chess960 = false;
            int32_t length = shatranj_makePositionByFen(StartFEN, chess960, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        shatranj_printPosition(positionBytes, positionLength, true);
                        shatranj_printPositionFen(positionBytes, positionLength, true);
                    }
                    // printFen
                    {
                        uint8_t* outStrFen;
                        shatranj_position_to_fen(positionBytes, positionLength, true, outStrFen);
                        free(outStrFen);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = shatranj_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        // printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = shatranj_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t move = shatranj_letComputerThink(positionBytes, positionLength, true, 15, 19, 20000);
                        if(move!=0){
                            // print move to string
                            shatranj_printMove(move);
                            // check legal move
                            if(shatranj_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = shatranj_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                shatranj_printMove(move);
                                shatranj_printPosition(positionBytes, positionLength, true);
                                shatranj_printPositionFen(positionBytes, positionLength, true);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            shatranj_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        shatranj_printPosition(positionBytes, positionLength, true);
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
                // free data
                if(positionBytes!=NULL){
                    free(positionBytes);
                }
            }
        }
        // return NULL;
    }

    int32_t shatranj_main(int matchCount, std::string ResourcePath) {
        // insert code here...
        std::cout << "Hello, World!\n";

        shatranj_initCore();
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

            printf("size: %lu, %lu\n", sizeof(Pawns::Table), sizeof(StateInfo));

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
// 10.7
// 10.8
// 10.8
