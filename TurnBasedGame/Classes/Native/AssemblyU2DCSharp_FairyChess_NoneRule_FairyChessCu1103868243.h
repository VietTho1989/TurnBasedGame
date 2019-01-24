#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<FairyChess.Common/Color>
struct VP_1_t1646218928;
// VP`1<FairyChess.Common/PieceType>
struct VP_1_t3228928525;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.FairyChessCustomHand
struct  FairyChessCustomHand_t1103868243  : public GameMove_t1861898997
{
public:
	// VP`1<FairyChess.Common/Color> FairyChess.NoneRule.FairyChessCustomHand::color
	VP_1_t1646218928 * ___color_5;
	// VP`1<FairyChess.Common/PieceType> FairyChess.NoneRule.FairyChessCustomHand::pieceType
	VP_1_t3228928525 * ___pieceType_6;
	// VP`1<System.Int32> FairyChess.NoneRule.FairyChessCustomHand::pieceCount
	VP_1_t2450154454 * ___pieceCount_7;

public:
	inline static int32_t get_offset_of_color_5() { return static_cast<int32_t>(offsetof(FairyChessCustomHand_t1103868243, ___color_5)); }
	inline VP_1_t1646218928 * get_color_5() const { return ___color_5; }
	inline VP_1_t1646218928 ** get_address_of_color_5() { return &___color_5; }
	inline void set_color_5(VP_1_t1646218928 * value)
	{
		___color_5 = value;
		Il2CppCodeGenWriteBarrier(&___color_5, value);
	}

	inline static int32_t get_offset_of_pieceType_6() { return static_cast<int32_t>(offsetof(FairyChessCustomHand_t1103868243, ___pieceType_6)); }
	inline VP_1_t3228928525 * get_pieceType_6() const { return ___pieceType_6; }
	inline VP_1_t3228928525 ** get_address_of_pieceType_6() { return &___pieceType_6; }
	inline void set_pieceType_6(VP_1_t3228928525 * value)
	{
		___pieceType_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieceType_6, value);
	}

	inline static int32_t get_offset_of_pieceCount_7() { return static_cast<int32_t>(offsetof(FairyChessCustomHand_t1103868243, ___pieceCount_7)); }
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
