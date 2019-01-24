//
//  utils.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

// #include "../../Platform.h"

#include <random>
#include "gomoku_utils.hpp"

namespace gomoku
{
    bool remoteCell(const char *gs, int32_t g_board_size, int32_t r, int32_t c)
    {
        if (gs == nullptr) return false;
        for (int32_t i = r - 2; i <= r + 2; ++i) {
            if (i < 0 || i >= g_board_size) continue;
            for (int32_t j = c - 2; j <= c + 2; ++j) {
                if (j < 0 || j >= g_board_size) continue;
                if (gs[g_board_size * i + j] > 0) return false;
            }
        }
        return true;
    }
    
    void zobristInit(int32_t size, uint64_t *z1, uint64_t *z2)
    {
        std::random_device rd;
        std::mt19937 gen(rd());
        std::uniform_int_distribution<uint64_t> d(0, UINT64_MAX);
        
        // Generate random values
        for (int32_t i = 0; i < size; i++) {
            z1[i] = d(gen);
            z2[i] = d(gen);
        }
    }
    
    uint64_t zobristHash(const char *gs, int32_t size, uint64_t *z1, uint64_t *z2)
    {
        uint64_t state = 0;
        for (int32_t i = 0; i < size; i++) {
            if (gs[i] == 1) {
                state ^= z1[i];
            } else if (gs[i] == 2) {
                state ^= z2[i];
            }
        }
        return state;
    }
}
