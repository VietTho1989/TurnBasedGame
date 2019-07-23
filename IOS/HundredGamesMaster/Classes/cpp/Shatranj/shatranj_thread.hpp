//
//  thread.hpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef shatranj_thread_hpp
#define shatranj_thread_hpp

#include <stdio.h>
#include <atomic>
#include <condition_variable>
#include <mutex>
#include <thread>
#include <vector>

#include "shatranj_material.hpp"
#include "shatranj_movepick.hpp"
#include "shatranj_pawns.hpp"
#include "shatranj_position.hpp"
#include "shatranj_search.hpp"
#include "shatranj_thread_win32.hpp"
#include "shatranj_tt.hpp"

namespace Shatranj
{
    /// Thread class keeps together all the thread-related stuff. We use
    /// per-thread pawn and material hash tables so that once we get a
    /// pointer to an entry its life time is unlimited and we don't have
    /// to care about someone changing the entry under our feet.
    
    class Thread {
        
        Mutex mutex;
        ConditionVariable cv;
        size_t idx;
        bool exit = false, searching = true; // Set before starting std::thread
        std::thread stdThread;
        
    public:
        explicit Thread(size_t);
        virtual ~Thread();
        virtual void search();
        void clear();
        void idle_loop();
        void start_searching();
        void wait_for_search_finished();
        
        Pawns::Table pawnsTable;
        Material::Table materialTable;
        Endgames endgames;
        size_t PVIdx;
        int32_t selDepth, nmp_ply, pair;
        std::atomic<uint64_t> nodes, tbHits;
        
        Position* rootPos = NULL;
        Search::RootMoves rootMoves;
        Depth rootDepth, completedDepth;
        CounterMoveHistory counterMoves;
        ButterflyHistory mainHistory;
        ContinuationHistory contHistory;
        
        // TODO tu cho vao
    public:
        Search::LimitsType lms;
        bool stop = false;
        
        int32_t skillLevel = 1;
        
        TranspositionTable TT; // Our global transposition table
    };
}

#endif /* thread_hpp */
