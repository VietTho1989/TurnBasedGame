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
// VP`1<GameManager.Match.Elimination.BracketContestUI/UIData>
struct VP_1_t4175162044;
// VP`1<GameManager.Match.Elimination.ChooseBracketContestUI/UIData>
struct VP_1_t1032530061;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketUI/UIData
struct  UIData_t3003708268  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.Bracket>> GameManager.Match.Elimination.BracketUI/UIData::bracket
	VP_1_t4172034731 * ___bracket_5;
	// VP`1<GameManager.Match.Elimination.BracketContestUI/UIData> GameManager.Match.Elimination.BracketUI/UIData::bracketContestUIData
	VP_1_t4175162044 * ___bracketContestUIData_6;
	// VP`1<GameManager.Match.Elimination.ChooseBracketContestUI/UIData> GameManager.Match.Elimination.BracketUI/UIData::chooseBracketContestUIData
	VP_1_t1032530061 * ___chooseBracketContestUIData_7;

public:
	inline static int32_t get_offset_of_bracket_5() { return static_cast<int32_t>(offsetof(UIData_t3003708268, ___bracket_5)); }
	inline VP_1_t4172034731 * get_bracket_5() const { return ___bracket_5; }
	inline VP_1_t4172034731 ** get_address_of_bracket_5() { return &___bracket_5; }
	inline void set_bracket_5(VP_1_t4172034731 * value)
	{
		___bracket_5 = value;
		Il2CppCodeGenWriteBarrier(&___bracket_5, value);
	}

	inline static int32_t get_offset_of_bracketContestUIData_6() { return static_cast<int32_t>(offsetof(UIData_t3003708268, ___bracketContestUIData_6)); }
	inline VP_1_t4175162044 * get_bracketContestUIData_6() const { return ___bracketContestUIData_6; }
	inline VP_1_t4175162044 ** get_address_of_bracketContestUIData_6() { return &___bracketContestUIData_6; }
	inline void set_bracketContestUIData_6(VP_1_t4175162044 * value)
	{
		___bracketContestUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContestUIData_6, value);
	}

	inline static int32_t get_offset_of_chooseBracketContestUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3003708268, ___chooseBracketContestUIData_7)); }
	inline VP_1_t1032530061 * get_chooseBracketContestUIData_7() const { return ___chooseBracketContestUIData_7; }
	inline VP_1_t1032530061 ** get_address_of_chooseBracketContestUIData_7() { return &___chooseBracketContestUIData_7; }
	inline void set_chooseBracketContestUIData_7(VP_1_t1032530061 * value)
	{
		___chooseBracketContestUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketContestUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
