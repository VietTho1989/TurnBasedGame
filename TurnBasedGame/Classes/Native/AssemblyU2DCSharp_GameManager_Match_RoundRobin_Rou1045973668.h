#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RoundRobin.RoundRobin>
struct NetData_1_t4137370243;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinIdentity
struct  RoundRobinIdentity_t1045973668  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.RoundRobin.RoundRobinIdentity::index
	int32_t ___index_17;
	// NetData`1<GameManager.Match.RoundRobin.RoundRobin> GameManager.Match.RoundRobin.RoundRobinIdentity::netData
	NetData_1_t4137370243 * ___netData_18;

public:
	inline static int32_t get_offset_of_index_17() { return static_cast<int32_t>(offsetof(RoundRobinIdentity_t1045973668, ___index_17)); }
	inline int32_t get_index_17() const { return ___index_17; }
	inline int32_t* get_address_of_index_17() { return &___index_17; }
	inline void set_index_17(int32_t value)
	{
		___index_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RoundRobinIdentity_t1045973668, ___netData_18)); }
	inline NetData_1_t4137370243 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t4137370243 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t4137370243 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
