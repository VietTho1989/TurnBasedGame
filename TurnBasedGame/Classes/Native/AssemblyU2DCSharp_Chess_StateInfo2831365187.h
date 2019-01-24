#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.UInt64>
struct VP_1_t3287473920;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.UInt64>
struct LP_1_t1646940870;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.StateInfo
struct  StateInfo_t2831365187  : public Data_t3569509720
{
public:
	// VP`1<System.UInt64> Chess.StateInfo::pawnKey
	VP_1_t3287473920 * ___pawnKey_5;
	// VP`1<System.UInt64> Chess.StateInfo::materialKey
	VP_1_t3287473920 * ___materialKey_6;
	// LP`1<System.Int32> Chess.StateInfo::nonPawnMaterial
	LP_1_t809621404 * ___nonPawnMaterial_7;
	// VP`1<System.Int32> Chess.StateInfo::castlingRights
	VP_1_t2450154454 * ___castlingRights_8;
	// VP`1<System.Int32> Chess.StateInfo::rule50
	VP_1_t2450154454 * ___rule50_9;
	// VP`1<System.Int32> Chess.StateInfo::pliesFromNull
	VP_1_t2450154454 * ___pliesFromNull_10;
	// VP`1<System.Int32> Chess.StateInfo::psq
	VP_1_t2450154454 * ___psq_11;
	// VP`1<System.Int32> Chess.StateInfo::epSquare
	VP_1_t2450154454 * ___epSquare_12;
	// VP`1<System.UInt64> Chess.StateInfo::key
	VP_1_t3287473920 * ___key_13;
	// VP`1<System.UInt64> Chess.StateInfo::checkersBB
	VP_1_t3287473920 * ___checkersBB_14;
	// VP`1<System.Int32> Chess.StateInfo::capturedPiece
	VP_1_t2450154454 * ___capturedPiece_15;
	// LP`1<System.UInt64> Chess.StateInfo::blockersForKing
	LP_1_t1646940870 * ___blockersForKing_16;
	// LP`1<System.UInt64> Chess.StateInfo::pinnersForKing
	LP_1_t1646940870 * ___pinnersForKing_17;
	// LP`1<System.UInt64> Chess.StateInfo::checkSquares
	LP_1_t1646940870 * ___checkSquares_18;

public:
	inline static int32_t get_offset_of_pawnKey_5() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___pawnKey_5)); }
	inline VP_1_t3287473920 * get_pawnKey_5() const { return ___pawnKey_5; }
	inline VP_1_t3287473920 ** get_address_of_pawnKey_5() { return &___pawnKey_5; }
	inline void set_pawnKey_5(VP_1_t3287473920 * value)
	{
		___pawnKey_5 = value;
		Il2CppCodeGenWriteBarrier(&___pawnKey_5, value);
	}

	inline static int32_t get_offset_of_materialKey_6() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___materialKey_6)); }
	inline VP_1_t3287473920 * get_materialKey_6() const { return ___materialKey_6; }
	inline VP_1_t3287473920 ** get_address_of_materialKey_6() { return &___materialKey_6; }
	inline void set_materialKey_6(VP_1_t3287473920 * value)
	{
		___materialKey_6 = value;
		Il2CppCodeGenWriteBarrier(&___materialKey_6, value);
	}

	inline static int32_t get_offset_of_nonPawnMaterial_7() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___nonPawnMaterial_7)); }
	inline LP_1_t809621404 * get_nonPawnMaterial_7() const { return ___nonPawnMaterial_7; }
	inline LP_1_t809621404 ** get_address_of_nonPawnMaterial_7() { return &___nonPawnMaterial_7; }
	inline void set_nonPawnMaterial_7(LP_1_t809621404 * value)
	{
		___nonPawnMaterial_7 = value;
		Il2CppCodeGenWriteBarrier(&___nonPawnMaterial_7, value);
	}

	inline static int32_t get_offset_of_castlingRights_8() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___castlingRights_8)); }
	inline VP_1_t2450154454 * get_castlingRights_8() const { return ___castlingRights_8; }
	inline VP_1_t2450154454 ** get_address_of_castlingRights_8() { return &___castlingRights_8; }
	inline void set_castlingRights_8(VP_1_t2450154454 * value)
	{
		___castlingRights_8 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRights_8, value);
	}

	inline static int32_t get_offset_of_rule50_9() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___rule50_9)); }
	inline VP_1_t2450154454 * get_rule50_9() const { return ___rule50_9; }
	inline VP_1_t2450154454 ** get_address_of_rule50_9() { return &___rule50_9; }
	inline void set_rule50_9(VP_1_t2450154454 * value)
	{
		___rule50_9 = value;
		Il2CppCodeGenWriteBarrier(&___rule50_9, value);
	}

	inline static int32_t get_offset_of_pliesFromNull_10() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___pliesFromNull_10)); }
	inline VP_1_t2450154454 * get_pliesFromNull_10() const { return ___pliesFromNull_10; }
	inline VP_1_t2450154454 ** get_address_of_pliesFromNull_10() { return &___pliesFromNull_10; }
	inline void set_pliesFromNull_10(VP_1_t2450154454 * value)
	{
		___pliesFromNull_10 = value;
		Il2CppCodeGenWriteBarrier(&___pliesFromNull_10, value);
	}

	inline static int32_t get_offset_of_psq_11() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___psq_11)); }
	inline VP_1_t2450154454 * get_psq_11() const { return ___psq_11; }
	inline VP_1_t2450154454 ** get_address_of_psq_11() { return &___psq_11; }
	inline void set_psq_11(VP_1_t2450154454 * value)
	{
		___psq_11 = value;
		Il2CppCodeGenWriteBarrier(&___psq_11, value);
	}

	inline static int32_t get_offset_of_epSquare_12() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___epSquare_12)); }
	inline VP_1_t2450154454 * get_epSquare_12() const { return ___epSquare_12; }
	inline VP_1_t2450154454 ** get_address_of_epSquare_12() { return &___epSquare_12; }
	inline void set_epSquare_12(VP_1_t2450154454 * value)
	{
		___epSquare_12 = value;
		Il2CppCodeGenWriteBarrier(&___epSquare_12, value);
	}

	inline static int32_t get_offset_of_key_13() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___key_13)); }
	inline VP_1_t3287473920 * get_key_13() const { return ___key_13; }
	inline VP_1_t3287473920 ** get_address_of_key_13() { return &___key_13; }
	inline void set_key_13(VP_1_t3287473920 * value)
	{
		___key_13 = value;
		Il2CppCodeGenWriteBarrier(&___key_13, value);
	}

	inline static int32_t get_offset_of_checkersBB_14() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___checkersBB_14)); }
	inline VP_1_t3287473920 * get_checkersBB_14() const { return ___checkersBB_14; }
	inline VP_1_t3287473920 ** get_address_of_checkersBB_14() { return &___checkersBB_14; }
	inline void set_checkersBB_14(VP_1_t3287473920 * value)
	{
		___checkersBB_14 = value;
		Il2CppCodeGenWriteBarrier(&___checkersBB_14, value);
	}

	inline static int32_t get_offset_of_capturedPiece_15() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___capturedPiece_15)); }
	inline VP_1_t2450154454 * get_capturedPiece_15() const { return ___capturedPiece_15; }
	inline VP_1_t2450154454 ** get_address_of_capturedPiece_15() { return &___capturedPiece_15; }
	inline void set_capturedPiece_15(VP_1_t2450154454 * value)
	{
		___capturedPiece_15 = value;
		Il2CppCodeGenWriteBarrier(&___capturedPiece_15, value);
	}

	inline static int32_t get_offset_of_blockersForKing_16() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___blockersForKing_16)); }
	inline LP_1_t1646940870 * get_blockersForKing_16() const { return ___blockersForKing_16; }
	inline LP_1_t1646940870 ** get_address_of_blockersForKing_16() { return &___blockersForKing_16; }
	inline void set_blockersForKing_16(LP_1_t1646940870 * value)
	{
		___blockersForKing_16 = value;
		Il2CppCodeGenWriteBarrier(&___blockersForKing_16, value);
	}

	inline static int32_t get_offset_of_pinnersForKing_17() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___pinnersForKing_17)); }
	inline LP_1_t1646940870 * get_pinnersForKing_17() const { return ___pinnersForKing_17; }
	inline LP_1_t1646940870 ** get_address_of_pinnersForKing_17() { return &___pinnersForKing_17; }
	inline void set_pinnersForKing_17(LP_1_t1646940870 * value)
	{
		___pinnersForKing_17 = value;
		Il2CppCodeGenWriteBarrier(&___pinnersForKing_17, value);
	}

	inline static int32_t get_offset_of_checkSquares_18() { return static_cast<int32_t>(offsetof(StateInfo_t2831365187, ___checkSquares_18)); }
	inline LP_1_t1646940870 * get_checkSquares_18() const { return ___checkSquares_18; }
	inline LP_1_t1646940870 ** get_address_of_checkSquares_18() { return &___checkSquares_18; }
	inline void set_checkSquares_18(LP_1_t1646940870 * value)
	{
		___checkSquares_18 = value;
		Il2CppCodeGenWriteBarrier(&___checkSquares_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
