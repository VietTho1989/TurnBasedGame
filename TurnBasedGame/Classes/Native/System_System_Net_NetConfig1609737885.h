#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.NetConfig
struct  NetConfig_t1609737885  : public Il2CppObject
{
public:
	// System.Boolean System.Net.NetConfig::ipv6Enabled
	bool ___ipv6Enabled_0;
	// System.Int32 System.Net.NetConfig::MaxResponseHeadersLength
	int32_t ___MaxResponseHeadersLength_1;

public:
	inline static int32_t get_offset_of_ipv6Enabled_0() { return static_cast<int32_t>(offsetof(NetConfig_t1609737885, ___ipv6Enabled_0)); }
	inline bool get_ipv6Enabled_0() const { return ___ipv6Enabled_0; }
	inline bool* get_address_of_ipv6Enabled_0() { return &___ipv6Enabled_0; }
	inline void set_ipv6Enabled_0(bool value)
	{
		___ipv6Enabled_0 = value;
	}

	inline static int32_t get_offset_of_MaxResponseHeadersLength_1() { return static_cast<int32_t>(offsetof(NetConfig_t1609737885, ___MaxResponseHeadersLength_1)); }
	inline int32_t get_MaxResponseHeadersLength_1() const { return ___MaxResponseHeadersLength_1; }
	inline int32_t* get_address_of_MaxResponseHeadersLength_1() { return &___MaxResponseHeadersLength_1; }
	inline void set_MaxResponseHeadersLength_1(int32_t value)
	{
		___MaxResponseHeadersLength_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
