#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Object[]
struct ObjectU5BU5D_t3614634134;
// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Messages.MethodCallMessage
struct  MethodCallMessage_t1119839878  : public Il2CppObject
{
public:
	// System.String BestHTTP.SignalR.Messages.MethodCallMessage::<Hub>k__BackingField
	String_t* ___U3CHubU3Ek__BackingField_0;
	// System.String BestHTTP.SignalR.Messages.MethodCallMessage::<Method>k__BackingField
	String_t* ___U3CMethodU3Ek__BackingField_1;
	// System.Object[] BestHTTP.SignalR.Messages.MethodCallMessage::<Arguments>k__BackingField
	ObjectU5BU5D_t3614634134* ___U3CArgumentsU3Ek__BackingField_2;
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> BestHTTP.SignalR.Messages.MethodCallMessage::<State>k__BackingField
	Il2CppObject* ___U3CStateU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CHubU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MethodCallMessage_t1119839878, ___U3CHubU3Ek__BackingField_0)); }
	inline String_t* get_U3CHubU3Ek__BackingField_0() const { return ___U3CHubU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CHubU3Ek__BackingField_0() { return &___U3CHubU3Ek__BackingField_0; }
	inline void set_U3CHubU3Ek__BackingField_0(String_t* value)
	{
		___U3CHubU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHubU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CMethodU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MethodCallMessage_t1119839878, ___U3CMethodU3Ek__BackingField_1)); }
	inline String_t* get_U3CMethodU3Ek__BackingField_1() const { return ___U3CMethodU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CMethodU3Ek__BackingField_1() { return &___U3CMethodU3Ek__BackingField_1; }
	inline void set_U3CMethodU3Ek__BackingField_1(String_t* value)
	{
		___U3CMethodU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMethodU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CArgumentsU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MethodCallMessage_t1119839878, ___U3CArgumentsU3Ek__BackingField_2)); }
	inline ObjectU5BU5D_t3614634134* get_U3CArgumentsU3Ek__BackingField_2() const { return ___U3CArgumentsU3Ek__BackingField_2; }
	inline ObjectU5BU5D_t3614634134** get_address_of_U3CArgumentsU3Ek__BackingField_2() { return &___U3CArgumentsU3Ek__BackingField_2; }
	inline void set_U3CArgumentsU3Ek__BackingField_2(ObjectU5BU5D_t3614634134* value)
	{
		___U3CArgumentsU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CArgumentsU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MethodCallMessage_t1119839878, ___U3CStateU3Ek__BackingField_3)); }
	inline Il2CppObject* get_U3CStateU3Ek__BackingField_3() const { return ___U3CStateU3Ek__BackingField_3; }
	inline Il2CppObject** get_address_of_U3CStateU3Ek__BackingField_3() { return &___U3CStateU3Ek__BackingField_3; }
	inline void set_U3CStateU3Ek__BackingField_3(Il2CppObject* value)
	{
		___U3CStateU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CStateU3Ek__BackingField_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
