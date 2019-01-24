#include <memory>
#include "hex_board.hpp"
#include "hex_eval.hpp"

namespace Hex
{
    using namespace std;
    using namespace board;
    namespace eval
    {
        
        Eval::Eval(board::IBoard * pBoard)
        : _pBoard(pBoard)
        {
        }
        
        Eval::operator long()
        {
            return 0;
        }
        
    }   
}
