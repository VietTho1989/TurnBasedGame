#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"
#include "System_Xml_System_Xml_Schema_XmlSeverityType3547578624.h"

// System.Xml.Schema.XmlSchemaException
struct XmlSchemaException_t4082200141;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.ValidationEventArgs
struct  ValidationEventArgs_t1577905814  : public EventArgs_t3289624707
{
public:
	// System.Xml.Schema.XmlSchemaException System.Xml.Schema.ValidationEventArgs::exception
	XmlSchemaException_t4082200141 * ___exception_1;
	// System.String System.Xml.Schema.ValidationEventArgs::message
	String_t* ___message_2;
	// System.Xml.Schema.XmlSeverityType System.Xml.Schema.ValidationEventArgs::severity
	int32_t ___severity_3;

public:
	inline static int32_t get_offset_of_exception_1() { return static_cast<int32_t>(offsetof(ValidationEventArgs_t1577905814, ___exception_1)); }
	inline XmlSchemaException_t4082200141 * get_exception_1() const { return ___exception_1; }
	inline XmlSchemaException_t4082200141 ** get_address_of_exception_1() { return &___exception_1; }
	inline void set_exception_1(XmlSchemaException_t4082200141 * value)
	{
		___exception_1 = value;
		Il2CppCodeGenWriteBarrier(&___exception_1, value);
	}

	inline static int32_t get_offset_of_message_2() { return static_cast<int32_t>(offsetof(ValidationEventArgs_t1577905814, ___message_2)); }
	inline String_t* get_message_2() const { return ___message_2; }
	inline String_t** get_address_of_message_2() { return &___message_2; }
	inline void set_message_2(String_t* value)
	{
		___message_2 = value;
		Il2CppCodeGenWriteBarrier(&___message_2, value);
	}

	inline static int32_t get_offset_of_severity_3() { return static_cast<int32_t>(offsetof(ValidationEventArgs_t1577905814, ___severity_3)); }
	inline int32_t get_severity_3() const { return ___severity_3; }
	inline int32_t* get_address_of_severity_3() { return &___severity_3; }
	inline void set_severity_3(int32_t value)
	{
		___severity_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
