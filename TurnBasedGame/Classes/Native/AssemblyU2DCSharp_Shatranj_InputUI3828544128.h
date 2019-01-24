#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4126421754.h"

// Shatranj.UseRuleInputUI
struct UseRuleInputUI_t245162495;
// Shatranj.NoneRuleInputUI
struct NoneRuleInputUI_t1078481600;
// GameDataUICheckAllowInputChange`1<Shatranj.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t2288127587;
// GameDataCheckChangeRule`1<Shatranj.Shatranj>
struct GameDataCheckChangeRule_1_t653498817;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.InputUI
struct  InputUI_t3828544128  : public UIBehavior_1_t4126421754
{
public:
	// Shatranj.UseRuleInputUI Shatranj.InputUI::useRulePrefab
	UseRuleInputUI_t245162495 * ___useRulePrefab_6;
	// Shatranj.NoneRuleInputUI Shatranj.InputUI::noneRulePrefab
	NoneRuleInputUI_t1078481600 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Shatranj.InputUI/UIData> Shatranj.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t2288127587 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Shatranj.Shatranj> Shatranj.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t653498817 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t3828544128, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t245162495 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t245162495 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t245162495 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t3828544128, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t1078481600 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t1078481600 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t1078481600 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t3828544128, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t2288127587 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t2288127587 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t2288127587 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t3828544128, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t653498817 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t653498817 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t653498817 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
