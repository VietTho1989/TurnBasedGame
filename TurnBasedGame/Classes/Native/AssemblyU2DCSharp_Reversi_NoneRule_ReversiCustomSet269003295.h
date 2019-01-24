#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.SByte>
struct VP_1_t832694555;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.NoneRule.ReversiCustomSet
struct  ReversiCustomSet_t269003295  : public GameMove_t1861898997
{
public:
	// VP`1<System.SByte> Reversi.NoneRule.ReversiCustomSet::square
	VP_1_t832694555 * ___square_5;
	// VP`1<System.Int32> Reversi.NoneRule.ReversiCustomSet::piece
	VP_1_t2450154454 * ___piece_6;

public:
	inline static int32_t get_offset_of_square_5() { return static_cast<int32_t>(offsetof(ReversiCustomSet_t269003295, ___square_5)); }
	inline VP_1_t832694555 * get_square_5() const { return ___square_5; }
	inline VP_1_t832694555 ** get_address_of_square_5() { return &___square_5; }
	inline void set_square_5(VP_1_t832694555 * value)
	{
		___square_5 = value;
		Il2CppCodeGenWriteBarrier(&___square_5, value);
	}

	inline static int32_t get_offset_of_piece_6() { return static_cast<int32_t>(offsetof(ReversiCustomSet_t269003295, ___piece_6)); }
	inline VP_1_t2450154454 * get_piece_6() const { return ___piece_6; }
	inline VP_1_t2450154454 ** get_address_of_piece_6() { return &___piece_6; }
	inline void set_piece_6(VP_1_t2450154454 * value)
	{
		___piece_6 = value;
		Il2CppCodeGenWriteBarrier(&___piece_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
