//
//  engine.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_engine_hpp
#define weiqi_engine_hpp

#include <stdio.h>
#include "weiqi_move.hpp"

namespace weiqi
{
    enum engine_id {
        E_RANDOM,
        E_REPLAY,
        E_PATTERNSCAN,
        E_PATTERNPLAY,
        E_MONTECARLO,
        E_UCT,
        E_DISTRIBUTED,
        E_JOSEKI,
#ifdef DCNN
        E_DCNN,
#endif
        E_MAX,
    };
    
    // bo static
    inline void best_moves_add_full(coord_t c, float r, void *d, coord_t *best_c, float *best_r, void **best_d, int32_t nbest)
    {
        for (int32_t i = 0; i < nbest; i++)
            if (r > best_r[i]) {
                for (int32_t j = nbest - 1; j > i; j--) { // shift
                    best_r[j] = best_r[j - 1];
                    best_c[j] = best_c[j - 1];
                    best_d[j] = best_d[j - 1];
                }
                best_r[i] = r;
                best_c[i] = c;
                best_d[i] = d;
                break;
            }
    }
}

#endif /* engine_hpp */
