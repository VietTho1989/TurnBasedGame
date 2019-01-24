#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.Types.NetworkID,UnityEngine.Networking.Types.NetworkAccessToken>
struct Dictionary_2_t1898959281;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Utility
struct  Utility_t2692878198  : public Il2CppObject
{
public:

public:
};

struct Utility_t2692878198_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.Types.NetworkID,UnityEngine.Networking.Types.NetworkAccessToken> UnityEngine.Networking.Utility::s_dictTokens
	Dictionary_2_t1898959281 * ___s_dictTokens_0;

public:
	inline static int32_t get_offset_of_s_dictTokens_0() { return static_cast<int32_t>(offsetof(Utility_t2692878198_StaticFields, ___s_dictTokens_0)); }
	inline Dictionary_2_t1898959281 * get_s_dictTokens_0() const { return ___s_dictTokens_0; }
	inline Dictionary_2_t1898959281 ** get_address_of_s_dictTokens_0() { return &___s_dictTokens_0; }
	inline void set_s_dictTokens_0(Dictionary_2_t1898959281 * value)
	{
		___s_dictTokens_0 = value;
		Il2CppCodeGenWriteBarrier(&___s_dictTokens_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
