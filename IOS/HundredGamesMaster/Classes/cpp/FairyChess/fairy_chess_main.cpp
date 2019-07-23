//
//  fairy_chess_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 8/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <sstream>
#include <vector>
// #include <thread>
// #include <pthread.h>
#include <boost/thread.hpp>
#include "fairy_chess_main.hpp"
#include "fairy_chess_jni.hpp"
#include "fairy_chess_misc.hpp"
#include "fairy_chess_movepick.hpp"
#include "fairy_chess_pawns.hpp"
#include "fairy_chess_search.hpp"

namespace FairyChess
{
    
    // void *threadMyTest(void *vargp)
    void threadMyTest()
    {
        {
            uint8_t* startPositionBytes;
            VariantType variantType = minishogi;
            {
                static PRNG rng(now());
                variantType = (VariantType)(rng.rand<uint32_t>()%28);
                printf("random variantType: %d\n", variantType);
            }
            bool chess960 = false;
            char strFen[200];
            {
                getStartFen(strFen, variantType);
                printf("strFen: %s\n", strFen);
            }
            int32_t length = fairy_chess_makePositionByFen(variantType, strFen, chess960, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        fairy_chess_printPosition(positionBytes, positionLength, true);
                        fairy_chess_printPositionFen(positionBytes, positionLength, true);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = fairy_chess_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = fairy_chess_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t move = fairy_chess_letComputerThink(positionBytes, positionLength, true, 15, 19, 30000);
                        if(move!=0){
                            // print move to string
                            // fairy_chess_printMove(move, chess960);
                            // check legal move
                            if(fairy_chess_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = fairy_chess_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                //fairy_chess_printMove(move, chess960);
                                fairy_chess_printPosition(positionBytes, positionLength, true);
                                fairy_chess_printPositionFen(positionBytes, positionLength, true);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            fairy_chess_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        fairy_chess_printPosition(positionBytes, positionLength, true);
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
    
    bool alreadyInitFairyChessMain = false;
    
    int32_t fairy_chess_main(int32_t matchCount, std::string ResourcePath)
    {
        // CounterMoveHistory counterMoves;
        // ButterflyHistory mainHistory;
        // CapturePieceToHistory captureHistory;
        // ContinuationHistory contHistory;
        printf("sizeof Position: %lu, %lu, %lu, %lu\n", sizeof(Position), sizeof(Search::Stack), sizeof(StateInfo), sizeof(ButterflyHistory));
        
        if(!alreadyInitFairyChessMain){
            alreadyInitFairyChessMain = true;
            fairy_chess_initCore();
        }
        {
            /*pthread_attr_t attr;
            pthread_attr_init(&attr);
            pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
            // TODO Co le ko can pthread_attr_setstacksize(&attr, 1048576);
            
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
        }
        
        return 0;
    }
}
// 140.6
// 142.4
