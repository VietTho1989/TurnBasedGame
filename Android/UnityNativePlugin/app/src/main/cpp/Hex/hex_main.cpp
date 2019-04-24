//
//  main.cpp
//  MyFutaHex
//
//  Created by Viet Tho on 9/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <stdlib.h>
#include <pthread.h>
#include "fhcore/hex_board.hpp"
#include "fhcore/hex_iengine.hpp"
#include "fhcore/hex_mcts.hpp"
#include "fhcore/hex_color.hpp"
#include "../Platform.h"
#include "hex_jni.hpp"

namespace Hex
{
    using namespace board;
    using namespace engine;
    using namespace std;
    
    void *threadTest(void *vargp)
    {
        {
            uint8_t* startPositionBytes;
            uint16_t boardSize = 11;
            int32_t length = hex_makeDefaultPosition(boardSize, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        uint8_t* outStrPosition;
                        hex_printPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    int32_t gameFinish = hex_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        int32_t limitTime = 20;
                        bool firstMoveCenter = false;
                        uint16_t move = hex_letComputerThink(positionBytes, positionLength, true, limitTime, firstMoveCenter);
                        if(move>=0){
                            // print move to string
                            {
                                
                            }
                            // check legal move
                            if(hex_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = hex_doMove(positionBytes, positionLength, true, move, newOutRet);
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
                            printf("error, why don't find any move, break\n");
                            // chess_printPosition(positionBytes, positionLength, true);
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        {
                            uint8_t* outStrPosition;
                            hex_printPosition(positionBytes, positionLength, true, outStrPosition);
                            free(outStrPosition);
                        }
                        switch (gameFinish) {
                            case 1:
                                printf("you win\n");
                                break;
                            case 2:
                                printf("you lose\n");
                                break;
                            default:
                                printf("error, unknown gameFinish: %d\n", gameFinish);
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
        return NULL;
    }
    
    void *threadMyTest(void *vargp)
    {
        board::IBoard* _pBoard = IBoard::create(30);
        // think
        int32_t turn = 0;
        while (_pBoard->winner()==Color::Empty) {
            // find ai move
            pos_t result;
            {
                EngineCfg cfg;
                cfg.colorAI = _pBoard->color();
                cfg.pBoard = _pBoard;
                
                MCTSEngine* pEngine = new MCTSEngine(std::chrono::seconds(5));
                {
                    pEngine->firstMoveCenter = false;
                }
                pEngine->configure(cfg);
                pEngine->compute_sync(result);
                cout << result << std::endl;
                // free data
                delete pEngine;
            }
            // doMove
            {
                int32_t row = result.row;
                int32_t col = result.col;
                Color color = _pBoard->color();
                (*_pBoard)(row, col) = color;
            }
            // print pos
            {
                char strPos[5000];
                print(_pBoard, strPos);
                printf("Turn: %d\n%s\n", turn, strPos);
                turn++;
            }
        }
        printf("result: %hhd\n", _pBoard->winner());
        delete _pBoard;
        
        return NULL;
    }
    
    int32_t hex_main(int32_t matchCount, std::string ResourcePath) {
        // insert code here...
        // printf("size of : %lu", sizeof(disjointset::DisjointSetT<11>));
        
        srand(now());
        pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        
        for(int32_t i=0; i<matchCount; i++){
            pthread_t tid;
            pthread_create(&tid, &attr, threadTest, NULL);
        }
        
        return 0;
    }
}
