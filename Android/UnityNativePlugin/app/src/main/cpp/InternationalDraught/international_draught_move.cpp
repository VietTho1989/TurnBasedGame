//
//  move.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_move.hpp"
#include "international_draught_bit.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_util.hpp"
#include "international_draught_move_gen.hpp"

namespace InternationalDraught
{
    namespace move {
        
        // prototypes
        
        // bo static
        Bit amb(const List & list, Square from, Square to) {
            
            Bit b = bit::Squares;
            
            for (int32_t i = 0; i < list.size(); i++) {
                
                Move mv = list.move(i);
                
                if (move::from(mv) == from && move::to(mv) == to) {
                    b &= captured(mv);
                }
            }
            
            {
                // assert(b != bit::Squares);
                if(b==bit::Squares){
                    printf("error, assert(b != bit::Squares)\n");
                    b = Bit(0);
                }
            }
            return b;
        }
        
        // functions
        
        Move make(Square from, Square to, Bit captured) {
            {
                // assert(bit::is_incl(captured, bit::Inner));
                if(!bit::is_incl(captured, bit::Inner)){
                    printf("error, assert(bit::is_incl(captured, bit::Inner))\n");
                }
            }
            {
                // assert(!bit::has(captured, from));
                if(bit::has(captured, from)){
                    printf("error, assert(!bit::has(captured, from))\n");
                }
            }
            {
                // assert(!bit::has(captured, to));
                if(bit::has(captured, to)){
                    printf("error, assert(!bit::has(captured, to))\n");
                }
            }
            
            return Move((uint64(from) << 6) | (uint64(to) << 0) | (uint64(captured) << 5));
        }
        
        bool is_capture(Move mv, const Pos & /* pos */) {
            return captured(mv) != 0;
        }
        
        bool is_promotion(Move mv, const Pos & pos) {
            return is_man(mv, pos) && square_is_promotion(move::to(mv), pos.turn());
        }
        
        bool is_man(Move mv, const Pos & pos) {
            return bit::has(pos.man(), move::from(mv));
        }
        
        bool is_conversion(Move mv, const Pos & pos) {
            return is_man(mv, pos) || is_capture(mv, pos);
        }
        
        bool is_legal(Variant_Type variantType, Move mv, const Pos & pos) {
            List list;
            gen_moves(variantType, list, pos);
            return list::has(list, mv);
        }
        
        std::string to_string(Variant_Type variantType, Move mv, const Pos & pos) {
            {
                // assert(is_legal(variantType, mv, pos));
                if(!is_legal(variantType, mv, pos)){
                    printf("error, assert(is_legal(variantType, mv, pos))\n");
                }
            }
            
            Square from = move::from(mv);
            Square to   = move::to(mv);
            Bit    caps = captured(mv);
            
            std::string s;
            
            s += square_to_string(from);
            s += (caps != 0) ? "x" : "-";
            s += square_to_string(to);
            
            if (caps != 0) { // capture => test for ambiguity
                
                List list;
                gen_captures(variantType, list, pos);

                int32_t captureCount = 0;
                for (Bit b = caps & ~amb(list, from, to); b != 0; b = bit::rest(b)) {
                    captureCount++;
                    Square sq = bit::first(b);
                    s += "x";
                    s += square_to_string(sq);
                }
                if(captureCount>=1){
                    printf("CaptureCount>=1\n");
                }
            }
            
            return s;
        }
        
        std::string to_hub(Move mv) {
            
            Square from = move::from(mv);
            Square to   = move::to(mv);
            Bit    caps = captured(mv);
            
            std::string s;
            
            s += square_to_string(from);
            s += (caps != 0) ? "x" : "-";
            s += square_to_string(to);
            
            bool haveCaputre = false;
            for (Bit b = caps; b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                s += "x";
                s += square_to_string(sq);
                haveCaputre = true;
            }
            if(haveCaputre){
                printf("haveCapture: %s\n", s.c_str());
            }
            
            return s;
        }
        
        Move from_string(Variant_Type variantType, const std::string & s, const Pos & pos) {
            
            Scanner_Number scan(s);
            std::string token;
            
            token = scan.get_token();
            Square from = square_from_string(token);
            
            token = scan.get_token();
            if (token != "-" && token != "x") {
                // throw Bad_Input();
                printf("error, bad input\n");
            }
            bool is_cap = token == "x";
            
            token = scan.get_token();
            Square to = square_from_string(token);
            
            Bit caps = Bit(0);
            
            while (!scan.eos()) {
                
                token = scan.get_token();
                if (token != "x") {
                    // throw Bad_Input();
                    printf("error, bad input\n");
                }
                
                token = scan.get_token();
                bit::set(caps, square_from_string(token));
            }
            
            if (!is_cap && caps == 0) { // quiet move
                return make(from, to);
            }
            
            // capture => check legality
            
            List list;
            gen_captures(variantType, list, pos);
            
            Move move = None;
            int32_t size = 0;
            
            for (int32_t i = 0; i < list.size(); i++) {
                
                Move mv = list.move(i);
                
                if (move::from(mv) == from && move::to(mv) == to && bit::is_incl(caps, captured(mv))) {
                    move = mv;
                    size++;
                }
            }
            
            if (size > 1) return None; // ambiguous move
            
            return move;
        }
        
        Move from_hub(const std::string & s) {
            
            Scanner_Number scan(s);
            std::string token;
            
            token = scan.get_token();
            Square from = square_from_string(token);
            
            token = scan.get_token();
            if (token != "-" && token != "x") {
                // throw Bad_Input();
                printf("error, bad input\n");
            }
            
            token = scan.get_token();
            Square to = square_from_string(token);
            
            Bit caps = Bit(0);
            
            while (!scan.eos()) {
                
                token = scan.get_token();
                if (token != "x") {
                    // throw Bad_Input();
                    printf("error, bad input\n");
                }
                
                token = scan.get_token();
                bit::set(caps, square_from_string(token));
            }
            
            return make(from, to, caps);
        }
        
    }
}
