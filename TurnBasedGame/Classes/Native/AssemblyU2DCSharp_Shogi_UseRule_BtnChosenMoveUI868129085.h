#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3006754391.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.BtnChosenMoveUI
struct  BtnChosenMoveUI_t868129085  : public UIBehavior_1_t3006754391
{
public:
	// UnityEngine.UI.Image Shogi.UseRule.BtnChosenMoveUI::imgPiece
	Image_t2042527209 * ___imgPiece_6;
	// UnityEngine.UI.Text Shogi.UseRule.BtnChosenMoveUI::tvMoveType
	Text_t356221433 * ___tvMoveType_7;
	// UnityEngine.UI.Text Shogi.UseRule.BtnChosenMoveUI::tvMove
	Text_t356221433 * ___tvMove_8;
	// Shogi.ShogiGameDataUI/UIData Shogi.UseRule.BtnChosenMoveUI::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_9;

public:
	inline static int32_t get_offset_of_imgPiece_6() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t868129085, ___imgPiece_6)); }
	inline Image_t2042527209 * get_imgPiece_6() const { return ___imgPiece_6; }
	inline Image_t2042527209 ** get_address_of_imgPiece_6() { return &___imgPiece_6; }
	inline void set_imgPiece_6(Image_t2042527209 * value)
	{
		___imgPiece_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_6, value);
	}

	inline static int32_t get_offset_of_tvMoveType_7() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t868129085, ___tvMoveType_7)); }
	inline Text_t356221433 * get_tvMoveType_7() const { return ___tvMoveType_7; }
	inline Text_t356221433 ** get_address_of_tvMoveType_7() { return &___tvMoveType_7; }
	inline void set_tvMoveType_7(Text_t356221433 * value)
	{
		___tvMoveType_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvMoveType_7, value);
	}

	inline static int32_t get_offset_of_tvMove_8() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t868129085, ___tvMove_8)); }
	inline Text_t356221433 * get_tvMove_8() const { return ___tvMove_8; }
	inline Text_t356221433 ** get_address_of_tvMove_8() { return &___tvMove_8; }
	inline void set_tvMove_8(Text_t356221433 * value)
	{
		___tvMove_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvMove_8, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_9() { return static_cast<int32_t>(offsetof(BtnChosenMoveUI_t868129085, ___shogiGameDataUIData_9)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_9() const { return ___shogiGameDataUIData_9; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_9() { return &___shogiGameDataUIData_9; }
	inline void set_shogiGameDataUIData_9(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
