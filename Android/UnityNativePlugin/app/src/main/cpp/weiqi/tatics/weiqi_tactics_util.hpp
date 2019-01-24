//
//  util.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_tactics_util_hpp
#define weiqi_tactics_util_hpp

#include <stdio.h>

/* Advanced tactical checks non-essential to the board implementation. */

#include "../../Platform.h"
#include "../weiqi_board.hpp"
#include "../weiqi_debug.hpp"
#include "../weiqi_mq.hpp"

namespace weiqi
{
    /* Checks if there are any stones in n-vincinity of coord. */
    bool board_stone_radar(struct board *b, coord_t coord, int32_t distance);
    
    /* Measure various distances on the board: */
    /* Distance from the edge; on edge returns 0. */
    // bo static
    inline int32_t coord_edge_distance(coord_t c, struct board *b)
    {
        board_statics* board_statics = &b->board_statics;
        int32_t x = coord_x(board_statics, c, b);
        int32_t y = coord_y(board_statics, c, b);
        int32_t dx = x > board_size(b) / 2 ? board_size(b) - 1 - x : x;
        int32_t dy = y > board_size(b) / 2 ? board_size(b) - 1 - y : y;
        return (dx < dy ? dx : dy) - 1 /* S_OFFBOARD */;
    }
    /* Distance of two points in gridcular metric - this metric defines
     * circle-like structures on the square grid. */
    // bo static
    inline int32_t coord_gridcular_distance(coord_t c1, coord_t c2, struct board *b)
    {
        board_statics* board_statics = &b->board_statics;
        int32_t dx = abs(coord_dx(board_statics, c1, c2, b));
        int32_t dy = abs(coord_dy(board_statics, c1, c2, b));
        return dx + dy + (dx > dy ? dx : dy);
    }
    
    /* Construct a "common fate graph" from given coordinate; that is, a weighted
     * graph of intersections where edges between all neighbors have weight 1,
     * but edges between neighbors of same color have weight 0. Thus, this is
     * "stone chain" metric in a sense. */
    /* The output are distances from start stored in given [board_size2()] array;
     * intersections further away than maxdist have all distance maxdist+1 set. */
    void cfg_distances(struct board *b, coord_t start, int32_t *distances, int32_t maxdist);
    
    /* Compute an extra komi describing the "effective handicap" black receives
     * (returns 0 for even game with 7.5 komi). @stone_value is value of single
     * handicap stone, 7 is a good default. */
    /* This is just an approximation since in reality, handicap seems to be usually
     * non-linear. */
    floating_t board_effective_handicap(struct board *b, int32_t first_move_value);
    
    /* Returns estimated number of remaining moves for one player until end of game. */
    int32_t board_estimated_moves_left(struct board *b);
    
    /* To avoid running out of time, assume we always have at least 30 more moves
     * to play if we don't have more precise information from gtp time_left: */
#define MIN_MOVES_LEFT 30
    
    /* Tactical evaluation of move @coord by color @color, given
     * simulation end position @b. I.e., a move is tactically good
     * if the resulting group stays on board until the game end.
     * The value is normalized to [0,1]. */
    /* We can also take into account surrounding stones, e.g. to
     * encourage taking off external liberties during a semeai. */
    // bo static
    inline double board_local_value(bool scan_neis, struct board *b, coord_t coord, enum stone color)
    {
        if (scan_neis) {
            /* Count surrounding friendly stones and our eyes. */
            int32_t friends = 0;
            foreach_neighbor(b, coord, {
                friends += board_at(b, c) == color || board_at(b, c) == S_OFFBOARD || board_is_one_point_eye(b, c, color);
            });
            return (double) (2 * (board_at(b, coord) == color) + friends) / 6.f;
        } else {
            return (board_at(b, coord) == color) ? 1.f : 0.f;
        }
    }
}

#endif /* util_hpp */
