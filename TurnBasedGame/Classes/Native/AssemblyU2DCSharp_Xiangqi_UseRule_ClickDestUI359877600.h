#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2031082469.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Xiangqi.UseRule.LegalMoveUI
struct LegalMoveUI_t4249769808;
// Xiangqi.UseRule.ShowUI/UIData
struct UIData_t2301285320;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRule.ClickDestUI
struct  ClickDestUI_t359877600  : public UIBehavior_1_t2031082469
{
public:
	// UnityEngine.UI.Image Xiangqi.UseRule.ClickDestUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// Xiangqi.UseRule.LegalMoveUI Xiangqi.UseRule.ClickDestUI::legalMovePrefab
	LegalMoveUI_t4249769808 * ___legalMovePrefab_7;
	// Xiangqi.UseRule.ShowUI/UIData Xiangqi.UseRule.ClickDestUI::show
	UIData_t2301285320 * ___show_8;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t359877600, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t359877600, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t4249769808 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t4249769808 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t4249769808 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_show_8() { return static_cast<int32_t>(offsetof(ClickDestUI_t359877600, ___show_8)); }
	inline UIData_t2301285320 * get_show_8() const { return ___show_8; }
	inline UIData_t2301285320 ** get_address_of_show_8() { return &___show_8; }
	inline void set_show_8(UIData_t2301285320 * value)
	{
		___show_8 = value;
		Il2CppCodeGenWriteBarrier(&___show_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
