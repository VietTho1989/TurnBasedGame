//
//  position.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstring>
#include "gomoku_position.hpp"

namespace gomoku
{
    void Position::setLastMove(int32_t coord)
    {
        for (int32_t i=LastMoveCount-1; i>0; i--) {
            lastMove[i] = lastMove[i-1];
        }
        lastMove[0] = coord;
    }
    
    void Position::print(char* ret)
    {
        ret[0] = 0;
        if(gs!=nullptr){
            printf("winSize: %d\n", winSize);
            int64_t length = strlen(gs);
            if(length==boardSize*boardSize){
                for(int32_t y=0; y<boardSize; y++){
                    for(int32_t x=0; x<boardSize; x++){
                        int32_t coord = x+ boardSize*y;
                        if(gs[coord]=='1' || gs[coord]=='2'){
                            // get char
                            char c = 'X';
                            {
                                bool isWinCoord = false;
                                // check is win coord
                                {
                                    if(winSize>=0 && winSize<100){
                                        for(int32_t i=0; i<winSize; i++){
                                            if(winCoord[i]==coord){
                                                isWinCoord = true;
                                                // printf("winCoord: %d\n", i);
                                                break;
                                            }
                                        }
                                    }else{
                                        printf("winSize error: %d\n", winSize);
                                    }
                                }
                                if(!isWinCoord){
                                    if(gs[coord]=='1'){
                                        c = 'X';
                                    }else{
                                        c = 'O';
                                    }
                                }else{
                                    if(gs[coord]=='1'){
                                        c = 'x';
                                    }else{
                                        c = 'o';
                                    }
                                }
                            }
                            // print
                            {
                                // find lastMoveIndex
                                int32_t lastMoveIndex = -1;
                                for(int32_t i=LastMoveCount-1; i>=0; i--){
                                    if(coord==lastMove[i]){
                                        lastMoveIndex = i;
                                    }
                                }
                                if(lastMoveIndex>=0){
                                    sprintf(ret, "%s %c%d", ret, c, lastMoveIndex+1);
                                }else{
                                    sprintf(ret, "%s %c ", ret, c);
                                }
                            }
                        }else{
                            sprintf(ret, "%s . ", ret);
                        }
                    }
                    sprintf(ret, "%s\n", ret);
                }
            }else{
                printf("error, length error: %ld, %d\n", length, boardSize);
            }
        }else{
            printf("error, gs null\n");
        }
    }

    int32_t Position::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t boardSize = 19;
            ret+= sizeof(int32_t);
            // char* gs;
            ret+= sizeof(char)*boardSize*boardSize;
            // int32_t player = 1;
            ret+= sizeof(int32_t);
            // int32_t winningPlayer = 0;
            ret+= sizeof(int32_t);
            // int32_t lastMove;
            ret+= LastMoveCount*sizeof(int32_t);
            
            // int32_t winSize = 0;
            ret+= sizeof(int32_t);
            // int32_t winCoord[100];
            ret+= 100*sizeof(int32_t);
        }
        return ret;
    }

    int32_t Position::convertToByteArray(struct Position* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // int32_t boardSize = 19;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->boardSize;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: boardSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // char* gs;
                {
                    int32_t size = sizeof(char);
                    // get gsLength
                    int64_t gsLength = 0;
                    {
                        if(position->gs){
                            gsLength = strlen(position->gs);
                        }
                    }
                    // write
                    for(int32_t i=0; i< position->boardSize* position->boardSize; i++){
                        if(pointerIndex+size<=length){
                            char value = '0';
                            {
                                if(i<gsLength){
                                    value = position->gs[i];
                                }else{
                                    printf("error, i>=gsLength: %d, %ld\n", i, gsLength);
                                }
                            }
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: c: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // int32_t player = 1;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->player;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: player: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t winningPlayer = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->winningPlayer;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winningPlayer: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t lastMove;
                {
                    int32_t size = LastMoveCount*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->lastMove, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: lastMove: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // int32_t winSize = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->winSize;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t winCoord[100];
                {
                    int32_t size = 100*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &position->winCoord, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winCoord: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check convert correct
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t Position::parseByteArray(struct Position* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t boardSize = 19;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->boardSize, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: boardSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    if(position->boardSize<3){
                        printf("error, boardSize error\n");
                        position->boardSize = 3;
                    }
                }
                    break;
                case 1:
                    // char* gs;
                {
                    // find gs
                    char* gs = NULL;
                    {
                        // find old
                        {
                            if(position->gs){
                                if(strlen(position->gs)==position->boardSize*position->boardSize){
                                    gs = position->gs;
                                }else{
                                    free(position->gs);
                                }
                            }
                        }
                        // make new
                        if(!gs){
                            gs = (char*)calloc(position->boardSize*position->boardSize+1, sizeof(char));
                            position->gs = gs;
                        }
                    }
                    // parse
                    if(gs){
                        int32_t size = sizeof(char)* position->boardSize*position->boardSize;
                        if(pointerIndex+size<=length){
                            memcpy(gs, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: gs: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }else{
                        printf("error, gs null\n");
                    }
                }
                    break;
                case 2:
                    // int32_t player = 1;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->player, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: player: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // int32_t winningPlayer = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->winningPlayer, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winningPlayer: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // int32_t lastMove;
                {
                    int32_t size = LastMoveCount*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->lastMove, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: lastMove: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                    
                case 5:
                    // int32_t winSize = 0;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->winSize, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                    // int32_t winCoord[100];
                {
                    int32_t size = 100*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->winCoord, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: winCoord: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        {
            if(canCorrect){
                // player
                {
                    if(position->player!=1 && position->player!=2){
                        printf("error, player not correct: %d\n", position->player);
                        position->player = 1;
                    }
                }
            }
        }
        
        // return
        if (!isParseCorrect) {
            printf("error, position parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
}
