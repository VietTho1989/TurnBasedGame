#pragma once

#include "board.hpp"
#include "movelist.hpp"

namespace ricefish {

class MoveGenerator {
public:

    MoveList<MoveEntry>& get_moves(Board& position);

private:
    MoveList<MoveEntry> moves;

    void add_moves(MoveList<MoveEntry>& list, Board& board);
};

}