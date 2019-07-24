/*
pregen.h/pregen.cpp - Source Code for ElephantEye, Part II

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.0, Last Modified: Nov. 2007
Copyright (C) 2004-2007 www.elephantbase.net

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

#include "../base/xiangqi_base.hpp"
#include "../base/xiangqi_rc4prng.hpp"
#include <stdio.h>
#include <string.h>
#include <cstdlib>

#ifndef XIANGQI_PREGEN_H
#define XIANGQI_PREGEN_H

namespace Xiangqi
{
    
#define __ASSERT_PIECE(pc) __ASSERT((pc) >= 16 && (pc) <= 47)
#define IF_PIECE(pc) ((pc) >= 16 && (pc) <= 47)
    
#define __ASSERT_SQUARE(sq) __ASSERT(IN_BOARD(sq))
#define IF_SQUARE(sq) IN_BOARD(sq)
    
#define __ASSERT_BITRANK(w) __ASSERT((w) < (1 << 9))
#define IF_BITRANK(w) ((w) < (1 << 9))
    
#define __ASSERT_BITFILE(w) __ASSERT((w) < (1 << 10))
#define IF_BITFILE(w) ((w) < (1 << 10))
    
    const int32_t RANK_TOP = 3;
    const int32_t RANK_BOTTOM = 12;
    const int32_t FILE_LEFT = 3;
    const int32_t FILE_CENTER = 7;
    const int32_t FILE_RIGHT = 11;
    
    extern const bool cbcInBoard[256];    // ���������
    extern const bool cbcInFort[256];     // �ǳ������
    extern const bool cbcCanPromote[256]; // ���������
    extern const int8_t ccLegalSpanTab[512];   // �����ŷ���ȱ�
    extern const int8_t ccKnightPinTab[512];   // ���ȱ�
    
    inline bool IN_BOARD(int32_t sq) {
        return cbcInBoard[sq];
    }
    
    inline bool IN_FORT(int32_t sq) {
        return cbcInFort[sq];
    }
    
    inline bool CAN_PROMOTE(int32_t sq) {
        return cbcCanPromote[sq];
    }
    
    inline int8_t LEGAL_SPAN_TAB(int32_t nDisp) {
        return ccLegalSpanTab[nDisp];
    }
    
    inline int8_t KNIGHT_PIN_TAB(int32_t nDisp) {
        return ccKnightPinTab[nDisp];
    }
    
    inline int32_t RANK_Y(int32_t sq) {
        return sq >> 4;
    }
    
    inline int32_t FILE_X(int32_t sq) {
        return sq & 15;
    }
    
    inline int32_t COORD_XY(int32_t x, int32_t y) {
        return x + (y << 4);
    }
    
    inline int32_t SQUARE_FLIP(int32_t sq) {
        return 254 - sq;
    }
    
    inline int32_t FILE_FLIP(int32_t x) {
        return 14 - x;
    }
    
    inline int32_t RANK_FLIP(int32_t y) {
        return 15 - y;
    }
    
    inline int32_t OPP_SIDE(int32_t sd) {
        return 1 - sd;
    }
    
    inline int32_t SQUARE_FORWARD(int32_t sq, int32_t sd) {
        return sq - 16 + (sd << 5);
    }
    
    inline int32_t SQUARE_BACKWARD(int32_t sq, int32_t sd) {
        return sq + 16 - (sd << 5);
    }
    
    inline bool KING_SPAN(int32_t sqSrc, int32_t sqDst) {
        return LEGAL_SPAN_TAB(sqDst - sqSrc + 256) == 1;
    }
    
    inline bool ADVISOR_SPAN(int32_t sqSrc, int32_t sqDst) {
        return LEGAL_SPAN_TAB(sqDst - sqSrc + 256) == 2;
    }
    
    inline bool BISHOP_SPAN(int32_t sqSrc, int32_t sqDst) {
        return LEGAL_SPAN_TAB(sqDst - sqSrc + 256) == 3;
    }
    
    inline int32_t BISHOP_PIN(int32_t sqSrc, int32_t sqDst) {
        return (sqSrc + sqDst) >> 1;
    }
    
    inline int32_t KNIGHT_PIN(int32_t sqSrc, int32_t sqDst) {
        return sqSrc + KNIGHT_PIN_TAB(sqDst - sqSrc + 256);
    }
    
    inline bool WHITE_HALF(int32_t sq) {
        return (sq & 0x80) != 0;
    }
    
    inline bool BLACK_HALF(int32_t sq) {
        return (sq & 0x80) == 0;
    }
    
    inline bool HOME_HALF(int32_t sq, int32_t sd) {
        return (sq & 0x80) != (sd << 7);
    }
    
    inline bool AWAY_HALF(int32_t sq, int32_t sd) {
        return (sq & 0x80) == (sd << 7);
    }
    
    inline bool SAME_HALF(int32_t sqSrc, int32_t sqDst) {
        return ((sqSrc ^ sqDst) & 0x80) == 0;
    }
    
    inline bool DIFF_HALF(int32_t sqSrc, int32_t sqDst) {
        return ((sqSrc ^ sqDst) & 0x80) != 0;
    }
    
    inline int32_t RANK_DISP(int32_t y) {
        return y << 4;
    }
    
    inline int32_t FILE_DISP(int32_t x) {
        return x;
    }
    
    // ������λ�С��͡�λ�С����ɳ����ŷ���Ԥ�ýṹ
    struct SlideMoveStruct {
        uint8_t ucNonCap[2];    // ���������ߵ������һ��/��Сһ��
        uint8_t ucRookCap[2];   // ���������ߵ������һ��/��Сһ��
        uint8_t ucCannonCap[2]; // �ڳ������ߵ������һ��/��Сһ��
        uint8_t ucSuperCap[2];  // ������(�����ӳ���)���ߵ������һ��/��Сһ��
        
        public: static void copyData(SlideMoveStruct* dest, SlideMoveStruct* from)
        {
            // uint8_t ucNonCap[2];
            {
                dest->ucNonCap[0] = from->ucNonCap[0];
                dest->ucNonCap[1] = from->ucNonCap[1];
            }
            // uint8_t ucRookCap[2];
            {
                dest->ucRookCap[0] = from->ucRookCap[0];
                dest->ucRookCap[1] = from->ucRookCap[1];
            }
            // uint8_t ucCannonCap[2];
            {
                dest->ucCannonCap[0] = from->ucCannonCap[0];
                dest->ucCannonCap[1] = from->ucCannonCap[1];
            }
            // uint8_t ucSuperCap[2];
            {
                dest->ucSuperCap[0] = from->ucSuperCap[0];
                dest->ucSuperCap[1] = from->ucSuperCap[1];
            }
        }
    }; // smv
    
    // ������λ�С��͡�λ�С��жϳ����ŷ������Ե�Ԥ�ýṹ
    struct SlideMaskStruct {
        uint16_t wNonCap, wRookCap, wCannonCap, wSuperCap;
        
        public: static void copyData(SlideMaskStruct* dest, SlideMaskStruct* from)
        {
            dest->wNonCap = from->wNonCap;
            dest->wRookCap = from->wRookCap;
            dest->wCannonCap = from->wCannonCap;
            dest->wSuperCap = from->wSuperCap;
        }
    }; // sms
    
    struct ZobristStruct {
        uint32_t dwKey;
        uint32_t dwLock0;
        uint32_t dwLock1;
        
        static int32_t getByteSize()
        {
            return 3*sizeof(uint32_t);
        }
        
        static int32_t convertToByteArray(ZobristStruct* zobr, uint8_t* &byteArray)
        {
            // find length of return
            int32_t length = zobr->getByteSize();
            byteArray = (uint8_t*)calloc(length, sizeof(uint8_t));
            {
                int32_t pointerIndex = 0;
                // uint32_t dwKey;
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        uint32_t value = zobr->dwKey;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: gamePly: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint32_t dwLock0;
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        uint32_t value = zobr->dwLock0;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: gamePly: %d, %d\n", pointerIndex, length);
                    }
                }
                // uint32_t dwLock1;
                {
                    int32_t size = sizeof(uint32_t);
                    if(pointerIndex+size<=length){
                        uint32_t value = zobr->dwLock1;
                        memcpy(byteArray + pointerIndex, &value, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: gamePly: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            return length;
        }
        
        static int32_t parseByteArray(ZobristStruct* zobr, uint8_t* positionBytes, int32_t length, int32_t start)
        {
            bool convertLog = false;
            if(convertLog)
                printf("parseByteArray: %d\n", length);
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                switch (index) {
                    case 0:
                        // uint32_t dwKey;
                    {
                        if(convertLog)
                            printf("zobr: parseByteArray: dwKey: %d\n", pointerIndex);
                        int32_t size = sizeof(uint32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&zobr->dwKey, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: dwKey: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                        // uint32_t dwLock0;
                    {
                        if(convertLog)
                            printf("zobr: parseByteArray: dwLock0: %d\n", pointerIndex);
                        int32_t size = sizeof(uint32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&zobr->dwLock0, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: dwLock0: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                        // uint32_t dwLock1;
                    {
                        if(convertLog)
                            printf("zobr: parseByteArray: dwLock1: %d\n", pointerIndex);
                        int32_t size = sizeof(uint32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&zobr->dwLock1, positionBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            if(convertLog)
                                printf("length error: dwLock1: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    default:
                    {
                        if(convertLog)
                            printf("error, convertByteArrayToPosition: unknown index: %d\n", index);
                        alreadyPassAll = true;
                    }
                        break;
                }
                // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
                index++;
                if (!isParseCorrect) {
                    if(convertLog)
                        printf("not parse correct\n");
                    break;
                }
                if (alreadyPassAll) {
                    break;
                }
            }
            // return
            if (!isParseCorrect) {
                if(convertLog)
                    printf("parse fail: %d; %d; %d\n", pointerIndex, length, start);
                return -1;
            } else {
                if(convertLog)
                    printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
                return (pointerIndex - start);
            }
        }
        
        void InitZero(void) {
            dwKey = dwLock0 = dwLock1 = 0;
        }
        
        void InitRC4(RC4Struct &rc4) {
            dwKey = rc4.NextLong();
            dwLock0 = rc4.NextLong();
            dwLock1 = rc4.NextLong();
            // printf("initRC4: %u; %u; %u\n", dwKey, dwLock0, dwLock1);
        }
        
        void Xor(const ZobristStruct &zobr) {
            dwKey ^= zobr.dwKey;
            dwLock0 ^= zobr.dwLock0;
            dwLock1 ^= zobr.dwLock1;
        }
        
        void Xor(const ZobristStruct &zobr1, const ZobristStruct &zobr2) {
            dwKey ^= zobr1.dwKey ^ zobr2.dwKey;
            dwLock0 ^= zobr1.dwLock0 ^ zobr2.dwLock0;
            dwLock1 ^= zobr1.dwLock1 ^ zobr2.dwLock1;
        }
        
    }; // zobr
    
    struct PreGenStruct {
        // Zobrist��ֵ����Zobrist��ֵ��ZobristУ����������
        ZobristStruct zobrPlayer;
        ZobristStruct zobrTable[14][256];
        
        uint16_t wBitRankMask[256]; // ÿ�����ӵ�λ�е�����λ
        uint16_t wBitFileMask[256]; // ÿ�����ӵ�λ�е�����λ
        
        /* ������λ�С��͡�λ�С����ɳ����ŷ����жϳ����ŷ������Ե�Ԥ������
         *
         * ��λ�С��͡�λ�С�������ElephantEye�ĺ��ļ����������������ڵ��ŷ����ɡ������жϺ;��������
         * �Գ�ʼ����췽�ұߵ����ڸ��е��ж�Ϊ�������ȱ���֪�����еġ�λ�С�����"1010000101b"��
         * ElephantEye������Ԥ�����飬��"...MoveTab"��"...MaskTab"���÷��ֱ��ǣ�
         * һ�����Ҫ֪��������ǰ���ӵ�Ŀ���(��ʼ����2��Ŀ�����9)����ôϣ��������֪��������ӣ�
         * ����Ԥ������һ������"FileMoveTab_CannonCap[10][1024]"��ʹ��"FileMoveTab_CannonCap[2][1010000101b] == 9"�Ϳ����ˡ�
         * �������Ҫ�жϸ����ܷ�Ե�Ŀ���(ͬ������ʼ����2��Ŀ�����9Ϊ��)����ô��Ҫ֪��Ŀ����λ�У���"0000000001b"��
         * ����ֻҪ��"...MoveTab"�ĸ����ԡ�����λ������ʽ���¼�������"...MaskTab"�Ϳ����ˣ��á��롱�������ж��ܷ�Ե�Ŀ���
         * ����ͨ��һ��"...MaskTab"��Ԫ������������λ���ж��ܷ�Ե�ͬ�л�ͬ�е�ĳ������ʱ��ֻ��Ҫ��һ���жϾͿ����ˡ�
         */
        SlideMoveStruct smvRankMoveTab[9][512];   // 36,864 �ֽ�
        SlideMoveStruct smvFileMoveTab[10][1024]; // 81,920 �ֽ�
        SlideMaskStruct smsRankMaskTab[9][512];   // 36,864 �ֽ�
        SlideMaskStruct smsFileMaskTab[10][1024]; // 81,920 �ֽ�
        // ����:  237,568 �ֽ�
        
        /* ��������(���ʺ��á�λ�С��͡�λ�С�)���ŷ�Ԥ��������
         *
         * �ⲿ�����������������ϵġ��ŷ�Ԥ���ɡ����飬���Ը���ĳ�����ӵ���ʼ��ֱ�Ӳ����飬�õ����е�Ŀ���
         * ʹ������ʱ�����Ը�����ʼ����ȷ��һ��ָ��"g_...Moves[Square]"�����ָ��ָ��һϵ��Ŀ�����0������
         * Ϊ�˶����ַ������[256][n]��n����4�ı��������ұ������n(��Ϊ��������˽�����ʶ��0)���������ۺ��������顣
         */
        uint8_t ucsqKingMoves[256][8];
        uint8_t ucsqAdvisorMoves[256][8];
        uint8_t ucsqBishopMoves[256][8];
        uint8_t ucsqBishopPins[256][4];
        uint8_t ucsqKnightMoves[256][12];
        uint8_t ucsqKnightPins[256][8];
        uint8_t ucsqPawnMoves[2][256][4];
        
        /*~PreGenStruct()
        {
            printf("Pregen destructor\n");
        }*/
    };
    
    // ����Ԥ���۽ṹ
    struct PreEvalStruct {
        bool bPromotion;
        int32_t vlAdvanced;
        uint8_t ucvlWhitePieces[7][256];
        uint8_t ucvlBlackPieces[7][256];
    };
    
    struct MyPreGen
    {
        PreGenStruct PreGen;
        PreEvalStruct PreEval;
        
    public:
        void PreGenInit(void);
    };
    
}

#endif