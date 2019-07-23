//
//  utils.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_utils_hpp
#define gomoku_utils_hpp

#include <stdio.h>
#include <stdint.h>

namespace gomoku
{
    struct RenjuAIUtils
    {
    public:
        RenjuAIUtils();
        ~RenjuAIUtils();
        
    };
    
    // bo static
    inline char getCell(const char *gs, int32_t g_board_size, int32_t r, int32_t c) {
        if (r < 0 || r >= g_board_size || c < 0 || c >= g_board_size) return -1;
        return gs[g_board_size * r + c];
    }
    
    // bo static
    inline bool setCell(char *gs, int32_t g_board_size, int32_t r, int32_t c, char value) {
        // printf("set cell: %d, %d, %c, %d\n", r, c, value, g_board_size);
        if (r < 0 || r >= g_board_size || c < 0 || c >= g_board_size){
            printf("error, set cell error: %d, %d, %c, %d\n", r, c, value, g_board_size);
            return false;
        }
        gs[g_board_size * r + c] = value;
        return true;
    }
    
    // bo static
    bool remoteCell(const char *gs, int32_t g_board_size, int32_t r, int32_t c);
    
    // Game state hashing
    // bo static
    void zobristInit(int32_t size, uint64_t *z1, uint64_t *z2);
    // bo static
    uint64_t zobristHash(const char *gs, int32_t size, uint64_t *z1, uint64_t *z2);
    // bo static
    inline void zobristToggle(uint64_t *state, uint64_t *z1, uint64_t *z2, int32_t row_size, int32_t r, int32_t c, int32_t player) {
        if (player == 1) {
            *state ^= z1[row_size * r + c];
        } else if (player == 2) {
            *state ^= z2[row_size * r + c];
        }
    }
}

#endif /* utils_hpp */
