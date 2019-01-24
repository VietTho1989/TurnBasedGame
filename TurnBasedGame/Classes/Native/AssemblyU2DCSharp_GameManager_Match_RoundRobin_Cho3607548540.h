#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundContest>>
struct VP_1_t1654538847;
// LP`1<GameManager.Match.RoundRobin.ChooseRoundContestTeamUI/UIData>
struct LP_1_t3128280973;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestHolder/UIData
struct  UIData_t3607548540  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundContest>> GameManager.Match.RoundRobin.ChooseRoundContestHolder/UIData::roundContest
	VP_1_t1654538847 * ___roundContest_8;
	// LP`1<GameManager.Match.RoundRobin.ChooseRoundContestTeamUI/UIData> GameManager.Match.RoundRobin.ChooseRoundContestHolder/UIData::teams
	LP_1_t3128280973 * ___teams_9;

public:
	inline static int32_t get_offset_of_roundContest_8() { return static_cast<int32_t>(offsetof(UIData_t3607548540, ___roundContest_8)); }
	inline VP_1_t1654538847 * get_roundContest_8() const { return ___roundContest_8; }
	inline VP_1_t1654538847 ** get_address_of_roundContest_8() { return &___roundContest_8; }
	inline void set_roundContest_8(VP_1_t1654538847 * value)
	{
		___roundContest_8 = value;
		Il2CppCodeGenWriteBarrier(&___roundContest_8, value);
	}

	inline static int32_t get_offset_of_teams_9() { return static_cast<int32_t>(offsetof(UIData_t3607548540, ___teams_9)); }
	inline LP_1_t3128280973 * get_teams_9() const { return ___teams_9; }
	inline LP_1_t3128280973 ** get_address_of_teams_9() { return &___teams_9; }
	inline void set_teams_9(LP_1_t3128280973 * value)
	{
		___teams_9 = value;
		Il2CppCodeGenWriteBarrier(&___teams_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
