#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1987908921.h"

// Xiangqi.XiangqiFenUI
struct XiangqiFenUI_t235256850;
// UnityEngine.Transform
struct Transform_t3275118058;
// Xiangqi.XiangqiPieceUI
struct XiangqiPieceUI_t4230850847;
// AnimationManagerCheckChange`1<Xiangqi.XiangqiBoardUI/UIData>
struct AnimationManagerCheckChange_1_t2918806606;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiBoardUI
struct  XiangqiBoardUI_t3654403185  : public UIBehavior_1_t1987908921
{
public:
	// Xiangqi.XiangqiFenUI Xiangqi.XiangqiBoardUI::xiangqiFenPrefab
	XiangqiFenUI_t235256850 * ___xiangqiFenPrefab_6;
	// UnityEngine.Transform Xiangqi.XiangqiBoardUI::xiangqiFenContainer
	Transform_t3275118058 * ___xiangqiFenContainer_7;
	// Xiangqi.XiangqiPieceUI Xiangqi.XiangqiBoardUI::piecePrefab
	XiangqiPieceUI_t4230850847 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<Xiangqi.XiangqiBoardUI/UIData> Xiangqi.XiangqiBoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t2918806606 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_xiangqiFenPrefab_6() { return static_cast<int32_t>(offsetof(XiangqiBoardUI_t3654403185, ___xiangqiFenPrefab_6)); }
	inline XiangqiFenUI_t235256850 * get_xiangqiFenPrefab_6() const { return ___xiangqiFenPrefab_6; }
	inline XiangqiFenUI_t235256850 ** get_address_of_xiangqiFenPrefab_6() { return &___xiangqiFenPrefab_6; }
	inline void set_xiangqiFenPrefab_6(XiangqiFenUI_t235256850 * value)
	{
		___xiangqiFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_xiangqiFenContainer_7() { return static_cast<int32_t>(offsetof(XiangqiBoardUI_t3654403185, ___xiangqiFenContainer_7)); }
	inline Transform_t3275118058 * get_xiangqiFenContainer_7() const { return ___xiangqiFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_xiangqiFenContainer_7() { return &___xiangqiFenContainer_7; }
	inline void set_xiangqiFenContainer_7(Transform_t3275118058 * value)
	{
		___xiangqiFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(XiangqiBoardUI_t3654403185, ___piecePrefab_8)); }
	inline XiangqiPieceUI_t4230850847 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline XiangqiPieceUI_t4230850847 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(XiangqiPieceUI_t4230850847 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(XiangqiBoardUI_t3654403185, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t2918806606 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t2918806606 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t2918806606 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
