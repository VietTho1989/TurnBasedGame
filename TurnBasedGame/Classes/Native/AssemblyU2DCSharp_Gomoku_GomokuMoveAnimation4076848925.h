#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_MoveAnimation3061523661.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<Gomoku.Gomoku>
struct VP_1_t3027266814;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuMoveAnimation
struct  GomokuMoveAnimation_t4076848925  : public MoveAnimation_t3061523661
{
public:
	// VP`1<System.Int32> Gomoku.GomokuMoveAnimation::move
	VP_1_t2450154454 * ___move_5;
	// VP`1<Gomoku.Gomoku> Gomoku.GomokuMoveAnimation::gomoku
	VP_1_t3027266814 * ___gomoku_6;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(GomokuMoveAnimation_t4076848925, ___move_5)); }
	inline VP_1_t2450154454 * get_move_5() const { return ___move_5; }
	inline VP_1_t2450154454 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t2450154454 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}

	inline static int32_t get_offset_of_gomoku_6() { return static_cast<int32_t>(offsetof(GomokuMoveAnimation_t4076848925, ___gomoku_6)); }
	inline VP_1_t3027266814 * get_gomoku_6() const { return ___gomoku_6; }
	inline VP_1_t3027266814 ** get_address_of_gomoku_6() { return &___gomoku_6; }
	inline void set_gomoku_6(VP_1_t3027266814 * value)
	{
		___gomoku_6 = value;
		Il2CppCodeGenWriteBarrier(&___gomoku_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
