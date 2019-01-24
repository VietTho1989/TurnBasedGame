#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen835549632.h"

// HEX.UseRuleInputUI
struct UseRuleInputUI_t338664885;
// HEX.NoneRuleInputUI
struct NoneRuleInputUI_t375160360;
// GameDataUICheckAllowInputChange`1<HEX.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t3292222761;
// GameDataCheckChangeRule`1<HEX.Hex>
struct GameDataCheckChangeRule_1_t3168411663;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.InputUI
struct  InputUI_t482200744  : public UIBehavior_1_t835549632
{
public:
	// HEX.UseRuleInputUI HEX.InputUI::useRulePrefab
	UseRuleInputUI_t338664885 * ___useRulePrefab_6;
	// HEX.NoneRuleInputUI HEX.InputUI::noneRulePrefab
	NoneRuleInputUI_t375160360 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<HEX.InputUI/UIData> HEX.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t3292222761 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<HEX.Hex> HEX.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t3168411663 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t482200744, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t338664885 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t338664885 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t338664885 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t482200744, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t375160360 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t375160360 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t375160360 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t482200744, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t3292222761 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t3292222761 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t3292222761 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t482200744, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t3168411663 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t3168411663 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t3168411663 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
