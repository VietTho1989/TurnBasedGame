//
//  list.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_list_hpp
#define international_draught_list_hpp

#include <stdio.h>
#include "international_draught_common.hpp"
#include "international_draught_libmy.hpp"
//#include "international_draught_pos.hpp"

namespace InternationalDraught
{
    // class Pos;
    
    // types
    
    class List {
        
        private :
        
        static const int32_t Size { 128 };

        int32_t p_capture_size;

        int32_t p_size;
        Move p_move[Size];
        int32_t p_score[Size];
        
        public :
        
        List ();
        List (const List & list);
        
        void operator= (const List & list);
        
        void clear       ();
        void add_move    (Square from, Square to);
        void add_capture (Square from, Square to, Bit caps);
        
        void add (Move mv);
        
        void set_size(int32_t size){
            {
                // assert(size <= p_size);
                if(size>p_size){
                    printf("error, assert(size <= p_size)\n");
                    size = p_size;
                }
            }
            p_size = size;
        }
        
        void set_score(int32_t i, int32_t sc){
            {
                // assert(i >= 0 && i < p_size);
                if(!(i >= 0 && i < p_size)){
                    printf("error, assert(i >= 0 && i < p_size)\n");
                    i = 0;
                }
            }
            p_score[i] = sc;
        }
        
        void mtf         (int32_t i); // move to front
        void sort        ();
        void sort_static ();

        int32_t  size  ()      const { return p_size; }
        
        Move move(int32_t i) const {
            {
                // assert(i >= 0 && i < p_size);
                if(!(i >= 0 && i < p_size)){
                    printf("error, assert(i >= 0 && i < p_size)\n");
                    i = 0;
                }
            }
            return p_move[i];
        }

        int32_t  score (int32_t i) const {
            {
                // assert(i >= 0 && i < p_size);
                if(!(i >= 0 && i < p_size)){
                    printf("error, assert(i >= 0 && i < p_size)\n");
                    i = 0;
                }
            }
            return p_score[i];
        }
        
        Move operator[] (int32_t i) const { return move(i); }
        
    private :
        // bo static
        uint64 move_order (Move mv);
        
        void copy (const List & list);
    };
    
    // functions
    
    namespace list {

        int32_t  pick (const List & list, double k);
        
        bool has        (const List & list, Move mv);
        int32_t  find       (const List & list, Move mv);
        
    }
}

#endif /* list_hpp */
