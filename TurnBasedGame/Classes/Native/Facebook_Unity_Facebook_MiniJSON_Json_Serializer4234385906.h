#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.MiniJSON.Json/Serializer
struct  Serializer_t4234385906  : public Il2CppObject
{
public:
	// System.Text.StringBuilder Facebook.MiniJSON.Json/Serializer::builder
	StringBuilder_t1221177846 * ___builder_0;

public:
	inline static int32_t get_offset_of_builder_0() { return static_cast<int32_t>(offsetof(Serializer_t4234385906, ___builder_0)); }
	inline StringBuilder_t1221177846 * get_builder_0() const { return ___builder_0; }
	inline StringBuilder_t1221177846 ** get_address_of_builder_0() { return &___builder_0; }
	inline void set_builder_0(StringBuilder_t1221177846 * value)
	{
		___builder_0 = value;
		Il2CppCodeGenWriteBarrier(&___builder_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
