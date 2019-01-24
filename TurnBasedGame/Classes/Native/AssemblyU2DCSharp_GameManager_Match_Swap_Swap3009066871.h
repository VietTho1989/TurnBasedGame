#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<GameManager.Match.Swap.SwapRequest>
struct LP_1_t2742568078;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.Swap
struct  Swap_t3009066871  : public Data_t3569509720
{
public:
	// LP`1<GameManager.Match.Swap.SwapRequest> GameManager.Match.Swap.Swap::swapRequests
	LP_1_t2742568078 * ___swapRequests_5;

public:
	inline static int32_t get_offset_of_swapRequests_5() { return static_cast<int32_t>(offsetof(Swap_t3009066871, ___swapRequests_5)); }
	inline LP_1_t2742568078 * get_swapRequests_5() const { return ___swapRequests_5; }
	inline LP_1_t2742568078 ** get_address_of_swapRequests_5() { return &___swapRequests_5; }
	inline void set_swapRequests_5(LP_1_t2742568078 * value)
	{
		___swapRequests_5 = value;
		Il2CppCodeGenWriteBarrier(&___swapRequests_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
