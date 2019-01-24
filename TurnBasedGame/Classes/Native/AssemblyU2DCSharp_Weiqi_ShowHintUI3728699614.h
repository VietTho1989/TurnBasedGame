#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3530584382.h"

// Weiqi.WeiqiMoveUI
struct WeiqiMoveUI_t2369461500;
// Weiqi.NoneRule.WeiqiCustomSetUI
struct WeiqiCustomSetUI_t3060179092;
// Weiqi.NoneRule.WeiqiCustomMoveUI
struct WeiqiCustomMoveUI_t2786002911;
// Weiqi.WeiqiGameDataUI/UIData
struct UIData_t3165614177;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.ShowHintUI
struct  ShowHintUI_t3728699614  : public UIBehavior_1_t3530584382
{
public:
	// Weiqi.WeiqiMoveUI Weiqi.ShowHintUI::movePrefab
	WeiqiMoveUI_t2369461500 * ___movePrefab_6;
	// Weiqi.NoneRule.WeiqiCustomSetUI Weiqi.ShowHintUI::weiqiCustomSetPrefab
	WeiqiCustomSetUI_t3060179092 * ___weiqiCustomSetPrefab_7;
	// Weiqi.NoneRule.WeiqiCustomMoveUI Weiqi.ShowHintUI::weiqiCustomMovePrefab
	WeiqiCustomMoveUI_t2786002911 * ___weiqiCustomMovePrefab_8;
	// Weiqi.WeiqiGameDataUI/UIData Weiqi.ShowHintUI::weiqiGameDataUIData
	UIData_t3165614177 * ___weiqiGameDataUIData_9;
	// GameDataUI/UIData Weiqi.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_movePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t3728699614, ___movePrefab_6)); }
	inline WeiqiMoveUI_t2369461500 * get_movePrefab_6() const { return ___movePrefab_6; }
	inline WeiqiMoveUI_t2369461500 ** get_address_of_movePrefab_6() { return &___movePrefab_6; }
	inline void set_movePrefab_6(WeiqiMoveUI_t2369461500 * value)
	{
		___movePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___movePrefab_6, value);
	}

	inline static int32_t get_offset_of_weiqiCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t3728699614, ___weiqiCustomSetPrefab_7)); }
	inline WeiqiCustomSetUI_t3060179092 * get_weiqiCustomSetPrefab_7() const { return ___weiqiCustomSetPrefab_7; }
	inline WeiqiCustomSetUI_t3060179092 ** get_address_of_weiqiCustomSetPrefab_7() { return &___weiqiCustomSetPrefab_7; }
	inline void set_weiqiCustomSetPrefab_7(WeiqiCustomSetUI_t3060179092 * value)
	{
		___weiqiCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_weiqiCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t3728699614, ___weiqiCustomMovePrefab_8)); }
	inline WeiqiCustomMoveUI_t2786002911 * get_weiqiCustomMovePrefab_8() const { return ___weiqiCustomMovePrefab_8; }
	inline WeiqiCustomMoveUI_t2786002911 ** get_address_of_weiqiCustomMovePrefab_8() { return &___weiqiCustomMovePrefab_8; }
	inline void set_weiqiCustomMovePrefab_8(WeiqiCustomMoveUI_t2786002911 * value)
	{
		___weiqiCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_weiqiGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t3728699614, ___weiqiGameDataUIData_9)); }
	inline UIData_t3165614177 * get_weiqiGameDataUIData_9() const { return ___weiqiGameDataUIData_9; }
	inline UIData_t3165614177 ** get_address_of_weiqiGameDataUIData_9() { return &___weiqiGameDataUIData_9; }
	inline void set_weiqiGameDataUIData_9(UIData_t3165614177 * value)
	{
		___weiqiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t3728699614, ___gameDataUIData_10)); }
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
