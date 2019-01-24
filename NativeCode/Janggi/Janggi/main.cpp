//
//  main.cpp
//  Janggi
//
//  Created by Viet Tho on 12/24/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include <string>
#include <cstdio>
#include <ctime>

using namespace std;

#include "defines.h"
#include "janggi.h"

#define ASCIIBASE 48

bool string2ints(string in, Pos& current, Pos& next);
void autoMode(Janggi& janggi);
void man2Computer(Janggi& janggi);
void manualMode(Janggi& janggi);

int main(int argc, const char * argv[])
{
    std::cout << "Hello, World!\n";
    srand(time(NULL));
    
    Janggi janggi;
    janggi.Print();
    
    int turn = 0;
    do {
        printf("turn: %d\n", turn);
        turn++;
        janggi.Print();
        
        // check finish
        {
            vector<Action> allLegalActions = janggi.rootNode.board.GetAllLegalActions(janggi.turn);
            printf("allLegalActions: %lu, %d\n", allLegalActions.size(), janggi.turn);
            if(allLegalActions.size()==0){
                printf("jiangqi finish: %d\n", janggi.turn);
                break;
            }
        }
        
        clock_t start = clock();
        SearchParam searchParam;
        {
            int mctsIteration = 100;
            int mctsSimulationDepth = 2;
            // find scale
            int totalPiece = janggi.rootNode.board.getPieceCount();
            printf("totalPiece: %d\n", totalPiece);
            // set
            {
                if(totalPiece>0){
                    searchParam.mctsIteration = mctsIteration*(32*32)/(totalPiece*totalPiece);
                    searchParam.mctsSimulationDepth = mctsSimulationDepth;
                }else{
                    printf("error, totalPiece 0\n");
                    searchParam.mctsIteration = mctsIteration;
                    searchParam.mctsSimulationDepth = mctsSimulationDepth;
                }
            }
        }
        Action action = janggi.MyCalculateNextAction(&searchParam);
        double duration = (clock() - start )/(double)CLOCKS_PER_SEC;
        cout << "calc time : " << duration << endl;
        printf("best : %d,%d -> %d,%d\n",
               action.prev.x,
               action.prev.y,
               action.next.x,
               action.next.y);
        
        // doMove
        if(janggi.rootNode.board.isLegalMove(action, janggi.turn)){
            janggi.MyPerformAction(action); //throws on error. use 'try-catch' to handle exception.
        }else{
            printf("error, why not legal move: %d, %d, %d, %d\n", action.prev.x, action.prev.y, action.next.x, action.next.y);
            vector<Action> allLegalActions = janggi.rootNode.board.GetAllLegalActions(janggi.turn);
            printf("allLegalActions: %lu, %d\n", allLegalActions.size(), janggi.turn);
            if(allLegalActions.size()>0){
                action = allLegalActions[0];
                janggi.MyPerformAction(action);
            }else{
                printf("error, why don't have any legal action\n");
            }
        }
        
    } while(1);
    
    return 1;
}
