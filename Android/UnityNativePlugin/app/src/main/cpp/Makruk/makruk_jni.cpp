//
//  makruk_jni.cpp
//  NativeCore
//
//  Created by Viet Tho on 7/24/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "makruk_jni.hpp"
#include "engine/makruk_uci.hpp"
#include "engine/makruk_bitboard.hpp"
#include "engine/makruk_search.hpp"
#include "engine/makruk_pawns.hpp"
#include "engine/syzygy/makruk_tbprobe.hpp"
#include "engine/makruk_tt.hpp"
#include "engine/makruk_thread.hpp"
#include "engine/makruk_position.hpp"

namespace Makruk
{
    
    namespace PSQT {
        void init();
    }
    
    bool alreadyInitMakruk = false;
    
    void makruk_initCore()
    {
        if(!alreadyInitMakruk){
            alreadyInitMakruk = true;
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
    
    void makruk_printMove(int32_t move)
    {
        char strMove[100];
        UCI::move(strMove, (Move)move);
        printf("move: %s\n", strMove);
    }
    
    int32_t makruk_makePositionByFen(const char* strFen, bool isChess960, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // Make position
        Position position;
        StateInfo* st = (StateInfo*)calloc(1, sizeof(StateInfo));
        {
            st->previous = NULL;
        }
        position.set(strFen, isChess960, st, NULL);
        // add to free later
        position.sts = new std::vector<StateInfo*>;
        position.pushStateInfo((st));
        // return
        {
            ret = Position::convertToByteArray(&position, outRet);
        }
        // free data
        position.freeData();
        // return
        return ret;
    }
    
    void makruk_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // print position
        printPos(pos);
        // free data
        pos.freeData();
    }
    
    void makruk_printPositionFen(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // print
        {
            char fen[200];
            pos.myFen(fen);
            printf("positionFen: %s\n", fen);
        }
        // free data
        pos.freeData();
    }
    
    
    bool makruk_isPositionOk(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        bool ret = true;
        {
            // make position
            Position pos;
            {
                pos.sts = new std::vector<StateInfo*>;
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // check
            {
                ret = pos.myPosIsOk();
            }
            // free data
            pos.freeData();
        }
        return ret;
    }
    
    int32_t makruk_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        // make position
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        if(pos.myPosIsOk()){
            // is draw
            if(ret==0){
                if(pos.myIsDraw()){
                    printf("game finish, my game is draw1\n");
                    ret = 3;
                }
            }
            // black or white win
            if(ret==0){
                if(MoveList<LEGAL>(pos).size()==0){
                    printf("game finish, don't have legal move\n");
                    if(pos.sideToMove==BLACK){
                        ret = 1;
                    }else{
                        ret = 2;
                    }
                }
            }
        }else{
            printf("position wrong");
            ret = 0;
        }
        // free data
        pos.freeData();
        // return
        return ret;
    }
    
    /////////////////////////////////////////////////////////////////////////////
    //////////////////// LetComputerThink /////////////////////
    /////////////////////////////////////////////////////////////////////////////
    
    int32_t makruk_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int64_t duration)
    {
        int32_t ret = MOVE_NONE;
        // make position
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // search
        if(pos.myPosIsOk()){
            // Make thread
            Thread* th = new Thread(0);
            // Search
            if(th){
                // set thread
                pos.thisThread = th;
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
                // TODO tam bo th->nmp_ply = 0;
                // TODO tam bo th->pair = -1;
                // search
                {
                    th->clear();
                    // set root
                    {
                        // copy to root th->rootPos.set(pos.fen(), pos.is_chess960(), st, th);
                        memcpy(&th->rootPos, &pos, sizeof(Position));
                        // rootMoves
                        {
                            Search::RootMoves rootMoves;
                            {
                                for (const auto& m : MoveList<LEGAL>(pos))
                                    if (   limits.searchmoves.empty()
                                        || std::count(limits.searchmoves.begin(), limits.searchmoves.end(), m))
                                        rootMoves.emplace_back(m);
                                
                                if (!rootMoves.empty())
                                    Tablebases::filter_root_moves(pos, rootMoves);
                            }
                            th->rootMoves = rootMoves;
                        }
                    }
                    
                    TimePoint beforeTime = now();
                    th->search();
                    TimePoint afterTime = now();
                    
                    printf("chess_letComputerThink: time: %lld, %lld\n", beforeTime, afterTime);
                    // printf("find best move: test\n");
                    {
                        if(th->rootMoves.size()>0){
                            ret = th->rootMoves[0].pv[0];
                        }
                    }
                }
            } else {
                printf("thread null\n");
            }
            // free data
            {
                // pos.thisThread = NULL;
                delete th;
            }
        } else {
            printf("position not ok\n");
        }
        // free data
        pos.freeData();
        // return
        return ret;
    }
    
    bool isLegalMoveByByte(Position* pos, int32_t move)
    {
        bool ret = false;
        {
            for (const auto& m : MoveList<LEGAL>(*pos)) {
                if((int)m==move){
                    ret = true;
                    break;
                }
            }
        }
        return ret;
    }
    
    bool makruk_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move)
    {
        bool ret = false;
        {
            Position pos;
            {
                pos.sts = new std::vector<StateInfo*>;
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // Check
            if(pos.myPosIsOk()){
                ret = isLegalMoveByByte(&pos, move);
            }else{
                printf("position not ok");
            }
            // free data
            pos.freeData();
        }
        return ret;
    }
    
    int32_t makruk_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, int32_t move, uint8_t* &outRet)
    {
        int32_t ret = 0;
        // make position
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        if(pos.myPosIsOk()){
            if(!isLegalMoveByByte(&pos, move)){
                ret = 0;
            }else{
                Move m = (Move)move;
                // do move
                StateInfo* newSt = (StateInfo*)calloc(1, sizeof(StateInfo));
                {
                    pos.pushStateInfo(newSt);
                }
                pos.do_move(m, *newSt);
                // convert to return value
                ret = Position::convertToByteArray(&pos, outRet);
            }
        }else{
            printf("position not ok");
        }
        // free data
        pos.freeData();
        // return
        return ret;
    }
    
    int32_t makruk_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // make position
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLegalMovesLength = 0;
        if(pos.myPosIsOk()) {
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
        pos.freeData();
        // return
        return outLegalMovesLength;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////// Print ///////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    int32_t makruk_position_to_fen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen)
    {
        // make position
        Position pos;
        {
            pos.sts = new std::vector<StateInfo*>;
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make fen
        int32_t outLength = 0;
        {
            char strFen[200];
            {
                strFen[0] = 0;
            }
            pos.myFen(strFen);
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
        // free data
        pos.freeData();
        return outLength;
    }
    
}
