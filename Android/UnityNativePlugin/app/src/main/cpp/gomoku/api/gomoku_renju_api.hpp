//
//  renju_api.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_renju_api_hpp
#define gomoku_renju_api_hpp

#include <stdio.h>
#include <string>

namespace gomoku
{
    struct RenjuAPI
    {
    public:
        int32_t level = 12;
        /*RenjuAPI();
         ~RenjuAPI();*/
        
        // Generate move based on a given game state
        // bo static
        bool generateMove(const char *gs_string, int32_t g_board_size, int32_t ai_player_id, int32_t search_depth, int32_t time_limit, int32_t num_threads, int32_t *actual_depth, int32_t *move_r, int32_t *move_c, int32_t *winning_player, uint32_t *node_count, uint32_t *eval_count, uint32_t *pm_count);
        
    private:
        // Render game state into text
        // bo static
        std::string renderGameState(const char *gs);
    };
    
    // Convert a game state string to game state binary array
    void gsFromString(const char *gs_string, char *gs, int32_t g_gs_size);
}

#endif /* renju_api_hpp */
