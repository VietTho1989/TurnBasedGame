//
//  eval.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_eval_hpp
#define international_draught_eval_hpp

// includes

#include <string>
#include <stdio.h>

#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_var.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    // functions
    Score eval(struct var::Var* myVar, const Pos & pos, Side sd);
}

#endif /* eval_hpp */
