#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundContest>>
struct VP_1_t1654538847;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestTeamUI/UIData
struct  UIData_t95569721  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundContest>> GameManager.Match.RoundRobin.ChooseRoundContestTeamUI/UIData::roundContest
	VP_1_t1654538847 * ___roundContest_5;
	// VP`1<System.Int32> GameManager.Match.RoundRobin.ChooseRoundContestTeamUI/UIData::teamIndex
	VP_1_t2450154454 * ___teamIndex_6;

public:
	inline static int32_t get_offset_of_roundContest_5() { return static_cast<int32_t>(offsetof(UIData_t95569721, ___roundContest_5)); }
	inline VP_1_t1654538847 * get_roundContest_5() const { return ___roundContest_5; }
	inline VP_1_t1654538847 ** get_address_of_roundContest_5() { return &___roundContest_5; }
	inline void set_roundContest_5(VP_1_t1654538847 * value)
	{
		___roundContest_5 = value;
		Il2CppCodeGenWriteBarrier(&___roundContest_5, value);
	}

	inline static int32_t get_offset_of_teamIndex_6() { return static_cast<int32_t>(offsetof(UIData_t95569721, ___teamIndex_6)); }
	inline VP_1_t2450154454 * get_teamIndex_6() const { return ___teamIndex_6; }
	inline VP_1_t2450154454 ** get_address_of_teamIndex_6() { return &___teamIndex_6; }
	inline void set_teamIndex_6(VP_1_t2450154454 * value)
	{
		___teamIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndex_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
