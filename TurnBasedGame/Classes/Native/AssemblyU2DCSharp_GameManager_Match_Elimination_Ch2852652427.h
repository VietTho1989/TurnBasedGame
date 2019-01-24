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
// VP`1<GameManager.Match.Elimination.ChooseBracketAdapter/UIData>
struct VP_1_t4134260772;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketUI/UIData
struct  UIData_t2852652427  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.Elimination.EliminationRound>> GameManager.Match.Elimination.ChooseBracketUI/UIData::eliminationRound
	VP_1_t2596597324 * ___eliminationRound_5;
	// VP`1<GameManager.Match.Elimination.ChooseBracketAdapter/UIData> GameManager.Match.Elimination.ChooseBracketUI/UIData::chooseBracketAdapter
	VP_1_t4134260772 * ___chooseBracketAdapter_6;

public:
	inline static int32_t get_offset_of_eliminationRound_5() { return static_cast<int32_t>(offsetof(UIData_t2852652427, ___eliminationRound_5)); }
	inline VP_1_t2596597324 * get_eliminationRound_5() const { return ___eliminationRound_5; }
	inline VP_1_t2596597324 ** get_address_of_eliminationRound_5() { return &___eliminationRound_5; }
	inline void set_eliminationRound_5(VP_1_t2596597324 * value)
	{
		___eliminationRound_5 = value;
		Il2CppCodeGenWriteBarrier(&___eliminationRound_5, value);
	}

	inline static int32_t get_offset_of_chooseBracketAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t2852652427, ___chooseBracketAdapter_6)); }
	inline VP_1_t4134260772 * get_chooseBracketAdapter_6() const { return ___chooseBracketAdapter_6; }
	inline VP_1_t4134260772 ** get_address_of_chooseBracketAdapter_6() { return &___chooseBracketAdapter_6; }
	inline void set_chooseBracketAdapter_6(VP_1_t4134260772 * value)
	{
		___chooseBracketAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseBracketAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
