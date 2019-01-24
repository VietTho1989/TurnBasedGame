//
//  patternplay.hpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef patternplay_hpp
#define patternplay_hpp

#include <stdio.h>
#include "../../../Platform.h"

#include "../../weiqi_pattern.hpp"

namespace weiqi
{
    /* Internal engine state. */
    struct patternplay {
        int32_t debug_level;
        
        struct pattern_setup pat;
    };
    
    coord_t patternplay_genmove(struct patternplay *pp, struct board *b, struct time_info *ti, enum stone color, bool pass_all_alive);
    
    struct patternplay* patternplay_state_init(char *arg);
}

#endif /* patternplay_hpp */
