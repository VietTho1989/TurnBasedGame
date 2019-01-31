#include <iostream>
#include <sstream>
#include <vector>
#include <chrono>
#include <algorithm>
#include <cstdint>

#include "chinese_checkers_ricefish.hpp"
//#include "projectmeta.hpp"
//#include "benchmark.hpp"

namespace ChineseCheckers
{

    void Ricefish::run() {
        std::cin.exceptions(std::iostream::eofbit | std::iostream::failbit | std::iostream::badbit);
        while (true) {
            std::string line;
            std::getline(std::cin, line);
            std::istringstream input(line);
            
            std::string token;
            input >> std::skipws >> token;
            if (token == "uci") {
                receive_initialize();
            } else if (token == "isready") {
                receive_ready();
            } else if (token == "ucinewgame") {
                receive_new_game();
            } else if (token == "position") {
                receive_position(input);
            } else if (token == "go") {
                receive_go(input);
            } else if (token == "stop") {
                receive_stop();
            } else if (token == "ponderhit") {
                receive_ponder_hit();
            } else if (token == "print") {
                receive_print();
            } else if (token == "string") {
                receive_string();
            } else if (token == "quit") {
                receive_quit();
                break;
            }
        }
    }
    
    void Ricefish::receive_quit() {
        // We received a quit command. Stop calculating now and
        // cleanup!
        search->quit();
    }
    
    void Ricefish::receive_initialize() {
        search->stop();
        
        // We received an initialization request.
        
        // We could do some global initialization here. Probably it would be best
        // to initialize all tables here as they will exist until the end of the
        // program.
        
        // We must send an initialization answer back!
        std::cout << "id name Ricefish v0.1\n";// << PROJECT_VERSION_MAJOR << "." << PROJECT_VERSION_MINOR << '\n';
        std::cout << "id author Bendik Samseth" << '\n';
        std::cout << "uciok" << std::endl;
    }
    
    void Ricefish::receive_ready() {
        // We received a ready request. We must send the token back as soon as we
        // can. However, because we launch the search in a separate thread, our main
        // thread is able to handle the commands asynchronously to the search. If we
        // don't answer the ready request in time, our engine will probably be
        // killed by the GUI.
        std::cout << "readyok" << std::endl;
    }
    
    void Ricefish::receive_new_game() {
        search->stop();
        
        // We received a new game command.
        
        // Initialize per-game settings here.
        *current_position = Board();
    }
    
    void Ricefish::receive_position(std::istringstream &input) {
        search->stop();
        
        // We received an position command. Just setup the position.
        
        std::string token;
        input >> token;
        if (token == "startpos") {
            *current_position = Board();
            
            if (input >> token) {
                if (token != "moves") {
                    throw std::invalid_argument("Unrecognized command: " + token);
                }
            }
        } else if (token == "fen") {
            std::string fen;
            
            while (input >> token) {
                if (token == "moves") {
                    break;
                } else {
                    fen += token + " ";
                }
            }
            
            *current_position = Board(fen);
        } else {
            throw std::invalid_argument("Bad position command.");
        }
        
        MoveGenerator move_generator;
        
        while (input >> token) {
            // Verify moves
            MoveList<MoveEntry> &moves = move_generator.get_moves(*current_position);
            bool found = false;
            for (const auto& e : moves) {
                Move move = e->move;
                std::stringstream move_string;
                move_string << move;
                if (move_string.str() == token) {
                    current_position->make_move(move);
                    found = true;
                    break;
                }
            }
            
            if (!found) {
                throw std::invalid_argument("Suggested move is not legal: " + token + " position " + current_position->to_string());
            }
        }
        
        // Don't start searching though!
    }
    
    void Ricefish::receive_go(std::istringstream &input) {
        search->stop();
        
        // We received a start command. Extract all parameters from the
        // command and start the search.
        std::string token;
        input >> token;
        if (token == "depth") {
            int search_depth;
            if (input >> search_depth) {
                search->new_depth_search(*current_position, search_depth);
            } else {
                throw std::invalid_argument("Missing depth parameter.");
            }
        } else if (token == "nodes") {
            uint64_t search_nodes;
            if (input >> search_nodes) {
                search->new_nodes_search(*current_position, search_nodes);
            }
        } else if (token == "movetime") {
            uint64_t search_time;
            if (input >> search_time) {
                search->new_time_search(*current_position, search_time);
            }
        } else if (token == "infinite") {
            search->new_infinite_search(*current_position);
        } else {
            uint64_t white_time_left = 1;
            uint64_t white_time_increment = 0;
            uint64_t black_time_left = 1;
            uint64_t black_time_increment = 0;
            int search_moves_toGo = 40;
            bool ponder = false;
            
            do {
                if (token == "wtime") {
                    if (!(input >> white_time_left)) {
                        throw std::invalid_argument("Missing wtime parameter.");
                    }
                } else if (token == "winc") {
                    if (!(input >> white_time_increment)) {
                        throw std::invalid_argument("Missing winc parameter.");
                    }
                } else if (token == "btime") {
                    if (!(input >> black_time_left)) {
                        throw std::invalid_argument("Missing btime parameter.");
                    }
                } else if (token == "binc") {
                    if (!(input >> black_time_increment)) {
                        throw std::invalid_argument("Missing binc parameter.");
                    }
                } else if (token == "movestogo") {
                    if (!(input >> search_moves_toGo)) {
                        throw std::invalid_argument("Missing movestogo parameter.");
                    }
                } else if (token == "ponder") {
                    ponder = true;
                }
            } while (input >> token);
            
            if (ponder) {
                search->new_ponder_search(*current_position,
                                          white_time_left, white_time_increment, black_time_left, black_time_increment,
                                          search_moves_toGo);
            } else {
                search->new_clock_search(*current_position,
                                         white_time_left, white_time_increment, black_time_left, black_time_increment,
                                         search_moves_toGo);
            }
        }
        
        // Go...
        search->start();
        start_time = std::chrono::system_clock::now();
        status_start_time = start_time;
    }
    
    void Ricefish::receive_ponder_hit() {
        // We received a ponder hit command. Just call ponderhit().
        search->ponderhit();
    }
    
    void Ricefish::receive_stop() {
        // We received a stop command. If a search is running, stop it.
        search->stop();
    }
    
    void Ricefish::send_best_move(Move best_move, Move ponder_move) {
        std::cout << "bestmove ";
        
        if (best_move != Moves::NO_MOVE) {
            std::cout << from_move(best_move);
            
            if (ponder_move != Moves::NO_MOVE) {
                std::cout << " ponder " << from_move(ponder_move);
            }
        } else {
            std::cout << "NO_MOVE";
        }
        
        std::cout << std::endl;
    }
    
    void Ricefish::send_status(
                               int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move, int current_move_number) {
        if (std::chrono::duration_cast<std::chrono::milliseconds>(
                                                                  std::chrono::system_clock::now() - status_start_time).count() >= 1000) {
            send_status(false, current_depth, current_max_depth, total_nodes, current_move, current_move_number);
        }
    }
    
    void Ricefish::send_status(
                               bool force, int current_depth, int current_max_depth, uint64_t total_nodes, Move current_move,
                               int current_move_number) {
        auto time_delta = std::chrono::duration_cast<std::chrono::milliseconds>(
                                                                                std::chrono::system_clock::now() - start_time);
        
        if (force || time_delta.count() >= 1000) {
            std::cout << "info";
            std::cout << " depth " << current_depth;
            std::cout << " seldepth " << current_max_depth;
            std::cout << " nodes " << total_nodes;
            std::cout << " time " << time_delta.count();
            std::cout << " nps " << (time_delta.count() >= 1000 ? (total_nodes * 1000) / time_delta.count() : 0);
            
            if (current_move != Moves::NO_MOVE) {
                std::cout << " currmove " << from_move(current_move);
                std::cout << " currmovenumber " << current_move_number;
            }
            
            std::cout << std::endl;
            
            status_start_time = std::chrono::system_clock::now();
        }
    }
    
    void Ricefish::send_move(RootEntry entry, int current_depth, int current_max_depth, uint64_t total_nodes) {
        auto time_delta = std::chrono::duration_cast<std::chrono::milliseconds>(
                                                                                std::chrono::system_clock::now() - start_time);
        
        std::cout << "info";
        std::cout << " depth " << current_depth;
        std::cout << " seldepth " << current_max_depth;
        std::cout << " nodes " << total_nodes;
        std::cout << " time " << time_delta.count();
        std::cout << " nps " << (time_delta.count() >= 1000 ? (total_nodes * 1000) / time_delta.count() : 0);
        
        std::cout << " score cp " << entry.value;
        
        if (entry.pv.size > 0) {
            std::cout << " pv";
            for (int i = 0; i < entry.pv.size; i++) {
                std::cout << " " << from_move(entry.pv.moves[i]);
            }
        }
        
        std::cout << std::endl;
        
        status_start_time = std::chrono::system_clock::now();
    }
    
    std::string Ricefish::from_move(const Move& move) {
        std::stringstream ss;
        ss << move;
        return ss.str();
    }
    
    void Ricefish::receive_print() {
        std::cout << *current_position << std::endl;
    }
    
    void Ricefish::receive_string() {
        std::cout << current_position->to_string() << std::endl;
    }

}
