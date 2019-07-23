//
//  solitaire_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 12/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <stdlib.h>
#include "solitaire_jni.hpp"
#include "solitaire_Solitaire.hpp"

namespace Solitaire
{
    
    int32_t solitaire_makeDefaultPosition(int32_t drawCount, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // create
            Solitaire s;
            {
                s.Initialize();
                int random = rand();
                printf("random: %d\n", random);
                s.SetDrawCount(drawCount);
                s.Shuffle1(random);
                s.ResetGame();
                s.UpdateAvailableMoves();
                // printf("%s\n\n", s.GameDiagram().c_str());
            }
            // convert
            ret = Solitaire::convertToByteArray(&s, outRet);
        }
        return ret;
    }
    
    int32_t solitaire_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        int32_t ret = 0;
        {
            bool isWin = false;
            {
                if(pos.piles[FOUNDATION1C].Size()==13 && pos.piles[FOUNDATION2D].Size()==13 && pos.piles[FOUNDATION3S].Size()==13 && pos.piles[FOUNDATION4H].Size()==13){
                    isWin = true;
                }
            }
            if(isWin){
                // you win
                ret = 1;
            }else{
                // check don't have any moves
                if(pos.movesAvailableCount==0){
                    // don't have any legal move
                    ret = 2;
                }
            }
        }
        return ret;
    }
    
    int32_t solitaire_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int multiThreaded, int maxClosedCount, bool fastMode, uint8_t* &outRet)
    {
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // think
        int32_t outLength = 0;
        {
            if (maxClosedCount == 0) {
                maxClosedCount = 5000000;
            }
            {
                pos.ResetGame();
                
                // TODO Test draw move
                /*{
                    pos.movesMadeCount = 30;
                    for(int i=0; i<pos.movesMadeCount; i++){
                        pos.movesMade[i].From = WASTE;
                        pos.movesMade[i].To = WASTE;
                        pos.movesMade[i].Count = 1;
                        pos.movesMade[i].Extra = 1;
                    }
                }*/
                
                clock_t total = clock();
                SolveResult result = CouldNotComplete;
                if (fastMode) {
                    int bestCount = 512;
                    int bestFoundation = 0;
                    result = pos.SolveFast(maxClosedCount, 0, 0);
                    if (result == SolvedMinimal || result == SolvedMayNotBeMinimal) {
                        bestCount = pos.MovesMadeNormalizedCount();
                    }
                    bestFoundation = pos.FoundationCount();
                    Solitaire best = pos;
                    pos.ResetGame();
                    result = pos.SolveFast(maxClosedCount, 0, 4);
                    if ((result == SolvedMinimal || result == SolvedMayNotBeMinimal) && pos.MovesMadeNormalizedCount() < bestCount) {
                        best = pos;
                        bestCount = pos.MovesMadeNormalizedCount();
                        bestFoundation = pos.FoundationCount();
                    }
                    if (pos.FoundationCount() > bestFoundation) {
                        best = pos;
                        bestFoundation = pos.FoundationCount();
                    }
                    pos.ResetGame();
                    result = pos.SolveFast(maxClosedCount, 1, 4);
                    if ((result == SolvedMinimal || result == SolvedMayNotBeMinimal) && pos.MovesMadeNormalizedCount() < bestCount) {
                        best = pos;
                        bestCount = pos.MovesMadeNormalizedCount();
                        bestFoundation = pos.FoundationCount();
                    }
                    if (pos.FoundationCount() > bestFoundation) {
                        best = pos;
                        bestFoundation = pos.FoundationCount();
                    }
                    pos = best;
                    if (bestFoundation == 52) {
                        result = SolvedMayNotBeMinimal;
                    }
                } else if (multiThreaded > 1) {
                    result = pos.SolveMinimalMultithreaded(multiThreaded, maxClosedCount);
                } else {
                    result = pos.SolveMinimal(maxClosedCount);
                }
                
                if (result == SolvedMinimal) {
                    printf("Minimal solution in %d moves.", pos.MovesMadeNormalizedCount());
                } else if (result == SolvedMayNotBeMinimal) {
                    printf("Solved in %d moves.", pos.MovesMadeNormalizedCount());
                } else if (result == Impossible) {
                    printf("Impossible. Max cards in foundation %d at %d moves.\n", pos.FoundationCount(), pos.MovesMadeNormalizedCount());
                } else if (result == CouldNotComplete) {
                    printf("Unknown. Max cards in foundation %d at %d moves.", pos.FoundationCount(), pos.MovesMadeNormalizedCount());
                }
                printf(" Took %lu ms.\n", (clock() - total));
                
                // correct answer
                {
                    if(pos.movesMadeCount<0 || pos.movesMadeCount>=512){
                        printf("error, movesMadeCount not correct\n");
                        pos.movesMadeCount = 0;
                    }
                }
                
                // convert to return value
                {
                    outLength = sizeof(int32_t) + sizeof(int32_t) + pos.movesMadeCount*Move::getByteSize();
                    outRet = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    // copy byte array
                    int32_t pointerIndex = 0;
                    // result
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=outLength){
                            memcpy(outRet + pointerIndex, &result, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: result: %d, %d\n", pointerIndex, outLength);
                        }
                    }
                    // move count
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=outLength){
                            memcpy(outRet + pointerIndex, &pos.movesMadeCount, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: movesMadeCount: %d, %d\n", pointerIndex, outLength);
                        }
                    }
                    // movesMade
                    {
                        for(int32_t i=0; i<pos.movesMadeCount; i++){
                            uint8_t* moveByteArray;
                            int32_t size = Move::convertToByteArray (&pos.movesMade[i], moveByteArray);
                            if(pointerIndex+size<=outLength){
                                memcpy(outRet + pointerIndex, moveByteArray, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: movesMade: %d, %d\n", pointerIndex, outLength);
                            }
                            free(moveByteArray);
                        }
                    }
                }
                printf("move count: %d, outLength: %d\n", pos.movesMadeCount, outLength);
            }
        }
        return outLength;
    }
    
    int32_t solitaire_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // make position
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // play move
        {
            pos.MakeMove(move);
            pos.UpdateAvailableMoves();
        }
        // return
        int32_t newLength = Solitaire::convertToByteArray(&pos, outRet);
        return newLength;
    }
    
    int32_t solitaire_reset(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet)
    {
        // make position
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // reset
        pos.ResetGame();
        pos.UpdateAvailableMoves();
        // return
        int32_t newLength = Solitaire::convertToByteArray(&pos, outRet);
        return newLength;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////// Print ///////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    int32_t solitaire_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[1000];
            {
                ret[0] = 0;
                strcpy(ret, pos.GameDiagram().c_str());
                printf("\nprint solitaire:\n%s\n", ret);
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outStrPosition = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrPosition, ret, outLength);
                }
            }
        }
        // return
        return outLength;
    }
    
    int32_t solitaire_printMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // make position
        Solitaire pos;
        {
            Solitaire::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // make strMove
        int32_t outLength = 0;
        {
            // get
            char ret[1000];
            {
                ret[0] = 0;
                strcpy(ret, pos.GetMoveInfo(move).c_str());
                printf("\nprint solitaireMove:\n%s\n", ret);
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outRet = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outRet, ret, outLength);
                }
            }
        }
        // return
        return outLength;
    }
    
}
