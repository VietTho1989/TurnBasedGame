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
// LP`1<System.UInt32>
struct LP_1_t887425977;
// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiMoveAnimation
struct  ShogiMoveAnimation_t3405649795  : public MoveAnimation_t3061523661
{
public:
	// LP`1<System.Int32> Shogi.ShogiMoveAnimation::piece
	LP_1_t809621404 * ___piece_5;
	// LP`1<System.UInt32> Shogi.ShogiMoveAnimation::hand
	LP_1_t887425977 * ___hand_6;
	// VP`1<System.UInt32> Shogi.ShogiMoveAnimation::move
	VP_1_t2527959027 * ___move_7;
	// VP`1<System.Int32> Shogi.ShogiMoveAnimation::playerIndex
	VP_1_t2450154454 * ___playerIndex_8;

public:
	inline static int32_t get_offset_of_piece_5() { return static_cast<int32_t>(offsetof(ShogiMoveAnimation_t3405649795, ___piece_5)); }
	inline LP_1_t809621404 * get_piece_5() const { return ___piece_5; }
	inline LP_1_t809621404 ** get_address_of_piece_5() { return &___piece_5; }
	inline void set_piece_5(LP_1_t809621404 * value)
	{
		___piece_5 = value;
		Il2CppCodeGenWriteBarrier(&___piece_5, value);
	}

	inline static int32_t get_offset_of_hand_6() { return static_cast<int32_t>(offsetof(ShogiMoveAnimation_t3405649795, ___hand_6)); }
	inline LP_1_t887425977 * get_hand_6() const { return ___hand_6; }
	inline LP_1_t887425977 ** get_address_of_hand_6() { return &___hand_6; }
	inline void set_hand_6(LP_1_t887425977 * value)
	{
		___hand_6 = value;
		Il2CppCodeGenWriteBarrier(&___hand_6, value);
	}

	inline static int32_t get_offset_of_move_7() { return static_cast<int32_t>(offsetof(ShogiMoveAnimation_t3405649795, ___move_7)); }
	inline VP_1_t2527959027 * get_move_7() const { return ___move_7; }
	inline VP_1_t2527959027 ** get_address_of_move_7() { return &___move_7; }
	inline void set_move_7(VP_1_t2527959027 * value)
	{
		___move_7 = value;
		Il2CppCodeGenWriteBarrier(&___move_7, value);
	}

	inline static int32_t get_offset_of_playerIndex_8() { return static_cast<int32_t>(offsetof(ShogiMoveAnimation_t3405649795, ___playerIndex_8)); }
	inline VP_1_t2450154454 * get_playerIndex_8() const { return ___playerIndex_8; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_8() { return &___playerIndex_8; }
	inline void set_playerIndex_8(VP_1_t2450154454 * value)
	{
		___playerIndex_8 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
