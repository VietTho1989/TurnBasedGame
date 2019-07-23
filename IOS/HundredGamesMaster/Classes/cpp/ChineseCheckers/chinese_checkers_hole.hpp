#pragma once

#include <string>
#include <iostream>
#include <array>
#include "chinese_checkers_pebble.hpp"

namespace ChineseCheckers
{

    struct Hole {
        int32_t y;
        int32_t x;
    };
    
    inline bool operator== (const Hole& a, const Hole& b) {
        return a.x == b.x and a.y == b.y;
    }
    
    inline bool operator!= (const Hole& a, const Hole& b) {
        return !(a == b);
    }
    
    inline Hole operator+ (const Hole& a, const Hole& b) {
        return {a.y + b.y, a.x + b.x};
    }
    
    inline Hole operator- (const Hole& a, const Hole& b) {
        return {a.y - b.y, a.x - b.x};
    }
    
    inline std::ostream& operator<< (std::ostream& strm, const Hole& b) {
        return strm << (char)('A' + b.y) << (char)('a' + b.x);
    }
    
    namespace Holes {
        
        constexpr Hole P1_HOME = {1, 13};
        constexpr Hole P2_HOME = {17, 5};
        constexpr int32_t N_HOLES = 121;
        constexpr std::array<Hole, N_HOLES> valid_holes = {
            Hole{1, 13},
            Hole{2, 12},Hole{2, 13},
            Hole{3, 11},Hole{3, 12},Hole{3, 13},
            Hole{4, 10},Hole{4, 11},Hole{4, 12},Hole{4, 13},
            Hole{5, 5},Hole{5, 6},Hole{5, 7},Hole{5, 8},Hole{5, 9},Hole{5, 10},Hole{5, 11},Hole{5, 12},Hole{5, 13},Hole{5, 14},Hole{5, 15},Hole{5, 16}, Hole{5, 17},
            Hole{6, 5},Hole{6, 6},Hole{6, 7},Hole{6, 8},Hole{6, 9},Hole{6, 10},Hole{6, 11},Hole{6, 12},Hole{6, 13},Hole{6, 14}, Hole{6, 15},Hole{6, 16},
            Hole{7, 5},Hole{7, 6},Hole{7, 7},Hole{7, 8},Hole{7, 9},Hole{7, 10},Hole{7, 11},Hole{7, 12},Hole{7, 13}, Hole{7, 14},Hole{7, 15},
            Hole{8, 5},Hole{8, 6},Hole{8, 7},Hole{8, 8},Hole{8, 9},Hole{8, 10},Hole{8, 11},Hole{8, 12},Hole{8, 13}, Hole{8, 14},
            Hole{9, 5},Hole{9, 6},Hole{9, 7},Hole{9, 8},Hole{9, 9},Hole{9, 10},Hole{9, 11},Hole{9, 12},Hole{9, 13},
            Hole{10, 4}, Hole{10, 5},Hole{10, 6},Hole{10, 7},Hole{10, 8},Hole{10, 9},Hole{10, 10},Hole{10, 11},Hole{10, 12},Hole{10, 13},
            Hole{11, 3},Hole{11, 4}, Hole{11, 5},Hole{11, 6},Hole{11, 7},Hole{11, 8},Hole{11, 9},Hole{11, 10},Hole{11, 11},Hole{11, 12},Hole{11, 13},
            Hole{12, 2},Hole{12, 3}, Hole{12, 4},Hole{12, 5},Hole{12, 6},Hole{12, 7},Hole{12, 8},Hole{12, 9},Hole{12, 10},Hole{12, 11},Hole{12, 12},Hole{12, 13},
            Hole{13, 1}, Hole{13, 2},Hole{13, 3},Hole{13, 4},Hole{13, 5},Hole{13, 6},Hole{13, 7},Hole{13, 8},Hole{13, 9},Hole{13, 10},Hole{13, 11},Hole{13, 12},Hole{13, 13},
            Hole{14, 5},Hole{14, 6},Hole{14, 7},Hole{14, 8},
            Hole{15, 5},Hole{15, 6},Hole{15, 7},
            Hole{16, 5},Hole{16, 6},
            Hole{17, 5}
        };
        
    }

}
