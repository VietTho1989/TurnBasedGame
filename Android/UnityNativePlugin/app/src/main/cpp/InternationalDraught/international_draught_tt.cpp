//
//  tt.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_tt.hpp"
#include "international_draught_score.hpp"
#include "international_draught_hash.hpp"

namespace InternationalDraught
{
    namespace tt {
        
        // constants
        
        const int32_t Cluster_Size { 4 };
        
        // functions
        
        void TT::set_size(int32_t size) {
            {
                // assert(ml::is_power_2(size));
                if(!ml::is_power_2(size)){
                    printf("error, assert(ml::is_power_2(size))\n");
                    size = 1 << 22;
                }
            }
            
            p_size = size;
            p_mask = (size - 1) & -Cluster_Size;
            
            p_table.resize(p_size);
            
            clear();
        }
        
        void TT::clear() {
            {
                // assert(sizeof(Entry) == 16);
                if(sizeof(Entry) != 16){
                    printf("error, assert(sizeof(Entry) == 16)\n");
                }
            }
            
            Entry entry { 0, 0, 0, 0, 0, 0, 0, 0 };
            
            for (int32_t i = 0; i < p_size; i++) {
                p_table[i] = entry;
            }
            
            set_date(0);
        }
        
        void TT::inc_date() {
            set_date((p_date + 1) % Date_Size);
        }
        
        void TT::set_date(int32_t date) {
            {
                // assert(date >= 0 && date < Date_Size);
                if(!(date >= 0 && date < Date_Size)){
                    printf("error, assert(date >= 0 && date < Date_Size)\n");
                    date = 0;
                }
            }
            
            p_date = date;
            
            for (date = 0; date < Date_Size; date++) {
                p_age[date] = age(date);
            }
        }

        int32_t TT::age(int32_t date) const {
            {
                // assert(date >= 0 && date < Date_Size);
                if(!(date >= 0 && date < Date_Size)){
                    printf("error, assert(date >= 0 && date < Date_Size)\n");
                    date = 0;
                }
            }

            int32_t age = p_date - date;
            if (age < 0) age += Date_Size;
            
            {
                // assert(age >= 0 && age < Date_Size);
                if(!(age >= 0 && age < Date_Size)){
                    printf("error, assert(age >= 0 && age < Date_Size)\n");
                    age = 0;
                }
            }
            return age;
        }
        
        void TT::store(Key key, Move_Index move, Depth depth, Flags flags, Score score) {
            
            // assert(move >= 0 && move < (1 << 16));
            {
                // assert(depth >= 0 && depth < (1 << 8));
                if(!(depth >= 0 && depth < (1 << 8))){
                    printf("error, assert(depth >= 0 && depth < (1 << 8))\n");
                    return;
                }
            }
            {
                // assert((int(flags) & ~int(Flags_Mask)) == 0);
                if((int(flags) & ~int(Flags_Mask)) != 0){
                    printf("error, assert((int(flags) & ~int(Flags_Mask)) == 0)\n");
                    return;
                }
            }
            {
                // assert(score > -(1 << 15) && score < +(1 << 15));
                if(!(score > -(1 << 15) && score < +(1 << 15))){
                    printf("error, assert(score > -(1 << 15) && score < +(1 << 15))\n");
                    return;
                }
            }
            {
                // assert(score != score::None);
                if(score == score::None){
                    printf("error, assert(score != score::None)\n");
                }
            }
            
            // probe

            int32_t    index = hash::index(key, p_mask);
            uint32 lock  = hash::lock(key);
            
            Entry * be = nullptr;
            int32_t bs = -256;
            
            for (int32_t i = 0; i < Cluster_Size; i++) {
                {
                    // assert(index + i < p_size);
                    if(index + i >= p_size){
                        printf("error, assert(index + i < p_size)\n");
                        return;
                    }
                }
                Entry & entry = p_table[index + i];
                
                if (entry.lock == lock) { // hash hit
                    
                    if (entry.depth <= depth) {
                        {
                            // assert(entry.lock == lock);
                            if(entry.lock!=lock){
                                printf("error, assert(entry.lock == lock)\n");
                                return;
                            }
                        }
                        if (move != Move_Index_None) entry.move = move;
                        entry.depth = depth;
                        entry.date = p_date;
                        entry.flags = int(flags);
                        entry.score = score;
                        
                    } else { // deeper entry
                        
                        entry.date = p_date;
                    }
                    
                    return;
                }
                
                // evaluate replacement score

                int32_t sc = 0;
                sc = sc * Date_Size + p_age[entry.date];
                sc = sc * 256 - entry.depth;
                {
                    // assert(sc > -256);
                    if(sc<=-256){
                        printf("error, assert(sc > -256)\n");
                        return;
                    }
                }
                
                if (sc > bs) {
                    be = &entry;
                    bs = sc;
                }
            }
            
            // "best" entry found
            
            {
                // assert(be != nullptr);
                if(be==nullptr){
                    printf("error, assert(be != nullptr)\n");
                    return;
                }
            }
            Entry & entry = *be;
            // assert(entry.lock != lock); // triggers in SMP
            
            // store
            
            entry.lock = lock;
            entry.move = move;
            entry.depth = depth;
            entry.date = p_date;
            entry.flags = int(flags);
            entry.score = score;
        }
        
        bool TT::probe(Key key, Move_Index & move, Depth & depth, Flags & flags, Score & score) {
            
            // init
            
            // probe

            int32_t    index = hash::index(key, p_mask);
            uint32 lock  = hash::lock(key);
            
            for (int32_t i = 0; i < Cluster_Size; i++) {
                {
                    // assert(index + i < p_size);
                    if(index + i >= p_size){
                        printf("error, assert(index + i < p_size)\n");
                        return false;
                    }
                }
                const Entry & entry = p_table[index + i];
                
                if (entry.lock == lock) {
                    
                    // found
                    
                    move = Move_Index(entry.move);
                    depth = Depth(entry.depth);
                    flags = Flags(entry.flags);
                    score = Score(entry.score);
                    
                    return true;
                }
            }
            
            // not found
            
            return false;
        }
        
    }
}
