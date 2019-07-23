//
//  timeman.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_timeman_hpp
#define shatranj_timeman_hpp

#include <stdio.h>
#include "shatranj_misc.hpp"
#include "shatranj_search.hpp"
#include "shatranj_thread.hpp"
#include "../Platform.h"

namespace Shatranj
{
    /// The TimeManagement class computes the optimal time to think depending on
    /// the maximum available time, the game move number and other parameters.
    
    class TimeManagement {
    public:
        void init(Search::LimitsType& limits, Color us, int32_t ply);

        int32_t optimum() const
        {
            return optimumTime;
        }

        int32_t maximum() const
        {
            return maximumTime;
        }
        
        int64_t elapsed() const
        {
            // return int(Search::Limits.npmsec ? Threads.nodes_searched() : now() - startTime);
            return now() - startTime;
        }
        
        int64_t availableNodes; // When in 'nodes as time' mode
        
    private:
        TimePoint startTime;
        int32_t optimumTime;
        int32_t maximumTime;
    };

}

#endif /* timeman_hpp */
