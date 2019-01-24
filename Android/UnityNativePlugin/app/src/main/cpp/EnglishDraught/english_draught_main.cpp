//
//  main.cpp
//  EnglishDraught
//
//  Created by Viet Tho on 7/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <thread>
#include <pthread.h>
#include "english_draught_jni.hpp"
#include "engine/english_draught_ai.hpp"

namespace EnglishDraught
{
    
    void *threadTest(void *vargp)
    {
        uint8_t* startPositionBytes;
        int maxPly = 200;
        int32_t length = english_draught_makeDefaultPosition(EnglishDraughtStartFen, maxPly, startPositionBytes);
        printf("makeDefaultPosition: %d\n", length);
        // lastMove
        SMove lastMove;
        {
            lastMove.SrcDst = 0;
        }
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                {
                    english_draught_printPosition(positionBytes, positionLength, true, &lastMove);
                }
                // legalMoves
                {
                    uint8_t* outLegalMoves;
                    int32_t outLegalMovesLength = english_draught_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                    printf("outLegalMovesLength: %d\n", outLegalMovesLength);
                    free(outLegalMoves);
                }
                int32_t gameFinish = english_draught_isGameFinish(positionBytes, positionLength, true);
                // printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // letComputerThink
                    bool threeMoveRandom = true;
                    float fMaxSeconds = 10.0f;
                    int32_t g_MaxDepth = 12;
                    int32_t pickBestMove = 90;
                    uint8_t* moveBytes;
                    int32_t moveLength = english_draught_letComputerThink(positionBytes, positionLength, true, threeMoveRandom, fMaxSeconds, g_MaxDepth, pickBestMove, moveBytes);
                    // do move
                    {
                        // print move to string
                        english_draught_printMove(moveBytes, moveLength);
                        // check legal move
                        if(english_draught_isLegalMove(positionBytes, positionLength, true, moveBytes, moveLength)){
                            // lastMove
                            {
                                SMove::parseByteArray(&lastMove, moveBytes, moveLength, 0, true);
                            }
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = english_draught_doMove(positionBytes, positionLength, true, moveBytes, moveLength, newOutRet);
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
                    english_draught_printPosition(positionBytes, positionLength, true, &lastMove);
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
                // usleep(1000);
            }while (true);
            if(positionBytes!=NULL){
                printf("error, why positionBytes!=NULL\n");
                free(positionBytes);
            }
        }
        
        return NULL;
    }
    
    void *threadMyTest(void *vargp)
    {
        CBoard board;
        {
            board.StartPosition(1);
            board.SideToMove = BLACK;
        }
        SMove lastMove;
        {
            lastMove.SrcDst = 0;
        }
        do {
            printf("turn: %d\n", board.turn);
            // print fen
            {
                char fen[100];
                fen[0] = 0;
                board.ToFen(fen);
                printf("turn fen: %s\n", fen);
            }
            // print board
            {
                char strBoard[2000];
                board.print(strBoard, &lastMove);
                printf("%s", strBoard);
            }
            int32_t gameFinish = CheckForGameOver(board);
            if(gameFinish==0) {
                // find ai move
                AI ai;
                ai.NewGame();
                CBoard beforeBoard = board;
                ai.ComputerMove(board.SideToMove, board);
                // doMove
                {
                    board = beforeBoard;
                    board.DoMove(ai.bestMove, MAKEMOVE);
                }
                lastMove = ai.bestMove;
            } else {
                printf("game finish: %d\n", gameFinish);
                // print board
                {
                    char strBoard[2000];
                    board.print(strBoard, &lastMove);
                    printf("%s", strBoard);
                }
                switch (gameFinish) {
                    case 0:
                        printf("error\n");
                        break;
                    case 1:
                        printf("black win\n");
                        break;
                    case 2:
                        printf("white win\n");
                        break;
                    case 3:
                        printf("draw\n");
                        break;
                    default:
                        printf("error, unknown gameFinish: %d\n", gameFinish);
                        break;
                }
                break;
            }
        } while (true);
        
        return NULL;
    }
    
    bool alreadyInitEnglishDraughtMain = false;
    
    int32_t english_draught_main(int matchCount, std::string ResourcePath) {
        // insert code here...
        std::cout << "Hello, World!\n";
        
        printf("size ttable: %lu, %lu\n", sizeof(TEntry)*HASHTABLESIZE + 2, sizeof(AI));
        if(!alreadyInitEnglishDraughtMain){
            alreadyInitEnglishDraughtMain = true;
            english_draught_setPath("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCore/Resources/AlwaysIn/EnglishDraught");
            english_draught_initCore();
        }
        
        pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        // pthread_attr_setstacksize(&attr, 10*1048576);
        
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
         for(int32_t i=0; i<1; i++){
         pthread_t tid;
         pthread_create(&tid, &attr, threadTest, NULL);
         }
         }*/
        
        return 0;
    }
    
}
// 130.4
