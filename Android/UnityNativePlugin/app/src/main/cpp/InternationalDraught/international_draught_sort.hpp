//
//  sort.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_sort_hpp
#define international_draught_sort_hpp

// includes

#include <stdio.h>
#include "international_draught_pos.hpp"
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    
    // functions
    
    void sort_clear ();
    
    void good_move (Move_Index index);
    void bad_move  (Move_Index index);
    
    void sort_all (List & list, const Pos & pos, Move_Index tt_move);
}

#endif /* sort_hpp */
