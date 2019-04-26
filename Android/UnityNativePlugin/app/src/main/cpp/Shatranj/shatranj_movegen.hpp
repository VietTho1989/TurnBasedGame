//
//  movegen.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_movegen_hpp
#define shatranj_movegen_hpp

#include <stdio.h>
#include <algorithm>

#include "shatranj_types.hpp"

namespace Shatranj
{
    class Position;
    
    enum GenType {
        CAPTURES,
        QUIETS,
        QUIET_CHECKS,
        EVASIONS,
        NON_EVASIONS,
        LEGAL
    };
    
    struct ExtMove {
        Move move;
        int32_t value;
        
        operator Move() const { return move; }
        void operator=(Move m) { move = m; }
        
        // Inhibit unwanted implicit conversions to Move
        // with an ambiguity that yields to a compile error.
        operator float() const;
    };
    
    inline bool operator<(const ExtMove& f, const ExtMove& s) {
        return f.value < s.value;
    }
    
    template<GenType> ExtMove* generate(const Position& pos, ExtMove* moveList);
    
    /// The MoveList struct is a simple wrapper around generate(). It sometimes comes
    /// in handy to use this class instead of the low level generate() function.
    template<GenType T> struct MoveList {
        
        explicit MoveList(const Position& pos) : last(generate<T>(pos, moveList)) {}
        const ExtMove* begin() const { return moveList; }
        const ExtMove* end() const { return last; }
        size_t size() const { return last - moveList; }
        bool contains(Move move) const {
            return std::find(begin(), end(), move) != end();
        }
        
    private:
        ExtMove moveList[MAX_MOVES], *last;
    };
}

#endif /* movegen_hpp */
