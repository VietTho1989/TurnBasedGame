//
//  sort.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "international_draught_sort.hpp"
#include "international_draught_list.hpp"
#include "international_draught_move.hpp"

namespace InternationalDraught
{
    // constants
    
    const int32_t Prob_Bit   { 12 };
    const int32_t Prob_One   { 1 << Prob_Bit };
    const int32_t Prob_Half  { 1 << (Prob_Bit - 1) };
    const int32_t Prob_Shift { 5 }; // smaller => more adaptive
    
    // variables
    
    static int32_t G_Hist[Move_Index_Size];
    
    // functions
    
    void sort_clear() {
        
        for (int32_t index = 0; index < Move_Index_Size; index++) {
            G_Hist[index] = Prob_Half;
        }
    }
    
    void good_move(Move_Index index) {
        {
            // assert(index != Move_Index_None);
            if(index == Move_Index_None){
                printf("error, assert(index != Move_Index_None)\n");
                index = (Move_Index)1;
            }
        }
        G_Hist[index] += (Prob_One - G_Hist[index]) >> Prob_Shift;
    }
    
    void bad_move(Move_Index index) {
        {
            // assert(index != Move_Index_None);
            if(index == Move_Index_None){
                printf("error, assert(index != Move_Index_None)\n");
                index = Move_Index(1);
            }
        }
        G_Hist[index] -= G_Hist[index] >> Prob_Shift;
    }
    
    void sort_all(List & list, const Pos & pos, Move_Index tt_move) {
        
        if (list.size() <= 1) return;
        
        for (int32_t i = 0; i < list.size(); i++) {
            
            Move mv = list.move(i);
            Move_Index index = move::index(mv, pos);

            int32_t sc;
            
            if (index == tt_move) {
                sc = (1 << 15) - 1;
            } else {
                sc = G_Hist[index];
                {
                    // assert(sc < (1 << 12));
                    if(sc>=(1 << 12)){
                        printf("error, assert(sc < (1 << 12))\n");
                        sc = (1 << 12) - 1;
                    }
                }
            }
            
            {
                // assert(sc >= 0 && sc < (1 << 15));
                if(!(sc >= 0 && sc < (1 << 15))){
                    printf("error, assert(sc >= 0 && sc < (1 << 15))\n");
                    sc = 0;
                }
            }
            list.set_score(i, sc);
        }
        
        list.sort();
    }
}
