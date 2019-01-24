#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<Chess.Common/Piece>
struct VP_1_t3663429032;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.NoneRule.ChessCustomSet
struct  ChessCustomSet_t3667489137  : public GameMove_t1861898997
{
public:
	// VP`1<System.Int32> Chess.NoneRule.ChessCustomSet::x
	VP_1_t2450154454 * ___x_5;
	// VP`1<System.Int32> Chess.NoneRule.ChessCustomSet::y
	VP_1_t2450154454 * ___y_6;
	// VP`1<Chess.Common/Piece> Chess.NoneRule.ChessCustomSet::piece
	VP_1_t3663429032 * ___piece_7;

public:
	inline static int32_t get_offset_of_x_5() { return static_cast<int32_t>(offsetof(ChessCustomSet_t3667489137, ___x_5)); }
	inline VP_1_t2450154454 * get_x_5() const { return ___x_5; }
	inline VP_1_t2450154454 ** get_address_of_x_5() { return &___x_5; }
	inline void set_x_5(VP_1_t2450154454 * value)
	{
		___x_5 = value;
		Il2CppCodeGenWriteBarrier(&___x_5, value);
	}

	inline static int32_t get_offset_of_y_6() { return static_cast<int32_t>(offsetof(ChessCustomSet_t3667489137, ___y_6)); }
	inline VP_1_t2450154454 * get_y_6() const { return ___y_6; }
	inline VP_1_t2450154454 ** get_address_of_y_6() { return &___y_6; }
	inline void set_y_6(VP_1_t2450154454 * value)
	{
		___y_6 = value;
		Il2CppCodeGenWriteBarrier(&___y_6, value);
	}

	inline static int32_t get_offset_of_piece_7() { return static_cast<int32_t>(offsetof(ChessCustomSet_t3667489137, ___piece_7)); }
	inline VP_1_t3663429032 * get_piece_7() const { return ___piece_7; }
	inline VP_1_t3663429032 ** get_address_of_piece_7() { return &___piece_7; }
	inline void set_piece_7(VP_1_t3663429032 * value)
	{
		___piece_7 = value;
		Il2CppCodeGenWriteBarrier(&___piece_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
