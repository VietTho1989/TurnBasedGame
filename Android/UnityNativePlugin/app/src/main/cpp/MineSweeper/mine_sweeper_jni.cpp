//
//  mine_sweeper_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 9/4/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include "mine_sweeper_jni.hpp"
#include "mine_sweeper_board.hpp"
#include "mine_sweeper_Solver.hpp"

namespace MineSweeper
{
    
    int32_t mine_sweeper_makeDefaultPosition(int32_t N, int32_t M, int32_t K, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // correct input
            {
                if(N<5){
                    N = 5;
                }
                if(N>MAX_DIMENSION){
                    N = MAX_DIMENSION;
                }
                if(M<5){
                    M = 5;
                }
                if(M>MAX_DIMENSION){
                    M = MAX_DIMENSION;
                }
                if(K<0){
                    K = 1;
                }
                if(K>=N*M){
                    K = N*M-1;
                }
            }
            // Make position
            Board* pos = new Board(N, M, K);
            // return
            ret = Board::convertToByteArray(pos, outRet);
            // free data
            delete pos;
        }
        return ret;
    }
    
    int32_t mine_sweeper_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Board* pos = new Board;
        {
            Board::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        int32_t ret = 0;
        {
            switch (pos->winOrLoss()) {
                case 0:
                    // not finish
                    ret = 0;
                    break;
                case 1:
                    // win
                    ret = 1;
                    break;
                case -1:
                    // lose
                    ret = 2;
                    break;
                default:
                    break;
            }
        }
        // free data
        delete pos;
        return ret;
    }
    
    int32_t mine_sweeper_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t firstMoveType)
    {
        int32_t ret = -1;
        {
            // make position
            Board* pos = new Board;
            {
                Board::parseByteArray(pos, positionBytes, length, 0, canCorrect);
            }
            // search
            {
                Point choice;
                {
                    Solver solver(pos);
                    //first move
                    if(!solver.isInitialized()){
                        switch (firstMoveType) {
                            case 0:
                                choice = solver.ranFirstMove();
                                break;
                            case 1:
                                choice = solver.cenFirstMove();
                                break;
                            case 2:
                                choice = solver.corFirstMove();
                                break;
                            default:
                                choice = solver.ranFirstMove();
                                break;
                        }
                    }else{
                        //not first move
                        solver.sim();
                        if(solver.safeCellExist()){
                            printf("safeCellExist\n");
                            choice = solver.chooseSafeCell();
                        }else{
                            solver.csp();
                            if(solver.safeCellExist()){
                                printf("csp safeCellExist\n");
                                choice = solver.chooseSafeCell();
                            }else{
                                printf("ran tieBreaking\n");
                                choice = solver.ranTieBreaking();
                            }
                        }
                    }
                }
                printf("find choice: %d, %d, %d, %d\n", choice.x, choice.y, pos->N, pos->M);
                ret = choice.x + choice.y*pos->N;
                /*{
                    pos->pick(choice.x, choice.y);
                    pos->print();
                }*/
                // TODO Can phai tra ve flag cua pos nua
            }
            delete pos;
        }
        // return
        return ret;
    }
    
    bool mine_sweeper_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move)
    {
        bool ret = false;
        {
            // make position
            Board* pos = new Board;
            {
                Board::parseByteArray(pos, positionBytes, length, 0, canCorrect);
            }
            // Check
            {
                Point point;
                {
                    point.x = move%pos->N;
                    point.y = move/pos->N;
                }
                if(point.x>=0 && point.x<pos->N && point.y>=0 && point.y<pos->M){
                    if(pos->init){
                        if (pos->board[point.x][point.y] == -1) {
                            ret = true;
                        } else{
                            //this place has already been checked
                            printf("error, this place has already been checked: %d, %d, %d\n", point.x, point.y, pos->board[point.x][point.y]);
                        }
                    }else{
                        ret = true;
                    }
                }else{
                    printf("point outside board: %d, %d\n", point.x, point.y);
                }
            }
            // free data
            delete pos;
        }
        return ret;
    }
    
    int32_t mine_sweeper_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // make position
        Board* pos = new Board;
        {
            Board::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // doMove
        {
            Point point;
            {
                point.x = move%pos->N;
                point.y = move/pos->N;
            }
            // do move
            pos->pick(point.x, point.y);
            // convert to return value
            ret = Board::convertToByteArray(pos, outRet);
        }
        // free data
        delete pos;
        // return
        return ret;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////// Print ///////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    int32_t mine_sweeper_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char* ret = (char*)calloc(1, MAX_DIMENSION*MAX_DIMENSION*20);
            {
                pos.print(ret);
#ifdef Debug
                printf("\n%s\n", ret);
#endif
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outStrPosition = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrPosition, ret, outLength);
                }
            }
            free(ret);
        }
        // return
        return outLength;
    }
    
}
