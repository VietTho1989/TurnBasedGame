//
//  search.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_search_hpp
#define weiqi_search_hpp

#include <stdio.h>

#include "weiqi_tree.hpp"

#include "../../Platform.h"
#include "../weiqi_stone.hpp"
#include "../weiqi_timeinfo.hpp"
#include "../weiqi_board.hpp"

namespace weiqi
{
    
    void default_ti_init(void);
    
    /* Internal UCT structures */
    
    /* How often to inspect the tree from the main thread to check for playout
     * stop, progress reports, etc. (in seconds) */
#define TREE_BUSYWAIT_INTERVAL 0.1 /* 100ms */
    
    
    /* Thread manager state */
    // extern volatile sig_atomic_t uct_halt;
    // extern bool thread_manager_running;
    
    /* Search thread context */
    struct uct_thread_ctx {
        int32_t tid;
        struct uct *u;
        struct board *b;
        enum stone color;
        struct tree *t;
        uint64_t seed;
        int32_t games;
        struct time_info *ti;
    };
    
    /* Progress information of the on-going MCTS search - when did we
     * last adjusted dynkomi, printed out stuff, etc. */
    struct uct_search_state {
        /* Number of games simulated for this simulation before
         * we started the search. (We have simulated them earlier.) */
        int32_t base_playouts;
        /* Number of last dynkomi adjustment. */
        int32_t last_dynkomi;
        /* Number of last game with progress print. */
        int32_t last_print;
        /* Number of simulations to wait before next print. */
        int32_t print_interval;
        /* Printed notification about full memory? */
        bool fullmem;
        
        struct time_stop stop;
        struct uct_thread_ctx ctx;
    };

    int32_t uct_search_games(struct uct_search_state *s);
    
    void uct_search_start(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s);
    
    struct uct_thread_ctx *uct_search_stop(struct uct *u);
    
    void uct_search_progress(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s, int32_t i);
    
    bool uct_search_check_stop(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s, int32_t i);
    
    struct tree_node *uct_search_result(struct uct *u, struct board *b, enum stone color, bool pass_all_alive, int32_t played_games, int32_t base_playouts, coord_t *best_coord);
}

#endif /* search_hpp */
