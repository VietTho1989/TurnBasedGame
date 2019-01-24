#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen878666713.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Shatranj.UseRule.GetUI
struct GetUI_t533004436;
// Shatranj.UseRule.GettingUI
struct GettingUI_t2926927584;
// Shatranj.UseRule.ShowUI
struct ShowUI_t7027405;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRuleInputUI
struct  UseRuleInputUI_t245162495  : public UIBehavior_1_t878666713
{
public:
	// AdvancedCoroutines.Routine Shatranj.UseRuleInputUI::getLegalMoves
	Routine_t2502590640 * ___getLegalMoves_6;
	// Shatranj.UseRule.GetUI Shatranj.UseRuleInputUI::getPrefab
	GetUI_t533004436 * ___getPrefab_7;
	// Shatranj.UseRule.GettingUI Shatranj.UseRuleInputUI::gettingPrefab
	GettingUI_t2926927584 * ___gettingPrefab_8;
	// Shatranj.UseRule.ShowUI Shatranj.UseRuleInputUI::showPrefab
	ShowUI_t7027405 * ___showPrefab_9;
	// System.Boolean Shatranj.UseRuleInputUI::haveChange
	bool ___haveChange_10;

public:
	inline static int32_t get_offset_of_getLegalMoves_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t245162495, ___getLegalMoves_6)); }
	inline Routine_t2502590640 * get_getLegalMoves_6() const { return ___getLegalMoves_6; }
	inline Routine_t2502590640 ** get_address_of_getLegalMoves_6() { return &___getLegalMoves_6; }
	inline void set_getLegalMoves_6(Routine_t2502590640 * value)
	{
		___getLegalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___getLegalMoves_6, value);
	}

	inline static int32_t get_offset_of_getPrefab_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t245162495, ___getPrefab_7)); }
	inline GetUI_t533004436 * get_getPrefab_7() const { return ___getPrefab_7; }
	inline GetUI_t533004436 ** get_address_of_getPrefab_7() { return &___getPrefab_7; }
	inline void set_getPrefab_7(GetUI_t533004436 * value)
	{
		___getPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___getPrefab_7, value);
	}

	inline static int32_t get_offset_of_gettingPrefab_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t245162495, ___gettingPrefab_8)); }
	inline GettingUI_t2926927584 * get_gettingPrefab_8() const { return ___gettingPrefab_8; }
	inline GettingUI_t2926927584 ** get_address_of_gettingPrefab_8() { return &___gettingPrefab_8; }
	inline void set_gettingPrefab_8(GettingUI_t2926927584 * value)
	{
		___gettingPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gettingPrefab_8, value);
	}

	inline static int32_t get_offset_of_showPrefab_9() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t245162495, ___showPrefab_9)); }
	inline ShowUI_t7027405 * get_showPrefab_9() const { return ___showPrefab_9; }
	inline ShowUI_t7027405 ** get_address_of_showPrefab_9() { return &___showPrefab_9; }
	inline void set_showPrefab_9(ShowUI_t7027405 * value)
	{
		___showPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___showPrefab_9, value);
	}

	inline static int32_t get_offset_of_haveChange_10() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t245162495, ___haveChange_10)); }
	inline bool get_haveChange_10() const { return ___haveChange_10; }
	inline bool* get_address_of_haveChange_10() { return &___haveChange_10; }
	inline void set_haveChange_10(bool value)
	{
		___haveChange_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
