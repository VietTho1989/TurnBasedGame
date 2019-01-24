#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Collections.IEnumerator
struct IEnumerator_t1466026749;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.TaskManager/CoroutineCommand
struct  CoroutineCommand_t1564774187 
{
public:
	// System.Collections.IEnumerator Foundation.Tasks.TaskManager/CoroutineCommand::Coroutine
	Il2CppObject * ___Coroutine_0;
	// System.Action Foundation.Tasks.TaskManager/CoroutineCommand::OnComplete
	Action_t3226471752 * ___OnComplete_1;

public:
	inline static int32_t get_offset_of_Coroutine_0() { return static_cast<int32_t>(offsetof(CoroutineCommand_t1564774187, ___Coroutine_0)); }
	inline Il2CppObject * get_Coroutine_0() const { return ___Coroutine_0; }
	inline Il2CppObject ** get_address_of_Coroutine_0() { return &___Coroutine_0; }
	inline void set_Coroutine_0(Il2CppObject * value)
	{
		___Coroutine_0 = value;
		Il2CppCodeGenWriteBarrier(&___Coroutine_0, value);
	}

	inline static int32_t get_offset_of_OnComplete_1() { return static_cast<int32_t>(offsetof(CoroutineCommand_t1564774187, ___OnComplete_1)); }
	inline Action_t3226471752 * get_OnComplete_1() const { return ___OnComplete_1; }
	inline Action_t3226471752 ** get_address_of_OnComplete_1() { return &___OnComplete_1; }
	inline void set_OnComplete_1(Action_t3226471752 * value)
	{
		___OnComplete_1 = value;
		Il2CppCodeGenWriteBarrier(&___OnComplete_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Foundation.Tasks.TaskManager/CoroutineCommand
struct CoroutineCommand_t1564774187_marshaled_pinvoke
{
	Il2CppObject * ___Coroutine_0;
	Il2CppMethodPointer ___OnComplete_1;
};
// Native definition for COM marshalling of Foundation.Tasks.TaskManager/CoroutineCommand
struct CoroutineCommand_t1564774187_marshaled_com
{
	Il2CppObject * ___Coroutine_0;
	Il2CppMethodPointer ___OnComplete_1;
};
