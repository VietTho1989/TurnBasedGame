#pragma once

#include "chinese_checkers_hole.hpp"

namespace ChineseCheckers
{

    struct Move {
        Hole from;
        Hole to;
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
    public:
        static int32_t getByteSize()
        {
            return 4*sizeof(int32_t);
        }
        
        static int32_t convertToByteArray(Move* move, uint8_t* &byteArray)
        {
            int32_t length = Move::getByteSize();
            uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // fromX
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->from.x, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: fromX %d, %d\n", pointerIndex, length);
                    }
                }
                // fromY
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->from.y, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: fromY %d, %d\n", pointerIndex, length);
                    }
                }
                // toX
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->to.x, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: toX %d, %d\n", pointerIndex, length);
                    }
                }
                // toY
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &move->to.y, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: toY %d, %d\n", pointerIndex, length);
                    }
                }
                // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
            }
            byteArray = ret;
            return length;
        }
        
        static int32_t parseByteArray(Move* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                    {
                        // fromX
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->from.x, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: fromX %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                    {
                        // fromY
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->from.y, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: fromY %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                    {
                        // toX
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->to.x, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: toX %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                    {
                        // toY
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&move->to.y, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: toY %d, %d\n", pointerIndex, length);
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
        
    };

    inline bool operator==(const Move &a, const Move &b) {
        return a.from == b.from and a.to == b.to;
    }
    
    inline bool operator!= (const Move& a, const Move& b) {
        return !(a == b);
    }
    
    inline std::ostream& operator<<(std::ostream &strm, const Move &m) {
        return strm << m.from << m.to;
    }

    namespace Moves {

        constexpr Move NO_MOVE = {{0, 0}, {0, 0}};

    }

}
