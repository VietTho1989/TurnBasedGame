//
//  random_engine.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_random_engine.hpp"

namespace weiqi
{
    coord_t random_genmove(struct board *b, enum stone color, bool pass_all_alive)
    {
        /* Play a random coordinate. However, we must also guard
         * against suicide moves; repeat playing while it's a suicide
         * unless we keep suiciding; in that case, we probably don't
         * have any other moves available and we pass. */
        coord_t coord;
        int32_t i = 0; bool suicide = false;
        
        do {
            /* board_play_random() actually plays the move too;
             * this is desirable for MC simulations but not within
             * the genmove. Make a scratch new board for it. */
            struct board b2;
            board_copy(&b2, b);
            
            board_play_random(&b2, color, &coord, NULL, NULL);
            
            suicide = (coord != pass && !group_at(&b2, coord));
            board_done_noalloc(&b2);
        } while (suicide && i++ < 100);
        
        return (suicide ? pass : coord);
    }
}
