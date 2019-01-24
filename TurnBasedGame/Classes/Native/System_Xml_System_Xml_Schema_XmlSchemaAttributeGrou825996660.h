#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"

// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaAttributeGroupRef
struct  XmlSchemaAttributeGroupRef_t825996660  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.Xml.XmlQualifiedName System.Xml.Schema.XmlSchemaAttributeGroupRef::refName
	XmlQualifiedName_t1944712516 * ___refName_16;

public:
	inline static int32_t get_offset_of_refName_16() { return static_cast<int32_t>(offsetof(XmlSchemaAttributeGroupRef_t825996660, ___refName_16)); }
	inline XmlQualifiedName_t1944712516 * get_refName_16() const { return ___refName_16; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_refName_16() { return &___refName_16; }
	inline void set_refName_16(XmlQualifiedName_t1944712516 * value)
	{
		___refName_16 = value;
		Il2CppCodeGenWriteBarrier(&___refName_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
