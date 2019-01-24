//
//  list.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cmath>

#include "international_draught_bit.hpp"
#include "international_draught_list.hpp"
#include "international_draught_move.hpp"
#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    // functions
    
    List::List() {
        clear();
    }
    
    List::List(const List & list) {
        copy(list);
    }
    
    void List::operator=(const List & list) {
        copy(list);
    }
    
    void List::clear() {
        p_capture_size = 0;
        p_size = 0;
    }
    
    void List::add_move(Square from, Square to) {
        {
            // assert(p_capture_size == 0);
            if(p_capture_size != 0){
                printf("error, assert(p_capture_size == 0)\n");
                p_capture_size = 0;
            }
        }
        Move mv = move::make(from, to);
        add(mv);
    }
    
    void List::add_capture(Square from, Square to, Bit caps) {
        {
            // assert(caps != 0);
            if(caps==0){
                printf("error, assert(caps != 0)\n");
                caps = Bit(1);
            }
        }

        int32_t size = bit::count(caps);
        
        if (size >= p_capture_size) {
            
            Move mv = move::make(from, to, caps);
            
            if (!(size >= 4 && list::has(*this, mv))) { // check for duplicate
                
                if (size > p_capture_size) {
                    p_capture_size = size;
                    p_size = 0;
                }
                
                add(mv);
            }
        }
    }
    
    void List::add(Move mv) {
        {
            // assert(!(list::has(*this, mv)));
            if(list::has(*this, mv)){
                printf("error, assert(!(list::has(*this, mv)))\n");
                return;
            }
        }
        
        {
            // assert(p_size < Size);
            if(p_size>=Size){
                printf("error, assert(p_size < Size)\n");
                return;
            }
        }
        p_move[p_size] = mv;
        // p_score[p_size] = 0;
        p_size++;
    }
    
    void List::copy(const List & list) { // does not copy scores
        
        p_size = list.p_size;
        
        for (int32_t i = 0; i < list.p_size; i++) {
            p_move[i] = list.p_move[i];
        }
    }
    
    void List::mtf(int32_t i) {
        {
            // assert(i >= 0 && i < p_size);
            if(!(i >= 0 && i < p_size)){
                printf("error, assert(i >= 0 && i < p_size)\n");
                i = 0;
            }
        }
        
        Move mv = p_move[i];
        int32_t  sc = p_score[i];
        
        for (int32_t j = i; j > 0; j--) {
            p_move[j]  = p_move[j - 1];
            p_score[j] = p_score[j - 1];
        }
        
        p_move[0]  = mv;
        p_score[0] = sc;
    }
    
    void List::sort() {
        
        // init

        int32_t size = p_size;
        if (size <= 1) return;
        
        p_score[size] = -(1 << 30); // HACK: sentinel
        
        // insert sort (stable)
        
        for (int32_t i = size - 2; i >= 0; i--) {
            
            Move mv = p_move[i];
            int32_t  sc = p_score[i];

            int32_t j;
            
            for (j = i; sc < p_score[j + 1]; j++) {
                p_move[j]  = p_move[j + 1];
                p_score[j] = p_score[j + 1];
            }
            {
                // assert(j < size);
                if(j>=size){
                    printf("error, assert(j < size)\n");
                    j = size - 1;
                }
            }
            
            p_move[j]  = mv;
            p_score[j] = sc;
        }
        
        // debug
        
        /*if (DEBUG) {
            for (int32_t i = 0; i < size - 1; i++) {
                // assert(p_score[i] >= p_score[i + 1]);
                if(p_score[i] < p_score[i + 1]){
                    printf("error, assert(p_score[i] >= p_score[i + 1])\n");
                }
            }
        }*/
    }
    
    void List::sort_static() { // for opening book
        
        // init

        int32_t size = p_size;
        if (size <= 1) return;
        
        // insert sort (stable)
        
        for (int32_t i = size - 2; i >= 0; i--) {
            
            Move mv = p_move[i];
            int32_t  sc = p_score[i];
            uint64 order = move_order(mv);

            int32_t j;
            
            for (j = i; j + 1 < size && order < move_order(p_move[j + 1]); j++) {
                p_move[j]  = p_move[j + 1];
                p_score[j] = p_score[j + 1];
            }
            
            {
                // assert(j < size);
                if(j>=size){
                    printf("error, assert(j < size)\n");
                    j = size - 1;
                }
            }
            
            p_move[j]  = mv;
            p_score[j] = sc;
        }
        
        // debug
        
        /*if (DEBUG) {
            for (int32_t i = 0; i < size - 1; i++) {
                // assert(move_order(p_move[i]) >= move_order(p_move[i + 1]));
                if(move_order(p_move[i]) < move_order(p_move[i + 1])){
                    printf("error, assert(move_order(p_move[i]) >= move_order(p_move[i + 1]))\n");
                }
            }
        }*/
    }
    
    uint64 List::move_order(Move mv) { // for opening book
        
        uint64 from = move::from(mv);
        uint64 to   = move::to(mv);
        uint64 caps = move::captured(mv);
        
        return (from << (64 - 6)) | (to << (64 - 12)) | (caps >> 12);
    }
    
    namespace list {

        int32_t pick(const List & list, double k) {
            {
                // assert(list.size() != 0);
                if(list.size()==0){
                    printf("error, assert(list.size() != 0)\n");
                    return 0;
                }
            }

            int32_t bs = list.score(0);
            
            for (int32_t i = 1; i < list.size(); i++) { // skip 0
                int32_t sc = list.score(i);
                if (sc > bs) bs = sc;
            }

            int32_t index = -1;
            double tot = 0.0;
            
            for (int32_t i = 0; i < list.size(); i++) {
                
                double w = std::exp(double(list.score(i) - bs) / 100.0 * k);
                tot += w;
                
                {
                    // assert(tot > 0.0);
                    if(tot<=0){
                        printf("error, assert(tot > 0.0)\n");
                        tot = 1;
                    }
                }
                if (ml::rand_bool(w / tot)) index = i;
            }
            
            {
                // assert(index >= 0 && index < list.size());
                if(!(index >= 0 && index < list.size())){
                    printf("error, assert(index >= 0 && index < list.size())\n");
                    index = 0;
                }
            }
            return index;
        }
        
        bool has(const List & list, Move mv) {
            for (int32_t i = 0; i < list.size(); i++) {
                if (list.move(i) == mv) return true;
            }
            return false;
        }

        int32_t find(const List & list, Move mv) {
            
            for (int32_t i = 0; i < list.size(); i++) {
                if (list.move(i) == mv) return i;
            }
            
            {
                // assert(false);
                printf("error, assert(false)\n");
                return 0;
            }
            // return -1;
        }
        
    }
}
