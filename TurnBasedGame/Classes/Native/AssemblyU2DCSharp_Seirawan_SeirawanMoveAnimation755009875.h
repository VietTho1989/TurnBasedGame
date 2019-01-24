#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_MoveAnimation3061523661.h"

// LP`1<System.Int32>
struct LP_1_t809621404;
// LP`1<System.Boolean>
struct LP_1_t2563318674;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.SeirawanMoveAnimation
struct  SeirawanMoveAnimation_t755009875  : public MoveAnimation_t3061523661
{
public:
	// LP`1<System.Int32> Seirawan.SeirawanMoveAnimation::board
	LP_1_t809621404 * ___board_5;
	// LP`1<System.Boolean> Seirawan.SeirawanMoveAnimation::inHand
	LP_1_t2563318674 * ___inHand_6;
	// VP`1<System.Int32> Seirawan.SeirawanMoveAnimation::move
	VP_1_t2450154454 * ___move_7;
	// VP`1<System.Boolean> Seirawan.SeirawanMoveAnimation::chess960
	VP_1_t4203851724 * ___chess960_8;

public:
	inline static int32_t get_offset_of_board_5() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimation_t755009875, ___board_5)); }
	inline LP_1_t809621404 * get_board_5() const { return ___board_5; }
	inline LP_1_t809621404 ** get_address_of_board_5() { return &___board_5; }
	inline void set_board_5(LP_1_t809621404 * value)
	{
		___board_5 = value;
		Il2CppCodeGenWriteBarrier(&___board_5, value);
	}

	inline static int32_t get_offset_of_inHand_6() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimation_t755009875, ___inHand_6)); }
	inline LP_1_t2563318674 * get_inHand_6() const { return ___inHand_6; }
	inline LP_1_t2563318674 ** get_address_of_inHand_6() { return &___inHand_6; }
	inline void set_inHand_6(LP_1_t2563318674 * value)
	{
		___inHand_6 = value;
		Il2CppCodeGenWriteBarrier(&___inHand_6, value);
	}

	inline static int32_t get_offset_of_move_7() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimation_t755009875, ___move_7)); }
	inline VP_1_t2450154454 * get_move_7() const { return ___move_7; }
	inline VP_1_t2450154454 ** get_address_of_move_7() { return &___move_7; }
	inline void set_move_7(VP_1_t2450154454 * value)
	{
		___move_7 = value;
		Il2CppCodeGenWriteBarrier(&___move_7, value);
	}

	inline static int32_t get_offset_of_chess960_8() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimation_t755009875, ___chess960_8)); }
	inline VP_1_t4203851724 * get_chess960_8() const { return ___chess960_8; }
	inline VP_1_t4203851724 ** get_address_of_chess960_8() { return &___chess960_8; }
	inline void set_chess960_8(VP_1_t4203851724 * value)
	{
		___chess960_8 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
