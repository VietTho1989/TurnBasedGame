#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlLinkedNode1287616130.h"

// System.Xml.XmlAttributeCollection
struct XmlAttributeCollection_t3359885287;
// System.Xml.XmlNameEntry
struct XmlNameEntry_t3745551716;
// System.Xml.XmlLinkedNode
struct XmlLinkedNode_t1287616130;
// System.Xml.Schema.IXmlSchemaInfo
struct IXmlSchemaInfo_t2533799901;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlElement
struct  XmlElement_t2877111883  : public XmlLinkedNode_t1287616130
{
public:
	// System.Xml.XmlAttributeCollection System.Xml.XmlElement::attributes
	XmlAttributeCollection_t3359885287 * ___attributes_6;
	// System.Xml.XmlNameEntry System.Xml.XmlElement::name
	XmlNameEntry_t3745551716 * ___name_7;
	// System.Xml.XmlLinkedNode System.Xml.XmlElement::lastLinkedChild
	XmlLinkedNode_t1287616130 * ___lastLinkedChild_8;
	// System.Boolean System.Xml.XmlElement::isNotEmpty
	bool ___isNotEmpty_9;
	// System.Xml.Schema.IXmlSchemaInfo System.Xml.XmlElement::schemaInfo
	Il2CppObject * ___schemaInfo_10;

public:
	inline static int32_t get_offset_of_attributes_6() { return static_cast<int32_t>(offsetof(XmlElement_t2877111883, ___attributes_6)); }
	inline XmlAttributeCollection_t3359885287 * get_attributes_6() const { return ___attributes_6; }
	inline XmlAttributeCollection_t3359885287 ** get_address_of_attributes_6() { return &___attributes_6; }
	inline void set_attributes_6(XmlAttributeCollection_t3359885287 * value)
	{
		___attributes_6 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_6, value);
	}

	inline static int32_t get_offset_of_name_7() { return static_cast<int32_t>(offsetof(XmlElement_t2877111883, ___name_7)); }
	inline XmlNameEntry_t3745551716 * get_name_7() const { return ___name_7; }
	inline XmlNameEntry_t3745551716 ** get_address_of_name_7() { return &___name_7; }
	inline void set_name_7(XmlNameEntry_t3745551716 * value)
	{
		___name_7 = value;
		Il2CppCodeGenWriteBarrier(&___name_7, value);
	}

	inline static int32_t get_offset_of_lastLinkedChild_8() { return static_cast<int32_t>(offsetof(XmlElement_t2877111883, ___lastLinkedChild_8)); }
	inline XmlLinkedNode_t1287616130 * get_lastLinkedChild_8() const { return ___lastLinkedChild_8; }
	inline XmlLinkedNode_t1287616130 ** get_address_of_lastLinkedChild_8() { return &___lastLinkedChild_8; }
	inline void set_lastLinkedChild_8(XmlLinkedNode_t1287616130 * value)
	{
		___lastLinkedChild_8 = value;
		Il2CppCodeGenWriteBarrier(&___lastLinkedChild_8, value);
	}

	inline static int32_t get_offset_of_isNotEmpty_9() { return static_cast<int32_t>(offsetof(XmlElement_t2877111883, ___isNotEmpty_9)); }
	inline bool get_isNotEmpty_9() const { return ___isNotEmpty_9; }
	inline bool* get_address_of_isNotEmpty_9() { return &___isNotEmpty_9; }
	inline void set_isNotEmpty_9(bool value)
	{
		___isNotEmpty_9 = value;
	}

	inline static int32_t get_offset_of_schemaInfo_10() { return static_cast<int32_t>(offsetof(XmlElement_t2877111883, ___schemaInfo_10)); }
	inline Il2CppObject * get_schemaInfo_10() const { return ___schemaInfo_10; }
	inline Il2CppObject ** get_address_of_schemaInfo_10() { return &___schemaInfo_10; }
	inline void set_schemaInfo_10(Il2CppObject * value)
	{
		___schemaInfo_10 = value;
		Il2CppCodeGenWriteBarrier(&___schemaInfo_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
