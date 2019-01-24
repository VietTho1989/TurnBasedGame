//
//  main.cpp
//  Khet
//
//  Created by Viet Tho on 12/18/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "CommsHandler.h"
#include "Tests/TestBase.h"
#include "Tests/MoveGenTest.h"
#include "Tests/MakeMoveTest.h"
#include "Tests/TerminationTest.h"
#include "Tests/TestRunner.h"
#include <iostream>
#include <string>

// Count the number of moves available in the position.
int CountMoves(const Board& board)
{
    MoveGenerator gen(board);
    int count = 0;
    Move move = NoMove;
    while ((move = gen.Next()) != NoMove)
    {
        // std::cout << GetStart(move) << " " << GetEnd(move) << " " << GetRotation(move) << std::endl;
        ++count;
    }
    
    return count;
}

int main(int argc, const char * argv[]) {
    printf("hello world\n");
    // insert code here...
    if (argc == 2 && std::string(argv[1]) == "test")
    {
        // Execute the unit tests.
        TestRunner runner;
        runner.RunTests<MoveGenTest>();
        runner.RunTests<MakeMoveTest>();
        runner.RunTests<TerminationTest>();
    }
    else
    {
        // Start listening for commands.
        /*CommsHandler handler;
        std::string message;
        while (std::getline(std::cin, message) && handler.Process(message));*/
        
        TT _table;
        
        _table.Clear();
        Board _board("x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0");
        printf("%s\n", _board.ToString().c_str());
        printf("MaxGameLength: %d\n", MaxGameLength);
        // search
        int turn = 0;
        do{
            printf("turn: %d, %d, %d\n", turn, _board.IsCheckmate(), _board.IsDraw());
            printf("Count Moves: %d\n", CountMoves(_board));
            SearchParams params;
            {
                // neu depth = 0 thi moveTime moi co tac dung
                params._infinite = false;
                params._moveTime = 3000;
                params._depth = 0;
            }
            _table.Age();
            Search _search;
            int score = 0;
            Move bestMove = _search.Start(_table, params, _board, score);
            printf("score: %d, bestMove: %d\n", score, bestMove);
            printf("%s\n", _board.ToString().c_str());
            turn++;
            if(bestMove==0 || turn>=2000){
                printf("bestMove 0\n");
                // find a legal move
                 Move move = NoMove;
                {
                    MoveGenerator gen(_board);
                    while ((move = gen.Next()) != NoMove)
                    {
                        break;
                    }
                }
                if(move!=NoMove){
                    printf("make a legal move\n");
                    _board.MakeMove(move);
                }else{
                    printf("error, don't have any legal move");
                    break;
                }
            }else{
                _board.MakeMove(bestMove);
            }
        }while (true);
    }
    
    return 0;
}

/*
************
*xP...k.p..*
*.....a...P*
*.....sp...*
*..........*
*.p..Ss....*
*p.....S...*
*..P.......*
*...P..K..X*
************

************
*22...0.1..*
*.....1...2*
*.....01...*
*..........*
*.0..12....*
*0.....3...*
*..3.......*
*...3..0..0*
************
*/

/*
 ************
 *x...ak.p..*
 *......a...*
 *...P......*
 *.P...p...P*
 *..A.p.....*
 *p.s..S....*
 *.....SA..P*
 *....Ks...X*
 ************
 
 ************
 *2...20.1..*
 *......2...*
 *...3......*
 *.3...1...3*
 *..0.2.....*
 *0.0..1....*
 *.....11..2*
 *....01...0*
 ************
*/
