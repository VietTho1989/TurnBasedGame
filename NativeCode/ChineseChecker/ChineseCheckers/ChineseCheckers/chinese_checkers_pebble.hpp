#pragma once

#include <array>
#include <exception>

namespace ChineseCheckers
{

    enum class Pebble
    {
        NO_PEBBLE = 0,
        P1,
        P2,

        // Invalid squares set to non-zero to avoid bugs.
        INVALID = 123
    };

    inline constexpr Pebble operator~ (Pebble pebble) {
        switch (pebble) {
            case Pebble::P1:
                return Pebble::P2;
            case  Pebble::P2:
                return Pebble::P1;
            default:
                throw std::invalid_argument("Can only negate P1 and P2");
        }
    }

    namespace Pebbles {

        constexpr int VALUES_SIZE = 3;

        constexpr std::array<Pebble, VALUES_SIZE> values = {
            Pebble::NO_PEBBLE, Pebble::P1, Pebble::P2
        };

        inline constexpr bool is_valid(Pebble pebble) {
            return pebble != Pebble::INVALID;
        }
        
        inline constexpr bool is_pebble(Pebble pebble) {
            return pebble == Pebble::P1 or pebble == Pebble::P2;
        }

        constexpr int CHARS_SIZE = 3;
        constexpr std::array<char, CHARS_SIZE> chars = {
            '.', 'x', '+'
        };

        inline constexpr char get_char(Pebble pebble) {
            switch (pebble) {
                case Pebble::NO_PEBBLE:
                case Pebble::P1:
                case Pebble::P2:
                    return chars[static_cast<int>(pebble)];
                default:
                    return ' ';
            }
        }

        inline constexpr Pebble from_char(char pebble) {
            switch (pebble) {
                case '.':
                    return Pebble::NO_PEBBLE;
                case 'x':
                    return Pebble::P1;
                case '+':
                    return Pebble::P2;
                default:
                    return Pebble::INVALID;
            }
        }

    }
}
