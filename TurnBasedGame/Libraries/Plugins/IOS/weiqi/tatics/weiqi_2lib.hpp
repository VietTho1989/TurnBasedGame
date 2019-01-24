//
//  2lib.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi__2lib_hpp
#define weiqi__2lib_hpp

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_mq.hpp"
#include "../weiqi_debug.hpp"

namespace weiqi
{
    void can_atari_group(struct board *b, group_t group, enum stone owner, enum stone to_play, struct move_queue *q, int32_t tag, bool use_def_no_hopeless);
    
    void group_2lib_check(struct board *b, group_t group, enum stone to_play, struct move_queue *q, int32_t tag, bool use_miaisafe, bool use_def_no_hopeless);
    
    bool can_capture_2lib_group(struct board *b, group_t g, enum stone color, struct move_queue *q, int32_t tag);
    
    void group_2lib_capture_check(struct board *b, group_t group, enum stone to_play, struct move_queue *q, int32_t tag, bool use_miaisafe, bool use_def_no_hopeless);
}

#endif /* _lib_hpp */
