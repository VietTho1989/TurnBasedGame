#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// BestHTTP.WebSocket.OnWebSocketOpenDelegate
struct OnWebSocketOpenDelegate_t4018547189;
// BestHTTP.WebSocket.OnWebSocketMessageDelegate
struct OnWebSocketMessageDelegate_t730459590;
// BestHTTP.WebSocket.OnWebSocketBinaryDelegate
struct OnWebSocketBinaryDelegate_t3919072826;
// BestHTTP.WebSocket.OnWebSocketClosedDelegate
struct OnWebSocketClosedDelegate_t2679686585;
// BestHTTP.WebSocket.OnWebSocketErrorDelegate
struct OnWebSocketErrorDelegate_t1328789641;
// BestHTTP.WebSocket.OnWebSocketErrorDescriptionDelegate
struct OnWebSocketErrorDescriptionDelegate_t2599777013;
// BestHTTP.WebSocket.OnWebSocketIncompleteFrameDelegate
struct OnWebSocketIncompleteFrameDelegate_t2035490966;
// BestHTTP.WebSocket.WebSocketResponse
struct WebSocketResponse_t3376763264;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.WebSocket.WebSocket
struct  WebSocket_t71448861  : public Il2CppObject
{
public:
	// System.Boolean BestHTTP.WebSocket.WebSocket::<StartPingThread>k__BackingField
	bool ___U3CStartPingThreadU3Ek__BackingField_0;
	// System.Int32 BestHTTP.WebSocket.WebSocket::<PingFrequency>k__BackingField
	int32_t ___U3CPingFrequencyU3Ek__BackingField_1;
	// BestHTTP.HTTPRequest BestHTTP.WebSocket.WebSocket::<InternalRequest>k__BackingField
	HTTPRequest_t138485887 * ___U3CInternalRequestU3Ek__BackingField_2;
	// BestHTTP.WebSocket.OnWebSocketOpenDelegate BestHTTP.WebSocket.WebSocket::OnOpen
	OnWebSocketOpenDelegate_t4018547189 * ___OnOpen_3;
	// BestHTTP.WebSocket.OnWebSocketMessageDelegate BestHTTP.WebSocket.WebSocket::OnMessage
	OnWebSocketMessageDelegate_t730459590 * ___OnMessage_4;
	// BestHTTP.WebSocket.OnWebSocketBinaryDelegate BestHTTP.WebSocket.WebSocket::OnBinary
	OnWebSocketBinaryDelegate_t3919072826 * ___OnBinary_5;
	// BestHTTP.WebSocket.OnWebSocketClosedDelegate BestHTTP.WebSocket.WebSocket::OnClosed
	OnWebSocketClosedDelegate_t2679686585 * ___OnClosed_6;
	// BestHTTP.WebSocket.OnWebSocketErrorDelegate BestHTTP.WebSocket.WebSocket::OnError
	OnWebSocketErrorDelegate_t1328789641 * ___OnError_7;
	// BestHTTP.WebSocket.OnWebSocketErrorDescriptionDelegate BestHTTP.WebSocket.WebSocket::OnErrorDesc
	OnWebSocketErrorDescriptionDelegate_t2599777013 * ___OnErrorDesc_8;
	// BestHTTP.WebSocket.OnWebSocketIncompleteFrameDelegate BestHTTP.WebSocket.WebSocket::OnIncompleteFrame
	OnWebSocketIncompleteFrameDelegate_t2035490966 * ___OnIncompleteFrame_9;
	// System.Boolean BestHTTP.WebSocket.WebSocket::requestSent
	bool ___requestSent_10;
	// BestHTTP.WebSocket.WebSocketResponse BestHTTP.WebSocket.WebSocket::webSocket
	WebSocketResponse_t3376763264 * ___webSocket_11;

public:
	inline static int32_t get_offset_of_U3CStartPingThreadU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___U3CStartPingThreadU3Ek__BackingField_0)); }
	inline bool get_U3CStartPingThreadU3Ek__BackingField_0() const { return ___U3CStartPingThreadU3Ek__BackingField_0; }
	inline bool* get_address_of_U3CStartPingThreadU3Ek__BackingField_0() { return &___U3CStartPingThreadU3Ek__BackingField_0; }
	inline void set_U3CStartPingThreadU3Ek__BackingField_0(bool value)
	{
		___U3CStartPingThreadU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CPingFrequencyU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___U3CPingFrequencyU3Ek__BackingField_1)); }
	inline int32_t get_U3CPingFrequencyU3Ek__BackingField_1() const { return ___U3CPingFrequencyU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CPingFrequencyU3Ek__BackingField_1() { return &___U3CPingFrequencyU3Ek__BackingField_1; }
	inline void set_U3CPingFrequencyU3Ek__BackingField_1(int32_t value)
	{
		___U3CPingFrequencyU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CInternalRequestU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___U3CInternalRequestU3Ek__BackingField_2)); }
	inline HTTPRequest_t138485887 * get_U3CInternalRequestU3Ek__BackingField_2() const { return ___U3CInternalRequestU3Ek__BackingField_2; }
	inline HTTPRequest_t138485887 ** get_address_of_U3CInternalRequestU3Ek__BackingField_2() { return &___U3CInternalRequestU3Ek__BackingField_2; }
	inline void set_U3CInternalRequestU3Ek__BackingField_2(HTTPRequest_t138485887 * value)
	{
		___U3CInternalRequestU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CInternalRequestU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_OnOpen_3() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnOpen_3)); }
	inline OnWebSocketOpenDelegate_t4018547189 * get_OnOpen_3() const { return ___OnOpen_3; }
	inline OnWebSocketOpenDelegate_t4018547189 ** get_address_of_OnOpen_3() { return &___OnOpen_3; }
	inline void set_OnOpen_3(OnWebSocketOpenDelegate_t4018547189 * value)
	{
		___OnOpen_3 = value;
		Il2CppCodeGenWriteBarrier(&___OnOpen_3, value);
	}

	inline static int32_t get_offset_of_OnMessage_4() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnMessage_4)); }
	inline OnWebSocketMessageDelegate_t730459590 * get_OnMessage_4() const { return ___OnMessage_4; }
	inline OnWebSocketMessageDelegate_t730459590 ** get_address_of_OnMessage_4() { return &___OnMessage_4; }
	inline void set_OnMessage_4(OnWebSocketMessageDelegate_t730459590 * value)
	{
		___OnMessage_4 = value;
		Il2CppCodeGenWriteBarrier(&___OnMessage_4, value);
	}

	inline static int32_t get_offset_of_OnBinary_5() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnBinary_5)); }
	inline OnWebSocketBinaryDelegate_t3919072826 * get_OnBinary_5() const { return ___OnBinary_5; }
	inline OnWebSocketBinaryDelegate_t3919072826 ** get_address_of_OnBinary_5() { return &___OnBinary_5; }
	inline void set_OnBinary_5(OnWebSocketBinaryDelegate_t3919072826 * value)
	{
		___OnBinary_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnBinary_5, value);
	}

	inline static int32_t get_offset_of_OnClosed_6() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnClosed_6)); }
	inline OnWebSocketClosedDelegate_t2679686585 * get_OnClosed_6() const { return ___OnClosed_6; }
	inline OnWebSocketClosedDelegate_t2679686585 ** get_address_of_OnClosed_6() { return &___OnClosed_6; }
	inline void set_OnClosed_6(OnWebSocketClosedDelegate_t2679686585 * value)
	{
		___OnClosed_6 = value;
		Il2CppCodeGenWriteBarrier(&___OnClosed_6, value);
	}

	inline static int32_t get_offset_of_OnError_7() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnError_7)); }
	inline OnWebSocketErrorDelegate_t1328789641 * get_OnError_7() const { return ___OnError_7; }
	inline OnWebSocketErrorDelegate_t1328789641 ** get_address_of_OnError_7() { return &___OnError_7; }
	inline void set_OnError_7(OnWebSocketErrorDelegate_t1328789641 * value)
	{
		___OnError_7 = value;
		Il2CppCodeGenWriteBarrier(&___OnError_7, value);
	}

	inline static int32_t get_offset_of_OnErrorDesc_8() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnErrorDesc_8)); }
	inline OnWebSocketErrorDescriptionDelegate_t2599777013 * get_OnErrorDesc_8() const { return ___OnErrorDesc_8; }
	inline OnWebSocketErrorDescriptionDelegate_t2599777013 ** get_address_of_OnErrorDesc_8() { return &___OnErrorDesc_8; }
	inline void set_OnErrorDesc_8(OnWebSocketErrorDescriptionDelegate_t2599777013 * value)
	{
		___OnErrorDesc_8 = value;
		Il2CppCodeGenWriteBarrier(&___OnErrorDesc_8, value);
	}

	inline static int32_t get_offset_of_OnIncompleteFrame_9() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___OnIncompleteFrame_9)); }
	inline OnWebSocketIncompleteFrameDelegate_t2035490966 * get_OnIncompleteFrame_9() const { return ___OnIncompleteFrame_9; }
	inline OnWebSocketIncompleteFrameDelegate_t2035490966 ** get_address_of_OnIncompleteFrame_9() { return &___OnIncompleteFrame_9; }
	inline void set_OnIncompleteFrame_9(OnWebSocketIncompleteFrameDelegate_t2035490966 * value)
	{
		___OnIncompleteFrame_9 = value;
		Il2CppCodeGenWriteBarrier(&___OnIncompleteFrame_9, value);
	}

	inline static int32_t get_offset_of_requestSent_10() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___requestSent_10)); }
	inline bool get_requestSent_10() const { return ___requestSent_10; }
	inline bool* get_address_of_requestSent_10() { return &___requestSent_10; }
	inline void set_requestSent_10(bool value)
	{
		___requestSent_10 = value;
	}

	inline static int32_t get_offset_of_webSocket_11() { return static_cast<int32_t>(offsetof(WebSocket_t71448861, ___webSocket_11)); }
	inline WebSocketResponse_t3376763264 * get_webSocket_11() const { return ___webSocket_11; }
	inline WebSocketResponse_t3376763264 ** get_address_of_webSocket_11() { return &___webSocket_11; }
	inline void set_webSocket_11(WebSocketResponse_t3376763264 * value)
	{
		___webSocket_11 = value;
		Il2CppCodeGenWriteBarrier(&___webSocket_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
