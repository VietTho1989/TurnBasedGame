//
//  ownermap.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#include "weiqi_ownermap.hpp"
#include "weiqi_mq.hpp"

namespace weiqi
{
    void board_ownermap_init(struct board_ownermap *ownermap)
    {
        memset(ownermap, 0, sizeof(*ownermap));
    }
    
    // bo static
    void printhook(struct board *board, coord_t c, strbuf_t *buf, void *data)
    {
        struct board_ownermap* ownermap = (struct board_ownermap*)data;
        
        if (c == pass) { /* Stuff to display in header */
            if (!ownermap || !ownermap->playouts) return;
            {
                char str[32];
                {
                    board_ownermap_score_est_str(str, board, ownermap);
                }
                sbprintf(buf, "Score Est: %s", str);
            }
            return;
        }
        
        if (!ownermap) {
            sbprintf(buf, ". ");
            return;
        }
        const char chr[] = ":XO,"; // dame, black, white, unclear
        const char chm[] = ":xo,";
        char ch = chr[board_ownermap_judge_point(ownermap, c, GJ_THRES)];
        if (ch == ',') { // less precise estimate then?
            ch = chm[board_ownermap_judge_point(ownermap, c, 0.67)];
        }
        sbprintf(buf, "%c ", ch);
    }
    
    void board_print_ownermap(struct board *b, FILE *f, struct board_ownermap *ownermap)
    {
        board_print_custom(b, stderr, printhook, ownermap);
    }
    
    void board_ownermap_fill(struct board_ownermap *ownermap, struct board *b)
    {
        ownermap->playouts++;
        foreach_point(b) {
            enum stone color = board_at(b, c);
            if (color == S_NONE)
                color = board_get_one_point_eye(b, c);
            ownermap->map[c][color]++;
        } foreach_point_end;
    }
    
    void board_ownermap_merge(int32_t bsize2, struct board_ownermap *dst, struct board_ownermap *src)
    {
        dst->playouts += src->playouts;
        for (int32_t i = 0; i < bsize2; i++)
            for (int32_t j = 0; j < S_MAX; j++)
                dst->map[i][j] += src->map[i][j];
    }
    
    float board_ownermap_estimate_point(struct board_ownermap *ownermap, coord_t c)
    {
        {
            // assert(ownermap->map);
        }
        int32_t b = ownermap->map[c][S_BLACK];
        int32_t w = ownermap->map[c][S_WHITE];
        int32_t total = ownermap->playouts;
        return 1.0 * (b - w) / total;
    }
    
    enum point_judgement board_ownermap_judge_point(struct board_ownermap *ownermap, coord_t c, floating_t thres)
    {
        {
            // assert(ownermap->map);
        }
        int32_t n = ownermap->map[c][S_NONE];
        int32_t b = ownermap->map[c][S_BLACK];
        int32_t w = ownermap->map[c][S_WHITE];
        int32_t total = ownermap->playouts;
        if (n >= total * thres)
            return PJ_DAME;
        else if (n + b >= total * thres)
            return PJ_BLACK;
        else if (n + w >= total * thres)
            return PJ_WHITE;
        else
            return PJ_UNKNOWN;
    }
    
    void board_ownermap_judge_groups(struct board *b, struct board_ownermap *ownermap, struct group_judgement *judge)
    {
        {
            // assert(ownermap->map);
            /*if(!ownermap->map){
                printf("error, assert(ownermap->map)\n");
            }*/
        }
        {
            // assert(judge->gs);
            if(!judge->gs){
                printf("error, assert(judge->gs)\n");
                // judge->gs = GS_ALIVE;
            }
        }
        memset(judge->gs, GS_NONE, board_size2(b) * sizeof(judge->gs[0]));
        
        foreach_point(b) {
            enum stone color = board_at(b, c);
            group_t g = group_at(b, c);
            if (!g) continue;
            
            enum point_judgement pj = board_ownermap_judge_point(ownermap, c, judge->thres);
            // assert(judge->gs[g] == GS_NONE || judge->gs[g] == pj);
            if (pj == PJ_UNKNOWN) {
                /* Fate is uncertain. */
                judge->gs[g] = GS_UNKNOWN;
                
            } else if (judge->gs[g] != GS_UNKNOWN) {
                /* Update group state. */
                enum gj_state new1;
                
                // Comparing enum types, casting (int) avoids compiler warnings
                if ((int)pj == (int)color) {
                    new1 = GS_ALIVE;
                } else if ((int)pj == (int)stone_other(color)) {
                    new1 = GS_DEAD;
                } else {
                    {
                        // assert(pj == PJ_DAME);
                        if(!(pj == PJ_DAME)){
                            printf("error, assert(pj == PJ_DAME)\n");
                            pj = PJ_DAME;
                        }
                    }
                    /* Exotic! */
                    new1 = GS_UNKNOWN;
                }
                
                if (judge->gs[g] == GS_NONE) {
                    judge->gs[g] = new1;
                } else if (judge->gs[g] != new1) {
                    /* Contradiction. :( */
                    judge->gs[g] = GS_UNKNOWN;
                }
            }
        } foreach_point_end;
    }
    
    void groups_of_status(struct board *b, struct group_judgement *judge, enum gj_state s, struct move_queue *mq)
    {
        foreach_point(b) { /* foreach_group, effectively */
            group_t g = group_at(b, c);
            if (!g || g != c) continue;
            
            {
                // assert(judge->gs[g] != GS_NONE);
                if(judge->gs[g] == GS_NONE){
                    printf("error, assert(judge->gs[g] != GS_NONE)\n");
                    judge->gs[g] = GS_ALIVE;
                }
            }
            if (judge->gs[g] == s)
                mq_add(mq, g, 0);
        } foreach_point_end;
    }
    
    enum point_judgement board_ownermap_score_est_coord(struct board *b, struct board_ownermap *ownermap, coord_t c)
    {
        enum point_judgement j = board_ownermap_judge_point(ownermap, c, 0.67);
        enum stone s = board_at(b, c);
        
        /* If status is unclear and there's a stone there assume it's alive. */
        if (j != PJ_BLACK && j != PJ_WHITE && (s == S_BLACK || s == S_WHITE))
            return (enum point_judgement)s;
        return j;
    }
    
    float board_ownermap_score_est(struct board *b, struct board_ownermap *ownermap)
    {
        float scores[S_MAX] = {0.0, };  /* Number of points owned by each color */
        foreach_point(b) {
            enum point_judgement j = board_ownermap_score_est_coord(b, ownermap, c);
            scores[j]++;
        } foreach_point_end;
        
        return ((scores[PJ_WHITE] + b->komi + b->handicap) - scores[PJ_BLACK]);
    }
    
    /* Returns static buffer */
    void board_ownermap_score_est_str(char* ret, struct board *b, struct board_ownermap *ownermap)
    {
        // static char buf[32];
        float s = board_ownermap_score_est(b, ownermap);
        sprintf(ret, "%s+%.1f\n", (s > 0 ? "W" : "B"), fabs(s));
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// my print /////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////
    
    void my_printhook(struct board *board, coord_t c, char* f, void *data)
    {
        struct board_ownermap* ownermap = (struct board_ownermap*)data;
        
        if (c == pass) { /* Stuff to display in header */
            if (!ownermap || !ownermap->playouts) return;
            {
                char str[32];
                {
                    board_ownermap_score_est_str(str, board, ownermap);
                }
                sprintf(f, "%sScore Est: %s", f, str);
            }
            return;
        }
        
        if (!ownermap) {
            sprintf(f, "%s. ", f);
            return;
        }
        const char chr[] = ":XO,"; // dame, black, white, unclear
        const char chm[] = ":xo,";
        char ch = chr[board_ownermap_judge_point(ownermap, c, GJ_THRES)];
        if (ch == ',') { // less precise estimate then?
            ch = chm[board_ownermap_judge_point(ownermap, c, 0.67)];
        }
        sprintf(f, "%s%c ", f, ch);
    }
    
    void board_print_ownermap(struct board *b, char *f, struct board_ownermap *ownermap)
    {
        if(ownermap!=NULL){
            board_print_custom(b, f, my_printhook, ownermap);
        }else{
            board_print_custom(b, f, NULL, ownermap);
        }
    }
}
