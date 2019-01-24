#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"
#include "System_Configuration_System_Configuration_Configur3219689025.h"

// System.String
struct String_t;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationPropertyAttribute
struct  ConfigurationPropertyAttribute_t3655647199  : public Attribute_t542643598
{
public:
	// System.String System.Configuration.ConfigurationPropertyAttribute::name
	String_t* ___name_0;
	// System.Object System.Configuration.ConfigurationPropertyAttribute::default_value
	Il2CppObject * ___default_value_1;
	// System.Configuration.ConfigurationPropertyOptions System.Configuration.ConfigurationPropertyAttribute::flags
	int32_t ___flags_2;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(ConfigurationPropertyAttribute_t3655647199, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_default_value_1() { return static_cast<int32_t>(offsetof(ConfigurationPropertyAttribute_t3655647199, ___default_value_1)); }
	inline Il2CppObject * get_default_value_1() const { return ___default_value_1; }
	inline Il2CppObject ** get_address_of_default_value_1() { return &___default_value_1; }
	inline void set_default_value_1(Il2CppObject * value)
	{
		___default_value_1 = value;
		Il2CppCodeGenWriteBarrier(&___default_value_1, value);
	}

	inline static int32_t get_offset_of_flags_2() { return static_cast<int32_t>(offsetof(ConfigurationPropertyAttribute_t3655647199, ___flags_2)); }
	inline int32_t get_flags_2() const { return ___flags_2; }
	inline int32_t* get_address_of_flags_2() { return &___flags_2; }
	inline void set_flags_2(int32_t value)
	{
		___flags_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
