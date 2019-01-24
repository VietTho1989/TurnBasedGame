#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_RequestNewRound795623277.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundHaveLimit
struct  RequestNewRoundHaveLimit_t3454006262  : public Limit_t795623277
{
public:
	// VP`1<System.Int32> GameManager.Match.RequestNewRoundHaveLimit::maxRound
	VP_1_t2450154454 * ___maxRound_5;
	// VP`1<System.Boolean> GameManager.Match.RequestNewRoundHaveLimit::enoughScoreStop
	VP_1_t4203851724 * ___enoughScoreStop_6;

public:
	inline static int32_t get_offset_of_maxRound_5() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimit_t3454006262, ___maxRound_5)); }
	inline VP_1_t2450154454 * get_maxRound_5() const { return ___maxRound_5; }
	inline VP_1_t2450154454 ** get_address_of_maxRound_5() { return &___maxRound_5; }
	inline void set_maxRound_5(VP_1_t2450154454 * value)
	{
		___maxRound_5 = value;
		Il2CppCodeGenWriteBarrier(&___maxRound_5, value);
	}

	inline static int32_t get_offset_of_enoughScoreStop_6() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimit_t3454006262, ___enoughScoreStop_6)); }
	inline VP_1_t4203851724 * get_enoughScoreStop_6() const { return ___enoughScoreStop_6; }
	inline VP_1_t4203851724 ** get_address_of_enoughScoreStop_6() { return &___enoughScoreStop_6; }
	inline void set_enoughScoreStop_6(VP_1_t4203851724 * value)
	{
		___enoughScoreStop_6 = value;
		Il2CppCodeGenWriteBarrier(&___enoughScoreStop_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
