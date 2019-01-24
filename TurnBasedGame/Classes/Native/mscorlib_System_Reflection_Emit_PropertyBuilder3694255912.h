#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Reflection_PropertyInfo2253729065.h"
#include "mscorlib_System_Reflection_PropertyAttributes883448530.h"

// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Reflection.Emit.MethodBuilder
struct MethodBuilder_t644187984;
// System.Reflection.Emit.TypeBuilder
struct TypeBuilder_t3308873219;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.PropertyBuilder
struct  PropertyBuilder_t3694255912  : public PropertyInfo_t
{
public:
	// System.Reflection.PropertyAttributes System.Reflection.Emit.PropertyBuilder::attrs
	int32_t ___attrs_0;
	// System.String System.Reflection.Emit.PropertyBuilder::name
	String_t* ___name_1;
	// System.Type System.Reflection.Emit.PropertyBuilder::type
	Type_t * ___type_2;
	// System.Reflection.Emit.MethodBuilder System.Reflection.Emit.PropertyBuilder::set_method
	MethodBuilder_t644187984 * ___set_method_3;
	// System.Reflection.Emit.MethodBuilder System.Reflection.Emit.PropertyBuilder::get_method
	MethodBuilder_t644187984 * ___get_method_4;
	// System.Reflection.Emit.TypeBuilder System.Reflection.Emit.PropertyBuilder::typeb
	TypeBuilder_t3308873219 * ___typeb_5;

public:
	inline static int32_t get_offset_of_attrs_0() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___attrs_0)); }
	inline int32_t get_attrs_0() const { return ___attrs_0; }
	inline int32_t* get_address_of_attrs_0() { return &___attrs_0; }
	inline void set_attrs_0(int32_t value)
	{
		___attrs_0 = value;
	}

	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier(&___name_1, value);
	}

	inline static int32_t get_offset_of_type_2() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___type_2)); }
	inline Type_t * get_type_2() const { return ___type_2; }
	inline Type_t ** get_address_of_type_2() { return &___type_2; }
	inline void set_type_2(Type_t * value)
	{
		___type_2 = value;
		Il2CppCodeGenWriteBarrier(&___type_2, value);
	}

	inline static int32_t get_offset_of_set_method_3() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___set_method_3)); }
	inline MethodBuilder_t644187984 * get_set_method_3() const { return ___set_method_3; }
	inline MethodBuilder_t644187984 ** get_address_of_set_method_3() { return &___set_method_3; }
	inline void set_set_method_3(MethodBuilder_t644187984 * value)
	{
		___set_method_3 = value;
		Il2CppCodeGenWriteBarrier(&___set_method_3, value);
	}

	inline static int32_t get_offset_of_get_method_4() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___get_method_4)); }
	inline MethodBuilder_t644187984 * get_get_method_4() const { return ___get_method_4; }
	inline MethodBuilder_t644187984 ** get_address_of_get_method_4() { return &___get_method_4; }
	inline void set_get_method_4(MethodBuilder_t644187984 * value)
	{
		___get_method_4 = value;
		Il2CppCodeGenWriteBarrier(&___get_method_4, value);
	}

	inline static int32_t get_offset_of_typeb_5() { return static_cast<int32_t>(offsetof(PropertyBuilder_t3694255912, ___typeb_5)); }
	inline TypeBuilder_t3308873219 * get_typeb_5() const { return ___typeb_5; }
	inline TypeBuilder_t3308873219 ** get_address_of_typeb_5() { return &___typeb_5; }
	inline void set_typeb_5(TypeBuilder_t3308873219 * value)
	{
		___typeb_5 = value;
		Il2CppCodeGenWriteBarrier(&___typeb_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
