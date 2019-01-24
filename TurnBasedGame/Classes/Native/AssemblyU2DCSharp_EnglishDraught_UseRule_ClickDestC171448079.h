#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3619916618.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// EnglishDraught.UseRule.BtnChosenMoveUI
struct BtnChosenMoveUI_t2388295787;
// EnglishDraught.UseRule.ShowUI/UIData
struct UIData_t711475682;
// EnglishDraught.UseRule.ClickDestUI/UIData
struct UIData_t3726068143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.UseRule.ClickDestChooseUI
struct  ClickDestChooseUI_t171448079  : public UIBehavior_1_t3619916618
{
public:
	// UnityEngine.Transform EnglishDraught.UseRule.ClickDestChooseUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// EnglishDraught.UseRule.BtnChosenMoveUI EnglishDraught.UseRule.ClickDestChooseUI::btnChoseMovePrefab
	BtnChosenMoveUI_t2388295787 * ___btnChoseMovePrefab_7;
	// UnityEngine.Transform EnglishDraught.UseRule.ClickDestChooseUI::btnChoseMovesContainter
	Transform_t3275118058 * ___btnChoseMovesContainter_8;
	// EnglishDraught.UseRule.ShowUI/UIData EnglishDraught.UseRule.ClickDestChooseUI::showUIData
	UIData_t711475682 * ___showUIData_9;
	// EnglishDraught.UseRule.ClickDestUI/UIData EnglishDraught.UseRule.ClickDestChooseUI::clickDestUIData
	UIData_t3726068143 * ___clickDestUIData_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t171448079, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_btnChoseMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t171448079, ___btnChoseMovePrefab_7)); }
	inline BtnChosenMoveUI_t2388295787 * get_btnChoseMovePrefab_7() const { return ___btnChoseMovePrefab_7; }
	inline BtnChosenMoveUI_t2388295787 ** get_address_of_btnChoseMovePrefab_7() { return &___btnChoseMovePrefab_7; }
	inline void set_btnChoseMovePrefab_7(BtnChosenMoveUI_t2388295787 * value)
	{
		___btnChoseMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnChoseMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_btnChoseMovesContainter_8() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t171448079, ___btnChoseMovesContainter_8)); }
	inline Transform_t3275118058 * get_btnChoseMovesContainter_8() const { return ___btnChoseMovesContainter_8; }
	inline Transform_t3275118058 ** get_address_of_btnChoseMovesContainter_8() { return &___btnChoseMovesContainter_8; }
	inline void set_btnChoseMovesContainter_8(Transform_t3275118058 * value)
	{
		___btnChoseMovesContainter_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnChoseMovesContainter_8, value);
	}

	inline static int32_t get_offset_of_showUIData_9() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t171448079, ___showUIData_9)); }
	inline UIData_t711475682 * get_showUIData_9() const { return ___showUIData_9; }
	inline UIData_t711475682 ** get_address_of_showUIData_9() { return &___showUIData_9; }
	inline void set_showUIData_9(UIData_t711475682 * value)
	{
		___showUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___showUIData_9, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_10() { return static_cast<int32_t>(offsetof(ClickDestChooseUI_t171448079, ___clickDestUIData_10)); }
	inline UIData_t3726068143 * get_clickDestUIData_10() const { return ___clickDestUIData_10; }
	inline UIData_t3726068143 ** get_address_of_clickDestUIData_10() { return &___clickDestUIData_10; }
	inline void set_clickDestUIData_10(UIData_t3726068143 * value)
	{
		___clickDestUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
