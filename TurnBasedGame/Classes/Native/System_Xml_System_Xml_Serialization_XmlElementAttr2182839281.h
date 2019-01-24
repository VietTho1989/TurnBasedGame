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
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Serialization.XmlElementAttribute
struct  XmlElementAttribute_t2182839281  : public Attribute_t542643598
{
public:
	// System.String System.Xml.Serialization.XmlElementAttribute::elementName
	String_t* ___elementName_0;
	// System.Type System.Xml.Serialization.XmlElementAttribute::type
	Type_t * ___type_1;
	// System.Int32 System.Xml.Serialization.XmlElementAttribute::order
	int32_t ___order_2;

public:
	inline static int32_t get_offset_of_elementName_0() { return static_cast<int32_t>(offsetof(XmlElementAttribute_t2182839281, ___elementName_0)); }
	inline String_t* get_elementName_0() const { return ___elementName_0; }
	inline String_t** get_address_of_elementName_0() { return &___elementName_0; }
	inline void set_elementName_0(String_t* value)
	{
		___elementName_0 = value;
		Il2CppCodeGenWriteBarrier(&___elementName_0, value);
	}

	inline static int32_t get_offset_of_type_1() { return static_cast<int32_t>(offsetof(XmlElementAttribute_t2182839281, ___type_1)); }
	inline Type_t * get_type_1() const { return ___type_1; }
	inline Type_t ** get_address_of_type_1() { return &___type_1; }
	inline void set_type_1(Type_t * value)
	{
		___type_1 = value;
		Il2CppCodeGenWriteBarrier(&___type_1, value);
	}

	inline static int32_t get_offset_of_order_2() { return static_cast<int32_t>(offsetof(XmlElementAttribute_t2182839281, ___order_2)); }
	inline int32_t get_order_2() const { return ___order_2; }
	inline int32_t* get_address_of_order_2() { return &___order_2; }
	inline void set_order_2(int32_t value)
	{
		___order_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
