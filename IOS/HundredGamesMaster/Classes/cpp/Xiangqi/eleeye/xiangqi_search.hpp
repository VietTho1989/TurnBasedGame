/*
search.h/search.cpp - Source Code for ElephantEye, Part VIII

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

#include "../base/xiangqi_base.hpp"
#include "../base/xiangqi_rc4prng.hpp"
#ifndef CCHESS_A3800
  #include "xiangqi_ucci.hpp"
#endif
#include "xiangqi_pregen.hpp"
#include "xiangqi_position.hpp"

#ifndef XIANGQI_SEARCH_H
#define XIANGQI_SEARCH_H

#ifdef _WIN32
#include <windows.h>
#else
#define WINAPI
#endif

#include "xiangqi_movesort.hpp"

namespace Xiangqi
{
    
    // ������Ϣ���Ƿ�װ��ģ���ڲ���
    struct Search2 {
        int64_t llTime;                     // ��ʱ��
        bool bStop, bPonderStop;            // ��ֹ�źźͺ�̨˼����Ϊ����ֹ�ź�
        bool bPopPv, bPopCurrMove;          // �Ƿ����pv��currmove
        int32_t nPopDepth, vlPopValue;          // �������Ⱥͷ�ֵ
        int32_t nAllNodes, nMainNodes;          // �ܽ���������������Ľ����
        int32_t nUnchanged;                     // δ�ı�����ŷ������
        uint16_t wmvPvLine[MAX_MOVE_NUM];   // ��Ҫ����·���ϵ��ŷ��б�
        uint16_t wmvKiller[LIMIT_DEPTH][2]; // ɱ���ŷ���
        MoveSortStruct MoveSort;            // �������ŷ�����
    };
    
    // ����ģʽ
    const int32_t GO_MODE_INFINITY = 0;
    const int32_t GO_MODE_NODES = 1;
    const int32_t GO_MODE_TIMER = 2;
    
    struct SearchResult
    {
        uint32_t move;
        int32_t order = 0;
        int32_t score = -MATE_VALUE;
        int32_t depth = 0;
    };
    
    struct MoveScore
    {
        uint32_t move;
        int32_t score = -MATE_VALUE;
        int32_t depth = 0;
    };
    
    // ����ǰ�����õ�ȫ�ֱ�����ָ����������
    struct SearchStruct {
        Search2 search2;
        
        // temperory save move score
        MoveScore moveScores[MAX_GEN_MOVES];
        int32_t nMoveScore = 0;
        
        PositionStruct pos;                // �д������ľ���
        bool bQuit, bPonder, bDraw;        // �Ƿ��յ��˳�ָ���̨˼��ģʽ�����ģʽ
        bool bBatch, bDebug;               // �Ƿ�������ģʽ�͵���ģʽ
        bool bUseHash, bUseBook;           // �Ƿ�ʹ���û���ü��Ϳ��ֿ�
        bool bNullMove, bKnowledge;        // �Ƿ���Ųü���ʹ�þ�������֪ʶ
        bool bIdle;                        // �Ƿ����
        RC4Struct rc4Random;               // �����
        int32_t nGoMode, nNodes, nCountMask;   // ����ģʽ���������
        int32_t nProperTimer, nMaxTimer;       // �ƻ�ʹ��ʱ��
        int32_t nRandomMask, nBanMoves;        // ���������λ�ͽ�����
        uint16_t wmvBanList[MAX_MOVE_NUM]; // �����б�
        char szBookFile[1024];             // ���ֿ�
        
        bool bAlwaysCheck;                 // �Ƿ�ֻ����(������ɱ�ž�)
        const char *(WINAPI *GetEngineName)(void);                     // ����������������API����ָ��
        void (WINAPI *PreEvaluate)(PositionStruct *, PreEvalStruct *); // ����Ԥ����API����ָ��
        int32_t (WINAPI *Evaluate)(PositionStruct *, int, int, int);
        
        // TODO my method
    public:
        bool quit(void);
        
        bool Interrupt(void);
        
        void PopPvLine(int32_t nDepth = 0, int32_t vl = 0);

        int32_t SearchQuiesc(PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta);
        
        void PopLeaf(PositionStruct &pos);

        int32_t SearchCut(int32_t vlBeta, int32_t nDepth, bool bNoNull = false);

        int32_t SearchPV(int32_t vlAlpha, int32_t vlBeta, int32_t nDepth, uint16_t *lpwmvPvLine);

        int32_t SearchRoot(int32_t nDepth);
        
        bool SearchUnique(int32_t vlBeta, int32_t nDepth);
        
        void MySearchMain(int32_t nDepth);
        
    public:
        int32_t pickBestMove = 100;
        uint32_t mvResult = 0;
    };
    
    // extern SearchStruct Search;
    
#ifndef CCHESS_A3800
    
    // UCCI���湹�����
    void BuildPos(PositionStruct &pos, const UcciCommStruct &UcciComm);
    
    // UCCI֧�� - ���Ҷ�ӽ��ľ�����Ϣ
    void PopLeaf(PositionStruct &pos);
    
#endif
    
    inline int32_t MyEvaluate(SearchStruct* search, PositionStruct &pos, int32_t vlAlpha, int32_t vlBeta);
    
}

#endif
