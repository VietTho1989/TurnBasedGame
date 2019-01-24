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
// VP`1<GameManager.Match.ContestUI/UIData>
struct VP_1_t584350433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketContestUI/UIData
struct  UIData_t3796885038  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.BracketContest>> GameManager.Match.Elimination.BracketContestUI/UIData::bracketContest
	VP_1_t303438799 * ___bracketContest_5;
	// VP`1<GameManager.Match.ContestUI/UIData> GameManager.Match.Elimination.BracketContestUI/UIData::contestUIData
	VP_1_t584350433 * ___contestUIData_6;

public:
	inline static int32_t get_offset_of_bracketContest_5() { return static_cast<int32_t>(offsetof(UIData_t3796885038, ___bracketContest_5)); }
	inline VP_1_t303438799 * get_bracketContest_5() const { return ___bracketContest_5; }
	inline VP_1_t303438799 ** get_address_of_bracketContest_5() { return &___bracketContest_5; }
	inline void set_bracketContest_5(VP_1_t303438799 * value)
	{
		___bracketContest_5 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContest_5, value);
	}

	inline static int32_t get_offset_of_contestUIData_6() { return static_cast<int32_t>(offsetof(UIData_t3796885038, ___contestUIData_6)); }
	inline VP_1_t584350433 * get_contestUIData_6() const { return ___contestUIData_6; }
	inline VP_1_t584350433 ** get_address_of_contestUIData_6() { return &___contestUIData_6; }
	inline void set_contestUIData_6(VP_1_t584350433 * value)
	{
		___contestUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___contestUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
