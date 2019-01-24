#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_TypingPlayer_State988376424.h"

// NetData`1<TypingPlayer>
struct NetData_1_t3380185883;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingPlayerIdentity
struct  TypingPlayerIdentity_t2109931436  : public DataIdentity_t543951486
{
public:
	// System.UInt32 TypingPlayerIdentity::playerId
	uint32_t ___playerId_17;
	// TypingPlayer/State TypingPlayerIdentity::state
	int32_t ___state_18;
	// NetData`1<TypingPlayer> TypingPlayerIdentity::netData
	NetData_1_t3380185883 * ___netData_19;

public:
	inline static int32_t get_offset_of_playerId_17() { return static_cast<int32_t>(offsetof(TypingPlayerIdentity_t2109931436, ___playerId_17)); }
	inline uint32_t get_playerId_17() const { return ___playerId_17; }
	inline uint32_t* get_address_of_playerId_17() { return &___playerId_17; }
	inline void set_playerId_17(uint32_t value)
	{
		___playerId_17 = value;
	}

	inline static int32_t get_offset_of_state_18() { return static_cast<int32_t>(offsetof(TypingPlayerIdentity_t2109931436, ___state_18)); }
	inline int32_t get_state_18() const { return ___state_18; }
	inline int32_t* get_address_of_state_18() { return &___state_18; }
	inline void set_state_18(int32_t value)
	{
		___state_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(TypingPlayerIdentity_t2109931436, ___netData_19)); }
	inline NetData_1_t3380185883 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3380185883 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3380185883 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
