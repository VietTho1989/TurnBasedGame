#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Text_RegularExpressions_RxCompiler4215271879.h"

// System.Reflection.Emit.DynamicMethod[]
struct DynamicMethodU5BU5D_t3262100997;
// System.Boolean[]
struct BooleanU5BU5D_t3568034315;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Int32>
struct Dictionary_2_t1079703083;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Reflection.Emit.Label>
struct Dictionary_2_t3251028295;
// System.Reflection.FieldInfo
struct FieldInfo_t;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.Reflection.Emit.LocalBuilder
struct LocalBuilder_t2116499186;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.CILCompiler
struct  CILCompiler_t1740644799  : public RxCompiler_t4215271879
{
public:
	// System.Reflection.Emit.DynamicMethod[] System.Text.RegularExpressions.CILCompiler::eval_methods
	DynamicMethodU5BU5D_t3262100997* ___eval_methods_2;
	// System.Boolean[] System.Text.RegularExpressions.CILCompiler::eval_methods_defined
	BooleanU5BU5D_t3568034315* ___eval_methods_defined_3;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Int32> System.Text.RegularExpressions.CILCompiler::generic_ops
	Dictionary_2_t1079703083 * ___generic_ops_4;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Int32> System.Text.RegularExpressions.CILCompiler::op_flags
	Dictionary_2_t1079703083 * ___op_flags_5;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Reflection.Emit.Label> System.Text.RegularExpressions.CILCompiler::labels
	Dictionary_2_t3251028295 * ___labels_6;
	// System.Reflection.Emit.LocalBuilder System.Text.RegularExpressions.CILCompiler::local_textinfo
	LocalBuilder_t2116499186 * ___local_textinfo_33;

public:
	inline static int32_t get_offset_of_eval_methods_2() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___eval_methods_2)); }
	inline DynamicMethodU5BU5D_t3262100997* get_eval_methods_2() const { return ___eval_methods_2; }
	inline DynamicMethodU5BU5D_t3262100997** get_address_of_eval_methods_2() { return &___eval_methods_2; }
	inline void set_eval_methods_2(DynamicMethodU5BU5D_t3262100997* value)
	{
		___eval_methods_2 = value;
		Il2CppCodeGenWriteBarrier(&___eval_methods_2, value);
	}

	inline static int32_t get_offset_of_eval_methods_defined_3() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___eval_methods_defined_3)); }
	inline BooleanU5BU5D_t3568034315* get_eval_methods_defined_3() const { return ___eval_methods_defined_3; }
	inline BooleanU5BU5D_t3568034315** get_address_of_eval_methods_defined_3() { return &___eval_methods_defined_3; }
	inline void set_eval_methods_defined_3(BooleanU5BU5D_t3568034315* value)
	{
		___eval_methods_defined_3 = value;
		Il2CppCodeGenWriteBarrier(&___eval_methods_defined_3, value);
	}

	inline static int32_t get_offset_of_generic_ops_4() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___generic_ops_4)); }
	inline Dictionary_2_t1079703083 * get_generic_ops_4() const { return ___generic_ops_4; }
	inline Dictionary_2_t1079703083 ** get_address_of_generic_ops_4() { return &___generic_ops_4; }
	inline void set_generic_ops_4(Dictionary_2_t1079703083 * value)
	{
		___generic_ops_4 = value;
		Il2CppCodeGenWriteBarrier(&___generic_ops_4, value);
	}

	inline static int32_t get_offset_of_op_flags_5() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___op_flags_5)); }
	inline Dictionary_2_t1079703083 * get_op_flags_5() const { return ___op_flags_5; }
	inline Dictionary_2_t1079703083 ** get_address_of_op_flags_5() { return &___op_flags_5; }
	inline void set_op_flags_5(Dictionary_2_t1079703083 * value)
	{
		___op_flags_5 = value;
		Il2CppCodeGenWriteBarrier(&___op_flags_5, value);
	}

	inline static int32_t get_offset_of_labels_6() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___labels_6)); }
	inline Dictionary_2_t3251028295 * get_labels_6() const { return ___labels_6; }
	inline Dictionary_2_t3251028295 ** get_address_of_labels_6() { return &___labels_6; }
	inline void set_labels_6(Dictionary_2_t3251028295 * value)
	{
		___labels_6 = value;
		Il2CppCodeGenWriteBarrier(&___labels_6, value);
	}

	inline static int32_t get_offset_of_local_textinfo_33() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799, ___local_textinfo_33)); }
	inline LocalBuilder_t2116499186 * get_local_textinfo_33() const { return ___local_textinfo_33; }
	inline LocalBuilder_t2116499186 ** get_address_of_local_textinfo_33() { return &___local_textinfo_33; }
	inline void set_local_textinfo_33(LocalBuilder_t2116499186 * value)
	{
		___local_textinfo_33 = value;
		Il2CppCodeGenWriteBarrier(&___local_textinfo_33, value);
	}
};

struct CILCompiler_t1740644799_StaticFields
{
public:
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_str
	FieldInfo_t * ___fi_str_7;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_string_start
	FieldInfo_t * ___fi_string_start_8;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_string_end
	FieldInfo_t * ___fi_string_end_9;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_program
	FieldInfo_t * ___fi_program_10;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_marks
	FieldInfo_t * ___fi_marks_11;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_groups
	FieldInfo_t * ___fi_groups_12;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_deep
	FieldInfo_t * ___fi_deep_13;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_stack
	FieldInfo_t * ___fi_stack_14;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_mark_start
	FieldInfo_t * ___fi_mark_start_15;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_mark_end
	FieldInfo_t * ___fi_mark_end_16;
	// System.Reflection.FieldInfo System.Text.RegularExpressions.CILCompiler::fi_mark_index
	FieldInfo_t * ___fi_mark_index_17;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_stack_get_count
	MethodInfo_t * ___mi_stack_get_count_18;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_stack_set_count
	MethodInfo_t * ___mi_stack_set_count_19;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_stack_push
	MethodInfo_t * ___mi_stack_push_20;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_stack_pop
	MethodInfo_t * ___mi_stack_pop_21;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_set_start_of_match
	MethodInfo_t * ___mi_set_start_of_match_22;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_is_word_char
	MethodInfo_t * ___mi_is_word_char_23;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_reset_groups
	MethodInfo_t * ___mi_reset_groups_24;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_checkpoint
	MethodInfo_t * ___mi_checkpoint_25;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_backtrack
	MethodInfo_t * ___mi_backtrack_26;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_open
	MethodInfo_t * ___mi_open_27;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_close
	MethodInfo_t * ___mi_close_28;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_get_last_defined
	MethodInfo_t * ___mi_get_last_defined_29;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_mark_get_index
	MethodInfo_t * ___mi_mark_get_index_30;
	// System.Reflection.MethodInfo System.Text.RegularExpressions.CILCompiler::mi_mark_get_length
	MethodInfo_t * ___mi_mark_get_length_31;
	// System.Boolean System.Text.RegularExpressions.CILCompiler::trace_compile
	bool ___trace_compile_32;

public:
	inline static int32_t get_offset_of_fi_str_7() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_str_7)); }
	inline FieldInfo_t * get_fi_str_7() const { return ___fi_str_7; }
	inline FieldInfo_t ** get_address_of_fi_str_7() { return &___fi_str_7; }
	inline void set_fi_str_7(FieldInfo_t * value)
	{
		___fi_str_7 = value;
		Il2CppCodeGenWriteBarrier(&___fi_str_7, value);
	}

	inline static int32_t get_offset_of_fi_string_start_8() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_string_start_8)); }
	inline FieldInfo_t * get_fi_string_start_8() const { return ___fi_string_start_8; }
	inline FieldInfo_t ** get_address_of_fi_string_start_8() { return &___fi_string_start_8; }
	inline void set_fi_string_start_8(FieldInfo_t * value)
	{
		___fi_string_start_8 = value;
		Il2CppCodeGenWriteBarrier(&___fi_string_start_8, value);
	}

	inline static int32_t get_offset_of_fi_string_end_9() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_string_end_9)); }
	inline FieldInfo_t * get_fi_string_end_9() const { return ___fi_string_end_9; }
	inline FieldInfo_t ** get_address_of_fi_string_end_9() { return &___fi_string_end_9; }
	inline void set_fi_string_end_9(FieldInfo_t * value)
	{
		___fi_string_end_9 = value;
		Il2CppCodeGenWriteBarrier(&___fi_string_end_9, value);
	}

	inline static int32_t get_offset_of_fi_program_10() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_program_10)); }
	inline FieldInfo_t * get_fi_program_10() const { return ___fi_program_10; }
	inline FieldInfo_t ** get_address_of_fi_program_10() { return &___fi_program_10; }
	inline void set_fi_program_10(FieldInfo_t * value)
	{
		___fi_program_10 = value;
		Il2CppCodeGenWriteBarrier(&___fi_program_10, value);
	}

	inline static int32_t get_offset_of_fi_marks_11() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_marks_11)); }
	inline FieldInfo_t * get_fi_marks_11() const { return ___fi_marks_11; }
	inline FieldInfo_t ** get_address_of_fi_marks_11() { return &___fi_marks_11; }
	inline void set_fi_marks_11(FieldInfo_t * value)
	{
		___fi_marks_11 = value;
		Il2CppCodeGenWriteBarrier(&___fi_marks_11, value);
	}

	inline static int32_t get_offset_of_fi_groups_12() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_groups_12)); }
	inline FieldInfo_t * get_fi_groups_12() const { return ___fi_groups_12; }
	inline FieldInfo_t ** get_address_of_fi_groups_12() { return &___fi_groups_12; }
	inline void set_fi_groups_12(FieldInfo_t * value)
	{
		___fi_groups_12 = value;
		Il2CppCodeGenWriteBarrier(&___fi_groups_12, value);
	}

	inline static int32_t get_offset_of_fi_deep_13() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_deep_13)); }
	inline FieldInfo_t * get_fi_deep_13() const { return ___fi_deep_13; }
	inline FieldInfo_t ** get_address_of_fi_deep_13() { return &___fi_deep_13; }
	inline void set_fi_deep_13(FieldInfo_t * value)
	{
		___fi_deep_13 = value;
		Il2CppCodeGenWriteBarrier(&___fi_deep_13, value);
	}

	inline static int32_t get_offset_of_fi_stack_14() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_stack_14)); }
	inline FieldInfo_t * get_fi_stack_14() const { return ___fi_stack_14; }
	inline FieldInfo_t ** get_address_of_fi_stack_14() { return &___fi_stack_14; }
	inline void set_fi_stack_14(FieldInfo_t * value)
	{
		___fi_stack_14 = value;
		Il2CppCodeGenWriteBarrier(&___fi_stack_14, value);
	}

	inline static int32_t get_offset_of_fi_mark_start_15() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_mark_start_15)); }
	inline FieldInfo_t * get_fi_mark_start_15() const { return ___fi_mark_start_15; }
	inline FieldInfo_t ** get_address_of_fi_mark_start_15() { return &___fi_mark_start_15; }
	inline void set_fi_mark_start_15(FieldInfo_t * value)
	{
		___fi_mark_start_15 = value;
		Il2CppCodeGenWriteBarrier(&___fi_mark_start_15, value);
	}

	inline static int32_t get_offset_of_fi_mark_end_16() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_mark_end_16)); }
	inline FieldInfo_t * get_fi_mark_end_16() const { return ___fi_mark_end_16; }
	inline FieldInfo_t ** get_address_of_fi_mark_end_16() { return &___fi_mark_end_16; }
	inline void set_fi_mark_end_16(FieldInfo_t * value)
	{
		___fi_mark_end_16 = value;
		Il2CppCodeGenWriteBarrier(&___fi_mark_end_16, value);
	}

	inline static int32_t get_offset_of_fi_mark_index_17() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___fi_mark_index_17)); }
	inline FieldInfo_t * get_fi_mark_index_17() const { return ___fi_mark_index_17; }
	inline FieldInfo_t ** get_address_of_fi_mark_index_17() { return &___fi_mark_index_17; }
	inline void set_fi_mark_index_17(FieldInfo_t * value)
	{
		___fi_mark_index_17 = value;
		Il2CppCodeGenWriteBarrier(&___fi_mark_index_17, value);
	}

	inline static int32_t get_offset_of_mi_stack_get_count_18() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_stack_get_count_18)); }
	inline MethodInfo_t * get_mi_stack_get_count_18() const { return ___mi_stack_get_count_18; }
	inline MethodInfo_t ** get_address_of_mi_stack_get_count_18() { return &___mi_stack_get_count_18; }
	inline void set_mi_stack_get_count_18(MethodInfo_t * value)
	{
		___mi_stack_get_count_18 = value;
		Il2CppCodeGenWriteBarrier(&___mi_stack_get_count_18, value);
	}

	inline static int32_t get_offset_of_mi_stack_set_count_19() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_stack_set_count_19)); }
	inline MethodInfo_t * get_mi_stack_set_count_19() const { return ___mi_stack_set_count_19; }
	inline MethodInfo_t ** get_address_of_mi_stack_set_count_19() { return &___mi_stack_set_count_19; }
	inline void set_mi_stack_set_count_19(MethodInfo_t * value)
	{
		___mi_stack_set_count_19 = value;
		Il2CppCodeGenWriteBarrier(&___mi_stack_set_count_19, value);
	}

	inline static int32_t get_offset_of_mi_stack_push_20() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_stack_push_20)); }
	inline MethodInfo_t * get_mi_stack_push_20() const { return ___mi_stack_push_20; }
	inline MethodInfo_t ** get_address_of_mi_stack_push_20() { return &___mi_stack_push_20; }
	inline void set_mi_stack_push_20(MethodInfo_t * value)
	{
		___mi_stack_push_20 = value;
		Il2CppCodeGenWriteBarrier(&___mi_stack_push_20, value);
	}

	inline static int32_t get_offset_of_mi_stack_pop_21() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_stack_pop_21)); }
	inline MethodInfo_t * get_mi_stack_pop_21() const { return ___mi_stack_pop_21; }
	inline MethodInfo_t ** get_address_of_mi_stack_pop_21() { return &___mi_stack_pop_21; }
	inline void set_mi_stack_pop_21(MethodInfo_t * value)
	{
		___mi_stack_pop_21 = value;
		Il2CppCodeGenWriteBarrier(&___mi_stack_pop_21, value);
	}

	inline static int32_t get_offset_of_mi_set_start_of_match_22() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_set_start_of_match_22)); }
	inline MethodInfo_t * get_mi_set_start_of_match_22() const { return ___mi_set_start_of_match_22; }
	inline MethodInfo_t ** get_address_of_mi_set_start_of_match_22() { return &___mi_set_start_of_match_22; }
	inline void set_mi_set_start_of_match_22(MethodInfo_t * value)
	{
		___mi_set_start_of_match_22 = value;
		Il2CppCodeGenWriteBarrier(&___mi_set_start_of_match_22, value);
	}

	inline static int32_t get_offset_of_mi_is_word_char_23() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_is_word_char_23)); }
	inline MethodInfo_t * get_mi_is_word_char_23() const { return ___mi_is_word_char_23; }
	inline MethodInfo_t ** get_address_of_mi_is_word_char_23() { return &___mi_is_word_char_23; }
	inline void set_mi_is_word_char_23(MethodInfo_t * value)
	{
		___mi_is_word_char_23 = value;
		Il2CppCodeGenWriteBarrier(&___mi_is_word_char_23, value);
	}

	inline static int32_t get_offset_of_mi_reset_groups_24() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_reset_groups_24)); }
	inline MethodInfo_t * get_mi_reset_groups_24() const { return ___mi_reset_groups_24; }
	inline MethodInfo_t ** get_address_of_mi_reset_groups_24() { return &___mi_reset_groups_24; }
	inline void set_mi_reset_groups_24(MethodInfo_t * value)
	{
		___mi_reset_groups_24 = value;
		Il2CppCodeGenWriteBarrier(&___mi_reset_groups_24, value);
	}

	inline static int32_t get_offset_of_mi_checkpoint_25() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_checkpoint_25)); }
	inline MethodInfo_t * get_mi_checkpoint_25() const { return ___mi_checkpoint_25; }
	inline MethodInfo_t ** get_address_of_mi_checkpoint_25() { return &___mi_checkpoint_25; }
	inline void set_mi_checkpoint_25(MethodInfo_t * value)
	{
		___mi_checkpoint_25 = value;
		Il2CppCodeGenWriteBarrier(&___mi_checkpoint_25, value);
	}

	inline static int32_t get_offset_of_mi_backtrack_26() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_backtrack_26)); }
	inline MethodInfo_t * get_mi_backtrack_26() const { return ___mi_backtrack_26; }
	inline MethodInfo_t ** get_address_of_mi_backtrack_26() { return &___mi_backtrack_26; }
	inline void set_mi_backtrack_26(MethodInfo_t * value)
	{
		___mi_backtrack_26 = value;
		Il2CppCodeGenWriteBarrier(&___mi_backtrack_26, value);
	}

	inline static int32_t get_offset_of_mi_open_27() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_open_27)); }
	inline MethodInfo_t * get_mi_open_27() const { return ___mi_open_27; }
	inline MethodInfo_t ** get_address_of_mi_open_27() { return &___mi_open_27; }
	inline void set_mi_open_27(MethodInfo_t * value)
	{
		___mi_open_27 = value;
		Il2CppCodeGenWriteBarrier(&___mi_open_27, value);
	}

	inline static int32_t get_offset_of_mi_close_28() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_close_28)); }
	inline MethodInfo_t * get_mi_close_28() const { return ___mi_close_28; }
	inline MethodInfo_t ** get_address_of_mi_close_28() { return &___mi_close_28; }
	inline void set_mi_close_28(MethodInfo_t * value)
	{
		___mi_close_28 = value;
		Il2CppCodeGenWriteBarrier(&___mi_close_28, value);
	}

	inline static int32_t get_offset_of_mi_get_last_defined_29() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_get_last_defined_29)); }
	inline MethodInfo_t * get_mi_get_last_defined_29() const { return ___mi_get_last_defined_29; }
	inline MethodInfo_t ** get_address_of_mi_get_last_defined_29() { return &___mi_get_last_defined_29; }
	inline void set_mi_get_last_defined_29(MethodInfo_t * value)
	{
		___mi_get_last_defined_29 = value;
		Il2CppCodeGenWriteBarrier(&___mi_get_last_defined_29, value);
	}

	inline static int32_t get_offset_of_mi_mark_get_index_30() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_mark_get_index_30)); }
	inline MethodInfo_t * get_mi_mark_get_index_30() const { return ___mi_mark_get_index_30; }
	inline MethodInfo_t ** get_address_of_mi_mark_get_index_30() { return &___mi_mark_get_index_30; }
	inline void set_mi_mark_get_index_30(MethodInfo_t * value)
	{
		___mi_mark_get_index_30 = value;
		Il2CppCodeGenWriteBarrier(&___mi_mark_get_index_30, value);
	}

	inline static int32_t get_offset_of_mi_mark_get_length_31() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___mi_mark_get_length_31)); }
	inline MethodInfo_t * get_mi_mark_get_length_31() const { return ___mi_mark_get_length_31; }
	inline MethodInfo_t ** get_address_of_mi_mark_get_length_31() { return &___mi_mark_get_length_31; }
	inline void set_mi_mark_get_length_31(MethodInfo_t * value)
	{
		___mi_mark_get_length_31 = value;
		Il2CppCodeGenWriteBarrier(&___mi_mark_get_length_31, value);
	}

	inline static int32_t get_offset_of_trace_compile_32() { return static_cast<int32_t>(offsetof(CILCompiler_t1740644799_StaticFields, ___trace_compile_32)); }
	inline bool get_trace_compile_32() const { return ___trace_compile_32; }
	inline bool* get_address_of_trace_compile_32() { return &___trace_compile_32; }
	inline void set_trace_compile_32(bool value)
	{
		___trace_compile_32 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
