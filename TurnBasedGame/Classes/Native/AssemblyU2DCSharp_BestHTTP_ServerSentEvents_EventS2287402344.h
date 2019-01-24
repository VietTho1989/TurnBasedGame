#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_HTTPResponse62748825.h"

// System.Action`2<BestHTTP.ServerSentEvents.EventSourceResponse,BestHTTP.ServerSentEvents.Message>
struct Action_2_t172185580;
// System.Action`1<BestHTTP.ServerSentEvents.EventSourceResponse>
struct Action_1_t2089201726;
// System.Object
struct Il2CppObject;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// BestHTTP.ServerSentEvents.Message
struct Message_t1650395211;
// System.Collections.Generic.List`1<BestHTTP.ServerSentEvents.Message>
struct List_1_t1019516343;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.ServerSentEvents.EventSourceResponse
struct  EventSourceResponse_t2287402344  : public HTTPResponse_t62748825
{
public:
	// System.Boolean BestHTTP.ServerSentEvents.EventSourceResponse::<IsClosed>k__BackingField
	bool ___U3CIsClosedU3Ek__BackingField_25;
	// System.Action`2<BestHTTP.ServerSentEvents.EventSourceResponse,BestHTTP.ServerSentEvents.Message> BestHTTP.ServerSentEvents.EventSourceResponse::OnMessage
	Action_2_t172185580 * ___OnMessage_26;
	// System.Action`1<BestHTTP.ServerSentEvents.EventSourceResponse> BestHTTP.ServerSentEvents.EventSourceResponse::OnClosed
	Action_1_t2089201726 * ___OnClosed_27;
	// System.Object BestHTTP.ServerSentEvents.EventSourceResponse::FrameLock
	Il2CppObject * ___FrameLock_28;
	// System.Byte[] BestHTTP.ServerSentEvents.EventSourceResponse::LineBuffer
	ByteU5BU5D_t3397334013* ___LineBuffer_29;
	// System.Int32 BestHTTP.ServerSentEvents.EventSourceResponse::LineBufferPos
	int32_t ___LineBufferPos_30;
	// BestHTTP.ServerSentEvents.Message BestHTTP.ServerSentEvents.EventSourceResponse::CurrentMessage
	Message_t1650395211 * ___CurrentMessage_31;
	// System.Collections.Generic.List`1<BestHTTP.ServerSentEvents.Message> BestHTTP.ServerSentEvents.EventSourceResponse::CompletedMessages
	List_1_t1019516343 * ___CompletedMessages_32;

public:
	inline static int32_t get_offset_of_U3CIsClosedU3Ek__BackingField_25() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___U3CIsClosedU3Ek__BackingField_25)); }
	inline bool get_U3CIsClosedU3Ek__BackingField_25() const { return ___U3CIsClosedU3Ek__BackingField_25; }
	inline bool* get_address_of_U3CIsClosedU3Ek__BackingField_25() { return &___U3CIsClosedU3Ek__BackingField_25; }
	inline void set_U3CIsClosedU3Ek__BackingField_25(bool value)
	{
		___U3CIsClosedU3Ek__BackingField_25 = value;
	}

	inline static int32_t get_offset_of_OnMessage_26() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___OnMessage_26)); }
	inline Action_2_t172185580 * get_OnMessage_26() const { return ___OnMessage_26; }
	inline Action_2_t172185580 ** get_address_of_OnMessage_26() { return &___OnMessage_26; }
	inline void set_OnMessage_26(Action_2_t172185580 * value)
	{
		___OnMessage_26 = value;
		Il2CppCodeGenWriteBarrier(&___OnMessage_26, value);
	}

	inline static int32_t get_offset_of_OnClosed_27() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___OnClosed_27)); }
	inline Action_1_t2089201726 * get_OnClosed_27() const { return ___OnClosed_27; }
	inline Action_1_t2089201726 ** get_address_of_OnClosed_27() { return &___OnClosed_27; }
	inline void set_OnClosed_27(Action_1_t2089201726 * value)
	{
		___OnClosed_27 = value;
		Il2CppCodeGenWriteBarrier(&___OnClosed_27, value);
	}

	inline static int32_t get_offset_of_FrameLock_28() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___FrameLock_28)); }
	inline Il2CppObject * get_FrameLock_28() const { return ___FrameLock_28; }
	inline Il2CppObject ** get_address_of_FrameLock_28() { return &___FrameLock_28; }
	inline void set_FrameLock_28(Il2CppObject * value)
	{
		___FrameLock_28 = value;
		Il2CppCodeGenWriteBarrier(&___FrameLock_28, value);
	}

	inline static int32_t get_offset_of_LineBuffer_29() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___LineBuffer_29)); }
	inline ByteU5BU5D_t3397334013* get_LineBuffer_29() const { return ___LineBuffer_29; }
	inline ByteU5BU5D_t3397334013** get_address_of_LineBuffer_29() { return &___LineBuffer_29; }
	inline void set_LineBuffer_29(ByteU5BU5D_t3397334013* value)
	{
		___LineBuffer_29 = value;
		Il2CppCodeGenWriteBarrier(&___LineBuffer_29, value);
	}

	inline static int32_t get_offset_of_LineBufferPos_30() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___LineBufferPos_30)); }
	inline int32_t get_LineBufferPos_30() const { return ___LineBufferPos_30; }
	inline int32_t* get_address_of_LineBufferPos_30() { return &___LineBufferPos_30; }
	inline void set_LineBufferPos_30(int32_t value)
	{
		___LineBufferPos_30 = value;
	}

	inline static int32_t get_offset_of_CurrentMessage_31() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___CurrentMessage_31)); }
	inline Message_t1650395211 * get_CurrentMessage_31() const { return ___CurrentMessage_31; }
	inline Message_t1650395211 ** get_address_of_CurrentMessage_31() { return &___CurrentMessage_31; }
	inline void set_CurrentMessage_31(Message_t1650395211 * value)
	{
		___CurrentMessage_31 = value;
		Il2CppCodeGenWriteBarrier(&___CurrentMessage_31, value);
	}

	inline static int32_t get_offset_of_CompletedMessages_32() { return static_cast<int32_t>(offsetof(EventSourceResponse_t2287402344, ___CompletedMessages_32)); }
	inline List_1_t1019516343 * get_CompletedMessages_32() const { return ___CompletedMessages_32; }
	inline List_1_t1019516343 ** get_address_of_CompletedMessages_32() { return &___CompletedMessages_32; }
	inline void set_CompletedMessages_32(List_1_t1019516343 * value)
	{
		___CompletedMessages_32 = value;
		Il2CppCodeGenWriteBarrier(&___CompletedMessages_32, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
