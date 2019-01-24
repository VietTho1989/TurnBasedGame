/*
 *  x86asm.cpp
 *  CoolChix
 *
 *  Created by minhbkait on 8/22/08.
 *  Copyright 2008 bm. All rights reserved.
 *
 */

#include "xiangqi_x86asm.hpp"

//inline uint32_t LOW_LONG(uint64_t Operand) {
//    return (uint32_t) Operand;
//}
//
//inline uint32_t HIGH_LONG(uint64_t Operand) {
//    return (uint32_t) (Operand >> 32);
//}
//
//inline uint64_t MAKE_LONG_LONG(uint32_t LowLong, uint32_t HighLong) {
//    return (uint64_t) LowLong | ((uint64_t) HighLong << 32);
//}
//
//int32_t Bsf(uint32_t Operand) {
//    int32_t Index = 0;
//    while ((Operand) && ((Operand & 0x00000001) == 0))
//    {
//        Operand >>= 1;
//        Index += 1;
//    };
//    if (Operand)
//        return Index;
//    return 0;
//}
//
//int32_t Bsr(uint32_t Operand) {
//    int32_t Index = 31;
//    while ((Operand) && ((Operand & 0x80000000) == 0))
//    {
//        Operand <<= 1;
//        Index -= 1;
//    };
//    if (Operand)
//        return Index;
//    return 0;
//}
