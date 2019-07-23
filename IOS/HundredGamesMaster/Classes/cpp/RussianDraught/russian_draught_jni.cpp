//
//  russian_draught_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 8/22/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "russian_draught_jni.hpp"
#include "russian_draught_KALLISTO.hpp"
#include "../Platform.h"

namespace RussianDraught
{
    
    void russian_draught_initCore()
    {
        initCore();
    }
    
    int32_t russian_draught_makePositionByFen(const char* strFen, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // Make position
            Position* pos = new Position;
            {
                pos->EI_NewGame(strFen);
            }
            // return
            ret = Position::convertToByteArray(pos, outRet);
            // free data
            delete pos;
        }
        return ret;
    }
    
    int32_t russian_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Position* pos = new Position;
        {
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        int32_t ret = pos->russian_draught_isGameFinish();
        // free data
        delete pos;
        return ret;
    }
    
    int32_t russian_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t timeLimit, int32_t pickBestMove, uint8_t* &outRet)
    {
        // Make Pos
        Position* pos = new Position;
        {
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // Search
        Search* search = new Search;
        {
            search->pos = pos;
            search->timeLimit = timeLimit;
            search->pickBestMove = pickBestMove;
        }
        search->EI_Think();
        // get result
        int32_t ret = 0;
        if(search->n>0){
            ret = move2::convertToByteArray(&search->bestrootmove, outRet);
        }else{
            printf("error, don't have any move\n");
        }
        // free data
        {
            delete pos;
            delete search;
        }
        // return
        return ret;
    }
    
    bool russian_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        // Make Pos
        Position* pos = new Position;
        {
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // Make Move
        move2* move = new move2;
        {
            move2::parseByteArray(move, moveBytes, moveLength, 0, canCorrect);
        }
        // Check
        bool ret = false;
        {
            struct move2 movelist[MAXMOVES];
            int32_t n = 0;
            // gen move
            {
                n = Gen_Captures(pos->Board, movelist, pos->Color, 1, pos);
                if (!n) {
                    n = Gen_Moves(pos->Board, movelist, pos->Color, pos);
                }
            }
            if (n>=0 && n<MAXMOVES){
                for(int32_t i=0; i<n; i++) {
                    bool isEqual = true;
                    {
                        if(move->l==movelist[i].l && move->l>0 && move->l<12){
                            for(int32_t x=0; x<move->l; x++){
                                if(move->m[x]!=movelist[i].m[x]){
                                    isEqual = false;
                                    break;
                                }
                            }
                        } else {
                            isEqual = false;
                        }
                    }
                    if(isEqual){
                        ret = true;
                        break;
                    }
                }
            } else {
                printf("error, don't have any move\n");
            }
        }
        // free data
        {
            delete pos;
            delete move;
        }
        // return
        return ret;
    }
    
    int32_t russian_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // Make Pos
        Position* pos = new Position;
        {
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // Make Move
        move2* move = new move2;
        {
            move2::parseByteArray(move, moveBytes, moveLength, 0, canCorrect);
        }
        // doMove
        {
            pos->domove(move);
        }
        // return
        int32_t ret = Position::convertToByteArray(pos, outRet);
        // print
        {
/*#ifdef Debug
            // print move
            {
                char ret[128];
                {
                    ret[0] = 0;
                    MoveToStr(*move, ret);
                    printf("move: %s\n", ret);
                }
            }
            // print pos
            {
                char ret[1000];
                {
                    pos->PrintBoard(ret);
                    printf("\n%s\n", ret);
                }
            }
#endif*/
        }
        // free data
        {
            delete pos;
            delete move;
        }
        return ret;
    }
    
    int32_t russian_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // Make Pos
        Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // get move
        int32_t outLegalMovesLength = 0;
        {
            struct move2 movelist[MAXMOVES];
            int32_t n = 0;
            // gen move
            {
                n = Gen_Captures(pos.Board, movelist, pos.Color, 1, &pos);
                if (!n) {
                    n = Gen_Moves(pos.Board, movelist, pos.Color, &pos);
                }
            }
            // convert to byte array
            if(n>0 && n<MAXMOVES){
                // init
                outLegalMovesLength = n*move2::getByteSize();
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy bytes
                {
                    for(int32_t i=0; i<n; i++){
                        uint8_t* moveBytes;
                        move2::convertToByteArray(&movelist[i], moveBytes);
                        memcpy(outLegalMoves + move2::getByteSize()*i, moveBytes , move2::getByteSize());
                        free(moveBytes);
                    }
                }
            }
        }
        return outLegalMovesLength;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////// Print ///////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    int32_t russian_draught_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        // make pos
        Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[1000];
            {
                pos.PrintBoard(ret);
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
        }
        // return
        return outLength;
    }
    
    int32_t russian_draught_printMove(uint8_t* moveBytes, int32_t moveLength, bool canCorrect, uint8_t* &outStrMove)
    {
        move2 move;
        {
            move2::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // make strMove
        int32_t outLength = 0;
        {
            char ret[128];
            {
                ret[0] = 0;
                MoveToStr(move, ret);
#ifdef Debug
                printf("move: %s\n", ret);
#endif
            }
            // make
            {
                outLength = (int32_t)(strlen(ret) + 1);
                // make out
                {
                    outStrMove = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrMove, ret, outLength);
                }
            }
        }
        // return
        return outLength;
    }
    
    int32_t russian_draught_position_to_fen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen)
    {
        // make position
        Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make fen
        int32_t outLength = 0;
        {
            char strFen[200];
            {
                strFen[0] = 0;
            }
            pos.toFen(strFen);
            // make
            {
                outLength = (int32_t)(strlen(strFen) + 1);
                // make out
                {
                    outStrFen = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrFen, strFen, outLength);
                }
            }
            printf("fen: %s\n", strFen);
        }
        // return
        return outLength;
    }
    
}
