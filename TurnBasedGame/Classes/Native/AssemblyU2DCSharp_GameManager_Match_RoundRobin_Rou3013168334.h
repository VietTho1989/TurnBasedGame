#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RoundRobin.RoundRobinFactory>
struct NetData_1_t1140427969;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinFactoryIdentity
struct  RoundRobinFactoryIdentity_t3013168334  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.RoundRobin.RoundRobinFactoryIdentity::teamCount
	int32_t ___teamCount_17;
	// System.Boolean GameManager.Match.RoundRobin.RoundRobinFactoryIdentity::needReturnRound
	bool ___needReturnRound_18;
	// NetData`1<GameManager.Match.RoundRobin.RoundRobinFactory> GameManager.Match.RoundRobin.RoundRobinFactoryIdentity::netData
	NetData_1_t1140427969 * ___netData_19;

public:
	inline static int32_t get_offset_of_teamCount_17() { return static_cast<int32_t>(offsetof(RoundRobinFactoryIdentity_t3013168334, ___teamCount_17)); }
	inline int32_t get_teamCount_17() const { return ___teamCount_17; }
	inline int32_t* get_address_of_teamCount_17() { return &___teamCount_17; }
	inline void set_teamCount_17(int32_t value)
	{
		___teamCount_17 = value;
	}

	inline static int32_t get_offset_of_needReturnRound_18() { return static_cast<int32_t>(offsetof(RoundRobinFactoryIdentity_t3013168334, ___needReturnRound_18)); }
	inline bool get_needReturnRound_18() const { return ___needReturnRound_18; }
	inline bool* get_address_of_needReturnRound_18() { return &___needReturnRound_18; }
	inline void set_needReturnRound_18(bool value)
	{
		___needReturnRound_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RoundRobinFactoryIdentity_t3013168334, ___netData_19)); }
	inline NetData_1_t1140427969 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1140427969 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1140427969 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
