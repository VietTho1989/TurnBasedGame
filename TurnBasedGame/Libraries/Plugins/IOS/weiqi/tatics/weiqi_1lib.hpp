//
//  1lib.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi__1lib_hpp
#define weiqi__1lib_hpp

#include <stdio.h>
#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_mq.hpp"

namespace weiqi
{
    /* Can group @group usefully capture a neighbor ?
     * (usefully: not a snapback) */
    bool can_countercapture(struct board *b, group_t group, struct move_queue *q, int32_t tag);
    /* Can group @group capture *any* neighbor ? */
    bool can_countercapture_any(struct board *b, group_t group, struct move_queue *q, int32_t tag);
    
    /* Examine given group in atari, suggesting suitable moves for player
     * @to_play to deal with it (rescuing or capturing it). */
    /* ladder != NULL implies to always enqueue all relevant moves. */
    void group_atari_check(uint32_t alwaysccaprate, struct board *b, group_t group, enum stone to_play, struct move_queue *q, coord_t *ladder, bool middle_ladder, int32_t tag);
}

#endif /* _lib_hpp */
