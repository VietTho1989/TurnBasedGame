#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1871548631.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Shatranj.UseRule.LegalMoveUI
struct LegalMoveUI_t2878128976;
// Shatranj.UseRule.ClickDestClickMoveOrChooseUI
struct ClickDestClickMoveOrChooseUI_t2163948961;
// Shatranj.UseRule.ClickDestUI/UIData
struct UIData_t3609719773;
// Shatranj.UseRule.ShowUI/UIData
struct UIData_t2943401200;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.ClickDestClickUI
struct  ClickDestClickUI_t2005188804  : public UIBehavior_1_t1871548631
{
public:
	// UnityEngine.UI.Image Shatranj.UseRule.ClickDestClickUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// Shatranj.UseRule.LegalMoveUI Shatranj.UseRule.ClickDestClickUI::legalMovePrefab
	LegalMoveUI_t2878128976 * ___legalMovePrefab_7;
	// Shatranj.UseRule.ClickDestClickMoveOrChooseUI Shatranj.UseRule.ClickDestClickUI::moveOrChoosePrefab
	ClickDestClickMoveOrChooseUI_t2163948961 * ___moveOrChoosePrefab_8;
	// Shatranj.UseRule.ClickDestUI/UIData Shatranj.UseRule.ClickDestClickUI::clickDestUIData
	UIData_t3609719773 * ___clickDestUIData_9;
	// Shatranj.UseRule.ShowUI/UIData Shatranj.UseRule.ClickDestClickUI::show
	UIData_t2943401200 * ___show_10;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t2005188804, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t2005188804, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t2878128976 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t2878128976 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t2878128976 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_moveOrChoosePrefab_8() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t2005188804, ___moveOrChoosePrefab_8)); }
	inline ClickDestClickMoveOrChooseUI_t2163948961 * get_moveOrChoosePrefab_8() const { return ___moveOrChoosePrefab_8; }
	inline ClickDestClickMoveOrChooseUI_t2163948961 ** get_address_of_moveOrChoosePrefab_8() { return &___moveOrChoosePrefab_8; }
	inline void set_moveOrChoosePrefab_8(ClickDestClickMoveOrChooseUI_t2163948961 * value)
	{
		___moveOrChoosePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___moveOrChoosePrefab_8, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_9() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t2005188804, ___clickDestUIData_9)); }
	inline UIData_t3609719773 * get_clickDestUIData_9() const { return ___clickDestUIData_9; }
	inline UIData_t3609719773 ** get_address_of_clickDestUIData_9() { return &___clickDestUIData_9; }
	inline void set_clickDestUIData_9(UIData_t3609719773 * value)
	{
		___clickDestUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_9, value);
	}

	inline static int32_t get_offset_of_show_10() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t2005188804, ___show_10)); }
	inline UIData_t2943401200 * get_show_10() const { return ___show_10; }
	inline UIData_t2943401200 ** get_address_of_show_10() { return &___show_10; }
	inline void set_show_10(UIData_t2943401200 * value)
	{
		___show_10 = value;
		Il2CppCodeGenWriteBarrier(&___show_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
