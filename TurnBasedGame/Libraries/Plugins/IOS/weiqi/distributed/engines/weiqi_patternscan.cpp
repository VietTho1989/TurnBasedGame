//
//  patternscan.cpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_patternscan.hpp"

namespace weiqi
{
    struct patternscan* patternscan_state_init(char *arg)
    {
        struct patternscan* ps = (struct patternscan*)calloc2(1, sizeof(struct patternscan));
        bool pat_setup = false;
        int32_t xspat = -1;
        
        ps->debug_level = 1;
        ps->color_mask = S_BLACK | S_WHITE;
        
        if (arg) {
            char *optspec, *next = arg;
            while (*next) {
                optspec = next;
                next += strcspn(next, ",");
                if (*next) { *next++ = 0; } else { *next = 0; }
                
                char *optname = optspec;
                char *optval = strchr(optspec, '=');
                if (optval) *optval++ = 0;
                
                if (!strcasecmp(optname, "debug")) {
                    if (optval)
                        ps->debug_level = atoi(optval);
                    else
                        ps->debug_level++;
                    
                } else if (!strcasecmp(optname, "gen_spat_dict")) {
                    /* If set, re-generate the spatial patterns
                     * dictionary; you need to have a dictionary
                     * of spatial stone configurations in order
                     * to match any spatial features. */
                    /* XXX: If you specify the 'patterns' option,
                     * this must come first! */
                    ps->gen_spat_dict = !optval || atoi(optval);
                    
                } else if (!strcasecmp(optname, "no_pattern_match")) {
                    /* If set, do not actually match patterns.
                     * Useful only together with gen_spat_dict
                     * when just building spatial dictionary. */
                    ps->no_pattern_match = !optval || atoi(optval);
                    
                } else if (!strcasecmp(optname, "spat_threshold") && optval) {
                    /* Minimal number of times new spatial
                     * feature must occur in this run (!) to
                     * be included in the dictionary. Note that
                     * this will produce discontinuous dictionary
                     * that you should renumber. Also note that
                     * 3x3 patterns are always saved. */
                    ps->spat_threshold = atoi(optval);
                    
                } else if (!strcasecmp(optname, "competition")) {
                    /* In competition mode, first the played
                     * pattern is printed, then all patterns
                     * that could be played (including the played
                     * one). */
                    ps->competition = !optval || atoi(optval);
                    
                } else if (!strcasecmp(optname, "spat_split_sizes")) {
                    /* Generate a separate pattern for each
                     * spatial size. This is important to
                     * preserve good generalization in unknown
                     * situations where the largest pattern
                     * might not match. */
                    ps->spat_split_sizes = 1;
                    
                } else if (!strcasecmp(optname, "color_mask") && optval) {
                    /* Bitmask of move colors to match. Set this
                     * to 2 if you want to match only white moves,
                     * for example. (Useful for processing
                     * handicap games.) */
                    ps->color_mask = atoi(optval);
                    
                } else if (!strcasecmp(optname, "xspat") && optval) {
                    /* xspat==0: don't match spatial features
                     * xspat==1: match *only* spatial features */
                    xspat = atoi(optval);
                    
                } else if (!strcasecmp(optname, "patterns") && optval) {
                    patterns_init(&ps->pat, optval, ps->gen_spat_dict, false);
                    pat_setup = true;
                    
                } else {
                    // die("patternscan: Invalid engine argument %s or missing value\n", optname);
                    printf("die, patternscan: Invalid engine argument %s or missing value\n", optname);
                }
            }
        }
        
        if (!pat_setup)
            patterns_init(&ps->pat, NULL, ps->gen_spat_dict, false);
        if (ps->spat_split_sizes)
            ps->pat.pc.spat_largest = 0;
        
        for (int32_t i = 0; i < FEAT_MAX; i++) if ((xspat == 0 && i == FEAT_SPATIAL) || (xspat == 1 && i != FEAT_SPATIAL)) ps->pat.ps[i] = 0;
        ps->loaded_spatials = ps->pat.pc.spat_dict->nspatials;
        
        ps->gameno = 1;
        
        return ps;
    }
}
