//
//  slave.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "weiqi_slave.hpp"

#include "../../Platform.h"
#include "../distributed/weiqi_distributed.hpp"
#include "../weiqi_timeinfo.hpp"
#include "../weiqi_debug.hpp"

namespace weiqi
{
    /* UCT infrastructure for a distributed engine slave. */
    
    /* For debugging only. */
    static struct hash_counts h_counts;
    static int64_t parent_not_found = 0;
    static int64_t parent_leaf = 0;
    static int64_t node_not_found = 0;
    
    /* Hash table entry mapping path to node. */
    struct tree_hash {
        path_t coord_path;
        struct tree_node *node;
    };
    
    void* uct_htable_alloc(int32_t hbits)
    {
        return calloc2(1 << hbits, sizeof(struct tree_hash));
    }
    
    /* Clear the hash table. Used only when running as slave for the distributed engine. */
    void uct_htable_reset(struct tree *t)
    {
        if (!t->htable) return;
        double start = time_now();
        memset(t->htable, 0, (1 << t->hbits) * sizeof(t->htable[0]));
        if (DEBUGL(3))
            printf("tree occupied %lld %.1f%% inserts %lld collisions %ld/%ld %.1f%% clear %.3fms\nparent_not_found %.1f%% parent_leaf %.1f%% node_not_found %.1f%%\n", h_counts.occupied, h_counts.occupied * 100.0 / (1 << t->hbits), h_counts.inserts, h_counts.collisions, h_counts.lookups, h_counts.collisions * 100.0 / (h_counts.lookups + 1), (time_now() - start)*1000, parent_not_found * 100.0 / (h_counts.lookups + 1), parent_leaf * 100.0 / (h_counts.lookups + 1), node_not_found * 100.0 / (h_counts.lookups + 1));
        if (DEBUG_MODE) h_counts.occupied = 0;
    }
}
