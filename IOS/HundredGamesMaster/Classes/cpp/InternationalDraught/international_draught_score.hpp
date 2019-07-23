//
//  score.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_score_hpp
#define international_draught_score_hpp

#include <stdio.h>

// includes

#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    namespace score {
        
        // constants
        
        const Score Inf      { Score(10000) };
        const Score BB_Inf   { Score( 9000) };
        const Score Eval_Inf { Score( 8000) };
        
        const Score None { -Inf - Score(1) };
        
        // functions
        
        inline int32_t side(int32_t sc, Side sd) { return (sd == White) ? +sc : -sc; }
        
        inline bool  is_ok (int32_t sc)  { return sc >= -Inf && sc <= +Inf; }
        
        inline Score make  (int32_t sc)  {
            {
                // assert(is_ok(sc));
                if(!is_ok(sc)){
                    printf("error, assert(is_ok(sc))\n");
                    sc = 0;
                }
            }
            return Score(sc);
        }
        
        inline Score loss  (Ply ply) { return -Inf + Score(ply); }
        
        Score to_tt   (Score sc, Ply ply);
        Score from_tt (Score sc, Ply ply);
        
        Score clamp    (Score sc);
        Score add_safe (Score sc, Score inc);
        
    }
}

#endif /* score_hpp */
