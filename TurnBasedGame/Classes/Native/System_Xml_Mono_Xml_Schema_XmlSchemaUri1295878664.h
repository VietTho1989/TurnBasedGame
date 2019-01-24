#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Uri19570940.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XmlSchemaUri
struct  XmlSchemaUri_t1295878664  : public Uri_t19570940
{
public:
	// System.String Mono.Xml.Schema.XmlSchemaUri::value
	String_t* ___value_38;

public:
	inline static int32_t get_offset_of_value_38() { return static_cast<int32_t>(offsetof(XmlSchemaUri_t1295878664, ___value_38)); }
	inline String_t* get_value_38() const { return ___value_38; }
	inline String_t** get_address_of_value_38() { return &___value_38; }
	inline void set_value_38(String_t* value)
	{
		___value_38 = value;
		Il2CppCodeGenWriteBarrier(&___value_38, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
