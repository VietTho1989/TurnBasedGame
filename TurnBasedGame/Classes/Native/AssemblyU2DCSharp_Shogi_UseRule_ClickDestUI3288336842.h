#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen265219158.h"

// Shogi.UseRule.ClickDestClickUI
struct ClickDestClickUI_t2009720508;
// Shogi.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t1985115139;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.ClickDestUI
struct  ClickDestUI_t3288336842  : public UIBehavior_1_t265219158
{
public:
	// Shogi.UseRule.ClickDestClickUI Shogi.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t2009720508 * ___clickDestClickPrefab_6;
	// Shogi.UseRule.ClickDestChooseUI Shogi.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t1985115139 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t3288336842, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t2009720508 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t2009720508 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t2009720508 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t3288336842, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t1985115139 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t1985115139 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t1985115139 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
