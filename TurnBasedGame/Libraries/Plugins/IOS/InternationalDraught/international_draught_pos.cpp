//
//  pos.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_pos.hpp"
#include "international_draught_var.hpp"
#include "international_draught_move.hpp"
#include "international_draught_move_gen.hpp"
#include "international_draught_fen.hpp"
#include "international_draught_bb_base.hpp"
#include "international_draught_hash.hpp"
#include "international_draught_score.hpp"

namespace InternationalDraught
{
    // functions
    
    Pos::Pos(Variant_Type variantType, Side turn, Bit wm, Bit bm, Bit wk, Bit bk) : Pos(variantType, wm | bm, wk | bk, wm | wk, bm | bk, wm | bm | wk | bk, turn)
    {
        {
            // assert(bit::count(wm | bm | wk | bk) == bit::count(wm) + bit::count(bm) + bit::count(wk) + bit::count(bk)); // all disjoint?
            if(!(bit::count(wm | bm | wk | bk) == bit::count(wm) + bit::count(bm) + bit::count(wk) + bit::count(bk))){
                printf("error, assert(bit::count(wm | bm | wk | bk) == bit::count(wm) + bit::count(bm) + bit::count(wk) + bit::count(bk))\n");
            }
        }
        
        {
            // assert(bit::is_incl(wm, bit::WM_Squares));
            if(!bit::is_incl(wm, bit::WM_Squares)){
                printf("error, assert(bit::is_incl(wm, bit::WM_Squares))\n");
            }
        }
        {
            // assert(bit::is_incl(bm, bit::BM_Squares));
            if(!(bit::is_incl(bm, bit::BM_Squares))){
                printf("error, assert(bit::is_incl(bm, bit::BM_Squares))\n");
            }
        }
    }
    
    Pos::Pos(Variant_Type variantType, Bit man, Bit king, Bit white, Bit black, Bit all, Side turn) {
        {
            // assert((man ^ king) == all);
            if(!((man ^ king) == all)){
                printf("error, assert((man ^ king) == all)\n");
            }
        }
        {
            // assert((white ^ black) == all);
            if(!((white ^ black) == all)){
                printf("error, assert((white ^ black) == all)\n");
            }
        }
        
        {
            // assert(bit::is_incl(man & white, bit::WM_Squares));
            if(!(bit::is_incl(man & white, bit::WM_Squares))){
                printf("error, assert(bit::is_incl(man & white, bit::WM_Squares))\n");
            }
        }
        {
            // assert(bit::is_incl(man & black, bit::BM_Squares));
            if(!(bit::is_incl(man & black, bit::BM_Squares))){
                printf("error, assert(bit::is_incl(man & black, bit::BM_Squares))\n");
            }
        }
        
        Bit side[Side_Size] { white, black };
        {
            // assert(side[side_opp(turn)] != 0);
            if(side[side_opp(turn)] == 0){
                printf("error, assert(side[side_opp(turn)] != 0)\n");
            }
        }
        if (variantType == BT){
            // assert((side[turn] & king) == 0);
            if((side[turn] & king) != 0){
                printf("error, assert((side[turn] & king) == 0)\n");
            }
        }
        
        {
            // assert(bit::count(white) <= 20);
            if(bit::count(white) > 20){
                printf("error, assert(bit::count(white) <= 20)\n");
            }
        }
        {
            // assert(bit::count(black) <= 20);
            if(bit::count(black) > 20){
                printf("error, assert(bit::count(black) <= 20)\n");
            }
        }
        
        p_piece[Man]  = man;
        p_piece[King] = king;
        p_side[White] = white;
        p_side[Black] = black;
        p_all = all;
        p_turn = turn;
    }
    
    Pos Pos::succ(Variant_Type variantType, Move mv) const {
        
        Square from = move::from(mv);
        Square to   = move::to(mv);
        Bit    caps = move::captured(mv);
        
        Side atk = p_turn;
        Side def = side_opp(atk);
        
        {
            // assert(is_side(from, atk));
            if(!(is_side(from, atk))){
                printf("error, assert(is_side(from, atk))\n");
            }
        }
        {
            // assert(from == to || is_empty(to));
            if(!(from == to || is_empty(to))){
                printf("error, assert(from == to || is_empty(to))\n");
            }
        }
        {
            // assert(bit::is_incl(caps, side(def)));
            if(!(bit::is_incl(caps, side(def)))){
                printf("error, assert(bit::is_incl(caps, side(def)))\n");
            }
        }
        
        Bit piece[Piece_Size] { p_piece[Man],  p_piece[King] };
        Bit side[Side_Size]   { p_side[White], p_side[Black] };
        Bit all = this->all();
        
        Bit delta = bit::bit(from) ^ bit::bit(to);
        
        side[atk] ^= delta;
        all ^= delta;
        
        if (is_piece(from, King)) { // king move
            piece[King] ^= delta;
        } else if (square_is_promotion(to, atk)) { // promotion
            bit::clear(piece[Man], from);
            bit::set(piece[King], to);
        } else { // man move
            piece[Man] ^= delta;
        }
        
        piece[Man]  &= ~caps;
        piece[King] &= ~caps;
        side[def]   &= ~caps;
        all         &= ~caps;
        
        return Pos(variantType, piece[Man], piece[King], side[White], side[Black], all, def);
    }
    
    //////////////////////////////////////////////////////////////////////////
    //////////////////// Print Position //////////////////////
    
    Piece_Side Pos::piece_side(Square sq)
    {
        int32_t ps = (bit::bit(empty(), sq) << 2)
        | (bit::bit(king(),  sq) << 1)
        | (bit::bit(black(), sq) << 0);
        
        return Piece_Side(ps); // can be Empty
    }
    
    Node::Node(Pos& pos) : Node(pos, 0, nullptr) {
    }
    
    Node::Node(Pos& pos, int32_t ply, Node* parent) {
        p_pos = pos;
        p_ply = ply;
        p_parent = parent;
    }
    
    void Node::mySucc(struct var::Var* myVar, Move mv, Node* newNode)
    {
        Pos new_pos = p_pos.succ(myVar->Variant, mv);
        
        if (move::is_conversion(mv, p_pos)) {
            // printf("move is conversion\n");
            newNode->p_pos = new_pos;
            newNode->p_ply = 0;
            newNode->p_parent = nullptr;
        } else {
            // printf("move isn't conversion\n");
            newNode->p_pos = new_pos;
            newNode->p_ply = p_ply + 1;
            newNode->p_parent = this;
        }
    }
    
    bool Node::is_end(struct var::Var* myVar) const {
        return pos::is_loss(myVar, p_pos) || is_draw(3);
    }
    
    bool Node::is_draw(int32_t rep) const {
        
        if (p_ply < 4) return false;
        
        const Node * node = this;

        int32_t n = 1;
        
        for (int32_t i = 0; i < p_ply / 2; i++) {
            
            node = node->p_parent;
            {
                // assert(node != nullptr);
                if(node==nullptr){
                    printf("error, assert(node != nullptr)\n");
                    return false;
                }
            }
            
            node = node->p_parent;
            {
                // assert(node != nullptr);
                if(node==nullptr){
                    printf("error, assert(node != nullptr)\n");
                    return false;
                }
            }
            
            {
                // assert(node->p_pos.turn() == p_pos.turn());
                if(node->p_pos.turn() != p_pos.turn()){
                    printf("error, assert(node->p_pos.turn() == p_pos.turn())\n");
                    return false;
                }
            }
            
            if (node->p_pos.wk() == p_pos.wk()
                && node->p_pos.bk() == p_pos.bk()) {
                n++;
                if (n == rep) return true;
            }
        }
        
        return false;
    }
    
    namespace pos { // ###
        
        // types
        
        typedef int32_t fun_t(Piece_Side ps, Square sq);
        
        // constants
        
        const int32_t Table_Bit  { 18 };
        const int32_t Table_Size { 1 << Table_Bit };
        const int32_t Table_Mask { Table_Size - 1 };
        
        // variables
        
        Pos StartNormal;
        Pos StartKiller;
        Pos StartBT;
        
        static int32_t Tempo_Ranks_123[Table_Size];
        static int32_t Tempo_Ranks_456[Table_Size];
        static int32_t Tempo_Ranks_789[Table_Size];
        
        static int32_t Tempo_Ranks_012[Table_Size];
        static int32_t Tempo_Ranks_345[Table_Size];
        static int32_t Tempo_Ranks_678[Table_Size];
        
        static int32_t Skew_Ranks_123[Table_Size];
        static int32_t Skew_Ranks_456[Table_Size];
        static int32_t Skew_Ranks_789[Table_Size];
        
        static int32_t Skew_Ranks_012[Table_Size];
        static int32_t Skew_Ranks_345[Table_Size];
        static int32_t Skew_Ranks_678[Table_Size];
        
        // prototypes
        
        // bo static
        int32_t table_val(fun_t f, Piece_Side ps, int32_t index, int32_t offset) {
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

            int32_t val = 0;
            
            uint64 group = (uint64(index) << offset) & bit::Squares;
            
            for (Bit b = Bit(group); b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                val += f(ps, sq);
            }
            
            return val;
        }
        
        // bo static
        int32_t tempo(Piece_Side ps, Square sq) {
            switch (piece_side_piece(ps)) {
                case Man  :
                    return (Line_Size - 1) - square_rank(sq, piece_side_side(ps));
                case King :
                    return 0;
                default   :
                    return 0;
            }
        }
        // bo static
        int32_t skew(Piece_Side ps, Square sq) {
            switch (piece_side_piece(ps)) {
                case Man  : return square_file(sq) * 2 - (Line_Size - 1);
                case King : return 0;
                default   : return 0;
            }
        }
        
        // functions
        
        void init() {
            
            // starting position
            {
                StartNormal = pos_from_fen(Normal, Start_FEN);
                StartKiller = pos_from_fen(Killer, Start_FEN);
                StartBT = pos_from_fen(BT, Start_FEN);
            }
            
            // men tables
            
            for (int32_t index = 0; index < Table_Size; index++) {
                
                Tempo_Ranks_123[index] = table_val(tempo, White_Man, index,  6);
                Tempo_Ranks_456[index] = table_val(tempo, White_Man, index, 26);
                Tempo_Ranks_789[index] = table_val(tempo, White_Man, index, 45);
                
                Tempo_Ranks_012[index] = table_val(tempo, Black_Man, index,  0);
                Tempo_Ranks_345[index] = table_val(tempo, Black_Man, index, 19);
                Tempo_Ranks_678[index] = table_val(tempo, Black_Man, index, 39);
                
                Skew_Ranks_123[index]  = table_val(skew,  White_Man, index,  6);
                Skew_Ranks_456[index]  = table_val(skew,  White_Man, index, 26);
                Skew_Ranks_789[index]  = table_val(skew,  White_Man, index, 45);
                
                Skew_Ranks_012[index]  = table_val(skew,  Black_Man, index,  0);
                Skew_Ranks_345[index]  = table_val(skew,  Black_Man, index, 19);
                Skew_Ranks_678[index]  = table_val(skew,  Black_Man, index, 39);
            }
        }
        
        bool is_loss(struct var::Var* myVar, const Pos & pos) {
            return !can_move(pos, pos.turn())
            || (myVar->Variant == BT && has_king(pos, side_opp(pos.turn())));
        }
        
        bool is_wipe(struct var::Var* myVar, const Pos & pos) { // fast subset of "is_loss"
            return pos.side(pos.turn()) == 0
            || (myVar->Variant == BT && has_king(pos, side_opp(pos.turn())));
        }
        
        Piece_Side piece_side(const Pos & pos, Square sq) {

            int32_t ps = (bit::bit(pos.empty(), sq) << 2)
            | (bit::bit(pos.king(),  sq) << 1)
            | (bit::bit(pos.black(), sq) << 0);
            
            return Piece_Side(ps); // can be Empty
        }
        
        double phase(const Pos & pos) {
            
            double phase = double(stage(pos)) / double(Stage_Size);
            
            {
                // assert(phase >= 0.0 && phase <= 1.0);
                if(!(phase >= 0.0 && phase <= 1.0)){
                    printf("error, assert(phase >= 0.0 && phase <= 1.0)\n");
                    phase = 1.0;
                }
            }
            return phase;
        }

        int32_t stage(const Pos & pos) {

            int32_t stage = 300 - tempo(pos);
            
            {
                // assert(stage >= 0 && stage <= Stage_Size);
                if(!(stage >= 0 && stage <= Stage_Size)){
                    printf("error, assert(stage >= 0 && stage <= Stage_Size)\n");
                    stage = 0;
                }
            }
            return stage;
        }

        int32_t tempo(const Pos & pos) {

            int32_t tempo = 0;
            
            tempo += Tempo_Ranks_123[(pos.wm() >>  6) & Table_Mask];
            tempo += Tempo_Ranks_456[(pos.wm() >> 26) & Table_Mask];
            tempo += Tempo_Ranks_789[(pos.wm() >> 45) & Table_Mask];
            
            tempo += Tempo_Ranks_012[(pos.bm() >>  0) & Table_Mask];
            tempo += Tempo_Ranks_345[(pos.bm() >> 19) & Table_Mask];
            tempo += Tempo_Ranks_678[(pos.bm() >> 39) & Table_Mask];
            
            return tempo;
        }

        int32_t skew(const Pos & pos, Side sd) {

            int32_t skew = 0;
            
            if (sd == White) {
                skew += Skew_Ranks_123[(pos.wm() >>  6) & Table_Mask];
                skew += Skew_Ranks_456[(pos.wm() >> 26) & Table_Mask];
                skew += Skew_Ranks_789[(pos.wm() >> 45) & Table_Mask];
            } else {
                skew += Skew_Ranks_012[(pos.bm() >>  0) & Table_Mask];
                skew += Skew_Ranks_345[(pos.bm() >> 19) & Table_Mask];
                skew += Skew_Ranks_678[(pos.bm() >> 39) & Table_Mask];
            }
            
            return skew;
        }
        
        void disp(struct var::Var* myVar, const Pos& pos) {
            
            // pieces
            
            for (int32_t rk = 0; rk < Line_Size; rk++) {
                
                for (int32_t fl = 0; fl < Line_Size; fl++) {
                    
                    if (square_is_light(fl, rk)) {
                        
                        std::printf("  ");
                        
                    } else {
                        
                        Square sq = square_make(fl, rk);
                        
                        switch (piece_side(pos, sq)) {
                            case White_Man :  std::printf("O "); break;
                            case Black_Man :  std::printf("* "); break;
                            case White_King : std::printf("@ "); break;
                            case Black_King : std::printf("# "); break;
                            case Empty :      std::printf("- "); break;
                            default :         std::printf("? "); break;
                        }
                    }
                }
                
                std::printf("  ");
                
                for (int32_t fl = 0; fl < Line_Size; fl++) {
                    
                    if (square_is_light(fl, rk)) {
                        std::printf("  ");
                    } else {
                        Square sq = square_make(fl, rk);
                        std::printf("%02d", square_to_std(sq));
                    }
                }
                
                std::printf("\n");
            }
            
            std::printf("\n");
            std::fflush(stdout);
            
            // turn
            
            Side atk = pos.turn();
            Side def = side_opp(atk);
            
            if (is_loss(myVar, pos)) {
                
                std::cout << side_to_string(def) << " wins #";
                
            } else {
                
                std::cout << side_to_string(atk) << " to play";
                
                if (bb::pos_is_load(myVar, pos)) {
                    bb::Value val = bb::probe(myVar, pos);
                    std::cout << ", endgame " << bb::value_to_string(val);
                }
            }
            
            std::cout << std::endl;
            std::cout << std::endl;
        }
    }
    
    Move find_index(const List & list, Move_Index index, const Pos & pos) {
        
        for (int32_t i = 0; i < list.size(); i++) {
            
            Move mv = list.move(i);
            
            if (move::index(mv, pos) == index) {
                return mv;
            }
        }
        
        return move::None;
    }
    
    // bo static
    void book_filter(List& list, Score margin) {
        if (list.size() > 1) {
            int32_t i;
            for (i = 1; i < list.size(); i++) { // skip 0
                if (list.score(i) + margin < list.score(0)) break;
            }
            list.set_size(i);
        }
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////// Convert ////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////
    
    book::Entry* find_entry(book::Book* book, const Pos& pos, bool create) {
        
        Key key = hash::key(pos);
        if (key == book::Key_None) {
            printf("error, key none, return null\n");
            return nullptr;
        }
        
        for (int32_t index = hash::index(key, book::Hash_Mask); true; index = (index + 1) & book::Hash_Mask) {
            book::Entry * entry = &book->p_table[index];
            if (entry->key == book::Key_None) { // free entry
                if (create) {
                    *entry = { key, 0, false, false };
                    return entry;
                } else {
                    // printf("error, find_entry: return null\n");
                    return nullptr;
                }
            } else if (entry->key == key) {
                return entry;
            }
        }
    }
    
    Score backup(book::Book* book, Variant_Type variantType, const Pos& pos) {
        
        book::Entry * entry = find_entry(book, pos);
        {
            // assert(entry != nullptr);
            if(entry==nullptr){
                printf("error, assert(entry != nullptr)\n");
                return Score(0);
            }else{
                // printf("correct, find entry\n");
            }
        }
        
        if (entry->done || !entry->node) return Score(entry->score);
        
        List list;
        gen_moves(variantType, list, pos);
        
        Score bs = score::None;
        
        for (int32_t i = 0; i < list.size(); i++) {
            
            Move mv = list.move(i);
            
            Pos new_pos = pos.succ(variantType, mv);
            Score sc = -backup(book, variantType, new_pos);
            
            if (sc > bs) bs = sc;
        }
        
        if (bs == score::None) bs = -score::Inf; // no legal moves
        
        {
            // assert(bs >= -score::Inf && bs <= +score::Inf);
            if(!(bs >= -score::Inf && bs <= +score::Inf)){
                printf("error, assert(bs >= -score::Inf && bs <= +score::Inf)\n");
                if(bs<-score::Inf){
                    bs = -score::Inf;
                }
                if(bs > +score::Inf){
                    bs = +score::Inf;
                }
            }
        }
        entry->score = (int16) bs;
        entry->done = true;
        
        return bs;
    }
    
    bool load(book::Book* book, Variant_Type variantType, std::istream& file, const Pos& pos) {
        
        book::Entry * entry = find_entry(book, pos, true);
        // assert(entry != nullptr);
        if(entry==nullptr){
            printf("error, entry null\n");
            return false;
        }
        
        if (entry->done){
            // printf("error, why entry done\n");
            return true;
        }
        entry->done = true;
        
        bool node;
        file >> node;
        
        if (file.eof()) {
            printf("load(): EOF\n");
            // std::exit(EXIT_FAILURE);
            return false;
        }
        
        if (!node) { // leaf
            file >> entry->score;
            // printf("Book load: score: %d\n", entry->score);
            if (file.eof()) {
                printf("load(): EOF\n");
                // std::exit(EXIT_FAILURE);
                return false;
            }
        } else {
            entry->node = true;
            List list;
            gen_moves(variantType, list, pos);
            list.sort_static();
            
            for (int32_t i = 0; i < list.size(); i++) {
                Move mv = list.move(i);
                Pos new_pos = pos.succ(variantType, mv);
                if(!load(book, variantType, file, new_pos)){
                    printf("error, why load fail\n");
                    return false;
                }
            }
        }
        return true;
    }
    
#ifdef Android
    bool load(book::Book* book, Variant_Type variantType, assetistream& file, const Pos& pos) {
        // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load asset stream\n");
        book::Entry * entry = find_entry(book, pos, true);
        // assert(entry != nullptr);
        if(entry==nullptr){
            printf("error, entry null\n");
            return false;
        }
        
        if (entry->done){
            // printf("error, why entry done\n");
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, why entry done\n");
            return true;
        }
        entry->done = true;
        
        bool node;
        file >> node;
        
        if (file.eof()) {
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load(): EOF\n");
            // std::exit(EXIT_FAILURE);
            return false;
        }
        
        if (!node) { // leaf
            file >> entry->score;
            // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Book load: score: %d\n", entry->score);
            if (file.eof()) {
                // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "load(): EOF\n");
                // std::exit(EXIT_FAILURE);
                return false;
            }
        } else {
            entry->node = true;
            List list;
            gen_moves(variantType, list, pos);
            list.sort_static();
            
            for (int32_t i = 0; i < list.size(); i++) {
                Move mv = list.move(i);
                Pos new_pos = pos.succ(variantType, mv);
                if(!load(book, variantType, file, new_pos)){
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, why load fail\n");
                    return false;
                }
            }
        }
        return true;
    }
#endif
    
    bool in_book(book::Book* book, const Pos& pos) {
        const book::Entry * entry = find_entry(book, pos);
        return entry != nullptr && entry->node;
    }
    
    Score book_score(book::Book* book, const Pos& pos) {
        book::Entry* entry = find_entry(book, pos);
        // assert(entry != nullptr);
        if(entry==nullptr){
            printf("error, book_score: entry nullptr\n");
            return Score(0);
        }else{
            // printf("correct, bookScore find entry: %d\n", entry->score);
        }
        
        return entry->score;
    }
    
    bool probe(book::Book* book, Variant_Type variantType, const Pos & pos, Score margin, Move & move, Score & score) {
        
        move = move::None;
        score = score::None;
        
        if (!in_book(book, pos)) {
            printf("not in book\n");
            return false;
        }
        
        List list;
        book_gen(book, variantType, list, pos);
        
        book_filter(list, margin);
        if (list.size() == 0) return false;
        
        int32_t i = list::pick(list, 20.0);
        move = list.move(i);
        score = score::make(list.score(i));
        return true;
    }
    
    void book_gen(book::Book* book, Variant_Type variantType, List& list, const Pos& pos) {
        
        gen_moves(variantType, list, pos);
        
        for (int32_t i = 0; i < list.size(); i++) {
            
            Move mv = list.move(i);
            
            Pos new_pos = pos.succ(variantType, mv);
            Score sc = -book_score(book, new_pos);
            
            list.set_score(i, (int) sc);
        }
        
        list.sort();
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////// Convert ////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////

    int32_t Pos::getByteSize()
    {
        int32_t ret = 0;
        {
            // Bit p_piece[Piece_Size];// 8*2
            ret+= 8*2;
            // Bit p_side[Side_Size];// 8*2
            ret+= 8*2;
            // Bit p_all;// 8
            ret+= 8;
            // Side p_turn;// 4
            ret+= 4;
        }
        return ret;
    }

    int32_t Pos::convertToByteArray(struct Pos* pos, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = Pos::getByteSize();
        byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // convert property
            {
                // Bit p_piece[Piece_Size];// 8*2
                {
                    int32_t size = Piece_Size*sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &pos->p_piece, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_piece: %d, %d\n", pointerIndex, length);
                    }
                }
                // Bit p_side[Side_Size];// 8*2
                {
                    int32_t size = Side_Size*sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &pos->p_side, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_side: %d, %d\n", pointerIndex, length);
                    }
                }
                // Bit p_all;// 8
                {
                    int32_t size = sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &pos->p_all, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_all: %d, %d\n", pointerIndex, length);
                    }
                }
                // Side p_turn;// 4
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, &pos->p_turn, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_turn: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // check convert correct
            if(pointerIndex!=length){
                printf("error: convert not correct: %d; %d\n", pointerIndex, length);
            }else{
                // printf("convert byte array correct\n");
            }
        }
        return length;
    }

    int32_t Pos::parseByteArray(struct Pos* pos, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // Bit p_piece[Piece_Size];// 8*2
                {
                    int32_t size = Piece_Size*sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(&pos->p_piece, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_piece: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                    // Bit p_side[Side_Size];// 8*2
                {
                    int32_t size = Side_Size*sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(&pos->p_side, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_side: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // Bit p_all;// 8
                {
                    int32_t size = sizeof(uint64);
                    if(pointerIndex+size<=length){
                        memcpy(&pos->p_all, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_all: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // Side p_turn;// 4
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&pos->p_turn, positionBytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: p_turn: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        {
            if(canCorrect){
                // TODO can hoan thien
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error position parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
}
