#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaDerivationMe3165007540.h"

// System.String
struct String_t;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.Xml.Schema.XmlSchemaType
struct XmlSchemaType_t1795078578;
// System.Xml.Schema.XmlSchemaDatatype
struct XmlSchemaDatatype_t1195946242;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaType
struct  XmlSchemaType_t1795078578  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaType::final
	int32_t ___final_16;
	// System.Boolean System.Xml.Schema.XmlSchemaType::isMixed
	bool ___isMixed_17;
	// System.String System.Xml.Schema.XmlSchemaType::name
	String_t* ___name_18;
	// System.Boolean System.Xml.Schema.XmlSchemaType::recursed
	bool ___recursed_19;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaType::BaseSchemaTypeName
	XmlQualifiedName_t1944712516 * ___BaseSchemaTypeName_20;
	// System.Xml.Schema.XmlSchemaType System.Xml.Schema.XmlSchemaType::BaseXmlSchemaTypeInternal
	XmlSchemaType_t1795078578 * ___BaseXmlSchemaTypeInternal_21;
	// System.Xml.Schema.XmlSchemaDatatype System.Xml.Schema.XmlSchemaType::DatatypeInternal
	XmlSchemaDatatype_t1195946242 * ___DatatypeInternal_22;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaType::resolvedDerivedBy
	int32_t ___resolvedDerivedBy_23;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaType::finalResolved
	int32_t ___finalResolved_24;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaType::QNameInternal
	XmlQualifiedName_t1944712516 * ___QNameInternal_25;

public:
	inline static int32_t get_offset_of_final_16() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___final_16)); }
	inline int32_t get_final_16() const { return ___final_16; }
	inline int32_t* get_address_of_final_16() { return &___final_16; }
	inline void set_final_16(int32_t value)
	{
		___final_16 = value;
	}

	inline static int32_t get_offset_of_isMixed_17() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___isMixed_17)); }
	inline bool get_isMixed_17() const { return ___isMixed_17; }
	inline bool* get_address_of_isMixed_17() { return &___isMixed_17; }
	inline void set_isMixed_17(bool value)
	{
		___isMixed_17 = value;
	}

	inline static int32_t get_offset_of_name_18() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___name_18)); }
	inline String_t* get_name_18() const { return ___name_18; }
	inline String_t** get_address_of_name_18() { return &___name_18; }
	inline void set_name_18(String_t* value)
	{
		___name_18 = value;
		Il2CppCodeGenWriteBarrier(&___name_18, value);
	}

	inline static int32_t get_offset_of_recursed_19() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___recursed_19)); }
	inline bool get_recursed_19() const { return ___recursed_19; }
	inline bool* get_address_of_recursed_19() { return &___recursed_19; }
	inline void set_recursed_19(bool value)
	{
		___recursed_19 = value;
	}

	inline static int32_t get_offset_of_BaseSchemaTypeName_20() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___BaseSchemaTypeName_20)); }
	inline XmlQualifiedName_t1944712516 * get_BaseSchemaTypeName_20() const { return ___BaseSchemaTypeName_20; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_BaseSchemaTypeName_20() { return &___BaseSchemaTypeName_20; }
	inline void set_BaseSchemaTypeName_20(XmlQualifiedName_t1944712516 * value)
	{
		___BaseSchemaTypeName_20 = value;
		Il2CppCodeGenWriteBarrier(&___BaseSchemaTypeName_20, value);
	}

	inline static int32_t get_offset_of_BaseXmlSchemaTypeInternal_21() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___BaseXmlSchemaTypeInternal_21)); }
	inline XmlSchemaType_t1795078578 * get_BaseXmlSchemaTypeInternal_21() const { return ___BaseXmlSchemaTypeInternal_21; }
	inline XmlSchemaType_t1795078578 ** get_address_of_BaseXmlSchemaTypeInternal_21() { return &___BaseXmlSchemaTypeInternal_21; }
	inline void set_BaseXmlSchemaTypeInternal_21(XmlSchemaType_t1795078578 * value)
	{
		___BaseXmlSchemaTypeInternal_21 = value;
		Il2CppCodeGenWriteBarrier(&___BaseXmlSchemaTypeInternal_21, value);
	}

	inline static int32_t get_offset_of_DatatypeInternal_22() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___DatatypeInternal_22)); }
	inline XmlSchemaDatatype_t1195946242 * get_DatatypeInternal_22() const { return ___DatatypeInternal_22; }
	inline XmlSchemaDatatype_t1195946242 ** get_address_of_DatatypeInternal_22() { return &___DatatypeInternal_22; }
	inline void set_DatatypeInternal_22(XmlSchemaDatatype_t1195946242 * value)
	{
		___DatatypeInternal_22 = value;
		Il2CppCodeGenWriteBarrier(&___DatatypeInternal_22, value);
	}

	inline static int32_t get_offset_of_resolvedDerivedBy_23() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___resolvedDerivedBy_23)); }
	inline int32_t get_resolvedDerivedBy_23() const { return ___resolvedDerivedBy_23; }
	inline int32_t* get_address_of_resolvedDerivedBy_23() { return &___resolvedDerivedBy_23; }
	inline void set_resolvedDerivedBy_23(int32_t value)
	{
		___resolvedDerivedBy_23 = value;
	}

	inline static int32_t get_offset_of_finalResolved_24() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___finalResolved_24)); }
	inline int32_t get_finalResolved_24() const { return ___finalResolved_24; }
	inline int32_t* get_address_of_finalResolved_24() { return &___finalResolved_24; }
	inline void set_finalResolved_24(int32_t value)
	{
		___finalResolved_24 = value;
	}

	inline static int32_t get_offset_of_QNameInternal_25() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578, ___QNameInternal_25)); }
	inline XmlQualifiedName_t1944712516 * get_QNameInternal_25() const { return ___QNameInternal_25; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_QNameInternal_25() { return &___QNameInternal_25; }
	inline void set_QNameInternal_25(XmlQualifiedName_t1944712516 * value)
	{
		___QNameInternal_25 = value;
		Il2CppCodeGenWriteBarrier(&___QNameInternal_25, value);
	}
};

struct XmlSchemaType_t1795078578_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.Schema.XmlSchemaType::<>f__switch$map42
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map42_26;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.Schema.XmlSchemaType::<>f__switch$map43
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map43_27;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map42_26() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578_StaticFields, ___U3CU3Ef__switchU24map42_26)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map42_26() const { return ___U3CU3Ef__switchU24map42_26; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map42_26() { return &___U3CU3Ef__switchU24map42_26; }
	inline void set_U3CU3Ef__switchU24map42_26(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map42_26 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map42_26, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map43_27() { return static_cast<int32_t>(offsetof(XmlSchemaType_t1795078578_StaticFields, ___U3CU3Ef__switchU24map43_27)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map43_27() const { return ___U3CU3Ef__switchU24map43_27; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map43_27() { return &___U3CU3Ef__switchU24map43_27; }
	inline void set_U3CU3Ef__switchU24map43_27(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map43_27 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map43_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
