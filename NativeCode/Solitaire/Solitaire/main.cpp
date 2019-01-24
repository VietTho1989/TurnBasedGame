//
//  main.cpp
//  Solitaire
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <thread>
#include "Board.h"
#include <iostream>
#include "ArtificialPlayer.h"

/// <summary>
/// Runs a game of solitaire with AI input
/// </summary>
/// <param name="gameBoard">The solitaire game that is going to be played</param>
void runAI(Board *gameBoard)
{
    ArtificialPlayer myAI(gameBoard);
    
    char input[20]; // Input buffer
    
    gameBoard->printBoard();
    std::this_thread::sleep_for (std::chrono::seconds(1));
    
    do
    {
        gameBoard->printBoard();
        
        std::string command = myAI.getCommand();
        
        if (command == "EXIT")
            return;
        
        gameBoard->handle(command);
        std::cout << "\tAI says: " << command << "\n";
        
        std::this_thread::sleep_for (std::chrono::seconds(1));
    } while (gameBoard->isSet());
}


int main(int argc, const char * argv[]) {
    // insert code here...
    std::cout << "Hello, World!\n";
    
    Board myBoard; // Solitaire board
    // myBoard.setBoard();
    
    runAI(&myBoard);
    
    return 0;
}
