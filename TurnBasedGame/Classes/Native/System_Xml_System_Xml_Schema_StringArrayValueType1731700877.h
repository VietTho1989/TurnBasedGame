#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.String[]
struct StringU5BU5D_t1642385972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.StringArrayValueType
struct  StringArrayValueType_t1731700877 
{
public:
	// System.String[] System.Xml.Schema.StringArrayValueType::value
	StringU5BU5D_t1642385972* ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(StringArrayValueType_t1731700877, ___value_0)); }
	inline StringU5BU5D_t1642385972* get_value_0() const { return ___value_0; }
	inline StringU5BU5D_t1642385972** get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(StringU5BU5D_t1642385972* value)
	{
		___value_0 = value;
		Il2CppCodeGenWriteBarrier(&___value_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Xml.Schema.StringArrayValueType
struct StringArrayValueType_t1731700877_marshaled_pinvoke
{
	char** ___value_0;
};
// Native definition for COM marshalling of System.Xml.Schema.StringArrayValueType
struct StringArrayValueType_t1731700877_marshaled_com
{
	Il2CppChar** ___value_0;
};
