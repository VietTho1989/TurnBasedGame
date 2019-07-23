//
//  selfatari.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_selfatari_hpp
#define weiqi_selfatari_hpp

/* A fairly reliable self-atari detector. */

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_debug.hpp"
#include "../weiqi_board.hpp"

namespace weiqi
{
#define SELFATARI_3LIB_SUICIDE		1
#define SELFATARI_BIG_GROUPS_ONLY	2
    
    /* Move (color, coord) is a selfatari; this means that it puts a group of
     * ours in atari; i.e., the group has two liberties now. Return the other
     * liberty of such a troublesome group (optionally stored at *bygroup)
     * if that one is not a self-atari.
     * (In case (color, coord) is a multi-selfatari, consider a randomly chosen
     * candidate.) */
    coord_t selfatari_cousin(struct board *b, enum stone color, coord_t coord, group_t *bygroup);
    
    bool is_bad_selfatari_slow(struct board *b, enum stone color, coord_t to, int32_t flags);
    
    /* Check if this move is undesirable self-atari (resulting group would have
     * only single liberty and not capture anything; ko is allowed); we mostly
     * want to avoid these moves. The function actually does a rather elaborate
     * tactical check, allowing self-atari moves that are nakade, eye falsification
     * or throw-ins. */
    // bo static
    inline bool is_bad_selfatari(struct board *b, enum stone color, coord_t to)
    {
        /* More than one immediate liberty, thumbs up! */
        if (immediate_liberty_count(b, to) > 1)
            return false;
        
        return is_bad_selfatari_slow(b, color, to, SELFATARI_3LIB_SUICIDE);
    }
    
    /* Check if this move is a really bad self-atari, allowing opponent to capture
     * 3 stones or more that could have been saved / don't look like useful nakade.
     * Doesn't care much about 1 stone / 2 stones business unlike is_bad_selfatari(). */
    // bo static
    inline bool is_really_bad_selfatari(struct board *b, enum stone color, coord_t to)
    {
        /* More than one immediate liberty, thumbs up! */
        if (immediate_liberty_count(b, to) > 1)
            return false;
        
        return is_bad_selfatari_slow(b, color, to, SELFATARI_BIG_GROUPS_ONLY);
    }
    
    /* Check if move results in self-atari. */
    // bo static
    inline bool is_selfatari(struct board *b, enum stone color, coord_t to)
    {
        /* More than one immediate liberty, thumbs up! */
        if (immediate_liberty_count(b, to) > 1)
            return false;
        
        bool r = true;
        with_move(b, to, color, {
            group_t g = group_at(b, to);
            if (g && board_group_info(b, g)->libs > 1)
                r = false;
        });
        
        return r;
    }
}

#endif /* selfatari_hpp */
