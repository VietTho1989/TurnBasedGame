#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netwo107267906.h"

// UnityEngine.Networking.LocalClient
struct LocalClient_t4139140194;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ULocalConnectionToClient
struct  ULocalConnectionToClient_t815699498  : public NetworkConnection_t107267906
{
public:
	// UnityEngine.Networking.LocalClient UnityEngine.Networking.ULocalConnectionToClient::m_LocalClient
	LocalClient_t4139140194 * ___m_LocalClient_19;

public:
	inline static int32_t get_offset_of_m_LocalClient_19() { return static_cast<int32_t>(offsetof(ULocalConnectionToClient_t815699498, ___m_LocalClient_19)); }
	inline LocalClient_t4139140194 * get_m_LocalClient_19() const { return ___m_LocalClient_19; }
	inline LocalClient_t4139140194 ** get_address_of_m_LocalClient_19() { return &___m_LocalClient_19; }
	inline void set_m_LocalClient_19(LocalClient_t4139140194 * value)
	{
		___m_LocalClient_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalClient_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
