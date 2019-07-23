/*
position.h/position.cpp - Source Code for ElephantEye, Part III

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.3, Last Modified: Mar. 2012
Copyright (C) 2004-2012 www.xqbase.com

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
*/

#include <string.h>
// #include <cstdlib>
#include "../base/xiangqi_base.hpp"
#include "xiangqi_pregen.hpp"
#include "xiangqi_preeval.hpp"

#ifndef XIANGQI_POSITION_H
#define XIANGQI_POSITION_H

namespace Xiangqi
{
    /* ElephantEyeԴ����ʹ�õ��������Ǻ�Լ����
     *
     * sq: �������(��������0��255������"pregen.cpp")
     * pc: �������(��������0��47������"position.cpp")
     * pt: �����������(��������0��6������"position.cpp")
     * mv: �ŷ�(��������0��65535������"position.cpp")
     * sd: ���ӷ�(������0����췽��1����ڷ�)
     * vl: �����ֵ(��������"-MATE_VALUE"��"MATE_VALUE"������"position.cpp")
     * (ע�������ĸ��Ǻſ���uc��dw�ȴ��������ļǺ����ʹ��)
     * pos: ����(PositionStruct���ͣ�����"position.h")
     * sms: λ�к�λ�е��ŷ�����Ԥ�ýṹ(����"pregen.h")
     * smv: λ�к�λ�е��ŷ��ж�Ԥ�ýṹ(����"pregen.h")
     */
    
    const int32_t MAX_MOVE_NUM = 1024;  // ���������ɵĻع��ŷ���
    const int32_t MAX_GEN_MOVES = 128;  // ����������ŷ������й�������κξ��涼���ᳬ��120���ŷ�
    const int32_t DRAW_MOVES = 100;     // Ĭ�ϵĺ����ŷ�����ElephantEye�趨��50�غϼ�100������������Ӧ������������
    const int32_t REP_HASH_MASK = 4095; // �ж��ظ�����������û����ȣ���4096������
    
    const int32_t MATE_VALUE = 10000;           // ��߷�ֵ���������ķ�ֵ
    const int32_t BAN_VALUE = MATE_VALUE - 100; // �����и��ķ�ֵ�����ڸ�ֵ����д���û���(����"hash.cpp")
    const int32_t WIN_VALUE = MATE_VALUE - 200; // ������ʤ���ķ�ֵ���ޣ�������ֵ��˵���Ѿ�������ɱ����
    const int32_t NULLOKAY_MARGIN = 200;        // ���Ųü����Բ������������ֵ�߽�
    const int32_t NULLSAFE_MARGIN = 400;        // ����ʹ�ÿ��Ųü���������������ֵ�߽�
    const int32_t DRAW_VALUE = 20;              // ����ʱ���صķ���(ȡ��ֵ)
    
    const bool CHECK_LAZY = true;   // ͵����⽫��
    const int32_t CHECK_MULTI = 48;     // ������ӽ���
    
    // ÿ�����������ͱ��
    const int32_t KING_TYPE = 0;
    const int32_t ADVISOR_TYPE = 1;
    const int32_t BISHOP_TYPE = 2;
    const int32_t KNIGHT_TYPE = 3;
    const int32_t ROOK_TYPE = 4;
    const int32_t CANNON_TYPE = 5;
    const int32_t PAWN_TYPE = 6;
    
    // ÿ�������Ŀ�ʼ��źͽ������
    const int32_t KING_FROM = 0;
    const int32_t ADVISOR_FROM = 1;
    const int32_t ADVISOR_TO = 2;
    const int32_t BISHOP_FROM = 3;
    const int32_t BISHOP_TO = 4;
    const int32_t KNIGHT_FROM = 5;
    const int32_t KNIGHT_TO = 6;
    const int32_t ROOK_FROM = 7;
    const int32_t ROOK_TO = 8;
    const int32_t CANNON_FROM = 9;
    const int32_t CANNON_TO = 10;
    const int32_t PAWN_FROM = 11;
    const int32_t PAWN_TO = 15;
    
    // ��������������λ
    const int32_t KING_BITPIECE = 1 << KING_FROM;
    const int32_t ADVISOR_BITPIECE = (1 << ADVISOR_FROM) | (1 << ADVISOR_TO);
    const int32_t BISHOP_BITPIECE = (1 << BISHOP_FROM) | (1 << BISHOP_TO);
    const int32_t KNIGHT_BITPIECE = (1 << KNIGHT_FROM) | (1 << KNIGHT_TO);
    const int32_t ROOK_BITPIECE = (1 << ROOK_FROM) | (1 << ROOK_TO);
    const int32_t CANNON_BITPIECE = (1 << CANNON_FROM) | (1 << CANNON_TO);
    const int32_t PAWN_BITPIECE = (1 << PAWN_FROM) | (1 << (PAWN_FROM + 1)) |
    (1 << (PAWN_FROM + 2)) | (1 << (PAWN_FROM + 3)) | (1 << PAWN_TO);
    const int32_t ATTACK_BITPIECE = KNIGHT_BITPIECE | ROOK_BITPIECE | CANNON_BITPIECE | PAWN_BITPIECE;
    
    inline uint32_t BIT_PIECE(int32_t pc) {
        return 1 << (pc - 16);
    }
    
    inline uint32_t WHITE_BITPIECE(int32_t nBitPiece) {
        return nBitPiece;
    }
    
    inline uint32_t BLACK_BITPIECE(int32_t nBitPiece) {
        return nBitPiece << 16;
    }
    
    inline uint32_t BOTH_BITPIECE(int32_t nBitPiece) {
        return nBitPiece + (nBitPiece << 16);
    }
    
    // "RepStatus()"���ص��ظ����λ
    const int32_t REP_NONE = 0;
    const int32_t REP_DRAW = 1;
    const int32_t REP_LOSS = 3;
    const int32_t REP_WIN = 5;
    
    /* ElephantEye�ĺܶ�����ж��õ�"SIDE_TAG()"��������췽��Ϊ16���ڷ���Ϊ32��
     * ��"SIDE_TAG() + i"���Է����ѡ�����ӵ����ͣ�"i"��0��15�����ǣ�
     * ˧�����������������ڱ���������(��ʿʿ������������������������)
     * ����"i"ȡ"KNIGHT_FROM"��"KNIGHT_TO"�����ʾ���μ���������λ��
     */
    inline int32_t SIDE_TAG(int32_t sd) {
        return 16 + (sd << 4);
    }
    
    inline int32_t OPP_SIDE_TAG(int32_t sd) {
        return 32 - (sd << 4);
    }
    
    inline int32_t SIDE_VALUE(int32_t sd, int32_t vl) {
        return (sd == 0 ? vl : -vl);
    }
    
    inline int32_t PIECE_INDEX(int32_t pc) {
        return pc & 15;
    }
    
    extern const char *const cszStartFen;     // ��ʼ�����FEN��
    extern const char *const cszPieceBytes;   // �������Ͷ�Ӧ�����ӷ���
    extern const int32_t cnPieceTypes[48];        // ������Ŷ�Ӧ����������
    extern const int32_t cnSimpleValues[48];      // ���ӵļ򵥷�ֵ
    extern const uint8_t cucsqMirrorTab[256]; // ����ľ���(���ҶԳ�)����
    
    inline char PIECE_BYTE(int32_t pt) {
        return cszPieceBytes[pt];
    }
    
    inline int32_t PIECE_TYPE(int32_t pc) {
        return cnPieceTypes[pc];
    }
    
    inline int32_t SIMPLE_VALUE(int32_t pc) {
        return cnSimpleValues[pc];
    }
    
    inline uint8_t SQUARE_MIRROR(int32_t sq) {
        return cucsqMirrorTab[sq];
    }
    
    // FEN�������ӱ�ʶ
    int32_t FenPiece(int32_t Arg);
    
    // �����ŷ��ṹ
    union MoveStruct {
        uint32_t dwmv;           // ���������ṹ��
        struct {
            uint16_t wmv, wvl;     // �ŷ��ͷ�ֵ
        };
        struct {
            uint8_t Src, Dst;      // ��ʼ���Ŀ���
            int8_t CptDrw, ChkChs; // ������(+)/�����ŷ���(-)��������(+)/��׽��(-)
        };
    }; // mvs
    
    // �ŷ��ṹ
    inline int32_t SRC(int32_t mv) { // �õ��ŷ������
        return mv & 255;
    }
    
    inline int32_t DST(int32_t mv) { // �õ��ŷ����յ�
        return mv >> 8;
    }
    
    inline int32_t MOVE(int32_t sqSrc, int32_t sqDst) {   // �������յ�õ��ŷ�
        return sqSrc + (sqDst << 8);
    }
    
    inline uint32_t MOVE_COORD(int32_t mv) {      // ���ŷ�ת�����ַ���
        union {
            char c[4];
            uint32_t dw;
        } Ret;
        Ret.c[0] = FILE_X(SRC(mv)) - FILE_LEFT + 'a';
        Ret.c[1] = '9' - RANK_Y(SRC(mv)) + RANK_TOP;
        Ret.c[2] = FILE_X(DST(mv)) - FILE_LEFT + 'a';
        Ret.c[3] = '9' - RANK_Y(DST(mv)) + RANK_TOP;
        // ��������ŷ��ĺ�����
        /*__ASSERT_BOUND('a', Ret.c[0], 'i');
        __ASSERT_BOUND('0', Ret.c[1], '9');
        __ASSERT_BOUND('a', Ret.c[2], 'i');
        __ASSERT_BOUND('0', Ret.c[3], '9');*/
        {
            if(!__IF_BOUND('a', Ret.c[0], 'i')){
                printf("error: __ASSERT_BOUND('a', Ret.c[0], 'i'): %d, %d\n", mv, Ret.c[0]);
            }
            if(!__IF_BOUND('0', Ret.c[1], '9')){
                printf("error: __ASSERT_BOUND('0', Ret.c[1], '9'): %d, %d\n", mv, Ret.c[1]);
            }
            if(!__IF_BOUND('a', Ret.c[2], 'i')){
                printf("error: __ASSERT_BOUND('a', Ret.c[2], 'i'): %d, %d\n", mv, Ret.c[2]);
            }
            if(!__IF_BOUND('0', Ret.c[3], '9')){
                printf("error: __ASSERT_BOUND('0', Ret.c[3], '9'): %d, %d\n", mv, Ret.c[2]);
            }
        }
        return Ret.dw;
    }
    
    inline int32_t COORD_MOVE(uint32_t dwMoveStr) { // ���ַ���ת�����ŷ�
        int32_t sqSrc, sqDst;
        char *lpArgPtr;
        lpArgPtr = (char *) &dwMoveStr;
        sqSrc = COORD_XY(lpArgPtr[0] - 'a' + FILE_LEFT, '9' - lpArgPtr[1] + RANK_TOP);
        sqDst = COORD_XY(lpArgPtr[2] - 'a' + FILE_LEFT, '9' - lpArgPtr[3] + RANK_TOP);
        // �������ŷ��ĺ����Բ�������
        // __ASSERT_SQUARE(sqSrc);
        // __ASSERT_SQUARE(sqDst);
        return (IN_BOARD(sqSrc) && IN_BOARD(sqDst) ? MOVE(sqSrc, sqDst) : 0);
    }
    
    inline int32_t MOVE_MIRROR(int32_t mv) {          // ���ŷ�������
        return MOVE(SQUARE_MIRROR(SRC(mv)), SQUARE_MIRROR(DST(mv)));
    }
    
    // �ع��ṹ
    struct RollbackStruct {
        ZobristStruct zobr;
        int32_t vlWhite;
        int32_t vlBlack;
        MoveStruct mvs;
        
    public:
        static int32_t getByteSize()
        {
            return ZobristStruct::getByteSize() + 2*sizeof(int32_t) + sizeof(uint32_t);
        }
        
        static int32_t convertToByteArray(RollbackStruct* rbs, uint8_t* &byteArray)
        {
            // find length of return
            int32_t length = rbs->getByteSize();
            byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // ZobristStruct zobr;
                {
                    uint8_t* zobrByteArray;
                    int32_t size = ZobristStruct::convertToByteArray(&rbs->zobr, zobrByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(byteArray + pointerIndex, zobrByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: zobr: %d, %d\n", pointerIndex, length);
                    }
                    free(zobrByteArray);
                }
                // int32_t vlWhite;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = rbs->vlWhite;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: vlWhite: %d, %d\n", pointerIndex, length);
                    }
                }
                // int32_t vlBlack;
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t value = rbs->vlBlack;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: vlWhite: %d, %d\n", pointerIndex, length);
                    }
                }
                // MoveStruct mvs;
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        uint32_t value = rbs->mvs.dwmv;
                        memcpy(byteArray + pointerIndex, &value, size);
                        // printf("convert to byte array: mvs: %u, %u\n", value, rbs->mvs.dwmv);
                        pointerIndex+=size;
                    }else{
                        printf("length error: mvs: %d, %d\n", pointerIndex, length);
                    }
                }
                if(pointerIndex!=length){
                    printf("error: convert not correct\n");
                }
            }
            return length;
        }
        
        static int32_t parseByteArray(RollbackStruct* rbs, uint8_t* positionBytes, int32_t length, int32_t start)
        {
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // ZobristStruct zobr;
                    {
                        int32_t zobrByteLength = ZobristStruct::parseByteArray(&rbs->zobr, positionBytes, length, pointerIndex);
                        if (zobrByteLength > 0) {
                            pointerIndex+= zobrByteLength;
                        } else {
                            printf("cannot parse\n");
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                        // int32_t vlWhite;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&rbs->vlWhite, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: vlWhite: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                        // int32_t vlBlack;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&rbs->vlBlack, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: vlBlack: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                        // MoveStruct mvs;
                    {
                        int32_t size = sizeof(uint32_t);
                        if(pointerIndex+size<=length){
                            uint32_t value;
                            memcpy(&value, positionBytes + pointerIndex, size);
                            rbs->mvs.dwmv = value;
                            // printf("parse byte array: mvs: %u, %u\n", value, rbs->mvs.dwmv);
                            pointerIndex+=size;
                        }else{
                            printf("length error: mvs: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        // printf("error, convertByteArrayToPosition: unknown index: %d\n", index);
                        alreadyPassAll = true;
                    }
                        break;
                }
                // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
                index++;
                if (!isParseCorrect) {
                    printf("not parse correct\n");
                    break;
                }
                if (alreadyPassAll) {
                    break;
                }
            }
            // return
            if (!isParseCorrect) {
                printf("parse fail: %d; %d; %d\n", pointerIndex, length, start);
                return -1;
            } else {
                // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
                return (pointerIndex - start);
            }
        }
        
    }; // rbs
    
    const bool DEL_PIECE = true; // ����"PositionStruct::AddPiece()"��ѡ��
    
    // �û���ṹ���û�����Ϣ��������ZobristУ�����м䣬���Է�ֹ��ȡ��ͻ
    struct HashStruct {
        uint32_t dwZobristLock0;           // ZobristУ��������һ����
        uint16_t wmv;                      // ����ŷ�
        uint8_t ucAlphaDepth, ucBetaDepth; // ���(�ϱ߽���±߽�)
        int16_t svlAlpha, svlBeta;         // ��ֵ(�ϱ߽���±߽�)
        uint32_t dwZobristLock1;           // ZobristУ�������ڶ�����
    }; // hsh
    
    // ����ṹ
    struct PositionStruct {
        // ������Ա
        int32_t sdPlayer;             // �ֵ��ķ��ߣ�0��ʾ�췽��1��ʾ�ڷ�
        uint8_t ucpcSquares[256]; // ÿ�����ӷŵ����ӣ�0��ʾû������
        uint8_t ucsqPieces[48];   // ÿ�����ӷŵ�λ�ã�0��ʾ����
        ZobristStruct zobr;       // Zobrist
        
        // λ�ṹ��Ա��������ǿ���̵Ĵ���
        union {
            uint32_t dwBitPiece;    // 32λ������λ��0��31λ���α�ʾ���Ϊ16��47�������Ƿ���������
            uint16_t wBitPiece[2];  // ��ֳ�����
        };
        uint16_t wBitRanks[16];   // λ�����飬ע���÷���"wBitRanks[RANK_Y(sq)]"
        uint16_t wBitFiles[16];   // λ�����飬ע���÷���"wBitFiles[FILE_X(sq)]"
        
        // ������������
        int32_t vlWhite, vlBlack;   // �췽�ͺڷ���������ֵ
        
        // �ع��ŷ����������ѭ������
        int32_t nMoveNum, nDistance;              // �ع��ŷ������������
        RollbackStruct rbsList[MAX_MOVE_NUM]; // �ع��б�
        uint8_t ucRepHash[REP_HASH_MASK + 1]; // Mini-displacement table for judging duplicate situations
        
        PreEvalStructEx PreEvalEx;
        MyPreGen* myPreGen = nullptr;
        
        // ��ȡ�ŷ�Ԥ������Ϣ
        SlideMoveStruct *RankMovePtr(int32_t x, int32_t y) {
            return myPreGen->PreGen.smvRankMoveTab[x - FILE_LEFT] + wBitRanks[y];
        }
        SlideMoveStruct *FileMovePtr(int32_t x, int32_t y) {
            return myPreGen->PreGen.smvFileMoveTab[y - RANK_TOP] + wBitFiles[x];
        }
        SlideMaskStruct *RankMaskPtr(int32_t x, int32_t y) {
            return myPreGen->PreGen.smsRankMaskTab[x - FILE_LEFT] + wBitRanks[y];
        }
        SlideMaskStruct *FileMaskPtr(int32_t x, int32_t y) {
            return myPreGen->PreGen.smsFileMaskTab[y - RANK_TOP] + wBitFiles[x];
        }
        
        // ���̴������
        void ClearBoard(void) { // ���̳�ʼ��
            sdPlayer = 0;
            memset(ucpcSquares, 0, 256);
            memset(ucsqPieces, 0, 48);
            zobr.InitZero();
            dwBitPiece = 0;
            memset(wBitRanks, 0, 16 * sizeof(uint16_t));
            memset(wBitFiles, 0, 16 * sizeof(uint16_t));
            vlWhite = vlBlack = 0;
            // "ClearBoard()"�����������"SetIrrev()"������ʼ��������Ա
        }
        
        void ChangeSide(void) { // �������巽
            sdPlayer = OPP_SIDE(sdPlayer);
            zobr.Xor(myPreGen->PreGen.zobrPlayer);
        }
        
        void SaveStatus(void) { // ����״̬
            RollbackStruct *lprbs;
            lprbs = rbsList + nMoveNum;
            lprbs->zobr = zobr;
            lprbs->vlWhite = vlWhite;
            lprbs->vlBlack = vlBlack;
        }
        
        void Rollback(void) {   // �ع�
            RollbackStruct *lprbs;
            lprbs = rbsList + nMoveNum;
            zobr = lprbs->zobr;
            vlWhite = lprbs->vlWhite;
            vlBlack = lprbs->vlBlack;
        }
        
        void AddPiece(int32_t sq, int32_t pc, bool bDel = false); // ��������������
        int32_t MovePiece(int32_t mv);                            // �ƶ�����
        void UndoMovePiece(int32_t mv, int32_t pcCaptured);       // �����ƶ�����
        int32_t Promote(int32_t sq);                              // ����
        void UndoPromote(int32_t sq, int32_t pcCaptured);         // ��������
        
        // �ŷ��������
        bool MakeMove(int32_t mv);   // ִ��һ���ŷ�
        void UndoMakeMove(void); // ����һ���ŷ�
        void NullMove(void);     // ִ��һ������
        void UndoNullMove(void); // ����һ������
        
        void SetIrrev(void) {    // �Ѿ�����ɡ������桱��������ع��ŷ�
            rbsList[0].mvs.dwmv = 0; // wmv, Chk, CptDrw, ChkChs = 0
            rbsList[0].mvs.ChkChs = CheckedBy();
            nMoveNum = 1;
            nDistance = 0;
            memset(ucRepHash, 0, REP_HASH_MASK + 1);
        }
        
        // ���洦�����
        void FromFen(const char *szFen); // FEN��ʶ��
        void ToFen(char *szFen) const;   // ����FEN��
        const char* MyToFen();
        void Mirror(void);               // ���澵��
        
        // �ŷ�������
        bool GoodCap(int32_t mv) {     // �õĳ����ŷ���⣬�������ŷ�����¼����ʷ���ɱ���ŷ�����
            int32_t pcMoved, pcCaptured;
            pcCaptured = ucpcSquares[DST(mv)];
            if (pcCaptured == 0) {
                return false;
            }
            if (!Protected(OPP_SIDE(sdPlayer), DST(mv))) {
                return true;
            }
            pcMoved = ucpcSquares[SRC(mv)];
            return SIMPLE_VALUE(pcCaptured) > SIMPLE_VALUE(pcMoved);
        }
        
        bool LegalMove(int32_t mv);            // �ŷ������Լ�⣬�����ڡ�ɱ���ŷ����ļ����
        int32_t CheckedBy(bool bLazy = false); // ���ĸ��ӽ���
        bool IsMate(void);                       // �ж����ѱ�����
        
        MoveStruct LastMove(void) const {        // ǰһ���ŷ������ŷ������˾���Ľ���״̬
            return rbsList[nMoveNum - 1].mvs;
        }
        
        bool CanPromote(void) const {            // �ж��Ƿ�������
            return (wBitPiece[sdPlayer] & PAWN_BITPIECE) != PAWN_BITPIECE && LastMove().ChkChs <= 0;
        }
        
        bool NullOkay(void) const {              // ����ʹ�ÿ��Ųü�������
            return (sdPlayer == 0 ? vlWhite : vlBlack) > NULLOKAY_MARGIN;
        }
        
        bool NullSafe(void) const {              // ���Ųü����Բ����������
            return (sdPlayer == 0 ? vlWhite : vlBlack) > NULLSAFE_MARGIN;
        }
        
        bool IsDraw(void) const {                // �����ж�
            if(!myPreGen->PreEval.bPromotion && (dwBitPiece & BOTH_BITPIECE(ATTACK_BITPIECE)) == 0){
                // printf("game draw: not attack piece\n");
                return true;
            }
            if(-LastMove().CptDrw >= DRAW_MOVES){
                // printf("game draw: >= DRAW_MOVES: %d\n", LastMove().CptDrw);
                if(nMoveNum>=DRAW_MOVES){
                    return true;
                }else{
                    // printf("error, pos is draw: why nMoveNum<DRAW_MOVES: %d\n", nMoveNum);
                }
            }
            if(nMoveNum == MAX_MOVE_NUM){
                // printf("game draw: MAX_MOVE_NUM\n");
                return true;
            }
            return false;
            /*return (!myPreGen->PreEval.bPromotion && (dwBitPiece & BOTH_BITPIECE(ATTACK_BITPIECE)) == 0) ||
            -LastMove().CptDrw >= DRAW_MOVES || nMoveNum == MAX_MOVE_NUM;*/
        }

        int32_t RepStatus(int32_t nRecur = 1);     // �ظ�������

        int32_t DrawValue(void) const {              // ����ķ�ֵ
            return (nDistance & 1) == 0 ? -DRAW_VALUE : DRAW_VALUE;
        }

        int32_t RepValue(int32_t vlRep) const {          // �ظ�����ķ�ֵ
            // return vlRep == REP_LOSS ? nDistance - MATE_VALUE : vlRep == REP_WIN ? MATE_VALUE - nDistance : DrawValue();
            // �����и��ķ�ֵ������BAN_VALUE����д���û���(����"hash.cpp")
            return vlRep == REP_LOSS ? nDistance - BAN_VALUE : vlRep == REP_WIN ? BAN_VALUE - nDistance : DrawValue();
        }

        int32_t Material(void) const {               // ����ƽ�⣬��������Ȩ����
            return SIDE_VALUE(sdPlayer, vlWhite - vlBlack) + myPreGen->PreEval.vlAdvanced;
        }
        
        // �ŷ����ɹ��̣�������Щ���̴������ر�����԰����Ƕ�������"genmoves.cpp"��
        bool Protected(int32_t sd, int32_t sqSrc, int32_t sqExcept = 0); // ���ӱ����ж�
        int32_t ChasedBy(int32_t mv);                                // ׽�ĸ���
        int32_t MvvLva(int32_t sqDst, int32_t pcCaptured, int32_t nLva);     // ����MVV(LVA)ֵ
        int32_t GenCapMoves(MoveStruct *lpmvs);                  // �����ŷ�������
        int32_t GenNonCapMoves(MoveStruct *lpmvs);               // �������ŷ�������

        int32_t GenAllMoves(MoveStruct *lpmvs) {                 // ȫ���ŷ�������
            // printf("position: genAllMove\n");
            int32_t nCapNum;
            nCapNum = GenCapMoves(lpmvs);
            // printf("GenAllMoves: nCapNum: %d\n", nCapNum);
            return nCapNum + GenNonCapMoves(lpmvs + nCapNum);
        }
        
        // �ŷ����ɹ��̣�������Щ���̴������ر�����԰����Ƕ�������"preeval.cpp"��"evaluate.cpp"��
        void PreEvaluate(void);
        int32_t AdvisorShape(void);
        int32_t StringHold(void);
        int32_t RookMobility(void);
        int32_t KnightTrap(void);
        int32_t Evaluate(int32_t vlAlpha, int32_t vlBeta);
        
        // TODO myMethod
        int32_t nHashMask;
        HashStruct *hshItems;
#ifdef HASH_QUIESC
        HashStruct *hshItemsQ;
#endif
        
    public:
        bool isOK();
        
        void print();

        int32_t getByteSize();
        
        static int32_t convertToByteArray(PositionStruct* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(PositionStruct* position, uint8_t* positionBytes, int32_t length, int32_t start, bool canCorrect);

        int32_t myGenMoves(uint32_t* lpmv);
        
// TODO hash method
        void MyDelHash();
        
        void MyNewHash(int32_t nHashScale);
        
        inline void MyClearHash();
        
        /*~PositionStruct()
        {
            printf("position destructor\n");
        }*/
    }; // pos
    
    void makePositionWrong(PositionStruct* pos);
}

#endif
