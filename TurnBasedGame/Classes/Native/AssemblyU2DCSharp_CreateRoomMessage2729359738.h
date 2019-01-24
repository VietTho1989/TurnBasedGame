#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"
#include "AssemblyU2DCSharp_GameType_Type2350072159.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CreateRoomMessage
struct  CreateRoomMessage_t2729359738  : public MessageBase_t2552428296
{
public:
	// GameType/Type CreateRoomMessage::gameType
	int32_t ___gameType_0;
	// System.String CreateRoomMessage::roomName
	String_t* ___roomName_1;
	// System.String CreateRoomMessage::password
	String_t* ___password_2;

public:
	inline static int32_t get_offset_of_gameType_0() { return static_cast<int32_t>(offsetof(CreateRoomMessage_t2729359738, ___gameType_0)); }
	inline int32_t get_gameType_0() const { return ___gameType_0; }
	inline int32_t* get_address_of_gameType_0() { return &___gameType_0; }
	inline void set_gameType_0(int32_t value)
	{
		___gameType_0 = value;
	}

	inline static int32_t get_offset_of_roomName_1() { return static_cast<int32_t>(offsetof(CreateRoomMessage_t2729359738, ___roomName_1)); }
	inline String_t* get_roomName_1() const { return ___roomName_1; }
	inline String_t** get_address_of_roomName_1() { return &___roomName_1; }
	inline void set_roomName_1(String_t* value)
	{
		___roomName_1 = value;
		Il2CppCodeGenWriteBarrier(&___roomName_1, value);
	}

	inline static int32_t get_offset_of_password_2() { return static_cast<int32_t>(offsetof(CreateRoomMessage_t2729359738, ___password_2)); }
	inline String_t* get_password_2() const { return ___password_2; }
	inline String_t** get_address_of_password_2() { return &___password_2; }
	inline void set_password_2(String_t* value)
	{
		___password_2 = value;
		Il2CppCodeGenWriteBarrier(&___password_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
