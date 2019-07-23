//
//  chinese_checkers_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 1/31/19.
//  Copyright © 2019 Viet Tho. All rights reserved.
//

#include "chinese_checkers_jni.hpp"
#include "chinese_checkers_board.hpp"
#include "chinese_checkers_search.hpp"
#include "chinese_checkers_ricefish.hpp"

namespace ChineseCheckers
{
    
    int32_t chinese_checkers_makePositionByFen(const char* strFen, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // Make position
            Board pos(strFen);
            // return
            {
                ret = Board::convertToByteArray(&pos, outRet);
            }
        }
        return ret;
    }
    
    int32_t chinese_checkers_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        // make position
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // check
        {
            switch(board.get_winner())
            {
                case Pebble::NO_PEBBLE:
                    break;
                case Pebble::P1:
                    ret = 1;
                    break;
                case Pebble::P2:
                    ret = 2;
                    break;
                case Pebble::INVALID:
                    break;
                default:
                    printf("error, unknown winner\n");
                    break;
            }
        }
        // return
        return ret;
    }
    
    int32_t chinese_checkers_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t type, int32_t depth, int32_t time, int32_t node, int32_t pickBestMove, uint8_t* &outRet)
    {
        // Make Pos
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // Search
        Move move;
        {
            MyProtocol myProtocol;
            {
                myProtocol.isFinishSearch = false;
            }
            Search* search = new Search(myProtocol);
            // init paramater
            {
                switch (type) {
                    case 0:
                        search->new_depth_search(board, depth);
                        break;
                    case 1:
                        search->new_time_search(board, time);
                        break;
                    case 2:
                        search->new_nodes_search(board, node);
                        break;
                    default:
                        search->new_time_search(board, time);
                        break;
                }
                search->pickBestMove = pickBestMove;
            }
            search->start();
            // wait to finish search
            while (!myProtocol.isFinishSearch) {
                std::this_thread::sleep_for (std::chrono::seconds(1));
            }
            // set move
            {
                move.from.x = myProtocol.bestMove.from.x;
                move.from.y = myProtocol.bestMove.from.y;
                move.to.x = myProtocol.bestMove.to.x;
                move.to.y = myProtocol.bestMove.to.y;
            }
            // free data
            {
                search->quit();
                delete search;
            }
        }
        // get result
        int32_t ret = 0;
        {
            ret = Move::convertToByteArray(&move, outRet);
        }
        // return
        return ret;
    }
    
    bool chinese_checkers_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        // Make Pos
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // Make Move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // Check
        bool ret = false;
        {
            MoveGenerator generator;
            MoveList<MoveEntry> move_list = generator.get_moves(board);
            if(move_list.contains(move)){
                ret = true;
            }else{
                printf("error, not contain legal move\n");
            }
        }
        // return
        return ret;
    }
    
    int32_t chinese_checkers_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, uint8_t* &outRet)
    {
        // Make Pos
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // Make Move
        Move move;
        {
            Move::parseByteArray(&move, moveBytes, moveLength, 0, canCorrect);
        }
        // doMove
        {
            board.make_move(move);
        }
        // return
        int32_t ret = Board::convertToByteArray(&board, outRet);
        return ret;
    }
    
    int32_t chinese_checkers_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // Make Pos
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // get move
        int32_t outLegalMovesLength = 0;
        {
            // get move list
            MoveGenerator generator;
            MoveList<MoveEntry> move_list = generator.get_moves(board);
            // convert
            if(move_list.size>0){
                // init
                outLegalMovesLength = (int32_t)move_list.size*Move::getByteSize();
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy bytes
                {
                    int32_t i = 0;
                    for (const auto& e : move_list) {
                        uint8_t* moveBytes;
                        {
                            Move move = e->move;
                            Move::convertToByteArray(&move, moveBytes);
                        }
                        memcpy(outLegalMoves + Move::getByteSize()*i, moveBytes , Move::getByteSize());
                        free(moveBytes);
                        i++;
                    }
                }
            }else{
                printf("why don't have any legal moves\n");
            }
        }
        return outLegalMovesLength;
    }
    
    int32_t chinese_checkers_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        // make pos
        Board board;
        {
            Board::parseByteArray(&board, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[1000];
            {
                board.print(ret);
                printf("\n%s\n", ret);
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
    
}
