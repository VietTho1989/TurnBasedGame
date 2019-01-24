//
//  tt.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_tt_hpp
#define international_draught_tt_hpp

// includes

#include <stdio.h>
#include <vector>

#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    namespace tt {
        
        // types
        
        enum class Flags;
        
        inline Flags operator | (Flags f0, Flags f1) { return Flags(int(f0) | int(f1)); }
        
        inline void  operator |= (Flags & f0, Flags f1) { f0 = f0 | f1; }
        
        // constants
        
        const Flags Flags_None  { Flags(0) };
        const Flags Flags_Lower { Flags(1 << 0) };
        const Flags Flags_Upper { Flags(1 << 1) };
        const Flags Flags_Exact { Flags_Lower | Flags_Upper };
        const Flags Flags_Mask  { Flags_Lower | Flags_Upper };
        
        // types
        
        class TT {
            
            private :
            
            static const int32_t Date_Size { 16 };
            
            struct Entry { // 16 bytes
                uint32 lock;
                uint32 pad_4; // #
                uint16 move;
                int16 score;
                uint8 depth;
                uint8 date;
                uint8 flags;
                uint8 pad_1; // #
            };
            
            std::vector<Entry> p_table;

            int32_t p_size;
            int32_t p_mask;
            int32_t p_date;
            int32_t p_age[Date_Size];
            
            public :
            
            void set_size (int32_t size);
            
            void clear    ();
            void inc_date ();
            
            void store (Key key, Move_Index move, Depth depth, Flags flags, Score score);
            bool probe (Key key, Move_Index & move, Depth & depth, Flags & flags, Score & score);
            
            private :
            
            void set_date (int32_t date);
            int32_t  age      (int32_t date) const;
        };
        
        
        // functions
        
        inline bool is_lower (Flags flags) { return (int(flags) & int(Flags_Lower)) != 0; }
        inline bool is_upper (Flags flags) { return (int(flags) & int(Flags_Upper)) != 0; }
        inline bool is_exact (Flags flags) { return flags == Flags_Exact; }
        
    }
}

#endif /* tt_hpp */
