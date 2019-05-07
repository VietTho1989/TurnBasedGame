//
//  board.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include "weiqi_board.hpp"
#include "weiqi_pattern3.hpp"
#include "weiqi_fbook.hpp"
#include "weiqi_debug.hpp"
#include "weiqi_random.hpp"
#include "weiqi_mq.hpp"
#include "weiqi_position.hpp"

namespace weiqi
{
#if 0
#define profiling_noinline __attribute__((noinline))
#else
#define profiling_noinline
#endif
    
#define gi_granularity 4
#define gi_allocsize(gids) ((1 << gi_granularity) + ((gids) >> gi_granularity) * (1 << gi_granularity))
    
    /////////////////////////////////////////////////////////////////////////////
    /////////////////////// Not Use Define ////////////////
    /////////////////////////////////////////////////////////////////////////////
    
    enum stone board_at(struct board *b, coord_t c)
    {
        if(c>=0 && c<BOARD_MAX_COORDS){
            return b->b[c];
        }else{
            // printf("board_at error: %d\n", c);
            return S_NONE;
        }
    }
    
    enum stone board_atxy(struct board *b, int x, int y)
    {
        int c = (x) + board_size(b) * (y);
        if(c>=0 && c<BOARD_MAX_COORDS){
            return b->b[c];
        }else{
            // printf("board_atxy error: %d\n", c);
            return S_NONE;
        }
    }
    
    group_t group_at(struct board *b, coord_t c)
    {
        if(c>=0 && c<BOARD_MAX_COORDS){
            return b->g[c];
        }else{
            // printf("group_at error: %d\n", c);
            return 0;
        }
    }
    
    group_t group_atxy(struct board *b, int x, int y)
    {
        coord_t c = (x) + board_size(b) * (y);
        if(c>=0 && c<BOARD_MAX_COORDS){
            return b->g[c];
        }else{
            // printf("group_atxy error: %d\n", c);
            return 0;
        }
    }
    
    char neighbor_count_at(struct board *b_, coord_t coord, enum stone color)
    {
        char ret = 0;
        {
            if(coord>=0 && coord<BOARD_MAX_COORDS){
                if(color>=0 && color<S_MAX){
                    ret = (b_)->n[coord].colors[(enum stone) color];
                }else{
                    printf("color error: %d\n", color);
                }
            }else{
                printf("board error: %d\n", coord);
            }
        }
        return ret;
    }
    
    void board_set(struct board *b, coord_t c, enum stone stone)
    {
        if(c>=0 && c<BOARD_MAX_COORDS){
            b->b[c] = stone;
        }else{
            // printf("board_set error: %d\n", c);
        }
    }
    
    void set_neighbor_count_at(struct board *b_, coord_t coord, enum stone color, char count)
    {
        if(coord>=0 && coord<BOARD_MAX_COORDS){
            if(color>=0 && color<S_MAX){
                (b_)->n[coord].colors[(enum stone) color] = count;
            }else{
                printf("color error: %d\n", color);
            }
        }else{
            printf("board error: %d\n", coord);
        }
    }
    
    void inc_neighbor_count_at(struct board *b_, coord_t coord, enum stone color)
    {
        if(coord>=0 && coord<BOARD_MAX_COORDS){
            if(color>=0 && color<S_MAX){
                (b_)->n[coord].colors[(enum stone) color]++;
            }else{
                printf("color error: %d\n", color);
            }
        }else{
            printf("board error: %d\n", coord);
        }
    }
    
    void dec_neighbor_count_at(struct board *b_, coord_t coord, enum stone color)
    {
        if(coord>=0 && coord<BOARD_MAX_COORDS){
            if(color>=0 && color<S_MAX){
                (b_)->n[coord].colors[(enum stone) color]--;
            }else{
                printf("color error: %d\n", color);
            }
        }else{
            printf("board error: %d\n", coord);
        }
    }
    
    coord_t groupnext_at(struct board *b_, coord_t c)
    {
        if(c>=0 && c<BOARD_MAX_COORDS){
            return (b_)->p[c];
        }else{
            printf("error, groupnext_at: %d, ", c);
            return 0;
        }
    }
    
    void groupnext_set(struct board *b_, coord_t c, coord_t nextCoord)
    {
        if(c>=0 && c<BOARD_MAX_COORDS){
            (b_)->p[c] = nextCoord;
        }else{
            printf("error, groupnext_set: %d, ", c);
        }
    }
    
    coord_t groupnext_atxy(struct board *b_, int32_t x, int32_t y)
    {
        int32_t c = (x) + board_size(b_) * (y);
        if(c>=0 && c<BOARD_MAX_COORDS){
            return (b_)->p[c];
        }else{
            printf("error, groupnext_atxy: %d, ", c);
            return 0;
        }
    }
    
    struct group* board_group_info(struct board *b_, group_t g_)
    {
        // printf("find board group info\n");
        if(g_>=0 && g_<BOARD_MAX_COORDS){
            return &(b_)->gi[(g_)];
        }else{
            printf("error, board_group_info error: %d\n", g_);
            return &(b_)->gi[0];
        }
    }
    
    hash_t hash_at(board_statics* board_statics, struct board *board, coord_t coord, enum stone color)
    {
        if(coord>=0 && coord<BOARD_MAX_COORDS){
            return board_statics->h[coord][((color) == S_BLACK ? 1 : 0)];
        }else{
            printf("hash_at: coord error: %d\n", coord);
            return 0;
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////
    /////////////////////// End Not Use Define ////////////////
    /////////////////////////////////////////////////////////////////////////////
    
    // bo static
    inline void board_addf(struct board *b, coord_t c)
    {
        // printf("board_addf: %d\n", c);
        b->fmap[c] = b->flen;
        b->f[b->flen++] = c;
    }
    
    // bo static
    inline void board_rmf(struct board *b, int32_t f)
    {
        /* Not bothering to delete fmap records,
         * Just keep the valid ones up to date. */
        // printf("board_rmf before: %p: %d, %d\n", b, f, b->flen);
        coord_t c = b->f[f] = b->f[--b->flen];
        b->fmap[c] = f;
        // printf("board_rmf: %p: %d, %d, %d\n", b, f, c, b->flen);
    }
    
    // bo static
    void board_setup(struct board *b)
    {
        memset(b, 0, sizeof(*b));
        
        struct move m = { pass, S_NONE };
        b->last_move = b->last_move2 = b->last_move3 = b->last_move4 = b->last_ko = b->ko = m;
    }
    
    void board_init(struct board* b, char *fbookfile)
    {
        board_setup(b);
        
        b->fbookfile = fbookfile;
        
        // Default setup
        b->size = 9 + 2;
        board_clear(b);
    }
    
    void board_init_data(struct board *board)
    {
        // printf("board_init_data\n");
        int32_t size = board_size(board);
        
        board_setup(board);
        board_resize(board, size - 2 /* S_OFFBOARD margin */);
        
        /* Setup initial symmetry */
        if (size % 2) {
            /*board->symmetry.d = 1;
             board->symmetry.x1 = board->symmetry.y1 = board_size(board) / 2;
             board->symmetry.x2 = board->symmetry.y2 = board_size(board) - 1;
             board->symmetry.type = SYM_FULL;*/
            
            board->symmetry.d = 0;
            board->symmetry.x1 = board->symmetry.y1 = 1;
            board->symmetry.x2 = board->symmetry.y2 = board_size(board) - 1;
            board->symmetry.type = SYM_NONE;
        } else {
            /* TODO: We do not handle board symmetry on boards
             * with no tengen yet. */
            // TODO Test
            printf("board_init_data: symmetry\n");
            board->symmetry.d = 0;
            board->symmetry.x1 = board->symmetry.y1 = 1;
            board->symmetry.x2 = board->symmetry.y2 = board_size(board) - 1;
            board->symmetry.type = SYM_NONE;
        }
        
        /* Draw the offboard margin */
        int32_t top_row = board_size2(board) - board_size(board);
        int32_t i;
        for (i = 0; i < board_size(board); i++)
            board->b[i] = board->b[top_row + i] = S_OFFBOARD;
        for (i = 0; i <= top_row; i += board_size(board))
            board->b[i] = board->b[board_size(board) - 1 + i] = S_OFFBOARD;
        
        foreach_point(board) {
            coord_t coord = c;
            if (board_at(board, coord) == S_OFFBOARD)
                continue;
            foreach_neighbor(board, c, {
                inc_neighbor_count_at(board, coord, board_at(board, c));
            } );
        } foreach_point_end;
        
        /* All positions are free! Except the margin. */
        for (i = board_size(board); i < (board_size(board) - 1) * board_size(board); i++)
            if (i % board_size(board) != 0 && i % board_size(board) != board_size(board) - 1){
                board->f[board->flen++] = i;
            }
        
#ifdef BOARD_PAT3
        /* Initialize 3x3 pattern codes. */
        foreach_point(board) {
            if (board_at(board, c) == S_NONE)
                board->pat3[c] = pattern3_hash(board, c);
        } foreach_point_end;
#endif
    }
    
    struct board* board_copy(struct board *b2, struct board *b1)
    {
        // printf("board_copy: %lu\n", sizeof(struct board));
        memcpy(b2, b1, sizeof(struct board));
        
        // XXX: Special semantics.
        b2->fbook = NULL;
        // TODO b2->ps = NULL;
        memset(&b2->ps, 0, sizeof(struct moggy_state));
        
        return b2;
    }
    
    void board_done_noalloc(struct board *board)
    {
        if (board->fbook)
            fbook_done(board->fbook);
        {
            /*if (board->ps!=NULL){
             // printf("delete board ps\n");
             delete board->ps;
             }else{
             printf("error, why not delete board ps\n");
             }*/
            memset(&board->ps, 0, sizeof(struct moggy_state));
        }
    }
    
    void board_done(struct board *board)
    {
        board_done_noalloc(board);
        // TODO co le ko can free(board);
        // TODO cai nay phai check can than
        delete board;
    }
    
    void board_resize(struct board *board, int32_t size)
    {
#ifdef BOARD_SIZE
        assert(board_size(board) == size + 2);
#endif
        // assert(size <= BOARD_MAX_SIZE);
        if(!(size <= BOARD_MAX_SIZE)){
            printf("error, assert(size <= BOARD_MAX_SIZE): %d\n", size);
            size = BOARD_MAX_SIZE;
        }
        board->size = size + 2 /* S_OFFBOARD margin */;
        board->size2 = board_size(board) * board_size(board);
        
        board->bits2 = 1;
        while ((1 << board->bits2) < board->size2) board->bits2++;
    }
    
    void board_statics_init(struct board *board)
    {
        // printf("board_statics_init\n");
        int32_t size = board_size(board);
        
        memset(&board->board_statics, 0, sizeof(struct board_statics));
        board->board_statics.size = size;
        
        /* Setup neighborhood iterators */
        board->board_statics.nei8[0] = -size - 1; // (-1,-1)
        board->board_statics.nei8[1] = 1;
        board->board_statics.nei8[2] = 1;
        board->board_statics.nei8[3] = size - 2; // (-1,0)
        board->board_statics.nei8[4] = 2;
        board->board_statics.nei8[5] = size - 2; // (-1,1)
        board->board_statics.nei8[6] = 1;
        board->board_statics.nei8[7] = 1;
        board->board_statics.dnei[0] = -size - 1;
        board->board_statics.dnei[1] = 2;
        board->board_statics.dnei[2] = size*2 - 2;
        board->board_statics.dnei[3] = 2;
        
        /* Set up coordinate cache */
        foreach_point(board) {
            board->board_statics.coord[c][0] = c % board_size(board);
            board->board_statics.coord[c][1] = c / board_size(board);
            // printf("set up coordinate cache: %d (%d, %d)\n", c, board->board_statics.coord[c][0], board->board_statics.coord[c][1]);
        } foreach_point_end;
        
        /* Initialize zobrist hashtable. */
        /* We will need these to be stable across Pachi runs for
         * certain kinds of pattern matching, thus we do not use
         * fast_random() for this. */
        hash_t hseed = 0x3121110101112131;
        foreach_point(board) {
            board->board_statics.h[c][0] = (hseed *= 16807);
            if (!board->board_statics.h[c][0])
                board->board_statics.h[c][0] = 1;
            /* And once again for white */
            board->board_statics.h[c][1] = (hseed *= 16807);
            if (!board->board_statics.h[c][1])
                board->board_statics.h[c][1] = 1;
        } foreach_point_end;
    }
    
    void board_clear(struct board *board)
    {
        // int32_t size = board_size(board);
        floating_t komi = board->komi;
        char *fbookfile = board->fbookfile;
        enum go_ruleset rules = board->rules;
        
        board_done_noalloc(board);
        
        board_statics_init(board);
        board_init_data(board);
        
        board->komi = komi;
        board->fbookfile = fbookfile;
        board->rules = rules;
        
        if (board->fbookfile)
            board->fbook = fbook_init(board->fbookfile, board);
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// board capturable ///////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void board_capturable_add(struct board *board, group_t group, coord_t lib, bool onestone)
    {
        
#ifdef BOARD_PAT3
        int32_t fn__i = 0;
        foreach_neighbor(board, lib, {
            board->pat3[lib] |= (group_at(board, c) == group) << (16 + 3 - fn__i);
            fn__i++;
        });
#endif
        
#ifdef WANT_BOARD_C
        /* Update the list of capturable groups. */
        // assert(group);
        if(!group){
            printf("error, assert(group)\n");
        }
        // assert(board->clen < board_size2(board));
        if(!(board->clen < board_size2(board))){
            printf("error, assert(board->clen < board_size2(board))\n");
            board->clen = 0;
        }
        board->c[board->clen++] = group;
#endif
    }
    
    // bo static
    void board_capturable_rm(struct board *board, group_t group, coord_t lib, bool onestone)
    {
#ifdef BOARD_PAT3
        int32_t fn__i = 0;
        foreach_neighbor(board, lib, {
            board->pat3[lib] &= ~((group_at(board, c) == group) << (16 + 3 - fn__i));
            fn__i++;
        });
#endif
        
#ifdef WANT_BOARD_C
        /* Update the list of capturable groups. */
        for (int32_t i = 0; i < board->clen; i++)
            if (unlikely(board->c[i] == group)) {
                board->c[i] = board->c[--board->clen];
                return;
            }
        printf("rm of bad group %d\n", group_base(group));
        {
            // assert(0);
            printf("error, assert(0)\n");
        }
#endif
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// undo ///////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void undo_init(struct board *b, struct move *m, struct board_undo *u)
    {
        // Paranoid uninitialized mem test
        // memset(u, 0xff, sizeof(*u));
        
        u->last_move2 = b->last_move2;
        u->ko = b->ko;
        u->last_ko = b->last_ko;
        u->last_ko_age = b->last_ko_age;
        u->captures = 0;
        
        u->nmerged = u->nmerged_tmp = u->nenemies = 0;
        for (int32_t i = 0; i < 4; i++)
            u->merged[i].group = u->enemies[i].group = 0;
    }
    
    // bo static
    group_t profiling_noinline new_group(struct board *board, coord_t coord, struct board_undo *u)
    {
        group_t group = coord;
        struct group *gi = board_group_info(board, group);
        foreach_neighbor(board, coord, {
            if (board_at(board, c) == S_NONE)
            /* board_group_addlib is ridiculously expensive for us */
/*#if GROUP_KEEP_LIBS < 4
                if (gi->libs < GROUP_KEEP_LIBS)
#endif*/
                if (gi->libs < GROUP_KEEP_LIBS)
                    gi->lib[gi->libs++] = c;
        });
        
        group_set(board, coord, group);
        groupnext_set(board, coord, 0);
        
        if (!u)
            if (gi->libs == 1)
                board_capturable_add(board, group, gi->lib[0], true);
        
        if (DEBUGL(8)){
            board_statics* board_statics = &board->board_statics;
            printf("new_group: added %d,%d to group %d\n", coord_x(board_statics, coord, board), coord_y(board_statics, coord, board), group_base(group));
        }
        
        return group;
    }
    
    // bo static
    inline void undo_save_merge(struct board *b, struct board_undo *u, group_t g, coord_t c)
    {
        if (g == u->merged[0].group || g == u->merged[1].group ||
            g == u->merged[2].group || g == u->merged[3].group)
            return;

        int32_t i = u->nmerged++;
        if (!i)
            u->inserted = c;
        u->merged[i].group = g;
        u->merged[i].last = 0;   // can remove
        u->merged[i].info = *board_group_info(b, g);
    }
    
    // bo static
    inline void undo_save_enemy(struct board *b, struct board_undo *u, group_t g)
    {
        if (g == u->enemies[0].group || g == u->enemies[1].group ||
            g == u->enemies[2].group || g == u->enemies[3].group)
            return;

        int32_t i = u->nenemies++;
        u->enemies[i].group = g;
        u->enemies[i].info = *board_group_info(b, g);

        int32_t j = 0;
        coord_t *stones = u->enemies[i].stones;
        if (board_group_info(b, g)->libs <= 1) { // Will be captured
            foreach_in_group(b, g) {
                stones[j++] = c;
            } foreach_in_group_end;
            u->captures += j;
        }
        stones[j] = 0;
    }
    
    // bo static
    void undo_save_group_info(struct board *b, coord_t coord, enum stone color, struct board_undo *u)
    {
        u->next_at = groupnext_at(b, coord);
        
        foreach_neighbor(b, coord, {
            group_t g = group_at(b, c);
            
            if (board_at(b, c) == color)
                undo_save_merge(b, u, g, c);
            else if (board_at(b, c) == stone_other(color))
                undo_save_enemy(b, u, g);
        });
    }
    
    // bo static
    void undo_save_suicide(struct board *b, coord_t coord, enum stone color, struct board_undo *u)
    {
        foreach_neighbor(b, coord, {
            if (board_at(b, c) == color) {
                // Handle suicide as a capture ...
                undo_save_enemy(b, u, group_at(b, c));
                return;
            }
        });
        {
            // assert(0);
            printf("error, assert(0)\n");
        }
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// Board_Group ///////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void board_group_find_extra_libs(struct board *board, group_t group, struct group *gi, coord_t avoid)
    {
        /* Add extra liberty from the board to our liberty list. */
        
        unsigned char* watermark = new unsigned char[board_size2(board) / 8];
        
        memset(watermark, 0, sizeof(unsigned char)*board_size2(board) / 8);
#define watermark_get(c)	(watermark[c >> 3] & (1 << (c & 7)))
#define watermark_set(c)	watermark[c >> 3] |= (1 << (c & 7))
        
        for (int32_t i = 0; i < GROUP_KEEP_LIBS - 1; i++)
            watermark_set(gi->lib[i]);
        watermark_set(avoid);
        
        foreach_in_group(board, group) {
            coord_t coord2 = c;
            foreach_neighbor(board, coord2, {
                if (board_at(board, c) + watermark_get(c) != S_NONE)
                    continue;
                watermark_set(c);
                gi->lib[gi->libs++] = c;
                if (unlikely(gi->libs >= GROUP_KEEP_LIBS)){
                    delete [] watermark;
                    return;
                }
            } );
        } foreach_in_group_end;
#undef watermark_get
#undef watermark_set
        
        delete [] watermark;
        
    }
    
    // bo static
    void board_group_rmlib(struct board *board, group_t group, coord_t coord, struct board_undo *u)
    {
        /*if (DEBUGL(7)){
         char strCoord1[256];
         {
         coord2sstr(strCoord1, group_base(group), board);
         }
         char strCoord2[256];
         {
         coord2sstr(strCoord2, coord, board);
         }
         printf("Group %d[%s] %d: Removing liberty %s\n", group_base(group), strCoord1, board_group_info(board, group).libs, strCoord2);
         }*/
        
        struct group *gi = board_group_info(board, group);
        bool onestone = group_is_onestone(board, group);
        for (int32_t i = 0; i < GROUP_KEEP_LIBS; i++) {
#if 0
            /* Seems extra branch just slows it down */
            if (!gi->lib[i])
                break;
#endif
            if (likely(gi->lib[i] != coord))
                continue;
            
            coord_t lib = gi->lib[i] = gi->lib[--gi->libs];
            gi->lib[gi->libs] = 0;
            
            /* Postpone refilling lib[] until we need to. */
            {
                // assert(GROUP_REFILL_LIBS > 1);
                if(!(GROUP_REFILL_LIBS > 1)){
                    printf("error, assert(GROUP_REFILL_LIBS > 1)\n");
                }
            }
            if (gi->libs > GROUP_REFILL_LIBS)
                return;
            if (gi->libs == GROUP_REFILL_LIBS)
                board_group_find_extra_libs(board, group, gi, coord);
            if (u) return;
            
            if (gi->libs == 1)
                board_capturable_add(board, group, gi->lib[0], onestone);
            else if (gi->libs == 0)
                board_capturable_rm(board, group, lib, onestone);
            return;
        }
        
        /* This is ok even if gi->libs < GROUP_KEEP_LIBS since we
         * can call this multiple times per coord. */
        return;
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// board print /////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void board_print_top(struct board *board, strbuf_t *buf, int32_t c)
    {
        for (int32_t i = 0; i < c; i++) {
            char asdf[] = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            sbprintf(buf, "      ");
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sbprintf(buf, "%c ", asdf[x - 1]);
            sbprintf(buf, " ");
        }
        sbprintf(buf, "\n");
        for (int32_t i = 0; i < c; i++) {
            sbprintf(buf, "    +-");
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sbprintf(buf, "--");
            sbprintf(buf, "+");
        }
        sbprintf(buf, "\n");
    }
    
    // bo static
    void board_print_bottom(struct board *board, strbuf_t *buf, int32_t c)
    {
        for (int32_t i = 0; i < c; i++) {
            sbprintf(buf, "    +-");
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sbprintf(buf, "--");
            sbprintf(buf, "+");
        }
        sbprintf(buf, "\n");
    }
    
    // bo static
    void board_print_row(struct board *board, int32_t y, strbuf_t *buf, board_cprint cprint, void *data)
    {
        sbprintf(buf, " %2d | ", y);
        board_statics* board_statics = &board->board_statics;
        for (int32_t x = 1; x < board_size(board) - 1; x++){
            if (coord_x(board_statics, board->last_move.coord, board) == x && coord_y(board_statics, board->last_move.coord, board) == y)
                sbprintf(buf, "%c)", stone2char(board_atxy(board, x, y)));
            else
                sbprintf(buf, "%c ", stone2char(board_atxy(board, x, y)));
        }
        sbprintf(buf, "|");
        if (cprint) {
            sbprintf(buf, " %2d | ", y);
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                cprint(board, coord_xy(board, x, y), buf, data);
            sbprintf(buf, "|");
        }
        sbprintf(buf, "\n");
    }
    
    void board_print_custom(struct board *board, FILE* f, board_cprint cprint, void *data)
    {
        char buffer[10240];
        strbuf_t strbuf;
        strbuf_t *buf = strbuf_init(&strbuf, buffer, sizeof(buffer));
        sbprintf(buf, "Move: % 3d  Komi: %2.1f  Handicap: %d  Captures B: %d W: %d  ", board->moves, board->komi, board->handicap, board->captures[S_BLACK], board->captures[S_WHITE]);
        if (cprint) /* handler can add things to header when called with pass */
            cprint(board, pass, buf, data);
        sbprintf(buf, "\n");
        board_print_top(board, buf, 1 + !!cprint);
        for (int32_t y = board_size(board) - 2; y >= 1; y--)
            board_print_row(board, y, buf, cprint, data);
        board_print_bottom(board, buf, 1 + !!cprint);
        fprintf(f, "%s\n", buf->str);
    }
    
    // bo static
    void cprint_group(struct board *board, coord_t c, strbuf_t *buf, void *data)
    {
        sbprintf(buf, "%d ", group_base(group_at(board, c)));
    }
    
    void board_print(struct board *board, FILE* f)
    {
        board_print_custom(board, f, DEBUGL(6) ? cprint_group : NULL, NULL);
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// board print char* /////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    void board_print_top(struct board *board, char* f, int32_t c)
    {
        for (int32_t i = 0; i < c; i++) {
            char asdf[] = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            sprintf(f, "%s      ", f);
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sprintf(f, "%s%c ", f, asdf[x - 1]);
            sprintf(f, "%s ", f);
        }
        sprintf(f, "%s\n", f);
        for (int32_t i = 0; i < c; i++) {
            sprintf(f, "%s    +-", f);
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sprintf(f, "%s--", f);
            sprintf(f, "%s+", f);
        }
        sprintf(f, "%s\n", f);
    }
    
    void board_print_row(struct board *board, int32_t y, char* f, my_board_cprint cprint, void *data)
    {
        sprintf(f, "%s %2d | ", f, y);
        board_statics* board_statics = &board->board_statics;
        // printf("last move: %d\n", board->last_move.coord);
        for (int32_t x = 1; x < board_size(board) - 1; x++){
            // check is last move
            int32_t lastMoveIndex = 0;
            {
                // lastMove
                if(lastMoveIndex==0){
                    int32_t coordX = coord_x(board_statics, board->last_move.coord, board);
                    int32_t coordY = coord_y(board_statics, board->last_move.coord, board);
                    if(coordX == x && coordY == y){
                        lastMoveIndex = 1;
                    }
                }
                // lastMove2
                if(lastMoveIndex==0){
                    int32_t coordX = coord_x(board_statics, board->last_move2.coord, board);
                    int32_t coordY = coord_y(board_statics, board->last_move2.coord, board);
                    if(coordX == x && coordY == y){
                        lastMoveIndex = 2;
                    }
                }
                // lastMove3
                if(lastMoveIndex==0){
                    int32_t coordX = coord_x(board_statics, board->last_move3.coord, board);
                    int32_t coordY = coord_y(board_statics, board->last_move3.coord, board);
                    if(coordX == x && coordY == y){
                        lastMoveIndex = 3;
                    }
                }
                // lastMove4
                if(lastMoveIndex==0){
                    int32_t coordX = coord_x(board_statics, board->last_move4.coord, board);
                    int32_t coordY = coord_y(board_statics, board->last_move4.coord, board);
                    if(coordX == x && coordY == y){
                        lastMoveIndex = 4;
                    }
                }
            }
            switch (lastMoveIndex) {
                case 0:
                {
                    sprintf(f, "%s%c ", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
                case 1:
                {
                    sprintf(f, "%s%c1", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
                case 2:
                {
                    sprintf(f, "%s%c2", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
                case 3:
                {
                    sprintf(f, "%s%c3", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
                case 4:
                {
                    sprintf(f, "%s%c4", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
                default:
                {
                    printf("error, unknown lastMoveIndex: %d\n", lastMoveIndex);
                    sprintf(f, "%s%c ", f, stone2char(board_atxy(board, x, y)));
                }
                    break;
            }
        }
        sprintf(f, "%s|", f);
        if (cprint) {
            sprintf(f, "%s %2d | ", f, y);
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                cprint(board, coord_xy(board, x, y), f, data);
            sprintf(f, "%s|", f);
        }
        sprintf(f, "%s\n", f);
    }
    
    void board_print_bottom(struct board *board, char* f, int32_t c)
    {
        for (int32_t i = 0; i < c; i++) {
            sprintf(f, "%s    +-", f);
            for (int32_t x = 1; x < board_size(board) - 1; x++)
                sprintf(f, "%s--", f);
            sprintf(f, "%s+", f);
        }
        sprintf(f, "%s\n", f);
    }
    
    void board_print_custom(struct board *board, char* f, my_board_cprint cprint, void *data)
    {
        sprintf(f, "%sMove: % 3d  Komi: %2.1f  Handicap: %d  Captures B: %d W: %d  ", f, board->moves, board->komi, board->handicap, board->captures[S_BLACK], board->captures[S_WHITE]);
        if (cprint) /* handler can add things to header when called with pass */
            cprint(board, pass, f, data);
        sprintf(f, "%s\n", f);
        board_print_top(board, f, 1 + !!cprint);
        for (int32_t y = board_size(board) - 2; y >= 1; y--){
            board_print_row(board, y, f, cprint, data);
        }
        board_print_bottom(board, f, 1 + !!cprint);
    }
    
    void my_print_group(struct board *board, coord_t c, char* f, void *data)
    {
        sprintf(f, "%s%d ", f, group_base(group_at(board, c)));
    }
    
    void board_print(struct board *board, char* f, int32_t flen)
    {
        board_print_custom(board, f, DEBUGL(6) ? my_print_group : NULL, NULL);
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// board hash /////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    /* Update board hash with given coordinate. */
    // bo static
    void profiling_noinline board_hash_update(struct board *board, coord_t coord, enum stone color)
    {
        board_statics* board_statics = &board->board_statics;
        board->hash ^= hash_at(board_statics, board, coord, color);
        board->qhash[coord_quadrant(board_statics, coord, board)] ^= hash_at(board_statics, board, coord, color);
        if (DEBUGL(8))
        {
            printf("board_hash_update(%d,%d,%d) ^ %" PRIhash" -> %" PRIhash"\n", color, coord_x(board_statics, coord, board), coord_y(board_statics, coord, board), hash_at(board_statics, board, coord, color), board->hash);
        }
        
#if defined(BOARD_PAT3)
        /* @color is not what we need in case of capture. */
        // bo static
        const int32_t ataribits[8] = { -1, 0, -1, 1, 2, -1, 3, -1 };
        enum stone new_color = board_at(board, coord);
        bool in_atari = false;
        if (new_color == S_NONE)
            board->pat3[coord] = pattern3_hash(board, coord);
        else
            in_atari = (board_group_info(board, group_at(board, coord))->libs == 1);
        foreach_8neighbor(board_statics, board, coord) {
            /* Internally, the loop uses fn__i=[0..7]. We can use
             * it directly to address bits within the bitmap of the
             * neighbors since the bitmap order is reverse to the
             * loop order. */
            if (board_at(board, c) != S_NONE)
                continue;
            board->pat3[c] &= ~(3 << (fn__i*2));
            board->pat3[c] |= new_color << (fn__i*2);
            if (ataribits[fn__i] >= 0) {
                board->pat3[c] &= ~(1 << (16 + ataribits[fn__i]));
                board->pat3[c] |= in_atari << (16 + ataribits[fn__i]);
            }
        } foreach_8neighbor_end;
#endif
    }
    
    /* Commit current board hash to history. */
    // bo static
    void profiling_noinline board_hash_commit(struct board *board)
    {
        if (DEBUGL(8)){
            printf("board_hash_commit %" PRIhash"\n", board->hash);
        }
        if (likely(board->history_hash[board->hash & history_hash_mask]) == 0) {
            board->history_hash[board->hash & history_hash_mask] = board->hash;
            return;
        }
        
        hash_t i = board->hash;
        while (board->history_hash[i & history_hash_mask]) {
            if (board->history_hash[i & history_hash_mask] == board->hash) {
                if (DEBUGL(5)){
                    board_statics* board_statics = &board->board_statics;
                    printf("SUPERKO VIOLATION noted at %d,%d\n", coord_x(board_statics, board->last_move.coord, board), coord_y(board_statics, board->last_move.coord, board));
                }
                board->superko_violation = true;
                return;
            }
            i = history_hash_next(i);
        }
        board->history_hash[i & history_hash_mask] = board->hash;
    }
    
    void board_symmetry_update(struct board *b, struct board_symmetry *symmetry, coord_t c)
    {
        if (likely(symmetry->type == SYM_NONE)) {
            /* Fully degenerated already. We do not support detection
             * of restoring of symmetry, assuming that this is too rare
             * a case to handle. */
            return;
        }
        board_statics* board_statics = &b->board_statics;
        int32_t x = coord_x(board_statics, c, b);
        int32_t y = coord_y(board_statics, c, b);
        // printf("board_symmetry_update: coordX, coordY: %d (%d, %d)\n", c, x, y);
        int32_t t = board_size(b) / 2;
        int32_t dx = board_size(b) - 1 - x; /* for SYM_DOWN */
        if (DEBUGL(6))
        {
            printf("SYMMETRY [%d,%d,%d,%d|%d=%d] update for %d,%d\n", symmetry->x1, symmetry->y1, symmetry->x2, symmetry->y2, symmetry->d, symmetry->type, x, y);
        }
        
        switch (symmetry->type) {
            case SYM_FULL:
                if (x == t && y == t)
                    return;        /* Tengen keeps full symmetry. */
                
                /* New symmetry now? */
                if (x == y) {
                    symmetry->type = SYM_DIAG_UP;
                    symmetry->x1 = symmetry->y1 = 1;
                    symmetry->x2 = symmetry->y2 = board_size(b) - 1;
                    symmetry->d = 1;
                } else if (dx == y) {
                    symmetry->type = SYM_DIAG_DOWN;
                    symmetry->x1 = symmetry->y1 = 1;
                    symmetry->x2 = symmetry->y2 = board_size(b) - 1;
                    symmetry->d = 1;
                } else if (x == t) {
                    symmetry->type = SYM_HORIZ;
                    symmetry->y1 = 1;
                    symmetry->y2 = board_size(b) - 1;
                    symmetry->d = 0;
                } else if (y == t) {
                    symmetry->type = SYM_VERT;
                    symmetry->x1 = 1;
                    symmetry->x2 = board_size(b) - 1;
                    symmetry->d = 0;
                } else {
                break_symmetry:
                    symmetry->type = SYM_NONE;
                    symmetry->x1 = symmetry->y1 = 1;
                    symmetry->x2 = symmetry->y2 = board_size(b) - 1;
                    symmetry->d = 0;
                }
                break;
            case SYM_DIAG_UP:
                if (x == y)
                    return;
                goto break_symmetry;
            case SYM_DIAG_DOWN:
                if (dx == y)
                    return;
                goto break_symmetry;
            case SYM_HORIZ:
                if (x == t)
                    return;
                goto break_symmetry;
            case SYM_VERT:
                if (y == t)
                    return;
                goto break_symmetry;
            case SYM_NONE:
            {
                // assert(0);
                printf("error, assert(0)\n");
            }
                break;
        }
        
        if (DEBUGL(6))
        {
            printf("NEW SYMMETRY [%d,%d,%d,%d|%d=%d]\n", symmetry->x1, symmetry->y1, symmetry->x2, symmetry->y2, symmetry->d, symmetry->type);
        }
        /* Whew. */
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// Board_Play ///////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void profiling_noinline merge_groups(struct board *board, group_t group_to, group_t group_from, struct board_undo *u)
    {
        if (DEBUGL(7)){
            printf("board_play_raw: merging groups %d -> %d\n", group_base(group_from), group_base(group_to));
        }
        struct group *gi_from = board_group_info(board, group_from);
        struct group *gi_to = board_group_info(board, group_to);
        bool onestone_from = group_is_onestone(board, group_from);
        bool onestone_to = group_is_onestone(board, group_to);
        
        if (!u)
        /* We do this early before the group info is rewritten. */
            if (gi_from->libs == 1)
                board_capturable_rm(board, group_from, gi_from->lib[0], onestone_from);
        
        if (DEBUGL(7)){
            printf("---- (froml %d, tol %d)\n", gi_from->libs, gi_to->libs);
        }
        
        if (gi_to->libs < GROUP_KEEP_LIBS) {
            for (int32_t i = 0; i < gi_from->libs; i++) {
                for (int32_t j = 0; j < gi_to->libs; j++)
                    if (gi_to->lib[j] == gi_from->lib[i])
                        goto next_from_lib;
                if (!u) {
                    if (gi_to->libs == 0)
                        board_capturable_add(board, group_to, gi_from->lib[i], onestone_to);
                    else if (gi_to->libs == 1)
                        board_capturable_rm(board, group_to, gi_to->lib[0], onestone_to);
                }
                gi_to->lib[gi_to->libs++] = gi_from->lib[i];
                if (gi_to->libs >= GROUP_KEEP_LIBS)
                    break;
            next_from_lib:;
            }
        }
        
        if (!u && gi_to->libs == 1) {
            coord_t lib = board_group_info(board, group_to)->lib[0];
#ifdef BOARD_PAT3
            if (gi_from->libs == 1) {
                /* We removed group_from from capturable groups,
                 * therefore switching the atari flag off.
                 * We need to set it again since group_to is also
                 * capturable. */
                int32_t fn__i = 0;
                foreach_neighbor(board, lib, {
                    board->pat3[lib] |= (group_at(board, c) == group_from) << (16 + 3 - fn__i);
                    fn__i++;
                });
            }
#endif
        }
        
        coord_t last_in_group;
        foreach_in_group(board, group_from) {
            last_in_group = c;
            group_set(board, c, group_to);
        } foreach_in_group_end;
        
        if (u) u->merged[++u->nmerged_tmp].last = last_in_group;
        groupnext_set(board, last_in_group, groupnext_at(board, group_base(group_to)));
        groupnext_set(board, group_base(group_to), group_base(group_from));
        memset(gi_from, 0, sizeof(struct group));
        
        if (DEBUGL(7)){
            printf("board_play_raw: merged group: %d\n", group_base(group_to));
        }
    }
    
    // bo static
    void board_group_addlib(struct board *board, group_t group, coord_t coord, struct board_undo *u)
    {
        /*if (DEBUGL(7)){
         char strCoord1[256];
         {
         coord2sstr(strCoord1, group_base(group), board);
         }
         char strCoord2[256];
         {
         coord2sstr(strCoord2, coord, board);
         }
         printf("Group %d[%s] %d: Adding liberty %s\n", group_base(group), strCoord1, board_group_info(board, group).libs, strCoord2);
         }*/
        
        struct group *gi = board_group_info(board, group);
        bool onestone = group_is_onestone(board, group);
        if (gi->libs < GROUP_KEEP_LIBS) {
            for (int32_t i = 0; i < GROUP_KEEP_LIBS; i++) {
#if 0
                /* Seems extra branch just slows it down */
                if (!gi->lib[i])
                    break;
#endif
                if (unlikely(gi->lib[i] == coord))
                    return;
            }
            if (!u) {
                if (gi->libs == 0)
                    board_capturable_add(board, group, coord, onestone);
                else if (gi->libs == 1)
                    board_capturable_rm(board, group, gi->lib[0], onestone);
            }
            gi->lib[gi->libs++] = coord;
        }
    }
    
    /* This is a low-level routine that doesn't maintain consistency
     * of all the board data structures. */
    // bo static
    void board_remove_stone(struct board *board, group_t group, coord_t c, struct board_undo *u)
    {
        enum stone color = board_at(board, c);
        board_set(board, c, S_NONE);
        group_set(board, c, 0);
        if (!u){
            board_hash_update(board, c, color);
        }
        
        /* Increase liberties of surrounding groups */
        coord_t coord = c;
        foreach_neighbor(board, coord, {
            dec_neighbor_count_at(board, c, color);
            group_t g = group_at(board, c);
            if (g && g != group)
                board_group_addlib(board, g, coord, u);
        });
        if (u) return;
        
#ifdef BOARD_PAT3
        /* board_hash_update() might have seen the freed up point as able
         * to capture another group in atari that only after the loop
         * above gained enough liberties. Reset pat3 again. */
        board->pat3[c] = pattern3_hash(board, c);
#endif
        
        if (DEBUGL(6)){
            board_statics* board_statics = &board->board_statics;
            printf("pushing free move [%d]: %d,%d\n", board->flen, coord_x(board_statics, c, board), coord_y(board_statics, c, board));
        }
        board_addf(board, c);
    }
    
    // bo static
    int32_t profiling_noinline board_group_capture(struct board *board, group_t group, struct board_undo *u)
    {
        int32_t stones = 0;
        
        foreach_in_group(board, group) {
            board->captures[stone_other(board_at(board, c))]++;
            board_remove_stone(board, group, c, u);
            stones++;
        } foreach_in_group_end;
        
        struct group *gi = board_group_info(board, group);
        {
            // assert(gi->libs == 0);
            if(!(gi->libs == 0)){
                printf("error, assert(gi->libs == 0)\n");
            }
        }
        memset(gi, 0, sizeof(*gi));
        
        return stones;
    }
    
    // bo static
    void profiling_noinline add_to_group(struct board *board, group_t group, coord_t prevstone, coord_t coord, struct board_undo *u)
    {
        group_set(board, coord, group);
        groupnext_set(board, coord, groupnext_at(board, prevstone));
        groupnext_set(board, prevstone, coord);
        
        foreach_neighbor(board, coord, {
            if (board_at(board, c) == S_NONE)
                board_group_addlib(board, group, c, u);
        });
        
        if (DEBUGL(8)){
            board_statics* board_statics = &board->board_statics;
            printf("add_to_group: added (%d,%d ->) %d,%d (-> %d,%d) to group %d\n", coord_x(board_statics, prevstone, board), coord_y(board_statics, prevstone, board), coord_x(board_statics, coord, board), coord_y(board_statics, coord, board), groupnext_at(board, coord) % board_size(board), groupnext_at(board, coord) / board_size(board), group_base(group));
        }
    }
    
    // bo static
    inline group_t play_one_neighbor(struct board *board, coord_t coord, enum stone color, enum stone other_color, coord_t c, group_t group, struct board_undo *u)
    {
        enum stone ncolor = board_at(board, c);
        group_t ngroup = group_at(board, c);
        
        inc_neighbor_count_at(board, c, color);
        
        if (!ngroup)
            return group;
        
        board_group_rmlib(board, ngroup, coord, u);
        if (DEBUGL(7)){
            printf("board_play_raw: reducing libs for group %d (%d:%d,%d)\n", group_base(ngroup), ncolor, color, other_color);
        }
        
        if (ncolor == color && ngroup != group) {
            if (!group) {
                group = ngroup;
                add_to_group(board, group, c, coord, u);
            } else
                merge_groups(board, group, ngroup, u);
        } else if (ncolor == other_color) {
            if (DEBUGL(8)) {
                struct group *gi = board_group_info(board, ngroup);
                {
                    char strCoord[256];
                    {
                        coord2sstr(strCoord, group_base(ngroup), board);
                    }
                    printf("testing captured group %d[%s]: ", group_base(ngroup), strCoord);
                }
                for (int32_t i = 0; i < GROUP_KEEP_LIBS; i++){
                    char strCoord[256];
                    {
                        coord2sstr(strCoord, gi->lib[i], board);
                    }
                    printf("%s ", strCoord);
                }
                printf("\n");
            }
            if (unlikely(board_group_captured(board, ngroup)))
                board_group_capture(board, ngroup, u);
        }
        return group;
    }
    
    /* We played on a place with at least one liberty. We will become a member of
     * some group for sure. */
    group_t profiling_noinline board_play_outside(struct board *board, struct move *m, int32_t f, struct board_undo *u)
    {
        coord_t coord = m->coord;
        enum stone color = m->color;
        enum stone other_color = stone_other(color);
        group_t group = 0;
        
        if (u)
            undo_save_group_info(board, coord, color, u);
        else {
            // printf("board_play_outside: board_rmf: %d\n", f);
            board_rmf(board, f);
            if (DEBUGL(6)){
                printf("popping free move [%d->%d]: %d\n", board->flen, f, board->f[f]);
            }
        }
        foreach_neighbor(board, coord, {
            group = play_one_neighbor(board, coord, color, other_color, c, group, u);
        });
        
        board_set(board, coord, color);
        if (unlikely(!group))
            group = new_group(board, coord, u);
        
        if (!u) {
            board->last_move4 = board->last_move3;
            board->last_move3 = board->last_move2;
        }
        board->last_move2 = board->last_move;
        board->last_move = *m;
        board->moves++;
        if (!u) {
            board_hash_update(board, coord, color);
            board_symmetry_update(board, &board->symmetry, coord);
        }
        struct move ko = { pass, S_NONE };
        board->ko = ko;
        
        return group;
    }
    
    /* We played in an eye-like shape. Either we capture at least one of the eye
     * sides in the process of playing, or return -1. */
    // bo static
    int32_t profiling_noinline board_play_in_eye(struct board *board, struct move *m, int32_t f, struct board_undo *u)
    {
        coord_t coord = m->coord;
        enum stone color = m->color;
        /* Check ko: Capture at a position of ko capture one move ago */
        if (unlikely(color == board->ko.color && coord == board->ko.coord)) {
            if (DEBUGL(5)){
                board_statics* board_statics = &board->board_statics;
                printf("board_check: ko at %d,%d color %d\n", coord_x(board_statics, coord, board), coord_y(board_statics, coord, board), color);
            }
            return -1;
        } else if (DEBUGL(6)){
            board_statics* board_statics = &board->board_statics;
            printf("board_check: no ko at %d,%d,%d - ko is %d,%d,%d\n", color, coord_x(board_statics, coord, board), coord_y(board_statics, coord, board), board->ko.color, coord_x(board_statics, board->ko.coord, board), coord_y(board_statics, board->ko.coord, board));
        }
        
        struct move ko = { pass, S_NONE };

        int32_t captured_groups = 0;
        
        foreach_neighbor(board, coord, {
            group_t g = group_at(board, c);
            if (DEBUGL(7)){
                printf("board_check: group %d has %d libs\n", g, board_group_info(board, g)->libs);
            }
            captured_groups += (board_group_info(board, g)->libs == 1);
        });
        
        if (likely(captured_groups == 0)) {
            if (DEBUGL(5)) {
                if (DEBUGL(6))  board_print(board, stderr);
                printf("board_check: one-stone suicide\n");
            }
            return -1;
        }
        
        if (!u) {
            // printf("board_play_in_eye: board_rmf: %d\n", f);
            board_rmf(board, f);
            if (DEBUGL(6))
                printf("popping free move [%d->%d]: %d\n", board->flen, f, board->f[f]);
        }
        else
            undo_save_group_info(board, coord, color, u);

        int32_t ko_caps = 0;
        coord_t cap_at = pass;
        foreach_neighbor(board, coord, {
            inc_neighbor_count_at(board, c, color);
            
            group_t group = group_at(board, c);
            if (!group)
                continue;
            
            board_group_rmlib(board, group, coord, u);
            if (DEBUGL(7))
                printf("board_play_raw: reducing libs for group %d\n", group_base(group));
            
            if (board_group_captured(board, group)) {
                ko_caps += board_group_capture(board, group, u);
                cap_at = c;
            }
        });
        if (ko_caps == 1) {
            ko.color = stone_other(color);
            ko.coord = cap_at; // unique
            board->last_ko = ko;
            board->last_ko_age = board->moves;
            if (DEBUGL(5)){
                char strCoord[256];
                {
                    coord2sstr(strCoord, ko.coord, board);
                }
                printf("guarding ko at %d,%s\n", ko.color, strCoord);
            }
        }
        
        board_set(board, coord, color);
        group_t group = new_group(board, coord, u);
        
        if (!u) {
            board->last_move4 = board->last_move3;
            board->last_move3 = board->last_move2;
        }
        board->last_move2 = board->last_move;
        board->last_move = *m;
        board->moves++;
        if (!u) {
            board_hash_update(board, coord, color);
            board_hash_commit(board);
            board_symmetry_update(board, &board->symmetry, coord);
        }
        board->ko = ko;
        
        return !!group;
    }
    
    // bo static
    
#ifdef _MSC_VER
    int32_t board_play_f(struct board *board, struct move *m, int32_t f, struct board_undo *u)
#else
    int32_t __attribute__((flatten)) board_play_f(struct board *board, struct move *m, int32_t f, struct board_undo *u)
#endif
    {
        // printf("board_play_f: %p: %d\n", board, f);
        if (DEBUGL(7)){
            board_statics* board_statics = &board->board_statics;
            char strCoord[256];
            {
                coord2sstr(strCoord, m->coord, board);
            }
            printf("board_play(%s): ---- Playing %d,%d\n", strCoord, coord_x(board_statics, m->coord, board), coord_y(board_statics, m->coord, board));
        }
        if (likely(!board_is_eyelike(board, m->coord, stone_other(m->color)))) {
            /* NOT playing in an eye. Thus this move has to succeed. (This
             * is thanks to New Zealand rules. Otherwise, multi-stone
             * suicide might fail.) */
            group_t group = board_play_outside(board, m, f, u);
            if (unlikely(board_group_captured(board, group))) {
                if (u) undo_save_suicide(board, m->coord, m->color, u);
                board_group_capture(board, group, u);
            }
            if (!u)
                board_hash_commit(board);
            return 0;
        } else
            return board_play_in_eye(board, m, f, u);
    }
    
    // bo static
    int32_t board_play_(struct board *board, struct move *m, struct board_undo *u)
    {
        // printf("board_play\n");
#ifdef BOARD_UNDO_CHECKS
        {
            // assert(u || !board->quicked);
            if(!(u || !board->quicked)){
                printf("error, assert(u || !board->quicked)\n");
            }
        }
#endif
        
        if (u) undo_init(board, m, u);
        
        if (unlikely(is_pass(m->coord) || is_resign(m->coord))) {
            if (is_pass(m->coord) && board->rules == RULES_SIMING) {
                /* On pass, the player gives a pass stone
                 * to the opponent. */
                board->captures[stone_other(m->color)]++;
            }
            struct move nomove = { pass, S_NONE };
            board->ko = nomove;
            if (!u) {
                board->last_move4 = board->last_move3;
                board->last_move3 = board->last_move2;
            }
            board->last_move2 = board->last_move;
            board->last_move = *m;
            board->moves++;
            return 0;
        }
        
        if (unlikely(board_at(board, m->coord) != S_NONE)) {
            if (DEBUGL(7))
                printf("error, board_check: stone exists\n");
            return -1;
        }

        int32_t f = (u ? -1 : board->fmap[m->coord]);
        return board_play_f(board, m, f, u);
    }

    int32_t board_play(struct board *board, struct move *m)
    {
        // khoi tao board_statics
        {
            int32_t size = board_size(board);
            if(board->board_statics.size!=size){
                // TODO can xem lai
                // printf("error, why board_statics not init: %p\n", board);
                board_statics_init(board);
            }
        }
        int32_t ret = board_play_(board, m, NULL);
        {
            // TODO Test
            {
                bool freePointCorrect = true;
                foreach_free_point(board) {
                    if(!(board_at(board, c) == S_NONE)){
                        //printf("error, uct_playout: why not correct free point: %p: %d, %d, %d\n", board, c, board->flen, board_at(board, c));
                        freePointCorrect = false;
                    }
                } foreach_free_point_end;
                if(!freePointCorrect){
                    // printf("error, free point not correct: %p\n", board);
                    // sua lai
                    {
                        board->flen = 0;
                        for (int32_t i = board_size(board); i < (board_size(board) - 1) * board_size(board); i++)
                            if (i % board_size(board) != 0 && i % board_size(board) != board_size(board) - 1){
                                if(board_at(board, i) == S_NONE){
                                    board->fmap[i] = board->flen;
                                    board->f[board->flen++] = i;
                                }
                            }
                    }
                }
            }
        }
        return ret;
    }

    int32_t board_quick_play(struct board *board, struct move *m, struct board_undo *u)
    {
        int32_t r = board_play_(board, m, u);
#ifdef BOARD_UNDO_CHECKS
        if (r >= 0)
            board->quicked++;
#endif
        return r;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// Undo /////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    inline void undo_merge(struct board *b, struct board_undo *u, struct move *m)
    {
        coord_t coord = m->coord;
        group_t group = group_at(b, coord);
        struct undo_merge *merged = u->merged;
        
        // Others groups, in reverse order ...
        for (int32_t i = u->nmerged - 1; i > 0; i--) {
            group_t old_group = merged[i].group;
            
            *board_group_info(b, old_group) = merged[i].info;
            
            groupnext_set(b, group_base(group), groupnext_at(b, merged[i].last));
            groupnext_set(b, merged[i].last, 0);
            
#if 0
            printf("merged_group[%i]:   (last: %s)", i, coord2sstr(merged[i].last, b));
            foreach_in_group(b, old_group) {
                printf("%s ", coord2sstr(c, b));
            } foreach_in_group_end;
            printf("\n");
#endif
            
            foreach_in_group(b, old_group) {
                group_set(b, c, old_group);
            } foreach_in_group_end;
        }
        
        // Restore first group
        groupnext_set(b, u->inserted, groupnext_at(b, coord));
        *board_group_info(b, merged[0].group) = merged[0].info;
        
#if 0
        printf("merged_group[0]: ");
        foreach_in_group(b, merged[0].group) {
            printf("%s ", coord2sstr(c, b));
        } foreach_in_group_end;
        printf("\n");
#endif
    }
    
    // bo static
    inline void restore_enemies(struct board *b, struct board_undo *u, struct move *m)
    {
        enum stone color = m->color;
        enum stone other_color = stone_other(m->color);
        
        struct undo_enemy *enemy = u->enemies;
        for (int32_t i = 0; i < u->nenemies; i++) {
            group_t old_group = enemy[i].group;
            
            *board_group_info(b, old_group) = enemy[i].info;
            
            coord_t *stones = enemy[i].stones;
            for (int32_t j = 0; stones[j]; j++) {
                board_set(b, stones[j], other_color);
                group_set(b, stones[j], old_group);
                groupnext_set(b, stones[j], stones[j + 1]);
                
                foreach_neighbor(b, stones[j], {
                    inc_neighbor_count_at(b, c, other_color);
                });
                
                // Update liberties of neighboring groups
                foreach_neighbor(b, stones[j], {
                    if (board_at(b, c) != color)
                        continue;
                    group_t g = group_at(b, c);
                    if (g == u->merged[0].group || g == u->merged[1].group || g == u->merged[2].group || g == u->merged[3].group)
                        continue;
                    board_group_rmlib(b, g, stones[j], u);
                });
            }
        }
    }
    
    // bo static
    void board_undo_stone(struct board *b, struct board_undo *u, struct move *m)
    {
        coord_t coord = m->coord;
        enum stone color = m->color;
        /* - update groups
         * - put captures back
         */
        
        //printf("nmerged: %i\n", u->nmerged);
        
        // Restore merged groups
        if (u->nmerged)
            undo_merge(b, u, m);
        else			// Single stone group undo
            memset(board_group_info(b, group_at(b, coord)), 0, sizeof(struct group));
        
        board_set(b, coord, S_NONE);
        group_set(b, coord, 0);
        groupnext_set(b, coord, u->next_at);
        
        foreach_neighbor(b, coord, {
            dec_neighbor_count_at(b, c, color);
        });
        
        // Restore enemy groups
        if (u->nenemies) {
            b->captures[color] -= u->captures;
            restore_enemies(b, u, m);
        }
    }
    
    // bo static
    inline void restore_suicide(struct board *b, struct board_undo *u, struct move *m)
    {
        enum stone color = m->color;
        enum stone other_color = stone_other(m->color);
        
        struct undo_enemy *enemy = u->enemies;
        for (int32_t i = 0; i < u->nenemies; i++) {
            group_t old_group = enemy[i].group;
            
            *board_group_info(b, old_group) = enemy[i].info;
            
            coord_t *stones = enemy[i].stones;
            for (int32_t j = 0; stones[j]; j++) {
                // printf("stones j: %d, %d\n", j, stones[j]);
                board_set(b, stones[j], other_color);
                group_set(b, stones[j], old_group);
                groupnext_set(b, stones[j], stones[j + 1]);
                
                foreach_neighbor(b, stones[j], {
                    inc_neighbor_count_at(b, c, other_color);
                });
                
                // Update liberties of neighboring groups
                foreach_neighbor(b, stones[j], {
                    if (board_at(b, c) != color)
                        continue;
                    group_t g = group_at(b, c);
                    if (g == u->enemies[0].group || g == u->enemies[1].group ||
                        g == u->enemies[2].group || g == u->enemies[3].group)
                        continue;
                    board_group_rmlib(b, g, stones[j], u);
                });
            }
        }
    }
    
    // bo static
    void board_undo_suicide(struct board *b, struct board_undo *u, struct move *m)
    {
        coord_t coord = m->coord;
        enum stone other_color = stone_other(m->color);
        
        // Pretend it's capture ...
        struct move m2;
        {
            m2.coord = m->coord;
            m2.color = other_color;
        };
        b->captures[other_color] -= u->captures;
        
        restore_suicide(b, u, &m2);
        
        undo_merge(b, u, m);
        
        board_set(b, coord, S_NONE);
        group_set(b, coord, 0);
        groupnext_set(b, coord, u->next_at);
        
        foreach_neighbor(b, coord, {
            dec_neighbor_count_at(b, c, m->color);
        });
        
    }
    
    void board_quick_undo(struct board *b, struct move *m, struct board_undo *u)
    {
#ifdef BOARD_UNDO_CHECKS
        b->quicked--;
#endif
        
        b->last_move = b->last_move2;
        b->last_move2 = u->last_move2;
        b->ko = u->ko;
        b->last_ko = u->last_ko;
        b->last_ko_age = u->last_ko_age;
        
        if (unlikely(is_pass(m->coord) || is_resign(m->coord)))
            return;
        
        b->moves--;
        
        if (likely(board_at(b, m->coord) == m->color))
            board_undo_stone(b, u, m);
        else if (board_at(b, m->coord) == S_NONE)
            board_undo_suicide(b, u, m);
        else {
            // assert(0);	/* Anything else doesn't make sense */
            printf("error, assert(0)\n");
        }
    }
    
    
    /* Undo, supported only for pass moves. This form of undo is required by KGS
     * to settle disputes on dead groups. See also fast_board_undo() */
    int32_t board_undo(struct board *board)
    {
        if (!is_pass(board->last_move.coord))
            return -1;
        if (board->rules == RULES_SIMING) {
            /* Return pass stone to the passing player. */
            board->captures[stone_other(board->last_move.color)]--;
        }
        board->last_move = board->last_move2;
        board->last_move2 = board->last_move3;
        board->last_move3 = board->last_move4;
        if (board->last_ko_age == board->moves)
            board->ko = board->last_ko;
        return 0;
    }
    
    bool board_set_rules(struct board *board, char *name)
    {
        if (!strcasecmp(name, "japanese"))
            board->rules = RULES_JAPANESE;
        else if (!strcasecmp(name, "chinese"))
            board->rules = RULES_CHINESE;
        else if (!strcasecmp(name, "aga"))
            board->rules = RULES_AGA;
        else if (!strcasecmp(name, "new_zealand"))
            board->rules = RULES_NEW_ZEALAND;
        else if (!strcasecmp(name, "siming") || !strcasecmp(name, "simplified_ing"))
            board->rules = RULES_SIMING;
        else
            return false;
        return true;
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// board play random //////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    
    bool board_is_false_eyelike(struct board *board, coord_t coord, enum stone eye_color)
    {
        // enum stone color_diag_libs[S_MAX] = {0, 0, 0, 0};
        int32_t color_diag_libs[S_MAX] = {0, 0, 0, 0};
        
        /* XXX: We attempt false eye detection but we will yield false
         * positives in case of http://senseis.xmp.net/?TwoHeadedDragon :-( */
        
        board_statics* board_statics = &board->board_statics;
        foreach_diag_neighbor(board_statics, board, coord) {
            color_diag_libs[(enum stone) board_at(board, c)]++;
        } foreach_diag_neighbor_end;
        /* For false eye, we need two enemy stones diagonally in the
         * middle of the board, or just one enemy stone at the edge
         * or in the corner. */
        color_diag_libs[stone_other(eye_color)] += !!color_diag_libs[S_OFFBOARD];
        return color_diag_libs[stone_other(eye_color)] >= 2;
    }
    
    bool board_is_one_point_eye(struct board *board, coord_t coord, enum stone eye_color)
    {
        return board_is_eyelike(board, coord, eye_color) && !board_is_false_eyelike(board, coord, eye_color);
    }
    
    bool board_permit(struct board *b, struct move *m, void *data)
    {
        if (unlikely(board_is_one_point_eye(b, m->coord, m->color)) /* bad idea to play into one, usually */
            || !board_is_valid_move(b, m))
            return false;
        return true;
    }
    
    // bo static
    inline bool board_try_random_move(struct board *b, enum stone color, coord_t *coord, int32_t f, ppr_permit permit, void *permit_data)
    {
        *coord = b->f[f];
        struct move m = { *coord, color };
        if (DEBUGL(6)){
            board_statics* board_statics = &b->board_statics;
            char strCoord[256];
            {
                coord2sstr(strCoord, *coord, b);
            }
            printf("trying random move %d: %d,%d %s %d\n", f, coord_x(board_statics, *coord, b), coord_y(board_statics, *coord, b), strCoord, board_is_valid_move(b, &m));
        }
        permit = (permit ? permit : board_permit);
        if (!permit(b, &m, permit_data))
            return false;
        if (m.coord == *coord)
            return likely(board_play_f(b, &m, f, NULL) >= 0);
        *coord = m.coord; // permit modified the coordinate
        return likely(board_play(b, &m) >= 0);
    }
    
    void board_play_random(struct board *b, enum stone color, coord_t *coord, ppr_permit permit, void *permit_data)
    {
        if (unlikely(b->flen == 0)){
            printf("error, board_play_random: why unlikely\n");
            // TODO goto play_pass; de phan duoi vao
            {
                *coord = pass;
                struct move m = { pass, color };
                board_play(b, &m);
                return;
            }
        }

        int32_t base = fast_random(b->flen), f;
        for (f = base; f < b->flen; f++)
            if (board_try_random_move(b, color, coord, f, permit, permit_data))
                return;
        for (f = 0; f < base; f++)
            if (board_try_random_move(b, color, coord, f, permit, permit_data))
                return;
        
        // play_pass:
        *coord = pass;
        struct move m = { pass, color };
        board_play(b, &m);
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////// Handicap /////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////
    
    void board_handicap_stone(struct board *board, int32_t x, int32_t y, FILE *f)
    {
        struct move m;
        m.color = S_BLACK; m.coord = coord_xy(board, x, y);
        
        board_play(board, &m);
        
        char str[256];
        coord2str(str, m.coord, board);
        if (DEBUGL(1)){
            printf("choosing handicap %s (%d,%d)\n", str, x, y);
        }
        if (f){
            fprintf(f, "%s ", str);
        }
    }
    
    void board_handicap(struct board *board, int32_t stones, FILE *f)
    {
        // TODO co nen han che ko?
        {
            if(stones>9){
                printf("error, why handicap too large: %d\n", stones);
                stones = 9;
            }
            if(stones<0){
                printf("error, why handicap too small: %d\n", stones);
                stones = 0;
            }
        }
        if(stones<=9){
            int32_t margin = 3 + (board_size(board) >= 13);
            int32_t min = margin;
            int32_t mid = board_size(board) / 2;
            int32_t max = board_size(board) - 1 - margin;
            const int32_t places[][2] = {
                { min, min }, { max, max }, { max, min }, { min, max },
                { min, mid }, { max, mid },
                { mid, min }, { mid, max },
                { mid, mid },
            };
            
            board->handicap = stones;
            
            if (stones == 5 || stones == 7) {
                board_handicap_stone(board, mid, mid, f);
                stones--;
            }

            int32_t i;
            for (i = 0; i < stones; i++)
                board_handicap_stone(board, places[i][0], places[i][1], f);
        }else{
            printf("error, why handicap too large: %d\n", stones);
        }
    }
    
    enum stone board_get_one_point_eye(struct board *board, coord_t coord)
    {
        if (board_is_one_point_eye(board, coord, S_WHITE))
            return S_WHITE;
        else if (board_is_one_point_eye(board, coord, S_BLACK))
            return S_BLACK;
        else
            return S_NONE;
    }
    
    floating_t board_fast_score(struct board *board)
    {
        int32_t scores[S_MAX];
        memset(scores, 0, sizeof(scores));
        
        foreach_point(board) {
            enum stone color = board_at(board, c);
            if (color == S_NONE && board->rules != RULES_STONES_ONLY)
                color = board_get_one_point_eye(board, c);
            scores[color]++;
        } foreach_point_end;
        
        return board->komi + (board->rules != RULES_SIMING ? board->handicap : 0) + scores[S_WHITE] - scores[S_BLACK];
    }
    
    /* Owner map: 0: undecided; 1: black; 2: white; 3: dame */
    
    /* One flood-fill iteration; returns true if next iteration
     * is required. */
    // bo static
    bool board_tromp_taylor_iter(struct board *board, int32_t *ownermap)
    {
        bool needs_update = false;
        foreach_free_point(board) {
            /* Ignore occupied and already-dame positions. */
            {
                // assert(board_at(board, c) == S_NONE);
                if(!(board_at(board, c) == S_NONE)){
                    printf("error, assert(board_at(board, c) == S_NONE)\n");
                }
            }
            if (board->rules == RULES_STONES_ONLY)
                ownermap[c] = 3;
            if (ownermap[c] == 3)
                continue;
            /* Count neighbors. */
            int32_t nei[4] = {0};
            foreach_neighbor(board, c, {
                nei[ownermap[c]]++;
            });
            /* If we have neighbors of both colors, or dame,
             * we are dame too. */
            if ((nei[1] && nei[2]) || nei[3]) {
                ownermap[c] = 3;
                /* Speed up the propagation. */
                foreach_neighbor(board, c, {
                    if (board_at(board, c) == S_NONE)
                        ownermap[c] = 3;
                });
                needs_update = true;
                continue;
            }
            /* If we have neighbors of one color, we are owned
             * by that color, too. */
            if (!ownermap[c] && (nei[1] || nei[2])) {
                int32_t newowner = nei[1] ? 1 : 2;
                ownermap[c] = newowner;
                /* Speed up the propagation. */
                foreach_neighbor(board, c, {
                    if (board_at(board, c) == S_NONE && !ownermap[c])
                        ownermap[c] = newowner;
                });
                needs_update = true;
                continue;
            }
        } foreach_free_point_end;
        return needs_update;
    }
    
    
    /* Tromp-Taylor Counting */
    floating_t board_official_score_and_dame(struct board *board, struct move_queue *q, int32_t *dame)
    {
        /* A point P, not colored C, is said to reach C, if there is a path of
         * (vertically or horizontally) adjacent points of P's color from P to
         * a point of color C.
         *
         * A player's score is the number of points of her color, plus the
         * number of empty points that reach only her color. */

        int32_t* ownermap = new int32_t[board_size2(board)];
        
        int32_t s[4] = {0};
        const int32_t o[4] = {0, 1, 2, 0};
        foreach_point(board) {
            ownermap[c] = o[board_at(board, c)];
            s[board_at(board, c)]++;
        } foreach_point_end;
        
        if (q) {
            /* Process dead groups. */
            for (uint32_t i = 0; i < q->moves; i++) {
                foreach_in_group(board, q->move[i]) {
                    enum stone color = board_at(board, c);
                    ownermap[c] = o[stone_other(color)];
                    s[color]--; s[stone_other(color)]++;
                } foreach_in_group_end;
            }
        }
        
        /* We need to special-case empty board. */
        if (!s[S_BLACK] && !s[S_WHITE])
            return board->komi;
        
        while (board_tromp_taylor_iter(board, ownermap))
        /* Flood-fill... */;

        int32_t scores[S_MAX];
        memset(scores, 0, sizeof(scores));
        
        *dame = 0;
        foreach_point(board) {
            {
                // assert(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0);
                if(!(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0)){
                    printf("error, assert(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0)\n");
                }
            }
            if (ownermap[c] == 3) {  (*dame)++; continue;  }
            scores[ownermap[c]]++;
        } foreach_point_end;
        
        delete [] ownermap;
        
        // printf("black score: %d, white score: %d, none: %d, offboard: %d\n", scores[S_BLACK], scores[S_WHITE], scores[S_NONE], scores[S_OFFBOARD]);
        return board->komi + (board->rules != RULES_SIMING ? board->handicap : 0) + scores[S_WHITE] - scores[S_BLACK];
    }
    
    floating_t board_official_score(struct board *board, struct move_queue *q)
    {
        int32_t dame;
        return board_official_score_and_dame(board, q, &dame);
    }
    
    void my_board_official_score_and_dame(struct Position* pos, struct move_queue *q)
    {
        // get board
        struct board* board = &pos->b;
        
        // ownermap
        int32_t* ownermap = new int32_t[board_size2(board)];
        
        int32_t s[4] = {0};
        const int32_t o[4] = {0, 1, 2, 0};
        foreach_point(board) {
            ownermap[c] = o[board_at(board, c)];
            s[board_at(board, c)]++;
        } foreach_point_end;
        
        if (q) {
            /* Process dead groups. */
            for (uint32_t i = 0; i < q->moves; i++) {
                foreach_in_group(board, q->move[i]) {
                    enum stone color = board_at(board, c);
                    ownermap[c] = o[stone_other(color)];
                    s[color]--; s[stone_other(color)]++;
                } foreach_in_group_end;
            }
        }
        
        /* We need to special-case empty board. */
        if (!s[S_BLACK] && !s[S_WHITE]){
            // printf("error, special case: empty board\n");
            {
                // owner map
                {
                    int32_t boardSize2 = board_size2(board);
                    for(int32_t i=0; i<boardSize2; i++){
                        pos->scoreOwnerMap[i] = 0;
                    }
                }
                pos->scoreOwnerMapSize = board_size2(board);
                pos->scoreBlack = 0;
                pos->scoreWhite = 0;
                pos->dame = 0;
                pos->score = board->komi;
            }
            // free data
            {
                delete [] ownermap;
            }
            return;
        }
        
        while (board_tromp_taylor_iter(board, ownermap))
        /* Flood-fill... */;

        int32_t scores[S_MAX];
        memset(scores, 0, sizeof(scores));
        
        pos->dame = 0;
        foreach_point(board) {
            {
                // assert(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0);
                if(!(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0)){
                    printf("error, assert(board_at(board, c) == S_OFFBOARD || ownermap[c] != 0)\n");
                }
            }
            if (ownermap[c] == 3) {  (pos->dame)++; continue;  }
            scores[ownermap[c]]++;
            // printf("owner map score: %d, %d\n", c, ownermap[c]);
        } foreach_point_end;
        // printf("black score: %d, white score: %d, none: %d, offboard: %d\n", scores[S_BLACK], scores[S_WHITE], scores[S_NONE], scores[S_OFFBOARD]);
        float score = board->komi + (board->rules != RULES_SIMING ? board->handicap : 0) + scores[S_WHITE] - scores[S_BLACK];
        // update position
        {
            // TODO co van de memcpy(pos->scoreOwnerMap, ownermap, board_size2(board));
            {
                int32_t boardSize2 = board_size2(board);
                for(int32_t i=0; i<boardSize2; i++){
                    pos->scoreOwnerMap[i] = ownermap[i];
                }
            }
            pos->scoreOwnerMapSize = board_size2(board);
            pos->scoreBlack = scores[S_BLACK];
            pos->scoreWhite = scores[S_WHITE];
            // ko can dame = 0;
            pos->score = score;
        }
        
        delete [] ownermap;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////// ConvertToByteArray /////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////

    int32_t board_statics::convertToByteArray(struct board_statics* board_statics, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = board_statics::getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert properties
            {
                // int32_t size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = board_statics->size;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t nei8[8];
                {
                    // ret+=sizeof(int32_t)*8;
                    int32_t size = sizeof(int32_t)*8;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &board_statics->nei8, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: nei8: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t dnei[4];
                {
                    // ret+=sizeof(int32_t)*4;
                    int32_t size = sizeof(int32_t)*4;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &board_statics->dnei, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: dnei: %d, %d\n", pointerIndex, length);
                    }
                }
                // hash_t h[BOARD_MAX_COORDS][2]
                {
                    // ret+=sizeof(hash_t)*BOARD_MAX_COORDS*2;
                    int32_t size = sizeof(hash_t)*BOARD_MAX_COORDS*2;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &board_statics->h, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: h: %d, %d\n", pointerIndex, length);
                    }
                    // printf("board_statics: convert hash_t: %llu\n", board_statics->h[0][0]);
                }
                // uint8_t coord[BOARD_MAX_COORDS][2]
                {
                    // ret+=sizeof(uint8_t)*BOARD_MAX_COORDS*2;
                    int32_t size = sizeof(uint8_t)*BOARD_MAX_COORDS*2;
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &board_statics->coord, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: coord: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check convert correct
            if(pointerIndex!=length){
                printf("error: convert board_statics not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t board_statics::parseByteArray(struct board_statics* board_statics, uint8_t* positionBytes, int32_t length, int32_t start)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&board_statics->size, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // int32_t nei8[8];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<8; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&board_statics->nei8[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: nei8: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 2:
                    // int32_t dnei[4];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<4; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&board_statics->dnei[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: dnei: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                }
                    break;
                case 3:
                    // hash_t h[BOARD_MAX_COORDS][2]
                {
                    int32_t size = sizeof(hash_t)*BOARD_MAX_COORDS*2;
                    if(pointerIndex+size<=length){
                        memcpy(&board_statics->h, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: h: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board_statics: parse hash_t: %llu\n", board_statics->h[0][0]);
                }
                    break;
                case 4:
                    // uint8_t coord[BOARD_MAX_COORDS][2]
                {
                    int32_t size = sizeof(uint8_t)*BOARD_MAX_COORDS*2;
                    if(pointerIndex+size<=length){
                        memcpy(&board_statics->coord, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: coord: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("error, not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }

    int32_t board::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t size;
            ret+=sizeof(int32_t);
            // int32_t size2;
            ret+=sizeof(int32_t);
            // int32_t bits2;
            ret+=sizeof(int32_t);
            // int32_t captures[S_MAX];
            ret+=S_MAX*sizeof(int32_t);
            // floating_t komi;
            ret+=sizeof(floating_t);
            // int32_t handicap;
            ret+=sizeof(int32_t);
            // enum go_ruleset rules;
            ret+=sizeof(int32_t);
            /*char *fbookfile;
             struct fbook *fbook;*/
            
            // int32_t moves;
            ret+=sizeof(int32_t);
            // struct move last_move;
            ret+=move::getByteSize();
            // struct move last_move2;
            ret+=move::getByteSize();
            // FB_ONLY(struct move last_move3);
            ret+=move::getByteSize();
            // FB_ONLY(struct move last_move4);
            ret+=move::getByteSize();
            // FB_ONLY(bool superko_violation);
            ret+=sizeof(int8_t);
            
            // enum stone b[BOARD_MAX_COORDS];
            ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
            // group_t g[BOARD_MAX_COORDS];
            ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
            // coord_t p[BOARD_MAX_COORDS];
            ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
            
            // FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];
            ret+=sizeof(hash3_t)*BOARD_MAX_COORDS;
            
            // struct group gi[BOARD_MAX_COORDS];
            ret+=group::getByteSize()*BOARD_MAX_COORDS;
            
            //FB_ONLY(group_t c)[BOARD_MAX_GROUPS];
            ret+=sizeof(int32_t)*BOARD_MAX_GROUPS;
            // FB_ONLY(int32_t clen);
            ret+=sizeof(int32_t);
            
            // FB_ONLY(struct board_symmetry symmetry);
            ret+=board_symmetry::getByteSize();
            
            // FB_ONLY(struct move last_ko);
            ret+=move::getByteSize();
            // FB_ONLY(int32_t last_ko_age);
            ret+=sizeof(int32_t);
            
            // struct move ko;
            ret+=move::getByteSize();
            
            // int32_t quicked;
            ret+=sizeof(int32_t);
            
            // FB_ONLY(hash_t history_hash)[1 << history_hash_bits];
            ret+=sizeof(hash_t)*(1 << history_hash_bits);
            // FB_ONLY(hash_t hash);
            ret+=sizeof(hash_t);
            // FB_ONLY(hash_t qhash)[4];
            ret+=sizeof(hash_t)*4;
        }
        return ret;
    }

    int32_t board::convertToByteArray(struct board* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert properties
            {
                // int32_t size;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->size;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t size2;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->size2;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size2: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t bits2;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->bits2;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: bits2: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t captures[S_MAX];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<S_MAX; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = position->captures[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: captures: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // floating_t komi;
                {
                    int32_t size = sizeof(floating_t);
                    if(pointerIndex+size<=length){
                        floating_t value = position->komi;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: komi: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t handicap;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->handicap;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: handicap: %d, %d\n", pointerIndex, length);
                    }
                }
                // enum go_ruleset rules;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->rules;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: rules: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // int32_t moves;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->moves;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moves: %d, %d\n", pointerIndex, length);
                    }
                }
                // struct move last_move;
                {
                    // ret+=move::getByteSize();
                    uint8_t* lastMoveByteArray;
                    int32_t size = move::convertToByteArray(&position->last_move, lastMoveByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, lastMoveByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_move: %d, %d\n", pointerIndex, length);
                    }
                    free(lastMoveByteArray);
                }
                // struct move last_move2;
                {
                    // ret+=move::getByteSize();
                    uint8_t* lastMove2ByteArray;
                    int32_t size = move::convertToByteArray(&position->last_move2, lastMove2ByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, lastMove2ByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_move2: %d, %d\n", pointerIndex, length);
                    }
                    free(lastMove2ByteArray);
                }
                // FB_ONLY(struct move last_move3);
                {
                    // ret+=move::getByteSize();
                    uint8_t* lastMove3ByteArray;
                    int32_t size = move::convertToByteArray(&position->last_move3, lastMove3ByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, lastMove3ByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_move3: %d, %d\n", pointerIndex, length);
                    }
                    free(lastMove3ByteArray);
                }
                // FB_ONLY(struct move last_move4);
                {
                    // ret+=move::getByteSize();
                    uint8_t* lastMove4ByteArray;
                    int32_t size = move::convertToByteArray(&position->last_move4, lastMove4ByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, lastMove4ByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_move4: %d, %d\n", pointerIndex, length);
                    }
                    free(lastMove4ByteArray);
                }
                // FB_ONLY(bool superko_violation);
                {
                    int32_t size = sizeof(int8_t);
                    if(pointerIndex+size<=length){
                        // get value
                        int8_t value = 0;
                        if(position->superko_violation){
                            value = 1;
                        }else{
                            value = 0;
                        }
                        // copy
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: superko_violation: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // enum stone b[BOARD_MAX_COORDS];
                {
                    // ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = position->b[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: b: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // group_t g[BOARD_MAX_COORDS];
                {
                    // ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = position->g[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: g: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // coord_t p[BOARD_MAX_COORDS];
                {
                    // ret+=sizeof(int32_t)*BOARD_MAX_COORDS;
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = position->p[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: p: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                
                // FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];
                {
                    // ret+=sizeof(hash3_t)*BOARD_MAX_COORDS;
                    int32_t size = sizeof(hash3_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            hash3_t value = position->pat3[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: pat3: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                
                // struct group gi[BOARD_MAX_COORDS];
                {
                    // group::getByteSize();
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        uint8_t* giByteArray;
                        int32_t size = group::convertToByteArray(&position->gi[i], giByteArray);
                        // write
                        if(pointerIndex+size<=length){
                            memcpy(byteArray + pointerIndex, giByteArray, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: gi: %d, %d\n", pointerIndex, length);
                        }
                        free(giByteArray);
                    }
                }
                
                //FB_ONLY(group_t c)[BOARD_MAX_GROUPS];
                {
                    // ret+=sizeof(int32_t)*BOARD_MAX_GROUPS;
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_GROUPS; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = position->c[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: c: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // FB_ONLY(int32_t clen);
                {
                    // ret+=sizeof(int32_t);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->clen;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: clen: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // FB_ONLY(struct board_symmetry symmetry);
                {
                    // ret+=board_symmetry::getByteSize();
                    uint8_t* symmetryByteArray;
                    int32_t size = board_symmetry::convertToByteArray(&position->symmetry, symmetryByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, symmetryByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: symmetry: %d, %d\n", pointerIndex, length);
                    }
                    free(symmetryByteArray);
                }
                
                // FB_ONLY(struct move last_ko);
                {
                    // ret+=move::getByteSize();
                    uint8_t* lastKoByteArray;
                    int32_t size = move::convertToByteArray(&position->last_ko, lastKoByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, lastKoByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_ko: %d, %d\n", pointerIndex, length);
                    }
                    free(lastKoByteArray);
                }
                // FB_ONLY(int32_t last_ko_age);
                {
                    // ret+=sizeof(int32_t);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->last_ko_age;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_ko_age: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // struct move ko;
                {
                    // ret+=move::getByteSize();
                    uint8_t* koByteArray;
                    int32_t size = move::convertToByteArray(&position->ko, koByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, koByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: ko: %d, %d\n", pointerIndex, length);
                    }
                    free(koByteArray);
                }
                
                // int32_t quicked;
                {
                    // ret+=sizeof(int32_t);
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = position->quicked;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_ko_age: %d, %d\n", pointerIndex, length);
                    }
                }
                
                // FB_ONLY(hash_t history_hash)[1 << history_hash_bits];
                {
                    // ret+=sizeof(hash_t)*(1 << history_hash_bits);
                    int32_t size = sizeof(hash_t);
                    int32_t arrayLength = 1 << history_hash_bits;
                    for(int32_t i=0; i<arrayLength; i++){
                        if(pointerIndex+size<=length){
                            hash_t value = position->history_hash[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: history_hash: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
                // FB_ONLY(hash_t hash);
                {
                    // ret+=sizeof(hash_t);
                    int32_t size = sizeof(hash_t);
                    if(pointerIndex+size<=length){
                        hash_t value = position->hash;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: hash: %d, %d\n", pointerIndex, length);
                    }
                }
                // FB_ONLY(hash_t qhash)[4];
                {
                    // ret+=sizeof(hash_t)*4;
                    int32_t size = sizeof(hash_t);
                    for(int32_t i=0; i<4; i++){
                        if(pointerIndex+size<=length){
                            hash_t value = position->qhash[i];
                            memcpy(byteArray + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: qhash: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
            }
            // result
            if(pointerIndex!=length){
                printf("error: convert board not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t board::parseByteArray(struct board* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t size;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->size, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: size: %d\n", pointerIndex);
                }
                    break;
                case 1:
                    // int32_t size2;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->size2, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: size2: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: size2: %d\n", pointerIndex);
                }
                    break;
                case 2:
                    // int32_t bits2;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->bits2, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: bit2: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: bits2: %d\n", pointerIndex);
                }
                    break;
                case 3:
                    // int32_t captures[S_MAX];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<S_MAX; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->captures[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: captures: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: captures: %d\n", pointerIndex);
                }
                    break;
                case 4:
                    // floating_t komi;
                {
                    int32_t size = sizeof(floating_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->komi, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: komi: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: komi: %d\n", pointerIndex);
                }
                    break;
                case 5:
                    // int32_t handicap;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->handicap, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: handicap: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: handicap: %d\n", pointerIndex);
                }
                    break;
                case 6:
                    // enum go_ruleset rules;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t rules = 0;
                        memcpy(&rules, positionBytes + pointerIndex, size);
                        position->rules = (go_ruleset)rules;
                        pointerIndex+=size;
                    }else{
                        printf("length error: rules: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: rules: %d\n", pointerIndex);
                }
                    break;
                case 7:
                    // int32_t moves;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->moves, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moves: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: moves: %d\n", pointerIndex);
                }
                    break;
                case 8:
                    // struct move last_move;
                {
                    int32_t lastMoveByteLength = move::parseByteArray(&position->last_move, positionBytes, length, pointerIndex);
                    if (lastMoveByteLength > 0) {
                        pointerIndex+= lastMoveByteLength;
                    } else {
                        printf("error, cannot parse: last_move\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_move: %d\n", pointerIndex);
                }
                    break;
                case 9:
                    // struct move last_move2;
                {
                    int32_t lastMove2ByteLength = move::parseByteArray(&position->last_move2, positionBytes, length, pointerIndex);
                    if (lastMove2ByteLength > 0) {
                        pointerIndex+= lastMove2ByteLength;
                    } else {
                        printf("error, cannot parse: last_move2\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_move2: %d\n", pointerIndex);
                }
                    break;
                case 10:
                    // FB_ONLY(struct move last_move3);
                {
                    int32_t lastMove3ByteLength = move::parseByteArray(&position->last_move3, positionBytes, length, pointerIndex);
                    if (lastMove3ByteLength > 0) {
                        pointerIndex+= lastMove3ByteLength;
                    } else {
                        printf("error, cannot parse: last_move3\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_move3: %d\n", pointerIndex);
                }
                    break;
                case 11:
                    // FB_ONLY(struct move last_move4);
                {
                    int32_t lastMove4ByteLength = move::parseByteArray(&position->last_move4, positionBytes, length, pointerIndex);
                    if (lastMove4ByteLength > 0) {
                        pointerIndex+= lastMove4ByteLength;
                    } else {
                        printf("error, cannot parse: last_move4\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_move4: %d\n", pointerIndex);
                }
                    break;
                case 12:
                    // FB_ONLY(bool superko_violation);
                {
                    int32_t size = sizeof(int8_t);
                    if(pointerIndex+size<=length){
                        int8_t value = 0;
                        memcpy(&value, positionBytes + pointerIndex, size);
                        if(value==1){
                            position->superko_violation = true;
                        }else{
                            position->superko_violation = false;
                        }
                        pointerIndex+=size;
                    }else{
                        printf("length error: superko_violation: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: superko_violation: %d\n", pointerIndex);
                }
                    break;
                case 13:
                    // enum stone b[BOARD_MAX_COORDS];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            int32_t value = 0;
                            memcpy(&value, positionBytes + pointerIndex, size);
                            position->b[i] = (stone)value;
                            pointerIndex+=size;
                        }else{
                            printf("length error: b: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: stone: %d\n", pointerIndex);
                }
                    break;
                case 14:
                    // group_t g[BOARD_MAX_COORDS];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->g[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: g: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: g: %d\n", pointerIndex);
                }
                    break;
                case 15:
                    // coord_t p[BOARD_MAX_COORDS];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->p[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: p: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: p: %d\n", pointerIndex);
                }
                    break;
                case 16:
                    // FB_ONLY(hash3_t pat3)[BOARD_MAX_COORDS];
                {
                    int32_t size = sizeof(hash3_t);
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->pat3[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: pat3: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: pat3: %d\n", pointerIndex);
                }
                    break;
                case 17:
                    // struct group gi[BOARD_MAX_COORDS];
                {
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        int32_t giByteLength = group::parseByteArray(&position->gi[i], positionBytes, length, pointerIndex);
                        if (giByteLength > 0) {
                            pointerIndex+= giByteLength;
                        } else {
                            printf("error, cannot parse: gi\n");
                            isParseCorrect = false;
                            break;
                        }
                    }
                    // printf("board parse: gi: %d\n", pointerIndex);
                }
                    break;
                    
                
                case 18:
                    //FB_ONLY(group_t c)[BOARD_MAX_GROUPS];
                {
                    int32_t size = sizeof(int32_t);
                    for(int32_t i=0; i<BOARD_MAX_GROUPS; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->c[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: c: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: c: %d\n", pointerIndex);
                }
                    break;
                case 19:
                    // FB_ONLY(int32_t clen);
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->clen, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: clen: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: clen: %d\n", pointerIndex);
                }
                    break;
                case 20:
                    // FB_ONLY(struct board_symmetry symmetry);
                {
                    int32_t symmetryByteLength = board_symmetry::parseByteArray(&position->symmetry, positionBytes, length, pointerIndex);
                    if (symmetryByteLength > 0) {
                        pointerIndex+= symmetryByteLength;
                    } else {
                        printf("error, cannot parse: symmetry\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: symmetry: %d\n", pointerIndex);
                }
                    break;
                case 21:
                    // FB_ONLY(struct move last_ko);
                {
                    int32_t lastKoByteLength = move::parseByteArray(&position->last_ko, positionBytes, length, pointerIndex);
                    if (lastKoByteLength > 0) {
                        pointerIndex+= lastKoByteLength;
                    } else {
                        printf("error, cannot parse: last_ko\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_ko: %d\n", pointerIndex);
                }
                    break;
                case 22:
                    // FB_ONLY(int32_t last_ko_age);
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->last_ko_age, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: last_ko_age: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: last_ko_age: %d\n", pointerIndex);
                }
                    break;
                case 23:
                    // struct move ko;
                {
                    int32_t koByteLength = move::parseByteArray(&position->ko, positionBytes, length, pointerIndex);
                    if (koByteLength > 0) {
                        pointerIndex+= koByteLength;
                    } else {
                        printf("error, cannot parse: ko\n");
                        isParseCorrect = false;
                    }
                    // printf("board parse: ko: %d\n", pointerIndex);
                }
                    break;
                case 24:
                    // int32_t quicked;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->quicked, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: quicked: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: quicked: %d\n", pointerIndex);
                }
                    break;
                case 25:
                    // FB_ONLY(hash_t history_hash)[1 << history_hash_bits];
                {
                    int32_t size = sizeof(hash_t);
                    int32_t arrayLength = 1 << history_hash_bits;
                    for(int32_t i=0; i<arrayLength; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->history_hash[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: history_hash: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: history_hash: %d\n", pointerIndex);
                }
                    break;
                case 26:
                    // FB_ONLY(hash_t hash);
                {
                    int32_t size = sizeof(hash_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->hash, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: hash: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("board parse: hash: %d\n", pointerIndex);
                }
                    break;
                case 27:
                    // FB_ONLY(hash_t qhash)[4];
                {
                    int32_t size = sizeof(hash_t);
                    for(int32_t i=0; i<4; i++){
                        if(pointerIndex+size<=length){
                            memcpy(&position->qhash[i], positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: qhash: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // printf("board parse: qhash: %d\n", pointerIndex);
                }
                    break;
                default:
                {
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // init other data
        {
            // board_statics
            board_statics_init(position);
            // free point
            {
                position->flen = 0;
                for (int32_t i = board_size(position); i < (board_size(position) - 1) * board_size(position); i++)
                    if (i % board_size(position) != 0 && i % board_size(position) != board_size(position) - 1){
                        if(board_at(position, i) == S_NONE){
                            position->fmap[i] = position->flen;
                            position->f[position->flen++] = i;
                        }
                    }
            }
            // neighbor count
            {
                board board;
                board_init(&board, nullptr);
                board_resize(&board, real_board_size(position));
                board_clear(&board);
                board.rules = position->rules;
                board.komi = position->komi;
                board_handicap(&board, 0, nullptr);
                board_statics_init(&board);
                // play
                {
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        stone stone = position->b[i];
                        if(stone==S_BLACK || stone==S_WHITE){
                            move move;
                            {
                                move.color = stone;
                                move.coord = i;
                            }
                            board_play(&board, &move);
                        }
                    }
                }
                // update neighbor
                {
                    for(int32_t i=0; i<BOARD_MAX_COORDS; i++){
                        // neighbor
                        for(int32_t j=0; j<S_MAX; j++){
                            position->n[i].colors[j] = board.n[i].colors[j];
                        }
                    }
                }
            }
        }
        // check position ok: if not, correct it
        {
            if(canCorrect){
                
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
}
// 73529
// 71765
