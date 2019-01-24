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
// NetData`1<Chess.Chess>
struct NetData_1_t2400692683;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.ChessIdentity
struct  ChessIdentity_t487794884  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// DataIdentity/SyncListUInt64 Chess.ChessIdentity::byTypeBB
	SyncListUInt64_t567569778 * ___byTypeBB_18;
	// DataIdentity/SyncListUInt64 Chess.ChessIdentity::byColorBB
	SyncListUInt64_t567569778 * ___byColorBB_19;
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::pieceCount
	SyncListInt_t3316705628 * ___pieceCount_20;
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::pieceList
	SyncListInt_t3316705628 * ___pieceList_21;
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::index
	SyncListInt_t3316705628 * ___index_22;
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::castlingRightsMask
	SyncListInt_t3316705628 * ___castlingRightsMask_23;
	// UnityEngine.Networking.SyncListInt Chess.ChessIdentity::castlingRookSquare
	SyncListInt_t3316705628 * ___castlingRookSquare_24;
	// DataIdentity/SyncListUInt64 Chess.ChessIdentity::castlingPath
	SyncListUInt64_t567569778 * ___castlingPath_25;
	// System.Int32 Chess.ChessIdentity::gamePly
	int32_t ___gamePly_26;
	// System.Int32 Chess.ChessIdentity::sideToMove
	int32_t ___sideToMove_27;
	// System.Boolean Chess.ChessIdentity::chess960
	bool ___chess960_28;
	// System.Boolean Chess.ChessIdentity::isCustom
	bool ___isCustom_29;
	// NetData`1<Chess.Chess> Chess.ChessIdentity::netData
	NetData_1_t2400692683 * ___netData_30;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_byTypeBB_18() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___byTypeBB_18)); }
	inline SyncListUInt64_t567569778 * get_byTypeBB_18() const { return ___byTypeBB_18; }
	inline SyncListUInt64_t567569778 ** get_address_of_byTypeBB_18() { return &___byTypeBB_18; }
	inline void set_byTypeBB_18(SyncListUInt64_t567569778 * value)
	{
		___byTypeBB_18 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_18, value);
	}

	inline static int32_t get_offset_of_byColorBB_19() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___byColorBB_19)); }
	inline SyncListUInt64_t567569778 * get_byColorBB_19() const { return ___byColorBB_19; }
	inline SyncListUInt64_t567569778 ** get_address_of_byColorBB_19() { return &___byColorBB_19; }
	inline void set_byColorBB_19(SyncListUInt64_t567569778 * value)
	{
		___byColorBB_19 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_19, value);
	}

	inline static int32_t get_offset_of_pieceCount_20() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___pieceCount_20)); }
	inline SyncListInt_t3316705628 * get_pieceCount_20() const { return ___pieceCount_20; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCount_20() { return &___pieceCount_20; }
	inline void set_pieceCount_20(SyncListInt_t3316705628 * value)
	{
		___pieceCount_20 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_20, value);
	}

	inline static int32_t get_offset_of_pieceList_21() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___pieceList_21)); }
	inline SyncListInt_t3316705628 * get_pieceList_21() const { return ___pieceList_21; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceList_21() { return &___pieceList_21; }
	inline void set_pieceList_21(SyncListInt_t3316705628 * value)
	{
		___pieceList_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_21, value);
	}

	inline static int32_t get_offset_of_index_22() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___index_22)); }
	inline SyncListInt_t3316705628 * get_index_22() const { return ___index_22; }
	inline SyncListInt_t3316705628 ** get_address_of_index_22() { return &___index_22; }
	inline void set_index_22(SyncListInt_t3316705628 * value)
	{
		___index_22 = value;
		Il2CppCodeGenWriteBarrier(&___index_22, value);
	}

	inline static int32_t get_offset_of_castlingRightsMask_23() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___castlingRightsMask_23)); }
	inline SyncListInt_t3316705628 * get_castlingRightsMask_23() const { return ___castlingRightsMask_23; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRightsMask_23() { return &___castlingRightsMask_23; }
	inline void set_castlingRightsMask_23(SyncListInt_t3316705628 * value)
	{
		___castlingRightsMask_23 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRightsMask_23, value);
	}

	inline static int32_t get_offset_of_castlingRookSquare_24() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___castlingRookSquare_24)); }
	inline SyncListInt_t3316705628 * get_castlingRookSquare_24() const { return ___castlingRookSquare_24; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRookSquare_24() { return &___castlingRookSquare_24; }
	inline void set_castlingRookSquare_24(SyncListInt_t3316705628 * value)
	{
		___castlingRookSquare_24 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRookSquare_24, value);
	}

	inline static int32_t get_offset_of_castlingPath_25() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___castlingPath_25)); }
	inline SyncListUInt64_t567569778 * get_castlingPath_25() const { return ___castlingPath_25; }
	inline SyncListUInt64_t567569778 ** get_address_of_castlingPath_25() { return &___castlingPath_25; }
	inline void set_castlingPath_25(SyncListUInt64_t567569778 * value)
	{
		___castlingPath_25 = value;
		Il2CppCodeGenWriteBarrier(&___castlingPath_25, value);
	}

	inline static int32_t get_offset_of_gamePly_26() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___gamePly_26)); }
	inline int32_t get_gamePly_26() const { return ___gamePly_26; }
	inline int32_t* get_address_of_gamePly_26() { return &___gamePly_26; }
	inline void set_gamePly_26(int32_t value)
	{
		___gamePly_26 = value;
	}

	inline static int32_t get_offset_of_sideToMove_27() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___sideToMove_27)); }
	inline int32_t get_sideToMove_27() const { return ___sideToMove_27; }
	inline int32_t* get_address_of_sideToMove_27() { return &___sideToMove_27; }
	inline void set_sideToMove_27(int32_t value)
	{
		___sideToMove_27 = value;
	}

	inline static int32_t get_offset_of_chess960_28() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___chess960_28)); }
	inline bool get_chess960_28() const { return ___chess960_28; }
	inline bool* get_address_of_chess960_28() { return &___chess960_28; }
	inline void set_chess960_28(bool value)
	{
		___chess960_28 = value;
	}

	inline static int32_t get_offset_of_isCustom_29() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___isCustom_29)); }
	inline bool get_isCustom_29() const { return ___isCustom_29; }
	inline bool* get_address_of_isCustom_29() { return &___isCustom_29; }
	inline void set_isCustom_29(bool value)
	{
		___isCustom_29 = value;
	}

	inline static int32_t get_offset_of_netData_30() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884, ___netData_30)); }
	inline NetData_1_t2400692683 * get_netData_30() const { return ___netData_30; }
	inline NetData_1_t2400692683 ** get_address_of_netData_30() { return &___netData_30; }
	inline void set_netData_30(NetData_1_t2400692683 * value)
	{
		___netData_30 = value;
		Il2CppCodeGenWriteBarrier(&___netData_30, value);
	}
};

struct ChessIdentity_t487794884_StaticFields
{
public:
	// System.Int32 Chess.ChessIdentity::kListboard
	int32_t ___kListboard_31;
	// System.Int32 Chess.ChessIdentity::kListbyTypeBB
	int32_t ___kListbyTypeBB_32;
	// System.Int32 Chess.ChessIdentity::kListbyColorBB
	int32_t ___kListbyColorBB_33;
	// System.Int32 Chess.ChessIdentity::kListpieceCount
	int32_t ___kListpieceCount_34;
	// System.Int32 Chess.ChessIdentity::kListpieceList
	int32_t ___kListpieceList_35;
	// System.Int32 Chess.ChessIdentity::kListindex
	int32_t ___kListindex_36;
	// System.Int32 Chess.ChessIdentity::kListcastlingRightsMask
	int32_t ___kListcastlingRightsMask_37;
	// System.Int32 Chess.ChessIdentity::kListcastlingRookSquare
	int32_t ___kListcastlingRookSquare_38;
	// System.Int32 Chess.ChessIdentity::kListcastlingPath
	int32_t ___kListcastlingPath_39;

public:
	inline static int32_t get_offset_of_kListboard_31() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListboard_31)); }
	inline int32_t get_kListboard_31() const { return ___kListboard_31; }
	inline int32_t* get_address_of_kListboard_31() { return &___kListboard_31; }
	inline void set_kListboard_31(int32_t value)
	{
		___kListboard_31 = value;
	}

	inline static int32_t get_offset_of_kListbyTypeBB_32() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListbyTypeBB_32)); }
	inline int32_t get_kListbyTypeBB_32() const { return ___kListbyTypeBB_32; }
	inline int32_t* get_address_of_kListbyTypeBB_32() { return &___kListbyTypeBB_32; }
	inline void set_kListbyTypeBB_32(int32_t value)
	{
		___kListbyTypeBB_32 = value;
	}

	inline static int32_t get_offset_of_kListbyColorBB_33() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListbyColorBB_33)); }
	inline int32_t get_kListbyColorBB_33() const { return ___kListbyColorBB_33; }
	inline int32_t* get_address_of_kListbyColorBB_33() { return &___kListbyColorBB_33; }
	inline void set_kListbyColorBB_33(int32_t value)
	{
		___kListbyColorBB_33 = value;
	}

	inline static int32_t get_offset_of_kListpieceCount_34() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListpieceCount_34)); }
	inline int32_t get_kListpieceCount_34() const { return ___kListpieceCount_34; }
	inline int32_t* get_address_of_kListpieceCount_34() { return &___kListpieceCount_34; }
	inline void set_kListpieceCount_34(int32_t value)
	{
		___kListpieceCount_34 = value;
	}

	inline static int32_t get_offset_of_kListpieceList_35() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListpieceList_35)); }
	inline int32_t get_kListpieceList_35() const { return ___kListpieceList_35; }
	inline int32_t* get_address_of_kListpieceList_35() { return &___kListpieceList_35; }
	inline void set_kListpieceList_35(int32_t value)
	{
		___kListpieceList_35 = value;
	}

	inline static int32_t get_offset_of_kListindex_36() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListindex_36)); }
	inline int32_t get_kListindex_36() const { return ___kListindex_36; }
	inline int32_t* get_address_of_kListindex_36() { return &___kListindex_36; }
	inline void set_kListindex_36(int32_t value)
	{
		___kListindex_36 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRightsMask_37() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListcastlingRightsMask_37)); }
	inline int32_t get_kListcastlingRightsMask_37() const { return ___kListcastlingRightsMask_37; }
	inline int32_t* get_address_of_kListcastlingRightsMask_37() { return &___kListcastlingRightsMask_37; }
	inline void set_kListcastlingRightsMask_37(int32_t value)
	{
		___kListcastlingRightsMask_37 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRookSquare_38() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListcastlingRookSquare_38)); }
	inline int32_t get_kListcastlingRookSquare_38() const { return ___kListcastlingRookSquare_38; }
	inline int32_t* get_address_of_kListcastlingRookSquare_38() { return &___kListcastlingRookSquare_38; }
	inline void set_kListcastlingRookSquare_38(int32_t value)
	{
		___kListcastlingRookSquare_38 = value;
	}

	inline static int32_t get_offset_of_kListcastlingPath_39() { return static_cast<int32_t>(offsetof(ChessIdentity_t487794884_StaticFields, ___kListcastlingPath_39)); }
	inline int32_t get_kListcastlingPath_39() const { return ___kListcastlingPath_39; }
	inline int32_t* get_address_of_kListcastlingPath_39() { return &___kListcastlingPath_39; }
	inline void set_kListcastlingPath_39(int32_t value)
	{
		___kListcastlingPath_39 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
