#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// Mono.Xml.Schema.XmlSchemaUri
struct XmlSchemaUri_t1295878664;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.UriValueType
struct  UriValueType_t1626089757 
{
public:
	// Mono.Xml.Schema.XmlSchemaUri System.Xml.Schema.UriValueType::value
	XmlSchemaUri_t1295878664 * ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(UriValueType_t1626089757, ___value_0)); }
	inline XmlSchemaUri_t1295878664 * get_value_0() const { return ___value_0; }
	inline XmlSchemaUri_t1295878664 ** get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(XmlSchemaUri_t1295878664 * value)
	{
		___value_0 = value;
		Il2CppCodeGenWriteBarrier(&___value_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Xml.Schema.UriValueType
struct UriValueType_t1626089757_marshaled_pinvoke
{
	XmlSchemaUri_t1295878664 * ___value_0;
};
// Native definition for COM marshalling of System.Xml.Schema.UriValueType
struct UriValueType_t1626089757_marshaled_com
{
	XmlSchemaUri_t1295878664 * ___value_0;
};
