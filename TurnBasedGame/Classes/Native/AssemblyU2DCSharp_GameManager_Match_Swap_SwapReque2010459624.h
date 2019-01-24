#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.Swap.SwapRequest>
struct NetData_1_t4251172647;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapRequestIdentity
struct  SwapRequestIdentity_t2010459624  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.Swap.SwapRequestIdentity::teamIndex
	int32_t ___teamIndex_17;
	// System.Int32 GameManager.Match.Swap.SwapRequestIdentity::playerIndex
	int32_t ___playerIndex_18;
	// NetData`1<GameManager.Match.Swap.SwapRequest> GameManager.Match.Swap.SwapRequestIdentity::netData
	NetData_1_t4251172647 * ___netData_19;

public:
	inline static int32_t get_offset_of_teamIndex_17() { return static_cast<int32_t>(offsetof(SwapRequestIdentity_t2010459624, ___teamIndex_17)); }
	inline int32_t get_teamIndex_17() const { return ___teamIndex_17; }
	inline int32_t* get_address_of_teamIndex_17() { return &___teamIndex_17; }
	inline void set_teamIndex_17(int32_t value)
	{
		___teamIndex_17 = value;
	}

	inline static int32_t get_offset_of_playerIndex_18() { return static_cast<int32_t>(offsetof(SwapRequestIdentity_t2010459624, ___playerIndex_18)); }
	inline int32_t get_playerIndex_18() const { return ___playerIndex_18; }
	inline int32_t* get_address_of_playerIndex_18() { return &___playerIndex_18; }
	inline void set_playerIndex_18(int32_t value)
	{
		___playerIndex_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(SwapRequestIdentity_t2010459624, ___netData_19)); }
	inline NetData_1_t4251172647 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t4251172647 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t4251172647 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
