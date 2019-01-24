#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_MarshalByRefObject1285298191.h"
#include "mscorlib_System_TimeSpan3430258949.h"

// System.Threading.WaitHandle
struct WaitHandle_t677569169;
// System.Threading.WaitOrTimerCallback
struct WaitOrTimerCallback_t2724438238;
// System.Object
struct Il2CppObject;
// System.Threading.ManualResetEvent
struct ManualResetEvent_t926074657;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.RegisteredWaitHandle
struct  RegisteredWaitHandle_t2863394393  : public MarshalByRefObject_t1285298191
{
public:
	// System.Threading.WaitHandle System.Threading.RegisteredWaitHandle::_waitObject
	WaitHandle_t677569169 * ____waitObject_1;
	// System.Threading.WaitOrTimerCallback System.Threading.RegisteredWaitHandle::_callback
	WaitOrTimerCallback_t2724438238 * ____callback_2;
	// System.TimeSpan System.Threading.RegisteredWaitHandle::_timeout
	TimeSpan_t3430258949  ____timeout_3;
	// System.Object System.Threading.RegisteredWaitHandle::_state
	Il2CppObject * ____state_4;
	// System.Boolean System.Threading.RegisteredWaitHandle::_executeOnlyOnce
	bool ____executeOnlyOnce_5;
	// System.Threading.WaitHandle System.Threading.RegisteredWaitHandle::_finalEvent
	WaitHandle_t677569169 * ____finalEvent_6;
	// System.Threading.ManualResetEvent System.Threading.RegisteredWaitHandle::_cancelEvent
	ManualResetEvent_t926074657 * ____cancelEvent_7;
	// System.Int32 System.Threading.RegisteredWaitHandle::_callsInProcess
	int32_t ____callsInProcess_8;
	// System.Boolean System.Threading.RegisteredWaitHandle::_unregistered
	bool ____unregistered_9;

public:
	inline static int32_t get_offset_of__waitObject_1() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____waitObject_1)); }
	inline WaitHandle_t677569169 * get__waitObject_1() const { return ____waitObject_1; }
	inline WaitHandle_t677569169 ** get_address_of__waitObject_1() { return &____waitObject_1; }
	inline void set__waitObject_1(WaitHandle_t677569169 * value)
	{
		____waitObject_1 = value;
		Il2CppCodeGenWriteBarrier(&____waitObject_1, value);
	}

	inline static int32_t get_offset_of__callback_2() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____callback_2)); }
	inline WaitOrTimerCallback_t2724438238 * get__callback_2() const { return ____callback_2; }
	inline WaitOrTimerCallback_t2724438238 ** get_address_of__callback_2() { return &____callback_2; }
	inline void set__callback_2(WaitOrTimerCallback_t2724438238 * value)
	{
		____callback_2 = value;
		Il2CppCodeGenWriteBarrier(&____callback_2, value);
	}

	inline static int32_t get_offset_of__timeout_3() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____timeout_3)); }
	inline TimeSpan_t3430258949  get__timeout_3() const { return ____timeout_3; }
	inline TimeSpan_t3430258949 * get_address_of__timeout_3() { return &____timeout_3; }
	inline void set__timeout_3(TimeSpan_t3430258949  value)
	{
		____timeout_3 = value;
	}

	inline static int32_t get_offset_of__state_4() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____state_4)); }
	inline Il2CppObject * get__state_4() const { return ____state_4; }
	inline Il2CppObject ** get_address_of__state_4() { return &____state_4; }
	inline void set__state_4(Il2CppObject * value)
	{
		____state_4 = value;
		Il2CppCodeGenWriteBarrier(&____state_4, value);
	}

	inline static int32_t get_offset_of__executeOnlyOnce_5() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____executeOnlyOnce_5)); }
	inline bool get__executeOnlyOnce_5() const { return ____executeOnlyOnce_5; }
	inline bool* get_address_of__executeOnlyOnce_5() { return &____executeOnlyOnce_5; }
	inline void set__executeOnlyOnce_5(bool value)
	{
		____executeOnlyOnce_5 = value;
	}

	inline static int32_t get_offset_of__finalEvent_6() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____finalEvent_6)); }
	inline WaitHandle_t677569169 * get__finalEvent_6() const { return ____finalEvent_6; }
	inline WaitHandle_t677569169 ** get_address_of__finalEvent_6() { return &____finalEvent_6; }
	inline void set__finalEvent_6(WaitHandle_t677569169 * value)
	{
		____finalEvent_6 = value;
		Il2CppCodeGenWriteBarrier(&____finalEvent_6, value);
	}

	inline static int32_t get_offset_of__cancelEvent_7() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____cancelEvent_7)); }
	inline ManualResetEvent_t926074657 * get__cancelEvent_7() const { return ____cancelEvent_7; }
	inline ManualResetEvent_t926074657 ** get_address_of__cancelEvent_7() { return &____cancelEvent_7; }
	inline void set__cancelEvent_7(ManualResetEvent_t926074657 * value)
	{
		____cancelEvent_7 = value;
		Il2CppCodeGenWriteBarrier(&____cancelEvent_7, value);
	}

	inline static int32_t get_offset_of__callsInProcess_8() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____callsInProcess_8)); }
	inline int32_t get__callsInProcess_8() const { return ____callsInProcess_8; }
	inline int32_t* get_address_of__callsInProcess_8() { return &____callsInProcess_8; }
	inline void set__callsInProcess_8(int32_t value)
	{
		____callsInProcess_8 = value;
	}

	inline static int32_t get_offset_of__unregistered_9() { return static_cast<int32_t>(offsetof(RegisteredWaitHandle_t2863394393, ____unregistered_9)); }
	inline bool get__unregistered_9() const { return ____unregistered_9; }
	inline bool* get_address_of__unregistered_9() { return &____unregistered_9; }
	inline void set__unregistered_9(bool value)
	{
		____unregistered_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
