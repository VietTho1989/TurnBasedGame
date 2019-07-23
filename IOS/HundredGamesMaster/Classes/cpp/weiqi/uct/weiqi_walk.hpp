//
//  walk.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_walk_hpp
#define weiqi_walk_hpp

#include <stdio.h>
#include "weiqi_tree.hpp"
#include "weiqi_internal.hpp"

#include "../../Platform.h"
#include "../weiqi_move.hpp"
#include "../weiqi_board.hpp"
#include "../weiqi_gogui.hpp"
#include "../weiqi_playout.hpp"
#include "../tatics/weiqi_tactics_util.hpp"
#include "../weiqi_stats.hpp"

namespace weiqi
{
    void uct_progress_status(struct uct *u, struct tree *t, enum stone color, int32_t playouts, coord_t *final1);

    int32_t uct_playout(struct uct *u, struct board *b, enum stone player_color, struct tree *t);
    int32_t uct_playouts(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s);
}

#endif /* walk_hpp */
