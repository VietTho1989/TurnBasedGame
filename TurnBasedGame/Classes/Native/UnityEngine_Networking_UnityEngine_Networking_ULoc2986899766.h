#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netwo107267906.h"

// UnityEngine.Networking.NetworkServer
struct NetworkServer_t3779449791;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ULocalConnectionToServer
struct  ULocalConnectionToServer_t2986899766  : public NetworkConnection_t107267906
{
public:
	// UnityEngine.Networking.NetworkServer UnityEngine.Networking.ULocalConnectionToServer::m_LocalServer
	NetworkServer_t3779449791 * ___m_LocalServer_19;

public:
	inline static int32_t get_offset_of_m_LocalServer_19() { return static_cast<int32_t>(offsetof(ULocalConnectionToServer_t2986899766, ___m_LocalServer_19)); }
	inline NetworkServer_t3779449791 * get_m_LocalServer_19() const { return ___m_LocalServer_19; }
	inline NetworkServer_t3779449791 ** get_address_of_m_LocalServer_19() { return &___m_LocalServer_19; }
	inline void set_m_LocalServer_19(NetworkServer_t3779449791 * value)
	{
		___m_LocalServer_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalServer_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
