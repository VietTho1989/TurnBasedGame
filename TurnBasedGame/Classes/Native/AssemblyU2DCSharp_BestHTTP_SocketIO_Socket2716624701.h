#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// BestHTTP.SocketIO.SocketManager
struct SocketManager_t3470268644;
// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.Int32,BestHTTP.SocketIO.Events.SocketIOAckCallback>
struct Dictionary_2_t3356392074;
// BestHTTP.SocketIO.Events.EventTable
struct EventTable_t3321213846;
// System.Collections.Generic.List`1<System.Object>
struct List_1_t2058570427;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Socket
struct  Socket_t2716624701  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.SocketManager BestHTTP.SocketIO.Socket::<Manager>k__BackingField
	SocketManager_t3470268644 * ___U3CManagerU3Ek__BackingField_0;
	// System.String BestHTTP.SocketIO.Socket::<Namespace>k__BackingField
	String_t* ___U3CNamespaceU3Ek__BackingField_1;
	// System.Boolean BestHTTP.SocketIO.Socket::<IsOpen>k__BackingField
	bool ___U3CIsOpenU3Ek__BackingField_2;
	// System.Boolean BestHTTP.SocketIO.Socket::<AutoDecodePayload>k__BackingField
	bool ___U3CAutoDecodePayloadU3Ek__BackingField_3;
	// System.Collections.Generic.Dictionary`2<System.Int32,BestHTTP.SocketIO.Events.SocketIOAckCallback> BestHTTP.SocketIO.Socket::AckCallbacks
	Dictionary_2_t3356392074 * ___AckCallbacks_4;
	// BestHTTP.SocketIO.Events.EventTable BestHTTP.SocketIO.Socket::EventCallbacks
	EventTable_t3321213846 * ___EventCallbacks_5;
	// System.Collections.Generic.List`1<System.Object> BestHTTP.SocketIO.Socket::arguments
	List_1_t2058570427 * ___arguments_6;

public:
	inline static int32_t get_offset_of_U3CManagerU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___U3CManagerU3Ek__BackingField_0)); }
	inline SocketManager_t3470268644 * get_U3CManagerU3Ek__BackingField_0() const { return ___U3CManagerU3Ek__BackingField_0; }
	inline SocketManager_t3470268644 ** get_address_of_U3CManagerU3Ek__BackingField_0() { return &___U3CManagerU3Ek__BackingField_0; }
	inline void set_U3CManagerU3Ek__BackingField_0(SocketManager_t3470268644 * value)
	{
		___U3CManagerU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CManagerU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CNamespaceU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___U3CNamespaceU3Ek__BackingField_1)); }
	inline String_t* get_U3CNamespaceU3Ek__BackingField_1() const { return ___U3CNamespaceU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CNamespaceU3Ek__BackingField_1() { return &___U3CNamespaceU3Ek__BackingField_1; }
	inline void set_U3CNamespaceU3Ek__BackingField_1(String_t* value)
	{
		___U3CNamespaceU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNamespaceU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CIsOpenU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___U3CIsOpenU3Ek__BackingField_2)); }
	inline bool get_U3CIsOpenU3Ek__BackingField_2() const { return ___U3CIsOpenU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CIsOpenU3Ek__BackingField_2() { return &___U3CIsOpenU3Ek__BackingField_2; }
	inline void set_U3CIsOpenU3Ek__BackingField_2(bool value)
	{
		___U3CIsOpenU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CAutoDecodePayloadU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___U3CAutoDecodePayloadU3Ek__BackingField_3)); }
	inline bool get_U3CAutoDecodePayloadU3Ek__BackingField_3() const { return ___U3CAutoDecodePayloadU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CAutoDecodePayloadU3Ek__BackingField_3() { return &___U3CAutoDecodePayloadU3Ek__BackingField_3; }
	inline void set_U3CAutoDecodePayloadU3Ek__BackingField_3(bool value)
	{
		___U3CAutoDecodePayloadU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_AckCallbacks_4() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___AckCallbacks_4)); }
	inline Dictionary_2_t3356392074 * get_AckCallbacks_4() const { return ___AckCallbacks_4; }
	inline Dictionary_2_t3356392074 ** get_address_of_AckCallbacks_4() { return &___AckCallbacks_4; }
	inline void set_AckCallbacks_4(Dictionary_2_t3356392074 * value)
	{
		___AckCallbacks_4 = value;
		Il2CppCodeGenWriteBarrier(&___AckCallbacks_4, value);
	}

	inline static int32_t get_offset_of_EventCallbacks_5() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___EventCallbacks_5)); }
	inline EventTable_t3321213846 * get_EventCallbacks_5() const { return ___EventCallbacks_5; }
	inline EventTable_t3321213846 ** get_address_of_EventCallbacks_5() { return &___EventCallbacks_5; }
	inline void set_EventCallbacks_5(EventTable_t3321213846 * value)
	{
		___EventCallbacks_5 = value;
		Il2CppCodeGenWriteBarrier(&___EventCallbacks_5, value);
	}

	inline static int32_t get_offset_of_arguments_6() { return static_cast<int32_t>(offsetof(Socket_t2716624701, ___arguments_6)); }
	inline List_1_t2058570427 * get_arguments_6() const { return ___arguments_6; }
	inline List_1_t2058570427 ** get_address_of_arguments_6() { return &___arguments_6; }
	inline void set_arguments_6(List_1_t2058570427 * value)
	{
		___arguments_6 = value;
		Il2CppCodeGenWriteBarrier(&___arguments_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
