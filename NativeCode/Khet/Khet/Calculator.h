#ifndef __CALCULATOR_H__
#define __CALCULATOR_H__

#include "Search.h"
#include "TranspositionTable.h"
#include <thread>

// This class wraps up a thread that executes a search.
// There is currently only one searching thread.
class Calculator
{
public:
    void Start(TT&, const SearchParams&, Board&);
    void Stop();

private:
    Search _search;
    std::thread _thread;

    void ThreadFunc(TT&, const SearchParams&, Board&);
};

#endif // __CALCULATOR_H__ 

