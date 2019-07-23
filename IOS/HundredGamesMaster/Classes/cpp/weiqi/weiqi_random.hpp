//
//  random.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_random_hpp
#define weiqi_random_hpp

#include <stdio.h>
#include <stdint.h>
#include "weiqi_util.hpp"

namespace weiqi
{
    
    void random_init(void);
    
    void fast_srandom(uint64_t seed);
    uint64_t fast_getseed(void);
    
    /* Note that only 16bit numbers can be returned. */
    // uint16_t fast_random(uint32_t max);
    /* Use this one if you want larger numbers. */
    static uint32_t fast_irandom(uint32_t max);
    
    /* Get random number in [0..1] range. */
    float fast_frandom();
    
    // bo static
    inline uint32_t fast_irandom(uint32_t max)
    {
        if (max <= 65536)
            return fast_random(max);
        int32_t himax = (max - 1) / 65536;
        uint16_t hi = fast_random(himax + 1);
        return ((uint32_t)hi << 16) | fast_random(hi < himax ? 65536 : max % 65536);
    }
}

#endif /* random_hpp */
