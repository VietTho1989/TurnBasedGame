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
// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData/State>
struct VP_1_t2660266457;
// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData>
struct VP_1_t2925723727;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData
struct  UIData_t3192788859  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_5;
	// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData/State> GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData::state
	VP_1_t2660266457 * ___state_6;
	// VP`1<GameManager.Match.Swap.AdminRequestSwapPlayerChooseHumanAdapter/UIData> GameManager.Match.Swap.AdminRequestSwapPlayerHumanUI/UIData::humanAdapter
	VP_1_t2925723727 * ___humanAdapter_7;

public:
	inline static int32_t get_offset_of_teamPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3192788859, ___teamPlayer_5)); }
	inline VP_1_t3658899499 * get_teamPlayer_5() const { return ___teamPlayer_5; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_5() { return &___teamPlayer_5; }
	inline void set_teamPlayer_5(VP_1_t3658899499 * value)
	{
		___teamPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t3192788859, ___state_6)); }
	inline VP_1_t2660266457 * get_state_6() const { return ___state_6; }
	inline VP_1_t2660266457 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2660266457 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_humanAdapter_7() { return static_cast<int32_t>(offsetof(UIData_t3192788859, ___humanAdapter_7)); }
	inline VP_1_t2925723727 * get_humanAdapter_7() const { return ___humanAdapter_7; }
	inline VP_1_t2925723727 ** get_address_of_humanAdapter_7() { return &___humanAdapter_7; }
	inline void set_humanAdapter_7(VP_1_t2925723727 * value)
	{
		___humanAdapter_7 = value;
		Il2CppCodeGenWriteBarrier(&___humanAdapter_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
