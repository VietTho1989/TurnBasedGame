//
//  main.cpp
//  nmm
//
//  Created by Viet Tho on 1/2/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include <iostream>
#include <stdio.h>
#include <chrono>
#include <sys/timeb.h>

#include "Platform.h"
#include "nmmagent.h"
#include "board.h"
#include <cstring>

bool finish(SmrtState root, bool &white_win, bool white_turn)
{
    if(root->terminal)
    {
        white_win = root->white_win;
        return true;
    }
    return false;
}

SmrtState ai_player(NMMAgent *a, SmrtState curr, bool unused, GamePhase phase, int random_level)
{
    if(random_level > 1)
    {
        std::vector<SmrtState> suc = a->expand(curr, a->get_color_pieces());
        curr = suc[rand()%random_level%suc.size()];
    }
    else
    {
        curr = a->decide(curr);
    }
    return curr;
}

int main(int argc, const char * argv[]) {
    // insert code here...
    std::cout << "Hello, World!\n";
    
    srand(now());
    int turn = 0;
    
    //agent 1
    NMMAgent* a = new NMMAgent();
    int aphase1[6] = {18, 26, 1, 6, 12, 7};
    int aphase2[7] = {14, 43, 10, 8, 7, 47, 1086};
    int aphase3[4] = {10, 1, 16, 1190};
    a->set_evaluator_weights(aphase1, aphase2, aphase3);
    a->set_color_pieces(true);
    
    //agent 2
    NMMAgent* b = new NMMAgent();
    int bphase1[6] = {18, 26, 1, 6, 21, 7};
    int bphase2[7] = {42, 28, 16, 8, 24, 19, 949};
    int bphase3[4] = {23, 18, 5, 1096};
    b->set_evaluator_weights(bphase1, bphase2, bphase3);
    b->set_color_pieces(false);
    /*b->eval->pickBestMove = 0;
    {
        b->MaxNormal = 1;
        b->MaxPositioning = 1;
        b->MaxBlackAndWhite3 = 1;
        b->MaxBlackOrWhite3 = 1;
    }*/
    
    SmrtState root = SmrtState(new State(SmrtBoard(new Board()), 0, Place, 0, false, false));
    // bool white_win = false;
    bool white_turn = true;
    auto player1 = ai_player;
    auto player2 = ai_player;
    
    int DrawTurn = 500;
    
    while(!root->terminal)
    {
        printf("root utility: %f\n", root->utility);
        if(white_turn)
            root = player1(a, root, white_turn, a->get_game_phase(), 1);
        else
            root = player2(b, root, white_turn, b->get_game_phase(), 1);
        
        ++turn;
        if(turn > DrawTurn)
            break;
        std::cout << "TURNO: " << turn << (white_turn? " W\t" : " B\t") << root << "\n";
        std::cout << root->board << "\n\n";
        if(turn == 18)
        {
            std::cout << "Positioning Over - Playing started\n";
            a->set_game_phase(Playing);
            b->set_game_phase(Playing);
        }
        white_turn = !white_turn;
    }
    
    printf("root terminal: %s, so %s\n", white_turn? "white turn" : "black turn", white_turn ? "black win" : "white win");
    
    return 0;
}

/*
  ---------- ----------B
 |          |          |
 |   B------ ------W   |
 |   |      |      |   |
 |   |    -- --    |   |
 |   |   |     |   |   |
 W---B---       ---W---W
 |   |   |     |   |   |
 |   |    -- --    |   |
 |   |      |      |   |
 |    ------B------W   |
 |          |          |
  ---------- ----------
 
 ---------- ----------
 |          |          |
 |    ------W------W   |
 |   |      |      |   |
 |   |    -- --    |   |
 |   |   |     |   |   |
 W---W---W      ---W---
 |   |   |     |   |   |
 |   |    --W--    |   |
 |   |      |      |   |
 |    ------W------    |
 |          |          |
 B----------W----------B
 
 ----------W----------
 |          |          |
 |   B------W------B   |
 |   |      |      |   |
 |   |   W--B--B   |   |
 |   |   |     |   |   |
 ---W---B     W---W---W
 |   |   |     |   |   |
 |   |   B--B--W   |   |
 |   |      |      |   |
 |   B------W------    |
 |          |          |
 ---------- ----------
 
*/
