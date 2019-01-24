#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"

// ServerManager
struct ServerManager_t3491151942;
// UnityEngine.Networking.SyncListUInt
struct SyncListUInt_t2190275715;
// System.Collections.Generic.Dictionary`2<Data,DataIdentity>
struct Dictionary_2_t3473330449;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DataIdentity
struct  DataIdentity_t543951486  : public NetworkBehaviour_t3873055601
{
public:
	// ServerManager DataIdentity::ServerManager
	ServerManager_t3491151942 * ___ServerManager_8;
	// System.Boolean DataIdentity::haveChangeDataSize
	bool ___haveChangeDataSize_9;
	// System.Int32 DataIdentity::dataSize
	int32_t ___dataSize_10;
	// System.Boolean DataIdentity::NotFindNeedWait
	bool ___NotFindNeedWait_11;
	// System.Boolean DataIdentity::NotFindTransformParent
	bool ___NotFindTransformParent_12;
	// UnityEngine.Networking.SyncListUInt DataIdentity::searchInfor
	SyncListUInt_t2190275715 * ___searchInfor_13;
	// System.Boolean DataIdentity::refresh
	bool ___refresh_14;

public:
	inline static int32_t get_offset_of_ServerManager_8() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___ServerManager_8)); }
	inline ServerManager_t3491151942 * get_ServerManager_8() const { return ___ServerManager_8; }
	inline ServerManager_t3491151942 ** get_address_of_ServerManager_8() { return &___ServerManager_8; }
	inline void set_ServerManager_8(ServerManager_t3491151942 * value)
	{
		___ServerManager_8 = value;
		Il2CppCodeGenWriteBarrier(&___ServerManager_8, value);
	}

	inline static int32_t get_offset_of_haveChangeDataSize_9() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___haveChangeDataSize_9)); }
	inline bool get_haveChangeDataSize_9() const { return ___haveChangeDataSize_9; }
	inline bool* get_address_of_haveChangeDataSize_9() { return &___haveChangeDataSize_9; }
	inline void set_haveChangeDataSize_9(bool value)
	{
		___haveChangeDataSize_9 = value;
	}

	inline static int32_t get_offset_of_dataSize_10() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___dataSize_10)); }
	inline int32_t get_dataSize_10() const { return ___dataSize_10; }
	inline int32_t* get_address_of_dataSize_10() { return &___dataSize_10; }
	inline void set_dataSize_10(int32_t value)
	{
		___dataSize_10 = value;
	}

	inline static int32_t get_offset_of_NotFindNeedWait_11() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___NotFindNeedWait_11)); }
	inline bool get_NotFindNeedWait_11() const { return ___NotFindNeedWait_11; }
	inline bool* get_address_of_NotFindNeedWait_11() { return &___NotFindNeedWait_11; }
	inline void set_NotFindNeedWait_11(bool value)
	{
		___NotFindNeedWait_11 = value;
	}

	inline static int32_t get_offset_of_NotFindTransformParent_12() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___NotFindTransformParent_12)); }
	inline bool get_NotFindTransformParent_12() const { return ___NotFindTransformParent_12; }
	inline bool* get_address_of_NotFindTransformParent_12() { return &___NotFindTransformParent_12; }
	inline void set_NotFindTransformParent_12(bool value)
	{
		___NotFindTransformParent_12 = value;
	}

	inline static int32_t get_offset_of_searchInfor_13() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___searchInfor_13)); }
	inline SyncListUInt_t2190275715 * get_searchInfor_13() const { return ___searchInfor_13; }
	inline SyncListUInt_t2190275715 ** get_address_of_searchInfor_13() { return &___searchInfor_13; }
	inline void set_searchInfor_13(SyncListUInt_t2190275715 * value)
	{
		___searchInfor_13 = value;
		Il2CppCodeGenWriteBarrier(&___searchInfor_13, value);
	}

	inline static int32_t get_offset_of_refresh_14() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486, ___refresh_14)); }
	inline bool get_refresh_14() const { return ___refresh_14; }
	inline bool* get_address_of_refresh_14() { return &___refresh_14; }
	inline void set_refresh_14(bool value)
	{
		___refresh_14 = value;
	}
};

struct DataIdentity_t543951486_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<Data,DataIdentity> DataIdentity::clientMap
	Dictionary_2_t3473330449 * ___clientMap_15;
	// System.Int32 DataIdentity::kListsearchInfor
	int32_t ___kListsearchInfor_16;

public:
	inline static int32_t get_offset_of_clientMap_15() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486_StaticFields, ___clientMap_15)); }
	inline Dictionary_2_t3473330449 * get_clientMap_15() const { return ___clientMap_15; }
	inline Dictionary_2_t3473330449 ** get_address_of_clientMap_15() { return &___clientMap_15; }
	inline void set_clientMap_15(Dictionary_2_t3473330449 * value)
	{
		___clientMap_15 = value;
		Il2CppCodeGenWriteBarrier(&___clientMap_15, value);
	}

	inline static int32_t get_offset_of_kListsearchInfor_16() { return static_cast<int32_t>(offsetof(DataIdentity_t543951486_StaticFields, ___kListsearchInfor_16)); }
	inline int32_t get_kListsearchInfor_16() const { return ___kListsearchInfor_16; }
	inline int32_t* get_address_of_kListsearchInfor_16() { return &___kListsearchInfor_16; }
	inline void set_kListsearchInfor_16(int32_t value)
	{
		___kListsearchInfor_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
