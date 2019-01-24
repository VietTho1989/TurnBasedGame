#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_RoundRobin_Req3981516053.h"

// VP`1<GameManager.Match.RoundRobin.RequestNewRoundRobinAskBtnCancelUI/UIData/State>
struct VP_1_t2993601577;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RequestNewRoundRobinAskBtnCancelUI/UIData
struct  UIData_t1496392043  : public Btn_t3981516053
{
public:
	// VP`1<GameManager.Match.RoundRobin.RequestNewRoundRobinAskBtnCancelUI/UIData/State> GameManager.Match.RoundRobin.RequestNewRoundRobinAskBtnCancelUI/UIData::state
	VP_1_t2993601577 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UIData_t1496392043, ___state_5)); }
	inline VP_1_t2993601577 * get_state_5() const { return ___state_5; }
	inline VP_1_t2993601577 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2993601577 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
