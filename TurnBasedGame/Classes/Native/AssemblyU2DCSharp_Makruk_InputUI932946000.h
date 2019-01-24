#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1973226186.h"

// Makruk.UseRuleInputUI
struct UseRuleInputUI_t2034558509;
// Makruk.NoneRuleInputUI
struct NoneRuleInputUI_t3622619756;
// GameDataUICheckAllowInputChange`1<Makruk.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t134932019;
// GameDataCheckChangeRule`1<Makruk.Makruk>
struct GameDataCheckChangeRule_1_t411103007;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.InputUI
struct  InputUI_t932946000  : public UIBehavior_1_t1973226186
{
public:
	// Makruk.UseRuleInputUI Makruk.InputUI::useRulePrefab
	UseRuleInputUI_t2034558509 * ___useRulePrefab_6;
	// Makruk.NoneRuleInputUI Makruk.InputUI::noneRulePrefab
	NoneRuleInputUI_t3622619756 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Makruk.InputUI/UIData> Makruk.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t134932019 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Makruk.Makruk> Makruk.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t411103007 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t932946000, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t2034558509 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t2034558509 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t2034558509 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t932946000, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t3622619756 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t3622619756 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t3622619756 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t932946000, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t134932019 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t134932019 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t134932019 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t932946000, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t411103007 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t411103007 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t411103007 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
