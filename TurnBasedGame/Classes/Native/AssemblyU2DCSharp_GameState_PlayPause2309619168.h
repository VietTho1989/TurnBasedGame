#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_Play_Sub1773278100.h"

// VP`1<Human>
struct VP_1_t1534365499;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayPause
struct  PlayPause_t2309619168  : public Sub_t1773278100
{
public:
	// VP`1<Human> GameState.PlayPause::human
	VP_1_t1534365499 * ___human_5;

public:
	inline static int32_t get_offset_of_human_5() { return static_cast<int32_t>(offsetof(PlayPause_t2309619168, ___human_5)); }
	inline VP_1_t1534365499 * get_human_5() const { return ___human_5; }
	inline VP_1_t1534365499 ** get_address_of_human_5() { return &___human_5; }
	inline void set_human_5(VP_1_t1534365499 * value)
	{
		___human_5 = value;
		Il2CppCodeGenWriteBarrier(&___human_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
