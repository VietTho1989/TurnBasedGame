﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager3076858892.h"

// LP`1<GameManager.Match.TeamResult>
struct LP_1_t2167682310;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStatePlayEnd
struct  ContestManagerStatePlayEnd_t3113360053  : public State_t3076858892
{
public:
	// LP`1<GameManager.Match.TeamResult> GameManager.Match.ContestManagerStatePlayEnd::teamResults
	LP_1_t2167682310 * ___teamResults_5;

public:
	inline static int32_t get_offset_of_teamResults_5() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayEnd_t3113360053, ___teamResults_5)); }
	inline LP_1_t2167682310 * get_teamResults_5() const { return ___teamResults_5; }
	inline LP_1_t2167682310 ** get_address_of_teamResults_5() { return &___teamResults_5; }
	inline void set_teamResults_5(LP_1_t2167682310 * value)
	{
		___teamResults_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamResults_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
