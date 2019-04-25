//
//  main.cpp
//  Klondike_Solver
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include<iostream>
#include<fstream>
#include<ctime>
#include<cstring>
// #include <pthread.h>
#include <thread>
#include <vector>
#include "../Platform.h"
#include "solitaire_Solitaire.hpp"
#include "solitaire_main.hpp"
#include "solitaire_jni.hpp"
#define _stricmp strcasecmp

using namespace std;

namespace Solitaire
{
    
    // void *threadTest(void *vargp)
    void threadTest()
    {
        {
            uint8_t* startPositionBytes;
            uint16_t drawCount = 1;
            int32_t length = solitaire_makeDefaultPosition(drawCount, startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                // moves
                bool alreadyThink = false;
                SolveResult result = CouldNotComplete;
                int32_t moveCount = 0;
                Move moves[512];
                // match
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        uint8_t* outStrPosition;
                        solitaire_printPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    int32_t gameFinish = solitaire_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        // think
                        if(!alreadyThink){
                            alreadyThink = true;
                            // think
                            uint8_t* moveBytes;
                            int32_t multiThreaded = 1;
                            int32_t maxClosedCount = 0;
                            bool fastMode = true;
                            int32_t moveLength = solitaire_letComputerThink(positionBytes, positionLength, true, multiThreaded, maxClosedCount, fastMode, moveBytes);
                            // convert
                            {
                                int32_t pointerIndex = 0;
                                bool isParseCorrect = true;
                                // result
                                if(isParseCorrect){
                                    int32_t size = sizeof(int32_t);
                                    if(pointerIndex+size<=moveLength){
                                        memcpy(&result, moveBytes + pointerIndex, size);
                                        pointerIndex+=size;
                                    }else{
                                        printf("length error: result: %d, %d\n", pointerIndex, length);
                                        isParseCorrect = false;
                                    }
                                }
                                // move count
                                if(isParseCorrect){
                                    int32_t size = sizeof(int32_t);
                                    if(pointerIndex+size<=moveLength){
                                        memcpy(&moveCount, moveBytes + pointerIndex, size);
                                        pointerIndex+=size;
                                    }else{
                                        printf("length error: moveCount: %d, %d\n", pointerIndex, length);
                                        isParseCorrect = false;
                                    }
                                    // correct
                                    if(moveCount<0 || moveCount>=512){
                                        printf("moveCount error: %d\n", moveCount);
                                    }
                                }
                                // moves
                                if(isParseCorrect){
                                    for (int32_t i = 0; i < moveCount; i++) {
                                        int32_t moveByteLength = Move::parseByteArray (&moves[i], moveBytes, moveLength, pointerIndex, true);
                                        if (moveByteLength > 0) {
                                            pointerIndex+= moveByteLength;
                                        } else {
                                            printf("cannot parse\n");
                                            break;
                                        }
                                    }
                                }
                            }
                            printf("solitaire result: %d, %d\n", result, moveCount);
                            // free data
                            if(moveLength>0){
                                free(moveBytes);
                            }else{
                                printf("error, why moveLength = 0\n");
                            }
                        }
                        // doMove
                        {
                            uint8_t* moveBytes;
                            int32_t moveLength = Move::convertToByteArray(&moves[turn], moveBytes);
                            // do move
                            {
                                uint8_t* newOutRet;
                                int32_t newLength = solitaire_doMove(positionBytes, positionLength, true, moveBytes, moveLength, newOutRet);
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
                            turn++;
                            if(turn>moveCount){
                                printf("error, why don't win\n");
                                break;
                            }
                        }
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        {
                            uint8_t* outStrPosition;
                            solitaire_printPosition(positionBytes, positionLength, true, outStrPosition);
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
        // return NULL;
    }
    
    int solitaire_main(int32_t matchCount, std::string ResourcePath)
    {
        /*pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        pthread_attr_setstacksize(&attr, 10*1048576);
        
        for(int32_t i=0; i<matchCount; i++){
            pthread_t tid;
            pthread_create(&tid, &attr, threadTest, NULL);
        }*/
        
        std::vector<std::thread> threads;
        for(int32_t i=0; i<matchCount; i++){
            threads.push_back(std::thread(threadTest));
        }
        for(auto& t : threads)
        {
            t.join();
        }
        
        /*Solitaire s;
        s.Initialize();
        
        srand(now());
        int random = rand();
        printf("random: %d\n", random);
        s.SetDrawCount(1);
        s.Shuffle1(random);
        
        int outputMethod = 0;
        int multiThreaded = 1;
        int maxClosedCount = 0;
        bool fastMode = false;
        bool replay = true;
        bool showMoves = true;
        
        if (maxClosedCount == 0) { maxClosedCount = 5000000; }
        {
            s.ResetGame();
            
            if (outputMethod == 0) {
                cout << s.GameDiagram() << "\n\n";
            } else if (outputMethod == 1) {
                cout << s.GameDiagramPysol() << "\n\n";
            }
            
            clock_t total = clock();
            SolveResult result = CouldNotComplete;
            if (fastMode) {
                int bestCount = 512;
                int bestFoundation = 0;
                result = s.SolveFast(maxClosedCount, 0, 0);
                if (result == SolvedMinimal || result == SolvedMayNotBeMinimal) {
                    bestCount = s.MovesMadeNormalizedCount();
                }
                bestFoundation = s.FoundationCount();
                Solitaire best = s;
                s.ResetGame();
                result = s.SolveFast(maxClosedCount, 0, 4);
                if ((result == SolvedMinimal || result == SolvedMayNotBeMinimal) && s.MovesMadeNormalizedCount() < bestCount) {
                    best = s; bestCount = s.MovesMadeNormalizedCount(); bestFoundation = s.FoundationCount();
                }
                if (s.FoundationCount() > bestFoundation) {
                    best = s; bestFoundation = s.FoundationCount();
                }
                s.ResetGame();
                result = s.SolveFast(maxClosedCount, 1, 4);
                if ((result == SolvedMinimal || result == SolvedMayNotBeMinimal) && s.MovesMadeNormalizedCount() < bestCount) {
                    best = s; bestCount = s.MovesMadeNormalizedCount(); bestFoundation = s.FoundationCount();
                }
                if (s.FoundationCount() > bestFoundation) {
                    best = s; bestFoundation = s.FoundationCount();
                }
                s = best;
                if (bestFoundation == 52) { result = SolvedMayNotBeMinimal; }
            } else if (multiThreaded > 1) {
                result = s.SolveMinimalMultithreaded(multiThreaded, maxClosedCount);
            } else {
                result = s.SolveMinimal(maxClosedCount);
            }
            
            bool canReplay = false;
            if (result == SolvedMinimal) {
                cout << "Minimal solution in " << s.MovesMadeNormalizedCount() << " moves.";
                canReplay = true;
            } else if (result == SolvedMayNotBeMinimal) {
                cout << "Solved in " << s.MovesMadeNormalizedCount() << " moves.";
                canReplay = true;
            } else if (result == Impossible) {
                cout << "Impossible. Max cards in foundation " << s.FoundationCount() << " at " << s.MovesMadeNormalizedCount() << " moves.";
            } else if (result == CouldNotComplete) {
                cout << "Unknown. Max cards in foundation " << s.FoundationCount() << " at " << s.MovesMadeNormalizedCount() << " moves.";
            }
            cout << " Took " << (clock() - total) << " ms.\n";
            
            if (outputMethod < 2 && replay && canReplay) {
                int movesToMake = s.MovesMadeCount();
                s.ResetGame();
                for (int i = 0; i < movesToMake; i++) {
                    cout << "----------------------------------------\n";
                    cout << s.GetMoveInfo(s[i]) << "\n\n";
                    s.MakeMove(s[i]);
                    
                    if (outputMethod == 0) {
                        cout << s.GameDiagram() << "\n\n";
                    } else {
                        cout << s.GameDiagramPysol() << "\n\n";
                    }
                }
                cout << "----------------------------------------\n";
            }
            if (showMoves && canReplay) {
                cout << s.MovesMade() << "\n\n";
            } else if (showMoves) {
                cout << "\n";
            }
        };*/
        
        return 0;
    }
    
}
