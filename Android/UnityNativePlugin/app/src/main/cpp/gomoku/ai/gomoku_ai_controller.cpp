//
//  ai_controller.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstring>

#include "gomoku_ai_controller.hpp"
#include "gomoku_eval.hpp"
#include "gomoku_negamax.hpp"
#include "gomoku_utils.hpp"

namespace gomoku
{
    void RenjuAIController::generateMove(const char *gs, int32_t g_board_size, int32_t player, int32_t search_depth, int32_t time_limit, int32_t *actual_depth, int32_t *move_r, int32_t *move_c, int32_t *winning_player, uint32_t *node_count, uint32_t *eval_count, uint32_t *pm_count) {
        int32_t g_gs_size = g_board_size*g_board_size;
        // Check arguments
        /*if (gs == nullptr || player  < 1 || player > 2 || search_depth == 0 || search_depth > 10 || time_limit < 0 || move_r == nullptr || move_c == nullptr) {
         printf("error, parameter error\n");
         return;
         }*/
        if (gs == nullptr || player  < 1 || player > 2 || search_depth == 0 || time_limit < 0 || move_r == nullptr || move_c == nullptr) {
            printf("error, parameter error\n");
            return;
        }
        // correct percent
        {
            if(level<=0){
                level = 1;
            }else{
                if(level>=20){
                    level = 20;
                }
            }
        }
        
        // Initialize counters
        g_eval_count = 0;
        g_pm_count = 0;
        
        // Initialize data
        *move_r = -1;
        *move_c = -1;
        int32_t _winning_player = 0;
        if (actual_depth != nullptr){
            *actual_depth = 0;
        }
        
        // Check if anyone wins the game
        {
            _winning_player = winningPlayer(gs, g_board_size);
            if (_winning_player != 0) {
                if (winning_player != nullptr){
                    *winning_player = _winning_player;
                }
                printf("error, have anyone win: %d, %d\n", _winning_player, *winning_player);
                return;
            }
        }
        
        // Copy game state
        char *_gs = new char[g_gs_size];
        std::memcpy(_gs, gs, g_gs_size);
        
        // Run negamax
        RenjuAINegamax renjuAINegamax;
        renjuAINegamax.heuristicNegamax(this, _gs, g_board_size, player, search_depth, time_limit, true, actual_depth, move_r, move_c);
        
        // Execute the move
        std::memcpy(_gs, gs, g_gs_size);
        setCell(_gs, g_board_size, *move_r, *move_c, static_cast<char>(player));
        
        // Check if anyone wins the game
        _winning_player = winningPlayer(_gs, g_board_size);
        
        // Write output
        if (winning_player != nullptr) *winning_player = _winning_player;
        if (node_count != nullptr) *node_count = g_node_count;
        if (eval_count != nullptr) *eval_count = g_eval_count;
        if (pm_count != nullptr) *pm_count = g_pm_count;
        
        delete[] _gs;
    }
}
