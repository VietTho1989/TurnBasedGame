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

#ifndef CHESS_STOCK_FISH_THREAD_H_INCLUDED
#define CHESS_STOCK_FISH_THREAD_H_INCLUDED

#include <atomic>
#include <condition_variable>
#include <mutex>
#include <thread>
#include <vector>

#include "chess_stock_fish_material.hpp"
#include "chess_stock_fish_movepick.hpp"
#include "chess_stock_fish_pawns.hpp"
#include "chess_stock_fish_position.hpp"
#include "chess_stock_fish_search.hpp"
#include "chess_stock_fish_thread_win32.hpp"
#include "chess_stock_fish_tt.hpp"

namespace StockFishChess
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
        
        Position rootPos;
        Search::RootMoves rootMoves;
        Depth rootDepth, completedDepth;
        CounterMoveHistory counterMoves;
        ButterflyHistory mainHistory;
        CapturePieceToHistory captureHistory;
        ContinuationHistory contHistory;
        
        // TODO tu cho vao
    public:
        Search::LimitsType lms;
        bool stop = false;

        int32_t skillLevel = 1;
        
        TranspositionTable TT; // Our global transposition table
    };
    
}

#endif // #ifndef THREAD_H_INCLUDED