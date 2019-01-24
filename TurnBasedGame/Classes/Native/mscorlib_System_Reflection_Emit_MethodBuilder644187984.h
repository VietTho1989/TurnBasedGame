#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Reflection_MethodInfo3330546337.h"
#include "mscorlib_System_Reflection_MethodAttributes790385034.h"
#include "mscorlib_System_Reflection_MethodImplAttributes1541361196.h"
#include "mscorlib_System_Reflection_CallingConventions1097349142.h"

// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Reflection.Emit.ILGenerator
struct ILGenerator_t99948092;
// System.Reflection.Emit.TypeBuilder
struct TypeBuilder_t3308873219;
// System.Reflection.Emit.ParameterBuilder[]
struct ParameterBuilderU5BU5D_t2122994367;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Reflection.Emit.GenericTypeParameterBuilder[]
struct GenericTypeParameterBuilderU5BU5D_t358971386;
// System.Type[][]
struct TypeU5BU5DU5BU5D_t2318378278;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.MethodBuilder
struct  MethodBuilder_t644187984  : public MethodInfo_t
{
public:
	// System.Type System.Reflection.Emit.MethodBuilder::rtype
	Type_t * ___rtype_0;
	// System.Type[] System.Reflection.Emit.MethodBuilder::parameters
	TypeU5BU5D_t1664964607* ___parameters_1;
	// System.Reflection.MethodAttributes System.Reflection.Emit.MethodBuilder::attrs
	int32_t ___attrs_2;
	// System.Reflection.MethodImplAttributes System.Reflection.Emit.MethodBuilder::iattrs
	int32_t ___iattrs_3;
	// System.String System.Reflection.Emit.MethodBuilder::name
	String_t* ___name_4;
	// System.Int32 System.Reflection.Emit.MethodBuilder::table_idx
	int32_t ___table_idx_5;
	// System.Byte[] System.Reflection.Emit.MethodBuilder::code
	ByteU5BU5D_t3397334013* ___code_6;
	// System.Reflection.Emit.ILGenerator System.Reflection.Emit.MethodBuilder::ilgen
	ILGenerator_t99948092 * ___ilgen_7;
	// System.Reflection.Emit.TypeBuilder System.Reflection.Emit.MethodBuilder::type
	TypeBuilder_t3308873219 * ___type_8;
	// System.Reflection.Emit.ParameterBuilder[] System.Reflection.Emit.MethodBuilder::pinfo
	ParameterBuilderU5BU5D_t2122994367* ___pinfo_9;
	// System.Reflection.MethodInfo System.Reflection.Emit.MethodBuilder::override_method
	MethodInfo_t * ___override_method_10;
	// System.Reflection.CallingConventions System.Reflection.Emit.MethodBuilder::call_conv
	int32_t ___call_conv_11;
	// System.Boolean System.Reflection.Emit.MethodBuilder::init_locals
	bool ___init_locals_12;
	// System.Reflection.Emit.GenericTypeParameterBuilder[] System.Reflection.Emit.MethodBuilder::generic_params
	GenericTypeParameterBuilderU5BU5D_t358971386* ___generic_params_13;
	// System.Type[] System.Reflection.Emit.MethodBuilder::returnModReq
	TypeU5BU5D_t1664964607* ___returnModReq_14;
	// System.Type[] System.Reflection.Emit.MethodBuilder::returnModOpt
	TypeU5BU5D_t1664964607* ___returnModOpt_15;
	// System.Type[][] System.Reflection.Emit.MethodBuilder::paramModReq
	TypeU5BU5DU5BU5D_t2318378278* ___paramModReq_16;
	// System.Type[][] System.Reflection.Emit.MethodBuilder::paramModOpt
	TypeU5BU5DU5BU5D_t2318378278* ___paramModOpt_17;

public:
	inline static int32_t get_offset_of_rtype_0() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___rtype_0)); }
	inline Type_t * get_rtype_0() const { return ___rtype_0; }
	inline Type_t ** get_address_of_rtype_0() { return &___rtype_0; }
	inline void set_rtype_0(Type_t * value)
	{
		___rtype_0 = value;
		Il2CppCodeGenWriteBarrier(&___rtype_0, value);
	}

	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___parameters_1)); }
	inline TypeU5BU5D_t1664964607* get_parameters_1() const { return ___parameters_1; }
	inline TypeU5BU5D_t1664964607** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(TypeU5BU5D_t1664964607* value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}

	inline static int32_t get_offset_of_attrs_2() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___attrs_2)); }
	inline int32_t get_attrs_2() const { return ___attrs_2; }
	inline int32_t* get_address_of_attrs_2() { return &___attrs_2; }
	inline void set_attrs_2(int32_t value)
	{
		___attrs_2 = value;
	}

	inline static int32_t get_offset_of_iattrs_3() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___iattrs_3)); }
	inline int32_t get_iattrs_3() const { return ___iattrs_3; }
	inline int32_t* get_address_of_iattrs_3() { return &___iattrs_3; }
	inline void set_iattrs_3(int32_t value)
	{
		___iattrs_3 = value;
	}

	inline static int32_t get_offset_of_name_4() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___name_4)); }
	inline String_t* get_name_4() const { return ___name_4; }
	inline String_t** get_address_of_name_4() { return &___name_4; }
	inline void set_name_4(String_t* value)
	{
		___name_4 = value;
		Il2CppCodeGenWriteBarrier(&___name_4, value);
	}

	inline static int32_t get_offset_of_table_idx_5() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___table_idx_5)); }
	inline int32_t get_table_idx_5() const { return ___table_idx_5; }
	inline int32_t* get_address_of_table_idx_5() { return &___table_idx_5; }
	inline void set_table_idx_5(int32_t value)
	{
		___table_idx_5 = value;
	}

	inline static int32_t get_offset_of_code_6() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___code_6)); }
	inline ByteU5BU5D_t3397334013* get_code_6() const { return ___code_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_code_6() { return &___code_6; }
	inline void set_code_6(ByteU5BU5D_t3397334013* value)
	{
		___code_6 = value;
		Il2CppCodeGenWriteBarrier(&___code_6, value);
	}

	inline static int32_t get_offset_of_ilgen_7() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___ilgen_7)); }
	inline ILGenerator_t99948092 * get_ilgen_7() const { return ___ilgen_7; }
	inline ILGenerator_t99948092 ** get_address_of_ilgen_7() { return &___ilgen_7; }
	inline void set_ilgen_7(ILGenerator_t99948092 * value)
	{
		___ilgen_7 = value;
		Il2CppCodeGenWriteBarrier(&___ilgen_7, value);
	}

	inline static int32_t get_offset_of_type_8() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___type_8)); }
	inline TypeBuilder_t3308873219 * get_type_8() const { return ___type_8; }
	inline TypeBuilder_t3308873219 ** get_address_of_type_8() { return &___type_8; }
	inline void set_type_8(TypeBuilder_t3308873219 * value)
	{
		___type_8 = value;
		Il2CppCodeGenWriteBarrier(&___type_8, value);
	}

	inline static int32_t get_offset_of_pinfo_9() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___pinfo_9)); }
	inline ParameterBuilderU5BU5D_t2122994367* get_pinfo_9() const { return ___pinfo_9; }
	inline ParameterBuilderU5BU5D_t2122994367** get_address_of_pinfo_9() { return &___pinfo_9; }
	inline void set_pinfo_9(ParameterBuilderU5BU5D_t2122994367* value)
	{
		___pinfo_9 = value;
		Il2CppCodeGenWriteBarrier(&___pinfo_9, value);
	}

	inline static int32_t get_offset_of_override_method_10() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___override_method_10)); }
	inline MethodInfo_t * get_override_method_10() const { return ___override_method_10; }
	inline MethodInfo_t ** get_address_of_override_method_10() { return &___override_method_10; }
	inline void set_override_method_10(MethodInfo_t * value)
	{
		___override_method_10 = value;
		Il2CppCodeGenWriteBarrier(&___override_method_10, value);
	}

	inline static int32_t get_offset_of_call_conv_11() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___call_conv_11)); }
	inline int32_t get_call_conv_11() const { return ___call_conv_11; }
	inline int32_t* get_address_of_call_conv_11() { return &___call_conv_11; }
	inline void set_call_conv_11(int32_t value)
	{
		___call_conv_11 = value;
	}

	inline static int32_t get_offset_of_init_locals_12() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___init_locals_12)); }
	inline bool get_init_locals_12() const { return ___init_locals_12; }
	inline bool* get_address_of_init_locals_12() { return &___init_locals_12; }
	inline void set_init_locals_12(bool value)
	{
		___init_locals_12 = value;
	}

	inline static int32_t get_offset_of_generic_params_13() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___generic_params_13)); }
	inline GenericTypeParameterBuilderU5BU5D_t358971386* get_generic_params_13() const { return ___generic_params_13; }
	inline GenericTypeParameterBuilderU5BU5D_t358971386** get_address_of_generic_params_13() { return &___generic_params_13; }
	inline void set_generic_params_13(GenericTypeParameterBuilderU5BU5D_t358971386* value)
	{
		___generic_params_13 = value;
		Il2CppCodeGenWriteBarrier(&___generic_params_13, value);
	}

	inline static int32_t get_offset_of_returnModReq_14() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___returnModReq_14)); }
	inline TypeU5BU5D_t1664964607* get_returnModReq_14() const { return ___returnModReq_14; }
	inline TypeU5BU5D_t1664964607** get_address_of_returnModReq_14() { return &___returnModReq_14; }
	inline void set_returnModReq_14(TypeU5BU5D_t1664964607* value)
	{
		___returnModReq_14 = value;
		Il2CppCodeGenWriteBarrier(&___returnModReq_14, value);
	}

	inline static int32_t get_offset_of_returnModOpt_15() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___returnModOpt_15)); }
	inline TypeU5BU5D_t1664964607* get_returnModOpt_15() const { return ___returnModOpt_15; }
	inline TypeU5BU5D_t1664964607** get_address_of_returnModOpt_15() { return &___returnModOpt_15; }
	inline void set_returnModOpt_15(TypeU5BU5D_t1664964607* value)
	{
		___returnModOpt_15 = value;
		Il2CppCodeGenWriteBarrier(&___returnModOpt_15, value);
	}

	inline static int32_t get_offset_of_paramModReq_16() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___paramModReq_16)); }
	inline TypeU5BU5DU5BU5D_t2318378278* get_paramModReq_16() const { return ___paramModReq_16; }
	inline TypeU5BU5DU5BU5D_t2318378278** get_address_of_paramModReq_16() { return &___paramModReq_16; }
	inline void set_paramModReq_16(TypeU5BU5DU5BU5D_t2318378278* value)
	{
		___paramModReq_16 = value;
		Il2CppCodeGenWriteBarrier(&___paramModReq_16, value);
	}

	inline static int32_t get_offset_of_paramModOpt_17() { return static_cast<int32_t>(offsetof(MethodBuilder_t644187984, ___paramModOpt_17)); }
	inline TypeU5BU5DU5BU5D_t2318378278* get_paramModOpt_17() const { return ___paramModOpt_17; }
	inline TypeU5BU5DU5BU5D_t2318378278** get_address_of_paramModOpt_17() { return &___paramModOpt_17; }
	inline void set_paramModOpt_17(TypeU5BU5DU5BU5D_t2318378278* value)
	{
		___paramModOpt_17 = value;
		Il2CppCodeGenWriteBarrier(&___paramModOpt_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
