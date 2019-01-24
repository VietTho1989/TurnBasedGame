#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaAnnotated2082486936.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaFacet_Facet3019654938.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaFacet
struct  XmlSchemaFacet_t614309579  : public XmlSchemaAnnotated_t2082486936
{
public:
	// System.Boolean System.Xml.Schema.XmlSchemaFacet::isFixed
	bool ___isFixed_17;
	// System.String System.Xml.Schema.XmlSchemaFacet::val
	String_t* ___val_18;

public:
	inline static int32_t get_offset_of_isFixed_17() { return static_cast<int32_t>(offsetof(XmlSchemaFacet_t614309579, ___isFixed_17)); }
	inline bool get_isFixed_17() const { return ___isFixed_17; }
	inline bool* get_address_of_isFixed_17() { return &___isFixed_17; }
	inline void set_isFixed_17(bool value)
	{
		___isFixed_17 = value;
	}

	inline static int32_t get_offset_of_val_18() { return static_cast<int32_t>(offsetof(XmlSchemaFacet_t614309579, ___val_18)); }
	inline String_t* get_val_18() const { return ___val_18; }
	inline String_t** get_address_of_val_18() { return &___val_18; }
	inline void set_val_18(String_t* value)
	{
		___val_18 = value;
		Il2CppCodeGenWriteBarrier(&___val_18, value);
	}
};

struct XmlSchemaFacet_t614309579_StaticFields
{
public:
	// System.Xml.Schema.XmlSchemaFacet/Facet System.Xml.Schema.XmlSchemaFacet::AllFacets
	int32_t ___AllFacets_16;

public:
	inline static int32_t get_offset_of_AllFacets_16() { return static_cast<int32_t>(offsetof(XmlSchemaFacet_t614309579_StaticFields, ___AllFacets_16)); }
	inline int32_t get_AllFacets_16() const { return ___AllFacets_16; }
	inline int32_t* get_address_of_AllFacets_16() { return &___AllFacets_16; }
	inline void set_AllFacets_16(int32_t value)
	{
		___AllFacets_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
