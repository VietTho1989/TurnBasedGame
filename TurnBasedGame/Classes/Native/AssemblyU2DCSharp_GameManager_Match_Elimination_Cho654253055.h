#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>>
struct VP_1_t4172034731;
// VP`1<GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData>
struct VP_1_t3549621408;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestUI/UIData
struct  UIData_t654253055  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>> GameManager.Match.Elimination.ChooseBracketContestUI/UIData::bracket
	VP_1_t4172034731 * ___bracket_5;
	// VP`1<GameManager.Match.Elimination.ChooseBracketContestAdapter/UIData> GameManager.Match.Elimination.ChooseBracketContestUI/UIData::chooseBracketContestAdapter
	VP_1_t3549621408 * ___chooseBracketContestAdapter_6;

public:
	inline static int32_t get_offset_of_bracket_5() { return static_cast<int32_t>(offsetof(UIData_t654253055, ___bracket_5)); }
	inline VP_1_t4172034731 * get_bracket_5() const { return ___bracket_5; }
	inline VP_1_t4172034731 ** get_address_of_bracket_5() { return &___bracket_5; }
	inline void set_bracket_5(VP_1_t4172034731 * value)
	{
		___bracket_5 = value;
		Il2CppCodeGenWriteBarrier(&___bracket_5, value);
	}

	inline static int32_t get_offset_of_chooseBracketContestAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t654253055, ___chooseBracketContestAdapter_6)); }
	inline VP_1_t3549621408 * get_chooseBracketContestAdapter_6() const { return ___chooseBracketContestAdapter_6; }
	inline VP_1_t3549621408 ** get_address_of_chooseBracketContestAdapter_6() { return &___chooseBracketContestAdapter_6; }
	inline void set_chooseBracketContestAdapter_6(VP_1_t3549621408 * value)
	{
		___chooseBracketContestAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketContestAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
