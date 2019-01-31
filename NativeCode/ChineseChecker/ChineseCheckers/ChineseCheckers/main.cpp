//
//  main.cpp
//  ChineseCheckers
//
//  Created by Viet Tho on 1/31/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include <iostream>
#include "chinese_checkers_ricefish.hpp"
#include "chinese_checkers_board.hpp"
#include "chinese_checkers_interface.hpp"

using namespace std;
using namespace ChineseCheckers;

int main() {
    // std::unique_ptr<ricefish::Ricefish> fish(new ricefish::Ricefish());
    // fish->run();
    
    Board board;
    self_play(board);
    
    return 0;
}
