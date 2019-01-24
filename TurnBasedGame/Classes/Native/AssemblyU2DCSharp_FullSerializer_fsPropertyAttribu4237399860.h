#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"

// System.String
struct String_t;
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsPropertyAttribute
struct  fsPropertyAttribute_t4237399860  : public Attribute_t542643598
{
public:
	// System.String FullSerializer.fsPropertyAttribute::Name
	String_t* ___Name_0;
	// System.Type FullSerializer.fsPropertyAttribute::Converter
	Type_t * ___Converter_1;

public:
	inline static int32_t get_offset_of_Name_0() { return static_cast<int32_t>(offsetof(fsPropertyAttribute_t4237399860, ___Name_0)); }
	inline String_t* get_Name_0() const { return ___Name_0; }
	inline String_t** get_address_of_Name_0() { return &___Name_0; }
	inline void set_Name_0(String_t* value)
	{
		___Name_0 = value;
		Il2CppCodeGenWriteBarrier(&___Name_0, value);
	}

	inline static int32_t get_offset_of_Converter_1() { return static_cast<int32_t>(offsetof(fsPropertyAttribute_t4237399860, ___Converter_1)); }
	inline Type_t * get_Converter_1() const { return ___Converter_1; }
	inline Type_t ** get_address_of_Converter_1() { return &___Converter_1; }
	inline void set_Converter_1(Type_t * value)
	{
		___Converter_1 = value;
		Il2CppCodeGenWriteBarrier(&___Converter_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
