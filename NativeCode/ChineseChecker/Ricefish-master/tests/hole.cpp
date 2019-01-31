#include <gtest/gtest.h>
#include <iostream>

#include "hole.hpp"

namespace ricefish {

TEST(Hole, test_addition_subtraction) {
    Hole a{1, 2};
    Hole b{3, 6};
    Hole c{4, 8};
    ASSERT_EQ(a + b, c);
    ASSERT_EQ(c - a, b);
    ASSERT_EQ(c - b, a);
}

TEST(Hole, to_string) {
    std::stringstream ss;
    ss << Hole{0, 1};
    ASSERT_STREQ("Ab", ss.str().c_str());
}

}
