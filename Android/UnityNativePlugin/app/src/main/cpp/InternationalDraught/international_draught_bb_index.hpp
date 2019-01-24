//
//  bb_index.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_bb_index_hpp
#define international_draught_bb_index_hpp

#include <stdio.h>
#include "international_draught_libmy.hpp"
#include "international_draught_var.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    
    namespace bb {
        
        // functions
        
        void index_init ();
        
        bool id_is_ok (ID id);
        ID   id_make  (int32_t wm, int32_t bm, int32_t wk, int32_t bk);
        
        bool id_is_illegal (Variant_Type variantType, ID id);
        bool id_is_loss    (Variant_Type variantType, ID id);

        int32_t  id_size (ID id);

        int32_t  id_wm (ID id);
        int32_t  id_bm (ID id);
        int32_t  id_wk (ID id);
        int32_t  id_bk (ID id);
        
        std::string id_name (ID id);
        std::string id_file (ID id);
        
        ID pos_id (const Pos & pos);
        
        Index pos_index  (ID id, const Pos & pos);
        Index index_size (ID id);
        
    }
}

#endif /* bb_index_hpp */
