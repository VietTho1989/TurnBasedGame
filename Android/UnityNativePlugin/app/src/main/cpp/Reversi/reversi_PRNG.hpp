//
//  PRNG.hpp
//  TestOthello
//
//  Created by Viet Tho on 3/21/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef reversi_PRNG_hpp
#define reversi_PRNG_hpp

#include <stdio.h>
#include <cassert>
#include <chrono>
#include <ostream>
#include <string>
#include <vector>

namespace Reversi
{
    class PRNG {
        
        uint64_t s;
        
        uint64_t rand64() {
            
            s ^= s >> 12, s ^= s << 25, s ^= s >> 27;
            return s * 2685821657736338717LL;
        }
        
    public:
        PRNG(uint64_t seed) : s(seed) { assert(seed); }
        
        template<typename T> T rand() { return T(rand64()); }
        
        /// Special generator used to fast init magic numbers.
        /// Output values only have 1/8th of their bits set on average.
        template<typename T> T sparse_rand(){
            return T(rand64() & rand64() & rand64());
        }
    };
    
    typedef std::chrono::milliseconds::rep TimePoint; // A value in milliseconds
    
    inline TimePoint now() {
        return std::chrono::duration_cast<std::chrono::milliseconds>
        (std::chrono::steady_clock::now().time_since_epoch()).count();
    }
}

#endif /* PRNG_hpp */
