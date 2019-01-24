#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4174289920.h"

// RussianDraught.UseRule.ClickDestClickUI
struct ClickDestClickUI_t1425640904;
// RussianDraught.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t1003972415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UseRule.ClickDestUI
struct  ClickDestUI_t2277739662  : public UIBehavior_1_t4174289920
{
public:
	// RussianDraught.UseRule.ClickDestClickUI RussianDraught.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t1425640904 * ___clickDestClickPrefab_6;
	// RussianDraught.UseRule.ClickDestChooseUI RussianDraught.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t1003972415 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t2277739662, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t1425640904 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t1425640904 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t1425640904 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t2277739662, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t1003972415 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t1003972415 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t1003972415 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
