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
// VP`1<RussianDraught.RussianDraughtMove>
struct VP_1_t1620789205;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtMoveAnimation
struct  RussianDraughtMoveAnimation_t817841913  : public MoveAnimation_t3061523661
{
public:
	// LP`1<System.Int32> RussianDraught.RussianDraughtMoveAnimation::Board
	LP_1_t809621404 * ___Board_5;
	// VP`1<RussianDraught.RussianDraughtMove> RussianDraught.RussianDraughtMoveAnimation::move
	VP_1_t1620789205 * ___move_6;

public:
	inline static int32_t get_offset_of_Board_5() { return static_cast<int32_t>(offsetof(RussianDraughtMoveAnimation_t817841913, ___Board_5)); }
	inline LP_1_t809621404 * get_Board_5() const { return ___Board_5; }
	inline LP_1_t809621404 ** get_address_of_Board_5() { return &___Board_5; }
	inline void set_Board_5(LP_1_t809621404 * value)
	{
		___Board_5 = value;
		Il2CppCodeGenWriteBarrier(&___Board_5, value);
	}

	inline static int32_t get_offset_of_move_6() { return static_cast<int32_t>(offsetof(RussianDraughtMoveAnimation_t817841913, ___move_6)); }
	inline VP_1_t1620789205 * get_move_6() const { return ___move_6; }
	inline VP_1_t1620789205 ** get_address_of_move_6() { return &___move_6; }
	inline void set_move_6(VP_1_t1620789205 * value)
	{
		___move_6 = value;
		Il2CppCodeGenWriteBarrier(&___move_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
