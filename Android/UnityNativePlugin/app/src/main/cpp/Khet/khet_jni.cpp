//
//  khet_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 12/19/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "khet_jni.hpp"
#include "khet_Board.hpp"
#include "khet_Types.hpp"
#include "khet_MoveGenerator.hpp"
#include "khet_Search.hpp"

namespace Khet
{
    
    bool alreadyInitKhet = false;
    
    void khet_initCore()
    {
        if(!alreadyInitKhet){
            alreadyInitKhet = true;
            Board::Board_Init();
        }
    }
    
    int32_t khet_makePositionByFen(const char* strFen, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // Make position
            Board pos(strFen);
            // return
            ret = Board::convertToByteArray(&pos, outRet);
        }
        return ret;
    }
    
    int32_t khet_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        // make position
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // check
        {
            if(pos.IsDraw()){
                return 3;
            }else if(pos.IsCheckmate()){
                if(pos.PlayerToMove()==Player::Silver){
                    // silver is checkmated, red win
                    return 2;
                }else{
                    // ret is checkmated, silver win
                    return 1;
                }
            }else{
                MoveGenerator gen(pos);
                int32_t count = 0;
                Move move = NoMove;
                while ((move = gen.Next()) != NoMove)
                {
                    // std::cout << GetStart(move) << " " << GetEnd(move) << " " << GetRotation(move) << std::endl;
                    ++count;
                }
                if(count==0){
                    printf("don't have any legal move\n");
                    if(pos.PlayerToMove()==Player::Silver){
                        // silver is checkmated, red win
                        return 2;
                    }else{
                        // ret is checkmated, silver win
                        return 1;
                    }
                }
            }
        }
        // return
        return ret;
    }
    
    uint32_t khet_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool infinite, int32_t moveTime, int32_t depth, int32_t pickBestMove)
    {
        uint32_t ret = NoMove;
        // make position
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // search
        {
            TT _table;
            _table.Clear();
            // searchParams
            SearchParams params;
            {
                // neu depth = 0 thi moveTime moi co tac dung
                params._infinite = infinite;
                params._moveTime = moveTime;
                params._depth = depth;
                params.pickBestMove = pickBestMove;
            }
            _table.Age();
            Search _search;
            int32_t score = 0;
            Move bestMove = _search.Start(_table, params, pos, score);
            if(bestMove==0){
                printf("bestMove 0\n");
                // find a legal move
                Move move = NoMove;
                {
                    MoveGenerator gen(pos);
                    while ((move = gen.Next()) != NoMove)
                    {
                        break;
                    }
                }
                if(move!=NoMove){
                    printf("find a legal move: %d\n", move);
                    ret = move;
                }else{
                    printf("error, don't have any legal move");
                }
            }else{
                ret = bestMove;
                printf("find move: %d\n", ret);
            }
        }
        // return
        return ret;
    }
    
    bool khet_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move)
    {
        bool ret = false;
        {
            Board pos;
            {
                Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // Check
            ret = pos.IsLegal(move);
        }
        return ret;
    }
    
    int32_t khet_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint32_t move, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // make position
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // doMove
        {
            pos.MakeMove(move);
            // convert to return value
            ret = Board::convertToByteArray(&pos, outRet);
        }
        // return
        return ret;
    }
    
    int32_t khet_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // make position
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLegalMovesLength = 0;
        {
            std::vector<Move> moveList;
            {
                MoveGenerator gen(pos);
                Move move = NoMove;
                while ((move = gen.Next()) != NoMove)
                {
                    moveList.push_back(move);
                }
            }
            if(moveList.size()>0){
                // init
                outLegalMovesLength = (int)(moveList.size()*sizeof(Move));
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy byte
                int32_t moveIndex = 0;
                for (int32_t i=0; i<moveList.size(); i++) {
                    Move move = moveList[i];
                    memcpy(outLegalMoves + sizeof(Move)*moveIndex, &move , sizeof(Move));
                    moveIndex++;
                }
            }else{
                printf("error, don't have any legal moves\n");
            }
        }
        // return
        return outLegalMovesLength;
    }
    
    int32_t khet_position_to_fen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen)
    {
        // make position
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make fen
        int32_t outLength = 0;
        {
            char strFen[1000];
            {
                strFen[0] = 0;
            }
            // makeFen
            {
                pos.makeFen(strFen);
            }
            // make
            {
                outLength = (int32_t)(strlen(strFen) + 1);
                // make out
                {
                    outStrFen = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrFen, strFen, outLength);
                }
            }
            /*Board testBoard(strFen);
            printf("fen: %s\n%s\n", strFen, testBoard.ToString().c_str());*/
        }
        // return
        return outLength;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////
    ////////////////////// print /////////////////////
    ////////////////////////////////////////////////////////////////////////////////////
    
    int32_t khet_getStrPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        // make pos
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[5000];
            {
                ret[0] = 0;
                strcpy(ret, pos.ToString().c_str());
            }
            // make
            {
                outLength = (int)(strlen(ret) + 1);
                // make out
                {
                    outStrPosition = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrPosition, ret, outLength);
                }
            }
            printf("%s\n", ret);
        }
        // return
        return outLength;
    }
    
    int32_t khet_getStrMove(uint32_t move, uint8_t* &outStrMove)
    {
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[100];
            {
                ret[0] = 0;
                std::string m = move != NoMove ? ToString(move) : "none";
                strcpy(ret, m.c_str());
            }
            // make
            {
                outLength = (int)(strlen(ret) + 1);
                // make out
                {
                    outStrMove = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrMove, ret, outLength);
                }
            }
            printf("getStrMove: %s\n", ret);
        }
        // return
        return outLength;
    }
    
    int32_t khet_getLaserPath(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLaserPath)
    {
        // make pos
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 2*BoardArea*sizeof(int32_t);
        {
            outLaserPath = (uint8_t*)calloc(outLength, sizeof(uint8_t));
            // silver
            {
                PathLaser pathLaser;
                pathLaser.Fire(Player::Silver, pos);
                memcpy(outLaserPath, pathLaser._laserPath, BoardArea*sizeof(int32_t));
                // print
                {
                    char strPath[1000];
                    {
                        strPath[0] = 0;
                    }
                    for (int32_t r = BoardHeight - 1; r > -1; r--) {
                        for (int32_t c = 0; c < BoardWidth; c++) {
                            int32_t i = r*BoardWidth + c;
                            if (i % BoardWidth == 0) {
                                sprintf(strPath, "%s\n", strPath);
                            }
                            if(pathLaser._laserPath[i]==-1){
                                sprintf(strPath, "%s ", strPath);
                            }else if(pathLaser._laserPath[i]>=0) {
                                sprintf(strPath, "%s*", strPath);
                            }else{
                                sprintf(strPath, "%s.", strPath);
                            }
                        }
                    }
                    printf("LaserPath: Silver %s\n", strPath);
                }
            }
            // red
            {
                PathLaser pathLaser;
                pathLaser.Fire(Player::Red, pos);
                memcpy(outLaserPath+BoardArea*sizeof(int32_t), pathLaser._laserPath, BoardArea*sizeof(int32_t));
                // print
                {
                    char strPath[1000];
                    {
                        strPath[0] = 0;
                    }
                    for (int32_t r = BoardHeight - 1; r > -1; r--) {
                        for (int32_t c = 0; c < BoardWidth; c++) {
                            int32_t i = r*BoardWidth + c;
                            if (i % BoardWidth == 0) {
                                sprintf(strPath, "%s\n", strPath);
                            }
                            if(pathLaser._laserPath[i]==-1){
                                sprintf(strPath, "%s ", strPath);
                            }else if(pathLaser._laserPath[i]>=0) {
                                sprintf(strPath, "%s*", strPath);
                            }else{
                                sprintf(strPath, "%s.", strPath);
                            }
                        }
                    }
                    printf("LaserPath: Red %s\n", strPath);
                }
            }
        }
        // return
        return outLength;
    }
    
    int32_t khet_getMyLaserPath(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t player, uint8_t* &outLaserPath)
    {
        // make pos
        Board pos;
        {
            Board::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLength = 0;
        {
            // find path
            MyPathLaser myPathLaser;
            myPathLaser.Fire((Player)player, pos);
            // copy
            if(myPathLaser._laserPath.size()>0){
                // init
                outLength = (int32_t)(myPathLaser._laserPath.size()*sizeof(int32_t));
                outLaserPath = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                // copy
                for (int32_t i=0; i<myPathLaser._laserPath.size(); i++) {
                    memcpy(outLaserPath + sizeof(int32_t)*i, &myPathLaser._laserPath[i] , sizeof(int32_t));
                }
            }else{
                printf("error, don't have any laser path\n");
            }
        }
        // return
        return outLength;
    }
    
}
