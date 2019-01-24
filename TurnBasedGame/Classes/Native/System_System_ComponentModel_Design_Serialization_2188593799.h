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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.Design.Serialization.DesignerSerializerAttribute
struct  DesignerSerializerAttribute_t2188593799  : public Attribute_t542643598
{
public:
	// System.String System.ComponentModel.Design.Serialization.DesignerSerializerAttribute::serializerTypeName
	String_t* ___serializerTypeName_0;
	// System.String System.ComponentModel.Design.Serialization.DesignerSerializerAttribute::baseSerializerTypeName
	String_t* ___baseSerializerTypeName_1;

public:
	inline static int32_t get_offset_of_serializerTypeName_0() { return static_cast<int32_t>(offsetof(DesignerSerializerAttribute_t2188593799, ___serializerTypeName_0)); }
	inline String_t* get_serializerTypeName_0() const { return ___serializerTypeName_0; }
	inline String_t** get_address_of_serializerTypeName_0() { return &___serializerTypeName_0; }
	inline void set_serializerTypeName_0(String_t* value)
	{
		___serializerTypeName_0 = value;
		Il2CppCodeGenWriteBarrier(&___serializerTypeName_0, value);
	}

	inline static int32_t get_offset_of_baseSerializerTypeName_1() { return static_cast<int32_t>(offsetof(DesignerSerializerAttribute_t2188593799, ___baseSerializerTypeName_1)); }
	inline String_t* get_baseSerializerTypeName_1() const { return ___baseSerializerTypeName_1; }
	inline String_t** get_address_of_baseSerializerTypeName_1() { return &___baseSerializerTypeName_1; }
	inline void set_baseSerializerTypeName_1(String_t* value)
	{
		___baseSerializerTypeName_1 = value;
		Il2CppCodeGenWriteBarrier(&___baseSerializerTypeName_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
