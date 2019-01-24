//
//  slave.hpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef weiqi_slave_hpp
#define weiqi_slave_hpp

#include <stdio.h>
#include "weiqi_tree.hpp"

namespace weiqi
{
    void* uct_htable_alloc(int32_t hbits);
    void uct_htable_reset(struct tree *t);
}

#endif /* slave_hpp */
