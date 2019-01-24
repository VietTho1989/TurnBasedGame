//
//  nakade.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_nakade_hpp
#define weiqi_nakade_hpp

/* Piercing eyes. */

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_board.hpp"

namespace weiqi
{
    /* Find an eye-piercing point within the @around area of empty board
     * internal to group of color @color.
     * Returns pass if the area is not a nakade shape or not internal. */
    coord_t nakade_point(struct board *b, coord_t around, enum stone color);
    
    /* big eyespace can be reduced to one eye */
    bool nakade_dead_shape(struct board *b, coord_t around, enum stone color);
}

#endif /* nakade_hpp */
