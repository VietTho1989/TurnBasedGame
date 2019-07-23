#ifndef __reversi_COMMON_H__
#define __reversi_COMMON_H__

#include <cstdint>
#include <cstdlib>
#include <chrono>

namespace Reversi
{
#define PRINT_SEARCH_INFO true
    
    typedef uint64_t bitbrd;
    typedef std::chrono::high_resolution_clock OthelloClock;
    typedef std::chrono::high_resolution_clock::time_point OthelloTime;
    
    const int32_t INFTY = (1 << 30);
    const int32_t WIPEOUT = (1 << 28);
    const int32_t MOVE_NULL = 64;
    const int32_t MOVE_BROKEN = -2;
    const int32_t OPENING_NOT_FOUND = -3;
    const int32_t CBLACK = 1;
    const int32_t CWHITE = 0;
    const uint8_t PV_NODE = 0;
    const uint8_t CUT_NODE = 1;
    const uint8_t ALL_NODE = 2;
    
    // Bitboard functions
    int32_t countSetBits(bitbrd i);
    int32_t bitScanForward(bitbrd bb);
    int32_t bitScanReverse(bitbrd bb);
    bitbrd reflectVertical(bitbrd i);
    bitbrd reflectHorizontal(bitbrd x);
    bitbrd reflectDiag(bitbrd x);
    
    // Utility functions
    double getTimeElapsed(OthelloTime startTime);
    void printMove(int32_t move);
    
    enum Side {
        WHITE, BLACK
    };
    
    class Move {
        
    public:
        int32_t x, y;
        Move(int32_t x, int32_t y) {
            this->x = x;
            this->y = y;
        }
        ~Move() {}

        int32_t getX() { return x; }
        int32_t getY() { return y; }
        
        void setX(int32_t x) { this->x = x; }
        void setY(int32_t y) { this->y = y; }
    };
    
    class MoveList {
    public:
        int32_t moves[32];
        uint32_t size;
        
        MoveList() {
            size = 0;
        }
        ~MoveList() {}
        
        void add(int32_t m) {
            moves[size] = m;
            size++;
        }

        int32_t get(int32_t i) { return moves[i]; }
        int32_t last() { return moves[size-1]; }
        void set(int32_t i, int32_t val) { moves[i] = val; }
        
        void swap(int32_t i, int32_t j) {
            int32_t temp = moves[i];
            moves[i] = moves[j];
            moves[j] = temp;
        }
        
        void clear() {
            size = 0;
        }
    };

    int32_t nextMove(MoveList &moves, MoveList &scores, uint32_t index);
    void sort(MoveList &moves, MoveList &scores, int32_t left, int32_t right);
    
    enum RotateType
    {
        A1H8 = 0,
        H1A8 = 1,
        FULL = 2,
        ROTATE_NUM = 3
    };
    
    bitbrd rotateBitboard(bitbrd value, RotateType rotateType);
    
    int8_t rotateMove(int8_t move, RotateType rotateType);
}

#endif
