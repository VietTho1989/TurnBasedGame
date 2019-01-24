//
//  bit.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_bit.hpp"

namespace InternationalDraught
{
    namespace bit {
        
        // variables
        
        static Bit File[Line_Size];
        static Bit Rank[Line_Size];
        
        static Bit Capture_Mask[Square_Size][64];
        static Bit Beyond[Square_Size][64];
        static int32_t Line_Inc[Square_Size][64];
        
        static Bit Man[Square_Size];
        static Bit King[Square_Size];
        
        // prototypes
        
        // bo static
        Bit ray_1(Square from, Inc inc) {
            Bit b = Bit(0);
            if (square_is_ok(from + inc)) {
                set(b, square_make(from + inc));
            }
            return b;
        }
        
        // bo static
        Bit ray(Square from, Inc inc) {
            Bit b = Bit(0);
            for (int32_t sq = from + inc; square_is_ok(sq); sq += inc) {
                set(b, square_make(sq));
            }
            return b;
        }
        
        // functions
        
        void init() {
            
            // files and ranks
            
            for (int32_t dense = 0; dense < Dense_Size; dense++) {
                
                Square sq = square_sparse(dense);
                
                set(File[square_file(sq)], sq);
                set(Rank[square_rank(sq)], sq);
            }
            
            // king attacks
            
            for (int32_t dense = 0; dense < Dense_Size; dense++) {
                
                Square from = square_sparse(dense);
                
                for (int32_t dir = 0; dir < Dir_Size; dir++) {
                    
                    Inc inc = dir_inc(dir);
                    
                    Man[from]  |= ray_1(from, inc);
                    King[from] |= ray(from, inc);
                    
                    for (Bit b = ray(from, inc); b != 0; b = rest(b)) {
                        
                        Square to = first(b);
                        
                        Capture_Mask[from][to] = (ray(from, inc) & ~bit(to) & ~ray(to, inc)) | ray_1(to, inc);
                        Beyond[from][to]       = ray(to, inc);
                        Line_Inc[from][to]     = inc;
                    }
                }
            }
        }
        
        Bit file(int32_t fl) {
            {
                // assert(fl >= 0 && fl < Line_Size);
                if(!(fl >= 0 && fl < Line_Size)){
                    printf("error, assert(fl >= 0 && fl < Line_Size)\n");
                    fl = 0;
                }
            }
            return File[fl];
        }
        
        Bit rank(int32_t rk) {
            {
                // assert(rk >= 0 && rk < Line_Size);
                if(!(rk >= 0 && rk < Line_Size)){
                    printf("error, assert(rk >= 0 && rk < Line_Size)\n");
                    rk = 0;
                }
            }
            return Rank[rk];
        }
        
        Bit rank(int32_t rk, Side sd) {
            {
                // assert(rk >= 0 && rk < Line_Size);
                if(!(rk >= 0 && rk < Line_Size)){
                    printf("error, assert(rk >= 0 && rk < Line_Size)\n");
                    rk = 0;
                }
            }
            if (sd == White) rk = (Line_Size - 1) - rk;
            return Rank[rk];
        }
        
        Bit capture_mask(Square from, Square to) {
            {
                // assert(has(King[from] & Inner, to));
                if(!(has(King[from] & Inner, to))){
                    printf("error, assert(has(King[from] & Inner, to))\n");
                }
            }
            return Capture_Mask[from][to];
        }
        
        Bit beyond(Square from, Square to) {
            {
                // assert(has(King[from], to));
                if(!(has(King[from], to))){
                    printf("error, assert(has(King[from], to))\n");
                }
            }
            return Beyond[from][to];
        }
        
        Inc line_inc(Square from, Square to) {
            {
                // assert(has(King[from], to));
                if(!(has(King[from], to))){
                    printf("error, assert(has(King[from], to))\n");
                }
            }
            return inc_make(Line_Inc[from][to]);
        }
        
        Bit man_attack(Square from) {
            return Man[from];
        }
        
        Bit king_attack(Square from) {
            return King[from];
        }
        
        Bit king_attack(Square from, Bit empty) {
            return attack(from, King[from], empty);
        }
        
        Bit attack(Square from, Bit tos, Bit empty) {
            {
                // assert(is_incl(tos, King[from]));
                if(!(is_incl(tos, King[from]))){
                    printf("error, assert(is_incl(tos, King[from]))\n");
                }
            }
            
            for (Bit b = tos & Inner & ~empty; b != 0; b = rest(b)) {
                Square sq = first(b);
                tos &= ~Beyond[from][sq];
            }
            
            return tos;
        }
        
    }
}
