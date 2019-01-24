#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<Shogi.Common/Square>
struct VP_1_t567270415;
// VP`1<Shogi.Common/Piece>
struct VP_1_t823118500;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomSet
struct  ShogiCustomSet_t3177613805  : public GameMove_t1861898997
{
public:
	// VP`1<Shogi.Common/Square> Shogi.NoneRule.ShogiCustomSet::square
	VP_1_t567270415 * ___square_5;
	// VP`1<Shogi.Common/Piece> Shogi.NoneRule.ShogiCustomSet::piece
	VP_1_t823118500 * ___piece_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(ShogiCustomSet_t3177613805, ___square_5)); }
	inline VP_1_t567270415 * get_square_5() const { return ___square_5; }
	inline VP_1_t567270415 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t567270415 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(ShogiCustomSet_t3177613805, ___piece_6)); }
	inline VP_1_t823118500 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t823118500 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t823118500 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
