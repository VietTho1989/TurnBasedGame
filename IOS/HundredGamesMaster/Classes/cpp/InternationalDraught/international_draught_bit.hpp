//
//  bit.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_bit_hpp
#define international_draught_bit_hpp

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    namespace bit {
        
        // constants
        
        const Bit Squares { Bit(U64(0x7DF3EF9F7CFBE7DF)) }; // legal squares
        const Bit Inner   { Bit(U64(0x00F3C79E3CF1E780)) };
        
        const Bit WM_Squares { Bit(U64(0x7DF3EF9F7CFBE7C0)) }; // white man
        const Bit BM_Squares { Bit(U64(0x01F3EF9F7CFBE7DF)) }; // black man
        
        const Bit Files_01 { Bit(U64(0x0410208104082041)) };
        const Bit Files_23 { Bit(U64(0x0820410208104082)) };
        const Bit Files_45 { Bit(U64(0x1040820410208104)) };
        const Bit Files_67 { Bit(U64(0x2081040820410208)) };
        const Bit Files_89 { Bit(U64(0x4102081040820410)) };
        
        const Bit Ranks_012 { Bit(U64(0x000000000003E7DF)) };
        const Bit Ranks_345 { Bit(U64(0x0000001F7CF80000)) };
        const Bit Ranks_678 { Bit(U64(0x01F3EF8000000000)) };
        const Bit Ranks_123 { Bit(U64(0x0000000000FBE7C0)) };
        const Bit Ranks_456 { Bit(U64(0x00000F9F7C000000)) };
        const Bit Ranks_789 { Bit(U64(0x7DF3E00000000000)) };
        
        // functions
        
        void init ();
        
        inline bool is_ok (uint64 b) { return (b & ~U64(0x7DF3EF9F7CFBE7DF)) == 0; }
        
        inline Bit  bit (Square sq) { return Bit(U64(1) << sq); }
        
        inline bool has (Bit b, Square sq) { return (b & bit(sq)) != 0; }
        inline int32_t  bit (Bit b, Square sq) { return (b >> sq) & 1; }
        
        inline bool is_incl (Bit b0, Bit b1) { return (b0 & ~b1) == 0; }
        
        inline void set    (Bit & b, Square sq) { b |=  bit(sq); }
        inline void clear  (Bit & b, Square sq) { b &= ~bit(sq); }
        inline void flip   (Bit & b, Square sq) { b ^=  bit(sq); }
        
        inline Bit add(Bit b, Square sq)
        {
            {
                // assert(!has(b, sq));
                if(has(b, sq)){
                    printf("error, assert(!has(b, sq))\n");
                }
            }
            return b ^ bit(sq);
        }
        
        inline Bit remove (Bit b, Square sq)
        {
            {
                // assert(has(b, sq));
                if(!(has(b, sq))){
                    printf("error, assert(has(b, sq))\n");
                }
            }
            return b ^ bit(sq);
        }
        
        inline Square first(Bit b){
            {
                // assert(b != 0);
                if(b==0){
                    printf("error, assert(b != 0)\n");
                    b = Bit(1);
                }
            }
            return Square(ml::bit_first(b));
        }
        
        inline Bit rest(Bit b)
        {
            {
                // assert(b != 0);
                if(b==0){
                    printf("error, assert(b != 0)\n");
                    b = Bit(1);
                }
            }
            return b & (b - 1);
        }
        
        inline int32_t    count (Bit b) { return ml::bit_count(b); }
        
        Bit  file (int32_t fl);
        Bit  rank (int32_t rk);
        Bit  rank (int32_t rk, Side sd);
        
        Bit  capture_mask (Square from, Square to);
        Bit  beyond       (Square from, Square to);
        Inc  line_inc     (Square from, Square to);
        
        Bit  man_attack  (Square from);
        Bit  king_attack (Square from);
        
        Bit  king_attack (Square from, Bit empty);
        Bit  attack      (Square from, Bit tos, Bit empty);
        
        void disp (Bit b);
        
    }
}

#endif /* bit_hpp */
