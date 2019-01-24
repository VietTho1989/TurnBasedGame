#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaParticle3365045970.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaDerivationMe3165007540.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaForm1143227640.h"

// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.String
struct String_t;
// System.Object
struct Il2CppObject;
// System.Xml.Schema.XmlSchemaType
struct XmlSchemaType_t1795078578;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.Xml.Schema.XmlSchema
struct XmlSchema_t880472818;
// System.Xml.Schema.XmlSchemaElement
struct XmlSchemaElement_t2433337156;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaElement
struct  XmlSchemaElement_t2433337156  : public XmlSchemaParticle_t3365045970
{
public:
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaElement::block
	int32_t ___block_27;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaElement::constraints
	XmlSchemaObjectCollection_t395083109 * ___constraints_28;
	// System.String System.Xml.Schema.XmlSchemaElement::defaultValue
	String_t* ___defaultValue_29;
	// System.Object System.Xml.Schema.XmlSchemaElement::elementType
	Il2CppObject * ___elementType_30;
	// System.Xml.Schema.XmlSchemaType System.Xml.Schema.XmlSchemaElement::elementSchemaType
	XmlSchemaType_t1795078578 * ___elementSchemaType_31;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaElement::final
	int32_t ___final_32;
	// System.String System.Xml.Schema.XmlSchemaElement::fixedValue
	String_t* ___fixedValue_33;
	// System.Xml.Schema.XmlSchemaForm System.Xml.Schema.XmlSchemaElement::form
	int32_t ___form_34;
	// System.Boolean System.Xml.Schema.XmlSchemaElement::isAbstract
	bool ___isAbstract_35;
	// System.Boolean System.Xml.Schema.XmlSchemaElement::isNillable
	bool ___isNillable_36;
	// System.String System.Xml.Schema.XmlSchemaElement::name
	String_t* ___name_37;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaElement::refName
	XmlQualifiedName_t1944712516 * ___refName_38;
	// System.Xml.Schema.XmlSchemaType System.Xml.Schema.XmlSchemaElement::schemaType
	XmlSchemaType_t1795078578 * ___schemaType_39;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaElement::schemaTypeName
	XmlQualifiedName_t1944712516 * ___schemaTypeName_40;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaElement::substitutionGroup
	XmlQualifiedName_t1944712516 * ___substitutionGroup_41;
	// System.Xml.Schema.XmlSchema System.Xml.Schema.XmlSchemaElement::schema
	XmlSchema_t880472818 * ___schema_42;
	// System.Boolean System.Xml.Schema.XmlSchemaElement::parentIsSchema
	bool ___parentIsSchema_43;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaElement::qName
	XmlQualifiedName_t1944712516 * ___qName_44;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaElement::blockResolved
	int32_t ___blockResolved_45;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaElement::finalResolved
	int32_t ___finalResolved_46;
	// System.Xml.Schema.XmlSchemaElement System.Xml.Schema.XmlSchemaElement::referencedElement
	XmlSchemaElement_t2433337156 * ___referencedElement_47;
	// System.Collections.ArrayList System.Xml.Schema.XmlSchemaElement::substitutingElements
	ArrayList_t4252133567 * ___substitutingElements_48;
	// System.Xml.Schema.XmlSchemaElement System.Xml.Schema.XmlSchemaElement::substitutionGroupElement
	XmlSchemaElement_t2433337156 * ___substitutionGroupElement_49;
	// System.Boolean System.Xml.Schema.XmlSchemaElement::actualIsAbstract
	bool ___actualIsAbstract_50;
	// System.Boolean System.Xml.Schema.XmlSchemaElement::actualIsNillable
	bool ___actualIsNillable_51;
	// System.String System.Xml.Schema.XmlSchemaElement::validatedDefaultValue
	String_t* ___validatedDefaultValue_52;
	// System.String System.Xml.Schema.XmlSchemaElement::validatedFixedValue
	String_t* ___validatedFixedValue_53;

public:
	inline static int32_t get_offset_of_block_27() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___block_27)); }
	inline int32_t get_block_27() const { return ___block_27; }
	inline int32_t* get_address_of_block_27() { return &___block_27; }
	inline void set_block_27(int32_t value)
	{
		___block_27 = value;
	}

	inline static int32_t get_offset_of_constraints_28() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___constraints_28)); }
	inline XmlSchemaObjectCollection_t395083109 * get_constraints_28() const { return ___constraints_28; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_constraints_28() { return &___constraints_28; }
	inline void set_constraints_28(XmlSchemaObjectCollection_t395083109 * value)
	{
		___constraints_28 = value;
		Il2CppCodeGenWriteBarrier(&___constraints_28, value);
	}

	inline static int32_t get_offset_of_defaultValue_29() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___defaultValue_29)); }
	inline String_t* get_defaultValue_29() const { return ___defaultValue_29; }
	inline String_t** get_address_of_defaultValue_29() { return &___defaultValue_29; }
	inline void set_defaultValue_29(String_t* value)
	{
		___defaultValue_29 = value;
		Il2CppCodeGenWriteBarrier(&___defaultValue_29, value);
	}

	inline static int32_t get_offset_of_elementType_30() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___elementType_30)); }
	inline Il2CppObject * get_elementType_30() const { return ___elementType_30; }
	inline Il2CppObject ** get_address_of_elementType_30() { return &___elementType_30; }
	inline void set_elementType_30(Il2CppObject * value)
	{
		___elementType_30 = value;
		Il2CppCodeGenWriteBarrier(&___elementType_30, value);
	}

	inline static int32_t get_offset_of_elementSchemaType_31() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___elementSchemaType_31)); }
	inline XmlSchemaType_t1795078578 * get_elementSchemaType_31() const { return ___elementSchemaType_31; }
	inline XmlSchemaType_t1795078578 ** get_address_of_elementSchemaType_31() { return &___elementSchemaType_31; }
	inline void set_elementSchemaType_31(XmlSchemaType_t1795078578 * value)
	{
		___elementSchemaType_31 = value;
		Il2CppCodeGenWriteBarrier(&___elementSchemaType_31, value);
	}

	inline static int32_t get_offset_of_final_32() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___final_32)); }
	inline int32_t get_final_32() const { return ___final_32; }
	inline int32_t* get_address_of_final_32() { return &___final_32; }
	inline void set_final_32(int32_t value)
	{
		___final_32 = value;
	}

	inline static int32_t get_offset_of_fixedValue_33() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___fixedValue_33)); }
	inline String_t* get_fixedValue_33() const { return ___fixedValue_33; }
	inline String_t** get_address_of_fixedValue_33() { return &___fixedValue_33; }
	inline void set_fixedValue_33(String_t* value)
	{
		___fixedValue_33 = value;
		Il2CppCodeGenWriteBarrier(&___fixedValue_33, value);
	}

	inline static int32_t get_offset_of_form_34() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___form_34)); }
	inline int32_t get_form_34() const { return ___form_34; }
	inline int32_t* get_address_of_form_34() { return &___form_34; }
	inline void set_form_34(int32_t value)
	{
		___form_34 = value;
	}

	inline static int32_t get_offset_of_isAbstract_35() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___isAbstract_35)); }
	inline bool get_isAbstract_35() const { return ___isAbstract_35; }
	inline bool* get_address_of_isAbstract_35() { return &___isAbstract_35; }
	inline void set_isAbstract_35(bool value)
	{
		___isAbstract_35 = value;
	}

	inline static int32_t get_offset_of_isNillable_36() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___isNillable_36)); }
	inline bool get_isNillable_36() const { return ___isNillable_36; }
	inline bool* get_address_of_isNillable_36() { return &___isNillable_36; }
	inline void set_isNillable_36(bool value)
	{
		___isNillable_36 = value;
	}

	inline static int32_t get_offset_of_name_37() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___name_37)); }
	inline String_t* get_name_37() const { return ___name_37; }
	inline String_t** get_address_of_name_37() { return &___name_37; }
	inline void set_name_37(String_t* value)
	{
		___name_37 = value;
		Il2CppCodeGenWriteBarrier(&___name_37, value);
	}

	inline static int32_t get_offset_of_refName_38() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___refName_38)); }
	inline XmlQualifiedName_t1944712516 * get_refName_38() const { return ___refName_38; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_refName_38() { return &___refName_38; }
	inline void set_refName_38(XmlQualifiedName_t1944712516 * value)
	{
		___refName_38 = value;
		Il2CppCodeGenWriteBarrier(&___refName_38, value);
	}

	inline static int32_t get_offset_of_schemaType_39() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___schemaType_39)); }
	inline XmlSchemaType_t1795078578 * get_schemaType_39() const { return ___schemaType_39; }
	inline XmlSchemaType_t1795078578 ** get_address_of_schemaType_39() { return &___schemaType_39; }
	inline void set_schemaType_39(XmlSchemaType_t1795078578 * value)
	{
		___schemaType_39 = value;
		Il2CppCodeGenWriteBarrier(&___schemaType_39, value);
	}

	inline static int32_t get_offset_of_schemaTypeName_40() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___schemaTypeName_40)); }
	inline XmlQualifiedName_t1944712516 * get_schemaTypeName_40() const { return ___schemaTypeName_40; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_schemaTypeName_40() { return &___schemaTypeName_40; }
	inline void set_schemaTypeName_40(XmlQualifiedName_t1944712516 * value)
	{
		___schemaTypeName_40 = value;
		Il2CppCodeGenWriteBarrier(&___schemaTypeName_40, value);
	}

	inline static int32_t get_offset_of_substitutionGroup_41() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___substitutionGroup_41)); }
	inline XmlQualifiedName_t1944712516 * get_substitutionGroup_41() const { return ___substitutionGroup_41; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_substitutionGroup_41() { return &___substitutionGroup_41; }
	inline void set_substitutionGroup_41(XmlQualifiedName_t1944712516 * value)
	{
		___substitutionGroup_41 = value;
		Il2CppCodeGenWriteBarrier(&___substitutionGroup_41, value);
	}

	inline static int32_t get_offset_of_schema_42() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___schema_42)); }
	inline XmlSchema_t880472818 * get_schema_42() const { return ___schema_42; }
	inline XmlSchema_t880472818 ** get_address_of_schema_42() { return &___schema_42; }
	inline void set_schema_42(XmlSchema_t880472818 * value)
	{
		___schema_42 = value;
		Il2CppCodeGenWriteBarrier(&___schema_42, value);
	}

	inline static int32_t get_offset_of_parentIsSchema_43() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___parentIsSchema_43)); }
	inline bool get_parentIsSchema_43() const { return ___parentIsSchema_43; }
	inline bool* get_address_of_parentIsSchema_43() { return &___parentIsSchema_43; }
	inline void set_parentIsSchema_43(bool value)
	{
		___parentIsSchema_43 = value;
	}

	inline static int32_t get_offset_of_qName_44() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___qName_44)); }
	inline XmlQualifiedName_t1944712516 * get_qName_44() const { return ___qName_44; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_qName_44() { return &___qName_44; }
	inline void set_qName_44(XmlQualifiedName_t1944712516 * value)
	{
		___qName_44 = value;
		Il2CppCodeGenWriteBarrier(&___qName_44, value);
	}

	inline static int32_t get_offset_of_blockResolved_45() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___blockResolved_45)); }
	inline int32_t get_blockResolved_45() const { return ___blockResolved_45; }
	inline int32_t* get_address_of_blockResolved_45() { return &___blockResolved_45; }
	inline void set_blockResolved_45(int32_t value)
	{
		___blockResolved_45 = value;
	}

	inline static int32_t get_offset_of_finalResolved_46() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___finalResolved_46)); }
	inline int32_t get_finalResolved_46() const { return ___finalResolved_46; }
	inline int32_t* get_address_of_finalResolved_46() { return &___finalResolved_46; }
	inline void set_finalResolved_46(int32_t value)
	{
		___finalResolved_46 = value;
	}

	inline static int32_t get_offset_of_referencedElement_47() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___referencedElement_47)); }
	inline XmlSchemaElement_t2433337156 * get_referencedElement_47() const { return ___referencedElement_47; }
	inline XmlSchemaElement_t2433337156 ** get_address_of_referencedElement_47() { return &___referencedElement_47; }
	inline void set_referencedElement_47(XmlSchemaElement_t2433337156 * value)
	{
		___referencedElement_47 = value;
		Il2CppCodeGenWriteBarrier(&___referencedElement_47, value);
	}

	inline static int32_t get_offset_of_substitutingElements_48() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___substitutingElements_48)); }
	inline ArrayList_t4252133567 * get_substitutingElements_48() const { return ___substitutingElements_48; }
	inline ArrayList_t4252133567 ** get_address_of_substitutingElements_48() { return &___substitutingElements_48; }
	inline void set_substitutingElements_48(ArrayList_t4252133567 * value)
	{
		___substitutingElements_48 = value;
		Il2CppCodeGenWriteBarrier(&___substitutingElements_48, value);
	}

	inline static int32_t get_offset_of_substitutionGroupElement_49() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___substitutionGroupElement_49)); }
	inline XmlSchemaElement_t2433337156 * get_substitutionGroupElement_49() const { return ___substitutionGroupElement_49; }
	inline XmlSchemaElement_t2433337156 ** get_address_of_substitutionGroupElement_49() { return &___substitutionGroupElement_49; }
	inline void set_substitutionGroupElement_49(XmlSchemaElement_t2433337156 * value)
	{
		___substitutionGroupElement_49 = value;
		Il2CppCodeGenWriteBarrier(&___substitutionGroupElement_49, value);
	}

	inline static int32_t get_offset_of_actualIsAbstract_50() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___actualIsAbstract_50)); }
	inline bool get_actualIsAbstract_50() const { return ___actualIsAbstract_50; }
	inline bool* get_address_of_actualIsAbstract_50() { return &___actualIsAbstract_50; }
	inline void set_actualIsAbstract_50(bool value)
	{
		___actualIsAbstract_50 = value;
	}

	inline static int32_t get_offset_of_actualIsNillable_51() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___actualIsNillable_51)); }
	inline bool get_actualIsNillable_51() const { return ___actualIsNillable_51; }
	inline bool* get_address_of_actualIsNillable_51() { return &___actualIsNillable_51; }
	inline void set_actualIsNillable_51(bool value)
	{
		___actualIsNillable_51 = value;
	}

	inline static int32_t get_offset_of_validatedDefaultValue_52() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___validatedDefaultValue_52)); }
	inline String_t* get_validatedDefaultValue_52() const { return ___validatedDefaultValue_52; }
	inline String_t** get_address_of_validatedDefaultValue_52() { return &___validatedDefaultValue_52; }
	inline void set_validatedDefaultValue_52(String_t* value)
	{
		___validatedDefaultValue_52 = value;
		Il2CppCodeGenWriteBarrier(&___validatedDefaultValue_52, value);
	}

	inline static int32_t get_offset_of_validatedFixedValue_53() { return static_cast<int32_t>(offsetof(XmlSchemaElement_t2433337156, ___validatedFixedValue_53)); }
	inline String_t* get_validatedFixedValue_53() const { return ___validatedFixedValue_53; }
	inline String_t** get_address_of_validatedFixedValue_53() { return &___validatedFixedValue_53; }
	inline void set_validatedFixedValue_53(String_t* value)
	{
		___validatedFixedValue_53 = value;
		Il2CppCodeGenWriteBarrier(&___validatedFixedValue_53, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
