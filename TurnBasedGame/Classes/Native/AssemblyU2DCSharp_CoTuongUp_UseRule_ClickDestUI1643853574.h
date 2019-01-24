#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen901285070.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Button
struct Button_t2872111280;
// CoTuongUp.UseRule.ShowUI/UIData
struct UIData_t795491345;
// CoTuongUp.UseRule.LegalMoveUI
struct LegalMoveUI_t2453541980;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.UseRule.ClickDestUI
struct  ClickDestUI_t1643853574  : public UIBehavior_1_t901285070
{
public:
	// UnityEngine.UI.Image CoTuongUp.UseRule.ClickDestUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// UnityEngine.UI.Button CoTuongUp.UseRule.ClickDestUI::btnFlip
	Button_t2872111280 * ___btnFlip_7;
	// CoTuongUp.UseRule.ShowUI/UIData CoTuongUp.UseRule.ClickDestUI::showUIData
	UIData_t795491345 * ___showUIData_8;
	// CoTuongUp.UseRule.LegalMoveUI CoTuongUp.UseRule.ClickDestUI::legalMovePrefab
	LegalMoveUI_t2453541980 * ___legalMovePrefab_9;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t1643853574, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_btnFlip_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t1643853574, ___btnFlip_7)); }
	inline Button_t2872111280 * get_btnFlip_7() const { return ___btnFlip_7; }
	inline Button_t2872111280 ** get_address_of_btnFlip_7() { return &___btnFlip_7; }
	inline void set_btnFlip_7(Button_t2872111280 * value)
	{
		___btnFlip_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnFlip_7, value);
	}

	inline static int32_t get_offset_of_showUIData_8() { return static_cast<int32_t>(offsetof(ClickDestUI_t1643853574, ___showUIData_8)); }
	inline UIData_t795491345 * get_showUIData_8() const { return ___showUIData_8; }
	inline UIData_t795491345 ** get_address_of_showUIData_8() { return &___showUIData_8; }
	inline void set_showUIData_8(UIData_t795491345 * value)
	{
		___showUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___showUIData_8, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_9() { return static_cast<int32_t>(offsetof(ClickDestUI_t1643853574, ___legalMovePrefab_9)); }
	inline LegalMoveUI_t2453541980 * get_legalMovePrefab_9() const { return ___legalMovePrefab_9; }
	inline LegalMoveUI_t2453541980 ** get_address_of_legalMovePrefab_9() { return &___legalMovePrefab_9; }
	inline void set_legalMovePrefab_9(LegalMoveUI_t2453541980 * value)
	{
		___legalMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
