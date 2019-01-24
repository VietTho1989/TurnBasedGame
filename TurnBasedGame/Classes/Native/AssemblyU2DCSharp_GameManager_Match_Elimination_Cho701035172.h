#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>>
struct VP_1_t2596597324;
// LP`1<GameManager.Match.Elimination.ChooseEliminationRoundBracketUI/UIData>
struct LP_1_t1877119306;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseEliminationRoundHolder/UIData
struct  UIData_t701035172  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>> GameManager.Match.Elimination.ChooseEliminationRoundHolder/UIData::eliminationRound
	VP_1_t2596597324 * ___eliminationRound_8;
	// LP`1<GameManager.Match.Elimination.ChooseEliminationRoundBracketUI/UIData> GameManager.Match.Elimination.ChooseEliminationRoundHolder/UIData::brackets
	LP_1_t1877119306 * ___brackets_9;

public:
	inline static int32_t get_offset_of_eliminationRound_8() { return static_cast<int32_t>(offsetof(UIData_t701035172, ___eliminationRound_8)); }
	inline VP_1_t2596597324 * get_eliminationRound_8() const { return ___eliminationRound_8; }
	inline VP_1_t2596597324 ** get_address_of_eliminationRound_8() { return &___eliminationRound_8; }
	inline void set_eliminationRound_8(VP_1_t2596597324 * value)
	{
		___eliminationRound_8 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRound_8, value);
	}

	inline static int32_t get_offset_of_brackets_9() { return static_cast<int32_t>(offsetof(UIData_t701035172, ___brackets_9)); }
	inline LP_1_t1877119306 * get_brackets_9() const { return ___brackets_9; }
	inline LP_1_t1877119306 ** get_address_of_brackets_9() { return &___brackets_9; }
	inline void set_brackets_9(LP_1_t1877119306 * value)
	{
		___brackets_9 = value;
		Il2CppCodeGenWriteBarrier(&___brackets_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
