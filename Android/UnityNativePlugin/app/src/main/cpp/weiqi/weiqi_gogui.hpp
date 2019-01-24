//
//  gogui.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_gogui_hpp
#define weiqi_gogui_hpp

#include <stdio.h>
#include "weiqi_util.hpp"
#include "weiqi_board.hpp"

namespace weiqi
{
    /* How many candidates to display */
#define GOGUI_CANDIDATES 30
    
    enum gogui_reporting {
        UR_GOGUI_ZERO,
        UR_GOGUI_BEST,
        UR_GOGUI_SEQ,
        UR_GOGUI_WR,
    };
    
    extern enum gogui_reporting gogui_livegfx;
    
    extern char gogui_gfx_buf[];
    
    void gogui_show_best_moves(strbuf_t *buf, struct board *b, enum stone color, coord_t *best_c, float *best_r, int32_t n);
    void gogui_show_best_moves_colors(strbuf_t *buf, struct board *b, enum stone color, coord_t *best_c, float *best_r, int32_t n);
    void gogui_show_winrates(strbuf_t *buf, struct board *b, enum stone color, coord_t *best_c, float *best_r, int32_t nbest);
    void gogui_show_best_seq(strbuf_t *buf, struct board *b, enum stone color, coord_t *seq, int32_t n);
    void gogui_show_livegfx(char *str);
}

#endif /* gogui_hpp */
