#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<GameManager.Match.RoundContest>
struct NetData_1_t2451827303;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundContestIdentity
struct  RoundContestIdentity_t3458946248  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.RoundRobin.RoundContestIdentity::index
	int32_t ___index_17;
	// UnityEngine.Networking.SyncListInt GameManager.Match.RoundRobin.RoundContestIdentity::teamIndexs
	SyncListInt_t3316705628 * ___teamIndexs_18;
	// NetData`1<GameManager.Match.RoundContest> GameManager.Match.RoundRobin.RoundContestIdentity::netData
	NetData_1_t2451827303 * ___netData_19;

public:
	inline static int32_t get_offset_of_index_17() { return static_cast<int32_t>(offsetof(RoundContestIdentity_t3458946248, ___index_17)); }
	inline int32_t get_index_17() const { return ___index_17; }
	inline int32_t* get_address_of_index_17() { return &___index_17; }
	inline void set_index_17(int32_t value)
	{
		___index_17 = value;
	}

	inline static int32_t get_offset_of_teamIndexs_18() { return static_cast<int32_t>(offsetof(RoundContestIdentity_t3458946248, ___teamIndexs_18)); }
	inline SyncListInt_t3316705628 * get_teamIndexs_18() const { return ___teamIndexs_18; }
	inline SyncListInt_t3316705628 ** get_address_of_teamIndexs_18() { return &___teamIndexs_18; }
	inline void set_teamIndexs_18(SyncListInt_t3316705628 * value)
	{
		___teamIndexs_18 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndexs_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RoundContestIdentity_t3458946248, ___netData_19)); }
	inline NetData_1_t2451827303 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2451827303 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2451827303 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct RoundContestIdentity_t3458946248_StaticFields
{
public:
	// System.Int32 GameManager.Match.RoundRobin.RoundContestIdentity::kListteamIndexs
	int32_t ___kListteamIndexs_20;

public:
	inline static int32_t get_offset_of_kListteamIndexs_20() { return static_cast<int32_t>(offsetof(RoundContestIdentity_t3458946248_StaticFields, ___kListteamIndexs_20)); }
	inline int32_t get_kListteamIndexs_20() const { return ___kListteamIndexs_20; }
	inline int32_t* get_address_of_kListteamIndexs_20() { return &___kListteamIndexs_20; }
	inline void set_kListteamIndexs_20(int32_t value)
	{
		___kListteamIndexs_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
