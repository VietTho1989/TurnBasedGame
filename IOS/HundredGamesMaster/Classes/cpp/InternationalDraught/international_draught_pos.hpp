//
//  pos.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_pos_hpp
#define international_draught_pos_hpp

#include <stdio.h>
#include "international_draught_bit.hpp"
#include "international_draught_var.hpp"

namespace InternationalDraught
{
    // types
    
    struct Pos
    {
        
    private:
        Bit p_piece[Piece_Size];// 8*2
        Bit p_side[Side_Size];// 8*2
        Bit p_all;// 8
        Side p_turn;// 4
        
    public:
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(struct Pos* pos, uint8_t* &byteArray);
        
        static int32_t parseByteArray(struct Pos* pos, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);
        
    public:
        Pos () { }
        Pos (Variant_Type variantType, Side turn, Bit wm, Bit bm, Bit wk, Bit bk);
        
        Pos succ (Variant_Type variantType, Move mv) const;
        
        Side turn () const { return p_turn; }
        
        Bit  all   () const { return p_all; }
        Bit  empty () const { return bit::Squares ^ all(); }
        
        Bit  piece (Piece pc) const { return p_piece[pc]; }
        Bit  side  (Side sd)  const { return p_side[sd]; }
        
        Bit  piece_side (Piece pc, Side sd) const { return piece(pc) & side(sd); }
        
        Bit  man  () const { return piece(Man); }
        Bit  king () const { return piece(King); }
        
        Bit  man  (Side sd) const { return piece_side(Man, sd); }
        Bit  king (Side sd) const { return piece_side(King, sd); }
        
        Bit  white () const { return side(White); }
        Bit  black () const { return side(Black); }
        
        Bit  wm () const { return man(White); }
        Bit  bm () const { return man(Black); }
        Bit  wk () const { return king(White); }
        Bit  bk () const { return king(Black); }
        
        bool is_piece (Square sq, Piece pc) const { return bit::has(piece(pc), sq); }
        bool is_side  (Square sq, Side sd)  const { return bit::has(side(sd), sq); }
        bool is_empty (Square sq)           const { return bit::has(empty(), sq); }
        
    private:
        Pos(Variant_Type variantType, Bit man, Bit king, Bit white, Bit black, Bit all, Side turn);
        
    public:
        
        Piece_Side piece_side(Square sq);
    };
    
    class Node {
        
        public :
        
        Pos p_pos;
        int32_t p_ply;
        Node * p_parent;
        
        public :
        
        Node () { }
        explicit Node (Pos& pos);
        
        operator const Pos & () const { return p_pos; }
        
        bool is_end  (struct var::Var* myVar)        const;
        bool is_draw (int32_t rep) const;
        
    public:
        
        // Node* succ(Move mv);
        
        void mySucc(struct var::Var* myVar, Move mv, Node* newNode);
        
        Node (Pos& pos, int32_t ply, Node* parent);
    };
    
    namespace pos { // ###
        
        // variables
        
        extern Pos StartNormal;
        extern Pos StartKiller;
        extern Pos StartBT;
        
        // functions
        
        void init ();
        
        bool is_loss (struct var::Var* myVar, const Pos & pos);
        bool is_wipe (struct var::Var* myVar, const Pos & pos);
        
        inline int32_t  size (const Pos & pos) { return bit::count(pos.all()); }
        
        inline bool has_king (const Pos & pos)          { return pos.king()   != 0; }
        inline bool has_king (const Pos & pos, Side sd) { return pos.king(sd) != 0; }
        
        Piece_Side piece_side (const Pos& pos, Square sq);
        
        double phase (const Pos & pos);
        int32_t    stage (const Pos & pos);
        int32_t    tempo (const Pos & pos);
        int32_t    skew  (const Pos & pos, Side sd);
        
        void disp (struct var::Var* myVar, const Pos & pos);
        
    }
    
    Move find_index (const List & list, Move_Index index, const Pos & pos);
    
    book::Entry * find_entry (book::Book* book, const Pos & pos, bool create = false);
    
    Score backup (book::Book* book, Variant_Type variantType, const Pos& pos);
    
    bool load (book::Book* book, Variant_Type variantType, std::istream& file, const Pos& pos);
    
#ifdef Android
    bool load (book::Book* book, Variant_Type variantType, assetistream& file, const Pos& pos);
#endif
    
    bool in_book(book::Book* book, const Pos& pos);
    
    Score book_score (book::Book* book, const Pos& pos);
    
    bool probe (book::Book* book, Variant_Type variantType, const Pos & pos, Score margin, Move & move, Score & score);
    
    void book_gen(book::Book* book, Variant_Type variantType, List& list, const Pos & pos);
    
}

#endif /* pos_hpp */
