#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen484161594.h"

// Seirawan.UseRule.ClickDestClickUI
struct ClickDestClickUI_t474767464;
// Seirawan.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t1221073489;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.UseRule.ClickDestUI
struct  ClickDestUI_t2381317722  : public UIBehavior_1_t484161594
{
public:
	// Seirawan.UseRule.ClickDestClickUI Seirawan.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t474767464 * ___clickDestClickPrefab_6;
	// Seirawan.UseRule.ClickDestChooseUI Seirawan.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t1221073489 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t2381317722, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t474767464 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t474767464 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t474767464 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t2381317722, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t1221073489 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t1221073489 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t1221073489 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
