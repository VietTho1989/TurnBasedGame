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
#include "mscorlib_System_TimeSpan3430258949.h"

// System.String
struct String_t;
// System.Action`1<BestHTTP.SignalR.NegotiationData>
struct Action_1_t2860820189;
// System.Action`2<BestHTTP.SignalR.NegotiationData,System.String>
struct Action_2_t1785747759;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// BestHTTP.SignalR.IConnection
struct IConnection_t313572887;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.NegotiationData
struct  NegotiationData_t3059020807  : public Il2CppObject
{
public:
	// System.String BestHTTP.SignalR.NegotiationData::<Url>k__BackingField
	String_t* ___U3CUrlU3Ek__BackingField_0;
	// System.String BestHTTP.SignalR.NegotiationData::<WebSocketServerUrl>k__BackingField
	String_t* ___U3CWebSocketServerUrlU3Ek__BackingField_1;
	// System.String BestHTTP.SignalR.NegotiationData::<ConnectionToken>k__BackingField
	String_t* ___U3CConnectionTokenU3Ek__BackingField_2;
	// System.String BestHTTP.SignalR.NegotiationData::<ConnectionId>k__BackingField
	String_t* ___U3CConnectionIdU3Ek__BackingField_3;
	// System.Nullable`1<System.TimeSpan> BestHTTP.SignalR.NegotiationData::<KeepAliveTimeout>k__BackingField
	Nullable_1_t1693325264  ___U3CKeepAliveTimeoutU3Ek__BackingField_4;
	// System.TimeSpan BestHTTP.SignalR.NegotiationData::<DisconnectTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CDisconnectTimeoutU3Ek__BackingField_5;
	// System.TimeSpan BestHTTP.SignalR.NegotiationData::<ConnectionTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CConnectionTimeoutU3Ek__BackingField_6;
	// System.Boolean BestHTTP.SignalR.NegotiationData::<TryWebSockets>k__BackingField
	bool ___U3CTryWebSocketsU3Ek__BackingField_7;
	// System.String BestHTTP.SignalR.NegotiationData::<ProtocolVersion>k__BackingField
	String_t* ___U3CProtocolVersionU3Ek__BackingField_8;
	// System.TimeSpan BestHTTP.SignalR.NegotiationData::<TransportConnectTimeout>k__BackingField
	TimeSpan_t3430258949  ___U3CTransportConnectTimeoutU3Ek__BackingField_9;
	// System.TimeSpan BestHTTP.SignalR.NegotiationData::<LongPollDelay>k__BackingField
	TimeSpan_t3430258949  ___U3CLongPollDelayU3Ek__BackingField_10;
	// System.Action`1<BestHTTP.SignalR.NegotiationData> BestHTTP.SignalR.NegotiationData::OnReceived
	Action_1_t2860820189 * ___OnReceived_11;
	// System.Action`2<BestHTTP.SignalR.NegotiationData,System.String> BestHTTP.SignalR.NegotiationData::OnError
	Action_2_t1785747759 * ___OnError_12;
	// BestHTTP.HTTPRequest BestHTTP.SignalR.NegotiationData::NegotiationRequest
	HTTPRequest_t138485887 * ___NegotiationRequest_13;
	// BestHTTP.SignalR.IConnection BestHTTP.SignalR.NegotiationData::Connection
	Il2CppObject * ___Connection_14;

public:
	inline static int32_t get_offset_of_U3CUrlU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CUrlU3Ek__BackingField_0)); }
	inline String_t* get_U3CUrlU3Ek__BackingField_0() const { return ___U3CUrlU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CUrlU3Ek__BackingField_0() { return &___U3CUrlU3Ek__BackingField_0; }
	inline void set_U3CUrlU3Ek__BackingField_0(String_t* value)
	{
		___U3CUrlU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUrlU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CWebSocketServerUrlU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CWebSocketServerUrlU3Ek__BackingField_1)); }
	inline String_t* get_U3CWebSocketServerUrlU3Ek__BackingField_1() const { return ___U3CWebSocketServerUrlU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CWebSocketServerUrlU3Ek__BackingField_1() { return &___U3CWebSocketServerUrlU3Ek__BackingField_1; }
	inline void set_U3CWebSocketServerUrlU3Ek__BackingField_1(String_t* value)
	{
		___U3CWebSocketServerUrlU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CWebSocketServerUrlU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CConnectionTokenU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CConnectionTokenU3Ek__BackingField_2)); }
	inline String_t* get_U3CConnectionTokenU3Ek__BackingField_2() const { return ___U3CConnectionTokenU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CConnectionTokenU3Ek__BackingField_2() { return &___U3CConnectionTokenU3Ek__BackingField_2; }
	inline void set_U3CConnectionTokenU3Ek__BackingField_2(String_t* value)
	{
		___U3CConnectionTokenU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CConnectionTokenU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CConnectionIdU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CConnectionIdU3Ek__BackingField_3)); }
	inline String_t* get_U3CConnectionIdU3Ek__BackingField_3() const { return ___U3CConnectionIdU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CConnectionIdU3Ek__BackingField_3() { return &___U3CConnectionIdU3Ek__BackingField_3; }
	inline void set_U3CConnectionIdU3Ek__BackingField_3(String_t* value)
	{
		___U3CConnectionIdU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CConnectionIdU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CKeepAliveTimeoutU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CKeepAliveTimeoutU3Ek__BackingField_4)); }
	inline Nullable_1_t1693325264  get_U3CKeepAliveTimeoutU3Ek__BackingField_4() const { return ___U3CKeepAliveTimeoutU3Ek__BackingField_4; }
	inline Nullable_1_t1693325264 * get_address_of_U3CKeepAliveTimeoutU3Ek__BackingField_4() { return &___U3CKeepAliveTimeoutU3Ek__BackingField_4; }
	inline void set_U3CKeepAliveTimeoutU3Ek__BackingField_4(Nullable_1_t1693325264  value)
	{
		___U3CKeepAliveTimeoutU3Ek__BackingField_4 = value;
	}

	inline static int32_t get_offset_of_U3CDisconnectTimeoutU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CDisconnectTimeoutU3Ek__BackingField_5)); }
	inline TimeSpan_t3430258949  get_U3CDisconnectTimeoutU3Ek__BackingField_5() const { return ___U3CDisconnectTimeoutU3Ek__BackingField_5; }
	inline TimeSpan_t3430258949 * get_address_of_U3CDisconnectTimeoutU3Ek__BackingField_5() { return &___U3CDisconnectTimeoutU3Ek__BackingField_5; }
	inline void set_U3CDisconnectTimeoutU3Ek__BackingField_5(TimeSpan_t3430258949  value)
	{
		___U3CDisconnectTimeoutU3Ek__BackingField_5 = value;
	}

	inline static int32_t get_offset_of_U3CConnectionTimeoutU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CConnectionTimeoutU3Ek__BackingField_6)); }
	inline TimeSpan_t3430258949  get_U3CConnectionTimeoutU3Ek__BackingField_6() const { return ___U3CConnectionTimeoutU3Ek__BackingField_6; }
	inline TimeSpan_t3430258949 * get_address_of_U3CConnectionTimeoutU3Ek__BackingField_6() { return &___U3CConnectionTimeoutU3Ek__BackingField_6; }
	inline void set_U3CConnectionTimeoutU3Ek__BackingField_6(TimeSpan_t3430258949  value)
	{
		___U3CConnectionTimeoutU3Ek__BackingField_6 = value;
	}

	inline static int32_t get_offset_of_U3CTryWebSocketsU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CTryWebSocketsU3Ek__BackingField_7)); }
	inline bool get_U3CTryWebSocketsU3Ek__BackingField_7() const { return ___U3CTryWebSocketsU3Ek__BackingField_7; }
	inline bool* get_address_of_U3CTryWebSocketsU3Ek__BackingField_7() { return &___U3CTryWebSocketsU3Ek__BackingField_7; }
	inline void set_U3CTryWebSocketsU3Ek__BackingField_7(bool value)
	{
		___U3CTryWebSocketsU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CProtocolVersionU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CProtocolVersionU3Ek__BackingField_8)); }
	inline String_t* get_U3CProtocolVersionU3Ek__BackingField_8() const { return ___U3CProtocolVersionU3Ek__BackingField_8; }
	inline String_t** get_address_of_U3CProtocolVersionU3Ek__BackingField_8() { return &___U3CProtocolVersionU3Ek__BackingField_8; }
	inline void set_U3CProtocolVersionU3Ek__BackingField_8(String_t* value)
	{
		___U3CProtocolVersionU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProtocolVersionU3Ek__BackingField_8, value);
	}

	inline static int32_t get_offset_of_U3CTransportConnectTimeoutU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CTransportConnectTimeoutU3Ek__BackingField_9)); }
	inline TimeSpan_t3430258949  get_U3CTransportConnectTimeoutU3Ek__BackingField_9() const { return ___U3CTransportConnectTimeoutU3Ek__BackingField_9; }
	inline TimeSpan_t3430258949 * get_address_of_U3CTransportConnectTimeoutU3Ek__BackingField_9() { return &___U3CTransportConnectTimeoutU3Ek__BackingField_9; }
	inline void set_U3CTransportConnectTimeoutU3Ek__BackingField_9(TimeSpan_t3430258949  value)
	{
		___U3CTransportConnectTimeoutU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_U3CLongPollDelayU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___U3CLongPollDelayU3Ek__BackingField_10)); }
	inline TimeSpan_t3430258949  get_U3CLongPollDelayU3Ek__BackingField_10() const { return ___U3CLongPollDelayU3Ek__BackingField_10; }
	inline TimeSpan_t3430258949 * get_address_of_U3CLongPollDelayU3Ek__BackingField_10() { return &___U3CLongPollDelayU3Ek__BackingField_10; }
	inline void set_U3CLongPollDelayU3Ek__BackingField_10(TimeSpan_t3430258949  value)
	{
		___U3CLongPollDelayU3Ek__BackingField_10 = value;
	}

	inline static int32_t get_offset_of_OnReceived_11() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___OnReceived_11)); }
	inline Action_1_t2860820189 * get_OnReceived_11() const { return ___OnReceived_11; }
	inline Action_1_t2860820189 ** get_address_of_OnReceived_11() { return &___OnReceived_11; }
	inline void set_OnReceived_11(Action_1_t2860820189 * value)
	{
		___OnReceived_11 = value;
		Il2CppCodeGenWriteBarrier(&___OnReceived_11, value);
	}

	inline static int32_t get_offset_of_OnError_12() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___OnError_12)); }
	inline Action_2_t1785747759 * get_OnError_12() const { return ___OnError_12; }
	inline Action_2_t1785747759 ** get_address_of_OnError_12() { return &___OnError_12; }
	inline void set_OnError_12(Action_2_t1785747759 * value)
	{
		___OnError_12 = value;
		Il2CppCodeGenWriteBarrier(&___OnError_12, value);
	}

	inline static int32_t get_offset_of_NegotiationRequest_13() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___NegotiationRequest_13)); }
	inline HTTPRequest_t138485887 * get_NegotiationRequest_13() const { return ___NegotiationRequest_13; }
	inline HTTPRequest_t138485887 ** get_address_of_NegotiationRequest_13() { return &___NegotiationRequest_13; }
	inline void set_NegotiationRequest_13(HTTPRequest_t138485887 * value)
	{
		___NegotiationRequest_13 = value;
		Il2CppCodeGenWriteBarrier(&___NegotiationRequest_13, value);
	}

	inline static int32_t get_offset_of_Connection_14() { return static_cast<int32_t>(offsetof(NegotiationData_t3059020807, ___Connection_14)); }
	inline Il2CppObject * get_Connection_14() const { return ___Connection_14; }
	inline Il2CppObject ** get_address_of_Connection_14() { return &___Connection_14; }
	inline void set_Connection_14(Il2CppObject * value)
	{
		___Connection_14 = value;
		Il2CppCodeGenWriteBarrier(&___Connection_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
