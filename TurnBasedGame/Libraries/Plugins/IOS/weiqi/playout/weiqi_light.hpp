//
//  light.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_light_hpp
#define weiqi_light_hpp

#include <stdio.h>

#include "../../Platform.h"
#include "../weiqi_board.hpp"

namespace weiqi
{
    struct playout_policy *playout_light_init(char *arg, struct board *b);
}

#endif /* light_hpp */
