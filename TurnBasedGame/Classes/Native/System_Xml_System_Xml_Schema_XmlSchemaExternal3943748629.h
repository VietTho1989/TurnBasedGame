#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaObject2050913741.h"

// System.String
struct String_t;
// System.Xml.Schema.XmlSchema
struct XmlSchema_t880472818;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaExternal
struct  XmlSchemaExternal_t3943748629  : public XmlSchemaObject_t2050913741
{
public:
	// System.String System.Xml.Schema.XmlSchemaExternal::id
	String_t* ___id_13;
	// System.Xml.Schema.XmlSchema System.Xml.Schema.XmlSchemaExternal::schema
	XmlSchema_t880472818 * ___schema_14;
	// System.String System.Xml.Schema.XmlSchemaExternal::location
	String_t* ___location_15;

public:
	inline static int32_t get_offset_of_id_13() { return static_cast<int32_t>(offsetof(XmlSchemaExternal_t3943748629, ___id_13)); }
	inline String_t* get_id_13() const { return ___id_13; }
	inline String_t** get_address_of_id_13() { return &___id_13; }
	inline void set_id_13(String_t* value)
	{
		___id_13 = value;
		Il2CppCodeGenWriteBarrier(&___id_13, value);
	}

	inline static int32_t get_offset_of_schema_14() { return static_cast<int32_t>(offsetof(XmlSchemaExternal_t3943748629, ___schema_14)); }
	inline XmlSchema_t880472818 * get_schema_14() const { return ___schema_14; }
	inline XmlSchema_t880472818 ** get_address_of_schema_14() { return &___schema_14; }
	inline void set_schema_14(XmlSchema_t880472818 * value)
	{
		___schema_14 = value;
		Il2CppCodeGenWriteBarrier(&___schema_14, value);
	}

	inline static int32_t get_offset_of_location_15() { return static_cast<int32_t>(offsetof(XmlSchemaExternal_t3943748629, ___location_15)); }
	inline String_t* get_location_15() const { return ___location_15; }
	inline String_t** get_address_of_location_15() { return &___location_15; }
	inline void set_location_15(String_t* value)
	{
		___location_15 = value;
		Il2CppCodeGenWriteBarrier(&___location_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
