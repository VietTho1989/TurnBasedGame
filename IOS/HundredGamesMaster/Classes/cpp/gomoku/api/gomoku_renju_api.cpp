//
//  renju_api.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../../Platform.h"
#include "gomoku_renju_api.hpp"
#include <cstring>
#include "../ai/gomoku_ai_controller.hpp"

namespace gomoku
{
    bool RenjuAPI::generateMove(const char *gs_string, int32_t g_board_size, int32_t ai_player_id, int32_t search_depth, int32_t time_limit, int32_t num_threads, int32_t *actual_depth, int32_t *move_r, int32_t *move_c, int32_t *winning_player, uint32_t *node_count, uint32_t *eval_count, uint32_t *pm_count)
    {
        int32_t g_gs_size = g_board_size*g_board_size;
        // printf("generate move: boardSize: %d\n", g_board_size);
        // Check input data
        /*if (strlen(gs_string) != g_gs_size || ai_player_id < 1 || ai_player_id > 2 || search_depth == 0 || search_depth > 10 || time_limit < 0 || num_threads < 1) {
         printf("error\n");
         return false;
         }*/
        if (strlen(gs_string) != g_gs_size || ai_player_id < 1 || ai_player_id > 2 || search_depth == 0 || time_limit < 0 || num_threads < 1) {
            printf("error\n");
            return false;
        }
        
        // Copy game state
        char *gs = new char[g_gs_size];
        std::memcpy(gs, gs_string, g_gs_size);
        
        // Convert from string
        gsFromString(gs_string, gs, g_gs_size);
        
        // Generate move
        RenjuAIController renjuAIController;
        {
            renjuAIController.level = level;
        }
        renjuAIController.generateMove(gs, g_board_size, ai_player_id, search_depth, time_limit, actual_depth, move_r, move_c, winning_player, node_count, eval_count, pm_count);
        
        // Release memory
        delete[] gs;
        return true;
    }
    
    void gsFromString(const char *gs_string, char *gs, int32_t g_gs_size) {
        if (strlen(gs_string) != g_gs_size) return;
        for (int32_t i = 0; i < static_cast<int32_t>(g_gs_size); i++) {
            gs[i] = gs_string[i] - '0';
        }
    }
}
