﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Turn>
struct NetData_1_t99096208;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TurnIdentity
struct  TurnIdentity_t2726475789  : public DataIdentity_t543951486
{
public:
	// System.Int32 TurnIdentity::turn
	int32_t ___turn_17;
	// System.Int32 TurnIdentity::playerIndex
	int32_t ___playerIndex_18;
	// System.Int32 TurnIdentity::gameTurn
	int32_t ___gameTurn_19;
	// NetData`1<Turn> TurnIdentity::netData
	NetData_1_t99096208 * ___netData_20;

public:
	inline static int32_t get_offset_of_turn_17() { return static_cast<int32_t>(offsetof(TurnIdentity_t2726475789, ___turn_17)); }
	inline int32_t get_turn_17() const { return ___turn_17; }
	inline int32_t* get_address_of_turn_17() { return &___turn_17; }
	inline void set_turn_17(int32_t value)
	{
		___turn_17 = value;
	}

	inline static int32_t get_offset_of_playerIndex_18() { return static_cast<int32_t>(offsetof(TurnIdentity_t2726475789, ___playerIndex_18)); }
	inline int32_t get_playerIndex_18() const { return ___playerIndex_18; }
	inline int32_t* get_address_of_playerIndex_18() { return &___playerIndex_18; }
	inline void set_playerIndex_18(int32_t value)
	{
		___playerIndex_18 = value;
	}

	inline static int32_t get_offset_of_gameTurn_19() { return static_cast<int32_t>(offsetof(TurnIdentity_t2726475789, ___gameTurn_19)); }
	inline int32_t get_gameTurn_19() const { return ___gameTurn_19; }
	inline int32_t* get_address_of_gameTurn_19() { return &___gameTurn_19; }
	inline void set_gameTurn_19(int32_t value)
	{
		___gameTurn_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(TurnIdentity_t2726475789, ___netData_20)); }
	inline NetData_1_t99096208 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t99096208 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t99096208 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif