#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Foundation.Tasks.UnityTask
struct UnityTask_t1881051092;
// System.Action`1<Foundation.Tasks.UnityTask>
struct Action_1_t1682850474;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0
struct  U3CTimeOutAsyncU3Ec__Iterator0_t1243010837  : public Il2CppObject
{
public:
	// System.Int32 Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::seconds
	int32_t ___seconds_0;
	// Foundation.Tasks.UnityTask Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::task
	UnityTask_t1881051092 * ___task_1;
	// System.Action`1<Foundation.Tasks.UnityTask> Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::onTimeout
	Action_1_t1682850474 * ___onTimeout_2;
	// System.Object Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::$current
	Il2CppObject * ___U24current_3;
	// System.Boolean Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::$disposing
	bool ___U24disposing_4;
	// System.Int32 Foundation.Tasks.TaskExtensions/<TimeOutAsync>c__Iterator0::$PC
	int32_t ___U24PC_5;

public:
	inline static int32_t get_offset_of_seconds_0() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___seconds_0)); }
	inline int32_t get_seconds_0() const { return ___seconds_0; }
	inline int32_t* get_address_of_seconds_0() { return &___seconds_0; }
	inline void set_seconds_0(int32_t value)
	{
		___seconds_0 = value;
	}

	inline static int32_t get_offset_of_task_1() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___task_1)); }
	inline UnityTask_t1881051092 * get_task_1() const { return ___task_1; }
	inline UnityTask_t1881051092 ** get_address_of_task_1() { return &___task_1; }
	inline void set_task_1(UnityTask_t1881051092 * value)
	{
		___task_1 = value;
		Il2CppCodeGenWriteBarrier(&___task_1, value);
	}

	inline static int32_t get_offset_of_onTimeout_2() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___onTimeout_2)); }
	inline Action_1_t1682850474 * get_onTimeout_2() const { return ___onTimeout_2; }
	inline Action_1_t1682850474 ** get_address_of_onTimeout_2() { return &___onTimeout_2; }
	inline void set_onTimeout_2(Action_1_t1682850474 * value)
	{
		___onTimeout_2 = value;
		Il2CppCodeGenWriteBarrier(&___onTimeout_2, value);
	}

	inline static int32_t get_offset_of_U24current_3() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___U24current_3)); }
	inline Il2CppObject * get_U24current_3() const { return ___U24current_3; }
	inline Il2CppObject ** get_address_of_U24current_3() { return &___U24current_3; }
	inline void set_U24current_3(Il2CppObject * value)
	{
		___U24current_3 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_3, value);
	}

	inline static int32_t get_offset_of_U24disposing_4() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___U24disposing_4)); }
	inline bool get_U24disposing_4() const { return ___U24disposing_4; }
	inline bool* get_address_of_U24disposing_4() { return &___U24disposing_4; }
	inline void set_U24disposing_4(bool value)
	{
		___U24disposing_4 = value;
	}

	inline static int32_t get_offset_of_U24PC_5() { return static_cast<int32_t>(offsetof(U3CTimeOutAsyncU3Ec__Iterator0_t1243010837, ___U24PC_5)); }
	inline int32_t get_U24PC_5() const { return ___U24PC_5; }
	inline int32_t* get_address_of_U24PC_5() { return &___U24PC_5; }
	inline void set_U24PC_5(int32_t value)
	{
		___U24PC_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
