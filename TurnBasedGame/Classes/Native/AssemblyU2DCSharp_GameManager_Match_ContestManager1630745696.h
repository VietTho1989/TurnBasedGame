#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_GameType_Type2350072159.h"

// NetData`1<GameManager.Match.ContestManagerStateLobby>
struct NetData_1_t3678638419;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStateLobbyIdentity
struct  ContestManagerStateLobbyIdentity_t1630745696  : public DataIdentity_t543951486
{
public:
	// GameType/Type GameManager.Match.ContestManagerStateLobbyIdentity::gameType
	int32_t ___gameType_17;
	// System.Boolean GameManager.Match.ContestManagerStateLobbyIdentity::randomTeamIndex
	bool ___randomTeamIndex_18;
	// NetData`1<GameManager.Match.ContestManagerStateLobby> GameManager.Match.ContestManagerStateLobbyIdentity::netData
	NetData_1_t3678638419 * ___netData_19;

public:
	inline static int32_t get_offset_of_gameType_17() { return static_cast<int32_t>(offsetof(ContestManagerStateLobbyIdentity_t1630745696, ___gameType_17)); }
	inline int32_t get_gameType_17() const { return ___gameType_17; }
	inline int32_t* get_address_of_gameType_17() { return &___gameType_17; }
	inline void set_gameType_17(int32_t value)
	{
		___gameType_17 = value;
	}

	inline static int32_t get_offset_of_randomTeamIndex_18() { return static_cast<int32_t>(offsetof(ContestManagerStateLobbyIdentity_t1630745696, ___randomTeamIndex_18)); }
	inline bool get_randomTeamIndex_18() const { return ___randomTeamIndex_18; }
	inline bool* get_address_of_randomTeamIndex_18() { return &___randomTeamIndex_18; }
	inline void set_randomTeamIndex_18(bool value)
	{
		___randomTeamIndex_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ContestManagerStateLobbyIdentity_t1630745696, ___netData_19)); }
	inline NetData_1_t3678638419 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3678638419 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3678638419 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
