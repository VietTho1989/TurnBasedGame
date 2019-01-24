#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Events_BaseInvokableCall2229564840.h"

// UnityEngine.Events.UnityAction`1<UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct>
struct UnityAction_1_t2982217422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Events.InvokableCall`1<UnityEngine.UI.Extensions.ReorderableList/ReorderableListEventStruct>
struct  InvokableCall_1_t4104925824  : public BaseInvokableCall_t2229564840
{
public:
	// UnityEngine.Events.UnityAction`1<T1> UnityEngine.Events.InvokableCall`1::Delegate
	UnityAction_1_t2982217422 * ___Delegate_0;

public:
	inline static int32_t get_offset_of_Delegate_0() { return static_cast<int32_t>(offsetof(InvokableCall_1_t4104925824, ___Delegate_0)); }
	inline UnityAction_1_t2982217422 * get_Delegate_0() const { return ___Delegate_0; }
	inline UnityAction_1_t2982217422 ** get_address_of_Delegate_0() { return &___Delegate_0; }
	inline void set_Delegate_0(UnityAction_1_t2982217422 * value)
	{
		___Delegate_0 = value;
		Il2CppCodeGenWriteBarrier(&___Delegate_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
