#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"

// System.Xml.Schema.XmlSchemaAnyAttribute
struct XmlSchemaAnyAttribute_t530453212;
// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.String
struct String_t;
// System.Xml.Schema.XmlSchemaAttributeGroup
struct XmlSchemaAttributeGroup_t491156493;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.Xml.Schema.XmlSchemaObjectTable
struct XmlSchemaObjectTable_t3364835593;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaAttributeGroup
struct  XmlSchemaAttributeGroup_t491156493  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.Xml.Schema.XmlSchemaAnyAttribute System.Xml.Schema.XmlSchemaAttributeGroup::anyAttribute
	XmlSchemaAnyAttribute_t530453212 * ___anyAttribute_16;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaAttributeGroup::attributes
	XmlSchemaObjectCollection_t395083109 * ___attributes_17;
	// System.String System.Xml.Schema.XmlSchemaAttributeGroup::name
	String_t* ___name_18;
	// System.Xml.Schema.XmlSchemaAttributeGroup System.Xml.Schema.XmlSchemaAttributeGroup::redefined
	XmlSchemaAttributeGroup_t491156493 * ___redefined_19;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaAttributeGroup::qualifiedName
	XmlQualifiedName_t1944712516 * ___qualifiedName_20;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchemaAttributeGroup::attributeUses
	XmlSchemaObjectTable_t3364835593 * ___attributeUses_21;
	// System.Xml.Schema.XmlSchemaAnyAttribute System.Xml.Schema.XmlSchemaAttributeGroup::anyAttributeUse
	XmlSchemaAnyAttribute_t530453212 * ___anyAttributeUse_22;
	// System.Boolean System.Xml.Schema.XmlSchemaAttributeGroup::AttributeGroupRecursionCheck
	bool ___AttributeGroupRecursionCheck_23;

public:
	inline static int32_t get_offset_of_anyAttribute_16() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___anyAttribute_16)); }
	inline XmlSchemaAnyAttribute_t530453212 * get_anyAttribute_16() const { return ___anyAttribute_16; }
	inline XmlSchemaAnyAttribute_t530453212 ** get_address_of_anyAttribute_16() { return &___anyAttribute_16; }
	inline void set_anyAttribute_16(XmlSchemaAnyAttribute_t530453212 * value)
	{
		___anyAttribute_16 = value;
		Il2CppCodeGenWriteBarrier(&___anyAttribute_16, value);
	}

	inline static int32_t get_offset_of_attributes_17() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___attributes_17)); }
	inline XmlSchemaObjectCollection_t395083109 * get_attributes_17() const { return ___attributes_17; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_attributes_17() { return &___attributes_17; }
	inline void set_attributes_17(XmlSchemaObjectCollection_t395083109 * value)
	{
		___attributes_17 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_17, value);
	}

	inline static int32_t get_offset_of_name_18() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___name_18)); }
	inline String_t* get_name_18() const { return ___name_18; }
	inline String_t** get_address_of_name_18() { return &___name_18; }
	inline void set_name_18(String_t* value)
	{
		___name_18 = value;
		Il2CppCodeGenWriteBarrier(&___name_18, value);
	}

	inline static int32_t get_offset_of_redefined_19() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___redefined_19)); }
	inline XmlSchemaAttributeGroup_t491156493 * get_redefined_19() const { return ___redefined_19; }
	inline XmlSchemaAttributeGroup_t491156493 ** get_address_of_redefined_19() { return &___redefined_19; }
	inline void set_redefined_19(XmlSchemaAttributeGroup_t491156493 * value)
	{
		___redefined_19 = value;
		Il2CppCodeGenWriteBarrier(&___redefined_19, value);
	}

	inline static int32_t get_offset_of_qualifiedName_20() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___qualifiedName_20)); }
	inline XmlQualifiedName_t1944712516 * get_qualifiedName_20() const { return ___qualifiedName_20; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_qualifiedName_20() { return &___qualifiedName_20; }
	inline void set_qualifiedName_20(XmlQualifiedName_t1944712516 * value)
	{
		___qualifiedName_20 = value;
		Il2CppCodeGenWriteBarrier(&___qualifiedName_20, value);
	}

	inline static int32_t get_offset_of_attributeUses_21() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___attributeUses_21)); }
	inline XmlSchemaObjectTable_t3364835593 * get_attributeUses_21() const { return ___attributeUses_21; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_attributeUses_21() { return &___attributeUses_21; }
	inline void set_attributeUses_21(XmlSchemaObjectTable_t3364835593 * value)
	{
		___attributeUses_21 = value;
		Il2CppCodeGenWriteBarrier(&___attributeUses_21, value);
	}

	inline static int32_t get_offset_of_anyAttributeUse_22() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___anyAttributeUse_22)); }
	inline XmlSchemaAnyAttribute_t530453212 * get_anyAttributeUse_22() const { return ___anyAttributeUse_22; }
	inline XmlSchemaAnyAttribute_t530453212 ** get_address_of_anyAttributeUse_22() { return &___anyAttributeUse_22; }
	inline void set_anyAttributeUse_22(XmlSchemaAnyAttribute_t530453212 * value)
	{
		___anyAttributeUse_22 = value;
		Il2CppCodeGenWriteBarrier(&___anyAttributeUse_22, value);
	}

	inline static int32_t get_offset_of_AttributeGroupRecursionCheck_23() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroup_t491156493, ___AttributeGroupRecursionCheck_23)); }
	inline bool get_AttributeGroupRecursionCheck_23() const { return ___AttributeGroupRecursionCheck_23; }
	inline bool* get_address_of_AttributeGroupRecursionCheck_23() { return &___AttributeGroupRecursionCheck_23; }
	inline void set_AttributeGroupRecursionCheck_23(bool value)
	{
		___AttributeGroupRecursionCheck_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
