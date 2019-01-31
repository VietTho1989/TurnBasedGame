#pragma once

#include <array>
#include <memory>
#include "chinese_checkers_move.hpp"
#include "chinese_checkers_depth.hpp"
#include "chinese_checkers_value.hpp"
#include "chinese_checkers_board.hpp"

namespace ChineseCheckers
{

    /**
     * This class stores our moves for a specific position. For the root node we
     * will populate pv for every root move.
     */
    template<class T> class MoveList {
    private:
        static const int MAX_MOVES = 2048;
        
    public:
        std::array<std::shared_ptr<T>, MAX_MOVES> entries;
        int size = 0;
        
        MoveList() {
            for (unsigned i = 0; i < entries.size(); i++) {
                entries[i] = std::shared_ptr<T>(new T());
            }
        }
        
        void add(Move m) {
            entries[size++]->move = m;
        }
        
        /**
         * Sorts the move list using a stable insertion sort.
         */
        void sort() {
            for (int i = 1; i < size; i++) {
                std::shared_ptr<T> entry(entries[i]);
                
                int j = i;
                while ((j > 0) && (entries[j - 1]->value < entry->value)) {
                    entries[j] = entries[j - 1];
                    j--;
                }
                
                entries[j] = entry;
            }
        }
        
        void rate() {
            for (int i = 0; i < size; i++) {
                const Move& move = entries[i]->move;
                entries[i]->value = Board::dist(move.from, move.to);
            }
        }
        
        bool contains(const Move& move) {
            for (int i = 0; i < size; i++)
                if (entries[i]->move == move)
                    return true;
            return false;
        }
        
        
        // Defining necessary operations to allow
        // for (Move m : move_list) ...
        
        struct Iterator {
            int i;
            const MoveList& container;
            
            Iterator& operator++ () {
                ++i;
                return *this;
            }
            bool operator!= (const Iterator other) {
                return i != other.i;
            }
            auto& operator* () {
                return container.entries[i];
            }
        };
        
        constexpr auto begin() {
            return Iterator{0, *this};
        }
        auto end() {
            return Iterator{size, *this};
        }
    };
    
    class MoveVariation {
    public:
        std::array<Move, Depth::MAX_PLY> moves;
        int size = 0;
    };
    
    class MoveEntry {
    public:
        Move move = Moves::NO_MOVE;
        int value = Value::NO_VALUE;
    };
    
    class RootEntry : public MoveEntry {
    public:
        MoveVariation pv;
    };

}
