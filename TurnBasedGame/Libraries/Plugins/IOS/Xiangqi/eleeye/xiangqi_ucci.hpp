/*
ucci.h/ucci.cpp - Source Code for ElephantEye, Part I

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.2, Last Modified: Sep. 2010
Copyright (C) 2004-2010 www.xqbase.com

This part (ucci.h/ucci.cpp only) of codes is NOT published under LGPL, and
can be used without restriction.
*/

#include "../base/xiangqi_base.hpp"

#ifndef XIANGQI_UCCI_H
#define XIANGQI_UCCI_H

namespace Xiangqi
{
    const int32_t UCCI_MAX_DEPTH = 32; // UCCI����˼���ļ������
    
    // ��UCCIָ���йؼ����йص�ѡ��
    enum UcciOptionEnum {
        UCCI_OPTION_UNKNOWN, UCCI_OPTION_BATCH, UCCI_OPTION_DEBUG, UCCI_OPTION_PONDER, UCCI_OPTION_USEHASH, UCCI_OPTION_USEBOOK, UCCI_OPTION_USEEGTB,
        UCCI_OPTION_BOOKFILES, UCCI_OPTION_EGTBPATHS, UCCI_OPTION_HASHSIZE, UCCI_OPTION_THREADS, UCCI_OPTION_PROMOTION,
        UCCI_OPTION_IDLE, UCCI_OPTION_PRUNING, UCCI_OPTION_KNOWLEDGE, UCCI_OPTION_RANDOMNESS, UCCI_OPTION_STYLE, UCCI_OPTION_NEWGAME
    }; // ��"setoption"ָ����ѡ��
    enum UcciRepetEnum {
        UCCI_REPET_ALWAYSDRAW, UCCI_REPET_CHECKBAN, UCCI_REPET_ASIANRULE, UCCI_REPET_CHINESERULE
    }; // ѡ��"repetition"���趨ֵ
    enum UcciGradeEnum {
        UCCI_GRADE_NONE, UCCI_GRADE_TINY, UCCI_GRADE_SMALL, UCCI_GRADE_MEDIUM, UCCI_GRADE_LARGE, UCCI_GRADE_HUGE
    }; // ѡ��"idle"��"pruning"��"knowledge"��"selectivity"���趨ֵ
    enum UcciStyleEnum {
        UCCI_STYLE_SOLID, UCCI_STYLE_NORMAL, UCCI_STYLE_RISKY
    }; // ѡ��"style"���趨ֵ
    enum UcciGoEnum {
        UCCI_GO_DEPTH, UCCI_GO_NODES, UCCI_GO_TIME_MOVESTOGO, UCCI_GO_TIME_INCREMENT
    }; // ��"go"ָ��ָ����ʱ��ģʽ���ֱ����޶���ȡ��޶��������ʱ���ƺͼ�ʱ��
    enum UcciCommEnum {
        UCCI_COMM_UNKNOWN, UCCI_COMM_UCCI, UCCI_COMM_ISREADY, UCCI_COMM_PONDERHIT, UCCI_COMM_PONDERHIT_DRAW, UCCI_COMM_STOP,
        UCCI_COMM_SETOPTION, UCCI_COMM_POSITION, UCCI_COMM_BANMOVES, UCCI_COMM_GO, UCCI_COMM_PROBE, UCCI_COMM_QUIT
    }; // UCCIָ������
    
    // UCCIָ����Խ��ͳ������������Ľṹ
    union UcciCommStruct {
        
        /* �ɵõ�������Ϣ��UCCIָ��ֻ������4������
         *
         * 1. "setoption"ָ��ݵ���Ϣ���ʺ���"UCCI_COMM_SETOPTION"ָ������
         *    "setoption"ָ�������趨ѡ����������ܵ�����Ϣ�С�ѡ�����͡��͡�ѡ��ֵ��
         *    ���磬"setoption batch on"��ѡ�����;���"UCCI_OPTION_DEBUG"��ֵ(Value.bCheck)����"true"
         */
        struct {
            UcciOptionEnum Option; // ѡ������
            union {                // ѡ��ֵ
                int32_t nSpin;           // "spin"���͵�ѡ���ֵ
                bool bCheck;         // "check"���͵�ѡ���ֵ
                UcciRepetEnum Repet; // "combo"���͵�ѡ��"repetition"��ֵ
                UcciGradeEnum Grade; // "combo"���͵�ѡ��"pruning"��"knowledge"��"selectivity"��ֵ
                UcciStyleEnum Style; // "combo"���͵�ѡ��"style"��ֵ
                char *szOption;      // "string"���͵�ѡ���ֵ
            };                     // "button"���͵�ѡ��û��ֵ
        };
        
        /* 2. "position"ָ��ݵ���Ϣ���ʺ���"e_CommPosition"ָ������
         *    "position"ָ���������þ��棬������ʼ������ͬ�����ŷ����ɵľ���
         *    ���磬position startpos moves h2e2 h9g8��FEN������"startpos"�����FEN�����ŷ���(MoveNum)����2
         */
        struct {
            const char *szFenStr;     // FEN�����������(��"startpos"��)Ҳ�ɽ���������ת����FEN��
            int32_t nMoveNum;             // �����ŷ���
            uint32_t *lpdwMovesCoord; // �����ŷ���ָ�����"IdleLine()"�е�һ����̬���飬�����԰�"CoordList"����������
        };
        
        /* 3. "banmoves"ָ��ݵ���Ϣ���ʺ���"e_CommBanMoves"ָ������
         *    "banmoves"ָ���������ý�ֹ�ŷ������ݽṹʱ������"position"ָ��ĺ����ŷ�����û��FEN��
         */
        struct {
            int32_t nBanMoveNum;
            uint32_t *lpdwBanMovesCoord;
        };
        
        /* 4. "go"ָ��ݵ���Ϣ���ʺ���"UCCI_COMM_GOָ������
         *    "go"ָ��������˼��(����)��ͬʱ�趨˼��ģʽ�����̶���ȡ�ʱ���ƻ��Ǽ�ʱ��
         */
        struct {
            UcciGoEnum Go; // ˼��ģʽ
            bool bPonder;  // ��̨˼��
            bool bDraw;    // ���
            union {
                int32_t nDepth, nNodes, nTime;
            }; // ��ȡ��������ʱ��
            union {
                int32_t nMovesToGo, nIncrement;
            }; // �޶�ʱ����Ҫ�߶��ٲ���(��ʱ��)������ò����޶�ʱ��Ӷ���(ʱ����)
        };
    };

}

#endif
