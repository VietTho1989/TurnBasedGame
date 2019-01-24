//
//  move_gen.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_move_gen_hpp
#define international_draught_move_gen_hpp

#include <stdio.h>
#include "international_draught_pos.hpp"
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_var.hpp"

namespace InternationalDraught
{
    
    // functions
    
    void gen_moves      (Variant_Type variantType, List & list, const Pos & pos);
    void gen_captures   (Variant_Type variantType, List & list, const Pos & pos);
    void gen_promotions (List & list, const Pos & pos);
    void add_sacs       (List & list, const Pos & pos);
    
    bool can_move    (const Pos & pos, Side sd);
    bool can_capture (const Pos & pos, Side sd);
    
    inline bool is_quiet   (const Pos & pos) { return !can_capture(pos, White) && !can_capture(pos, Black); }
    inline bool is_capture (const Pos & pos) { return can_capture(pos, pos.turn()); }
    inline bool is_threat  (const Pos & pos) { return can_capture(pos, side_opp(pos.turn())); }
}

#endif /* move_gen_hpp */
