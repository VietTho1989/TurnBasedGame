#include <gtest/gtest.h>
#include <string>
#include <algorithm>
#include <movegenerator.hpp>

#include "board.hpp"

namespace ricefish {

TEST(Board, test_inside) {
    int inside_count = 0;
    int inside_p1_count = 0;
    int inside_p2_count = 0;
    for (int x = 0; x < X_SIZE; ++x) {
        for (int y = 0; y < Y_SIZE; ++y) {
            bool inside = Board::inside_board(y, x);
            bool in_p1 = Board::inside_P1(y, x);
            bool in_p2 = Board::inside_P2(y, x);
            if (in_p1 or in_p2) {
                ASSERT_TRUE(inside);
            }
            ASSERT_FALSE(in_p1 and in_p2);
            inside_count += Board::inside_board(y, x);
            inside_p1_count += in_p1;
            inside_p2_count += in_p2;
        }
    }
    ASSERT_EQ(inside_count, 121);
    ASSERT_EQ(inside_p1_count, 10);
    ASSERT_EQ(inside_p2_count, 10);
}

TEST(Board, test_initial_pos) {
    Board b;
    EXPECT_EQ(b.get_turn(), Pebble::P1);
    EXPECT_EQ(b(Holes::P1_HOME), Pebble::P1);
    EXPECT_EQ(b(Holes::P2_HOME), Pebble::P2);
    for (int x = 0; x < X_SIZE; ++x) {
        for (int y = 0; y < Y_SIZE; ++y) {
            if (Board::inside_board(y, x)) {
                if (Board::inside_P1(y, x))
                    ASSERT_EQ(b(y, x), Pebble::P1);
                else if (Board::inside_P2(y, x))
                    ASSERT_EQ(b(y, x), Pebble::P2);
                else
                    ASSERT_EQ(b(y, x), Pebble::NO_PEBBLE);
            } else
                ASSERT_EQ(b(y, x), Pebble::INVALID);
        }
    }

    for (const Hole& hole : Holes::valid_holes) {
        ASSERT_NE(b(hole), Pebble::INVALID);
    }
}

TEST(Board, make_undo_moves) {
    Board b;

    const Pebble p1 = b.get_turn();
    const Move m = {{4, 13}, {5, 13}};

    b.make_move(m);

    ASSERT_EQ(p1, b(5, 13));
    ASSERT_EQ(Pebble::NO_PEBBLE, b(4, 13));
    ASSERT_EQ(~p1, b.get_turn());

    b.undo_move(m);

    Board init;

    ASSERT_EQ(init, b);
}

TEST(Board, test_movegen_leaves_board_unchanged) {
    // Movegen cannot be a const method as it needs to temporarily modify
    // the squares when generating jumps. Therefore, test the constness of
    // the movegen here:
    Board b;

    MoveGenerator generator;
    auto moves = generator.get_moves(b);

    Board init;

    ASSERT_EQ(init, b);
}

TEST(Board, test_simple_scores) {
    // Initial position is evenly scored.
    Board b;
    ASSERT_EQ(Value::DRAW, b.score());

    // The opposite of the initial position is also a draw (both players done).
    b = Board{Positions::END_POSITION};
    ASSERT_EQ(Value::DRAW, b.score());

    // (Un)Making one move for P2 results in a winning position for P1.
    const Move m {{4, 13}, {5, 13}};
    b.make_move(m);

    ASSERT_EQ( Value::MATE, b.score_by_side<Pebble::P1>());
    ASSERT_EQ(-Value::MATE, b.score_by_side<Pebble::P2>());
}

struct D {
    Hole from;
    Hole to;
    int dist;
};

const std::vector<D> test_distances = {
        {{1, 13}, {17, 5}, 16},
        {{8, 6}, {5, 9}, 3},
        {{17, 5}, {13, 1}, 8},
        {{11, 10}, {9, 8}, 4},
        {{5, 5}, {1, 13}, 8},
        {{5, 17}, {1, 13}, 8},
};

TEST(Board, test_distance) {
    for (const auto& d : test_distances) {
        // Dist should be equal under interchange of arguments.
        ASSERT_EQ(d.dist, Board::dist(d.from, d.to));
        ASSERT_EQ(d.dist, Board::dist(d.to, d.from));
    }
}


}
