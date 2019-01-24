#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaGroupBase3811767860.h"

// System.Xml.Schema.XmlSchemaObjectCollection
struct XmlSchemaObjectCollection_t395083109;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaSequence
struct  XmlSchemaSequence_t728414063  : public XmlSchemaGroupBase_t3811767860
{
public:
	// System.Xml.Schema.XmlSchemaObjectCollection System.Xml.Schema.XmlSchemaSequence::items
	XmlSchemaObjectCollection_t395083109 * ___items_28;

public:
	inline static int32_t get_offset_of_items_28() { return static_cast<int32_t>(offsetof(XmlSchemaSequence_t728414063, ___items_28)); }
	inline XmlSchemaObjectCollection_t395083109 * get_items_28() const { return ___items_28; }
	inline XmlSchemaObjectCollection_t395083109 ** get_address_of_items_28() { return &___items_28; }
	inline void set_items_28(XmlSchemaObjectCollection_t395083109 * value)
	{
		___items_28 = value;
		Il2CppCodeGenWriteBarrier(&___items_28, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
