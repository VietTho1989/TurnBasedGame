//
//  josekibase.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_josekibase_hpp
#define weiqi_josekibase_hpp

#include <stdio.h>
#include "../../../Platform.h"

#include "../../weiqi_board.hpp"

namespace weiqi
{
    /* Single joseki situation - moves for S_BLACK-1, S_WHITE-1. */
    struct joseki_pattern {
        /* moves[] is a pass-terminated list or NULL */
        coord_t *moves[2];
    };
    
#define joseki_hash_bits 20 // 8M w/ 32-bit pointers
#define joseki_hash_mask ((1 << joseki_hash_bits) - 1)
    
    /* The joseki dictionary for given board size. */
    struct joseki_dict {
        int32_t bsize;
        struct joseki_pattern* patterns;
    };
    
    struct joseki_dict *joseki_init(int32_t bsize);
    struct joseki_dict *joseki_load(int32_t bsize);
    void joseki_done(struct joseki_dict *);
}

#endif /* josekibase_hpp */
