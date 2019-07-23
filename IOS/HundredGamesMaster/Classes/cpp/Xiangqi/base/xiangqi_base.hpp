#include <assert.h>
// #include <chrono>

/*#include "../../Platform.h"
#ifndef Android
#include <sys/timeb.h>
#else
#include <time.h>
#endif*/

#ifndef XIANGQI_BASE_H
#define XIANGQI_BASE_H

namespace Xiangqi
{
    
#ifdef _MSC_VER
    typedef signed   __int64  int64_t; // ll
    typedef unsigned __int64 uint64_t; // qw
    typedef signed   __int32  int32_t; // l
    typedef unsigned __int32 uint32_t; // dw
    typedef signed   __int16  int16_t; // s
    typedef unsigned __int16 uint16_t; // w
    typedef signed   __int8   int8_t;  // c
    typedef unsigned __int8  uint8_t;  // uc
#define FORMAT_I64 "I64"
#else
#include <stdint.h>
#define FORMAT_I64 "ll"
#endif
    
#define __IF_BOUND(a, b, c) ((a) <= (b) && (b) <= (c))
    
#define __ASSERT(a) assert(a)
#define __ASSERT_BOUND(a, b, c) assert((a) <= (b) && (b) <= (c))
    
#define __ASSERT_BOUND_2(a, b, c, d) assert((a) <= (b) && (b) <= (c) && (c) <= (d))
#define IF_BOUND_2(a, b, c, d) ((a) <= (b) && (b) <= (c) && (c) <= (d))
    
    inline bool EQV(bool bArg1, bool bArg2) {
        return bArg1 ? bArg2 : !bArg2;
    }
    
    inline bool XOR(bool bArg1, bool bArg2) {
        return bArg1 ? !bArg2 : bArg2;
    }
    
    template <typename T> inline T MIN(T Arg1, T Arg2) {
        return Arg1 < Arg2 ? Arg1 : Arg2;
    }
    
    template <typename T> inline T MAX(T Arg1, T Arg2) {
        return Arg1 > Arg2 ? Arg1 : Arg2;
    }
    
    template <typename T> inline T ABS(T Arg) {
        return Arg < 0 ? -Arg : Arg;
    }
    
    template <typename T> inline T SQR(T Arg) {
        return Arg * Arg;
    }
    
    template <typename T> inline void SWAP(T &Arg1, T &Arg2) {
        T Temp;
        Temp = Arg1;
        Arg1 = Arg2;
        Arg2 = Temp;
    }
    
    inline int32_t PopCnt8(uint8_t uc) {
        int32_t n;
        n = ((uc >> 1) & 0x55) + (uc & 0x55);
        n = ((n >> 2) & 0x33) + (n & 0x33);
        return (n >> 4) + (n & 0x0f);
    }
    
    inline int32_t PopCnt16(uint16_t w) {
        int32_t n;
        n = ((w >> 1) & 0x5555) + (w & 0x5555);
        n = ((n >> 2) & 0x3333) + (n & 0x3333);
        n = ((n >> 4) & 0x0f0f) + (n & 0x0f0f);
        return (n >> 8) + (n & 0x00ff);
    }
    
    inline int32_t PopCnt32(uint32_t dw) {
        int32_t n;
        n = ((dw >> 1) & 0x55555555) + (dw & 0x55555555);
        n = ((n >> 2) & 0x33333333) + (n & 0x33333333);
        n = ((n >> 4) & 0x0f0f0f0f) + (n & 0x0f0f0f0f);
        n = ((n >> 8) & 0x00ff00ff) + (n & 0x00ff00ff);
        return (n >> 16) + (n & 0x0000ffff);
    }
    
}

#endif
