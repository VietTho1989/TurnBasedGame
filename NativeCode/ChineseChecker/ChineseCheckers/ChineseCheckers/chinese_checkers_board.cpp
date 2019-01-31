#include <cassert>
#include <cmath>
#include <iomanip>
#include <string>
#include <sstream>

#include "chinese_checkers_board.hpp"


namespace ChineseCheckers
{

    Board::Board(const std::string& str) {
        std::stringstream ss(str);  // Using a sstream to split by whitespace.
        std::string board_string;
        char turn;
        ss >> board_string >> turn;
        
        // Set the turn.
        _turn = Pebbles::from_char(turn);
        
        // Fill squares.
        int i = 0;
        for (int y = 0; y < Y_SIZE; ++y) {
            for (int x = 0; x < X_SIZE; ++x) {
                if (inside_board(y, x)) {
                    (*this)(y, x) = board_string[i] == '0' ? Pebble::NO_PEBBLE
                    : (board_string[i] == '1' ? Pebble::P1 : Pebble::P2);
                    i++;
                } else {
                    (*this)(y, x) = Pebble::INVALID;
                }
            }
        }
    }
    
    std::string Board::to_string() const {
        std::ostringstream oss;
        for (const Hole& hole : Holes::valid_holes) {
            const auto p = (*this)(hole);
            oss << (p == Pebble::P1 ? '1' :
                    p == Pebble::P2 ? '2' : '0');
        }
        oss << ' ' << Pebbles::get_char(_turn);
        return oss.str();
    }
    
    
    std::ostream &operator<<(std::ostream &strm, const Board &b) {
        for (int y = 0; y < Y_SIZE; ++y) {
            strm << std::setw(2) << (char) ('A' + y) << "|";
            for (int x = 0; x < X_SIZE; ++x) {
                strm << Pebbles::get_char(b(y, x)) << ' ';
            }
            strm << '\n';
        }
        
        strm << "   ";
        for (int x = 0; x < X_SIZE; ++x) strm << "--";
        strm << "\n   ";
        for (char x = 0; x < X_SIZE; ++x) {
            strm << (char) ('a' + x) << ' ';
        }
        return strm;
    }
    
    void Board::make_move(const Move &move) {
        
        assert((*this)(move.from) == _turn);
        (*this)(move.to) = (*this)(move.from);
        (*this)(move.from) = Pebble::NO_PEBBLE;
        _turn = ~_turn;
    }
    
    void Board::undo_move(const Move &move) {
        _turn = ~_turn;
        (*this)(move.from) = _turn;
        (*this)(move.to) = Pebble::NO_PEBBLE;
    }
    
    Pebble Board::get_winner() const {
        int p1_count = 0;
        int p2_count = 0;
        for (const Hole& hole : Holes::valid_holes) {
            const auto p = (*this)(hole);
            if (p == Pebble::P1)
                p1_count += inside_P2(hole.y, hole.x);
            else if (p == Pebble::P2)
                p2_count += inside_P1(hole.y, hole.x);
        }
        if (p1_count == 10)
            return Pebble::P1;
        else if (p2_count == 10)
            return Pebble::P2;
        else
            return Pebble::NO_PEBBLE;
    }
    
    int Board::score_absolute(int score) const {
        return _turn == Pebble::P1 ? score : -score;
    }
    
    int Board::score() const {
        int32_t score = (_turn == Pebble::P1 ? score_by_side<Pebble::P1>() : score_by_side<Pebble::P2>());
        // printf("score: %d\n", score);
        return score;
    }
    
    int Board::dist(const Hole &a, const Hole &b) {
        int diag_steps = 0;
        Hole delta = a - b;
        int adx = std::abs(delta.x), ady = std::abs(delta.y);
        if (delta.x * delta.y < 0) {
            diag_steps = std::min(adx, ady);
        }
        return adx + ady - diag_steps;
    }
    
    template<Pebble Us>
    int Board::score_by_side() const {
        constexpr const Pebble Them = ~Us;
        constexpr const Hole &our_goal = Us == Pebble::P1 ? Holes::P2_HOME : Holes::P1_HOME;
        constexpr const Hole &their_goal = Us == Pebble::P1 ? Holes::P1_HOME : Holes::P2_HOME;
        
        int our_dist = 0, their_dist = 0;
        for (const Hole& hole : Holes::valid_holes) {
            if ((*this)(hole) == Us)
                our_dist += dist(hole, our_goal);
            else if ((*this)(hole) == Them)
                their_dist += dist(hole, their_goal);
        }
        //
        if (our_dist <= 20 and their_dist <= 20)
            return 0;  // Draw.
        else if (our_dist <= 20)
            return Value::MATE;  // Win.
        else if (their_dist <= 20)
            return -Value::MATE;  // Loss.
        else
            return their_dist - our_dist;
    }

}
