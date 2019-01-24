//
//  seki.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_seki_hpp
#define weiqi_seki_hpp

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_board.hpp"

namespace weiqi
{
    bool breaking_3_stone_seki(struct board *b, coord_t coord, enum stone color);
}

#endif /* seki_hpp */
