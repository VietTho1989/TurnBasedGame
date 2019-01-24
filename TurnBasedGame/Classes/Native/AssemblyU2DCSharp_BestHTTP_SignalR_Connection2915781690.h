#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_SignalR_ConnectionStates420400692.h"
#include "AssemblyU2DCSharp_BestHTTP_SignalR_ProtocolVersion4229923159.h"
#include "mscorlib_System_DateTime693205669.h"
#include "mscorlib_System_TimeSpan3430258949.h"
#include "mscorlib_System_Nullable_1_gen3251239280.h"
#include "AssemblyU2DCSharp_BestHTTP_SupportedProtocols1503488249.h"

// BestHTTP.SignalR.JsonEncoders.IJsonEncoder
struct IJsonEncoder_t2969913559;
// System.Uri
struct Uri_t19570940;
// BestHTTP.SignalR.NegotiationData
struct NegotiationData_t3059020807;
// BestHTTP.SignalR.Hubs.Hub[]
struct HubU5BU5D_t767056102;
// BestHTTP.SignalR.Transports.TransportBase
struct TransportBase_t148904526;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;
// BestHTTP.SignalR.Authentication.IAuthenticationProvider
struct IAuthenticationProvider_t675015388;
// BestHTTP.SignalR.OnConnectedDelegate
struct OnConnectedDelegate_t3283761253;
// BestHTTP.SignalR.OnClosedDelegate
struct OnClosedDelegate_t587495364;
// BestHTTP.SignalR.OnErrorDelegate
struct OnErrorDelegate_t3605384424;
// BestHTTP.SignalR.OnStateChanged
struct OnStateChanged_t3950199048;
// BestHTTP.SignalR.OnNonHubMessageDelegate
struct OnNonHubMessageDelegate_t1922405057;
// BestHTTP.SignalR.OnPrepareRequestDelegate
struct OnPrepareRequestDelegate_t3434123680;
// System.Object
struct Il2CppObject;
// System.String[]
struct StringU5BU5D_t1642385972;
// BestHTTP.SignalR.Messages.MultiMessage
struct MultiMessage_t207384742;
// System.String
struct String_t;
// System.Collections.Generic.List`1<BestHTTP.SignalR.Messages.IServerMessage>
struct List_1_t1753264875;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Connection
struct  Connection_t2915781690  : public Il2CppObject
{
public:
	// System.Uri BestHTTP.SignalR.Connection::<Uri>k__BackingField
	Uri_t19570940 * ___U3CUriU3Ek__BackingField_1;
	// BestHTTP.SignalR.ConnectionStates BestHTTP.SignalR.Connection::_state
	int32_t ____state_2;
	// BestHTTP.SignalR.NegotiationData BestHTTP.SignalR.Connection::<NegotiationResult>k__BackingField
	NegotiationData_t3059020807 * ___U3CNegotiationResultU3Ek__BackingField_3;
	// BestHTTP.SignalR.Hubs.Hub[] BestHTTP.SignalR.Connection::<Hubs>k__BackingField
	HubU5BU5D_t767056102* ___U3CHubsU3Ek__BackingField_4;
	// BestHTTP.SignalR.Transports.TransportBase BestHTTP.SignalR.Connection::<Transport>k__BackingField
	TransportBase_t148904526 * ___U3CTransportU3Ek__BackingField_5;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> BestHTTP.SignalR.Connection::<AdditionalQueryParams>k__BackingField
	Dictionary_2_t3943999495 * ___U3CAdditionalQueryParamsU3Ek__BackingField_6;
	// System.Boolean BestHTTP.SignalR.Connection::<QueryParamsOnlyForHandshake>k__BackingField
	bool ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7;
	// BestHTTP.SignalR.JsonEncoders.IJsonEncoder BestHTTP.SignalR.Connection::<JsonEncoder>k__BackingField
	Il2CppObject * ___U3CJsonEncoderU3Ek__BackingField_8;
	// BestHTTP.SignalR.Authentication.IAuthenticationProvider BestHTTP.SignalR.Connection::<AuthenticationProvider>k__BackingField
	Il2CppObject * ___U3CAuthenticationProviderU3Ek__BackingField_9;
	// BestHTTP.SignalR.OnConnectedDelegate BestHTTP.SignalR.Connection::OnConnected
	OnConnectedDelegate_t3283761253 * ___OnConnected_10;
	// BestHTTP.SignalR.OnClosedDelegate BestHTTP.SignalR.Connection::OnClosed
	OnClosedDelegate_t587495364 * ___OnClosed_11;
	// BestHTTP.SignalR.OnErrorDelegate BestHTTP.SignalR.Connection::OnError
	OnErrorDelegate_t3605384424 * ___OnError_12;
	// BestHTTP.SignalR.OnConnectedDelegate BestHTTP.SignalR.Connection::OnReconnecting
	OnConnectedDelegate_t3283761253 * ___OnReconnecting_13;
	// BestHTTP.SignalR.OnConnectedDelegate BestHTTP.SignalR.Connection::OnReconnected
	OnConnectedDelegate_t3283761253 * ___OnReconnected_14;
	// BestHTTP.SignalR.OnStateChanged BestHTTP.SignalR.Connection::OnStateChanged
	OnStateChanged_t3950199048 * ___OnStateChanged_15;
	// BestHTTP.SignalR.OnNonHubMessageDelegate BestHTTP.SignalR.Connection::OnNonHubMessage
	OnNonHubMessageDelegate_t1922405057 * ___OnNonHubMessage_16;
	// BestHTTP.SignalR.OnPrepareRequestDelegate BestHTTP.SignalR.Connection::<RequestPreparator>k__BackingField
	OnPrepareRequestDelegate_t3434123680 * ___U3CRequestPreparatorU3Ek__BackingField_17;
	// BestHTTP.SignalR.ProtocolVersions BestHTTP.SignalR.Connection::<Protocol>k__BackingField
	uint8_t ___U3CProtocolU3Ek__BackingField_18;
	// System.Object BestHTTP.SignalR.Connection::SyncRoot
	Il2CppObject * ___SyncRoot_19;
	// System.UInt64 BestHTTP.SignalR.Connection::<ClientMessageCounter>k__BackingField
	uint64_t ___U3CClientMessageCounterU3Ek__BackingField_20;
	// System.String[] BestHTTP.SignalR.Connection::ClientProtocols
	StringU5BU5D_t1642385972* ___ClientProtocols_21;
	// System.UInt64 BestHTTP.SignalR.Connection::RequestCounter
	uint64_t ___RequestCounter_22;
	// BestHTTP.SignalR.Messages.MultiMessage BestHTTP.SignalR.Connection::LastReceivedMessage
	MultiMessage_t207384742 * ___LastReceivedMessage_23;
	// System.String BestHTTP.SignalR.Connection::GroupsToken
	String_t* ___GroupsToken_24;
	// System.Collections.Generic.List`1<BestHTTP.SignalR.Messages.IServerMessage> BestHTTP.SignalR.Connection::BufferedMessages
	List_1_t1753264875 * ___BufferedMessages_25;
	// System.DateTime BestHTTP.SignalR.Connection::LastMessageReceivedAt
	DateTime_t693205669  ___LastMessageReceivedAt_26;
	// System.DateTime BestHTTP.SignalR.Connection::ReconnectStartedAt
	DateTime_t693205669  ___ReconnectStartedAt_27;
	// System.Boolean BestHTTP.SignalR.Connection::ReconnectStarted
	bool ___ReconnectStarted_28;
	// System.DateTime BestHTTP.SignalR.Connection::LastPingSentAt
	DateTime_t693205669  ___LastPingSentAt_29;
	// System.TimeSpan BestHTTP.SignalR.Connection::PingInterval
	TimeSpan_t3430258949  ___PingInterval_30;
	// BestHTTP.HTTPRequest BestHTTP.SignalR.Connection::PingRequest
	HTTPRequest_t138485887 * ___PingRequest_31;
	// System.Nullable`1<System.DateTime> BestHTTP.SignalR.Connection::TransportConnectionStartedAt
	Nullable_1_t3251239280  ___TransportConnectionStartedAt_32;
	// System.Text.StringBuilder BestHTTP.SignalR.Connection::queryBuilder
	StringBuilder_t1221177846 * ___queryBuilder_33;
	// System.String BestHTTP.SignalR.Connection::BuiltConnectionData
	String_t* ___BuiltConnectionData_34;
	// System.String BestHTTP.SignalR.Connection::BuiltQueryParams
	String_t* ___BuiltQueryParams_35;
	// BestHTTP.SupportedProtocols BestHTTP.SignalR.Connection::NextProtocolToTry
	int32_t ___NextProtocolToTry_36;

public:
	inline static int32_t get_offset_of_U3CUriU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CUriU3Ek__BackingField_1)); }
	inline Uri_t19570940 * get_U3CUriU3Ek__BackingField_1() const { return ___U3CUriU3Ek__BackingField_1; }
	inline Uri_t19570940 ** get_address_of_U3CUriU3Ek__BackingField_1() { return &___U3CUriU3Ek__BackingField_1; }
	inline void set_U3CUriU3Ek__BackingField_1(Uri_t19570940 * value)
	{
		___U3CUriU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUriU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of__state_2() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ____state_2)); }
	inline int32_t get__state_2() const { return ____state_2; }
	inline int32_t* get_address_of__state_2() { return &____state_2; }
	inline void set__state_2(int32_t value)
	{
		____state_2 = value;
	}

	inline static int32_t get_offset_of_U3CNegotiationResultU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CNegotiationResultU3Ek__BackingField_3)); }
	inline NegotiationData_t3059020807 * get_U3CNegotiationResultU3Ek__BackingField_3() const { return ___U3CNegotiationResultU3Ek__BackingField_3; }
	inline NegotiationData_t3059020807 ** get_address_of_U3CNegotiationResultU3Ek__BackingField_3() { return &___U3CNegotiationResultU3Ek__BackingField_3; }
	inline void set_U3CNegotiationResultU3Ek__BackingField_3(NegotiationData_t3059020807 * value)
	{
		___U3CNegotiationResultU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNegotiationResultU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CHubsU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CHubsU3Ek__BackingField_4)); }
	inline HubU5BU5D_t767056102* get_U3CHubsU3Ek__BackingField_4() const { return ___U3CHubsU3Ek__BackingField_4; }
	inline HubU5BU5D_t767056102** get_address_of_U3CHubsU3Ek__BackingField_4() { return &___U3CHubsU3Ek__BackingField_4; }
	inline void set_U3CHubsU3Ek__BackingField_4(HubU5BU5D_t767056102* value)
	{
		___U3CHubsU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHubsU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CTransportU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CTransportU3Ek__BackingField_5)); }
	inline TransportBase_t148904526 * get_U3CTransportU3Ek__BackingField_5() const { return ___U3CTransportU3Ek__BackingField_5; }
	inline TransportBase_t148904526 ** get_address_of_U3CTransportU3Ek__BackingField_5() { return &___U3CTransportU3Ek__BackingField_5; }
	inline void set_U3CTransportU3Ek__BackingField_5(TransportBase_t148904526 * value)
	{
		___U3CTransportU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTransportU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CAdditionalQueryParamsU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CAdditionalQueryParamsU3Ek__BackingField_6)); }
	inline Dictionary_2_t3943999495 * get_U3CAdditionalQueryParamsU3Ek__BackingField_6() const { return ___U3CAdditionalQueryParamsU3Ek__BackingField_6; }
	inline Dictionary_2_t3943999495 ** get_address_of_U3CAdditionalQueryParamsU3Ek__BackingField_6() { return &___U3CAdditionalQueryParamsU3Ek__BackingField_6; }
	inline void set_U3CAdditionalQueryParamsU3Ek__BackingField_6(Dictionary_2_t3943999495 * value)
	{
		___U3CAdditionalQueryParamsU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAdditionalQueryParamsU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7)); }
	inline bool get_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7() const { return ___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7; }
	inline bool* get_address_of_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7() { return &___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7; }
	inline void set_U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7(bool value)
	{
		___U3CQueryParamsOnlyForHandshakeU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CJsonEncoderU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CJsonEncoderU3Ek__BackingField_8)); }
	inline Il2CppObject * get_U3CJsonEncoderU3Ek__BackingField_8() const { return ___U3CJsonEncoderU3Ek__BackingField_8; }
	inline Il2CppObject ** get_address_of_U3CJsonEncoderU3Ek__BackingField_8() { return &___U3CJsonEncoderU3Ek__BackingField_8; }
	inline void set_U3CJsonEncoderU3Ek__BackingField_8(Il2CppObject * value)
	{
		___U3CJsonEncoderU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CJsonEncoderU3Ek__BackingField_8, value);
	}

	inline static int32_t get_offset_of_U3CAuthenticationProviderU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CAuthenticationProviderU3Ek__BackingField_9)); }
	inline Il2CppObject * get_U3CAuthenticationProviderU3Ek__BackingField_9() const { return ___U3CAuthenticationProviderU3Ek__BackingField_9; }
	inline Il2CppObject ** get_address_of_U3CAuthenticationProviderU3Ek__BackingField_9() { return &___U3CAuthenticationProviderU3Ek__BackingField_9; }
	inline void set_U3CAuthenticationProviderU3Ek__BackingField_9(Il2CppObject * value)
	{
		___U3CAuthenticationProviderU3Ek__BackingField_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAuthenticationProviderU3Ek__BackingField_9, value);
	}

	inline static int32_t get_offset_of_OnConnected_10() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnConnected_10)); }
	inline OnConnectedDelegate_t3283761253 * get_OnConnected_10() const { return ___OnConnected_10; }
	inline OnConnectedDelegate_t3283761253 ** get_address_of_OnConnected_10() { return &___OnConnected_10; }
	inline void set_OnConnected_10(OnConnectedDelegate_t3283761253 * value)
	{
		___OnConnected_10 = value;
		Il2CppCodeGenWriteBarrier(&___OnConnected_10, value);
	}

	inline static int32_t get_offset_of_OnClosed_11() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnClosed_11)); }
	inline OnClosedDelegate_t587495364 * get_OnClosed_11() const { return ___OnClosed_11; }
	inline OnClosedDelegate_t587495364 ** get_address_of_OnClosed_11() { return &___OnClosed_11; }
	inline void set_OnClosed_11(OnClosedDelegate_t587495364 * value)
	{
		___OnClosed_11 = value;
		Il2CppCodeGenWriteBarrier(&___OnClosed_11, value);
	}

	inline static int32_t get_offset_of_OnError_12() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnError_12)); }
	inline OnErrorDelegate_t3605384424 * get_OnError_12() const { return ___OnError_12; }
	inline OnErrorDelegate_t3605384424 ** get_address_of_OnError_12() { return &___OnError_12; }
	inline void set_OnError_12(OnErrorDelegate_t3605384424 * value)
	{
		___OnError_12 = value;
		Il2CppCodeGenWriteBarrier(&___OnError_12, value);
	}

	inline static int32_t get_offset_of_OnReconnecting_13() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnReconnecting_13)); }
	inline OnConnectedDelegate_t3283761253 * get_OnReconnecting_13() const { return ___OnReconnecting_13; }
	inline OnConnectedDelegate_t3283761253 ** get_address_of_OnReconnecting_13() { return &___OnReconnecting_13; }
	inline void set_OnReconnecting_13(OnConnectedDelegate_t3283761253 * value)
	{
		___OnReconnecting_13 = value;
		Il2CppCodeGenWriteBarrier(&___OnReconnecting_13, value);
	}

	inline static int32_t get_offset_of_OnReconnected_14() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnReconnected_14)); }
	inline OnConnectedDelegate_t3283761253 * get_OnReconnected_14() const { return ___OnReconnected_14; }
	inline OnConnectedDelegate_t3283761253 ** get_address_of_OnReconnected_14() { return &___OnReconnected_14; }
	inline void set_OnReconnected_14(OnConnectedDelegate_t3283761253 * value)
	{
		___OnReconnected_14 = value;
		Il2CppCodeGenWriteBarrier(&___OnReconnected_14, value);
	}

	inline static int32_t get_offset_of_OnStateChanged_15() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnStateChanged_15)); }
	inline OnStateChanged_t3950199048 * get_OnStateChanged_15() const { return ___OnStateChanged_15; }
	inline OnStateChanged_t3950199048 ** get_address_of_OnStateChanged_15() { return &___OnStateChanged_15; }
	inline void set_OnStateChanged_15(OnStateChanged_t3950199048 * value)
	{
		___OnStateChanged_15 = value;
		Il2CppCodeGenWriteBarrier(&___OnStateChanged_15, value);
	}

	inline static int32_t get_offset_of_OnNonHubMessage_16() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___OnNonHubMessage_16)); }
	inline OnNonHubMessageDelegate_t1922405057 * get_OnNonHubMessage_16() const { return ___OnNonHubMessage_16; }
	inline OnNonHubMessageDelegate_t1922405057 ** get_address_of_OnNonHubMessage_16() { return &___OnNonHubMessage_16; }
	inline void set_OnNonHubMessage_16(OnNonHubMessageDelegate_t1922405057 * value)
	{
		___OnNonHubMessage_16 = value;
		Il2CppCodeGenWriteBarrier(&___OnNonHubMessage_16, value);
	}

	inline static int32_t get_offset_of_U3CRequestPreparatorU3Ek__BackingField_17() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CRequestPreparatorU3Ek__BackingField_17)); }
	inline OnPrepareRequestDelegate_t3434123680 * get_U3CRequestPreparatorU3Ek__BackingField_17() const { return ___U3CRequestPreparatorU3Ek__BackingField_17; }
	inline OnPrepareRequestDelegate_t3434123680 ** get_address_of_U3CRequestPreparatorU3Ek__BackingField_17() { return &___U3CRequestPreparatorU3Ek__BackingField_17; }
	inline void set_U3CRequestPreparatorU3Ek__BackingField_17(OnPrepareRequestDelegate_t3434123680 * value)
	{
		___U3CRequestPreparatorU3Ek__BackingField_17 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRequestPreparatorU3Ek__BackingField_17, value);
	}

	inline static int32_t get_offset_of_U3CProtocolU3Ek__BackingField_18() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CProtocolU3Ek__BackingField_18)); }
	inline uint8_t get_U3CProtocolU3Ek__BackingField_18() const { return ___U3CProtocolU3Ek__BackingField_18; }
	inline uint8_t* get_address_of_U3CProtocolU3Ek__BackingField_18() { return &___U3CProtocolU3Ek__BackingField_18; }
	inline void set_U3CProtocolU3Ek__BackingField_18(uint8_t value)
	{
		___U3CProtocolU3Ek__BackingField_18 = value;
	}

	inline static int32_t get_offset_of_SyncRoot_19() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___SyncRoot_19)); }
	inline Il2CppObject * get_SyncRoot_19() const { return ___SyncRoot_19; }
	inline Il2CppObject ** get_address_of_SyncRoot_19() { return &___SyncRoot_19; }
	inline void set_SyncRoot_19(Il2CppObject * value)
	{
		___SyncRoot_19 = value;
		Il2CppCodeGenWriteBarrier(&___SyncRoot_19, value);
	}

	inline static int32_t get_offset_of_U3CClientMessageCounterU3Ek__BackingField_20() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___U3CClientMessageCounterU3Ek__BackingField_20)); }
	inline uint64_t get_U3CClientMessageCounterU3Ek__BackingField_20() const { return ___U3CClientMessageCounterU3Ek__BackingField_20; }
	inline uint64_t* get_address_of_U3CClientMessageCounterU3Ek__BackingField_20() { return &___U3CClientMessageCounterU3Ek__BackingField_20; }
	inline void set_U3CClientMessageCounterU3Ek__BackingField_20(uint64_t value)
	{
		___U3CClientMessageCounterU3Ek__BackingField_20 = value;
	}

	inline static int32_t get_offset_of_ClientProtocols_21() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___ClientProtocols_21)); }
	inline StringU5BU5D_t1642385972* get_ClientProtocols_21() const { return ___ClientProtocols_21; }
	inline StringU5BU5D_t1642385972** get_address_of_ClientProtocols_21() { return &___ClientProtocols_21; }
	inline void set_ClientProtocols_21(StringU5BU5D_t1642385972* value)
	{
		___ClientProtocols_21 = value;
		Il2CppCodeGenWriteBarrier(&___ClientProtocols_21, value);
	}

	inline static int32_t get_offset_of_RequestCounter_22() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___RequestCounter_22)); }
	inline uint64_t get_RequestCounter_22() const { return ___RequestCounter_22; }
	inline uint64_t* get_address_of_RequestCounter_22() { return &___RequestCounter_22; }
	inline void set_RequestCounter_22(uint64_t value)
	{
		___RequestCounter_22 = value;
	}

	inline static int32_t get_offset_of_LastReceivedMessage_23() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___LastReceivedMessage_23)); }
	inline MultiMessage_t207384742 * get_LastReceivedMessage_23() const { return ___LastReceivedMessage_23; }
	inline MultiMessage_t207384742 ** get_address_of_LastReceivedMessage_23() { return &___LastReceivedMessage_23; }
	inline void set_LastReceivedMessage_23(MultiMessage_t207384742 * value)
	{
		___LastReceivedMessage_23 = value;
		Il2CppCodeGenWriteBarrier(&___LastReceivedMessage_23, value);
	}

	inline static int32_t get_offset_of_GroupsToken_24() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___GroupsToken_24)); }
	inline String_t* get_GroupsToken_24() const { return ___GroupsToken_24; }
	inline String_t** get_address_of_GroupsToken_24() { return &___GroupsToken_24; }
	inline void set_GroupsToken_24(String_t* value)
	{
		___GroupsToken_24 = value;
		Il2CppCodeGenWriteBarrier(&___GroupsToken_24, value);
	}

	inline static int32_t get_offset_of_BufferedMessages_25() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___BufferedMessages_25)); }
	inline List_1_t1753264875 * get_BufferedMessages_25() const { return ___BufferedMessages_25; }
	inline List_1_t1753264875 ** get_address_of_BufferedMessages_25() { return &___BufferedMessages_25; }
	inline void set_BufferedMessages_25(List_1_t1753264875 * value)
	{
		___BufferedMessages_25 = value;
		Il2CppCodeGenWriteBarrier(&___BufferedMessages_25, value);
	}

	inline static int32_t get_offset_of_LastMessageReceivedAt_26() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___LastMessageReceivedAt_26)); }
	inline DateTime_t693205669  get_LastMessageReceivedAt_26() const { return ___LastMessageReceivedAt_26; }
	inline DateTime_t693205669 * get_address_of_LastMessageReceivedAt_26() { return &___LastMessageReceivedAt_26; }
	inline void set_LastMessageReceivedAt_26(DateTime_t693205669  value)
	{
		___LastMessageReceivedAt_26 = value;
	}

	inline static int32_t get_offset_of_ReconnectStartedAt_27() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___ReconnectStartedAt_27)); }
	inline DateTime_t693205669  get_ReconnectStartedAt_27() const { return ___ReconnectStartedAt_27; }
	inline DateTime_t693205669 * get_address_of_ReconnectStartedAt_27() { return &___ReconnectStartedAt_27; }
	inline void set_ReconnectStartedAt_27(DateTime_t693205669  value)
	{
		___ReconnectStartedAt_27 = value;
	}

	inline static int32_t get_offset_of_ReconnectStarted_28() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___ReconnectStarted_28)); }
	inline bool get_ReconnectStarted_28() const { return ___ReconnectStarted_28; }
	inline bool* get_address_of_ReconnectStarted_28() { return &___ReconnectStarted_28; }
	inline void set_ReconnectStarted_28(bool value)
	{
		___ReconnectStarted_28 = value;
	}

	inline static int32_t get_offset_of_LastPingSentAt_29() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___LastPingSentAt_29)); }
	inline DateTime_t693205669  get_LastPingSentAt_29() const { return ___LastPingSentAt_29; }
	inline DateTime_t693205669 * get_address_of_LastPingSentAt_29() { return &___LastPingSentAt_29; }
	inline void set_LastPingSentAt_29(DateTime_t693205669  value)
	{
		___LastPingSentAt_29 = value;
	}

	inline static int32_t get_offset_of_PingInterval_30() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___PingInterval_30)); }
	inline TimeSpan_t3430258949  get_PingInterval_30() const { return ___PingInterval_30; }
	inline TimeSpan_t3430258949 * get_address_of_PingInterval_30() { return &___PingInterval_30; }
	inline void set_PingInterval_30(TimeSpan_t3430258949  value)
	{
		___PingInterval_30 = value;
	}

	inline static int32_t get_offset_of_PingRequest_31() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___PingRequest_31)); }
	inline HTTPRequest_t138485887 * get_PingRequest_31() const { return ___PingRequest_31; }
	inline HTTPRequest_t138485887 ** get_address_of_PingRequest_31() { return &___PingRequest_31; }
	inline void set_PingRequest_31(HTTPRequest_t138485887 * value)
	{
		___PingRequest_31 = value;
		Il2CppCodeGenWriteBarrier(&___PingRequest_31, value);
	}

	inline static int32_t get_offset_of_TransportConnectionStartedAt_32() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___TransportConnectionStartedAt_32)); }
	inline Nullable_1_t3251239280  get_TransportConnectionStartedAt_32() const { return ___TransportConnectionStartedAt_32; }
	inline Nullable_1_t3251239280 * get_address_of_TransportConnectionStartedAt_32() { return &___TransportConnectionStartedAt_32; }
	inline void set_TransportConnectionStartedAt_32(Nullable_1_t3251239280  value)
	{
		___TransportConnectionStartedAt_32 = value;
	}

	inline static int32_t get_offset_of_queryBuilder_33() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___queryBuilder_33)); }
	inline StringBuilder_t1221177846 * get_queryBuilder_33() const { return ___queryBuilder_33; }
	inline StringBuilder_t1221177846 ** get_address_of_queryBuilder_33() { return &___queryBuilder_33; }
	inline void set_queryBuilder_33(StringBuilder_t1221177846 * value)
	{
		___queryBuilder_33 = value;
		Il2CppCodeGenWriteBarrier(&___queryBuilder_33, value);
	}

	inline static int32_t get_offset_of_BuiltConnectionData_34() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___BuiltConnectionData_34)); }
	inline String_t* get_BuiltConnectionData_34() const { return ___BuiltConnectionData_34; }
	inline String_t** get_address_of_BuiltConnectionData_34() { return &___BuiltConnectionData_34; }
	inline void set_BuiltConnectionData_34(String_t* value)
	{
		___BuiltConnectionData_34 = value;
		Il2CppCodeGenWriteBarrier(&___BuiltConnectionData_34, value);
	}

	inline static int32_t get_offset_of_BuiltQueryParams_35() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___BuiltQueryParams_35)); }
	inline String_t* get_BuiltQueryParams_35() const { return ___BuiltQueryParams_35; }
	inline String_t** get_address_of_BuiltQueryParams_35() { return &___BuiltQueryParams_35; }
	inline void set_BuiltQueryParams_35(String_t* value)
	{
		___BuiltQueryParams_35 = value;
		Il2CppCodeGenWriteBarrier(&___BuiltQueryParams_35, value);
	}

	inline static int32_t get_offset_of_NextProtocolToTry_36() { return static_cast<int32_t>(offsetof(Connection_t2915781690, ___NextProtocolToTry_36)); }
	inline int32_t get_NextProtocolToTry_36() const { return ___NextProtocolToTry_36; }
	inline int32_t* get_address_of_NextProtocolToTry_36() { return &___NextProtocolToTry_36; }
	inline void set_NextProtocolToTry_36(int32_t value)
	{
		___NextProtocolToTry_36 = value;
	}
};

struct Connection_t2915781690_StaticFields
{
public:
	// BestHTTP.SignalR.JsonEncoders.IJsonEncoder BestHTTP.SignalR.Connection::DefaultEncoder
	Il2CppObject * ___DefaultEncoder_0;

public:
	inline static int32_t get_offset_of_DefaultEncoder_0() { return static_cast<int32_t>(offsetof(Connection_t2915781690_StaticFields, ___DefaultEncoder_0)); }
	inline Il2CppObject * get_DefaultEncoder_0() const { return ___DefaultEncoder_0; }
	inline Il2CppObject ** get_address_of_DefaultEncoder_0() { return &___DefaultEncoder_0; }
	inline void set_DefaultEncoder_0(Il2CppObject * value)
	{
		___DefaultEncoder_0 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultEncoder_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
