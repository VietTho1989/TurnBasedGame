#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3617017881.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// RussianDraught.UseRuleInputUI/UIData
struct UIData_t2359856708;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UseRule.BtnChosenMoveUI
struct  BtnChosenMoveUI_t2334963257  : public UIBehavior_1_t3617017881
{
public:
	// UnityEngine.UI.Image RussianDraught.UseRule.BtnChosenMoveUI::imgPiece
	Image_t2042527209 * ___imgPiece_6;
	// UnityEngine.UI.Text RussianDraught.UseRule.BtnChosenMoveUI::tvMove
	Text_t356221433 * ___tvMove_7;
	// RussianDraught.UseRuleInputUI/UIData RussianDraught.UseRule.BtnChosenMoveUI::useRuleInputUIData
	UIData_t2359856708 * ___useRuleInputUIData_8;

public:
	inline static int32_t get_offset_of_imgPiece_6() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t2334963257, ___imgPiece_6)); }
	inline Image_t2042527209 * get_imgPiece_6() const { return ___imgPiece_6; }
	inline Image_t2042527209 ** get_address_of_imgPiece_6() { return &___imgPiece_6; }
	inline void set_imgPiece_6(Image_t2042527209 * value)
	{
		___imgPiece_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_6, value);
	}

	inline static int32_t get_offset_of_tvMove_7() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t2334963257, ___tvMove_7)); }
	inline Text_t356221433 * get_tvMove_7() const { return ___tvMove_7; }
	inline Text_t356221433 ** get_address_of_tvMove_7() { return &___tvMove_7; }
	inline void set_tvMove_7(Text_t356221433 * value)
	{
		___tvMove_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvMove_7, value);
	}

	inline static int32_t get_offset_of_useRuleInputUIData_8() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t2334963257, ___useRuleInputUIData_8)); }
	inline UIData_t2359856708 * get_useRuleInputUIData_8() const { return ___useRuleInputUIData_8; }
	inline UIData_t2359856708 ** get_address_of_useRuleInputUIData_8() { return &___useRuleInputUIData_8; }
	inline void set_useRuleInputUIData_8(UIData_t2359856708 * value)
	{
		___useRuleInputUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___useRuleInputUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
