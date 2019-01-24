#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1578867161.h"

// Seirawan.UseRuleInputUI
struct UseRuleInputUI_t3219778915;
// Seirawan.NoneRuleInputUI
struct NoneRuleInputUI_t1471040844;
// GameDataUICheckAllowInputChange`1<Seirawan.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t4035540290;
// GameDataCheckChangeRule`1<Seirawan.Seirawan>
struct GameDataCheckChangeRule_1_t1137750466;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.InputUI
struct  InputUI_t3832680924  : public UIBehavior_1_t1578867161
{
public:
	// Seirawan.UseRuleInputUI Seirawan.InputUI::useRulePrefab
	UseRuleInputUI_t3219778915 * ___useRulePrefab_6;
	// Seirawan.NoneRuleInputUI Seirawan.InputUI::noneRulePrefab
	NoneRuleInputUI_t1471040844 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Seirawan.InputUI/UIData> Seirawan.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t4035540290 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Seirawan.Seirawan> Seirawan.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t1137750466 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t3832680924, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t3219778915 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t3219778915 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t3219778915 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t3832680924, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t1471040844 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t1471040844 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t1471040844 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t3832680924, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t4035540290 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t4035540290 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t4035540290 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t3832680924, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t1137750466 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t1137750466 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t1137750466 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
