//
//  search.hpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef international_draught_search_hpp
#define international_draught_search_hpp

#include <stdio.h>
#include <string>

#include "international_draught_libmy.hpp"
#include "international_draught_common.hpp"
#include "international_draught_move.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_util.hpp"
#include "international_draught_score.hpp"
#include "international_draught_tt.hpp"
#include "international_draught_thread.hpp"
#include "international_draught_var.hpp"

namespace InternationalDraught
{
    
    // constants
    
    const Depth Depth_Max { Depth(99) };
    
    const Ply Ply_Max  { Ply(99) };
    const int32_t Ply_Size { Ply_Max + 1 };
    
    // types
    
    enum Output_Type { Output_None, Output_Terminal, Output_Hub };
    
    class Line {
        
        private :
        
        ml::Array<Move, Ply_Size> p_move;
        
        public :
        
        Line () { clear(); }
        
        void clear () { p_move.clear(); }
        
        void add(Move mv) {
            {
                // assert(mv != move::None);
                if(mv == move::None){
                    printf("error, assert(mv != move::None)\n");
                }
            }
            p_move.add(mv);
        }
        
        void set    (Move mv);
        void concat (Move mv, const Line & pv);

        int32_t  size ()      const { return p_move.size(); }
        Move move (int32_t i) const { return p_move[i]; }
        
        Move operator[] (int32_t i) const { return move(i); }
        
        std::string to_string (var::Var* myVar, const Pos & pos, int32_t size_max = 0) const;
        std::string to_hub    () const;
    };
    
    class Search_Input {
        
        public :
        
        bool move;
        bool book;
        Depth depth;
        bool input;
        Output_Type output;
        bool ponder;
        
        private :
        
        bool p_smart;
        int32_t p_moves;
        double p_time;
        double p_inc;
        
        public :
        
        Search_Input () { init(); }
        
        void init ();
        
        void set_time (double time);
        void set_time (int32_t moves, double time, double inc);
        
        bool   smart  () const { return p_smart; }
        int32_t    moves  () const { return p_moves; }
        double time   () const { return p_time; }
        double inc    () const { return p_inc; }
    };
    
    struct Search;
    
    class Search_Output {
        
        public :
        
        Move move;
        Move answer;
        Score score;
        Depth depth;
        Line pv;
        
        int64 node;
        int64 leaf;
        int64 ply_sum;
        
        private :
        
        const Search_Input * p_si;
        Pos p_pos;
        Timer p_timer;
        
        public :
        
        void init (const Search_Input & si, const Pos & pos);
        void end  ();
        
        void new_best_move(Search* mySearch, Move mv, Score sc = score::None);
        void new_best_move(Search* mySearch, Move mv, Score sc, Depth depth, const Line & pv);
        void disp_best_move(Search* mySearch);
        
        double ply_avg () const { return (leaf == 0) ? 0.0 : double(ply_sum) / double(leaf); }
        double time    () const { return p_timer.elapsed(); }
    };
    
    // functions
    
    struct SMP : public Lockable {
        std::atomic<bool> busy;
    };
    
    class Time {
        
    private:
        
        double p_time_0; // target
        double p_time_1; // extended
        double p_time_2; // maximum
        
    public:
        
        void init (var::Var* myVar, const Search_Input & si, const Pos & pos);
        
        double time_0 () const { return p_time_0; }
        double time_1 () const { return p_time_1; }
        double time_2 () const { return p_time_2; }
        
    private:
        
        void init (double time);
        void init (var::Var* myVar, int32_t moves, double time, double inc, const Pos & pos);
    };
    
    struct Search
    {
        tt::TT g_TT;
        
        Time g_Time; // TODO: move to SG
        
        SMP g_SMP; // lock to create and broadcast split points // MOVE ME to SG?
        Lockable g_IO;
        
        struct var::Var* myVar;
        
    public:
        void search (Search_Output& so, Node& node, const Search_Input& si);
        Move  quick_move(const Pos& pos);
        Score quick_score(const Pos& pos);
    };
}

#endif /* search_hpp */
