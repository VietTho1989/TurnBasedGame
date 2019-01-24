//
//  dcnn.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_dcnn.hpp"
#include "weiqi_board.hpp"

namespace weiqi
{
    // bo static
    inline int32_t coord2dcnn_idx(coord_t c, struct board *b)
    {
        board_statics* board_statics = &b->board_statics;
        int32_t x = coord_x(board_statics, c, b) - 1;
        int32_t y = coord_y(board_statics, c, b) - 1;
        return (y * 19 + x);
    }
}
