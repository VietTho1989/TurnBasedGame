#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen777124485.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.Elimination.ChooseEliminationRoundBracketUI
struct ChooseEliminationRoundBracketUI_t2694206578;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseEliminationRoundHolder
struct  ChooseEliminationRoundHolder_t2123455086  : public SriaHolderBehavior_1_t777124485
{
public:
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseEliminationRoundHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseEliminationRoundHolder::tvState
	Text_t356221433 * ___tvState_17;
	// GameManager.Match.Elimination.ChooseEliminationRoundBracketUI GameManager.Match.Elimination.ChooseEliminationRoundHolder::bracketPrefab
	ChooseEliminationRoundBracketUI_t2694206578 * ___bracketPrefab_18;
	// UnityEngine.Transform GameManager.Match.Elimination.ChooseEliminationRoundHolder::bracketContainer
	Transform_t3275118058 * ___bracketContainer_19;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundHolder_t2123455086, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_tvState_17() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundHolder_t2123455086, ___tvState_17)); }
	inline Text_t356221433 * get_tvState_17() const { return ___tvState_17; }
	inline Text_t356221433 ** get_address_of_tvState_17() { return &___tvState_17; }
	inline void set_tvState_17(Text_t356221433 * value)
	{
		___tvState_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_17, value);
	}

	inline static int32_t get_offset_of_bracketPrefab_18() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundHolder_t2123455086, ___bracketPrefab_18)); }
	inline ChooseEliminationRoundBracketUI_t2694206578 * get_bracketPrefab_18() const { return ___bracketPrefab_18; }
	inline ChooseEliminationRoundBracketUI_t2694206578 ** get_address_of_bracketPrefab_18() { return &___bracketPrefab_18; }
	inline void set_bracketPrefab_18(ChooseEliminationRoundBracketUI_t2694206578 * value)
	{
		___bracketPrefab_18 = value;
		Il2CppCodeGenWriteBarrier(&___bracketPrefab_18, value);
	}

	inline static int32_t get_offset_of_bracketContainer_19() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundHolder_t2123455086, ___bracketContainer_19)); }
	inline Transform_t3275118058 * get_bracketContainer_19() const { return ___bracketContainer_19; }
	inline Transform_t3275118058 ** get_address_of_bracketContainer_19() { return &___bracketContainer_19; }
	inline void set_bracketContainer_19(Transform_t3275118058 * value)
	{
		___bracketContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContainer_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
