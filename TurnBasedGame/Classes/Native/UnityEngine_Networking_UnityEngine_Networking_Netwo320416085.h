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
#include "UnityEngine_Networking_UnityEngine_Networking_Netwo835211239.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "UnityEngine_UnityEngine_Quaternion4030073918.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage
struct  ObjectSpawnMessage_t320416085  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// UnityEngine.Networking.NetworkHash128 UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage::assetId
	NetworkHash128_t835211239  ___assetId_1;
	// UnityEngine.Vector3 UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage::position
	Vector3_t2243707580  ___position_2;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage::payload
	ByteU5BU5D_t3397334013* ___payload_3;
	// UnityEngine.Quaternion UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage::rotation
	Quaternion_t4030073918  ___rotation_4;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(ObjectSpawnMessage_t320416085, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_assetId_1() { return static_cast<int32_t>(offsetof(ObjectSpawnMessage_t320416085, ___assetId_1)); }
	inline NetworkHash128_t835211239  get_assetId_1() const { return ___assetId_1; }
	inline NetworkHash128_t835211239 * get_address_of_assetId_1() { return &___assetId_1; }
	inline void set_assetId_1(NetworkHash128_t835211239  value)
	{
		___assetId_1 = value;
	}

	inline static int32_t get_offset_of_position_2() { return static_cast<int32_t>(offsetof(ObjectSpawnMessage_t320416085, ___position_2)); }
	inline Vector3_t2243707580  get_position_2() const { return ___position_2; }
	inline Vector3_t2243707580 * get_address_of_position_2() { return &___position_2; }
	inline void set_position_2(Vector3_t2243707580  value)
	{
		___position_2 = value;
	}

	inline static int32_t get_offset_of_payload_3() { return static_cast<int32_t>(offsetof(ObjectSpawnMessage_t320416085, ___payload_3)); }
	inline ByteU5BU5D_t3397334013* get_payload_3() const { return ___payload_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_payload_3() { return &___payload_3; }
	inline void set_payload_3(ByteU5BU5D_t3397334013* value)
	{
		___payload_3 = value;
		Il2CppCodeGenWriteBarrier(&___payload_3, value);
	}

	inline static int32_t get_offset_of_rotation_4() { return static_cast<int32_t>(offsetof(ObjectSpawnMessage_t320416085, ___rotation_4)); }
	inline Quaternion_t4030073918  get_rotation_4() const { return ___rotation_4; }
	inline Quaternion_t4030073918 * get_address_of_rotation_4() { return &___rotation_4; }
	inline void set_rotation_4(Quaternion_t4030073918  value)
	{
		___rotation_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
