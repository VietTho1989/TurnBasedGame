//
//  move.hpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_move_hpp
#define weiqi_move_hpp

#include <stdio.h>
#include <ctype.h>
#include <stdint.h>
#include <string.h>

#include "weiqi_util.hpp"
#include "weiqi_stone.hpp"

namespace weiqi
{
    typedef int32_t coord_t;
    
#define coord_xy(board, x, y) ((x) + (y) * board_size(board))
#define coord_x(board_statics, c, b) (board_statics->coord[c][0])
#define coord_y(board_statics, c, b) (board_statics->coord[c][1])
    /* TODO: Smarter way to do this? */
#define coord_dx(board_statics, c1, c2, b) (coord_x(board_statics, c1, b) - coord_x(board_statics, c2, b))
#define coord_dy(board_statics, c1, c2, b) (coord_y(board_statics, c1, b) - coord_y(board_statics, c2, b))
    
#define pass   -1
#define resign -2
#define is_pass(c)   (c == pass)
#define is_resign(c) (c == resign)
    
#define coord_is_adjecent(c1, c2, b) (abs(c1 - c2) == 1 || abs(c1 - c2) == board_size(b))
#define coord_is_8adjecent(c1, c2, b) (abs(c1 - c2) == 1 || abs(abs(c1 - c2) - board_size(b)) < 2)
    
    /* Quadrants:
     * 0 1
     * 2 3 (vertically reversed from board_print output, of course!)
     * Middle coordinates are included in lower-valued quadrants. */
#define coord_quadrant(board_statics, c, b) ((coord_x(board_statics, c, b) > board_size(b) / 2) + 2 * (coord_y(board_statics, c, b) > board_size(b) / 2))
    
    struct board;
    // char *coord2bstr(char *buf, coord_t c, struct board *board);
    /* Return coordinate string in a dynamically allocated buffer. Thread-safe. */
    // char *coord2str(coord_t c, struct board *b);
    void coord2str(char* ret, coord_t c, struct board *board);
    /* Return coordinate string in a static buffer; multiple buffers are shuffled
     * to enable use for multiple printf() parameters, but it is NOT safe for
     * anything but debugging - in particular, it is NOT thread-safe! */
    // char *coord2sstr(coord_t c, struct board *b);
    void coord2sstr(char* ret, coord_t c, struct board *board);
    
    coord_t str2coord(char *str, int32_t board_size);
    
    
    struct move {
        coord_t coord;
        enum stone color;
        
    public:
        inline static int32_t getByteSize()
        {
            return sizeof(int32_t) + sizeof(int32_t);
        }
        
        static int32_t convertToByteArray(struct move* move, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct move* move, uint8_t* positionBytes, int32_t length, int32_t start);
    };
    
    // loai bo static
    inline int32_t move_cmp(struct move *m1, struct move *m2)
    {
        if (m1->color != m2->color)
            return m1->color - m2->color;
        return m1->coord - m2->coord;
    }
}

#endif /* move_hpp */
