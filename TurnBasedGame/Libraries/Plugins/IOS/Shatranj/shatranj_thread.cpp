//
//  thread.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_thread.hpp"
#include <algorithm> // For std::count
#include <cassert>

#include "shatranj_movegen.hpp"
#include "shatranj_search.hpp"
#include "shatranj_tbprobe.hpp"
#include "shatranj_uci.hpp"

namespace Shatranj
{
    
    /// Thread constructor launches the thread and waits until it goes to sleep
    /// in idle_loop(). Note that 'searching' and 'exit' should be alredy set.
    
    Thread::Thread(size_t n) : idx(n), stdThread(&Thread::idle_loop, this) {
        
        wait_for_search_finished();
        TT.resize(Options["Hash"]);
    }
    
    
    /// Thread destructor wakes up the thread in idle_loop() and waits
    /// for its termination. Thread should be already waiting.
    
    Thread::~Thread() {
        
        // assert(!searching);
        if(searching){
            printf("error, assert(!searching)\n");
        }
        
        exit = true;
        start_searching();
        stdThread.join();
    }
    
    
    /// Thread::clear() reset histories, usually before a new game
    
    void Thread::clear() {
        
        counterMoves.fill(MOVE_NONE);
        mainHistory.fill(0);
        // captureHistory.fill(0);
        
        for (auto& to : contHistory)
            for (auto& h : to)
                h.fill(0);
        
        contHistory[NO_PIECE][0].fill(Search::CounterMovePruneThreshold - 1);
    }
    
    /// Thread::start_searching() wakes up the thread that will start the search
    
    void Thread::start_searching() {
        
        std::lock_guard<Mutex> lk(mutex);
        searching = true;
        cv.notify_one(); // Wake up the thread in idle_loop()
    }
    
    
    /// Thread::wait_for_search_finished() blocks on the condition variable
    /// until the thread has finished searching.
    
    void Thread::wait_for_search_finished() {
        
        std::unique_lock<Mutex> lk(mutex);
        cv.wait(lk, [&]{ return !searching; });
    }
    
    
    /// Thread::idle_loop() is where the thread is parked, blocked on the
    /// condition variable, when it has no work to do.
    
    void Thread::idle_loop() {
        //printf("thread idle loop\n");
        // If OS already scheduled us on a different group than 0 then don't overwrite
        // the choice, eventually we are one of many one-threaded processes running on
        // some Windows NUMA hardware, for instance in fishtest. To make it simple,
        // just check if running threads are below a threshold, in this case all this
        // NUMA machinery is not needed.
        if (Options["Threads"] >= 8)
            WinProcGroup::bindThisThread(idx);
        
        while (true) {
            std::unique_lock<Mutex> lk(mutex);
            searching = false;
            cv.notify_one(); // Wake up anyone waiting for search finished
            cv.wait(lk, [&]{ return searching; });
            
            if (exit)
                return;
            
            lk.unlock();
            
            search();
        }
    }
    
}
