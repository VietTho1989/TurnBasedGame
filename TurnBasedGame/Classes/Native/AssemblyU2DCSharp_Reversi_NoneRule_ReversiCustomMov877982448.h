#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Reversi.NoneRule.ReversiCustomMove>
struct NetData_1_t1195566731;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.NoneRule.ReversiCustomMoveIdentity
struct  ReversiCustomMoveIdentity_t877982448  : public DataIdentity_t543951486
{
public:
	// System.SByte Reversi.NoneRule.ReversiCustomMoveIdentity::from
	int8_t ___from_17;
	// System.SByte Reversi.NoneRule.ReversiCustomMoveIdentity::dest
	int8_t ___dest_18;
	// NetData`1<Reversi.NoneRule.ReversiCustomMove> Reversi.NoneRule.ReversiCustomMoveIdentity::netData
	NetData_1_t1195566731 * ___netData_19;

public:
	inline static int32_t get_offset_of_from_17() { return static_cast<int32_t>(offsetof(ReversiCustomMoveIdentity_t877982448, ___from_17)); }
	inline int8_t get_from_17() const { return ___from_17; }
	inline int8_t* get_address_of_from_17() { return &___from_17; }
	inline void set_from_17(int8_t value)
	{
		___from_17 = value;
	}

	inline static int32_t get_offset_of_dest_18() { return static_cast<int32_t>(offsetof(ReversiCustomMoveIdentity_t877982448, ___dest_18)); }
	inline int8_t get_dest_18() const { return ___dest_18; }
	inline int8_t* get_address_of_dest_18() { return &___dest_18; }
	inline void set_dest_18(int8_t value)
	{
		___dest_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ReversiCustomMoveIdentity_t877982448, ___netData_19)); }
	inline NetData_1_t1195566731 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1195566731 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1195566731 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
