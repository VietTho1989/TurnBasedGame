#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// NetData`1<GameManager.Match.RequestNewRoundStateAsk>
struct NetData_1_t3625227728;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundStateAskIdentity
struct  RequestNewRoundStateAskIdentity_t1630900773  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListUInt GameManager.Match.RequestNewRoundStateAskIdentity::accepts
	SyncListUInt_t2190275715 * ___accepts_17;
	// NetData`1<GameManager.Match.RequestNewRoundStateAsk> GameManager.Match.RequestNewRoundStateAskIdentity::netData
	NetData_1_t3625227728 * ___netData_18;

public:
	inline static int32_t get_offset_of_accepts_17() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskIdentity_t1630900773, ___accepts_17)); }
	inline SyncListUInt_t2190275715 * get_accepts_17() const { return ___accepts_17; }
	inline SyncListUInt_t2190275715 ** get_address_of_accepts_17() { return &___accepts_17; }
	inline void set_accepts_17(SyncListUInt_t2190275715 * value)
	{
		___accepts_17 = value;
		Il2CppCodeGenWriteBarrier(&___accepts_17, value);
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskIdentity_t1630900773, ___netData_18)); }
	inline NetData_1_t3625227728 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t3625227728 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t3625227728 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

struct RequestNewRoundStateAskIdentity_t1630900773_StaticFields
{
public:
	// System.Int32 GameManager.Match.RequestNewRoundStateAskIdentity::kListaccepts
	int32_t ___kListaccepts_19;

public:
	inline static int32_t get_offset_of_kListaccepts_19() { return static_cast<int32_t>(offsetof(RequestNewRoundStateAskIdentity_t1630900773_StaticFields, ___kListaccepts_19)); }
	inline int32_t get_kListaccepts_19() const { return ___kListaccepts_19; }
	inline int32_t* get_address_of_kListaccepts_19() { return &___kListaccepts_19; }
	inline void set_kListaccepts_19(int32_t value)
	{
		___kListaccepts_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
