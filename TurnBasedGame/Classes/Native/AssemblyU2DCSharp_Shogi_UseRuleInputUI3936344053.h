﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3638973390.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Shogi.UseRule.GetUI
struct GetUI_t595171724;
// Shogi.UseRule.GettingUI
struct GettingUI_t3176789812;
// Shogi.UseRule.ShowUI
struct ShowUI_t3736266973;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRuleInputUI
struct  UseRuleInputUI_t3936344053  : public UIBehavior_1_t3638973390
{
public:
	// AdvancedCoroutines.Routine Shogi.UseRuleInputUI::getLegalMoves
	Routine_t2502590640 * ___getLegalMoves_6;
	// Shogi.UseRule.GetUI Shogi.UseRuleInputUI::getPrefab
	GetUI_t595171724 * ___getPrefab_7;
	// Shogi.UseRule.GettingUI Shogi.UseRuleInputUI::gettingPrefab
	GettingUI_t3176789812 * ___gettingPrefab_8;
	// Shogi.UseRule.ShowUI Shogi.UseRuleInputUI::showPrefab
	ShowUI_t3736266973 * ___showPrefab_9;
	// System.Boolean Shogi.UseRuleInputUI::haveChange
	bool ___haveChange_10;

public:
	inline static int32_t get_offset_of_getLegalMoves_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3936344053, ___getLegalMoves_6)); }
	inline Routine_t2502590640 * get_getLegalMoves_6() const { return ___getLegalMoves_6; }
	inline Routine_t2502590640 ** get_address_of_getLegalMoves_6() { return &___getLegalMoves_6; }
	inline void set_getLegalMoves_6(Routine_t2502590640 * value)
	{
		___getLegalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___getLegalMoves_6, value);
	}

	inline static int32_t get_offset_of_getPrefab_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3936344053, ___getPrefab_7)); }
	inline GetUI_t595171724 * get_getPrefab_7() const { return ___getPrefab_7; }
	inline GetUI_t595171724 ** get_address_of_getPrefab_7() { return &___getPrefab_7; }
	inline void set_getPrefab_7(GetUI_t595171724 * value)
	{
		___getPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___getPrefab_7, value);
	}

	inline static int32_t get_offset_of_gettingPrefab_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3936344053, ___gettingPrefab_8)); }
	inline GettingUI_t3176789812 * get_gettingPrefab_8() const { return ___gettingPrefab_8; }
	inline GettingUI_t3176789812 ** get_address_of_gettingPrefab_8() { return &___gettingPrefab_8; }
	inline void set_gettingPrefab_8(GettingUI_t3176789812 * value)
	{
		___gettingPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gettingPrefab_8, value);
	}

	inline static int32_t get_offset_of_showPrefab_9() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3936344053, ___showPrefab_9)); }
	inline ShowUI_t3736266973 * get_showPrefab_9() const { return ___showPrefab_9; }
	inline ShowUI_t3736266973 ** get_address_of_showPrefab_9() { return &___showPrefab_9; }
	inline void set_showPrefab_9(ShowUI_t3736266973 * value)
	{
		___showPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___showPrefab_9, value);
	}

	inline static int32_t get_offset_of_haveChange_10() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t3936344053, ___haveChange_10)); }
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
