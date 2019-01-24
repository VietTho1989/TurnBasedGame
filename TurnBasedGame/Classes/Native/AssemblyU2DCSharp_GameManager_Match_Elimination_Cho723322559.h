#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>>
struct VP_1_t4172034731;
// LP`1<GameManager.Match.Elimination.ChooseBracketBracketContestUI/UIData>
struct LP_1_t3031235307;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketHolder/UIData
struct  UIData_t723322559  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>> GameManager.Match.Elimination.ChooseBracketHolder/UIData::bracket
	VP_1_t4172034731 * ___bracket_8;
	// LP`1<GameManager.Match.Elimination.ChooseBracketBracketContestUI/UIData> GameManager.Match.Elimination.ChooseBracketHolder/UIData::bracketContests
	LP_1_t3031235307 * ___bracketContests_9;

public:
	inline static int32_t get_offset_of_bracket_8() { return static_cast<int32_t>(offsetof(UIData_t723322559, ___bracket_8)); }
	inline VP_1_t4172034731 * get_bracket_8() const { return ___bracket_8; }
	inline VP_1_t4172034731 ** get_address_of_bracket_8() { return &___bracket_8; }
	inline void set_bracket_8(VP_1_t4172034731 * value)
	{
		___bracket_8 = value;
		Il2CppCodeGenWriteBarrier(&___bracket_8, value);
	}

	inline static int32_t get_offset_of_bracketContests_9() { return static_cast<int32_t>(offsetof(UIData_t723322559, ___bracketContests_9)); }
	inline LP_1_t3031235307 * get_bracketContests_9() const { return ___bracketContests_9; }
	inline LP_1_t3031235307 ** get_address_of_bracketContests_9() { return &___bracketContests_9; }
	inline void set_bracketContests_9(LP_1_t3031235307 * value)
	{
		___bracketContests_9 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContests_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
