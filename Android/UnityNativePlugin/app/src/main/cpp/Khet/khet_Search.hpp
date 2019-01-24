#ifndef __KHET_SEARCH_H__
#define __KHET_SEARCH_H__

#include "khet_Board.hpp"
#include "khet_Evaluator.hpp"
#include "khet_History.hpp"
#include "khet_Types.hpp"
#include "khet_SearchParams.hpp"
#include "khet_TranspositionTable.hpp"
#include <ctime>

namespace Khet
{
    class Search
    {
    public:
        // Iterative deepening Minimax search.
        Move Start(TT&, const SearchParams&, Board&, int32_t&);
        
        // Stop the current search.
        void Stop();
        
    private:
        bool _stopped;
        SearchParams _params;
        clock_t _startTime;
        History _history;
        
        // Display an info string for the current search.
        void ScoreInfo(int32_t, int32_t) const;
        void MateInfo(int32_t) const;
        
        // Display the best move that was found.
        void BestMove(Move) const;
        
        clock_t TimeElapsed() const;
        
        // Check whether there is still time remaining for the search.
        bool CheckTime() const;
        
        // This root call to the Alpha-Beta search returns the best root move.
        Move AlphaBetaRoot(TT&, History&, Move killers[], const Evaluator&, Board&, int32_t, int32_t&);
        
        // Score the given position using NegaMax with Alpha-Beta pruning.
        int32_t AlphaBeta(TT&, History&, Move killers[], const Evaluator&, Board&, int32_t depth, const int32_t maxDepth, int32_t alpha, int32_t beta, int32_t sign);
        
        // Quiescence search extension.
        int32_t Quiesce(const Evaluator&, Board&, int32_t depth, int32_t alpha, int32_t beta, int32_t sign);
    };
}

#endif // __SEARCH_H__
