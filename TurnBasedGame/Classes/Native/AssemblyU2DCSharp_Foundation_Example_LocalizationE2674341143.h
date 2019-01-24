#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.LocalizationExample
struct  LocalizationExample_t2674341143  : public MonoBehaviour_t1158329972
{
public:

public:
};

struct LocalizationExample_t2674341143_StaticFields
{
public:
	// System.String Foundation.Example.LocalizationExample::ExampleString
	String_t* ___ExampleString_2;

public:
	inline static int32_t get_offset_of_ExampleString_2() { return static_cast<int32_t>(offsetof(LocalizationExample_t2674341143_StaticFields, ___ExampleString_2)); }
	inline String_t* get_ExampleString_2() const { return ___ExampleString_2; }
	inline String_t** get_address_of_ExampleString_2() { return &___ExampleString_2; }
	inline void set_ExampleString_2(String_t* value)
	{
		___ExampleString_2 = value;
		Il2CppCodeGenWriteBarrier(&___ExampleString_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
