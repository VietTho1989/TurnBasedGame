#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Configuration_System_Configuration_Configur3219689025.h"

// System.Object
struct Il2CppObject;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.ComponentModel.TypeConverter
struct TypeConverter_t745995970;
// System.Configuration.ConfigurationValidatorBase
struct ConfigurationValidatorBase_t210547623;
// System.Configuration.ConfigurationCollectionAttribute
struct ConfigurationCollectionAttribute_t2811353736;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationProperty
struct  ConfigurationProperty_t2048066811  : public Il2CppObject
{
public:
	// System.String System.Configuration.ConfigurationProperty::name
	String_t* ___name_1;
	// System.Type System.Configuration.ConfigurationProperty::type
	Type_t * ___type_2;
	// System.Object System.Configuration.ConfigurationProperty::default_value
	Il2CppObject * ___default_value_3;
	// System.ComponentModel.TypeConverter System.Configuration.ConfigurationProperty::converter
	TypeConverter_t745995970 * ___converter_4;
	// System.Configuration.ConfigurationValidatorBase System.Configuration.ConfigurationProperty::validation
	ConfigurationValidatorBase_t210547623 * ___validation_5;
	// System.Configuration.ConfigurationPropertyOptions System.Configuration.ConfigurationProperty::flags
	int32_t ___flags_6;
	// System.String System.Configuration.ConfigurationProperty::description
	String_t* ___description_7;
	// System.Configuration.ConfigurationCollectionAttribute System.Configuration.ConfigurationProperty::collectionAttribute
	ConfigurationCollectionAttribute_t2811353736 * ___collectionAttribute_8;

public:
	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier(&___name_1, value);
	}

	inline static int32_t get_offset_of_type_2() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___type_2)); }
	inline Type_t * get_type_2() const { return ___type_2; }
	inline Type_t ** get_address_of_type_2() { return &___type_2; }
	inline void set_type_2(Type_t * value)
	{
		___type_2 = value;
		Il2CppCodeGenWriteBarrier(&___type_2, value);
	}

	inline static int32_t get_offset_of_default_value_3() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___default_value_3)); }
	inline Il2CppObject * get_default_value_3() const { return ___default_value_3; }
	inline Il2CppObject ** get_address_of_default_value_3() { return &___default_value_3; }
	inline void set_default_value_3(Il2CppObject * value)
	{
		___default_value_3 = value;
		Il2CppCodeGenWriteBarrier(&___default_value_3, value);
	}

	inline static int32_t get_offset_of_converter_4() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___converter_4)); }
	inline TypeConverter_t745995970 * get_converter_4() const { return ___converter_4; }
	inline TypeConverter_t745995970 ** get_address_of_converter_4() { return &___converter_4; }
	inline void set_converter_4(TypeConverter_t745995970 * value)
	{
		___converter_4 = value;
		Il2CppCodeGenWriteBarrier(&___converter_4, value);
	}

	inline static int32_t get_offset_of_validation_5() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___validation_5)); }
	inline ConfigurationValidatorBase_t210547623 * get_validation_5() const { return ___validation_5; }
	inline ConfigurationValidatorBase_t210547623 ** get_address_of_validation_5() { return &___validation_5; }
	inline void set_validation_5(ConfigurationValidatorBase_t210547623 * value)
	{
		___validation_5 = value;
		Il2CppCodeGenWriteBarrier(&___validation_5, value);
	}

	inline static int32_t get_offset_of_flags_6() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___flags_6)); }
	inline int32_t get_flags_6() const { return ___flags_6; }
	inline int32_t* get_address_of_flags_6() { return &___flags_6; }
	inline void set_flags_6(int32_t value)
	{
		___flags_6 = value;
	}

	inline static int32_t get_offset_of_description_7() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___description_7)); }
	inline String_t* get_description_7() const { return ___description_7; }
	inline String_t** get_address_of_description_7() { return &___description_7; }
	inline void set_description_7(String_t* value)
	{
		___description_7 = value;
		Il2CppCodeGenWriteBarrier(&___description_7, value);
	}

	inline static int32_t get_offset_of_collectionAttribute_8() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811, ___collectionAttribute_8)); }
	inline ConfigurationCollectionAttribute_t2811353736 * get_collectionAttribute_8() const { return ___collectionAttribute_8; }
	inline ConfigurationCollectionAttribute_t2811353736 ** get_address_of_collectionAttribute_8() { return &___collectionAttribute_8; }
	inline void set_collectionAttribute_8(ConfigurationCollectionAttribute_t2811353736 * value)
	{
		___collectionAttribute_8 = value;
		Il2CppCodeGenWriteBarrier(&___collectionAttribute_8, value);
	}
};

struct ConfigurationProperty_t2048066811_StaticFields
{
public:
	// System.Object System.Configuration.ConfigurationProperty::NoDefaultValue
	Il2CppObject * ___NoDefaultValue_0;

public:
	inline static int32_t get_offset_of_NoDefaultValue_0() { return static_cast<int32_t>(offsetof(ConfigurationProperty_t2048066811_StaticFields, ___NoDefaultValue_0)); }
	inline Il2CppObject * get_NoDefaultValue_0() const { return ___NoDefaultValue_0; }
	inline Il2CppObject ** get_address_of_NoDefaultValue_0() { return &___NoDefaultValue_0; }
	inline void set_NoDefaultValue_0(Il2CppObject * value)
	{
		___NoDefaultValue_0 = value;
		Il2CppCodeGenWriteBarrier(&___NoDefaultValue_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
