#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// SimpleJson.IJsonSerializerStrategy
struct IJsonSerializerStrategy_t209712766;
// SimpleJson.PocoJsonSerializerStrategy
struct PocoJsonSerializerStrategy_t2810850750;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SimpleJson.SimpleJson
struct  SimpleJson_t3569903358  : public Il2CppObject
{
public:

public:
};

struct SimpleJson_t3569903358_StaticFields
{
public:
	// SimpleJson.IJsonSerializerStrategy SimpleJson.SimpleJson::_currentJsonSerializerStrategy
	Il2CppObject * ____currentJsonSerializerStrategy_0;
	// SimpleJson.PocoJsonSerializerStrategy SimpleJson.SimpleJson::_pocoJsonSerializerStrategy
	PocoJsonSerializerStrategy_t2810850750 * ____pocoJsonSerializerStrategy_1;

public:
	inline static int32_t get_offset_of__currentJsonSerializerStrategy_0() { return static_cast<int32_t>(offsetof(SimpleJson_t3569903358_StaticFields, ____currentJsonSerializerStrategy_0)); }
	inline Il2CppObject * get__currentJsonSerializerStrategy_0() const { return ____currentJsonSerializerStrategy_0; }
	inline Il2CppObject ** get_address_of__currentJsonSerializerStrategy_0() { return &____currentJsonSerializerStrategy_0; }
	inline void set__currentJsonSerializerStrategy_0(Il2CppObject * value)
	{
		____currentJsonSerializerStrategy_0 = value;
		Il2CppCodeGenWriteBarrier(&____currentJsonSerializerStrategy_0, value);
	}

	inline static int32_t get_offset_of__pocoJsonSerializerStrategy_1() { return static_cast<int32_t>(offsetof(SimpleJson_t3569903358_StaticFields, ____pocoJsonSerializerStrategy_1)); }
	inline PocoJsonSerializerStrategy_t2810850750 * get__pocoJsonSerializerStrategy_1() const { return ____pocoJsonSerializerStrategy_1; }
	inline PocoJsonSerializerStrategy_t2810850750 ** get_address_of__pocoJsonSerializerStrategy_1() { return &____pocoJsonSerializerStrategy_1; }
	inline void set__pocoJsonSerializerStrategy_1(PocoJsonSerializerStrategy_t2810850750 * value)
	{
		____pocoJsonSerializerStrategy_1 = value;
		Il2CppCodeGenWriteBarrier(&____pocoJsonSerializerStrategy_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
