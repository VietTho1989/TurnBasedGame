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

// StringSerializationAPI
struct  StringSerializationAPI_t2463027245  : public Il2CppObject
{
public:

public:
};

struct StringSerializationAPI_t2463027245_StaticFields
{
public:
	// FullSerializer.fsSerializer StringSerializationAPI::_serializer
	fsSerializer_t4193731081 * ____serializer_0;

public:
	inline static int32_t get_offset_of__serializer_0() { return static_cast<int32_t>(offsetof(StringSerializationAPI_t2463027245_StaticFields, ____serializer_0)); }
	inline fsSerializer_t4193731081 * get__serializer_0() const { return ____serializer_0; }
	inline fsSerializer_t4193731081 ** get_address_of__serializer_0() { return &____serializer_0; }
	inline void set__serializer_0(fsSerializer_t4193731081 * value)
	{
		____serializer_0 = value;
		Il2CppCodeGenWriteBarrier(&____serializer_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
