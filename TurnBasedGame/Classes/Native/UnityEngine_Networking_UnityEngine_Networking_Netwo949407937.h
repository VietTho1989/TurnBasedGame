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





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.AnimationTriggerMessage
struct  AnimationTriggerMessage_t949407937  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.AnimationTriggerMessage::netId
	NetworkInstanceId_t33998832  ___netId_0;
	// System.Int32 UnityEngine.Networking.NetworkSystem.AnimationTriggerMessage::hash
	int32_t ___hash_1;

public:
	inline static int32_t get_offset_of_netId_0() { return static_cast<int32_t>(offsetof(AnimationTriggerMessage_t949407937, ___netId_0)); }
	inline NetworkInstanceId_t33998832  get_netId_0() const { return ___netId_0; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_0() { return &___netId_0; }
	inline void set_netId_0(NetworkInstanceId_t33998832  value)
	{
		___netId_0 = value;
	}

	inline static int32_t get_offset_of_hash_1() { return static_cast<int32_t>(offsetof(AnimationTriggerMessage_t949407937, ___hash_1)); }
	inline int32_t get_hash_1() const { return ___hash_1; }
	inline int32_t* get_address_of_hash_1() { return &___hash_1; }
	inline void set_hash_1(int32_t value)
	{
		___hash_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
