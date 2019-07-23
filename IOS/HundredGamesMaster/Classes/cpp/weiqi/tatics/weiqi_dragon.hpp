//
//  dragon.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_dragon_hpp
#define weiqi_dragon_hpp

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_debug.hpp"
#include "../weiqi_board.hpp"

namespace weiqi
{
    /* Functions for dealing with dragons, ie virtually connected groups of stones.
     * Used for some high-level tactics decisions, like trying to detect useful lost
     * ladders or whether breaking a 3-stones seki is safe.
     * Currently these are fairly expensive (dragon data is not cached) so shouldn't be
     * called by low-level / perf-critical code. */
    
    
    /* Like group_at() but returns unique id for all stones in a dragon.
     * Depending on the situation what is considered to be a dragon here may or
     * may not match what we'd intuitively call a dragon: there are connections
     * it doesn't understand (dead cutting stones for instance) so it'll usually
     * be smaller. Doesn't need to be perfect though. */
    group_t dragon_at(struct board *b, coord_t to);
    
    /* Returns total number of liberties of dragon at @to. */
    int32_t dragon_liberties(struct board *b, enum stone color, coord_t to);
    
    /* Print board highlighting given dragon */
    void dragon_print(struct board *board, char* f, group_t dragon, char* buf);
    
    /* Like board_print() but use a different color for each dragon */
    void board_print_dragons(struct board *board, char* f, char* buf);
    
    /* Pick a color for dragon with index @i. Returns ansi color code.
     * Useful for writing custom board_print_dragons()-like functions. */
    char *pick_dragon_color(int32_t i, bool bold, bool white_ok);
    
    /* Try to find out if dragon has 2 eyes. Pretty conservative:
     * big eye areas are counted as one eye, must be completely enclosed and
     * have all surrounded stones connected. Doesn't need to be perfect though. */
    bool dragon_is_safe(struct board *b, group_t g, enum stone color);
    
    /* Like group_is_safe() but passing already visited stones / eyes. */
    bool dragon_is_safe_full(struct board *b, group_t g, enum stone color, int32_t *visited, int32_t *eyes);
    
    /* Does one opposite color group neighbor of @g have 2 eyes ? */
    bool neighbor_is_safe(struct board *b, group_t g);
    
    /* Try to detect big eye area, ie:
     *  - completely enclosed area, not too big,
     *  - surrounding stones all connected to each other
     *  - size >= 2  (so no false eye issues)
     * Returns size of the area, or 0 if doesn't match.  */
    int32_t big_eye_area(struct board *b, enum stone color, coord_t around, int32_t *visited);
    
    /* Point we control:
     * Opponent can't play there or we can capture if he does. */
    bool is_controlled_eye_point(struct board *b, coord_t to, enum stone color);
    
    /* Try to find out if dragon is completely surrounded:
     * Look for outwards 2-stones gap from our external liberties.
     * (hack, but works pretty well in practice) */
    bool dragon_is_surrounded(struct board *b, coord_t to);
}

#endif /* dragon_hpp */
