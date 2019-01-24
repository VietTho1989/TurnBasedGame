#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.Swap.SwapRequestStateAccept>
struct NetData_1_t1060167942;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestStateAcceptIdentity
struct  SwapRequestStateAcceptIdentity_t4149724655  : public DataIdentity_t543951486
{
public:
	// System.Single GameManager.Match.Swap.SwapRequestStateAcceptIdentity::time
	float ___time_17;
	// System.Single GameManager.Match.Swap.SwapRequestStateAcceptIdentity::duration
	float ___duration_18;
	// NetData`1<GameManager.Match.Swap.SwapRequestStateAccept> GameManager.Match.Swap.SwapRequestStateAcceptIdentity::netData
	NetData_1_t1060167942 * ___netData_19;

public:
	inline static int32_t get_offset_of_time_17() { return static_cast<int32_t>(offsetof(SwapRequestStateAcceptIdentity_t4149724655, ___time_17)); }
	inline float get_time_17() const { return ___time_17; }
	inline float* get_address_of_time_17() { return &___time_17; }
	inline void set_time_17(float value)
	{
		___time_17 = value;
	}

	inline static int32_t get_offset_of_duration_18() { return static_cast<int32_t>(offsetof(SwapRequestStateAcceptIdentity_t4149724655, ___duration_18)); }
	inline float get_duration_18() const { return ___duration_18; }
	inline float* get_address_of_duration_18() { return &___duration_18; }
	inline void set_duration_18(float value)
	{
		___duration_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(SwapRequestStateAcceptIdentity_t4149724655, ___netData_19)); }
	inline NetData_1_t1060167942 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1060167942 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1060167942 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
