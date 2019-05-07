//
//  nlib.cpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include "weiqi_nlib.hpp"
// #include "weiqi_debug.hpp"
#include "weiqi_2lib.hpp"

namespace weiqi
{
    void group_nlib_defense_check(struct board *b, group_t group, enum stone to_play, struct move_queue *q, int32_t tag)
    {
        enum stone color = to_play;
        {
            // assert(color != S_OFFBOARD && color != S_NONE && color == board_at(b, group_base(group)));
            if(!(color != S_OFFBOARD && color != S_NONE && color == board_at(b, group_base(group)))){
                printf("error, assert(color != S_OFFBOARD && color != S_NONE && color == board_at(b, group_base(group)))\n");
            }
        }
        
        if (DEBUGL(5)){
            char strCoord[256];
            {
                coord2sstr(strCoord, group, b);
            }
            printf("[%s] nlib defense check of color %d\n", strCoord, color);
        }
        
#if 0
        /* XXX: The code below is specific for 3-liberty groups. Its impact
         * needs to be tested first, and possibly moved to a more appropriate
         * place. */
        
        /* First, look at our liberties. */
        int32_t continuous = 0, enemy = 0, spacy = 0, eyes = 0;
        for (int32_t i = 0; i < 3; i++) {
            coord_t c = board_group_info(b, group).lib[i];
            eyes += board_is_one_point_eye(b, c, to_play);
            continuous += coord_is_adjecent(c, board_group_info(b, group).lib[(i + 1) % 3], b);
            enemy += neighbor_count_at(b, c, stone_other(color));
            spacy += immediate_liberty_count(b, c) > 1;
        }
        
        /* Safe groups are boring. */
        if (eyes > 1)
            return;
        
        /* If all our liberties are in single line and they are internal,
         * this is likely a tiny three-point eyespace that we rather want
         * to live at! */
        {
            // assert(continuous < 3);
            if(!(continuous < 3)){
                printf("error, assert(continuous < 3)\n");
            }
        }
        if (continuous == 2 && !enemy && spacy == 1) {
            {
                // assert(!eyes);
                if(eyes){
                    printf("error, assert(!eyes)\n");
                }
            }
            int32_t i;
            for (i = 0; i < 3; i++)
                if (immediate_liberty_count(b, board_group_info(b, group).lib[i]) == 2)
                    break;
            /* Play at middle point. */
            mq_add(q, board_group_info(b, group).lib[i], tag);
            mq_nodup(q);
            return;
        }
#endif
        
        /* "Escaping" (gaining more liberties) with many-liberty group
         * is difficult. Do not even try. */
        
        /* There is another way to gain safety - through winning semeai
         * with another group. */
        /* We will not look at taking liberties of enemy n-groups, since
         * we do not try to gain liberties for own n-groups. That would
         * be really unbalanced (and most of our liberty-taking moves
         * would be really stupid, most likely). */
        
        /* However, it is possible that we must start capturing a 2-lib
         * neighbor right now, because of approach liberties. Therefore,
         * we will check for this case. If we take a liberty of a group
         * even if we could have waited another move, no big harm done
         * either. */
        
        foreach_in_group(b, group) {
            foreach_neighbor(b, c, {
                if (board_at(b, c) != stone_other(color))
                    continue;
                group_t g2 = group_at(b, c);
                if (board_group_info(b, g2)->libs != 2)
                    continue;
                can_atari_group(b, g2, stone_other(color), to_play, q, tag, true /* XXX */);
            });
        } foreach_in_group_end;
    }
}
