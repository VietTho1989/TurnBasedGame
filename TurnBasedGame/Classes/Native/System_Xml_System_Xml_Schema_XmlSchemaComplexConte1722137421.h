#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaContent3733871217.h"

// System.Xml.Schema.XmlSchemaAnyAttribute
struct XmlSchemaAnyAttribute_t530453212;
// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;
// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.Xml.Schema.XmlSchemaParticle
struct XmlSchemaParticle_t3365045970;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaComplexContentRestriction
struct  XmlSchemaComplexContentRestriction_t1722137421  : public XmlSchemaContent_t3733871217
{
public:
	// System.Xml.Schema.XmlSchemaAnyAttribute System.Xml.Schema.XmlSchemaComplexContentRestriction::any
	XmlSchemaAnyAttribute_t530453212 * ___any_17;
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaComplexContentRestriction::attributes
	XmlSchemaObjectCollection_t395083109 * ___attributes_18;
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaComplexContentRestriction::baseTypeName
	XmlQualifiedName_t1944712516 * ___baseTypeName_19;
	// System.Xml.Schema.XmlSchemaParticle System.Xml.Schema.XmlSchemaComplexContentRestriction::particle
	XmlSchemaParticle_t3365045970 * ___particle_20;

public:
	inline static int32_t get_offset_of_any_17() { return static_cast<int32_t>(offsetof(XmlSchemaComplexContentRestriction_t1722137421, ___any_17)); }
	inline XmlSchemaAnyAttribute_t530453212 * get_any_17() const { return ___any_17; }
	inline XmlSchemaAnyAttribute_t530453212 ** get_address_of_any_17() { return &___any_17; }
	inline void set_any_17(XmlSchemaAnyAttribute_t530453212 * value)
	{
		___any_17 = value;
		Il2CppCodeGenWriteBarrier(&___any_17, value);
	}

	inline static int32_t get_offset_of_attributes_18() { return static_cast<int32_t>(offsetof(XmlSchemaComplexContentRestriction_t1722137421, ___attributes_18)); }
	inline XmlSchemaObjectCollection_t395083109 * get_attributes_18() const { return ___attributes_18; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_attributes_18() { return &___attributes_18; }
	inline void set_attributes_18(XmlSchemaObjectCollection_t395083109 * value)
	{
		___attributes_18 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_18, value);
	}

	inline static int32_t get_offset_of_baseTypeName_19() { return static_cast<int32_t>(offsetof(XmlSchemaComplexContentRestriction_t1722137421, ___baseTypeName_19)); }
	inline XmlQualifiedName_t1944712516 * get_baseTypeName_19() const { return ___baseTypeName_19; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_baseTypeName_19() { return &___baseTypeName_19; }
	inline void set_baseTypeName_19(XmlQualifiedName_t1944712516 * value)
	{
		___baseTypeName_19 = value;
		Il2CppCodeGenWriteBarrier(&___baseTypeName_19, value);
	}

	inline static int32_t get_offset_of_particle_20() { return static_cast<int32_t>(offsetof(XmlSchemaComplexContentRestriction_t1722137421, ___particle_20)); }
	inline XmlSchemaParticle_t3365045970 * get_particle_20() const { return ___particle_20; }
	inline XmlSchemaParticle_t3365045970 ** get_address_of_particle_20() { return &___particle_20; }
	inline void set_particle_20(XmlSchemaParticle_t3365045970 * value)
	{
		___particle_20 = value;
		Il2CppCodeGenWriteBarrier(&___particle_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
