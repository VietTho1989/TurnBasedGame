//
//  common.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_common_hpp
#define international_draught_common_hpp

#include <stdio.h>
#include <string>

#include "international_draught_libmy.hpp"

namespace InternationalDraught
{
    enum Variant_Type { Normal, Killer, BT };
    
    namespace bb
    {
        // constants
        
        const int32_t ID_Size { 1 << 12 };
        
        // types
        
        typedef uint32 Index; // enough for 6 pieces (7 for BT variant)
        
        enum ID : int;
    }
    
    // constants
    
    const int32_t Line_Size { 10 };
    const int32_t Dense_Size { Line_Size * Line_Size / 2 };
    const int32_t Square_Size { 63 };
    const int32_t Dir_Size { 4 };
    const int32_t Side_Size { 2 };
    const int32_t Piece_Size { 2 };
    const int32_t Piece_Side_Size { 4 }; // excludes Empty #
    
    const int32_t Move_Index_Size { 1 << 12 };
    
    const int32_t Stage_Size { 300 };
    
    const std::string Engine_Name { "Scan" };
    const std::string Engine_Version { "3.0" };
    
    // types
    
    enum Square : int32_t;
    
    enum class Dir : int32_t;
    enum Inc : int32_t {
        I1 = 6, J1 = 7,
        I2 = I1 * 2, J2 = J1 * 2,
    };
    
    enum Side { White, Black };
    enum Piece { Man, King };
    
    enum Piece_Side {
        White_Man,
        Black_Man,
        White_King,
        Black_King,
        Empty,
    };
    
    enum class Key  : uint64;
    enum class Move : uint64;
    
    enum Move_Index { Move_Index_None = 0 };
    
    enum Trit {
        Trit_White = -1,
        Trit_Empty = 0,
        Trit_Black = +1,
    };
    
    enum Depth : int32_t;
    enum Ply   : int32_t;
    // enum Score : int;
    typedef float Score;
    
    class Bit {
        
        public :
        
        uint64 p_bit;
        
        public :
        
        Bit () { p_bit = 0; }
        // bo explicit
        explicit Bit (uint64 b)
        {
            {
                // assert((b & ~U64(0x7DF3EF9F7CFBE7DF)) == 0);
                if(!((b & ~U64(0x7DF3EF9F7CFBE7DF)) == 0)){
                    printf("error, assert((b & ~U64(0x7DF3EF9F7CFBE7DF)) == 0)\n");
                }
            }
            p_bit = b;
        }
        
        operator uint64 () const { return p_bit; }
        
        void operator |= (Bit b)    { p_bit |= uint64(b); }
        void operator &= (uint64 b) { p_bit &= b; }
        void operator ^= (Bit b)    { p_bit ^= uint64(b); }
    };
    
    // operators
    
    inline Inc operator + (Inc sc) { return Inc(+int(sc)); }
    inline Inc operator - (Inc sc) { return Inc(-int(sc)); }
    
    inline void operator ^= (Key & k0, Key k1) { k0 = Key(uint64(k0) ^ uint64(k1)); }
    
    inline Depth operator + (Depth d0, Depth d1) { return Depth(int(d0) + int(d1)); }
    inline Depth operator - (Depth d0, Depth d1) { return Depth(int(d0) - int(d1)); }
    
    inline void operator += (Depth & d0, Depth d1) { d0 = d0 + d1; }
    inline void operator -= (Depth & d0, Depth d1) { d0 = d0 - d1; }
    
    inline Ply  operator + (Ply p0, Ply p1) { return Ply(int(p0) + int(p1)); }
    inline Ply  operator - (Ply p0, Ply p1) { return Ply(int(p0) - int(p1)); }
    
    inline void operator += (Ply & p0, Ply p1) { p0 = p0 + p1; }
    inline void operator -= (Ply & p0, Ply p1) { p0 = p0 - p1; }
    
    /*inline Score operator + (Score sc) { return Score(+int(sc)); }
     inline Score operator - (Score sc) { return Score(-int(sc)); }
     
     inline Score operator + (Score s0, Score s1) { return Score(int(s0) + int(s1)); }
     inline Score operator - (Score s0, Score s1) { return Score(int(s0) - int(s1)); }
     
     inline void operator += (Score & s0, Score s1) { s0 = s0 + s1; }
     inline void operator -= (Score & s0, Score s1) { s0 = s0 - s1; }*/
    
    inline Bit  operator | (Bit b0, Bit    b1) { return Bit(uint64(b0) | uint64(b1)); }
    inline Bit  operator & (Bit b0, uint64 b1) { return Bit(uint64(b0) & b1); }
    inline Bit  operator ^ (Bit b0, Bit    b1) { return Bit(uint64(b0) ^ uint64(b1)); }
    
    // functions
    
    void common_init ();
    
    bool   square_is_light (int32_t fl, int32_t rk);
    bool   square_is_dark  (int32_t fl, int32_t rk);
    bool   square_is_ok    (int32_t fl, int32_t rk);
    bool   square_is_ok    (int32_t sq);
    Square square_make     (int32_t fl, int32_t rk);
    Square square_make     (int32_t sq);
    
    Square square_sparse   (int32_t dense);
    int32_t    square_dense    (Square sq);
    Square square_from_std (int32_t std);
    int32_t    square_to_std   (Square sq);
    int32_t    square_file     (Square sq);
    int32_t    square_rank     (Square sq);
    Square square_opp      (Square sq);

    int32_t  square_rank         (Square sq, Side sd);
    bool square_is_promotion (Square sq, Side sd);
    
    std::string square_to_string   (Square sq);
    bool        string_is_square   (const std::string & s);
    Square      square_from_string (const std::string & s);
    
    Inc  inc_make (int32_t inc);
    Inc  dir_inc  (int32_t dir);
    
    Side side_make (int32_t sd);
    Side side_opp  (Side sd);
    
    std::string side_to_string (Side sd);
    
    Piece_Side piece_side_make  (int32_t ps);
    Piece      piece_side_piece (Piece_Side ps);
    Side       piece_side_side  (Piece_Side ps);
}

#endif /* common_hpp */
