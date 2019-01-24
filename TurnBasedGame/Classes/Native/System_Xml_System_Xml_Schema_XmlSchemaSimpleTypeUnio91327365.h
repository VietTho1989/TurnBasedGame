#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaSimpleTypeCo1606103299.h"

// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.Xml.XmlQualifiedName[]
struct XmlQualifiedNameU5BU5D_t717347117;
// System.Object[]
struct ObjectU5BU5D_t3614634134;
// System.Xml.Schema.XmlSchemaSimpleType[]
struct XmlSchemaSimpleTypeU5BU5D_t192177157;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaSimpleTypeUnion
struct  XmlSchemaSimpleTypeUnion_t91327365  : public XmlSchemaSimpleTypeContent_t1606103299
{
public:
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaSimpleTypeUnion::baseTypes
	XmlSchemaObjectCollection_t395083109 * ___baseTypes_17;
	// System.Xml.XmlQualifiedName[] System.Xml.Schema.XmlSchemaSimpleTypeUnion::memberTypes
	XmlQualifiedNameU5BU5D_t717347117* ___memberTypes_18;
	// System.Object[] System.Xml.Schema.XmlSchemaSimpleTypeUnion::validatedTypes
	ObjectU5BU5D_t3614634134* ___validatedTypes_19;
	// System.Xml.Schema.XmlSchemaSimpleType[] System.Xml.Schema.XmlSchemaSimpleTypeUnion::validatedSchemaTypes
	XmlSchemaSimpleTypeU5BU5D_t192177157* ___validatedSchemaTypes_20;

public:
	inline static int32_t get_offset_of_baseTypes_17() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleTypeUnion_t91327365, ___baseTypes_17)); }
	inline XmlSchemaObjectCollection_t395083109 * get_baseTypes_17() const { return ___baseTypes_17; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_baseTypes_17() { return &___baseTypes_17; }
	inline void set_baseTypes_17(XmlSchemaObjectCollection_t395083109 * value)
	{
		___baseTypes_17 = value;
		Il2CppCodeGenWriteBarrier(&___baseTypes_17, value);
	}

	inline static int32_t get_offset_of_memberTypes_18() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleTypeUnion_t91327365, ___memberTypes_18)); }
	inline XmlQualifiedNameU5BU5D_t717347117* get_memberTypes_18() const { return ___memberTypes_18; }
	inline XmlQualifiedNameU5BU5D_t717347117** get_address_of_memberTypes_18() { return &___memberTypes_18; }
	inline void set_memberTypes_18(XmlQualifiedNameU5BU5D_t717347117* value)
	{
		___memberTypes_18 = value;
		Il2CppCodeGenWriteBarrier(&___memberTypes_18, value);
	}

	inline static int32_t get_offset_of_validatedTypes_19() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleTypeUnion_t91327365, ___validatedTypes_19)); }
	inline ObjectU5BU5D_t3614634134* get_validatedTypes_19() const { return ___validatedTypes_19; }
	inline ObjectU5BU5D_t3614634134** get_address_of_validatedTypes_19() { return &___validatedTypes_19; }
	inline void set_validatedTypes_19(ObjectU5BU5D_t3614634134* value)
	{
		___validatedTypes_19 = value;
		Il2CppCodeGenWriteBarrier(&___validatedTypes_19, value);
	}

	inline static int32_t get_offset_of_validatedSchemaTypes_20() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleTypeUnion_t91327365, ___validatedSchemaTypes_20)); }
	inline XmlSchemaSimpleTypeU5BU5D_t192177157* get_validatedSchemaTypes_20() const { return ___validatedSchemaTypes_20; }
	inline XmlSchemaSimpleTypeU5BU5D_t192177157** get_address_of_validatedSchemaTypes_20() { return &___validatedSchemaTypes_20; }
	inline void set_validatedSchemaTypes_20(XmlSchemaSimpleTypeU5BU5D_t192177157* value)
	{
		___validatedSchemaTypes_20 = value;
		Il2CppCodeGenWriteBarrier(&___validatedSchemaTypes_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
