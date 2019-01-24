#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1329445110.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAcceptUpdate
struct  SwapRequestStateAcceptUpdate_t156493044  : public UpdateBehavior_1_t1329445110
{
public:
	// AdvancedCoroutines.Routine GameManager.Match.Swap.SwapRequestStateAcceptUpdate::time
	Routine_t2502590640 * ___time_4;

public:
	inline static int32_t get_offset_of_time_4() { return static_cast<int32_t>(offsetof(SwapRequestStateAcceptUpdate_t156493044, ___time_4)); }
	inline Routine_t2502590640 * get_time_4() const { return ___time_4; }
	inline Routine_t2502590640 ** get_address_of_time_4() { return &___time_4; }
	inline void set_time_4(Routine_t2502590640 * value)
	{
		___time_4 = value;
		Il2CppCodeGenWriteBarrier(&___time_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
