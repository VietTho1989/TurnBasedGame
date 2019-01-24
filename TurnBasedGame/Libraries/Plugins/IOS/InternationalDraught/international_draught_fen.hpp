//
//  fen.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_fen_hpp
#define international_draught_fen_hpp

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_var.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    
    // constants
    
    const std::string Start_FEN { "W:W31-50:B1-20" };
    const std::string Start_Hub { "Wbbbbbbbbbbbbbbbbbbbbeeeeeeeeeewwwwwwwwwwwwwwwwwwww" };
    const std::string Start_DXP { "Wzzzzzzzzzzzzzzzzzzzzeeeeeeeeeewwwwwwwwwwwwwwwwwwww" };
    
    // functions
    
    Pos pos_from_fen (Variant_Type variantType, const std::string & s);
    Pos pos_from_hub (const std::string & s);
    Pos pos_from_dxp (const std::string & s);
    
    std::string pos_fen (Pos& pos);
    std::string pos_dxp (const Pos & pos);
}

#endif /* fen_hpp */
