#include "Calculator.h"
#include <thread>

void Calculator::Start(TT& table, const SearchParams& params, Board& board)
{
    // Start the search asynchronously.
    _thread = std::thread(&Calculator::ThreadFunc, this, std::ref(table), params, std::ref(board));
    _thread.detach();
}

void Calculator::Stop()
{
    _search.Stop();
    if (_thread.joinable())
        _thread.join();
}

// Callback method for the thread.
void Calculator::ThreadFunc(TT& table, const SearchParams& params, Board& board)
{
    int score = 0;
    _search.Start(table, params, board, score);
}
