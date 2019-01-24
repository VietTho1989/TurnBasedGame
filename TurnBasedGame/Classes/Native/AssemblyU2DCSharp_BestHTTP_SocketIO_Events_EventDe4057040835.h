#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<BestHTTP.SocketIO.Events.SocketIOCallback>
struct List_1_t3752707628;
// BestHTTP.SocketIO.Events.SocketIOCallback[]
struct SocketIOCallbackU5BU5D_t2754743361;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Events.EventDescriptor
struct  EventDescriptor_t4057040835  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<BestHTTP.SocketIO.Events.SocketIOCallback> BestHTTP.SocketIO.Events.EventDescriptor::<Callbacks>k__BackingField
	List_1_t3752707628 * ___U3CCallbacksU3Ek__BackingField_0;
	// System.Boolean BestHTTP.SocketIO.Events.EventDescriptor::<OnlyOnce>k__BackingField
	bool ___U3COnlyOnceU3Ek__BackingField_1;
	// System.Boolean BestHTTP.SocketIO.Events.EventDescriptor::<AutoDecodePayload>k__BackingField
	bool ___U3CAutoDecodePayloadU3Ek__BackingField_2;
	// BestHTTP.SocketIO.Events.SocketIOCallback[] BestHTTP.SocketIO.Events.EventDescriptor::CallbackArray
	SocketIOCallbackU5BU5D_t2754743361* ___CallbackArray_3;

public:
	inline static int32_t get_offset_of_U3CCallbacksU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(EventDescriptor_t4057040835, ___U3CCallbacksU3Ek__BackingField_0)); }
	inline List_1_t3752707628 * get_U3CCallbacksU3Ek__BackingField_0() const { return ___U3CCallbacksU3Ek__BackingField_0; }
	inline List_1_t3752707628 ** get_address_of_U3CCallbacksU3Ek__BackingField_0() { return &___U3CCallbacksU3Ek__BackingField_0; }
	inline void set_U3CCallbacksU3Ek__BackingField_0(List_1_t3752707628 * value)
	{
		___U3CCallbacksU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCallbacksU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3COnlyOnceU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(EventDescriptor_t4057040835, ___U3COnlyOnceU3Ek__BackingField_1)); }
	inline bool get_U3COnlyOnceU3Ek__BackingField_1() const { return ___U3COnlyOnceU3Ek__BackingField_1; }
	inline bool* get_address_of_U3COnlyOnceU3Ek__BackingField_1() { return &___U3COnlyOnceU3Ek__BackingField_1; }
	inline void set_U3COnlyOnceU3Ek__BackingField_1(bool value)
	{
		___U3COnlyOnceU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CAutoDecodePayloadU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(EventDescriptor_t4057040835, ___U3CAutoDecodePayloadU3Ek__BackingField_2)); }
	inline bool get_U3CAutoDecodePayloadU3Ek__BackingField_2() const { return ___U3CAutoDecodePayloadU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CAutoDecodePayloadU3Ek__BackingField_2() { return &___U3CAutoDecodePayloadU3Ek__BackingField_2; }
	inline void set_U3CAutoDecodePayloadU3Ek__BackingField_2(bool value)
	{
		___U3CAutoDecodePayloadU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_CallbackArray_3() { return static_cast<int32_t>(offsetof(EventDescriptor_t4057040835, ___CallbackArray_3)); }
	inline SocketIOCallbackU5BU5D_t2754743361* get_CallbackArray_3() const { return ___CallbackArray_3; }
	inline SocketIOCallbackU5BU5D_t2754743361** get_address_of_CallbackArray_3() { return &___CallbackArray_3; }
	inline void set_CallbackArray_3(SocketIOCallbackU5BU5D_t2754743361* value)
	{
		___CallbackArray_3 = value;
		Il2CppCodeGenWriteBarrier(&___CallbackArray_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
