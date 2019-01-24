/*
movesort.h/movesort.cpp - Source Code for ElephantEye, Part VII

ElephantEye - a Chinese Chess Program (UCCI Engine)
Designed by Morning Yellow, Version: 3.11, Last Modified: Dec. 2007
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
#include "xiangqi_position.hpp"
#include "xiangqi_movesort.hpp"

#include "../../Platform.h"
#include "../xiangqi_jni.hpp"

namespace Xiangqi
{
    int32_t nHistory[65536]; // ��ʷ��
    
    // ������ʷ����ŷ��б�ֵ
    void MoveSortStruct::SetHistory(void) {
        int32_t i, j, vl, nShift, nNewShift;
        nShift = 0;
        for (i = nMoveIndex; i < nMoveNum; i ++) {
            // ����ŷ��ķ�ֵ����65536���ͱ���������ŷ��ķ�ֵ��������ʹ���Ƕ�������65536
            vl = nHistory[mvs[i].wmv] >> nShift;
            if (vl > 65535) {
                nNewShift = Bsr(vl) - 15;
                for (j = nMoveIndex; j < i; j ++) {
                    mvs[j].wvl >>= nNewShift;
                }
                vl >>= nNewShift;
                // __ASSERT_BOUND(32768, vl, 65535);
                if(!__IF_BOUND(32768, vl, 65535)){
                    printf("error, ASSERT_BOUND(32768, vl, 65535)\n");
                }
                nShift += nNewShift;
            }
            mvs[i].wvl = vl;
        }
    }
    
    // Shell���򷨣�������"1, 4, 13, 40 ..."�����У�����Ҫ��"1, 2, 4, 8, ..."��
    static const int32_t cnShellStep[8] = {0, 1, 4, 13, 40, 121, 364, 1093};
    
    void MoveSortStruct::ShellSort(void) {
        int32_t i, j, nStep, nStepLevel;
        MoveStruct mvsBest;
        nStepLevel = 1;
        while (cnShellStep[nStepLevel] < nMoveNum - nMoveIndex) {
            nStepLevel ++;
        }
        nStepLevel --;
        while (nStepLevel > 0) {
            nStep = cnShellStep[nStepLevel];
            for (i = nMoveIndex + nStep; i < nMoveNum; i ++) {
                mvsBest = mvs[i];
                j = i - nStep;
                while (j >= nMoveIndex && mvsBest.wvl > mvs[j].wvl) {
                    mvs[j + nStep] = mvs[j];
                    j -= nStep;
                }
                mvs[j + nStep] = mvsBest;
            }
            nStepLevel --;
        }
    }
    
    /* ���ɽ⽫�ŷ�������ΨһӦ���ŷ�(�ж��Ӧ���ŷ��򷵻���)
     *
     * �⽫�ŷ���˳�����£�
     * 1. �û����ŷ�(SORT_VALUE_MAX)��
     * 2. ����ɱ���ŷ�(SORT_VALUE_MAX - 1��2)��
     * 3. �����ŷ�������ʷ������(��1��SORT_VALUE_MAX - 3)��
     * 4. ���ܽ⽫���ŷ�(0)����Щ�ŷ�����˵���
     */
    int32_t MoveSortStruct::InitEvade(PositionStruct &pos, int32_t mv, const uint16_t *lpwmvKiller) {
        int32_t i, nLegal;
        nPhase = PHASE_REST;
        nMoveIndex = 0;
        nMoveNum = pos.GenAllMoves(mvs);
        SetHistory();
        nLegal = 0;
        for (i = nMoveIndex; i < nMoveNum; i ++) {
            if (mvs[i].wmv == mv) {
                nLegal ++;
                mvs[i].wvl = SORT_VALUE_MAX;
            } else if (pos.MakeMove(mvs[i].wmv)) {
                pos.UndoMakeMove();
                nLegal ++;
                if (mvs[i].wmv == lpwmvKiller[0]) {
                    mvs[i].wvl = SORT_VALUE_MAX - 1;
                } else if (mvs[i].wmv == lpwmvKiller[1]) {
                    mvs[i].wvl = SORT_VALUE_MAX - 2;
                } else {
                    mvs[i].wvl = MIN(mvs[i].wvl + 1, SORT_VALUE_MAX - 3);
                }
            } else {
                mvs[i].wvl = 0;
            }
        }
        ShellSort();
        nMoveNum = nMoveIndex + nLegal;
        return (nLegal == 1 ? mvs[0].wmv : 0);
    }
    
    // ������һ�������������ŷ�
    int32_t MoveSortStruct::NextFull(PositionStruct &pos) {
        switch (nPhase) {
                // "nPhase"��ʾ�ŷ����������ɽ׶Σ�����Ϊ��
                
                // 0. �û����ŷ���������ɺ�����������һ�׶Σ�
            case PHASE_HASH:
                nPhase = PHASE_GEN_CAP;
                if (mvHash != 0) {
                    // __ASSERT(pos.LegalMove(mvHash));
                    if(!(pos.LegalMove(mvHash))){
                        printf("error, ASSERT(pos.LegalMove(mvHash))\n");
                    }
                    return mvHash;
                }
                // ���ɣ�����û��"break"����ʾ"switch"����һ��"case"ִ��������������һ��"case"����ͬ
                
                // 1. �������г����ŷ�����ɺ�����������һ�׶Σ�
            case PHASE_GEN_CAP:
                nPhase = PHASE_GOODCAP;
                nMoveIndex = 0;
                nMoveNum = pos.GenCapMoves(mvs);
                ShellSort();
                
                // 2. MVV(LVA)����������Ҫѭ�����ɴΣ�
            case PHASE_GOODCAP:
                if (nMoveIndex < nMoveNum && mvs[nMoveIndex].wvl > 1) {
                    // ע�⣺MVV(LVA)ֵ������1����˵�����Ӳ���ֱ���ܻ�����Ƶģ���Щ�ŷ��������Ժ�����
                    nMoveIndex ++;
                    // __ASSERT_PIECE(pos.ucpcSquares[DST(mvs[nMoveIndex - 1].wmv)]);
                    if(!IF_PIECE(pos.ucpcSquares[DST(mvs[nMoveIndex - 1].wmv)])){
                        printf("error, ASSERT_PIECE(pos.ucpcSquares[DST(mvs[nMoveIndex - 1].wmv)])\n");
                    }
                    return mvs[nMoveIndex - 1].wmv;
                }
                
                // 3. ɱ���ŷ�����(��һ��ɱ���ŷ�)����ɺ�����������һ�׶Σ�
            case PHASE_KILLER1:
                nPhase = PHASE_KILLER2;
                if (mvKiller1 != 0 && pos.LegalMove(mvKiller1)) {
                    // ע�⣺ɱ���ŷ���������ŷ������ԣ���ͬ
                    return mvKiller1;
                }
                
                // 4. ɱ���ŷ�����(�ڶ���ɱ���ŷ�)����ɺ�����������һ�׶Σ�
            case PHASE_KILLER2:
                nPhase = PHASE_GEN_NONCAP;
                if (mvKiller2 != 0 && pos.LegalMove(mvKiller2)) {
                    return mvKiller2;
                }
                
                // 5. �������в������ŷ�����ɺ�����������һ�׶Σ�
            case PHASE_GEN_NONCAP:
                nPhase = PHASE_REST;
                nMoveNum += pos.GenNonCapMoves(mvs + nMoveNum);
                SetHistory();
                ShellSort();
                
                // 6. ��ʣ���ŷ�����ʷ������(�������ؽ⽫�ŷ�)��
            case PHASE_REST:
                if (nMoveIndex < nMoveNum) {
                    nMoveIndex ++;
                    return mvs[nMoveIndex - 1].wmv;
                }
                
                // 7. û���ŷ��ˣ������㡣
            default:
                return 0;
        }
    }
    
    // ���ɸ������ŷ�
    void MoveSortStruct::InitRoot(PositionStruct &pos, int32_t nBanMoves, const uint16_t *lpwmvBanList) {
        int32_t i, j, nBanned;
        nMoveIndex = 0;
        nMoveNum = pos.GenAllMoves(mvs);
        nBanned = 0;
        for (i = 0; i < nMoveNum; i ++) {
            mvs[i].wvl = 1;
            for (j = 0; j < nBanMoves; j ++) {
                if (mvs[i].wmv == lpwmvBanList[j]) {
                    // print ban move
                    /*{
                        uint32_t dwmv = MOVE_COORD(mvs[i].wmv);
                        printMove(dwmv);
                    }*/
                    mvs[i].wvl = 0;
                    nBanned ++;
                    break;
                }
            }
        }
        ShellSort();
        nMoveNum -= nBanned;
    }
    
    // ���¸������ŷ������б�
    void MoveSortStruct::UpdateRoot(int32_t mv) {
        int32_t i;
        for (i = 0; i < nMoveNum; i ++) {
            if (mvs[i].wmv == mv) {
                mvs[i].wvl = SORT_VALUE_MAX;
            } else if (mvs[i].wvl > 0) {
                mvs[i].wvl --;
            }
        }
    }
}
