#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2790964794.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Seirawan.UseRule.GetUI
struct GetUI_t4179340408;
// Seirawan.UseRule.GettingUI
struct GettingUI_t2864561012;
// Seirawan.UseRule.ShowUI
struct ShowUI_t1598054991;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.UseRuleInputUI
struct  UseRuleInputUI_t3219778915  : public UIBehavior_1_t2790964794
{
public:
	// AdvancedCoroutines.Routine Seirawan.UseRuleInputUI::getLegalMoves
	Routine_t2502590640 * ___getLegalMoves_6;
	// Seirawan.UseRule.GetUI Seirawan.UseRuleInputUI::getPrefab
	GetUI_t4179340408 * ___getPrefab_7;
	// Seirawan.UseRule.GettingUI Seirawan.UseRuleInputUI::gettingPrefab
	GettingUI_t2864561012 * ___gettingPrefab_8;
	// Seirawan.UseRule.ShowUI Seirawan.UseRuleInputUI::showPrefab
	ShowUI_t1598054991 * ___showPrefab_9;
	// System.Boolean Seirawan.UseRuleInputUI::haveChange
	bool ___haveChange_10;

public:
	inline static int32_t get_offset_of_getLegalMoves_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3219778915, ___getLegalMoves_6)); }
	inline Routine_t2502590640 * get_getLegalMoves_6() const { return ___getLegalMoves_6; }
	inline Routine_t2502590640 ** get_address_of_getLegalMoves_6() { return &___getLegalMoves_6; }
	inline void set_getLegalMoves_6(Routine_t2502590640 * value)
	{
		___getLegalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___getLegalMoves_6, value);
	}

	inline static int32_t get_offset_of_getPrefab_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3219778915, ___getPrefab_7)); }
	inline GetUI_t4179340408 * get_getPrefab_7() const { return ___getPrefab_7; }
	inline GetUI_t4179340408 ** get_address_of_getPrefab_7() { return &___getPrefab_7; }
	inline void set_getPrefab_7(GetUI_t4179340408 * value)
	{
		___getPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___getPrefab_7, value);
	}

	inline static int32_t get_offset_of_gettingPrefab_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3219778915, ___gettingPrefab_8)); }
	inline GettingUI_t2864561012 * get_gettingPrefab_8() const { return ___gettingPrefab_8; }
	inline GettingUI_t2864561012 ** get_address_of_gettingPrefab_8() { return &___gettingPrefab_8; }
	inline void set_gettingPrefab_8(GettingUI_t2864561012 * value)
	{
		___gettingPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gettingPrefab_8, value);
	}

	inline static int32_t get_offset_of_showPrefab_9() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3219778915, ___showPrefab_9)); }
	inline ShowUI_t1598054991 * get_showPrefab_9() const { return ___showPrefab_9; }
	inline ShowUI_t1598054991 ** get_address_of_showPrefab_9() { return &___showPrefab_9; }
	inline void set_showPrefab_9(ShowUI_t1598054991 * value)
	{
		___showPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___showPrefab_9, value);
	}

	inline static int32_t get_offset_of_haveChange_10() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3219778915, ___haveChange_10)); }
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
