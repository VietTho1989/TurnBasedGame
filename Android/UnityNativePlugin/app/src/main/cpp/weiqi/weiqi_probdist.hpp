//
//  probdist.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_probdist_hpp
#define weiqi_probdist_hpp

#include <stdio.h>

/* Tools for picking an item according to a probability distribution. */

/* The probability distribution structure is designed to be once
 * initialized, then random items assigned a value repeatedly and
 * random items picked repeatedly as well. */

#include "weiqi_fixp.hpp"
#include "weiqi_move.hpp"
#include "weiqi_util.hpp"

namespace weiqi
{
    /* The interface looks a bit funny-wrapped since we used to switch
     * between different probdist representations. */
    
    struct probdist {
        struct board *b;
        fixp_t *items; // [bsize2], [i] = P(pick==i)
        fixp_t *rowtotals; // [bsize], [i] = sum of items in row i
        fixp_t total; // sum of all items
    };
    
    
    /* Declare pd_ corresponding to board b_ in the local scope. */
#define probdist_alloca(pd_, b_) \
fixp_t pd_ ## __pdi[board_size2(b_)] __attribute__((aligned(32))); memset(pd_ ## __pdi, 0, sizeof(pd_ ## __pdi)); \
fixp_t pd_ ## __pdr[board_size(b_)] __attribute__((aligned(32))); memset(pd_ ## __pdr, 0, sizeof(pd_ ## __pdr)); \
struct probdist pd_ = { .b = b_, .items = pd_ ## __pdi, .rowtotals = pd_ ## __pdr, .total = 0 };
    
    /* Get the value of given item. */
#define probdist_one(pd, c) ((pd)->items[c])
    
    /* Get the cummulative probability value (normalizing constant). */
#define probdist_total(pd) ((pd)->total)
    
    /* Set the value of given item. */
    // bo static
    void probdist_set(struct probdist *pd, coord_t c, fixp_t val);
    
    /* Remove the item from the totals; this is used when you then
     * pass it in the ignore list to probdist_pick(). Of course you
     * must restore the totals afterwards. */
    // bo static
    void probdist_mute(struct probdist *pd, coord_t c);
    
    /* Pick a random item. ignore is a pass-terminated sorted array of items
     * that are not to be considered (and whose values are not in @total). */
    coord_t probdist_pick(struct probdist *pd, coord_t *ignore);
}

#endif /* probdist_hpp */
