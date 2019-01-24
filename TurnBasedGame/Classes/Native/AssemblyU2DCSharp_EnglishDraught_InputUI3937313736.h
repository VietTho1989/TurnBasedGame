#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen943793260.h"

// EnglishDraught.UseRuleInputUI
struct UseRuleInputUI_t2585931659;
// EnglishDraught.NoneRuleInputUI
struct NoneRuleInputUI_t2254420396;
// GameDataUICheckAllowInputChange`1<EnglishDraught.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t3400466389;
// GameDataCheckChangeRule`1<EnglishDraught.EnglishDraught>
struct GameDataCheckChangeRule_1_t80529955;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.InputUI
struct  InputUI_t3937313736  : public UIBehavior_1_t943793260
{
public:
	// EnglishDraught.UseRuleInputUI EnglishDraught.InputUI::useRulePrefab
	UseRuleInputUI_t2585931659 * ___useRulePrefab_6;
	// EnglishDraught.NoneRuleInputUI EnglishDraught.InputUI::noneRulePrefab
	NoneRuleInputUI_t2254420396 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<EnglishDraught.InputUI/UIData> EnglishDraught.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t3400466389 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<EnglishDraught.EnglishDraught> EnglishDraught.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t80529955 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t3937313736, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t2585931659 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t2585931659 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t2585931659 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t3937313736, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t2254420396 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t2254420396 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t2254420396 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t3937313736, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t3400466389 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t3400466389 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t3400466389 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t3937313736, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t80529955 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t80529955 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t80529955 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
