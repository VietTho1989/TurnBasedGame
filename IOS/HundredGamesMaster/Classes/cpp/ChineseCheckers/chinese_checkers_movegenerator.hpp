#pragma once

#include "chinese_checkers_board.hpp"
#include "chinese_checkers_movelist.hpp"

namespace ChineseCheckers
{

    class MoveGenerator {
    public:
        
        MoveList<MoveEntry>& get_moves(Board& position);
        
    private:
        MoveList<MoveEntry> moves;
        
        void add_moves(MoveList<MoveEntry>& list, Board& board);
    };

}
