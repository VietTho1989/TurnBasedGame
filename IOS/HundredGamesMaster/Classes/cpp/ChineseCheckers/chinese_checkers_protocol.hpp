#pragma once

#include "chinese_checkers_movelist.hpp"

namespace ChineseCheckers
{

    class Protocol {
    public:
        virtual ~Protocol() = default;
        
        virtual void send_best_move(Move best_move, Move ponder_move) = 0;
        
        virtual void send_status(
                                 int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move,
                                 int current_move_number) = 0;
        
        virtual void send_status(
                                 bool force, int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move,
                                 int current_move_number) = 0;
        
        virtual void send_move(RootEntry entry, int current_depth, int current_max_depth, uint64_t total_nodes) = 0;
    };

}
