//
// Created by bozai on 20/10/2016.
//

#include "mine_sweeper_Solver.hpp"
#include "../Platform.h"

namespace MineSweeper
{
    Solver::Solver(Board* board1) {
        board = board1;
    }
    
    Matrix Solver::distToBoundary() {
        vector<Point> boundary;
        NebSet nebSetNow = board->neb;
        int32_t numOfNebs = (int32_t)nebSetNow.size();
        
        for(int32_t i=0; i<numOfNebs; i++){
            Neb nebNow = nebSetNow[i];
            boundary.reserve( boundary.size() + nebNow.boundary.size() ); // preallocate memory
            boundary.insert( boundary.end(), nebNow.boundary.begin(), nebNow.boundary.end() );
        }
        int32_t N = board->N, M = board->M;
        Matrix dis2bd = Matrix(N, vector<int>(M));;//the distance from the uncovered cell to boundary distance. initialize -100
        Matrix bd = Matrix(N, vector<int>(M));
        //initial with -1, copy flags
        for (int32_t i = 0; i < N; i++) {
            for (int32_t j = 0; j < M; j++) {
                dis2bd[i][j] = -1;
                bd[i][j] = board->board[i][j];
            }
        }
        
        vector<Point> S = boundary;
        vector<Point> c_p={{-1,0},{0,-1},{1,0},{0,1}};
        
        for(int32_t i=0; i<S.size(); i++){
            int32_t x=boundary[i].x;
            int32_t y=boundary[i].y;
            dis2bd[x][y]=0;
        }
        vector<Point> D;
        
        while(S.size()!=0){
            D.clear();
            for(int8_t i=0; i<S.size(); i++){
                for(int8_t j=0; j<c_p.size(); j++){
                    int8_t cx=S[i].x;
                    int8_t c_prx=S[i].x+c_p[j].x;
                    int8_t cy=S[i].y;
                    int8_t c_pry=S[i].y+c_p[j].y;
                    
                    if (c_prx < 0 || c_prx >= N || c_pry < 0 || c_pry >= M)
                        continue;
                    if((dis2bd[c_prx][c_pry]==-1) && (bd[c_prx][c_pry]==-1)){
                        D.push_back({c_prx, c_pry});
                        dis2bd[c_prx][c_pry] = dis2bd[cx][cy]+1;
                        
                    }
                }
            }
            S.clear();
            S=D;
        }
        return dis2bd;
    }
    
    bool Solver::safeCellExist() {
        for(int32_t i=0; i<board->N;i++){
            for(int32_t j=0;j<board->M;j++){
                if(board->flags[i][j]==1){//is it still safe to use == given flags now is float?
                    return true;
                }
            }
        }
        return  false;
    }
    
    Point Solver::chooseSafeCell() {
        for(int8_t i=0;i<board->N;i++){
            for(int8_t j=0; j<board->M; j++){
                if(board->flags[i][j]==1) {//is it still safe to use == given flags now is float?
                    return Point{static_cast<int8_t>(i),j};
                }
            }
        }
        return Point{0,0};
    }
    
    bool Solver::isInitialized() {
        return board->init;
    }
    
    Point Solver::ranFirstMove() {
        
        srand((uint32_t)now());
        int32_t T = board->N*board->M;
        int32_t t = rand() % T;
        int8_t row = t/board->M;
        int8_t col = t-row*board->M;
        return  Point{row,col};
    }
    
    Point Solver::corFirstMove() {
        if(!board->init){
            int8_t row = board->N-1;
            int8_t col = board->M-1;
            return Point{row, col};
        }
        return Point{0, 0};
    }
    
    Point Solver::cenFirstMove() {
        if(!board->init){
            int8_t row = (board->N-1)/2;
            int8_t col = (board->M-1)/2;
            return Point{row,col};
        }
        return Point{0,0};
    }
    
    void Solver::sim() {
        NebSet nebSetNow = board->getNeb();
        int32_t numOfNebs = (int32_t)nebSetNow.size();
        for(int32_t i=0; i<numOfNebs; i++){
            Neb nebNow = nebSetNow[i];
            int32_t boundarySize = (int32_t)nebNow.boundary.size();
            //for every boundary cell
            for(int32_t j = 0; j<boundarySize; j++){
                Point cellNow = nebNow.boundary[j];
                int32_t fringeCount = 0;
                //count its fringe cells
                for (int8_t i = -1; i < 2; i++) {
                    for (int8_t j = -1; j < 2; j++) {
                        if (i == 0 && j == 0)
                            continue;
                        Point np{static_cast<int8_t>(cellNow.x+i), static_cast<int8_t>(cellNow.y+j)};
                        if (np.x < 0 || np.x >= board->N || np.y < 0 || np.y >= board->M)
                            continue;
                        if (board->board[np.x][np.y] == -1) {
                            fringeCount++;
                        }
                    }
                }
                
                //rule 1: If num of adjacent fringes equals to num of mines, then they are all mines, flag them!
                if(board->board[cellNow.x][cellNow.y] == fringeCount){
                    for (int8_t i = -1; i < 2; i++) {
                        for (int8_t j = -1; j < 2; j++) {
                            if (i == 0 && j == 0)
                                continue;
                            Point np{static_cast<int8_t>(cellNow.x+i), static_cast<int8_t>(cellNow.y+j)};
                            if (np.x < 0 || np.x >= board->N || np.y < 0 || np.y >= board->M)
                                continue;
                            if (board->board[np.x][np.y] == -1) {
                                //mark in the flag matrix
                                board->flags[np.x][np.y] = -1;
                                board->minesFound++;
                                // printf("solver sim: board flag -1\n");
                            }
                        }
                    }
                }
                
                //rule 2:pick any uncovered cell around a 0-valued cell
                //handled by the game
                
                //rule3:if a k-valued cell is surrounding by k-flagged mines, other adjacent cells are safe
                int32_t minesAround = 0;
                //count the already known mines around the boundary cell
                for (int8_t i = -1; i < 2; i++) {
                    for (int8_t j = -1; j < 2; j++) {
                        if (i == 0 && j == 0)
                            continue;
                        Point np{static_cast<int8_t>(cellNow.x+i), static_cast<int8_t>(cellNow.y+j)};
                        if (np.x < 0 || np.x >= board->N || np.y < 0 || np.y >= board->M)
                            continue;
                        if (board->flags[np.x][np.y] == -1)
                            minesAround++;
                    }
                }
                //if all mines are detected
                if(minesAround == board->board[cellNow.x][cellNow.y]){
                    //all mines are detected, thus others are safe, mark the safe ones with 1
                    for (int8_t i = -1; i < 2; i++) {
                        for (int8_t j = -1; j < 2; j++) {
                            if (i == 0 && j == 0)
                                continue;
                            Point np{static_cast<int8_t>(cellNow.x+i), static_cast<int8_t>(cellNow.y+j)};
                            if (np.x < 0 || np.x >= board->N || np.y < 0 || np.y >= board->M)
                                continue;
                            if (board->flags[np.x][np.y] != 2 && board->flags[np.x][np.y]!=-1){
                                //mark and return
                                board->flags[np.x][np.y] = 1;
                                return;//return as soon as safe cell is found
                            }
                        }
                    }
                }
            }
        }
        return;
    }
    
    void Solver::csp() {
        // printf("Solver csp\n");
        NebSet nebSetNow = board->getNeb();
        int32_t numOfNebs = (int32_t)nebSetNow.size();
        for (int32_t i = 0; i < numOfNebs; i++) {
            Neb nebNow = nebSetNow[i];
            int32_t fringeSize = (int32_t)nebNow.fringe.size();
            vector<int32_t> configurations;
            int32_t unsureInFringe = 0;
            //count unsure fringe cells in this neb
            for (int32_t j = 0; j < fringeSize; j++) {
                // printf("fringe point: %d, %d\n", nebNow.fringe[j].x, nebNow.fringe[j].y);
                if (board->flags[nebNow.fringe[j].x][nebNow.fringe[j].y] == 0) {
                    unsureInFringe++;
                }
            }
            //use enu only when there are uncertain cells
            if (unsureInFringe != 0) {
                if(unsureInFringe>=18){
                    printf("error, unsureInFringe too much: %d\n", unsureInFringe);
                    unsureInFringe = 18;
                    // return;
                }
                // else
                {
                    //try all combinations of these cells
                    for (int32_t k = 0; k < pow(2, unsureInFringe); k++) {
                        //copy the flag board for messing around
                        ByteMatrix copiedFlagMatrix = board->flags;
                        int32_t unsureIndex = -1;
                        //put in k(cconfiguration) to copiedFlagMatrix
                        for (int32_t j = 0; j < fringeSize; j++) {
                            // printf("unsureInFringe: %d, %d, %d\n", k, fringeSize, unsureInFringe);
                            //find unsure cell in flags
                            if (board->flags[nebNow.fringe[j].x][nebNow.fringe[j].y] ==
                                0) {//is it still safe to use == given flags now is float?
                                unsureIndex++;
                                int32_t mine = k & (1 << unsureIndex);
                                if (mine) {
                                    copiedFlagMatrix[nebNow.fringe[j].x][nebNow.fringe[j].y] = -1;
                                }
                                //copiedFlagMatrix[nebNow.fringe[j].x][nebNow.fringe[j].y] = 1;//not necessary, only count mines in copiedFlagMatrix
                            }
                        }
                        
                        //test if this  config is compatible
                        bool compatibility = true;
                        int32_t boundarySizeNow = (int32_t)nebNow.boundary.size();
                        for (int32_t b = 0; b < boundarySizeNow; b++) {
                            int32_t bombsNearby = 0;
                            //count mines in the copiedFlagsMatrix
                            for (int8_t p = -1; p < 2; p++) {
                                for (int8_t q = -1; q < 2; q++) {
                                    if (p == 0 && q == 0)
                                        continue;
                                    Point np{static_cast<int8_t>(nebNow.boundary[b].x + p), static_cast<int8_t>(nebNow.boundary[b].y + q)};
                                    if (np.x < 0 || np.x >= board->N || np.y < 0 || np.y >= board->M)
                                        continue;
                                    if (copiedFlagMatrix[np.x][np.y] == -1) bombsNearby++;
                                }
                            }
                            //if not compatible for this cell
                            if (board->board[nebNow.boundary[b].x][nebNow.boundary[b].y] != bombsNearby) {
                                compatibility = false;
                                break;
                            }
                        }
                        //if this is compatible, then and it in the configurations
                        if (compatibility) {
                            configurations.push_back(k);
                        }
                    }
                }
            }
            
            int32_t numOfCompatible = (int32_t)configurations.size();
            int32_t unsureIndex = -1;
            bool found = false;
            Point lastFound;
            for (int32_t f = 0; f < fringeSize; f++) {
                //compute prob for each unsure cell
                if (board->flags[nebNow.fringe[f].x][nebNow.fringe[f].y] == 0) {
                    unsureIndex++;
                    int32_t mineCfgCount = 0;
                    for (int32_t c = 0; c < numOfCompatible; c++) {
                        int32_t mineOrNot = configurations[c] & (1 << unsureIndex);
                        if (mineOrNot) {
                            mineCfgCount++;
                        }
                    }
                    //               int prob = mineCfgCount/numOfCompatible;
                    //               board.flags[nebNow.fringe[f].x][nebNow.fringe[f].y] = -prob;
                    if (mineCfgCount == numOfCompatible) {
                        board->flags[nebNow.fringe[f].x][nebNow.fringe[f].y] = -1;
                        board->minesFound++;
                    }
                    if (mineCfgCount == 0) {
                        board->flags[nebNow.fringe[f].x][nebNow.fringe[f].y] = 1;
                        //do not return here,return after mark all in this neighbor
                        found= true;
                        lastFound = Point{nebNow.fringe[f].x,nebNow.fringe[f].y};
                    }
                }
            }
            if(found){
                return;
            }
        }
    }
    
    //Point Solver::mdp() {}
    
    Point Solver::ranTieBreaking() {
        // TODO Can phai cai thien
        int32_t riskyChoices = 0;
        for(int32_t i=0; i<board->N; i++){
            for(int32_t j=0; j<board->M; j++){
                if(board->board[i][j]==-1){
                    if(board->flags[i][j]==0){
                        riskyChoices++;
                    }
                }
            }
        }
        int32_t choice = rand()%riskyChoices;
        for(int32_t i=0; i<board->N; i++){
            for(int32_t j=0; j<board->M; j++){
                if(board->board[i][j]==-1){
                    if(board->flags[i][j]==0){
                        riskyChoices--;
                    }
                    if(choice==riskyChoices){
                        // cout<<"Kidding you, I'm just guessing around"<<endl;
                        return Point{static_cast<int8_t>(i), static_cast<int8_t>(j)};
                    }
                }
            }
        }
        printf("error, cannot get a point\n");
        return Point{0,0};
    }
    
    Point Solver::awayFromBoundary() {
        Matrix dist = distToBoundary();
        int32_t max=0;
        Point maxPoint;
        for(int8_t i=0; i<board->N; i++){
            for(int8_t j=0; j<board->M; j++){
                if(board->flags[i][j]==0 && dist[i][j]>max){//is it still safe to use == given flags now is float?
                    max = dist[i][j];
                    maxPoint = Point{i, j};
                }
            }
        }
        return maxPoint;
    }
    
    Point Solver::awayFromBoundaryAndFringe() {
        Matrix dist = distToBoundary();
        int32_t max=0;
        Point maxPoint;
        for(int8_t i=0; i<board->N; i++){
            for(int8_t j=0; j<board->M;j++){
                int32_t distFrame = i<j?i:j;
                distFrame = distFrame<(7-i)?distFrame:(7-i);
                distFrame = distFrame<(7-j)?distFrame:(7-j);
                distFrame++;
                int32_t minBetween = dist[i][j]<distFrame?dist[i][j]:distFrame;
                if(board->flags[i][j]==0 && minBetween>max){
                    //is it still safe to use == given flags now is float?
                    max = minBetween;
                    maxPoint = Point{i, j};
                }
            }
        }
        return maxPoint;
    }
    
    Point Solver::closeToBoundary() {
        Matrix dist = distToBoundary();
        int32_t min=1000;
        Point minPoint;
        for(int8_t i=0; i<board->N; i++){
            for(int8_t j=0; j<board->M; j++){
                if(board->flags[i][j]==0 && dist[i][j]<min){
                    //is it still safe to use == given flags now is float?
                    min = dist[i][j];
                    minPoint = Point{i, j};
                }
            }
        }
        return minPoint;
    }
    
}
