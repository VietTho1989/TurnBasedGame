//
//  score.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_score.hpp"
#include "international_draught_search.hpp"

namespace InternationalDraught
{
    namespace score {
        
        // functions
        
        inline bool is_win  (Score sc) { return sc > +Eval_Inf; }
        inline bool is_loss (Score sc) { return sc < -Eval_Inf; }
        inline bool is_eval (Score sc) { return sc >= -Eval_Inf && sc <= +Eval_Inf; }
        
        Score to_tt(Score sc, Ply ply) {
            {
                // assert(is_ok(sc));
                if(!is_ok(sc)){
                    printf("error, assert(is_ok(sc))\n");
                    return 0;
                }
            }
            {
                // assert(ply >= 0 && ply <= Ply_Max);
                if(!(ply >= 0 && ply <= Ply_Max)){
                    printf("error, assert(ply >= 0 && ply <= Ply_Max)\n");
                    ply = Ply(0);
                }
            }
            
            if (is_win(sc)) {
                sc += Score(ply);
                {
                    // assert(sc <= +Inf);
                    if(sc > +Inf){
                        printf("error, assert(sc <= +Inf)\n");
                        sc = +Inf;
                    }
                }
            } else if (is_loss(sc)) {
                sc -= Score(ply);
                {
                    // assert(sc >= -Inf);
                    if(sc < -Inf){
                        printf("error, assert(sc >= -Inf)\n");
                        sc = -Inf;
                    }
                }
            }
            
            return sc;
        }
        
        Score from_tt(Score sc, Ply ply) {
            {
                // assert(is_ok(sc));
                if(!is_ok(sc)){
                    printf("error, assert(is_ok(sc))\n");
                    sc = Score(0);
                }
            }
            {
                // assert(ply >= 0 && ply <= Ply_Max);
                if(!(ply >= 0 && ply <= Ply_Max)){
                    printf("error, assert(ply >= 0 && ply <= Ply_Max)\n");
                    ply = Ply(0);
                }
            }
            
            if (is_win(sc)) {
                sc -= Score(ply);
                {
                    // assert(is_win(sc));
                    if(!is_win(sc)){
                        printf("error, assert(is_win(sc))\n");
                        sc = +Eval_Inf + 1;
                    }
                }
            } else if (is_loss(sc)) {
                sc += Score(ply);
                {
                    // assert(is_loss(sc));
                    if(!is_loss(sc)){
                        printf("error, assert(is_loss(sc))\n");
                        sc = -Eval_Inf - 1;
                    }
                }
            }
            
            return sc;
        }
        
        Score clamp(Score sc) {
            
            if (is_win(sc)) {
                sc = +Eval_Inf;
            } else if (is_loss(sc)) {
                sc = -Eval_Inf;
            }
            {
                // assert(is_eval(sc));
                if(!is_eval(sc)){
                    printf("error, assert(is_eval(sc))\n");
                    sc = 0;
                }
            }
            return sc;
        }
        
        Score add_safe(Score sc, Score inc) {
            
            if (is_eval(sc)) {
                return clamp(sc + inc);
            } else {
                return sc;
            }
        }
        
    }
}
