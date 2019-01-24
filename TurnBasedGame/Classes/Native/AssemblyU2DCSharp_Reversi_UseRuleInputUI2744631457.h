#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3949171268.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Reversi.UseRule.GetUI
struct GetUI_t3346617768;
// Reversi.UseRule.GettingUI
struct GettingUI_t1936239540;
// Reversi.UseRule.ShowUI
struct ShowUI_t3993419365;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.UseRuleInputUI
struct  UseRuleInputUI_t2744631457  : public UIBehavior_1_t3949171268
{
public:
	// AdvancedCoroutines.Routine Reversi.UseRuleInputUI::getLegalMoves
	Routine_t2502590640 * ___getLegalMoves_6;
	// Reversi.UseRule.GetUI Reversi.UseRuleInputUI::getPrefab
	GetUI_t3346617768 * ___getPrefab_7;
	// Reversi.UseRule.GettingUI Reversi.UseRuleInputUI::gettingPrefab
	GettingUI_t1936239540 * ___gettingPrefab_8;
	// Reversi.UseRule.ShowUI Reversi.UseRuleInputUI::showPrefab
	ShowUI_t3993419365 * ___showPrefab_9;
	// System.Boolean Reversi.UseRuleInputUI::haveChange
	bool ___haveChange_10;

public:
	inline static int32_t get_offset_of_getLegalMoves_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t2744631457, ___getLegalMoves_6)); }
	inline Routine_t2502590640 * get_getLegalMoves_6() const { return ___getLegalMoves_6; }
	inline Routine_t2502590640 ** get_address_of_getLegalMoves_6() { return &___getLegalMoves_6; }
	inline void set_getLegalMoves_6(Routine_t2502590640 * value)
	{
		___getLegalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___getLegalMoves_6, value);
	}

	inline static int32_t get_offset_of_getPrefab_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t2744631457, ___getPrefab_7)); }
	inline GetUI_t3346617768 * get_getPrefab_7() const { return ___getPrefab_7; }
	inline GetUI_t3346617768 ** get_address_of_getPrefab_7() { return &___getPrefab_7; }
	inline void set_getPrefab_7(GetUI_t3346617768 * value)
	{
		___getPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___getPrefab_7, value);
	}

	inline static int32_t get_offset_of_gettingPrefab_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t2744631457, ___gettingPrefab_8)); }
	inline GettingUI_t1936239540 * get_gettingPrefab_8() const { return ___gettingPrefab_8; }
	inline GettingUI_t1936239540 ** get_address_of_gettingPrefab_8() { return &___gettingPrefab_8; }
	inline void set_gettingPrefab_8(GettingUI_t1936239540 * value)
	{
		___gettingPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gettingPrefab_8, value);
	}

	inline static int32_t get_offset_of_showPrefab_9() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t2744631457, ___showPrefab_9)); }
	inline ShowUI_t3993419365 * get_showPrefab_9() const { return ___showPrefab_9; }
	inline ShowUI_t3993419365 ** get_address_of_showPrefab_9() { return &___showPrefab_9; }
	inline void set_showPrefab_9(ShowUI_t3993419365 * value)
	{
		___showPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___showPrefab_9, value);
	}

	inline static int32_t get_offset_of_haveChange_10() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t2744631457, ___haveChange_10)); }
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
