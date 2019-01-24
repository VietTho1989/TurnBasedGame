#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// LP`1<DiscoveredServer>
struct LP_1_t222966109;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DiscoveredServers
struct  DiscoveredServers_t3079914554  : public Data_t3569509720
{
public:
	// LP`1<DiscoveredServer> DiscoveredServers::servers
	LP_1_t222966109 * ___servers_5;

public:
	inline static int32_t get_offset_of_servers_5() { return static_cast<int32_t>(offsetof(DiscoveredServers_t3079914554, ___servers_5)); }
	inline LP_1_t222966109 * get_servers_5() const { return ___servers_5; }
	inline LP_1_t222966109 ** get_address_of_servers_5() { return &___servers_5; }
	inline void set_servers_5(LP_1_t222966109 * value)
	{
		___servers_5 = value;
		Il2CppCodeGenWriteBarrier(&___servers_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
