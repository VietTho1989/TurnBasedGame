#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen240866011.h"

// Shogi.UseRuleInputUI
struct UseRuleInputUI_t3936344053;
// Shogi.NoneRuleInputUI
struct NoneRuleInputUI_t1229990576;
// GameDataUICheckAllowInputChange`1<Shogi.InputUI/UIData>
struct GameDataUICheckAllowInputChange_1_t2697539140;
// GameDataCheckChangeRule`1<Shogi.Shogi>
struct GameDataCheckChangeRule_1_t3728765806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.InputUI
struct  InputUI_t2204915484  : public UIBehavior_1_t240866011
{
public:
	// Shogi.UseRuleInputUI Shogi.InputUI::useRulePrefab
	UseRuleInputUI_t3936344053 * ___useRulePrefab_6;
	// Shogi.NoneRuleInputUI Shogi.InputUI::noneRulePrefab
	NoneRuleInputUI_t1229990576 * ___noneRulePrefab_7;
	// GameDataUICheckAllowInputChange`1<Shogi.InputUI/UIData> Shogi.InputUI::gameDataUICheckAllowInputChange
	GameDataUICheckAllowInputChange_1_t2697539140 * ___gameDataUICheckAllowInputChange_8;
	// GameDataCheckChangeRule`1<Shogi.Shogi> Shogi.InputUI::gameDataCheckChangeRule
	GameDataCheckChangeRule_1_t3728765806 * ___gameDataCheckChangeRule_9;

public:
	inline static int32_t get_offset_of_useRulePrefab_6() { return static_cast<int32_t>(offsetof(InputUI_t2204915484, ___useRulePrefab_6)); }
	inline UseRuleInputUI_t3936344053 * get_useRulePrefab_6() const { return ___useRulePrefab_6; }
	inline UseRuleInputUI_t3936344053 ** get_address_of_useRulePrefab_6() { return &___useRulePrefab_6; }
	inline void set_useRulePrefab_6(UseRuleInputUI_t3936344053 * value)
	{
		___useRulePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRulePrefab_6, value);
	}

	inline static int32_t get_offset_of_noneRulePrefab_7() { return static_cast<int32_t>(offsetof(InputUI_t2204915484, ___noneRulePrefab_7)); }
	inline NoneRuleInputUI_t1229990576 * get_noneRulePrefab_7() const { return ___noneRulePrefab_7; }
	inline NoneRuleInputUI_t1229990576 ** get_address_of_noneRulePrefab_7() { return &___noneRulePrefab_7; }
	inline void set_noneRulePrefab_7(NoneRuleInputUI_t1229990576 * value)
	{
		___noneRulePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___noneRulePrefab_7, value);
	}

	inline static int32_t get_offset_of_gameDataUICheckAllowInputChange_8() { return static_cast<int32_t>(offsetof(InputUI_t2204915484, ___gameDataUICheckAllowInputChange_8)); }
	inline GameDataUICheckAllowInputChange_1_t2697539140 * get_gameDataUICheckAllowInputChange_8() const { return ___gameDataUICheckAllowInputChange_8; }
	inline GameDataUICheckAllowInputChange_1_t2697539140 ** get_address_of_gameDataUICheckAllowInputChange_8() { return &___gameDataUICheckAllowInputChange_8; }
	inline void set_gameDataUICheckAllowInputChange_8(GameDataUICheckAllowInputChange_1_t2697539140 * value)
	{
		___gameDataUICheckAllowInputChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUICheckAllowInputChange_8, value);
	}

	inline static int32_t get_offset_of_gameDataCheckChangeRule_9() { return static_cast<int32_t>(offsetof(InputUI_t2204915484, ___gameDataCheckChangeRule_9)); }
	inline GameDataCheckChangeRule_1_t3728765806 * get_gameDataCheckChangeRule_9() const { return ___gameDataCheckChangeRule_9; }
	inline GameDataCheckChangeRule_1_t3728765806 ** get_address_of_gameDataCheckChangeRule_9() { return &___gameDataCheckChangeRule_9; }
	inline void set_gameDataCheckChangeRule_9(GameDataCheckChangeRule_1_t3728765806 * value)
	{
		___gameDataCheckChangeRule_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataCheckChangeRule_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
