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

// UnityEngine.Networking.NetworkSystem.PeerAuthorityMessage
struct  PeerAuthorityMessage_t1205003694  : public MessageBase_t2552428296
{
public:
	// System.Int32 UnityEngine.Networking.NetworkSystem.PeerAuthorityMessage::connectionId
	int32_t ___connectionId_0;
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkSystem.PeerAuthorityMessage::netId
	NetworkInstanceId_t33998832  ___netId_1;
	// System.Boolean UnityEngine.Networking.NetworkSystem.PeerAuthorityMessage::authorityState
	bool ___authorityState_2;

public:
	inline static int32_t get_offset_of_connectionId_0() { return static_cast<int32_t>(offsetof(PeerAuthorityMessage_t1205003694, ___connectionId_0)); }
	inline int32_t get_connectionId_0() const { return ___connectionId_0; }
	inline int32_t* get_address_of_connectionId_0() { return &___connectionId_0; }
	inline void set_connectionId_0(int32_t value)
	{
		___connectionId_0 = value;
	}

	inline static int32_t get_offset_of_netId_1() { return static_cast<int32_t>(offsetof(PeerAuthorityMessage_t1205003694, ___netId_1)); }
	inline NetworkInstanceId_t33998832  get_netId_1() const { return ___netId_1; }
	inline NetworkInstanceId_t33998832 * get_address_of_netId_1() { return &___netId_1; }
	inline void set_netId_1(NetworkInstanceId_t33998832  value)
	{
		___netId_1 = value;
	}

	inline static int32_t get_offset_of_authorityState_2() { return static_cast<int32_t>(offsetof(PeerAuthorityMessage_t1205003694, ___authorityState_2)); }
	inline bool get_authorityState_2() const { return ___authorityState_2; }
	inline bool* get_address_of_authorityState_2() { return &___authorityState_2; }
	inline void set_authorityState_2(bool value)
	{
		___authorityState_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
