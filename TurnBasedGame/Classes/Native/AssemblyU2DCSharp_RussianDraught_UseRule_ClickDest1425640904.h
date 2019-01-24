#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3555607130.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// RussianDraught.UseRule.LegalMoveUI
struct LegalMoveUI_t3518501628;
// RussianDraught.UseRule.ClickDestUI/UIData
struct UIData_t595247772;
// RussianDraught.UseRule.ShowUI/UIData
struct UIData_t138457507;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UseRule.ClickDestClickUI
struct  ClickDestClickUI_t1425640904  : public UIBehavior_1_t3555607130
{
public:
	// UnityEngine.UI.Image RussianDraught.UseRule.ClickDestClickUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// RussianDraught.UseRule.LegalMoveUI RussianDraught.UseRule.ClickDestClickUI::legalMovePrefab
	LegalMoveUI_t3518501628 * ___legalMovePrefab_7;
	// RussianDraught.UseRule.ClickDestUI/UIData RussianDraught.UseRule.ClickDestClickUI::clickDestUIData
	UIData_t595247772 * ___clickDestUIData_8;
	// RussianDraught.UseRule.ShowUI/UIData RussianDraught.UseRule.ClickDestClickUI::show
	UIData_t138457507 * ___show_9;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1425640904, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1425640904, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t3518501628 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t3518501628 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t3518501628 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_8() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1425640904, ___clickDestUIData_8)); }
	inline UIData_t595247772 * get_clickDestUIData_8() const { return ___clickDestUIData_8; }
	inline UIData_t595247772 ** get_address_of_clickDestUIData_8() { return &___clickDestUIData_8; }
	inline void set_clickDestUIData_8(UIData_t595247772 * value)
	{
		___clickDestUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_8, value);
	}

	inline static int32_t get_offset_of_show_9() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1425640904, ___show_9)); }
	inline UIData_t138457507 * get_show_9() const { return ___show_9; }
	inline UIData_t138457507 ** get_address_of_show_9() { return &___show_9; }
	inline void set_show_9(UIData_t138457507 * value)
	{
		___show_9 = value;
		Il2CppCodeGenWriteBarrier(&___show_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
