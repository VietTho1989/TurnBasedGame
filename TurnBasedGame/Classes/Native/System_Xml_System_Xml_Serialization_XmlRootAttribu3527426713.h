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

// System.Xml.Serialization.XmlRootAttribute
struct  XmlRootAttribute_t3527426713  : public Attribute_t542643598
{
public:
	// System.String System.Xml.Serialization.XmlRootAttribute::elementName
	String_t* ___elementName_0;
	// System.Boolean System.Xml.Serialization.XmlRootAttribute::isNullable
	bool ___isNullable_1;
	// System.String System.Xml.Serialization.XmlRootAttribute::ns
	String_t* ___ns_2;

public:
	inline static int32_t get_offset_of_elementName_0() { return static_cast<int32_t>(offsetof(XmlRootAttribute_t3527426713, ___elementName_0)); }
	inline String_t* get_elementName_0() const { return ___elementName_0; }
	inline String_t** get_address_of_elementName_0() { return &___elementName_0; }
	inline void set_elementName_0(String_t* value)
	{
		___elementName_0 = value;
		Il2CppCodeGenWriteBarrier(&___elementName_0, value);
	}

	inline static int32_t get_offset_of_isNullable_1() { return static_cast<int32_t>(offsetof(XmlRootAttribute_t3527426713, ___isNullable_1)); }
	inline bool get_isNullable_1() const { return ___isNullable_1; }
	inline bool* get_address_of_isNullable_1() { return &___isNullable_1; }
	inline void set_isNullable_1(bool value)
	{
		___isNullable_1 = value;
	}

	inline static int32_t get_offset_of_ns_2() { return static_cast<int32_t>(offsetof(XmlRootAttribute_t3527426713, ___ns_2)); }
	inline String_t* get_ns_2() const { return ___ns_2; }
	inline String_t** get_address_of_ns_2() { return &___ns_2; }
	inline void set_ns_2(String_t* value)
	{
		___ns_2 = value;
		Il2CppCodeGenWriteBarrier(&___ns_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
