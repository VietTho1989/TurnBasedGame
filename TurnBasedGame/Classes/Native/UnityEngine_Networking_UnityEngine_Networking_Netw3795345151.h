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

// UnityEngine.Networking.NetworkSystem.OverrideTransformMessage
struct  OverrideTransformMessage_t3795345151  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.OverrideTransformMessage::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.OverrideTransformMessage::payload
	ByteU5BU5D_t3397334013* ___payload_1;
	// System.Boolean UnityEngine.Networking.NetworkSystem.OverrideTransformMessage::teleport
	bool ___teleport_2;
	// System.Int32 UnityEngine.Networking.NetworkSystem.OverrideTransformMessage::time
	int32_t ___time_3;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(OverrideTransformMessage_t3795345151, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_payload_1() { return static_cast<int32_t>(offsetof(OverrideTransformMessage_t3795345151, ___payload_1)); }
	inline ByteU5BU5D_t3397334013* get_payload_1() const { return ___payload_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_payload_1() { return &___payload_1; }
	inline void set_payload_1(ByteU5BU5D_t3397334013* value)
	{
		___payload_1 = value;
		Il2CppCodeGenWriteBarrier(&___payload_1, value);
	}

	inline static int32_t get_offset_of_teleport_2() { return static_cast<int32_t>(offsetof(OverrideTransformMessage_t3795345151, ___teleport_2)); }
	inline bool get_teleport_2() const { return ___teleport_2; }
	inline bool* get_address_of_teleport_2() { return &___teleport_2; }
	inline void set_teleport_2(bool value)
	{
		___teleport_2 = value;
	}

	inline static int32_t get_offset_of_time_3() { return static_cast<int32_t>(offsetof(OverrideTransformMessage_t3795345151, ___time_3)); }
	inline int32_t get_time_3() const { return ___time_3; }
	inline int32_t* get_address_of_time_3() { return &___time_3; }
	inline void set_time_3(int32_t value)
	{
		___time_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
