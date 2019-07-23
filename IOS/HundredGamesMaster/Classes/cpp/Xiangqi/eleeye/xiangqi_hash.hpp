/*
hash.h/hash.cpp - Source Code for ElephantEye, Part V

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.31, Last Modified: May 2012
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
#include "../base/xiangqi_base.hpp"
#include "xiangqi_position.hpp"

#ifndef XIANGQI_HASH_H
#define XIANGQI_HASH_H

namespace Xiangqi
{
    
    // �û����־��ֻ����"RecordHash()"������
    const int32_t HASH_BETA = 1;
    const int32_t HASH_ALPHA = 2;
    const int32_t HASH_PV = HASH_ALPHA | HASH_BETA;
    
    const int32_t HASH_LAYERS = 2;   // �û���Ĳ���
    const int32_t NULL_DEPTH = 2;    // ���Ųü������
    
    inline void ClearHash(PositionStruct &pos) {         // ����û���
        memset(pos.hshItems, 0, (pos.nHashMask + 1) * sizeof(HashStruct));
#ifdef HASH_QUIESC
        memset(hshItemsQ, 0, (nHashMask + 1) * sizeof(HashStruct));
#endif
    }
    
    inline void NewHash(PositionStruct &pos, int32_t nHashScale) { // �����û�����С�� 2^nHashScale �ֽ�
        pos.nHashMask = ((1 << nHashScale) / sizeof(HashStruct)) - 1;
        pos.hshItems = new HashStruct[pos.nHashMask + 1];
#ifdef HASH_QUIESC
        hshItemsQ = new HashStruct[nHashMask + 1];
#endif
        ClearHash(pos);
    }
    
    inline void DelHash(PositionStruct &pos)
    {           // �ͷ��û���
        delete[] pos.hshItems;
#ifdef HASH_QUIESC
        delete[] hshItemsQ;
#endif
    }
    
    // �ж��û����Ƿ���Ͼ���(Zobrist���Ƿ����)
    inline bool HASH_POS_EQUAL(const HashStruct &hsh, const PositionStruct &pos) {
        return hsh.dwZobristLock0 == pos.zobr.dwLock0 && hsh.dwZobristLock1 == pos.zobr.dwLock1;
    }
    
    // ������Ͳ�����ȡ�û�����(����һ�����ã����Զ��丳ֵ)
    inline HashStruct &HASH_ITEM(const PositionStruct &pos, int32_t nLayer) {
        return pos.hshItems[(pos.zobr.dwKey + nLayer) & pos.nHashMask];
    }
    
    // �û���Ĺ������
    void RecordHash(PositionStruct &pos, int32_t nFlag, int32_t vl, int32_t nDepth, int32_t mv);                    // �洢�û��������Ϣ
    int32_t ProbeHash(PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta, int32_t nDepth, bool bNoNull, int32_t &mv); // ��ȡ�û��������Ϣ
#ifdef HASH_QUIESC
    void RecordHashQ(const PositionStruct &pos, int32_t vlBeta, int32_t vlAlpha); // �洢�û��������Ϣ(��̬����)
    int32_t ProbeHashQ(const PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta);   // ��ȡ�û��������Ϣ(��̬����)
#endif
    
#ifndef CCHESS_A3800
    // UCCI֧�� - ���Hash���еľ�����Ϣ
    bool PopHash(PositionStruct &pos);
#endif
    
}

#endif
