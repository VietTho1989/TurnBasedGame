#include <gtest/gtest.h>

#include "pebble.hpp"

namespace ricefish {

TEST(Pebble, test_values ) {
    for (auto pebble : Pebbles::values) {
        EXPECT_EQ(pebble, Pebbles::values[static_cast<int>(pebble)]);
    }
}

TEST(Pebble, test_char) {
    ASSERT_EQ(Pebbles::get_char(Pebble::NO_PEBBLE), '.');
    ASSERT_EQ(Pebbles::get_char(Pebble::P1), 'x');
    ASSERT_EQ(Pebbles::get_char(Pebble::P2), '+');
    ASSERT_EQ(Pebbles::get_char(Pebble::INVALID), ' ');

    ASSERT_EQ(Pebble::P1, Pebbles::from_char(Pebbles::get_char(Pebble::P1)));
    ASSERT_EQ(Pebble::P2, Pebbles::from_char(Pebbles::get_char(Pebble::P2)));
    ASSERT_EQ(Pebble::NO_PEBBLE, Pebbles::from_char(Pebbles::get_char(Pebble::NO_PEBBLE)));
    ASSERT_EQ(Pebble::INVALID, Pebbles::from_char(Pebbles::get_char(Pebble::INVALID)));
}

TEST(Pebble, test_inversion) {
    ASSERT_EQ(~Pebble::P1, Pebble::P2);
    ASSERT_EQ(~Pebble::P2, Pebble::P1);
    ASSERT_ANY_THROW(~Pebble::NO_PEBBLE);
    ASSERT_ANY_THROW(~Pebble::INVALID);
}

}
