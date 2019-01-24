//
//  english_draught_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 7/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <cstring>
#include "english_draught_jni.hpp"
#include "engine/english_draught_ai.hpp"

namespace EnglishDraught
{
    char englishDraughtPath[1000];
    
    bool english_draught_setPath(const char* newPath)
    {
        bool isExist = true;
        {
            strcpy(englishDraughtPath, newPath);
        }
        return isExist;
    }
    
    void english_draught_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, SMove* lastMove)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // print
        {
            char strPos[3000];
            pos.print(strPos, lastMove);
            printf("%s", strPos);
        }
    }
    
    void english_draught_printMove(uint8_t* moveBytes, int32_t moveLength)
    {
        // make move
        struct SMove sMove;
        {
            SMove::parseByteArray(&sMove, moveBytes, moveLength, 0, true);
        }
        // print
        {
            char strMove[100];
            sMove.print(strMove);
            printf("Move: %s\n", strMove);
        }
    }
    
    bool alreadyInitEnglishDraught = false;
    
    void english_draught_initCore()
    {
        if(!alreadyInitEnglishDraught){
            alreadyInitEnglishDraught = true;
            char pc2[1100];
            {
                sprintf(pc2, "%s/%s", englishDraughtPath, "2pc.cdb");
            }
            char pc3[1100];
            {
                sprintf(pc3, "%s/%s", englishDraughtPath, "3pc.cdb");
            }
            char pc4[1100];
            {
                sprintf(pc4, "%s/%s", englishDraughtPath, "4pc.cdb");
            }
            InitEngine(pc2, pc3, pc4);
        }
    }
    
    int32_t english_draught_makeDefaultPosition(const char* englishDraughtFen, int32_t maxPly, uint8_t* &outRet)
    {
        CBoard position;
        {
            position.Clear();
            position.FromFen(englishDraughtFen);
            position.maxPly = maxPly;
        }
        // convert
        int32_t length = CBoard::convertToByteArray(&position, outRet);
        return length;
    }
    
    int32_t english_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // check
        return CheckForGameOver(pos);
    }
    
    int32_t english_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool threeMoveRandom, float fMaxSeconds, int32_t g_MaxDepth, int32_t pickBestMove, uint8_t* &outMove)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make ai
        AI ai;
        {
            ai.NewGame();
            ai.threeMoveRandom = threeMoveRandom;
            ai.fMaxSeconds = fMaxSeconds;
            ai.g_MaxDepth = g_MaxDepth;
            ai.pickBestMove = pickBestMove;
        }
        // think
        ai.ComputerMove(pos.SideToMove, pos);
        printf("find ai move: %llu\n", ai.bestMove.SrcDst);
        // return
        int32_t moveLength = SMove::convertToByteArray(&ai.bestMove, outMove);
        return moveLength;
    }
    
    bool english_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        struct SMove sMove;
        {
            SMove::parseByteArray(&sMove, moveBytes, moveLength, 0, canCorrect);
        }
        // check
        bool ret = false;
        {
            // generate move
            struct CMoveList moveList;
            {
                moveList.Clear();
                if (pos.SideToMove == BLACK) {
                    moveList.FindMovesBlack(pos.Sqs, pos.C);
                } else if (pos.SideToMove == WHITE) {
                    moveList.FindMovesWhite(pos.Sqs, pos.C);
                }
            }
            // check
            {
                for(int i=1; i<=moveList.nMoves; i++){
                    printf("moveList: legalMove: %llu, %llu\n", moveList.Moves[i].SrcDst, sMove.SrcDst);
                    {
                        char strMove[100];
                        moveList.Moves[i].print(strMove);
                        printf("LegalMove: %s\n", strMove);
                    }
                    if(moveList.Moves[i].SrcDst==sMove.SrcDst){
                        printf("find legal move\n");
                        ret = true;
                        break;
                    }
                }
            }
        }
        return ret;
    }
    
    int32_t english_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        struct SMove sMove;
        {
            SMove::parseByteArray(&sMove, moveBytes, moveLength, 0, canCorrect);
        }
        // doMove
        pos.DoMove(sMove, MAKEMOVE);
        // return
        int32_t outLength = CBoard::convertToByteArray(&pos, outRet);
        return outLength;
    }
    
    int32_t english_draught_getFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Make fen
        char strFen[300];
        {
            pos.ToFen(strFen);
        }
        int32_t fenLength = (int)strlen(strFen);
        // return
        {
            outRet = (uint8_t*)calloc(fenLength, sizeof(uint8_t));
            memcpy(outRet, strFen, fenLength);
        }
        return fenLength;
    }
    
    int32_t english_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // make position
        struct CBoard pos;
        {
            CBoard::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // generate move
        struct CMoveList moveList;
        {
            moveList.Clear();
            if (pos.SideToMove == BLACK) {
                moveList.FindMovesBlack(pos.Sqs, pos.C);
            } else if (pos.SideToMove == WHITE) {
                moveList.FindMovesWhite(pos.Sqs, pos.C);
            }
        }
        // return
        int outLegalMovesLength = moveList.nMoves*SMove::getByteSize();
        {
            // init
            outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
            // copy byte
            {
                for(int i=1; i<=moveList.nMoves; i++) {
                    uint8_t* moveByteArray;
                    int32_t moveLength = SMove::convertToByteArray(&moveList.Moves[i], moveByteArray);
                    // copy
                    {
                        memcpy(outLegalMoves + SMove::getByteSize()*(i-1), moveByteArray , moveLength);
                    }
                    // free
                    free(moveByteArray);
                }
            }
        }
        return outLegalMovesLength;
    }
    
}
