#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_TimeControl_TimeControl_Use2108614994.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<TimeControl.TimeControl>
struct NetData_1_t2252944969;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.TimeControlIdentity
struct  TimeControlIdentity_t3232087810  : public DataIdentity_t543951486
{
public:
	// System.Boolean TimeControl.TimeControlIdentity::isEnable
	bool ___isEnable_17;
	// System.Boolean TimeControl.TimeControlIdentity::aiCanTimeOut
	bool ___aiCanTimeOut_18;
	// UnityEngine.Networking.SyncListInt TimeControl.TimeControlIdentity::timeOutPlayers
	SyncListInt_t3316705628 * ___timeOutPlayers_19;
	// TimeControl.TimeControl/Use TimeControl.TimeControlIdentity::use
	int32_t ___use_20;
	// NetData`1<TimeControl.TimeControl> TimeControl.TimeControlIdentity::netData
	NetData_1_t2252944969 * ___netData_21;

public:
	inline static int32_t get_offset_of_isEnable_17() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810, ___isEnable_17)); }
	inline bool get_isEnable_17() const { return ___isEnable_17; }
	inline bool* get_address_of_isEnable_17() { return &___isEnable_17; }
	inline void set_isEnable_17(bool value)
	{
		___isEnable_17 = value;
	}

	inline static int32_t get_offset_of_aiCanTimeOut_18() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810, ___aiCanTimeOut_18)); }
	inline bool get_aiCanTimeOut_18() const { return ___aiCanTimeOut_18; }
	inline bool* get_address_of_aiCanTimeOut_18() { return &___aiCanTimeOut_18; }
	inline void set_aiCanTimeOut_18(bool value)
	{
		___aiCanTimeOut_18 = value;
	}

	inline static int32_t get_offset_of_timeOutPlayers_19() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810, ___timeOutPlayers_19)); }
	inline SyncListInt_t3316705628 * get_timeOutPlayers_19() const { return ___timeOutPlayers_19; }
	inline SyncListInt_t3316705628 ** get_address_of_timeOutPlayers_19() { return &___timeOutPlayers_19; }
	inline void set_timeOutPlayers_19(SyncListInt_t3316705628 * value)
	{
		___timeOutPlayers_19 = value;
		Il2CppCodeGenWriteBarrier(&___timeOutPlayers_19, value);
	}

	inline static int32_t get_offset_of_use_20() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810, ___use_20)); }
	inline int32_t get_use_20() const { return ___use_20; }
	inline int32_t* get_address_of_use_20() { return &___use_20; }
	inline void set_use_20(int32_t value)
	{
		___use_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810, ___netData_21)); }
	inline NetData_1_t2252944969 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t2252944969 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t2252944969 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct TimeControlIdentity_t3232087810_StaticFields
{
public:
	// System.Int32 TimeControl.TimeControlIdentity::kListtimeOutPlayers
	int32_t ___kListtimeOutPlayers_22;

public:
	inline static int32_t get_offset_of_kListtimeOutPlayers_22() { return static_cast<int32_t>(offsetof(TimeControlIdentity_t3232087810_StaticFields, ___kListtimeOutPlayers_22)); }
	inline int32_t get_kListtimeOutPlayers_22() const { return ___kListtimeOutPlayers_22; }
	inline int32_t* get_address_of_kListtimeOutPlayers_22() { return &___kListtimeOutPlayers_22; }
	inline void set_kListtimeOutPlayers_22(int32_t value)
	{
		___kListtimeOutPlayers_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
