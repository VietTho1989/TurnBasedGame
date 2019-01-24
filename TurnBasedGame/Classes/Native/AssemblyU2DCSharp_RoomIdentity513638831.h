#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_Room_AllowHint1717080220.h"

// System.String
struct String_t;
// NetData`1<Room>
struct NetData_1_t1288746898;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomIdentity
struct  RoomIdentity_t513638831  : public DataIdentity_t543951486
{
public:
	// System.String RoomIdentity::roomName
	String_t* ___roomName_17;
	// System.String RoomIdentity::password
	String_t* ___password_18;
	// System.Int64 RoomIdentity::timeCreated
	int64_t ___timeCreated_19;
	// Room/AllowHint RoomIdentity::allowHint
	int32_t ___allowHint_20;
	// System.Boolean RoomIdentity::allowLoadHistory
	bool ___allowLoadHistory_21;
	// NetData`1<Room> RoomIdentity::netData
	NetData_1_t1288746898 * ___netData_22;

public:
	inline static int32_t get_offset_of_roomName_17() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___roomName_17)); }
	inline String_t* get_roomName_17() const { return ___roomName_17; }
	inline String_t** get_address_of_roomName_17() { return &___roomName_17; }
	inline void set_roomName_17(String_t* value)
	{
		___roomName_17 = value;
		Il2CppCodeGenWriteBarrier(&___roomName_17, value);
	}

	inline static int32_t get_offset_of_password_18() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___password_18)); }
	inline String_t* get_password_18() const { return ___password_18; }
	inline String_t** get_address_of_password_18() { return &___password_18; }
	inline void set_password_18(String_t* value)
	{
		___password_18 = value;
		Il2CppCodeGenWriteBarrier(&___password_18, value);
	}

	inline static int32_t get_offset_of_timeCreated_19() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___timeCreated_19)); }
	inline int64_t get_timeCreated_19() const { return ___timeCreated_19; }
	inline int64_t* get_address_of_timeCreated_19() { return &___timeCreated_19; }
	inline void set_timeCreated_19(int64_t value)
	{
		___timeCreated_19 = value;
	}

	inline static int32_t get_offset_of_allowHint_20() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___allowHint_20)); }
	inline int32_t get_allowHint_20() const { return ___allowHint_20; }
	inline int32_t* get_address_of_allowHint_20() { return &___allowHint_20; }
	inline void set_allowHint_20(int32_t value)
	{
		___allowHint_20 = value;
	}

	inline static int32_t get_offset_of_allowLoadHistory_21() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___allowLoadHistory_21)); }
	inline bool get_allowLoadHistory_21() const { return ___allowLoadHistory_21; }
	inline bool* get_address_of_allowLoadHistory_21() { return &___allowLoadHistory_21; }
	inline void set_allowLoadHistory_21(bool value)
	{
		___allowLoadHistory_21 = value;
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(RoomIdentity_t513638831, ___netData_22)); }
	inline NetData_1_t1288746898 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t1288746898 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t1288746898 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
