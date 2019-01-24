//
//  ownermap.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_ownermap_hpp
#define weiqi_ownermap_hpp

/* Map of board intersection owners, and devices to derive group status
 * information from the map. */

#include <stdio.h>
#include <signal.h> // sig_atomic_t
#include "weiqi_board.hpp"

namespace weiqi
{
    /* How big proportion of ownermap counts must be of one color to consider
     * the point sure. */
#define GJ_THRES	0.8
    
    struct board_ownermap {
        /* Map of final owners of all intersections on the board. */
        /* This may be shared between multiple threads! */
        /* XXX: We assume sig_atomic_t is thread-atomic. This may not
         * be true in pathological cases. */
        sig_atomic_t playouts;
        /* At the final board position, for each coordinate increase the
         * counter of appropriate color. */
        sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];
    };
    
    void board_ownermap_init(struct board_ownermap *ownermap);
    void board_print_ownermap(struct board *b, FILE *f, struct board_ownermap *ownermap);
    void board_ownermap_fill(struct board_ownermap *ownermap, struct board *b);
    void board_ownermap_merge(int32_t bsize2, struct board_ownermap *dst, struct board_ownermap *src);
    
    void board_print_ownermap(struct board *b, char *f, struct board_ownermap *ownermap);
    
    /* Estimate coord ownership based on ownermap stats. */
    enum point_judgement {
        PJ_DAME = S_NONE,
        PJ_BLACK = S_BLACK,
        PJ_WHITE = S_WHITE,
        PJ_UNKNOWN = 3,
    };
    enum point_judgement board_ownermap_judge_point(struct board_ownermap *ownermap, coord_t c, floating_t thres);
    float board_ownermap_estimate_point(struct board_ownermap *ownermap, coord_t c);
    
    
    /* Estimate status of stones on board based on ownermap stats. */
    enum gj_state {
        GS_NONE,
        GS_DEAD,
        GS_ALIVE,
        GS_UNKNOWN,
    };
    
    struct group_judgement {
        floating_t thres;
        gj_state *gs; // [bsize2]
    };
    void board_ownermap_judge_groups(struct board *b, struct board_ownermap *ownermap, struct group_judgement *judge);
    
    /* Add groups of given status to mq. */
    struct move_queue;
    void groups_of_status(struct board *b, struct group_judgement *judge, enum gj_state s, struct move_queue *mq);
    
    /* Score estimate based on board ownermap. (positive: W wins) */
    float board_ownermap_score_est(struct board *b, struct board_ownermap *ownermap);
    void board_ownermap_score_est_str(char* ret, struct board *b, struct board_ownermap *ownermap);
    enum point_judgement board_ownermap_score_est_coord(struct board *b, struct board_ownermap *ownermap, coord_t c);
}

#endif /* ownermap_hpp */
