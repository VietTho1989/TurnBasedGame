#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_State3403004169.h"

// VP`1<GameState.Start/Sub>
struct VP_1_t1266313606;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.Start
struct  Start_t2596435130  : public State_t3403004169
{
public:
	// VP`1<GameState.Start/Sub> GameState.Start::sub
	VP_1_t1266313606 * ___sub_5;

public:
	inline static int32_t get_offset_of_sub_5() { return static_cast<int32_t>(offsetof(Start_t2596435130, ___sub_5)); }
	inline VP_1_t1266313606 * get_sub_5() const { return ___sub_5; }
	inline VP_1_t1266313606 ** get_address_of_sub_5() { return &___sub_5; }
	inline void set_sub_5(VP_1_t1266313606 * value)
	{
		___sub_5 = value;
		Il2CppCodeGenWriteBarrier(&___sub_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
