#pragma once

#include <iostream>
#include <vector>
#include <string>
#include <cassert>
#include <string>
#include <sstream>

#include "chinese_checkers_pebble.hpp"
#include "chinese_checkers_hole.hpp"
#include "chinese_checkers_move.hpp"
#include "chinese_checkers_direction.hpp"
#include "chinese_checkers_value.hpp"

namespace ChineseCheckers
{

    namespace Positions {
        const std::string INITIAL_POSITION =
        "1"
        "11"
        "111"
        "1111"
        "0000000000000"
        "000000000000"
        "00000000000"
        "0000000000"
        "000000000"
        "0000000000"
        "00000000000"
        "000000000000"
        "0000000000000"
        "2222"
        "222"
        "22"
        "2"
        " "
        "x";

        const std::string END_POSITION =
        "2"
        "22"
        "222"
        "2222"
        "0000000000000"
        "000000000000"
        "00000000000"
        "0000000000"
        "000000000"
        "0000000000"
        "00000000000"
        "000000000000"
        "0000000000000"
        "1111"
        "111"
        "11"
        "1"
        " "
        "+";

        const std::string ONE_BEST_JUMP_P1 =
        "1"
        "10"
        "110"
        "1110"
        "0000000100000"
        "000000100000"
        "00000000000"
        "0000001000"
        "000000000"
        "0000000000"
        "00000000000"
        "000000000000"
        "0000000000000"
        "2222"
        "222"
        "22"
        "2"
        " "
        "x";

        const std::string ONE_BEST_JUMP_P2 =
        "1"
        "11"
        "111"
        "1111"
        "0000000000000"
        "000000000000"
        "00000000000"
        "0000000000"
        "000000000"
        "0000200000"
        "00000000000"
        "000002000000"
        "0000020000000"
        "0222"
        "022"
        "02"
        "2"
        " "
        "+";
    }

    constexpr int X_SIZE = 19, Y_SIZE = 19;

    class Board
    {
    public:
        std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;
        Pebble _turn;

    public:
        // Ctor
        explicit Board(const std::string &board_string = Positions::INITIAL_POSITION);

        // String rep.
        std::string to_string() const;
        
        void to_string(char* ret);
        
        void print(char* ret);

        // Moves.
        void make_move(const Move &move);

        void undo_move(const Move &move);

        // Score.
        Pebble get_winner() const;

        float score(int32_t pickBestMove) const;

        template<Pebble Us> int score_by_side() const;

        int score_absolute(int score) const;

        static int dist(const Hole &a, const Hole &b);

        // Board perimiters.
        inline constexpr static bool inside_board(int y, int x) {
            int sum = x + y;
            return (x <= 13 and y <= 13 and 14 <= sum and sum <= 26)
               or (5 <= x and 5 <= y and 10 <= sum and sum <= 22);
        }

        inline constexpr static bool inside_P1(int y, int x) {
            int sum = x + y;
            return 10 <= x and x <= 13 and 1 <= y and y <= 4
               and 14 <= sum and sum <= 17;
        }

        inline constexpr static bool inside_P2(int y, int x) {
            int sum = x + y;
            return 5 <= x and x <= 8 and 14 <= y and y <= 17
               and 19 <= sum and sum <= 22;
        }

        // Operators.
        inline bool operator== (const Board& rhs) const {
            return _squares == rhs._squares and _turn == rhs._turn;
        }
        
        inline bool operator!= (const Board& rhs) {
            return !(*this == rhs);
        }
        
        inline Pebble& operator() (int y, int x) {
            // assert(0 <= x and x < X_SIZE);
            if(!(0 <= x and x < X_SIZE)){
                printf("error, assert(0 <= x and x < X_SIZE): %d\n", x);
                x = 0;
            }
            // assert(0 <= y and y < Y_SIZE);
            if(!(0 <= y and y < Y_SIZE)){
                printf("error, assert(0 <= y and y < Y_SIZE): %d\n", y);
                y = 0;
            }
            return _squares[y][x];
        }
        
        inline const Pebble& operator() (int y, int x) const {
            // assert(0 <= x and x < X_SIZE);
            if(!(0 <= x and x < X_SIZE)){
                printf("error, assert(0 <= x and x < X_SIZE): %d\n", x);
                x = 0;
            }
            // assert(0 <= y and y < Y_SIZE);
            if(!(0 <= y and y < Y_SIZE)){
                printf("error, assert(0 <= y and y < Y_SIZE): %d\n", y);
                y = 0;
            }
            return _squares[y][x];
        }
        
        inline Pebble& operator() (const Hole& h) {
            auto x = h.x, y = h.y;
            // assert(0 <= x and x < X_SIZE);
            if(!(0 <= x and x < X_SIZE)){
                printf("error, assert(0 <= x and x < X_SIZE): %d\n", x);
                x = 0;
            }
            // assert(0 <= y and y < Y_SIZE);
            if(!(0 <= y and y < Y_SIZE)){
                printf("error, assert(0 <= y and y < Y_SIZE): %d\n", y);
                y = 0;
            }
            return _squares[y][x];
        }
        
        inline const Pebble& operator() (const Hole& h) const {
            auto x = h.x, y = h.y;
            // assert(0 <= x and x < X_SIZE);
            if(!(0 <= x and x < X_SIZE)){
                printf("error, assert(0 <= x and x < X_SIZE): %d\n", x);
                x = 0;
            }
            // assert(0 <= y and y < Y_SIZE);
            if(!(0 <= y and y < Y_SIZE)){
                printf("error, assert(0 <= y and y < Y_SIZE): %d\n", y);
                y = 0;
            }
            return _squares[y][x];
        }

        // Getters.
        inline Pebble get_turn() {
            return _turn;
        }

        // Display.
        friend std::ostream &operator<<(std::ostream &, const Board &);
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
    public:
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(Board* board, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Board* board, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };

}
