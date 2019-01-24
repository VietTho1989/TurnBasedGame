#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3867924092.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Shatranj.UseRule.BtnChosenMoveUI
struct BtnChosenMoveUI_t1908179859;
// Shatranj.UseRule.ShowUI/UIData
struct UIData_t2943401200;
// Shatranj.UseRule.ClickDestUI/UIData
struct UIData_t3609719773;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.ClickDestChooseUI
struct  ClickDestChooseUI_t2781012983  : public UIBehavior_1_t3867924092
{
public:
	// UnityEngine.Transform Shatranj.UseRule.ClickDestChooseUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Shatranj.UseRule.BtnChosenMoveUI Shatranj.UseRule.ClickDestChooseUI::btnChoseMovePrefab
	BtnChosenMoveUI_t1908179859 * ___btnChoseMovePrefab_7;
	// UnityEngine.Transform Shatranj.UseRule.ClickDestChooseUI::btnChoseMovesContainter
	Transform_t3275118058 * ___btnChoseMovesContainter_8;
	// Shatranj.UseRule.ShowUI/UIData Shatranj.UseRule.ClickDestChooseUI::showUIData
	UIData_t2943401200 * ___showUIData_9;
	// Shatranj.UseRule.ClickDestUI/UIData Shatranj.UseRule.ClickDestChooseUI::clickDestUIData
	UIData_t3609719773 * ___clickDestUIData_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t2781012983, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_btnChoseMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t2781012983, ___btnChoseMovePrefab_7)); }
	inline BtnChosenMoveUI_t1908179859 * get_btnChoseMovePrefab_7() const { return ___btnChoseMovePrefab_7; }
	inline BtnChosenMoveUI_t1908179859 ** get_address_of_btnChoseMovePrefab_7() { return &___btnChoseMovePrefab_7; }
	inline void set_btnChoseMovePrefab_7(BtnChosenMoveUI_t1908179859 * value)
	{
		___btnChoseMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnChoseMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_btnChoseMovesContainter_8() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t2781012983, ___btnChoseMovesContainter_8)); }
	inline Transform_t3275118058 * get_btnChoseMovesContainter_8() const { return ___btnChoseMovesContainter_8; }
	inline Transform_t3275118058 ** get_address_of_btnChoseMovesContainter_8() { return &___btnChoseMovesContainter_8; }
	inline void set_btnChoseMovesContainter_8(Transform_t3275118058 * value)
	{
		___btnChoseMovesContainter_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnChoseMovesContainter_8, value);
	}

	inline static int32_t get_offset_of_showUIData_9() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t2781012983, ___showUIData_9)); }
	inline UIData_t2943401200 * get_showUIData_9() const { return ___showUIData_9; }
	inline UIData_t2943401200 ** get_address_of_showUIData_9() { return &___showUIData_9; }
	inline void set_showUIData_9(UIData_t2943401200 * value)
	{
		___showUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___showUIData_9, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_10() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t2781012983, ___clickDestUIData_10)); }
	inline UIData_t3609719773 * get_clickDestUIData_10() const { return ___clickDestUIData_10; }
	inline UIData_t3609719773 ** get_address_of_clickDestUIData_10() { return &___clickDestUIData_10; }
	inline void set_clickDestUIData_10(UIData_t3609719773 * value)
	{
		___clickDestUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
