//
//  board.h
//
//  Created by pilhoon on 1/18/16.
//

#ifndef board_h
#define board_h

#include <vector>
#include "defines.h"
#include "action.h"
#include "pos.h"

class Board {
public:
    int stage[kStageHeight][kStageWidth];
    
    int getPieceCount();

    Board();
    Board(Board const &b);
    Board(int s[][kStageWidth]);
    void DoAction(Action action);
    int GetValue();
    vector<Action> GetPossibleActions(Turn turn);
    bool IsMovableUnit(int unitID, int turn);
    bool IsUnit(Pos p);
    void SetStage(StageID stage_id);
    void Init();
    string GetUnitID(Pos pos);
    void Print();
    string ToString(Pos sharpPosition = Pos(-1,-1));
    vector<Pos> GetMovableCanditates(Pos pos);
    vector<Pos> MoveGung(Pos current);
    vector<Pos> MoveCha(Pos current);
    vector<Pos> MovePo(Pos current);
    vector<Pos> MoveMa(Pos current);
    vector<Pos> MoveSang(Pos current);
    vector<Pos> MoveJol(Pos current);
    
public:
    vector<Action> GetAllLegalActions(Turn turn);
    
    bool isLegalMove(Action action, Turn turn);
};

#endif /* board_h */
