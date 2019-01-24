#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>>
struct VP_1_t3658899499;
// VP`1<ComputerUI/UIData>
struct VP_1_t1050701168;
// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData/State>
struct VP_1_t1478112117;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData
struct  UIData_t1989135391  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_5;
	// VP`1<ComputerUI/UIData> GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData::editComputer
	VP_1_t1050701168 * ___editComputer_6;
	// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData/State> GameManager.Match.Swap.AdminRequestSwapPlayerComputerUI/UIData::state
	VP_1_t1478112117 * ___state_7;

public:
	inline static int32_t get_offset_of_teamPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t1989135391, ___teamPlayer_5)); }
	inline VP_1_t3658899499 * get_teamPlayer_5() const { return ___teamPlayer_5; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_5() { return &___teamPlayer_5; }
	inline void set_teamPlayer_5(VP_1_t3658899499 * value)
	{
		___teamPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_5, value);
	}

	inline static int32_t get_offset_of_editComputer_6() { return static_cast<int32_t>(offsetof(UIData_t1989135391, ___editComputer_6)); }
	inline VP_1_t1050701168 * get_editComputer_6() const { return ___editComputer_6; }
	inline VP_1_t1050701168 ** get_address_of_editComputer_6() { return &___editComputer_6; }
	inline void set_editComputer_6(VP_1_t1050701168 * value)
	{
		___editComputer_6 = value;
		Il2CppCodeGenWriteBarrier(&___editComputer_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(UIData_t1989135391, ___state_7)); }
	inline VP_1_t1478112117 * get_state_7() const { return ___state_7; }
	inline VP_1_t1478112117 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t1478112117 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
