#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3875726691.h"

// Makruk.UseRule.ClickDestClickUI
struct ClickDestClickUI_t1598277248;
// Makruk.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t1408930953;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.UseRule.ClickDestUI
struct  ClickDestUI_t1649561996  : public UIBehavior_1_t3875726691
{
public:
	// Makruk.UseRule.ClickDestClickUI Makruk.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t1598277248 * ___clickDestClickPrefab_6;
	// Makruk.UseRule.ClickDestChooseUI Makruk.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t1408930953 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t1649561996, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t1598277248 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t1598277248 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t1598277248 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t1649561996, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t1408930953 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t1408930953 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t1408930953 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
