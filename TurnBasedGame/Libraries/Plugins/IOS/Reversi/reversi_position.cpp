//
//  position.cpp
//  TestOthello
//
//  Created by Viet Tho on 3/20/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "reversi_position.hpp"
#include <string.h>

namespace Reversi
{
    bool PositionStruct::isOK()
    {
        return true;
    }

    int32_t PositionStruct::getByteSize()
    {
        int32_t ret = sizeof(int32_t) + sizeof(uint64_t) + sizeof(uint64_t);
        ret+=sizeof(int8_t) + 64*sizeof(int8_t)+64*sizeof(bitbrd)+64*sizeof(int32_t);
        return ret;
    }

    int32_t PositionStruct::convertToByteArray(PositionStruct* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // Side side;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    int32_t value = position->side;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: side: %d, %d\n", pointerIndex, length);
                }
            }
            // bitbrd white;
            {
                int32_t size = sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    uint64_t value = position->white;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: piece1: %d, %d\n", pointerIndex, length);
                }
            }
            // bitbrd black;
            {
                int32_t size = sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    uint64_t value = position->black;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: piece1: %d, %d\n", pointerIndex, length);
                }
            }
            // nMoveNum
            {
                int32_t size = sizeof(int8_t);
                if(pointerIndex+size<=length){
                    int8_t value = position->nMoveNum;
                    memcpy(byteArray + pointerIndex, &value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: nMoveNum: %d, %d\n", pointerIndex, length);
                }
            }
            // moves
            {
                int32_t size = sizeof(int8_t);
                for(int32_t i=0; i<64; i++){
                    if(pointerIndex+size<=length){
                        int8_t value = position->moves[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moves: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // changes
            {
                int32_t size = sizeof(bitbrd);
                for(int32_t i=0; i<64; i++){
                    if(pointerIndex+size<=length){
                        bitbrd value = position->changes[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: changes: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // oldSides
            {
                int32_t size = sizeof(int32_t);
                for(int32_t i=0; i<64; i++){
                    if(pointerIndex+size<=length){
                        int32_t value = position->oldSides[i];
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: oldSides: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check parse correct
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t PositionStruct::parseByteArray(PositionStruct* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // Side side;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value;
                        memcpy(&value, positionBytes + pointerIndex, size);
                        position->side = (Side)value;
                        pointerIndex+=size;
                    }else{
                        printf("length error: side: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // bitbrd white;
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->white, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: piece1: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // bitbrd black;
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->black, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: piece2: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // nMoveNum
                {
                    int32_t size = sizeof(int8_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->nMoveNum, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: nMoveNum: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // moves
                {
                    int32_t size = sizeof(int8_t);
                    for(int32_t i=0; i<64; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->moves[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moves: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 5:
                    // changes
                {
                    int32_t size = sizeof(bitbrd);
                    for(int32_t i=0; i<64; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->changes[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: changes: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 6:
                    // oldSides
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<64; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->oldSides[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: oldSides: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
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
                if(!position->isOK()){
                    
                }else{
                    // printf("position ok\n");
                }
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
    void PositionStruct::rotatePos(PositionStruct* pos, RotateType rotateType)
    {
        this->white = rotateBitboard(pos->white, rotateType);
        this->black = rotateBitboard(pos->black, rotateType);
        this->side = pos->side;
        // history
        {
            this->nMoveNum = pos->nMoveNum;
            if(this->nMoveNum>=0 && this->nMoveNum<64){
                for(int32_t i=0; i<this->nMoveNum; i++){
                    // moves
                    this->moves[i] = rotateMove(pos->moves[i], rotateType);
                    // changes
                    this->changes[i] = rotateBitboard(pos->changes[i], rotateType);
                    // oldSides
                    this->oldSides[i] = pos->oldSides[i];
                }
            }else{
                printf("error, nMoveNum error: %d\n", this->nMoveNum);
            }
        }
    }
}
