//
//  jni.cpp
//  TestOthello
//
//  Created by Viet Tho on 3/20/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "reversi_jni.hpp"
#include <string.h>
#include "reversi_eval.hpp"
#include "reversi_position.hpp"
#include "reversi_player.hpp"
#include "reversi_PRNG.hpp"

namespace Reversi
{
    void reversi_setBookPath(const char* newBookPath)
    {
        bookPath = newBookPath;
    }

    int32_t reversi_makeDefaultPosition(uint8_t* &outRet)
    {
        // make position
        PositionStruct pos;// (strFen, NULL, NULL);
        {
            pos.side = BLACK;
            // piece
            {
                Board board;
                pos.white = board.pieces[0];
                pos.black = board.pieces[1];
            }
        }
        // convert
        int32_t length = PositionStruct::convertToByteArray(&pos, outRet);
        // return
        return length;
    }
    
    void reversi_printMove(int8_t move, char* result)
    {
        result[0] = 0;
        sprintf(result, "%c%d", 'a' + (move & 7), (move >> 3) + 1);
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// print position /////////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    inline void printPosition(PositionStruct* pos)
    {
        char result[300];
        result[0] = 0;
        sprintf(result, "%s\n", result);
        // last move
        int8_t lastMove = -1;
        bitbrd change = 0;
        {
            if(pos->nMoveNum>=1 && pos->nMoveNum<=64){
                lastMove = pos->moves[pos->nMoveNum-1];
                change = pos->changes[pos->nMoveNum-1];
            }
        }
        // board
        {
            bitbrd taken = pos->white | pos->black;
            // legal
            Board board(pos->white, pos->black);
            bitbrd legal = board.getLegal(pos->side);
            sprintf(result, "%s `  a  b  c  d  e  f  g  h\n", result);
            for(int32_t y=0; y<8; y++){
                sprintf(result, "%s %d ", result, y+1);
                for (int32_t x=0; x<8; x++) {
                    int32_t i = 8*y+x;
                    // piece in position
                    if (taken & MOVEMASK[i]) {
                        // check is last
                        bool isLast = false;
                        bool isLastMove = false;
                        {
                            if(i==lastMove){
                                isLast = true;
                                isLastMove = true;
                            }
                            if(change & MOVEMASK[i]){
                                isLast = true;
                            }
                        }
                        if (pos->black & MOVEMASK[i]){
                            if(!isLastMove){
                                sprintf(result, isLast ? "%s B " : "%s b ", result);
                            }else{
                                sprintf(result, isLast ? "%s[B]" : "%s b ", result);
                            }
                        } else {
                            if(!isLastMove){
                                sprintf(result, isLast ? "%s W " : "%s w ", result);
                            }else{
                                sprintf(result, isLast ? "%s[W]" : "%s w ", result);
                            }
                        }
                    } else {
                        if (legal & MOVEMASK[i]) {
                            /*{
                             char strMove[3];
                             printMove(i, strMove);
                             printf("legal move: %d %s\n", i, strMove);
                             }*/
                            sprintf(result, "%s + ", result);
                        } else {
                            sprintf(result, "%s - ", result);
                        }
                    }
                }
                sprintf(result, "%s\n", result);
            }
        }
        sprintf(result, "%s\n", result);
        printf("%s", result);
    }
    
    void reversi_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // print
        printPosition(&pos);
    }

    int32_t reversi_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        // init position
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // set board
        Board board(pos.white, pos.black);
        // have any move left?
        if(board.getLegal(WHITE)==0 && board.getLegal(BLACK)==0){
            printf("white count: %d, black count: %d\n", board.count(WHITE), board.count(BLACK));
            int32_t whiteCount = board.count(WHITE);
            int32_t blackCount = board.count(BLACK);
            if(blackCount>whiteCount){
                // black win
                return 1;
            }else if(whiteCount>blackCount){
                // white win
                return 2;
            }else{
                // draw
                return 3;
            }
        }else{
            return 0;
        }
    }
    
    int8_t reversi_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t sort, int32_t min, int32_t max, int32_t end, int32_t msLeft, bool useBook, int32_t percent)
    {
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // side
        Side mSide = BLACK;
        {
            if(pos.side==0){
                mSide = WHITE;
            }else if(pos.side==1){
                mSide = BLACK;
            }
        }
        // set player
        Player p(mSide);
        p.setDepths(sort, min, max, end);
        p.useBook = useBook;
        p.otherHeuristic = true;
        p.percent = percent;
        {
            p.game = Board(pos.white, pos.black);
            
            {
                MoveList moveList = p.game.getLegalMoves(mSide);
                for(int32_t i=0; i<moveList.size; i++){
                    char strMove[3];
                    reversi_printMove(moveList.moves[i], strMove);
                    // printf("legalMoves: %d %s\n", moveList.moves[i], strMove);
                }
            }
        }
        // Find lastMove
        int8_t m = p.myDoMove(msLeft);
#ifdef Android
        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "find ai move: %d\n", m);
#endif
        // rotate board
        {
            int8_t rotateMoves[ROTATE_NUM];
            int32_t rotateNum = 0;
            // find rotate moves
            {
                if(m>=0 && m<=63){
                    // rotateBitboardA1H8
                    for(int32_t i = 0; i<ROTATE_NUM; i++){
                        RotateType rotateType = (RotateType)i;
                        PositionStruct rotatePos;
                        rotatePos.rotatePos(&pos, rotateType);
                        // rotate move
                        if(rotatePos.white==pos.white && rotatePos.black==pos.black){
                            // print position rotate the same
                            {
                                printf("rotatePosition: %d\n", rotateType);
                                printPosition(&rotatePos);
                            }
                            int8_t rm = rotateMove(m, rotateType);
                            // print
                            {
                                char strMove[3];
                                reversi_printMove(rm, strMove);
                                printf("find rotateMove: %s ", strMove);
                                printMove(m);
                                printf("\n");
                            }
                            // add rotate move
                            {
                                rotateMoves[rotateNum] = rm;
                                rotateNum++;
                            }
                        }
                        printf("\n");
                    }
                }else{
                    printf("error, why m wrong: %d\n", m);
                }
            }
            // random
            if(rotateNum>0 && rotateNum<=ROTATE_NUM){
                static PRNG rng(now());
                int32_t choseIndex = abs(rng.rand<int>())%(rotateNum+1);
                if(choseIndex>=0 && choseIndex<rotateNum){
                    int8_t chosenMove = rotateMoves[choseIndex];
                    // print
                    {
                        char strMove[3];
                        reversi_printMove(chosenMove, strMove);
                        printf("choose rotateMove: %s ", strMove);
                        printMove(m);
                        printf("\n");
                    }
                    // return
                    return chosenMove;
                }else{
                    printf("don't choose rotate move\n");
                }
            }
        }
        // return
        return m;
    }
    
    bool reversi_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int8_t move)
    {
        // init position
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // check legal
        Board board(pos.white, pos.black);
        // check legal move
        {
            // get side
            Side side = WHITE;
            {
                if(pos.side==0){
                    side = WHITE;
                }else{
                    side = BLACK;
                }
            }
            printf("checkMove: %d, %d\n", move, side);
            return board.checkMove(move, side);
        }
    }

    int32_t reversi_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int8_t move, uint8_t* &outRet)
    {
        // init position
        PositionStruct pos;
        {
            PositionStruct::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // board
        Board board(pos.white, pos.black);
        // history
        if(pos.nMoveNum>=0 && pos.nMoveNum<64){
            pos.moves[pos.nMoveNum] = move;
            pos.oldSides[pos.nMoveNum] = pos.side;
            // change mask
            {
                if (move >=0 && move<64) {
                    pos.changes[pos.nMoveNum] = board.getDoMove(move, pos.side);
                }else{
                    pos.changes[pos.nMoveNum] = 0;
                }
            }
            pos.nMoveNum++;
        }else{
            printf("error, pos: nMoveNum error: %d\n", pos.nMoveNum);
        }
        // find side
        Side side = WHITE;
        {
            if(pos.side==0){
                side = WHITE;
            }else{
                side = BLACK;
            }
        }
        // do move
        printf("doMove: %d, %d\n", move, pos.side);
        board.doMove(move, pos.side);
        printf("doMove: white count: %d, black count: %d\n", board.count(WHITE), board.count(BLACK));
        // update
        {
            pos.white = board.pieces[0];
            pos.black = board.pieces[1];
            // side
            {
                // find new side
                Side newSide = WHITE;
                if(pos.side==0){
                    newSide = BLACK;
                }else{
                    newSide = WHITE;
                }
                if(board.getLegal(newSide)!=0){
                    if(newSide==WHITE){
                        pos.side = 0;
                    }else{
                        pos.side = 1;
                    }
                }else{
                    printf("new position not change side: %d\n", newSide);
                }
            }
        }
        // return
        int32_t newLength = PositionStruct::convertToByteArray(&pos, outRet);
        return newLength;
    }
}
