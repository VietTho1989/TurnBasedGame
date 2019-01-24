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

// NetData`1<GameManager.Match.ContestManagerStatePlay>
struct NetData_1_t40292797;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerStatePlayIdentity
struct  ContestManagerStatePlayIdentity_t54579538  : public DataIdentity_t543951486
{
public:
	// System.Boolean GameManager.Match.ContestManagerStatePlayIdentity::isForceEnd
	bool ___isForceEnd_17;
	// System.Boolean GameManager.Match.ContestManagerStatePlayIdentity::randomTeamIndex
	bool ___randomTeamIndex_18;
	// GameType/Type GameManager.Match.ContestManagerStatePlayIdentity::gameTypeType
	int32_t ___gameTypeType_19;
	// NetData`1<GameManager.Match.ContestManagerStatePlay> GameManager.Match.ContestManagerStatePlayIdentity::netData
	NetData_1_t40292797 * ___netData_20;

public:
	inline static int32_t get_offset_of_isForceEnd_17() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayIdentity_t54579538, ___isForceEnd_17)); }
	inline bool get_isForceEnd_17() const { return ___isForceEnd_17; }
	inline bool* get_address_of_isForceEnd_17() { return &___isForceEnd_17; }
	inline void set_isForceEnd_17(bool value)
	{
		___isForceEnd_17 = value;
	}

	inline static int32_t get_offset_of_randomTeamIndex_18() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayIdentity_t54579538, ___randomTeamIndex_18)); }
	inline bool get_randomTeamIndex_18() const { return ___randomTeamIndex_18; }
	inline bool* get_address_of_randomTeamIndex_18() { return &___randomTeamIndex_18; }
	inline void set_randomTeamIndex_18(bool value)
	{
		___randomTeamIndex_18 = value;
	}

	inline static int32_t get_offset_of_gameTypeType_19() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayIdentity_t54579538, ___gameTypeType_19)); }
	inline int32_t get_gameTypeType_19() const { return ___gameTypeType_19; }
	inline int32_t* get_address_of_gameTypeType_19() { return &___gameTypeType_19; }
	inline void set_gameTypeType_19(int32_t value)
	{
		___gameTypeType_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(ContestManagerStatePlayIdentity_t54579538, ___netData_20)); }
	inline NetData_1_t40292797 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t40292797 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t40292797 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
