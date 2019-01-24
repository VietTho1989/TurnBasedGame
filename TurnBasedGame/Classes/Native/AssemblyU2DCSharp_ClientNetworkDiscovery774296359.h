#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3838653650.h"

// DiscoveredServers
struct DiscoveredServers_t3079914554;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientNetworkDiscovery
struct  ClientNetworkDiscovery_t774296359  : public NetworkDiscovery_t3838653650
{
public:
	// DiscoveredServers ClientNetworkDiscovery::discoveredServers
	DiscoveredServers_t3079914554 * ___discoveredServers_21;

public:
	inline static int32_t get_offset_of_discoveredServers_21() { return static_cast<int32_t>(offsetof(ClientNetworkDiscovery_t774296359, ___discoveredServers_21)); }
	inline DiscoveredServers_t3079914554 * get_discoveredServers_21() const { return ___discoveredServers_21; }
	inline DiscoveredServers_t3079914554 ** get_address_of_discoveredServers_21() { return &___discoveredServers_21; }
	inline void set_discoveredServers_21(DiscoveredServers_t3079914554 * value)
	{
		___discoveredServers_21 = value;
		Il2CppCodeGenWriteBarrier(&___discoveredServers_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
