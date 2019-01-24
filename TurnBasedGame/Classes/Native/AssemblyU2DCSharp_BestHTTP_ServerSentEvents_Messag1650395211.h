#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_TimeSpan3430258949.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.ServerSentEvents.Message
struct  Message_t1650395211  : public Il2CppObject
{
public:
	// System.String BestHTTP.ServerSentEvents.Message::<Id>k__BackingField
	String_t* ___U3CIdU3Ek__BackingField_0;
	// System.String BestHTTP.ServerSentEvents.Message::<Event>k__BackingField
	String_t* ___U3CEventU3Ek__BackingField_1;
	// System.String BestHTTP.ServerSentEvents.Message::<Data>k__BackingField
	String_t* ___U3CDataU3Ek__BackingField_2;
	// System.TimeSpan BestHTTP.ServerSentEvents.Message::<Retry>k__BackingField
	TimeSpan_t3430258949  ___U3CRetryU3Ek__BackingField_3;

public:
	inline static int32_t get_offset_of_U3CIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Message_t1650395211, ___U3CIdU3Ek__BackingField_0)); }
	inline String_t* get_U3CIdU3Ek__BackingField_0() const { return ___U3CIdU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CIdU3Ek__BackingField_0() { return &___U3CIdU3Ek__BackingField_0; }
	inline void set_U3CIdU3Ek__BackingField_0(String_t* value)
	{
		___U3CIdU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CIdU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CEventU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Message_t1650395211, ___U3CEventU3Ek__BackingField_1)); }
	inline String_t* get_U3CEventU3Ek__BackingField_1() const { return ___U3CEventU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CEventU3Ek__BackingField_1() { return &___U3CEventU3Ek__BackingField_1; }
	inline void set_U3CEventU3Ek__BackingField_1(String_t* value)
	{
		___U3CEventU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CEventU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CDataU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Message_t1650395211, ___U3CDataU3Ek__BackingField_2)); }
	inline String_t* get_U3CDataU3Ek__BackingField_2() const { return ___U3CDataU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CDataU3Ek__BackingField_2() { return &___U3CDataU3Ek__BackingField_2; }
	inline void set_U3CDataU3Ek__BackingField_2(String_t* value)
	{
		___U3CDataU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDataU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CRetryU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Message_t1650395211, ___U3CRetryU3Ek__BackingField_3)); }
	inline TimeSpan_t3430258949  get_U3CRetryU3Ek__BackingField_3() const { return ___U3CRetryU3Ek__BackingField_3; }
	inline TimeSpan_t3430258949 * get_address_of_U3CRetryU3Ek__BackingField_3() { return &___U3CRetryU3Ek__BackingField_3; }
	inline void set_U3CRetryU3Ek__BackingField_3(TimeSpan_t3430258949  value)
	{
		___U3CRetryU3Ek__BackingField_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
