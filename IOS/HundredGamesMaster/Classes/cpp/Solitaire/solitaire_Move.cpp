#include "solitaire_Move.hpp"
#include <cstdlib>

namespace Solitaire
{
    
    Move::Move() {}
    
    Move::Move(unsigned char from, unsigned char to, unsigned char count, unsigned char extra) {
        From = from; To = to; Count = count; Extra = extra;
    }
    
    void Move::Set(unsigned char from, unsigned char to, unsigned char count, unsigned char extra) {
        From = from; To = to; Count = count; Extra = extra;
    }
    
    MoveNode::MoveNode(Move move) {
        Value = move;
        Parent = NULL;
    }
    
    MoveNode::MoveNode(Move move, shared_ptr<MoveNode> const& parent) {
        Value = move;
        Parent = parent;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert Move ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Move::getByteSize()
    {
        int32_t ret = 0;
        {
            ret+= 4*sizeof(unsigned char);
        }
        return ret;
    }
    
    int32_t Move::convertToByteArray(Move* move, uint8_t* &byteArray)
    {
        int32_t length = Move::getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // From
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &move->From, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: From: %d, %d\n", pointerIndex, length);
                }
            }
            // To
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &move->To, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: To: %d, %d\n", pointerIndex, length);
                }
            }
            // Count
            {
                int32_t size = sizeof(unsigned char);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &move->Count, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: Count: %d, %d\n", pointerIndex, length);
                }
            }
            // Extra
            int32_t size = sizeof(unsigned char);
            if(pointerIndex+size<=length){
                memcpy(ret + pointerIndex, &move->Extra, size);
                pointerIndex+=size;
            }else{
                printf("length error: Extra: %d, %d\n", pointerIndex, length);
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Move::parseByteArray(Move* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // From
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&move->From, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: From: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // To
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&move->To, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: To: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // Count
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&move->Count, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Count: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                {
                    // Extra
                    int32_t size = sizeof(unsigned char);
                    if(pointerIndex+size<=length){
                        memcpy(&move->Extra, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: Extra: %d, %d\n", pointerIndex, length);
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
            if(move->Count>24){
                printf("error, why move count too large: %d\n", move->Count);
                // move->Count = 0;
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
    
}
