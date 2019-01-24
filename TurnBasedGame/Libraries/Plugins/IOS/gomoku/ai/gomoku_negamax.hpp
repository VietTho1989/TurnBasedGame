//
//  negamax.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_negamax_hpp
#define gomoku_negamax_hpp

#include <stdio.h>
#include <vector>
#include "gomoku_ai_controller.hpp"

namespace gomoku
{
    struct RenjuAINegamax
    {
    public:
        /*RenjuAINegamax();
         ~RenjuAINegamax();*/
        
        // bo static
        void heuristicNegamax(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player, int32_t depth, int32_t time_limit, bool enable_ab_pruning, int32_t *actual_depth, int32_t *move_r, int32_t *move_c);
        
    private:
        // Preset search breadth
        // From root to leaf, each element is for 2 layers
        // e.g. {10, 5, 2} -> 10, 10, 5, 5, 2, 2, 2, ...
        // bo static
        int32_t presetSearchBreadth[5] = {10, 6, 6, 3, 3};
        
        // A move (candidate)
        struct Move {
            int32_t r;
            int32_t c;
            int32_t heuristic_val;
            int32_t actual_score;
            
            // Overloads < for sorting
            bool operator<(Move other) const {
                return heuristic_val > other.heuristic_val;
            }
        };
        
        // bo static
        int32_t heuristicNegamax(RenjuAIController* controller, char *gs, int32_t g_board_size, int32_t player, int32_t initial_depth, int32_t depth, bool enable_ab_pruning, int32_t alpha, int32_t beta, int32_t *move_r, int32_t *move_c);
        
        // Search possible moves based on a given state, sorted by heuristic values.
        // bo static
        void searchMovesOrdered(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player, std::vector<Move> *result);
        
        // Currently not used
        // bo static
        int32_t negamax(RenjuAIController* controller, char *gs, int32_t g_board_size, int32_t player, int32_t depth, int32_t *move_r, int32_t *move_c);
    };
}

#endif /* negamax_hpp */
