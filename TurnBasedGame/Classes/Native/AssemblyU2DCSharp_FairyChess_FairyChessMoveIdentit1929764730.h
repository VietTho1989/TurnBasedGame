#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// System.String
struct String_t;
// NetData`1<FairyChess.FairyChessMove>
struct NetData_1_t3666427885;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessMoveIdentity
struct  FairyChessMoveIdentity_t1929764730  : public DataIdentity_t543951486
{
public:
	// System.Int32 FairyChess.FairyChessMoveIdentity::move
	int32_t ___move_17;
	// System.String FairyChess.FairyChessMoveIdentity::strMove
	String_t* ___strMove_18;
	// NetData`1<FairyChess.FairyChessMove> FairyChess.FairyChessMoveIdentity::netData
	NetData_1_t3666427885 * ___netData_19;

public:
	inline static int32_t get_offset_of_move_17() { return static_cast<int32_t>(offsetof(FairyChessMoveIdentity_t1929764730, ___move_17)); }
	inline int32_t get_move_17() const { return ___move_17; }
	inline int32_t* get_address_of_move_17() { return &___move_17; }
	inline void set_move_17(int32_t value)
	{
		___move_17 = value;
	}

	inline static int32_t get_offset_of_strMove_18() { return static_cast<int32_t>(offsetof(FairyChessMoveIdentity_t1929764730, ___strMove_18)); }
	inline String_t* get_strMove_18() const { return ___strMove_18; }
	inline String_t** get_address_of_strMove_18() { return &___strMove_18; }
	inline void set_strMove_18(String_t* value)
	{
		___strMove_18 = value;
		Il2CppCodeGenWriteBarrier(&___strMove_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(FairyChessMoveIdentity_t1929764730, ___netData_19)); }
	inline NetData_1_t3666427885 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3666427885 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3666427885 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
