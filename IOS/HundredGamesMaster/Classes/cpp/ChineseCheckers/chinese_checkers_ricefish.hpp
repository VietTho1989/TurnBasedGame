#pragma once

#include <memory>
#include <cstdint>
#include "chinese_checkers_search.hpp"
#include "chinese_checkers_protocol.hpp"
#include "chinese_checkers_board.hpp"

namespace ChineseCheckers
{

    class Ricefish : public Protocol
    {
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
    
    class MyProtocol : public Protocol
    {
        
    public:
        Move bestMove;
        Move ponderMove;
        
        bool isFinishSearch = false;
        
        void send_best_move(Move best_move, Move ponder_move)
        {
            // printf("send_best_move\n");
            // std::__1::cout<<best_move << " " << ponder_move;
            // bestMove
            {
                this->bestMove.from.x = best_move.from.x;
                this->bestMove.from.y = best_move.from.y;
                this->bestMove.to.x = best_move.to.x;
                this->bestMove.to.y = best_move.to.y;
            }
            // ponderMove
            {
                this->ponderMove.from.x = ponder_move.from.x;
                this->ponderMove.from.y = ponder_move.from.y;
                this->ponderMove.to.x = ponder_move.to.x;
                this->ponderMove.to.y = ponder_move.to.y;
            }
            isFinishSearch = true;
        }
        
        void send_status(int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move, int current_move_number)
        {
            
        }
        
        void send_status(bool force, int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move, int current_move_number)
        {
            
        }
        
        void send_move(RootEntry entry, int current_depth, int current_max_depth, uint64_t total_nodes)
        {
            
        }
        
    };

}
