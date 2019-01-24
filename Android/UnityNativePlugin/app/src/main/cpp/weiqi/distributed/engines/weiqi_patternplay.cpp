//
//  patternplay.cpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_patternplay.hpp"
#include "../../../Platform.h"

#include "../../weiqi_patternprob.hpp"
#include "../../weiqi_pattern.hpp"

namespace weiqi
{
    // bo static
    coord_t patternplay_genmove(struct patternplay *pp, struct board *b, struct time_info *ti, enum stone color, bool pass_all_alive)
    {
        struct pattern* pats = new struct pattern[b->flen];
        floating_t* probs = new floating_t[b->flen];
        
        pattern_rate_moves(&pp->pat, b, color, pats, probs);

        int32_t best = 0;
        for (int32_t f = 0; f < b->flen; f++) {
            if (pp->debug_level >= 5 && probs[f] >= 0.001) {
                char s[256];
                pattern2str(s, &pats[f]);
                char strCoord[256];
                {
                    coord2sstr(strCoord, b->f[f], b);
                }
                printf("\t%s: %.3f %s\n", strCoord, probs[f], s);
            }
            if (probs[f] > probs[best]){
                best = f;
            }
        }
        
        delete [] pats;
        delete [] probs;
        
        return b->f[best];
    }
    
    struct patternplay* patternplay_state_init(char *arg)
    {
        struct patternplay* pp = (struct patternplay*)calloc2(1, sizeof(struct patternplay));
        bool pat_setup = false;
        
        pp->debug_level = debug_level;
        
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
                        pp->debug_level = atoi(optval);
                    else
                        pp->debug_level++;
                    
                } else if (!strcasecmp(optname, "patterns") && optval) {
                    patterns_init(&pp->pat, optval, false, true);
                    pat_setup = true;
                    
                } else
                    // die("patternplay: Invalid engine argument %s or missing value\n", optname);
                    printf("dieu, patternplay: Invalid engine argument %s or missing value\n", optname);
            }
        }
        
        if (!pat_setup)
            patterns_init(&pp->pat, NULL, false, true);
        
        if (!pp->pat.pc.spat_dict || !pp->pat.pd){
            // die("Missing spatial dictionary / probtable, aborting.\n");
            printf("Missing spatial dictionary / probtable, aborting.\n");
        }
        return pp;
    }
}
