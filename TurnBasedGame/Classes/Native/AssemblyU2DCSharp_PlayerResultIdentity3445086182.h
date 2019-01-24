#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<PlayerResult>
struct NetData_1_t3604809425;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayerResultIdentity
struct  PlayerResultIdentity_t3445086182  : public DataIdentity_t543951486
{
public:
	// System.Int32 PlayerResultIdentity::playerIndex
	int32_t ___playerIndex_17;
	// System.Single PlayerResultIdentity::score
	float ___score_18;
	// NetData`1<PlayerResult> PlayerResultIdentity::netData
	NetData_1_t3604809425 * ___netData_19;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(PlayerResultIdentity_t3445086182, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_score_18() { return static_cast<int32_t>(offsetof(PlayerResultIdentity_t3445086182, ___score_18)); }
	inline float get_score_18() const { return ___score_18; }
	inline float* get_address_of_score_18() { return &___score_18; }
	inline void set_score_18(float value)
	{
		___score_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(PlayerResultIdentity_t3445086182, ___netData_19)); }
	inline NetData_1_t3604809425 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3604809425 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3604809425 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
