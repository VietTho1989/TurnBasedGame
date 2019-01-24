//
//  search.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_search_hpp
#define shatranj_search_hpp

#include <stdio.h>
#include <vector>

#include "shatranj_misc.hpp"
#include "shatranj_movepick.hpp"
#include "shatranj_types.hpp"

namespace Shatranj
{
    class Position;
    
    namespace Search {
        
        /// Threshold used for countermoves based pruning
        const int32_t CounterMovePruneThreshold = 0;
        
        
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
        
        
        /// LimitsType struct stores information sent by GUI about available time to
        /// search the current move, maximum depth/time, or if we are in analysis mode.
        
        struct LimitsType {
            
            LimitsType() { // Init explicitly due to broken value-initialization of non POD in MSVC
                nodes = time[WHITE] = time[BLACK] = inc[WHITE] = inc[BLACK] =
                npmsec = movestogo = depth = movetime = mate = perft = infinite = 0;
            }
            
            bool use_time_management() const {
                return !(mate | movetime | depth | nodes | perft | infinite);
            }
            
            std::vector<Move> searchmoves;
            int32_t time[COLOR_NB], inc[COLOR_NB], npmsec, movestogo, depth,
            movetime, mate, perft, infinite;
            int64_t nodes;
            TimePoint startTime;
            
            // TODO Tu them vao
            int64_t duration = 0;
        };
        
        extern LimitsType Limits;
        
        void init();
        
    } // namespace Search
}

#endif /* search_hpp */
