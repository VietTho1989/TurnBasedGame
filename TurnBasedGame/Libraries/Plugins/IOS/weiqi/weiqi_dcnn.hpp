//
//  dcnn.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_dcnn_hpp
#define weiqi_dcnn_hpp

#include <stdio.h>
#include "weiqi_move.hpp"

namespace weiqi
{
#ifdef DCNN
    
#define DCNN_BEST_N 20
    
    /* Don't try to load dcnn. */
    void disable_dcnn();
    
    void dcnn_get_moves(struct board *b, enum stone color, float result[]);
    bool using_dcnn(struct board *b);
    void dcnn_init();
    void find_dcnn_best_moves(struct board *b, float *r, coord_t *best_c, float *best_r, int32_t nbest);
    void print_dcnn_best_moves(struct board *b, coord_t *best_c, float *best_r, int32_t nbest);
    
    /* Time spent in dcnn code */
    double get_dcnn_time();
    void reset_dcnn_time();
    
    /* Convert board coord to dcnn data index */
    // bo static
    inline int32_t coord2dcnn_idx(coord_t c, struct board *b);
    
#else
    
    
#define disable_dcnn()
#define using_dcnn(b)  0
#define dcnn_init()
#define get_dcnn_time()    (0.)
#define reset_dcnn_time()  do { } while(0)
    
    
#endif
}

#endif /* dcnn_hpp */
