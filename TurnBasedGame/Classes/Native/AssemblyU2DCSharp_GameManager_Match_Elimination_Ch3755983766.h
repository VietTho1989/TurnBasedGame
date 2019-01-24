#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>>
struct VP_1_t2596597324;
// LP`1<GameManager.Match.Elimination.ChooseBracketHolder/UIData>
struct LP_1_t3756033811;
// System.Collections.Generic.List`1<GameManager.Match.Elimination.Bracket>
struct List_1_t4092095794;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketAdapter/UIData
struct  UIData_t3755983766  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>> GameManager.Match.Elimination.ChooseBracketAdapter/UIData::eliminationRound
	VP_1_t2596597324 * ___eliminationRound_20;
	// LP`1<GameManager.Match.Elimination.ChooseBracketHolder/UIData> GameManager.Match.Elimination.ChooseBracketAdapter/UIData::holders
	LP_1_t3756033811 * ___holders_21;
	// System.Collections.Generic.List`1<GameManager.Match.Elimination.Bracket> GameManager.Match.Elimination.ChooseBracketAdapter/UIData::brackets
	List_1_t4092095794 * ___brackets_22;

public:
	inline static int32_t get_offset_of_eliminationRound_20() { return static_cast<int32_t>(offsetof(UIData_t3755983766, ___eliminationRound_20)); }
	inline VP_1_t2596597324 * get_eliminationRound_20() const { return ___eliminationRound_20; }
	inline VP_1_t2596597324 ** get_address_of_eliminationRound_20() { return &___eliminationRound_20; }
	inline void set_eliminationRound_20(VP_1_t2596597324 * value)
	{
		___eliminationRound_20 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRound_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t3755983766, ___holders_21)); }
	inline LP_1_t3756033811 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3756033811 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3756033811 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_brackets_22() { return static_cast<int32_t>(offsetof(UIData_t3755983766, ___brackets_22)); }
	inline List_1_t4092095794 * get_brackets_22() const { return ___brackets_22; }
	inline List_1_t4092095794 ** get_address_of_brackets_22() { return &___brackets_22; }
	inline void set_brackets_22(List_1_t4092095794 * value)
	{
		___brackets_22 = value;
		Il2CppCodeGenWriteBarrier(&___brackets_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
