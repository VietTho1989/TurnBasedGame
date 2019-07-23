//
//  hash.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include "international_draught_hash.hpp"
#include "international_draught_bit.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    namespace hash {
        
        // constants
        
        const int32_t Table_Bit  { 18 };
        const int32_t Table_Size { 1 << Table_Bit };
        const int32_t Table_Mask { Table_Size - 1 };
        
        // variables
        
        static Key Key_Turn;
        static Key Key_Piece[Piece_Side_Size][64];
        
        static Key Key_Ranks_123[Table_Size];
        static Key Key_Ranks_456[Table_Size];
        static Key Key_Ranks_789[Table_Size];
        
        static Key Key_Ranks_012[Table_Size];
        static Key Key_Ranks_345[Table_Size];
        static Key Key_Ranks_678[Table_Size];
        
        // prototypes
        
        // bo static
        Key table_key(Piece_Side ps, int32_t index, int32_t offset) {
            {
                // assert(index >= 0 && index < Table_Size);
                if(!(index >= 0 && index < Table_Size)){
                    printf("error, assert(index >= 0 && index < Table_Size)\n");
                    index = 0;
                }
            }
            {
                // assert(square_is_ok(offset));
                if(!square_is_ok(offset)){
                    printf("error, assert(square_is_ok(offset))\n");
                }
            }
            
            Key key = Key(0);
            
            uint64 group = (uint64(index) << offset) & bit::Squares;
            
            for (Bit b = Bit(group); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
#ifndef Android
                key ^= Key_Piece[ps][sq];
#else
                key =  (Key)((uint64)key ^ (uint64)Key_Piece[ps][sq]);
#endif

            }
            
            return key;
        }
        
        // functions
        
        void init() {
            
            // hash keys
            
            Key_Turn = Key(ml::rand_int_64());
            
            for (int32_t ps = 0; ps < Piece_Side_Size; ps++) {
                for (int32_t dense = 0; dense < Dense_Size; dense++) {
                    Square sq = square_sparse(dense);
                    Key_Piece[ps][sq] = Key(ml::rand_int_64());
                }
            }
            
            // men tables
            
            for (int32_t index = 0; index < Table_Size; index++) {
                
                Key_Ranks_123[index] = table_key(White_Man, index,  6);
                Key_Ranks_456[index] = table_key(White_Man, index, 26);
                Key_Ranks_789[index] = table_key(White_Man, index, 45);
                
                Key_Ranks_012[index] = table_key(Black_Man, index,  0);
                Key_Ranks_345[index] = table_key(Black_Man, index, 19);
                Key_Ranks_678[index] = table_key(Black_Man, index, 39);
            }
        }
        
        Key key(const Pos & pos) {
#ifndef Android
            Key key = Key(0);

            // men

            Bit wm = pos.wm();
            Bit bm = pos.bm();

            key ^= Key_Ranks_123[(wm >>  6) & Table_Mask];
            key ^= Key_Ranks_456[(wm >> 26) & Table_Mask];
            key ^= Key_Ranks_789[(wm >> 45) & Table_Mask];

            key ^= Key_Ranks_012[(bm >>  0) & Table_Mask];
            key ^= Key_Ranks_345[(bm >> 19) & Table_Mask];
            key ^= Key_Ranks_678[(bm >> 39) & Table_Mask];

            // kings

            for (Bit b = pos.wk(); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                key ^= Key_Piece[White_King][sq];
            }

            for (Bit b = pos.bk(); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                key ^= Key_Piece[Black_King][sq];
            }

            // turn

            if (pos.turn() != White) key ^= Key_Turn;

            return key;
#else
            Key key = Key(0);

            // men

            Bit wm = pos.wm();
            Bit bm = pos.bm();

            key = (Key)((uint64)key ^ (uint64)Key_Ranks_123[(wm >>  6) & Table_Mask]);
            key = (Key)((uint64)key ^ (uint64)Key_Ranks_456[(wm >> 26) & Table_Mask]);
            key = (Key)((uint64)key ^ (uint64)Key_Ranks_789[(wm >> 45) & Table_Mask]);

            key = (Key)((uint64)key ^ (uint64)Key_Ranks_012[(bm >>  0) & Table_Mask]);
            key = (Key)((uint64)key ^ (uint64)Key_Ranks_345[(bm >> 19) & Table_Mask]);
            key = (Key)((uint64)key ^ (uint64)Key_Ranks_678[(bm >> 39) & Table_Mask]);

            // kings

            for (Bit b = pos.wk(); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                key = (Key)((uint64)key ^ (uint64)Key_Piece[White_King][sq]);
            }

            for (Bit b = pos.bk(); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                key = (Key)((uint64)key ^ (uint64)Key_Piece[Black_King][sq]);
            }

            // turn

            if (pos.turn() != White) key = (Key)((uint64)key ^ (uint64)Key_Turn);

            return key;
#endif
        }
        
    }
}
