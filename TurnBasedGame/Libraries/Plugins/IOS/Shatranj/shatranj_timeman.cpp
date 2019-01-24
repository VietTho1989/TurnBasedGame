//
//  timeman.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <algorithm>

#include "shatranj_timeman.hpp"
#include "shatranj_search.hpp"
#include "shatranj_uci.hpp"

using namespace std;

namespace Shatranj
{
    namespace {
        
        enum TimeType { OptimumTime, MaxTime };

        int32_t remaining(int32_t myTime, int32_t myInc, int32_t moveOverhead, int32_t movesToGo, int32_t moveNum, bool ponder, TimeType type) {
            
            if (myTime <= 0)
                return 0;
            
            double ratio; // Which ratio of myTime we are going to use
            
            // Usage of increment follows quadratic distribution with the maximum at move 25
            double inc = myInc * max(55.0, 120 - 0.12 * (moveNum - 25) * (moveNum - 25));
            
            // In moves-to-go we distribute time according to a quadratic function with
            // the maximum around move 20 for 40 moves in y time case.
            if (movesToGo)
            {
                ratio = (type == OptimumTime ? 1.0 : 6.0) / min(50, movesToGo);
                
                if (moveNum <= 40)
                    ratio *= 1.1 - 0.001 * (moveNum - 20) * (moveNum - 20);
                else
                    ratio *= 1.5;
                
                ratio *= 1 + inc / (myTime * 8.5);
            }
            // Otherwise we increase usage of remaining time as the game goes on
            else
            {
                double k = 1 + 20 * moveNum / (500.0 + moveNum);
                ratio = (type == OptimumTime ? 0.017 : 0.07) * (k + inc / myTime);
            }

            int32_t time = int32_t(min(1.0, ratio) * max(0, myTime - moveOverhead));
            
            if (type == OptimumTime && ponder)
                time = 5 * time / 4;
            
            return time;
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
    
    void TimeManagement::init(Search::LimitsType& limits, Color us, int32_t ply)
    {
        int32_t moveOverhead = Options["Move Overhead"];
        int32_t npmsec       = Options["nodestime"];
        bool ponder      = Options["Ponder"];
        
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

        int32_t moveNum = (ply + 1) / 2;
        
        startTime = limits.startTime;
        optimumTime = remaining(limits.time[us], limits.inc[us], moveOverhead,
                                limits.movestogo, moveNum, ponder, OptimumTime);
        maximumTime = remaining(limits.time[us], limits.inc[us], moveOverhead,
                                limits.movestogo, moveNum, ponder, MaxTime);
    }
}
