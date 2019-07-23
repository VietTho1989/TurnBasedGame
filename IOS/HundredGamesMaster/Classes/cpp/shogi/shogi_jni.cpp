//
//  shogi_jni.cpp
//  TestShogi
//
//  Created by Viet Tho on 2/16/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include <mutex>
#include <thread>
#include "shogi_jni.hpp"

#include "core/shogi_init.hpp"
#include "core/shogi_evaluate.hpp"
#include "core/shogi_search.hpp"
#include "core/shogi_generateMoves.hpp"
#include "core/shogi_book.hpp"
#include "core/shogi_position.hpp"

namespace Shogi {
    
    bool alreadyInit = false;
    
    void shogi_printMove(uint32_t move)
    {
        // make move
        Move mv(move);
        // print
        {
            char strMove[100];
            {
                mv.toUSI(strMove);
            }
            printf("move: %s\n", strMove);
        }
    }
    
    #define SS_MAX_LENGTH 3000
    
    void shogi_printPosition(u8* positionBytes, int32_t length, bool canCorrect)
    {
        Position pos;
        {
            Position::parse(&pos, positionBytes, length, 0, canCorrect);
        }
        // make string
        char ss[SS_MAX_LENGTH];
        {
            ss[0] = 0;
            // board
            {
                //const char* PieceToCharCSATable[PieceNone] = {" * ", "+FU", "+KY", "+KE", "+GI", "+KA", "+HI", "+KI", "+OU", "+TO", "+NY", "+NK", "+NG", "+UM", "+RY", "", "", "-FU", "-KY", "-KE", "-GI", "-KA", "-HI", "-KI", "-OU", "-TO", "-NY", "-NK", "-NG", "-UM", "-RY"
                //};
                char PieceToCharCSATable[PieceNone][4] = {" * ", "+FU", "+KY", "+KE", "+GI", "+KA", "+HI", "+KI", "+OU", "+TO", "+NY", "+NK", "+NG", "+UM", "+RY", "", "", "-FU", "-KY", "-KE", "-GI", "-KA", "-HI", "-KI", "-OU", "-TO", "-NY", "-NK", "-NG", "-UM", "-RY"
                };
                snprintf(ss, SS_MAX_LENGTH, "%s'  9  8  7  6  5  4  3  2  1\n", ss);
                int32_t i = 0;
                for (Rank r = Rank1; r < RankNum; ++r) {
                    ++i;
                    snprintf(ss, SS_MAX_LENGTH, "%sP%d", ss, i);
                    for (File f = File9; File1 <= f; --f){
                        const Piece pc = pos.piece(makeSquare(f, r));
                        snprintf(ss, SS_MAX_LENGTH, "%s%s", ss, PieceToCharCSATable[pc]);
                    }
                    snprintf(ss, SS_MAX_LENGTH, "%s\n", ss);
                }
            }
            /*{
                const char* handBlack = printHand(&pos, Black);
                ss += handBlack;
                delete [] handBlack;
            }*/
            /*{
                const char* handWhite = printHand(&pos, White);
                ss += handWhite;
                delete [] handWhite;
            }*/
            snprintf(ss, SS_MAX_LENGTH, "%s%s", ss, (pos.turn() == Black ? "Turn: Black\n" : "Turn: White\n"));
            snprintf(ss, SS_MAX_LENGTH, "%s\n", ss);
            snprintf(ss, SS_MAX_LENGTH, "%skey = %llu\n", ss, (u64)pos.getKey());
        }
        // return
        printf("\nmyPosition temp string: \n%s\n", ss);
    }
    
    void shogi_printPositionFen(u8* positionBytes, int32_t length, bool canCorrect)
    {
        Position pos;
        {
            Position::parse(&pos, positionBytes, length, 0, canCorrect);
        }
        // print
        char fen[1000];
        pos.myToSFEN(fen);
        printf("positionFen: %s\n", fen);
    }

    int32_t shogi_getCheckersFromBitBoard(u8* bitboardBytes, u8* &outRet)
    {
        // make bitboard
        Bitboard checker;
        {
            int32_t size = 2*sizeof(u64);// bitboardSize
            memcpy(&checker, bitboardBytes, size);
        }
        // find checker square
        std::vector<int> squares;
        {
            for(int32_t i=0; i<SquareNum; i++){
                if(checker.isSet((Square)i)){
                    squares.push_back(i);
                }
            }
        }
        // write to return value
        int32_t length = (int32_t)(sizeof(int32_t)*(squares.size()+1));
        {
            outRet = (uint8_t*)calloc(length, sizeof(uint8_t));
            // write
            {
                int32_t size = sizeof(int32_t);
                int32_t pointerIndex = 0;
                // write count
                {
                    if(pointerIndex+size<=length){
                        int32_t value = (int32_t)squares.size();
                        memcpy(outRet + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: getCheckers: %d, %d\n", pointerIndex, length);
                    }
                }
                // write array
                for(int32_t i=0; i<squares.size(); i++){
                    if(pointerIndex+size<=length){
                        int32_t value = squares[i];
                        memcpy(outRet + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: getCheckers: %d, %d\n", pointerIndex, length);
                    }
                }
            }
        }
        return length;
    }

    int32_t shogi_checkMyPositionIsOk(u8* positionBytes, int32_t length)
    {
        int32_t ret = -1;
        // make position
        Position pos;
        {
            Position::parse(&pos, positionBytes, length, 0, false);
        }
        // find ret
        ret = pos.myIsOK();
        // return
        return ret;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// set path ////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    inline bool exist(const std::string& name)
    {
        std::ifstream file(name);
        if(!file)            // If the file was not found, then file is 0, i.e. !file=1 or true.
            return false;    // The file was not found.
        else                 // If the file was found, then file is non-0.
            return true;     // The file was found.
    }
    
    char bookPath[1000];// = new char[1000];
    
    bool shogi_setBookPath(const char* newBookPath)
    {
        bool isExist = exist(newBookPath);
        if(isExist){
            strcpy(bookPath, newBookPath);
        }else{
            // strcpy(bookPath, "");
            strcpy(bookPath, newBookPath);
        }
        return isExist;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// evaluatorPath ////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    char evaluatorPath[1000];// = new char[1000];
    
    bool shogi_setEvaluatorPath(const char* newEvaluatorPath)
    {
        bool isExist = exist(newEvaluatorPath);
        if(isExist){
            strcpy(evaluatorPath, newEvaluatorPath);
        }else{
            // strcpy(evaluatorPath, "");
            strcpy(evaluatorPath, newEvaluatorPath);
        }
        return isExist;
    }
    
    std::mutex shogi_prepareMutex;
    int32_t shogi_prepareCount = 0;
    volatile bool shogi_isWaitSetFile = false;
    
    void prepareMultiThreadSetFile(bool isSetFile, bool isEnd)
    {
        if(isSetFile){
            if(!isEnd){
                // start set file
                do{
                    shogi_prepareMutex.lock();
                    {
                        shogi_isWaitSetFile = true;
                        if(shogi_prepareCount==0){
                            printf("prepare finish, will set book file\n");
                            break;
                        }else{
                            // printf("prepare not finish, won't set book file\n");
                            shogi_prepareMutex.unlock();
                            std::this_thread::sleep_for (std::chrono::seconds(1));
                        }
                    }
                }while (true);
            }else{
                // end set file
                shogi_isWaitSetFile = false;
                shogi_prepareMutex.unlock();
            }
        }else{
            if(!isEnd){
                // start method
                while (shogi_isWaitSetFile) {
                    std::this_thread::sleep_for (std::chrono::seconds(1));
                }
                shogi_prepareMutex.lock();
                {
                    shogi_prepareCount++;
                }
                shogi_prepareMutex.unlock();
            }else{
                // end method
                shogi_prepareMutex.lock();
                {
                    shogi_prepareCount--;
                    if(shogi_prepareCount<0){
                        shogi_prepareCount=0;
                        printf("error, why prepareMutext<0\n");
                    }
                }
                shogi_prepareMutex.unlock();
            }
        }
    }
    
    std::mutex evaluatorMutex;
    
    bool shogi_changeEvaluatorPath(const char* newEvaluatorPath)
    {
        if(shogi_isWaitSetFile){
            printf("error, isWaitSetFile, not set anymore\n");
            return false;
        }
        bool isExist = exist(newEvaluatorPath);
        evaluatorMutex.lock();
        {
            prepareMultiThreadSetFile(true, false);
            if(isExist){
                if(strcmp(newEvaluatorPath, evaluatorPath)!=0){
                    strcpy(evaluatorPath, newEvaluatorPath);
                    Evaluator::init(evaluatorPath);
                }else{
                    printf("error, why the same evaluatorPath\n");
                }
            }else{
                printf("error, evaluatorPath not exist\n");
            }
            prepareMultiThreadSetFile(true, true);
        }
        evaluatorMutex.unlock();
        return isExist;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////// initCore ////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    bool alreadyInitZobrist = false;
    
    void shogi_initCore()
    {
        if(!alreadyInit){
            alreadyInit = true;
            initTable();
            // Zobrist
            {
                if(!alreadyInitZobrist){
                    alreadyInitZobrist = true;
                    Position::initZobrist();
                }else{
                    printf("error, already initZobrit\n");
                }
            }
            HuffmanCodedPos::init();
            
            // TODO evaluator init
            // Evaluator::init(evaluatorPath);
        }else{
            printf("error, already init core\n");
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    ////////////////////// core /////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////

    int32_t shogi_makePositionByFen(const char* strFen, u8* &outRet)
    {
        printf("makePositionByFen: %s\n", strFen);
        prepareMultiThreadSetFile(false, false);
        Position pos;// (strFen, NULL, NULL);
        {
            pos.set(strFen, NULL);
        }
        int32_t length = Position::convertToByteArray(&pos, outRet);
        // return
        prepareMultiThreadSetFile(false, true);
        return length;
    }

    int32_t shogi_isGameFinish(u8* positionBytes, int32_t length, bool canCorrect)
    {
        prepareMultiThreadSetFile(false, false);
        int32_t ret = 0;
        {
            Position pos;
            {
                Position::parse(&pos, positionBytes, length, 0, canCorrect);
            }
            if(pos.myIsOK()==-1)
            {
                // check get legal move
                bool haveAnyLegalMove = true;
                // check have any legal move?
                {
                    MoveList<Legal> ml(pos);
                    if(ml.size()==0){
                        haveAnyLegalMove = false;
                    }
                }
                // process
                if(!haveAnyLegalMove){
                    // printf("game finish: gamePly: %d %d\n", pos.gamePly(), pos.turn());
                    switch(pos.turn()){
                        case Black:
                            // black turn, so black win
                            ret = 2;
                            break;
                        case White:
                            // white turn, so white win
                            ret = 1;
                            break;
                        default:
                            printf("error, unknown color\n");
                            break;
                    }
                }else{
                    // hoa co hay ko?
                    switch (pos.isDraw()) {
                        case NotRepetition:
                            // printf("notRepetition\n");
                            break;
                        case RepetitionDraw:
                            printf("repetitionDraw\n");
                            ret = 3;
                            break;
                        case RepetitionWin:
                            printf("repetitionWin\n");
                            break;
                        case RepetitionLose:
                            printf("repetionLose\n");
                            break;
                        case RepetitionSuperior:
                            printf("repetitionSuperior\n");
                            break;
                        case RepetitionInferior:
                            printf("repetitionInferior\n");
                            break;
                        default:
                            break;
                    }
                }
            }
            else{
                printf("error, isGameFinish: position not ok\n");
            }
        }
        // black: +OU, white: -OU
        prepareMultiThreadSetFile(false, true);
        return ret;
    }
    
    u32 shogi_letComputerThink(u8* positionBytes, int32_t length, bool canCorrect, int32_t depth, int32_t skillLevel, int32_t mr, int32_t duration, bool useBook)
    {
        prepareMultiThreadSetFile(false, false);

        // TODO maxDepth
        {
            if(depth>12){
                depth = 12;
            }
        }
        u32 ret = 0;
        {
            // make searcher
            Searcher s;
            {
                s.myInit();
            }
            // make thread
            Thread* th = new Thread(&s);
            // make position
            Position pos;
            {
                Position::parse(&pos, positionBytes, length, 0, canCorrect);
                pos.thisThread_ = th;
                pos.setSearcher(&s);
            }
            if(pos.myIsOK()==-1)
            {
                // book
#ifdef Android
                Book book(assetManager, bookPath);
                const std::tuple<Move, Score> bookMoveScore = book.probe(pos, bookPath, false);
#else
                Book book;
                 const std::tuple<Move, Score> bookMoveScore = book.probe(pos, bookPath, false);
#endif
                bool bookHaveMove = false;
                {
                    if(std::get<0>(bookMoveScore)){
#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "have book move\n");
#else
                        printf("have book move\n");
#endif
                        bookHaveMove = true;
                    }
                }
                // limit
                LimitsType limits;
                {
                    limits.startTime.restart();
                    {
                        limits.ponder = false;
                        limits.time[Black] = 0;
                        limits.time[White] = 0;
                        limits.inc[Black] = 0;
                        limits.inc[White] = 0;
                        limits.moveTime = duration;
                        limits.mate = 0;
                        // depth
                        {
                            if(useBook && bookHaveMove){
                                limits.depth = 0;
                            }else{
                                limits.depth = depth;
                            }
                        }
                        limits.nodes = 0;
                    }
                }
                // start search
                {
                    pos.searcher()->signals.stopOnPonderHit = pos.searcher()->signals.stop = false;
                    pos.searcher()->limits = limits;
                    // time
                    {
                        const Color us = pos.turn();
                        pos.searcher()->timeManager.init(pos.searcher()->limits, us, pos.gamePly(), pos,  pos.searcher());
                    }
                    // rootMove
                    std::vector<RootMove> rootMoves;
                    for (MoveList<Legal> ml(pos); !ml.end(); ++ml) {
                        if (limits.searchmoves.empty() | std::find(std::begin(limits.searchmoves), std::end(limits.searchmoves), ml.move()) != std::end(limits.searchmoves)) {
                            // printf("add move to search: %s\n", ml.move().toUSI().c_str());
                            rootMoves.push_back(RootMove(ml.move()));
                        }
                    }
                    // search
                    if(rootMoves.size()>0){
                        // set thread
                        {
                            th->rootPos = &pos; // Position(pos, th);
                            th->maxPly = 0;
                            th->rootDepth = Depth0;
                            th->rootMoves = rootMoves;
                        }

#ifdef Android
                        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Evaluator allocated: %d, myPosIsOk: %d\n", Evaluator::allocated, pos.myIsOK());
#endif
                        
                        //setUpStates->back() = tmp;
                        th->mySearch(skillLevel, mr);

                        // select move
                        printf("after letComputerThink: limit time: %d\n", limits.startTime.elapsed());
                        // book
                        if (std::get<0>(bookMoveScore) && std::find(th->rootMoves.begin(), th->rootMoves.end(), std::get<0>(bookMoveScore)) != th->rootMoves.end())
                        {
                            printf("find a bookMove\n");
                            std::swap(th->rootMoves[0], *std::find(th->rootMoves.begin(), th->rootMoves.end(), std::get<0>(bookMoveScore)));
                            th->rootMoves[0].score = std::get<1>(bookMoveScore);
                        }else{
                            printf("not find a book move\n");
                        }
                        // select move
                        if(th->rootMoves[0].pv.size()>0){
                            // print move score
                            /*for(int32_t i=0; i<th->rootMoves.size() && i<=3; i++){
                             printf("print all move score: %d; %d, %s\n", i, th->rootMoves[i].score, th->rootMoves[i].pv[0].toUSI().c_str());
                             }*/
                            // printf("find ai move: %s %d\n", th->rootMoves[0].pv[0].toUSI().c_str(), th->rootMoves[0].score);
                            ret = th->rootMoves[0].pv[0].value();
                        }else{
                            printf("error, why rootMoves[0].pv size = 0\n");
                        }
                    }else{
                        printf("error, why don't have any rootMove\n");
                    }
                }
            }
            else{
                printf("error, letComputerThink: position not ok\n");
            }
            // free data
            {
                delete th;
            }
        }
        prepareMultiThreadSetFile(false, true);
        return ret;
    }
    
    bool shogi_isLegalMove(u8* positionBytes, int32_t length, bool canCorrect, u32 move)
    {
        prepareMultiThreadSetFile(false, false);
        bool ret = false;
        {
            // make position
            Position pos;
            {
                Position::parse(&pos, positionBytes, length, 0, canCorrect);
            }
            // position is correct?
            if(pos.myIsOK()==-1)
            {
                // check legal move
                Move mv(move);
                ret = pos.moveIsLegal(mv);
            }
            else{
                printf("error, isLegalMove: position not ok\n");
            }
        }
        // return
        prepareMultiThreadSetFile(false, true);
        return ret;
    }

    int32_t shogi_doMove(u8* positionBytes, int32_t length, bool canCorrect, u32 move, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        Position pos;
        {
            // make searcher
            Searcher s;
            {
                s.myInit();
            }
            // make thread
            Thread* th = new Thread(&s);
            Position::parse(&pos, positionBytes, length, 0, canCorrect);
            pos.thisThread_ = th;
            pos.setSearcher(&s);
        }
        // doMove
        if(pos.myIsOK()==-1)
        {
            Move mv(move);
            StateInfo* newSt = (StateInfo*)calloc(1, sizeof(StateInfo));
            {
                pos.pushStateInfo(newSt);
            }
            pos.doMove(mv, *newSt);
        }
        else{
            printf("error, doMove: position not ok\n");
        }
        // return
        int32_t newLength = Position::convertToByteArray(&pos, outRet);
        {
            // free data
            delete pos.thisThread_;
        }
        prepareMultiThreadSetFile(false, true);
        return newLength;
    }

    int32_t shogi_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
#ifdef Android
        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "shogi_getLegalMoves\n");
#endif
        prepareMultiThreadSetFile(false, false);
        // make position
        Position pos;
        {
            Position::parse(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLegalMovesLength = 0;
        if(pos.myIsOK()==-1)
        {
            MoveList<LegalAll> moveList = MoveList<LegalAll>(pos);
            if(moveList.size()>0){
                // init
                outLegalMovesLength = (int)(moveList.size()*sizeof(u32));
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy byte
                {
                    int32_t moveIndex = 0;
                    for (; !moveList.end(); ++moveList) {
                        Move move = moveList.move();
                        u32 moveValue = move.value();
                        memcpy(outLegalMoves + sizeof(u32)*moveIndex, &moveValue , sizeof(u32));
                        // shogi_printMove(moveValue);
                        moveIndex++;
                    }
                }
            }
        }
        else{
            printf("error, position not ok\n");
            #ifdef Android
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, position not ok\n");
            #endif
        }
        prepareMultiThreadSetFile(false, true);
        return outLegalMovesLength;
    }
}
