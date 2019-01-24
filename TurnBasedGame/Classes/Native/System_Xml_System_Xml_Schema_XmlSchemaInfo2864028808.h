#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaValidity995929432.h"

// System.Xml.Schema.XmlSchemaSimpleType
struct XmlSchemaSimpleType_t248156492;
// System.Xml.Schema.XmlSchemaAttribute
struct XmlSchemaAttribute_t4015859774;
// System.Xml.Schema.XmlSchemaElement
struct XmlSchemaElement_t2433337156;
// System.Xml.Schema.XmlSchemaType
struct XmlSchemaType_t1795078578;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaInfo
struct  XmlSchemaInfo_t2864028808  : public Il2CppObject
{
public:
	// System.Boolean System.Xml.Schema.XmlSchemaInfo::isDefault
	bool ___isDefault_0;
	// System.Boolean System.Xml.Schema.XmlSchemaInfo::isNil
	bool ___isNil_1;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaInfo::memberType
	XmlSchemaSimpleType_t248156492 * ___memberType_2;
	// System.Xml.Schema.XmlSchemaAttribute System.Xml.Schema.XmlSchemaInfo::attr
	XmlSchemaAttribute_t4015859774 * ___attr_3;
	// System.Xml.Schema.XmlSchemaElement System.Xml.Schema.XmlSchemaInfo::elem
	XmlSchemaElement_t2433337156 * ___elem_4;
	// System.Xml.Schema.XmlSchemaType System.Xml.Schema.XmlSchemaInfo::type
	XmlSchemaType_t1795078578 * ___type_5;
	// System.Xml.Schema.XmlSchemaValidity System.Xml.Schema.XmlSchemaInfo::validity
	int32_t ___validity_6;

public:
	inline static int32_t get_offset_of_isDefault_0() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___isDefault_0)); }
	inline bool get_isDefault_0() const { return ___isDefault_0; }
	inline bool* get_address_of_isDefault_0() { return &___isDefault_0; }
	inline void set_isDefault_0(bool value)
	{
		___isDefault_0 = value;
	}

	inline static int32_t get_offset_of_isNil_1() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___isNil_1)); }
	inline bool get_isNil_1() const { return ___isNil_1; }
	inline bool* get_address_of_isNil_1() { return &___isNil_1; }
	inline void set_isNil_1(bool value)
	{
		___isNil_1 = value;
	}

	inline static int32_t get_offset_of_memberType_2() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___memberType_2)); }
	inline XmlSchemaSimpleType_t248156492 * get_memberType_2() const { return ___memberType_2; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_memberType_2() { return &___memberType_2; }
	inline void set_memberType_2(XmlSchemaSimpleType_t248156492 * value)
	{
		___memberType_2 = value;
		Il2CppCodeGenWriteBarrier(&___memberType_2, value);
	}

	inline static int32_t get_offset_of_attr_3() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___attr_3)); }
	inline XmlSchemaAttribute_t4015859774 * get_attr_3() const { return ___attr_3; }
	inline XmlSchemaAttribute_t4015859774 ** get_address_of_attr_3() { return &___attr_3; }
	inline void set_attr_3(XmlSchemaAttribute_t4015859774 * value)
	{
		___attr_3 = value;
		Il2CppCodeGenWriteBarrier(&___attr_3, value);
	}

	inline static int32_t get_offset_of_elem_4() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___elem_4)); }
	inline XmlSchemaElement_t2433337156 * get_elem_4() const { return ___elem_4; }
	inline XmlSchemaElement_t2433337156 ** get_address_of_elem_4() { return &___elem_4; }
	inline void set_elem_4(XmlSchemaElement_t2433337156 * value)
	{
		___elem_4 = value;
		Il2CppCodeGenWriteBarrier(&___elem_4, value);
	}

	inline static int32_t get_offset_of_type_5() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___type_5)); }
	inline XmlSchemaType_t1795078578 * get_type_5() const { return ___type_5; }
	inline XmlSchemaType_t1795078578 ** get_address_of_type_5() { return &___type_5; }
	inline void set_type_5(XmlSchemaType_t1795078578 * value)
	{
		___type_5 = value;
		Il2CppCodeGenWriteBarrier(&___type_5, value);
	}

	inline static int32_t get_offset_of_validity_6() { return static_cast<int32_t>(offsetof(XmlSchemaInfo_t2864028808, ___validity_6)); }
	inline int32_t get_validity_6() const { return ___validity_6; }
	inline int32_t* get_address_of_validity_6() { return &___validity_6; }
	inline void set_validity_6(int32_t value)
	{
		___validity_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
