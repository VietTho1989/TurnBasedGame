//
//  nlib.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_nlib_hpp
#define weiqi_nlib_hpp

/* N-liberty semeai defense tactical checks. */

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_board.hpp"

namespace weiqi
{
    void group_nlib_defense_check(struct board *b, group_t group, enum stone to_play, struct move_queue *q, int32_t tag);
}

#endif /* nlib_hpp */
