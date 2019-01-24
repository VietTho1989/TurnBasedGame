#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.Object>
struct List_1_t2058570427;
// System.Action`1<System.Object>
struct Action_1_t2491248677;
// System.Action`2<System.Int32,System.Object>
struct Action_2_t1987817360;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ObservableList`1<System.Object>
struct  ObservableList_1_t49474940  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<T> Foundation.Databinding.ObservableList`1::InternalList
	List_1_t2058570427 * ___InternalList_0;
	// System.Action`1<T> Foundation.Databinding.ObservableList`1::OnAdd
	Action_1_t2491248677 * ___OnAdd_1;
	// System.Action`2<System.Int32,T> Foundation.Databinding.ObservableList`1::OnInset
	Action_2_t1987817360 * ___OnInset_2;
	// System.Action`1<T> Foundation.Databinding.ObservableList`1::OnRemove
	Action_1_t2491248677 * ___OnRemove_3;
	// System.Action Foundation.Databinding.ObservableList`1::OnClear
	Action_t3226471752 * ___OnClear_4;

public:
	inline static int32_t get_offset_of_InternalList_0() { return static_cast<int32_t>(offsetof(ObservableList_1_t49474940, ___InternalList_0)); }
	inline List_1_t2058570427 * get_InternalList_0() const { return ___InternalList_0; }
	inline List_1_t2058570427 ** get_address_of_InternalList_0() { return &___InternalList_0; }
	inline void set_InternalList_0(List_1_t2058570427 * value)
	{
		___InternalList_0 = value;
		Il2CppCodeGenWriteBarrier(&___InternalList_0, value);
	}

	inline static int32_t get_offset_of_OnAdd_1() { return static_cast<int32_t>(offsetof(ObservableList_1_t49474940, ___OnAdd_1)); }
	inline Action_1_t2491248677 * get_OnAdd_1() const { return ___OnAdd_1; }
	inline Action_1_t2491248677 ** get_address_of_OnAdd_1() { return &___OnAdd_1; }
	inline void set_OnAdd_1(Action_1_t2491248677 * value)
	{
		___OnAdd_1 = value;
		Il2CppCodeGenWriteBarrier(&___OnAdd_1, value);
	}

	inline static int32_t get_offset_of_OnInset_2() { return static_cast<int32_t>(offsetof(ObservableList_1_t49474940, ___OnInset_2)); }
	inline Action_2_t1987817360 * get_OnInset_2() const { return ___OnInset_2; }
	inline Action_2_t1987817360 ** get_address_of_OnInset_2() { return &___OnInset_2; }
	inline void set_OnInset_2(Action_2_t1987817360 * value)
	{
		___OnInset_2 = value;
		Il2CppCodeGenWriteBarrier(&___OnInset_2, value);
	}

	inline static int32_t get_offset_of_OnRemove_3() { return static_cast<int32_t>(offsetof(ObservableList_1_t49474940, ___OnRemove_3)); }
	inline Action_1_t2491248677 * get_OnRemove_3() const { return ___OnRemove_3; }
	inline Action_1_t2491248677 ** get_address_of_OnRemove_3() { return &___OnRemove_3; }
	inline void set_OnRemove_3(Action_1_t2491248677 * value)
	{
		___OnRemove_3 = value;
		Il2CppCodeGenWriteBarrier(&___OnRemove_3, value);
	}

	inline static int32_t get_offset_of_OnClear_4() { return static_cast<int32_t>(offsetof(ObservableList_1_t49474940, ___OnClear_4)); }
	inline Action_t3226471752 * get_OnClear_4() const { return ___OnClear_4; }
	inline Action_t3226471752 ** get_address_of_OnClear_4() { return &___OnClear_4; }
	inline void set_OnClear_4(Action_t3226471752 * value)
	{
		___OnClear_4 = value;
		Il2CppCodeGenWriteBarrier(&___OnClear_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
