//
//  patternscan.hpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_patternscan_hpp
#define weiqi_patternscan_hpp

#include <stdio.h>
#include "../../../Platform.h"

#include "../../weiqi_pattern.hpp"

/* The engine has two modes:
 *
 * * gen_spat_dict=1: patterns.spat file is generated with a list of all
 *   encountered spatials
 *
 * * gen_spat_dict=0,no_pattern_match=1: all encountered patterns are
 *   listed on output on each move; the general format is
 * 	[(winpattern)]
 *   but with competition=1 it is
 * 	[(winpattern)] [(witnesspattern0) (witnesspattern1) ...]
 *   and with spat_split_sizes=1 even
 * 	[(winpattern0) (winpattern1) ...] [(witpattern0) (witpattern1) ...]
 */

namespace weiqi
{
    /* Internal engine state. */
    struct patternscan {
        int32_t debug_level;
        
        struct pattern_setup pat;
        bool competition;
        bool spat_split_sizes;
        int32_t color_mask;
        
        bool no_pattern_match;
        bool gen_spat_dict;
        /* Minimal number of occurences for spatial to be saved. */
        int32_t spat_threshold;
        /* Number of loaded spatials; checkpoint for saving new sids
         * in case gen_spat_dict is enabled. */
        int32_t loaded_spatials;
        
        /* Book-keeping of spatial occurence count. */
        int32_t gameno;
        uint32_t nscounts;
        int32_t *scounts;
        int32_t *sgameno;
    };
    
    struct patternscan* patternscan_state_init(char *arg);
}

#endif /* patternscan_hpp */
