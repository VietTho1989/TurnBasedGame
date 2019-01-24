#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// FullSerializer.fsSerializer
struct fsSerializer_t4193731081;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.JsonSerializer
struct  JsonSerializer_t436789542  : public Il2CppObject
{
public:

public:
};

struct JsonSerializer_t436789542_StaticFields
{
public:
	// FullSerializer.fsSerializer FullSerializer.JsonSerializer::Internal
	fsSerializer_t4193731081 * ___Internal_0;

public:
	inline static int32_t get_offset_of_Internal_0() { return static_cast<int32_t>(offsetof(JsonSerializer_t436789542_StaticFields, ___Internal_0)); }
	inline fsSerializer_t4193731081 * get_Internal_0() const { return ___Internal_0; }
	inline fsSerializer_t4193731081 ** get_address_of_Internal_0() { return &___Internal_0; }
	inline void set_Internal_0(fsSerializer_t4193731081 * value)
	{
		___Internal_0 = value;
		Il2CppCodeGenWriteBarrier(&___Internal_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
