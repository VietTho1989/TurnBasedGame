//
//  eval.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>
#include <limits.h>
#include <cstring>
#include "../../Platform.h"

#include "gomoku_eval.hpp"
#include "gomoku_utils.hpp"
#include "../gomoku_position.hpp"

using namespace std;

namespace gomoku
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// Property //////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    
    // An array of preset patterns
    DirectionPattern *preset_patterns = nullptr;
    
    // Preset scores of each preset pattern
    // bo static
    int32_t *preset_scores = nullptr;

    int32_t preset_patterns_size = 0;
    int32_t preset_patterns_skip[6] = {0};
    
    ///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// Method //////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////

    int32_t evalState(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player) {
        // Check parameters
        if (gs == nullptr || player < 1 || player > 2){
            printf("evalState score 0\n");
            return 0;
        }
        
        // Evaluate all possible moves
        int32_t score = 0;
        for (int32_t r = 0; r < g_board_size; ++r) {
            for (int32_t c = 0; c < g_board_size; ++c) {
                score += evalMove(controller, gs, g_board_size, r, c, player);
            }
        }
        printf("evalState: score: %d\n", score);
        return score;
    }

    int32_t evalMove(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t player) {
        // Check parameters
        if (gs == nullptr ||
            player < 1 || player > 2) return 0;
        
        // Count evaluations
        ++controller->g_eval_count;
        
        // Generate preset patterns structure in memory
        if (preset_patterns == nullptr) {
            generatePresetPatterns(&preset_patterns, &preset_scores, &preset_patterns_size, preset_patterns_skip);
        }
        
        // Allocate 4 direction measurements
        DirectionMeasurement adm[4];
        
        // Measure in consecutive and non-consecutive conditions
        int32_t max_score = 0;
        for (bool consecutive = false;; consecutive = true) {
            // Execute measurement
            measureAllDirections(gs, g_board_size, r, c, player, consecutive, adm);

            int32_t score = evalADM(controller, adm);
            
            // Prefer consecutive
            // if (!consecutive) score *= 0.9;
            
            // Choose the better between consecutive and non-consecutive
            max_score = max(max_score, score);
            
            if (consecutive) break;
        }
        return max_score;
    }

    int32_t evalADM(RenjuAIController* controller, DirectionMeasurement *all_direction_measurement) {
        int32_t score = 0;
        int32_t size = preset_patterns_size;
        
        // Add to score by length on each direction
        // Find the maximum length in ADM and skip some patterns
        int32_t max_measured_len = 0;
        for (int32_t i = 0; i < 4; i++) {
            int32_t len = all_direction_measurement[i].length;
            max_measured_len = len > max_measured_len ? len : max_measured_len;
            score += len - 1;
        }
        int32_t start_pattern = preset_patterns_skip[max_measured_len];
        
        // = preset_patterns_skip[max_measured_len];
        
        // Loop through and try to match all preset patterns
        for (int32_t i = start_pattern; i < size; ++i) {
            score += matchPattern(controller, all_direction_measurement, &preset_patterns[2 * i]) * preset_scores[i];
            
            // Only match one threatening pattern
            if (score >= kRenjuAiEvalThreateningScore) break;
        }
        
        // // If no match, calculate score as the number of open ends
        // if (score == 0) {
        //     for (int32_t i = 0; i < 4; i++) {
        //         if (all_direction_measurement[i].block_count > 0) {
        //             score = 1;
        //             break;
        //         }
        //     }
        // }
        
        return score;
    }

    int32_t matchPattern(RenjuAIController* controller, DirectionMeasurement *all_direction_measurement, DirectionPattern *patterns) {
        // Check arguments
        if (all_direction_measurement == nullptr) return -1;
        if (patterns == nullptr) return -1;
        
        // Increment PM count
        controller->g_pm_count++;
        
        // Initialize match_count to INT_MAX since minimum value will be output
        int32_t match_count = INT_MAX, single_pattern_match = 0;
        
        // Currently allows maximum 2 patterns
        for (int32_t i = 0; i < 2; ++i) {
            auto p = patterns[i];
            if (p.length == 0) break;
            
            // Initialize counter
            single_pattern_match = 0;
            
            // Loop through 4 directions
            for (int32_t j = 0; j < 4; ++j) {
                auto dm = all_direction_measurement[j];
                
                // Requires exact match
#ifndef Android
                if (dm.length == p.length &&
                    (p.block_count == -1 || dm.block_count == p.block_count) &&
                    (p.space_count == -1 || dm.space_count == p.space_count)) {
                    single_pattern_match++;
                }
#else
                if (dm.length == p.length &&
                    (p.block_count == static_cast<char>(-1) || dm.block_count == p.block_count) &&
                    (p.space_count == static_cast<char>(-1) || dm.space_count == p.space_count)) {
                    single_pattern_match++;
                }
#endif
            }
            
            // Consider minimum number of occurrences
            single_pattern_match /= p.min_occurrence;
            
            // Take smaller value
            match_count = match_count >= single_pattern_match ? single_pattern_match : match_count;
        }
        return match_count;
    }
    
    void measureAllDirections(const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t player, bool consecutive, DirectionMeasurement *adm)
    {
        // Check arguments
        if (gs == nullptr) return;
        if (r < 0 || r >= g_board_size || c < 0 || c >= g_board_size) return;
        
        // Measure 4 directions
        measureDirection(gs, g_board_size, r, c, 0,  1, player, consecutive, &adm[0]);
        measureDirection(gs, g_board_size, r, c, 1,  1, player, consecutive, &adm[1]);
        measureDirection(gs, g_board_size, r, c, 1,  0, player, consecutive, &adm[2]);
        measureDirection(gs, g_board_size, r, c, 1, -1, player, consecutive, &adm[3]);
    }
    
    void measureDirection(const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t dr, int32_t dc, int32_t player, bool consecutive, DirectionMeasurement *result) {
        // Check arguments
        if (gs == nullptr) return;
        if (r < 0 || r >= g_board_size || c < 0 || c >= g_board_size) return;
        if (dr == 0 && dc == 0) return;
        
        // Initialization
        int32_t cr = r, cc = c;
        result->length = 1, result->block_count = 2, result->space_count = 0;

        int32_t space_allowance = 1;
        if (consecutive) space_allowance = 0;
        
        for (bool reversed = false;; reversed = true) {
            while (true) {
                // Move
                cr += dr; cc += dc;
                
                // Validate position
                if (cr < 0 || cr >= g_board_size || cc < 0 || cc >= g_board_size) break;
                
                // Get cell value
                int32_t cell = gs[g_board_size * cr + cc];
                
                // Empty cells
                if (cell == 0) {
                    if (space_allowance > 0 && getCell(gs, g_board_size, cr + dr, cc + dc) == player) {
                        space_allowance--; result->space_count++;
                        continue;
                    } else {
                        result->block_count--;
                        break;
                    }
                }
                
                // Another player
                if (cell != player) break;
                
                // Current player
                result->length++;
            }
            
            // Reverse direction and continue (just once)
            if (reversed) break;
            cr = r; cc = c;
            dr = -dr; dc = -dc;
        }
        
        // More than 5 pieces in a row is equivalent to 5 pieces
        if (result->length >= 5) {
            if (result->space_count == 0) {
                result->length = 5;
                result->block_count = 0;
            } else {
                result->length = 4;
                result->block_count = 1;
            }
        }
    }
    
    void generatePresetPatterns(DirectionPattern **preset_patterns, int32_t **preset_scores, int32_t *preset_patterns_size, int32_t *preset_patterns_skip) {
        const int32_t _size = 11;
        preset_patterns_skip[5] = 0;
        preset_patterns_skip[4] = 1;
        preset_patterns_skip[3] = 7;
        preset_patterns_skip[2] = 10;
        
        preset_patterns_skip[1] = _size;
        preset_patterns_skip[0] = _size;

#ifndef Android
        DirectionPattern patterns[_size * 2] = {
            {1, 5,  0,  0}, {0, 0,  0,  0},  // 10000
            {1, 4,  0,  0}, {0, 0,  0,  0},  // 700
            {2, 4,  1,  0}, {0, 0,  0,  0},  // 700
            {2, 4, -1,  1}, {0, 0,  0,  0},  // 700
            {1, 4,  1,  0}, {1, 4, -1,  1},  // 700
            {1, 4,  1,  0}, {1, 3,  0, -1},  // 500
            {1, 4, -1,  1}, {1, 3,  0, -1},  // 500
            {2, 3,  0, -1}, {0, 0,  0,  0},  // 300
            // {1, 4,  1,  0}, {0, 0,  0,  0},  // 1
            // {1, 4, -1,  1}, {0, 0,  0,  0},  // 1
            {3, 2,  0, -1}, {0, 0,  0,  0},  // 50
            {1, 3,  0, -1}, {0, 0,  0,  0},  // 20
            {1, 2,  0, -1}, {0, 0,  0,  0}   // 9
        };
#else
        DirectionPattern patterns[_size * 2] = {
                {1, 5,  0,  0}, {0, 0,  0,  0},  // 10000
                {1, 4,  0,  0}, {0, 0,  0,  0},  // 700
                {2, 4,  1,  0}, {0, 0,  0,  0},  // 700
                {2, 4, static_cast<char>(-1),  1}, {0, 0,  0,  0},  // 700
                {1, 4,  1,  0}, {1, 4, static_cast<char>(-1),  1},  // 700
                {1, 4,  1,  0}, {1, 3,  0, static_cast<char>(-1)},  // 500
                {1, 4, static_cast<char>(-1),  1}, {1, 3,  0, static_cast<char>(-1)},  // 500
                {2, 3,  0, static_cast<char>(-1)}, {0, 0,  0,  0},  // 300
                // {1, 4,  1,  0}, {0, 0,  0,  0},  // 1
                // {1, 4, -1,  1}, {0, 0,  0,  0},  // 1
                {3, 2,  0, static_cast<char>(-1)}, {0, 0,  0,  0},  // 50
                {1, 3,  0, static_cast<char>(-1)}, {0, 0,  0,  0},  // 20
                {1, 2,  0, static_cast<char>(-1)}, {0, 0,  0,  0}   // 9
        };
#endif

        int32_t scores[_size] = {
            10000,
            700,
            700,
            700,
            700,
            500,
            500,
            300,
            // 1,
            // 1,
            50,
            20,
            9
        };
        
        *preset_patterns = new DirectionPattern[_size * 2];
        *preset_scores   = new int[_size];
        
        memcpy(*preset_patterns, patterns, sizeof(DirectionPattern) * _size * 2);
        memcpy(*preset_scores, scores, sizeof(int32_t) * _size);
        
        *preset_patterns_size = _size;
    }

    int32_t winningPlayer(const char *gs, int32_t g_board_size) {
        if (gs == nullptr){
            printf("error, gs null\n");
            return 0;
        }
        for (int32_t r = 0; r < g_board_size; ++r) {
            for (int32_t c = 0; c < g_board_size; ++c) {
                int32_t cell = gs[g_board_size * r + c];
                if (cell == 0){
                    continue;
                }
                for (int32_t dr = -1; dr <= 1; ++dr) {
                    for (int32_t dc = -1; dc <= 1; ++dc) {
                        if (dr == 0 && dc <= 0) continue;
                        DirectionMeasurement dm;
                        measureDirection(gs, g_board_size, r, c, dr, dc, cell, 1, &dm);
                        if (dm.length >= 5) {
                            // printf("winningPlayer cell: %d, %d, %d\n", cell, r, c);
                            return cell;
                        }
                    }
                }
            }
        }
        return 0;
    }

    int32_t myWinningPlayer(const char *gs, int32_t g_board_size, Position* pos)
    {
        // reset state
        {
            pos->winningPlayer = 0;
            pos->winSize = 0;
        }
        if (gs == nullptr){
            printf("error, gs null\n");
            return 0;
        }
        for (int32_t r = 0; r < g_board_size; ++r) {
            for (int32_t c = 0; c < g_board_size; ++c) {
                int32_t cell = gs[g_board_size * r + c];
                if (cell == 0){
                    continue;
                }
                for (int32_t dr = -1; dr <= 1; ++dr) {
                    for (int32_t dc = -1; dc <= 1; ++dc) {
                        if (dr == 0 && dc <= 0) {
                            continue;
                        }
                        DirectionMeasurement dm;
                        measureDirection(gs, g_board_size, r, c, dr, dc, cell, 1, &dm);
                        if (dm.length >= 5) {
                            // printf("winningPlayer cell: %d, %d, %d\n", cell, r, c);
                            pos->winningPlayer = cell;
                            // add coord
                            {
                                if(pos->winSize<100){
                                    pos->winCoord[pos->winSize] = g_board_size * r + c;
                                    pos->winSize++;
                                }else{
                                    printf("error, why pos->winSize too large: %d\n", pos->winSize);
                                }
                            }
                        }
                    }
                }
            }
        }
        return 0;
    }
}
