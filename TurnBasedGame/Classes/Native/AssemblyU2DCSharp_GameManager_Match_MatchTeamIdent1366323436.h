#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.MatchTeam>
struct NetData_1_t3625920195;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.MatchTeamIdentity
struct  MatchTeamIdentity_t1366323436  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.MatchTeamIdentity::teamIndex
	int32_t ___teamIndex_17;
	// NetData`1<GameManager.Match.MatchTeam> GameManager.Match.MatchTeamIdentity::netData
	NetData_1_t3625920195 * ___netData_18;

public:
	inline static int32_t get_offset_of_teamIndex_17() { return static_cast<int32_t>(offsetof(MatchTeamIdentity_t1366323436, ___teamIndex_17)); }
	inline int32_t get_teamIndex_17() const { return ___teamIndex_17; }
	inline int32_t* get_address_of_teamIndex_17() { return &___teamIndex_17; }
	inline void set_teamIndex_17(int32_t value)
	{
		___teamIndex_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(MatchTeamIdentity_t1366323436, ___netData_18)); }
	inline NetData_1_t3625920195 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3625920195 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3625920195 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
