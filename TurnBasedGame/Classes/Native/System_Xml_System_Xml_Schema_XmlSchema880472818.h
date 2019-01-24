#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaObject2050913741.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaForm1143227640.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaDerivationMe3165007540.h"

// System.Xml.Schema.XmlSchemaObjectTable
struct XmlSchemaObjectTable_t3364835593;
// System.String
struct String_t;
// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.Xml.Schema.XmlSchemaSet
struct XmlSchemaSet_t313318308;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchema
struct  XmlSchema_t880472818  : public XmlSchemaObject_t2050913741
{
public:
	// System.Xml.Schema.XmlSchemaForm System.Xml.Schema.XmlSchema::attributeFormDefault
	int32_t ___attributeFormDefault_13;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::attributeGroups
	XmlSchemaObjectTable_t3364835593 * ___attributeGroups_14;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::attributes
	XmlSchemaObjectTable_t3364835593 * ___attributes_15;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchema::blockDefault
	int32_t ___blockDefault_16;
	// System.Xml.Schema.XmlSchemaForm System.Xml.Schema.XmlSchema::elementFormDefault
	int32_t ___elementFormDefault_17;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::elements
	XmlSchemaObjectTable_t3364835593 * ___elements_18;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchema::finalDefault
	int32_t ___finalDefault_19;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::groups
	XmlSchemaObjectTable_t3364835593 * ___groups_20;
	// System.String System.Xml.Schema.XmlSchema::id
	String_t* ___id_21;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchema::includes
	XmlSchemaObjectCollection_t395083109 * ___includes_22;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchema::items
	XmlSchemaObjectCollection_t395083109 * ___items_23;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::notations
	XmlSchemaObjectTable_t3364835593 * ___notations_24;
	// System.Xml.Schema.XmlSchemaObjectTable System.Xml.Schema.XmlSchema::schemaTypes
	XmlSchemaObjectTable_t3364835593 * ___schemaTypes_25;
	// System.String System.Xml.Schema.XmlSchema::targetNamespace
	String_t* ___targetNamespace_26;
	// System.String System.Xml.Schema.XmlSchema::version
	String_t* ___version_27;
	// System.Xml.Schema.XmlSchemaSet System.Xml.Schema.XmlSchema::schemas
	XmlSchemaSet_t313318308 * ___schemas_28;
	// System.Xml.XmlNameTable System.Xml.Schema.XmlSchema::nameTable
	XmlNameTable_t1345805268 * ___nameTable_29;
	// System.Boolean System.Xml.Schema.XmlSchema::missedSubComponents
	bool ___missedSubComponents_30;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchema::compilationItems
	XmlSchemaObjectCollection_t395083109 * ___compilationItems_31;

public:
	inline static int32_t get_offset_of_attributeFormDefault_13() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___attributeFormDefault_13)); }
	inline int32_t get_attributeFormDefault_13() const { return ___attributeFormDefault_13; }
	inline int32_t* get_address_of_attributeFormDefault_13() { return &___attributeFormDefault_13; }
	inline void set_attributeFormDefault_13(int32_t value)
	{
		___attributeFormDefault_13 = value;
	}

	inline static int32_t get_offset_of_attributeGroups_14() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___attributeGroups_14)); }
	inline XmlSchemaObjectTable_t3364835593 * get_attributeGroups_14() const { return ___attributeGroups_14; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_attributeGroups_14() { return &___attributeGroups_14; }
	inline void set_attributeGroups_14(XmlSchemaObjectTable_t3364835593 * value)
	{
		___attributeGroups_14 = value;
		Il2CppCodeGenWriteBarrier(&___attributeGroups_14, value);
	}

	inline static int32_t get_offset_of_attributes_15() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___attributes_15)); }
	inline XmlSchemaObjectTable_t3364835593 * get_attributes_15() const { return ___attributes_15; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_attributes_15() { return &___attributes_15; }
	inline void set_attributes_15(XmlSchemaObjectTable_t3364835593 * value)
	{
		___attributes_15 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_15, value);
	}

	inline static int32_t get_offset_of_blockDefault_16() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___blockDefault_16)); }
	inline int32_t get_blockDefault_16() const { return ___blockDefault_16; }
	inline int32_t* get_address_of_blockDefault_16() { return &___blockDefault_16; }
	inline void set_blockDefault_16(int32_t value)
	{
		___blockDefault_16 = value;
	}

	inline static int32_t get_offset_of_elementFormDefault_17() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___elementFormDefault_17)); }
	inline int32_t get_elementFormDefault_17() const { return ___elementFormDefault_17; }
	inline int32_t* get_address_of_elementFormDefault_17() { return &___elementFormDefault_17; }
	inline void set_elementFormDefault_17(int32_t value)
	{
		___elementFormDefault_17 = value;
	}

	inline static int32_t get_offset_of_elements_18() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___elements_18)); }
	inline XmlSchemaObjectTable_t3364835593 * get_elements_18() const { return ___elements_18; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_elements_18() { return &___elements_18; }
	inline void set_elements_18(XmlSchemaObjectTable_t3364835593 * value)
	{
		___elements_18 = value;
		Il2CppCodeGenWriteBarrier(&___elements_18, value);
	}

	inline static int32_t get_offset_of_finalDefault_19() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___finalDefault_19)); }
	inline int32_t get_finalDefault_19() const { return ___finalDefault_19; }
	inline int32_t* get_address_of_finalDefault_19() { return &___finalDefault_19; }
	inline void set_finalDefault_19(int32_t value)
	{
		___finalDefault_19 = value;
	}

	inline static int32_t get_offset_of_groups_20() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___groups_20)); }
	inline XmlSchemaObjectTable_t3364835593 * get_groups_20() const { return ___groups_20; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_groups_20() { return &___groups_20; }
	inline void set_groups_20(XmlSchemaObjectTable_t3364835593 * value)
	{
		___groups_20 = value;
		Il2CppCodeGenWriteBarrier(&___groups_20, value);
	}

	inline static int32_t get_offset_of_id_21() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___id_21)); }
	inline String_t* get_id_21() const { return ___id_21; }
	inline String_t** get_address_of_id_21() { return &___id_21; }
	inline void set_id_21(String_t* value)
	{
		___id_21 = value;
		Il2CppCodeGenWriteBarrier(&___id_21, value);
	}

	inline static int32_t get_offset_of_includes_22() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___includes_22)); }
	inline XmlSchemaObjectCollection_t395083109 * get_includes_22() const { return ___includes_22; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_includes_22() { return &___includes_22; }
	inline void set_includes_22(XmlSchemaObjectCollection_t395083109 * value)
	{
		___includes_22 = value;
		Il2CppCodeGenWriteBarrier(&___includes_22, value);
	}

	inline static int32_t get_offset_of_items_23() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___items_23)); }
	inline XmlSchemaObjectCollection_t395083109 * get_items_23() const { return ___items_23; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_items_23() { return &___items_23; }
	inline void set_items_23(XmlSchemaObjectCollection_t395083109 * value)
	{
		___items_23 = value;
		Il2CppCodeGenWriteBarrier(&___items_23, value);
	}

	inline static int32_t get_offset_of_notations_24() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___notations_24)); }
	inline XmlSchemaObjectTable_t3364835593 * get_notations_24() const { return ___notations_24; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_notations_24() { return &___notations_24; }
	inline void set_notations_24(XmlSchemaObjectTable_t3364835593 * value)
	{
		___notations_24 = value;
		Il2CppCodeGenWriteBarrier(&___notations_24, value);
	}

	inline static int32_t get_offset_of_schemaTypes_25() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___schemaTypes_25)); }
	inline XmlSchemaObjectTable_t3364835593 * get_schemaTypes_25() const { return ___schemaTypes_25; }
	inline XmlSchemaObjectTable_t3364835593 ** get_address_of_schemaTypes_25() { return &___schemaTypes_25; }
	inline void set_schemaTypes_25(XmlSchemaObjectTable_t3364835593 * value)
	{
		___schemaTypes_25 = value;
		Il2CppCodeGenWriteBarrier(&___schemaTypes_25, value);
	}

	inline static int32_t get_offset_of_targetNamespace_26() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___targetNamespace_26)); }
	inline String_t* get_targetNamespace_26() const { return ___targetNamespace_26; }
	inline String_t** get_address_of_targetNamespace_26() { return &___targetNamespace_26; }
	inline void set_targetNamespace_26(String_t* value)
	{
		___targetNamespace_26 = value;
		Il2CppCodeGenWriteBarrier(&___targetNamespace_26, value);
	}

	inline static int32_t get_offset_of_version_27() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___version_27)); }
	inline String_t* get_version_27() const { return ___version_27; }
	inline String_t** get_address_of_version_27() { return &___version_27; }
	inline void set_version_27(String_t* value)
	{
		___version_27 = value;
		Il2CppCodeGenWriteBarrier(&___version_27, value);
	}

	inline static int32_t get_offset_of_schemas_28() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___schemas_28)); }
	inline XmlSchemaSet_t313318308 * get_schemas_28() const { return ___schemas_28; }
	inline XmlSchemaSet_t313318308 ** get_address_of_schemas_28() { return &___schemas_28; }
	inline void set_schemas_28(XmlSchemaSet_t313318308 * value)
	{
		___schemas_28 = value;
		Il2CppCodeGenWriteBarrier(&___schemas_28, value);
	}

	inline static int32_t get_offset_of_nameTable_29() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___nameTable_29)); }
	inline XmlNameTable_t1345805268 * get_nameTable_29() const { return ___nameTable_29; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_29() { return &___nameTable_29; }
	inline void set_nameTable_29(XmlNameTable_t1345805268 * value)
	{
		___nameTable_29 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_29, value);
	}

	inline static int32_t get_offset_of_missedSubComponents_30() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___missedSubComponents_30)); }
	inline bool get_missedSubComponents_30() const { return ___missedSubComponents_30; }
	inline bool* get_address_of_missedSubComponents_30() { return &___missedSubComponents_30; }
	inline void set_missedSubComponents_30(bool value)
	{
		___missedSubComponents_30 = value;
	}

	inline static int32_t get_offset_of_compilationItems_31() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818, ___compilationItems_31)); }
	inline XmlSchemaObjectCollection_t395083109 * get_compilationItems_31() const { return ___compilationItems_31; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_compilationItems_31() { return &___compilationItems_31; }
	inline void set_compilationItems_31(XmlSchemaObjectCollection_t395083109 * value)
	{
		___compilationItems_31 = value;
		Il2CppCodeGenWriteBarrier(&___compilationItems_31, value);
	}
};

struct XmlSchema_t880472818_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.Schema.XmlSchema::<>f__switch$map41
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map41_32;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map41_32() { return static_cast<int32_t>(offsetof(XmlSchema_t880472818_StaticFields, ___U3CU3Ef__switchU24map41_32)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map41_32() const { return ___U3CU3Ef__switchU24map41_32; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map41_32() { return &___U3CU3Ef__switchU24map41_32; }
	inline void set_U3CU3Ef__switchU24map41_32(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map41_32 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map41_32, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
