//
//  fairy_chess_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 8/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "fairy_chess_jni.hpp"
#include "fairy_chess_position.hpp"
#include "fairy_chess_bitboard.hpp"
#include "fairy_chess_search.hpp"
#include "fairy_chess_thread.hpp"
#include "fairy_chess_tt.hpp"
#include "fairy_chess_uci.hpp"
#include "syzygy/fairy_chess_tbprobe.hpp"
#include "fairy_chess_evaluate.hpp"

namespace FairyChess
{
    
    namespace PSQT {
        void init();
    }
    
    bool alreadyInitFairyChess = false;
    
    void fairy_chess_initCore()
    {
        if(!alreadyInitFairyChess){
            alreadyInitFairyChess = true;
            variants.init();
            UCI::init(Options);
            PSQT::init();
            Bitboards::init();
            Position::init();
            Bitbases::init();
            Search::init();
            Pawns::init();
            Tablebases::init(Options["SyzygyPath"]);
        }
    }
    
    void fairy_chess_printMove(int32_t move, Position* position)
    {
        char strMove[100];
        UCI::move(strMove, *position, (Move)move);
        printf("move: %s\n", strMove);
    }
    
    int32_t fairy_chess_makePositionByFen(VariantType variantType, const char* strFen, bool isChess960, uint8_t* &outRet)
    {
        int32_t ret = 0;
        {
            // Make position
            Position* pos = new Position;
            StateInfo* st = (StateInfo*)calloc(1, sizeof(StateInfo));;
            {
                st->previous = NULL;
            }
            pos->set(getVariantByType(variantType), strFen, isChess960, st, NULL);
            // add to remove later
            pos->sts = new std::vector<StateInfo*>;
            pos->pushStateInfo(st);
            // return
            {
                ret = Position::convertToByteArray(pos, outRet);
            }
            // free data
            pos->freeData();
            delete pos;
        }
        return ret;
    }
    
    void fairy_chess_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // print position
        {
            char strPos[1000];
            printPos(strPos, *pos);
            printf("%s\n", strPos);
        }
        // free data
        pos->freeData();
        delete pos;
    }
    
    int32_t fairy_chess_getStrPosition(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrPosition)
    {
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char ret[5000];
            {
                printPos(ret, pos);
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
        }
        // free data
        pos.freeData();
        // return
        return outLength;
    }
    
    void fairy_chess_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // print
        {
            char fen[200];
            pos->myFen(fen);
            printf("positionFen: %s\n", fen);
        }
        // free data
        pos->freeData();
        delete pos;
    }
    
    int32_t fairy_chess_getPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen)
    {
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char fen[300];
            {
                pos.myFen(fen);
            }
            // make
            {
                outLength = (int)(strlen(fen) + 1);
                // make out
                {
                    outStrFen = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrFen, fen, outLength);
                }
            }
        }
        // free data
        pos.freeData();
        // return
        return outLength;
    }
    
    int32_t fairy_chess_getStrMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outStrMove)
    {
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make strPosition
        int32_t outLength = 0;
        {
            // get
            char strMove[100];
            {
                UCI::move(strMove, pos, (Move)move);
            }
            // make
            {
                outLength = (int)(strlen(strMove) + 1);
                // make out
                {
                    outStrMove = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrMove, strMove, outLength);
                }
            }
        }
        // free data
        pos.freeData();
        // return
        return outLength;
    }
    
    bool fairy_chess_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        bool ret = true;
        // make position
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // check
        {
            ret = pos->myPosIsOk();
        }
        // free data
        pos->freeData();
        delete pos;
        // return
        return ret;
    }
    
    int32_t fairy_chess_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        // make position
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        if(pos->myPosIsOk()){
            // is draw
            if(ret==0){
                if(pos->is_draw(0)){
                    ret = 3;
                }
            }
            // black or white win
            if(ret==0){
                if(MoveList<LEGAL>(pos).size()==0){
                    // don't have any legal move, finish
                    // TODO have check move
                    bool hasCheckMove = true;
                    {
                        hasCheckMove = true;
                        /*if(pos.checkers()!=0){
                            hasCheckMove = true;
                        }else{
                            hasCheckMove = false;
                        }*/
                    }
                    if(hasCheckMove){
                        if(pos->sideToMove==BLACK){
                            ret = 1;
                        }else{
                            ret = 2;
                        }
                    }else{
                        ret = 3;
                    }
                }
            }
        }else{
            printf("position wrong");
            ret = 0;
        }
        // free data
        pos->freeData();
        delete pos;
        // return
        return ret;
    }
    
    /////////////////////////////////////////////////////////////////////////////
    //////////////////// LetComputerThink /////////////////////
    /////////////////////////////////////////////////////////////////////////////
    
    int32_t fairy_chess_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration)
    {
        int32_t ret = MOVE_NONE;
        // make position
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // search
        if(pos->myPosIsOk()){
            // Make thread
            Thread* th = new Thread(0);
            // Search
            if(th){
                // set thread
                pos->thisThread = th;
                // init property
                th->nodes = th->tbHits = 0;
                th->rootDepth = th->completedDepth = DEPTH_ZERO;
                // limit: gioi han thoi gian tim kiem, do sau
                Search::LimitsType limits;
                {
                    limits.startTime = now(); // As early as possible!
                    limits.duration = duration;
                    limits.depth = depth;
                    limits.movetime = 10;
                    limits.time[WHITE] = 0;
                    limits.time[BLACK] = 0;
                    
                    th->lms = limits;
                    
                    // TODO chu y neu de 20 thi
                    th->skillLevel = skillLevel;
                }
                // search
                {
                    th->clear();
                    // set root
                    {
                        // memcpy(&th->rootPos, &pos, sizeof(Position));
                        th->rootPos = pos;
                        // rootMoves
                        {
                            Search::RootMoves rootMoves;
                            {
                                for (const auto& m : MoveList<LEGAL>(pos))
                                    if (   limits.searchmoves.empty()
                                        || std::count(limits.searchmoves.begin(), limits.searchmoves.end(), m))
                                        rootMoves.emplace_back(m);
                                
                                if (!rootMoves.empty()) {
                                    // Tablebases::filter_root_moves(pos, rootMoves);
                                    Tablebases::rank_root_moves(pos, rootMoves);
                                }
                            }
                            th->rootMoves = rootMoves;
                        }
                    }
                    // search
                    {
                        if(th->rootMoves.size()>0){
                            th->search();
                            ret = th->rootMoves[0].pv[0];
                        }else{
                            printf("error, don't have root move\n");
                        }
                    }
                }
            } else {
                printf("thread null\n");
            }
            // printMove
            fairy_chess_printMove(ret, pos);
            // free data
            delete th;
        } else {
            printf("position not ok\n");
        }
        // free data
        pos->freeData();
        delete pos;
        // return
        return ret;
    }
    
    bool isLegalMoveByByte(Position* pos, int32_t move)
    {
        bool ret = false;
        {
            for (const auto& m : MoveList<LEGAL>(pos)) {
                if((int)m==move){
                    ret = true;
                    break;
                }
            }
        }
        return ret;
    }
    
    bool fairy_chess_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move)
    {
        bool ret = false;
        {
            Position* pos = new Position;
            {
                pos->sts = new std::vector<StateInfo*>;
                Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
            }
            // Check
            if(pos->myPosIsOk()){
                ret = isLegalMoveByByte(pos, move);
            }else{
                printf("position not ok");
            }
            // free data
            pos->freeData();
            delete pos;
        }
        return ret;
    }
    
    int32_t fairy_chess_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // make position
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        if(pos->myPosIsOk()){
            if(!isLegalMoveByByte(pos, move)){
                ret = 0;
            }else{
                Move m = (Move)move;
                // do move
                StateInfo* newSt = (StateInfo*)calloc(1, sizeof(StateInfo));;
                {
                    pos->pushStateInfo(newSt);
                }
                pos->do_move(m, *newSt);
                // convert to return value
                ret = Position::convertToByteArray(pos, outRet);
            }
        }else{
            printf("position not ok");
        }
        // free data
        pos->freeData();
        delete pos;
        // return
        return ret;
    }
    
    int32_t fairy_chess_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // make position
        Position* pos = new Position;
        {
            pos->sts = new std::vector<StateInfo*>;
            Position::parseByteArray(pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLegalMovesLength = 0;
        if(pos->myPosIsOk()) {
            MoveList<LEGAL> moveList = MoveList<LEGAL>(pos);
            if(moveList.size()>0){
                // init
                outLegalMovesLength = (int)(moveList.size()*sizeof(int32_t));
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy byte
                int32_t moveIndex = 0;
                for (const auto& m : moveList) {
                    int32_t move = (int32_t)m;
                    memcpy(outLegalMoves + sizeof(int32_t)*moveIndex, &move , sizeof(int32_t));
                    // chess_printMove(move, pos.chess960);
                    moveIndex++;
                }
            }
        }else{
            printf("error, position not ok\n");
        }
        // free data
        pos->freeData();
        delete pos;
        // return
        return outLegalMovesLength;
    }
    
}
