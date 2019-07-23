/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2018 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

  Stockfish is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Stockfish is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#ifndef CHESS_STOCK_FISH_SEARCH_H_INCLUDED
#define CHESS_STOCK_FISH_SEARCH_H_INCLUDED

#include <vector>

#include "chess_stock_fish_misc.hpp"
#include "chess_stock_fish_movepick.hpp"
#include "chess_stock_fish_types.hpp"
//#include "chess_stock_fish_thread.h"

namespace StockFishChess
{
    class Position;
    class Thread;
    
    namespace Search {
        
        /// Threshold used for countermoves based pruning
        const int32_t CounterMovePruneThreshold = 0;
        
        /// RootMove struct is used for moves at the root of the tree. For each root move
        /// we store a score and a PV (really a refutation in the case of moves which
        /// fail low). Score is normally set at -VALUE_INFINITE for all non-pv moves.
        
        struct RootMove {
            
            explicit RootMove(Move m) : pv(1, m) {}
            bool extract_ponder_from_tt(Position& pos);
            bool operator==(const Move& m) const { return pv[0] == m; }
            bool operator<(const RootMove& m) const { // Sort in descending order
                return m.score != score ? m.score < score
                : m.previousScore < previousScore;
            }
            
            Value score = -VALUE_INFINITE;
            Value previousScore = -VALUE_INFINITE;
            int32_t selDepth = 0;
            std::vector<Move> pv;
        };
        
        typedef std::vector<RootMove> RootMoves;
        
        
        /// Stack struct keeps track of the information we need to remember from nodes
        /// shallower and deeper in the tree during the search. Each search thread has
        /// its own array of Stack objects, indexed by the current ply.
        
        struct Stack {
            Move* pv;
            PieceToHistory* contHistory;
            int32_t ply;
            Move currentMove;
            Move excludedMove;
            Move killers[2];
            Value staticEval;
            int32_t statScore;
            int32_t moveCount;
        };
        
        
        /// LimitsType struct stores information sent by GUI about available time to
        /// search the current move, maximum depth/time, or if we are in analysis mode.
        
        struct LimitsType {
            
            LimitsType() { // Init explicitly due to broken value-initialization of non POD in MSVC
                nodes = time[WHITE] = time[BLACK] = inc[WHITE] = inc[BLACK] =
                npmsec = movestogo = depth = movetime = mate = perft = infinite = 0;
                duration = 0;
            }
            
            bool use_time_management() const {
                return !(mate | movetime | depth | nodes | perft | infinite);
            }
            
            std::vector<Move> searchmoves;
            int32_t time[COLOR_NB], inc[COLOR_NB], npmsec, movestogo, depth,
            movetime, mate, perft, infinite;
            int64_t nodes;
            TimePoint startTime;
            int64_t duration = 0;
        };
        
        extern LimitsType Limits;
        
        void init();
        
    } // namespace Search
}

#endif // #ifndef CHESS_STOCK_FISH_SEARCH_H_INCLUDED
