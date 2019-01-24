//
//  eval.hpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef gomoku_eval_hpp
#define gomoku_eval_hpp

#include "../../Platform.h"
#include <stdio.h>
#include "gomoku_ai_controller.hpp"
#include "../gomoku_position.hpp"

namespace gomoku
{
#define kRenjuAiEvalWinningScore 10000
#define kRenjuAiEvalThreateningScore 300
    
    
    // Evaluate the entire game state as a player
    // bo static
    int32_t evalState(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player);
    
    // Evaluate one possible move as a player
    // bo static
    int32_t evalMove(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t player);
    
    // Check if any player is winning based on a given state
    // bo static
    int32_t winningPlayer(const char *gs, int32_t g_board_size);
    
    // Result of a single direction measurement
    struct DirectionMeasurement {
        char length;          // Number of pieces in a row
        char block_count;     // Number of ends blocked by edge or the other player (0-2)
        char space_count;     // Number of spaces in the middle of pattern
    };
    
    // A single direction pattern
    struct DirectionPattern {
        char min_occurrence;  // Minimum number of occurrences to match
        char length;          // Length of pattern (pieces in a row)
        char block_count;     // Number of ends blocked by edge or the other player (0-2)
        char space_count;     // Number of spaces in the middle of pattern (-1: Ignore value)
    };
    
    ///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// Property //////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    
    // An array of preset patterns
    extern DirectionPattern *preset_patterns;
    
    // Preset scores of each preset pattern
    // bo static
    extern int32_t *preset_scores;
    
    extern int32_t preset_patterns_size;
    extern int32_t preset_patterns_skip[6];
    
    ///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// Method //////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    
    // Loads preset patterns into memory
    // preset_patterns_skip is the number of patterns to skip for a maximum
    // measured length in an all_direction_measurement (e.g. longest is 3 pieces
    // in an ADM, then skip first few patterns that require 4 pieces or more).
    // bo static
    void generatePresetPatterns(DirectionPattern **preset_patterns, int32_t **preset_scores, int32_t *preset_patterns_size, int32_t *preset_patterns_skip);
    
    // Evaluates an all-direction measurement
    // bo static
    int32_t evalADM(RenjuAIController* controller, DirectionMeasurement *all_direction_measurement);
    
    // Tries to match a set of patterns with an all-direction measurement
    // bo static
    int32_t matchPattern(RenjuAIController* controller, DirectionMeasurement *all_direction_measurement, DirectionPattern *patterns);
    
    // Measures all 4 directions
    // bo static
    void measureAllDirections(const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t player, bool consecutive, DirectionMeasurement *adm);
    
    // Measure a single direction
    // bo static
    void measureDirection(const char *gs, int32_t g_board_size, int32_t r, int32_t c, int32_t dr, int32_t dc, int32_t player, bool consecutive, DirectionMeasurement *result);

    int32_t myWinningPlayer(const char *gs, int32_t g_board_size, Position* pos);
}

#endif /* eval_hpp */
