/*
preeval.h/preeval.cpp - Source Code for ElephantEye, Part X

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

#include "../base/xiangqi_base.hpp"
#include "xiangqi_pregen.hpp"
#include "xiangqi_position.hpp"
#include "xiangqi_preeval.hpp"

namespace Xiangqi
{
#if _WIN32
    
#include <windows.h>
    extern "C" __declspec(dllexport) void WINAPI PreEvaluate(PositionStruct *lppos, PreEvalStruct *lpPreEval);
    
#else
    
#define WINAPI
    extern "C" void WINAPI PreEvaluate(PositionStruct *lppos, PreEvalStruct *lpPreEval);
    
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
    
    /* ����λ�ü�ֵ��
     * ElephantEye������λ�ü�ֵ��Ծ������۵ĵ������˺ܴ�����ã��ڲ��ա������񵰡�����Ļ����ϣ��������¸Ķ���
     * 1. �����������ֺ�λ����ط������һ�������ڿ������㣻
     * 2. һ��·�ı�(��)��Ѳ��λ�÷�ֵ������5�֣��Լ���äĿ���߱�(��)�������
     * 3. ���ӱ�(��)(���߳���)���10�֣��Լ��ٹ��ӱ�(��)äĿ����(ʿ)��(��)�������
     * 4. һ��·���ںᳵ��λ�÷�ֵ������5�֣��Լ�������(ʿ)ʱ����������ĺᳵ�������
     */
    
    // 1. ���о֡��н��������˧(��)�ͱ�(��)�����ա������񵰡�
    static const uint8_t cucvlKingPawnMidgameAttacking[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  9,  9,  9, 11, 13, 11,  9,  9,  9,  0,  0,  0,  0,
        0,  0,  0, 39, 49, 69, 84, 89, 84, 69, 49, 39,  0,  0,  0,  0,
        0,  0,  0, 39, 49, 64, 74, 74, 74, 64, 49, 39,  0,  0,  0,  0,
        0,  0,  0, 39, 46, 54, 59, 61, 59, 54, 46, 39,  0,  0,  0,  0,
        0,  0,  0, 29, 37, 41, 54, 59, 54, 41, 37, 29,  0,  0,  0,  0,
        0,  0,  0,  7,  0, 13,  0, 16,  0, 13,  0,  7,  0,  0,  0,  0,
        0,  0,  0,  7,  0,  7,  0, 15,  0,  7,  0,  7,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0, 11, 15, 11,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 2. ���о֡�û�н��������˧(��)�ͱ�(��)
    static const uint8_t cucvlKingPawnMidgameAttackless[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  9,  9,  9, 11, 13, 11,  9,  9,  9,  0,  0,  0,  0,
        0,  0,  0, 19, 24, 34, 42, 44, 42, 34, 24, 19,  0,  0,  0,  0,
        0,  0,  0, 19, 24, 32, 37, 37, 37, 32, 24, 19,  0,  0,  0,  0,
        0,  0,  0, 19, 23, 27, 29, 30, 29, 27, 23, 19,  0,  0,  0,  0,
        0,  0,  0, 14, 18, 20, 27, 29, 27, 20, 18, 14,  0,  0,  0,  0,
        0,  0,  0,  7,  0, 13,  0, 16,  0, 13,  0,  7,  0,  0,  0,  0,
        0,  0,  0,  7,  0,  7,  0, 15,  0,  7,  0,  7,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  2,  2,  2,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0, 11, 15, 11,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 3. �о֡��н��������˧(��)�ͱ�(��)
    static const uint8_t cucvlKingPawnEndgameAttacking[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 10, 10, 10, 15, 15, 15, 10, 10, 10,  0,  0,  0,  0,
        0,  0,  0, 50, 55, 60, 85,100, 85, 60, 55, 50,  0,  0,  0,  0,
        0,  0,  0, 65, 70, 70, 75, 75, 75, 70, 70, 65,  0,  0,  0,  0,
        0,  0,  0, 75, 80, 80, 80, 80, 80, 80, 80, 75,  0,  0,  0,  0,
        0,  0,  0, 70, 70, 65, 70, 70, 70, 65, 70, 70,  0,  0,  0,  0,
        0,  0,  0, 45,  0, 40, 45, 45, 45, 40,  0, 45,  0,  0,  0,  0,
        0,  0,  0, 40,  0, 35, 40, 40, 40, 35,  0, 40,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  5,  5, 15,  5,  5,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  3,  3, 13,  3,  3,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  1,  1, 11,  1,  1,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 4. �о֡�û�н��������˧(��)�ͱ�(��)
    static const uint8_t cucvlKingPawnEndgameAttackless[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 10, 10, 10, 15, 15, 15, 10, 10, 10,  0,  0,  0,  0,
        0,  0,  0, 10, 15, 20, 45, 60, 45, 20, 15, 10,  0,  0,  0,  0,
        0,  0,  0, 25, 30, 30, 35, 35, 35, 30, 30, 25,  0,  0,  0,  0,
        0,  0,  0, 35, 40, 40, 45, 45, 45, 40, 40, 35,  0,  0,  0,  0,
        0,  0,  0, 25, 30, 30, 35, 35, 35, 30, 30, 25,  0,  0,  0,  0,
        0,  0,  0, 25,  0, 25, 25, 25, 25, 25,  0, 25,  0,  0,  0,  0,
        0,  0,  0, 20,  0, 20, 20, 20, 20, 20,  0, 20,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  5,  5, 13,  5,  5,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  3,  3, 12,  3,  3,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  1,  1, 11,  1,  1,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 5. û����в����(ʿ)����(��)
    static const uint8_t cucvlAdvisorBishopThreatless[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 20,  0,  0,  0, 20,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 18,  0,  0, 20, 23, 20,  0,  0, 18,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 23,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 20, 20,  0, 20, 20,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 5'. ������ģ�û����в����(ʿ)����(��)
    static const uint8_t cucvlAdvisorBishopPromotionThreatless[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 30,  0,  0,  0, 30,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 28,  0,  0, 30, 33, 30,  0,  0, 28,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 30, 30,  0, 30, 30,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 6. �ܵ���в����(ʿ)����(��)�����ա������񵰡�
    static const uint8_t cucvlAdvisorBishopThreatened[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 40,  0,  0,  0, 40,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 38,  0,  0, 40, 43, 40,  0,  0, 38,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0, 43,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0, 40, 40,  0, 40, 40,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 7. ���оֵ������ա������񵰡�
    static const uint8_t cucvlKnightMidgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 90, 90, 90, 96, 90, 96, 90, 90, 90,  0,  0,  0,  0,
        0,  0,  0, 90, 96,103, 97, 94, 97,103, 96, 90,  0,  0,  0,  0,
        0,  0,  0, 92, 98, 99,103, 99,103, 99, 98, 92,  0,  0,  0,  0,
        0,  0,  0, 93,108,100,107,100,107,100,108, 93,  0,  0,  0,  0,
        0,  0,  0, 90,100, 99,103,104,103, 99,100, 90,  0,  0,  0,  0,
        0,  0,  0, 90, 98,101,102,103,102,101, 98, 90,  0,  0,  0,  0,
        0,  0,  0, 92, 94, 98, 95, 98, 95, 98, 94, 92,  0,  0,  0,  0,
        0,  0,  0, 93, 92, 94, 95, 92, 95, 94, 92, 93,  0,  0,  0,  0,
        0,  0,  0, 85, 90, 92, 93, 78, 93, 92, 90, 85,  0,  0,  0,  0,
        0,  0,  0, 88, 85, 90, 88, 90, 88, 90, 85, 88,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 8. �оֵ���
    static const uint8_t cucvlKnightEndgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0, 92, 94, 96, 96, 96, 96, 96, 94, 92,  0,  0,  0,  0,
        0,  0,  0, 94, 96, 98, 98, 98, 98, 98, 96, 94,  0,  0,  0,  0,
        0,  0,  0, 96, 98,100,100,100,100,100, 98, 96,  0,  0,  0,  0,
        0,  0,  0, 96, 98,100,100,100,100,100, 98, 96,  0,  0,  0,  0,
        0,  0,  0, 96, 98,100,100,100,100,100, 98, 96,  0,  0,  0,  0,
        0,  0,  0, 94, 96, 98, 98, 98, 98, 98, 96, 94,  0,  0,  0,  0,
        0,  0,  0, 94, 96, 98, 98, 98, 98, 98, 96, 94,  0,  0,  0,  0,
        0,  0,  0, 92, 94, 96, 96, 96, 96, 96, 94, 92,  0,  0,  0,  0,
        0,  0,  0, 90, 92, 94, 92, 92, 92, 94, 92, 90,  0,  0,  0,  0,
        0,  0,  0, 88, 90, 92, 90, 90, 90, 92, 90, 88,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 9. ���оֵĳ������ա������񵰡�
    static const uint8_t cucvlRookMidgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,206,208,207,213,214,213,207,208,206,  0,  0,  0,  0,
        0,  0,  0,206,212,209,216,233,216,209,212,206,  0,  0,  0,  0,
        0,  0,  0,206,208,207,214,216,214,207,208,206,  0,  0,  0,  0,
        0,  0,  0,206,213,213,216,216,216,213,213,206,  0,  0,  0,  0,
        0,  0,  0,208,211,211,214,215,214,211,211,208,  0,  0,  0,  0,
        0,  0,  0,208,212,212,214,215,214,212,212,208,  0,  0,  0,  0,
        0,  0,  0,204,209,204,212,214,212,204,209,204,  0,  0,  0,  0,
        0,  0,  0,198,208,204,212,212,212,204,208,198,  0,  0,  0,  0,
        0,  0,  0,200,208,206,212,200,212,206,208,200,  0,  0,  0,  0,
        0,  0,  0,194,206,204,212,200,212,204,206,194,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 10. �оֵĳ�
    static const uint8_t cucvlRookEndgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,182,182,182,184,186,184,182,182,182,  0,  0,  0,  0,
        0,  0,  0,184,184,184,186,190,186,184,184,184,  0,  0,  0,  0,
        0,  0,  0,182,182,182,184,186,184,182,182,182,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,180,180,180,182,184,182,180,180,180,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 11. ���оֵ��ڣ����ա������񵰡�
    static const uint8_t cucvlCannonMidgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,100,100, 96, 91, 90, 91, 96,100,100,  0,  0,  0,  0,
        0,  0,  0, 98, 98, 96, 92, 89, 92, 96, 98, 98,  0,  0,  0,  0,
        0,  0,  0, 97, 97, 96, 91, 92, 91, 96, 97, 97,  0,  0,  0,  0,
        0,  0,  0, 96, 99, 99, 98,100, 98, 99, 99, 96,  0,  0,  0,  0,
        0,  0,  0, 96, 96, 96, 96,100, 96, 96, 96, 96,  0,  0,  0,  0,
        0,  0,  0, 95, 96, 99, 96,100, 96, 99, 96, 95,  0,  0,  0,  0,
        0,  0,  0, 96, 96, 96, 96, 96, 96, 96, 96, 96,  0,  0,  0,  0,
        0,  0,  0, 97, 96,100, 99,101, 99,100, 96, 97,  0,  0,  0,  0,
        0,  0,  0, 96, 97, 98, 98, 98, 98, 98, 97, 96,  0,  0,  0,  0,
        0,  0,  0, 96, 96, 97, 99, 99, 99, 97, 96, 96,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // 12. �оֵ���
    static const uint8_t cucvlCannonEndgame[256] = {
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,100,100,100,100,100,100,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,100,100,100,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,100,100,100,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,102,104,102,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,102,104,102,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,102,104,102,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,102,104,102,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,102,104,102,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,104,106,104,100,100,100,  0,  0,  0,  0,
        0,  0,  0,100,100,100,104,106,104,100,100,100,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
        0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
    };
    
    // ��ͷ�ڵ���в��ֵ��ָ���ǶԺ췽��˵���к�(���ڷ�Ҫ��15ȥ��)�������Ͽ�ͷ��λ��Խ����вԽ�󡣽���о�ʱ����ֵҪ��Ӧ���١�
    static const int32_t cvlHollowThreat[16] = {
        0,  0,  0,  0,  0,  0, 60, 65, 70, 75, 80, 80, 80,  0,  0,  0
    };
    
    // �������������в��ֵ��ָ��ͬ�ϣ������ϸ߶�Խ����вԽ��û��������ʱ��ȡ�ķ�֮һ������о�ʱ��ȡֵ�ƺ���Ӧ�仯��
    static const int32_t cvlCentralThreat[16] = {
        0,  0,  0,  0,  0,  0, 50, 45, 40, 35, 30, 30, 30,  0,  0,  0
    };
    
    // �����ڵ���в��ֵ��ָ�����кţ�������Խ����������вԽ����в����ʱ����ֵҪ��Ӧ���١�
    static const int32_t cvlBottomThreat[16] = {
        0,  0,  0, 40, 30,  0,  0,  0,  0,  0, 30, 40,  0,  0,  0,  0
    };
    
    // ��ģ��ֻ�漰��"PositionStruct"�е�"ucsqPieces"��"dwBitPiece/wBitPiece"��"vlWhite"��"vlBlack"�ĸ���Ա����ʡ��ǰ���"this->"
    
    /* ����Ԥ���۾��ǳ�ʼ������Ԥ��������(PreEval��PreEvalEx)�Ĺ��̡�
     * ElephantEye�ľ���Ԥ������Ҫ�������������棺
     * 1. �жϾ��ƴ��ڿ��оֻ��ǲоֽ׶Σ�
     * 2. �ж�ÿһ���Ƿ�ԶԷ��γ���в��
     */
    
    const int32_t ROOK_MIDGAME_VALUE = 6;
    const int32_t KNIGHT_CANNON_MIDGAME_VALUE = 3;
    const int32_t OTHER_MIDGAME_VALUE = 1;
    const int32_t TOTAL_MIDGAME_VALUE = ROOK_MIDGAME_VALUE * 4 + KNIGHT_CANNON_MIDGAME_VALUE * 8 + OTHER_MIDGAME_VALUE * 18;
    const int32_t TOTAL_ADVANCED_VALUE = 4;
    const int32_t TOTAL_ATTACK_VALUE = 8;
    const int32_t ADVISOR_BISHOP_ATTACKLESS_VALUE = 80;
    const int32_t TOTAL_ADVISOR_LEAKAGE = 80;
    
    static bool bInit = false;
    
    void PositionStruct::PreEvaluate(void) {
        // printf("position preevaluate\n");
        int32_t i, sq, nMidgameValue, nWhiteAttacks, nBlackAttacks, nWhiteSimpleValue, nBlackSimpleValue;
        uint8_t ucvlPawnPiecesAttacking[256], ucvlPawnPiecesAttackless[256];
        
        if (!bInit) {
            bInit = true;
            // ��ʼ��"PreEvalEx.cPopCnt16"���飬ֻ��Ҫ��ʼ��һ��
            for (i = 0; i < 65536; i ++) {
                PreEvalEx.cPopCnt16[i] = PopCnt16(i);
            }
        }
        
        // �����жϾ��ƴ��ڿ��оֻ��ǲоֽ׶Σ������Ǽ���������ӵ����������ճ�=6������=3������=1��ӡ�
        nMidgameValue = PopCnt32(this->dwBitPiece & BOTH_BITPIECE(ADVISOR_BITPIECE | BISHOP_BITPIECE | PAWN_BITPIECE)) * OTHER_MIDGAME_VALUE;
        nMidgameValue += PopCnt32(this->dwBitPiece & BOTH_BITPIECE(KNIGHT_BITPIECE | CANNON_BITPIECE)) * KNIGHT_CANNON_MIDGAME_VALUE;
        nMidgameValue += PopCnt32(this->dwBitPiece & BOTH_BITPIECE(ROOK_BITPIECE)) * ROOK_MIDGAME_VALUE;
        // ʹ�ö��κ�������������ʱ����Ϊ�ӽ��о�
        nMidgameValue = (2 * TOTAL_MIDGAME_VALUE - nMidgameValue) * nMidgameValue / TOTAL_MIDGAME_VALUE;
        // __ASSERT_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE);
        if(!__IF_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE)){
            printf("error, ASSERT_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE)\n");
            if(nMidgameValue<0){
                nMidgameValue = 0;
            }
            if(nMidgameValue>TOTAL_MIDGAME_VALUE){
                nMidgameValue = TOTAL_MIDGAME_VALUE;
            }
        }
        myPreGen->PreEval.vlAdvanced = (TOTAL_ADVANCED_VALUE * nMidgameValue + TOTAL_ADVANCED_VALUE / 2) / TOTAL_MIDGAME_VALUE;
        // __ASSERT_BOUND(0, myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE);
        if(!__IF_BOUND(0, myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE)){
            printf("error, ASSERT_BOUND(0, myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE)\n");
            if(myPreGen->PreEval.vlAdvanced<0){
                myPreGen->PreEval.vlAdvanced = 0;
            }
            if(myPreGen->PreEval.vlAdvanced>TOTAL_ADVANCED_VALUE){
                myPreGen->PreEval.vlAdvanced = TOTAL_ADVANCED_VALUE;
            }
        }
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                myPreGen->PreEval.ucvlWhitePieces[0][sq] = myPreGen->PreEval.ucvlBlackPieces[0][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlKingPawnMidgameAttacking[sq] * nMidgameValue + cucvlKingPawnEndgameAttacking[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                myPreGen->PreEval.ucvlWhitePieces[3][sq] = myPreGen->PreEval.ucvlBlackPieces[3][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlKnightMidgame[sq] * nMidgameValue + cucvlKnightEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                myPreGen->PreEval.ucvlWhitePieces[4][sq] = myPreGen->PreEval.ucvlBlackPieces[4][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlRookMidgame[sq] * nMidgameValue + cucvlRookEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                myPreGen->PreEval.ucvlWhitePieces[5][sq] = myPreGen->PreEval.ucvlBlackPieces[5][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlCannonMidgame[sq] * nMidgameValue + cucvlCannonEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                ucvlPawnPiecesAttacking[sq] = myPreGen->PreEval.ucvlWhitePieces[0][sq];
                ucvlPawnPiecesAttackless[sq] = (uint8_t)
                ((cucvlKingPawnMidgameAttackless[sq] * nMidgameValue + cucvlKingPawnEndgameAttackless[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
            }
        }
        for (i = 0; i < 16; i ++) {
            PreEvalEx.vlHollowThreat[i] = cvlHollowThreat[i] * (nMidgameValue + TOTAL_MIDGAME_VALUE) / (TOTAL_MIDGAME_VALUE * 2);
            // __ASSERT_BOUND(0, PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i]);
            if(!__IF_BOUND(0, PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i])){
                printf("error, ASSERT_BOUND(0, PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i])\n");
                if(PreEvalEx.vlHollowThreat[i]<0){
                    PreEvalEx.vlHollowThreat[i] = 0;
                }
                if(PreEvalEx.vlHollowThreat[i]>cvlHollowThreat[i]){
                    PreEvalEx.vlHollowThreat[i] = cvlHollowThreat[i];
                }
            }
            PreEvalEx.vlCentralThreat[i] = cvlCentralThreat[i];
        }
        
        // Ȼ���жϸ����Ƿ��ڽ���״̬�������Ǽ�����ֹ������ӵ����������ճ���2�ڱ�1��ӡ�
        nWhiteAttacks = nBlackAttacks = 0;
        for (i = SIDE_TAG(0) + KNIGHT_FROM; i <= SIDE_TAG(0) + ROOK_TO; i ++) {
            if (this->ucsqPieces[i] != 0 && BLACK_HALF(this->ucsqPieces[i])) {
                nWhiteAttacks += 2;
            }
        }
        for (i = SIDE_TAG(0) + CANNON_FROM; i <= SIDE_TAG(0) + PAWN_TO; i ++) {
            if (this->ucsqPieces[i] != 0 && BLACK_HALF(this->ucsqPieces[i])) {
                nWhiteAttacks ++;
            }
        }
        for (i = SIDE_TAG(1) + KNIGHT_FROM; i <= SIDE_TAG(1) + ROOK_TO; i ++) {
            if (this->ucsqPieces[i] != 0 && WHITE_HALF(this->ucsqPieces[i])) {
                nBlackAttacks += 2;
            }
        }
        for (i = SIDE_TAG(1) + CANNON_FROM; i <= SIDE_TAG(1) + PAWN_TO; i ++) {
            if (this->ucsqPieces[i] != 0 && WHITE_HALF(this->ucsqPieces[i])) {
                nBlackAttacks ++;
            }
        }
        // ��������������ȶԷ��࣬��ôÿ��һ������(����2������)��вֵ��2����вֵ��಻����8��
        nWhiteSimpleValue = PopCnt16(this->wBitPiece[0] & ROOK_BITPIECE) * 2 + PopCnt16(this->wBitPiece[0] & (KNIGHT_BITPIECE | CANNON_BITPIECE));
        nBlackSimpleValue = PopCnt16(this->wBitPiece[1] & ROOK_BITPIECE) * 2 + PopCnt16(this->wBitPiece[1] & (KNIGHT_BITPIECE | CANNON_BITPIECE));
        if (nWhiteSimpleValue > nBlackSimpleValue) {
            nWhiteAttacks += (nWhiteSimpleValue - nBlackSimpleValue) * 2;
        } else {
            nBlackAttacks += (nBlackSimpleValue - nWhiteSimpleValue) * 2;
        }
        nWhiteAttacks = MIN(nWhiteAttacks, TOTAL_ATTACK_VALUE);
        nBlackAttacks = MIN(nBlackAttacks, TOTAL_ATTACK_VALUE);
        PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE * nWhiteAttacks / TOTAL_ATTACK_VALUE;
        PreEvalEx.vlWhiteAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE * nBlackAttacks / TOTAL_ATTACK_VALUE;
        // __ASSERT_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE);
        if(!__IF_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE)){
            printf("error, ASSERT_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE)\n");
            if(nWhiteAttacks<0){
                nWhiteAttacks = 0;
            }
            if(nWhiteAttacks>TOTAL_ATTACK_VALUE){
                nWhiteAttacks = TOTAL_ATTACK_VALUE;
            }
        }
        // __ASSERT_BOUND(0, nBlackAttacks, TOTAL_ATTACK_VALUE);
        if(!__IF_BOUND(0, nBlackAttacks, TOTAL_ATTACK_VALUE)){
            if(nBlackAttacks<0){
                nBlackAttacks = 0;
            }
            if(nBlackAttacks>TOTAL_ATTACK_VALUE){
                nBlackAttacks = TOTAL_ATTACK_VALUE;
            }
        }
        // __ASSERT_BOUND(0, PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE);
        if(!__IF_BOUND(0, PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)){
            printf("error, ASSERT_BOUND(0, PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)\n");
            if(PreEvalEx.vlBlackAdvisorLeakage<0){
                PreEvalEx.vlBlackAdvisorLeakage = 0;
            }
            if(PreEvalEx.vlBlackAdvisorLeakage>TOTAL_ADVISOR_LEAKAGE){
                PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE;
            }
        }
        // __ASSERT_BOUND(0, PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE);
        if(!__IF_BOUND(0, PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)){
            if(PreEvalEx.vlBlackAdvisorLeakage<0){
                PreEvalEx.vlBlackAdvisorLeakage = 0;
            }
            if(PreEvalEx.vlBlackAdvisorLeakage > TOTAL_ADVISOR_LEAKAGE){
                PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE;
            }
        }
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                myPreGen->PreEval.ucvlWhitePieces[1][sq] = myPreGen->PreEval.ucvlWhitePieces[2][sq] = (uint8_t) ((cucvlAdvisorBishopThreatened[sq] * nBlackAttacks + (myPreGen->PreEval.bPromotion ? cucvlAdvisorBishopPromotionThreatless[sq] : cucvlAdvisorBishopThreatless[sq]) * (TOTAL_ATTACK_VALUE - nBlackAttacks)) / TOTAL_ATTACK_VALUE);
                myPreGen->PreEval.ucvlBlackPieces[1][sq] = myPreGen->PreEval.ucvlBlackPieces[2][sq] = (uint8_t) ((cucvlAdvisorBishopThreatened[SQUARE_FLIP(sq)] * nWhiteAttacks + (myPreGen->PreEval.bPromotion ? cucvlAdvisorBishopPromotionThreatless[SQUARE_FLIP(sq)] : cucvlAdvisorBishopThreatless[SQUARE_FLIP(sq)]) * (TOTAL_ATTACK_VALUE - nWhiteAttacks)) / TOTAL_ATTACK_VALUE);
                myPreGen->PreEval.ucvlWhitePieces[6][sq] = (uint8_t) ((ucvlPawnPiecesAttacking[sq] * nWhiteAttacks + ucvlPawnPiecesAttackless[sq] * (TOTAL_ATTACK_VALUE - nWhiteAttacks)) / TOTAL_ATTACK_VALUE);
                myPreGen->PreEval.ucvlBlackPieces[6][sq] = (uint8_t) ((ucvlPawnPiecesAttacking[SQUARE_FLIP(sq)] * nBlackAttacks + ucvlPawnPiecesAttackless[SQUARE_FLIP(sq)] * (TOTAL_ATTACK_VALUE - nBlackAttacks)) / TOTAL_ATTACK_VALUE);
            }
        }
        for (i = 0; i < 16; i ++) {
            PreEvalEx.vlWhiteBottomThreat[i] = cvlBottomThreat[i] * nBlackAttacks / TOTAL_ATTACK_VALUE;
            PreEvalEx.vlBlackBottomThreat[i] = cvlBottomThreat[i] * nWhiteAttacks / TOTAL_ATTACK_VALUE;
        }
        
        // ���Ԥ�����Ƿ�Գ�
#ifndef NDEBUG
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                for (i = 0; i < 7; i ++) {
                    // __ASSERT(myPreGen->PreEval.ucvlWhitePieces[i][sq] == myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)]);
                    if(!(myPreGen->PreEval.ucvlWhitePieces[i][sq] == myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)])){
                        printf("error, ASSERT(myPreGen->PreEval.ucvlWhitePieces[i][sq] == myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)])\n");
                    }
                    // __ASSERT(myPreGen->PreEval.ucvlBlackPieces[i][sq] == myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)]);
                    if(!(myPreGen->PreEval.ucvlBlackPieces[i][sq] == myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)])){
                        printf("error, ASSERT(myPreGen->PreEval.ucvlBlackPieces[i][sq] == myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)])\n");
                    }
                }
            }
        }
        for (i = FILE_LEFT; i <= FILE_RIGHT; i ++) {
            // __ASSERT(PreEvalEx.vlWhiteBottomThreat[i] == PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)]);
            if(!(PreEvalEx.vlWhiteBottomThreat[i] == PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)])){
                printf("error, ASSERT(PreEvalEx.vlWhiteBottomThreat[i] == PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)])\n");
            }
            // __ASSERT(PreEvalEx.vlBlackBottomThreat[i] == PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)]);
            if(!(PreEvalEx.vlBlackBottomThreat[i] == PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)])){
                printf("error, ASSERT(PreEvalEx.vlBlackBottomThreat[i] == PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)])\n");
            }
        }
#endif
        
        // ����������в���ٵ�����(ʿ)��(��)��ֵ
        this->vlWhite = ADVISOR_BISHOP_ATTACKLESS_VALUE * (TOTAL_ATTACK_VALUE - nBlackAttacks) / TOTAL_ATTACK_VALUE;
        this->vlBlack = ADVISOR_BISHOP_ATTACKLESS_VALUE * (TOTAL_ATTACK_VALUE - nWhiteAttacks) / TOTAL_ATTACK_VALUE;
        // ����������䣬��ô������в����(ʿ)��(��)��ֵ������һ��
        if (myPreGen->PreEval.bPromotion) {
            this->vlWhite /= 2;
            this->vlBlack /= 2;
        }
        // ������¼�������λ�÷�
        for (i = 16; i < 32; i ++) {
            sq = this->ucsqPieces[i];
            if (sq != 0) {
                // __ASSERT_SQUARE(sq);
                if(!IF_SQUARE(sq)){
                    printf("error, ASSERT_SQUARE(sq)\n");
                }
                this->vlWhite += myPreGen->PreEval.ucvlWhitePieces[PIECE_TYPE(i)][sq];
            }
        }
        for (i = 32; i < 48; i ++) {
            sq = this->ucsqPieces[i];
            if (sq != 0) {
                // __ASSERT_SQUARE(sq);
                if(!IF_SQUARE(sq)){
                    printf("error, ASSERT_SQUARE(sq)\n");
                }
                this->vlBlack += myPreGen->PreEval.ucvlBlackPieces[PIECE_TYPE(i)][sq];
            }
        }
        
    }
    
    void WINAPI PreEvaluateEVA(PositionStruct *lppos, PreEvalStruct *lpPreEval) {
        int32_t i, sq, nMidgameValue, nWhiteAttacks, nBlackAttacks, nWhiteSimpleValue, nBlackSimpleValue;
        uint8_t ucvlPawnPiecesAttacking[256], ucvlPawnPiecesAttackless[256];
        
        if (!bInit) {
            bInit = true;
            // ��ʼ��"PreEvalEx.cPopCnt16"���飬ֻ��Ҫ��ʼ��һ��
            for (i = 0; i < 65536; i ++) {
                lppos->PreEvalEx.cPopCnt16[i] = PopCnt16(i);
            }
            // ע�⣺����;�������API����ӵ��������ͬ��PreGenʵ����
            lppos->myPreGen->PreGenInit();
        }
        lppos->myPreGen->PreEval.bPromotion = lpPreEval->bPromotion;
        
        // �����жϾ��ƴ��ڿ��оֻ��ǲоֽ׶Σ������Ǽ���������ӵ����������ճ�=6������=3������=1��ӡ�
        nMidgameValue = PopCnt32(lppos->dwBitPiece & BOTH_BITPIECE(ADVISOR_BITPIECE | BISHOP_BITPIECE | PAWN_BITPIECE)) * OTHER_MIDGAME_VALUE;
        nMidgameValue += PopCnt32(lppos->dwBitPiece & BOTH_BITPIECE(KNIGHT_BITPIECE | CANNON_BITPIECE)) * KNIGHT_CANNON_MIDGAME_VALUE;
        nMidgameValue += PopCnt32(lppos->dwBitPiece & BOTH_BITPIECE(ROOK_BITPIECE)) * ROOK_MIDGAME_VALUE;
        // ʹ�ö��κ�������������ʱ����Ϊ�ӽ��о�
        nMidgameValue = (2 * TOTAL_MIDGAME_VALUE - nMidgameValue) * nMidgameValue / TOTAL_MIDGAME_VALUE;
        // __ASSERT_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE);
        if(!__IF_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE)){
            printf("error, ASSERT_BOUND(0, nMidgameValue, TOTAL_MIDGAME_VALUE)\n");
            if(nMidgameValue<0){
                nMidgameValue = 0;
            }
            if(nMidgameValue>TOTAL_MIDGAME_VALUE){
                nMidgameValue = TOTAL_MIDGAME_VALUE;
            }
        }
        lppos->myPreGen->PreEval.vlAdvanced = (TOTAL_ADVANCED_VALUE * nMidgameValue + TOTAL_ADVANCED_VALUE / 2) / TOTAL_MIDGAME_VALUE;
        // __ASSERT_BOUND(0, lppos->myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE);
        if(!__IF_BOUND(0, lppos->myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE)){
            printf("error, ASSERT_BOUND(0, lppos->myPreGen->PreEval.vlAdvanced, TOTAL_ADVANCED_VALUE)\n");
            if(lppos->myPreGen->PreEval.vlAdvanced<0){
                lppos->myPreGen->PreEval.vlAdvanced = 0;
            }
            if(lppos->myPreGen->PreEval.vlAdvanced>TOTAL_ADVANCED_VALUE){
                lppos->myPreGen->PreEval.vlAdvanced = TOTAL_ADVANCED_VALUE;
            }
        }
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                lppos->myPreGen->PreEval.ucvlWhitePieces[0][sq] = lppos->myPreGen->PreEval.ucvlBlackPieces[0][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlKingPawnMidgameAttacking[sq] * nMidgameValue + cucvlKingPawnEndgameAttacking[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                lppos->myPreGen->PreEval.ucvlWhitePieces[3][sq] = lppos->myPreGen->PreEval.ucvlBlackPieces[3][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlKnightMidgame[sq] * nMidgameValue + cucvlKnightEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                lppos->myPreGen->PreEval.ucvlWhitePieces[4][sq] = lppos->myPreGen->PreEval.ucvlBlackPieces[4][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlRookMidgame[sq] * nMidgameValue + cucvlRookEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                lppos->myPreGen->PreEval.ucvlWhitePieces[5][sq] = lppos->myPreGen->PreEval.ucvlBlackPieces[5][SQUARE_FLIP(sq)] = (uint8_t)
                ((cucvlCannonMidgame[sq] * nMidgameValue + cucvlCannonEndgame[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
                ucvlPawnPiecesAttacking[sq] = lppos->myPreGen->PreEval.ucvlWhitePieces[0][sq];
                ucvlPawnPiecesAttackless[sq] = (uint8_t)
                ((cucvlKingPawnMidgameAttackless[sq] * nMidgameValue + cucvlKingPawnEndgameAttackless[sq] * (TOTAL_MIDGAME_VALUE - nMidgameValue)) / TOTAL_MIDGAME_VALUE);
            }
        }
        for (i = 0; i < 16; i ++) {
            lppos->PreEvalEx.vlHollowThreat[i] = cvlHollowThreat[i] * (nMidgameValue + TOTAL_MIDGAME_VALUE) / (TOTAL_MIDGAME_VALUE * 2);
            // __ASSERT_BOUND(0, lppos->PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i]);
            if(!__IF_BOUND(0, lppos->PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i])){
                printf("error, ASSERT_BOUND(0, lppos->PreEvalEx.vlHollowThreat[i], cvlHollowThreat[i])\n");
                if(lppos->PreEvalEx.vlHollowThreat[i]<0){
                    lppos->PreEvalEx.vlHollowThreat[i] = 0;
                }
                if(lppos->PreEvalEx.vlHollowThreat[i]>cvlHollowThreat[i]){
                    lppos->PreEvalEx.vlHollowThreat[i] = cvlHollowThreat[i];
                }
            }
            lppos->PreEvalEx.vlCentralThreat[i] = cvlCentralThreat[i];
        }
        
        // Ȼ���жϸ����Ƿ��ڽ���״̬�������Ǽ�����ֹ������ӵ����������ճ���2�ڱ�1��ӡ�
        nWhiteAttacks = nBlackAttacks = 0;
        for (i = SIDE_TAG(0) + KNIGHT_FROM; i <= SIDE_TAG(0) + ROOK_TO; i ++) {
            if (lppos->ucsqPieces[i] != 0 && BLACK_HALF(lppos->ucsqPieces[i])) {
                nWhiteAttacks += 2;
            }
        }
        for (i = SIDE_TAG(0) + CANNON_FROM; i <= SIDE_TAG(0) + PAWN_TO; i ++) {
            if (lppos->ucsqPieces[i] != 0 && BLACK_HALF(lppos->ucsqPieces[i])) {
                nWhiteAttacks ++;
            }
        }
        for (i = SIDE_TAG(1) + KNIGHT_FROM; i <= SIDE_TAG(1) + ROOK_TO; i ++) {
            if (lppos->ucsqPieces[i] != 0 && WHITE_HALF(lppos->ucsqPieces[i])) {
                nBlackAttacks += 2;
            }
        }
        for (i = SIDE_TAG(1) + CANNON_FROM; i <= SIDE_TAG(1) + PAWN_TO; i ++) {
            if (lppos->ucsqPieces[i] != 0 && WHITE_HALF(lppos->ucsqPieces[i])) {
                nBlackAttacks ++;
            }
        }
        // ��������������ȶԷ��࣬��ôÿ��һ������(����2������)��вֵ��2����вֵ��಻����8��
        nWhiteSimpleValue = PopCnt16(lppos->wBitPiece[0] & ROOK_BITPIECE) * 2 + PopCnt16(lppos->wBitPiece[0] & (KNIGHT_BITPIECE | CANNON_BITPIECE));
        nBlackSimpleValue = PopCnt16(lppos->wBitPiece[1] & ROOK_BITPIECE) * 2 + PopCnt16(lppos->wBitPiece[1] & (KNIGHT_BITPIECE | CANNON_BITPIECE));
        if (nWhiteSimpleValue > nBlackSimpleValue) {
            nWhiteAttacks += (nWhiteSimpleValue - nBlackSimpleValue) * 2;
        } else {
            nBlackAttacks += (nBlackSimpleValue - nWhiteSimpleValue) * 2;
        }
        nWhiteAttacks = MIN(nWhiteAttacks, TOTAL_ATTACK_VALUE);
        nBlackAttacks = MIN(nBlackAttacks, TOTAL_ATTACK_VALUE);
        lppos->PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE * nWhiteAttacks / TOTAL_ATTACK_VALUE;
        lppos->PreEvalEx.vlWhiteAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE * nBlackAttacks / TOTAL_ATTACK_VALUE;
        // __ASSERT_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE);
        if(!__IF_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE)){
            printf("error, ASSERT_BOUND(0, nWhiteAttacks, TOTAL_ATTACK_VALUE)\n");
            if(nWhiteAttacks<0){
                nWhiteAttacks = 0;
            }
            if(nWhiteAttacks>TOTAL_ATTACK_VALUE){
                nWhiteAttacks = TOTAL_ATTACK_VALUE;
            }
        }
        // __ASSERT_BOUND(0, nBlackAttacks, TOTAL_ATTACK_VALUE);
        if(!__IF_BOUND(0, nBlackAttacks, TOTAL_ATTACK_VALUE)){
            if(nBlackAttacks<0){
                nBlackAttacks = 0;
            }
            if(nBlackAttacks>TOTAL_ATTACK_VALUE){
                nBlackAttacks = TOTAL_ATTACK_VALUE;
            }
        }
        // __ASSERT_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE);
        if(!__IF_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)){
            printf("error, ASSERT_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)\n");
            if(lppos->PreEvalEx.vlBlackAdvisorLeakage<0){
                lppos->PreEvalEx.vlBlackAdvisorLeakage = 0;
            }
            if(lppos->PreEvalEx.vlBlackAdvisorLeakage>TOTAL_ADVISOR_LEAKAGE){
                lppos->PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE;
            }
        }
        // __ASSERT_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE);
        if(!__IF_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)){
            printf("error, ASSERT_BOUND(0, lppos->PreEvalEx.vlBlackAdvisorLeakage, TOTAL_ADVISOR_LEAKAGE)\n");
            if(lppos->PreEvalEx.vlBlackAdvisorLeakage<0){
                lppos->PreEvalEx.vlBlackAdvisorLeakage = 0;
            }
            if(lppos->PreEvalEx.vlBlackAdvisorLeakage>TOTAL_ADVISOR_LEAKAGE){
                lppos->PreEvalEx.vlBlackAdvisorLeakage = TOTAL_ADVISOR_LEAKAGE;
            }
        }
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                lppos->myPreGen->PreEval.ucvlWhitePieces[1][sq] = lppos->myPreGen->PreEval.ucvlWhitePieces[2][sq] = (uint8_t) ((cucvlAdvisorBishopThreatened[sq] * nBlackAttacks + (lppos->myPreGen->PreEval.bPromotion ? cucvlAdvisorBishopPromotionThreatless[sq] : cucvlAdvisorBishopThreatless[sq]) * (TOTAL_ATTACK_VALUE - nBlackAttacks)) / TOTAL_ATTACK_VALUE);
                lppos->myPreGen->PreEval.ucvlBlackPieces[1][sq] = lppos->myPreGen->PreEval.ucvlBlackPieces[2][sq] = (uint8_t) ((cucvlAdvisorBishopThreatened[SQUARE_FLIP(sq)] * nWhiteAttacks + (lppos->myPreGen->PreEval.bPromotion ? cucvlAdvisorBishopPromotionThreatless[SQUARE_FLIP(sq)] : cucvlAdvisorBishopThreatless[SQUARE_FLIP(sq)]) * (TOTAL_ATTACK_VALUE - nWhiteAttacks)) / TOTAL_ATTACK_VALUE);
                lppos->myPreGen->PreEval.ucvlWhitePieces[6][sq] = (uint8_t) ((ucvlPawnPiecesAttacking[sq] * nWhiteAttacks + ucvlPawnPiecesAttackless[sq] * (TOTAL_ATTACK_VALUE - nWhiteAttacks)) / TOTAL_ATTACK_VALUE);
                lppos->myPreGen->PreEval.ucvlBlackPieces[6][sq] = (uint8_t) ((ucvlPawnPiecesAttacking[SQUARE_FLIP(sq)] * nBlackAttacks + ucvlPawnPiecesAttackless[SQUARE_FLIP(sq)] * (TOTAL_ATTACK_VALUE - nBlackAttacks)) / TOTAL_ATTACK_VALUE);
            }
        }
        for (i = 0; i < 16; i ++) {
            lppos->PreEvalEx.vlWhiteBottomThreat[i] = cvlBottomThreat[i] * nBlackAttacks / TOTAL_ATTACK_VALUE;
            lppos->PreEvalEx.vlBlackBottomThreat[i] = cvlBottomThreat[i] * nWhiteAttacks / TOTAL_ATTACK_VALUE;
        }
        
        // ���Ԥ�����Ƿ�Գ�
#ifndef NDEBUG
        for (sq = 0; sq < 256; sq ++) {
            if (IN_BOARD(sq)) {
                for (i = 0; i < 7; i ++) {
                    // __ASSERT(lppos->myPreGen->PreEval.ucvlWhitePieces[i][sq] == lppos->myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)]);
                    if(!(lppos->myPreGen->PreEval.ucvlWhitePieces[i][sq] == lppos->myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)])){
                        printf("error, ASSERT(lppos->myPreGen->PreEval.ucvlWhitePieces[i][sq] == lppos->myPreGen->PreEval.ucvlWhitePieces[i][SQUARE_MIRROR(sq)])\n");
                    }
                    // __ASSERT(lppos->myPreGen->PreEval.ucvlBlackPieces[i][sq] == lppos->myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)]);
                    if(!(lppos->myPreGen->PreEval.ucvlBlackPieces[i][sq] == lppos->myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)])){
                        printf("error, ASSERT(lppos->myPreGen->PreEval.ucvlBlackPieces[i][sq] == lppos->myPreGen->PreEval.ucvlBlackPieces[i][SQUARE_MIRROR(sq)])\n");
                    }
                }
            }
        }
        for (i = FILE_LEFT; i <= FILE_RIGHT; i ++) {
            // __ASSERT(lppos->PreEvalEx.vlWhiteBottomThreat[i] == lppos->PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)]);
            if(!(lppos->PreEvalEx.vlWhiteBottomThreat[i] == lppos->PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)])){
                printf("error, ASSERT(lppos->PreEvalEx.vlWhiteBottomThreat[i] == lppos->PreEvalEx.vlWhiteBottomThreat[FILE_FLIP(i)])\n");
            }
            // __ASSERT(lppos->PreEvalEx.vlBlackBottomThreat[i] == lppos->PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)]);
            if(!(lppos->PreEvalEx.vlBlackBottomThreat[i] == lppos->PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)])){
                printf("error, ASSERT(lppos->PreEvalEx.vlBlackBottomThreat[i] == lppos->PreEvalEx.vlBlackBottomThreat[FILE_FLIP(i)])\n");
            }
        }
#endif
        
        // ����������в���ٵ�����(ʿ)��(��)��ֵ
        lppos->vlWhite = ADVISOR_BISHOP_ATTACKLESS_VALUE * (TOTAL_ATTACK_VALUE - nBlackAttacks) / TOTAL_ATTACK_VALUE;
        lppos->vlBlack = ADVISOR_BISHOP_ATTACKLESS_VALUE * (TOTAL_ATTACK_VALUE - nWhiteAttacks) / TOTAL_ATTACK_VALUE;
        // ����������䣬��ô������в����(ʿ)��(��)��ֵ������һ��
        if (lppos->myPreGen->PreEval.bPromotion) {
            lppos->vlWhite /= 2;
            lppos->vlBlack /= 2;
        }
        // ������¼�������λ�÷�
        for (i = 16; i < 32; i ++) {
            sq = lppos->ucsqPieces[i];
            if (sq != 0) {
                // __ASSERT_SQUARE(sq);
                if(!IF_SQUARE(sq)){
                    printf("error, ASSERT_SQUARE(sq)\n");
                    sq = 128;
                }
                lppos->vlWhite += lppos->myPreGen->PreEval.ucvlWhitePieces[PIECE_TYPE(i)][sq];
            }
        }
        for (i = 32; i < 48; i ++) {
            sq = lppos->ucsqPieces[i];
            if (sq != 0) {
                // __ASSERT_SQUARE(sq);
                if(!IF_SQUARE(sq)){
                    printf("error, ASSERT_SQUARE(sq)\n");
                    sq = 128;
                }
                lppos->vlBlack += lppos->myPreGen->PreEval.ucvlBlackPieces[PIECE_TYPE(i)][sq];
            }
        }
        
        // ע�⣺����;�������API����ӵ��������ͬ��PreEvalʵ����
        *lpPreEval = lppos->myPreGen->PreEval;
    }
}
