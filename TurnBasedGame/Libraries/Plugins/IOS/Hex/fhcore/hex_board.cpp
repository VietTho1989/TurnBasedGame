#include <map>
#include <list>
#include <algorithm>
#include <cassert>
#include <cmath>
#include <iomanip>
#include <sstream>
#include <typeinfo>
#include "hex_board.hpp"

namespace Hex
{
    using namespace std;
    
    namespace board
    {
        
#define REGISTER_CREATE_BY_SIZE(container, size) do { \
container[size] = BoardT<size>::create; \
} while (0)
        
        typedef IBoard *(*PF_CREATE)(void);
        static map<coord_t, PF_CREATE> s2t;
        
        static struct initializer
        {
            initializer();
            ~initializer() {};
        } dummy;
        
        initializer::initializer()
        {
            REGISTER_CREATE_BY_SIZE(s2t, 4);
            REGISTER_CREATE_BY_SIZE(s2t, 5);
            REGISTER_CREATE_BY_SIZE(s2t, 6);
            REGISTER_CREATE_BY_SIZE(s2t, 7);
            REGISTER_CREATE_BY_SIZE(s2t, 8);
            REGISTER_CREATE_BY_SIZE(s2t, 9);
            REGISTER_CREATE_BY_SIZE(s2t, 10);
            REGISTER_CREATE_BY_SIZE(s2t, 11);
            REGISTER_CREATE_BY_SIZE(s2t, 12);
            REGISTER_CREATE_BY_SIZE(s2t, 13);
            REGISTER_CREATE_BY_SIZE(s2t, 14);
            REGISTER_CREATE_BY_SIZE(s2t, 15);
            REGISTER_CREATE_BY_SIZE(s2t, 16);
            REGISTER_CREATE_BY_SIZE(s2t, 17);
            REGISTER_CREATE_BY_SIZE(s2t, 18);
            REGISTER_CREATE_BY_SIZE(s2t, 19);
            REGISTER_CREATE_BY_SIZE(s2t, 20);
            REGISTER_CREATE_BY_SIZE(s2t, 21);
            REGISTER_CREATE_BY_SIZE(s2t, 22);
            REGISTER_CREATE_BY_SIZE(s2t, 23);
            REGISTER_CREATE_BY_SIZE(s2t, 24);
            REGISTER_CREATE_BY_SIZE(s2t, 25);
            REGISTER_CREATE_BY_SIZE(s2t, 26);
            REGISTER_CREATE_BY_SIZE(s2t, 27);
            REGISTER_CREATE_BY_SIZE(s2t, 28);
            REGISTER_CREATE_BY_SIZE(s2t, 29);
            REGISTER_CREATE_BY_SIZE(s2t, 30);
            REGISTER_CREATE_BY_SIZE(s2t, 31);
            REGISTER_CREATE_BY_SIZE(s2t, 32);
            REGISTER_CREATE_BY_SIZE(s2t, 33);
            REGISTER_CREATE_BY_SIZE(s2t, 34);
            REGISTER_CREATE_BY_SIZE(s2t, 35);
            REGISTER_CREATE_BY_SIZE(s2t, 36);
            REGISTER_CREATE_BY_SIZE(s2t, 37);
            REGISTER_CREATE_BY_SIZE(s2t, 38);
            REGISTER_CREATE_BY_SIZE(s2t, 39);
            REGISTER_CREATE_BY_SIZE(s2t, 40);
            REGISTER_CREATE_BY_SIZE(s2t, 41);
            REGISTER_CREATE_BY_SIZE(s2t, 42);
            REGISTER_CREATE_BY_SIZE(s2t, 43);
            REGISTER_CREATE_BY_SIZE(s2t, 44);
            REGISTER_CREATE_BY_SIZE(s2t, 45);
            REGISTER_CREATE_BY_SIZE(s2t, 46);
            REGISTER_CREATE_BY_SIZE(s2t, 47);
            REGISTER_CREATE_BY_SIZE(s2t, 48);
            REGISTER_CREATE_BY_SIZE(s2t, 49);
            REGISTER_CREATE_BY_SIZE(s2t, 50);
            
            // REGISTER_CREATE_BY_SIZE(s2t, MAX_BOARD_SIZE);
        }
        
        IBoard * IBoard::create(const coord_t size)
        {
            auto iter = s2t.find(size);
            if (s2t.end() != iter)
            {
                auto func = iter->second;
                return func();
            }
            return nullptr;
        }
        
        IBoard * IBoard::create(const string & name)
        {
            return nullptr;
        }
        
        bool IBoard::operator==(const IBoard & rhs) const
        {
            // assert(boardsize() == rhs.boardsize());
            if(boardsize() != rhs.boardsize()){
                printf("error, assert(boardsize() == rhs.boardsize())\n");
                return false;
            }
            return equal_to(rhs);
        }
        
        bool IBoard::operator!=(const IBoard & rhs) const
        {
            // assert(boardsize() == rhs.boardsize());
            if(boardsize() != rhs.boardsize()){
                printf("error, assert(boardsize() == rhs.boardsize())\n");
                return false;
            }
            return !equal_to(rhs);
        }
        
        void print(IBoard* pBoard, char* ret)
        {
            ret[0] = 0;
            sprintf(ret, "%s     ", ret);
            coord_t size = pBoard->boardsize();
            for(int32_t i=0; i<size; i++) {
                sprintf(ret, "%s%-3d ", ret, i);
            }
            sprintf(ret, "%s\n     ", ret);
            for(int32_t i=0; i<size; i++) {
                sprintf(ret, "%sR   ", ret);
            }
            sprintf(ret, "%s\n", ret);
            for(int32_t i=0; i<size; i++)
            {
                for(int32_t j=0; j<i; j++) {
                    sprintf(ret, "%s  ", ret);
                }
                sprintf(ret, "%s%2d B", ret, i);
                for(int32_t j=0; j<size; j++) {
                    sprintf(ret, "%s ", ret);
                    switch((*pBoard)(i, j))
                    {
                        case color::Color::Empty:
                        {
                            sprintf(ret, "%s.", ret);
                        }
                            break;
                        case color::Color::Blue:
                        {
                            sprintf(ret, "%sb", ret);
                        }
                            break;
                        case color::Color::Red:
                        {
                            sprintf(ret, "%sr", ret);
                        }
                            break;
                    }
                    sprintf(ret, "%s  ", ret);
                }
                sprintf(ret, "%sB", ret);
                sprintf(ret, "%s %d", ret, i);
                sprintf(ret, "%s\n", ret);
            }
            
            for(int32_t i=0; i<size-1; i++) {
                sprintf(ret, "%s  ", ret);
            }
            sprintf(ret, "%s     ", ret);
            for(int32_t i=0; i<size; i++) {
                sprintf(ret, "%sR   ", ret);
            }
            sprintf(ret, "%s\n", ret);
            for(int32_t i=0; i<size-1; i++) {
                sprintf(ret, "%s  ", ret);
            }
            sprintf(ret, "%s     ", ret);
            for(int32_t i=0; i<size; i++) {
                sprintf(ret, "%s%-3d ", ret, i);
            }
            sprintf(ret, "%s\n", ret);
        }
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert Board ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t IBoard::getByteSize()
        {
            int32_t ret = 0;
            {
                // size
                ret+=sizeof(coord_t);
                // board
                ret+=this->boardsize()*this->boardsize()*sizeof(int8_t);
            }
            return ret;
        }
        
        int32_t IBoard::convertToByteArray(IBoard* position, uint8_t* &byteArray)
        {
            int32_t length = position->getByteSize();
            uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // boardSize
                {
                    int32_t size = sizeof(coord_t);
                    if(pointerIndex+size<=length){
                        coord_t boardSize = position->boardsize();
                        memcpy(ret + pointerIndex, &boardSize, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                    }
                }
                // board
                {
                    coord_t boardSize = position->boardsize();
                    int32_t size = sizeof(int8_t);
                    for(int32_t i=0; i<boardSize; i++) {
                        for(int32_t j=0; j<boardSize; j++) {
                            if(pointerIndex+size<=length){
                                color::Color myColor = (*position)(i, j);// y, x
                                int8_t color = (int8_t)myColor;
                                memcpy(ret + pointerIndex, &color, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: board: %d, %d\n", pointerIndex, length);
                            }
                        }
                    }
                }
                // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
            }
            byteArray = ret;
            return length;
        }
        
        int32_t IBoard::parseByteArray(IBoard* &position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // board
                    {
                        coord_t boardSize = 11;
                        {
                            int32_t size = sizeof(coord_t);
                            if(pointerIndex+size<=length){
                                memcpy(&boardSize, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: boardSize: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        // correct boardSize
                        {
                            if(boardSize<4){
                                boardSize = 4;
                            }
                            if(boardSize>=MAX_BOARD_SIZE){
                                boardSize = MAX_BOARD_SIZE;
                            }
                        }
                        // Make pos
                        {
                            position = IBoard::create(boardSize);
                            position->reset();
                        }
                    }
                        break;
                    case 1:
                    {
                        // board
                        coord_t boardSize = position->boardsize();
                        int32_t size = sizeof(int8_t);
                        for(int32_t i=0; i<boardSize; i++) {
                            for(int32_t j=0; j<boardSize; j++) {
                                if(pointerIndex+size<=length){
                                    int8_t color;
                                    memcpy(&color, bytes + pointerIndex, size);
                                    pointerIndex+=size;
                                    // set
                                    (*position)(i, j) = (color::Color)color;
                                }else{
                                    printf("length error: board: %d, %d\n", pointerIndex, length);
                                }
                            }
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
}
