/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2017 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

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

#include <algorithm> // For std::count
#include <cassert>

#include "makruk_movegen.hpp"
#include "makruk_search.hpp"
#include "makruk_thread.hpp"
#include "syzygy/makruk_tbprobe.hpp"
#include "makruk_uci.hpp"

namespace Makruk
{
    
    /// Thread constructor launches the thread and waits until it goes to sleep
    /// in idle_loop(). Note that 'searching' and 'exit' should be alredy set.
    
    Thread::Thread(size_t n) : idx(n), stdThread(&Thread::idle_loop, this) {
        TT.resize(Options["Hash"]);
        TT.clear();
        /*if(TT!=NULL) {
            TT->resize(Options["Hash"]);
        } else {
            printf("error, TT null\n");
            TT = new TranspositionTable;
            TT->resize(Options["Hash"]);
        }*/
        wait_for_search_finished();
    }
    
    
    /// Thread destructor wakes up the thread in idle_loop() and waits
    /// for its termination. Thread should be already waiting.
    
    Thread::~Thread() {
        /*if(TT!=NULL){
            delete TT;
            TT = NULL;
        } else{
            printf("error, why TT null\n");
        }*/
        // printf("thead destructor\n");
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
