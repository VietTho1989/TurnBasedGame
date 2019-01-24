#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlNode616554813.h"

// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.String
struct String_t;
// System.Xml.XmlImplementation
struct XmlImplementation_t1664517635;
// System.Xml.XmlResolver
struct XmlResolver_t2024571559;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Xml.XmlNameEntryCache
struct XmlNameEntryCache_t3855584002;
// System.Xml.XmlLinkedNode
struct XmlLinkedNode_t1287616130;
// System.Xml.Schema.XmlSchemaSet
struct XmlSchemaSet_t313318308;
// System.Xml.Schema.IXmlSchemaInfo
struct IXmlSchemaInfo_t2533799901;
// System.Xml.XmlNodeChangedEventHandler
struct XmlNodeChangedEventHandler_t2964483403;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlDocument
struct  XmlDocument_t3649534162  : public XmlNode_t616554813
{
public:
	// System.Boolean System.Xml.XmlDocument::optimal_create_element
	bool ___optimal_create_element_6;
	// System.Boolean System.Xml.XmlDocument::optimal_create_attribute
	bool ___optimal_create_attribute_7;
	// System.Xml.XmlNameTable System.Xml.XmlDocument::nameTable
	XmlNameTable_t1345805268 * ___nameTable_8;
	// System.String System.Xml.XmlDocument::baseURI
	String_t* ___baseURI_9;
	// System.Xml.XmlImplementation System.Xml.XmlDocument::implementation
	XmlImplementation_t1664517635 * ___implementation_10;
	// System.Boolean System.Xml.XmlDocument::preserveWhitespace
	bool ___preserveWhitespace_11;
	// System.Xml.XmlResolver System.Xml.XmlDocument::resolver
	XmlResolver_t2024571559 * ___resolver_12;
	// System.Collections.Hashtable System.Xml.XmlDocument::idTable
	Hashtable_t909839986 * ___idTable_13;
	// System.Xml.XmlNameEntryCache System.Xml.XmlDocument::nameCache
	XmlNameEntryCache_t3855584002 * ___nameCache_14;
	// System.Xml.XmlLinkedNode System.Xml.XmlDocument::lastLinkedChild
	XmlLinkedNode_t1287616130 * ___lastLinkedChild_15;
	// System.Xml.Schema.XmlSchemaSet System.Xml.XmlDocument::schemas
	XmlSchemaSet_t313318308 * ___schemas_16;
	// System.Xml.Schema.IXmlSchemaInfo System.Xml.XmlDocument::schemaInfo
	Il2CppObject * ___schemaInfo_17;
	// System.Boolean System.Xml.XmlDocument::loadMode
	bool ___loadMode_18;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeChanged
	XmlNodeChangedEventHandler_t2964483403 * ___NodeChanged_19;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeChanging
	XmlNodeChangedEventHandler_t2964483403 * ___NodeChanging_20;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeInserted
	XmlNodeChangedEventHandler_t2964483403 * ___NodeInserted_21;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeInserting
	XmlNodeChangedEventHandler_t2964483403 * ___NodeInserting_22;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeRemoved
	XmlNodeChangedEventHandler_t2964483403 * ___NodeRemoved_23;
	// System.Xml.XmlNodeChangedEventHandler System.Xml.XmlDocument::NodeRemoving
	XmlNodeChangedEventHandler_t2964483403 * ___NodeRemoving_24;

public:
	inline static int32_t get_offset_of_optimal_create_element_6() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___optimal_create_element_6)); }
	inline bool get_optimal_create_element_6() const { return ___optimal_create_element_6; }
	inline bool* get_address_of_optimal_create_element_6() { return &___optimal_create_element_6; }
	inline void set_optimal_create_element_6(bool value)
	{
		___optimal_create_element_6 = value;
	}

	inline static int32_t get_offset_of_optimal_create_attribute_7() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___optimal_create_attribute_7)); }
	inline bool get_optimal_create_attribute_7() const { return ___optimal_create_attribute_7; }
	inline bool* get_address_of_optimal_create_attribute_7() { return &___optimal_create_attribute_7; }
	inline void set_optimal_create_attribute_7(bool value)
	{
		___optimal_create_attribute_7 = value;
	}

	inline static int32_t get_offset_of_nameTable_8() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___nameTable_8)); }
	inline XmlNameTable_t1345805268 * get_nameTable_8() const { return ___nameTable_8; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_8() { return &___nameTable_8; }
	inline void set_nameTable_8(XmlNameTable_t1345805268 * value)
	{
		___nameTable_8 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_8, value);
	}

	inline static int32_t get_offset_of_baseURI_9() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___baseURI_9)); }
	inline String_t* get_baseURI_9() const { return ___baseURI_9; }
	inline String_t** get_address_of_baseURI_9() { return &___baseURI_9; }
	inline void set_baseURI_9(String_t* value)
	{
		___baseURI_9 = value;
		Il2CppCodeGenWriteBarrier(&___baseURI_9, value);
	}

	inline static int32_t get_offset_of_implementation_10() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___implementation_10)); }
	inline XmlImplementation_t1664517635 * get_implementation_10() const { return ___implementation_10; }
	inline XmlImplementation_t1664517635 ** get_address_of_implementation_10() { return &___implementation_10; }
	inline void set_implementation_10(XmlImplementation_t1664517635 * value)
	{
		___implementation_10 = value;
		Il2CppCodeGenWriteBarrier(&___implementation_10, value);
	}

	inline static int32_t get_offset_of_preserveWhitespace_11() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___preserveWhitespace_11)); }
	inline bool get_preserveWhitespace_11() const { return ___preserveWhitespace_11; }
	inline bool* get_address_of_preserveWhitespace_11() { return &___preserveWhitespace_11; }
	inline void set_preserveWhitespace_11(bool value)
	{
		___preserveWhitespace_11 = value;
	}

	inline static int32_t get_offset_of_resolver_12() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___resolver_12)); }
	inline XmlResolver_t2024571559 * get_resolver_12() const { return ___resolver_12; }
	inline XmlResolver_t2024571559 ** get_address_of_resolver_12() { return &___resolver_12; }
	inline void set_resolver_12(XmlResolver_t2024571559 * value)
	{
		___resolver_12 = value;
		Il2CppCodeGenWriteBarrier(&___resolver_12, value);
	}

	inline static int32_t get_offset_of_idTable_13() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___idTable_13)); }
	inline Hashtable_t909839986 * get_idTable_13() const { return ___idTable_13; }
	inline Hashtable_t909839986 ** get_address_of_idTable_13() { return &___idTable_13; }
	inline void set_idTable_13(Hashtable_t909839986 * value)
	{
		___idTable_13 = value;
		Il2CppCodeGenWriteBarrier(&___idTable_13, value);
	}

	inline static int32_t get_offset_of_nameCache_14() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___nameCache_14)); }
	inline XmlNameEntryCache_t3855584002 * get_nameCache_14() const { return ___nameCache_14; }
	inline XmlNameEntryCache_t3855584002 ** get_address_of_nameCache_14() { return &___nameCache_14; }
	inline void set_nameCache_14(XmlNameEntryCache_t3855584002 * value)
	{
		___nameCache_14 = value;
		Il2CppCodeGenWriteBarrier(&___nameCache_14, value);
	}

	inline static int32_t get_offset_of_lastLinkedChild_15() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___lastLinkedChild_15)); }
	inline XmlLinkedNode_t1287616130 * get_lastLinkedChild_15() const { return ___lastLinkedChild_15; }
	inline XmlLinkedNode_t1287616130 ** get_address_of_lastLinkedChild_15() { return &___lastLinkedChild_15; }
	inline void set_lastLinkedChild_15(XmlLinkedNode_t1287616130 * value)
	{
		___lastLinkedChild_15 = value;
		Il2CppCodeGenWriteBarrier(&___lastLinkedChild_15, value);
	}

	inline static int32_t get_offset_of_schemas_16() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___schemas_16)); }
	inline XmlSchemaSet_t313318308 * get_schemas_16() const { return ___schemas_16; }
	inline XmlSchemaSet_t313318308 ** get_address_of_schemas_16() { return &___schemas_16; }
	inline void set_schemas_16(XmlSchemaSet_t313318308 * value)
	{
		___schemas_16 = value;
		Il2CppCodeGenWriteBarrier(&___schemas_16, value);
	}

	inline static int32_t get_offset_of_schemaInfo_17() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___schemaInfo_17)); }
	inline Il2CppObject * get_schemaInfo_17() const { return ___schemaInfo_17; }
	inline Il2CppObject ** get_address_of_schemaInfo_17() { return &___schemaInfo_17; }
	inline void set_schemaInfo_17(Il2CppObject * value)
	{
		___schemaInfo_17 = value;
		Il2CppCodeGenWriteBarrier(&___schemaInfo_17, value);
	}

	inline static int32_t get_offset_of_loadMode_18() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___loadMode_18)); }
	inline bool get_loadMode_18() const { return ___loadMode_18; }
	inline bool* get_address_of_loadMode_18() { return &___loadMode_18; }
	inline void set_loadMode_18(bool value)
	{
		___loadMode_18 = value;
	}

	inline static int32_t get_offset_of_NodeChanged_19() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeChanged_19)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeChanged_19() const { return ___NodeChanged_19; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeChanged_19() { return &___NodeChanged_19; }
	inline void set_NodeChanged_19(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeChanged_19 = value;
		Il2CppCodeGenWriteBarrier(&___NodeChanged_19, value);
	}

	inline static int32_t get_offset_of_NodeChanging_20() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeChanging_20)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeChanging_20() const { return ___NodeChanging_20; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeChanging_20() { return &___NodeChanging_20; }
	inline void set_NodeChanging_20(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeChanging_20 = value;
		Il2CppCodeGenWriteBarrier(&___NodeChanging_20, value);
	}

	inline static int32_t get_offset_of_NodeInserted_21() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeInserted_21)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeInserted_21() const { return ___NodeInserted_21; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeInserted_21() { return &___NodeInserted_21; }
	inline void set_NodeInserted_21(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeInserted_21 = value;
		Il2CppCodeGenWriteBarrier(&___NodeInserted_21, value);
	}

	inline static int32_t get_offset_of_NodeInserting_22() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeInserting_22)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeInserting_22() const { return ___NodeInserting_22; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeInserting_22() { return &___NodeInserting_22; }
	inline void set_NodeInserting_22(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeInserting_22 = value;
		Il2CppCodeGenWriteBarrier(&___NodeInserting_22, value);
	}

	inline static int32_t get_offset_of_NodeRemoved_23() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeRemoved_23)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeRemoved_23() const { return ___NodeRemoved_23; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeRemoved_23() { return &___NodeRemoved_23; }
	inline void set_NodeRemoved_23(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeRemoved_23 = value;
		Il2CppCodeGenWriteBarrier(&___NodeRemoved_23, value);
	}

	inline static int32_t get_offset_of_NodeRemoving_24() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162, ___NodeRemoving_24)); }
	inline XmlNodeChangedEventHandler_t2964483403 * get_NodeRemoving_24() const { return ___NodeRemoving_24; }
	inline XmlNodeChangedEventHandler_t2964483403 ** get_address_of_NodeRemoving_24() { return &___NodeRemoving_24; }
	inline void set_NodeRemoving_24(XmlNodeChangedEventHandler_t2964483403 * value)
	{
		___NodeRemoving_24 = value;
		Il2CppCodeGenWriteBarrier(&___NodeRemoving_24, value);
	}
};

struct XmlDocument_t3649534162_StaticFields
{
public:
	// System.Type[] System.Xml.XmlDocument::optimal_create_types
	TypeU5BU5D_t1664964607* ___optimal_create_types_5;

public:
	inline static int32_t get_offset_of_optimal_create_types_5() { return static_cast<int32_t>(offsetof(XmlDocument_t3649534162_StaticFields, ___optimal_create_types_5)); }
	inline TypeU5BU5D_t1664964607* get_optimal_create_types_5() const { return ___optimal_create_types_5; }
	inline TypeU5BU5D_t1664964607** get_address_of_optimal_create_types_5() { return &___optimal_create_types_5; }
	inline void set_optimal_create_types_5(TypeU5BU5D_t1664964607* value)
	{
		___optimal_create_types_5 = value;
		Il2CppCodeGenWriteBarrier(&___optimal_create_types_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
