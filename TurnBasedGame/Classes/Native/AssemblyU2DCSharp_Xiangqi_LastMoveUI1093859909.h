#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1028541049.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Xiangqi.XiangqiMoveUI
struct XiangqiMoveUI_t3002962186;
// Xiangqi.NoneRule.XiangqiCustomSetUI
struct XiangqiCustomSetUI_t1518985814;
// Xiangqi.NoneRule.XiangqiCustomMoveUI
struct XiangqiCustomMoveUI_t3268604469;
// LastMoveCheckChange`1<Xiangqi.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t631908966;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.LastMoveUI
struct  LastMoveUI_t1093859909  : public UIBehavior_1_t1028541049
{
public:
	// UnityEngine.Transform Xiangqi.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Xiangqi.XiangqiMoveUI Xiangqi.LastMoveUI::xiangqiMovePrefab
	XiangqiMoveUI_t3002962186 * ___xiangqiMovePrefab_7;
	// Xiangqi.NoneRule.XiangqiCustomSetUI Xiangqi.LastMoveUI::xiangqiCustomSetPrefab
	XiangqiCustomSetUI_t1518985814 * ___xiangqiCustomSetPrefab_8;
	// Xiangqi.NoneRule.XiangqiCustomMoveUI Xiangqi.LastMoveUI::xiangqiCustomMovePrefab
	XiangqiCustomMoveUI_t3268604469 * ___xiangqiCustomMovePrefab_9;
	// LastMoveCheckChange`1<Xiangqi.LastMoveUI/UIData> Xiangqi.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t631908966 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t1093859909, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_xiangqiMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t1093859909, ___xiangqiMovePrefab_7)); }
	inline XiangqiMoveUI_t3002962186 * get_xiangqiMovePrefab_7() const { return ___xiangqiMovePrefab_7; }
	inline XiangqiMoveUI_t3002962186 ** get_address_of_xiangqiMovePrefab_7() { return &___xiangqiMovePrefab_7; }
	inline void set_xiangqiMovePrefab_7(XiangqiMoveUI_t3002962186 * value)
	{
		___xiangqiMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_xiangqiCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t1093859909, ___xiangqiCustomSetPrefab_8)); }
	inline XiangqiCustomSetUI_t1518985814 * get_xiangqiCustomSetPrefab_8() const { return ___xiangqiCustomSetPrefab_8; }
	inline XiangqiCustomSetUI_t1518985814 ** get_address_of_xiangqiCustomSetPrefab_8() { return &___xiangqiCustomSetPrefab_8; }
	inline void set_xiangqiCustomSetPrefab_8(XiangqiCustomSetUI_t1518985814 * value)
	{
		___xiangqiCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_xiangqiCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t1093859909, ___xiangqiCustomMovePrefab_9)); }
	inline XiangqiCustomMoveUI_t3268604469 * get_xiangqiCustomMovePrefab_9() const { return ___xiangqiCustomMovePrefab_9; }
	inline XiangqiCustomMoveUI_t3268604469 ** get_address_of_xiangqiCustomMovePrefab_9() { return &___xiangqiCustomMovePrefab_9; }
	inline void set_xiangqiCustomMovePrefab_9(XiangqiCustomMoveUI_t3268604469 * value)
	{
		___xiangqiCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t1093859909, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t631908966 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t631908966 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t631908966 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
