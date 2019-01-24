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
// NetData`1<Makruk.Makruk>
struct NetData_1_t3199195824;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.MakrukIdentity
struct  MakrukIdentity_t1358353409  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Makruk.MakrukIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// DataIdentity/SyncListUInt64 Makruk.MakrukIdentity::byTypeBB
	SyncListUInt64_t567569778 * ___byTypeBB_18;
	// DataIdentity/SyncListUInt64 Makruk.MakrukIdentity::byColorBB
	SyncListUInt64_t567569778 * ___byColorBB_19;
	// UnityEngine.Networking.SyncListInt Makruk.MakrukIdentity::pieceCount
	SyncListInt_t3316705628 * ___pieceCount_20;
	// UnityEngine.Networking.SyncListInt Makruk.MakrukIdentity::pieceList
	SyncListInt_t3316705628 * ___pieceList_21;
	// UnityEngine.Networking.SyncListInt Makruk.MakrukIdentity::index
	SyncListInt_t3316705628 * ___index_22;
	// System.Int32 Makruk.MakrukIdentity::gamePly
	int32_t ___gamePly_23;
	// System.Int32 Makruk.MakrukIdentity::sideToMove
	int32_t ___sideToMove_24;
	// System.Boolean Makruk.MakrukIdentity::chess960
	bool ___chess960_25;
	// System.Boolean Makruk.MakrukIdentity::isCustom
	bool ___isCustom_26;
	// NetData`1<Makruk.Makruk> Makruk.MakrukIdentity::netData
	NetData_1_t3199195824 * ___netData_27;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_byTypeBB_18() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___byTypeBB_18)); }
	inline SyncListUInt64_t567569778 * get_byTypeBB_18() const { return ___byTypeBB_18; }
	inline SyncListUInt64_t567569778 ** get_address_of_byTypeBB_18() { return &___byTypeBB_18; }
	inline void set_byTypeBB_18(SyncListUInt64_t567569778 * value)
	{
		___byTypeBB_18 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_18, value);
	}

	inline static int32_t get_offset_of_byColorBB_19() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___byColorBB_19)); }
	inline SyncListUInt64_t567569778 * get_byColorBB_19() const { return ___byColorBB_19; }
	inline SyncListUInt64_t567569778 ** get_address_of_byColorBB_19() { return &___byColorBB_19; }
	inline void set_byColorBB_19(SyncListUInt64_t567569778 * value)
	{
		___byColorBB_19 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_19, value);
	}

	inline static int32_t get_offset_of_pieceCount_20() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___pieceCount_20)); }
	inline SyncListInt_t3316705628 * get_pieceCount_20() const { return ___pieceCount_20; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceCount_20() { return &___pieceCount_20; }
	inline void set_pieceCount_20(SyncListInt_t3316705628 * value)
	{
		___pieceCount_20 = value;
		Il2CppCodeGenWriteBarrier(&___pieceCount_20, value);
	}

	inline static int32_t get_offset_of_pieceList_21() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___pieceList_21)); }
	inline SyncListInt_t3316705628 * get_pieceList_21() const { return ___pieceList_21; }
	inline SyncListInt_t3316705628 ** get_address_of_pieceList_21() { return &___pieceList_21; }
	inline void set_pieceList_21(SyncListInt_t3316705628 * value)
	{
		___pieceList_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieceList_21, value);
	}

	inline static int32_t get_offset_of_index_22() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___index_22)); }
	inline SyncListInt_t3316705628 * get_index_22() const { return ___index_22; }
	inline SyncListInt_t3316705628 ** get_address_of_index_22() { return &___index_22; }
	inline void set_index_22(SyncListInt_t3316705628 * value)
	{
		___index_22 = value;
		Il2CppCodeGenWriteBarrier(&___index_22, value);
	}

	inline static int32_t get_offset_of_gamePly_23() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___gamePly_23)); }
	inline int32_t get_gamePly_23() const { return ___gamePly_23; }
	inline int32_t* get_address_of_gamePly_23() { return &___gamePly_23; }
	inline void set_gamePly_23(int32_t value)
	{
		___gamePly_23 = value;
	}

	inline static int32_t get_offset_of_sideToMove_24() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___sideToMove_24)); }
	inline int32_t get_sideToMove_24() const { return ___sideToMove_24; }
	inline int32_t* get_address_of_sideToMove_24() { return &___sideToMove_24; }
	inline void set_sideToMove_24(int32_t value)
	{
		___sideToMove_24 = value;
	}

	inline static int32_t get_offset_of_chess960_25() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___chess960_25)); }
	inline bool get_chess960_25() const { return ___chess960_25; }
	inline bool* get_address_of_chess960_25() { return &___chess960_25; }
	inline void set_chess960_25(bool value)
	{
		___chess960_25 = value;
	}

	inline static int32_t get_offset_of_isCustom_26() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___isCustom_26)); }
	inline bool get_isCustom_26() const { return ___isCustom_26; }
	inline bool* get_address_of_isCustom_26() { return &___isCustom_26; }
	inline void set_isCustom_26(bool value)
	{
		___isCustom_26 = value;
	}

	inline static int32_t get_offset_of_netData_27() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409, ___netData_27)); }
	inline NetData_1_t3199195824 * get_netData_27() const { return ___netData_27; }
	inline NetData_1_t3199195824 ** get_address_of_netData_27() { return &___netData_27; }
	inline void set_netData_27(NetData_1_t3199195824 * value)
	{
		___netData_27 = value;
		Il2CppCodeGenWriteBarrier(&___netData_27, value);
	}
};

struct MakrukIdentity_t1358353409_StaticFields
{
public:
	// System.Int32 Makruk.MakrukIdentity::kListboard
	int32_t ___kListboard_28;
	// System.Int32 Makruk.MakrukIdentity::kListbyTypeBB
	int32_t ___kListbyTypeBB_29;
	// System.Int32 Makruk.MakrukIdentity::kListbyColorBB
	int32_t ___kListbyColorBB_30;
	// System.Int32 Makruk.MakrukIdentity::kListpieceCount
	int32_t ___kListpieceCount_31;
	// System.Int32 Makruk.MakrukIdentity::kListpieceList
	int32_t ___kListpieceList_32;
	// System.Int32 Makruk.MakrukIdentity::kListindex
	int32_t ___kListindex_33;

public:
	inline static int32_t get_offset_of_kListboard_28() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListboard_28)); }
	inline int32_t get_kListboard_28() const { return ___kListboard_28; }
	inline int32_t* get_address_of_kListboard_28() { return &___kListboard_28; }
	inline void set_kListboard_28(int32_t value)
	{
		___kListboard_28 = value;
	}

	inline static int32_t get_offset_of_kListbyTypeBB_29() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListbyTypeBB_29)); }
	inline int32_t get_kListbyTypeBB_29() const { return ___kListbyTypeBB_29; }
	inline int32_t* get_address_of_kListbyTypeBB_29() { return &___kListbyTypeBB_29; }
	inline void set_kListbyTypeBB_29(int32_t value)
	{
		___kListbyTypeBB_29 = value;
	}

	inline static int32_t get_offset_of_kListbyColorBB_30() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListbyColorBB_30)); }
	inline int32_t get_kListbyColorBB_30() const { return ___kListbyColorBB_30; }
	inline int32_t* get_address_of_kListbyColorBB_30() { return &___kListbyColorBB_30; }
	inline void set_kListbyColorBB_30(int32_t value)
	{
		___kListbyColorBB_30 = value;
	}

	inline static int32_t get_offset_of_kListpieceCount_31() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListpieceCount_31)); }
	inline int32_t get_kListpieceCount_31() const { return ___kListpieceCount_31; }
	inline int32_t* get_address_of_kListpieceCount_31() { return &___kListpieceCount_31; }
	inline void set_kListpieceCount_31(int32_t value)
	{
		___kListpieceCount_31 = value;
	}

	inline static int32_t get_offset_of_kListpieceList_32() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListpieceList_32)); }
	inline int32_t get_kListpieceList_32() const { return ___kListpieceList_32; }
	inline int32_t* get_address_of_kListpieceList_32() { return &___kListpieceList_32; }
	inline void set_kListpieceList_32(int32_t value)
	{
		___kListpieceList_32 = value;
	}

	inline static int32_t get_offset_of_kListindex_33() { return static_cast<int32_t>(offsetof(MakrukIdentity_t1358353409_StaticFields, ___kListindex_33)); }
	inline int32_t get_kListindex_33() const { return ___kListindex_33; }
	inline int32_t* get_address_of_kListindex_33() { return &___kListindex_33; }
	inline void set_kListindex_33(int32_t value)
	{
		___kListindex_33 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
