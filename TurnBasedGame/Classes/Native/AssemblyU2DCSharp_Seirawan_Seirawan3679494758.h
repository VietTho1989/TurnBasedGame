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
// LP`1<System.Boolean>
struct LP_1_t2563318674;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<Seirawan.SeirawanStateInfo>
struct LP_1_t1155128313;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.Seirawan
struct  Seirawan_t3679494758  : public GameType_t1512575910
{
public:
	// LP`1<System.Int32> Seirawan.Seirawan::board
	LP_1_t809621404 * ___board_10;
	// LP`1<System.UInt64> Seirawan.Seirawan::byTypeBB
	LP_1_t1646940870 * ___byTypeBB_11;
	// LP`1<System.UInt64> Seirawan.Seirawan::byColorBB
	LP_1_t1646940870 * ___byColorBB_12;
	// LP`1<System.Boolean> Seirawan.Seirawan::inHand
	LP_1_t2563318674 * ___inHand_13;
	// LP`1<System.Int32> Seirawan.Seirawan::handScore
	LP_1_t809621404 * ___handScore_14;
	// LP`1<System.Int32> Seirawan.Seirawan::pieceCount
	LP_1_t809621404 * ___pieceCount_15;
	// LP`1<System.Int32> Seirawan.Seirawan::pieceList
	LP_1_t809621404 * ___pieceList_16;
	// LP`1<System.Int32> Seirawan.Seirawan::index
	LP_1_t809621404 * ___index_17;
	// LP`1<System.Int32> Seirawan.Seirawan::castlingRightsMask
	LP_1_t809621404 * ___castlingRightsMask_18;
	// LP`1<System.Int32> Seirawan.Seirawan::castlingRookSquare
	LP_1_t809621404 * ___castlingRookSquare_19;
	// LP`1<System.UInt64> Seirawan.Seirawan::castlingPath
	LP_1_t1646940870 * ___castlingPath_20;
	// VP`1<System.Int32> Seirawan.Seirawan::gamePly
	VP_1_t2450154454 * ___gamePly_21;
	// VP`1<System.Int32> Seirawan.Seirawan::sideToMove
	VP_1_t2450154454 * ___sideToMove_22;
	// LP`1<Seirawan.SeirawanStateInfo> Seirawan.Seirawan::st
	LP_1_t1155128313 * ___st_23;
	// VP`1<System.Boolean> Seirawan.Seirawan::chess960
	VP_1_t4203851724 * ___chess960_24;
	// VP`1<System.Boolean> Seirawan.Seirawan::isCustom
	VP_1_t4203851724 * ___isCustom_25;

public:
	inline static int32_t get_offset_of_board_10() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___board_10)); }
	inline LP_1_t809621404 * get_board_10() const { return ___board_10; }
	inline LP_1_t809621404 ** get_address_of_board_10() { return &___board_10; }
	inline void set_board_10(LP_1_t809621404 * value)
	{
		___board_10 = value;
		Il2CppCodeGenWriteBarrier(&___board_10, value);
	}

	inline static int32_t get_offset_of_byTypeBB_11() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___byTypeBB_11)); }
	inline LP_1_t1646940870 * get_byTypeBB_11() const { return ___byTypeBB_11; }
	inline LP_1_t1646940870 ** get_address_of_byTypeBB_11() { return &___byTypeBB_11; }
	inline void set_byTypeBB_11(LP_1_t1646940870 * value)
	{
		___byTypeBB_11 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_11, value);
	}

	inline static int32_t get_offset_of_byColorBB_12() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___byColorBB_12)); }
	inline LP_1_t1646940870 * get_byColorBB_12() const { return ___byColorBB_12; }
	inline LP_1_t1646940870 ** get_address_of_byColorBB_12() { return &___byColorBB_12; }
	inline void set_byColorBB_12(LP_1_t1646940870 * value)
	{
		___byColorBB_12 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_12, value);
	}

	inline static int32_t get_offset_of_inHand_13() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___inHand_13)); }
	inline LP_1_t2563318674 * get_inHand_13() const { return ___inHand_13; }
	inline LP_1_t2563318674 ** get_address_of_inHand_13() { return &___inHand_13; }
	inline void set_inHand_13(LP_1_t2563318674 * value)
	{
		___inHand_13 = value;
		Il2CppCodeGenWriteBarrier(&___inHand_13, value);
	}

	inline static int32_t get_offset_of_handScore_14() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___handScore_14)); }
	inline LP_1_t809621404 * get_handScore_14() const { return ___handScore_14; }
	inline LP_1_t809621404 ** get_address_of_handScore_14() { return &___handScore_14; }
	inline void set_handScore_14(LP_1_t809621404 * value)
	{
		___handScore_14 = value;
		Il2CppCodeGenWriteBarrier(&___handScore_14, value);
	}

	inline static int32_t get_offset_of_pieceCount_15() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___pieceCount_15)); }
	inline LP_1_t809621404 * get_pieceCount_15() const { return ___pieceCount_15; }
	inline LP_1_t809621404 ** get_address_of_pieceCount_15() { return &___pieceCount_15; }
	inline void set_pieceCount_15(LP_1_t809621404 * value)
	{
		___pieceCount_15 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_15, value);
	}

	inline static int32_t get_offset_of_pieceList_16() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___pieceList_16)); }
	inline LP_1_t809621404 * get_pieceList_16() const { return ___pieceList_16; }
	inline LP_1_t809621404 ** get_address_of_pieceList_16() { return &___pieceList_16; }
	inline void set_pieceList_16(LP_1_t809621404 * value)
	{
		___pieceList_16 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_16, value);
	}

	inline static int32_t get_offset_of_index_17() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___index_17)); }
	inline LP_1_t809621404 * get_index_17() const { return ___index_17; }
	inline LP_1_t809621404 ** get_address_of_index_17() { return &___index_17; }
	inline void set_index_17(LP_1_t809621404 * value)
	{
		___index_17 = value;
		Il2CppCodeGenWriteBarrier(&___index_17, value);
	}

	inline static int32_t get_offset_of_castlingRightsMask_18() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___castlingRightsMask_18)); }
	inline LP_1_t809621404 * get_castlingRightsMask_18() const { return ___castlingRightsMask_18; }
	inline LP_1_t809621404 ** get_address_of_castlingRightsMask_18() { return &___castlingRightsMask_18; }
	inline void set_castlingRightsMask_18(LP_1_t809621404 * value)
	{
		___castlingRightsMask_18 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRightsMask_18, value);
	}

	inline static int32_t get_offset_of_castlingRookSquare_19() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___castlingRookSquare_19)); }
	inline LP_1_t809621404 * get_castlingRookSquare_19() const { return ___castlingRookSquare_19; }
	inline LP_1_t809621404 ** get_address_of_castlingRookSquare_19() { return &___castlingRookSquare_19; }
	inline void set_castlingRookSquare_19(LP_1_t809621404 * value)
	{
		___castlingRookSquare_19 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRookSquare_19, value);
	}

	inline static int32_t get_offset_of_castlingPath_20() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___castlingPath_20)); }
	inline LP_1_t1646940870 * get_castlingPath_20() const { return ___castlingPath_20; }
	inline LP_1_t1646940870 ** get_address_of_castlingPath_20() { return &___castlingPath_20; }
	inline void set_castlingPath_20(LP_1_t1646940870 * value)
	{
		___castlingPath_20 = value;
		Il2CppCodeGenWriteBarrier(&___castlingPath_20, value);
	}

	inline static int32_t get_offset_of_gamePly_21() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___gamePly_21)); }
	inline VP_1_t2450154454 * get_gamePly_21() const { return ___gamePly_21; }
	inline VP_1_t2450154454 ** get_address_of_gamePly_21() { return &___gamePly_21; }
	inline void set_gamePly_21(VP_1_t2450154454 * value)
	{
		___gamePly_21 = value;
		Il2CppCodeGenWriteBarrier(&___gamePly_21, value);
	}

	inline static int32_t get_offset_of_sideToMove_22() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___sideToMove_22)); }
	inline VP_1_t2450154454 * get_sideToMove_22() const { return ___sideToMove_22; }
	inline VP_1_t2450154454 ** get_address_of_sideToMove_22() { return &___sideToMove_22; }
	inline void set_sideToMove_22(VP_1_t2450154454 * value)
	{
		___sideToMove_22 = value;
		Il2CppCodeGenWriteBarrier(&___sideToMove_22, value);
	}

	inline static int32_t get_offset_of_st_23() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___st_23)); }
	inline LP_1_t1155128313 * get_st_23() const { return ___st_23; }
	inline LP_1_t1155128313 ** get_address_of_st_23() { return &___st_23; }
	inline void set_st_23(LP_1_t1155128313 * value)
	{
		___st_23 = value;
		Il2CppCodeGenWriteBarrier(&___st_23, value);
	}

	inline static int32_t get_offset_of_chess960_24() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___chess960_24)); }
	inline VP_1_t4203851724 * get_chess960_24() const { return ___chess960_24; }
	inline VP_1_t4203851724 ** get_address_of_chess960_24() { return &___chess960_24; }
	inline void set_chess960_24(VP_1_t4203851724 * value)
	{
		___chess960_24 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_24, value);
	}

	inline static int32_t get_offset_of_isCustom_25() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758, ___isCustom_25)); }
	inline VP_1_t4203851724 * get_isCustom_25() const { return ___isCustom_25; }
	inline VP_1_t4203851724 ** get_address_of_isCustom_25() { return &___isCustom_25; }
	inline void set_isCustom_25(VP_1_t4203851724 * value)
	{
		___isCustom_25 = value;
		Il2CppCodeGenWriteBarrier(&___isCustom_25, value);
	}
};

struct Seirawan_t3679494758_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Byte> Seirawan.Seirawan::AllowNames
	List_1_t3052225568 * ___AllowNames_26;

public:
	inline static int32_t get_offset_of_AllowNames_26() { return static_cast<int32_t>(offsetof(Seirawan_t3679494758_StaticFields, ___AllowNames_26)); }
	inline List_1_t3052225568 * get_AllowNames_26() const { return ___AllowNames_26; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_26() { return &___AllowNames_26; }
	inline void set_AllowNames_26(List_1_t3052225568 * value)
	{
		___AllowNames_26 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
