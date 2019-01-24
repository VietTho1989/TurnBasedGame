#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Foundation.Tasks.UnityTask`1<System.String>
struct UnityTask_1_t3958184437;
// Foundation.Example.TaskTests
struct TaskTests_t3311020090;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2
struct  U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053  : public Il2CppObject
{
public:
	// Foundation.Tasks.UnityTask`1<System.String> Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2::task
	UnityTask_1_t3958184437 * ___task_0;
	// Foundation.Example.TaskTests Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2::$this
	TaskTests_t3311020090 * ___U24this_1;
	// System.Object Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2::$current
	Il2CppObject * ___U24current_2;
	// System.Boolean Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2::$disposing
	bool ___U24disposing_3;
	// System.Int32 Foundation.Example.TaskTests/<DemoCoroutineWithResult>c__Iterator2::$PC
	int32_t ___U24PC_4;

public:
	inline static int32_t get_offset_of_task_0() { return static_cast<int32_t>(offsetof(U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053, ___task_0)); }
	inline UnityTask_1_t3958184437 * get_task_0() const { return ___task_0; }
	inline UnityTask_1_t3958184437 ** get_address_of_task_0() { return &___task_0; }
	inline void set_task_0(UnityTask_1_t3958184437 * value)
	{
		___task_0 = value;
		Il2CppCodeGenWriteBarrier(&___task_0, value);
	}

	inline static int32_t get_offset_of_U24this_1() { return static_cast<int32_t>(offsetof(U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053, ___U24this_1)); }
	inline TaskTests_t3311020090 * get_U24this_1() const { return ___U24this_1; }
	inline TaskTests_t3311020090 ** get_address_of_U24this_1() { return &___U24this_1; }
	inline void set_U24this_1(TaskTests_t3311020090 * value)
	{
		___U24this_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_1, value);
	}

	inline static int32_t get_offset_of_U24current_2() { return static_cast<int32_t>(offsetof(U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053, ___U24current_2)); }
	inline Il2CppObject * get_U24current_2() const { return ___U24current_2; }
	inline Il2CppObject ** get_address_of_U24current_2() { return &___U24current_2; }
	inline void set_U24current_2(Il2CppObject * value)
	{
		___U24current_2 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_2, value);
	}

	inline static int32_t get_offset_of_U24disposing_3() { return static_cast<int32_t>(offsetof(U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053, ___U24disposing_3)); }
	inline bool get_U24disposing_3() const { return ___U24disposing_3; }
	inline bool* get_address_of_U24disposing_3() { return &___U24disposing_3; }
	inline void set_U24disposing_3(bool value)
	{
		___U24disposing_3 = value;
	}

	inline static int32_t get_offset_of_U24PC_4() { return static_cast<int32_t>(offsetof(U3CDemoCoroutineWithResultU3Ec__Iterator2_t524038053, ___U24PC_4)); }
	inline int32_t get_U24PC_4() const { return ___U24PC_4; }
	inline int32_t* get_address_of_U24PC_4() { return &___U24PC_4; }
	inline void set_U24PC_4(int32_t value)
	{
		___U24PC_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
