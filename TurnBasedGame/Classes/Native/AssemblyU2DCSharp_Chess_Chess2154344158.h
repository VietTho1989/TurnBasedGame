#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameType1512575910.h"

// System.String
struct String_t;
// LP`1<System.Int32>
struct LP_1_t809621404;
// LP`1<System.UInt64>
struct LP_1_t1646940870;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<Chess.StateInfo>
struct LP_1_t1569109143;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.Chess
struct  Chess_t2154344158  : public GameType_t1512575910
{
public:
	// LP`1<System.Int32> Chess.Chess::board
	LP_1_t809621404 * ___board_10;
	// LP`1<System.UInt64> Chess.Chess::byTypeBB
	LP_1_t1646940870 * ___byTypeBB_11;
	// LP`1<System.UInt64> Chess.Chess::byColorBB
	LP_1_t1646940870 * ___byColorBB_12;
	// LP`1<System.Int32> Chess.Chess::pieceCount
	LP_1_t809621404 * ___pieceCount_13;
	// LP`1<System.Int32> Chess.Chess::pieceList
	LP_1_t809621404 * ___pieceList_14;
	// LP`1<System.Int32> Chess.Chess::index
	LP_1_t809621404 * ___index_15;
	// LP`1<System.Int32> Chess.Chess::castlingRightsMask
	LP_1_t809621404 * ___castlingRightsMask_16;
	// LP`1<System.Int32> Chess.Chess::castlingRookSquare
	LP_1_t809621404 * ___castlingRookSquare_17;
	// LP`1<System.UInt64> Chess.Chess::castlingPath
	LP_1_t1646940870 * ___castlingPath_18;
	// VP`1<System.Int32> Chess.Chess::gamePly
	VP_1_t2450154454 * ___gamePly_19;
	// VP`1<System.Int32> Chess.Chess::sideToMove
	VP_1_t2450154454 * ___sideToMove_20;
	// LP`1<Chess.StateInfo> Chess.Chess::st
	LP_1_t1569109143 * ___st_21;
	// VP`1<System.Boolean> Chess.Chess::chess960
	VP_1_t4203851724 * ___chess960_22;
	// VP`1<System.Boolean> Chess.Chess::isCustom
	VP_1_t4203851724 * ___isCustom_23;

public:
	inline static int32_t get_offset_of_board_10() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___board_10)); }
	inline LP_1_t809621404 * get_board_10() const { return ___board_10; }
	inline LP_1_t809621404 ** get_address_of_board_10() { return &___board_10; }
	inline void set_board_10(LP_1_t809621404 * value)
	{
		___board_10 = value;
		Il2CppCodeGenWriteBarrier(&___board_10, value);
	}

	inline static int32_t get_offset_of_byTypeBB_11() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___byTypeBB_11)); }
	inline LP_1_t1646940870 * get_byTypeBB_11() const { return ___byTypeBB_11; }
	inline LP_1_t1646940870 ** get_address_of_byTypeBB_11() { return &___byTypeBB_11; }
	inline void set_byTypeBB_11(LP_1_t1646940870 * value)
	{
		___byTypeBB_11 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_11, value);
	}

	inline static int32_t get_offset_of_byColorBB_12() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___byColorBB_12)); }
	inline LP_1_t1646940870 * get_byColorBB_12() const { return ___byColorBB_12; }
	inline LP_1_t1646940870 ** get_address_of_byColorBB_12() { return &___byColorBB_12; }
	inline void set_byColorBB_12(LP_1_t1646940870 * value)
	{
		___byColorBB_12 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_12, value);
	}

	inline static int32_t get_offset_of_pieceCount_13() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___pieceCount_13)); }
	inline LP_1_t809621404 * get_pieceCount_13() const { return ___pieceCount_13; }
	inline LP_1_t809621404 ** get_address_of_pieceCount_13() { return &___pieceCount_13; }
	inline void set_pieceCount_13(LP_1_t809621404 * value)
	{
		___pieceCount_13 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_13, value);
	}

	inline static int32_t get_offset_of_pieceList_14() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___pieceList_14)); }
	inline LP_1_t809621404 * get_pieceList_14() const { return ___pieceList_14; }
	inline LP_1_t809621404 ** get_address_of_pieceList_14() { return &___pieceList_14; }
	inline void set_pieceList_14(LP_1_t809621404 * value)
	{
		___pieceList_14 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_14, value);
	}

	inline static int32_t get_offset_of_index_15() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___index_15)); }
	inline LP_1_t809621404 * get_index_15() const { return ___index_15; }
	inline LP_1_t809621404 ** get_address_of_index_15() { return &___index_15; }
	inline void set_index_15(LP_1_t809621404 * value)
	{
		___index_15 = value;
		Il2CppCodeGenWriteBarrier(&___index_15, value);
	}

	inline static int32_t get_offset_of_castlingRightsMask_16() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___castlingRightsMask_16)); }
	inline LP_1_t809621404 * get_castlingRightsMask_16() const { return ___castlingRightsMask_16; }
	inline LP_1_t809621404 ** get_address_of_castlingRightsMask_16() { return &___castlingRightsMask_16; }
	inline void set_castlingRightsMask_16(LP_1_t809621404 * value)
	{
		___castlingRightsMask_16 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRightsMask_16, value);
	}

	inline static int32_t get_offset_of_castlingRookSquare_17() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___castlingRookSquare_17)); }
	inline LP_1_t809621404 * get_castlingRookSquare_17() const { return ___castlingRookSquare_17; }
	inline LP_1_t809621404 ** get_address_of_castlingRookSquare_17() { return &___castlingRookSquare_17; }
	inline void set_castlingRookSquare_17(LP_1_t809621404 * value)
	{
		___castlingRookSquare_17 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRookSquare_17, value);
	}

	inline static int32_t get_offset_of_castlingPath_18() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___castlingPath_18)); }
	inline LP_1_t1646940870 * get_castlingPath_18() const { return ___castlingPath_18; }
	inline LP_1_t1646940870 ** get_address_of_castlingPath_18() { return &___castlingPath_18; }
	inline void set_castlingPath_18(LP_1_t1646940870 * value)
	{
		___castlingPath_18 = value;
		Il2CppCodeGenWriteBarrier(&___castlingPath_18, value);
	}

	inline static int32_t get_offset_of_gamePly_19() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___gamePly_19)); }
	inline VP_1_t2450154454 * get_gamePly_19() const { return ___gamePly_19; }
	inline VP_1_t2450154454 ** get_address_of_gamePly_19() { return &___gamePly_19; }
	inline void set_gamePly_19(VP_1_t2450154454 * value)
	{
		___gamePly_19 = value;
		Il2CppCodeGenWriteBarrier(&___gamePly_19, value);
	}

	inline static int32_t get_offset_of_sideToMove_20() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___sideToMove_20)); }
	inline VP_1_t2450154454 * get_sideToMove_20() const { return ___sideToMove_20; }
	inline VP_1_t2450154454 ** get_address_of_sideToMove_20() { return &___sideToMove_20; }
	inline void set_sideToMove_20(VP_1_t2450154454 * value)
	{
		___sideToMove_20 = value;
		Il2CppCodeGenWriteBarrier(&___sideToMove_20, value);
	}

	inline static int32_t get_offset_of_st_21() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___st_21)); }
	inline LP_1_t1569109143 * get_st_21() const { return ___st_21; }
	inline LP_1_t1569109143 ** get_address_of_st_21() { return &___st_21; }
	inline void set_st_21(LP_1_t1569109143 * value)
	{
		___st_21 = value;
		Il2CppCodeGenWriteBarrier(&___st_21, value);
	}

	inline static int32_t get_offset_of_chess960_22() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___chess960_22)); }
	inline VP_1_t4203851724 * get_chess960_22() const { return ___chess960_22; }
	inline VP_1_t4203851724 ** get_address_of_chess960_22() { return &___chess960_22; }
	inline void set_chess960_22(VP_1_t4203851724 * value)
	{
		___chess960_22 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_22, value);
	}

	inline static int32_t get_offset_of_isCustom_23() { return static_cast<int32_t>(offsetof(Chess_t2154344158, ___isCustom_23)); }
	inline VP_1_t4203851724 * get_isCustom_23() const { return ___isCustom_23; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_23() { return &___isCustom_23; }
	inline void set_isCustom_23(VP_1_t4203851724 * value)
	{
		___isCustom_23 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_23, value);
	}
};

struct Chess_t2154344158_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Byte> Chess.Chess::AllowNames
	List_1_t3052225568 * ___AllowNames_24;

public:
	inline static int32_t get_offset_of_AllowNames_24() { return static_cast<int32_t>(offsetof(Chess_t2154344158_StaticFields, ___AllowNames_24)); }
	inline List_1_t3052225568 * get_AllowNames_24() const { return ___AllowNames_24; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_24() { return &___AllowNames_24; }
	inline void set_AllowNames_24(List_1_t3052225568 * value)
	{
		___AllowNames_24 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_24, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
