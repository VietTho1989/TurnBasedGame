#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml_Schema_XsdValidationState3545965403.h"

// System.Xml.Schema.XmlSchemaElement
struct XmlSchemaElement_t2433337156;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdElementValidationState
struct  XsdElementValidationState_t152111323  : public XsdValidationState_t3545965403
{
public:
	// System.Xml.Schema.XmlSchemaElement Mono.Xml.Schema.XsdElementValidationState::element
	XmlSchemaElement_t2433337156 * ___element_3;

public:
	inline static int32_t get_offset_of_element_3() { return static_cast<int32_t>(offsetof(XsdElementValidationState_t152111323, ___element_3)); }
	inline XmlSchemaElement_t2433337156 * get_element_3() const { return ___element_3; }
	inline XmlSchemaElement_t2433337156 ** get_address_of_element_3() { return &___element_3; }
	inline void set_element_3(XmlSchemaElement_t2433337156 * value)
	{
		___element_3 = value;
		Il2CppCodeGenWriteBarrier(&___element_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
