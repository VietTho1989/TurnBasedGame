//
//  prior.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_prior_hpp
#define weiqi_prior_hpp

#include <stdio.h>
#include "weiqi_uct.hpp"

#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_stats.hpp"
#include "../tatics/weiqi_ladder.hpp"
#include "../tatics/weiqi_tactics_util.hpp"
#include "../distributed/engines/weiqi_josekibase.hpp"
#include "../weiqi_move.hpp"
#include "../weiqi_patternprob.hpp"
#include "../weiqi_dcnn.hpp"
#include "../weiqi_jni.hpp"

namespace weiqi
{
    struct prior_map {
        struct board *b;
        enum stone to_play;
        int32_t parity;
        /* [board_size2(b)] array, move_stats are the prior
         * values to be assigned to individual moves;
         * move_stats.value is not updated. */
        struct move_stats *prior;
        /* [board_size2(b)] array, whether to compute
         * prior for the given value. */
        bool *consider;
        /* [board_size2(b)] array from cfg_distances() */
        int32_t *distances;
    };
    
    /* @value is the value, @playouts is its weight. */
    // bo static
    inline void add_prior_value(struct prior_map *map, coord_t c, floating_t value, int32_t playouts)
    {
        floating_t v = map->parity > 0 ? value : 1 - value;
        /* We don't need atomicity: */
        struct move_stats s;
        {
            s.playouts = playouts;
            s.value = v;
        }
        stats_merge(&map->prior[c], &s);
    }
    
    void uct_prior(struct uct *u, struct tree_node *node, struct prior_map *map);
    
    struct uct_prior;
    struct uct_prior *uct_prior_init(char *arg, struct board *b, struct uct *u);
    void uct_prior_done(struct uct_prior *p);
}

#endif /* prior_hpp */
