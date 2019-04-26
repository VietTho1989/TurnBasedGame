//
//  makruk_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 7/24/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <pthread.h>
#include "makruk_main.hpp"
#include "makruk_jni.hpp"
#include "engine/makruk_position.hpp"
#include "engine/makruk_search.hpp"
#include "../Platform.h"
#include "engine/syzygy/makruk_tbprobe.hpp"
#include "engine/makruk_thread.hpp"
#include "engine/makruk_uci.hpp"

namespace Makruk
{
    void *threadMyTest(void *vargp)
    {
        {
            uint8_t* startPositionBytes;
            bool chess960 = false;
            int32_t length = makruk_makePositionByFen(StartFEN, chess960, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        makruk_printPosition(positionBytes, positionLength, true);
                        makruk_printPositionFen(positionBytes, positionLength, true);
                    }
                    // printFen
                    {
                        uint8_t* outStrFen;
                        makruk_position_to_fen(positionBytes, positionLength, true, outStrFen);
                        free(outStrFen);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = makruk_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        // printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = makruk_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t move = makruk_letComputerThink(positionBytes, positionLength, true, 15, 19, 10000);
                        if(move!=0){
                            // print move to string
                            makruk_printMove(move);
                            // check legal move
                            if(makruk_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = makruk_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                makruk_printMove(move);
                                makruk_printPosition(positionBytes, positionLength, true);
                                makruk_printPositionFen(positionBytes, positionLength, true);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            makruk_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        makruk_printPosition(positionBytes, positionLength, true);
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
                    std::this_thread::sleep_for (std::chrono::seconds(1));
                }while (true);
                // free data
                if(positionBytes!=NULL){
                    free(positionBytes);
                }
            }
        }
        return NULL;
    }
    
    int32_t makruk_main(int matchCount, std::string ResourcePath) {
        // insert code here...
        std::cout << "Hello, World!\n";
        
        makruk_initCore();
        {
            pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadMyTest, NULL);
            }
            
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
