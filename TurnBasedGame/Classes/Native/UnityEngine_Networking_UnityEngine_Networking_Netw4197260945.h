#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.AddPlayerMessage
struct  AddPlayerMessage_t4197260945  : public MessageBase_t2552428296
{
public:
	// System.Int16 UnityEngine.Networking.NetworkSystem.AddPlayerMessage::playerControllerId
	int16_t ___playerControllerId_0;
	// System.Int32 UnityEngine.Networking.NetworkSystem.AddPlayerMessage::msgSize
	int32_t ___msgSize_1;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.AddPlayerMessage::msgData
	ByteU5BU5D_t3397334013* ___msgData_2;

public:
	inline static int32_t get_offset_of_playerControllerId_0() { return static_cast<int32_t>(offsetof(AddPlayerMessage_t4197260945, ___playerControllerId_0)); }
	inline int16_t get_playerControllerId_0() const { return ___playerControllerId_0; }
	inline int16_t* get_address_of_playerControllerId_0() { return &___playerControllerId_0; }
	inline void set_playerControllerId_0(int16_t value)
	{
		___playerControllerId_0 = value;
	}

	inline static int32_t get_offset_of_msgSize_1() { return static_cast<int32_t>(offsetof(AddPlayerMessage_t4197260945, ___msgSize_1)); }
	inline int32_t get_msgSize_1() const { return ___msgSize_1; }
	inline int32_t* get_address_of_msgSize_1() { return &___msgSize_1; }
	inline void set_msgSize_1(int32_t value)
	{
		___msgSize_1 = value;
	}

	inline static int32_t get_offset_of_msgData_2() { return static_cast<int32_t>(offsetof(AddPlayerMessage_t4197260945, ___msgData_2)); }
	inline ByteU5BU5D_t3397334013* get_msgData_2() const { return ___msgData_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_msgData_2() { return &___msgData_2; }
	inline void set_msgData_2(ByteU5BU5D_t3397334013* value)
	{
		___msgData_2 = value;
		Il2CppCodeGenWriteBarrier(&___msgData_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
