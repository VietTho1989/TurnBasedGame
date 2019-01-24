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
// NetData`1<Shogi.ChangedLists>
struct NetData_1_t203625414;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ChangedListsIdentity
struct  ChangedListsIdentity_t1214062795  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Shogi.ChangedListsIdentity::listindex
	SyncListInt_t3316705628 * ___listindex_17;
	// System.UInt64 Shogi.ChangedListsIdentity::size
	uint64_t ___size_18;
	// NetData`1<Shogi.ChangedLists> Shogi.ChangedListsIdentity::netData
	NetData_1_t203625414 * ___netData_19;

public:
	inline static int32_t get_offset_of_listindex_17() { return static_cast<int32_t>(offsetof(ChangedListsIdentity_t1214062795, ___listindex_17)); }
	inline SyncListInt_t3316705628 * get_listindex_17() const { return ___listindex_17; }
	inline SyncListInt_t3316705628 ** get_address_of_listindex_17() { return &___listindex_17; }
	inline void set_listindex_17(SyncListInt_t3316705628 * value)
	{
		___listindex_17 = value;
		Il2CppCodeGenWriteBarrier(&___listindex_17, value);
	}

	inline static int32_t get_offset_of_size_18() { return static_cast<int32_t>(offsetof(ChangedListsIdentity_t1214062795, ___size_18)); }
	inline uint64_t get_size_18() const { return ___size_18; }
	inline uint64_t* get_address_of_size_18() { return &___size_18; }
	inline void set_size_18(uint64_t value)
	{
		___size_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ChangedListsIdentity_t1214062795, ___netData_19)); }
	inline NetData_1_t203625414 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t203625414 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t203625414 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct ChangedListsIdentity_t1214062795_StaticFields
{
public:
	// System.Int32 Shogi.ChangedListsIdentity::kListlistindex
	int32_t ___kListlistindex_20;

public:
	inline static int32_t get_offset_of_kListlistindex_20() { return static_cast<int32_t>(offsetof(ChangedListsIdentity_t1214062795_StaticFields, ___kListlistindex_20)); }
	inline int32_t get_kListlistindex_20() const { return ___kListlistindex_20; }
	inline int32_t* get_address_of_kListlistindex_20() { return &___kListlistindex_20; }
	inline void set_kListlistindex_20(int32_t value)
	{
		___kListlistindex_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
