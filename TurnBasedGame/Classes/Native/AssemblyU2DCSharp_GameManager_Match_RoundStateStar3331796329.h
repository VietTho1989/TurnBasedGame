﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<GameManager.Match.RoundStateStart>
struct NetData_1_t3492469400;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundStateStartIdentity
struct  RoundStateStartIdentity_t3331796329  : public DataIdentity_t543951486
{
public:
	// NetData`1<GameManager.Match.RoundStateStart> GameManager.Match.RoundStateStartIdentity::netData
	NetData_1_t3492469400 * ___netData_17;

public:
	inline static int32_t get_offset_of_netData_17() { return static_cast<int32_t>(offsetof(RoundStateStartIdentity_t3331796329, ___netData_17)); }
	inline NetData_1_t3492469400 * get_netData_17() const { return ___netData_17; }
	inline NetData_1_t3492469400 ** get_address_of_netData_17() { return &___netData_17; }
	inline void set_netData_17(NetData_1_t3492469400 * value)
	{
		___netData_17 = value;
		Il2CppCodeGenWriteBarrier(&___netData_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif