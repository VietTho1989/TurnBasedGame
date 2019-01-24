#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Chess.ChessMove>
struct NetData_1_t1917638894;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ChessMoveIdentity
struct  ChessMoveIdentity_t830257827  : public DataIdentity_t543951486
{
public:
	// System.Int32 Chess.ChessMoveIdentity::move
	int32_t ___move_17;
	// System.Boolean Chess.ChessMoveIdentity::chess960
	bool ___chess960_18;
	// NetData`1<Chess.ChessMove> Chess.ChessMoveIdentity::netData
	NetData_1_t1917638894 * ___netData_19;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(ChessMoveIdentity_t830257827, ___move_17)); }
	inline int32_t get_move_17() const { return ___move_17; }
	inline int32_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int32_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_chess960_18() { return static_cast<int32_t>(offsetof(ChessMoveIdentity_t830257827, ___chess960_18)); }
	inline bool get_chess960_18() const { return ___chess960_18; }
	inline bool* get_address_of_chess960_18() { return &___chess960_18; }
	inline void set_chess960_18(bool value)
	{
		___chess960_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ChessMoveIdentity_t830257827, ___netData_19)); }
	inline NetData_1_t1917638894 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1917638894 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1917638894 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
