//
//  jni.cpp
//  InternationalDraught
//
//  Created by Viet Tho on 4/17/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef _WIN32
#include <unistd.h>
#else
#include <io.h>
#endif

#include "international_draught_jni.hpp"
#include "international_draught_pos.hpp"
#include "international_draught_position.hpp"
#include "international_draught_search.hpp"
#include "international_draught_fen.hpp"
#include "international_draught_hash.hpp"
#include "international_draught_bb_comp.hpp"
#include "international_draught_move_gen.hpp"

namespace InternationalDraught
{
    void international_draught_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        {
            char strPosition[1000];
            pos.print(strPosition);
            printf("\n%s\n\n", strPosition);
        }
    }
    
    void international_draught_printMove(uint64 move)
    {
        printf("printMove: %s\n", move::to_hub((Move)move).c_str());
    }
    
    ///////////////////////////////////////////////////////////////////////////////
    ///////////////// set bb multithread ///////////////////
    ///////////////////////////////////////////////////////////////////////////////
    
    std::mutex international_draught_prepareMutex;
    int32_t international_draught_prepareCount = 0;
    volatile bool international_draught_isWaitSetFile = false;
    
    void prepareMultiThreadSetFile(bool isSetFile, bool isEnd)
    {
        if(isSetFile){
            if(!isEnd){
                // start set file
                do{
                    international_draught_prepareMutex.lock();
                    {
                        international_draught_isWaitSetFile = true;
                        if(international_draught_prepareCount==0){
                            printf("prepare finish, will set book file\n");
                            break;
                        }else{
                            // printf("prepare not finish, won't set book file\n");
                            international_draught_prepareMutex.unlock();
                            std::this_thread::sleep_for (std::chrono::seconds(1));
                        }
                    }
                }while (true);
            }else{
                // end set file
                international_draught_isWaitSetFile = false;
                international_draught_prepareMutex.unlock();
            }
        }else{
            if(!isEnd){
                // start method
                while (international_draught_isWaitSetFile) {
                    std::this_thread::sleep_for (std::chrono::seconds(1));
                }
                international_draught_prepareMutex.lock();
                {
                    international_draught_prepareCount++;
                }
                international_draught_prepareMutex.unlock();
            }else{
                // end method
                international_draught_prepareMutex.lock();
                {
                    international_draught_prepareCount--;
                    if(international_draught_prepareCount<0){
                        international_draught_prepareCount=0;
                        printf("error, why prepareMutext<0\n");
                    }
                }
                international_draught_prepareMutex.unlock();
            }
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// setPath /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    inline bool exist(const char* path)
    {
        FILE * pFile;
        pFile = fopen (path, "rb");
        if (pFile!=NULL)
        {
            fclose (pFile);
            return true;
        }else{
            return false;
        }
    }
    
    bool international_draught_setBookPath(const char* newBookPath)
    {
        bool isExist = exist(newBookPath);
        if(isExist){
            strcpy(BookPath, newBookPath);
        }else{
            printf("error, BookPath not exist: %s\n", newBookPath);
            strcpy(BookPath, newBookPath);
        }
        return isExist;
    }
    
    std::mutex bbMutex;
    
    bool international_draught_setBBPath(const char* newBBPath)
    {
        if(international_draught_isWaitSetFile){
            printf("error, isWaitSetFile, not set anymore\n");
            return false;
        }
        bbMutex.lock();
        prepareMultiThreadSetFile(true, false);
        bool isExist = exist(newBBPath);
        {
            if(!isExist){
                printf("BBPath not exist: %s\n", newBBPath);
            }else{
            }
            if(strcmp(bb::bbPath, newBBPath)!=0){
                strcpy(bb::bbPath, newBBPath);
                // remove old bbFile
                {
                    if(bb::myBaseNormal){
                        printf("free old myBaseNormal\n");
                        free(bb::myBaseNormal);
                        bb::myBaseNormal = NULL;
                    }
                    if(bb::myBaseKiller){
                        printf("free old myBaseKiller\n");
                        free(bb::myBaseKiller);
                        bb::myBaseKiller = NULL;
                    }
                    if(bb::myBaseBT){
                        printf("free old myBaseNormal\n");
                        free(bb::myBaseBT);
                        bb::myBaseBT = NULL;
                    }
                }
            }else{
                printf("why the same BBPath: %s\n", newBBPath);
            }
        }
        prepareMultiThreadSetFile(true, true);
        bbMutex.unlock();
        return isExist;
    }
    
    bool international_draught_setEvalPath(const char* newEvalPath)
    {
        bool isExist = exist(newEvalPath);
        if(isExist){
            strcpy(EvalPath, newEvalPath);
        }else{
            printf("error, evalPath not exist: %s\n", newEvalPath);
            strcpy(EvalPath, newEvalPath);
        }
        return isExist;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////// Match /////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////
    
    bool alreadyInitInternationalDraught = false;
    
    void international_draught_initCore()
    {
        if(!alreadyInitInternationalDraught){
            alreadyInitInternationalDraught = true;
            common_init();
            bit::init();
            hash::init();
            pos::init();
            ml::rand_init(); // after hash keys
            bb::comp_init();
            bb::index_init();
        }
    }

    int32_t international_draught_makeDefaultPosition(Variant_Type variantType, const char* fen, uint8_t* &outRet)
    {
        // make position
        struct Position position;
        {
            //Node* node;
            {
                // init
                Node* node = (Node*)calloc(1, sizeof(Node));
                {
                    node->p_pos = pos_from_fen(variantType, fen);
                    node->p_ply = 0;
                    node->p_parent = NULL;
                }
                // set
                {
                    position.node = node;
                    position.firstNode = node;
                }
            }
            // struct var::Var var;
            {
                // TODO can hoan thien: co le phai init
                position.var.Variant = variantType;
            }
        }
        // convert
        int32_t length = Position::convertToByteArray(&position, outRet);
        // return
        return length;
    }

    int32_t international_draught_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        int32_t ret = 0;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // printf("pos moves: %d\n", pos.b.moves);
            if(pos.node){
                if(pos::is_loss(&pos.var, pos.node->p_pos)){
                    switch (pos.node->p_pos.turn()) {
                        case White:
                            ret = 1;
                            break;
                        case Black:
                            ret = 2;
                            break;
                        default:
                            printf("error, unknown turn\n");
                            break;
                    }
                }else{
                    if(pos.node->is_draw(3)){
                        printf("game draw\n");
                        ret = 3;
                    }else{
                        int32_t maxPly = pos.ply;
                        {
                            if(maxPly<50){
                                printf("error, maxPly too small: %d\n", maxPly);
                                maxPly = 50;
                            }else if(maxPly>500){
                                printf("error, maxPly too large: %d\n", maxPly);
                                maxPly = 500;
                            }
                        }
                        if(pos.node->p_ply>=maxPly){
                            printf("p_ply too large, so draw: %d\n", pos.node->p_ply);
                            ret = 3;
                        }
                    }
                }
            }else{
                printf("error, node null\n");
                ret = 3;
            }
        }
        return ret;
    }
    
    uint64 international_draught_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool move, bool useBook, int32_t depth, float time, bool input, bool useEndGameDatabase, int32_t pickBestMove)
    {
        prepareMultiThreadSetFile(false, false);
        uint64 ret = 0;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
                // book
                {
                    if(useBook){
                        if(pos.var.myBook){
                            pos.var.Book = true;
                        }else{
                            pos.var.myBook = getBook(pos.var.Variant);
                            pos.var.Book = pos.var.myBook != nullptr;
                        }
                    }else{
                        pos.var.Book = false;
                    }
                }
                // end game database
                {
                    if(useEndGameDatabase){
                        pos.var.myBase = bb::getMyBase(pos.var.Variant);
                        if(pos.var.myBase){
                            pos.var.BB = true;
                            pos.var.BB_Size = 5;
                        }else{
                            printf("cannot get myBase\n");
                            pos.var.BB = false;
                            pos.var.BB_Size = 5;
                        }
                    }else{
                        pos.var.BB = false;
                        pos.var.BB_Size = 5;
                    }
                }
                // pickBestMove
                {
                    if(pickBestMove>=0 && pickBestMove<=100){
                        pos.var.pickBestMove = pickBestMove;
                    }else{
                        printf("error, pickBestMove wrong\n");
                    }
                }
            }
            // find ai move
            if(pos.node){
                // make search input
                Search_Input si;
                {
                    si.move = move;
                    si.book = useBook;
                    si.depth = Depth(depth);
                    si.set_time(time);
                    si.input = input;
                    si.output = Output_Terminal;
                }
                // make search output
                Search_Output so;
                // search
                Search search;
                {
                    search.myVar = &pos.var;
                }
                search.search(so, *pos.node, si);
                // return result
                ret = (uint64)so.move;
            }else{
                printf("error, why pos.node null\n");
            }
            // printMove
            {
                if(pos.node){
                    printf("letComputerThink: move: %s\n", move::to_string(pos.var.Variant, (Move)ret, pos.node->p_pos).c_str());
                }else{
                    printf("error, pos.node null\n");
                }
            }
        }
        prepareMultiThreadSetFile(false, true);
        return ret;
    }
    
    bool international_draught_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint64 move)
    {
        bool ret = false;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // check
            if(pos.node){
                Move mv = (Move)move;
                ret = move::is_legal(pos.var.Variant, mv, pos.node->p_pos);
            }else{
                printf("error, node null\n");
            }
        }
        return ret;
    }

    int32_t international_draught_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint64 move, uint8_t* &outRet)
    {
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // play move
        Node* oldNode = pos.node;
        {
            // change node
            if(pos.node){
                Pos oldPos = pos.node->p_pos;
                Pos newPos = pos.node->p_pos;
                // Make move
                {
                    Move mv = (Move)move;
                    // printMove
                    printf("DoMove: %s, %s, %llu\n", square_to_string(move::from(mv)).c_str(), square_to_string( move::to(mv)).c_str(), move::captured(mv).p_bit);
                    // newNode
                    Node newNode;
                    pos.node->mySucc(&pos.var, mv, &newNode);
                    // set new node
                    pos.node = &newNode;
                    // get newPos to compare captures
                    newPos = newNode.p_pos;
                    
                    // TODO test
                    /*{
                        printf("doMove: ply: %d, %d\n", oldNode->p_ply, newNode.p_ply);
                        if(oldNode->p_ply>0){
                            if(newNode.p_ply<=oldNode->p_ply){
                                printf("error, why oldNode ply wrong\n");
                            }
                        }
                    }*/
                }
                // CaptureSquares
                {
                    pos.captureSize = 0;
                    // printf("from: %d\n", move::from((Move)move));
                    Square from = move::from((Move)move);
                    Square dest = move::to((Move)move);
                    // Square from = move::from(move);
                    for (int32_t y = 0; y < Line_Size; y++) {// Square.Rank_Size
                        for (int32_t x = 0; x < Line_Size; x++) {// Square.File_Size
                            if(square_is_dark(x, y)){
                                Square sq = square_make(x, y);
                                if(sq!=from && sq!=dest){
                                    if(oldPos.piece_side(sq)!=Empty && newPos.piece_side(sq)==Empty){
                                        // add
                                        if(pos.captureSize>=0 && pos.captureSize<20){
                                            printf("add captures: %s, %d\n", square_to_string(sq).c_str(), sq);
                                            pos.captureSquares[pos.captureSize] = sq;
                                            pos.captureSize++;
                                        }else{
                                            printf("error, why pos.captureSize wrong: %d\n", pos.captureSize);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }else{
                printf("error, node null\n");
            }
            // set last move
            pos.lastMove = move;
        }
        // convert to byteArray
        int32_t newLength = Position::convertToByteArray(&pos, outRet);
        // reset old node to release data
        {
            pos.node = oldNode;
        }
        // return
        return newLength;
    }

    int32_t international_draught_getFen(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outStrFen)
    {
        // make position
        struct Pos pos;
        {
            Pos::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Make fen
        const char* fen = pos_fen(pos).c_str();
        // make fen
        int32_t outLength = 0;
        {
            char strFen[200];
            {
                strFen[0] = 0;
            }
            strcpy(strFen, fen);
            // make
            {
                outLength = (int32_t)(strlen(strFen) + 1);
                // make out
                {
                    outStrFen = (uint8_t*)calloc(outLength, sizeof(uint8_t));
                    memcpy(outStrFen, strFen, outLength);
                }
            }
            printf("fen: %s\n", fen);
        }
        // return
        return outLength;
    }

    int32_t international_draught_getLegalMoves(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outLegalMoves)
    {
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // Check is legal move
        int32_t outLegalMovesLength = 0;
        // TODO co le phai check them positon ok nua
        if(pos.node){
            List moveList;
            gen_moves(pos.var.Variant, moveList, pos.node->p_pos);
            if(moveList.size()>0){
                // init
                outLegalMovesLength = (int)(moveList.size()*sizeof(uint64));
                outLegalMoves = (uint8_t*)calloc(outLegalMovesLength, sizeof(uint8_t));
                // copy byte
                {
                    printf("show legal moves: \n");
                    for (int32_t i = 0; i < moveList.size(); i++) {
                        uint64 mv = (uint64)moveList.move(i);
                        memcpy(outLegalMoves + sizeof(uint64)*i, &mv , sizeof(uint64));
                        international_draught_printMove(mv);
                    }
                }
            }
        }else{
            printf("error, node null\n");
        }
        // free data
        {
            
        }
        return outLegalMovesLength;
    }

    int32_t international_draught_getMoveSquareList(uint64 move, uint8_t* &outMoveSquareList)
    {
        int32_t squareSize = 0;
        int32_t squares[100];
        {
            Move mv = (Move)move;
            Square from = move::from(mv);
            Square to   = move::to(mv);
            Bit    caps = move::captured(mv);
            
            // Add From
            {
                squares[squareSize] = from;
                squareSize++;
            }
            // Add between
            for (Bit b = caps; b != 0; b = bit::rest(b)) {
                Square sq = bit::first(b);
                // Add
                {
                    squares[squareSize] = sq;
                    squareSize++;
                }
            }
            // Add To
            {
                squares[squareSize] = to;
                squareSize++;
            }
        }
        // return
        int32_t outMoveSquareListLength = 0;
        {
            if(squareSize>0 && squareSize<=100){
                outMoveSquareListLength = squareSize*sizeof(int32_t);
                outMoveSquareList = (uint8_t*)calloc(outMoveSquareListLength, sizeof(uint8_t));
                // copy byte
                {
                    for (int32_t i = 0; i < squareSize; i++) {
                        int32_t square = squares[i];
                        memcpy(outMoveSquareList + sizeof(int32_t)*i, &square , sizeof(int32_t));
                    }
                }
            } else{
                printf("squareSize error: %d\n", squareSize);
            }
        }
        // printf("printMove: %s\n", move::to_hub((Move)move).c_str());
        return outMoveSquareListLength;
    }
}
