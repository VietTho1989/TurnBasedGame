//
//  random_engine.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_random_engine_hpp
#define weiqi_random_engine_hpp

#include <stdio.h>
#include "weiqi_board.hpp"

namespace weiqi
{
    coord_t random_genmove(struct board *b, enum stone color, bool pass_all_alive);
}

#endif /* random_engine_hpp */
