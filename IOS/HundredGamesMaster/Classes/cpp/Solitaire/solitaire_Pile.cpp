#include "solitaire_Pile.hpp"
#include <cstdio>
#include <cstdlib>
#include <cstring>

namespace Solitaire
{
    
    void Pile::AddDown(Card card) {
        down[downSize++] = card;
        size++;
    }
    
    void Pile::AddUp(Card card) {
        up[upSize++] = card;
        size++;
    }
    
    void Pile::Flip() {
        if (upSize > 0) {
            down[downSize++] = up[--upSize];
        } else {
            up[upSize++] = down[--downSize];
        }
    }
    
    void Pile::Remove(Pile & to) {
        to.AddUp(up[--upSize]);
        size--;
    }
    
    void Pile::Remove(Pile & to, int count) {
        for (int i = upSize - count; i < upSize; ++i) {
            to.AddUp(up[i]);
        }
        
        upSize -= count;
        size -= count;
    }
    
    void Pile::RemoveTalon(Pile & to, int count) {
        int i = size - count;
        do {
            to.AddUp(up[--size]);
        } while (size > i);
        
        upSize = size;
    }
    
    void Pile::Reset() {
        size = 0;
        upSize = 0;
        downSize = 0;
    }
    
    void Pile::Initialize() {
        size = 0;
        upSize = 0;
        downSize = 0;
        for (int i = 0; i < 24; i++) {
            up[i].Clear();
            down[i].Clear();
        }
    }
    
    int Pile::Size() {
        return size;
    }
    
    int Pile::DownSize() {
        return downSize;
    }
    
    int Pile::UpSize() {
        return upSize;
    }
    
    Card Pile::operator[](int index) {
        return up[index];
    }
    
    Card Pile::Down(int index) {
        return down[index];
    }
    
    Card Pile::Up(int index) {
        return up[index];
    }
    
    Card Pile::Low() {
        return up[upSize - 1];
    }
    
    Card Pile::High() {
        return up[0];
    }
    
    int Pile::HighValue() {
        return upSize > 0 ? up[0].Value : 99;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert Pile ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Pile::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t size
            ret+= sizeof(int32_t);
            
            // int32_t downSize
            ret+= sizeof(int32_t);
            // Card down[24]
            if(downSize>=0 && downSize<=24){
                ret+= downSize*Card::getByteSize();
            }else{
                printf("error, downSize error: %d\n", downSize);
            }
            
            // int32_t upSize
            ret+= sizeof(upSize);
            // Card up[24]
            if(upSize>=0 && upSize<=24){
                ret+= upSize*Card::getByteSize();
            }else{
                printf("error, upSize error: %d\n", upSize);
            }
        }
        return ret;
    }
    
    int32_t Pile::convertToByteArray(Pile* pile, uint8_t* &byteArray)
    {
        int32_t length = pile->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // int32_t size
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &pile->size, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: size: %d, %d\n", pointerIndex, length);
                }
            }
            
            // int32_t downSize
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &pile->downSize, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: downSize: %d, %d\n", pointerIndex, length);
                }
            }
            // Card down[24]
            {
                if(pile->downSize>=0 && pile->downSize<=24){
                    for(int32_t i=0; i<pile->downSize; i++){
                        uint8_t* cardByteArray;
                        int32_t size = Card::convertToByteArray (&pile->down[i], cardByteArray);
                        if(pointerIndex+size<=length){
                            memcpy(ret + pointerIndex, cardByteArray, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: down: %d, %d\n", pointerIndex, length);
                        }
                        free(cardByteArray);
                    }
                }else{
                    printf("error, downSize: %d\n", pile->downSize);
                }
            }
            
            // int32_t upSize
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &pile->upSize, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: upSize: %d, %d\n", pointerIndex, length);
                }
            }
            // Card up[24]
            {
                if(pile->upSize>=0 && pile->upSize<=24){
                    for(int32_t i=0; i<pile->upSize; i++){
                        uint8_t* cardByteArray;
                        int32_t size = Card::convertToByteArray (&pile->up[i], cardByteArray);
                        if(pointerIndex+size<=length){
                            memcpy(ret + pointerIndex, cardByteArray, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: up: %d, %d\n", pointerIndex, length);
                        }
                        free(cardByteArray);
                    }
                }else{
                    printf("error, upSize: %d\n", pile->upSize);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Pile::parseByteArray(Pile* pile, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&pile->size, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                    
                case 1:
                {
                    // int32_t downSize
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&pile->downSize, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: downSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // Card down[24]
                {
                    if(pile->downSize>=0 && pile->downSize<=24){
                        for (int32_t i = 0; i < pile->downSize; i++) {
                            int32_t downByteLength = Card::parseByteArray (&pile->down[i], bytes, length, pointerIndex, canCorrect);
                            if (downByteLength > 0) {
                                pointerIndex+= downByteLength;
                            } else {
                                printf("cannot parse\n");
                                break;
                            }
                        }
                    }else{
                        printf("error, pile downSize: %d\n", pile->downSize);
                    }
                }
                    break;
                    
                case 3:
                    // int32_t upSize
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&pile->upSize, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: downSize: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // Card up[24]
                {
                    if(pile->upSize>=0 && pile->upSize<=24){
                        for (int32_t i = 0; i < pile->upSize; i++) {
                            int32_t upByteLength = Card::parseByteArray (&pile->up[i], bytes, length, pointerIndex, canCorrect);
                            if (upByteLength > 0) {
                                pointerIndex+= upByteLength;
                            } else {
                                printf("cannot parse\n");
                                break;
                            }
                        }
                    }else{
                        printf("error, pile upSize: %d\n", pile->upSize);
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
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
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            
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
    
}
