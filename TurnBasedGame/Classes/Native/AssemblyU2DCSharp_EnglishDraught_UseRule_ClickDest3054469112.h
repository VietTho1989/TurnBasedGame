#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen749966341.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// EnglishDraught.UseRule.LegalMoveUI
struct LegalMoveUI_t718981320;
// EnglishDraught.UseRule.ClickDestUI/UIData
struct UIData_t3726068143;
// EnglishDraught.UseRule.ShowUI/UIData
struct UIData_t711475682;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.UseRule.ClickDestClickUI
struct  ClickDestClickUI_t3054469112  : public UIBehavior_1_t749966341
{
public:
	// UnityEngine.UI.Image EnglishDraught.UseRule.ClickDestClickUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// EnglishDraught.UseRule.LegalMoveUI EnglishDraught.UseRule.ClickDestClickUI::legalMovePrefab
	LegalMoveUI_t718981320 * ___legalMovePrefab_7;
	// EnglishDraught.UseRule.ClickDestUI/UIData EnglishDraught.UseRule.ClickDestClickUI::clickDestUIData
	UIData_t3726068143 * ___clickDestUIData_8;
	// EnglishDraught.UseRule.ShowUI/UIData EnglishDraught.UseRule.ClickDestClickUI::show
	UIData_t711475682 * ___show_9;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3054469112, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3054469112, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t718981320 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t718981320 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t718981320 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_8() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3054469112, ___clickDestUIData_8)); }
	inline UIData_t3726068143 * get_clickDestUIData_8() const { return ___clickDestUIData_8; }
	inline UIData_t3726068143 ** get_address_of_clickDestUIData_8() { return &___clickDestUIData_8; }
	inline void set_clickDestUIData_8(UIData_t3726068143 * value)
	{
		___clickDestUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_8, value);
	}

	inline static int32_t get_offset_of_show_9() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3054469112, ___show_9)); }
	inline UIData_t711475682 * get_show_9() const { return ___show_9; }
	inline UIData_t711475682 ** get_address_of_show_9() { return &___show_9; }
	inline void set_show_9(UIData_t711475682 * value)
	{
		___show_9 = value;
		Il2CppCodeGenWriteBarrier(&___show_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
