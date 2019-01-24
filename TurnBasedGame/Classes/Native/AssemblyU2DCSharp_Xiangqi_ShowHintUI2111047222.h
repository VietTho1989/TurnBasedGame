#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen387601384.h"

// Xiangqi.XiangqiMoveUI
struct XiangqiMoveUI_t3002962186;
// Xiangqi.NoneRule.XiangqiCustomSetUI
struct XiangqiCustomSetUI_t1518985814;
// Xiangqi.NoneRule.XiangqiCustomMoveUI
struct XiangqiCustomMoveUI_t3268604469;
// Xiangqi.XiangqiGameDataUI/UIData
struct UIData_t2895034497;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.ShowHintUI
struct  ShowHintUI_t2111047222  : public UIBehavior_1_t387601384
{
public:
	// Xiangqi.XiangqiMoveUI Xiangqi.ShowHintUI::xiangqiMovePrefab
	XiangqiMoveUI_t3002962186 * ___xiangqiMovePrefab_6;
	// Xiangqi.NoneRule.XiangqiCustomSetUI Xiangqi.ShowHintUI::xiangqiCustomSetPrefab
	XiangqiCustomSetUI_t1518985814 * ___xiangqiCustomSetPrefab_7;
	// Xiangqi.NoneRule.XiangqiCustomMoveUI Xiangqi.ShowHintUI::xiangqiCustomMovePrefab
	XiangqiCustomMoveUI_t3268604469 * ___xiangqiCustomMovePrefab_8;
	// Xiangqi.XiangqiGameDataUI/UIData Xiangqi.ShowHintUI::xiangqiGameDataUIData
	UIData_t2895034497 * ___xiangqiGameDataUIData_9;
	// GameDataUI/UIData Xiangqi.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_xiangqiMovePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t2111047222, ___xiangqiMovePrefab_6)); }
	inline XiangqiMoveUI_t3002962186 * get_xiangqiMovePrefab_6() const { return ___xiangqiMovePrefab_6; }
	inline XiangqiMoveUI_t3002962186 ** get_address_of_xiangqiMovePrefab_6() { return &___xiangqiMovePrefab_6; }
	inline void set_xiangqiMovePrefab_6(XiangqiMoveUI_t3002962186 * value)
	{
		___xiangqiMovePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiMovePrefab_6, value);
	}

	inline static int32_t get_offset_of_xiangqiCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t2111047222, ___xiangqiCustomSetPrefab_7)); }
	inline XiangqiCustomSetUI_t1518985814 * get_xiangqiCustomSetPrefab_7() const { return ___xiangqiCustomSetPrefab_7; }
	inline XiangqiCustomSetUI_t1518985814 ** get_address_of_xiangqiCustomSetPrefab_7() { return &___xiangqiCustomSetPrefab_7; }
	inline void set_xiangqiCustomSetPrefab_7(XiangqiCustomSetUI_t1518985814 * value)
	{
		___xiangqiCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_xiangqiCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t2111047222, ___xiangqiCustomMovePrefab_8)); }
	inline XiangqiCustomMoveUI_t3268604469 * get_xiangqiCustomMovePrefab_8() const { return ___xiangqiCustomMovePrefab_8; }
	inline XiangqiCustomMoveUI_t3268604469 ** get_address_of_xiangqiCustomMovePrefab_8() { return &___xiangqiCustomMovePrefab_8; }
	inline void set_xiangqiCustomMovePrefab_8(XiangqiCustomMoveUI_t3268604469 * value)
	{
		___xiangqiCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_xiangqiGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t2111047222, ___xiangqiGameDataUIData_9)); }
	inline UIData_t2895034497 * get_xiangqiGameDataUIData_9() const { return ___xiangqiGameDataUIData_9; }
	inline UIData_t2895034497 ** get_address_of_xiangqiGameDataUIData_9() { return &___xiangqiGameDataUIData_9; }
	inline void set_xiangqiGameDataUIData_9(UIData_t2895034497 * value)
	{
		___xiangqiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t2111047222, ___gameDataUIData_10)); }
	inline UIData_t306925783 * get_gameDataUIData_10() const { return ___gameDataUIData_10; }
	inline UIData_t306925783 ** get_address_of_gameDataUIData_10() { return &___gameDataUIData_10; }
	inline void set_gameDataUIData_10(UIData_t306925783 * value)
	{
		___gameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
