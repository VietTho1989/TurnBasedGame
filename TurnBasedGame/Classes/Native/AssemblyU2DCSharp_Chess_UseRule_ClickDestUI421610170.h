#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen818786898.h"

// Chess.UseRule.ClickDestClickUI
struct ClickDestClickUI_t3652416100;
// Chess.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t2570081835;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRule.ClickDestUI
struct  ClickDestUI_t421610170  : public UIBehavior_1_t818786898
{
public:
	// Chess.UseRule.ClickDestClickUI Chess.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t3652416100 * ___clickDestClickPrefab_6;
	// Chess.UseRule.ClickDestChooseUI Chess.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t2570081835 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t421610170, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t3652416100 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t3652416100 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t3652416100 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t421610170, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t2570081835 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t2570081835 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t2570081835 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
