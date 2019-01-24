#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_Shogi_Common_Square188993409.h"
#include "AssemblyU2DCSharp_Shogi_Common_Piece444841494.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.Shogi/CheckerInfo
struct  CheckerInfo_t1289645822 
{
public:
	// Shogi.Common/Square Shogi.Shogi/CheckerInfo::square
	int32_t ___square_0;
	// Shogi.Common/Piece Shogi.Shogi/CheckerInfo::piece
	int32_t ___piece_1;

public:
	inline static int32_t get_offset_of_square_0() { return static_cast<int32_t>(offsetof(CheckerInfo_t1289645822, ___square_0)); }
	inline int32_t get_square_0() const { return ___square_0; }
	inline int32_t* get_address_of_square_0() { return &___square_0; }
	inline void set_square_0(int32_t value)
	{
		___square_0 = value;
	}

	inline static int32_t get_offset_of_piece_1() { return static_cast<int32_t>(offsetof(CheckerInfo_t1289645822, ___piece_1)); }
	inline int32_t get_piece_1() const { return ___piece_1; }
	inline int32_t* get_address_of_piece_1() { return &___piece_1; }
	inline void set_piece_1(int32_t value)
	{
		___piece_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
