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
// VP`1<FairyChess.Common/Piece>
struct VP_1_t880072437;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessMoveAnimation
struct  FairyChessMoveAnimation_t69044422  : public MoveAnimation_t3061523661
{
public:
	// LP`1<System.Int32> FairyChess.FairyChessMoveAnimation::board
	LP_1_t809621404 * ___board_5;
	// LP`1<System.Int32> FairyChess.FairyChessMoveAnimation::pieceCountInHand
	LP_1_t809621404 * ___pieceCountInHand_6;
	// VP`1<FairyChess.Common/Piece> FairyChess.FairyChessMoveAnimation::promoteOrDropPiece
	VP_1_t880072437 * ___promoteOrDropPiece_7;
	// VP`1<System.Int32> FairyChess.FairyChessMoveAnimation::move
	VP_1_t2450154454 * ___move_8;

public:
	inline static int32_t get_offset_of_board_5() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimation_t69044422, ___board_5)); }
	inline LP_1_t809621404 * get_board_5() const { return ___board_5; }
	inline LP_1_t809621404 ** get_address_of_board_5() { return &___board_5; }
	inline void set_board_5(LP_1_t809621404 * value)
	{
		___board_5 = value;
		Il2CppCodeGenWriteBarrier(&___board_5, value);
	}

	inline static int32_t get_offset_of_pieceCountInHand_6() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimation_t69044422, ___pieceCountInHand_6)); }
	inline LP_1_t809621404 * get_pieceCountInHand_6() const { return ___pieceCountInHand_6; }
	inline LP_1_t809621404 ** get_address_of_pieceCountInHand_6() { return &___pieceCountInHand_6; }
	inline void set_pieceCountInHand_6(LP_1_t809621404 * value)
	{
		___pieceCountInHand_6 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCountInHand_6, value);
	}

	inline static int32_t get_offset_of_promoteOrDropPiece_7() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimation_t69044422, ___promoteOrDropPiece_7)); }
	inline VP_1_t880072437 * get_promoteOrDropPiece_7() const { return ___promoteOrDropPiece_7; }
	inline VP_1_t880072437 ** get_address_of_promoteOrDropPiece_7() { return &___promoteOrDropPiece_7; }
	inline void set_promoteOrDropPiece_7(VP_1_t880072437 * value)
	{
		___promoteOrDropPiece_7 = value;
		Il2CppCodeGenWriteBarrier(&___promoteOrDropPiece_7, value);
	}

	inline static int32_t get_offset_of_move_8() { return static_cast<int32_t>(offsetof(FairyChessMoveAnimation_t69044422, ___move_8)); }
	inline VP_1_t2450154454 * get_move_8() const { return ___move_8; }
	inline VP_1_t2450154454 ** get_address_of_move_8() { return &___move_8; }
	inline void set_move_8(VP_1_t2450154454 * value)
	{
		___move_8 = value;
		Il2CppCodeGenWriteBarrier(&___move_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
