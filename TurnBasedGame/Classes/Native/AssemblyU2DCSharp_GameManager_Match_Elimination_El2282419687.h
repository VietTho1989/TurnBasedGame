#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>>
struct VP_1_t2596597324;
// VP`1<GameManager.Match.Elimination.BracketUI/UIData>
struct VP_1_t3381985274;
// VP`1<GameManager.Match.Elimination.ChooseBracketUI/UIData>
struct VP_1_t3230929433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationRoundUI/UIData
struct  UIData_t2282419687  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>> GameManager.Match.Elimination.EliminationRoundUI/UIData::eliminationRound
	VP_1_t2596597324 * ___eliminationRound_5;
	// VP`1<GameManager.Match.Elimination.BracketUI/UIData> GameManager.Match.Elimination.EliminationRoundUI/UIData::bracketUIData
	VP_1_t3381985274 * ___bracketUIData_6;
	// VP`1<GameManager.Match.Elimination.ChooseBracketUI/UIData> GameManager.Match.Elimination.EliminationRoundUI/UIData::chooseBracketUIData
	VP_1_t3230929433 * ___chooseBracketUIData_7;

public:
	inline static int32_t get_offset_of_eliminationRound_5() { return static_cast<int32_t>(offsetof(UIData_t2282419687, ___eliminationRound_5)); }
	inline VP_1_t2596597324 * get_eliminationRound_5() const { return ___eliminationRound_5; }
	inline VP_1_t2596597324 ** get_address_of_eliminationRound_5() { return &___eliminationRound_5; }
	inline void set_eliminationRound_5(VP_1_t2596597324 * value)
	{
		___eliminationRound_5 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRound_5, value);
	}

	inline static int32_t get_offset_of_bracketUIData_6() { return static_cast<int32_t>(offsetof(UIData_t2282419687, ___bracketUIData_6)); }
	inline VP_1_t3381985274 * get_bracketUIData_6() const { return ___bracketUIData_6; }
	inline VP_1_t3381985274 ** get_address_of_bracketUIData_6() { return &___bracketUIData_6; }
	inline void set_bracketUIData_6(VP_1_t3381985274 * value)
	{
		___bracketUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___bracketUIData_6, value);
	}

	inline static int32_t get_offset_of_chooseBracketUIData_7() { return static_cast<int32_t>(offsetof(UIData_t2282419687, ___chooseBracketUIData_7)); }
	inline VP_1_t3230929433 * get_chooseBracketUIData_7() const { return ___chooseBracketUIData_7; }
	inline VP_1_t3230929433 ** get_address_of_chooseBracketUIData_7() { return &___chooseBracketUIData_7; }
	inline void set_chooseBracketUIData_7(VP_1_t3230929433 * value)
	{
		___chooseBracketUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
