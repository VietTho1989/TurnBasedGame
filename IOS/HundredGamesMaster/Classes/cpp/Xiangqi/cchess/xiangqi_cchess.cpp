/*
cchess.h/cchess.cpp - Source Code for ElephantEye, Additional Part

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.21, Last Modified: Sep. 2010
Copyright (C) 2004-2010 www.xqbase.com

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

#include <stdio.h>
#include <string.h>
#include "../base/xiangqi_base.hpp"
#include "../eleeye/xiangqi_position.hpp"
#include "xiangqi_cchess.hpp"

namespace Xiangqi
{
    /* ��������ElephantEyeԴ����ĸ���ģ�飬�����ǽ�ElephantEye��Դ����Ӧ�õ���������С�
     * �������һ����ҪӦ�����й�����������������ڱ���ʱ����"CCHESS_DLL"�󣬼��ɱ����"CCHESS.DLL"��
     * Ŀǰ�����������Ѿ���Ϊ��������ʦ����һ���֣���Ҳʹ�á�������ʦ�����й�����������ϵĺ��Ĵ��빫�����ˡ�
     */
    
#ifdef CCHESS_DLL
    
#include <windows.h>
    
    extern "C" __declspec(dllexport) LPCSTR WINAPI CchessVersion(VOID);
    extern "C" __declspec(dllexport) VOID WINAPI CchessInit(BOOL bTraditional);
    extern "C" __declspec(dllexport) VOID WINAPI CchessPromotion(BOOL bPromotion);
    extern "C" __declspec(dllexport) VOID WINAPI CchessAddPiece(PositionStruct *lppos, LONG sq, LONG pc, BOOL bDel);
    extern "C" __declspec(dllexport) BOOL WINAPI CchessCanPromote(PositionStruct *lppos, LONG sq);
    extern "C" __declspec(dllexport) BOOL WINAPI CchessTryMove(PositionStruct *lppos, LPLONG lpStatus, LONG mv);
    extern "C" __declspec(dllexport) VOID WINAPI CchessUndoMove(PositionStruct *lppos);
    extern "C" __declspec(dllexport) BOOL WINAPI CchessTryNull(PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessUndoNull(PositionStruct *lppos);
    extern "C" __declspec(dllexport) LONG WINAPI CchessGenMoves(PositionStruct *lppos, LPLONG lpmv);
    extern "C" __declspec(dllexport) VOID WINAPI CchessSetIrrev(PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessClearBoard(PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessBoardMirror(PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessExchangeSide(PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessFlipBoard(PositionStruct *lppos);
    extern "C" __declspec(dllexport) LPSTR WINAPI CchessBoardText(const PositionStruct *lppos, BOOL bAnsi);
    extern "C" __declspec(dllexport) LPSTR WINAPI CchessBoard2Fen(const PositionStruct *lppos);
    extern "C" __declspec(dllexport) VOID WINAPI CchessFen2Board(PositionStruct *lppos, LPCSTR szFen);
    extern "C" __declspec(dllexport) LPSTR WINAPI CchessFenMirror(LPCSTR szFenSrc);
    extern "C" __declspec(dllexport) LONG WINAPI CchessFileMirror(LONG dwFileStr);
    extern "C" __declspec(dllexport) LONG WINAPI CchessChin2File(LONGLONG qwChinStr);
    extern "C" __declspec(dllexport) LONGLONG WINAPI CchessFile2Chin(LONG dwFileStr, LONG sd);
    extern "C" __declspec(dllexport) LONG WINAPI CchessFile2Move(LONG dwFileStr, const PositionStruct *lppos);
    extern "C" __declspec(dllexport) LONG WINAPI CchessMove2File(LONG mv, const PositionStruct *lppos);
    
    // ��������İ汾�ţ��ڡ�������ʦ����ʹ�á����ڹ��򡱹��ܿ��Կ�����
    static const char *const cszCchessVersion = "Chinese Chess Driver 3.21";
    
    LPCSTR WINAPI CchessVersion(VOID) {
        return cszCchessVersion;
    }
    
    VOID WINAPI CchessInit(BOOL bTraditional) {
        PreGenInit();
        ChineseInit(bTraditional != FALSE);
    }
    
    VOID WINAPI CchessPromotion(BOOL bPromotion) {
        PreEval.bPromotion = bPromotion != FALSE;
    }
    
    VOID WINAPI CchessAddPiece(PositionStruct *lppos, LONG sq, LONG pc, BOOL bDel) {
        lppos->AddPiece(sq, pc, bDel != FALSE);
    }
    
    BOOL WINAPI CchessCanPromote(PositionStruct *lppos, LONG sq) {
        int32_t pt;
        if (PreEval.bPromotion && lppos->CanPromote() && CAN_PROMOTE(sq)) {
            pt = PIECE_TYPE(lppos->ucpcSquares[sq]);
            return pt == ADVISOR_TYPE || pt == BISHOP_TYPE;
        }
        return FALSE;
    }
    
    BOOL WINAPI CchessTryMove(PositionStruct *lppos, LPLONG lpStatus, LONG mv) {
        return TryMove(*lppos, *(int32_t *) lpStatus, mv);
    }
    
    VOID WINAPI CchessUndoMove(PositionStruct *lppos) {
        lppos->UndoMakeMove();
    }
    
    // ִ�С����š����ù���Ŀǰ�����ڡ�����������������
    BOOL WINAPI CchessTryNull(PositionStruct *lppos) {
        if (lppos->LastMove().ChkChs > 0) {
            return FALSE;
        } else {
            lppos->NullMove();
            return TRUE;
        }
    }
    
    // ���������š����ù���Ŀǰ�����ڡ�����������������
    VOID WINAPI CchessUndoNull(PositionStruct *lppos) {
        lppos->UndoNullMove();
    }
    
    // ����ȫ�������ŷ�
    LONG WINAPI CchessGenMoves(PositionStruct *lppos, LPLONG lpmv) {
        int32_t i, nTotal, nLegal;
        MoveStruct mvs[MAX_GEN_MOVES];
        nTotal = lppos->GenAllMoves(mvs);
        nLegal = 0;
        for (i = 0; i < nTotal; i ++) {
            if (lppos->MakeMove(mvs[i].wmv)) {
                lppos->UndoMakeMove();
                lpmv[nLegal] = mvs[i].wmv;
                nLegal ++;
            }
        }
        return nLegal;
    }
    
    VOID WINAPI CchessSetIrrev(PositionStruct *lppos) {
        lppos->SetIrrev();
    }
    
    VOID WINAPI CchessClearBoard(PositionStruct *lppos) {
        lppos->ClearBoard();
    }
    
    VOID WINAPI CchessStartBoard(PositionStruct *lppos) {
        lppos->FromFen(cszStartFen);
    }
    
    VOID WINAPI CchessBoardMirror(PositionStruct *lppos) {
        lppos->Mirror();
    }
    
    VOID WINAPI CchessExchangeSide(PositionStruct *lppos) {
        ExchangeSide(*lppos);
    }
    
    VOID WINAPI CchessFlipBoard(PositionStruct *lppos) {
        FlipBoard(*lppos);
    }
    
    LPSTR WINAPI CchessBoardText(const PositionStruct *lppos, BOOL bAnsi) {
        static char szBoard[2048];
        BoardText(szBoard, *lppos, bAnsi != FALSE);
        return szBoard;
    }
    
    LPSTR WINAPI CchessBoard2Fen(const PositionStruct *lppos) {
        static char szFen[128];
        lppos->ToFen(szFen);
        return szFen;
    }
    
    VOID WINAPI CchessFen2Board(PositionStruct *lppos, LPCSTR szFen) {
        lppos->FromFen(szFen);
    }
    
    LPSTR WINAPI CchessFenMirror(LPCSTR szFenSrc) {
        static char szFenDst[128];
        FenMirror(szFenDst, szFenSrc);
        return szFenDst;
    }
    
    LONG WINAPI CchessFileMirror(LONG dwFileStr) {
        return FileMirror(dwFileStr);
    }
    
    LONG WINAPI CchessChin2File(LONGLONG qwChinStr) {
        return Chin2File(qwChinStr);
    }
    
    LONGLONG WINAPI CchessFile2Chin(LONG dwFileStr, LONG sd) {
        return File2Chin(dwFileStr, sd);
    }
    
    LONG WINAPI CchessFile2Move(LONG dwFileStr, const PositionStruct *lppos) {
        return File2Move(dwFileStr, *lppos);
    }
    
    LONG WINAPI CchessMove2File(LONG mv, const PositionStruct *lppos) {
        return Move2File(mv, *lppos);
    }
    
#endif
    
    /* ElephantEyeԴ����ʹ�õ��������Ǻ�Լ����
     *
     * sq: �������(��������0��255������"pregen.cpp")
     * pc: �������(��������0��47������"position.cpp")
     * pt: �����������(��������0��6������"position.cpp")
     * mv: �ŷ�(��������0��65535������"position.cpp")
     * sd: ���ӷ�(������0����췽��1����ڷ�)
     * vl: �����ֵ(��������"-MATE_VALUE"��"MATE_VALUE"������"position.cpp")
     * (ע����������Ǻſ���uc��dw�ȴ��������ļǺ����ʹ��)
     * pos: ����(PositionStruct���ͣ�����"position.h")
     * sms: λ�к�λ�е��ŷ�����Ԥ�ýṹ(����"pregen.h")
     * smv: λ�к�λ�е��ŷ��ж�Ԥ�ýṹ(����"pregen.h")
     */
    
    /* ���³����涨���ŷ���ʾʹ�õ����֡����ӡ�����(��ƽ��)��λ��(ǰ��)�ȵ���������
     *
     * ��ʾλ�õķ��Ź���8�������ˡ�ǰ�к����⻹�С�һ�������塱���ο�
     * ���й��������Ӧ�ù淶(��)���ŷ���ʾ��(��ơ��淶��)����������ҳ��
     * ����http://www.elephantbase.net/protocol/cchess_move.htm
     * ���ڡ�ǰ�к󡱱������ڡ�һ�������塱�Ժ󣬵��ֺ͡���ƽ�ˡ��ڷ�����һ�£����Ҫ�Ӽ�"DIRECT_TO_POS"��ת����
     * ���⣬������(ʿ)��(��)���ŷ���ʾ��������ʽ��������ʽ��һһ��Ӧ�Ĺ�ϵ(�̶����߱�ʾ)��
     * ��˿���ʹ������"cdwFixFile"��"cucFixMove"�����߽���ת�����ܹ���28�ֶ�Ӧ��ϵ��
     */
    const int32_t MAX_DIGIT = 9;
    const int32_t MAX_PIECE = 7;
    const int32_t MAX_DIRECT = 3;
    const int32_t MAX_POS = 8;
    const int32_t DIRECT_TO_POS = 5;
    const int32_t MAX_FIX_FILE = 28;
    
    /* ���������֡����ӡ������λ�ñ����Ӧ�ķ��źͺ��֡�
     *
     * ���鳤������Ҫ����Щ���ŵĸ�����1����"ccDirect2Byte"Ϊ����������û�з����ĳ�����Ŷ�Ӧʱ��
     * �÷�����Ϊ"MAX_DIRECT"����ԭ�ɷ���ʱ��֤���鲻Խ�磬���Կո��ʾ��
     * ���������м���(GBK��)�ͷ���(BIG5��)���ף���"cwDirect2Word..."Ϊ������׺"-Simp"��ʾ���壬"-Trad"��ʾ���塣
     * ������ʹ��ǰ��������"lpcwDirect2Word"ָ������λ�����ĺ���"ChineseInit()"��
     */
    
    static const char ccDirect2Byte[4] = {
        '+', '.', '-', ' '
    };
    
    static const char ccPos2Byte[12] = {
        'a', 'b', 'c', 'd', 'e', '+', '.', '-', ' ', ' ', ' ', ' '
    };
    
    static const uint16_t cwDigit2WordSimp[2][10] = {
        {
            0xbbd2/*һ*/, 0xfeb6/*��*/, 0xfdc8/*��*/, 0xc4cb/*��*/, 0xe5ce/*��*/,
            0xf9c1/*��*/, 0xdfc6/*��*/, 0xcbb0/*��*/, 0xc5be/*��*/, 0xa1a1/*��*/
        }, {
            0xb1a3/*��*/, 0xb2a3/*��*/, 0xb3a3/*��*/, 0xb4a3/*��*/, 0xb5a3/*��*/,
            0xb6a3/*��*/, 0xb7a3/*��*/, 0xb8a3/*��*/, 0xb9a3/*��*/, 0xa1a1/*��*/
        }
    };
    
    static const uint16_t cwPiece2WordSimp[2][8] = {
        {
            0xa7cb/*˧*/, 0xcbca/*��*/, 0xe0cf/*��*/, 0xedc2/*��*/, 0xb5b3/*��*/, 0xdac5/*��*/, 0xf8b1/*��*/, 0xa1a1/*��*/
        }, {
            0xabbd/*��*/, 0xbfca/*ʿ*/, 0xf3cf/*��*/, 0xedc2/*��*/, 0xb5b3/*��*/, 0xdac5/*��*/, 0xe4d7/*��*/, 0xa1a1/*��*/
        }
    };
    
    static const uint16_t cwDirect2WordSimp[4] = {
        0xf8bd/*��*/, 0xbdc6/*ƽ*/, 0xcbcd/*��*/, 0xa1a1/*��*/
    };
    
    static const uint16_t cwPos2WordSimp[10] = {
        0xbbd2/*һ*/, 0xfeb6/*��*/, 0xfdc8/*��*/, 0xc4cb/*��*/, 0xe5ce/*��*/,
        0xb0c7/*ǰ*/, 0xd0d6/*��*/, 0xf3ba/*��*/, 0xa1a1/*��*/, 0xa1a1/*��*/
    };
    
    static const uint16_t cwDigit2WordTrad[2][10] = {
        {
            0x40a4/*�@[һ]*/, 0x47a4/*�G[��]*/, 0x54a4/*�T[��]*/, 0x7ca5/*�|[��]*/, 0xada4/*��[��]*/,
            0xbba4/*��[��]*/, 0x43a4/*�C[��]*/, 0x4ba4/*�K[��]*/, 0x45a4/*�E[��]*/, 0x40a1/*�@*/
        }, {
            0xb0a2/*��[��]*/, 0xb1a2/*��[��]*/, 0xb2a2/*��[��]*/, 0xb3a2/*��[��]*/, 0xb4a2/*��[��]*/,
            0xb5a2/*��[��]*/, 0xb6a2/*��[��]*/, 0xb7a2/*��[��]*/, 0xb8a2/*��[��]*/, 0x40a1/*�@*/
        }
    };
    
    static const uint16_t cwPiece2WordTrad[2][8] = {
        {
            0xd3ab/*��[��]*/, 0x4ba5/*�K[��]*/, 0xdbac/*��[��]*/, 0xa8b0/*��[�R]*/,
            0xaea8/*��[܇]*/, 0xb6ac/*��[��]*/, 0x4ca7/*�L[��]*/, 0x40a1/*�@*/
        }, {
            0x4eb1/*�N[��]*/, 0x68a4/*�h[ʿ]*/, 0x48b6/*�H[��]*/, 0xa8b0/*��[�R]*/,
            0xaea8/*��[܇]*/, 0xb6ac/*��[��]*/, 0xf2a8/*��[��]*/, 0x40a1/*�@*/
        }
    };
    
    static const uint16_t cwDirect2WordTrad[4] = {
        0x69b6/*�i[�M]*/, 0xada5/*��[ƽ]*/, 0x68b0/*�h[��]*/, 0x40a1/*�@*/
    };
    
    static const uint16_t cwPos2WordTrad[10] = {
        0x40a4/*�@[һ]*/, 0x47a4/*�G[��]*/, 0x54a4/*�T[��]*/, 0x7ca5/*�|[��]*/, 0xada4/*��[��]*/,
        0x65ab/*�e[ǰ]*/, 0xa4a4/*��[��]*/, 0xe1ab/*��[��]*/, 0x40a1/*�@*/, 0x40a1/*�@*/
    };
    
    // �̶����߱�ʾ����������
    static const uint32_t cdwFixFile[28] = {
        0x352d3441/*A4-5*/, 0x352b3441/*A4+5*/, 0x342d3541/*A5-4*/, 0x342b3541/*A5+4*/,
        0x362d3541/*A5-6*/, 0x362b3541/*A5+6*/, 0x352d3641/*A6-5*/, 0x352b3641/*A6+5*/,
        0x332d3142/*B1-3*/, 0x332b3142/*B1+3*/, 0x312d3342/*B3-1*/, 0x312b3342/*B3+1*/,
        0x352d3342/*B3-5*/, 0x352b3342/*B3+5*/, 0x332d3542/*B5-3*/, 0x332b3542/*B5+3*/,
        0x372d3542/*B5-7*/, 0x372b3542/*B5+7*/, 0x352d3742/*B7-5*/, 0x352b3742/*B7+5*/,
        0x392d3742/*B7-9*/, 0x392b3742/*B7+9*/, 0x372d3942/*B9-7*/, 0x372b3942/*B9+7*/,
        0x503d3441/*A4=P*/, 0x503d3641/*A6=P*/, 0x503d3342/*B3=P*/, 0x503d3742/*B7=P*/
    };
    
    // �̶����߱�ʾ����������
    static const uint8_t cucFixMove[28][2] = {
        {0xa8, 0xb7}, {0xc8, 0xb7}, {0xb7, 0xc8}, {0xb7, 0xa8}, {0xb7, 0xc6}, {0xb7, 0xa6}, {0xa6, 0xb7}, {0xc6, 0xb7},
        {0xab, 0xc9}, {0xab, 0x89}, {0x89, 0xab}, {0xc9, 0xab}, {0x89, 0xa7}, {0xc9, 0xa7}, {0xa7, 0xc9}, {0xa7, 0x89},
        {0xa7, 0xc5}, {0xa7, 0x85}, {0x85, 0xa7}, {0xc5, 0xa7}, {0x85, 0xa3}, {0xc5, 0xa3}, {0xa3, 0xc5}, {0xa3, 0x85},
        {0xc8, 0xc8}, {0xc6, 0xc6}, {0xc9, 0xc9}, {0xc5, 0xc5}
    };
    
    // �����ı����̵������ַ�
    /*static const char *cszBoardStrSimp[19] = {
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ���ܩ�����  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  �������ܩ�  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ��  ��  ��  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ��  ��  ��  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��                              �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ��  ��  ��  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ��  ��  ��  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  ���ܩ�����  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� ",
        " ��  ��  ��  �������ܩ�  ��  ��  �� ",
        " ��--��--��--��--��--��--��--��--�� "
    };*/
    
    // �����ı����̵������ַ�
    /*static const char *cszBoardStrTrad[19] = {
        " �z--�s--�s--�s--�s--�s--�s--�s--�{ ",
        " �x  �x  �x  �x�@�x���x  �x  �x  �x ",
        " �u--�q--�q--�q--��--�q--�q--�q--�t ",
        " �x  �x  �x  �x���x�@�x  �x  �x  �x ",
        " �u--�q--�q--�q--�q--�q--�q--�q--�t ",
        " �x  �x  �x  �x  �x  �x  �x  �x  �x ",
        " �u--�q--�q--�q--�q--�q--�q--�q--�t ",
        " �x  �x  �x  �x  �x  �x  �x  �x  �x ",
        " �u--�r--�r--�r--�r--�r--�r--�r--�t ",
        " �x                              �x ",
        " �u--�s--�s--�s--�s--�s--�s--�s--�t ",
        " �x  �x  �x  �x  �x  �x  �x  �x  �x ",
        " �u--�q--�q--�q--�q--�q--�q--�q--�t ",
        " �x  �x  �x  �x  �x  �x  �x  �x  �x ",
        " �u--�q--�q--�q--�q--�q--�q--�q--�t ",
        " �x  �x  �x  �x�@�x���x  �x  �x  �x ",
        " �u--�q--�q--�q--��--�q--�q--�q--�t ",
        " �x  �x  �x  �x���x�@�x  �x  �x  �x ",
        " �|--�r--�r--�r--�r--�r--�r--�r--�} "
    };*/
    
    /* ������������ʵ�����ڲ���������(Square)��������������(FileSq)��ת����
     *
     * �ڲ�������������3��߽��16x16��������(����"pregen.cpp")��Ϊ����ת�������߸�ʽ��
     * Ҫ���������±�ţ����������ȴ��ҵ�����ͬ�����ٴ�ǰ�����˳��(���ġ��淶��)��
     * ת�����������Ȼ��16x16���������飬����16������к�(�ұ�����0)����16ȡ������к�(�ϱ�����0)��
     */
    
    static const uint8_t cucSquare2FileSq[256] = {
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0, 0x80, 0x70, 0x60, 0x50, 0x40, 0x30, 0x20, 0x10, 0x00, 0, 0, 0, 0,
        0, 0, 0, 0x81, 0x71, 0x61, 0x51, 0x41, 0x31, 0x21, 0x11, 0x01, 0, 0, 0, 0,
        0, 0, 0, 0x82, 0x72, 0x62, 0x52, 0x42, 0x32, 0x22, 0x12, 0x02, 0, 0, 0, 0,
        0, 0, 0, 0x83, 0x73, 0x63, 0x53, 0x43, 0x33, 0x23, 0x13, 0x03, 0, 0, 0, 0,
        0, 0, 0, 0x84, 0x74, 0x64, 0x54, 0x44, 0x34, 0x24, 0x14, 0x04, 0, 0, 0, 0,
        0, 0, 0, 0x85, 0x75, 0x65, 0x55, 0x45, 0x35, 0x25, 0x15, 0x05, 0, 0, 0, 0,
        0, 0, 0, 0x86, 0x76, 0x66, 0x56, 0x46, 0x36, 0x26, 0x16, 0x06, 0, 0, 0, 0,
        0, 0, 0, 0x87, 0x77, 0x67, 0x57, 0x47, 0x37, 0x27, 0x17, 0x07, 0, 0, 0, 0,
        0, 0, 0, 0x88, 0x78, 0x68, 0x58, 0x48, 0x38, 0x28, 0x18, 0x08, 0, 0, 0, 0,
        0, 0, 0, 0x89, 0x79, 0x69, 0x59, 0x49, 0x39, 0x29, 0x19, 0x09, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0,
        0, 0, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0
    };
    
    static const uint8_t cucFileSq2Square[256] = {
        0x3b, 0x4b, 0x5b, 0x6b, 0x7b, 0x8b, 0x9b, 0xab, 0xbb, 0xcb, 0, 0, 0, 0, 0, 0,
        0x3a, 0x4a, 0x5a, 0x6a, 0x7a, 0x8a, 0x9a, 0xaa, 0xba, 0xca, 0, 0, 0, 0, 0, 0,
        0x39, 0x49, 0x59, 0x69, 0x79, 0x89, 0x99, 0xa9, 0xb9, 0xc9, 0, 0, 0, 0, 0, 0,
        0x38, 0x48, 0x58, 0x68, 0x78, 0x88, 0x98, 0xa8, 0xb8, 0xc8, 0, 0, 0, 0, 0, 0,
        0x37, 0x47, 0x57, 0x67, 0x77, 0x87, 0x97, 0xa7, 0xb7, 0xc7, 0, 0, 0, 0, 0, 0,
        0x36, 0x46, 0x56, 0x66, 0x76, 0x86, 0x96, 0xa6, 0xb6, 0xc6, 0, 0, 0, 0, 0, 0,
        0x35, 0x45, 0x55, 0x65, 0x75, 0x85, 0x95, 0xa5, 0xb5, 0xc5, 0, 0, 0, 0, 0, 0,
        0x34, 0x44, 0x54, 0x64, 0x74, 0x84, 0x94, 0xa4, 0xb4, 0xc4, 0, 0, 0, 0, 0, 0,
        0x33, 0x43, 0x53, 0x63, 0x73, 0x83, 0x93, 0xa3, 0xb3, 0xc3, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0,
        0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0, 0, 0, 0, 0, 0
    };
    
    // ���ַ��ŵ�ָ�룬���涨�˼��廹�Ƿ��壬��"ChineseInit()"���и�ֵ
    static const uint16_t (*lpcwDigit2Word)[10], (*lpcwPiece2Word)[8], *lpcwDirect2Word, *lpcwPos2Word;
    static const char **lpcszBoardStr;
    static uint16_t wPromote;
    
    inline uint8_t SQUARE_FILESQ(int32_t sq) {
        return cucSquare2FileSq[sq];
    }
    
    inline uint8_t FILESQ_SQUARE(int32_t sq) {
        return cucFileSq2Square[sq];
    }
    
    inline int32_t FILESQ_RANK_Y(int32_t sq) {
        return sq & 15;
    }
    
    inline int32_t FILESQ_FILE_X(int32_t sq) {
        return sq >> 4;
    }
    
    inline int32_t FILESQ_COORD_XY(int32_t x, int32_t y) {
        return (x << 4) + y;
    }
    
    // ���ĳ�����Ӷ��ڱ����ӽǵ������������꣬���ӱ�Ŵ�0��15
    inline int32_t FILESQ_SIDE_PIECE(const PositionStruct &pos, int32_t nPieceNum) {
        int32_t sq;
        sq = pos.ucsqPieces[SIDE_TAG(pos.sdPlayer) + nPieceNum];
        return (sq == 0 ? -1 : pos.sdPlayer == 0 ? SQUARE_FILESQ(sq) : SQUARE_FILESQ(SQUARE_FLIP(sq)));
    }
    
    // �����������ͻ�����ӵı��
    inline int32_t FIRST_PIECE(int32_t pt, int32_t pc) {
        return pt * 2 - 1 + pc;
    }
    
    /* ���º���ʵ�������֡����ӡ������λ�õı���ͷ��š�����ͺ���֮���ת��
     *
     * ���ַ��ű���ת���Ĵ��룬������"position.cpp"�е�"PIECE_BYTE"�����"FenPiece()"������
     * �Ӻ���ת��Ϊ�������ѵ㣬���۴��ڼ���״̬���Ƿ���״̬��ת��ʱ�ȿ����˼��塢��������壬Ҳ������GBK���BIG5�룬
     * ��˳������αȽϺ��������⣬�������˶�GBK�뷱���ֺ������ֵ�ʶ��
     */
    
    inline int32_t Digit2Byte(int32_t nArg) {
        return nArg + '1';
    }
    
    inline int32_t Byte2Digit(int32_t nArg) {
        return (nArg >= '1' && nArg <= '9' ? nArg - '1' : MAX_DIGIT);
    }
    
    inline int32_t Piece2Byte(int32_t nArg) {
        return PIECE_BYTE(nArg);
    }
    
    inline int32_t Byte2Piece(int32_t nArg) {
        return (nArg >= '1' && nArg <= '7' ? nArg - '1' : nArg >= 'A' && nArg <= 'Z' ? FenPiece(nArg) :
                nArg >= 'a' && nArg <= 'z' ? FenPiece(nArg - 'a' + 'A') : MAX_PIECE);
    }
    
    inline int32_t Byte2Direct(int32_t nArg) {
        return (nArg == '+' ? 0 : nArg == '.' || nArg == '=' ? 1 : nArg == '-' ? 2 : 3);
    }
    
    inline int32_t Byte2Pos(int32_t nArg) {
        return (nArg >= 'a' && nArg <= 'e' ? nArg - 'a' : Byte2Direct(nArg) + DIRECT_TO_POS);
    }
    
    static int32_t Word2Digit(int32_t nArg) {
        int32_t i;
        for (i = 0; i < MAX_DIGIT; i ++) {
            if (nArg == cwDigit2WordSimp[0][i] || nArg == cwDigit2WordSimp[1][i] ||
                nArg == cwDigit2WordTrad[0][i] || nArg == cwDigit2WordTrad[1][i]) {
                break;
            }
        }
        return i;
    }
    
    static int32_t Word2Piece(int32_t nArg) {
        int32_t i;
        if (false) {
        } else if (nArg == 0x9b8e/*��*/ || nArg == 0xa28c/*��*/) {
            return 0;
        } else if (nArg == 0x52f1/*�R*/ || nArg == 0xd882/*��*/ || nArg == 0x58d8/*�X[��]*/) {
            return 3;
        } else if (nArg == 0x87dc/*܇*/ || nArg == 0x8cb3/*��*/ || nArg == 0xcfda/*��[��]*/ || nArg == 0x6582 /*�e*/) {
            return 4;
        } else if (nArg == 0xfcb0/*��*/ || nArg == 0x5da5/*�][��]*/ || nArg == 0x68b3/*�h*/ || nArg == 0xa5af/*��[�h]*/) {
            return 5;
        } else {
            for (i = 0; i < MAX_PIECE; i ++) {
                if (nArg == cwPiece2WordSimp[0][i] || nArg == cwPiece2WordSimp[1][i] ||
                    nArg == cwPiece2WordTrad[0][i] || nArg == cwPiece2WordTrad[1][i]) {
                    break;
                }
            }
            return i;
        }
    }
    
    static int32_t Word2Direct(int32_t nArg) {
        int32_t i;
        if (nArg == 0x4ddf/*�M*/) {
            return 0;
        } else {
            for (i = 0; i < MAX_DIRECT; i ++) {
                if (nArg == cwDirect2WordSimp[i] || nArg == cwDirect2WordTrad[i]) {
                    break;
                }
            }
            return i;
        }
    }
    
    static int32_t Word2Pos(int32_t nArg) {
        int32_t i;
        if (nArg == 0xe1e1/*��*/ || nArg == 0x5aa6/*�Z[��]*/) {
            return 2 + DIRECT_TO_POS;
        } else {
            for (i = 0; i < MAX_POS; i ++) {
                if (nArg == cwPos2WordSimp[i] || nArg == cwPos2WordTrad[i]) {
                    break;
                }
            }
            return i;
        }
    }
    
    // ȷ��ʹ�ü��庺�ֺͷ��庺��
    void ChineseInit(bool bTraditional) {
        if (bTraditional) {
            lpcwDigit2Word = cwDigit2WordTrad;
            lpcwPiece2Word = cwPiece2WordTrad;
            lpcwDirect2Word = cwDirect2WordTrad;
            lpcwPos2Word = cwPos2WordTrad;
            // lpcszBoardStr = cszBoardStrTrad;
            wPromote = 0xdcc5/*��*/;
        } else {
            lpcwDigit2Word = cwDigit2WordSimp;
            lpcwPiece2Word = cwPiece2WordSimp;
            lpcwDirect2Word = cwDirect2WordSimp;
            lpcwPos2Word = cwPos2WordSimp;
            // lpcszBoardStr = cszBoardStrSimp;
            wPromote = 0xe4b1/*��*/;
        }
    }
    
    // ����ĳ���ŷ����������ŷ�״̬������"cchess.h"
    bool TryMove(PositionStruct &pos, int32_t &nStatus, int32_t mv) {
        if (!pos.LegalMove(mv)) {
            nStatus = MOVE_ILLEGAL;
            return false;
        }
        if (!pos.MakeMove(mv)) {
            nStatus = MOVE_INCHECK;
            return false;
        }
        nStatus = 0;
        nStatus += (pos.LastMove().CptDrw > 0 ? MOVE_CAPTURE : 0);
        nStatus += (pos.LastMove().ChkChs > 0 ? MOVE_CHECK : 0);
        nStatus += (pos.IsMate() ? MOVE_MATE : 0);
        nStatus += pos.RepStatus(3) * MOVE_PERPETUAL; // ��ʾ������"position.cpp"�е�"IsRep()"����
        nStatus += (pos.IsDraw() ? MOVE_DRAW : 0);
        return true;
    }
    
    // ���澵��
    
    // ��ڻ���
    void ExchangeSide(PositionStruct &pos) {
        int32_t i, sq;
        uint8_t ucsqList[32];
        for (i = 16; i < 48; i ++) {
            sq = pos.ucsqPieces[i];
            ucsqList[i - 16] = sq;
            if (sq != 0) {
                pos.AddPiece(sq, i, DEL_PIECE);
            }
        }
        for (i = 16; i < 48; i ++) {
            sq = ucsqList[i < 32 ? i : i - 32]; // ���в�ͬ��FlipBoard
            if (sq != 0) {
                pos.AddPiece(SQUARE_FLIP(sq), i);
            }
        }
        pos.ChangeSide(); // ���в�ͬ��FlipBoard
    }
    
    // ��ת����
    void FlipBoard(PositionStruct &pos) {
        int32_t i, sq;
        uint8_t ucsqList[32];
        for (i = 16; i < 48; i ++) {
            sq = pos.ucsqPieces[i];
            ucsqList[i - 16] = sq;
            if (sq != 0) {
                pos.AddPiece(sq, i, DEL_PIECE);
            }
        }
        for (i = 16; i < 48; i ++) {
            sq = ucsqList[i - 16]; // ���в�ͬ��ExchangeSide
            if (sq != 0) {
                pos.AddPiece(SQUARE_FLIP(sq), i);
            }
        }
    }
    
    // �����ı�����(������()��ʾ��������[]��ʾ)
    void BoardText(char *szBoard, const PositionStruct &pos, bool bAnsi) {
        char *lpBoard;
        int32_t i, j, pc;
        
        lpBoard = szBoard;
        if (bAnsi) {
            lpBoard += sprintf(lpBoard, "\33[0m");
        }
        for (i = 0; i < 19; i ++) {
            if (i % 2 == 0) {
                for (j = FILE_LEFT; j <= FILE_RIGHT; j ++) {
                    pc = pos.ucpcSquares[COORD_XY(j, i / 2 + RANK_TOP)];
                    if ((pc & SIDE_TAG(0)) != 0) {
                        lpBoard += sprintf(lpBoard, bAnsi ? "(\33[1;31m%.2s\33[0m)" : "(%.2s)", (const char *) &lpcwPiece2Word[0][PIECE_TYPE(pc)]);
                    } else if ((pc & SIDE_TAG(1)) != 0) {
                        lpBoard += sprintf(lpBoard, bAnsi ? "[\33[1;32m%.2s\33[0m]" : "[%.2s]", (const char *) &lpcwPiece2Word[1][PIECE_TYPE(pc)]);
                    } else {
                        lpBoard += sprintf(lpBoard, "%.4s", lpcszBoardStr[i] + (j - FILE_LEFT) * 4);
                    }
                }
                lpBoard += sprintf(lpBoard, "\r\n");
            } else {
                lpBoard += sprintf(lpBoard, "%s\r\n", lpcszBoardStr[i]);
            }
        }
    }
    
    // ��FEN��������(ֻҪʶ���зָ���"/"�������ַ���˳��ߵ�����)
    void FenMirror(char *szFenDst, const char *szFenSrc) {
        int32_t i, j;
        const char *lpSrc;
        char *lpDst, *lpDstLimit;
        char szTempStr[128];
        
        lpSrc = szFenSrc;
        lpDst = szFenDst;
        lpDstLimit = lpDst + 127;
        if (*lpSrc == '\0') {
            *lpDst = '\0';
            return;
        }
        while (*lpSrc == ' ') {
            lpSrc ++;
            if (*lpSrc == '\0') {
                *lpDst = '\0';
                return;
            }
        }
        i = 0;
        while(lpDst < lpDstLimit && i < 127) {
            if (*lpSrc == '/' || *lpSrc == ' ' || *lpSrc == '\0') {
                for (j = 0; j < i; j ++) {
                    *lpDst = szTempStr[i - j - 1];
                    lpDst ++;
                    if (lpDst == lpDstLimit) {
                        break;
                    }
                }
                i = 0;
                if (*lpSrc == '/') {
                    *lpDst = '/';
                    lpDst ++;
                } else {
                    break;
                }
            } else {
                szTempStr[i] = *lpSrc;
                i ++;
            }
            lpSrc ++;
        };
        /* TODO while(lpSrc != '\0' && lpDst < lpDstLimit) {
         *lpDst = *lpSrc;
         lpSrc ++;
         lpDst ++;
         }*/
        while(lpSrc != nullptr && lpDst < lpDstLimit) {
            *lpDst = *lpSrc;
            lpSrc ++;
            lpDst ++;
        }
        *lpDst = '\0';
        return;
    }
    
    union C4dwStruct {
        char c[4];
        uint32_t dw;
    };
    
    /* ����"FileMirror()"���ŷ������߱�ʾ������
     *
     * ���ߵķ��ű�ʾ���������ں��ֱ�ʾ�������������ơ�ǰ���˶��������ı�ʾʱ�����ű�ʾ�ͻ��в�ͬ�������
     * ���ա��淶���Ľ��飬��ʾ��"C+-2"�����ױ�ʶ�𣬵���Ҳ�б�ʾ��"+C-2"�ģ������źͺ�����ȫ��Ӧ����˱�����Ҳ�ῼ��������ʽ��
     * ��һ���ŷ����ԣ����߱�ʾ�ľ�����Ψһ�ģ����Ƕ��ڡ��������������ж����(��)���ĺ��������
     * ������ֻ�ܿ����������һ�������������������ϸ���������(��)��������"Paxx"��"Pbxx"�ֱ��"Pcxx"��"Pdxx"����
     * ����������������޷�������ȷת����
     * ע�⣺���ű�ʾ��4���ֽڹ��ɣ����Կ�����һ��"uint32_t"���������ٴ���(ͬ�����ֱ�ʾ��"uint64_t")��
     */
    uint32_t FileMirror(uint32_t dwFileStr) {
        int32_t nPos, nFile, pt;
        C4dwStruct Ret;
        Ret.dw = dwFileStr;
        
        nPos = Byte2Direct(Ret.c[0]);
        if (nPos == MAX_DIRECT) {
            pt = Byte2Piece(Ret.c[0]);
            nFile = Byte2Digit(Ret.c[1]);
            if (nFile == MAX_DIGIT) {
                switch (Ret.c[1]) {
                    case 'a':
                        Ret.c[1] = 'c';
                        break;
                    case 'b':
                        Ret.c[1] = 'd';
                        break;
                    case 'c':
                        Ret.c[1] = 'a';
                        break;
                    case 'd':
                        Ret.c[1] = 'b';
                        break;
                    default:
                        break;
                }
            } else {
                Ret.c[1] = Digit2Byte(8 - nFile);
            }
        } else {
            pt = Byte2Piece(Ret.c[1]);
        }
        if ((pt >= ADVISOR_TYPE && pt <= KNIGHT_TYPE) || Byte2Direct(Ret.c[2]) == 1) {
            Ret.c[3] = Digit2Byte(8 - Byte2Digit(Ret.c[3]));
        }
        return Ret.dw;
    }
    
    // �����ֱ�ʾת��Ϊ���ű�ʾ
    uint32_t Chin2File(uint64_t qwChinStr) {
        int32_t nPos;
        uint16_t *lpwArg;
        C4dwStruct Ret;
        
        lpwArg = (uint16_t *) (void *) &qwChinStr;
        nPos = Word2Pos(lpwArg[0]);
        Ret.c[0] = PIECE_BYTE(Word2Piece(nPos == MAX_POS ? lpwArg[0] : lpwArg[1]));
        Ret.c[1] = (nPos == MAX_POS ? Digit2Byte(Word2Digit(lpwArg[1])) : ccPos2Byte[nPos]);
        if ((lpwArg[2] == 0xe4b1/*��*/ || lpwArg[2] == 0xdcc5/*��*/ || lpwArg[2] == 0x83d7/*׃*/) && Word2Piece(lpwArg[3]) == 6) {
            Ret.c[2] = '=';
            Ret.c[3] = 'P';
        } else {
            Ret.c[2] = ccDirect2Byte[Word2Direct(lpwArg[2])];
            Ret.c[3] = Digit2Byte(Word2Digit(lpwArg[3]));
        }
        return Ret.dw;
    }
    
    // �����ű�ʾת��Ϊ���ֱ�ʾ
    uint64_t File2Chin(uint32_t dwFileStr, int32_t sdPlayer) {
        int32_t nPos;
        char *lpArg;
        union {
            uint16_t w[4];
            uint64_t qw;
        } Ret;
        
        lpArg = (char *) &dwFileStr;
        nPos = Byte2Direct(lpArg[0]);
        if (nPos == MAX_DIRECT) {
            nPos = Byte2Pos(lpArg[1]);
            Ret.w[0] = (nPos == MAX_POS ? lpcwPiece2Word[sdPlayer][Byte2Piece(lpArg[0])] : lpcwPos2Word[nPos]);
            Ret.w[1] = (nPos == MAX_POS ? lpcwDigit2Word[sdPlayer][Byte2Digit(lpArg[1])] : lpcwPiece2Word[sdPlayer][Byte2Piece(lpArg[0])]);
        } else {
            Ret.w[0] = lpcwPos2Word[nPos + DIRECT_TO_POS];
            Ret.w[1] = lpcwPiece2Word[sdPlayer][Byte2Piece(lpArg[1])];
        }
        if (lpArg[2] == '=' && Byte2Piece(lpArg[3]) == 6) {
            Ret.w[2] = wPromote;
            Ret.w[3] = lpcwPiece2Word[sdPlayer][6];
        } else {
            Ret.w[2] = lpcwDirect2Word[Byte2Direct(lpArg[2])];
            Ret.w[3] = lpcwDigit2Word[sdPlayer][Byte2Digit(lpArg[3])];
        }
        return Ret.qw;
    }
    
    /* "File2Move()"���������߷��ű�ʾת��Ϊ�ڲ��ŷ���ʾ��
     *
     * ��������Լ������"Move2File()"�����Ǳ�ģ�����Ѵ���������������ر����ڴ����������������ж����(��)���������ϡ�
     * �����׵Ŀ���ʱ������ֻʹ�����ּ��̣����1��7���δ���˧(��)����(��)���������ӣ�"File2Move()"����Ҳ���ǵ���������⡣
     */
    int32_t File2Move(uint32_t dwFileStr, const PositionStruct &pos) {
        int32_t i, j, nPos, pt, sq, nPieceNum;
        int32_t xSrc, ySrc, xDst, yDst;
        C4dwStruct FileStr;
        int32_t nFileList[9], nPieceList[5];
        // ���߷��ű�ʾת��Ϊ�ڲ��ŷ���ʾ��ͨ����Ϊ���¼������裺
        
        // 1. ������߷����Ƿ�����(ʿ)��(��)��28�̶ֹ����߱�ʾ������֮ǰ���ȱ�������֡�Сд�Ȳ�ͳһ�ĸ�ʽת��Ϊͳһ��ʽ��
        FileStr.dw = dwFileStr;
        switch (FileStr.c[0]) {
            case '2':
            case 'a':
                FileStr.c[0] = 'A';
                break;
            case '3':
            case 'b':
            case 'E':
            case 'e':
                FileStr.c[0] = 'B';
                break;
            default:
                break;
        }
        if (FileStr.c[3] == 'p') {
            FileStr.c[3] = 'P';
        }
        for (i = 0; i < MAX_FIX_FILE; i ++) {
            if (FileStr.dw == cdwFixFile[i]) {
                if (pos.sdPlayer == 0) {
                    return MOVE(cucFixMove[i][0], cucFixMove[i][1]);
                } else {
                    return MOVE(SQUARE_FLIP(cucFixMove[i][0]), SQUARE_FLIP(cucFixMove[i][1]));
                }
            }
        }
        
        // 2. ���������28�̶ֹ����߱�ʾ����ô�����ӡ�λ�ú��������(�к�)��������
        nPos = Byte2Direct(FileStr.c[0]);
        if (nPos == MAX_DIRECT) {
            pt = Byte2Piece(FileStr.c[0]);
            nPos = Byte2Pos(FileStr.c[1]);
        } else {
            pt = Byte2Piece(FileStr.c[1]);
            nPos += DIRECT_TO_POS;
        }
        if (nPos == MAX_POS) {
            
            // 3. ������������кű�ʾ�ģ���ô����ֱ�Ӹ����������ҵ�������ţ�
            xSrc = Byte2Digit(FileStr.c[1]);
            if (pt == KING_TYPE) {
                sq = FILESQ_SIDE_PIECE(pos, 0);
            } else if (pt >= KNIGHT_TYPE && pt <= PAWN_TYPE) {
                j = (pt == PAWN_TYPE ? 5 : 2);
                for (i = 0; i < j; i ++) {
                    sq = FILESQ_SIDE_PIECE(pos, FIRST_PIECE(pt, i));
                    if (sq != -1) {
                        if (FILESQ_FILE_X(sq) == xSrc) {
                            break;
                        }
                    }
                }
                sq = (i == j ? -1 : sq);
            } else {
                sq = -1;
            }
        } else {
            
            // 4. �����������λ�ñ�ʾ�ģ���ô������ѡ�����ж���������ӵ��������ߣ����Ǳ��������Ѵ���ĵط���
            if (pt >= KNIGHT_TYPE && pt <= PAWN_TYPE) {
                for (i = 0; i < 9; i ++) {
                    nFileList[i] = 0;
                }
                j = (pt == PAWN_TYPE ? 5 : 2);
                for (i = 0; i < j; i ++) {
                    sq = FILESQ_SIDE_PIECE(pos, FIRST_PIECE(pt, i));
                    if (sq != -1) {
                        nFileList[FILESQ_FILE_X(sq)] ++;
                    }
                }
                nPieceNum = 0;
                for (i = 0; i < j; i ++) {
                    sq = FILESQ_SIDE_PIECE(pos, FIRST_PIECE(pt, i));
                    if (sq != -1) {
                        if (nFileList[FILESQ_FILE_X(sq)] > 1) {
                            nPieceList[nPieceNum] = FIRST_PIECE(pt, i);
                            nPieceNum ++;
                        }
                    }
                }
                
                // 5. �ҵ���Щ�����Ժ󣬶���Щ�����ϵ����ӽ�������Ȼ�����λ����ȷ��������ţ�
                for (i = 0; i < nPieceNum - 1; i ++) {
                    for (j = nPieceNum - 1; j > i; j --) {
                        if (FILESQ_SIDE_PIECE(pos, nPieceList[j - 1]) > FILESQ_SIDE_PIECE(pos, nPieceList[j])) {
                            SWAP(nPieceList[j - 1], nPieceList[j]);
                        }
                    }
                }
                // ��ʾ�����ֻ���������ӣ���ô���󡱱�ʾ�ڶ������ӣ�����ж�����ӣ�
                // ��ô��һ�������塱���δ����һ������������ӣ���ǰ�к����δ����һ�������������ӡ�
                if (nPieceNum == 2 && nPos == 2 + DIRECT_TO_POS) {
                    sq = FILESQ_SIDE_PIECE(pos, nPieceList[1]);
                } else {
                    nPos -= (nPos >= DIRECT_TO_POS ? DIRECT_TO_POS : 0);
                    sq = (nPos >= nPieceNum ? -1 : FILESQ_SIDE_PIECE(pos, nPieceList[nPos]));
                }
            } else {
                sq = -1;
            }
        }
        if (sq == -1) {
            return 0;
        }
        
        // 6. ������֪���ŷ�����㣬�Ϳ��Ը������߱�ʾ�ĺ�����������ȷ���ŷ����յ㣻
        xSrc = FILESQ_FILE_X(sq);
        ySrc = FILESQ_RANK_Y(sq);
        if (pt == KNIGHT_TYPE) {
            // ��ʾ����Ľ��˴���Ƚ����⡣
            xDst = Byte2Digit(FileStr.c[3]);
            if (FileStr.c[2] == '+') {
                yDst = ySrc - 3 + ABS(xDst - xSrc);
            } else {
                yDst = ySrc + 3 - ABS(xDst - xSrc);
            }
        } else {
            if (FileStr.c[2] == '+') {
                xDst = xSrc;
                yDst = ySrc - Byte2Digit(FileStr.c[3]) - 1;
            } else if (FileStr.c[2] == '-') {
                xDst = xSrc;
                yDst = ySrc + Byte2Digit(FileStr.c[3]) + 1;
            } else {
                xDst = Byte2Digit(FileStr.c[3]);
                yDst = ySrc;
            }
        }
        // ע�⣺yDst�п��ܳ�����Χ��
        if (yDst < 0 || yDst > 9) {
            return 0;
        }
        
        // 7. ��������ӷ�������ת��Ϊ�̶����꣬�õ��ŷ��������յ㡣
        if (pos.sdPlayer == 0) {
            return MOVE(FILESQ_SQUARE(FILESQ_COORD_XY(xSrc, ySrc)), FILESQ_SQUARE(FILESQ_COORD_XY(xDst, yDst)));
        } else {
            return MOVE(SQUARE_FLIP(FILESQ_SQUARE(FILESQ_COORD_XY(xSrc, ySrc))), SQUARE_FLIP(FILESQ_SQUARE(FILESQ_COORD_XY(xDst, yDst))));
        }
    }
    
    // ���ڲ��ŷ���ʾת��Ϊ���߷���
    uint32_t Move2File(int32_t mv, const PositionStruct &pos) {
        int32_t i, j, sq, pc, pt, nPieceNum;
        int32_t xSrc, ySrc, xDst, yDst;
        int32_t nFileList[9], nPieceList[5];
        C4dwStruct Ret;
        
        if (SRC(mv) == 0 || DST(mv) == 0) {
            return 0x20202020;
        }
        pc = pos.ucpcSquares[SRC(mv)];
        if (pc == 0) {
            return 0x20202020;
        }
        pt = PIECE_TYPE(pc);
        Ret.c[0] = PIECE_BYTE(pt);
        if (pos.sdPlayer == 0) {
            xSrc = FILESQ_FILE_X(SQUARE_FILESQ(SRC(mv)));
            ySrc = FILESQ_RANK_Y(SQUARE_FILESQ(SRC(mv)));
            xDst = FILESQ_FILE_X(SQUARE_FILESQ(DST(mv)));
            yDst = FILESQ_RANK_Y(SQUARE_FILESQ(DST(mv)));
        } else {
            xSrc = FILESQ_FILE_X(SQUARE_FILESQ(SQUARE_FLIP(SRC(mv))));
            ySrc = FILESQ_RANK_Y(SQUARE_FILESQ(SQUARE_FLIP(SRC(mv))));
            xDst = FILESQ_FILE_X(SQUARE_FILESQ(SQUARE_FLIP(DST(mv))));
            yDst = FILESQ_RANK_Y(SQUARE_FILESQ(SQUARE_FLIP(DST(mv))));
        }
        if (pt >= KING_TYPE && pt <= BISHOP_TYPE) {
            Ret.c[1] = Digit2Byte(xSrc);
        } else {
            for (i = 0; i < 9; i ++) {
                nFileList[i] = 0;
            }
            j = (pt == PAWN_TYPE ? 5 : 2);
            for (i = 0; i < j; i ++) {
                sq = FILESQ_SIDE_PIECE(pos, FIRST_PIECE(pt, i));
                if (sq != -1) {
                    nFileList[FILESQ_FILE_X(sq)] ++;
                }
            }
            // ��ʾ�������������������ж����(��)���������ϣ��ɲ���"File2Move()"������
            if (nFileList[xSrc] > 1) {
                nPieceNum = 0;
                for (i = 0; i < j; i ++) {
                    sq = FILESQ_SIDE_PIECE(pos, FIRST_PIECE(pt, i));
                    if (sq != -1) {
                        if (nFileList[FILESQ_FILE_X(sq)] > 1) {
                            nPieceList[nPieceNum] = FIRST_PIECE(pt, i);
                            nPieceNum ++;
                        }
                    }
                }
                for (i = 0; i < nPieceNum - 1; i ++) {
                    for (j = nPieceNum - 1; j > i; j --) {
                        if (FILESQ_SIDE_PIECE(pos, nPieceList[j - 1]) > FILESQ_SIDE_PIECE(pos, nPieceList[j])) {
                            SWAP(nPieceList[j - 1], nPieceList[j]);
                        }
                    }
                }
                sq = FILESQ_COORD_XY(xSrc, ySrc);
                for (i = 0; i < nPieceNum; i ++) {
                    if (FILESQ_SIDE_PIECE(pos, nPieceList[i]) == sq) {
                        break;
                    }
                }
                Ret.c[1] = (nPieceNum == 2 && i == 1 ? ccPos2Byte[2 + DIRECT_TO_POS] : ccPos2Byte[nPieceNum > 3 ? i : i + DIRECT_TO_POS]);
            } else {
                Ret.c[1] = Digit2Byte(xSrc);
            }
        }
        if (pt >= ADVISOR_TYPE && pt <= KNIGHT_TYPE) {
            if (SRC(mv) == DST(mv)) {
                Ret.c[2] = '=';
                Ret.c[3] = 'P';
            } else {
                Ret.c[2] = (yDst > ySrc ? '-' : '+');
                Ret.c[3] = Digit2Byte(xDst);
            }
        } else {
            Ret.c[2] = (yDst == ySrc ? '.' : yDst > ySrc ? '-' : '+');
            Ret.c[3] = (yDst == ySrc ? Digit2Byte(xDst) : Digit2Byte(ABS(ySrc - yDst) - 1));
        }
        return Ret.dw;
    }
}
