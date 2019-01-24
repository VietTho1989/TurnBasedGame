#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Serialization.XmlAttributeAttribute
struct  XmlAttributeAttribute_t850813783  : public Attribute_t542643598
{
public:
	// System.String System.Xml.Serialization.XmlAttributeAttribute::attributeName
	String_t* ___attributeName_0;
	// System.String System.Xml.Serialization.XmlAttributeAttribute::dataType
	String_t* ___dataType_1;

public:
	inline static int32_t get_offset_of_attributeName_0() { return static_cast<int32_t>(offsetof(XmlAttributeAttribute_t850813783, ___attributeName_0)); }
	inline String_t* get_attributeName_0() const { return ___attributeName_0; }
	inline String_t** get_address_of_attributeName_0() { return &___attributeName_0; }
	inline void set_attributeName_0(String_t* value)
	{
		___attributeName_0 = value;
		Il2CppCodeGenWriteBarrier(&___attributeName_0, value);
	}

	inline static int32_t get_offset_of_dataType_1() { return static_cast<int32_t>(offsetof(XmlAttributeAttribute_t850813783, ___dataType_1)); }
	inline String_t* get_dataType_1() const { return ___dataType_1; }
	inline String_t** get_address_of_dataType_1() { return &___dataType_1; }
	inline void set_dataType_1(String_t* value)
	{
		___dataType_1 = value;
		Il2CppCodeGenWriteBarrier(&___dataType_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
