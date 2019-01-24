#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_SystemException3877406272.h"

// System.Xml.Schema.XmlSchemaObject
struct XmlSchemaObject_t2050913741;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaException
struct  XmlSchemaException_t4082200141  : public SystemException_t3877406272
{
public:
	// System.Boolean System.Xml.Schema.XmlSchemaException::hasLineInfo
	bool ___hasLineInfo_11;
	// System.Int32 System.Xml.Schema.XmlSchemaException::lineNumber
	int32_t ___lineNumber_12;
	// System.Int32 System.Xml.Schema.XmlSchemaException::linePosition
	int32_t ___linePosition_13;
	// System.Xml.Schema.XmlSchemaObject System.Xml.Schema.XmlSchemaException::sourceObj
	XmlSchemaObject_t2050913741 * ___sourceObj_14;
	// System.String System.Xml.Schema.XmlSchemaException::sourceUri
	String_t* ___sourceUri_15;

public:
	inline static int32_t get_offset_of_hasLineInfo_11() { return static_cast<int32_t>(offsetof(XmlSchemaException_t4082200141, ___hasLineInfo_11)); }
	inline bool get_hasLineInfo_11() const { return ___hasLineInfo_11; }
	inline bool* get_address_of_hasLineInfo_11() { return &___hasLineInfo_11; }
	inline void set_hasLineInfo_11(bool value)
	{
		___hasLineInfo_11 = value;
	}

	inline static int32_t get_offset_of_lineNumber_12() { return static_cast<int32_t>(offsetof(XmlSchemaException_t4082200141, ___lineNumber_12)); }
	inline int32_t get_lineNumber_12() const { return ___lineNumber_12; }
	inline int32_t* get_address_of_lineNumber_12() { return &___lineNumber_12; }
	inline void set_lineNumber_12(int32_t value)
	{
		___lineNumber_12 = value;
	}

	inline static int32_t get_offset_of_linePosition_13() { return static_cast<int32_t>(offsetof(XmlSchemaException_t4082200141, ___linePosition_13)); }
	inline int32_t get_linePosition_13() const { return ___linePosition_13; }
	inline int32_t* get_address_of_linePosition_13() { return &___linePosition_13; }
	inline void set_linePosition_13(int32_t value)
	{
		___linePosition_13 = value;
	}

	inline static int32_t get_offset_of_sourceObj_14() { return static_cast<int32_t>(offsetof(XmlSchemaException_t4082200141, ___sourceObj_14)); }
	inline XmlSchemaObject_t2050913741 * get_sourceObj_14() const { return ___sourceObj_14; }
	inline XmlSchemaObject_t2050913741 ** get_address_of_sourceObj_14() { return &___sourceObj_14; }
	inline void set_sourceObj_14(XmlSchemaObject_t2050913741 * value)
	{
		___sourceObj_14 = value;
		Il2CppCodeGenWriteBarrier(&___sourceObj_14, value);
	}

	inline static int32_t get_offset_of_sourceUri_15() { return static_cast<int32_t>(offsetof(XmlSchemaException_t4082200141, ___sourceUri_15)); }
	inline String_t* get_sourceUri_15() const { return ___sourceUri_15; }
	inline String_t** get_address_of_sourceUri_15() { return &___sourceUri_15; }
	inline void set_sourceUri_15(String_t* value)
	{
		___sourceUri_15 = value;
		Il2CppCodeGenWriteBarrier(&___sourceUri_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
