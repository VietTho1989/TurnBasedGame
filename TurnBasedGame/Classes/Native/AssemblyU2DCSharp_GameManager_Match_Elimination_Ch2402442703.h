#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen799411872.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.Elimination.ChooseBracketBracketContestUI
struct ChooseBracketBracketContestUI_t1383136231;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketHolder
struct  ChooseBracketHolder_t2402442703  : public SriaHolderBehavior_1_t799411872
{
public:
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseBracketHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseBracketHolder::tvState
	Text_t356221433 * ___tvState_17;
	// UnityEngine.UI.Text GameManager.Match.Elimination.ChooseBracketHolder::tvByes
	Text_t356221433 * ___tvByes_18;
	// GameManager.Match.Elimination.ChooseBracketBracketContestUI GameManager.Match.Elimination.ChooseBracketHolder::bracketContestPrefab
	ChooseBracketBracketContestUI_t1383136231 * ___bracketContestPrefab_19;
	// UnityEngine.Transform GameManager.Match.Elimination.ChooseBracketHolder::bracketContestContainer
	Transform_t3275118058 * ___bracketContestContainer_20;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChooseBracketHolder_t2402442703, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_tvState_17() { return static_cast<int32_t>(offsetof(ChooseBracketHolder_t2402442703, ___tvState_17)); }
	inline Text_t356221433 * get_tvState_17() const { return ___tvState_17; }
	inline Text_t356221433 ** get_address_of_tvState_17() { return &___tvState_17; }
	inline void set_tvState_17(Text_t356221433 * value)
	{
		___tvState_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_17, value);
	}

	inline static int32_t get_offset_of_tvByes_18() { return static_cast<int32_t>(offsetof(ChooseBracketHolder_t2402442703, ___tvByes_18)); }
	inline Text_t356221433 * get_tvByes_18() const { return ___tvByes_18; }
	inline Text_t356221433 ** get_address_of_tvByes_18() { return &___tvByes_18; }
	inline void set_tvByes_18(Text_t356221433 * value)
	{
		___tvByes_18 = value;
		Il2CppCodeGenWriteBarrier(&___tvByes_18, value);
	}

	inline static int32_t get_offset_of_bracketContestPrefab_19() { return static_cast<int32_t>(offsetof(ChooseBracketHolder_t2402442703, ___bracketContestPrefab_19)); }
	inline ChooseBracketBracketContestUI_t1383136231 * get_bracketContestPrefab_19() const { return ___bracketContestPrefab_19; }
	inline ChooseBracketBracketContestUI_t1383136231 ** get_address_of_bracketContestPrefab_19() { return &___bracketContestPrefab_19; }
	inline void set_bracketContestPrefab_19(ChooseBracketBracketContestUI_t1383136231 * value)
	{
		___bracketContestPrefab_19 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContestPrefab_19, value);
	}

	inline static int32_t get_offset_of_bracketContestContainer_20() { return static_cast<int32_t>(offsetof(ChooseBracketHolder_t2402442703, ___bracketContestContainer_20)); }
	inline Transform_t3275118058 * get_bracketContestContainer_20() const { return ___bracketContestContainer_20; }
	inline Transform_t3275118058 ** get_address_of_bracketContestContainer_20() { return &___bracketContestContainer_20; }
	inline void set_bracketContestContainer_20(Transform_t3275118058 * value)
	{
		___bracketContestContainer_20 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContestContainer_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
