#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Shogi_Common_Square188993409.h"
#include "AssemblyU2DCSharp_Shogi_Common_Piece444841494.h"

// NetData`1<Shogi.NoneRule.ShogiCustomSet>
struct NetData_1_t3423962330;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomSetIdentity
struct  ShogiCustomSetIdentity_t984522687  : public DataIdentity_t543951486
{
public:
	// Shogi.Common/Square Shogi.NoneRule.ShogiCustomSetIdentity::square
	int32_t ___square_17;
	// Shogi.Common/Piece Shogi.NoneRule.ShogiCustomSetIdentity::piece
	int32_t ___piece_18;
	// NetData`1<Shogi.NoneRule.ShogiCustomSet> Shogi.NoneRule.ShogiCustomSetIdentity::netData
	NetData_1_t3423962330 * ___netData_19;

public:
	inline static int32_t get_offset_of_square_17() { return static_cast<int32_t>(offsetof(ShogiCustomSetIdentity_t984522687, ___square_17)); }
	inline int32_t get_square_17() const { return ___square_17; }
	inline int32_t* get_address_of_square_17() { return &___square_17; }
	inline void set_square_17(int32_t value)
	{
		___square_17 = value;
	}

	inline static int32_t get_offset_of_piece_18() { return static_cast<int32_t>(offsetof(ShogiCustomSetIdentity_t984522687, ___piece_18)); }
	inline int32_t get_piece_18() const { return ___piece_18; }
	inline int32_t* get_address_of_piece_18() { return &___piece_18; }
	inline void set_piece_18(int32_t value)
	{
		___piece_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ShogiCustomSetIdentity_t984522687, ___netData_19)); }
	inline NetData_1_t3423962330 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3423962330 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3423962330 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
