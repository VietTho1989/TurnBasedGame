//
//  tbprobe.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_tbprobe_hpp
#define shatranj_tbprobe_hpp

#include <stdio.h>
#include <ostream>
#include "shatranj_search.hpp"

namespace Shatranj
{
    namespace Tablebases {
        
        enum WDLScore {
            WDLLoss        = -2, // Loss
            WDLBlessedLoss = -1, // Loss, but draw under 50-move rule
            WDLDraw        =  0, // Draw
            WDLCursedWin   =  1, // Win, but draw under 50-move rule
            WDLWin         =  2, // Win
            
            WDLScoreNone  = -1000
        };
        
        // Possible states after a probing operation
        enum ProbeState {
            FAIL              =  0, // Probe failed (missing file table)
            OK                =  1, // Probe succesful
            CHANGE_STM        = -1, // DTZ should check the other side
            ZEROING_BEST_MOVE =  2  // Best move zeroes DTZ (capture or pawn move)
        };
        
        extern int32_t MaxCardinality;
        
        void init(const std::string& paths);
        WDLScore probe_wdl(Position& pos, ProbeState* result);
        int32_t probe_dtz(Position& pos, ProbeState* result);
        bool root_probe(Position& pos, Search::RootMoves& rootMoves, Value& score);
        bool root_probe_wdl(Position& pos, Search::RootMoves& rootMoves, Value& score);
        void filter_root_moves(Position& pos, Search::RootMoves& rootMoves);
        
        inline std::ostream& operator<<(std::ostream& os, const WDLScore v) {
            
            os << (v == WDLLoss        ? "Loss" :
                   v == WDLBlessedLoss ? "Blessed loss" :
                   v == WDLDraw        ? "Draw" :
                   v == WDLCursedWin   ? "Cursed win" :
                   v == WDLWin         ? "Win" : "None");
            
            return os;
        }
        
        inline std::ostream& operator<<(std::ostream& os, const ProbeState v) {
            
            os << (v == FAIL              ? "Failed" :
                   v == OK                ? "Success" :
                   v == CHANGE_STM        ? "Probed opponent side" :
                   v == ZEROING_BEST_MOVE ? "Best move zeroes DTZ" : "None");
            
            return os;
        }
        
    }
}

#endif /* tbprobe_hpp */
