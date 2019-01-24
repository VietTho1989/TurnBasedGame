#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_WaitAIInput_Sub998292136.h"

// VP`1<WaitAIInputSearch/State>
struct VP_1_t1064354243;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputSearch
struct  WaitAIInputSearch_t846335217  : public Sub_t998292136
{
public:
	// VP`1<WaitAIInputSearch/State> WaitAIInputSearch::state
	VP_1_t1064354243 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(WaitAIInputSearch_t846335217, ___state_5)); }
	inline VP_1_t1064354243 * get_state_5() const { return ___state_5; }
	inline VP_1_t1064354243 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1064354243 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
