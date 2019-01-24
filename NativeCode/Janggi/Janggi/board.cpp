//
//  board.cpp
//
//  Created by pilhoon on 1/18/16.
//

#include <cstring>
#include <iostream>
#include <cassert>
#include "board.h"
#include "pos.h"
#include "action.h"
#include "node.h"

Board::Board() {
    Init();
}

Board::Board(int s[][kStageWidth]) {
    memcpy(stage, s, sizeof(int)*kStageHeight*kStageWidth);
}

Board::Board(Board const &b) {
    memcpy(stage, b.stage, sizeof(int)*kStageHeight*kStageWidth);
}

void Board::DoAction(Action action) {
    if (stage[action.prev.y][action.prev.x] < 0) {
        throw;
    }
    
    //action.Print();
    stage[action.next.y][action.next.x] = stage[action.prev.y][action.prev.x];
    stage[action.prev.y][action.prev.x] = -1;
}

int Board::GetValue() {
    //return cho's score relative to han's score
    //if return value is 0, the score is tied
    //if return value is positive, cho is ahead of han
    //if return value is negative, han is ahead of cho
    int score_cho = 0, score_han = 0;
    
    for (int y=0 ; y<kStageHeight ; y++) {
        for (int x=0 ; x<kStageWidth ; x++) {
            int val = stage[y][x];            
            if (val >= 0) {
                if (val <= 6)
                    score_han += POINT[val];
                else
                    score_cho += POINT[val-7];
            }
        }
    }    
    return score_cho - score_han;
}

vector<Action> Board::GetPossibleActions(Turn turn)
{
    vector<Action> actions;
    for (int y=0 ; y<kStageHeight ; y++) {
        for (int x=0 ; x<kStageWidth ; x++) {
            if ( IsMovableUnit(stage[y][x], turn) ) {
                Pos curr(x,y);
                vector<Pos> candidates = GetMovableCanditates(curr);
                for (Pos p : candidates)
                    actions.push_back(Action(curr, p));
            }
        }
    }
    return actions;
}

int Board::getPieceCount()
{
    int ret = 0;
    {
        for (int y=0 ; y<kStageHeight ; y++) {
            for (int x=0 ; x<kStageWidth ; x++) {
                if(stage[y][x]!=-1){
                    ret++;
                }
            }
        }
    }
    return ret;
}

vector<Action> Board::GetAllLegalActions(Turn turn)
{
    vector<Action> allPossibleActions = this->GetPossibleActions(turn);
    Turn otherTurn = (turn==TURN_CHO) ? TURN_HAN : TURN_CHO;
    vector<Action> actions;
    {
        UnitID kingId = (turn==TURN_CHO) ? CG : HG;
        for(int i=0; i<allPossibleActions.size(); i++){
            Action action = allPossibleActions[i];
            // Check correct
            bool correct = true;
            {
                Board checkBoard (*this);
                checkBoard.DoAction(action);
                // find king position
                Pos kingPosition(-1, -1);
                {
                    for (int y=0 ; y<kStageHeight ; y++) {
                        for (int x=0 ; x<kStageWidth ; x++) {
                            if(checkBoard.stage[y][x]==kingId){
                                // printf("find kingPosition: %d, %d\n", x, y);
                                kingPosition.x = x;
                                kingPosition.y = y;
                                break;
                            }
                        }
                    }
                }
                // process
                if(kingPosition.x!=-1 && kingPosition.y!=-1){
                    // check king is threaten
                    bool isThreaten = false;
                    {
                        vector<Action> allNextPossibleActions = checkBoard.GetPossibleActions(otherTurn);
                        for(int j=0; j<allNextPossibleActions.size(); j++){
                            Action nextAction = allNextPossibleActions[j];
                            if(nextAction.next==kingPosition){
                                // printf("isThreaten: %d, %d, %d, %d\n", nextAction.next.x, nextAction.next.y, nextAction.prev.x, nextAction.prev.y);
                                isThreaten = true;
                                break;
                            }
                        }
                    }
                    if(isThreaten){
                        correct = false;
                    }
                }else{
                    // printf("kingPosition error\n");
                    correct = false;
                }
            }
            // add
            if(correct){
                actions.push_back(action);
            }
        }
    }
    // printf("getAllLegalActions: %lu, %lu, %d\n", actions.size(), allPossibleActions.size(), turn);
    return actions;
}

bool Board::isLegalMove(Action action, Turn turn)
{
    vector<Action> allLegalActions = GetAllLegalActions(turn);
    // check
    bool ret = false;
    {
        for(int i=0; i<allLegalActions.size(); i++){
            Action check = allLegalActions[i];
            if(check==action){
                ret = true;
                break;
            }
        }
    }
    return ret;
}

bool Board::IsMovableUnit(int unitID, int turn)
{
    return (unitID >= 0) &&
    (
     ( turn == TURN_CHO && unitID > 6 ) ||
     ( turn == TURN_HAN && unitID <= 6 )
     );
}

bool Board::IsUnit(Pos p) {
    return stage[p.y][p.x] >= 0 ;
}

void Board::SetStage(StageID stage_id)
{
    switch (stage_id) {
        case MSSMSMSM:
            stage[0][0] = HC;  stage[0][1] = HM;  stage[0][2] = HS;
            stage[0][3] = Hs;  stage[0][5] = Hs;  stage[0][6] = HS;
            stage[0][7] = HM;  stage[0][8] = HC;  stage[2][1] = HP;
            stage[2][7] = HP;  stage[3][0] = HJ;  stage[3][2] = HJ;
            stage[3][4] = HJ;  stage[3][6] = HJ;  stage[3][8] = HJ;
            stage[1][4] = HG;
            
            stage[9][0] = CC;  stage[9][1] = CS;  stage[9][2] = CM;
            stage[9][3] = Cs;  stage[9][5] = Cs;  stage[9][6] = CS;
            stage[9][7] = CM;  stage[9][8] = CC;  stage[7][1] = CP;
            stage[7][7] = CP;  stage[6][0] = CJ;  stage[6][2] = CJ;
            stage[6][4] = CJ;  stage[6][6] = CJ;  stage[6][8] = CJ;
            stage[8][4] = CG;
            break;
    }
}

void Board::Init() {
    for (int y = 0; y < kStageHeight; y++) {
        for (int x = 0; x < kStageWidth; x++) {
            stage[y][x] = -1;
        }
    }
    SetStage(MSSMSMSM); // 한:마상상마, 초:상마상마
}

string Board::GetUnitID(Pos pos) {
    if (stage[pos.y][pos.x] >= 0)
        return UnitIDChar[stage[pos.y][pos.x]];
    else {
        return "--";
    }
}

void Board::Print() {
    cout << ToString();
}

string Board::ToString(Pos sharpPosition) {  // TODO : -1 = magic number.
    string s = "   ";
    for (int x = 0; x < kStageWidth; x++)
        s += (to_string(x) + "   ");
    s += "\n";
    
    for (int y = 0; y < kStageHeight; y++) {
        s += (to_string(y) + " ");
        for (int x = 0; x < kStageWidth; x++) {
            Pos cur = Pos(x,y);
            if ( cur == sharpPosition )
                s += "##";
            else
                s += GetUnitID(cur);
            
            if (x != kStageWidth - 1)
                s += "  ";
        }
        if (y != kStageHeight - 1) {
            s += "\n  ";
            for (int x = 0; x < kStageWidth; x++)
                s += "    ";
            s += "\n";
        }
    }
    s += "\n====================================\n";
    return s;
}

vector<Pos> Board::GetMovableCanditates(Pos pos)
{
    vector<Pos> candidates;
    switch(stage[pos.y][pos.x]) {
        case HG:
        case CG:
        case Hs:
        case Cs:
          candidates = MoveGung(pos);
          break;
        case HC:
        case CC:
          candidates = MoveCha(pos);
          break;
        case HM:
        case CM:
          candidates = MoveMa(pos);
          break;
        case HS:
        case CS:
          candidates = MoveSang(pos);
          break;
        case HP:
        case CP:
          candidates = MovePo(pos);
          break;
        case HJ:
        case CJ:
          candidates = MoveJol(pos);
          break;
        default:
            throw;
    }

    // Remove redundancy
    vector<Pos> results;
    for (int i = 0; i < candidates.size(); i++) {
        bool isUnique = true;
        Pos candidate = candidates[i];
        for (int s = 0; s < i - 1; s++) {
            if (candidate.x == candidates[s].x && candidate.y == candidates[s].y) {
                isUnique = false;
                break;
            }
        }
        if (isUnique)
            results.push_back(candidate);
    }

    return results;
}

vector<Pos> Board::MoveGung(Pos pos)
{
    vector<Pos> candidates;
    int curr_id = stage[pos.y][pos.x];
    int nx, ny;
    for (int dy = -1; dy <= 1; dy++) {
        for (int dx = -1; dx <= 1; dx++) {
            nx = pos.x + dx;
            ny = pos.y + dy;
            if ((pos.x == 3 && (pos.y == 1 || pos.y == 8)) ||
                (pos.x == 4 && (pos.y == 0 || pos.y == 2 || pos.y == 7 || pos.y == 9)) ||
                (pos.x == 5 && (pos.y == 1 || pos.y == 8))) {
                // movable to only up, right, left, down side
                if (pos.DistWith(nx, ny) > 1)
                    continue;
            }
            if (nx >= 3 && nx <= 5
                && ((ny >= 0 && ny <= 2) || (ny >= 7 && ny <= 9))) {
                if (curr_id <= 6) {
                    if (stage[ny][nx]<0 || stage[ny][nx]>6) {
                        candidates.push_back(Pos(nx, ny));
                    }
                }
                else {
                    if (stage[ny][nx]<0 || stage[ny][nx] <= 6) {
                        candidates.push_back(Pos(nx, ny));
                    }
                }
            }
        }
    }
    
    return candidates;
}

vector<Pos> Board::MoveCha(Pos pos)
{
    int curr_id = stage[pos.y][pos.x];
    vector<Pos> candidates;
    
    // up
    if (pos.y>0) {
        for (int y = pos.y - 1; y >= 0; y--) {
            if (curr_id <= 6) {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else {
                    if (stage[y][pos.x] > 6) {
                        candidates.push_back(Pos(pos.x, y));
                    }
                    break;
                }
            }
            else {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else {
                    if (stage[y][pos.x] <= 6) {
                        candidates.push_back(Pos(pos.x, y));
                    }
                    break;
                }
            }
        }
    }
    // down
    if (pos.y<kStageHeight - 1) {
        for (int y = pos.y + 1; y < kStageHeight; y++) {
            if (curr_id <= 6) {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else {
                    if (stage[y][pos.x] > 6) {
                        candidates.push_back(Pos(pos.x, y));
                    }
                    break;
                }
            }
            else {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else {
                    if (stage[y][pos.x] <= 6) {
                        candidates.push_back(Pos(pos.x, y));
                    }
                    break;
                }
            }
        }
    }
    // right
    if (pos.x<kStageWidth - 1) {
        for (int x = pos.x + 1; x < kStageWidth; x++) {
            if (curr_id <= 6) {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else {
                    if (stage[pos.y][x] > 6) {
                        candidates.push_back(Pos(x, pos.y));
                    }
                    break;
                }
            }
            else {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else {
                    if (stage[pos.y][x] <= 6) {
                        candidates.push_back(Pos(x, pos.y));
                    }
                    break;
                }
            }
        }
    }
    // left
    if (pos.x>0) {
        for (int x = pos.x - 1; x >= 0; x--) {
            if (curr_id <= 6) {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else {
                    if (stage[pos.y][x] > 6) {
                        candidates.push_back(Pos(x, pos.y));
                    }
                    break;
                }
            }
            else {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else {
                    if (stage[pos.y][x] <= 6) {
                        candidates.push_back(Pos(x, pos.y));
                    }
                    break;
                }
            }
        }
    }
    
    // diagonal
    if (pos.x >= 3 && pos.x <= 5
        && ((pos.y >= 0 && pos.y <= 2) || (pos.y >= 7 && pos.y <= 9))) {
        int nx, ny;
        for (int dy = -1; dy <= 1; dy++) {
            for (int dx = -1; dx <= 1; dx++) {
                nx = pos.x + dx;
                ny = pos.y + dy;
                if ((pos.x == 3 && (pos.y == 1 || pos.y == 8)) ||
                    (pos.x == 4 && (pos.y == 0 || pos.y == 2 || pos.y == 7 || pos.y == 9)) ||
                    (pos.x == 5 && (pos.y == 1 || pos.y == 8))) {
                    // movable to only up, right, left, down side
                    if (pos.DistWith(nx, ny) > 1)
                        continue;
                }
                if (nx >= 3 && nx <= 5
                    && ((ny >= 0 && ny <= 2) || (ny >= 7 && ny <= 9))) {
                    if (curr_id <= 6) {
                        if (stage[ny][nx]<0 || stage[ny][nx]>6) {
                            candidates.push_back(Pos(nx, ny));
                        }
                    }
                    else {
                        if (stage[ny][nx]<0 || stage[ny][nx] <= 6) {
                            candidates.push_back(Pos(nx, ny));
                        }
                    }
                }
            }
        }
    }
    
    return candidates;
}

vector<Pos> Board::MovePo(Pos pos)
{
    int curr_id = stage[pos.y][pos.x];
    vector<Pos> candidates;
    // up
    if (pos.y > 1) {
        bool movable = false;
        for (int y = pos.y - 1; y >= 0; y--) {
            if (movable) {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else if (stage[y][pos.x] == HP || stage[y][pos.x] == CP) {
                    break;
                }
                else {
                    if ((curr_id<=6 && stage[y][pos.x]>6) || (curr_id>6 && stage[y][pos.x]<=6))
                        candidates.push_back(Pos(pos.x, y));
                    break;
                }
            }
            else {
                if (stage[y][pos.x] == HP || stage[y][pos.x] == CP) {
                    break;
                }
                else if (stage[y][pos.x] > 0) {
                    movable = true;
                }
            }
        }
    }
    
    // down
    if (pos.y < kStageHeight-2) {
        bool movable = false;
        for (int y = pos.y + 1; y <kStageHeight; y++) {
            if (movable) {
                if (stage[y][pos.x] < 0) {
                    candidates.push_back(Pos(pos.x, y));
                }
                else if (stage[y][pos.x] == HP || stage[y][pos.x] == CP) {
                    break;
                }
                else {
                    if ((curr_id <= 6 && stage[y][pos.x]>6) || (curr_id>6 && stage[y][pos.x] <= 6))
                        candidates.push_back(Pos(pos.x, y));
                    break;
                }
            }
            else {
                if (stage[y][pos.x] == HP || stage[y][pos.x] == CP) {
                    break;
                }
                else if (stage[y][pos.x] > 0) {
                    movable = true;
                }
            }
        }
    }
    
    // right
    if (pos.x < kStageWidth - 2) {
        bool movable = false;
        for (int x = pos.x + 1; x <kStageWidth; x++) {
            if (movable) {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else if (stage[pos.y][x] == HP || stage[pos.y][x] == CP) {
                    break;
                }
                else {
                    if ((curr_id <= 6 && stage[pos.y][x]>6) || (curr_id>6 && stage[pos.y][x] <= 6))
                        candidates.push_back(Pos(x, pos.y));
                    break;
                }
            }
            else {
                if (stage[pos.y][x] == HP || stage[pos.y][x] == CP) {
                    break;
                }
                else if (stage[pos.y][x] > 0) {
                    movable = true;
                }
            }
        }
    }
    
    // left
    if (pos.x > 1) {
        bool movable = false;
        for (int x = pos.x - 1; x >= 0; x--) {
            if (movable) {
                if (stage[pos.y][x] < 0) {
                    candidates.push_back(Pos(x, pos.y));
                }
                else if (stage[pos.y][x] == HP || stage[pos.y][x] == CP) {
                    break;
                }
                else {
                    if ((curr_id <= 6 && stage[pos.y][x]>6) || (curr_id>6 && stage[pos.y][x] <= 6))
                        candidates.push_back(Pos(x, pos.y));
                    break;
                }
            }
            else {
                if (stage[pos.y][x] == HP || stage[pos.y][x] == CP) {
                    break;
                }
                else if (stage[pos.y][x] > 0) {
                    movable = true;
                }
            }
        }
    }
    
    // diagonal
    Pos next;
    if (stage[4][1] > 0 && stage[4][1] != HP && stage[4][1] != CP) {
        if (pos.x == 3 && pos.x == 0) {
            next = Pos(5, 2);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 3 && pos.x == 2) {
            next = Pos(5, 0);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 5 && pos.x == 0) {
            next = Pos(3, 2);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 5 && pos.x == 2) {
            next = Pos(3, 0);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
    }
    else if (stage[4][8] > 0 && stage[4][8] != HP && stage[4][8] != CP) {
        if (pos.x == 3 && pos.x == 7) {
            next = Pos(5, 9);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 3 && pos.x == 9) {
            next = Pos(5, 7);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 5 && pos.x == 7) {
            next = Pos(3, 9);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
        else if (pos.x == 5 && pos.x == 9) {
            next = Pos(3, 7);
            if ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6))
                candidates.push_back(next);
        }
    }
    return candidates;
}

vector<Pos> Board::MoveMa(Pos pos)
{
    int curr_id = stage[pos.y][pos.x];
    vector<Pos> candidates;
    Pos next;
    if (pos.y > 1) {
        // up-left
        next = Pos(pos.x - 1, pos.y - 2);
        if (stage[pos.y - 1][pos.x] < 0 && next.x >= 0 && ((curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        // up-right
        next = Pos(pos.x + 1, pos.y - 2);
        if (stage[pos.y - 1][pos.x] < 0 && next.x < kStageWidth && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    if (pos.x < kStageWidth - 2) {
        // right-up
        next = Pos(pos.x + 2, pos.y + 1);
        if (stage[pos.y][pos.x + 1] < 0 && next.y <kStageHeight && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // right-down
        next = Pos(pos.x + 2, pos.y - 1);
        if (stage[pos.y][pos.x + 1] < 0 && next.y >= 0 && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    if (pos.y < kStageHeight - 2) {
        // down-left
        next = Pos(pos.x - 1, pos.y + 2);
        if (stage[pos.y + 1][pos.x] < 0 && next.x >= 0 && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // down-right
        next = Pos(pos.x + 1, pos.y + 2);
        if (stage[pos.y + 1][pos.x] < 0 && next.x < kStageWidth && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    if (pos.x > 1) {
        // left-up
        next = Pos(pos.x - 2, pos.y + 1);
        if (stage[pos.y][pos.x - 1] < 0 && next.y <kStageHeight && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // left-down
        next = Pos(pos.x - 2, pos.y - 1);
        if (stage[pos.y][pos.x - 1] < 0 && next.y >= 0 && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    return candidates;
}

vector<Pos> Board::MoveSang(Pos pos)
{
    int curr_id = stage[pos.y][pos.x];
    vector<Pos> candidates;
    Pos next;
    
    if (pos.y > 2) {
        // up-left
        next = Pos(pos.x - 2, pos.y - 3);
        if (pos.x > 1 && stage[pos.y - 1][pos.x]<0 && stage[pos.y - 2][pos.x - 1] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // up-right
        next = Pos(pos.x + 2, pos.y - 3);
        if (pos.x < kStageWidth - 2  && stage[pos.y - 1][pos.x]<0 && stage[pos.y - 2][pos.x + 1] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    if (pos.x < kStageWidth - 3) {
        // right-up
        next = Pos(pos.x + 3, pos.y - 2);
        if (pos.y > 1 && stage[pos.y][pos.x + 1]<0 && stage[pos.y - 1][pos.x + 2] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // right-down
        next = Pos(pos.x + 3, pos.y + 2);
        if (pos.y < kStageHeight - 2 && stage[pos.y][pos.x + 1]<0 && stage[pos.y + 1][pos.x + 2] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
    }
    if (pos.y < kStageHeight - 3) {
        // down-left
        next = Pos(pos.x - 2, pos.y + 3);
        if (pos.x > 1 && stage[pos.y + 1][pos.x]<0 && stage[pos.y + 2][pos.x - 1] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // down-right
        next = Pos(pos.x + 2, pos.y + 3);
        if (pos.x < kStageWidth - 2 && stage[pos.y + 1][pos.x]<0 && stage[pos.y + 2][pos.x + 1] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    if (pos.x > 2) {
        // left-up
        next = Pos(pos.x - 3, pos.y - 2);
        if (pos.y > 1 && stage[pos.y][pos.x - 1]<0 && stage[pos.y - 1][pos.x - 2] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
        
        // left-down
        next = Pos(pos.x - 3, pos.y + 2);
        if (pos.y < kStageHeight - 2 && stage[pos.y][pos.x - 1]<0 && stage[pos.y + 1][pos.x - 2] < 0
            && (stage[next.y][next.x] < 0 || (curr_id <= 6 && stage[next.y][next.x]>6) || (curr_id>6 && stage[next.y][next.x] <= 6)))
            candidates.push_back(next);
    }
    
    return candidates;
}

vector<Pos> Board::MoveJol(Pos pos)
{
    int curr_id = stage[pos.y][pos.x];
    vector<Pos> candidates;
    
    int nx, ny;
    // down-ward
    //if ((curr_id <= 6 && standard_position) || curr_id >6 && !standard_position) {
    if (curr_id <= 6) {
        for (int dy = 0; dy <= 1; dy++) {
            for (int dx = -1; dx <= 1; dx++) {
                nx = pos.x + dx;
                ny = pos.y + dy;
                if (nx >= 0 && nx < kStageWidth && ny >= 0 && ny < kStageHeight && (stage[ny][nx] < 0 || (curr_id <= 6 && stage[ny][nx] > 6) || (curr_id > 6 && stage[ny][nx] <= 6))) {
                    if ((pos.x == 3 && pos.y == 7 && nx == 4 && ny == 8) ||
                        (pos.x == 5 && pos.y == 7 && nx == 4 && ny == 8) ||
                        (pos.x == 4 && pos.y == 8 && nx == 3 && ny == 9) ||
                        (pos.x == 4 && pos.y == 8 && nx == 5 && ny == 9) || pos.DistWith(nx, ny) <= 1.1) {
                        candidates.push_back(Pos(nx, ny));
                    }
                }
            }
        }
    }
    // up-ward
    else {
        for (int dy = -1; dy <= 0; dy++) {
            for (int dx = -1; dx <= 1; dx++) {
                nx = pos.x + dx;
                ny = pos.y + dy;
                if (nx >= 0 && nx < kStageWidth && ny >= 0 && ny < kStageHeight && (stage[ny][nx] < 0 || (curr_id <= 6 && stage[ny][nx] > 6) || (curr_id > 6 && stage[ny][nx] <= 6))) {
                    if ((pos.x == 3 && pos.y == 2 && nx == 4 && ny == 1) ||
                        (pos.x == 5 && pos.y == 2 && nx == 4 && ny == 1) ||
                        (pos.x == 4 && pos.y == 1 && nx == 3 && ny == 0) ||
                        (pos.x == 4 && pos.y == 1 && nx == 5 && ny == 0) || pos.DistWith(nx, ny) <= 1.1) {
                        candidates.push_back(Pos(nx, ny));
                    }
                }
            }
        }
    }
    return candidates;
}
