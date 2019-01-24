#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Type1303803226.h"
#include "mscorlib_System_Reflection_TypeAttributes2229518203.h"
#include "mscorlib_System_Reflection_Emit_PackingSize4013171414.h"

// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Reflection.Emit.MethodBuilder[]
struct MethodBuilderU5BU5D_t4238041457;
// System.Reflection.Emit.ConstructorBuilder[]
struct ConstructorBuilderU5BU5D_t775814140;
// System.Reflection.Emit.PropertyBuilder[]
struct PropertyBuilderU5BU5D_t988886841;
// System.Reflection.Emit.FieldBuilder[]
struct FieldBuilderU5BU5D_t867683112;
// System.Reflection.Emit.TypeBuilder[]
struct TypeBuilderU5BU5D_t4254476946;
// System.Reflection.Emit.ModuleBuilder
struct ModuleBuilder_t4156028127;
// System.Reflection.Emit.GenericTypeParameterBuilder[]
struct GenericTypeParameterBuilderU5BU5D_t358971386;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.TypeBuilder
struct  TypeBuilder_t3308873219  : public Type_t
{
public:
	// System.String System.Reflection.Emit.TypeBuilder::tname
	String_t* ___tname_8;
	// System.String System.Reflection.Emit.TypeBuilder::nspace
	String_t* ___nspace_9;
	// System.Type System.Reflection.Emit.TypeBuilder::parent
	Type_t * ___parent_10;
	// System.Type System.Reflection.Emit.TypeBuilder::nesting_type
	Type_t * ___nesting_type_11;
	// System.Type[] System.Reflection.Emit.TypeBuilder::interfaces
	TypeU5BU5D_t1664964607* ___interfaces_12;
	// System.Int32 System.Reflection.Emit.TypeBuilder::num_methods
	int32_t ___num_methods_13;
	// System.Reflection.Emit.MethodBuilder[] System.Reflection.Emit.TypeBuilder::methods
	MethodBuilderU5BU5D_t4238041457* ___methods_14;
	// System.Reflection.Emit.ConstructorBuilder[] System.Reflection.Emit.TypeBuilder::ctors
	ConstructorBuilderU5BU5D_t775814140* ___ctors_15;
	// System.Reflection.Emit.PropertyBuilder[] System.Reflection.Emit.TypeBuilder::properties
	PropertyBuilderU5BU5D_t988886841* ___properties_16;
	// System.Reflection.Emit.FieldBuilder[] System.Reflection.Emit.TypeBuilder::fields
	FieldBuilderU5BU5D_t867683112* ___fields_17;
	// System.Reflection.Emit.TypeBuilder[] System.Reflection.Emit.TypeBuilder::subtypes
	TypeBuilderU5BU5D_t4254476946* ___subtypes_18;
	// System.Reflection.TypeAttributes System.Reflection.Emit.TypeBuilder::attrs
	int32_t ___attrs_19;
	// System.Int32 System.Reflection.Emit.TypeBuilder::table_idx
	int32_t ___table_idx_20;
	// System.Reflection.Emit.ModuleBuilder System.Reflection.Emit.TypeBuilder::pmodule
	ModuleBuilder_t4156028127 * ___pmodule_21;
	// System.Int32 System.Reflection.Emit.TypeBuilder::class_size
	int32_t ___class_size_22;
	// System.Reflection.Emit.PackingSize System.Reflection.Emit.TypeBuilder::packing_size
	int32_t ___packing_size_23;
	// System.Reflection.Emit.GenericTypeParameterBuilder[] System.Reflection.Emit.TypeBuilder::generic_params
	GenericTypeParameterBuilderU5BU5D_t358971386* ___generic_params_24;
	// System.Type System.Reflection.Emit.TypeBuilder::created
	Type_t * ___created_25;
	// System.String System.Reflection.Emit.TypeBuilder::fullname
	String_t* ___fullname_26;
	// System.Boolean System.Reflection.Emit.TypeBuilder::createTypeCalled
	bool ___createTypeCalled_27;
	// System.Type System.Reflection.Emit.TypeBuilder::underlying_type
	Type_t * ___underlying_type_28;

public:
	inline static int32_t get_offset_of_tname_8() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___tname_8)); }
	inline String_t* get_tname_8() const { return ___tname_8; }
	inline String_t** get_address_of_tname_8() { return &___tname_8; }
	inline void set_tname_8(String_t* value)
	{
		___tname_8 = value;
		Il2CppCodeGenWriteBarrier(&___tname_8, value);
	}

	inline static int32_t get_offset_of_nspace_9() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___nspace_9)); }
	inline String_t* get_nspace_9() const { return ___nspace_9; }
	inline String_t** get_address_of_nspace_9() { return &___nspace_9; }
	inline void set_nspace_9(String_t* value)
	{
		___nspace_9 = value;
		Il2CppCodeGenWriteBarrier(&___nspace_9, value);
	}

	inline static int32_t get_offset_of_parent_10() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___parent_10)); }
	inline Type_t * get_parent_10() const { return ___parent_10; }
	inline Type_t ** get_address_of_parent_10() { return &___parent_10; }
	inline void set_parent_10(Type_t * value)
	{
		___parent_10 = value;
		Il2CppCodeGenWriteBarrier(&___parent_10, value);
	}

	inline static int32_t get_offset_of_nesting_type_11() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___nesting_type_11)); }
	inline Type_t * get_nesting_type_11() const { return ___nesting_type_11; }
	inline Type_t ** get_address_of_nesting_type_11() { return &___nesting_type_11; }
	inline void set_nesting_type_11(Type_t * value)
	{
		___nesting_type_11 = value;
		Il2CppCodeGenWriteBarrier(&___nesting_type_11, value);
	}

	inline static int32_t get_offset_of_interfaces_12() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___interfaces_12)); }
	inline TypeU5BU5D_t1664964607* get_interfaces_12() const { return ___interfaces_12; }
	inline TypeU5BU5D_t1664964607** get_address_of_interfaces_12() { return &___interfaces_12; }
	inline void set_interfaces_12(TypeU5BU5D_t1664964607* value)
	{
		___interfaces_12 = value;
		Il2CppCodeGenWriteBarrier(&___interfaces_12, value);
	}

	inline static int32_t get_offset_of_num_methods_13() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___num_methods_13)); }
	inline int32_t get_num_methods_13() const { return ___num_methods_13; }
	inline int32_t* get_address_of_num_methods_13() { return &___num_methods_13; }
	inline void set_num_methods_13(int32_t value)
	{
		___num_methods_13 = value;
	}

	inline static int32_t get_offset_of_methods_14() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___methods_14)); }
	inline MethodBuilderU5BU5D_t4238041457* get_methods_14() const { return ___methods_14; }
	inline MethodBuilderU5BU5D_t4238041457** get_address_of_methods_14() { return &___methods_14; }
	inline void set_methods_14(MethodBuilderU5BU5D_t4238041457* value)
	{
		___methods_14 = value;
		Il2CppCodeGenWriteBarrier(&___methods_14, value);
	}

	inline static int32_t get_offset_of_ctors_15() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___ctors_15)); }
	inline ConstructorBuilderU5BU5D_t775814140* get_ctors_15() const { return ___ctors_15; }
	inline ConstructorBuilderU5BU5D_t775814140** get_address_of_ctors_15() { return &___ctors_15; }
	inline void set_ctors_15(ConstructorBuilderU5BU5D_t775814140* value)
	{
		___ctors_15 = value;
		Il2CppCodeGenWriteBarrier(&___ctors_15, value);
	}

	inline static int32_t get_offset_of_properties_16() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___properties_16)); }
	inline PropertyBuilderU5BU5D_t988886841* get_properties_16() const { return ___properties_16; }
	inline PropertyBuilderU5BU5D_t988886841** get_address_of_properties_16() { return &___properties_16; }
	inline void set_properties_16(PropertyBuilderU5BU5D_t988886841* value)
	{
		___properties_16 = value;
		Il2CppCodeGenWriteBarrier(&___properties_16, value);
	}

	inline static int32_t get_offset_of_fields_17() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___fields_17)); }
	inline FieldBuilderU5BU5D_t867683112* get_fields_17() const { return ___fields_17; }
	inline FieldBuilderU5BU5D_t867683112** get_address_of_fields_17() { return &___fields_17; }
	inline void set_fields_17(FieldBuilderU5BU5D_t867683112* value)
	{
		___fields_17 = value;
		Il2CppCodeGenWriteBarrier(&___fields_17, value);
	}

	inline static int32_t get_offset_of_subtypes_18() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___subtypes_18)); }
	inline TypeBuilderU5BU5D_t4254476946* get_subtypes_18() const { return ___subtypes_18; }
	inline TypeBuilderU5BU5D_t4254476946** get_address_of_subtypes_18() { return &___subtypes_18; }
	inline void set_subtypes_18(TypeBuilderU5BU5D_t4254476946* value)
	{
		___subtypes_18 = value;
		Il2CppCodeGenWriteBarrier(&___subtypes_18, value);
	}

	inline static int32_t get_offset_of_attrs_19() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___attrs_19)); }
	inline int32_t get_attrs_19() const { return ___attrs_19; }
	inline int32_t* get_address_of_attrs_19() { return &___attrs_19; }
	inline void set_attrs_19(int32_t value)
	{
		___attrs_19 = value;
	}

	inline static int32_t get_offset_of_table_idx_20() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___table_idx_20)); }
	inline int32_t get_table_idx_20() const { return ___table_idx_20; }
	inline int32_t* get_address_of_table_idx_20() { return &___table_idx_20; }
	inline void set_table_idx_20(int32_t value)
	{
		___table_idx_20 = value;
	}

	inline static int32_t get_offset_of_pmodule_21() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___pmodule_21)); }
	inline ModuleBuilder_t4156028127 * get_pmodule_21() const { return ___pmodule_21; }
	inline ModuleBuilder_t4156028127 ** get_address_of_pmodule_21() { return &___pmodule_21; }
	inline void set_pmodule_21(ModuleBuilder_t4156028127 * value)
	{
		___pmodule_21 = value;
		Il2CppCodeGenWriteBarrier(&___pmodule_21, value);
	}

	inline static int32_t get_offset_of_class_size_22() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___class_size_22)); }
	inline int32_t get_class_size_22() const { return ___class_size_22; }
	inline int32_t* get_address_of_class_size_22() { return &___class_size_22; }
	inline void set_class_size_22(int32_t value)
	{
		___class_size_22 = value;
	}

	inline static int32_t get_offset_of_packing_size_23() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___packing_size_23)); }
	inline int32_t get_packing_size_23() const { return ___packing_size_23; }
	inline int32_t* get_address_of_packing_size_23() { return &___packing_size_23; }
	inline void set_packing_size_23(int32_t value)
	{
		___packing_size_23 = value;
	}

	inline static int32_t get_offset_of_generic_params_24() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___generic_params_24)); }
	inline GenericTypeParameterBuilderU5BU5D_t358971386* get_generic_params_24() const { return ___generic_params_24; }
	inline GenericTypeParameterBuilderU5BU5D_t358971386** get_address_of_generic_params_24() { return &___generic_params_24; }
	inline void set_generic_params_24(GenericTypeParameterBuilderU5BU5D_t358971386* value)
	{
		___generic_params_24 = value;
		Il2CppCodeGenWriteBarrier(&___generic_params_24, value);
	}

	inline static int32_t get_offset_of_created_25() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___created_25)); }
	inline Type_t * get_created_25() const { return ___created_25; }
	inline Type_t ** get_address_of_created_25() { return &___created_25; }
	inline void set_created_25(Type_t * value)
	{
		___created_25 = value;
		Il2CppCodeGenWriteBarrier(&___created_25, value);
	}

	inline static int32_t get_offset_of_fullname_26() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___fullname_26)); }
	inline String_t* get_fullname_26() const { return ___fullname_26; }
	inline String_t** get_address_of_fullname_26() { return &___fullname_26; }
	inline void set_fullname_26(String_t* value)
	{
		___fullname_26 = value;
		Il2CppCodeGenWriteBarrier(&___fullname_26, value);
	}

	inline static int32_t get_offset_of_createTypeCalled_27() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___createTypeCalled_27)); }
	inline bool get_createTypeCalled_27() const { return ___createTypeCalled_27; }
	inline bool* get_address_of_createTypeCalled_27() { return &___createTypeCalled_27; }
	inline void set_createTypeCalled_27(bool value)
	{
		___createTypeCalled_27 = value;
	}

	inline static int32_t get_offset_of_underlying_type_28() { return static_cast<int32_t>(offsetof(TypeBuilder_t3308873219, ___underlying_type_28)); }
	inline Type_t * get_underlying_type_28() const { return ___underlying_type_28; }
	inline Type_t ** get_address_of_underlying_type_28() { return &___underlying_type_28; }
	inline void set_underlying_type_28(Type_t * value)
	{
		___underlying_type_28 = value;
		Il2CppCodeGenWriteBarrier(&___underlying_type_28, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
