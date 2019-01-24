//
//  ladder.cpp
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
#include "weiqi_dragon.hpp"
#include "weiqi_ladder.hpp"

namespace weiqi
{
    /* Read out middle ladder countercap sequences ? Otherwise we just
     * assume ladder doesn't work if countercapturing is possible. */
#define MIDDLE_LADDER_CHECK_COUNTERCAP 1
    
    
    bool is_border_ladder(struct board *b, coord_t coord, group_t laddered, enum stone lcolor)
    {
        if (can_countercapture(b, laddered, NULL, 0))
            return false;
        
        board_statics* board_statics = &b->board_statics;
        int32_t x = coord_x(board_statics, coord, b);
        int32_t y = coord_y(board_statics, coord, b);
        // printf("is_border_ladder: %d (%d, %d)\n", coord, x, y);
        
        if (DEBUGL(5))
            printf("border ladder\n");
        /* Direction along border; xd is horiz. border, yd vertical. */
        int32_t xd = 0, yd = 0;
        if (board_atxy(b, x + 1, y) == S_OFFBOARD || board_atxy(b, x - 1, y) == S_OFFBOARD)
            yd = 1;
        else
            xd = 1;
        /* Direction from the border; -1 is above/left, 1 is below/right. */
        int32_t dd = (board_atxy(b, x + yd, y + xd) == S_OFFBOARD) ? 1 : -1;
        if (DEBUGL(6))
            printf("xd %d yd %d dd %d\n", xd, yd, dd);
        /* | ? ?
         * | . O #
         * | c X #
         * | . O #
         * | ? ?   */
        /* This is normally caught, unless we have friends both above
         * and below... */
        if (board_atxy(b, x + xd * 2, y + yd * 2) == lcolor
            && board_atxy(b, x - xd * 2, y - yd * 2) == lcolor)
            return false;
        
        /* ...or can't block where we need because of shortage
         * of liberties. */
        group_t g1 = group_atxy(b, x + xd - yd * dd, y + yd - xd * dd);
        int32_t libs1 = board_group_info(b, g1).libs;
        group_t g2 = group_atxy(b, x - xd - yd * dd, y - yd - xd * dd);
        int32_t libs2 = board_group_info(b, g2).libs;
        if (DEBUGL(6))
            printf("libs1 %d libs2 %d\n", libs1, libs2);
        /* Already in atari? */
        if (libs1 < 2 || libs2 < 2)
            return false;
        /* Would be self-atari? */
        if (libs1 < 3 && (board_atxy(b, x + xd * 2, y + yd * 2) != S_NONE
                          || coord_is_adjecent(board_group_info(b, g1).lib[0], board_group_info(b, g1).lib[1], b)))
            return false;
        if (libs2 < 3 && (board_atxy(b, x - xd * 2, y - yd * 2) != S_NONE
                          || coord_is_adjecent(board_group_info(b, g2).lib[0], board_group_info(b, g2).lib[1], b)))
            return false;
        return true;
    }
    
    // bo static
    int32_t middle_ladder_walk(struct board *b, group_t laddered, enum stone lcolor, struct move_queue *prev_ccq, coord_t prevmove, int32_t len);
    
    // bo static
    int32_t middle_ladder_chase(struct board *b, group_t laddered, enum stone lcolor, struct move_queue *ccq, coord_t prevmove, int32_t len)
    {
        laddered = group_at(b, laddered);
        
        /*if (DEBUGL(8)) {
         board_print(b, stderr);
         char strCoord[256];
         {
         coord2sstr(strCoord, laddered, b);
         }
         printf("%s c %d\n", strCoord, board_group_info(b, laddered).libs);
         }*/
        
        if (!laddered || board_group_info(b, laddered).libs == 1) {
            /*if (DEBUGL(6))
             printf("* we can capture now\n");*/
            return len;
        }
        if (board_group_info(b, laddered).libs > 2) {
            /*if (DEBUGL(6))
             printf("* we are free now\n");*/
            return 0;
        }
        
        /* Now, consider alternatives. */
        int32_t liblist[2], libs = 0;
        for (int32_t i = 0; i < 2; i++) {
            coord_t ataristone = board_group_info(b, laddered).lib[i];
            coord_t escape = board_group_info(b, laddered).lib[1 - i];
            {
                /*if (immediate_liberty_count(b, escape) > 2 + coord_is_adjecent(ataristone, escape, b)) {
                 // Too much free space, ignore.
                 continue;
                 }*/
                int32_t immediateLibertyCount = immediate_liberty_count(b, escape);
                int32_t coordIsAdjecent = coord_is_adjecent(ataristone, escape, b);
                if(immediateLibertyCount > 2+coordIsAdjecent){
                    continue;
                }
            }
            liblist[libs++] = i;
        }
        
        /* Try more promising one first */
        if (libs == 2 && immediate_liberty_count(b, board_group_info(b, laddered).lib[0]) <
            immediate_liberty_count(b, board_group_info(b, laddered).lib[1])) {
            liblist[0] = 1; liblist[1] = 0;
        }
        
        /* Try out the alternatives. */
        for (int32_t i = 0; i < libs; i++) {
            coord_t ataristone = board_group_info(b, laddered).lib[liblist[i]];
            
            with_move(b, ataristone, stone_other(lcolor), {
                /* If we just played self-atari, abandon ship. */
                if (board_group_info(b, group_at(b, ataristone)).libs <= 1)
                    break;
                
                /*if (DEBUGL(6)){
                 char strCoord[256];
                 {
                 coord2sstr(strCoord, ataristone, b);
                 }
                 printf("(%d=0) ladder atari %s (%d libs)\n", i, strCoord, board_group_info(b, group_at(b, ataristone)).libs);
                 }*/

                int32_t l = middle_ladder_walk(b, laddered, lcolor, ccq, prevmove, len);
                if (l) {
/*#ifndef Android
                    with_move_return(l);
#else
                    
#endif*/
                    int32_t val_ = l;
                    do { int32_t val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0);
                }
            });
            
        }
        
        return 0;
    }
    
    // bo static
    void add_chaser_captures(struct board *b, group_t laddered, enum stone lcolor, struct move_queue *ccq,
                             coord_t nextmove)
    {
        foreach_neighbor(b, nextmove, {
            if (board_at(b, c) == stone_other(lcolor) && board_group_info(b, group_at(b, c)).libs == 1) {
                /* Ladder stone we can capture later, add it to the list */
                coord_t lib = board_group_info(b, group_at(b, c)).lib[0];
                /*if (DEBUGL(6)){
                 char strCoord[256];
                 {
                 coord2sstr(strCoord, lib, b);
                 }
                 printf("adding potential chaser capture %s\n", strCoord);
                 }*/
                mq_add(ccq, lib, 0);
            }
        });
    }
    
    /* Can we escape by capturing chaser ? */
    // bo static
    bool chaser_capture_escapes(struct board *b, group_t laddered, enum stone lcolor, struct move_queue *ccq)
    {
        for (uint32_t i = 0; i < ccq->moves; i++) {
            coord_t lib = ccq->move[i];
            if (!board_is_valid_play(b, lcolor, lib))
                continue;
            
#ifndef MIDDLE_LADDER_CHECK_COUNTERCAP
            return true;
#endif
            
            /* We can capture one of the ladder stones, investigate ... */
            /*if (DEBUGL(6)) {
             char strCoord[256];
             {
             coord2sstr(strCoord, lib, b);
             }
             printf("------------- can capture chaser, investigating %s -------------\n", strCoord);
             board_print(b, stderr);
             }*/
            
            with_move_strict(b, lib, lcolor, {
                if (!middle_ladder_chase(b, laddered, lcolor, ccq, lib, 0)) {
/*#ifndef Android
                    with_move_return(true); // escape !
#else
                    
#endif*/
                    bool val_ = true;
                    do {  bool val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0);
                }
            });
            
            /*if (DEBUGL(6)){
             char strCoord[256];
             {
             coord2sstr(strCoord, lib, b);
             }
             printf("-------------------------- done %s ------------------------------\n", strCoord);
             }*/
        }
        
        return false;
    }
    
    
    /* This is a rather expensive ladder reader. It can read out any sequences
     * where laddered group should be kept at two liberties. The recursion
     * always makes a "to-be-laddered" move and then considers the chaser's
     * two alternatives (usually, one of them is trivially refutable). The
     * function returns true if there is a branch that ends up with laddered
     * group captured, false if not (i.e. for each branch, laddered group can
     * gain three liberties). */
    // bo static
    int32_t middle_ladder_walk(struct board *b, group_t laddered, enum stone lcolor, struct move_queue *prev_ccq, coord_t prevmove, int32_t len)
    {
        {
            // assert(board_group_info(b, laddered).libs == 1);
            if(!(board_group_info(b, laddered).libs == 1)){
                printf("error, assert(board_group_info(b, laddered).libs == 1)\n");
            }
        }
        
        /* Check ko */
        if (b->ko.coord != pass)
            foreach_neighbor(b, b->last_move.coord, {
                if (group_at(b, c) == laddered) {
                    /*if (DEBUGL(6))
                     printf("* ko, no ladder\n");*/
                    return 0;
                }
            });
        
        /* Check countercaptures */
        if(prev_ccq==NULL || prev_ccq==nullptr){
            printf("error, why prev_ccq null\n");
            return 0;
        }
        struct move_queue ccq = *prev_ccq;
        if (prevmove != pass)
            add_chaser_captures(b, laddered, lcolor, &ccq, prevmove);
        if (chaser_capture_escapes(b, laddered, lcolor, &ccq))
            return 0;
        
        /* Escape then */
        coord_t nextmove = board_group_info(b, laddered).lib[0];
        /*if (DEBUGL(6)){
         char strCoord[256];
         {
         coord2sstr(strCoord, nextmove, b);
         }
         printf("  ladder escape %s\n", strCoord);
         }*/
        with_move_strict(b, nextmove, lcolor, {
            len = middle_ladder_chase(b, laddered, lcolor, &ccq, nextmove, len + 1);
        });
        
        return len;
    }
    
    // TODO cai length nay can xem xet lai: co le nen cho vao board
    // static __thread int32_t length = 0;
    
    bool is_middle_ladder(struct board *b, coord_t coord, group_t laddered, enum stone lcolor)
    {
        /* TODO: Remove the redundant parameters. */
        {
            // assert(board_group_info(b, laddered).libs == 1);
            if(!(board_group_info(b, laddered).libs == 1)){
                printf("error, assert(board_group_info(b, laddered).libs == 1)\n");
            }
        }
        {
            // assert(board_group_info(b, laddered).lib[0] == coord);
            if(!(board_group_info(b, laddered).lib[0] == coord)){
                printf("error, assert(board_group_info(b, laddered).lib[0] == coord)\n");
            }
        }
        {
            // assert(board_at(b, laddered) == lcolor);
            if(!(board_at(b, laddered) == lcolor)){
                printf("error, assert(board_at(b, laddered) == lcolor)\n");
            }
        }
        
        /* If we can move into empty space or do not have enough space
         * to escape, this is obviously not a ladder. */
        if (immediate_liberty_count(b, coord) != 2) {
            /*if (DEBUGL(5))
             printf("no ladder, wrong free space\n");*/
            return false;
        }
        
        /* A fair chance for a ladder. Group in atari, with some but limited
         * space to escape. Time for the expensive stuff - play it out and
         * start selective 2-liberty search. */
        
        /* We could escape by countercapturing a group. */
        struct move_queue ccq;
        {
            ccq.moves = 0;
        }
        can_countercapture(b, laddered, &ccq, 0);
        
        b->length = middle_ladder_walk(b, laddered, lcolor, &ccq, pass, 0);
        
        /*if (DEBUGL(6) && b->length) {
         printf("is_ladder(): stones: %i  length: %i\n", group_stone_count(b, laddered, 50), b->length);
         }*/
        
        return (b->length != 0);
    }
    
    bool is_middle_ladder_any(struct board *b, coord_t coord, group_t laddered, enum stone lcolor)
    {
        /* TODO: Remove the redundant parameters. */
        {
            // assert(board_group_info(b, laddered).libs == 1);
            if(!(board_group_info(b, laddered).libs == 1)){
                printf("error, assert(board_group_info(b, laddered).libs == 1)\n");
            }
        }
        {
            // assert(board_group_info(b, laddered).lib[0] == coord);
            if(!(board_group_info(b, laddered).lib[0] == coord)){
                printf("error, assert(board_group_info(b, laddered).lib[0] == coord)\n");
            }
        }
        {
            // assert(board_at(b, laddered) == lcolor);
            if(!(board_at(b, laddered) == lcolor)){
                printf("error, assert(board_at(b, laddered) == lcolor)\n");
            }
        }
        
        /* We could escape by countercapturing a group. */
        struct move_queue ccq;
        {
            ccq.moves = 0;
        }
        can_countercapture(b, laddered, &ccq, 0);
        
        b->length = middle_ladder_walk(b, laddered, lcolor, &ccq, pass, 0);
        return (b->length != 0);
    }
    
    bool wouldbe_ladder(struct board *b, group_t group, coord_t escapelib, coord_t chaselib, enum stone lcolor)
    {
        {
            // assert(board_group_info(b, group).libs == 2);
            if(!(board_group_info(b, group).libs == 2)){
                printf("error, assert(board_group_info(b, group).libs == 2)\n");
            }
        }
        {
            // assert(board_at(b, group) == lcolor);
            if(!(board_at(b, group) == lcolor)){
                printf("error, assert(board_at(b, group) == lcolor)\n");
            }
        }
        
        /*if (DEBUGL(6)){
         char strStone[20];
         {
         stone2str(strStone, lcolor);
         }
         char strCoord1[256];
         {
         coord2sstr(strCoord1, escapelib, b);
         }
         char strCoord2[256];
         {
         coord2sstr(strCoord2, chaselib, b);
         }
         printf("would-be ladder check - does %s %s play out chasing move %s?\n", strStone, strCoord1, strCoord2);
         }*/
        
        if (!coord_is_8adjecent(escapelib, chaselib, b)) {
            /*if (DEBUGL(5))
             printf("cannot determine ladder for remote simulated stone\n");*/
            return false;
        }
        
        if (neighbor_count_at(b, chaselib, lcolor) != 1 || immediate_liberty_count(b, chaselib) != 2) {
            /*if (DEBUGL(5))
             printf("overly trivial for a ladder\n");*/
            return false;
        }
        
        bool is_ladder = false;
        with_move(b, chaselib, stone_other(lcolor), {
            is_ladder = is_middle_ladder_any(b, board_group_info(b, group).lib[0], group, lcolor);
        });
        
        return is_ladder;
    }
    
    
    bool wouldbe_ladder_any(struct board *b, group_t group, coord_t escapelib, coord_t chaselib, enum stone lcolor)
    {
        {
            // assert(board_group_info(b, group).libs == 2);
            if(!(board_group_info(b, group).libs == 2)){
                printf("error, assert(board_group_info(b, group).libs == 2)\n");
            }
        }
        {
            // assert(board_at(b, group) == lcolor);
            if(!(board_at(b, group) == lcolor)){
                printf("error, assert(board_at(b, group) == lcolor)\n");
            }
        }
        
        if (!board_is_valid_play(b, stone_other(lcolor), chaselib) ||
            is_selfatari(b, stone_other(lcolor), chaselib) )   // !can_play_on_lib() sortof
            return false;
        
        bool ladder = false;
        with_move(b, chaselib, stone_other(lcolor), {
            {
                // assert(group_at(b, group) == group);
                if(!(group_at(b, group) == group)){
                    printf("error, assert(group_at(b, group) == group)\n");
                }
            }
            ladder = is_ladder_any(b, escapelib, group, true);
        });
        
        return ladder;
    }
    
    /* Laddered group can't escape, but playing it out could still be useful.
     *
     *      . . . * . . .    For example, life & death:
     *      X O O X O O X
     *      X X O O O X X
     *          X X X
     *
     * Try to weed out as many useless moves as possible while still allowing these ...
     * Call right after is_ladder() succeeded, uses static state.
     *
     * XXX can also be useful in other situations ? Should be pretty rare hopefully */
    bool useful_ladder(struct board *b, group_t laddered)
    {
        if (b->length >= 4 ||
            group_stone_count(b, laddered, 6) > 5 ||
            neighbor_is_safe(b, laddered))
            return false;
        
        coord_t lib = board_group_info(b, laddered).lib[0];
        enum stone lcolor = board_at(b, laddered);
        
        /* Check capturing group is surrounded */
        with_move(b, lib, stone_other(lcolor), {
            {
                // assert(!group_at(b, laddered));
                if(group_at(b, laddered)){
                    printf("error, assert(!group_at(b, laddered))\n");
                }
            }
            if (!dragon_is_surrounded(b, lib)) {
/*#ifndef Android
                with_move_return(false);
#else
                
#endif*/
                bool val_ = false;
                do {  bool val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0);
            }
        });
        
        /* Group safe even after escaping + capturing us ? */
        // XXX can need to walk ladder twice to become useful ...
        bool still_safe = false, cap_ok = false;
        with_move(b, lib, lcolor, {
            if (!group_at(b, lib))
                break;
            
            group_t g = group_at(b, lib);
            // Try diff move order, could be suicide !
            for (int32_t i = 0; !cap_ok && i < board_group_info(b, g).libs; i++) {
                coord_t cap = board_group_info(b, g).lib[i];
                with_move(b, cap, stone_other(lcolor), {
                    if (!group_at(b, lib) || !group_at(b, cap))
                        break;
                    coord_t cap = board_group_info(b, group_at(b, lib)).lib[0];
                    with_move(b, cap, stone_other(lcolor), {
                        {
                            // assert(!group_at(b, lib));
                            if(group_at(b, lib)){
                                printf("error, assert(!group_at(b, lib))\n");
                            }
                        }
                        cap_ok = true;
                        still_safe = dragon_is_safe(b, group_at(b, cap), stone_other(lcolor));
                    });
                });
            }
        });
        if (still_safe)
            return false;
        
        /* Does it look useful as selfatari ? */
        foreach_neighbor(b, lib, {
            if (board_at(b, c) != S_NONE)
                continue;
            with_move(b, c, stone_other(lcolor), {
                if (board_group_info(b, group_at(b, c)).libs - 1 <= 1)
                    break;
                if (!is_bad_selfatari(b, lcolor, lib)){
/*#ifndef Android
                        with_move_return(true);
#else
                    
#endif*/
                    bool val_ = true;
                    do {  bool val__ = (val_); board_quick_undo(board__, &m_, &u_); return val__;  } while (0);
                }
            });
        });
        return false;
    }
    
    // bo static
    bool is_double_atari(struct board *b, coord_t c, enum stone color)
    {
        if (board_at(b, c) != S_NONE ||
            immediate_liberty_count(b, c) < 2 ||  /* can't play there (hack) */
            neighbor_count_at(b, c, stone_other(color)) != 2)
            return false;

        int32_t ataris = 0;
        foreach_neighbor(b, c, {
            if (board_at(b, c) == stone_other(color) &&
                board_group_info(b, group_at(b, c)).libs == 2)
                ataris++;
        });
        
        return (ataris >= 2);
    }
    
    // bo static
    bool ladder_with_tons_of_double_ataris(struct board *b, group_t laddered, enum stone color)
    {
        {
            // assert(board_at(b, laddered) == stone_other(color));
            if(!(board_at(b, laddered) == stone_other(color))){
                printf("error, assert(board_at(b, laddered) == stone_other(color))\n");
            }
        }

        int32_t double_ataris = 0;
        board_statics* board_statics = &b->board_statics;
        foreach_in_group(b, laddered) {
            coord_t stone = c;
            foreach_diag_neighbor(board_statics, b, stone) {
                if (is_double_atari(b, c, stone_other(color)))
                    double_ataris++;
            } foreach_diag_neighbor_end;
        } foreach_in_group_end;
        
        return (double_ataris >= 2);
    }
    
    bool harmful_ladder_atari(struct board *b, coord_t atari, enum stone color)
    {
        {
            // assert(board_at(b, atari) == S_NONE);
            if(!(board_at(b, atari) == S_NONE)){
                printf("error, assert(board_at(b, atari) == S_NONE)\n");
            }
        }
        
        if (neighbor_count_at(b, atari, stone_other(color)) != 1)
            return false;
        
        foreach_neighbor(b, atari, {
            if (board_at(b, c) != stone_other(color))
                continue;
            group_t g = group_at(b, c);
            if (board_group_info(b, g).libs != 2)
                continue;
            
            coord_t escape = board_group_other_lib(b, g, atari);
            if (ladder_with_tons_of_double_ataris(b, g, color) &&              // getting ugly ...
                !wouldbe_ladder_any(b, g, escape, atari, stone_other(color)))  // and non-working ladder
                return true;
        });
        
        return false;
    }
}
