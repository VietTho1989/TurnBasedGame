﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen705445137.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<EnglishDraught.NoneRule.ClickMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3960765881;
// EnglishDraught.NoneRuleInputUI/UIData
struct UIData_t1468203088;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.NoneRule.ClickMoveUI
struct  ClickMoveUI_t3603692785  : public UIBehavior_1_t705445137
{
public:
	// UnityEngine.UI.Image EnglishDraught.NoneRule.ClickMoveUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// GameDataBoardCheckPerspectiveChange`1<EnglishDraught.NoneRule.ClickMoveUI/UIData> EnglishDraught.NoneRule.ClickMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3960765881 * ___perspectiveChange_7;
	// EnglishDraught.NoneRuleInputUI/UIData EnglishDraught.NoneRule.ClickMoveUI::noneRuleInputUIData
	UIData_t1468203088 * ___noneRuleInputUIData_8;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickMoveUI_t3603692785, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_7() { return static_cast<int32_t>(offsetof(ClickMoveUI_t3603692785, ___perspectiveChange_7)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3960765881 * get_perspectiveChange_7() const { return ___perspectiveChange_7; }
	inline GameDataBoardCheckPerspectiveChange_1_t3960765881 ** get_address_of_perspectiveChange_7() { return &___perspectiveChange_7; }
	inline void set_perspectiveChange_7(GameDataBoardCheckPerspectiveChange_1_t3960765881 * value)
	{
		___perspectiveChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_7, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_8() { return static_cast<int32_t>(offsetof(ClickMoveUI_t3603692785, ___noneRuleInputUIData_8)); }
	inline UIData_t1468203088 * get_noneRuleInputUIData_8() const { return ___noneRuleInputUIData_8; }
	inline UIData_t1468203088 ** get_address_of_noneRuleInputUIData_8() { return &___noneRuleInputUIData_8; }
	inline void set_noneRuleInputUIData_8(UIData_t1468203088 * value)
	{
		___noneRuleInputUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
