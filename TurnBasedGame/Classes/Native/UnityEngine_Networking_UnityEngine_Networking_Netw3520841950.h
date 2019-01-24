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

// UnityEngine.Networking.NetworkSystem.RemovePlayerMessage
struct  RemovePlayerMessage_t3520841950  : public MessageBase_t2552428296
{
public:
	// System.Int16 UnityEngine.Networking.NetworkSystem.RemovePlayerMessage::playerControllerId
	int16_t ___playerControllerId_0;

public:
	inline static int32_t get_offset_of_playerControllerId_0() { return static_cast<int32_t>(offsetof(RemovePlayerMessage_t3520841950, ___playerControllerId_0)); }
	inline int16_t get_playerControllerId_0() const { return ___playerControllerId_0; }
	inline int16_t* get_address_of_playerControllerId_0() { return &___playerControllerId_0; }
	inline void set_playerControllerId_0(int16_t value)
	{
		___playerControllerId_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
