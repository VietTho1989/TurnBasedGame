#pragma once

#include <memory>
#include <cstdint>
#include "search.hpp"
#include "protocol.hpp"
#include "board.hpp"

namespace ricefish {

class Ricefish : public Protocol {
public:
    void run();

    void send_best_move(Move best_move, Move ponder_move) final;

    void send_status(
            int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move,
            int current_move_number) final;

    void send_status(
            bool force, int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move,
            int current_move_number) final;

    void send_move(RootEntry entry, int current_depth, int current_max_depth, uint64_t total_nodes) final;

    static std::string from_move(const Move& move);

private:
    std::unique_ptr<Search> search = std::make_unique<Search>(*this);
    std::chrono::system_clock::time_point start_time;
    std::chrono::system_clock::time_point status_start_time;

    std::unique_ptr<Board> current_position = std::make_unique<Board>(Board());

    void receive_initialize();

    void receive_ready();

    void receive_new_game();

    void receive_position(std::istringstream &input);

    void receive_go(std::istringstream &input);

    void receive_ponder_hit();

    void receive_stop();

    void receive_print();

    void receive_string();

    void receive_quit();

};

}