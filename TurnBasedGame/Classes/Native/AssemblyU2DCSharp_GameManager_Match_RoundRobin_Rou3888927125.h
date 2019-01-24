#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RoundRobin.RoundRobinContent>
struct NetData_1_t2611765732;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinContentIdentity
struct  RoundRobinContentIdentity_t3888927125  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.RoundRobin.RoundRobinContentIdentity::needReturnRound
	bool ___needReturnRound_17;
	// NetData`1<GameManager.Match.RoundRobin.RoundRobinContent> GameManager.Match.RoundRobin.RoundRobinContentIdentity::netData
	NetData_1_t2611765732 * ___netData_18;

public:
	inline static int32_t get_offset_of_needReturnRound_17() { return static_cast<int32_t>(offsetof(RoundRobinContentIdentity_t3888927125, ___needReturnRound_17)); }
	inline bool get_needReturnRound_17() const { return ___needReturnRound_17; }
	inline bool* get_address_of_needReturnRound_17() { return &___needReturnRound_17; }
	inline void set_needReturnRound_17(bool value)
	{
		___needReturnRound_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RoundRobinContentIdentity_t3888927125, ___netData_18)); }
	inline NetData_1_t2611765732 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t2611765732 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t2611765732 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
