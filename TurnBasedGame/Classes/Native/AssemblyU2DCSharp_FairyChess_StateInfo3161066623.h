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
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.StateInfo
struct  StateInfo_t3161066623  : public Data_t3569509720
{
public:
	// VP`1<System.UInt64> FairyChess.StateInfo::pawnKey
	VP_1_t3287473920 * ___pawnKey_5;
	// VP`1<System.UInt64> FairyChess.StateInfo::materialKey
	VP_1_t3287473920 * ___materialKey_6;
	// LP`1<System.Int32> FairyChess.StateInfo::nonPawnMaterial
	LP_1_t809621404 * ___nonPawnMaterial_7;
	// VP`1<System.Int32> FairyChess.StateInfo::castlingRights
	VP_1_t2450154454 * ___castlingRights_8;
	// VP`1<System.Int32> FairyChess.StateInfo::rule50
	VP_1_t2450154454 * ___rule50_9;
	// VP`1<System.Int32> FairyChess.StateInfo::pliesFromNull
	VP_1_t2450154454 * ___pliesFromNull_10;
	// LP`1<System.Int32> FairyChess.StateInfo::checksGiven
	LP_1_t809621404 * ___checksGiven_11;
	// VP`1<System.Int32> FairyChess.StateInfo::psq
	VP_1_t2450154454 * ___psq_12;
	// VP`1<System.Int32> FairyChess.StateInfo::epSquare
	VP_1_t2450154454 * ___epSquare_13;
	// VP`1<System.UInt64> FairyChess.StateInfo::key
	VP_1_t3287473920 * ___key_14;
	// VP`1<System.UInt64> FairyChess.StateInfo::checkersBB
	VP_1_t3287473920 * ___checkersBB_15;
	// VP`1<System.Int32> FairyChess.StateInfo::capturedPiece
	VP_1_t2450154454 * ___capturedPiece_16;
	// VP`1<System.Int32> FairyChess.StateInfo::unpromotedCapturedPiece
	VP_1_t2450154454 * ___unpromotedCapturedPiece_17;
	// LP`1<System.UInt64> FairyChess.StateInfo::blockersForKing
	LP_1_t1646940870 * ___blockersForKing_18;
	// LP`1<System.UInt64> FairyChess.StateInfo::pinners
	LP_1_t1646940870 * ___pinners_19;
	// LP`1<System.UInt64> FairyChess.StateInfo::checkSquares
	LP_1_t1646940870 * ___checkSquares_20;
	// VP`1<System.Boolean> FairyChess.StateInfo::capturedpromoted
	VP_1_t4203851724 * ___capturedpromoted_21;

public:
	inline static int32_t get_offset_of_pawnKey_5() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___pawnKey_5)); }
	inline VP_1_t3287473920 * get_pawnKey_5() const { return ___pawnKey_5; }
	inline VP_1_t3287473920 ** get_address_of_pawnKey_5() { return &___pawnKey_5; }
	inline void set_pawnKey_5(VP_1_t3287473920 * value)
	{
		___pawnKey_5 = value;
		Il2CppCodeGenWriteBarrier(&___pawnKey_5, value);
	}

	inline static int32_t get_offset_of_materialKey_6() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___materialKey_6)); }
	inline VP_1_t3287473920 * get_materialKey_6() const { return ___materialKey_6; }
	inline VP_1_t3287473920 ** get_address_of_materialKey_6() { return &___materialKey_6; }
	inline void set_materialKey_6(VP_1_t3287473920 * value)
	{
		___materialKey_6 = value;
		Il2CppCodeGenWriteBarrier(&___materialKey_6, value);
	}

	inline static int32_t get_offset_of_nonPawnMaterial_7() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___nonPawnMaterial_7)); }
	inline LP_1_t809621404 * get_nonPawnMaterial_7() const { return ___nonPawnMaterial_7; }
	inline LP_1_t809621404 ** get_address_of_nonPawnMaterial_7() { return &___nonPawnMaterial_7; }
	inline void set_nonPawnMaterial_7(LP_1_t809621404 * value)
	{
		___nonPawnMaterial_7 = value;
		Il2CppCodeGenWriteBarrier(&___nonPawnMaterial_7, value);
	}

	inline static int32_t get_offset_of_castlingRights_8() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___castlingRights_8)); }
	inline VP_1_t2450154454 * get_castlingRights_8() const { return ___castlingRights_8; }
	inline VP_1_t2450154454 ** get_address_of_castlingRights_8() { return &___castlingRights_8; }
	inline void set_castlingRights_8(VP_1_t2450154454 * value)
	{
		___castlingRights_8 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRights_8, value);
	}

	inline static int32_t get_offset_of_rule50_9() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___rule50_9)); }
	inline VP_1_t2450154454 * get_rule50_9() const { return ___rule50_9; }
	inline VP_1_t2450154454 ** get_address_of_rule50_9() { return &___rule50_9; }
	inline void set_rule50_9(VP_1_t2450154454 * value)
	{
		___rule50_9 = value;
		Il2CppCodeGenWriteBarrier(&___rule50_9, value);
	}

	inline static int32_t get_offset_of_pliesFromNull_10() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___pliesFromNull_10)); }
	inline VP_1_t2450154454 * get_pliesFromNull_10() const { return ___pliesFromNull_10; }
	inline VP_1_t2450154454 ** get_address_of_pliesFromNull_10() { return &___pliesFromNull_10; }
	inline void set_pliesFromNull_10(VP_1_t2450154454 * value)
	{
		___pliesFromNull_10 = value;
		Il2CppCodeGenWriteBarrier(&___pliesFromNull_10, value);
	}

	inline static int32_t get_offset_of_checksGiven_11() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___checksGiven_11)); }
	inline LP_1_t809621404 * get_checksGiven_11() const { return ___checksGiven_11; }
	inline LP_1_t809621404 ** get_address_of_checksGiven_11() { return &___checksGiven_11; }
	inline void set_checksGiven_11(LP_1_t809621404 * value)
	{
		___checksGiven_11 = value;
		Il2CppCodeGenWriteBarrier(&___checksGiven_11, value);
	}

	inline static int32_t get_offset_of_psq_12() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___psq_12)); }
	inline VP_1_t2450154454 * get_psq_12() const { return ___psq_12; }
	inline VP_1_t2450154454 ** get_address_of_psq_12() { return &___psq_12; }
	inline void set_psq_12(VP_1_t2450154454 * value)
	{
		___psq_12 = value;
		Il2CppCodeGenWriteBarrier(&___psq_12, value);
	}

	inline static int32_t get_offset_of_epSquare_13() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___epSquare_13)); }
	inline VP_1_t2450154454 * get_epSquare_13() const { return ___epSquare_13; }
	inline VP_1_t2450154454 ** get_address_of_epSquare_13() { return &___epSquare_13; }
	inline void set_epSquare_13(VP_1_t2450154454 * value)
	{
		___epSquare_13 = value;
		Il2CppCodeGenWriteBarrier(&___epSquare_13, value);
	}

	inline static int32_t get_offset_of_key_14() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___key_14)); }
	inline VP_1_t3287473920 * get_key_14() const { return ___key_14; }
	inline VP_1_t3287473920 ** get_address_of_key_14() { return &___key_14; }
	inline void set_key_14(VP_1_t3287473920 * value)
	{
		___key_14 = value;
		Il2CppCodeGenWriteBarrier(&___key_14, value);
	}

	inline static int32_t get_offset_of_checkersBB_15() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___checkersBB_15)); }
	inline VP_1_t3287473920 * get_checkersBB_15() const { return ___checkersBB_15; }
	inline VP_1_t3287473920 ** get_address_of_checkersBB_15() { return &___checkersBB_15; }
	inline void set_checkersBB_15(VP_1_t3287473920 * value)
	{
		___checkersBB_15 = value;
		Il2CppCodeGenWriteBarrier(&___checkersBB_15, value);
	}

	inline static int32_t get_offset_of_capturedPiece_16() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___capturedPiece_16)); }
	inline VP_1_t2450154454 * get_capturedPiece_16() const { return ___capturedPiece_16; }
	inline VP_1_t2450154454 ** get_address_of_capturedPiece_16() { return &___capturedPiece_16; }
	inline void set_capturedPiece_16(VP_1_t2450154454 * value)
	{
		___capturedPiece_16 = value;
		Il2CppCodeGenWriteBarrier(&___capturedPiece_16, value);
	}

	inline static int32_t get_offset_of_unpromotedCapturedPiece_17() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___unpromotedCapturedPiece_17)); }
	inline VP_1_t2450154454 * get_unpromotedCapturedPiece_17() const { return ___unpromotedCapturedPiece_17; }
	inline VP_1_t2450154454 ** get_address_of_unpromotedCapturedPiece_17() { return &___unpromotedCapturedPiece_17; }
	inline void set_unpromotedCapturedPiece_17(VP_1_t2450154454 * value)
	{
		___unpromotedCapturedPiece_17 = value;
		Il2CppCodeGenWriteBarrier(&___unpromotedCapturedPiece_17, value);
	}

	inline static int32_t get_offset_of_blockersForKing_18() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___blockersForKing_18)); }
	inline LP_1_t1646940870 * get_blockersForKing_18() const { return ___blockersForKing_18; }
	inline LP_1_t1646940870 ** get_address_of_blockersForKing_18() { return &___blockersForKing_18; }
	inline void set_blockersForKing_18(LP_1_t1646940870 * value)
	{
		___blockersForKing_18 = value;
		Il2CppCodeGenWriteBarrier(&___blockersForKing_18, value);
	}

	inline static int32_t get_offset_of_pinners_19() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___pinners_19)); }
	inline LP_1_t1646940870 * get_pinners_19() const { return ___pinners_19; }
	inline LP_1_t1646940870 ** get_address_of_pinners_19() { return &___pinners_19; }
	inline void set_pinners_19(LP_1_t1646940870 * value)
	{
		___pinners_19 = value;
		Il2CppCodeGenWriteBarrier(&___pinners_19, value);
	}

	inline static int32_t get_offset_of_checkSquares_20() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___checkSquares_20)); }
	inline LP_1_t1646940870 * get_checkSquares_20() const { return ___checkSquares_20; }
	inline LP_1_t1646940870 ** get_address_of_checkSquares_20() { return &___checkSquares_20; }
	inline void set_checkSquares_20(LP_1_t1646940870 * value)
	{
		___checkSquares_20 = value;
		Il2CppCodeGenWriteBarrier(&___checkSquares_20, value);
	}

	inline static int32_t get_offset_of_capturedpromoted_21() { return static_cast<int32_t>(offsetof(StateInfo_t3161066623, ___capturedpromoted_21)); }
	inline VP_1_t4203851724 * get_capturedpromoted_21() const { return ___capturedpromoted_21; }
	inline VP_1_t4203851724 ** get_address_of_capturedpromoted_21() { return &___capturedpromoted_21; }
	inline void set_capturedpromoted_21(VP_1_t4203851724 * value)
	{
		___capturedpromoted_21 = value;
		Il2CppCodeGenWriteBarrier(&___capturedpromoted_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
