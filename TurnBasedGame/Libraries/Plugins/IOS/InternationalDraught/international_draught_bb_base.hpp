//
//  bb_base.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_bb_base_hpp
#define international_draught_bb_base_hpp

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_var.hpp"
#include "international_draught_bb_index.hpp"
#include "international_draught_bb_comp.hpp"

namespace InternationalDraught
{
    
    namespace bb {
        
        bool is_load(var::Var* myVar, int32_t size);
        
        // functions
        
        bool pos_is_load   (var::Var* myVar, const Pos& pos);
        bool pos_is_search (struct var::Var* myVar, const Pos & pos, int32_t bb_size);
        
        Value probe     (struct var::Var* myVar, const Pos & pos);
        Value probe_raw (struct var::Var* myVar, const Pos & pos);
        
        Value value_update (Value node, Value child);
        
        Value value_age (Value val);
        Value value_max (Value v0, Value v1);

        int32_t value_nega (Value val, Side sd);
        
        std::string value_to_string (Value val);
        
    }
}

#endif /* bb_base_hpp */
