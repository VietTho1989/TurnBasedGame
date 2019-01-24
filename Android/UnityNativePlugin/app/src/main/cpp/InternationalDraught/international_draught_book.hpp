//
//  book.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_book_hpp
#define international_draught_book_hpp

// includes

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
#include "international_draught_list.hpp"
#include "../Platform.h"

namespace InternationalDraught
{
    
    namespace book {
        
        // functions
        
        // void init(struct var::Var* myVar, const char* bookPath);
        
        // constants
        
        const int32_t Hash_Bit  { 20 };
        const int32_t Hash_Size { 1 << Hash_Bit };
        const int32_t Hash_Mask { Hash_Size - 1 };
        
        const Key Key_None { Key(0) };
        
        // types
        
        struct Entry {
            Key key;
            int16 score;
            bool node;
            bool done;
        };
        
        class Book {
            
        public:
            std::vector<Entry> p_table;
            
        public:
            bool load(Variant_Type variantType, const std::string & file_name);

            void clear ();
            
            void clear_done ();
            
        public:
            void backup (Variant_Type variantType);
            
            bool Load(Variant_Type variantType, const std::string & file_name);
            
        };
        
    }
}

#endif /* book_hpp */
