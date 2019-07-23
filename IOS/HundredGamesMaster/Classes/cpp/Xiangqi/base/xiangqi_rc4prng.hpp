#include "xiangqi_base.hpp"
#include "xiangqi_x86asm.hpp"
#include "../../Platform.h"

#ifndef XIANGQI_RC4PRNG_H
#define XIANGQI_RC4PRNG_H

namespace Xiangqi
{

    struct RC4Struct {
        uint8_t s[256];
        int32_t x, y;

        void Init(void *lpKey, int32_t nKeyLen) {
            int32_t i, j;
            x = y = j = 0;
            for (i = 0; i < 256; i ++) {
                s[i] = i;
            }
            for (i = 0; i < 256; i ++) {
                j = (j + s[i] + ((uint8_t *) lpKey)[i % nKeyLen]) & 255;
                SWAP(s[i], s[j]);
            }
        }

        void InitZero(void) {
            uint32_t dwKey;
            dwKey = 0;
            Init(&dwKey, 4);
        }

        void InitRand(void) {
            union {
                uint32_t dw[2];
                uint64_t qw;
            } Seed;
            Seed.qw = 0;
            Seed.dw[1] ^= (uint32_t) now();
            Init(&Seed, 8);
        }

        uint8_t NextByte(void) {
            x = (x + 1) & 255;
            y = (y + s[x]) & 255;
            SWAP(s[x], s[y]);
            return s[(s[x] + s[y]) & 255];
        }

        uint32_t NextLong(void) {
            union {
                uint8_t uc[4];
                uint32_t dw;
            } Ret;
            Ret.uc[0] = NextByte();
            Ret.uc[1] = NextByte();
            Ret.uc[2] = NextByte();
            Ret.uc[3] = NextByte();
            return Ret.dw;
        }
    };
    
}

#endif
