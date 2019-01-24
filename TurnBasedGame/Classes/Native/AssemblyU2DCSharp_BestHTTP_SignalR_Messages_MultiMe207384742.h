#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Nullable_1_gen1693325264.h"

// System.String
struct String_t;
// System.Collections.Generic.List`1<BestHTTP.SignalR.Messages.IServerMessage>
struct List_1_t1753264875;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Messages.MultiMessage
struct  MultiMessage_t207384742  : public Il2CppObject
{
public:
	// System.String BestHTTP.SignalR.Messages.MultiMessage::<MessageId>k__BackingField
	String_t* ___U3CMessageIdU3Ek__BackingField_0;
	// System.Boolean BestHTTP.SignalR.Messages.MultiMessage::<IsInitialization>k__BackingField
	bool ___U3CIsInitializationU3Ek__BackingField_1;
	// System.String BestHTTP.SignalR.Messages.MultiMessage::<GroupsToken>k__BackingField
	String_t* ___U3CGroupsTokenU3Ek__BackingField_2;
	// System.Boolean BestHTTP.SignalR.Messages.MultiMessage::<ShouldReconnect>k__BackingField
	bool ___U3CShouldReconnectU3Ek__BackingField_3;
	// System.Nullable`1<System.TimeSpan> BestHTTP.SignalR.Messages.MultiMessage::<PollDelay>k__BackingField
	Nullable_1_t1693325264  ___U3CPollDelayU3Ek__BackingField_4;
	// System.Collections.Generic.List`1<BestHTTP.SignalR.Messages.IServerMessage> BestHTTP.SignalR.Messages.MultiMessage::<Data>k__BackingField
	List_1_t1753264875 * ___U3CDataU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_U3CMessageIdU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CMessageIdU3Ek__BackingField_0)); }
	inline String_t* get_U3CMessageIdU3Ek__BackingField_0() const { return ___U3CMessageIdU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CMessageIdU3Ek__BackingField_0() { return &___U3CMessageIdU3Ek__BackingField_0; }
	inline void set_U3CMessageIdU3Ek__BackingField_0(String_t* value)
	{
		___U3CMessageIdU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CMessageIdU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CIsInitializationU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CIsInitializationU3Ek__BackingField_1)); }
	inline bool get_U3CIsInitializationU3Ek__BackingField_1() const { return ___U3CIsInitializationU3Ek__BackingField_1; }
	inline bool* get_address_of_U3CIsInitializationU3Ek__BackingField_1() { return &___U3CIsInitializationU3Ek__BackingField_1; }
	inline void set_U3CIsInitializationU3Ek__BackingField_1(bool value)
	{
		___U3CIsInitializationU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CGroupsTokenU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CGroupsTokenU3Ek__BackingField_2)); }
	inline String_t* get_U3CGroupsTokenU3Ek__BackingField_2() const { return ___U3CGroupsTokenU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CGroupsTokenU3Ek__BackingField_2() { return &___U3CGroupsTokenU3Ek__BackingField_2; }
	inline void set_U3CGroupsTokenU3Ek__BackingField_2(String_t* value)
	{
		___U3CGroupsTokenU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CGroupsTokenU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CShouldReconnectU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CShouldReconnectU3Ek__BackingField_3)); }
	inline bool get_U3CShouldReconnectU3Ek__BackingField_3() const { return ___U3CShouldReconnectU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CShouldReconnectU3Ek__BackingField_3() { return &___U3CShouldReconnectU3Ek__BackingField_3; }
	inline void set_U3CShouldReconnectU3Ek__BackingField_3(bool value)
	{
		___U3CShouldReconnectU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CPollDelayU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CPollDelayU3Ek__BackingField_4)); }
	inline Nullable_1_t1693325264  get_U3CPollDelayU3Ek__BackingField_4() const { return ___U3CPollDelayU3Ek__BackingField_4; }
	inline Nullable_1_t1693325264 * get_address_of_U3CPollDelayU3Ek__BackingField_4() { return &___U3CPollDelayU3Ek__BackingField_4; }
	inline void set_U3CPollDelayU3Ek__BackingField_4(Nullable_1_t1693325264  value)
	{
		___U3CPollDelayU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CDataU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(MultiMessage_t207384742, ___U3CDataU3Ek__BackingField_5)); }
	inline List_1_t1753264875 * get_U3CDataU3Ek__BackingField_5() const { return ___U3CDataU3Ek__BackingField_5; }
	inline List_1_t1753264875 ** get_address_of_U3CDataU3Ek__BackingField_5() { return &___U3CDataU3Ek__BackingField_5; }
	inline void set_U3CDataU3Ek__BackingField_5(List_1_t1753264875 * value)
	{
		___U3CDataU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CDataU3Ek__BackingField_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
