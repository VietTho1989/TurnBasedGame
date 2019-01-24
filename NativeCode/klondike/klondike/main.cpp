//
//  main.cpp
//  klondike
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//


#include <cassert>
#include <iostream>
#include <sstream>
#include <random>
#include <chrono>
#include <algorithm>
#include <queue>
#include <vector>
#include <functional>
#include <unordered_set>
#include <chrono>
#include "klondike.h"
#include "astar.h"
    
int main(int argc, const char * argv[]) {
    Deck deck;
    if(argc > 1) {
        unsigned seed = atoll(argv[1]);
        deck = Deck(seed);
    }
    GameState game(deck);
    std::cout << "Game #" << deck.getSeed() << std::endl << std::endl;
    std::unordered_set<GameState> history;
        
    for(size_t move=0;;++move) {
        // history
        {
            history.clear();
            history.insert(game);
        }
        // successor
        {
            printf("successor: %lu\n", game.successors().size());
        }
        astar::IDAStar<GameState,std::function<unsigned(const GameState&)>> as(game, &naiveHeuristic, history);
        std::cout << "\x1b[2J\x1b[H";
        std::cout << "Move #" << move << "\tHeuristic: " << naiveHeuristic(game) << std::endl << std::endl;
        std::cout << game << std::endl;
        if(as.isDone()) {
            printf("as isDone\n");
            break;
        }
        auto result = as.solve(1000, 1, [&as](const astar::SearchNode<GameState>& state, const astar::AStar<GameState,std::function<unsigned(const GameState&)>>& as, unsigned depthLimit)->bool{
            if((as.getNodesExpanded() - 1) % 5000 == 0) {
                // std::cout << "\x1b[2K";
                // std::cout << "\rSearching: Depth " << state.getPathCost() << ", F-Cost " << state.getFCost() << ", Queue Size " << as.getQueueSize() << ", Depth Limit " << depthLimit;// << next.getState();
                std::cout.flush();
            }
            return true;
        });
        printf("isGameFinish: %d\n", as.isGameFinish([&as](const astar::SearchNode<GameState>& state, const astar::AStar<GameState,std::function<unsigned(const GameState&)>>& as, unsigned depthLimit)->bool{
            return true;
        }));
        if(result) {
            Move initialMove = *result.getInitialMove();
                
            // assert(initialMove.type != MoveType::DEAL);
            if (initialMove.type == MoveType::DEAL) {
                printf("error, assert(initialMove.type != MoveType::DEAL)\n");
            } else{
                game = game.applyMove(initialMove);
            }
        } else {
            std::cout << "No solution found!" << std::endl;
            break;
        }
        if(move>=1000){
            printf("too many moes\n");
            break;
        }
    }
    return 0;
}
