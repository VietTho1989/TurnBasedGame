//
//  util.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_tactics_util.hpp"

namespace weiqi
{
    bool board_stone_radar(struct board *b, coord_t coord, int32_t distance)
    {
        board_statics* board_statics = &b->board_statics;
        int32_t bounds[4] = {
            coord_x(board_statics, coord, b) - distance,
            coord_y(board_statics, coord, b) - distance,
            coord_x(board_statics, coord, b) + distance,
            coord_y(board_statics, coord, b) + distance
        };
        // printf("board_stone_radar: %d, %d, %d, %d\n", bounds[0], bounds[1], bounds[2], bounds[3]);
        for (int32_t i = 0; i < 4; i++)
            if (bounds[i] < 1)
                bounds[i] = 1;
            else if (bounds[i] > board_size(b) - 2)
                bounds[i] = board_size(b) - 2;
        for (int32_t x = bounds[0]; x <= bounds[2]; x++)
            for (int32_t y = bounds[1]; y <= bounds[3]; y++)
                if (board_atxy(b, x, y) != S_NONE) {
                    /* printf("radar %d,%d,%d: %d,%d (%d)\n", coord_x(coord, b), coord_y(coord, b), distance, x, y, board_atxy(b, x, y)); */
                    return true;
                }
        return false;
    }
    
    void cfg_distances(struct board *b, coord_t start, int32_t *distances, int32_t maxdist)
    {
        /* Queue for d+1 spots; no two spots of the same group
         * should appear in the queue. */
#define qinc(x) (x = ((x + 1) >= board_size2(b) ? ((x) + 1 - board_size2(b)) : (x) + 1))
        
        coord_t* queue = new coord_t[board_size2(b)];
        
        int32_t qstart = 0,
        qstop = 0;
        
        foreach_point(b) {
            distances[c] = board_at(b, c) == S_OFFBOARD ? maxdist + 1 : -1;
        } foreach_point_end;
        
        queue[qstop++] = start;
        for (int32_t d = 0; d <= maxdist; d++) {
            /* Process queued moves, while setting the queue
             * for new wave. */
            int32_t qa = qstart, qb = qstop;
            qstart = qstop;
            for (int32_t q = qa; q < qb; qinc(q)) {
#define cfg_one(coord, grp) do {\
distances[coord] = d; \
foreach_neighbor (b, coord, { \
if (distances[c] < 0 && (!grp || group_at(b, coord) != grp)) { \
queue[qstop] = c; \
qinc(qstop); \
} \
}); \
} while (0)
                coord_t cq = queue[q];
                if(cq>=0){
                    // printf("normal cq: %d\n", cq);
                    if (distances[cq] >= 0)
                        continue; /* We already looked here. */
                    if (board_at(b, cq) == S_NONE) {
                        cfg_one(cq, 0);
                    } else {
                        group_t g = group_at(b, cq);
                        foreach_in_group(b, g) {
                            cfg_one(c, g);
                        } foreach_in_group_end;
                    }
                } else {
                    // printf("error, why cq < 0\n");
                }
#undef cfg_one
            }
        }
        
        foreach_point(b) {
            if (distances[c] < 0)
                distances[c] = maxdist + 1;
        } foreach_point_end;
        
        delete [] queue;
    }
    
    floating_t board_effective_handicap(struct board *b, int32_t first_move_value)
    {
        /* This can happen if the opponent passes during handicap
         * placing phase. */
        // assert(b->handicap != 1);
        
        /* Always return 0 for even games, in particular if
         * first_move_value is set on purpose to a value different
         * from the correct theoretical value (2*komi). */
        if (!b->handicap)
            return b->komi == 0.5 ? 0.5 * first_move_value : 7.5 - b->komi;
        return b->handicap * first_move_value + 0.5 - b->komi;
    }
    
    /* On average 20% of points remain empty at the end of a game */
#define EXPECTED_FINAL_EMPTY_PERCENT 20
    
    /* Returns estimated number of remaining moves for one player until end of game. */
    int32_t board_estimated_moves_left(struct board *b)
    {
        int32_t total_points = (board_size(b)-2)*(board_size(b)-2);
        int32_t moves_left = (b->flen - total_points*EXPECTED_FINAL_EMPTY_PERCENT/100)/2;
        return moves_left > MIN_MOVES_LEFT ? moves_left : MIN_MOVES_LEFT;
    }
}
