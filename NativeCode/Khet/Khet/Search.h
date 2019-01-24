#ifndef __SEARCH_H__
#define __SEARCH_H__

#include "Board.h"
#include "Evaluator.h"
#include "History.h"
#include "Types.h"
#include "SearchParams.h"
#include "TranspositionTable.h"
#include <ctime>

class Search
{
public:
    // Iterative deepening Minimax search.
    Move Start(TT&, const SearchParams&, Board&, int&);

    // Stop the current search.
    void Stop();

private:
    bool _stopped;
    SearchParams _params;
    clock_t _startTime;
    History _history;

    // Display an info string for the current search.
    void ScoreInfo(int, int) const;
    void MateInfo(int) const;

    // Display the best move that was found.
    void BestMove(Move) const;

    clock_t TimeElapsed() const;

    // Check whether there is still time remaining for the search.
    bool CheckTime() const;

    // This root call to the Alpha-Beta search returns the best root move.
    Move AlphaBetaRoot(TT&, History&, Move killers[], const Evaluator&, Board&, int, int&);

    // Score the given position using NegaMax with Alpha-Beta pruning.
    int AlphaBeta(TT&, History&, Move killers[], const Evaluator&, Board&, int depth, const int maxDepth, int alpha, int beta, int sign);

    // Quiescence search extension.
    int Quiesce(const Evaluator&, Board&, int depth, int alpha, int beta, int sign);
};

#endif // __SEARCH_H__
