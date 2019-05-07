//
//  1lib.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#define QUICK_BOARD_CODE

#include "weiqi_1lib.hpp"
#include "weiqi_selfatari.hpp"
#include "weiqi_ladder.hpp"
#include "weiqi_1lib.hpp"
#include "../../Platform.h"
#include "../weiqi_debug.hpp"

namespace weiqi
{
    // bo static
    inline bool capturing_group_is_snapback(struct board *b, group_t group)
    {
        coord_t lib = board_group_info(b, group)->lib[0];
        
        if (immediate_liberty_count(b, lib) > 0 ||
            group_stone_count(b, group, 2) > 1)
            return false;
        
        enum stone to_play = stone_other(board_at(b, group));
        enum stone other = stone_other(to_play);
        if (board_is_eyelike(b, lib, other))
            return false;
        
        foreach_neighbor(b, lib, {
            group_t g = group_at(b, c);
            if (board_at(b, c) == S_OFFBOARD || g == group)
                continue;
            
            if (board_at(b, c) == other &&
                board_group_info(b, g)->libs == 1)  // capture more than one group
                return false;
            if (board_at(b, c) == to_play &&
                board_group_info(b, g)->libs > 1)
                return false;
        });
        return true;
    }
    
    /* Whether to avoid capturing/atariing doomed groups (this is big
     * performance hit and may reduce playouts balance; it does increase
     * the strength, but not quite proportionally to the performance). */
    //#define NO_DOOMED_GROUPS
    
    // bo static
    inline bool can_capture(struct board *b, group_t g, enum stone to_play)
    {
        coord_t capture = board_group_info(b, g)->lib[0];
        if (DEBUGL(6)){
            char strCoord[256];
            {
                coord2sstr(strCoord, capture, b);
            }
            printf("can capture group %d (%s)?\n", g, strCoord);
        }
        /* Does playing on the liberty usefully capture the group? */
        if (board_is_valid_play(b, to_play, capture)
            && !capturing_group_is_snapback(b, g))
            return true;
        
        return false;
    }
    
    // bo static
    inline bool can_play_on_lib(struct board *b, group_t g, enum stone to_play)
    {
        coord_t capture = board_group_info(b, g)->lib[0];
        if (DEBUGL(6)){
            char strCoord[256];
            {
                coord2sstr(strCoord, capture, b);
            }
            printf("can capture group %d (%s)?\n", g, strCoord);
        }
        /* Does playing on the liberty usefully capture the group? */
        if (board_is_valid_play(b, to_play, capture) && !is_bad_selfatari(b, to_play, capture))
            return true;
        
        return false;
    }
    
    /* Checks snapbacks */
    bool can_countercapture(struct board *b, group_t group, struct move_queue *q, int32_t tag)
    {
        enum stone color = board_at(b, group);
        enum stone other = stone_other(color);
        {
            // assert(color == S_BLACK || color == S_WHITE);
            if(!(color == S_BLACK || color == S_WHITE)){
                printf("error, assert(color == S_BLACK || color == S_WHITE)\n");
            }
        }
        // Not checking b->clen, not maintained by board_quick_play()
        
        uint32_t qmoves_prev = q ? q->moves : 0;
        
        foreach_in_group(b, group) {
            foreach_neighbor(b, c, {
                group_t g = group_at(b, c);
                if (likely(board_at(b, c) != other
                           || board_group_info(b, g)->libs > 1) ||
                    !can_capture(b, g, color))
                    continue;
                
                if (!q)
                    return true;
                mq_add(q, board_group_info(b, group_at(b, c))->lib[0], tag);
                mq_nodup(q);
            });
        } foreach_in_group_end;
        
        bool can = q ? q->moves > qmoves_prev : false;
        return can;
    }
    
    bool can_countercapture_any(struct board *b, group_t group, struct move_queue *q, int32_t tag)
    {
        enum stone color = board_at(b, group);
        enum stone other = stone_other(color);
        {
            // assert(color == S_BLACK || color == S_WHITE);
            if(!(color == S_BLACK || color == S_WHITE)){
                printf("error, assert(color == S_BLACK || color == S_WHITE)\n");
            }
        }
        // Not checking b->clen, not maintained by board_quick_play()
        
        uint32_t qmoves_prev = q ? q->moves : 0;
        
        foreach_in_group(b, group) {
            foreach_neighbor(b, c, {
                group_t g = group_at(b, c);
                if (likely(board_at(b, c) != other
                           || board_group_info(b, g)->libs > 1))
                    continue;
                coord_t lib = board_group_info(b, g)->lib[0];
                if (!board_is_valid_play(b, color, lib))
                    continue;
                
                if (!q)
                    return true;
                mq_add(q, board_group_info(b, group_at(b, c))->lib[0], tag);
                mq_nodup(q);
            });
        } foreach_in_group_end;
        
        bool can = q ? q->moves > qmoves_prev : false;
        return can;
    }
    
    
#ifdef NO_DOOMED_GROUPS
    // bo static
    bool can_be_rescued(struct board *b, group_t group, enum stone color, int32_t tag)
    {
        /* Does playing on the liberty rescue the group? */
        if (can_play_on_lib(b, group, color))
            return true;
        
        /* Then, maybe we can capture one of our neighbors? */
        return can_countercapture(b, group, NULL, tag);
    }
#endif
    
    void group_atari_check(uint32_t alwaysccaprate, struct board *b, group_t group, enum stone to_play, struct move_queue *q, coord_t *ladder, bool middle_ladder, int32_t tag)
    {
        enum stone color = board_at(b, group_base(group));
        coord_t lib = board_group_info(b, group)->lib[0];
        
        {
            // assert(color != S_OFFBOARD && color != S_NONE);
            if(!(color != S_OFFBOARD && color != S_NONE)){
                printf("error, assert(color != S_OFFBOARD && color != S_NONE)\n");
            }
        }
        if (DEBUGL(5)){
            char strCoord1[256];
            {
                coord2sstr(strCoord1, group, b);
            }
            char strCoord2[256];
            {
                coord2sstr(strCoord2, lib, b);
            }
            printf("[%s] atariiiiiiiii %s of color %d\n", strCoord1, strCoord2, color);
        }
        {
            // assert(board_at(b, lib) == S_NONE);
            if(!(board_at(b, lib) == S_NONE)){
                printf("error, assert(board_at(b, lib) == S_NONE)\n");
            }
        }
        
        if (to_play != color) {
            /* We are the attacker! In that case, do not try defending
             * our group, since we can capture the culprit. */
#ifdef NO_DOOMED_GROUPS
            /* Do not remove group that cannot be saved by the opponent. */
            if (!can_be_rescued(b, group, color, tag))
                return;
#endif
            if (can_play_on_lib(b, group, to_play)) {
                mq_add(q, lib, tag);
                mq_nodup(q);
            }
            return;
        }
        
        /* Can we capture some neighbor? */
        /* XXX Attempts at using new can_countercapture() here failed so far.
         *     Could be because of a bug / under the stones situations
         *     (maybe not so uncommon in moggy ?) / it upsets moggy's balance somehow
         *     (there's always a chance opponent doesn't capture after taking snapback) */
        bool ccap = can_countercapture_any(b, group, q, tag);
        if (ccap && !ladder && alwaysccaprate > fast_random(100))
            return;
        
        /* Otherwise, do not save kos. */
        if (group_is_onestone(b, group) && neighbor_count_at(b, lib, color) + neighbor_count_at(b, lib, S_OFFBOARD) == 4) {
            /* Except when the ko is for an eye! */
            bool eyeconnect = false;
            board_statics* board_statics = &b->board_statics;
            foreach_diag_neighbor(board_statics, b, lib) {
                if (board_at(b, c) == S_NONE && neighbor_count_at(b, c, color) + neighbor_count_at(b, c, S_OFFBOARD) == 4) {
                    eyeconnect = true;
                    break;
                }
            } foreach_diag_neighbor_end;
            if (!eyeconnect)
                return;
        }
        
        /* Do not suicide... */
        if (!can_play_on_lib(b, group, to_play))
            return;
        if (DEBUGL(6))
            printf("...escape route valid\n");
        
        /* ...or play out ladders (unless we can counter-capture anytime). */
        if (!ccap) {
            if (is_ladder(b, lib, group, middle_ladder)) {
                /* Sometimes we want to keep the ladder move in the
                 * queue in order to discourage it. */
                if (!ladder)
                    return;
                else
                    *ladder = lib;
            } else if (DEBUGL(6))
                printf("...no ladder\n");
        }
        
        mq_add(q, lib, tag);
        mq_nodup(q);
    }
}
