//
//  fen.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_fen.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_util.hpp"

namespace InternationalDraught
{
    // bo static
    Side parse_side(Scanner_Number & scan) {
        
        std::string token = scan.get_token();
        
        if (token == "W") {
            return White;
        } else if (token == "B") {
            return Black;
        } else {
            // throw Bad_Input();
            printf("error, bad input\n");
            return White;
        }
    }
    
    // bo static
    void parse_pieces(Bit piece[], Scanner_Number & scan) {
        
        std::string token;
        
        while (true) {
            
            Piece pc = Man;
            
            token = scan.get_token();
            if (token == ",") token = scan.get_token();
            
            if (token == "") { // EOS
                return;
            } else if (token == ":") {
                scan.unget_char(); // HACK: no unget_token
                return;
            } else if (token == "K") {
                pc = King;
                token = scan.get_token();
            }
            
            if (!string_is_square(token)){
                // throw Bad_Input();
                printf("error, bad input\n");
                return;
            }
            int32_t from = std::stoi(token);
            
            token = scan.get_token();
            
            if (token != "-") {
                
                if (token.size() == 1) scan.unget_char(); // HACK: no unget_token
                
                bit::set(piece[pc], square_from_std(from));
                
            } else {
                
                token = scan.get_token();
                
                if (!string_is_square(token)){
                    // throw Bad_Input();
                    printf("error, bad input\n");
                    return;
                }
                int32_t to = std::stoi(token);
                if (to < from) {
                    // throw Bad_Input();
                    printf("error, bad input\n");
                    return;;
                }
                
                for (int32_t sq = from; sq <= to; sq++) {
                    bit::set(piece[pc], square_from_std(sq));
                }
            }
        }
    }
    
    // bo static
    Pos pos_from_pieces(Variant_Type variantType, Side turn, Bit wm, Bit bm, Bit wk, Bit bk) {
        
        if (bit::count(wm | bm | wk | bk) != bit::count(wm) + bit::count(bm) + bit::count(wk) + bit::count(bk)){
            // throw Bad_Input(); // all disjoint?
            printf("error, bad input\n");
        }
        
        if (!bit::is_incl(wm, bit::WM_Squares)) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        if (!bit::is_incl(bm, bit::BM_Squares)) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        
        Bit side[Side_Size] { wm | wk, bm | bk };
        if (side[side_opp(turn)] == 0) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        if (variantType == BT && (side[turn] & (wk | bk)) != 0) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        
        if (bit::count(side[White]) > 20) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        if (bit::count(side[Black]) > 20) {
            // throw Bad_Input();
            printf("error, bad input\n");
        }
        
        return Pos(variantType, turn, wm, bm, wk, bk);
    }
    
    // functions
    
    Pos pos_from_fen(Variant_Type variantType, const std::string & s) {
        
        Scanner_Number scan(s);
        
        Side turn = parse_side(scan);
        
        Bit piece_side[Side_Size][Piece_Size] { { Bit(0), Bit(0) }, { Bit(0), Bit(0) } };
        
        while (!scan.eos()) {
            
            std::string token = scan.get_token();
            if (token != ":"){
                // throw Bad_Input();
                printf("error, bad input\n");
            }
            
            Side sd = parse_side(scan);
            parse_pieces(piece_side[sd], scan);
        }
        
        return pos_from_pieces(variantType, turn, piece_side[White][Man], piece_side[Black][Man], piece_side[White][King], piece_side[Black][King]);
    }
    
    // bo static
    std::string run_string(Piece_Side ps, int32_t from, int32_t to) {
        {
            // assert(ps != Empty);
            if(ps==Empty){
                printf("error, assert(ps != Empty)\n");
                ps = White_Man;
            }
        }
        {
            // assert(1 <= from && from <= to && to <= Dense_Size);
            if(!(1 <= from && from <= to && to <= Dense_Size)){
                printf("error, assert(1 <= from && from <= to && to <= Dense_Size)\n");
                from = 1;
            }
        }
        
        std::string s;
        
        if (piece_side_piece(ps) == King) s += "K";
        
        s += std::to_string(from);
        
        if (to == from) { // length 1
            // no-op
        } else if (to == from + 1) { // length 2
            s += ",";
            if (piece_side_piece(ps) == King) s += "K";
            s += std::to_string(to);
        } else { // length 3+
            s += "-";
            s += std::to_string(to);
        }
        
        return s;
    }
    
    // bo static
    std::string pos_pieces(Pos& pos, Side sd)
    {
        
        std::string s;

        int32_t prev = -1;
        int32_t from = 0;
        int32_t to   = 0;
        
        for (int32_t sq = 1; sq <= Dense_Size; sq++) {
            
            Piece_Side ps = pos::piece_side(pos, square_from_std(sq));
            
            if (ps == prev) {
                
                to++;
                
            } else {
                
                if (prev >= 0) {
                    if (s != "") s += ",";
                    s += run_string(piece_side_make(prev), from, to);
                }
                
                if (ps != Empty && piece_side_side(ps) == sd) {
                    prev = ps;
                    from = sq;
                    to   = sq;
                } else {
                    prev = -1;
                    from = 0;
                    to   = 0;
                }
            }
        }
        
        if (prev >= 0) {
            if (s != "") s += ",";
            s += run_string(piece_side_make(prev), from, to);
        }
        
        return s;
    }
    
    std::string pos_fen(Pos& pos) {
        
        std::string s;
        
        s += (pos.turn() == White) ? "W" : "B";
        s += ":W" + pos_pieces(pos, White);
        s += ":B" + pos_pieces(pos, Black);
        
        return s;
    }
}
