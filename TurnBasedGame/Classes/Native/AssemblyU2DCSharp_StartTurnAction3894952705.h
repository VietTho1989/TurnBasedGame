﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameAction3938216248.h"

// VP`1<StartTurnAction/State>
struct VP_1_t264346291;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StartTurnAction
struct  StartTurnAction_t3894952705  : public GameAction_t3938216248
{
public:
	// VP`1<StartTurnAction/State> StartTurnAction::state
	VP_1_t264346291 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(StartTurnAction_t3894952705, ___state_5)); }
	inline VP_1_t264346291 * get_state_5() const { return ___state_5; }
	inline VP_1_t264346291 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t264346291 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
