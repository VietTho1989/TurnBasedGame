#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameMove1861898997.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// Shogi.Common/HandPiece[]
struct HandPieceU5BU5D_t1029127404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiMove
struct  ShogiMove_t406008629  : public GameMove_t1861898997
{
public:
	// VP`1<System.UInt32> Shogi.ShogiMove::move
	VP_1_t2527959027 * ___move_5;

public:
	inline static int32_t get_offset_of_move_5() { return static_cast<int32_t>(offsetof(ShogiMove_t406008629, ___move_5)); }
	inline VP_1_t2527959027 * get_move_5() const { return ___move_5; }
	inline VP_1_t2527959027 ** get_address_of_move_5() { return &___move_5; }
	inline void set_move_5(VP_1_t2527959027 * value)
	{
		___move_5 = value;
		Il2CppCodeGenWriteBarrier(&___move_5, value);
	}
};

struct ShogiMove_t406008629_StaticFields
{
public:
	// Shogi.Common/HandPiece[] Shogi.ShogiMove::PieceTypeToHandPieceTable
	HandPieceU5BU5D_t1029127404* ___PieceTypeToHandPieceTable_7;

public:
	inline static int32_t get_offset_of_PieceTypeToHandPieceTable_7() { return static_cast<int32_t>(offsetof(ShogiMove_t406008629_StaticFields, ___PieceTypeToHandPieceTable_7)); }
	inline HandPieceU5BU5D_t1029127404* get_PieceTypeToHandPieceTable_7() const { return ___PieceTypeToHandPieceTable_7; }
	inline HandPieceU5BU5D_t1029127404** get_address_of_PieceTypeToHandPieceTable_7() { return &___PieceTypeToHandPieceTable_7; }
	inline void set_PieceTypeToHandPieceTable_7(HandPieceU5BU5D_t1029127404* value)
	{
		___PieceTypeToHandPieceTable_7 = value;
		Il2CppCodeGenWriteBarrier(&___PieceTypeToHandPieceTable_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
