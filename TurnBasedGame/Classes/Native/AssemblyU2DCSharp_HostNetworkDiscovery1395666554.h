#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3838653650.h"

// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HostNetworkDiscovery
struct  HostNetworkDiscovery_t1395666554  : public NetworkDiscovery_t3838653650
{
public:
	// Server HostNetworkDiscovery::server
	Server_t2724320767 * ___server_21;
	// System.Boolean HostNetworkDiscovery::dirty
	bool ___dirty_22;

public:
	inline static int32_t get_offset_of_server_21() { return static_cast<int32_t>(offsetof(HostNetworkDiscovery_t1395666554, ___server_21)); }
	inline Server_t2724320767 * get_server_21() const { return ___server_21; }
	inline Server_t2724320767 ** get_address_of_server_21() { return &___server_21; }
	inline void set_server_21(Server_t2724320767 * value)
	{
		___server_21 = value;
		Il2CppCodeGenWriteBarrier(&___server_21, value);
	}

	inline static int32_t get_offset_of_dirty_22() { return static_cast<int32_t>(offsetof(HostNetworkDiscovery_t1395666554, ___dirty_22)); }
	inline bool get_dirty_22() const { return ___dirty_22; }
	inline bool* get_address_of_dirty_22() { return &___dirty_22; }
	inline void set_dirty_22(bool value)
	{
		___dirty_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
