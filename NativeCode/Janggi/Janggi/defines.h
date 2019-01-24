#ifndef H_DEFINES
#define H_DEFINES

#include <climits>
#include <utility>
#include <string>
#include "pos.h"

using namespace std;

// #define MINMAX_DEPTH 4
// #define ALPHA_BETA_DEPTH 6
// #define MCTS_ITERATION 50// 300
// #define MCTS_SIMULATION_DEPTH 2

struct SearchParam
{
    int mctsIteration = 100;
    int mctsSimulationDepth = 2;
};

const double EPSILON = 1e-6;

const int     kStageWidth = 9;
const int     kStageHeight = 10;

enum UnitID
{
  HG, HC, HM, HS, HP, Hs, HJ,
  CG, CC, CM, CS, CP, Cs, CJ,
  IDSize,
};

// G: General
// C: Chariot
// M: Horse
// S: Elephant
// P: Cannon
// s: Advisor
// J: Pawn

const string UnitIDChar[IDSize] = {
    "HG", "HC", "HM", "HS", "HP", "Hs", "HJ",
    "CG", "CC", "CM", "CS", "CP", "Cs", "CJ",
};

enum Turn {
  TURN_CHO,
  TURN_HAN
};

const int POINT[IDSize/2] = {
  INT_MAX, 13, 5, 3, 7, 3, 2
};

enum StageID {
  MSSMSMSM,
};

#endif

/*
 . h . a a . . . .
 . . . k . . . . .
 . . . . e h . . .
 r . . p p . p p .
 . . . . . . . . .
 . . . P . . . . .
 . P . E C P P P .
 . c . H K C . . .
 . . . . . . . . .
 . . . A . A H E r
*/
