/*
genmoves.cpp - Source Code for ElephantEye, Part IV

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
#include "xiangqi_pregen.hpp"
#include "xiangqi_position.hpp"

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
    
    // ��ģ��ֻ�漰��"PositionStruct"�е�"sdPlayer"��"ucpcSquares"��"ucsqPieces"������Ա����ʡ��ǰ���"this->"
    
    // ���ӱ����ж�
    bool PositionStruct::Protected(int32_t sd, int32_t sqSrc, int32_t sqExcept){
        // ����"sqExcept"��ʾ�ų�����������(ָ���ӱ��)�����Ǳ�ǣ���ӵı���ʱ����Ҫ�ų�ǣ��Ŀ���ӵı���
        int32_t i, sqDst, sqPin, pc, x, y, nSideTag;
        SlideMaskStruct *lpsmsRank, *lpsmsFile;
        // ���ӱ����жϰ������¼������裺
        
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
            sqSrc = 128;
        }
        nSideTag = SIDE_TAG(sd);
        if (HOME_HALF(sqSrc, sd)) {
            if (IN_FORT(sqSrc)) {
                
                // 1. �ж��ܵ�˧(��)�ı���
                sqDst = ucsqPieces[nSideTag + KING_FROM];
                if (sqDst != 0 && sqDst != sqExcept) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (KING_SPAN(sqSrc, sqDst)) {
                        return true;
                    }
                }
                
                // 2. �ж��ܵ���(ʿ)�ı���
                for (i = ADVISOR_FROM; i <= ADVISOR_TO; i ++) {
                    sqDst = ucsqPieces[nSideTag + i];
                    if (sqDst != 0 && sqDst != sqExcept) {
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        if (ADVISOR_SPAN(sqSrc, sqDst)) {
                            return true;
                        }
                    }
                }
            }
            
            // 3. �ж��ܵ���(��)�ı���
            for (i = BISHOP_FROM; i <= BISHOP_TO; i ++) {
                sqDst = ucsqPieces[nSideTag + i];
                if (sqDst != 0 && sqDst != sqExcept) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (BISHOP_SPAN(sqSrc, sqDst) && ucpcSquares[BISHOP_PIN(sqSrc, sqDst)] == 0) {
                        return true;
                    }
                }
            }
        } else {
            
            // 4. �ж��ܵ����ӱ�(��)����ı���
            for (sqDst = sqSrc - 1; sqDst <= sqSrc + 1; sqDst += 2) {
                // ��������ڱ��ߣ���ô���Բ�����
                // __ASSERT_SQUARE(sqDst);
                if (sqDst != sqExcept) {
                    pc = ucpcSquares[sqDst];
                    if ((pc & nSideTag) != 0 && PIECE_INDEX(pc) >= PAWN_FROM) {
                        return true;
                    }
                }
            }
        }
        
        // 5. �ж��ܵ���(��)����ı���
        sqDst = SQUARE_BACKWARD(sqSrc, sd);
        // ��������ڵ��ߣ���ô���Բ�����
        // __ASSERT_SQUARE(sqDst);
        if (sqDst != sqExcept) {
            pc = ucpcSquares[sqDst];
            if ((pc & nSideTag) != 0 && PIECE_INDEX(pc) >= PAWN_FROM) {
                return true;
            }
        }
        
        // 6. �ж��ܵ���ı���
        for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
            sqDst = ucsqPieces[nSideTag + i];
            if (sqDst != 0 && sqDst != sqExcept) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                sqPin = KNIGHT_PIN(sqDst, sqSrc); // ע�⣬sqSrc��sqDst�Ƿ��ģ�
                if (sqPin != sqDst && ucpcSquares[sqPin] == 0) {
                    return true;
                }
            }
        }
        
        x = FILE_X(sqSrc);
        y = RANK_Y(sqSrc);
        lpsmsRank = RankMaskPtr(x, y);
        lpsmsFile = FileMaskPtr(x, y);
        
        // 7. �ж��ܵ����ı���������"position.cpp"���"CheckedBy()"����
        for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
            sqDst = ucsqPieces[nSideTag + i];
            if (sqDst != 0 && sqDst != sqSrc && sqDst != sqExcept) {
                if (x == FILE_X(sqDst)) {
                    if ((lpsmsFile->wRookCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0) {
                        return true;
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if ((lpsmsRank->wRookCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0) {
                        return true;
                    }
                }
            }
        }
        
        // 8. �ж��ܵ��ڵı���������"position.cpp"���"CheckedBy()"����
        for (i = CANNON_FROM; i <= CANNON_TO; i ++) {
            sqDst = ucsqPieces[nSideTag + i];
            if (sqDst && sqDst != sqSrc && sqDst != sqExcept) {
                if (x == FILE_X(sqDst)) {
                    if ((lpsmsFile->wCannonCap & myPreGen->PreGen.wBitFileMask[sqDst]) != 0) {
                        return true;
                    }
                } else if (y == RANK_Y(sqDst)) {
                    if ((lpsmsRank->wCannonCap & myPreGen->PreGen.wBitRankMask[sqDst]) != 0) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
    /* ����MVV(LVA)ֵ�ĺ���
     *
     * MVV(LVA)ָ���ǣ�����������ޱ�������ôȡֵMVV������ȡֵMVV-LVA��
     * ����ElephantEye��MVV(LVA)ֵ�ڼ�����Ϻ��ټ���1���������������ǣ���������¼��ֺ��壺
     * a. MVV(LVA)����1��˵�������Ӽ�ֵ���ڹ�����(��������׬��)�����ֳ��ӽ�������������̬����Ҳ���������ֳ��ӣ�
     * b. MVV(LVA)����1��˵����������һ����ֵ(�Գ����ڻ�Թ��ӱ��䣬����������ǿ��ģ�Ҳֵ��һ��)����̬����Ҳ���������ֳ��ӣ�
     * c. MVV(LVA)����0��˵��������û�м�ֵ����̬���������������ֳ��ӡ�
     *
     * MVV��ֵ��"SIMPLE_VALUE"�ǰ���˧(��)=5����=4������=3����(��)=2����(ʿ)��(��)=1�趨�ģ�
     * LVA��ֱֵ�������ڳ����ŷ��������С�
     */
    int32_t PositionStruct::MvvLva(int32_t sqDst, int32_t pcCaptured, int32_t nLva) {
        int32_t nMvv, nLvaAdjust;
        nMvv = SIMPLE_VALUE(pcCaptured);
        nLvaAdjust = (Protected(OPP_SIDE(sdPlayer), sqDst) ? nLva : 0);
        if (nMvv >= nLvaAdjust) {
            return nMvv - nLvaAdjust + 1;
        } else {
            return (nMvv >= 3 || HOME_HALF(sqDst, sdPlayer)) ? 1 : 0;
        }
    }
    
    // �����ŷ�����������MVV(LVA)�趨��ֵ
    int32_t PositionStruct::GenCapMoves(MoveStruct *lpmvs) {
        int32_t i, sqSrc, sqDst, pcCaptured;
        int32_t x, y, nSideTag, nOppSideTag;
        bool bCanPromote;
        SlideMoveStruct *lpsmv;
        uint8_t *lpucsqDst, *lpucsqPin;
        MoveStruct *lpmvsCurr;
        // ���ɳ����ŷ��Ĺ��̰������¼������裺
        
        lpmvsCurr = lpmvs;
        nSideTag = SIDE_TAG(sdPlayer);
        nOppSideTag = OPP_SIDE_TAG(sdPlayer);
        bCanPromote = myPreGen->PreEval.bPromotion && CanPromote();
        
        // 1. ����˧(��)���ŷ�
        sqSrc = ucsqPieces[nSideTag + KING_FROM];
        if (sqSrc != 0) {
            // __ASSERT_SQUARE(sqSrc);
            if(!IF_SQUARE(sqSrc)){
                printf("error, ASSERT_SQUARE(sqSrc)\n");
                sqSrc = 128;
            }
            lpucsqDst = myPreGen->PreGen.ucsqKingMoves[sqSrc];
            sqDst = *lpucsqDst;
            while (sqDst != 0) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                // �ҵ�һ���ŷ��������жϳԵ��������Ƿ��ǶԷ����ӣ�����������"nOppSideTag"�ı�־(16��32�ߵ�)��
                // ����ǶԷ����ӣ��򱣴�MVV(LVA)ֵ��������������ޱ�������ֻ��MVV�������MVV-LVA(���MVV>LVA�Ļ�)��
                pcCaptured = ucpcSquares[sqDst];
                if ((pcCaptured & nOppSideTag) != 0) {
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 5); // ˧(��)�ļ�ֵ��5
                    lpmvsCurr ++;
                }
                lpucsqDst ++;
                sqDst = *lpucsqDst;
            }
        }
        
        // 2. ������(ʿ)���ŷ�
        for (i = ADVISOR_FROM; i <= ADVISOR_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqAdvisorMoves[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 1); // ��(ʿ)�ļ�ֵ��1
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                }
                if (bCanPromote && CAN_PROMOTE(sqSrc)) {
                    lpmvsCurr->wmv = MOVE(sqSrc, sqSrc);
                    lpmvsCurr->wvl = 0;
                    lpmvsCurr ++;
                }
            }
        }
        
        // 3. ������(��)���ŷ�
        for (i = BISHOP_FROM; i <= BISHOP_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqBishopMoves[sqSrc];
                lpucsqPin = myPreGen->PreGen.ucsqBishopPins[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[*lpucsqPin] == 0) {
                        pcCaptured = ucpcSquares[sqDst];
                        if ((pcCaptured & nOppSideTag) != 0) {
                            // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                            if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                                printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                            }
                            lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                            lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 1); // ��(��)�ļ�ֵ��1
                            lpmvsCurr ++;
                        }
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                    lpucsqPin ++;
                }
                if (bCanPromote && CAN_PROMOTE(sqSrc)) {
                    lpmvsCurr->wmv = MOVE(sqSrc, sqSrc);
                    lpmvsCurr->wvl = 0;
                    lpmvsCurr ++;
                }
            }
        }
        
        // 4. ��������ŷ�
        for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqKnightMoves[sqSrc];
                lpucsqPin = myPreGen->PreGen.ucsqKnightPins[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[*lpucsqPin] == 0) {
                        pcCaptured = ucpcSquares[sqDst];
                        if ((pcCaptured & nOppSideTag) != 0) {
                            // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                            if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                                printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                            }
                            lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                            lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 3); // ��ļ�ֵ��3
                            lpmvsCurr ++;
                        }
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                    lpucsqPin ++;
                }
            }
        }
        
        // 5. ���ɳ����ŷ�
        for (i = ROOK_FROM; i <= ROOK_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                
                lpsmv = RankMovePtr(x, y);
                sqDst = lpsmv->ucRookCap[0] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 4); // ���ļ�ֵ��4
                        lpmvsCurr ++;
                    }
                }
                sqDst = lpsmv->ucRookCap[1] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 4); // ���ļ�ֵ��4
                        lpmvsCurr ++;
                    }
                }
                
                lpsmv = FileMovePtr(x, y);
                sqDst = lpsmv->ucRookCap[0] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 4); // ���ļ�ֵ��4
                        lpmvsCurr ++;
                    }
                }
                sqDst = lpsmv->ucRookCap[1] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 4); // ���ļ�ֵ��4
                        lpmvsCurr ++;
                    }
                }
            }
        }
        
        // 6. �����ڵ��ŷ�
        for (i = CANNON_FROM; i <= CANNON_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)");
                    sqSrc = 128;
                }
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                
                lpsmv = RankMovePtr(x, y);
                sqDst = lpsmv->ucCannonCap[0] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 3); // �ڵļ�ֵ��3
                        lpmvsCurr ++;
                    }
                }
                sqDst = lpsmv->ucCannonCap[1] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 3); // �ڵļ�ֵ��3
                        lpmvsCurr ++;
                    }
                }
                
                lpsmv = FileMovePtr(x, y);
                sqDst = lpsmv->ucCannonCap[0] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 3); // �ڵļ�ֵ��3
                        lpmvsCurr ++;
                    }
                }
                sqDst = lpsmv->ucCannonCap[1] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                if (sqDst != sqSrc) {
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 3); // �ڵļ�ֵ��3
                        lpmvsCurr ++;
                    }
                }
            }
        }
        
        // 7. ���ɱ�(��)���ŷ�
        for (i = PAWN_FROM; i <= PAWN_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqPawnMoves[sdPlayer][sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    pcCaptured = ucpcSquares[sqDst];
                    if ((pcCaptured & nOppSideTag) != 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->wmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr->wvl = MvvLva(sqDst, pcCaptured, 2); // ��(��)�ļ�ֵ��2
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                }
            }
        }
        return (int)(lpmvsCurr - lpmvs);
    }
    
    // �������ŷ�������
    int32_t PositionStruct::GenNonCapMoves(MoveStruct *lpmvs)
    {
        int32_t i, sqSrc, sqDst, x, y, nSideTag;
        SlideMoveStruct *lpsmv;
        uint8_t *lpucsqDst, *lpucsqPin;
        MoveStruct *lpmvsCurr;
        // ���ɲ������ŷ��Ĺ��̰������¼������裺
        
        lpmvsCurr = lpmvs;
        nSideTag = SIDE_TAG(sdPlayer);
        
        // 1. ����˧(��)���ŷ�
        sqSrc = ucsqPieces[nSideTag + KING_FROM];
        if (sqSrc != 0) {
            // __ASSERT_SQUARE(sqSrc);
            if(!IF_SQUARE(sqSrc)){
                printf("error, ASSERT_SQUARE(sqSrc)\n");
                sqSrc = 128;
            }
            lpucsqDst = myPreGen->PreGen.ucsqKingMoves[sqSrc];
            sqDst = *lpucsqDst;
            while (sqDst != 0) {
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                // �ҵ�һ���ŷ��������ж��Ƿ�Ե�����
                if (ucpcSquares[sqDst] == 0) {
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr ++;
                }
                lpucsqDst ++;
                sqDst = *lpucsqDst;
            }
        }
        
        // 2. ������(ʿ)���ŷ�
        for (i = ADVISOR_FROM; i <= ADVISOR_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqAdvisorMoves[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[sqDst] == 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                }
            }
        }
        
        // 3. ������(��)���ŷ�
        for (i = BISHOP_FROM; i <= BISHOP_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqBishopMoves[sqSrc];
                lpucsqPin = myPreGen->PreGen.ucsqBishopPins[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[*lpucsqPin] == 0 && ucpcSquares[sqDst] == 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                    lpucsqPin ++;
                }
            }
        }
        
        // 4. ��������ŷ�
        for (i = KNIGHT_FROM; i <= KNIGHT_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                lpucsqDst = myPreGen->PreGen.ucsqKnightMoves[sqSrc];
                lpucsqPin = myPreGen->PreGen.ucsqKnightPins[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[*lpucsqPin] == 0 && ucpcSquares[sqDst] == 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                    lpucsqPin ++;
                }
            }
        }
        
        // 5. ���ɳ����ڵ��ŷ���û�б�Ҫ�ж��Ƿ�Ե���������
        for (i = ROOK_FROM; i <= CANNON_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                    sqSrc = 128;
                }
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                
                lpsmv = RankMovePtr(x, y);
                sqDst = lpsmv->ucNonCap[0] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                while (sqDst != sqSrc) {
                    // printf("ucpcSquares: %d %d; %d %d; %ld\n", ucpcSquares[sqSrc], ucpcSquares[sqDst], sqSrc, sqDst, lpmvsCurr - lpmvs);
                    // __ASSERT(ucpcSquares[sqDst] == 0);
                    if(!(ucpcSquares[sqDst] == 0)){
                        printf("error, ASSERT(ucpcSquares[sqDst] == 0)\n");
                    }
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr ++;
                    sqDst --;
                }
                sqDst = lpsmv->ucNonCap[1] + RANK_DISP(y);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                while (sqDst != sqSrc) {
                    // __ASSERT(ucpcSquares[sqDst] == 0);
                    if(!(ucpcSquares[sqDst] == 0)){
                        printf("error, ASSERT(ucpcSquares[sqDst] == 0)\n");
                    }
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr ++;
                    sqDst ++;
                }
                
                lpsmv = FileMovePtr(x, y);
                sqDst = lpsmv->ucNonCap[0] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                }
                while (sqDst != sqSrc) {
                    // __ASSERT(ucpcSquares[sqDst] == 0);
                    if(!(ucpcSquares[sqDst] == 0)){
                        printf("error, ASSERT(ucpcSquares[sqDst] == 0)");
                    }
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr ++;
                    sqDst -= 16;
                }
                sqDst = lpsmv->ucNonCap[1] + FILE_DISP(x);
                // __ASSERT_SQUARE(sqDst);
                if(!IF_SQUARE(sqDst)){
                    printf("error, ASSERT_SQUARE(sqDst)\n");
                    sqDst = 128;
                }
                while (sqDst != sqSrc) {
                    // __ASSERT(ucpcSquares[sqDst] == 0);
                    if(!(ucpcSquares[sqDst] == 0)){
                        printf("error, ASSERT(ucpcSquares[sqDst] == 0)\n");
                    }
                    // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                    if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                        printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                    }
                    lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                    lpmvsCurr ++;
                    sqDst += 16;
                }
            }
        }
        
        // 6. ���ɱ�(��)���ŷ�
        for (i = PAWN_FROM; i <= PAWN_TO; i ++) {
            sqSrc = ucsqPieces[nSideTag + i];
            if (sqSrc != 0) {
                // __ASSERT_SQUARE(sqSrc);
                if(!IF_SQUARE(sqSrc)){
                    printf("error, ASSERT_SQUARE(sqSrc)\n");
                }
                lpucsqDst = myPreGen->PreGen.ucsqPawnMoves[sdPlayer][sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[sqDst] == 0) {
                        // __ASSERT(LegalMove(MOVE(sqSrc, sqDst)));
                        if(!(LegalMove(MOVE(sqSrc, sqDst)))){
                            printf("error, ASSERT(LegalMove(MOVE(sqSrc, sqDst)))\n");
                        }
                        lpmvsCurr->dwmv = MOVE(sqSrc, sqDst);
                        lpmvsCurr ++;
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                }
            }
        }
        return (int)(lpmvsCurr - lpmvs);
    }
    
    // ��׽���ļ��
    int32_t PositionStruct::ChasedBy(int32_t mv)
    {
        int32_t i, nSideTag, pcMoved, pcCaptured;
        int32_t sqSrc, sqDst, x, y;
        uint8_t *lpucsqDst, *lpucsqPin;
        SlideMoveStruct *lpsmv;
        
        sqSrc = DST(mv);
        pcMoved = this->ucpcSquares[sqSrc];
        nSideTag = SIDE_TAG(this->sdPlayer);
        // __ASSERT_SQUARE(sqSrc);
        if(!IF_SQUARE(sqSrc)){
            printf("error, ASSERT_SQUARE(sqSrc)\n");
            sqSrc = 128;
        }
        // __ASSERT_PIECE(pcMoved);
        if(!IF_PIECE(pcMoved)){
            printf("error, ASSERT_PIECE(pcMoved)\n");
        }
        // __ASSERT_BOUND(0, pcMoved - OPP_SIDE_TAG(this->sdPlayer), 15);
        if(!__IF_BOUND(0, pcMoved - OPP_SIDE_TAG(this->sdPlayer), 15)){
            printf("error, ASSERT_BOUND(0, pcMoved - OPP_SIDE_TAG(this->sdPlayer), 15)\n");
        }
        
        // ��׽�����жϰ������¼��������ݣ�
        switch (pcMoved - OPP_SIDE_TAG(this->sdPlayer)) {
                
                // 1. �������ж��Ƿ�׽����׽�и����ڱ�(��)
            case KNIGHT_FROM:
            case KNIGHT_TO:
                // ��һ�����ȵİ˸�λ��
                lpucsqDst = myPreGen->PreGen.ucsqKnightMoves[sqSrc];
                lpucsqPin = myPreGen->PreGen.ucsqKnightPins[sqSrc];
                sqDst = *lpucsqDst;
                while (sqDst != 0) {
                    // __ASSERT_SQUARE(sqDst);
                    if(!IF_SQUARE(sqDst)){
                        printf("error, ASSERT_SQUARE(sqDst)\n");
                        sqDst = 128;
                    }
                    if (ucpcSquares[*lpucsqPin] == 0) {
                        pcCaptured = this->ucpcSquares[sqDst];
                        if ((pcCaptured & nSideTag) != 0) {
                            pcCaptured -= nSideTag;
                            // __ASSERT_BOUND(0, pcCaptured, 15);
                            if(!__IF_BOUND(0, pcCaptured, 15)){
                                printf("error, ASSERT_BOUND(0, pcCaptured, 15)\n");
                            }
                            // ���ɣ��Ż������жϵķ�֦
                            if (pcCaptured <= ROOK_TO) {
                                // ��׽��(ʿ)����(��)�����������迼��
                                if (pcCaptured >= ROOK_FROM) {
                                    // ��׽���˳�
                                    return pcCaptured;
                                }
                            } else {
                                if (pcCaptured <= CANNON_TO) {
                                    // ��׽�����ڣ�Ҫ�ж����Ƿ��ܱ���
                                    if (!Protected(this->sdPlayer, sqDst)) {
                                        return pcCaptured;
                                    }
                                } else {
                                    // ��׽���˱�(��)��Ҫ�жϱ�(��)�Ƿ���Ӳ��ܱ���
                                    if (AWAY_HALF(sqDst, sdPlayer) && !Protected(this->sdPlayer, sqDst)) {
                                        return pcCaptured;
                                    }
                                }
                            }
                        }
                    }
                    lpucsqDst ++;
                    sqDst = *lpucsqDst;
                    lpucsqPin ++;
                }
                break;
                
                // 2. ���˳����ж��Ƿ�׽�и������ڱ�(��)
            case ROOK_FROM:
            case ROOK_TO:
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                if (((SRC(mv) ^ sqSrc) & 0xf) == 0) {
                    // ����������ƶ��ˣ����жϳ�����Ե�����
                    lpsmv = RankMovePtr(x, y);
                    for (i = 0; i < 2; i ++) {
                        sqDst = lpsmv->ucRookCap[i] + RANK_DISP(y);
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        if (sqDst != sqSrc) {
                            pcCaptured = this->ucpcSquares[sqDst];
                            if ((pcCaptured & nSideTag) != 0) {
                                pcCaptured -= nSideTag;
                                // __ASSERT_BOUND(0, pcCaptured, 15);
                                if(!__IF_BOUND(0, pcCaptured, 15)){
                                    printf("error, ASSERT_BOUND(0, pcCaptured, 15)\n");
                                }
                                // ���ɣ��Ż������жϵķ�֦
                                if (pcCaptured <= ROOK_TO) {
                                    // ��׽��(ʿ)����(��)��������迼��
                                    if (pcCaptured >= KNIGHT_FROM) {
                                        if (pcCaptured <= KNIGHT_TO) {
                                            // ��׽������Ҫ�ж����Ƿ��ܱ���
                                            if (!Protected(this->sdPlayer, sqDst)) {
                                                return pcCaptured;
                                            }
                                        }
                                        // ��׽����������迼��
                                    }
                                } else {
                                    if (pcCaptured <= CANNON_TO) {
                                        // ��׽�����ڣ�Ҫ�ж����Ƿ��ܱ���
                                        if (!Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    } else {
                                        // ��׽���˱�(��)��Ҫ�жϱ�(��)�Ƿ���Ӳ��ܱ���
                                        if (AWAY_HALF(sqDst, sdPlayer) && !Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else {
                    // ����������ƶ��ˣ����жϳ�����Ե�����
                    lpsmv = FileMovePtr(x, y);
                    for (i = 0; i < 2; i ++) {
                        sqDst = lpsmv->ucRookCap[i] + FILE_DISP(x);
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        if (sqDst != sqSrc) {
                            pcCaptured = this->ucpcSquares[sqDst];
                            if ((pcCaptured & nSideTag) != 0) {
                                pcCaptured -= nSideTag;
                                // __ASSERT_BOUND(0, pcCaptured, 15);
                                if(!__IF_BOUND(0, pcCaptured, 15)){
                                    printf("error, ASSERT_BOUND(0, pcCaptured, 15)\n");
                                }
                                // ���ɣ��Ż������жϵķ�֦
                                if (pcCaptured <= ROOK_TO) {
                                    // ��׽��(ʿ)����(��)��������迼��
                                    if (pcCaptured >= KNIGHT_FROM) {
                                        if (pcCaptured <= KNIGHT_TO) {
                                            // ��׽������Ҫ�ж����Ƿ��ܱ���
                                            if (!Protected(this->sdPlayer, sqDst)) {
                                                return pcCaptured;
                                            }
                                        }
                                        // ��׽����������迼��
                                    }
                                } else {
                                    if (pcCaptured <= CANNON_TO) {
                                        // ��׽�����ڣ�Ҫ�ж����Ƿ��ܱ���
                                        if (!Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    } else {
                                        // ��׽���˱�(��)��Ҫ�жϱ�(��)�Ƿ���Ӳ��ܱ���
                                        if (AWAY_HALF(sqDst, sdPlayer) && !Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
                
                // 3. �����ڣ��ж��Ƿ�׽����׽�и������(��)
            case CANNON_FROM:
            case CANNON_TO:
                x = FILE_X(sqSrc);
                y = RANK_Y(sqSrc);
                if (((SRC(mv) ^ sqSrc) & 0xf) == 0) {
                    // ����������ƶ��ˣ����ж��ں���Ե�����
                    lpsmv = RankMovePtr(x, y);
                    for (i = 0; i < 2; i ++) {
                        sqDst = lpsmv->ucCannonCap[i] + RANK_DISP(y);
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        if (sqDst != sqSrc) {
                            pcCaptured = this->ucpcSquares[sqDst];
                            if ((pcCaptured & nSideTag) != 0) {
                                pcCaptured -= nSideTag;
                                // __ASSERT_BOUND(0, pcCaptured, 15);
                                if(!__IF_BOUND(0, pcCaptured, 15)){
                                    printf("error, ASSERT_BOUND(0, pcCaptured, 15)\n");
                                }
                                // ���ɣ��Ż������жϵķ�֦
                                if (pcCaptured <= ROOK_TO) {
                                    // ��׽��(ʿ)����(��)��������迼��
                                    if (pcCaptured >= KNIGHT_FROM) {
                                        if (pcCaptured <= KNIGHT_TO) {
                                            // ��׽������Ҫ�ж����Ƿ��ܱ���
                                            if (!Protected(this->sdPlayer, sqDst)) {
                                                return pcCaptured;
                                            }
                                        } else {
                                            // ��׽���˳�
                                            return pcCaptured;
                                        }
                                    }
                                } else {
                                    // ��׽�ڵ�������迼��
                                    if (pcCaptured >= PAWN_FROM) {
                                        // ��׽���˱�(��)��Ҫ�жϱ�(��)�Ƿ���Ӳ��ܱ���
                                        if (AWAY_HALF(sqDst, sdPlayer) && !Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else {
                    // ����ں����ƶ��ˣ����ж�������Ե�����
                    lpsmv = FileMovePtr(x, y);
                    for (i = 0; i < 2; i ++) {
                        sqDst = lpsmv->ucCannonCap[i] + FILE_DISP(x);
                        // __ASSERT_SQUARE(sqDst);
                        if(!IF_SQUARE(sqDst)){
                            printf("error, ASSERT_SQUARE(sqDst)\n");
                            sqDst = 128;
                        }
                        if (sqDst != sqSrc) {
                            pcCaptured = this->ucpcSquares[sqDst];
                            if ((pcCaptured & nSideTag) != 0) {
                                pcCaptured -= nSideTag;
                                // __ASSERT_BOUND(0, pcCaptured, 15);
                                if(!__IF_BOUND(0, pcCaptured, 15)){
                                    printf("error, ASSERT_BOUND(0, pcCaptured, 15)\n");
                                }
                                // ���ɣ��Ż������жϵķ�֦
                                if (pcCaptured <= ROOK_TO) {
                                    // ��׽��(ʿ)����(��)��������迼��
                                    if (pcCaptured >= KNIGHT_FROM) {
                                        if (pcCaptured <= KNIGHT_TO) {
                                            // ��׽������Ҫ�ж����Ƿ��ܱ���
                                            if (!Protected(this->sdPlayer, sqDst)) {
                                                return pcCaptured;
                                            }
                                        } else {
                                            // ��׽���˳�
                                            return pcCaptured;
                                        }
                                    }
                                } else {
                                    // ��׽�ڵ�������迼��
                                    if (pcCaptured >= PAWN_FROM) {
                                        // ��׽���˱�(��)��Ҫ�жϱ�(��)�Ƿ���Ӳ��ܱ���
                                        if (AWAY_HALF(sqDst, sdPlayer) && !Protected(this->sdPlayer, sqDst)) {
                                            return pcCaptured;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
        }
        
        return 0;
    }
}
