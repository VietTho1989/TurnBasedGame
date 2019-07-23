//
//  playout.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "weiqi_board.hpp"
#include "weiqi_debug.hpp"
#include "weiqi_move.hpp"
#include "weiqi_ownermap.hpp"
#include "weiqi_playout.hpp"

namespace weiqi
{
    /* Whether to set global debug level to the same as the playout
     * has, in case it is different. This can make sure e.g. tactical
     * reading produces proper level of debug prints during simulations.
     * But it is safe to enable this only in single-threaded instances! */
    //#define DEBUGL_BY_PLAYOUT
    
#define PLDEBUGL(n) DEBUGL_(policy->debug_level, n)
    
    /* Full permit logic, ie m->coord may get changed to an alternative move */
    // bo static
    bool playout_permit_move(struct playout_policy *p, struct board *b, struct move *m, bool alt)
    {
        coord_t coord = m->coord;
        if (coord == pass || coord == resign)
            return false;
        
        if (!board_permit(b, m, NULL) ||
            (p->permit && !p->permit(p, b, m, alt)))
            return false;
        
        return true;
    }
    
    /* Return coord if move is ok, an alternative move or pass if not */
    // bo static
    coord_t playout_check_move(struct playout_policy *p, struct board *b, coord_t coord, enum stone color)
    {
        struct move m;
        {
            m.coord = coord;
            m.color = color;
        }
        if (!playout_permit_move(p, b, &m, 1))
            return pass;
        return m.coord;
    }
    
    /* Is *this* move permitted ?
     * Called by policy permit() to check something so never the main permit() call. */
    bool playout_permit(struct playout_policy *p, struct board *b, coord_t coord, enum stone color)
    {
        struct move m;
        {
            m.coord = coord;
            m.color = color;
        }
        return playout_permit_move(p, b, &m, 0);
    }
    
    // bo static
    bool permit_handler(struct board *b, struct move *m, void *data)
    {
        struct playout_policy* policy = (struct playout_policy*)data;
        return playout_permit_move(policy, b, m, 1);
    }
    
    coord_t play_random_move(struct playout_setup *setup, struct board *b, enum stone color, struct playout_policy *policy)
    {
        coord_t coord = pass;
        
        if (setup->prepolicy_hook) {
            coord = setup->prepolicy_hook(policy, setup, b, color);
            // printf("prehook: %s\n", coord2sstr(coord, b));
        }
        
        if (is_pass(coord)) {
            coord = policy->choose(policy, setup, b, color);
            coord = playout_check_move(policy, b, coord, color);
            // printf("policy: %s\n", coord2sstr(coord, b));
        }
        
        if (is_pass(coord) && setup->postpolicy_hook) {
            coord = setup->postpolicy_hook(policy, setup, b, color);
            // printf("posthook: %s\n", coord2sstr(coord, b));
        }
        
        if (is_pass(coord)) {
        play_random:
            /* Defer to uniformly random move choice. */
            /* This must never happen if the policy is tracking
             * internal board state, obviously. */
            {
                // assert(!policy->setboard || policy->setboard_randomok);
                if(!(!policy->setboard || policy->setboard_randomok)){
                    printf("error, assert(!policy->setboard || policy->setboard_randomok)\n");
                }
            }
            board_play_random(b, color, &coord, permit_handler, policy);
            
        } else {
            struct move m;
            {
                m.coord = coord;
                m.color = color;
            }
            if (board_play(b, &m) < 0) {
                if (PLDEBUGL(4)) {
                    {
                        board_statics* board_statics = &b->board_statics;
                        printf("Pre-picked move %d,%d is ILLEGAL:\n", coord_x(board_statics, coord, b), coord_y(board_statics, coord, b));
                    }
                    board_print(b, stderr);
                }
                goto play_random;
            }
        }
        
        return coord;
    }

    int32_t play_random_game(struct playout_setup *setup, struct board *b, enum stone starting_color, struct playout_amafmap *amafmap, struct board_ownermap *ownermap, struct playout_policy *policy)
    {
        {
            // assert(setup && policy);
            if(!(setup && policy)){
                printf("error, assert(setup && policy)\n");
                // setup = 1;
                // policy = 1;
                return pass;
            }
        }

        int32_t gamelen = setup->gamelen - b->moves;
        
        if (policy->setboard)
            policy->setboard(policy, b);
#ifdef DEBUGL_BY_PLAYOUT
        int32_t debug_level_orig = debug_level;
        debug_level = policy->debug_level;
#endif
        
        enum stone color = starting_color;

        int32_t passes = is_pass(b->last_move.coord) && b->moves > 0;
        
        while (gamelen-- && passes < 2) {
            coord_t coord = play_random_move(setup, b, color, policy);
            
#if 0
            /* For UCT, superko test here is downright harmful since
             * in superko-likely situation we throw away literally
             * 95% of our playouts; UCT will deal with this fine by
             * itself. */
            if (unlikely(b->superko_violation)) {
                /* We ignore superko violations that are suicides. These
                 * are common only at the end of the game and are
                 * rather harmless. (They will not go through as a root
                 * move anyway.) */
                if (group_at(b, coord)) {
                    if (DEBUGL(3)) {
                        printf("Superko fun at %d,%d in\n", coord_x(coord, b), coord_y(coord, b));
                        if (DEBUGL(4))
                            board_print(b, stderr);
                    }
                    return 0;
                } else {
                    if (DEBUGL(6)) {
                        printf("Ignoring superko at %d,%d in\n", coord_x(coord, b), coord_y(coord, b));
                        board_print(b, stderr);
                    }
                    b->superko_violation = false;
                }
            }
#endif
            
            if (PLDEBUGL(7)) {
                {
                    char strCoord[256];
                    {
                        coord2sstr(strCoord, coord, b);
                    }
                    char strStone[20];
                    {
                        stone2str(strStone, color);
                    }
                    printf("%s %s\n", strStone, strCoord);
                }
                if (PLDEBUGL(8))
                    board_print(b, stderr);
            }
            
            if (unlikely(is_pass(coord))) {
                passes++;
            } else {
                passes = 0;
            }
            if (amafmap) {
                {
                    // assert(amafmap->gamelen < MAX_GAMELEN);
                    if(!(amafmap->gamelen < MAX_GAMELEN)){
                        printf("error, assert(amafmap->gamelen < MAX_GAMELEN)\n");
                        amafmap->gamelen = MAX_GAMELEN - 1;
                    }
                }
                amafmap->is_ko_capture[amafmap->gamelen] = board_playing_ko_threat(b);
                amafmap->game[amafmap->gamelen++] = coord;
            }
            
            if (setup->mercymin && abs(b->captures[S_BLACK] - b->captures[S_WHITE]) > setup->mercymin)
                break;
            
            color = stone_other(color);
        }
        
        floating_t score = board_fast_score(b);
        int32_t result = (starting_color == S_WHITE ? score * 2 : - (score * 2));
        
        if (DEBUGL(6)) {
            printf("Random playout result: %d (W %f)\n", result, score);
            if (DEBUGL(7))
                board_print(b, stderr);
        }
        
        if (ownermap)
            board_ownermap_fill(ownermap, b);
        
#ifdef DEBUGL_BY_PLAYOUT
        debug_level = debug_level_orig;
#endif
        
        return result;
    }
    
    void playout_policy_done(struct playout_policy *p)
    {
        if (p->done) p->done(p);
        if (p->data) free(p->data);
        free(p);
    }
}
