#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<TimeControl.HourGlass.PlayerTime>
struct NetData_1_t636045967;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.PlayerTimeIdentity
struct  PlayerTimeIdentity_t1816261024  : public DataIdentity_t543951486
{
public:
	// System.Int32 TimeControl.HourGlass.PlayerTimeIdentity::playerIndex
	int32_t ___playerIndex_17;
	// System.Single TimeControl.HourGlass.PlayerTimeIdentity::serverTime
	float ___serverTime_18;
	// System.Single TimeControl.HourGlass.PlayerTimeIdentity::clientTime
	float ___clientTime_19;
	// System.Single TimeControl.HourGlass.PlayerTimeIdentity::lagCompensation
	float ___lagCompensation_20;
	// NetData`1<TimeControl.HourGlass.PlayerTime> TimeControl.HourGlass.PlayerTimeIdentity::netData
	NetData_1_t636045967 * ___netData_21;

public:
	inline static int32_t get_offset_of_playerIndex_17() { return static_cast<int32_t>(offsetof(PlayerTimeIdentity_t1816261024, ___playerIndex_17)); }
	inline int32_t get_playerIndex_17() const { return ___playerIndex_17; }
	inline int32_t* get_address_of_playerIndex_17() { return &___playerIndex_17; }
	inline void set_playerIndex_17(int32_t value)
	{
		___playerIndex_17 = value;
	}

	inline static int32_t get_offset_of_serverTime_18() { return static_cast<int32_t>(offsetof(PlayerTimeIdentity_t1816261024, ___serverTime_18)); }
	inline float get_serverTime_18() const { return ___serverTime_18; }
	inline float* get_address_of_serverTime_18() { return &___serverTime_18; }
	inline void set_serverTime_18(float value)
	{
		___serverTime_18 = value;
	}

	inline static int32_t get_offset_of_clientTime_19() { return static_cast<int32_t>(offsetof(PlayerTimeIdentity_t1816261024, ___clientTime_19)); }
	inline float get_clientTime_19() const { return ___clientTime_19; }
	inline float* get_address_of_clientTime_19() { return &___clientTime_19; }
	inline void set_clientTime_19(float value)
	{
		___clientTime_19 = value;
	}

	inline static int32_t get_offset_of_lagCompensation_20() { return static_cast<int32_t>(offsetof(PlayerTimeIdentity_t1816261024, ___lagCompensation_20)); }
	inline float get_lagCompensation_20() const { return ___lagCompensation_20; }
	inline float* get_address_of_lagCompensation_20() { return &___lagCompensation_20; }
	inline void set_lagCompensation_20(float value)
	{
		___lagCompensation_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(PlayerTimeIdentity_t1816261024, ___netData_21)); }
	inline NetData_1_t636045967 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t636045967 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t636045967 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
