#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Networ33998832.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.ReconnectMessage
struct  ReconnectMessage_t3062411074  : public MessageBase_t2552428296
{
public:
	// System.Int32 UnityEngine.Networking.NetworkSystem.ReconnectMessage::oldConnectionId
	int32_t ___oldConnectionId_0;
	// System.Int16 UnityEngine.Networking.NetworkSystem.ReconnectMessage::playerControllerId
	int16_t ___playerControllerId_1;
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.ReconnectMessage::netId
	NetworkInstanceId_t33998832  ___netId_2;
	// System.Int32 UnityEngine.Networking.NetworkSystem.ReconnectMessage::msgSize
	int32_t ___msgSize_3;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.ReconnectMessage::msgData
	ByteU5BU5D_t3397334013* ___msgData_4;

public:
	inline static int32_t get_offset_of_oldConnectionId_0() { return static_cast<int32_t>(offsetof(ReconnectMessage_t3062411074, ___oldConnectionId_0)); }
	inline int32_t get_oldConnectionId_0() const { return ___oldConnectionId_0; }
	inline int32_t* get_address_of_oldConnectionId_0() { return &___oldConnectionId_0; }
	inline void set_oldConnectionId_0(int32_t value)
	{
		___oldConnectionId_0 = value;
	}

	inline static int32_t get_offset_of_playerControllerId_1() { return static_cast<int32_t>(offsetof(ReconnectMessage_t3062411074, ___playerControllerId_1)); }
	inline int16_t get_playerControllerId_1() const { return ___playerControllerId_1; }
	inline int16_t* get_address_of_playerControllerId_1() { return &___playerControllerId_1; }
	inline void set_playerControllerId_1(int16_t value)
	{
		___playerControllerId_1 = value;
	}

	inline static int32_t get_offset_of_netId_2() { return static_cast<int32_t>(offsetof(ReconnectMessage_t3062411074, ___netId_2)); }
	inline NetworkInstanceId_t33998832  get_netId_2() const { return ___netId_2; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_2() { return &___netId_2; }
	inline void set_netId_2(NetworkInstanceId_t33998832  value)
	{
		___netId_2 = value;
	}

	inline static int32_t get_offset_of_msgSize_3() { return static_cast<int32_t>(offsetof(ReconnectMessage_t3062411074, ___msgSize_3)); }
	inline int32_t get_msgSize_3() const { return ___msgSize_3; }
	inline int32_t* get_address_of_msgSize_3() { return &___msgSize_3; }
	inline void set_msgSize_3(int32_t value)
	{
		___msgSize_3 = value;
	}

	inline static int32_t get_offset_of_msgData_4() { return static_cast<int32_t>(offsetof(ReconnectMessage_t3062411074, ___msgData_4)); }
	inline ByteU5BU5D_t3397334013* get_msgData_4() const { return ___msgData_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_msgData_4() { return &___msgData_4; }
	inline void set_msgData_4(ByteU5BU5D_t3397334013* value)
	{
		___msgData_4 = value;
		Il2CppCodeGenWriteBarrier(&___msgData_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
