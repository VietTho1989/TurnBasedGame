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
// UnityEngine.Networking.SyncListBool
struct SyncListBool_t375623471;
// NetData`1<Seirawan.Seirawan>
struct NetData_1_t3925843283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.SeirawanIdentity
struct  SeirawanIdentity_t629459560  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// DataIdentity/SyncListUInt64 Seirawan.SeirawanIdentity::byTypeBB
	SyncListUInt64_t567569778 * ___byTypeBB_18;
	// DataIdentity/SyncListUInt64 Seirawan.SeirawanIdentity::byColorBB
	SyncListUInt64_t567569778 * ___byColorBB_19;
	// UnityEngine.Networking.SyncListBool Seirawan.SeirawanIdentity::inHand
	SyncListBool_t375623471 * ___inHand_20;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::handScore
	SyncListInt_t3316705628 * ___handScore_21;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::pieceCount
	SyncListInt_t3316705628 * ___pieceCount_22;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::pieceList
	SyncListInt_t3316705628 * ___pieceList_23;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::index
	SyncListInt_t3316705628 * ___index_24;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::castlingRightsMask
	SyncListInt_t3316705628 * ___castlingRightsMask_25;
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanIdentity::castlingRookSquare
	SyncListInt_t3316705628 * ___castlingRookSquare_26;
	// DataIdentity/SyncListUInt64 Seirawan.SeirawanIdentity::castlingPath
	SyncListUInt64_t567569778 * ___castlingPath_27;
	// System.Int32 Seirawan.SeirawanIdentity::gamePly
	int32_t ___gamePly_28;
	// System.Int32 Seirawan.SeirawanIdentity::sideToMove
	int32_t ___sideToMove_29;
	// System.Boolean Seirawan.SeirawanIdentity::chess960
	bool ___chess960_30;
	// System.Boolean Seirawan.SeirawanIdentity::isCustom
	bool ___isCustom_31;
	// NetData`1<Seirawan.Seirawan> Seirawan.SeirawanIdentity::netData
	NetData_1_t3925843283 * ___netData_32;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_byTypeBB_18() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___byTypeBB_18)); }
	inline SyncListUInt64_t567569778 * get_byTypeBB_18() const { return ___byTypeBB_18; }
	inline SyncListUInt64_t567569778 ** get_address_of_byTypeBB_18() { return &___byTypeBB_18; }
	inline void set_byTypeBB_18(SyncListUInt64_t567569778 * value)
	{
		___byTypeBB_18 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_18, value);
	}

	inline static int32_t get_offset_of_byColorBB_19() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___byColorBB_19)); }
	inline SyncListUInt64_t567569778 * get_byColorBB_19() const { return ___byColorBB_19; }
	inline SyncListUInt64_t567569778 ** get_address_of_byColorBB_19() { return &___byColorBB_19; }
	inline void set_byColorBB_19(SyncListUInt64_t567569778 * value)
	{
		___byColorBB_19 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_19, value);
	}

	inline static int32_t get_offset_of_inHand_20() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___inHand_20)); }
	inline SyncListBool_t375623471 * get_inHand_20() const { return ___inHand_20; }
	inline SyncListBool_t375623471 ** get_address_of_inHand_20() { return &___inHand_20; }
	inline void set_inHand_20(SyncListBool_t375623471 * value)
	{
		___inHand_20 = value;
		Il2CppCodeGenWriteBarrier(&___inHand_20, value);
	}

	inline static int32_t get_offset_of_handScore_21() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___handScore_21)); }
	inline SyncListInt_t3316705628 * get_handScore_21() const { return ___handScore_21; }
	inline SyncListInt_t3316705628 ** get_address_of_handScore_21() { return &___handScore_21; }
	inline void set_handScore_21(SyncListInt_t3316705628 * value)
	{
		___handScore_21 = value;
		Il2CppCodeGenWriteBarrier(&___handScore_21, value);
	}

	inline static int32_t get_offset_of_pieceCount_22() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___pieceCount_22)); }
	inline SyncListInt_t3316705628 * get_pieceCount_22() const { return ___pieceCount_22; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCount_22() { return &___pieceCount_22; }
	inline void set_pieceCount_22(SyncListInt_t3316705628 * value)
	{
		___pieceCount_22 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_22, value);
	}

	inline static int32_t get_offset_of_pieceList_23() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___pieceList_23)); }
	inline SyncListInt_t3316705628 * get_pieceList_23() const { return ___pieceList_23; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceList_23() { return &___pieceList_23; }
	inline void set_pieceList_23(SyncListInt_t3316705628 * value)
	{
		___pieceList_23 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_23, value);
	}

	inline static int32_t get_offset_of_index_24() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___index_24)); }
	inline SyncListInt_t3316705628 * get_index_24() const { return ___index_24; }
	inline SyncListInt_t3316705628 ** get_address_of_index_24() { return &___index_24; }
	inline void set_index_24(SyncListInt_t3316705628 * value)
	{
		___index_24 = value;
		Il2CppCodeGenWriteBarrier(&___index_24, value);
	}

	inline static int32_t get_offset_of_castlingRightsMask_25() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___castlingRightsMask_25)); }
	inline SyncListInt_t3316705628 * get_castlingRightsMask_25() const { return ___castlingRightsMask_25; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRightsMask_25() { return &___castlingRightsMask_25; }
	inline void set_castlingRightsMask_25(SyncListInt_t3316705628 * value)
	{
		___castlingRightsMask_25 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRightsMask_25, value);
	}

	inline static int32_t get_offset_of_castlingRookSquare_26() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___castlingRookSquare_26)); }
	inline SyncListInt_t3316705628 * get_castlingRookSquare_26() const { return ___castlingRookSquare_26; }
	inline SyncListInt_t3316705628 ** get_address_of_castlingRookSquare_26() { return &___castlingRookSquare_26; }
	inline void set_castlingRookSquare_26(SyncListInt_t3316705628 * value)
	{
		___castlingRookSquare_26 = value;
		Il2CppCodeGenWriteBarrier(&___castlingRookSquare_26, value);
	}

	inline static int32_t get_offset_of_castlingPath_27() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___castlingPath_27)); }
	inline SyncListUInt64_t567569778 * get_castlingPath_27() const { return ___castlingPath_27; }
	inline SyncListUInt64_t567569778 ** get_address_of_castlingPath_27() { return &___castlingPath_27; }
	inline void set_castlingPath_27(SyncListUInt64_t567569778 * value)
	{
		___castlingPath_27 = value;
		Il2CppCodeGenWriteBarrier(&___castlingPath_27, value);
	}

	inline static int32_t get_offset_of_gamePly_28() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___gamePly_28)); }
	inline int32_t get_gamePly_28() const { return ___gamePly_28; }
	inline int32_t* get_address_of_gamePly_28() { return &___gamePly_28; }
	inline void set_gamePly_28(int32_t value)
	{
		___gamePly_28 = value;
	}

	inline static int32_t get_offset_of_sideToMove_29() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___sideToMove_29)); }
	inline int32_t get_sideToMove_29() const { return ___sideToMove_29; }
	inline int32_t* get_address_of_sideToMove_29() { return &___sideToMove_29; }
	inline void set_sideToMove_29(int32_t value)
	{
		___sideToMove_29 = value;
	}

	inline static int32_t get_offset_of_chess960_30() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___chess960_30)); }
	inline bool get_chess960_30() const { return ___chess960_30; }
	inline bool* get_address_of_chess960_30() { return &___chess960_30; }
	inline void set_chess960_30(bool value)
	{
		___chess960_30 = value;
	}

	inline static int32_t get_offset_of_isCustom_31() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___isCustom_31)); }
	inline bool get_isCustom_31() const { return ___isCustom_31; }
	inline bool* get_address_of_isCustom_31() { return &___isCustom_31; }
	inline void set_isCustom_31(bool value)
	{
		___isCustom_31 = value;
	}

	inline static int32_t get_offset_of_netData_32() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560, ___netData_32)); }
	inline NetData_1_t3925843283 * get_netData_32() const { return ___netData_32; }
	inline NetData_1_t3925843283 ** get_address_of_netData_32() { return &___netData_32; }
	inline void set_netData_32(NetData_1_t3925843283 * value)
	{
		___netData_32 = value;
		Il2CppCodeGenWriteBarrier(&___netData_32, value);
	}
};

struct SeirawanIdentity_t629459560_StaticFields
{
public:
	// System.Int32 Seirawan.SeirawanIdentity::kListboard
	int32_t ___kListboard_33;
	// System.Int32 Seirawan.SeirawanIdentity::kListbyTypeBB
	int32_t ___kListbyTypeBB_34;
	// System.Int32 Seirawan.SeirawanIdentity::kListbyColorBB
	int32_t ___kListbyColorBB_35;
	// System.Int32 Seirawan.SeirawanIdentity::kListinHand
	int32_t ___kListinHand_36;
	// System.Int32 Seirawan.SeirawanIdentity::kListhandScore
	int32_t ___kListhandScore_37;
	// System.Int32 Seirawan.SeirawanIdentity::kListpieceCount
	int32_t ___kListpieceCount_38;
	// System.Int32 Seirawan.SeirawanIdentity::kListpieceList
	int32_t ___kListpieceList_39;
	// System.Int32 Seirawan.SeirawanIdentity::kListindex
	int32_t ___kListindex_40;
	// System.Int32 Seirawan.SeirawanIdentity::kListcastlingRightsMask
	int32_t ___kListcastlingRightsMask_41;
	// System.Int32 Seirawan.SeirawanIdentity::kListcastlingRookSquare
	int32_t ___kListcastlingRookSquare_42;
	// System.Int32 Seirawan.SeirawanIdentity::kListcastlingPath
	int32_t ___kListcastlingPath_43;

public:
	inline static int32_t get_offset_of_kListboard_33() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListboard_33)); }
	inline int32_t get_kListboard_33() const { return ___kListboard_33; }
	inline int32_t* get_address_of_kListboard_33() { return &___kListboard_33; }
	inline void set_kListboard_33(int32_t value)
	{
		___kListboard_33 = value;
	}

	inline static int32_t get_offset_of_kListbyTypeBB_34() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListbyTypeBB_34)); }
	inline int32_t get_kListbyTypeBB_34() const { return ___kListbyTypeBB_34; }
	inline int32_t* get_address_of_kListbyTypeBB_34() { return &___kListbyTypeBB_34; }
	inline void set_kListbyTypeBB_34(int32_t value)
	{
		___kListbyTypeBB_34 = value;
	}

	inline static int32_t get_offset_of_kListbyColorBB_35() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListbyColorBB_35)); }
	inline int32_t get_kListbyColorBB_35() const { return ___kListbyColorBB_35; }
	inline int32_t* get_address_of_kListbyColorBB_35() { return &___kListbyColorBB_35; }
	inline void set_kListbyColorBB_35(int32_t value)
	{
		___kListbyColorBB_35 = value;
	}

	inline static int32_t get_offset_of_kListinHand_36() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListinHand_36)); }
	inline int32_t get_kListinHand_36() const { return ___kListinHand_36; }
	inline int32_t* get_address_of_kListinHand_36() { return &___kListinHand_36; }
	inline void set_kListinHand_36(int32_t value)
	{
		___kListinHand_36 = value;
	}

	inline static int32_t get_offset_of_kListhandScore_37() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListhandScore_37)); }
	inline int32_t get_kListhandScore_37() const { return ___kListhandScore_37; }
	inline int32_t* get_address_of_kListhandScore_37() { return &___kListhandScore_37; }
	inline void set_kListhandScore_37(int32_t value)
	{
		___kListhandScore_37 = value;
	}

	inline static int32_t get_offset_of_kListpieceCount_38() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListpieceCount_38)); }
	inline int32_t get_kListpieceCount_38() const { return ___kListpieceCount_38; }
	inline int32_t* get_address_of_kListpieceCount_38() { return &___kListpieceCount_38; }
	inline void set_kListpieceCount_38(int32_t value)
	{
		___kListpieceCount_38 = value;
	}

	inline static int32_t get_offset_of_kListpieceList_39() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListpieceList_39)); }
	inline int32_t get_kListpieceList_39() const { return ___kListpieceList_39; }
	inline int32_t* get_address_of_kListpieceList_39() { return &___kListpieceList_39; }
	inline void set_kListpieceList_39(int32_t value)
	{
		___kListpieceList_39 = value;
	}

	inline static int32_t get_offset_of_kListindex_40() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListindex_40)); }
	inline int32_t get_kListindex_40() const { return ___kListindex_40; }
	inline int32_t* get_address_of_kListindex_40() { return &___kListindex_40; }
	inline void set_kListindex_40(int32_t value)
	{
		___kListindex_40 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRightsMask_41() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListcastlingRightsMask_41)); }
	inline int32_t get_kListcastlingRightsMask_41() const { return ___kListcastlingRightsMask_41; }
	inline int32_t* get_address_of_kListcastlingRightsMask_41() { return &___kListcastlingRightsMask_41; }
	inline void set_kListcastlingRightsMask_41(int32_t value)
	{
		___kListcastlingRightsMask_41 = value;
	}

	inline static int32_t get_offset_of_kListcastlingRookSquare_42() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListcastlingRookSquare_42)); }
	inline int32_t get_kListcastlingRookSquare_42() const { return ___kListcastlingRookSquare_42; }
	inline int32_t* get_address_of_kListcastlingRookSquare_42() { return &___kListcastlingRookSquare_42; }
	inline void set_kListcastlingRookSquare_42(int32_t value)
	{
		___kListcastlingRookSquare_42 = value;
	}

	inline static int32_t get_offset_of_kListcastlingPath_43() { return static_cast<int32_t>(offsetof(SeirawanIdentity_t629459560_StaticFields, ___kListcastlingPath_43)); }
	inline int32_t get_kListcastlingPath_43() const { return ___kListcastlingPath_43; }
	inline int32_t* get_address_of_kListcastlingPath_43() { return &___kListcastlingPath_43; }
	inline void set_kListcastlingPath_43(int32_t value)
	{
		___kListcastlingPath_43 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
