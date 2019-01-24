#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen679319026.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Chess.UseRule.GetUI
struct GetUI_t1450716084;
// Chess.UseRule.GettingUI
struct GettingUI_t1821938172;
// Chess.UseRule.ShowUI
struct ShowUI_t294300077;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRuleInputUI
struct  UseRuleInputUI_t1303770429  : public UIBehavior_1_t679319026
{
public:
	// AdvancedCoroutines.Routine Chess.UseRuleInputUI::getLegalMoves
	Routine_t2502590640 * ___getLegalMoves_6;
	// Chess.UseRule.GetUI Chess.UseRuleInputUI::getPrefab
	GetUI_t1450716084 * ___getPrefab_7;
	// Chess.UseRule.GettingUI Chess.UseRuleInputUI::gettingPrefab
	GettingUI_t1821938172 * ___gettingPrefab_8;
	// Chess.UseRule.ShowUI Chess.UseRuleInputUI::showPrefab
	ShowUI_t294300077 * ___showPrefab_9;
	// System.Boolean Chess.UseRuleInputUI::haveChange
	bool ___haveChange_10;

public:
	inline static int32_t get_offset_of_getLegalMoves_6() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t1303770429, ___getLegalMoves_6)); }
	inline Routine_t2502590640 * get_getLegalMoves_6() const { return ___getLegalMoves_6; }
	inline Routine_t2502590640 ** get_address_of_getLegalMoves_6() { return &___getLegalMoves_6; }
	inline void set_getLegalMoves_6(Routine_t2502590640 * value)
	{
		___getLegalMoves_6 = value;
		Il2CppCodeGenWriteBarrier(&___getLegalMoves_6, value);
	}

	inline static int32_t get_offset_of_getPrefab_7() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t1303770429, ___getPrefab_7)); }
	inline GetUI_t1450716084 * get_getPrefab_7() const { return ___getPrefab_7; }
	inline GetUI_t1450716084 ** get_address_of_getPrefab_7() { return &___getPrefab_7; }
	inline void set_getPrefab_7(GetUI_t1450716084 * value)
	{
		___getPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___getPrefab_7, value);
	}

	inline static int32_t get_offset_of_gettingPrefab_8() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t1303770429, ___gettingPrefab_8)); }
	inline GettingUI_t1821938172 * get_gettingPrefab_8() const { return ___gettingPrefab_8; }
	inline GettingUI_t1821938172 ** get_address_of_gettingPrefab_8() { return &___gettingPrefab_8; }
	inline void set_gettingPrefab_8(GettingUI_t1821938172 * value)
	{
		___gettingPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gettingPrefab_8, value);
	}

	inline static int32_t get_offset_of_showPrefab_9() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t1303770429, ___showPrefab_9)); }
	inline ShowUI_t294300077 * get_showPrefab_9() const { return ___showPrefab_9; }
	inline ShowUI_t294300077 ** get_address_of_showPrefab_9() { return &___showPrefab_9; }
	inline void set_showPrefab_9(ShowUI_t294300077 * value)
	{
		___showPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___showPrefab_9, value);
	}

	inline static int32_t get_offset_of_haveChange_10() { return static_cast<int32_t>(offsetof(UseRuleInputUI_t1303770429, ___haveChange_10)); }
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
