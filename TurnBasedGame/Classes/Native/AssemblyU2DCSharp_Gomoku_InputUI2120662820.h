#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3582126373.h"

// Gomoku.UseRuleInputUI
struct UseRuleInputUI_t3374782197;
// Gomoku.NoneRuleInputUI
struct NoneRuleInputUI_t691445388;
// GameDataUICheckAllowInputChange`1<Gomoku.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t1743832206;
// GameDataCheckChangeRule`1<Gomoku.Gomoku>
struct GameDataCheckChangeRule_1_t107245516;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.InputUI
struct  InputUI_t2120662820  : public UIBehavior_1_t3582126373
{
public:
	// Gomoku.UseRuleInputUI Gomoku.InputUI::useRulePrefab
	UseRuleInputUI_t3374782197 * ___useRulePrefab_6;
	// Gomoku.NoneRuleInputUI Gomoku.InputUI::noneRulePrefab
	NoneRuleInputUI_t691445388 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Gomoku.InputUI/UIData> Gomoku.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t1743832206 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Gomoku.Gomoku> Gomoku.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t107245516 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t2120662820, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t3374782197 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t3374782197 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t3374782197 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t2120662820, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t691445388 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t691445388 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t691445388 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t2120662820, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t1743832206 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t1743832206 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t1743832206 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t2120662820, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t107245516 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t107245516 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t107245516 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
