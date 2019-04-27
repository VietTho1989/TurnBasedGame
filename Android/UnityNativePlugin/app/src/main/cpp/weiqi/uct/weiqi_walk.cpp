//
//  walk.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include <pthread.h>
#include <signal.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "weiqi_walk.hpp"

namespace weiqi
{
#define DESCENT_DLEN 512
    
    void uct_progress_text(struct uct *u, struct tree *t, enum stone color, int32_t playouts)
    {
        struct board *b = t->board;
        if (!UDEBUGL(0))
            return;
        
        /* Best move */
        struct tree_node *best = u->policy->choose(u->policy, t->root, b, color, resign);
        if (!best) {
            printf("... No moves left\n");
            return;
        }
        // TODO printf("[%d] ", playouts);
        // TODO printf("best %.1f%% ", 100 * tree_node_get_value(t, 1, best->u.value));
        
        /* Dynamic komi */
        if (t->use_extra_komi){
            // TODO printf("xkomi %.1f ", t->extra_komi);
        }
        
        /* Best sequence */
        // TODO printf("| seq ");
        for (int32_t depth = 0; depth < 4; depth++) {
            if (best && best->u.playouts >= 25) {
                /*{
                 char strCoord[256];
                 {
                 coord2sstr(strCoord, node_coord(best), b);
                 }
                 printf("%3s ", strCoord);
                 }*/
                best = u->policy->choose(u->policy, best, b, color, resign);
            } else {
                // TODO printf("    ");
            }
        }
        
        /* Best candidates */
        int32_t nbest = 4;
        float   best_r[4];// [nbest];
        coord_t best_c[4];// [nbest];
        uct_get_best_moves(t, best_c, best_r, nbest, true);
        
        // TODO printf("| can %c ", color == S_BLACK ? 'b' : 'w');
        for (int32_t i = 0; i < nbest; i++)
            if (!is_pass(best_c[i])){
                char strCoord[256];
                {
                    coord2sstr(strCoord, best_c[i], b);
                }
                printf("%3s(%.1f) ", strCoord, 100 * best_r[i]);
            } else {
                printf("          ");
            }
        
        /* Tree memory usage */
        /* TODO if (UDEBUGL(3)){
         printf(" | %.1fMb", (float)t->nodes_size / 1024 / 1024);
         }*/
        
        // TODO printf("\n");
    }
    
    /* GoGui live gfx: show winrates */
    // bo static
    void uct_progress_gogui_winrates(strbuf_t *buf, struct uct *u, struct tree *t, enum stone color, int32_t playouts)
    {
        coord_t best_c[GOGUI_CANDIDATES];
        float   best_r[GOGUI_CANDIDATES];
        uct_get_best_moves(t, best_c, best_r, GOGUI_CANDIDATES, true);
        gogui_show_winrates(buf, t->board, color, best_c, best_r, GOGUI_CANDIDATES);
    }
    
    
    void uct_progress_json(struct uct *u, struct tree *t, enum stone color, int32_t playouts, coord_t *final1, bool big)
    {
        /* Prefix indicating JSON line. */
        printf("{\"%s\": {", final1 ? "move" : "frame");
        
        /* Plaout count */
        printf("\"playouts\": %d", playouts);
        
        /* Dynamic komi */
        if (t->use_extra_komi)
            printf(", \"extrakomi\": %.1f", t->extra_komi);
        
        if (final1) {
            /* Final move choice */
            char strCoord[256];
            {
                coord2sstr(strCoord, *final1, t->board);
            }
            printf(", \"choice\": \"%s\"", strCoord);
        } else {
            struct tree_node *best = u->policy->choose(u->policy, t->root, t->board, color, resign);
            if (best) {
                /* Best move */
                char strCoord[256];
                {
                    coord2sstr(strCoord, best->coord, t->board);
                }
                printf(", \"best\": {\"%s\": %f}", strCoord, tree_node_get_value(t, 1, best->u.value));
            }
        }
        
        /* Best candidates */
        int32_t cans = 4;
        struct tree_node *can[4];// [cans];
        memset(can, 0, sizeof(can));
        struct tree_node *best = t->root->children;
        while (best) {
            int32_t c = 0;
            while ((!can[c] || best->u.playouts > can[c]->u.playouts) && ++c < cans);
            for (int32_t d = 0; d < c; d++) can[d] = can[d + 1];
            if (c > 0) can[c - 1] = best;
            best = best->sibling;
        }
        printf(", \"can\": [");
        while (--cans >= 0) {
            if (!can[cans]) break;
            /* Best sequence */
            printf("%s[", cans < 3 ? ", " : "");
            best = can[cans];
            for (int32_t depth = 0; depth < 4; depth++) {
                if (!best || best->u.playouts < 25) break;
                {
                    char strCoord[256];
                    {
                        coord2sstr(strCoord, best->coord, t->board);
                    }
                    printf("%s{\"%s\":%.3f}", depth > 0 ? "," : "", strCoord, tree_node_get_value(t, 1, best->u.value));
                }
                best = u->policy->choose(u->policy, best, t->board, color, resign);
            }
            printf("]");
        }
        printf("]");
        
        if (big) {
            /* Average score. */
            if (t->avg_score.playouts > 0){
                printf(", \"avg\": {\"score\": %.3f}", t->avg_score.value);
            }
            /* Per-intersection information. */
            printf(", \"boards\": {");
            /* Position coloring information. */
            printf("\"colors\": [");
            int32_t f = 0;
            foreach_point(t->board) {
                if (board_at(t->board, c) == S_OFFBOARD) continue;
                printf("%s%d", f++ > 0 ? "," : "", board_at(t->board, c));
            } foreach_point_end;
            printf("]");
            /* Ownership statistics. Value (0..1000) for each possible
             * point describes likelihood of this point becoming black.
             * Normally, white rate is 1000-value; exception are possible
             * seki points, but these should be rare. */
            printf(", \"territory\": [");
            f = 0;
            foreach_point(t->board) {
                if (board_at(t->board, c) == S_OFFBOARD) continue;
                int32_t rate = u->ownermap.map[c][S_BLACK] * 1000 / u->ownermap.playouts;
                printf("%s%d", f++ > 0 ? "," : "", rate);
            } foreach_point_end;
            printf("]");
            printf("}");
        }
        
        printf("}}\n");
    }
    
    /* GoGui live gfx: show best sequence */
    // bo static
    void uct_progress_gogui_sequence(strbuf_t *buf, struct uct *u, struct tree *t, enum stone color, int32_t playouts)
    {
        coord_t seq[4] = { pass, pass, pass, pass };
        
        /* Best move */
        struct tree_node *best = u->policy->choose(u->policy, t->root, t->board, color, resign);
        if (!best) {  printf("... No moves left\n"); return;  }
        
        for (int32_t i = 0; i < 4 && best && best->u.playouts >= 25; i++) {
            seq[i] = node_coord(best);
            best = u->policy->choose(u->policy, best, t->board, color, resign);
        }
        
        gogui_show_best_seq(buf, t->board, color, seq, 4);
    }
    
    /* GoGui live gfx: show best moves */
    // bo static
    void uct_progress_gogui_best(strbuf_t *buf, struct uct *u, struct tree *t, enum stone color, int32_t playouts)
    {
        coord_t best_c[GOGUI_CANDIDATES];
        float   best_r[GOGUI_CANDIDATES];
        uct_get_best_moves(t, best_c, best_r, GOGUI_CANDIDATES, false);
        gogui_show_best_moves(buf, t->board, color, best_c, best_r, GOGUI_CANDIDATES);
    }
    
    void uct_progress_status(struct uct *u, struct tree *t, enum stone color, int32_t playouts, coord_t *final1)
    {
        switch (u->reporting) {
            case UR_TEXT:
                uct_progress_text(u, t, color, playouts);
                break;
            case UR_JSON:
            case UR_JSON_BIG:
                uct_progress_json(u, t, color, playouts, final1, u->reporting == UR_JSON_BIG);
                break;
            default:
                // assert(0);
                printf("error, assert(0)\n");
                break;
        }
        
        if (!gogui_livegfx)
            return;
        
        char buffer[10000];  strbuf_t strbuf;
        strbuf_t *buf = strbuf_init(&strbuf, buffer, sizeof(buffer));
        
        switch(gogui_livegfx) {
            case UR_GOGUI_BEST:
                uct_progress_gogui_best(buf, u, t, color, playouts);
                break;
            case UR_GOGUI_SEQ:
                uct_progress_gogui_sequence(buf, u, t, color, playouts);
                break;
            case UR_GOGUI_WR:
                uct_progress_gogui_winrates(buf, u, t, color, playouts);
                break;
            default:
                // assert(0);
                printf("error, assert(0)\n");
                break;
        }
        
        gogui_show_livegfx(buf->str);
    }
    
    struct uct_playout_callback {
        struct uct *uct;
        struct tree *tree;
        struct tree_node *lnode;
    };
    
    // bo static
    coord_t uct_playout_hook(struct playout_policy *playout, struct playout_setup *setup, struct board *b, enum stone color, int32_t mode)
    {
        /* XXX: This is used in some non-master branches. */
        return pass;
    }
    
    // bo static
    coord_t uct_playout_prepolicy(struct playout_policy *playout, struct playout_setup *setup, struct board *b, enum stone color)
    {
        return uct_playout_hook(playout, setup, b, color, 0);
    }
    
    // bo static
    coord_t uct_playout_postpolicy(struct playout_policy *playout, struct playout_setup *setup, struct board *b, enum stone color)
    {
        return uct_playout_hook(playout, setup, b, color, 1);
    }
    
    // bo static
    int32_t uct_leaf_node(struct uct *u, struct board *b, enum stone player_color, struct playout_amafmap *amaf, struct uct_descent *descent, int32_t *dlen, struct tree_node *significant[2], struct tree *t, struct tree_node *n, enum stone node_color, char *spaces)
    {
        enum stone next_color = stone_other(node_color);
        int32_t parity = (next_color == player_color ? 1 : -1);
        
        if (UDEBUGL(7)){
            char strCoord[256];
            {
                coord2sstr(strCoord, node_coord(n), t->board);
            }
            printf("%s*-- UCT playout #%d start [%s] %f\n", spaces, n->u.playouts, strCoord, tree_node_get_value(t, -parity, n->u.value));
        }
        
        /*struct uct_playout_callback upc = {
            .uct = u,
            .tree = t,
            // TODO: Don't necessarily restart the sequence walk when entering playout.
            .lnode = NULL,
        };*/
        struct uct_playout_callback upc;
        {
            upc.uct = u;
            upc.tree = t;
            // TODO: Don't necessarily restart the sequence walk when entering playout.
            upc.lnode = NULL;
        };
        
        /*struct playout_setup ps = {
         //.gamelen = u->gamelen,
         .gamelen = static_cast<unsigned int>(u->gamelen),
         .mercymin = u->mercymin,
         .prepolicy_hook = uct_playout_prepolicy,
         .postpolicy_hook = uct_playout_postpolicy,
         .hook_data = &upc,
         };*/
        struct playout_setup ps;
        {
            //.gamelen = u->gamelen,
            ps.gamelen = static_cast<unsigned int>(u->gamelen);
            ps.mercymin = u->mercymin;
            ps.prepolicy_hook = uct_playout_prepolicy;
            ps.postpolicy_hook = uct_playout_postpolicy;
            ps.hook_data = &upc;
        }
        // TODO Tu them vao
        {
            if(u->uct_halt)
            {
                printf("error, uct_halt\n");
                return 0;
            }
        }
        int32_t result = play_random_game(&ps, b, next_color, u->playout_amaf ? amaf : NULL, &u->ownermap, u->playout);
        if (next_color == S_WHITE) {
            /* We need the result from black's perspective. */
            result = - result;
        }
        if (UDEBUGL(7)){
            char strCoord[256];
            {
                coord2sstr(strCoord, node_coord(n), t->board);
            }
            printf("%s -- [%d..%d] %s random playout result %d\n", spaces, player_color, next_color, strCoord, result);
        }
        
        return result;
    }
    
    // bo static
    inline void record_amaf_move(struct playout_amafmap *amaf, coord_t coord, bool is_ko_capture)
    {
        // assert(amaf->gamelen < MAX_GAMELEN);
        if(!(amaf->gamelen < MAX_GAMELEN)){
            printf("error, assert(amaf->gamelen < MAX_GAMELEN)\n");
        }
        amaf->is_ko_capture[amaf->gamelen] = is_ko_capture;
        // TODO Test amaf->game[amaf->gamelen++] = coord;
        {
            amaf->game[amaf->gamelen] = coord;
            amaf->gamelen++;
        }
        // printf("record_amaf_move: %d, %d\n", amaf->gamelen, coord);
    }
    
    // bo static
    floating_t scale_value(struct uct *u, struct board *b, enum stone node_color, struct tree_node *significant[2], int32_t result)
    {
        floating_t rval = result > 0 ? 1.0 : result < 0 ? 0.0 : 0.5;
        if (u->val_scale && result != 0) {
            if (u->val_byavg) {
                if (u->t->avg_score.playouts < 50)
                    return rval;
                result -= u->t->avg_score.value * 2;
            }
            
            double scale = u->val_scale;
            if (u->val_bytemp) {
                /* xvalue is 0 at 0.5, 1 at 0 or 1 */
                /* No correction for parity necessary. */
                double xvalue = significant[node_color - 1] ? fabs(significant[node_color - 1]->u.value - 0.5) * 2 : 0;
                scale = u->val_bytemp_min + (u->val_scale - u->val_bytemp_min) * xvalue;
            }

            int32_t vp = u->val_points;
            if (!vp) {
                vp = board_size(b) - 1; vp *= vp; vp *= 2;
            }
            
            floating_t sval = (floating_t) abs(result) / vp;
            sval = sval > 1 ? 1 : sval;
            if (result < 0) sval = 1 - sval;
            if (u->val_extra)
                rval += scale * sval;
            else
                rval = (1 - scale) * rval + scale * sval;
            // printf("score %d => sval %f, rval %f\n", result, sval, rval);
        }
        return rval;
    }
    
    // bo static
    double local_value(struct uct *u, struct board *b, coord_t coord, enum stone color)
    {
        /* Tactical evaluation of move @coord by color @color, given
         * simulation end position @b. I.e., a move is tactically good
         * if the resulting group stays on board until the game end. */
        /* We can also take into account surrounding stones, e.g. to
         * encourage taking off external liberties during a semeai. */
        double val = board_local_value(u->local_tree_neival, b, coord, color);
        return (color == S_WHITE) ? 1.f - val : val;
    }
    
    // bo static
    void record_local_sequence(struct uct *u, struct tree *t, struct board *endb, struct uct_descent *descent, int32_t dlen, int32_t di, enum stone seq_color)
    {
#define LTREE_DEBUG if (UDEBUGL(6))
        
        /* Ignore pass sequences. */
        if (is_pass(node_coord(descent[di].node)))
            return;
        
        LTREE_DEBUG board_print(endb, stderr);
        LTREE_DEBUG {
            char strStone[20];
            {
                stone2str(strStone, seq_color);
            }
            printf("recording local %s sequence: ", strStone);
        }
        
        /* Sequences starting deeper are less relevant in general. */
        int32_t pval = LTREE_PLAYOUTS_MULTIPLIER;
        if (u->local_tree && u->local_tree_depth_decay > 0)
            pval = ((floating_t) pval) / pow(u->local_tree_depth_decay, di - 1);
        if (!pval) {
            LTREE_DEBUG fprintf(stderr, "too deep @%d\n", di);
            return;
        }
        
        /* Pick the right local tree root... */
        struct tree_node *lnode = seq_color == S_BLACK ? t->ltree_black : t->ltree_white;
        lnode->u.playouts++;
        
        /* ...determine the sequence value... */
        double sval = 0.5;
        if (u->local_tree_eval != LTE_EACH) {
            sval = local_value(u, endb, node_coord(descent[di].node), seq_color);
            {
                LTREE_DEBUG {
                    char strCoord[256];
                    {
                        coord2sstr(strCoord, node_coord(descent[di].node), t->board);
                    }
                    char strStone[20];
                    {
                        stone2str(strStone, seq_color);
                    }
                    printf("(goal %s[%s %1.3f][%d]) ", strCoord, strStone, sval, descent[di].node->d);
                }
            }
            
            if (u->local_tree_eval == LTE_TOTAL) {
                int32_t di0 = di;
                while (di < dlen && (di == di0 || descent[di].node->d < u->tenuki_d)) {
                    enum stone color = (di - di0) % 2 ? stone_other(seq_color) : seq_color;
                    double rval = local_value(u, endb, node_coord(descent[di].node), color);
                    if ((di - di0) % 2)
                        rval = 1 - rval;
                    sval += rval;
                    di++;
                }
                sval /= (di - di0 + 1);
                di = di0;
            }
        }
        
        /* ...and record the sequence. */
        int32_t di0 = di;
        while (di < dlen && !is_pass(node_coord(descent[di].node))
               && (di == di0 || descent[di].node->d < u->tenuki_d)) {
            enum stone color = (di - di0) % 2 ? stone_other(seq_color) : seq_color;
            double rval;
            if (u->local_tree_eval != LTE_EACH)
                rval = sval;
            else
                rval = local_value(u, endb, node_coord(descent[di].node), color);
            LTREE_DEBUG {
                char strCoord[256];
                {
                    coord2sstr(strCoord, node_coord(descent[di].node), t->board);
                }
                char strStone[20];
                {
                    stone2str(strStone, color);
                }
                printf("%s[%s %1.3f][%d] ", strCoord, strStone, rval, descent[di].node->d);
            }
            lnode = tree_get_node(t, lnode, node_coord(descent[di++].node), true);
            {
                // assert(lnode);
                if(!lnode){
                    printf("error, assert(lnode)\n");
                }
            }
            stats_add_result(&lnode->u, rval, pval);
        }
        
        /* Add lnode for tenuki (pass) if we descended further. */
        if (di < dlen) {
            double rval = u->local_tree_eval != LTE_EACH ? sval : 0.5;
            LTREE_DEBUG fprintf(stderr, "pass ");
            lnode = tree_get_node(t, lnode, pass, true);
            {
                // assert(lnode);
                if(!lnode){
                    printf("error, assert(lnode)\n");
                }
            }
            stats_add_result(&lnode->u, rval, pval);
        }
        
        LTREE_DEBUG fprintf(stderr, "\n");
    }

    int32_t uct_playout(struct uct *u, struct board *b, enum stone player_color, struct tree *t)
    {
        struct board b2;
        board_copy(&b2, b);
        
        struct playout_amafmap amaf;
        {
            amaf.gamelen = amaf.game_baselen = 0;
        }
        
        /* Walk the tree until we find a leaf, then expand it and do
         * a random playout. */
        struct tree_node *n = t->root;
        enum stone node_color = stone_other(player_color);
        {
            // assert(node_color == t->root_color);
            if(!(node_color == t->root_color)){
                printf("error, assert(node_color == t->root_color)\n");
            }
        }
        
        /* Make sure root node is expanded. Normally that's the case,
         * except direct calls to uct_playout() */
#ifdef _MSC_VER
        bool oldValue = n->is_expanded;
        n->is_expanded = 1;
        if (tree_leaf_node(n) && !oldValue){
#else
        if (tree_leaf_node(n) && !__sync_lock_test_and_set(&n->is_expanded, 1)){
#endif
            // printf("uct_playout: tree_expand_node: %d\n", n->coord);
            tree_expand_node(t, n, b, player_color, u, 1);
        }
        
        /* Tree descent history. */
        /* XXX: This is somewhat messy since @n and descent[dlen-1].node are
         * redundant. */
        struct uct_descent descent[DESCENT_DLEN];
        descent[0].node = n; descent[0].lnode = NULL;
        int32_t dlen = 1;
        /* Total value of the sequence. */
        struct move_stats seq_value;
        {
            seq_value.value = 0;
            seq_value.playouts = 0;
        }
        /* The last "significant" node along the descent (i.e. node
         * with higher than configured number of playouts). For black
         * and white. */
        struct tree_node *significant[2] = { NULL, NULL };
        if (n->u.playouts >= u->significant_threshold)
            significant[node_color - 1] = n;

        int32_t result;
        int32_t pass_limit = (board_size(&b2) - 2) * (board_size(&b2) - 2) / 2;
        int32_t passes = is_pass(b->last_move.coord) && b->moves > 0;
        
        /* debug */
        // bo static
        char spaces[] = "\0                                                      ";
        /* /debug */
        if (UDEBUGL(8))
            printf("--- (#%d) UCT walk with color %d\n", t->root->u.playouts, player_color);
        
        while (!tree_leaf_node(n) && passes < 2) {
            spaces[dlen - 1] = ' '; spaces[dlen] = 0;
            
            
            /*** Choose a node to descend to: */
            
            /* Parity is chosen already according to the child color, since
             * it is applied to children. */
            node_color = stone_other(node_color);
            int32_t parity = (node_color == player_color ? 1 : -1);
            
            {
                // assert(dlen < DESCENT_DLEN);
                if(!(dlen < DESCENT_DLEN)){
                    printf("error, assert(dlen < DESCENT_DLEN)\n");
                }
            }
            descent[dlen] = descent[dlen - 1];
            if (u->local_tree && (!descent[dlen].lnode || descent[dlen].node->d >= u->tenuki_d)) {
                /* Start new local sequence. */
                /* Remember that node_color already holds color of the
                 * to-be-found child. */
                descent[dlen].lnode = node_color == S_BLACK ? t->ltree_black : t->ltree_white;
            }
            
            if (!u->random_policy_chance || fast_random(u->random_policy_chance))
                u->policy->descend(u->policy, t, &descent[dlen], parity, b2.moves > pass_limit);
            else
                u->random_policy->descend(u->random_policy, t, &descent[dlen], parity, b2.moves > pass_limit);
            
            
            /*** Perform the descent: */
            
            if (descent[dlen].node->u.playouts >= u->significant_threshold) {
                significant[node_color - 1] = descent[dlen].node;
            }
            
            seq_value.playouts += descent[dlen].value.playouts;
            seq_value.value += descent[dlen].value.value * descent[dlen].value.playouts;
            n = descent[dlen++].node;
            {
                // assert(n == t->root || n->parent);
                if(!(n == t->root || n->parent)){
                    printf("error, assert(n == t->root || n->parent)\n");
                }
            }
            if (UDEBUGL(7)){
                char strCoord[256];
                {
                    coord2sstr(strCoord, node_coord(n), t->board);
                }
                printf("%s+-- UCT sent us to [%s:%d] %d,%f\n", spaces, strCoord, node_coord(n), n->u.playouts, tree_node_get_value(t, parity, n->u.value));
            }
            
            if (u->virtual_loss) {
#ifdef _MSC_VER
                n->descents+=u->virtual_loss;
#else
                __sync_fetch_and_add(&n->descents, u->virtual_loss);
#endif
            }
            
            struct move m;
            {
                m.coord = node_coord(n);
                m.color = node_color;
            }
            int32_t res = board_play(&b2, &m);
            
            if (res < 0 || (!is_pass(m.coord) && !group_at(&b2, m.coord)) /* suicide */
                || b2.superko_violation) {
                if (UDEBUGL(4)) {
                    for (struct tree_node *ni = n; ni; ni = ni->parent){
                        char strCoord[256];
                        {
                            coord2sstr(strCoord, node_coord(ni), t->board);
                        }
                        printf("%s<%" PRIhash"> ", strCoord, ni->hash);
                    }
                    {
                        board_statics* board_statics = &b->board_statics;
                        char strStone[20];
                        {
                            stone2str(strStone, node_color);
                        }
                        printf("marking invalid %s node %d,%d res %d group %d spk %d\n", strStone, coord_x(board_statics, node_coord(n),b), coord_y(board_statics, node_coord(n),b), res, group_at(&b2, m.coord), b2.superko_violation);
                    }
                }
                n->hints |= TREE_HINT_INVALID;
                result = 0;
                // TODO goto end;
                {
                    /* We need to undo the virtual loss we added during descend. */
                    if (u->virtual_loss) {
                        for (; n->parent; n = n->parent) {
#ifdef _MSC_VER
                            n->descents-=u->virtual_loss;
#else
                            __sync_fetch_and_sub(&n->descents, u->virtual_loss);
#endif
                        }
                    }
                    
                    board_done_noalloc(&b2);
                    return result;
                }
            }
            
            {
                // assert(node_coord(n) >= -1);
                if(!(node_coord(n) >= -1)){
                    printf("error, assert(node_coord(n) >= -1)\n");
                }
            }
            record_amaf_move(&amaf, node_coord(n), board_playing_ko_threat(&b2));
            
            if (is_pass(node_coord(n)))
                passes++;
            else
                passes = 0;
            
            enum stone next_color = stone_other(node_color);
            /* We need to make sure only one thread expands the node. If
             * we are unlucky enough for two threads to meet in the same
             * node, the latter one will simply do another simulation from
             * the node itself, no big deal. t->nodes_size may exceed
             * the maximum in multi-threaded case but not by much so it's ok.
             * The size test must be before the test&set not after, to allow
             * expansion of the node later if enough nodes have been freed. */
#ifdef _MSC_VER
            bool oldValue = n->is_expanded;
            n->is_expanded = 1;
            if (tree_leaf_node(n) && n->u.playouts - u->virtual_loss >= u->expand_p && t->nodes_size < u->max_tree_size && !oldValue){
#else
            if (tree_leaf_node(n) && n->u.playouts - u->virtual_loss >= u->expand_p && t->nodes_size < u->max_tree_size && !__sync_lock_test_and_set(&n->is_expanded, 1)){
#endif
                // printf("uct_layout: tree_expand_node1: %d\n", n->coord);
                tree_expand_node(t, n, &b2, next_color, u, -parity);
            }
        }
        
        amaf.game_baselen = amaf.gamelen;
        
        if (t->use_extra_komi && u->dynkomi->persim) {
            b2.komi += round(u->dynkomi->persim(u->dynkomi, &b2, t, n));
        }
        
        /* !!! !!! !!!
         * ALERT: The "result" number is extremely confusing. In some parts
         * of the code, it is from white's perspective, but here positive
         * number is black's win! Be VERY CAREFUL.
         * !!! !!! !!! */
        
        // assert(tree_leaf_node(n));
        /* In case of parallel tree search, the assertion might
         * not hold if two threads chew on the same node. */
        result = uct_leaf_node(u, &b2, player_color, &amaf, descent, &dlen, significant, t, n, node_color, spaces);
        
        if (u->policy->wants_amaf && u->playout_amaf_cutoff) {
            uint32_t cutoff = amaf.game_baselen;
            cutoff += (amaf.gamelen - amaf.game_baselen) * u->playout_amaf_cutoff / 100;
            amaf.gamelen = cutoff;
        }
        
        /* Record the result. */
        
        {
            // assert(n == t->root || n->parent);
            if(!(n == t->root || n->parent)){
                printf("error, assert(n == t->root || n->parent)\n");
            }
        }
        floating_t rval = scale_value(u, b, node_color, significant, result);
        u->policy->update(u->policy, t, n, node_color, player_color, &amaf, &b2, rval);
        
        stats_add_result(&t->avg_score, (float)result / 2, 1);
        if (t->use_extra_komi) {
            stats_add_result(&u->dynkomi->score, (float)result / 2, 1);
            stats_add_result(&u->dynkomi->value, rval, 1);
        }
        
        if (u->local_tree && n->parent && !is_pass(node_coord(n)) && dlen > 0) {
            /* Get the local sequences and record them in ltree. */
            /* We will look for sequence starts in our descent
             * history, then run record_local_sequence() for each
             * found sequence start; record_local_sequence() may
             * pick longer sequences from descent history then,
             * which is expected as it will create new lnodes. */
            enum stone seq_color = player_color;
            /* First move always starts a sequence. */
            record_local_sequence(u, t, &b2, descent, dlen, 1, seq_color);
            seq_color = stone_other(seq_color);
            for (int32_t dseqi = 2; dseqi < dlen; dseqi++, seq_color = stone_other(seq_color)) {
                if (u->local_tree_allseq) {
                    /* We are configured to record all subsequences. */
                    record_local_sequence(u, t, &b2, descent, dlen, dseqi, seq_color);
                    continue;
                }
                if (descent[dseqi].node->d >= u->tenuki_d) {
                    /* Tenuki! Record the fresh sequence. */
                    record_local_sequence(u, t, &b2, descent, dlen, dseqi, seq_color);
                    continue;
                }
                if (descent[dseqi].lnode && !descent[dseqi].lnode) {
                    /* Record result for in-descent picked sequence. */
                    record_local_sequence(u, t, &b2, descent, dlen, dseqi, seq_color);
                    continue;
                }
            }
        }
        
    end:
        /* We need to undo the virtual loss we added during descend. */
        if (u->virtual_loss) {
            for (; n->parent; n = n->parent) {
#ifdef _MSC_VER
                n->descents-=u->virtual_loss;
#else
                __sync_fetch_and_sub(&n->descents, u->virtual_loss);
#endif
                
            }
        }
        
        board_done_noalloc(&b2);
        return result;
    }

    int32_t uct_playouts(struct uct *u, struct board *b, enum stone color, struct tree *t, struct time_info *ti)
    {
        printf("uct_playouts\n");
        int32_t i;
        for (i = 0; !u->uct_halt; i++) {
            // printf("uct_playout: %d\n", i);
            uct_playout(u, b, color, t);
        }
        return i;
    }
}
