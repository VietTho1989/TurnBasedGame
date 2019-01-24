#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListUInt64
struct SyncListUInt64_t567569778;
// NetData`1<InternationalDraught.Pos>
struct NetData_1_t2422436207;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.PosIdentity
struct  PosIdentity_t2133931380  : public DataIdentity_t543951486
{
public:
	// DataIdentity/SyncListUInt64 InternationalDraught.PosIdentity::p_piece
	SyncListUInt64_t567569778 * ___p_piece_17;
	// DataIdentity/SyncListUInt64 InternationalDraught.PosIdentity::p_side
	SyncListUInt64_t567569778 * ___p_side_18;
	// System.UInt64 InternationalDraught.PosIdentity::p_all
	uint64_t ___p_all_19;
	// System.Int32 InternationalDraught.PosIdentity::p_turn
	int32_t ___p_turn_20;
	// NetData`1<InternationalDraught.Pos> InternationalDraught.PosIdentity::netData
	NetData_1_t2422436207 * ___netData_21;

public:
	inline static int32_t get_offset_of_p_piece_17() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380, ___p_piece_17)); }
	inline SyncListUInt64_t567569778 * get_p_piece_17() const { return ___p_piece_17; }
	inline SyncListUInt64_t567569778 ** get_address_of_p_piece_17() { return &___p_piece_17; }
	inline void set_p_piece_17(SyncListUInt64_t567569778 * value)
	{
		___p_piece_17 = value;
		Il2CppCodeGenWriteBarrier(&___p_piece_17, value);
	}

	inline static int32_t get_offset_of_p_side_18() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380, ___p_side_18)); }
	inline SyncListUInt64_t567569778 * get_p_side_18() const { return ___p_side_18; }
	inline SyncListUInt64_t567569778 ** get_address_of_p_side_18() { return &___p_side_18; }
	inline void set_p_side_18(SyncListUInt64_t567569778 * value)
	{
		___p_side_18 = value;
		Il2CppCodeGenWriteBarrier(&___p_side_18, value);
	}

	inline static int32_t get_offset_of_p_all_19() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380, ___p_all_19)); }
	inline uint64_t get_p_all_19() const { return ___p_all_19; }
	inline uint64_t* get_address_of_p_all_19() { return &___p_all_19; }
	inline void set_p_all_19(uint64_t value)
	{
		___p_all_19 = value;
	}

	inline static int32_t get_offset_of_p_turn_20() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380, ___p_turn_20)); }
	inline int32_t get_p_turn_20() const { return ___p_turn_20; }
	inline int32_t* get_address_of_p_turn_20() { return &___p_turn_20; }
	inline void set_p_turn_20(int32_t value)
	{
		___p_turn_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380, ___netData_21)); }
	inline NetData_1_t2422436207 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t2422436207 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t2422436207 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct PosIdentity_t2133931380_StaticFields
{
public:
	// System.Int32 InternationalDraught.PosIdentity::kListp_piece
	int32_t ___kListp_piece_22;
	// System.Int32 InternationalDraught.PosIdentity::kListp_side
	int32_t ___kListp_side_23;

public:
	inline static int32_t get_offset_of_kListp_piece_22() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380_StaticFields, ___kListp_piece_22)); }
	inline int32_t get_kListp_piece_22() const { return ___kListp_piece_22; }
	inline int32_t* get_address_of_kListp_piece_22() { return &___kListp_piece_22; }
	inline void set_kListp_piece_22(int32_t value)
	{
		___kListp_piece_22 = value;
	}

	inline static int32_t get_offset_of_kListp_side_23() { return static_cast<int32_t>(offsetof(PosIdentity_t2133931380_StaticFields, ___kListp_side_23)); }
	inline int32_t get_kListp_side_23() const { return ___kListp_side_23; }
	inline int32_t* get_address_of_kListp_side_23() { return &___kListp_side_23; }
	inline void set_kListp_side_23(int32_t value)
	{
		___kListp_side_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
