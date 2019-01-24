#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Reversi.ReversiMoveAnimation>
struct NetData_1_t2567996690;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiMoveAnimationIdentity
struct  ReversiMoveAnimationIdentity_t3261476999  : public DataIdentity_t543951486
{
public:
	// System.SByte Reversi.ReversiMoveAnimationIdentity::move
	int8_t ___move_17;
	// System.UInt64 Reversi.ReversiMoveAnimationIdentity::change
	uint64_t ___change_18;
	// NetData`1<Reversi.ReversiMoveAnimation> Reversi.ReversiMoveAnimationIdentity::netData
	NetData_1_t2567996690 * ___netData_19;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(ReversiMoveAnimationIdentity_t3261476999, ___move_17)); }
	inline int8_t get_move_17() const { return ___move_17; }
	inline int8_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int8_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_change_18() { return static_cast<int32_t>(offsetof(ReversiMoveAnimationIdentity_t3261476999, ___change_18)); }
	inline uint64_t get_change_18() const { return ___change_18; }
	inline uint64_t* get_address_of_change_18() { return &___change_18; }
	inline void set_change_18(uint64_t value)
	{
		___change_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ReversiMoveAnimationIdentity_t3261476999, ___netData_19)); }
	inline NetData_1_t2567996690 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2567996690 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2567996690 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
