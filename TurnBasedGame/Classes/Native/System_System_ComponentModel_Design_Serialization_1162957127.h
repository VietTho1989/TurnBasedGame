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

// System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute
struct  RootDesignerSerializerAttribute_t1162957127  : public Attribute_t542643598
{
public:
	// System.String System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute::serializer
	String_t* ___serializer_0;
	// System.String System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute::baseserializer
	String_t* ___baseserializer_1;
	// System.Boolean System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute::reload
	bool ___reload_2;

public:
	inline static int32_t get_offset_of_serializer_0() { return static_cast<int32_t>(offsetof(RootDesignerSerializerAttribute_t1162957127, ___serializer_0)); }
	inline String_t* get_serializer_0() const { return ___serializer_0; }
	inline String_t** get_address_of_serializer_0() { return &___serializer_0; }
	inline void set_serializer_0(String_t* value)
	{
		___serializer_0 = value;
		Il2CppCodeGenWriteBarrier(&___serializer_0, value);
	}

	inline static int32_t get_offset_of_baseserializer_1() { return static_cast<int32_t>(offsetof(RootDesignerSerializerAttribute_t1162957127, ___baseserializer_1)); }
	inline String_t* get_baseserializer_1() const { return ___baseserializer_1; }
	inline String_t** get_address_of_baseserializer_1() { return &___baseserializer_1; }
	inline void set_baseserializer_1(String_t* value)
	{
		___baseserializer_1 = value;
		Il2CppCodeGenWriteBarrier(&___baseserializer_1, value);
	}

	inline static int32_t get_offset_of_reload_2() { return static_cast<int32_t>(offsetof(RootDesignerSerializerAttribute_t1162957127, ___reload_2)); }
	inline bool get_reload_2() const { return ___reload_2; }
	inline bool* get_address_of_reload_2() { return &___reload_2; }
	inline void set_reload_2(bool value)
	{
		___reload_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
