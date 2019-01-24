#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Shogi_Common_BitBoard4040987689.h"

// Shogi.Common/SyncListBitBoard
struct SyncListBitBoard_t2261471494;
// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// NetData`1<Shogi.Shogi>
struct NetData_1_t2221891327;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiIdentity
struct  ShogiIdentity_t1456348664  : public DataIdentity_t543951486
{
public:
	// Shogi.Common/SyncListBitBoard Shogi.ShogiIdentity::byTypeBB
	SyncListBitBoard_t2261471494 * ___byTypeBB_17;
	// Shogi.Common/SyncListBitBoard Shogi.ShogiIdentity::byColorBB
	SyncListBitBoard_t2261471494 * ___byColorBB_18;
	// Shogi.Common/BitBoard Shogi.ShogiIdentity::goldsBB
	BitBoard_t4040987689  ___goldsBB_19;
	// UnityEngine.Networking.SyncListInt Shogi.ShogiIdentity::piece
	SyncListInt_t3316705628 * ___piece_20;
	// UnityEngine.Networking.SyncListInt Shogi.ShogiIdentity::kingSquare
	SyncListInt_t3316705628 * ___kingSquare_21;
	// UnityEngine.Networking.SyncListUInt Shogi.ShogiIdentity::hand
	SyncListUInt_t2190275715 * ___hand_22;
	// System.Int32 Shogi.ShogiIdentity::turn
	int32_t ___turn_23;
	// System.Int32 Shogi.ShogiIdentity::gamePly
	int32_t ___gamePly_24;
	// System.Int64 Shogi.ShogiIdentity::nodes
	int64_t ___nodes_25;
	// System.Boolean Shogi.ShogiIdentity::isCustom
	bool ___isCustom_26;
	// NetData`1<Shogi.Shogi> Shogi.ShogiIdentity::netData
	NetData_1_t2221891327 * ___netData_27;

public:
	inline static int32_t get_offset_of_byTypeBB_17() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___byTypeBB_17)); }
	inline SyncListBitBoard_t2261471494 * get_byTypeBB_17() const { return ___byTypeBB_17; }
	inline SyncListBitBoard_t2261471494 ** get_address_of_byTypeBB_17() { return &___byTypeBB_17; }
	inline void set_byTypeBB_17(SyncListBitBoard_t2261471494 * value)
	{
		___byTypeBB_17 = value;
		Il2CppCodeGenWriteBarrier(&___byTypeBB_17, value);
	}

	inline static int32_t get_offset_of_byColorBB_18() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___byColorBB_18)); }
	inline SyncListBitBoard_t2261471494 * get_byColorBB_18() const { return ___byColorBB_18; }
	inline SyncListBitBoard_t2261471494 ** get_address_of_byColorBB_18() { return &___byColorBB_18; }
	inline void set_byColorBB_18(SyncListBitBoard_t2261471494 * value)
	{
		___byColorBB_18 = value;
		Il2CppCodeGenWriteBarrier(&___byColorBB_18, value);
	}

	inline static int32_t get_offset_of_goldsBB_19() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___goldsBB_19)); }
	inline BitBoard_t4040987689  get_goldsBB_19() const { return ___goldsBB_19; }
	inline BitBoard_t4040987689 * get_address_of_goldsBB_19() { return &___goldsBB_19; }
	inline void set_goldsBB_19(BitBoard_t4040987689  value)
	{
		___goldsBB_19 = value;
	}

	inline static int32_t get_offset_of_piece_20() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___piece_20)); }
	inline SyncListInt_t3316705628 * get_piece_20() const { return ___piece_20; }
	inline SyncListInt_t3316705628 ** get_address_of_piece_20() { return &___piece_20; }
	inline void set_piece_20(SyncListInt_t3316705628 * value)
	{
		___piece_20 = value;
		Il2CppCodeGenWriteBarrier(&___piece_20, value);
	}

	inline static int32_t get_offset_of_kingSquare_21() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___kingSquare_21)); }
	inline SyncListInt_t3316705628 * get_kingSquare_21() const { return ___kingSquare_21; }
	inline SyncListInt_t3316705628 ** get_address_of_kingSquare_21() { return &___kingSquare_21; }
	inline void set_kingSquare_21(SyncListInt_t3316705628 * value)
	{
		___kingSquare_21 = value;
		Il2CppCodeGenWriteBarrier(&___kingSquare_21, value);
	}

	inline static int32_t get_offset_of_hand_22() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___hand_22)); }
	inline SyncListUInt_t2190275715 * get_hand_22() const { return ___hand_22; }
	inline SyncListUInt_t2190275715 ** get_address_of_hand_22() { return &___hand_22; }
	inline void set_hand_22(SyncListUInt_t2190275715 * value)
	{
		___hand_22 = value;
		Il2CppCodeGenWriteBarrier(&___hand_22, value);
	}

	inline static int32_t get_offset_of_turn_23() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___turn_23)); }
	inline int32_t get_turn_23() const { return ___turn_23; }
	inline int32_t* get_address_of_turn_23() { return &___turn_23; }
	inline void set_turn_23(int32_t value)
	{
		___turn_23 = value;
	}

	inline static int32_t get_offset_of_gamePly_24() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___gamePly_24)); }
	inline int32_t get_gamePly_24() const { return ___gamePly_24; }
	inline int32_t* get_address_of_gamePly_24() { return &___gamePly_24; }
	inline void set_gamePly_24(int32_t value)
	{
		___gamePly_24 = value;
	}

	inline static int32_t get_offset_of_nodes_25() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___nodes_25)); }
	inline int64_t get_nodes_25() const { return ___nodes_25; }
	inline int64_t* get_address_of_nodes_25() { return &___nodes_25; }
	inline void set_nodes_25(int64_t value)
	{
		___nodes_25 = value;
	}

	inline static int32_t get_offset_of_isCustom_26() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___isCustom_26)); }
	inline bool get_isCustom_26() const { return ___isCustom_26; }
	inline bool* get_address_of_isCustom_26() { return &___isCustom_26; }
	inline void set_isCustom_26(bool value)
	{
		___isCustom_26 = value;
	}

	inline static int32_t get_offset_of_netData_27() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664, ___netData_27)); }
	inline NetData_1_t2221891327 * get_netData_27() const { return ___netData_27; }
	inline NetData_1_t2221891327 ** get_address_of_netData_27() { return &___netData_27; }
	inline void set_netData_27(NetData_1_t2221891327 * value)
	{
		___netData_27 = value;
		Il2CppCodeGenWriteBarrier(&___netData_27, value);
	}
};

struct ShogiIdentity_t1456348664_StaticFields
{
public:
	// System.Int32 Shogi.ShogiIdentity::kListbyTypeBB
	int32_t ___kListbyTypeBB_28;
	// System.Int32 Shogi.ShogiIdentity::kListbyColorBB
	int32_t ___kListbyColorBB_29;
	// System.Int32 Shogi.ShogiIdentity::kListpiece
	int32_t ___kListpiece_30;
	// System.Int32 Shogi.ShogiIdentity::kListkingSquare
	int32_t ___kListkingSquare_31;
	// System.Int32 Shogi.ShogiIdentity::kListhand
	int32_t ___kListhand_32;

public:
	inline static int32_t get_offset_of_kListbyTypeBB_28() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664_StaticFields, ___kListbyTypeBB_28)); }
	inline int32_t get_kListbyTypeBB_28() const { return ___kListbyTypeBB_28; }
	inline int32_t* get_address_of_kListbyTypeBB_28() { return &___kListbyTypeBB_28; }
	inline void set_kListbyTypeBB_28(int32_t value)
	{
		___kListbyTypeBB_28 = value;
	}

	inline static int32_t get_offset_of_kListbyColorBB_29() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664_StaticFields, ___kListbyColorBB_29)); }
	inline int32_t get_kListbyColorBB_29() const { return ___kListbyColorBB_29; }
	inline int32_t* get_address_of_kListbyColorBB_29() { return &___kListbyColorBB_29; }
	inline void set_kListbyColorBB_29(int32_t value)
	{
		___kListbyColorBB_29 = value;
	}

	inline static int32_t get_offset_of_kListpiece_30() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664_StaticFields, ___kListpiece_30)); }
	inline int32_t get_kListpiece_30() const { return ___kListpiece_30; }
	inline int32_t* get_address_of_kListpiece_30() { return &___kListpiece_30; }
	inline void set_kListpiece_30(int32_t value)
	{
		___kListpiece_30 = value;
	}

	inline static int32_t get_offset_of_kListkingSquare_31() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664_StaticFields, ___kListkingSquare_31)); }
	inline int32_t get_kListkingSquare_31() const { return ___kListkingSquare_31; }
	inline int32_t* get_address_of_kListkingSquare_31() { return &___kListkingSquare_31; }
	inline void set_kListkingSquare_31(int32_t value)
	{
		___kListkingSquare_31 = value;
	}

	inline static int32_t get_offset_of_kListhand_32() { return static_cast<int32_t>(offsetof(ShogiIdentity_t1456348664_StaticFields, ___kListhand_32)); }
	inline int32_t get_kListhand_32() const { return ___kListhand_32; }
	inline int32_t* get_address_of_kListhand_32() { return &___kListhand_32; }
	inline void set_kListhand_32(int32_t value)
	{
		___kListhand_32 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
