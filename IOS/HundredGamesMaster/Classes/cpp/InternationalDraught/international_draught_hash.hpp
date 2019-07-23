//
//  hash.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_hash_hpp
#define international_draught_hash_hpp

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    
    namespace hash {
        
        // functions
        
        void init ();
        
        Key key (const Pos & pos);
        
        inline int32_t    index (Key key, int32_t mask) { return uint64(key) & mask; }
        inline uint32 lock  (Key key)           { return uint64(key) >> 32; }
        
    }
}

#endif /* hash_hpp */
