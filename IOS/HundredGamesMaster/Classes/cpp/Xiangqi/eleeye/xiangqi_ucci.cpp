/*
ucci.h/ucci.cpp - Source Code for ElephantEye, Part I

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.3, Last Modified: Mar. 2012
Copyright (C) 2004-2012 www.xqbase.com

This part (ucci.h/ucci.cpp only) of codes is NOT published under LGPL, and
can be used without restriction.
*/

#include <stdio.h>
#include "../base/xiangqi_base2.hpp"
#include "../base/xiangqi_parse.hpp"
#include "xiangqi_ucci.hpp"  

namespace Xiangqi
{
    
    const int32_t LINE_INPUT_MAX_CHAR = 8192;
    const int32_t MAX_MOVE_NUM = 1024;
    
    static char szFen[LINE_INPUT_MAX_CHAR];
    static uint32_t dwCoordList[MAX_MOVE_NUM];
    
    static bool ParsePos(UcciCommStruct &UcciComm, char *lp) {
        int32_t i;
        // �����ж��Ƿ�ָ����FEN��
        if (StrEqvSkip(lp, "fen ")) {
            strcpy(szFen, lp);
            UcciComm.szFenStr = szFen;
            // Ȼ���ж��Ƿ���startpos
        } else if (StrEqv(lp, "startpos")) {
            UcciComm.szFenStr = "rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w";
            // ������߶����ǣ�����������
        } else {
            return false;
        }
        // Ȼ��Ѱ���Ƿ�ָ���˺����ŷ������Ƿ���"moves"�ؼ���
        UcciComm.nMoveNum = 0;
        if (StrScanSkip(lp, " moves ")) {
            *(lp - strlen(" moves ")) = '\0';
            UcciComm.nMoveNum = MIN((int) (strlen(lp) + 1) / 5, MAX_MOVE_NUM); // ��ʾ��"moves"�����ÿ���ŷ�����1���ո��4���ַ�
            for (i = 0; i < UcciComm.nMoveNum; i ++) {
                dwCoordList[i] = *(uint32_t *) lp; // 4���ַ���ת��Ϊһ��"uint32_t"���洢�ʹ�����������
                lp += sizeof(uint32_t) + 1;
            }
            UcciComm.lpdwMovesCoord = dwCoordList;
        }
        return true;
    }
    
}
