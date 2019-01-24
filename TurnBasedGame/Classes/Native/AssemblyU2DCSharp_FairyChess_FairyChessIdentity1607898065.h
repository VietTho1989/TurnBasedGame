#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// DataIdentity/SyncListUInt64
struct SyncListUInt64_t567569778;
// NetData`1<FairyChess.FairyChess>
struct NetData_1_t4139145856;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.FairyChessIdentity
struct  FairyChessIdentity_t1607898065  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::unpromotedBoard
	SyncListInt_t3316705628 * ___unpromotedBoard_18;
	// DataIdentity/SyncListUInt64 FairyChess.FairyChessIdentity::byTypeBB
	SyncListUInt64_t567569778 * ___byTypeBB_19;
	// DataIdentity/SyncListUInt64 FairyChess.FairyChessIdentity::byColorBB
	SyncListUInt64_t567569778 * ___byColorBB_20;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::pieceCount
	SyncListInt_t3316705628 * ___pieceCount_21;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::pieceList
	SyncListInt_t3316705628 * ___pieceList_22;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::index
	SyncListInt_t3316705628 * ___index_23;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::castlingRightsMask
	SyncListInt_t3316705628 * ___castlingRightsMask_24;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::castlingRookSquare
	SyncListInt_t3316705628 * ___castlingRookSquare_25;
	// DataIdentity/SyncListUInt64 FairyChess.FairyChessIdentity::castlingPath
	SyncListUInt64_t567569778 * ___castlingPath_26;
	// System.Int32 FairyChess.FairyChessIdentity::gamePly
	int32_t ___gamePly_27;
	// System.Int32 FairyChess.FairyChessIdentity::sideToMove
	int32_t ___sideToMove_28;
	// System.Int32 FairyChess.FairyChessIdentity::variantType
	int32_t ___variantType_29;
	// System.Boolean FairyChess.FairyChessIdentity::chess960
	bool ___chess960_30;
	// UnityEngine.Networking.SyncListInt FairyChess.FairyChessIdentity::pieceCountInHand
	SyncListInt_t3316705628 * ___pieceCountInHand_31;
	// System.UInt64 FairyChess.FairyChessIdentity::promotedPieces
	uint64_t ___promotedPieces_32;
	// System.Boolean FairyChess.FairyChessIdentity::isCustom
	bool ___isCustom_33;
	// NetData`1<FairyChess.FairyChess> FairyChess.FairyChessIdentity::netData
	NetData_1_t4139145856 * ___netData_34;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_unpromotedBoard_18() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___unpromotedBoard_18)); }
	inline SyncListInt_t3316705628 * get_unpromotedBoard_18() const { return ___unpromotedBoard_18; }
	inline SyncListInt_t3316705628 ** get_address_of_unpromotedBoard_18() { return &___unpromotedBoard_18; }
	inline void set_unpromotedBoard_18(SyncListInt_t3316705628 * value)
	{
		___unpromotedBoard_18 = value;
		Il2CppCodeGenWriteBarrier(&___unpromotedBoard_18, value);
	}

	inline static int32_t get_offset_of_byTypeBB_19() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___byTypeBB_19)); }
	inline SyncListUInt64_t567569778 * get_byTypeBB_19() const { return ___byTypeBB_19; }
	inline SyncListUInt64_t567569778 ** get_address_of_byTypeBB_19() { return &___byTypeBB_19; }
	inline void set_byTypeBB_19(SyncListUInt64_t567569778 * value)
	{
		___byTypeBB_19 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_19, value);
	}

	inline static int32_t get_offset_of_byColorBB_20() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___byColorBB_20)); }
	inline SyncListUInt64_t567569778 * get_byColorBB_20() const { return ___byColorBB_20; }
	inline SyncListUInt64_t567569778 ** get_address_of_byColorBB_20() { return &___byColorBB_20; }
	inline void set_byColorBB_20(SyncListUInt64_t567569778 * value)
	{
		___byColorBB_20 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_20, value);
	}

	inline static int32_t get_offset_of_pieceCount_21() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___pieceCount_21)); }
	inline SyncListInt_t3316705628 * get_pieceCount_21() const { return ___pieceCount_21; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCount_21() { return &___pieceCount_21; }
	inline void set_pieceCount_21(SyncListInt_t3316705628 * value)
	{
		___pieceCount_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_21, value);
	}

	inline static int32_t get_offset_of_pieceList_22() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___pieceList_22)); }
	inline SyncListInt_t3316705628 * get_pieceList_22() const { return ___pieceList_22; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceList_22() { return &___pieceList_22; }
	inline void set_pieceList_22(SyncListInt_t3316705628 * value)
	{
		___pieceList_22 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_22, value);
	}

	inline static int32_t get_offset_of_index_23() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___index_23)); }
	inline SyncListInt_t3316705628 * get_index_23() const { return ___index_23; }
	inline SyncListInt_t3316705628 ** get_address_of_index_23() { return &___index_23; }
	inline void set_index_23(SyncListInt_t3316705628 * value)
	{
		___index_23 = value;
		Il2CppCodeGenWriteBarrier(&___index_23, value);
	}

	inline static int32_t get_offset_of_castlingRightsMask_24() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___castlingRightsMask_24)); }
	inline SyncListInt_t3316705628 * get_castlingRightsMask_24() const { return ___castlingRightsMask_24; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRightsMask_24() { return &___castlingRightsMask_24; }
	inline void set_castlingRightsMask_24(SyncListInt_t3316705628 * value)
	{
		___castlingRightsMask_24 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRightsMask_24, value);
	}

	inline static int32_t get_offset_of_castlingRookSquare_25() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___castlingRookSquare_25)); }
	inline SyncListInt_t3316705628 * get_castlingRookSquare_25() const { return ___castlingRookSquare_25; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRookSquare_25() { return &___castlingRookSquare_25; }
	inline void set_castlingRookSquare_25(SyncListInt_t3316705628 * value)
	{
		___castlingRookSquare_25 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRookSquare_25, value);
	}

	inline static int32_t get_offset_of_castlingPath_26() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___castlingPath_26)); }
	inline SyncListUInt64_t567569778 * get_castlingPath_26() const { return ___castlingPath_26; }
	inline SyncListUInt64_t567569778 ** get_address_of_castlingPath_26() { return &___castlingPath_26; }
	inline void set_castlingPath_26(SyncListUInt64_t567569778 * value)
	{
		___castlingPath_26 = value;
		Il2CppCodeGenWriteBarrier(&___castlingPath_26, value);
	}

	inline static int32_t get_offset_of_gamePly_27() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___gamePly_27)); }
	inline int32_t get_gamePly_27() const { return ___gamePly_27; }
	inline int32_t* get_address_of_gamePly_27() { return &___gamePly_27; }
	inline void set_gamePly_27(int32_t value)
	{
		___gamePly_27 = value;
	}

	inline static int32_t get_offset_of_sideToMove_28() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___sideToMove_28)); }
	inline int32_t get_sideToMove_28() const { return ___sideToMove_28; }
	inline int32_t* get_address_of_sideToMove_28() { return &___sideToMove_28; }
	inline void set_sideToMove_28(int32_t value)
	{
		___sideToMove_28 = value;
	}

	inline static int32_t get_offset_of_variantType_29() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___variantType_29)); }
	inline int32_t get_variantType_29() const { return ___variantType_29; }
	inline int32_t* get_address_of_variantType_29() { return &___variantType_29; }
	inline void set_variantType_29(int32_t value)
	{
		___variantType_29 = value;
	}

	inline static int32_t get_offset_of_chess960_30() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___chess960_30)); }
	inline bool get_chess960_30() const { return ___chess960_30; }
	inline bool* get_address_of_chess960_30() { return &___chess960_30; }
	inline void set_chess960_30(bool value)
	{
		___chess960_30 = value;
	}

	inline static int32_t get_offset_of_pieceCountInHand_31() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___pieceCountInHand_31)); }
	inline SyncListInt_t3316705628 * get_pieceCountInHand_31() const { return ___pieceCountInHand_31; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCountInHand_31() { return &___pieceCountInHand_31; }
	inline void set_pieceCountInHand_31(SyncListInt_t3316705628 * value)
	{
		___pieceCountInHand_31 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCountInHand_31, value);
	}

	inline static int32_t get_offset_of_promotedPieces_32() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___promotedPieces_32)); }
	inline uint64_t get_promotedPieces_32() const { return ___promotedPieces_32; }
	inline uint64_t* get_address_of_promotedPieces_32() { return &___promotedPieces_32; }
	inline void set_promotedPieces_32(uint64_t value)
	{
		___promotedPieces_32 = value;
	}

	inline static int32_t get_offset_of_isCustom_33() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___isCustom_33)); }
	inline bool get_isCustom_33() const { return ___isCustom_33; }
	inline bool* get_address_of_isCustom_33() { return &___isCustom_33; }
	inline void set_isCustom_33(bool value)
	{
		___isCustom_33 = value;
	}

	inline static int32_t get_offset_of_netData_34() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065, ___netData_34)); }
	inline NetData_1_t4139145856 * get_netData_34() const { return ___netData_34; }
	inline NetData_1_t4139145856 ** get_address_of_netData_34() { return &___netData_34; }
	inline void set_netData_34(NetData_1_t4139145856 * value)
	{
		___netData_34 = value;
		Il2CppCodeGenWriteBarrier(&___netData_34, value);
	}
};

struct FairyChessIdentity_t1607898065_StaticFields
{
public:
	// System.Int32 FairyChess.FairyChessIdentity::kListboard
	int32_t ___kListboard_35;
	// System.Int32 FairyChess.FairyChessIdentity::kListunpromotedBoard
	int32_t ___kListunpromotedBoard_36;
	// System.Int32 FairyChess.FairyChessIdentity::kListbyTypeBB
	int32_t ___kListbyTypeBB_37;
	// System.Int32 FairyChess.FairyChessIdentity::kListbyColorBB
	int32_t ___kListbyColorBB_38;
	// System.Int32 FairyChess.FairyChessIdentity::kListpieceCount
	int32_t ___kListpieceCount_39;
	// System.Int32 FairyChess.FairyChessIdentity::kListpieceList
	int32_t ___kListpieceList_40;
	// System.Int32 FairyChess.FairyChessIdentity::kListindex
	int32_t ___kListindex_41;
	// System.Int32 FairyChess.FairyChessIdentity::kListcastlingRightsMask
	int32_t ___kListcastlingRightsMask_42;
	// System.Int32 FairyChess.FairyChessIdentity::kListcastlingRookSquare
	int32_t ___kListcastlingRookSquare_43;
	// System.Int32 FairyChess.FairyChessIdentity::kListcastlingPath
	int32_t ___kListcastlingPath_44;
	// System.Int32 FairyChess.FairyChessIdentity::kListpieceCountInHand
	int32_t ___kListpieceCountInHand_45;

public:
	inline static int32_t get_offset_of_kListboard_35() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListboard_35)); }
	inline int32_t get_kListboard_35() const { return ___kListboard_35; }
	inline int32_t* get_address_of_kListboard_35() { return &___kListboard_35; }
	inline void set_kListboard_35(int32_t value)
	{
		___kListboard_35 = value;
	}

	inline static int32_t get_offset_of_kListunpromotedBoard_36() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListunpromotedBoard_36)); }
	inline int32_t get_kListunpromotedBoard_36() const { return ___kListunpromotedBoard_36; }
	inline int32_t* get_address_of_kListunpromotedBoard_36() { return &___kListunpromotedBoard_36; }
	inline void set_kListunpromotedBoard_36(int32_t value)
	{
		___kListunpromotedBoard_36 = value;
	}

	inline static int32_t get_offset_of_kListbyTypeBB_37() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListbyTypeBB_37)); }
	inline int32_t get_kListbyTypeBB_37() const { return ___kListbyTypeBB_37; }
	inline int32_t* get_address_of_kListbyTypeBB_37() { return &___kListbyTypeBB_37; }
	inline void set_kListbyTypeBB_37(int32_t value)
	{
		___kListbyTypeBB_37 = value;
	}

	inline static int32_t get_offset_of_kListbyColorBB_38() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListbyColorBB_38)); }
	inline int32_t get_kListbyColorBB_38() const { return ___kListbyColorBB_38; }
	inline int32_t* get_address_of_kListbyColorBB_38() { return &___kListbyColorBB_38; }
	inline void set_kListbyColorBB_38(int32_t value)
	{
		___kListbyColorBB_38 = value;
	}

	inline static int32_t get_offset_of_kListpieceCount_39() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListpieceCount_39)); }
	inline int32_t get_kListpieceCount_39() const { return ___kListpieceCount_39; }
	inline int32_t* get_address_of_kListpieceCount_39() { return &___kListpieceCount_39; }
	inline void set_kListpieceCount_39(int32_t value)
	{
		___kListpieceCount_39 = value;
	}

	inline static int32_t get_offset_of_kListpieceList_40() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListpieceList_40)); }
	inline int32_t get_kListpieceList_40() const { return ___kListpieceList_40; }
	inline int32_t* get_address_of_kListpieceList_40() { return &___kListpieceList_40; }
	inline void set_kListpieceList_40(int32_t value)
	{
		___kListpieceList_40 = value;
	}

	inline static int32_t get_offset_of_kListindex_41() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListindex_41)); }
	inline int32_t get_kListindex_41() const { return ___kListindex_41; }
	inline int32_t* get_address_of_kListindex_41() { return &___kListindex_41; }
	inline void set_kListindex_41(int32_t value)
	{
		___kListindex_41 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRightsMask_42() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListcastlingRightsMask_42)); }
	inline int32_t get_kListcastlingRightsMask_42() const { return ___kListcastlingRightsMask_42; }
	inline int32_t* get_address_of_kListcastlingRightsMask_42() { return &___kListcastlingRightsMask_42; }
	inline void set_kListcastlingRightsMask_42(int32_t value)
	{
		___kListcastlingRightsMask_42 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRookSquare_43() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListcastlingRookSquare_43)); }
	inline int32_t get_kListcastlingRookSquare_43() const { return ___kListcastlingRookSquare_43; }
	inline int32_t* get_address_of_kListcastlingRookSquare_43() { return &___kListcastlingRookSquare_43; }
	inline void set_kListcastlingRookSquare_43(int32_t value)
	{
		___kListcastlingRookSquare_43 = value;
	}

	inline static int32_t get_offset_of_kListcastlingPath_44() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListcastlingPath_44)); }
	inline int32_t get_kListcastlingPath_44() const { return ___kListcastlingPath_44; }
	inline int32_t* get_address_of_kListcastlingPath_44() { return &___kListcastlingPath_44; }
	inline void set_kListcastlingPath_44(int32_t value)
	{
		___kListcastlingPath_44 = value;
	}

	inline static int32_t get_offset_of_kListpieceCountInHand_45() { return static_cast<int32_t>(offsetof(FairyChessIdentity_t1607898065_StaticFields, ___kListpieceCountInHand_45)); }
	inline int32_t get_kListpieceCountInHand_45() const { return ___kListpieceCountInHand_45; }
	inline int32_t* get_address_of_kListpieceCountInHand_45() { return &___kListpieceCountInHand_45; }
	inline void set_kListpieceCountInHand_45(int32_t value)
	{
		___kListpieceCountInHand_45 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
