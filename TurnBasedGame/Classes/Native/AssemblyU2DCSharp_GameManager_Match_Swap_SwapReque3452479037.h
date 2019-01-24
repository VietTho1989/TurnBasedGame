#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_SwapReques588127394.h"

// VP`1<GameManager.Match.Swap.SwapRequestStateAskUI/UIData/Action>
struct VP_1_t2108299121;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAskUI/UIData/StateWait
struct  StateWait_t3452479037  : public State_t588127394
{
public:
	// VP`1<GameManager.Match.Swap.SwapRequestStateAskUI/UIData/Action> GameManager.Match.Swap.SwapRequestStateAskUI/UIData/StateWait::action
	VP_1_t2108299121 * ___action_5;

public:
	inline static int32_t get_offset_of_action_5() { return static_cast<int32_t>(offsetof(StateWait_t3452479037, ___action_5)); }
	inline VP_1_t2108299121 * get_action_5() const { return ___action_5; }
	inline VP_1_t2108299121 ** get_address_of_action_5() { return &___action_5; }
	inline void set_action_5(VP_1_t2108299121 * value)
	{
		___action_5 = value;
		Il2CppCodeGenWriteBarrier(&___action_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
