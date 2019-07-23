//
//  uct.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_uct_hpp
#define weiqi_uct_hpp

#include <stdio.h>
#include "weiqi_internal.hpp"
#include "weiqi_search.hpp"
#include "weiqi_walk.hpp"
#include "weiqi_slave.hpp"
#include "weiqi_plugins.hpp"
#include "weiqi_dynkomi.hpp"

#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_dcnn.hpp"
#include "../weiqi_timeinfo.hpp"
#include "../weiqi_debug.hpp"
#include "../weiqi_playout.hpp"
#include "../weiqi_ownermap.hpp"
#include "../weiqi_engine.hpp"
#include "../distributed/weiqi_distributed.hpp"
#include "../distributed/engines/weiqi_josekibase.hpp"
#include "../playout/weiqi_moggy.hpp"
#include "../playout/weiqi_light.hpp"

namespace weiqi
{
    coord_t uct_genmove(struct uct *u, struct board *b, struct time_info *ti, enum stone color, bool pass_all_alive);
    
    struct uct* uct_state_init(char *arg, struct board *b);
    
    void my_uct_done(struct uct *u);
    
    void uct_dead_group_list(struct uct *u, struct board *b, struct move_queue *mq);
}

#endif /* uct_hpp */
