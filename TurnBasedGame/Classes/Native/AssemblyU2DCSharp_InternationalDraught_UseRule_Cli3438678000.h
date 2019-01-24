#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1569076935.h"

// InternationalDraught.UseRule.ClickDestClickUI
struct ClickDestClickUI_t1832941736;
// InternationalDraught.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t3289853243;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.UseRule.ClickDestUI
struct  ClickDestUI_t3438678000  : public UIBehavior_1_t1569076935
{
public:
	// InternationalDraught.UseRule.ClickDestClickUI InternationalDraught.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t1832941736 * ___clickDestClickPrefab_6;
	// InternationalDraught.UseRule.ClickDestChooseUI InternationalDraught.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t3289853243 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t3438678000, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t1832941736 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t1832941736 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t1832941736 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t3438678000, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t3289853243 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t3289853243 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t3289853243 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
