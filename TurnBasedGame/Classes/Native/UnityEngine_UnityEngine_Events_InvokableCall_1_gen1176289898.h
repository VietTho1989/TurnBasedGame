#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_Events_BaseInvokableCall2229564840.h"

// UnityEngine.Events.UnityAction`1<UnityEngine.EventSystems.PointerEventData/InputButton>
struct UnityAction_1_t53581496;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Events.InvokableCall`1<UnityEngine.EventSystems.PointerEventData/InputButton>
struct  InvokableCall_1_t1176289898  : public BaseInvokableCall_t2229564840
{
public:
	// UnityEngine.Events.UnityAction`1<T1> UnityEngine.Events.InvokableCall`1::Delegate
	UnityAction_1_t53581496 * ___Delegate_0;

public:
	inline static int32_t get_offset_of_Delegate_0() { return static_cast<int32_t>(offsetof(InvokableCall_1_t1176289898, ___Delegate_0)); }
	inline UnityAction_1_t53581496 * get_Delegate_0() const { return ___Delegate_0; }
	inline UnityAction_1_t53581496 ** get_address_of_Delegate_0() { return &___Delegate_0; }
	inline void set_Delegate_0(UnityAction_1_t53581496 * value)
	{
		___Delegate_0 = value;
		Il2CppCodeGenWriteBarrier(&___Delegate_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
