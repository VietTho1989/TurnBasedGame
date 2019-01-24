#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3010142995.h"

// EnglishDraught.UseRule.ClickDestClickUI
struct ClickDestClickUI_t3054469112;
// EnglishDraught.UseRule.ClickDestChooseUI
struct ClickDestChooseUI_t171448079;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.UseRule.ClickDestUI
struct  ClickDestUI_t2966987276  : public UIBehavior_1_t3010142995
{
public:
	// EnglishDraught.UseRule.ClickDestClickUI EnglishDraught.UseRule.ClickDestUI::clickDestClickPrefab
	ClickDestClickUI_t3054469112 * ___clickDestClickPrefab_6;
	// EnglishDraught.UseRule.ClickDestChooseUI EnglishDraught.UseRule.ClickDestUI::clickDestChoosePrefab
	ClickDestChooseUI_t171448079 * ___clickDestChoosePrefab_7;

public:
	inline static int32_t get_offset_of_clickDestClickPrefab_6() { return static_cast<int32_t>(offsetof(ClickDestUI_t2966987276, ___clickDestClickPrefab_6)); }
	inline ClickDestClickUI_t3054469112 * get_clickDestClickPrefab_6() const { return ___clickDestClickPrefab_6; }
	inline ClickDestClickUI_t3054469112 ** get_address_of_clickDestClickPrefab_6() { return &___clickDestClickPrefab_6; }
	inline void set_clickDestClickPrefab_6(ClickDestClickUI_t3054469112 * value)
	{
		___clickDestClickPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestClickPrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestChoosePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestUI_t2966987276, ___clickDestChoosePrefab_7)); }
	inline ClickDestChooseUI_t171448079 * get_clickDestChoosePrefab_7() const { return ___clickDestChoosePrefab_7; }
	inline ClickDestChooseUI_t171448079 ** get_address_of_clickDestChoosePrefab_7() { return &___clickDestChoosePrefab_7; }
	inline void set_clickDestChoosePrefab_7(ClickDestChooseUI_t171448079 * value)
	{
		___clickDestChoosePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestChoosePrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
