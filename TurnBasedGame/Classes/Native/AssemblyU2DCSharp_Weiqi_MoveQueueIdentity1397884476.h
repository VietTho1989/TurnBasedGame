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
// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// NetData`1<Weiqi.MoveQueue>
struct NetData_1_t518671755;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.MoveQueueIdentity
struct  MoveQueueIdentity_t1397884476  : public DataIdentity_t543951486
{
public:
	// System.UInt32 Weiqi.MoveQueueIdentity::moves
	uint32_t ___moves_17;
	// UnityEngine.Networking.SyncListInt Weiqi.MoveQueueIdentity::move
	SyncListInt_t3316705628 * ___move_18;
	// DataIdentity/SyncListByte Weiqi.MoveQueueIdentity::bTag
	SyncListByte_t230810734 * ___bTag_19;
	// NetData`1<Weiqi.MoveQueue> Weiqi.MoveQueueIdentity::netData
	NetData_1_t518671755 * ___netData_20;

public:
	inline static int32_t get_offset_of_moves_17() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476, ___moves_17)); }
	inline uint32_t get_moves_17() const { return ___moves_17; }
	inline uint32_t* get_address_of_moves_17() { return &___moves_17; }
	inline void set_moves_17(uint32_t value)
	{
		___moves_17 = value;
	}

	inline static int32_t get_offset_of_move_18() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476, ___move_18)); }
	inline SyncListInt_t3316705628 * get_move_18() const { return ___move_18; }
	inline SyncListInt_t3316705628 ** get_address_of_move_18() { return &___move_18; }
	inline void set_move_18(SyncListInt_t3316705628 * value)
	{
		___move_18 = value;
		Il2CppCodeGenWriteBarrier(&___move_18, value);
	}

	inline static int32_t get_offset_of_bTag_19() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476, ___bTag_19)); }
	inline SyncListByte_t230810734 * get_bTag_19() const { return ___bTag_19; }
	inline SyncListByte_t230810734 ** get_address_of_bTag_19() { return &___bTag_19; }
	inline void set_bTag_19(SyncListByte_t230810734 * value)
	{
		___bTag_19 = value;
		Il2CppCodeGenWriteBarrier(&___bTag_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476, ___netData_20)); }
	inline NetData_1_t518671755 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t518671755 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t518671755 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct MoveQueueIdentity_t1397884476_StaticFields
{
public:
	// System.Int32 Weiqi.MoveQueueIdentity::kListmove
	int32_t ___kListmove_21;
	// System.Int32 Weiqi.MoveQueueIdentity::kListbTag
	int32_t ___kListbTag_22;

public:
	inline static int32_t get_offset_of_kListmove_21() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476_StaticFields, ___kListmove_21)); }
	inline int32_t get_kListmove_21() const { return ___kListmove_21; }
	inline int32_t* get_address_of_kListmove_21() { return &___kListmove_21; }
	inline void set_kListmove_21(int32_t value)
	{
		___kListmove_21 = value;
	}

	inline static int32_t get_offset_of_kListbTag_22() { return static_cast<int32_t>(offsetof(MoveQueueIdentity_t1397884476_StaticFields, ___kListbTag_22)); }
	inline int32_t get_kListbTag_22() const { return ___kListbTag_22; }
	inline int32_t* get_address_of_kListbTag_22() { return &___kListbTag_22; }
	inline void set_kListbTag_22(int32_t value)
	{
		___kListbTag_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
