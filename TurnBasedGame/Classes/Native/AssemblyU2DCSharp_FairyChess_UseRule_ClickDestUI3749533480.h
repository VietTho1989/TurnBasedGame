#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2047648951.h"

// FairyChess.UseRule.ClickDestClickUI
struct ClickDestClickUI_t689134400;
// FairyChess.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t4127051821;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRule.ClickDestUI
struct  ClickDestUI_t3749533480  : public UIBehavior_1_t2047648951
{
public:
	// FairyChess.UseRule.ClickDestClickUI FairyChess.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t689134400 * ___clickDestClickPrefab_6;
	// FairyChess.UseRule.ClickDestChooseUI FairyChess.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t4127051821 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t3749533480, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t689134400 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t689134400 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t689134400 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t3749533480, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t4127051821 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t4127051821 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t4127051821 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
