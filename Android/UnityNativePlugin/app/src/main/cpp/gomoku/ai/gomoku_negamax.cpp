//
//  negamax.cpp
//  gomoku
//
//  Created by Viet Tho on 4/11/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../../Platform.h"
#include <algorithm>
#include <cstring>
#include <ctime>
#include <iostream>
#include "gomoku_negamax.hpp"
#include "gomoku_eval.hpp"
#include "gomoku_utils.hpp"

using namespace std;

namespace gomoku
{
    // Estimated average branching factor for iterative deepening
#define kAvgBranchingFactor 3
    
    // Maximum depth for iterative deepening
#define kMaximumDepth 16
    
    // kScoreDecayFactor decays score each layer so the algorithm
    // prefers closer advantages
#define kScoreDecayFactor 0.95f
    
    void RenjuAINegamax::heuristicNegamax(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player, int32_t depth, int32_t time_limit, bool enable_ab_pruning, int32_t *actual_depth, int32_t *move_r, int32_t *move_c) {
        int32_t g_gs_size = g_board_size*g_board_size;
        // Check arguments
        if (gs == nullptr ||
            player < 1 || player > 2 ||
            depth == 0 || depth < -1 ||
            time_limit < 0) return;
        
        // Copy game state
        char *_gs = new char[g_gs_size];
        memcpy(_gs, gs, g_gs_size);
        
        // Speedup first move
        int32_t _cnt = 0;
        for (int32_t i = 0; i < static_cast<int>(g_gs_size); i++)
            if (_gs[i] != 0) _cnt++;
        
        if (_cnt <= 2) depth = 6;
        
        // Fixed depth or iterative deepening
        if (depth > 0) {
            if (actual_depth != nullptr) *actual_depth = depth;
            heuristicNegamax(controller, _gs, g_board_size, player, depth, depth, enable_ab_pruning, INT_MIN / 2, INT_MAX / 2, move_r, move_c);
        } else {
            // Iterative deepening
            std::clock_t c_start = std::clock();
            for (int32_t d = 6;; d += 2) {
                std::clock_t c_iteration_start = std::clock();
                
                // Reset game state
                memcpy(_gs, gs, g_gs_size);
                
                // Execute negamax
                heuristicNegamax(controller, _gs, g_board_size, player, d, d, enable_ab_pruning, INT_MIN / 2, INT_MAX / 2, move_r, move_c);
                
                // Times
                std::clock_t c_iteration = (std::clock() - c_iteration_start) * 1000 / CLOCKS_PER_SEC;
                std::clock_t c_elapsed = (std::clock() - c_start) * 1000 / CLOCKS_PER_SEC;
                
                if (c_elapsed + (c_iteration * kAvgBranchingFactor * kAvgBranchingFactor) > time_limit ||
                    d >= kMaximumDepth) {
                    if (actual_depth != nullptr) *actual_depth = d;
                    break;
                }
            }
        }
        delete[] _gs;
    }

    int32_t RenjuAINegamax::heuristicNegamax(RenjuAIController* controller, char *gs, int32_t g_board_size, int32_t player, int32_t initial_depth, int32_t depth, bool enable_ab_pruning, int32_t alpha, int32_t beta, int32_t *move_r, int32_t *move_c) {
        // Count node
        ++controller->g_node_count;

        int32_t max_score = INT_MIN;
        int32_t opponent = player == 1 ? 2 : 1;
        
        // Search and sort possible moves
        std::vector<Move> moves_player, moves_opponent, candidate_moves;
        searchMovesOrdered(controller, gs, g_board_size, player, &moves_player);
        searchMovesOrdered(controller, gs, g_board_size, opponent, &moves_opponent);
        
        // End if no move could be performed
        if (moves_player.size() == 0) return 0;
        
        // End directly if only one move or a winning move is found
        if (moves_player.size() == 1 || moves_player[0].heuristic_val >= kRenjuAiEvalWinningScore) {
            auto move = moves_player[0];
            if (move_r != nullptr) *move_r = move.r;
            if (move_c != nullptr) *move_c = move.c;
            return move.heuristic_val;
        }
        
        // If opponent has threatening moves, consider blocking them first
        bool block_opponent = false;
        int32_t tmp_size = min(static_cast<int>(moves_opponent.size()), 2);
        if (moves_opponent[0].heuristic_val >= kRenjuAiEvalThreateningScore) {
            block_opponent = true;
            for (int32_t i = 0; i < tmp_size; ++i) {
                auto move = moves_opponent[i];
                
                // Re-evaluate move as current player
                move.heuristic_val = evalMove(controller, gs, g_board_size, move.r, move.c, player);
                
                // Add to candidate list
                candidate_moves.push_back(move);
            }
        }
        
        // Set breadth
        int32_t breadth = (initial_depth >> 1) - ((depth + 1) >> 1);
        if (breadth > 4) breadth = presetSearchBreadth[4];
        else             breadth = presetSearchBreadth[breadth];
        
        // Copy moves for current player
        tmp_size = min(static_cast<int>(moves_player.size()), breadth);
        for (int32_t i = 0; i < tmp_size; ++i)
            candidate_moves.push_back(moves_player[i]);
        
        // Print heuristic values for debugging
        //    if (depth >= 8) {
        //        for (int32_t i = 0; i < moves_player.size(); ++i) {
        //            auto move = moves_player[i];
        //            std::cout << depth << " | " << move.r << ", " << move.c << ": " << move.heuristic_val << std::endl;
        //        }
        //    }
        
        // Loop through every move
        // printf("\n");
        int32_t size = static_cast<int32_t>(candidate_moves.size());
        for (int32_t i = 0; i < size; ++i) {
            auto move = candidate_moves[i];
            
            // Execute move
            setCell(gs, g_board_size, move.r, move.c, static_cast<char>(player));
            
            // Run negamax recursively
            int32_t score = 0;
            if (depth > 1) score = heuristicNegamax(controller, gs, g_board_size, opponent, initial_depth, depth - 1, enable_ab_pruning, -beta, -alpha + move.heuristic_val, nullptr, nullptr);
            
            // Closer moves get more score
            if (score >= 2) score = static_cast<int>(score * kScoreDecayFactor);
            
            // Calculate score difference
            move.actual_score = move.heuristic_val - score;
            
            // random score
            {
                // not block move
                if (depth != initial_depth || !block_opponent || max_score >= 0){
                    if(controller->level>0 && controller->level<20){
                        int32_t randomLevel = fastRandom(20 - controller->level);
                        int32_t actual_score = move.actual_score;
                        move.actual_score = actual_score - randomLevel*actual_score/20;
                        // printf("actual score: %d, %d, %d\n", actual_score, move.actual_score, randomLevel);
                    }
                }else{
                    printf("find blocking move: %d, %d: %d, %d\n", move.r, move.c, move.actual_score, initial_depth);
                }
            }
            // Store back to candidate array
            {
                candidate_moves[i].actual_score = move.actual_score;
                // printf("candidate move actual score: %d, %d, %d\n", move.actual_score, move.r, move.c);
            }
            
            // Print actual scores for debugging
            //        if (depth >= 8)
            //            std::cout << depth << " | " << move.r << ", " << move.c << ": " << move.actual_score << std::endl;
            
            // Restore
            setCell(gs, g_board_size, move.r, move.c, 0);
            
            // Update maximum score
            if (move.actual_score > max_score) {
                max_score = move.actual_score;
                if (move_r != nullptr) *move_r = move.r;
                if (move_c != nullptr) *move_c = move.c;
            }
            
            // Alpha-beta
            int32_t max_score_decayed = max_score;
            if (max_score >= 2) max_score_decayed = static_cast<int32_t>(max_score_decayed * kScoreDecayFactor);
            if (max_score > alpha) alpha = max_score;
            if (enable_ab_pruning && max_score_decayed >= beta) break;
        }
        // printf("\n");
        
        // If no moves that are much better than blocking threatening moves, block them.
        // This attempts blocking even winning is impossible if the opponent plays optimally.
        if (depth == initial_depth && block_opponent && max_score < 0) {
            auto blocking_move = candidate_moves[0];
            int32_t b_score = blocking_move.actual_score;
            if (b_score == 0) b_score = 1;
            if ((max_score - b_score) / static_cast<float>(std::abs(b_score)) < 0.2) {
                // printf("find blocking move: %d, %d\n", blocking_move.r, blocking_move.c);
                if (move_r != nullptr){
                    *move_r = blocking_move.r;
                }
                if (move_c != nullptr){
                    *move_c = blocking_move.c;
                }
                max_score = blocking_move.actual_score;
            }
        }
        return max_score;
    }
    
    void RenjuAINegamax::searchMovesOrdered(RenjuAIController* controller, const char *gs, int32_t g_board_size, int32_t player, std::vector<Move> *result) {
        // Clear and previous result
        result->clear();
        
        // Find an extent to reduce unnecessary calls to RenjuAIUtils::remoteCell
        int32_t min_r = INT_MAX, min_c = INT_MAX, max_r = INT_MIN, max_c = INT_MIN;
        for (int32_t r = 0; r < g_board_size; ++r) {
            for (int32_t c = 0; c < g_board_size; ++c) {
                if (gs[g_board_size * r + c] != 0) {
                    if (r < min_r) min_r = r;
                    if (c < min_c) min_c = c;
                    if (r > max_r) max_r = r;
                    if (c > max_c) max_c = c;
                }
            }
        }
        
        if (min_r - 2 < 0) min_r = 2;
        if (min_c - 2 < 0) min_c = 2;
        if (max_r + 2 >= g_board_size) max_r = g_board_size - 3;
        if (max_c + 2 >= g_board_size) max_c = g_board_size - 3;
        
        // Loop through all cells
        for (int32_t r = min_r - 2; r <= max_r + 2; ++r) {
            for (int32_t c = min_c - 2; c <= max_c + 2; ++c) {
                // Consider only empty cells
                if (gs[g_board_size * r + c] != 0) continue;
                
                // Skip remote cells (no pieces within 2 cells)
                if (remoteCell(gs, g_board_size, r, c)) {
                    continue;
                }
                
                Move m;
                m.r = r;
                m.c = c;
                
                // Evaluate move
                m.heuristic_val = evalMove(controller, gs, g_board_size, r, c, player);
                
                // Add move
                result->push_back(m);
            }
        }
        std::sort(result->begin(), result->end());
    }

    int32_t RenjuAINegamax::negamax(RenjuAIController* controller, char *gs, int32_t g_board_size, int32_t player, int32_t depth, int32_t *move_r, int32_t *move_c) {
        // Initialize with a minimum score
        int32_t max_score = INT_MIN;
        
        // Eval game state
        if (depth == 0) {
            return evalState(controller, gs, g_board_size, player);
        }
        
        // Loop through all cells
        for (int32_t r = 0; r < g_board_size; ++r) {
            for (int32_t c = 0; c < g_board_size; ++c) {
                // Consider only empty cells
                if (getCell(gs, g_board_size, r, c) != 0){
                    continue;
                }
                
                // Skip remote cells (no pieces within 2 cells)
                if (remoteCell(gs, g_board_size, r, c)){
                    continue;
                }
                
                // Execute move
                setCell(gs, g_board_size, r, c, static_cast<char>(player));
                
                // Run negamax recursively
                int32_t s = -negamax(controller,
                                 gs,                   // Game state
                                 g_board_size,
                                 player == 1 ? 2 : 1,  // Change player
                                 depth - 1,            // Reduce depth by 1
                                 nullptr,              // Result move not required
                                 nullptr);
                
                // Restore
                setCell(gs, g_board_size, r, c, 0);
                
                // Update max score
                if (s > max_score) {
                    max_score = s;
                    if (move_r != nullptr) *move_r = r;
                    if (move_c != nullptr) *move_c = c;
                }
            }
        }
        return max_score;
    }
}
