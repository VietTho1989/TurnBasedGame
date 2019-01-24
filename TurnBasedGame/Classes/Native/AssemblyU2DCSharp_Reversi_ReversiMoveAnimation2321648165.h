#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_MoveAnimation3061523661.h"

// VP`1<Reversi.Reversi>
struct VP_1_t2966052098;
// VP`1<System.SByte>
struct VP_1_t832694555;
// VP`1<System.UInt64>
struct VP_1_t3287473920;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiMoveAnimation
struct  ReversiMoveAnimation_t2321648165  : public MoveAnimation_t3061523661
{
public:
	// VP`1<Reversi.Reversi> Reversi.ReversiMoveAnimation::reversi
	VP_1_t2966052098 * ___reversi_5;
	// VP`1<System.SByte> Reversi.ReversiMoveAnimation::move
	VP_1_t832694555 * ___move_6;
	// VP`1<System.UInt64> Reversi.ReversiMoveAnimation::change
	VP_1_t3287473920 * ___change_7;

public:
	inline static int32_t get_offset_of_reversi_5() { return static_cast<int32_t>(offsetof(ReversiMoveAnimation_t2321648165, ___reversi_5)); }
	inline VP_1_t2966052098 * get_reversi_5() const { return ___reversi_5; }
	inline VP_1_t2966052098 ** get_address_of_reversi_5() { return &___reversi_5; }
	inline void set_reversi_5(VP_1_t2966052098 * value)
	{
		___reversi_5 = value;
		Il2CppCodeGenWriteBarrier(&___reversi_5, value);
	}

	inline static int32_t get_offset_of_move_6() { return static_cast<int32_t>(offsetof(ReversiMoveAnimation_t2321648165, ___move_6)); }
	inline VP_1_t832694555 * get_move_6() const { return ___move_6; }
	inline VP_1_t832694555 ** get_address_of_move_6() { return &___move_6; }
	inline void set_move_6(VP_1_t832694555 * value)
	{
		___move_6 = value;
		Il2CppCodeGenWriteBarrier(&___move_6, value);
	}

	inline static int32_t get_offset_of_change_7() { return static_cast<int32_t>(offsetof(ReversiMoveAnimation_t2321648165, ___change_7)); }
	inline VP_1_t3287473920 * get_change_7() const { return ___change_7; }
	inline VP_1_t3287473920 ** get_address_of_change_7() { return &___change_7; }
	inline void set_change_7(VP_1_t3287473920 * value)
	{
		___change_7 = value;
		Il2CppCodeGenWriteBarrier(&___change_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
