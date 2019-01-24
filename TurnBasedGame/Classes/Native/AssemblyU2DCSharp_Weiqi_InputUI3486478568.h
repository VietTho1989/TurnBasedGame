#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen615131412.h"

// Weiqi.UseRuleInputUI
struct UseRuleInputUI_t3063976135;
// Weiqi.NoneRuleInputUI
struct NoneRuleInputUI_t2013144124;
// GameDataUICheckAllowInputChange`1<Weiqi.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t3071804541;
// GameDataCheckChangeRule`1<Weiqi.Weiqi>
struct GameDataCheckChangeRule_1_t2597178741;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.InputUI
struct  InputUI_t3486478568  : public UIBehavior_1_t615131412
{
public:
	// Weiqi.UseRuleInputUI Weiqi.InputUI::useRulePrefab
	UseRuleInputUI_t3063976135 * ___useRulePrefab_6;
	// Weiqi.NoneRuleInputUI Weiqi.InputUI::noneRulePrefab
	NoneRuleInputUI_t2013144124 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Weiqi.InputUI/UIData> Weiqi.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t3071804541 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Weiqi.Weiqi> Weiqi.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t2597178741 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t3486478568, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t3063976135 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t3063976135 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t3063976135 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t3486478568, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t2013144124 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t2013144124 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t2013144124 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t3486478568, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t3071804541 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t3071804541 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t3071804541 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t3486478568, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t2597178741 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t2597178741 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t2597178741 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
