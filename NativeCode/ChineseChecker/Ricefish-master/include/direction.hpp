#pragma once

#include <array>
#include "hole.hpp"

namespace ricefish {

using Direction = Hole;

namespace Directions {

const std::array<Direction, 6> steps = {
    Direction{1,  0}, Direction{-1, 0}, Direction{0,  1},
    Direction{0, -1}, Direction{1, -1}, Direction{-1, 1}
};

}


}