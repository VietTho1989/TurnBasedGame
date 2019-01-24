#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<ViewPlayer>
struct NetData_1_t2432141253;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ViewPlayerIdentity
struct  ViewPlayerIdentity_t133948054  : public DataIdentity_t543951486
{
public:
	// System.UInt32 ViewPlayerIdentity::playerId
	uint32_t ___playerId_17;
	// System.Single ViewPlayerIdentity::time
	float ___time_18;
	// NetData`1<ViewPlayer> ViewPlayerIdentity::netData
	NetData_1_t2432141253 * ___netData_19;

public:
	inline static int32_t get_offset_of_playerId_17() { return static_cast<int32_t>(offsetof(ViewPlayerIdentity_t133948054, ___playerId_17)); }
	inline uint32_t get_playerId_17() const { return ___playerId_17; }
	inline uint32_t* get_address_of_playerId_17() { return &___playerId_17; }
	inline void set_playerId_17(uint32_t value)
	{
		___playerId_17 = value;
	}

	inline static int32_t get_offset_of_time_18() { return static_cast<int32_t>(offsetof(ViewPlayerIdentity_t133948054, ___time_18)); }
	inline float get_time_18() const { return ___time_18; }
	inline float* get_address_of_time_18() { return &___time_18; }
	inline void set_time_18(float value)
	{
		___time_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ViewPlayerIdentity_t133948054, ___netData_19)); }
	inline NetData_1_t2432141253 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2432141253 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2432141253 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
