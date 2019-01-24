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
// NetData`1<Shogi.ChangedListPair>
struct NetData_1_t1882909063;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ChangedListPairIdentity
struct  ChangedListPairIdentity_t815131740  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Shogi.ChangedListPairIdentity::newList
	SyncListInt_t3316705628 * ___newList_17;
	// UnityEngine.Networking.SyncListInt Shogi.ChangedListPairIdentity::oldlist
	SyncListInt_t3316705628 * ___oldlist_18;
	// NetData`1<Shogi.ChangedListPair> Shogi.ChangedListPairIdentity::netData
	NetData_1_t1882909063 * ___netData_19;

public:
	inline static int32_t get_offset_of_newList_17() { return static_cast<int32_t>(offsetof(ChangedListPairIdentity_t815131740, ___newList_17)); }
	inline SyncListInt_t3316705628 * get_newList_17() const { return ___newList_17; }
	inline SyncListInt_t3316705628 ** get_address_of_newList_17() { return &___newList_17; }
	inline void set_newList_17(SyncListInt_t3316705628 * value)
	{
		___newList_17 = value;
		Il2CppCodeGenWriteBarrier(&___newList_17, value);
	}

	inline static int32_t get_offset_of_oldlist_18() { return static_cast<int32_t>(offsetof(ChangedListPairIdentity_t815131740, ___oldlist_18)); }
	inline SyncListInt_t3316705628 * get_oldlist_18() const { return ___oldlist_18; }
	inline SyncListInt_t3316705628 ** get_address_of_oldlist_18() { return &___oldlist_18; }
	inline void set_oldlist_18(SyncListInt_t3316705628 * value)
	{
		___oldlist_18 = value;
		Il2CppCodeGenWriteBarrier(&___oldlist_18, value);
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ChangedListPairIdentity_t815131740, ___netData_19)); }
	inline NetData_1_t1882909063 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1882909063 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1882909063 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

struct ChangedListPairIdentity_t815131740_StaticFields
{
public:
	// System.Int32 Shogi.ChangedListPairIdentity::kListnewList
	int32_t ___kListnewList_20;
	// System.Int32 Shogi.ChangedListPairIdentity::kListoldlist
	int32_t ___kListoldlist_21;

public:
	inline static int32_t get_offset_of_kListnewList_20() { return static_cast<int32_t>(offsetof(ChangedListPairIdentity_t815131740_StaticFields, ___kListnewList_20)); }
	inline int32_t get_kListnewList_20() const { return ___kListnewList_20; }
	inline int32_t* get_address_of_kListnewList_20() { return &___kListnewList_20; }
	inline void set_kListnewList_20(int32_t value)
	{
		___kListnewList_20 = value;
	}

	inline static int32_t get_offset_of_kListoldlist_21() { return static_cast<int32_t>(offsetof(ChangedListPairIdentity_t815131740_StaticFields, ___kListoldlist_21)); }
	inline int32_t get_kListoldlist_21() const { return ___kListoldlist_21; }
	inline int32_t* get_address_of_kListoldlist_21() { return &___kListoldlist_21; }
	inline void set_kListoldlist_21(int32_t value)
	{
		___kListoldlist_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
