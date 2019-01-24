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

// UnityEngine.Networking.NetworkSystem.AnimationMessage
struct  AnimationMessage_t3934203181  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.AnimationMessage::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// System.Int32 UnityEngine.Networking.NetworkSystem.AnimationMessage::stateHash
	int32_t ___stateHash_1;
	// System.Single UnityEngine.Networking.NetworkSystem.AnimationMessage::normalizedTime
	float ___normalizedTime_2;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.AnimationMessage::parameters
	ByteU5BU5D_t3397334013* ___parameters_3;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(AnimationMessage_t3934203181, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_stateHash_1() { return static_cast<int32_t>(offsetof(AnimationMessage_t3934203181, ___stateHash_1)); }
	inline int32_t get_stateHash_1() const { return ___stateHash_1; }
	inline int32_t* get_address_of_stateHash_1() { return &___stateHash_1; }
	inline void set_stateHash_1(int32_t value)
	{
		___stateHash_1 = value;
	}

	inline static int32_t get_offset_of_normalizedTime_2() { return static_cast<int32_t>(offsetof(AnimationMessage_t3934203181, ___normalizedTime_2)); }
	inline float get_normalizedTime_2() const { return ___normalizedTime_2; }
	inline float* get_address_of_normalizedTime_2() { return &___normalizedTime_2; }
	inline void set_normalizedTime_2(float value)
	{
		___normalizedTime_2 = value;
	}

	inline static int32_t get_offset_of_parameters_3() { return static_cast<int32_t>(offsetof(AnimationMessage_t3934203181, ___parameters_3)); }
	inline ByteU5BU5D_t3397334013* get_parameters_3() const { return ___parameters_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_parameters_3() { return &___parameters_3; }
	inline void set_parameters_3(ByteU5BU5D_t3397334013* value)
	{
		___parameters_3 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
