#include "xiangqi_base.hpp"

#ifndef XIANGQI_X86ASM_H
#define XIANGQI_X86ASM_H

namespace Xiangqi
{
    inline uint32_t LOW_LONG(uint64_t Operand) {
        return (uint32_t) Operand;
    }

    inline uint32_t HIGH_LONG(uint64_t Operand) {
        return (uint32_t) (Operand >> 32);
    }

    inline uint64_t MAKE_LONG_LONG(uint32_t LowLong, uint32_t HighLong) {
        return (uint64_t) LowLong | ((uint64_t) HighLong << 32);
    }
    
#ifdef _MSC_VER

    /*__forceinline int Bsf(uint32_t Operand) {
        __asm {
            bsf eax, Operand;
        }
    }*/
    inline int32_t Bsf(uint32_t Operand) {
        int m;
        
        for (m = 0; m < 32; m++)
        {
            if (Operand & (1 << m))
                return m;
        }
        
        return 32;
    }
    
#else
    
    inline int32_t Bsf(uint32_t Operand) {
        uint32_t dw = Operand & -Operand;
        return
                ((dw & 0xFFFF0000) != 0 ? 16 : 0) +
                ((dw & 0xFF00FF00) != 0 ? 8 : 0) +
                ((dw & 0xF0F0F0F0) != 0 ? 4 : 0) +
                ((dw & 0xCCCCCCCC) != 0 ? 2 : 0) +
                ((dw & 0xAAAAAAAA) != 0 ? 1 : 0);
    }
    
#endif

    inline int32_t Bsr(uint32_t Operand) {
        uint32_t dw = Operand;
        int32_t n = 0;
        if ((dw & 0xFFFF0000) != 0) {
            dw &= 0xFFFF0000;
            n += 16;
        }
        if ((dw & 0xFF00FF00) != 0) {
            dw &= 0xFF00FF00;
            n += 8;
        }
        if ((dw & 0xF0F0F0F0) != 0) {
            dw &= 0xF0F0F0F0;
            n += 4;
        }
        if ((dw & 0xCCCCCCCC) != 0) {
            dw &= 0xCCCCCCCC;
            n += 2;
        }
        if ((dw & 0xAAAAAAAA) != 0) {
            dw &= 0xAAAAAAAA;
            n ++;
        }
        return n;
    }
}

#endif
