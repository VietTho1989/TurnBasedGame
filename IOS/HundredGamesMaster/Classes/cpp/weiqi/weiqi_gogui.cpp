//
//  gogui.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <assert.h>
#include <math.h>
#include "weiqi_gogui.hpp"

namespace weiqi
{
    typedef enum {
        GOGUI_BEST_WINRATES,
        GOGUI_BEST_MOVES,
        GOGUI_BEST_COLORS,
    } gogui_gfx_t;
    
    typedef enum {
        GOGUI_RESCALE_NONE,
        GOGUI_RESCALE_LINEAR = (1 << 0),
        GOGUI_RESCALE_LOG =    (1 << 1),
    } gogui_rescale_t;
    
    enum gogui_reporting gogui_livegfx = UR_GOGUI_ZERO;// 0;
    
    
    /* GoGui reads live gfx commands on stderr */
    void gogui_show_livegfx(char *str)
    {
        printf("gogui-gfx:\n");
        printf("%s", str);
        printf("\n");
    }
    
    /* Display best moves graphically in GoGui. */
    void gogui_show_best_moves(strbuf_t *buf, struct board *b, enum stone color, coord_t *best_c, float *best_r, int32_t n)
    {
        /* best move */
        if (best_c[0] != pass){
            char strCoord[256];
            {
                coord2sstr(strCoord, best_c[0], b);
            }
            sbprintf(buf, "VAR %s %s\n", (color == S_WHITE ? "w" : "b"), strCoord);
        }
        
        for (int32_t i = 1; i < n; i++)
            if (best_c[i] != pass){
                char strCoord[256];
                {
                    coord2sstr(strCoord, best_c[i], b);
                }
                sbprintf(buf, "LABEL %s %i\n", strCoord, i + 1);
            }
    }
    
    void gogui_show_winrates(strbuf_t *buf, struct board *b, enum stone color, coord_t *best_c, float *best_r, int32_t nbest)
    {
        /* best move */
        if (best_c[0] != pass){
            char strCoord[256];
            {
                coord2sstr(strCoord, best_c[0], b);
            }
            sbprintf(buf, "VAR %s %s\n", (color == S_WHITE ? "w" : "b"), strCoord);
        }
        
        for (int32_t i = 0; i < nbest; i++)
            if (best_c[i] != pass){
                char strCoord[256];
                {
                    coord2sstr(strCoord, best_c[i], b);
                }
                sbprintf(buf, "LABEL %s %i\n", strCoord, (int)(roundf(best_r[i] * 100)));
            }
    }
    
    void gogui_show_best_seq(strbuf_t *buf, struct board *b, enum stone color, coord_t *seq, int32_t n)
    {
        char col[] = "bw";
        sbprintf(buf, "VAR ");
        for (int32_t i = 0; i < n && seq[i] != pass; i++){
            char strCoord[256];
            {
                coord2sstr(strCoord, seq[i], b);
            }
            sbprintf(buf, "%c %3s ", col[(i + (color == S_WHITE)) % 2], strCoord);
        }
        sbprintf(buf, "\n");
    }
}
