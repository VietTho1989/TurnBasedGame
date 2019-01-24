#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1566494539.h"

// GameManager.Match.Elimination.BracketUI
struct BracketUI_t128116854;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameManager.Match.Elimination.ChooseBracketUI
struct ChooseBracketUI_t3302956931;
// RoomUI/UIData
struct UIData_t2598208972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationRoundUI
struct  EliminationRoundUI_t1345130477  : public UIBehavior_1_t1566494539
{
public:
	// GameManager.Match.Elimination.BracketUI GameManager.Match.Elimination.EliminationRoundUI::bracketPrefab
	BracketUI_t128116854 * ___bracketPrefab_6;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationRoundUI::bracketContainer
	Transform_t3275118058 * ___bracketContainer_7;
	// GameManager.Match.Elimination.ChooseBracketUI GameManager.Match.Elimination.EliminationRoundUI::chooseBracketPrefab
	ChooseBracketUI_t3302956931 * ___chooseBracketPrefab_8;
	// UnityEngine.Transform GameManager.Match.Elimination.EliminationRoundUI::chooseBracketContainer
	Transform_t3275118058 * ___chooseBracketContainer_9;
	// RoomUI/UIData GameManager.Match.Elimination.EliminationRoundUI::roomUIData
	UIData_t2598208972 * ___roomUIData_10;

public:
	inline static int32_t get_offset_of_bracketPrefab_6() { return static_cast<int32_t>(offsetof(EliminationRoundUI_t1345130477, ___bracketPrefab_6)); }
	inline BracketUI_t128116854 * get_bracketPrefab_6() const { return ___bracketPrefab_6; }
	inline BracketUI_t128116854 ** get_address_of_bracketPrefab_6() { return &___bracketPrefab_6; }
	inline void set_bracketPrefab_6(BracketUI_t128116854 * value)
	{
		___bracketPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___bracketPrefab_6, value);
	}

	inline static int32_t get_offset_of_bracketContainer_7() { return static_cast<int32_t>(offsetof(EliminationRoundUI_t1345130477, ___bracketContainer_7)); }
	inline Transform_t3275118058 * get_bracketContainer_7() const { return ___bracketContainer_7; }
	inline Transform_t3275118058 ** get_address_of_bracketContainer_7() { return &___bracketContainer_7; }
	inline void set_bracketContainer_7(Transform_t3275118058 * value)
	{
		___bracketContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContainer_7, value);
	}

	inline static int32_t get_offset_of_chooseBracketPrefab_8() { return static_cast<int32_t>(offsetof(EliminationRoundUI_t1345130477, ___chooseBracketPrefab_8)); }
	inline ChooseBracketUI_t3302956931 * get_chooseBracketPrefab_8() const { return ___chooseBracketPrefab_8; }
	inline ChooseBracketUI_t3302956931 ** get_address_of_chooseBracketPrefab_8() { return &___chooseBracketPrefab_8; }
	inline void set_chooseBracketPrefab_8(ChooseBracketUI_t3302956931 * value)
	{
		___chooseBracketPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketPrefab_8, value);
	}

	inline static int32_t get_offset_of_chooseBracketContainer_9() { return static_cast<int32_t>(offsetof(EliminationRoundUI_t1345130477, ___chooseBracketContainer_9)); }
	inline Transform_t3275118058 * get_chooseBracketContainer_9() const { return ___chooseBracketContainer_9; }
	inline Transform_t3275118058 ** get_address_of_chooseBracketContainer_9() { return &___chooseBracketContainer_9; }
	inline void set_chooseBracketContainer_9(Transform_t3275118058 * value)
	{
		___chooseBracketContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketContainer_9, value);
	}

	inline static int32_t get_offset_of_roomUIData_10() { return static_cast<int32_t>(offsetof(EliminationRoundUI_t1345130477, ___roomUIData_10)); }
	inline UIData_t2598208972 * get_roomUIData_10() const { return ___roomUIData_10; }
	inline UIData_t2598208972 ** get_address_of_roomUIData_10() { return &___roomUIData_10; }
	inline void set_roomUIData_10(UIData_t2598208972 * value)
	{
		___roomUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___roomUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
