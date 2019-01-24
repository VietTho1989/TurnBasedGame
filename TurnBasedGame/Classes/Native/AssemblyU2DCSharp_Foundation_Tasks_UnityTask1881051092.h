#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_CustomYieldInstruction1786092740.h"
#include "AssemblyU2DCSharp_Foundation_Tasks_TaskStrategy1827190280.h"
#include "AssemblyU2DCSharp_Foundation_Tasks_TaskStatus3554728257.h"

// System.Exception
struct Exception_t1927440687;
// Foundation.Tasks.HttpMetadata
struct HttpMetadata_t2935150347;
// System.Action
struct Action_t3226471752;
// System.Collections.IEnumerator
struct IEnumerator_t1466026749;
// System.Collections.Generic.List`1<System.Delegate>
struct List_1_t2391597423;
// Foundation.Tasks.UnityTask
struct UnityTask_t1881051092;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.UnityTask
struct  UnityTask_t1881051092  : public CustomYieldInstruction_t1786092740
{
public:
	// Foundation.Tasks.TaskStrategy Foundation.Tasks.UnityTask::Strategy
	int32_t ___Strategy_2;
	// System.Exception Foundation.Tasks.UnityTask::<Exception>k__BackingField
	Exception_t1927440687 * ___U3CExceptionU3Ek__BackingField_3;
	// Foundation.Tasks.TaskStatus Foundation.Tasks.UnityTask::<Status>k__BackingField
	int32_t ___U3CStatusU3Ek__BackingField_4;
	// Foundation.Tasks.HttpMetadata Foundation.Tasks.UnityTask::<Metadata>k__BackingField
	HttpMetadata_t2935150347 * ___U3CMetadataU3Ek__BackingField_5;
	// System.Boolean Foundation.Tasks.UnityTask::<HasContinuations>k__BackingField
	bool ___U3CHasContinuationsU3Ek__BackingField_6;
	// Foundation.Tasks.TaskStatus Foundation.Tasks.UnityTask::_status
	int32_t ____status_7;
	// System.Action Foundation.Tasks.UnityTask::_action
	Action_t3226471752 * ____action_8;
	// System.Collections.IEnumerator Foundation.Tasks.UnityTask::_routine
	Il2CppObject * ____routine_9;
	// System.Collections.Generic.List`1<System.Delegate> Foundation.Tasks.UnityTask::_completeList
	List_1_t2391597423 * ____completeList_10;

public:
	inline static int32_t get_offset_of_Strategy_2() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ___Strategy_2)); }
	inline int32_t get_Strategy_2() const { return ___Strategy_2; }
	inline int32_t* get_address_of_Strategy_2() { return &___Strategy_2; }
	inline void set_Strategy_2(int32_t value)
	{
		___Strategy_2 = value;
	}

	inline static int32_t get_offset_of_U3CExceptionU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ___U3CExceptionU3Ek__BackingField_3)); }
	inline Exception_t1927440687 * get_U3CExceptionU3Ek__BackingField_3() const { return ___U3CExceptionU3Ek__BackingField_3; }
	inline Exception_t1927440687 ** get_address_of_U3CExceptionU3Ek__BackingField_3() { return &___U3CExceptionU3Ek__BackingField_3; }
	inline void set_U3CExceptionU3Ek__BackingField_3(Exception_t1927440687 * value)
	{
		___U3CExceptionU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CExceptionU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CStatusU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ___U3CStatusU3Ek__BackingField_4)); }
	inline int32_t get_U3CStatusU3Ek__BackingField_4() const { return ___U3CStatusU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CStatusU3Ek__BackingField_4() { return &___U3CStatusU3Ek__BackingField_4; }
	inline void set_U3CStatusU3Ek__BackingField_4(int32_t value)
	{
		___U3CStatusU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CMetadataU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ___U3CMetadataU3Ek__BackingField_5)); }
	inline HttpMetadata_t2935150347 * get_U3CMetadataU3Ek__BackingField_5() const { return ___U3CMetadataU3Ek__BackingField_5; }
	inline HttpMetadata_t2935150347 ** get_address_of_U3CMetadataU3Ek__BackingField_5() { return &___U3CMetadataU3Ek__BackingField_5; }
	inline void set_U3CMetadataU3Ek__BackingField_5(HttpMetadata_t2935150347 * value)
	{
		___U3CMetadataU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMetadataU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CHasContinuationsU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ___U3CHasContinuationsU3Ek__BackingField_6)); }
	inline bool get_U3CHasContinuationsU3Ek__BackingField_6() const { return ___U3CHasContinuationsU3Ek__BackingField_6; }
	inline bool* get_address_of_U3CHasContinuationsU3Ek__BackingField_6() { return &___U3CHasContinuationsU3Ek__BackingField_6; }
	inline void set_U3CHasContinuationsU3Ek__BackingField_6(bool value)
	{
		___U3CHasContinuationsU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of__status_7() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ____status_7)); }
	inline int32_t get__status_7() const { return ____status_7; }
	inline int32_t* get_address_of__status_7() { return &____status_7; }
	inline void set__status_7(int32_t value)
	{
		____status_7 = value;
	}

	inline static int32_t get_offset_of__action_8() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ____action_8)); }
	inline Action_t3226471752 * get__action_8() const { return ____action_8; }
	inline Action_t3226471752 ** get_address_of__action_8() { return &____action_8; }
	inline void set__action_8(Action_t3226471752 * value)
	{
		____action_8 = value;
		Il2CppCodeGenWriteBarrier(&____action_8, value);
	}

	inline static int32_t get_offset_of__routine_9() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ____routine_9)); }
	inline Il2CppObject * get__routine_9() const { return ____routine_9; }
	inline Il2CppObject ** get_address_of__routine_9() { return &____routine_9; }
	inline void set__routine_9(Il2CppObject * value)
	{
		____routine_9 = value;
		Il2CppCodeGenWriteBarrier(&____routine_9, value);
	}

	inline static int32_t get_offset_of__completeList_10() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092, ____completeList_10)); }
	inline List_1_t2391597423 * get__completeList_10() const { return ____completeList_10; }
	inline List_1_t2391597423 ** get_address_of__completeList_10() { return &____completeList_10; }
	inline void set__completeList_10(List_1_t2391597423 * value)
	{
		____completeList_10 = value;
		Il2CppCodeGenWriteBarrier(&____completeList_10, value);
	}
};

struct UnityTask_t1881051092_StaticFields
{
public:
	// System.Boolean Foundation.Tasks.UnityTask::DisableMultiThread
	bool ___DisableMultiThread_0;
	// System.Boolean Foundation.Tasks.UnityTask::LogErrors
	bool ___LogErrors_1;
	// Foundation.Tasks.UnityTask Foundation.Tasks.UnityTask::_successTask
	UnityTask_t1881051092 * ____successTask_11;

public:
	inline static int32_t get_offset_of_DisableMultiThread_0() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092_StaticFields, ___DisableMultiThread_0)); }
	inline bool get_DisableMultiThread_0() const { return ___DisableMultiThread_0; }
	inline bool* get_address_of_DisableMultiThread_0() { return &___DisableMultiThread_0; }
	inline void set_DisableMultiThread_0(bool value)
	{
		___DisableMultiThread_0 = value;
	}

	inline static int32_t get_offset_of_LogErrors_1() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092_StaticFields, ___LogErrors_1)); }
	inline bool get_LogErrors_1() const { return ___LogErrors_1; }
	inline bool* get_address_of_LogErrors_1() { return &___LogErrors_1; }
	inline void set_LogErrors_1(bool value)
	{
		___LogErrors_1 = value;
	}

	inline static int32_t get_offset_of__successTask_11() { return static_cast<int32_t>(offsetof(UnityTask_t1881051092_StaticFields, ____successTask_11)); }
	inline UnityTask_t1881051092 * get__successTask_11() const { return ____successTask_11; }
	inline UnityTask_t1881051092 ** get_address_of__successTask_11() { return &____successTask_11; }
	inline void set__successTask_11(UnityTask_t1881051092 * value)
	{
		____successTask_11 = value;
		Il2CppCodeGenWriteBarrier(&____successTask_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
