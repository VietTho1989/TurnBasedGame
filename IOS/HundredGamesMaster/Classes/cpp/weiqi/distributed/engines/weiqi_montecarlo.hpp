//
//  montecarlo.hpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_montecarlo_hpp
#define weiqi_montecarlo_hpp

#include <stdio.h>
#include "../../../Platform.h"

#include "../../weiqi_util.hpp"
#include "../../weiqi_board.hpp"

/* This is simple monte-carlo engine. It plays MC_GAMES random games from the
 * current board and records win/loss ratio for each first move. The move with
 * the biggest number of winning games gets played. */
/* Note that while the library is based on New Zealand rules, this engine
 * returns moves according to Chinese rules. Thus, it does not return suicide
 * moves. It of course respects positional superko too. */

/* Pass me arguments like a=b,c=d,...
 * Supported arguments:
 * debug[=DEBUG_LEVEL]		1 is the default; more means more debugging prints
 * games=MC_GAMES		number of random games to play
 * gamelen=MC_GAMELEN		maximal length of played random game
 * playout={light,moggy}[:playout_params]
 */

namespace weiqi
{
#define MC_GAMES	40000
#define MC_GAMELEN	400
    
#define MCDEBUGL(n) DEBUGL_(mc->debug_level, n)
    
    
    /* Internal engine state. */
    struct montecarlo {
        int32_t debug_level;
        int32_t gamelen;
        floating_t resign_ratio;
        int32_t loss_threshold;
        struct joseki_dict *jdict;
        struct playout_policy *playout;
    };
    
    /* Per-move playout statistics. */
    struct move_stat {
        int32_t games;
        int32_t wins;
    };
    
    coord_t montecarlo_genmove(struct montecarlo* mc, struct board *b, struct time_info *ti, enum stone color, bool pass_all_alive);
    
    struct montecarlo* montecarlo_state_init(char *arg, struct board *b);
    
    void montecarlo_done(struct montecarlo* mc);
}

#endif /* montecarlo_hpp */
