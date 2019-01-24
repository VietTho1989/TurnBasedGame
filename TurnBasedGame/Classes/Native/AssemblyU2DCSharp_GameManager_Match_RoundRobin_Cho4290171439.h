#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_SriaHolderBehavior_1_gen3683637853.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// GameManager.Match.RoundRobin.ChooseRoundContestTeamUI
struct ChooseRoundContestTeamUI_t1832203884;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestHolder
struct  ChooseRoundContestHolder_t4290171439  : public SriaHolderBehavior_1_t3683637853
{
public:
	// UnityEngine.UI.Text GameManager.Match.RoundRobin.ChooseRoundContestHolder::tvIndex
	Text_t356221433 * ___tvIndex_16;
	// UnityEngine.UI.Text GameManager.Match.RoundRobin.ChooseRoundContestHolder::tvState
	Text_t356221433 * ___tvState_17;
	// GameManager.Match.RoundRobin.ChooseRoundContestTeamUI GameManager.Match.RoundRobin.ChooseRoundContestHolder::teamPrefab
	ChooseRoundContestTeamUI_t1832203884 * ___teamPrefab_18;
	// UnityEngine.Transform GameManager.Match.RoundRobin.ChooseRoundContestHolder::teamContainer
	Transform_t3275118058 * ___teamContainer_19;

public:
	inline static int32_t get_offset_of_tvIndex_16() { return static_cast<int32_t>(offsetof(ChooseRoundContestHolder_t4290171439, ___tvIndex_16)); }
	inline Text_t356221433 * get_tvIndex_16() const { return ___tvIndex_16; }
	inline Text_t356221433 ** get_address_of_tvIndex_16() { return &___tvIndex_16; }
	inline void set_tvIndex_16(Text_t356221433 * value)
	{
		___tvIndex_16 = value;
		Il2CppCodeGenWriteBarrier(&___tvIndex_16, value);
	}

	inline static int32_t get_offset_of_tvState_17() { return static_cast<int32_t>(offsetof(ChooseRoundContestHolder_t4290171439, ___tvState_17)); }
	inline Text_t356221433 * get_tvState_17() const { return ___tvState_17; }
	inline Text_t356221433 ** get_address_of_tvState_17() { return &___tvState_17; }
	inline void set_tvState_17(Text_t356221433 * value)
	{
		___tvState_17 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_17, value);
	}

	inline static int32_t get_offset_of_teamPrefab_18() { return static_cast<int32_t>(offsetof(ChooseRoundContestHolder_t4290171439, ___teamPrefab_18)); }
	inline ChooseRoundContestTeamUI_t1832203884 * get_teamPrefab_18() const { return ___teamPrefab_18; }
	inline ChooseRoundContestTeamUI_t1832203884 ** get_address_of_teamPrefab_18() { return &___teamPrefab_18; }
	inline void set_teamPrefab_18(ChooseRoundContestTeamUI_t1832203884 * value)
	{
		___teamPrefab_18 = value;
		Il2CppCodeGenWriteBarrier(&___teamPrefab_18, value);
	}

	inline static int32_t get_offset_of_teamContainer_19() { return static_cast<int32_t>(offsetof(ChooseRoundContestHolder_t4290171439, ___teamContainer_19)); }
	inline Transform_t3275118058 * get_teamContainer_19() const { return ___teamContainer_19; }
	inline Transform_t3275118058 ** get_address_of_teamContainer_19() { return &___teamContainer_19; }
	inline void set_teamContainer_19(Transform_t3275118058 * value)
	{
		___teamContainer_19 = value;
		Il2CppCodeGenWriteBarrier(&___teamContainer_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
