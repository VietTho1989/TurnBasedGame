#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_SwapReque4221180567.h"

// LP`1<Human>
struct LP_1_t4188799745;
// LP`1<System.UInt32>
struct LP_1_t887425977;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAsk
struct  SwapRequestStateAsk_t95620752  : public State_t4221180567
{
public:
	// LP`1<Human> GameManager.Match.Swap.SwapRequestStateAsk::whoCanAsks
	LP_1_t4188799745 * ___whoCanAsks_5;
	// LP`1<System.UInt32> GameManager.Match.Swap.SwapRequestStateAsk::accepts
	LP_1_t887425977 * ___accepts_6;

public:
	inline static int32_t get_offset_of_whoCanAsks_5() { return static_cast<int32_t>(offsetof(SwapRequestStateAsk_t95620752, ___whoCanAsks_5)); }
	inline LP_1_t4188799745 * get_whoCanAsks_5() const { return ___whoCanAsks_5; }
	inline LP_1_t4188799745 ** get_address_of_whoCanAsks_5() { return &___whoCanAsks_5; }
	inline void set_whoCanAsks_5(LP_1_t4188799745 * value)
	{
		___whoCanAsks_5 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAsks_5, value);
	}

	inline static int32_t get_offset_of_accepts_6() { return static_cast<int32_t>(offsetof(SwapRequestStateAsk_t95620752, ___accepts_6)); }
	inline LP_1_t887425977 * get_accepts_6() const { return ___accepts_6; }
	inline LP_1_t887425977 ** get_address_of_accepts_6() { return &___accepts_6; }
	inline void set_accepts_6(LP_1_t887425977 * value)
	{
		___accepts_6 = value;
		Il2CppCodeGenWriteBarrier(&___accepts_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
