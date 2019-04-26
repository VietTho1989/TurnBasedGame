//
//  main.cpp
//  StockFishChess
//
//  Created by Viet Tho on 1/9/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include <iostream>
#include <sstream>
// #include <pthread.h>
#include "chess_stock_fish_jni.hpp"
#include <vector>
// #include <thread>
#include <boost/thread.hpp>

namespace StockFishChess
{
    // void *threadMyTest(void *vargp)
    void threadMyTest()
    {
        {
            uint8_t* startPositionBytes;
            bool chess960 = false;
            int32_t length = chess_makePositionByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", chess960, startPositionBytes);
            // int32_t length = makePositionByFen("r1r2b1k/3q1p2/2b1p1pn/pp1pP1R1/2pP3P/P1P2NQB/2PB1P1K/6R1 w - - 0 36", chess960, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        chess_printPosition(positionBytes, positionLength, true);
                        chess_printPositionFen(positionBytes, positionLength, true);
                    }
                    // printFen
                    {
                        uint8_t* outStrFen;
                        chess_position_to_fen(positionBytes, positionLength, true, outStrFen);
                        free(outStrFen);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = chess_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    int32_t gameFinish = chess_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t move = chess_letComputerThink(positionBytes, positionLength, true, 15, 19, 5000);
                        if(move!=0){
                            // print move to string
                            chess_printMove(move, chess960);
                            // check legal move
                            if(chess_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = chess_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                chess_printMove(move, chess960);
                                chess_printPosition(positionBytes, positionLength, true);
                                chess_printPositionFen(positionBytes, positionLength, true);
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            chess_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        chess_printPosition(positionBytes, positionLength, true);
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
                    // std::this_thread::sleep_for (std::chrono::seconds(1));
                }while (true);
                // free data
                if(positionBytes!=NULL){
                    free(positionBytes);
                }
            }
        }
        // return NULL;
    }

    int32_t chess_main(int matchCount, std::string ResourcePath)
    {
        // insert code here...
        std::cout << "Hello, World!\n";
        
        chess_initCore();
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
                // attrs.set_stack_size(1024);
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
                for(int32_t i=0; i<12; i++){
                    pthread_t tid;
                    pthread_create(&tid, &attr, threadMyTest, NULL);
                }
            }*/
        }
        
        return 0;
    }
}
