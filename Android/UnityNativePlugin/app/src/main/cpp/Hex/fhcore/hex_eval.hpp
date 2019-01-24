#pragma once

namespace Hex
{
    namespace board
    {
        class IBoard;
    }
    
    namespace eval
    {
        
        class Eval
        {
        public:
            Eval(board::IBoard *pBoard);
            operator long();
        private:
            board::IBoard *_pBoard { nullptr };
        };
        
    }
}
