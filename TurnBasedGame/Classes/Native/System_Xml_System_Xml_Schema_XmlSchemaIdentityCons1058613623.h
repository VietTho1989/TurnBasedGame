#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"

// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.String
struct String_t;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.Xml.Schema.XmlSchemaXPath
struct XmlSchemaXPath_t604820427;
// Mono.Xml.Schema.XsdIdentitySelector
struct XsdIdentitySelector_t185499482;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaIdentityConstraint
struct  XmlSchemaIdentityConstraint_t1058613623  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaIdentityConstraint::fields
	XmlSchemaObjectCollection_t395083109 * ___fields_16;
	// System.String System.Xml.Schema.XmlSchemaIdentityConstraint::name
	String_t* ___name_17;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaIdentityConstraint::qName
	XmlQualifiedName_t1944712516 * ___qName_18;
	// System.Xml.Schema.XmlSchemaXPath System.Xml.Schema.XmlSchemaIdentityConstraint::selector
	XmlSchemaXPath_t604820427 * ___selector_19;
	// Mono.Xml.Schema.XsdIdentitySelector System.Xml.Schema.XmlSchemaIdentityConstraint::compiledSelector
	XsdIdentitySelector_t185499482 * ___compiledSelector_20;

public:
	inline static int32_t get_offset_of_fields_16() { return static_cast<int32_t>(offsetof(XmlSchemaIdentityConstraint_t1058613623, ___fields_16)); }
	inline XmlSchemaObjectCollection_t395083109 * get_fields_16() const { return ___fields_16; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_fields_16() { return &___fields_16; }
	inline void set_fields_16(XmlSchemaObjectCollection_t395083109 * value)
	{
		___fields_16 = value;
		Il2CppCodeGenWriteBarrier(&___fields_16, value);
	}

	inline static int32_t get_offset_of_name_17() { return static_cast<int32_t>(offsetof(XmlSchemaIdentityConstraint_t1058613623, ___name_17)); }
	inline String_t* get_name_17() const { return ___name_17; }
	inline String_t** get_address_of_name_17() { return &___name_17; }
	inline void set_name_17(String_t* value)
	{
		___name_17 = value;
		Il2CppCodeGenWriteBarrier(&___name_17, value);
	}

	inline static int32_t get_offset_of_qName_18() { return static_cast<int32_t>(offsetof(XmlSchemaIdentityConstraint_t1058613623, ___qName_18)); }
	inline XmlQualifiedName_t1944712516 * get_qName_18() const { return ___qName_18; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_qName_18() { return &___qName_18; }
	inline void set_qName_18(XmlQualifiedName_t1944712516 * value)
	{
		___qName_18 = value;
		Il2CppCodeGenWriteBarrier(&___qName_18, value);
	}

	inline static int32_t get_offset_of_selector_19() { return static_cast<int32_t>(offsetof(XmlSchemaIdentityConstraint_t1058613623, ___selector_19)); }
	inline XmlSchemaXPath_t604820427 * get_selector_19() const { return ___selector_19; }
	inline XmlSchemaXPath_t604820427 ** get_address_of_selector_19() { return &___selector_19; }
	inline void set_selector_19(XmlSchemaXPath_t604820427 * value)
	{
		___selector_19 = value;
		Il2CppCodeGenWriteBarrier(&___selector_19, value);
	}

	inline static int32_t get_offset_of_compiledSelector_20() { return static_cast<int32_t>(offsetof(XmlSchemaIdentityConstraint_t1058613623, ___compiledSelector_20)); }
	inline XsdIdentitySelector_t185499482 * get_compiledSelector_20() const { return ___compiledSelector_20; }
	inline XsdIdentitySelector_t185499482 ** get_address_of_compiledSelector_20() { return &___compiledSelector_20; }
	inline void set_compiledSelector_20(XsdIdentitySelector_t185499482 * value)
	{
		___compiledSelector_20 = value;
		Il2CppCodeGenWriteBarrier(&___compiledSelector_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
