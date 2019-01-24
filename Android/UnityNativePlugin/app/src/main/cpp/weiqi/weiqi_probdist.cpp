//
//  probdist.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include "weiqi_probdist.hpp"
#include "weiqi_board.hpp"
#include "weiqi_random.hpp"
#include "weiqi_debug.hpp"

namespace weiqi
{
    // coord_t probdist_pick(struct probdist *restrict pd, coord_t *restrict ignore)
    coord_t probdist_pick(struct probdist* pd, coord_t* ignore)
    {
        fixp_t total = probdist_total(pd);
        fixp_t stab = fast_irandom(total);
        if (DEBUGL(6))
            printf("stab %f / %f\n", fixp_to_double(stab), fixp_to_double(total));

        int32_t r = 1;
        coord_t c = board_size(pd->b) + 1;
        while (stab > pd->rowtotals[r]) {
            if (DEBUGL(6)){
                char strCoord[256];
                {
                    coord2sstr(strCoord, c, pd->b);
                }
                printf("[%s] skipping row %f (%f)\n", strCoord, fixp_to_double(pd->rowtotals[r]), fixp_to_double(stab));
            }
            
            stab -= pd->rowtotals[r];
            r++;
            {
                // assert(r < board_size(pd->b));
                if(!(r < board_size(pd->b))){
                    printf("error, assert(r < board_size(pd->b))\n");
                    r = board_size(pd->b) -1;
                }
            }
            
            c += board_size(pd->b);
            while (!is_pass(*ignore) && *ignore <= c)
                ignore++;
        }
        
        for (; c < board_size2(pd->b); c++) {
            if (DEBUGL(6)){
                char strCoord[256];
                {
                    coord2sstr(strCoord, c, pd->b);
                }
                printf("[%s] %f (%f)\n", strCoord, fixp_to_double(pd->items[c]), fixp_to_double(stab));
            }
            {
                // assert(is_pass(*ignore) || c <= *ignore);
                if(!(is_pass(*ignore) || c <= *ignore)){
                    printf("error, assert(is_pass(*ignore) || c <= *ignore)\n");
                    *ignore = pass;
                }
            }
            if (c == *ignore) {
                if (DEBUGL(6))
                    printf("\tignored\n");
                ignore++;
                continue;
            }
            
            if (stab <= pd->items[c])
                return c;
            stab -= pd->items[c];
        }
        
        printf("overstab %f (total %f)\n", fixp_to_double(stab), fixp_to_double(total));
        {
            // assert(0);
            printf("error, assert(0)\n");
        }
        return -1;
    }
    
    // bo static
    inline void probdist_set(struct probdist *pd, coord_t c, fixp_t val)
    {
        /* We disable the assertions here since this is quite time-critical
         * part of code, and also the compiler is reluctant to inline the
         * functions otherwise. */
#if 0
        {
            // assert(c >= 0 && c < board_size2(pd->b));
            if(!(c >= 0 && c < board_size2(pd->b))){
                printf("error, assert(c >= 0 && c < board_size2(pd->b))\n");
                c= 0;
            }
        }
        {
            // assert(val >= 0);
            if(!(val >= 0)){
                printf("error, assert(val >= 0)\n");
                val = 0;
            }
        }
#endif
        pd->total += val - pd->items[c];
        board_statics* board_statics = &pd->b->board_statics;
        pd->rowtotals[coord_y(board_statics, c, pd->b)] += val - pd->items[c];
        pd->items[c] = val;
    }
    
    // bo static
    inline void probdist_mute(struct probdist *pd, coord_t c)
    {
        pd->total -= pd->items[c];
        board_statics* board_statics = &pd->b->board_statics;
        pd->rowtotals[coord_y(board_statics, c, pd->b)] -= pd->items[c];
    }
}
