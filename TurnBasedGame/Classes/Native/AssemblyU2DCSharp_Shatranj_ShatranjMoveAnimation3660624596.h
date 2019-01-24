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
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.ShatranjMoveAnimation
struct  ShatranjMoveAnimation_t3660624596  : public MoveAnimation_t3061523661
{
public:
	// LP`1<System.Int32> Shatranj.ShatranjMoveAnimation::board
	LP_1_t809621404 * ___board_5;
	// VP`1<System.Int32> Shatranj.ShatranjMoveAnimation::move
	VP_1_t2450154454 * ___move_6;
	// VP`1<System.Boolean> Shatranj.ShatranjMoveAnimation::chess960
	VP_1_t4203851724 * ___chess960_7;

public:
	inline static int32_t get_offset_of_board_5() { return static_cast<int32_t>(offsetof(ShatranjMoveAnimation_t3660624596, ___board_5)); }
	inline LP_1_t809621404 * get_board_5() const { return ___board_5; }
	inline LP_1_t809621404 ** get_address_of_board_5() { return &___board_5; }
	inline void set_board_5(LP_1_t809621404 * value)
	{
		___board_5 = value;
		Il2CppCodeGenWriteBarrier(&___board_5, value);
	}

	inline static int32_t get_offset_of_move_6() { return static_cast<int32_t>(offsetof(ShatranjMoveAnimation_t3660624596, ___move_6)); }
	inline VP_1_t2450154454 * get_move_6() const { return ___move_6; }
	inline VP_1_t2450154454 ** get_address_of_move_6() { return &___move_6; }
	inline void set_move_6(VP_1_t2450154454 * value)
	{
		___move_6 = value;
		Il2CppCodeGenWriteBarrier(&___move_6, value);
	}

	inline static int32_t get_offset_of_chess960_7() { return static_cast<int32_t>(offsetof(ShatranjMoveAnimation_t3660624596, ___chess960_7)); }
	inline VP_1_t4203851724 * get_chess960_7() const { return ___chess960_7; }
	inline VP_1_t4203851724 ** get_address_of_chess960_7() { return &___chess960_7; }
	inline void set_chess960_7(VP_1_t4203851724 * value)
	{
		___chess960_7 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
