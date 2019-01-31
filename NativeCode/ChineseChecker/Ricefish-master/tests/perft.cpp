#include <gtest/gtest.h>
#include <vector>
#include <movegenerator.hpp>

#include "board.hpp"

namespace ricefish {

struct Entry {
    int depth;
    uint64_t nodes;
};

struct P {
    std::string pos_string;
    std::vector<Entry> perft_entries;
    P(std::string str, std::initializer_list<Entry> perft_entries) : pos_string(str), perft_entries(perft_entries) {}
};

// TODO: Add more perft positions.
const std::vector<P> perft_positions = {
       P{Positions::INITIAL_POSITION, {Entry{1, 14}, Entry{2, 14*14}}},
};


uint64_t mini_max(int depth, Board &board) {
    if (depth <= 0) {
        return 1;
    }

    uint64_t total_nodes = 0;

    MoveGenerator generator;
    auto moves = generator.get_moves(board);

    for (const auto& e : moves) {

        board.make_move(e->move);
        if (board.get_winner() == Pebble::NO_PEBBLE)
            total_nodes += mini_max(depth - 1, board);
        board.undo_move(e->move);
    }

    return total_nodes;
}

TEST(Perft, test_inside) {

    for (const auto& p : perft_positions) {
        for (const auto& e : p.perft_entries) {
            Board b(p.pos_string);

            auto result = mini_max(e.depth, b);

            ASSERT_EQ(e.nodes, result) << "Depth: " << e.depth
                                       <<  "\nPosition:\n" << b;
        }
    }

}

}
