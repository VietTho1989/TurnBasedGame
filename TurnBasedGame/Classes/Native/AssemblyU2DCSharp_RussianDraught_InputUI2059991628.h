#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen410731489.h"

// RussianDraught.UseRuleInputUI
struct UseRuleInputUI_t2587309085;
// RussianDraught.NoneRuleInputUI
struct NoneRuleInputUI_t1793156556;
// GameDataUICheckAllowInputChange`1<RussianDraught.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t2867404618;
// GameDataCheckChangeRule`1<RussianDraught.RussianDraught>
struct GameDataCheckChangeRule_1_t858235408;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.InputUI
struct  InputUI_t2059991628  : public UIBehavior_1_t410731489
{
public:
	// RussianDraught.UseRuleInputUI RussianDraught.InputUI::useRulePrefab
	UseRuleInputUI_t2587309085 * ___useRulePrefab_6;
	// RussianDraught.NoneRuleInputUI RussianDraught.InputUI::noneRulePrefab
	NoneRuleInputUI_t1793156556 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<RussianDraught.InputUI/UIData> RussianDraught.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t2867404618 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<RussianDraught.RussianDraught> RussianDraught.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t858235408 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t2059991628, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t2587309085 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t2587309085 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t2587309085 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t2059991628, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t1793156556 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t1793156556 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t1793156556 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t2059991628, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t2867404618 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t2867404618 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t2867404618 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t2059991628, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t858235408 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t858235408 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t858235408 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
