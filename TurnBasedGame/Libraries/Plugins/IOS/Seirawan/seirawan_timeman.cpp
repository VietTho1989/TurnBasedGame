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

#include <algorithm>
#include <cfloat>
#include <cmath>

#include "seirawan_search.hpp"
#include "seirawan_timeman.hpp"
#include "seirawan_uci.hpp"

using namespace std;

namespace Seirawan
{
    
    namespace {
        
        enum TimeType { OptimumTime, MaxTime };
        
        const int32_t MoveHorizon   = 50;   // Plan time management at most this many moves ahead
        const double MaxRatio   = 7.09; // When in trouble, we can step over reserved time with this ratio
        const double StealRatio = 0.35; // However we must not steal time from remaining moves over this ratio
        
        
        // move_importance() is a skew-logistic function based on naive statistical
        // analysis of "how many games are still undecided after n half-moves". Game
        // is considered "undecided" as long as neither side has >275cp advantage.
        // Data was extracted from the CCRL game database with some simple filtering criteria.
        
        double move_importance(int32_t ply) {
            
            const double XScale = 7.64;
            const double XShift = 58.4;
            const double Skew   = 0.183;
            
            return pow((1 + exp((ply - XShift) / XScale)), -Skew) + DBL_MIN; // Ensure non-zero
        }
        
        template<TimeType T>
        int32_t remaining(int32_t myTime, int32_t movesToGo, int32_t ply, int32_t slowMover) {
            
            const double TMaxRatio   = (T == OptimumTime ? 1 : MaxRatio);
            const double TStealRatio = (T == OptimumTime ? 0 : StealRatio);
            
            double moveImportance = (move_importance(ply) * slowMover) / 100;
            double otherMovesImportance = 0;
            
            for (int32_t i = 1; i < movesToGo; ++i)
                otherMovesImportance += move_importance(ply + 2 * i);
            
            double ratio1 = (TMaxRatio * moveImportance) / (TMaxRatio * moveImportance + otherMovesImportance);
            double ratio2 = (moveImportance + TStealRatio * otherMovesImportance) / (moveImportance + otherMovesImportance);
            
            return int32_t(myTime * min(ratio1, ratio2)); // Intel C++ asks for an explicit cast
        }
        
    } // namespace
    
    
    /// init() is called at the beginning of the search and calculates the allowed
    /// thinking time out of the time control and current game ply. We support four
    /// different kinds of time controls, passed in 'limits':
    ///
    ///  inc == 0 && movestogo == 0 means: x basetime  [sudden death!]
    ///  inc == 0 && movestogo != 0 means: x moves in y minutes
    ///  inc >  0 && movestogo == 0 means: x basetime + z increment
    ///  inc >  0 && movestogo != 0 means: x moves in y minutes + z increment
    
    void TimeManagement::init(Search::LimitsType& limits, Color us, int32_t ply) {

        int32_t minThinkingTime = Options["Minimum Thinking Time"];
        int32_t moveOverhead    = Options["Move Overhead"];
        int32_t slowMover       = Options["Slow Mover"];
        int32_t npmsec          = Options["nodestime"];
        
        // If we have to play in 'nodes as time' mode, then convert from time
        // to nodes, and use resulting values in time management formulas.
        // WARNING: Given npms (nodes per millisecond) must be much lower then
        // the real engine speed to avoid time losses.
        if (npmsec)
        {
            if (!availableNodes) // Only once at game start
                availableNodes = npmsec * limits.time[us]; // Time is in msec
            
            // Convert from millisecs to nodes
            limits.time[us] = (int)availableNodes;
            limits.inc[us] *= npmsec;
            limits.npmsec = npmsec;
        }
        
        startTime = limits.startTime;
        optimumTime = maximumTime = max(limits.time[us], minThinkingTime);
        
        const int32_t MaxMTG = limits.movestogo ? min(limits.movestogo, MoveHorizon) : MoveHorizon;
        
        // We calculate optimum time usage for different hypothetical "moves to go"-values
        // and choose the minimum of calculated search time values. Usually the greatest
        // hypMTG gives the minimum values.
        for (int32_t hypMTG = 1; hypMTG <= MaxMTG; ++hypMTG)
        {
            // Calculate thinking time for hypothetical "moves to go"-value
            int32_t hypMyTime =  limits.time[us]
            + limits.inc[us] * (hypMTG - 1)
            - moveOverhead * (2 + min(hypMTG, 40));
            
            hypMyTime = max(hypMyTime, 0);

            int32_t t1 = minThinkingTime + remaining<OptimumTime>(hypMyTime, hypMTG, ply, slowMover);
            int32_t t2 = minThinkingTime + remaining<MaxTime    >(hypMyTime, hypMTG, ply, slowMover);
            
            optimumTime = min(t1, optimumTime);
            maximumTime = min(t2, maximumTime);
        }
        
        if (Options["Ponder"])
            optimumTime += optimumTime / 4;
    }
    
}
