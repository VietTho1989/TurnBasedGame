﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Gomoku.NoneRule.GomokuCustomMove>
struct NetData_1_t3160217523;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.NoneRule.GomokuCustomMoveIdentity
struct  GomokuCustomMoveIdentity_t1090269816  : public DataIdentity_t543951486
{
public:
	// System.Int32 Gomoku.NoneRule.GomokuCustomMoveIdentity::from
	int32_t ___from_17;
	// System.Int32 Gomoku.NoneRule.GomokuCustomMoveIdentity::dest
	int32_t ___dest_18;
	// NetData`1<Gomoku.NoneRule.GomokuCustomMove> Gomoku.NoneRule.GomokuCustomMoveIdentity::netData
	NetData_1_t3160217523 * ___netData_19;

public:
	inline static int32_t get_offset_of_from_17() { return static_cast<int32_t>(offsetof(GomokuCustomMoveIdentity_t1090269816, ___from_17)); }
	inline int32_t get_from_17() const { return ___from_17; }
	inline int32_t* get_address_of_from_17() { return &___from_17; }
	inline void set_from_17(int32_t value)
	{
		___from_17 = value;
	}

	inline static int32_t get_offset_of_dest_18() { return static_cast<int32_t>(offsetof(GomokuCustomMoveIdentity_t1090269816, ___dest_18)); }
	inline int32_t get_dest_18() const { return ___dest_18; }
	inline int32_t* get_address_of_dest_18() { return &___dest_18; }
	inline void set_dest_18(int32_t value)
	{
		___dest_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(GomokuCustomMoveIdentity_t1090269816, ___netData_19)); }
	inline NetData_1_t3160217523 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3160217523 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3160217523 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
