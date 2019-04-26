//
//  seirawan_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 8/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <pthread.h>
#include "seirawan_main.hpp"
#include "seirawan_jni.hpp"
#include "seirawan_position.hpp"
#include "seirawan_search.hpp"
#include "../Platform.h"
#include "syzygy/seirawan_tbprobe.hpp"
#include "seirawan_thread.hpp"
#include "seirawan_uci.hpp"

namespace Seirawan
{
    void *threadMyTest(void *vargp)
    {
        {
            uint8_t* startPositionBytes;
            bool chess960 = false;
            int32_t length = seirawan_makePositionByFen(StartFEN, chess960, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        seirawan_printPosition(positionBytes, positionLength, true);
                        seirawan_printPositionFen(positionBytes, positionLength, true);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = seirawan_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        // printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = seirawan_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t move = seirawan_letComputerThink(positionBytes, positionLength, true, 15, 19, 5000);
                        if(move!=0){
                            // print move to string
                            seirawan_printMove(move);
                            // check legal move
                            if(seirawan_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = seirawan_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                seirawan_printMove(move);
                                seirawan_printPosition(positionBytes, positionLength, true);
                                seirawan_printPositionFen(positionBytes, positionLength, true);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            seirawan_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        seirawan_printPosition(positionBytes, positionLength, true);
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
    
    bool alreadyInitSeirawanMain = false;
    
    int32_t seirawan_main(int matchCount, std::string ResourcePath) {
        // insert code here...
        printf("sizeof StateInfo: %lu\n", sizeof(StateInfo));
        
        if(!alreadyInitSeirawanMain){
            alreadyInitSeirawanMain = true;
            seirawan_initCore();
        }
        {
            pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            
            for(int32_t i=0; i<matchCount; i++){
                pthread_t tid;
                pthread_create(&tid, &attr, threadMyTest, NULL);
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
// 129.3
// 139.7
