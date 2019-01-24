#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<Foundation.Messenger/Subscription>
struct List_1_t1864540872;
// System.Collections.Generic.List`1<Foundation.Messenger/Cache>
struct List_1_t3603292543;
// System.Func`2<System.Reflection.MethodInfo,System.Boolean>
struct Func_2_t499475658;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger
struct  Messenger_t137025655  : public Il2CppObject
{
public:

public:
};

struct Messenger_t137025655_StaticFields
{
public:
	// System.Boolean Foundation.Messenger::CheckSubclasses
	bool ___CheckSubclasses_0;
	// System.Collections.Generic.List`1<Foundation.Messenger/Subscription> Foundation.Messenger::Subscriptions
	List_1_t1864540872 * ___Subscriptions_1;
	// System.Collections.Generic.List`1<Foundation.Messenger/Cache> Foundation.Messenger::Cached
	List_1_t3603292543 * ___Cached_2;
	// System.Func`2<System.Reflection.MethodInfo,System.Boolean> Foundation.Messenger::<>f__am$cache0
	Func_2_t499475658 * ___U3CU3Ef__amU24cache0_3;

public:
	inline static int32_t get_offset_of_CheckSubclasses_0() { return static_cast<int32_t>(offsetof(Messenger_t137025655_StaticFields, ___CheckSubclasses_0)); }
	inline bool get_CheckSubclasses_0() const { return ___CheckSubclasses_0; }
	inline bool* get_address_of_CheckSubclasses_0() { return &___CheckSubclasses_0; }
	inline void set_CheckSubclasses_0(bool value)
	{
		___CheckSubclasses_0 = value;
	}

	inline static int32_t get_offset_of_Subscriptions_1() { return static_cast<int32_t>(offsetof(Messenger_t137025655_StaticFields, ___Subscriptions_1)); }
	inline List_1_t1864540872 * get_Subscriptions_1() const { return ___Subscriptions_1; }
	inline List_1_t1864540872 ** get_address_of_Subscriptions_1() { return &___Subscriptions_1; }
	inline void set_Subscriptions_1(List_1_t1864540872 * value)
	{
		___Subscriptions_1 = value;
		Il2CppCodeGenWriteBarrier(&___Subscriptions_1, value);
	}

	inline static int32_t get_offset_of_Cached_2() { return static_cast<int32_t>(offsetof(Messenger_t137025655_StaticFields, ___Cached_2)); }
	inline List_1_t3603292543 * get_Cached_2() const { return ___Cached_2; }
	inline List_1_t3603292543 ** get_address_of_Cached_2() { return &___Cached_2; }
	inline void set_Cached_2(List_1_t3603292543 * value)
	{
		___Cached_2 = value;
		Il2CppCodeGenWriteBarrier(&___Cached_2, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_3() { return static_cast<int32_t>(offsetof(Messenger_t137025655_StaticFields, ___U3CU3Ef__amU24cache0_3)); }
	inline Func_2_t499475658 * get_U3CU3Ef__amU24cache0_3() const { return ___U3CU3Ef__amU24cache0_3; }
	inline Func_2_t499475658 ** get_address_of_U3CU3Ef__amU24cache0_3() { return &___U3CU3Ef__amU24cache0_3; }
	inline void set_U3CU3Ef__amU24cache0_3(Func_2_t499475658 * value)
	{
		___U3CU3Ef__amU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
