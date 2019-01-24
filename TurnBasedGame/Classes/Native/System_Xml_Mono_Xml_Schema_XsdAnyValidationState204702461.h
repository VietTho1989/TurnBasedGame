#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_Mono_Xml_Schema_XsdValidationState3545965403.h"

// System.Xml.Schema.XmlSchemaAny
struct XmlSchemaAny_t3277730824;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdAnyValidationState
struct  XsdAnyValidationState_t204702461  : public XsdValidationState_t3545965403
{
public:
	// System.Xml.Schema.XmlSchemaAny Mono.Xml.Schema.XsdAnyValidationState::any
	XmlSchemaAny_t3277730824 * ___any_3;

public:
	inline static int32_t get_offset_of_any_3() { return static_cast<int32_t>(offsetof(XsdAnyValidationState_t204702461, ___any_3)); }
	inline XmlSchemaAny_t3277730824 * get_any_3() const { return ___any_3; }
	inline XmlSchemaAny_t3277730824 ** get_address_of_any_3() { return &___any_3; }
	inline void set_any_3(XmlSchemaAny_t3277730824 * value)
	{
		___any_3 = value;
		Il2CppCodeGenWriteBarrier(&___any_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
