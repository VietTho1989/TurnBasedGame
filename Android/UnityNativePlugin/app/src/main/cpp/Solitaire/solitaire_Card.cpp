#include "solitaire_Card.hpp"
#include <stdio.h>
#include <cstdlib>
#include <cstring>

namespace Solitaire
{
    
    void Card::Clear() {
        Rank = EMPTY;
        Suit = NONE;
    }
    
    void Card::Set(unsigned char value) {
        Value = value;
        Rank = (value % 13) + 1;
        Suit = value / 13;
        IsRed = Suit & 1;
        IsOdd = Rank & 1;
        Foundation = Suit + 9;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert Card ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Card::getByteSize()
    {
        int32_t ret = 0;
        {
            ret+= 6*sizeof(unsigned char);
        }
        return ret;
    }
    
    int32_t Card::convertToByteArray(Card* card, uint8_t* &byteArray)
    {
        int32_t length = Card::getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // Suit
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->Suit, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Suit: %d, %d\n", pointerIndex, length);
                }
            }
            // Rank
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->Rank, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Rank: %d, %d\n", pointerIndex, length);
                }
            }
            // IsOdd
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->IsOdd, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: IsOdd: %d, %d\n", pointerIndex, length);
                }
            }
            // IsRed
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->IsRed, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: IsRed: %d, %d\n", pointerIndex, length);
                }
            }
            // Foundation
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->Foundation, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Foundation: %d, %d\n", pointerIndex, length);
                }
            }
            // Value
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &card->Value, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Value: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Card::parseByteArray(Card* card, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // Suit
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->Suit, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Suit: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // Rank
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->Rank, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Rank: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // IsOdd
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->IsOdd, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: IsOdd: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                {
                    // IsRed
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->IsRed, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: IsRed: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                {
                    // Foundation
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->Foundation, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Foundation: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                {
                    // Value
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&card->Value, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Vakye: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
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
