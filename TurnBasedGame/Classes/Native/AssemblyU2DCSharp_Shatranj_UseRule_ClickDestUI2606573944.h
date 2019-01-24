#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2893794625.h"

// Shatranj.UseRule.ClickDestClickUI
struct ClickDestClickUI_t2005188804;
// Shatranj.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t2781012983;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.ClickDestUI
struct  ClickDestUI_t2606573944  : public UIBehavior_1_t2893794625
{
public:
	// Shatranj.UseRule.ClickDestClickUI Shatranj.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t2005188804 * ___clickDestClickPrefab_6;
	// Shatranj.UseRule.ClickDestChooseUI Shatranj.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t2781012983 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t2606573944, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t2005188804 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t2005188804 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t2005188804 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t2606573944, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t2781012983 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t2781012983 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t2781012983 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
