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

// UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage
struct  LobbyReadyToBeginMessage_t3495336496  : public MessageBase_t2552428296
{
public:
	// System.Byte UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage::slotId
	uint8_t ___slotId_0;
	// System.Boolean UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage::readyState
	bool ___readyState_1;

public:
	inline static int32_t get_offset_of_slotId_0() { return static_cast<int32_t>(offsetof(LobbyReadyToBeginMessage_t3495336496, ___slotId_0)); }
	inline uint8_t get_slotId_0() const { return ___slotId_0; }
	inline uint8_t* get_address_of_slotId_0() { return &___slotId_0; }
	inline void set_slotId_0(uint8_t value)
	{
		___slotId_0 = value;
	}

	inline static int32_t get_offset_of_readyState_1() { return static_cast<int32_t>(offsetof(LobbyReadyToBeginMessage_t3495336496, ___readyState_1)); }
	inline bool get_readyState_1() const { return ___readyState_1; }
	inline bool* get_address_of_readyState_1() { return &___readyState_1; }
	inline void set_readyState_1(bool value)
	{
		___readyState_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
