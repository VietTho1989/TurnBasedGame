//
//  moggy.hpp
//  weiqi
//
//  Created by Viet Tho on 3/28/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_moggy_hpp
#define weiqi_moggy_hpp

#include <stdio.h>
#include "../../Platform.h"

#include "../distributed/engines/weiqi_josekibase.hpp"
#include "../weiqi_board.hpp"

namespace weiqi
{
    struct playout_policy *playout_moggy_init(char *arg, struct board *b, struct joseki_dict *jdict);
}

#endif /* moggy_hpp */
