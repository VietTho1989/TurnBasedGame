#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListSByte
struct SyncListSByte_t583884747;
// DataIdentity/SyncListUInt64
struct SyncListUInt64_t567569778;
// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<Reversi.Reversi>
struct NetData_1_t2834123617;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiIdentity
struct  ReversiIdentity_t1265360410  : public DataIdentity_t543951486
{
public:
	// System.Int32 Reversi.ReversiIdentity::side
	int32_t ___side_17;
	// System.UInt64 Reversi.ReversiIdentity::white
	uint64_t ___white_18;
	// System.UInt64 Reversi.ReversiIdentity::black
	uint64_t ___black_19;
	// System.SByte Reversi.ReversiIdentity::nMoveNum
	int8_t ___nMoveNum_20;
	// DataIdentity/SyncListSByte Reversi.ReversiIdentity::moves
	SyncListSByte_t583884747 * ___moves_21;
	// DataIdentity/SyncListUInt64 Reversi.ReversiIdentity::changes
	SyncListUInt64_t567569778 * ___changes_22;
	// UnityEngine.Networking.SyncListInt Reversi.ReversiIdentity::oldSides
	SyncListInt_t3316705628 * ___oldSides_23;
	// System.Boolean Reversi.ReversiIdentity::isCustom
	bool ___isCustom_24;
	// NetData`1<Reversi.Reversi> Reversi.ReversiIdentity::netData
	NetData_1_t2834123617 * ___netData_25;

public:
	inline static int32_t get_offset_of_side_17() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___side_17)); }
	inline int32_t get_side_17() const { return ___side_17; }
	inline int32_t* get_address_of_side_17() { return &___side_17; }
	inline void set_side_17(int32_t value)
	{
		___side_17 = value;
	}

	inline static int32_t get_offset_of_white_18() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___white_18)); }
	inline uint64_t get_white_18() const { return ___white_18; }
	inline uint64_t* get_address_of_white_18() { return &___white_18; }
	inline void set_white_18(uint64_t value)
	{
		___white_18 = value;
	}

	inline static int32_t get_offset_of_black_19() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___black_19)); }
	inline uint64_t get_black_19() const { return ___black_19; }
	inline uint64_t* get_address_of_black_19() { return &___black_19; }
	inline void set_black_19(uint64_t value)
	{
		___black_19 = value;
	}

	inline static int32_t get_offset_of_nMoveNum_20() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___nMoveNum_20)); }
	inline int8_t get_nMoveNum_20() const { return ___nMoveNum_20; }
	inline int8_t* get_address_of_nMoveNum_20() { return &___nMoveNum_20; }
	inline void set_nMoveNum_20(int8_t value)
	{
		___nMoveNum_20 = value;
	}

	inline static int32_t get_offset_of_moves_21() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___moves_21)); }
	inline SyncListSByte_t583884747 * get_moves_21() const { return ___moves_21; }
	inline SyncListSByte_t583884747 ** get_address_of_moves_21() { return &___moves_21; }
	inline void set_moves_21(SyncListSByte_t583884747 * value)
	{
		___moves_21 = value;
		Il2CppCodeGenWriteBarrier(&___moves_21, value);
	}

	inline static int32_t get_offset_of_changes_22() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___changes_22)); }
	inline SyncListUInt64_t567569778 * get_changes_22() const { return ___changes_22; }
	inline SyncListUInt64_t567569778 ** get_address_of_changes_22() { return &___changes_22; }
	inline void set_changes_22(SyncListUInt64_t567569778 * value)
	{
		___changes_22 = value;
		Il2CppCodeGenWriteBarrier(&___changes_22, value);
	}

	inline static int32_t get_offset_of_oldSides_23() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___oldSides_23)); }
	inline SyncListInt_t3316705628 * get_oldSides_23() const { return ___oldSides_23; }
	inline SyncListInt_t3316705628 ** get_address_of_oldSides_23() { return &___oldSides_23; }
	inline void set_oldSides_23(SyncListInt_t3316705628 * value)
	{
		___oldSides_23 = value;
		Il2CppCodeGenWriteBarrier(&___oldSides_23, value);
	}

	inline static int32_t get_offset_of_isCustom_24() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___isCustom_24)); }
	inline bool get_isCustom_24() const { return ___isCustom_24; }
	inline bool* get_address_of_isCustom_24() { return &___isCustom_24; }
	inline void set_isCustom_24(bool value)
	{
		___isCustom_24 = value;
	}

	inline static int32_t get_offset_of_netData_25() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410, ___netData_25)); }
	inline NetData_1_t2834123617 * get_netData_25() const { return ___netData_25; }
	inline NetData_1_t2834123617 ** get_address_of_netData_25() { return &___netData_25; }
	inline void set_netData_25(NetData_1_t2834123617 * value)
	{
		___netData_25 = value;
		Il2CppCodeGenWriteBarrier(&___netData_25, value);
	}
};

struct ReversiIdentity_t1265360410_StaticFields
{
public:
	// System.Int32 Reversi.ReversiIdentity::kListmoves
	int32_t ___kListmoves_26;
	// System.Int32 Reversi.ReversiIdentity::kListchanges
	int32_t ___kListchanges_27;
	// System.Int32 Reversi.ReversiIdentity::kListoldSides
	int32_t ___kListoldSides_28;

public:
	inline static int32_t get_offset_of_kListmoves_26() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410_StaticFields, ___kListmoves_26)); }
	inline int32_t get_kListmoves_26() const { return ___kListmoves_26; }
	inline int32_t* get_address_of_kListmoves_26() { return &___kListmoves_26; }
	inline void set_kListmoves_26(int32_t value)
	{
		___kListmoves_26 = value;
	}

	inline static int32_t get_offset_of_kListchanges_27() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410_StaticFields, ___kListchanges_27)); }
	inline int32_t get_kListchanges_27() const { return ___kListchanges_27; }
	inline int32_t* get_address_of_kListchanges_27() { return &___kListchanges_27; }
	inline void set_kListchanges_27(int32_t value)
	{
		___kListchanges_27 = value;
	}

	inline static int32_t get_offset_of_kListoldSides_28() { return static_cast<int32_t>(offsetof(ReversiIdentity_t1265360410_StaticFields, ___kListoldSides_28)); }
	inline int32_t get_kListoldSides_28() const { return ___kListoldSides_28; }
	inline int32_t* get_address_of_kListoldSides_28() { return &___kListoldSides_28; }
	inline void set_kListoldSides_28(int32_t value)
	{
		___kListoldSides_28 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
