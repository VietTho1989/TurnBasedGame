#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>>
struct VP_1_t4172034731;
// LP`1<GameManager.Match.Elimination.ChooseBracketContestHolder/UIData>
struct LP_1_t3620976023;
// System.Collections.Generic.List`1<GameManager.Match.Elimination.BracketContest>
struct List_1_t223499862;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData
struct  UIData_t3171344402  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>> GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData::bracket
	VP_1_t4172034731 * ___bracket_20;
	// LP`1<GameManager.Match.Elimination.ChooseBracketContestHolder/UIData> GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData::holders
	LP_1_t3620976023 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.Elimination.BracketContest> GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData::bracketContests
	List_1_t223499862 * ___bracketContests_22;

public:
	inline static int32_t get_offset_of_bracket_20() { return static_cast<int32_t>(offsetof(UIData_t3171344402, ___bracket_20)); }
	inline VP_1_t4172034731 * get_bracket_20() const { return ___bracket_20; }
	inline VP_1_t4172034731 ** get_address_of_bracket_20() { return &___bracket_20; }
	inline void set_bracket_20(VP_1_t4172034731 * value)
	{
		___bracket_20 = value;
		Il2CppCodeGenWriteBarrier(&___bracket_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t3171344402, ___holders_21)); }
	inline LP_1_t3620976023 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3620976023 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3620976023 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_bracketContests_22() { return static_cast<int32_t>(offsetof(UIData_t3171344402, ___bracketContests_22)); }
	inline List_1_t223499862 * get_bracketContests_22() const { return ___bracketContests_22; }
	inline List_1_t223499862 ** get_address_of_bracketContests_22() { return &___bracketContests_22; }
	inline void set_bracketContests_22(List_1_t223499862 * value)
	{
		___bracketContests_22 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContests_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
