#include "movegenerator.hpp"

namespace ricefish {

MoveList<MoveEntry> &MoveGenerator::get_moves(Board &board) {
    moves.size = 0;

    // If the position is won, there are no more moves.
    if (board.get_winner() != Pebble::NO_PEBBLE)
        return moves;

    // Generate main moves (no quiescent moves at this time).
    add_moves(moves, board);

    moves.rate();
    moves.sort();

    return moves;
}

namespace {

void generate_jumps(Board& board,
                    const Hole &origin,
                    const Hole &from,
                    MoveList<MoveEntry>& list) {
    const auto original = board(from);
    board(from) = board.get_turn();

    for (const Direction &dir : Directions::steps) {
        Hole over = from + dir;
        Hole to = over + dir;
        if (Pebbles::is_pebble(board(over))
            and board(to) == Pebble::NO_PEBBLE) {
            list.add({origin, to});
            generate_jumps(board, origin, to, list);
        }
    }
    board(from) = original;
}
}

void MoveGenerator::add_moves(MoveList<MoveEntry>& list, Board& board) {
    for (const Hole& from : Holes::valid_holes) {
        const Pebble pebble = board(from);

        if (pebble == board.get_turn()) {

            // Generate all jumps. Do this first,
            // as jumps are more likely to be best moves.
            generate_jumps(board, from, from, list);

            // Generate all single steps.
            for (const Direction &dir : Directions::steps) {
                Hole to = from + dir;
                if (board(to) == Pebble::NO_PEBBLE)
                    list.add({from, to});
            }
        }
    }
}


}
