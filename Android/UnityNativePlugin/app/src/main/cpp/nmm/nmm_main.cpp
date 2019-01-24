//
//  nmm_main.cpp
//  NativeCore
//
//  Created by Viet Tho on 1/3/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include <iostream>
#include <string>
#include <thread>
#include "nmm_main.hpp"
#include "../Platform.h"
#include "nmmagent.hpp"
#include "nmm_board.hpp"
#include "nmm_jni.hpp"

namespace NMM
{
    
    void *threadTest(void *vargp)
    {
        uint8_t* startPositionBytes;
        int32_t length = nmm_makeDefaultPosition(startPositionBytes);
        printf("makeDefaultPosition: %d\n", length);
        // Make a match
        {
            int32_t turn = 0;
            uint8_t* positionBytes = startPositionBytes;
            int32_t positionLength = length;
            uint8_t* moveBytes = NULL;
            do{
                printf("before letComputerThink: %d %d\n", turn, positionLength);
                // print position
                {
                    uint8_t* outStrPosition;
                    nmm_printPosition(positionBytes, positionLength, true, outStrPosition);
                    free(outStrPosition);
                }
                // legalMoves
                {
                    uint8_t* outLegalMoves;
                    int32_t outLegalMovesLength = nmm_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                    if(outLegalMovesLength!=0){
                        free(outLegalMoves);
                    }
                    printf("outLegalMoves: %d\n", outLegalMovesLength);
                }
                int32_t gameFinish = nmm_isGameFinish(positionBytes, positionLength, true);
                // printf("gameFinish: %d\n", gameFinish);
                if(gameFinish==0){
                    // delete move
                    {
                        if(moveBytes!=NULL){
                            free(moveBytes);
                            moveBytes = NULL;
                        }else{
                            // printf("error, why moveBytes NULL\n");
                        }
                    }
                    // letComputerThink
                    int32_t moveLength = nmm_letComputerThink(positionBytes, positionLength, true, 3, 3, 3, 3, 90, moveBytes);
                    // do move
                    {
                        // print move to string
                        /*{
                            uint8_t* outStrMove;
                            russian_draught_printMove(moveBytes, moveLength, true, outStrMove);
                            free(outStrMove);
                        }*/
                        // check legal move
                        if(nmm_isLegalMove(positionBytes, positionLength, true, moveBytes, moveLength)){
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = nmm_doMove(positionBytes, positionLength, true, moveBytes, moveLength, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                                // delete move
                                {
                                    if(moveBytes!=NULL){
                                        free(moveBytes);
                                        moveBytes = NULL;
                                    }else{
                                        // printf("error, why moveBytes NULL\n");
                                    }
                                }
                            }
                        }else{
                            printf("error: why not legal move\n");
                            // delete move
                            {
                                if(moveBytes!=NULL){
                                    free(moveBytes);
                                    moveBytes = NULL;
                                }else{
                                    printf("error, why moveBytes NULL\n");
                                }
                            }
                            break;
                        }
                    }
                    turn++;
                }else{
                    printf("game finish in turn: %d\n", turn);
                    // print position
                    {
                        uint8_t* outStrPosition;
                        nmm_printPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    switch (gameFinish) {
                        case 1:
                            // white move first
                            printf("white win: %d\n", turn);
                            break;
                        case 2:
                            // black move after
                            printf("black win: %d\n", turn);
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
                // std::this_thread::sleep_for (std::chrono::seconds(1));
            }while (true);
            // free data
            {
                // free position
                if(positionBytes!=NULL){
                    printf("error, why positionBytes!=NULL\n");
                    free(positionBytes);
                    positionBytes = NULL;
                }
                // delete move
                {
                    if(moveBytes!=NULL){
                        free(moveBytes);
                        moveBytes = NULL;
                    }else{
                        // printf("error, why moveBytes NULL\n");
                    }
                }
            }
        }
        
        return NULL;
    }
    
    void *threadMyTest(void *vargp)
    {
        
        //agent 1
        NMMAgent* a = new NMMAgent();
        int32_t aphase1[6] = {18, 26, 1, 6, 12, 7};
        int32_t aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
        int32_t aphase3[4] = {10, 1, 16, 1190};
        a->set_evaluator_weights(aphase1, aphase2, aphase3);
        a->set_color_pieces(true);
        
        //agent 2
        NMMAgent* b = new NMMAgent();
        int32_t bphase1[6] = {18, 26, 1, 6, 21, 7};
        int32_t bphase2[7] = {42, 28, 16, 8, 24, 19, 949};
        int32_t bphase3[4] = {23, 18, 5, 1096};
        b->set_evaluator_weights(bphase1, bphase2, bphase3);
        b->set_color_pieces(false);
        
        SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
        
        while(!root->terminal)
        {
            printf("root utility: %f\n", root->utility);
            
            if(root->isWhiteTurn()) {
                int32_t turn = root->turn;
                // set agent
                a->set_game_phase(root->getPhase());
                a->set_color_pieces(true);
                // find
                root = a->decide(root);
                // next turn
                root->turn = turn + 1;
            } else {
                int32_t turn = root->turn;
                // set agent
                b->set_game_phase(root->getPhase());
                b->set_color_pieces(false);
                // find
                root = b->decide(root);
                // next turn
                root->turn = turn + 1;
            }
            
            if(root->turn > DrawTurn)
                break;
            printf("TURNO: %d %s\n", root->turn, (root->isWhiteTurn()? "W" : "B"));
            root->board->print();
            
            // test successor
            {
                // white
                {
                    std::vector<SmrtState> suc = a->expand(root, true);
                    printf("suc size: white: %lu\n", suc.size());
                }
                // black
                {
                    std::vector<SmrtState> suc = a->expand(root, false);
                    printf("suc size: black: %lu\n", suc.size());
                }
            }
        }
        
        printf("root terminal: %s, so %s\n", root->isWhiteTurn()? "white turn" : "black turn", root->isWhiteTurn() ? "black win" : "white win");
        // free data
        {
            // a
            {
                delete a->eval;
                delete a;
            }
            // b
            {
                delete b->eval;
                delete b;
            }
        }
        
        return NULL;
    }
 
    int32_t nmm_main(int32_t matchCount, std::string ResourcePath)
    {
        printf("size: %lu, %lu, %lu, %lu, %lu\n", sizeof(Spot), sizeof(Board), sizeof(State), sizeof(NMMAgent), sizeof(Evaluator));
        pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        pthread_attr_setstacksize(&attr, 10*1048576);
        
        matchCount = 1;
        for(int32_t i=0; i<matchCount; i++){
            pthread_t tid;
            pthread_create(&tid, &attr, threadTest, NULL);
        }
        
        return 0;
    }
    
}
