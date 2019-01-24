#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<HumanConnection>
struct NetData_1_t3879105804;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanConnectionIdentity
struct  HumanConnectionIdentity_t4238878977  : public DataIdentity_t543951486
{
public:
	// System.UInt32 HumanConnectionIdentity::playerId
	uint32_t ___playerId_17;
	// NetData`1<HumanConnection> HumanConnectionIdentity::netData
	NetData_1_t3879105804 * ___netData_18;

public:
	inline static int32_t get_offset_of_playerId_17() { return static_cast<int32_t>(offsetof(HumanConnectionIdentity_t4238878977, ___playerId_17)); }
	inline uint32_t get_playerId_17() const { return ___playerId_17; }
	inline uint32_t* get_address_of_playerId_17() { return &___playerId_17; }
	inline void set_playerId_17(uint32_t value)
	{
		___playerId_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(HumanConnectionIdentity_t4238878977, ___netData_18)); }
	inline NetData_1_t3879105804 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3879105804 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3879105804 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
