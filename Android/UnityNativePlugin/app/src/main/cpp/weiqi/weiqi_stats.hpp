//
//  stats.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_stats_hpp
#define weiqi_stats_hpp

#include <stdio.h>
#include "weiqi_util.hpp"

/* Move statistics; we track how good value each move has. */
/* These operations are supposed to be atomic - reasonably
 * safe to perform by multiple threads at once on the same stats.
 * What this means in practice is that perhaps the value will get
 * slightly wrong, but not drastically corrupted. */

namespace weiqi
{
    struct move_stats {
        floating_t value; // BLACK wins/playouts
        int32_t playouts; // # of playouts
    };
    
    /* Add a result to the stats. */
    // bo static
    inline void stats_add_result(struct move_stats *s, floating_t result, int32_t playouts)
    {
        int32_t s_playouts = s->playouts;
        floating_t s_value = s->value;
        /* Force the load, another thread can work on the
         * values in parallel. */
#ifdef _MSC_VER
        MemoryBarrier();
#else
        __sync_synchronize(); /* full memory barrier */
#endif
        
        s_playouts += playouts;
        s_value += (result - s_value) * playouts / s_playouts;
        
        /* We rely on the fact that these two assignments are atomic. */
        s->value = s_value;
        
#ifdef _MSC_VER
        MemoryBarrier();
#else
        __sync_synchronize(); /* full memory barrier */
#endif
        
        s->playouts = s_playouts;
    }
    
    /* Remove a result from the stats. */
    // bo static
    inline void stats_rm_result(struct move_stats *s, floating_t result, int32_t playouts)
    {
        if (s->playouts > playouts) {
            int32_t s_playouts = s->playouts;
            floating_t s_value = s->value;
            /* Force the load, another thread can work on the
             * values in parallel. */
#ifdef _MSC_VER
            MemoryBarrier();
#else
            __sync_synchronize(); /* full memory barrier */
#endif
            
            s_playouts -= playouts;
            s_value += (s_value - result) * playouts / s_playouts;
            
            /* We rely on the fact that these two assignments are atomic. */
            s->value = s_value;
            
#ifdef _MSC_VER
            MemoryBarrier();
#else
            __sync_synchronize(); /* full memory barrier */
#endif
            
            s->playouts = s_playouts;
            
        } else {
            /* We don't touch the value, since in parallel, another
             * thread can be adding a result, thus raising the
             * playouts count after we zero the value. Instead,
             * leaving the value as is with zero playouts should
             * not break anything. */
            s->playouts = 0;
        }
    }
    
    /* Merge two stats together. THIS IS NOT ATOMIC! */
    // bo static
    inline void stats_merge(struct move_stats *dest, struct move_stats *src)
    {
        /* In a sense, this is non-atomic version of stats_add_result(). */
        if (src->playouts) {
            dest->playouts += src->playouts;
            dest->value += (src->value - dest->value) * src->playouts / dest->playouts;
        }
    }
    
    /* Reverse stats parity. */
    // bo static
    inline void stats_reverse_parity(struct move_stats *s)
    {
        s->value = 1 - s->value;
    }
}

#endif /* stats_hpp */
