﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.SingleContestFactory>
struct NetData_1_t1344448173;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestFactoryIdentity
struct  SingleContestFactoryIdentity_t324225274  : public DataIdentity_t543951486
{
public:
	// System.Int32 GameManager.Match.SingleContestFactoryIdentity::playerPerTeam
	int32_t ___playerPerTeam_17;
	// NetData`1<GameManager.Match.SingleContestFactory> GameManager.Match.SingleContestFactoryIdentity::netData
	NetData_1_t1344448173 * ___netData_18;

public:
	inline static int32_t get_offset_of_playerPerTeam_17() { return static_cast<int32_t>(offsetof(SingleContestFactoryIdentity_t324225274, ___playerPerTeam_17)); }
	inline int32_t get_playerPerTeam_17() const { return ___playerPerTeam_17; }
	inline int32_t* get_address_of_playerPerTeam_17() { return &___playerPerTeam_17; }
	inline void set_playerPerTeam_17(int32_t value)
	{
		___playerPerTeam_17 = value;
	}

	inline static int32_t get_offset_of_netData_18() { return static_cast<int32_t>(offsetof(SingleContestFactoryIdentity_t324225274, ___netData_18)); }
	inline NetData_1_t1344448173 * get_netData_18() const { return ___netData_18; }
	inline NetData_1_t1344448173 ** get_address_of_netData_18() { return &___netData_18; }
	inline void set_netData_18(NetData_1_t1344448173 * value)
	{
		___netData_18 = value;
		Il2CppCodeGenWriteBarrier(&___netData_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif