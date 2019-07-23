//
//  stats.cpp
//  weiqi
//
//  Created by Viet Tho on 3/27/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "weiqi_stats.hpp"

/* We actually do the atomicity in a pretty hackish way - we simply
 * rely on the fact that int,floating_t operations should be atomic with
 * reasonable compilers (gcc) on reasonable architectures (i386,
 * x86_64). */
/* There is a write order dependency - when we bump the playouts,
 * our value must be already correct, otherwise the node will receive
 * invalid evaluation if that's made in parallel, esp. when
 * current s->playouts is zero. */

