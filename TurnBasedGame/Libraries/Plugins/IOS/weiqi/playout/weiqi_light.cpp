//
//  light.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_light.hpp"
#include "../../Platform.h"

#include "../weiqi_playout.hpp"

namespace weiqi
{
#define PLDEBUGL(n) DEBUGL_(p->debug_level, n)
    
    coord_t playout_light_choose(struct playout_policy *p, struct playout_setup *s, struct board *b, enum stone to_play)
    {
        return pass;
    }
    
    
    struct playout_policy* playout_light_init(char *arg, struct board *b)
    {
        struct playout_policy* p = (struct playout_policy*)calloc2(1, sizeof(*p));
        p->choose = playout_light_choose;
        
        if (arg)
            printf("playout-light: This policy does not accept arguments (%s)\n", arg);
        
        return p;
    }
}
