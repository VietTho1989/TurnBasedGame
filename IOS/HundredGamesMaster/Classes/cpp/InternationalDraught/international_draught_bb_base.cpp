//
//  bb_base.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_bb_base.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_move_gen.hpp"

namespace InternationalDraught
{
    namespace bb
    {
        // constants
        
        const int32_t Value_Size { 4 };
        
        // "constants"
        
        const int32_t Order[Value_Size] { 2, 0, 3, 1 }; // DLWU -> LUDW
        
        
        bool is_load(var::Var* myVar, int32_t size)
        {
            return myVar->BB && size <= myVar->BB_Size;
        }
        
        bool pos_is_load(var::Var* myVar, const Pos& pos) {
            return is_load(myVar, pos::size(pos));
        }
        
        bool pos_is_search(struct var::Var* myVar, const Pos & pos, int32_t bb_size) {
            return pos::size(pos) <= bb_size && pos_is_load(myVar, pos);
        }
        
        Value probe(struct var::Var* myVar, const Pos& pos) {
            // printf("probe\n");
            if (pos::is_wipe(myVar, pos)) {
                return Loss; // for BT variant
            }
            
            List list;
            gen_captures(myVar->Variant, list, pos);
            
            if (list.size() == 0) { // quiet position
                // printf("prob: probe_raw\n");
                return probe_raw(myVar, pos);
                
            } else { // capture position
                
                Value node = Loss;
                
                for (int32_t i = 0; i < list.size(); i++) {
                    
                    Move mv = list.move(i);
                    
                    Pos new_pos = pos.succ(myVar->Variant, mv);
                    
                    Value child = probe(myVar, new_pos);
                    
                    node = value_update(node, child);
                    if (node == Win) break;
                }
                
                return node;
            }
        }
        
        Value probe_raw(struct var::Var* myVar, const Pos & pos) {
            
            // assert(!pos::is_capture(pos));
            if(is_capture(pos)){
                printf("error, assert(!pos::is_capture(pos))\n");
                return Draw;
            }
            
            ID id = pos_id(pos);
            {
                // assert(!id_is_illegal(myVar->Variant, id));
                if(id_is_illegal(myVar->Variant, id)){
                    printf("error, assert(!id_is_illegal(myVar->Variant, id))\n");
                    return Draw;
                }
            }
            if (id_is_loss(myVar->Variant, id)) return Loss;
            
            Base& base = myVar->myBase->G_Base[id];
            Index index = pos_index(id, pos);
            
            Value value = base.get(index);
            // assert(value != Unknown);
            if(value == Unknown){
                printf("error, assert(value != Unknown)\n");
                return Draw;
            }
            
            return value;
        }
        
        Value value_update(Value node, Value child) {
            return value_max(node, value_age(child));
        }
        
        Value value_age(Value val) {
            
            if (val == Win) {
                return Loss;
            } else if (val == Loss) {
                return Win;
            } else {
                return val;
            }
        }
        
        Value value_max(Value v0, Value v1) {
            // assert(v0 != Win);
            if(v0==Win){
                printf("error, assert(v0 != Win)\n");
                v0 = Draw;
            }
            return (Order[v1] > Order[v0]) ? v1 : v0;
        }
        
        std::string value_to_string(Value val) {
            
            switch (val) {
                case Win  : return "win";
                case Loss : return "loss";
                case Draw : return "draw";
                default   : return "unknown";
            }
        }
    }
}
