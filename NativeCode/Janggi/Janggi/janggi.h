#ifndef JANGGI_H
#define JANGGI_H

#include "defines.h"
#include "board.h"
#include "node.h"

#define DEBUG_MCTS 0

class Janggi{ // almost utility class.
public:
    const Action CalculateNextAction(Turn turn, SearchParam* searchParam);
    Node Minmax(Node n, int depth, Turn turn, SearchParam* searchParam);
    Node AlphaBeta(Node node, int depth, int alpha, int beta, Turn turn, SearchParam* searchParam);
    Node MCTS(Turn turn, SearchParam* searchParam);
    double Simulation(Node n, Turn turn, SearchParam* searchParam);
    void Print();
    void PerformAction(Action a);
    
public:
    Node rootNode;
    
public:
    Turn turn = TURN_CHO;
    
    const Action MyCalculateNextAction(SearchParam* searchParam);
    
    void MyPerformAction(Action a);
    
};

#endif /* JANGGI_H */
