#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_SwapReque4221180567.h"

// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAccept
struct  SwapRequestStateAccept_t813819417  : public State_t4221180567
{
public:
	// VP`1<System.Single> GameManager.Match.Swap.SwapRequestStateAccept::time
	VP_1_t2454786938 * ___time_5;
	// VP`1<System.Single> GameManager.Match.Swap.SwapRequestStateAccept::duration
	VP_1_t2454786938 * ___duration_6;

public:
	inline static int32_t get_offset_of_time_5() { return static_cast<int32_t>(offsetof(SwapRequestStateAccept_t813819417, ___time_5)); }
	inline VP_1_t2454786938 * get_time_5() const { return ___time_5; }
	inline VP_1_t2454786938 ** get_address_of_time_5() { return &___time_5; }
	inline void set_time_5(VP_1_t2454786938 * value)
	{
		___time_5 = value;
		Il2CppCodeGenWriteBarrier(&___time_5, value);
	}

	inline static int32_t get_offset_of_duration_6() { return static_cast<int32_t>(offsetof(SwapRequestStateAccept_t813819417, ___duration_6)); }
	inline VP_1_t2454786938 * get_duration_6() const { return ___duration_6; }
	inline VP_1_t2454786938 ** get_address_of_duration_6() { return &___duration_6; }
	inline void set_duration_6(VP_1_t2454786938 * value)
	{
		___duration_6 = value;
		Il2CppCodeGenWriteBarrier(&___duration_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
