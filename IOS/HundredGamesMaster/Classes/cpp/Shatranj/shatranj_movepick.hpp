//
//  movepick.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_movepick_hpp
#define shatranj_movepick_hpp

#include <stdio.h>
#include <array>

#include "shatranj_movegen.hpp"
#include "shatranj_position.hpp"
#include "shatranj_types.hpp"

namespace Shatranj
{
    /// StatBoards is a generic 2-dimensional array used to store various statistics
    template<int32_t Size1, int32_t Size2, typename T = int16_t> struct StatBoards : public std::array<std::array<T, Size2>, Size1> {
        
        void fill(const T& v) {
            T* p = &(*this)[0][0];
            std::fill(p, p + sizeof(*this) / sizeof(*p), v);
        }
        
        void update(T& entry, int32_t bonus, const int32_t D) {
            
            // assert(abs(bonus) <= D); // Ensure range is [-32 * D, 32 * D]
            if(!(abs(bonus) <= D)){
                printf("error, assert(abs(bonus) <= D)\n");
            }
            // assert(abs(32 * D) < INT16_MAX); // Ensure we don't overflow
            if(!(abs(32 * D) < INT16_MAX)){
                printf("error, assert(abs(32 * D) < INT16_MAX)\n");
            }
            
            entry += bonus * 32 - entry * abs(bonus) / D;
            
            // assert(abs(entry) <= 32 * D);
            if(!(abs(entry) <= 32 * D)){
                printf("error, assert(abs(entry) <= 32 * D)\n");
            }
        }
    };
    
    /// ButterflyBoards are 2 tables (one for each color) indexed by the move's from
    /// and to squares, see chessprogramming.wikispaces.com/Butterfly+Boards
    typedef StatBoards<COLOR_NB, int(SQUARE_NB) * int(SQUARE_NB)> ButterflyBoards;
    
    /// PieceToBoards are addressed by a move's [piece][to] information
    typedef StatBoards<PIECE_NB, SQUARE_NB> PieceToBoards;
    
    /// ButterflyHistory records how often quiet moves have been successful or
    /// unsuccessful during the current search, and is used for reduction and move
    /// ordering decisions. It uses ButterflyBoards as backing store.
    struct ButterflyHistory : public ButterflyBoards {
        
        void update(Color c, Move m, int32_t bonus) {
            StatBoards::update((*this)[c][from_to(m)], bonus, 324);
        }
    };
    
    /// PieceToHistory is like ButterflyHistory, but is based on PieceToBoards
    struct PieceToHistory : public PieceToBoards {
        
        void update(Piece pc, Square to, int32_t bonus) {
            StatBoards::update((*this)[pc][to], bonus, 936);
        }
    };
    
    /// CounterMoveHistory stores counter moves indexed by [piece][to] of the previous
    /// move, see chessprogramming.wikispaces.com/Countermove+Heuristic
    typedef StatBoards<PIECE_NB, SQUARE_NB, Move> CounterMoveHistory;
    
    /// ContinuationHistory is the history of a given pair of moves, usually the
    /// current one given a previous one. History table is based on PieceToBoards
    /// instead of ButterflyBoards.
    typedef StatBoards<PIECE_NB, SQUARE_NB, PieceToHistory> ContinuationHistory;
    
    
    /// MovePicker class is used to pick one pseudo legal move at a time from the
    /// current position. The most important method is next_move(), which returns a
    /// new pseudo legal move each time it is called, until there are no moves left,
    /// when MOVE_NONE is returned. In order to improve the efficiency of the alpha
    /// beta algorithm, MovePicker attempts to return the moves which are most likely
    /// to get a cut-off first.
    
    class MovePicker {
    public:
        MovePicker(const MovePicker&) = delete;
        MovePicker& operator=(const MovePicker&) = delete;
        MovePicker(const Position&, Move, Value);
        MovePicker(const Position&, Move, Depth, const ButterflyHistory*, Square);
        MovePicker(const Position&, Move, Depth, const ButterflyHistory*, const PieceToHistory**, Move, Move*);
        Move next_move(bool skipQuiets = false);
        
    private:
        template<GenType> void score();
        ExtMove* begin() { return cur; }
        ExtMove* end() { return endMoves; }
        
        const Position& pos;
        const ButterflyHistory* mainHistory;
        const PieceToHistory** contHistory;
        Move ttMove, countermove, killers[2];
        ExtMove *cur, *endMoves, *endBadCaptures;
        int32_t stage;
        Square recaptureSquare;
        Value threshold;
        Depth depth;
        ExtMove moves[MAX_MOVES];
    };
}

#endif /* movepick_hpp */
