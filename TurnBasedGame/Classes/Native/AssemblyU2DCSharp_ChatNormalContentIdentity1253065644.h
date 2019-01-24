#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// ChatNormalContentIdentity/SyncListContent
struct SyncListContent_t2363454091;
// NetData`1<ChatNormalContent>
struct NetData_1_t1508695847;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatNormalContentIdentity
struct  ChatNormalContentIdentity_t1253065644  : public DataIdentity_t543951486
{
public:
	// System.UInt32 ChatNormalContentIdentity::owner
	uint32_t ___owner_17;
	// System.Int32 ChatNormalContentIdentity::editMax
	int32_t ___editMax_18;
	// ChatNormalContentIdentity/SyncListContent ChatNormalContentIdentity::messages
	SyncListContent_t2363454091 * ___messages_19;
	// NetData`1<ChatNormalContent> ChatNormalContentIdentity::netData
	NetData_1_t1508695847 * ___netData_20;

public:
	inline static int32_t get_offset_of_owner_17() { return static_cast<int32_t>(offsetof(ChatNormalContentIdentity_t1253065644, ___owner_17)); }
	inline uint32_t get_owner_17() const { return ___owner_17; }
	inline uint32_t* get_address_of_owner_17() { return &___owner_17; }
	inline void set_owner_17(uint32_t value)
	{
		___owner_17 = value;
	}

	inline static int32_t get_offset_of_editMax_18() { return static_cast<int32_t>(offsetof(ChatNormalContentIdentity_t1253065644, ___editMax_18)); }
	inline int32_t get_editMax_18() const { return ___editMax_18; }
	inline int32_t* get_address_of_editMax_18() { return &___editMax_18; }
	inline void set_editMax_18(int32_t value)
	{
		___editMax_18 = value;
	}

	inline static int32_t get_offset_of_messages_19() { return static_cast<int32_t>(offsetof(ChatNormalContentIdentity_t1253065644, ___messages_19)); }
	inline SyncListContent_t2363454091 * get_messages_19() const { return ___messages_19; }
	inline SyncListContent_t2363454091 ** get_address_of_messages_19() { return &___messages_19; }
	inline void set_messages_19(SyncListContent_t2363454091 * value)
	{
		___messages_19 = value;
		Il2CppCodeGenWriteBarrier(&___messages_19, value);
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(ChatNormalContentIdentity_t1253065644, ___netData_20)); }
	inline NetData_1_t1508695847 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t1508695847 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t1508695847 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct ChatNormalContentIdentity_t1253065644_StaticFields
{
public:
	// System.Int32 ChatNormalContentIdentity::kListmessages
	int32_t ___kListmessages_21;

public:
	inline static int32_t get_offset_of_kListmessages_21() { return static_cast<int32_t>(offsetof(ChatNormalContentIdentity_t1253065644_StaticFields, ___kListmessages_21)); }
	inline int32_t get_kListmessages_21() const { return ___kListmessages_21; }
	inline int32_t* get_address_of_kListmessages_21() { return &___kListmessages_21; }
	inline void set_kListmessages_21(int32_t value)
	{
		___kListmessages_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
