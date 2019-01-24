//
//  ai_controller.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_ai_controller_hpp
#define gomoku_ai_controller_hpp

#include <stdio.h>
#include <cstdint>

namespace gomoku
{
    struct RenjuAIController
    {
    public:
        /*RenjuAIController();
         ~RenjuAIController();*/
        
    public:
        uint32_t g_node_count = 0;
        uint32_t g_eval_count = 0;
        uint32_t g_pm_count = 0;
        uint32_t g_cc_0 = 0;
        uint32_t g_cc_1 = 0;

        uint32_t level = 12;
        
    public:
        // bo static
        void generateMove(const char *gs, int32_t g_board_size, int32_t player, int32_t search_depth, int32_t time_limit, int32_t *actual_depth, int32_t *move_r, int32_t *move_c, int32_t *winning_player, uint32_t *node_count, uint32_t *eval_count, uint32_t *pm_count);
    };
}

#endif /* ai_controller_hpp */
