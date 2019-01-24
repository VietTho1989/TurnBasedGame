//
//  uci.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_uci.hpp"
#include <cassert>
#include <iostream>
#include <sstream>
#include <string>

#include "shatranj_evaluate.hpp"
#include "shatranj_movegen.hpp"
#include "shatranj_position.hpp"
#include "shatranj_search.hpp"
#include "shatranj_thread.hpp"
#include "shatranj_tt.hpp"
#include "shatranj_timeman.hpp"
#include "shatranj_tbprobe.hpp"

using namespace std;

namespace Shatranj
{
    extern vector<string> setup_bench(const Position&, istream&);
    
    // FEN string of the initial position, normal chess
    const char* StartFEN = "rnbkqbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBKQBNR w 0 1";
    
    /// UCI::value() converts a Value to a string suitable for use with the UCI
    /// protocol specification:
    ///
    /// cp <x>    The score from the engine's point of view in centipawns.
    /// mate <y>  Mate in y moves, not plies. If the engine is getting mated
    ///           use negative values for y.
    
    string UCI::value(Value v) {
        
        // assert(-VALUE_INFINITE < v && v < VALUE_INFINITE);
        if(!(-VALUE_INFINITE < v && v < VALUE_INFINITE)){
            printf("error, assert(-VALUE_INFINITE < v && v < VALUE_INFINITE)\n");
        }
        
        stringstream ss;
        
        if (abs(v) < VALUE_MATE - MAX_PLY)
            ss << "cp " << v * 100 / PawnValueEg;
        else
            ss << "mate " << (v > 0 ? VALUE_MATE - v + 1 : -VALUE_MATE - v) / 2;
        
        return ss.str();
    }
    
    
    /// UCI::square() converts a Square to a string in algebraic notation (g1, a7, etc.)
    
    void UCI::square(char* ret, Square s)
    {
        ret[0] = 0;
        sprintf(ret, "%s%c%c", ret, 'a' + file_of(s), '1' + rank_of(s));
    }
    
    std::string UCI::square(Square s)
    {
        return std::string{ char('a' + file_of(s)), char('1' + rank_of(s)) };
    }
    
    /// UCI::move() converts a Move to a string in coordinate notation (g1f3, a7a8q).
    
    void UCI::move(char* ret, Move m)
    {
        ret[0] = 0;
        Square from = from_sq(m);
        Square to = to_sq(m);
        
        if (m == MOVE_NONE){
            strcpy(ret, "(none)");
            return;
        }
        if (m == MOVE_NULL){
            strcpy(ret, "0000");
            return;
        }
        {
            // from
            {
                char strFrom[10];
                UCI::square(strFrom, from);
                sprintf(ret, "%s%s",ret, strFrom);
            }
            // to
            {
                char strTo[10];
                UCI::square(strTo, to);
                sprintf(ret, "%s%s",ret, strTo);
            }
        }
        if (type_of(m) == PROMOTION) {
            // move += " pnbrqk"[promotion_type(m)];
            sprintf(ret, "%s%c", ret, " pnbrqk"[promotion_type(m)]);
        }
    }
    
    string UCI::move(Move m) {
        
        Square from = from_sq(m);
        Square to = to_sq(m);
        
        if (m == MOVE_NONE)
            return "(none)";
        
        if (m == MOVE_NULL)
            return "0000";
        
        string move = UCI::square(from) + UCI::square(to);
        
        if (type_of(m) == PROMOTION)
            move += " pbqnrk"[promotion_type(m)];
        
        return move;
    }
    
    
    /// UCI::to_move() converts a string representing a move in coordinate notation
    /// (g1f3, a7a8q) to the corresponding legal Move, if any.
    
    Move UCI::to_move(const Position& pos, string& str) {
        
        if (str.length() == 5) // Junior could send promotion piece in uppercase
            str[4] = char(tolower(str[4]));
        
        for (const auto& m : MoveList<LEGAL>(pos))
            if (str == UCI::move(m))
                return m;
        
        return MOVE_NONE;
    }
}
