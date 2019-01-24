#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RoundRobin>>
struct VP_1_t3340081787;
// LP`1<GameManager.Match.RoundRobin.ChooseRoundContestHolder/UIData>
struct LP_1_t2345292496;
// System.Collections.Generic.List`1<GameManager.Match.RoundContest>
struct List_1_t1574599910;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestAdapter/UIData
struct  UIData_t2196615483  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundRobin.RoundRobin>> GameManager.Match.RoundRobin.ChooseRoundContestAdapter/UIData::roundRobin
	VP_1_t3340081787 * ___roundRobin_20;
	// LP`1<GameManager.Match.RoundRobin.ChooseRoundContestHolder/UIData> GameManager.Match.RoundRobin.ChooseRoundContestAdapter/UIData::holders
	LP_1_t2345292496 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.RoundContest> GameManager.Match.RoundRobin.ChooseRoundContestAdapter/UIData::roundContests
	List_1_t1574599910 * ___roundContests_22;

public:
	inline static int32_t get_offset_of_roundRobin_20() { return static_cast<int32_t>(offsetof(UIData_t2196615483, ___roundRobin_20)); }
	inline VP_1_t3340081787 * get_roundRobin_20() const { return ___roundRobin_20; }
	inline VP_1_t3340081787 ** get_address_of_roundRobin_20() { return &___roundRobin_20; }
	inline void set_roundRobin_20(VP_1_t3340081787 * value)
	{
		___roundRobin_20 = value;
		Il2CppCodeGenWriteBarrier(&___roundRobin_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t2196615483, ___holders_21)); }
	inline LP_1_t2345292496 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t2345292496 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t2345292496 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_roundContests_22() { return static_cast<int32_t>(offsetof(UIData_t2196615483, ___roundContests_22)); }
	inline List_1_t1574599910 * get_roundContests_22() const { return ___roundContests_22; }
	inline List_1_t1574599910 ** get_address_of_roundContests_22() { return &___roundContests_22; }
	inline void set_roundContests_22(List_1_t1574599910 * value)
	{
		___roundContests_22 = value;
		Il2CppCodeGenWriteBarrier(&___roundContests_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
