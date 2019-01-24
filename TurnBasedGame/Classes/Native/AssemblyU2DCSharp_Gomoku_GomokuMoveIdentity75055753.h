#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Gomoku.GomokuMove>
struct NetData_1_t535415024;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuMoveIdentity
struct  GomokuMoveIdentity_t75055753  : public DataIdentity_t543951486
{
public:
	// System.Int32 Gomoku.GomokuMoveIdentity::move
	int32_t ___move_17;
	// System.Int32 Gomoku.GomokuMoveIdentity::boardSize
	int32_t ___boardSize_18;
	// NetData`1<Gomoku.GomokuMove> Gomoku.GomokuMoveIdentity::netData
	NetData_1_t535415024 * ___netData_19;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(GomokuMoveIdentity_t75055753, ___move_17)); }
	inline int32_t get_move_17() const { return ___move_17; }
	inline int32_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int32_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_boardSize_18() { return static_cast<int32_t>(offsetof(GomokuMoveIdentity_t75055753, ___boardSize_18)); }
	inline int32_t get_boardSize_18() const { return ___boardSize_18; }
	inline int32_t* get_address_of_boardSize_18() { return &___boardSize_18; }
	inline void set_boardSize_18(int32_t value)
	{
		___boardSize_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(GomokuMoveIdentity_t75055753, ___netData_19)); }
	inline NetData_1_t535415024 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t535415024 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t535415024 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
