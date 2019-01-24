//
//  fbook.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_fbook_hpp
#define weiqi_fbook_hpp

#include <stdio.h>

#include "weiqi_move.hpp"
#include "weiqi_board.hpp"

namespace weiqi
{
    /* Opening book (fbook as in "forcing book" since the move is just
     * played unconditionally if found, or possibly "fuseki book"). */
    
    struct fbook {
        int32_t bsize;
        int32_t handicap;

        int32_t movecnt;
        
#define fbook_hash_bits 20 // 12M w/ 32-bit coord_t
#define fbook_hash_mask ((1 << fbook_hash_bits) - 1)
        /* pass == no move in this position */
        coord_t moves[1<<fbook_hash_bits];
        hash_t hashes[1<<fbook_hash_bits];
    };
    
    extern struct fbook *fbcache;
    
    coord_t fbook_check(struct board *board);
    struct fbook *fbook_init(char *filename, struct board *b);
    void fbook_done(struct fbook *fbook);
    
    coord_t coord_transform(struct board *b, coord_t coord, int32_t i);
}

#endif /* fbook_hpp */
