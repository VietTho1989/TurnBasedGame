//
//  main.cpp
//  Khet
//
//  Created by Viet Tho on 12/18/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "khet_main.hpp"
#include "khet_CommsHandler.hpp"
#include "khet_MoveGenerator.hpp"
#include "khet_Board.hpp"
#include "khet_jni.hpp"
#include <iostream>
#include <string>

namespace Khet
{
    // Count the number of moves available in the position.
    int32_t CountMoves(const Board& board)
    {
        MoveGenerator gen(board);
        int32_t count = 0;
        Move move = NoMove;
        while ((move = gen.Next()) != NoMove)
        {
            // std::cout << GetStart(move) << " " << GetEnd(move) << " " << GetRotation(move) << std::endl;
            ++count;
        }
        
        return count;
    }
    
    void *threadMyTest(void *vargp)
    {
        TT _table;
        _table.Clear();
        Board _board("x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0");
        printf("%s\n", _board.ToString().c_str());
        printf("MaxGameLength: %d\n", MaxGameLength);
        // search
        int32_t turn = 0;
        do{
            printf("turn: %d, %d, %d\n", turn, _board.IsCheckmate(), _board.IsDraw());
            if(_board.IsCheckmate()){
                printf("board check mate\n");
                break;
            }else if(_board.IsDraw()){
                printf("board draw\n");
                break;
            }
            printf("Count Moves: %d\n", CountMoves(_board));
            SearchParams params;
            {
                // neu depth = 0 thi moveTime moi co tac dung
                params._infinite = false;
                params._moveTime = 5000;
                params._depth = 0;
            }
            _table.Age();
            Search _search;
            int32_t score = 0;
            Move bestMove = _search.Start(_table, params, _board, score);
            printf("score: %d, bestMove: %d\n", score, bestMove);
            printf("%s\n", _board.ToString().c_str());
            turn++;
            if(bestMove==0 || turn>=2000){
                printf("bestMove 0\n");
                // find a legal move
                Move move = NoMove;
                {
                    MoveGenerator gen(_board);
                    while ((move = gen.Next()) != NoMove)
                    {
                        break;
                    }
                }
                if(move!=NoMove){
                    printf("make a legal move\n");
                    _board.MakeMove(move);
                }else{
                    printf("error, don't have any legal move");
                    break;
                }
            }else{
                _board.MakeMove(bestMove);
            }
        }while (true);
        
        return NULL;
    }
    
    void *threadTest(void *vargp)
    {
        {
            uint8_t* startPositionBytes;
            const std::string Standard = "x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0";
            const std::string Dynasty = "x33p3a3p23/5k4/p13p3a3s23/p21s11P41P23/3p41p21S11P4/3S2A1P13P3/4K5/3P4A1P13X1 0";
            const std::string Imhotep = "x33a3ka3s22//3P42p13/p1P32P2s22p2P4/p2P42S2p42p1P3/3P32p23//2S2A1KA13X1 0";
            int32_t length = khet_makePositionByFen(Imhotep.c_str(), startPositionBytes);
            // Make a match
            {
                int32_t turn = 0;
                uint8_t* positionBytes = startPositionBytes;
                int32_t positionLength = length;
                do{
                    printf("before letComputerThink: %d %d\n", turn, positionLength);
                    {
                        uint8_t* outStrPosition;
                        khet_getStrPosition(positionBytes, positionLength, true, outStrPosition);
                        free(outStrPosition);
                    }
                    // fen
                    {
                        uint8_t* outStrFen;
                        khet_position_to_fen(positionBytes, positionLength, true, outStrFen);
                        free(outStrFen);
                    }
                    // laserPath
                    {
                        uint8_t* outStrPath;
                        khet_getLaserPath(positionBytes, positionLength, true, outStrPath);
                        free(outStrPath);
                    }
                    // legalMoves
                    {
                        uint8_t* outLegalMoves;
                        int32_t outLegalMovesLength = khet_getLegalMoves(positionBytes, positionLength, true, outLegalMoves);
                        if(outLegalMovesLength!=0){
                            free(outLegalMoves);
                        }
                        printf("outLegalMoves: %d\n", outLegalMovesLength);
                    }
                    // laserPath
                    {
                        // silver
                        {
                            uint8_t* outSilverPath;
                            int32_t outSilverPathLength = khet_getMyLaserPath(positionBytes, positionLength, true, (int32_t)Player::Silver, outSilverPath);
                            if(outSilverPathLength!=0){
                                free(outSilverPath);
                            }
                            printf("outSilverPath: %d\n", outSilverPathLength);
                        }
                        // red
                        {
                            uint8_t* outRedPath;
                            int32_t outRedPathLength = khet_getMyLaserPath(positionBytes, positionLength, true, (int32_t)Player::Red, outRedPath);
                            if(outRedPathLength!=0){
                                free(outRedPath);
                            }
                            printf("outRedPath: %d\n", outRedPathLength);
                        }
                    }
                    int32_t gameFinish = khet_isGameFinish(positionBytes, positionLength, true);
                    if(gameFinish==0){
                        uint32_t move = khet_letComputerThink(positionBytes, positionLength, true, false, 20000, 0, 90);
                        if(move!=0){
                            // print move to string
                            {
                                uint8_t* outStrMove;
                                khet_getStrMove(move, outStrMove);
                                free(outStrMove);
                            }
                            // check legal move
                            if(khet_isLegalMove(positionBytes, positionLength, true, move)){
                                // do move
                                uint8_t* newOutRet;
                                int32_t newLength = khet_doMove(positionBytes, positionLength, true, move, newOutRet);
                                // set new position bytes
                                {
                                    free(positionBytes);
                                    positionBytes = newOutRet;
                                    positionLength = newLength;
                                }
                            }else{
                                printf("error: why not legal move: %d\n", move);
                                //fairy_chess_printMove(move, chess960);
                                // print pos
                                {
                                    uint8_t* outStrPosition;
                                    khet_getStrPosition(positionBytes, positionLength, true, outStrPosition);
                                    free(outStrPosition);
                                }
                                break;
                            }
                        }else{
                            printf("error, why don't find any move, break\n");
                            // print pos
                            {
                                uint8_t* outStrPosition;
                                khet_getStrPosition(positionBytes, positionLength, true, outStrPosition);
                                free(outStrPosition);
                            }
                        }
                        turn++;
                    }else{
                        printf("game finish in turn: %d\n", turn);
                        // print pos
                        {
                            uint8_t* outStrPosition;
                            khet_getStrPosition(positionBytes, positionLength, true, outStrPosition);
                            free(outStrPosition);
                        }
                        switch (gameFinish) {
                            case 1:
                                printf("silver win\n");
                                break;
                            case 2:
                                printf("red win\n");
                                break;
                            case 3:
                                printf("the game is draw\n");
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                    std::this_thread::sleep_for (std::chrono::seconds(1));
                }while (true);
                // free data
                if(positionBytes!=NULL){
                    free(positionBytes);
                }
            }
        }
        return NULL;
    }
    
    int32_t khet_main(int32_t matchCount, std::string ResourcePath)
    {
        printf("hello world: %lu, %lu\n", sizeof(Evaluator), sizeof(EvalLaser));
        khet_initCore();
        
        // Test Fen
        /*{
            Board _board("x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0");
            //"x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0"
            // x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0
            // x23a2ka2p12/2p27/3P36/p01P21s0s11p11P3/p11P31S1S01p01P2/6p13/7P02/2P3A0KA03X0 0
            char fen[200];
            {
                fen[0] = 0;
            }
            _board.makeFen(fen);
            printf("fen: %s\n", fen);
        }*/
        
        pthread_attr_t attr;
        pthread_attr_init(&attr);
        pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED);
        pthread_attr_setstacksize(&attr, 10*1048576);
        
        for(int32_t i=0; i<matchCount; i++){
            pthread_t tid;
            pthread_create(&tid, &attr, threadTest, NULL);
        }
        
        return 0;
    }
}

/*
************
*xP...k.p..*
*.....a...P*
*.....sp...*
*..........*
*.p..Ss....*
*p.....S...*
*..P.......*
*...P..K..X*
************

************
*22...0.1..*
*.....1...2*
*.....01...*
*..........*
*.0..12....*
*0.....3...*
*..3.......*
*...3..0..0*
************
*/

/*
 ************
 *x...ak.p..*
 *......a...*
 *...P......*
 *.P...p...P*
 *..A.p.....*
 *p.s..S....*
 *.....SA..P*
 *....Ks...X*
 ************
 
 ************
 *2...20.1..*
 *......2...*
 *...3......*
 *.3...1...3*
 *..0.2.....*
 *0.0..1....*
 *.....11..2*
 *....01...0*
 ************
*/
