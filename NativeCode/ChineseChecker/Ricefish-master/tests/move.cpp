#include <gtest/gtest.h>
#include <iostream>

#include "move.hpp"

namespace ricefish {

TEST(move, test_no_move) {
    const Hole no_move_hole{0, 0};
    ASSERT_EQ(Moves::NO_MOVE.from, no_move_hole);
    ASSERT_EQ(Moves::NO_MOVE.from, Moves::NO_MOVE.to);
}

TEST(move, test_equality) {
    Move a {{1, 2}, {3, 4}};
    Move b {{4, 6}, {3, 4}};
    ASSERT_NE(a, b);
    ASSERT_NE(b, a);
    ASSERT_NE(b, Moves::NO_MOVE);
    ASSERT_EQ(a, a);
    ASSERT_EQ(b, b);
}

TEST(move, to_string) {
    Move a {{0, 1}, {2, 3}};
    std::stringstream ss;
    ss << a;
    ASSERT_STREQ("AbCd", ss.str().c_str());
}

}
