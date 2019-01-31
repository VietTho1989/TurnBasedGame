#pragma once

#include "chinese_checkers_hole.hpp"

namespace ChineseCheckers
{

    struct Move {
        Hole from;
        Hole to;
    };

    inline bool operator==(const Move &a, const Move &b) {
        return a.from == b.from and a.to == b.to;
    }
    
    inline bool operator!= (const Move& a, const Move& b) {
        return !(a == b);
    }
    
    inline std::ostream& operator<<(std::ostream &strm, const Move &m) {
        return strm << m.from << m.to;
    }

    namespace Moves {

        constexpr Move NO_MOVE = {{0, 0}, {0, 0}};

    }

}
