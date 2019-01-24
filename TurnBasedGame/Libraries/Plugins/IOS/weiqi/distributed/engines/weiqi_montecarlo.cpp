//
//  montecarlo.cpp
//  weiqi
//
//  Created by Viet Tho on 4/2/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>

#include "../../../Platform.h"
#include "weiqi_montecarlo.hpp"

#include "../../weiqi_playout.hpp"
#include "../../playout/weiqi_light.hpp"
#include "../../weiqi_timeinfo.hpp"
#include "../../weiqi_debug.hpp"

/* FIXME: Cutoff rule for simulations. Currently we are so fast that this
 * simply does not matter; even 100000 simulations are fast enough to
 * play 5 minutes S.D. on 19x19 and anything more sounds too ridiculous
 * already. */
/* FIXME: We cannot handle seki. Any good ideas are welcome. A possibility is
 * to consider 'pass' among the moves, but this seems tricky. */

namespace weiqi
{
    // bo static
    void board_stats_print(struct board *board, struct move_stat *moves, FILE *f)
    {
        fprintf(f, "\n       ");
        int32_t x, y;
        char asdf[] = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        for (x = 1; x < board_size(board) - 1; x++)
            fprintf(f, "%c    ", asdf[x - 1]);
        fprintf(f, "\n   +-");
        for (x = 1; x < board_size(board) - 1; x++)
            fprintf(f, "-----");
        fprintf(f, "+\n");
        for (y = board_size(board) - 2; y >= 1; y--) {
            fprintf(f, "%2d | ", y);
            for (x = 1; x < board_size(board) - 1; x++)
                if (moves[y * board_size(board) + x].games)
                    fprintf(f, "%0.2f ", (floating_t) moves[y * board_size(board) + x].wins / moves[y * board_size(board) + x].games);
                else
                    fprintf(f, "---- ");
            fprintf(f, "| ");
            for (x = 1; x < board_size(board) - 1; x++)
                fprintf(f, "%4d ", moves[y * board_size(board) + x].games);
            fprintf(f, "|\n");
        }
        fprintf(f, "   +-");
        for (x = 1; x < board_size(board) - 1; x++)
            fprintf(f, "-----");
        fprintf(f, "+\n");
    }
    
    // bo static
    coord_t montecarlo_genmove(struct montecarlo* mc, struct board *b, struct time_info *ti, enum stone color, bool pass_all_alive)
    {
        if (ti->dim == TD_WALLTIME) {
            fprintf(stderr, "Warning: TD_WALLTIME time mode not supported, resetting to defaults.\n");
            ti->period = TT_NULL;
        }
        if (ti->period == TT_NULL) {
            ti->period = TT_MOVE;
            ti->dim = TD_GAMES;
            // ti->len.games = MC_GAMES;
            ti->len.games_max = 0;
        }
        printf("montecarlo_genmove: %d\n", ti->len.games);
        struct time_stop stop;
        time_stop_conditions(ti, b, 20, 40, 3.0, &stop);
        
        /* resign when the hope for win vanishes */
        coord_t top_coord = resign;
        floating_t top_ratio = mc->resign_ratio;
        
        /* We use [0] for pass. Normally, this is an inaccessible corner
         * of board margin. */
        struct move_stat* moves = new struct move_stat[board_size2(b)];
        memset(moves, 0, sizeof(struct move_stat)*board_size2(b));

        int32_t losses = 0;
        int32_t i, superko = 0, good_games = 0;
        for (i = 0; i < stop.desired.playouts; i++) {
            {
                // assert(!b->superko_violation);
                if(b->superko_violation){
                    printf("error, assert(!b->superko_violation)\n");
                }
            }
            
            struct board b2;
            board_copy(&b2, b);
            
            coord_t coord;
            board_play_random(&b2, color, &coord, NULL, NULL);
            if (!is_pass(coord) && !group_at(&b2, coord)) {
                /* Multi-stone suicide. We play chinese rules,
                 * so we can't consider this. (Note that we
                 * unfortunately still consider this in playouts.) */
                if (DEBUGL(4)) {
                    board_statics* board_statics = &b->board_statics;
                    printf("SUICIDE DETECTED at %d,%d:\n", coord_x(board_statics, coord, b), coord_y(board_statics, coord, b));
                    board_print(b, stderr);
                }
                continue;
            }
            
            if (DEBUGL(3)){
                board_statics* board_statics = &b->board_statics;
                fprintf(stderr, "[%d,%d color %d] playing random game\n", coord_x(board_statics, coord, b), coord_y(board_statics, coord, b), color);
            }
            
            struct playout_setup ps;
            {
                ps.gamelen = static_cast<unsigned int>(mc->gamelen);
            }
            int32_t result = play_random_game(&ps, &b2, color, NULL, NULL, mc->playout);
            
            board_done_noalloc(&b2);
            
            if (result == 0) {
                /* Superko. We just ignore this playout.
                 * And play again. */
                if (unlikely(superko > 2 * stop.desired.playouts)) {
                    /* Uhh. Triple ko, or something? */
                    if (MCDEBUGL(0)){
                        fprintf(stderr, "SUPERKO LOOP. I will pass. Did we hit triple ko?\n");
                    }
                    goto pass_wins;
                }
                /* This playout didn't count; we should not
                 * disadvantage moves that lead to a superko.
                 * And it is supposed to be rare. */
                i--, superko++;
                continue;
            }
            
            if (MCDEBUGL(3))
                fprintf(stderr, "\tresult for other player: %d\n", result);

            int32_t pos = is_pass(coord) ? 0 : coord;
            
            good_games++;
            moves[pos].games++;
            
            losses += result > 0;
            moves[pos].wins += 1 - (result > 0);
            
            if (unlikely(!losses && i == mc->loss_threshold)) {
                /* We played out many games and didn't lose once yet.
                 * This game is over. */
                break;
            }
        }
        
        if (!good_games) {
            /* No moves to try??? */
            if (MCDEBUGL(0)) {
                fprintf(stderr, "OUT OF MOVES! I will pass. But how did this happen?\n");
                board_print(b, stderr);
            }
        pass_wins:
            top_coord = pass; top_ratio = 0.5;
            goto move_found;
        }
        
        foreach_point(b) {
            if (b->moves < 3) {
                /* Simple heuristic: avoid opening too low. Do not
                 * play on second or first line as first white or
                 * first two black moves.*/
                board_statics* board_statics = &b->board_statics;
                if (coord_x(board_statics, c, b) < 3 || coord_x(board_statics, c, b) > board_size(b) - 4 || coord_y(board_statics, c, b) < 3 || coord_y(board_statics, c, b) > board_size(b) - 4)
                    continue;
            }
            
            floating_t ratio = (floating_t) moves[c].wins / moves[c].games;
            /* Since pass is [0,0], we will pass only when we have nothing
             * better to do. */
            if (ratio >= top_ratio) {
                top_ratio = ratio;
                top_coord = c == 0 ? pass : c;
            }
        } foreach_point_end;
        
        if (MCDEBUGL(2)) {
            board_stats_print(b, moves, stderr);
        }
        
    move_found:
        if (MCDEBUGL(1)){
            board_statics* board_statics = &b->board_statics;
            fprintf(stderr, "*** WINNER is %d,%d with score %1.4f (%d games, %d superko)\n", coord_x(board_statics, top_coord, b), coord_y(board_statics, top_coord, b), top_ratio, i, superko);
        }
        
        delete [] moves;
        return top_coord;
    }
    
    struct montecarlo* montecarlo_state_init(char *arg, struct board *b)
    {
        struct montecarlo* mc = (struct montecarlo*)calloc2(1, sizeof(struct montecarlo));
        
        mc->debug_level = 1;
        mc->gamelen = MC_GAMELEN;
        mc->jdict = joseki_load(b->size);
        
        if (arg) {
            char *optspec, *next = arg;
            while (*next) {
                optspec = next;
                next += strcspn(next, ",");
                if (*next) { *next++ = 0; } else { *next = 0; }
                
                char *optname = optspec;
                char *optval = strchr(optspec, '=');
                if (optval) *optval++ = 0;
                
                if (!strcasecmp(optname, "debug")) {
                    if (optval)
                        mc->debug_level = atoi(optval);
                    else
                        mc->debug_level++;
                } else if (!strcasecmp(optname, "gamelen") && optval) {
                    mc->gamelen = atoi(optval);
                } else if (!strcasecmp(optname, "playout") && optval) {
                    char *playoutarg = strchr(optval, ':');
                    if (playoutarg)
                        *playoutarg++ = 0;
                    if (!strcasecmp(optval, "moggy")) {
                        mc->playout = playout_moggy_init(playoutarg, b, mc->jdict);
                    } else if (!strcasecmp(optval, "light")) {
                        mc->playout = playout_light_init(playoutarg, b);
                    } else {
                        fprintf(stderr, "MonteCarlo: Invalid playout policy %s\n", optval);
                    }
                } else {
                    fprintf(stderr, "MonteCarlo: Invalid engine argument %s or missing value\n", optname);
                }
            }
        }
        
        if (!mc->playout){
            mc->playout = playout_light_init(NULL, b);
        }
        mc->playout->debug_level = mc->debug_level;
        
        mc->resign_ratio = 0.1; /* Resign when most games are lost. */
        mc->loss_threshold = 5000; /* Stop reading if no loss encountered in first 5000 games. */
        
        return mc;
    }
    
    // bo static
    void montecarlo_done(struct montecarlo* mc)
    {
        playout_policy_done(mc->playout);
        joseki_done(mc->jdict);
        free(mc);
    }
}
