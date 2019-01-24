#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"

// System.String
struct String_t;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaNotation
struct  XmlSchemaNotation_t346281646  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.String System.Xml.Schema.XmlSchemaNotation::name
	String_t* ___name_16;
	// System.String System.Xml.Schema.XmlSchemaNotation::pub
	String_t* ___pub_17;
	// System.String System.Xml.Schema.XmlSchemaNotation::system
	String_t* ___system_18;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaNotation::qualifiedName
	XmlQualifiedName_t1944712516 * ___qualifiedName_19;

public:
	inline static int32_t get_offset_of_name_16() { return static_cast<int32_t>(offsetof(XmlSchemaNotation_t346281646, ___name_16)); }
	inline String_t* get_name_16() const { return ___name_16; }
	inline String_t** get_address_of_name_16() { return &___name_16; }
	inline void set_name_16(String_t* value)
	{
		___name_16 = value;
		Il2CppCodeGenWriteBarrier(&___name_16, value);
	}

	inline static int32_t get_offset_of_pub_17() { return static_cast<int32_t>(offsetof(XmlSchemaNotation_t346281646, ___pub_17)); }
	inline String_t* get_pub_17() const { return ___pub_17; }
	inline String_t** get_address_of_pub_17() { return &___pub_17; }
	inline void set_pub_17(String_t* value)
	{
		___pub_17 = value;
		Il2CppCodeGenWriteBarrier(&___pub_17, value);
	}

	inline static int32_t get_offset_of_system_18() { return static_cast<int32_t>(offsetof(XmlSchemaNotation_t346281646, ___system_18)); }
	inline String_t* get_system_18() const { return ___system_18; }
	inline String_t** get_address_of_system_18() { return &___system_18; }
	inline void set_system_18(String_t* value)
	{
		___system_18 = value;
		Il2CppCodeGenWriteBarrier(&___system_18, value);
	}

	inline static int32_t get_offset_of_qualifiedName_19() { return static_cast<int32_t>(offsetof(XmlSchemaNotation_t346281646, ___qualifiedName_19)); }
	inline XmlQualifiedName_t1944712516 * get_qualifiedName_19() const { return ___qualifiedName_19; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_qualifiedName_19() { return &___qualifiedName_19; }
	inline void set_qualifiedName_19(XmlQualifiedName_t1944712516 * value)
	{
		___qualifiedName_19 = value;
		Il2CppCodeGenWriteBarrier(&___qualifiedName_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
