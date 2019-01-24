#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[]
struct PeerInfoMessageU5BU5D_t2669814294;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.PeerListMessage
struct  PeerListMessage_t297244123  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[] UnityEngine.Networking.NetworkSystem.PeerListMessage::peers
	PeerInfoMessageU5BU5D_t2669814294* ___peers_0;
	// System.Int32 UnityEngine.Networking.NetworkSystem.PeerListMessage::oldServerConnectionId
	int32_t ___oldServerConnectionId_1;

public:
	inline static int32_t get_offset_of_peers_0() { return static_cast<int32_t>(offsetof(PeerListMessage_t297244123, ___peers_0)); }
	inline PeerInfoMessageU5BU5D_t2669814294* get_peers_0() const { return ___peers_0; }
	inline PeerInfoMessageU5BU5D_t2669814294** get_address_of_peers_0() { return &___peers_0; }
	inline void set_peers_0(PeerInfoMessageU5BU5D_t2669814294* value)
	{
		___peers_0 = value;
		Il2CppCodeGenWriteBarrier(&___peers_0, value);
	}

	inline static int32_t get_offset_of_oldServerConnectionId_1() { return static_cast<int32_t>(offsetof(PeerListMessage_t297244123, ___oldServerConnectionId_1)); }
	inline int32_t get_oldServerConnectionId_1() const { return ___oldServerConnectionId_1; }
	inline int32_t* get_address_of_oldServerConnectionId_1() { return &___oldServerConnectionId_1; }
	inline void set_oldServerConnectionId_1(int32_t value)
	{
		___oldServerConnectionId_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
