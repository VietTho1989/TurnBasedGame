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

// UnityEngine.Networking.NetworkSystem.AnimationParametersMessage
struct  AnimationParametersMessage_t349763583  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.AnimationParametersMessage::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// System.Byte[] UnityEngine.Networking.NetworkSystem.AnimationParametersMessage::parameters
	ByteU5BU5D_t3397334013* ___parameters_1;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(AnimationParametersMessage_t349763583, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(AnimationParametersMessage_t349763583, ___parameters_1)); }
	inline ByteU5BU5D_t3397334013* get_parameters_1() const { return ___parameters_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(ByteU5BU5D_t3397334013* value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
