#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.BracketContest>>
struct VP_1_t303438799;
// LP`1<GameManager.Match.Elimination.ChooseBracketContestTeamUI/UIData>
struct LP_1_t3181253950;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestHolder/UIData
struct  UIData_t588264771  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.BracketContest>> GameManager.Match.Elimination.ChooseBracketContestHolder/UIData::bracketContest
	VP_1_t303438799 * ___bracketContest_8;
	// LP`1<GameManager.Match.Elimination.ChooseBracketContestTeamUI/UIData> GameManager.Match.Elimination.ChooseBracketContestHolder/UIData::teams
	LP_1_t3181253950 * ___teams_9;

public:
	inline static int32_t get_offset_of_bracketContest_8() { return static_cast<int32_t>(offsetof(UIData_t588264771, ___bracketContest_8)); }
	inline VP_1_t303438799 * get_bracketContest_8() const { return ___bracketContest_8; }
	inline VP_1_t303438799 ** get_address_of_bracketContest_8() { return &___bracketContest_8; }
	inline void set_bracketContest_8(VP_1_t303438799 * value)
	{
		___bracketContest_8 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContest_8, value);
	}

	inline static int32_t get_offset_of_teams_9() { return static_cast<int32_t>(offsetof(UIData_t588264771, ___teams_9)); }
	inline LP_1_t3181253950 * get_teams_9() const { return ___teams_9; }
	inline LP_1_t3181253950 ** get_address_of_teams_9() { return &___teams_9; }
	inline void set_teams_9(LP_1_t3181253950 * value)
	{
		___teams_9 = value;
		Il2CppCodeGenWriteBarrier(&___teams_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
