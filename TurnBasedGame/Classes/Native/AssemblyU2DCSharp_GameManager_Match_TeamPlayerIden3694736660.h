#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.TeamPlayer>
struct NetData_1_t161220659;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.TeamPlayerIdentity
struct  TeamPlayerIdentity_t3694736660  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.TeamPlayerIdentity::playerIndex
	int32_t ___playerIndex_17;
	// NetData`1<GameManager.Match.TeamPlayer> GameManager.Match.TeamPlayerIdentity::netData
	NetData_1_t161220659 * ___netData_18;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(TeamPlayerIdentity_t3694736660, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(TeamPlayerIdentity_t3694736660, ___netData_18)); }
	inline NetData_1_t161220659 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t161220659 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t161220659 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
