//
//  node.cpp
//
//  Created by pilhoon on 1/18/16.
//

#ifndef node_cpp
#define node_cpp

#include <vector>
#include <cassert>
#include <iostream>
#include <cstdlib>
#include <ctime>
#include <cmath>

#include "node.h"
#include "board.h"

Node::Node() : isLeaf(true), totalScore(0.0f), visitCount(0) {
  
}

Node::Node(const Node& n){
    board = n.board;
    action = n.action;
    leafValue = n.leafValue;

    isLeaf = true;
    children.resize((int)(n.children.size()));
    std::copy(n.children.begin(), n.children.end(), children.begin());
    totalScore = n.totalScore;
} // copy ctor

Node::Node(Board b) :Node() {
	board = b;
};

void Node::Init()
{
  leafValue = 0;
  children.clear();
  isLeaf = true;
}

double Node::Rand_i()
{
  return static_cast<double>(rand() % RAND_MAX) / RAND_MAX;
}

int Node::GetValue() {
    return board.GetValue();
}

vector<Node> Node::GetChildren(Turn turn) {
  if (isLeaf)
    Expand(turn);
  return children;	
}

void Node::Print() {
    string s = board.ToString(action.prev);
    std::cout << s;
}

void Node::DoAction(Action a) {
    action = a;
    board.DoAction(a);
}

int Node::Selection(Turn turn)
{
    // Ensure this is not a leaf node.
    assert(children.size() != 0);
    // printf("SetSelection: %lu\n", children.size());
    if(children.size() == 0){
        printf("error, assert(children.size() != 0)\n");
        return 0;
    }
  
    int selected = 0;

#if 0
    selected = rand() % children.size();
#else
    double bestValue = -std::numeric_limits<double>::max();
    for (int k = 0; k < children.size(); k++) {

        Node* pCur = GetChild(k);
        assert(pCur != NULL);

        double uctValue;
      
        if (turn == TURN_CHO )
            uctValue = pCur->totalScore / (pCur->visitCount + EPSILON) +
            std::sqrt(std::log(visitCount + 1) / (pCur->visitCount + EPSILON));
        else
            uctValue = -pCur->totalScore / (pCur->visitCount + EPSILON) +
            std::sqrt(std::log(visitCount + 1) / (pCur->visitCount + EPSILON));

        uctValue += Rand_i()*EPSILON;

        if (uctValue >= bestValue) {
            selected = k;
            bestValue = uctValue;
        }
    }
#endif
    return selected;
}

void Node::Expand(Turn turn)
{
    if (!isLeaf)
        return;

    isLeaf = false;
    children.clear();
    vector<Action> acts = board.GetAllLegalActions(turn);// board.GetPossibleActions(turn) 
    for (Action a : acts) {
        Node n(board);
        n.DoAction(a);
        children.push_back(n);
    }
}

Node* Node::GetChild(int idx)
{ 
    if (isLeaf)
        return NULL;
    else
        return &children[idx];
}

double Node::GetScore()
{
#if 0
    if (visitCount == 0)
        return 0.0f;
    return totalScore/visitCount;
#else
    return totalScore;
#endif
}

#endif /* node_cpp */
