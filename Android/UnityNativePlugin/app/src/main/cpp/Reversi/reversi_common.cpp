#include <iostream>
#include "reversi_common.hpp"
#include "reversi_board.hpp"

namespace Reversi
{
    void swap(MoveList &moves, MoveList &scores, int32_t i, int32_t j);
    int32_t partition(MoveList &moves, MoveList &scores, int32_t left, int32_t right,
                  int32_t pindex);
    
    // For bitscan
    const int32_t index64[64] = {
        0, 47,  1, 56, 48, 27,  2, 60,
        57, 49, 41, 37, 28, 16,  3, 61,
        54, 58, 35, 52, 50, 42, 21, 44,
        38, 32, 29, 23, 17, 11,  4, 62,
        46, 55, 26, 59, 40, 36, 15, 53,
        34, 51, 20, 43, 31, 22, 10, 45,
        25, 39, 14, 33, 19, 30,  9, 24,
        13, 18,  8, 12,  7,  6,  5, 63
    };

    int32_t countSetBits(bitbrd i) {
        /*
         #if defined(__x86_64__)
         asm ("popcnt %1, %0" : "=r" (i) : "r" (i));
         return (int) i;
         #elif defined(__i386)
         int a = (int) (i & 0xFFFFFFFF);
         int b = (int) (i >> 32);
         asm ("popcntl %1, %0" : "=r" (a) : "r" (a));
         asm ("popcntl %1, %0" : "=r" (b) : "r" (b));
         return a+b;
         #else
         */
        i = i - ((i >> 1) & 0x5555555555555555);
        i = (i & 0x3333333333333333) + ((i >> 2) & 0x3333333333333333);
        i = (((i + (i >> 4)) & 0x0F0F0F0F0F0F0F0F) *
             0x0101010101010101) >> 56;
        return (int32_t) i;
        //#endif
    }
    
    // BitScan forward and reverse algorithms from
    // https://chessprogramming.wikispaces.com/BitScan
    int32_t bitScanForward(bitbrd bb) {
#if defined(__x86_64__)
        asm ("bsf %1, %0" : "=r" (bb) : "r" (bb));
        return (int32_t) bb;
#else
        return index64[(int32_t)(((bb ^ (bb-1)) * 0x03f79d71b4cb0a89) >> 58)];
#endif
    }

    int32_t bitScanReverse(bitbrd bb) {
#if defined(__x86_64__)
        asm ("bsr %1, %0" : "=r" (bb) : "r" (bb));
        return (int32_t) bb;
#elif defined(__i386)
        int32_t b = (int32_t) (bb >> 32);
        if(b) {
            asm ("bsrl %1, %0" : "=r" (b) : "r" (b));
            return b+32;
        }
        else {
            int32_t a = (int32_t) (bb & 0xFFFFFFFF);
            asm ("bsrl %1, %0" : "=r" (a) : "r" (a));
            return a;
        }
#else
        bb |= bb >> 1;
        bb |= bb >> 2;
        bb |= bb >> 4;
        bb |= bb >> 8;
        bb |= bb >> 16;
        bb |= bb >> 32;
        return index64[(int32_t)((bb * 0x03f79d71b4cb0a89) >> 58)];
#endif
    }
    
    // Reflection algorithms from
    // https://chessprogramming.wikispaces.com/Flipping+Mirroring+and+Rotating
    bitbrd reflectVertical(bitbrd i) {
#if defined(__x86_64__)
        asm ("bswap %0" : "=r" (i) : "0" (i));
        return i;
#else
        const bitbrd k1 = 0x00FF00FF00FF00FF;
        const bitbrd k2 = 0x0000FFFF0000FFFF;
        i = ((i >>  8) & k1) | ((i & k1) <<  8);
        i = ((i >> 16) & k2) | ((i & k2) << 16);
        i = ( i >> 32)       | ( i       << 32);
        return i;
#endif
    }
    
    bitbrd reflectHorizontal(bitbrd x) {
        const bitbrd k1 = 0x5555555555555555;
        const bitbrd k2 = 0x3333333333333333;
        const bitbrd k4 = 0x0f0f0f0f0f0f0f0f;
        x = ((x >> 1) & k1) | ((x & k1) << 1);
        x = ((x >> 2) & k2) | ((x & k2) << 2);
        x = ((x >> 4) & k4) | ((x & k4) << 4);
        return x;
    }
    
    bitbrd reflectDiag(bitbrd x) {
        bitbrd t;
        const bitbrd k1 = 0x5500550055005500;
        const bitbrd k2 = 0x3333000033330000;
        const bitbrd k4 = 0x0f0f0f0f00000000;
        t  = k4 & (x ^ (x << 28));
        x ^=       t ^ (t >> 28) ;
        t  = k2 & (x ^ (x << 14));
        x ^=       t ^ (t >> 14) ;
        t  = k1 & (x ^ (x <<  7));
        x ^=       t ^ (t >>  7) ;
        return x;
    }
    
    // Given a std::chrono time_point, this function returns the number of seconds
    // elapsed since then.
    double getTimeElapsed(OthelloTime startTime) {
        auto endTime = OthelloClock::now();
        std::chrono::duration<double> timeSpan =
        std::chrono::duration_cast<std::chrono::duration<double>>(
                                                                  endTime-startTime);
        return timeSpan.count() + 0.001;
    }
    
    // Pretty prints a move in (x, y) form indexed from 1.
    void printMove(int32_t move) {
        printf("%c%d", (char) ('a' + (move & 7)), (move >> 3) + 1);
    }
    
    // Retrieves the next move with the highest score, starting from index using a
    // partial selection sort. This way, the entire list does not have to be sorted
    // if an early cutoff occurs.
    int32_t nextMove(MoveList &moves, MoveList &scores, uint32_t index) {
        if (index >= moves.size)
            return MOVE_NULL;
        // Find the index of the next best move/score
        int32_t bestIndex = index;
        for (uint32_t i = index + 1; i < moves.size; i++) {
            if (scores.get(i) > scores.get(bestIndex))
                bestIndex = i;
        }
        // swap to the correct position
        moves.swap(bestIndex, index);
        scores.swap(bestIndex, index);
        // return the move
        return moves.get(index);
    }
    
    // A standard in-place quicksort that sorts moves according to scores.
    void sort(MoveList &moves, MoveList &scores, int32_t left, int32_t right) {
        int32_t pivot = (left + right) / 2;
        
        if (left < right) {
            pivot = partition(moves, scores, left, right, pivot);
            sort(moves, scores, left, pivot-1);
            sort(moves, scores, pivot+1, right);
        }
    }
    
    void swap(MoveList &moves, MoveList &scores, int32_t i, int32_t j) {
        int32_t less1 = moves.get(j);
        moves.set(j, moves.get(i));
        moves.set(i, less1);

        int32_t less2 = scores.get(j);
        scores.set(j, scores.get(i));
        scores.set(i, less2);
    }

    int32_t partition(MoveList &moves, MoveList &scores, int32_t left, int32_t right,
                      int32_t pindex) {

        int32_t index = left;
        int32_t pivot = scores.get(pindex);
        
        swap(moves, scores, pindex, right);
        
        for (int32_t i = left; i < right; i++) {
            if (scores.get(i) > pivot) {
                swap(moves, scores, i, index);
                index++;
            }
        }
        swap(moves, scores, index, right);
        
        return index;
    }
    
    bitbrd rotateBitboard(bitbrd value, RotateType rotateType)
    {
        bitbrd ret = 0;
        {
            int8_t bits[64];
            {
                for(int32_t y=0; y<8; y++){
                    for(int32_t x=0; x<8; x++){
                        int32_t i = x+8*y;
                        // get bit
                        int32_t bit = (value>>i)%2;
                        bits[i] = bit;
                        // printf("%d", bit);
                    }
                    // printf("\n");
                }
                // printf("\n");
            }
            // set ret
            {
                for(int32_t y=7; y>=0; y--){
                    for(int32_t x=7; x>=0; x--){
                        // get bit
                        int32_t bit = 0;
                        {
                            switch (rotateType) {
                                case A1H8:
                                {
                                    bit = bits[8*x+y];
                                }
                                    break;
                                case H1A8:
                                {
                                    bit = bits[8*(7-x)+(7-y)];
                                }
                                    break;
                                case FULL:
                                {
                                    bit = bits[8*(7-y)+(7-x)];
                                }
                                    break;
                                default:
                                    printf("error, unknown rotateType: %d\n", rotateType);
                                    break;
                            }
                        }
                        // set ret
                        ret = 2*ret + bit;
                        // printf("%d", bit);
                    }
                    // printf("\n");
                }
                // printf("\n");
            }
        }
        return ret;
    }
    
    int8_t rotateMove(int8_t move, RotateType rotateType)
    {
        int8_t x = move%8;
        int8_t y = move/8 ;
        switch (rotateType) {
            case A1H8:
            {
                // d3 c4 -90
                int8_t newX = y;
                int8_t newY = x;
                return newX+8*newY;
            }
            case H1A8:
            {
                // d3 f5 90
                int8_t newX = 7-y;
                int8_t newY = 7-x;
                return newX+8*newY;
            }
            case FULL:
            {
                // d3 e6
                int8_t newX = 7-x;
                int8_t newY = 7-y;
                return newX+8*newY;
            }
            default:
            {
                printf("error, unknown rotate type: %d\n", rotateType);
            }
                break;
        }
        return MOVE_NULL;
    }
}
