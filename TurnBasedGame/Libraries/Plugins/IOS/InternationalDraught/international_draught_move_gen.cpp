//
//  move_gen.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_move_gen.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    // bo static
    Bit contact_captures(const Pos & pos, Side sd) {
        
        Bit ba = pos.side(sd);
        Bit bd = pos.side(side_opp(sd));
        Bit be = pos.empty();
        
        return ba & (((bd << J1) & (be << J2)) | ((bd << I1) & (be << I2))
                     | ((bd >> I1) & (be >> I2)) | ((bd >> J1) & (be >> J2)));
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////// add_man_captures /////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void add_man_captures_rec(List & list, Bit bd, Bit be, Square start, Square jump, Square from, Bit caps) {
        {
            // assert(bit::has(be, from));
            if(!(bit::has(be, from))){
                printf("error, assert(bit::has(be, from))\n");
                return;
            }
        }
        
        bd = bit::remove(bd, jump);
        caps = bit::add(caps, jump);
        
        for (Bit b = bit::man_attack(from) & bd; b != 0; b = bit::rest(b)) {
            
            Square sq = bit::first(b);
            Square to = square_make(sq * 2 - from); // square behind sq
            
            if (bit::has(be, to)) {
                add_man_captures_rec(list, bd, be, start, sq, to, caps);
            }
        }
        
        list.add_capture(start, from, caps);
    }
    
    // bo static
    void add_man_captures(List & list, Bit bd, Bit be, Square from, Inc inc) {
        Square sq = square_make(from + inc);
        add_man_captures_rec(list, bd, bit::add(be, from), from, sq, square_make(sq + inc), Bit(0));
    }
    
    // bo static
    void add_man_captures(List & list, const Pos & pos, Bit bd, Bit be, Bit froms) {
        
        for (Bit b = froms & (bd << J1) & (be << J2); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_man_captures(list, bd, be, from, -J1);
        }
        
        for (Bit b = froms & (bd << I1) & (be << I2); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_man_captures(list, bd, be, from, -I1);
        }
        
        for (Bit b = froms & (bd >> I1) & (be >> I2); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_man_captures(list, bd, be, from, +I1);
        }
        
        for (Bit b = froms & (bd >> J1) & (be >> J2); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_man_captures(list, bd, be, from, +J1);
        }
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////// add_king_captures /////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void add_king_captures_rec(Variant_Type variant, List & list, const Pos & pos, Bit bd, Bit be, Square start, Square jump, Inc inc, Bit caps) {
        
        Square next = square_make(jump + inc);
        {
            // assert(bit::has(be, next));
            if(!bit::has(be, next)){
                printf("error, assert(bit::has(be, next))\n");
            }
        }
        
        bd = bit::remove(bd, jump);
        caps = bit::add(caps, jump);
        
        Bit ray = bit::beyond(square_make(jump - inc), jump); // ray(jump, inc)
        Bit froms = bit::attack(jump, ray, be);
        
        for (Bit bf = froms & be; bf != 0; bf = bit::rest(bf)) {
            
            Square from = bit::first(bf);
            
            for (Bit b = bit::king_attack(from) & bd; b != 0; b = bit::rest(b)) {
                
                Square sq = bit::first(b);
                
                if (bit::is_incl(bit::capture_mask(from, sq), be)) {
                    
                    Inc new_inc = bit::line_inc(from, sq);
                    {
                        // assert(new_inc != -inc);
                        if(new_inc == -inc){
                            printf("error, assert(new_inc != -inc)\n");
                            return;
                        }
                    }
                    if (new_inc == +inc && from != next) { // duplicate capture
                        continue;
                    }
                    
                    add_king_captures_rec(variant, list, pos, bd, be, start, sq, new_inc, caps);
                }
            }
            
            bool cond = variant == Killer && pos.is_piece(jump, King) && from != next;
            if (!cond) list.add_capture(start, from, caps);
        }
    }
    
    // bo static
    void add_king_captures(Variant_Type variantType, List& list, const Pos & pos, Bit bd, Bit be, Square from) {
        
        be = bit::add(be, from);
        
        for (Bit b = bit::king_attack(from) & bd; b != 0; b = bit::rest(b)) {
            
            Square sq = bit::first(b);
            
            if (bit::is_incl(bit::capture_mask(from, sq), be)) {
                Inc inc = bit::line_inc(from, sq);
                add_king_captures_rec(variantType, list, pos, bd, be, from, sq, inc, Bit(0));
            }
        }
    }
    
    void gen_captures(Variant_Type variantType, List& list, const Pos & pos) {
        
        list.clear();
        
        Side atk = pos.turn();
        Side def = side_opp(atk);
        
        Bit bd = pos.side(def) & bit::Inner;
        Bit be = pos.empty();
        
        // men
        
        add_man_captures(list, pos, bd, be, pos.man(atk));
        
        // kings
        
        for (Bit b = pos.king(atk); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_king_captures(variantType, list, pos, bd, be, from);
        }
        // printf("gen_captures: %d\n", list.size());
    }
    
    // bo static
    void add_moves_to(List & list, Bit tos, Inc inc) {
        
        for (Bit b = tos; b != 0; b = bit::rest(b)) {
            Square to = bit::first(b);
            list.add_move(square_make(to - inc), to);
        }
    }
    
    void add_sacs(List & list, const Pos & pos) {
        
        // list.clear();
        
        Side atk = pos.turn();
        Side def = side_opp(atk);
        
        Bit mp = pos.man(atk);
        Bit op = pos.side(def);
        Bit e  = pos.empty();
        
        if (pos.turn() == White) {
            
            // init
            
            uint64 strong = ((bit::file(1)             | bit::rank(Line_Size - 2) | (mp >> I2)) & (mp >> I1) & (e << I1))
            | ((bit::file(Line_Size - 2) | bit::rank(Line_Size - 2) | (mp >> J2)) & (mp >> J1) & (e << J1));
            
            uint64 weak = ((mp << J1) & (e << J2)) | ((mp << I1) & (e << I2))
            | ((mp >> I1) & (e >> I2)) | ((mp >> J1) & (e >> J2));
            
            uint64 target = strong & ~weak;
            
            uint64 pin = ((mp << J1) & (op << J2)) | ((mp << I1) & (op << I2))
            | ((mp >> I1) & (op >> I2)) | ((mp >> J1) & (op >> J2));
            
            uint64 danger_i = ((op << I1) & (e >> I1)) | ((op >> I1) & (e << I1));
            uint64 danger_j = ((op << J1) & (e >> J1)) | ((op >> J1) & (e << J1));
            
            uint64 wi = 0;
            uint64 wj = 0;
            
            // exchange
            
            wi |= (target >> I1) & (op << I1) & ~danger_j;
            wj |= (target >> J1) & (op << J1) & ~danger_i;
            
            wi |= ~(op << I1) & (op << J1) & ((e & target) >> J1);
            wj |= ~(op << J1) & (op << I1) & ((e & target) >> I1);
            
            wi |= ~(op << I1) & (op >> J1) & ((e & target) << J1);
            wj |= ~(op << J1) & (op >> I1) & ((e & target) << I1);
            
            // create opponent hole
            
            uint64 opp_weak = ((op << I1) & (e  << I2)) | ((op << J1) & (e  << J2));
            uint64 opp_pin  = ((op >> I1) & (mp >> I2)) | ((op >> J1) & (mp >> J2));
            
            Bit opp_target = op & opp_weak & opp_pin;
            
            wi |= ((mp & ~weak) >> I1) & (opp_target << I1) & ~danger_j;
            wj |= ((mp & ~weak) >> J1) & (opp_target << J1) & ~danger_i;
            
            // wrap up
            
            wi &= ((mp & ~pin) >> I1) & e;
            wj &= ((mp & ~pin) >> J1) & e;
            
            add_moves_to(list, Bit(wi), -I1);
            add_moves_to(list, Bit(wj), -J1);
            
        } else { // Black
            
            // init
            
            uint64 strong = ((bit::file(1)             | bit::rank(1) | (mp << J2)) & (mp << J1) & (e >> J1))
            | ((bit::file(Line_Size - 2) | bit::rank(1) | (mp << I2)) & (mp << I1) & (e >> I1));
            
            uint64 weak = ((mp << J1) & (e << J2)) | ((mp << I1) & (e << I2))
            | ((mp >> I1) & (e >> I2)) | ((mp >> J1) & (e >> J2));
            
            uint64 pin = ((mp << J1) & (op << J2)) | ((mp << I1) & (op << I2))
            | ((mp >> I1) & (op >> I2)) | ((mp >> J1) & (op >> J2));
            
            uint64 danger_i = ((op >> I1) & (e << I1)) | ((op << I1) & (e >> I1));
            uint64 danger_j = ((op >> J1) & (e << J1)) | ((op << J1) & (e >> J1));
            
            uint64 bi = 0;
            uint64 bj = 0;
            
            // exchange
            
            uint64 target = strong & ~weak;
            
            bi |= (target << I1) & (op >> I1) & ~danger_j;
            bj |= (target << J1) & (op >> J1) & ~danger_i;
            
            bi |= ~(op >> I1) & (op >> J1) & ((e & target) << J1);
            bj |= ~(op >> J1) & (op >> I1) & ((e & target) << I1);
            
            bi |= ~(op >> I1) & (op << J1) & ((e & target) >> J1);
            bj |= ~(op >> J1) & (op << I1) & ((e & target) >> I1);
            
            // create opponent hole
            
            uint64 opp_weak = ((op >> I1) & (e  >> I2)) | ((op >> J1) & (e  >> J2));
            uint64 opp_pin  = ((op << I1) & (mp << I2)) | ((op << J1) & (mp << J2));
            
            Bit opp_target = op & opp_weak & opp_pin;
            
            bi |= ((mp & ~weak) << I1) & (opp_target >> I1) & ~danger_j;
            bj |= ((mp & ~weak) << J1) & (opp_target >> J1) & ~danger_i;
            
            // wrap up
            
            bi &= ((mp & ~pin) << I1) & e;
            bj &= ((mp & ~pin) << J1) & e;
            
            add_moves_to(list, Bit(bi), +I1);
            add_moves_to(list, Bit(bj), +J1);
        }
    }
    
    bool can_move(const Pos & pos, Side sd) {
        
        Bit be = pos.empty();
        
        // man moves
        
        Bit bm = pos.man(sd);
        
        if (sd == White) {
            bm &= (be << I1) | (be << J1);
        } else {
            bm &= (be >> I1) | (be >> J1);
        }
        
        if (bm != 0) return true;
        
        // contact captures
        
        if (contact_captures(pos, sd) != 0) return true;
        
        // king moves
        
        for (Bit b = pos.king(sd); b != 0; b = bit::rest(b)) {
            
            Square from = bit::first(b);
            
            Bit moves = bit::man_attack(from) & be; // single step
            if (moves != 0) return true;
        }
        
        return false;
    }
    
    // bo static
    bool king_can_capture(const Pos & pos, Square from, Side def) {
        
        Bit bd = pos.side(def) & bit::Inner;
        Bit be = pos.empty();
        
        for (Bit b = bit::king_attack(from) & bd; b != 0; b = bit::rest(b)) {
            
            Square sq = bit::first(b);
            
            if (bit::is_incl(bit::capture_mask(from, sq), be)) {
                return true;
            }
        }
        
        return false;
    }
    
    bool can_capture(const Pos & pos, Side sd) {
        
        Side atk = sd;
        Side def = side_opp(atk);
        
        // men
        
        if (contact_captures(pos, atk) != 0) return true;
        
        // kings
        
        for (Bit b = pos.king(atk); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            if (king_can_capture(pos, from, def)) return true;
        }
        
        return false;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////// gen_moves /////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////
    
    // bo static
    void add_moves_from(List & list, Bit froms, Inc inc) {
        
        for (Bit b = froms; b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            list.add_move(from, square_make(from + inc));
        }
    }
    
    // bo static
    void add_man_moves(List & list, const Pos & pos, Bit froms) {
        
        Side atk = pos.turn();
        
        Bit be = pos.empty();
        
        if (atk == White) {
            add_moves_from(list, froms & (be << I1), -I1);
            add_moves_from(list, froms & (be << J1), -J1);
        } else {
            add_moves_from(list, froms & (be >> I1), +I1);
            add_moves_from(list, froms & (be >> J1), +J1);
        }
    }
    
    // bo static
    void add_king_moves(List & list, const Pos & pos, Square from) {
        
        Bit be = pos.empty();
        
        for (Bit b = bit::king_attack(from, be) & be; b != 0; b = bit::rest(b)) {
            Square to = bit::first(b);
            list.add_move(from, to);
        }
    }
    
    void gen_promotions(List & list, const Pos & pos) {
        
        list.clear();
        
        Side atk = pos.turn();
        
        add_man_moves(list, pos, pos.man(atk) & bit::rank(Line_Size - 2, atk));
    }
    
    // bo static
    void gen_quiets(List & list, const Pos & pos) {
        
        list.clear();
        
        Side atk = pos.turn();
        
        // men
        
        add_man_moves(list, pos, pos.man(atk));
        
        // kings
        
        for (Bit b = pos.king(atk); b != 0; b = bit::rest(b)) {
            Square from = bit::first(b);
            add_king_moves(list, pos, from);
        }
    }
    
    void gen_moves(Variant_Type variantType, List & list, const Pos & pos) {
        gen_captures(variantType, list, pos);
        if (list.size() == 0) gen_quiets(list, pos);
    }
}
