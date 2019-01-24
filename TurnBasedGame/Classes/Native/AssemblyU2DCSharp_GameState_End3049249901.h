#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_State3403004169.h"

// LP`1<GameState.Result>
struct LP_1_t990372079;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.End
struct  End_t3049249901  : public State_t3403004169
{
public:
	// LP`1<GameState.Result> GameState.End::results
	LP_1_t990372079 * ___results_5;

public:
	inline static int32_t get_offset_of_results_5() { return static_cast<int32_t>(offsetof(End_t3049249901, ___results_5)); }
	inline LP_1_t990372079 * get_results_5() const { return ___results_5; }
	inline LP_1_t990372079 ** get_address_of_results_5() { return &___results_5; }
	inline void set_results_5(LP_1_t990372079 * value)
	{
		___results_5 = value;
		Il2CppCodeGenWriteBarrier(&___results_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
