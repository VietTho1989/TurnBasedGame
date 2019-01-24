#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<Shogi.Common/HandPiece>
struct VP_1_t2971963327;
// VP`1<Shogi.Common/Color>
struct VP_1_t703898847;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomHand
struct  ShogiCustomHand_t3384452588  : public GameMove_t1861898997
{
public:
	// VP`1<Shogi.Common/HandPiece> Shogi.NoneRule.ShogiCustomHand::handPiece
	VP_1_t2971963327 * ___handPiece_5;
	// VP`1<Shogi.Common/Color> Shogi.NoneRule.ShogiCustomHand::color
	VP_1_t703898847 * ___color_6;
	// VP`1<System.Int32> Shogi.NoneRule.ShogiCustomHand::pieceCount
	VP_1_t2450154454 * ___pieceCount_7;

public:
	inline static int32_t get_offset_of_handPiece_5() { return static_cast<int32_t>(offsetof(ShogiCustomHand_t3384452588, ___handPiece_5)); }
	inline VP_1_t2971963327 * get_handPiece_5() const { return ___handPiece_5; }
	inline VP_1_t2971963327 ** get_address_of_handPiece_5() { return &___handPiece_5; }
	inline void set_handPiece_5(VP_1_t2971963327 * value)
	{
		___handPiece_5 = value;
		Il2CppCodeGenWriteBarrier(&___handPiece_5, value);
	}

	inline static int32_t get_offset_of_color_6() { return static_cast<int32_t>(offsetof(ShogiCustomHand_t3384452588, ___color_6)); }
	inline VP_1_t703898847 * get_color_6() const { return ___color_6; }
	inline VP_1_t703898847 ** get_address_of_color_6() { return &___color_6; }
	inline void set_color_6(VP_1_t703898847 * value)
	{
		___color_6 = value;
		Il2CppCodeGenWriteBarrier(&___color_6, value);
	}

	inline static int32_t get_offset_of_pieceCount_7() { return static_cast<int32_t>(offsetof(ShogiCustomHand_t3384452588, ___pieceCount_7)); }
	inline VP_1_t2450154454 * get_pieceCount_7() const { return ___pieceCount_7; }
	inline VP_1_t2450154454 ** get_address_of_pieceCount_7() { return &___pieceCount_7; }
	inline void set_pieceCount_7(VP_1_t2450154454 * value)
	{
		___pieceCount_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
