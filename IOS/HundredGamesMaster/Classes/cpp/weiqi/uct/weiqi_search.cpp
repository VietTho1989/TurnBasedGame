//
//  search.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//


#include <assert.h>
#include <limits.h>
#include <math.h>
#include <signal.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#include "weiqi_search.hpp"
#include "weiqi_internal.hpp"
#include "weiqi_walk.hpp"

namespace weiqi
{
    /* Default time settings for the UCT engine. In distributed mode, slaves are
     * unlimited by default and all control is done on the master, either in time
     * or with total number of playouts over all slaves. (It is also possible but
     * not recommended to limit only the slaves; the master then decides the move
     * when a majority of slaves have made their choice.) */
    static struct time_info default_ti;
    
    // bo static
    struct time_info unlimited_ti{};
    
    // bo static
    void default_ti_init(void)
    {
        char strTime[]= "10";
        time_parse(&default_ti, strTime);
        
        // unlimit
        {
            unlimited_ti.period = TT_MOVE;
            unlimited_ti.dim = TD_GAMES;
            unlimited_ti.len.games = INT_MAX;
            unlimited_ti.len.games_max = 0;
        }
        ti_fuseki.period = TT_NULL;
    }
    
    /* When terminating UCT search early, the safety margin to add to the
     * remaining playout number estimate when deciding whether the result can
     * still change. */
#define PLAYOUT_DELTA_SAFEMARGIN 1000
    
    /* Minimal number of simulations to consider early break. */
#define PLAYOUT_EARLY_BREAK_MIN 5000
    
    /* Minimal time to consider early break (in seconds). */
#define TIME_EARLY_BREAK_MIN 1.0
    
    /* ID of the thread manager. */
    /*static pthread_t thread_manager;
     static pthread_mutex_t finish_mutex = PTHREAD_MUTEX_INITIALIZER;
     static pthread_cond_t finish_cond = PTHREAD_COND_INITIALIZER;
     static volatile int32_t finish_thread;
     static pthread_mutex_t finish_serializer = PTHREAD_MUTEX_INITIALIZER;*/
    
    // bo static
    void* spawn_worker(void *ctx_, struct uct_search_state *s)
    {
        printf("spawn_worker\n");
        struct uct_thread_ctx* ctx = (struct uct_thread_ctx*)ctx_;
        /* Setup */
        fast_srandom(ctx->seed);
        /* Run */
        ctx->games = uct_playouts(ctx->u, ctx->b, ctx->color, ctx->t, ctx->ti, s);
        printf("spawn_worker before lock\n");
        return ctx;
    }
    
    /* Thread manager, controlling worker threads. It must be called with
     * finish_mutex lock held, but it will unlock it itself before exiting;
     * this is necessary to be completely deadlock-free. */
    /* The finish_cond can be signalled for it to stop; in that case,
     * the caller should set finish_thread = -1. */
    /* After it is started, it will update mctx->t to point at some tree
     * used for the actual search, on return
     * it will set mctx->games to the number of performed simulations. */
    // bo static
    void* spawn_thread_manager(void *ctx_, struct uct_search_state *s)
    {
        /* In thread_manager, we use only some of the ctx fields. */
        struct uct_thread_ctx* mctx = (struct uct_thread_ctx*)ctx_;
        struct uct *u = mctx->u;
        struct tree *t = mctx->t;
        fast_srandom(mctx->seed);

        int32_t played_games = 0;
        
        mctx->u->uct_halt = 0;
        // printf("spawn thread manager: %p, %p, %d\n", threads, threads[u->finish_thread], u->threads);
        
        /* Garbage collect the tree by preference when pondering. */
        if (u->pondering && t->nodes && t->nodes_size >= t->pruning_threshold) {
            t->root = tree_garbage_collect(t, t->root);
        }
        
        /* Make sure the root node is expanded. */
        {
            enum stone player_color = mctx->color;
            struct tree_node *n = t->root;
            enum stone node_color = stone_other(player_color);
            {
                // assert(node_color == t->root_color);
                if(!(node_color == t->root_color)){
                    printf("error, assert(node_color == t->root_color)\n");
                    node_color = t->root_color;
                }
            }
            
#ifdef _MSC_VER
            bool oldValue = n->is_expanded;
            n->is_expanded = 1;
            if (tree_leaf_node(n) && !oldValue){
#else
            if (tree_leaf_node(n) && !__sync_lock_test_and_set(&n->is_expanded, 1)){
#endif
                // printf("spawn_thread_manager: tree_expand_node: %d\n", n->coord);
                tree_expand_node(t, n, mctx->b, player_color, u, 1);
            }
        }
        
        /* Spawn threads... */
        // for (int32_t ti = 0; ti < u->threads; ti++)
        {
            // TODO cai nay can xem lai
            // TODO test callloc
            struct uct_thread_ctx* ctx = (struct uct_thread_ctx*)ctx_;// (struct uct_thread_ctx*)calloc(1, sizeof(*ctx));// malloc2(sizeof(*ctx));
            ctx->u = u; ctx->b = mctx->b; ctx->color = mctx->color;
            mctx->t = ctx->t = t;
            ctx->tid = 0; ctx->seed = fast_random(65536) + 0;
            ctx->ti = mctx->ti;
            // spawn worker
            {
                // TODO Tu them
                u->pctx = ctx;
                spawn_worker(ctx_, s);
            }
            played_games += ctx->games;
            // free(ctx);
        }
        
        mctx->games = played_games;
        
        return mctx;
    }
    
    /*** THREAD MANAGER end */
    
    /*** Search infrastructure: */


    int32_t uct_search_games(struct uct_search_state *s)
    {
        return s->ctx.t->root->u.playouts;
    }
    
    void uct_search_start(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s)
    {
        /* Set up search state. */
        s->base_playouts = s->last_dynkomi = s->last_print = t->root->u.playouts;
        s->print_interval = u->reportfreq;
        s->fullmem = false;
        
        if (ti) {
            if (ti->period == TT_NULL) {
                if (u->slave) {
                    *ti = unlimited_ti;
                } else {
                    *ti = default_ti;
                    time_start_timer(ti);
                }
            }
            time_stop_conditions(ti, b, u->fuseki_end, u->yose_start, u->max_maintime_ratio, &s->stop);
        }
        
        /* Fire up the tree search thread manager, which will in turn
         * spawn the searching threads. */
        {
            // assert(u->threads > 0);
            if(!(u->threads > 0)){
                printf("error, assert(u->threads > 0)\n");
            }
        }
        // TODO init uct_thread_ctx
        // printf("uct_search_start\n");
        {
            s->ctx.u = u;
            s->ctx.b = b;
            s->ctx.color = color;
            s->ctx.t = t;
            s->ctx.seed = fast_random(65536);
            s->ctx.ti = ti;
        }
        //mctx = (struct uct_thread_ctx) { .u = u, .b = b, .color = color, .t = t, .seed = fast_random(65536), .ti = ti };
        // spawn_thread_manager
        {
            spawn_thread_manager(&s->ctx, s);
        }
    }
    
    struct uct_thread_ctx* uct_search_stop(struct uct *u)
    {
        u->uct_halt = true;
        return u->pctx;
    }
    
    void uct_search_progress(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s, int32_t i)
    {
        struct uct_thread_ctx *ctx = &s->ctx;
        
        /* Adjust dynkomi? */
        int32_t di = u->dynkomi_interval * u->threads;
        if (ctx->t->use_extra_komi && u->dynkomi->permove
            && !u->pondering && di
            && i > s->last_dynkomi + di) {
            s->last_dynkomi += di;
            floating_t old_dynkomi = ctx->t->extra_komi;
            ctx->t->extra_komi = u->dynkomi->permove(u->dynkomi, b, ctx->t);
            if (UDEBUGL(3) && old_dynkomi != ctx->t->extra_komi)
                printf("dynkomi adjusted (%f -> %f)\n",
                       old_dynkomi, ctx->t->extra_komi);
        }
        
        /* Print progress? */
        if (i - s->last_print > s->print_interval) {
            s->last_print += s->print_interval; // keep the numbers tidy
            uct_progress_status(u, ctx->t, color, s->last_print, NULL);
        }
        
        if (!s->fullmem && ctx->t->nodes_size > u->max_tree_size) {
            /*char msg[] = "WARNING: Tree memory limit reached, stopping search.\nTry increasing max_tree_size.\n";
            if (UDEBUGL(2))  printf("%s", msg);
#ifdef _MSC_VER
            popup(msg);
#endif*/
            s->fullmem = true;
        }
    }
    
    /* Determine whether we should terminate the search early. */
    // bo static
    bool uct_search_stop_early(struct uct *u, struct tree *t, struct board *b, struct time_info *ti, struct time_stop *stop, struct tree_node *best, struct tree_node *best2, int32_t played, bool fullmem)
    {
        /* If the memory is full, stop immediately. Since the tree
         * cannot grow anymore, some non-well-expanded nodes will
         * quickly take over with extremely high ratio since the
         * counters are not properly simulated (just as if we use
         * non-UCT MonteCarlo). */
        /* (XXX: A proper solution would be to prune the tree
         * on the spot.) */
        if (fullmem) {
            printf("uct_search_stop_early: fullmen\n");
            return true;
        }
        
        /* Think at least 100ms to avoid a random move. This is particularly
         * important in distributed mode, where this function is called frequently. */
        double elapsed = 0.0;
        if (ti->dim == TD_WALLTIME) {
            elapsed = time_now() - ti->len.t.timer_start;
            if (elapsed < TREE_BUSYWAIT_INTERVAL)
                return false;
        }
        
        /* Break early if we estimate the second-best move cannot
         * catch up in assigned time anymore. We use all our time
         * if we are in byoyomi with single stone remaining in our
         * period, however - it's better to pre-ponder. */
        bool time_indulgent = (!ti->len.t.main_time && ti->len.t.byoyomi_stones == 1);
        if (best2 && ti->dim == TD_WALLTIME
            && played >= PLAYOUT_EARLY_BREAK_MIN && !time_indulgent) {
            double remaining = stop->worst.time - elapsed;
            double pps = ((double)played) / elapsed;
            double estplayouts = remaining * pps + PLAYOUT_DELTA_SAFEMARGIN;
            if (best->u.playouts > best2->u.playouts + estplayouts) {
                /*if (UDEBUGL(2))
                    printf("Early stop, result cannot change: best %d, best2 %d, estimated %f simulations to go (%d/%f=%f pps)\n", best->u.playouts, best2->u.playouts, estplayouts, played, elapsed, pps);*/
                // printf("uct_search_stop_early: Early stop\n");
                // return true;
            }
        }
        
        /* Early break in won situation. */
        if (best->u.playouts >= PLAYOUT_EARLY_BREAK_MIN
            && (ti->dim != TD_WALLTIME || elapsed > TIME_EARLY_BREAK_MIN)
            && tree_node_get_value(t, 1, best->u.value) >= u->sure_win_threshold) {
            printf("uct_search_stop_early: Early break in won situation\n");
            return true;
        }
        
        return false;
    }
    
    /* Determine whether we should terminate the search later than expected. */
    // bo static
    bool uct_search_keep_looking(struct uct *u, struct tree *t, struct board *b, struct time_info *ti, struct time_stop *stop, struct tree_node *best, struct tree_node *best2, struct tree_node *bestr, struct tree_node *winner, int32_t i)
    {
        if (!best) {
            if (UDEBUGL(2)){
                printf("Did not find best move, still trying...\n");
            }
            return true;
        }
        
        /* Do not waste time if we are winning. Spend up to worst time if
         * we are unsure, but only desired time if we are sure of winning. */
        floating_t beta = 2 * (tree_node_get_value(t, 1, best->u.value) - 0.5);
        if (ti->dim == TD_WALLTIME && beta > 0) {
            double good_enough = stop->desired.time * beta + stop->worst.time * (1 - beta);
            double elapsed = time_now() - ti->len.t.timer_start;
            if (elapsed > good_enough) return false;
        }
        
        if (u->best2_ratio > 0) {
            /* Check best/best2 simulations ratio. If the
             * two best moves give very similar results,
             * keep simulating. */
            if (best2 && best2->u.playouts
                && (double)best->u.playouts / best2->u.playouts < u->best2_ratio) {
                if (UDEBUGL(3))
                    printf("Best2 ratio %f < threshold %f\n", (double)best->u.playouts / best2->u.playouts, u->best2_ratio);
                return true;
            }
        }
        
        if (u->bestr_ratio > 0) {
            /* Check best, best_best value difference. If the best move
             * and its best child do not give similar enough results,
             * keep simulating. */
            if (bestr && bestr->u.playouts
                && fabs((double)best->u.value - bestr->u.value) > u->bestr_ratio) {
                if (UDEBUGL(3))
                    printf("Bestr delta %f > threshold %f\n", fabs((double)best->u.value - bestr->u.value), u->bestr_ratio);
                return true;
            }
        }
        
        if (winner && winner != best) {
            /* Keep simulating if best explored
             * does not have also highest value. */
            /* TODO if (UDEBUGL(3)){
             char strCoord1[256];
             {
             coord2sstr(strCoord1, node_coord(best), t->board);
             }
             char strCoord2[256];
             {
             coord2sstr(strCoord2, node_coord(winner), t->board);
             }
             printf("[%d] best %3s [%d] %f != winner %3s [%d] %f\n", i, strCoord1, best->u.playouts, tree_node_get_value(t, 1, best->u.value), strCoord2, winner->u.playouts, tree_node_get_value(t, 1, winner->u.value));
             }*/
            return true;
        }
        
        /* No reason to keep simulating, bye. */
        return false;
    }
    
    bool uct_search_check_stop(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti, struct uct_search_state *s, int32_t i)
    {
        // printf("uct_search_check_stop: %d\n", i);
        struct uct_thread_ctx *ctx = &s->ctx;
        
        /* Never consider stopping if we played too few simulations.
         * Maybe we risk losing on time when playing in super-extreme
         * time pressure but the tree is going to be just too messed
         * up otherwise - we might even play invalid suicides or pass
         * when we mustn't. */
        {
            // assert(!(ti->dim == TD_GAMES && ti->len.games < GJ_MINGAMES));
            if(ti->dim == TD_GAMES && ti->len.games < GJ_MINGAMES){
                printf("error, assert(!(ti->dim == TD_GAMES && ti->len.games < GJ_MINGAMES))\n");
                ti->dim = TD_WALLTIME;
                ti->len.games = GJ_MINGAMES;
            }
        }
        if (i < GJ_MINGAMES)
            return false;
        
        struct tree_node *best = NULL;
        struct tree_node *best2 = NULL; // Second-best move.
        struct tree_node *bestr = NULL; // best's best child.
        struct tree_node *winner = NULL;
        
        best = u->policy->choose(u->policy, ctx->t->root, b, color, resign);
        if (best) best2 = u->policy->choose(u->policy, ctx->t->root, b, color, node_coord(best));
        
        /* Possibly stop search early if it's no use to try on. */
        int32_t played = u->played_all + i - s->base_playouts;
        if (best && uct_search_stop_early(u, ctx->t, b, ti, &s->stop, best, best2, played, s->fullmem)) {
            // TODO Tam bo printf("uct_search_check_stop: uct_search_stop_early\n");
            // TODO Tam bo return true;
        }
        
        /* Check against time settings. */
        bool desired_done = false;
        if (ti->dim == TD_WALLTIME) {
            int64_t elapsed = now() - u->time_start;// ti->len.t.timer_start;
            /*if (elapsed > s->stop.worst.time){
                printf("uct_search_check_stop time: %f, %f, %f\n", elapsed, s->stop.worst.time, ti->len.t.timer_start);
                return true;
            }
            desired_done = elapsed > s->stop.desired.time;*/
            if(elapsed >= u->time*1000)
            {
                printf("uct_search_check_stop time out: %lld, %lld\n", elapsed, u->time);
                return true;
            }
        } else {
            {
                // assert(ti->dim == TD_GAMES);
                if(!(ti->dim == TD_GAMES)){
                    printf("error, assert(ti->dim == TD_GAMES)\n");
                    ti->dim = TD_GAMES;
                }
            }
            if (i > s->stop.worst.playouts)
                return true;
            desired_done = i > s->stop.desired.playouts;
        }
        
        /* We want to stop simulating, but are willing to keep trying
         * if we aren't completely sure about the winner yet. */
        if (desired_done) {
            if (u->policy->winner && u->policy->evaluate) {
                struct uct_descent descent;
                {
                    descent.node = ctx->t->root;
                }
                u->policy->winner(u->policy, ctx->t, &descent);
                winner = descent.node;
            }
            if (best)
                bestr = u->policy->choose(u->policy, best, b, stone_other(color), resign);
            if (!uct_search_keep_looking(u, ctx->t, b, ti, &s->stop, best, best2, bestr, winner, i)){
                printf("uct_search_check_stop: uct_search_keep_looking\n");
                 return true;
            }
        }
        
        /* TODO: Early break if best->variance goes under threshold
         * and we already have enough playouts (possibly thanks to tbook
         * or to pondering)? */
        return false;
    }
    
    struct tree_node* uct_search_result(struct uct *u, struct board *b, enum stone color, bool pass_all_alive, int32_t played_games, int32_t base_playouts, coord_t *best_coord)
    {
        /* Choose the best move from the tree. */
        struct tree_node *best = u->policy->choose(u->policy, u->t->root, b, color, resign);
        if (!best) {
            *best_coord = pass;
            return NULL;
        }
        *best_coord = node_coord(best);
        /*if (UDEBUGL(1)){
         char strCoord[256];
         {
         coord2sstr(strCoord, node_coord(best), b);
         }
         board_statics* board_statics = &b->board_statics;
         printf("*** WINNER is %s (%d,%d) with score %1.4f (%d/%d:%d/%d games), extra komi %f\n", strCoord, coord_x(board_statics, node_coord(best), b), coord_y(board_statics, node_coord(best), b), tree_node_get_value(u->t, 1, best->u.value), best->u.playouts, u->t->root->u.playouts, u->t->root->u.playouts - base_playouts, played_games, u->t->extra_komi);
         }*/
        
        /* Do not resign if we're so short of time that evaluation of best
         * move is completely unreliable, we might be winning actually.
         * In this case best is almost random but still better than resign. */
        if (tree_node_get_value(u->t, 1, best->u.value) < u->resign_threshold && !is_pass(node_coord(best))
            // If only simulated node has been a pass and no other node has
            // been simulated but pass won't win, an unsimulated node has
            // been returned; test therefore also for #simulations at root.
            && (best->u.playouts > GJ_MINGAMES || u->t->root->u.playouts > GJ_MINGAMES * 2)
            && !u->t->untrustworthy_tree) {
            printf("find best move: resign: %f, %f\n", tree_node_get_value(u->t, 1, best->u.value), u->resign_threshold);
            *best_coord = resign;
            return NULL;
        }
        
        /* If the opponent just passed and we win counting, always
         * pass as well. For option stones_only, we pass only when there
         * there is nothing else to do, to show how to maximize score. */
        if (b->moves > 1 && is_pass(b->last_move.coord) && b->rules != RULES_STONES_ONLY) {
            char *msg;
            if (uct_pass_is_safe(u, b, color, pass_all_alive, &msg)) {
                if (UDEBUGL(0)) {
                    float score = -1 * board_official_score(b, &u->dead_groups);
                    printf("<Will rather pass, looks safe enough. Final score: %s%.1f>\n", (score > 0 ? "B+" : "W+"), fabs(score));
                }
                *best_coord = pass;
                best = u->t->root->children; // pass is the first child
                {
                    // assert(is_pass(node_coord(best)));
                    if(!(is_pass(node_coord(best)))){
                        printf("error, assert(is_pass(node_coord(best)))\n");
                    }
                }
                return best;
            }
            if (UDEBUGL(0))	printf("Refusing to pass: %s\n", msg);
        }
        
        return best;
    }
}
