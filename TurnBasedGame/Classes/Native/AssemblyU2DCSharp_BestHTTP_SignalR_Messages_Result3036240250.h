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
// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Messages.ResultMessage
struct  ResultMessage_t3036240250  : public Il2CppObject
{
public:
	// System.UInt64 BestHTTP.SignalR.Messages.ResultMessage::<InvocationId>k__BackingField
	uint64_t ___U3CInvocationIdU3Ek__BackingField_0;
	// System.Object BestHTTP.SignalR.Messages.ResultMessage::<ReturnValue>k__BackingField
	Il2CppObject * ___U3CReturnValueU3Ek__BackingField_1;
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> BestHTTP.SignalR.Messages.ResultMessage::<State>k__BackingField
	Il2CppObject* ___U3CStateU3Ek__BackingField_2;

public:
	inline static int32_t get_offset_of_U3CInvocationIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(ResultMessage_t3036240250, ___U3CInvocationIdU3Ek__BackingField_0)); }
	inline uint64_t get_U3CInvocationIdU3Ek__BackingField_0() const { return ___U3CInvocationIdU3Ek__BackingField_0; }
	inline uint64_t* get_address_of_U3CInvocationIdU3Ek__BackingField_0() { return &___U3CInvocationIdU3Ek__BackingField_0; }
	inline void set_U3CInvocationIdU3Ek__BackingField_0(uint64_t value)
	{
		___U3CInvocationIdU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CReturnValueU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ResultMessage_t3036240250, ___U3CReturnValueU3Ek__BackingField_1)); }
	inline Il2CppObject * get_U3CReturnValueU3Ek__BackingField_1() const { return ___U3CReturnValueU3Ek__BackingField_1; }
	inline Il2CppObject ** get_address_of_U3CReturnValueU3Ek__BackingField_1() { return &___U3CReturnValueU3Ek__BackingField_1; }
	inline void set_U3CReturnValueU3Ek__BackingField_1(Il2CppObject * value)
	{
		___U3CReturnValueU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CReturnValueU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(ResultMessage_t3036240250, ___U3CStateU3Ek__BackingField_2)); }
	inline Il2CppObject* get_U3CStateU3Ek__BackingField_2() const { return ___U3CStateU3Ek__BackingField_2; }
	inline Il2CppObject** get_address_of_U3CStateU3Ek__BackingField_2() { return &___U3CStateU3Ek__BackingField_2; }
	inline void set_U3CStateU3Ek__BackingField_2(Il2CppObject* value)
	{
		___U3CStateU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStateU3Ek__BackingField_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
