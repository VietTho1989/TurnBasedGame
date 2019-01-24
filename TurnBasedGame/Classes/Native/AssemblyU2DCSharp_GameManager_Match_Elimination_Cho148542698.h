#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.BracketContest>>
struct VP_1_t303438799;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestTeamUI/UIData
struct  UIData_t148542698  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.BracketContest>> GameManager.Match.Elimination.ChooseBracketContestTeamUI/UIData::bracketContest
	VP_1_t303438799 * ___bracketContest_5;
	// VP`1<System.Int32> GameManager.Match.Elimination.ChooseBracketContestTeamUI/UIData::teamIndex
	VP_1_t2450154454 * ___teamIndex_6;

public:
	inline static int32_t get_offset_of_bracketContest_5() { return static_cast<int32_t>(offsetof(UIData_t148542698, ___bracketContest_5)); }
	inline VP_1_t303438799 * get_bracketContest_5() const { return ___bracketContest_5; }
	inline VP_1_t303438799 ** get_address_of_bracketContest_5() { return &___bracketContest_5; }
	inline void set_bracketContest_5(VP_1_t303438799 * value)
	{
		___bracketContest_5 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContest_5, value);
	}

	inline static int32_t get_offset_of_teamIndex_6() { return static_cast<int32_t>(offsetof(UIData_t148542698, ___teamIndex_6)); }
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
