#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.FacebookScheduler/<DelayEvent>d__1
struct  U3CDelayEventU3Ed__1_t1533394807  : public Il2CppObject
{
public:
	// System.Int32 Facebook.Unity.FacebookScheduler/<DelayEvent>d__1::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object Facebook.Unity.FacebookScheduler/<DelayEvent>d__1::<>2__current
	Il2CppObject * ___U3CU3E2__current_1;
	// System.Int64 Facebook.Unity.FacebookScheduler/<DelayEvent>d__1::delay
	int64_t ___delay_2;
	// System.Action Facebook.Unity.FacebookScheduler/<DelayEvent>d__1::action
	Action_t3226471752 * ___action_3;

public:
	inline static int32_t get_offset_of_U3CU3E1__state_0() { return static_cast<int32_t>(offsetof(U3CDelayEventU3Ed__1_t1533394807, ___U3CU3E1__state_0)); }
	inline int32_t get_U3CU3E1__state_0() const { return ___U3CU3E1__state_0; }
	inline int32_t* get_address_of_U3CU3E1__state_0() { return &___U3CU3E1__state_0; }
	inline void set_U3CU3E1__state_0(int32_t value)
	{
		___U3CU3E1__state_0 = value;
	}

	inline static int32_t get_offset_of_U3CU3E2__current_1() { return static_cast<int32_t>(offsetof(U3CDelayEventU3Ed__1_t1533394807, ___U3CU3E2__current_1)); }
	inline Il2CppObject * get_U3CU3E2__current_1() const { return ___U3CU3E2__current_1; }
	inline Il2CppObject ** get_address_of_U3CU3E2__current_1() { return &___U3CU3E2__current_1; }
	inline void set_U3CU3E2__current_1(Il2CppObject * value)
	{
		___U3CU3E2__current_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3E2__current_1, value);
	}

	inline static int32_t get_offset_of_delay_2() { return static_cast<int32_t>(offsetof(U3CDelayEventU3Ed__1_t1533394807, ___delay_2)); }
	inline int64_t get_delay_2() const { return ___delay_2; }
	inline int64_t* get_address_of_delay_2() { return &___delay_2; }
	inline void set_delay_2(int64_t value)
	{
		___delay_2 = value;
	}

	inline static int32_t get_offset_of_action_3() { return static_cast<int32_t>(offsetof(U3CDelayEventU3Ed__1_t1533394807, ___action_3)); }
	inline Action_t3226471752 * get_action_3() const { return ___action_3; }
	inline Action_t3226471752 ** get_address_of_action_3() { return &___action_3; }
	inline void set_action_3(Action_t3226471752 * value)
	{
		___action_3 = value;
		Il2CppCodeGenWriteBarrier(&___action_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
