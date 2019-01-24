#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.ObjectSpawnFinishedMessage
struct  ObjectSpawnFinishedMessage_t3823788215  : public MessageBase_t2552428296
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkSystem.ObjectSpawnFinishedMessage::state
	uint32_t ___state_0;

public:
	inline static int32_t get_offset_of_state_0() { return static_cast<int32_t>(offsetof(ObjectSpawnFinishedMessage_t3823788215, ___state_0)); }
	inline uint32_t get_state_0() const { return ___state_0; }
	inline uint32_t* get_address_of_state_0() { return &___state_0; }
	inline void set_state_0(uint32_t value)
	{
		___state_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
