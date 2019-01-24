//
//  fixp.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_fixp_hpp
#define weiqi_fixp_hpp

#include <stdio.h>

/* Tools for counting fixed-point numbers. */

/* We implement a simple fixed-point number type, with fixed number of
 * fractional binary digits after the radix point. */

#include <stdint.h>

namespace weiqi
{
    typedef uint_fast32_t fixp_t;
    
    /* We should accomodate at least 0..131072 (17bits) in the whole number
     * portion; assuming at least 32bit integer, that leaves us with 15-bit
     * fractional part. Thankfully, we need only unsigned values. */
#define FIXP_BITS 15
    
#define FIXP_SCALE (1<<FIXP_BITS)
    
#define double_to_fixp(n) ((fixp_t) ((n) * (FIXP_SCALE)))
#define fixp_to_double(n) ((double) (n) / FIXP_SCALE)
}

#endif /* fixp_hpp */
