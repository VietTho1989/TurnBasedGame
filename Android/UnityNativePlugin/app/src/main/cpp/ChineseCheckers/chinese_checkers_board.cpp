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
    
    void Board::to_string(char* ret)
    {
        ret[0] = 0;
        for (const Hole& hole : Holes::valid_holes) {
            const auto p = (*this)(hole);
            sprintf(ret, "%s%c", ret, (p == Pebble::P1 ? '1' : p == Pebble::P2 ? '2' : '0'));
        }
        sprintf(ret, "%s %c", ret, Pebbles::get_char(_turn));
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
    
    void Board::print(char* ret)
    {
        ret[0] = 0;
        for (int y = 0; y < Y_SIZE; ++y) {
            // strm << std::setw(2) << (char) ('A' + y) << "|";
            sprintf(ret, "%s  %c|", ret, (char) ('A' + y));
            for (int x = 0; x < X_SIZE; ++x) {
                // strm << Pebbles::get_char(b(y, x)) << ' ';
                sprintf(ret, "%s%c ", ret, Pebbles::get_char((*this)(y, x)));
            }
            // strm << '\n';
            sprintf(ret, "%s\n", ret);
        }
        
        // strm << "   ";
        sprintf(ret, "%s   ", ret);
        for (int x = 0; x < X_SIZE; ++x) {
            // strm << "--";
            sprintf(ret, "%s--", ret);
        }
        // strm << "\n   ";
        sprintf(ret, "%s\n   ", ret);
        for (char x = 0; x < X_SIZE; ++x) {
            // strm << (char) ('a' + x) << ' ';
            sprintf(ret, "%s%c ", ret, (char) ('a' + x));
        }
    }
    
    void Board::make_move(const Move &move) {
        
        // assert((*this)(move.from) == _turn);
        if((*this)(move.from) != _turn){
            printf("error, assert((*this)(move.from) == _turn)\n");
        }
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
    
    int Board::score_absolute(int score) const
    {
        return _turn == Pebble::P1 ? score : -score;
    }
    
    float Board::score(int32_t pickBestMove) const
    {
        int32_t score = (_turn == Pebble::P1 ? score_by_side<Pebble::P1>() : score_by_side<Pebble::P2>());
        // printf("score: %d\n", score);
        if(pickBestMove>=0 && pickBestMove<100){
            if(score>-Value::MATE && score<Value::MATE){
                float random = rand() % (100-pickBestMove);
                float newScore = score*(100-random)/100;
                // printf("random: %f, %f, %f\n", score, newScore, random);
                return newScore;
            }else{
                return score;
            }
        }else {
            return score;
        }
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
    
    template<Pebble Us> int Board::score_by_side() const {
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
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Board::getByteSize()
    {
        int32_t ret = 0;
        {
            // std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;
            ret+= sizeof(int8_t)*X_SIZE*Y_SIZE;
            // Pebble _turn;
            ret+= sizeof(int8_t);
        }
        return ret;
    }
    
    int32_t Board::convertToByteArray(Board* board, uint8_t* &byteArray)
    {
        int32_t length = Board::getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;
            {
                int32_t size = sizeof(uint8_t);
                for(int32_t y=0; y<Y_SIZE; y++)
                    for(int32_t x=0; x<X_SIZE; x++){
                        if(pointerIndex+size<=length){
                            uint8_t value = (uint8_t)board->_squares[y][x];
                            memcpy(ret + pointerIndex, &value, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: spot: %d, %d\n", pointerIndex, length);
                        }
                    }
            }
            // Pebble _turn;
            {
                int32_t size = sizeof(uint8_t);
                if(pointerIndex+size<=length){
                    uint8_t turn = (uint8_t)board->_turn;
                    memcpy(ret + pointerIndex, &turn, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Board::parseByteArray(Board* board, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;
                    int32_t size = sizeof(uint8_t);
                    for(int32_t y=0; y<Y_SIZE; y++)
                        for(int32_t x=0; x<X_SIZE; x++){
                            if(pointerIndex+size<=length){
                                uint8_t value = 0;
                                memcpy(&value, bytes + pointerIndex, size);
                                board->_squares[y][x] = (Pebble)value;
                                pointerIndex+=size;
                            }else{
                                printf("length error: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                }
                    break;
                case 1:
                {
                    // Pebble _turn;
                    int32_t size = sizeof(uint8_t);
                    if(pointerIndex+size<=length){
                        uint8_t value = 0;
                        memcpy(&value, bytes + pointerIndex, size);
                        board->_turn = (Pebble)value;
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        if(canCorrect){
            
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }

}
