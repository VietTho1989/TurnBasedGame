#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_ServerSentEvents_States3624480836.h"
#include "mscorlib_System_TimeSpan3430258949.h"
#include "mscorlib_System_DateTime693205669.h"

// System.Uri
struct Uri_t19570940;
// System.String
struct String_t;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// BestHTTP.ServerSentEvents.OnGeneralEventDelegate
struct OnGeneralEventDelegate_t2459579164;
// BestHTTP.ServerSentEvents.OnMessageDelegate
struct OnMessageDelegate_t4204746873;
// BestHTTP.ServerSentEvents.OnErrorDelegate
struct OnErrorDelegate_t676891988;
// BestHTTP.ServerSentEvents.OnRetryDelegate
struct OnRetryDelegate_t1334454456;
// BestHTTP.ServerSentEvents.OnStateChangedDelegate
struct OnStateChangedDelegate_t1222973807;
// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.ServerSentEvents.OnEventDelegate>
struct Dictionary_2_t2705454032;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.ServerSentEvents.EventSource
struct  EventSource_t3924127377  : public Il2CppObject
{
public:
	// System.Uri BestHTTP.ServerSentEvents.EventSource::<Uri>k__BackingField
	Uri_t19570940 * ___U3CUriU3Ek__BackingField_0;
	// BestHTTP.ServerSentEvents.States BestHTTP.ServerSentEvents.EventSource::_state
	int32_t ____state_1;
	// System.TimeSpan BestHTTP.ServerSentEvents.EventSource::<ReconnectionTime>k__BackingField
	TimeSpan_t3430258949  ___U3CReconnectionTimeU3Ek__BackingField_2;
	// System.String BestHTTP.ServerSentEvents.EventSource::<LastEventId>k__BackingField
	String_t* ___U3CLastEventIdU3Ek__BackingField_3;
	// BestHTTP.HTTPRequest BestHTTP.ServerSentEvents.EventSource::<InternalRequest>k__BackingField
	HTTPRequest_t138485887 * ___U3CInternalRequestU3Ek__BackingField_4;
	// BestHTTP.ServerSentEvents.OnGeneralEventDelegate BestHTTP.ServerSentEvents.EventSource::OnOpen
	OnGeneralEventDelegate_t2459579164 * ___OnOpen_5;
	// BestHTTP.ServerSentEvents.OnMessageDelegate BestHTTP.ServerSentEvents.EventSource::OnMessage
	OnMessageDelegate_t4204746873 * ___OnMessage_6;
	// BestHTTP.ServerSentEvents.OnErrorDelegate BestHTTP.ServerSentEvents.EventSource::OnError
	OnErrorDelegate_t676891988 * ___OnError_7;
	// BestHTTP.ServerSentEvents.OnRetryDelegate BestHTTP.ServerSentEvents.EventSource::OnRetry
	OnRetryDelegate_t1334454456 * ___OnRetry_8;
	// BestHTTP.ServerSentEvents.OnGeneralEventDelegate BestHTTP.ServerSentEvents.EventSource::OnClosed
	OnGeneralEventDelegate_t2459579164 * ___OnClosed_9;
	// BestHTTP.ServerSentEvents.OnStateChangedDelegate BestHTTP.ServerSentEvents.EventSource::OnStateChanged
	OnStateChangedDelegate_t1222973807 * ___OnStateChanged_10;
	// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.ServerSentEvents.OnEventDelegate> BestHTTP.ServerSentEvents.EventSource::EventTable
	Dictionary_2_t2705454032 * ___EventTable_11;
	// System.Byte BestHTTP.ServerSentEvents.EventSource::RetryCount
	uint8_t ___RetryCount_12;
	// System.DateTime BestHTTP.ServerSentEvents.EventSource::RetryCalled
	DateTime_t693205669  ___RetryCalled_13;

public:
	inline static int32_t get_offset_of_U3CUriU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___U3CUriU3Ek__BackingField_0)); }
	inline Uri_t19570940 * get_U3CUriU3Ek__BackingField_0() const { return ___U3CUriU3Ek__BackingField_0; }
	inline Uri_t19570940 ** get_address_of_U3CUriU3Ek__BackingField_0() { return &___U3CUriU3Ek__BackingField_0; }
	inline void set_U3CUriU3Ek__BackingField_0(Uri_t19570940 * value)
	{
		___U3CUriU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUriU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of__state_1() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ____state_1)); }
	inline int32_t get__state_1() const { return ____state_1; }
	inline int32_t* get_address_of__state_1() { return &____state_1; }
	inline void set__state_1(int32_t value)
	{
		____state_1 = value;
	}

	inline static int32_t get_offset_of_U3CReconnectionTimeU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___U3CReconnectionTimeU3Ek__BackingField_2)); }
	inline TimeSpan_t3430258949  get_U3CReconnectionTimeU3Ek__BackingField_2() const { return ___U3CReconnectionTimeU3Ek__BackingField_2; }
	inline TimeSpan_t3430258949 * get_address_of_U3CReconnectionTimeU3Ek__BackingField_2() { return &___U3CReconnectionTimeU3Ek__BackingField_2; }
	inline void set_U3CReconnectionTimeU3Ek__BackingField_2(TimeSpan_t3430258949  value)
	{
		___U3CReconnectionTimeU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CLastEventIdU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___U3CLastEventIdU3Ek__BackingField_3)); }
	inline String_t* get_U3CLastEventIdU3Ek__BackingField_3() const { return ___U3CLastEventIdU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CLastEventIdU3Ek__BackingField_3() { return &___U3CLastEventIdU3Ek__BackingField_3; }
	inline void set_U3CLastEventIdU3Ek__BackingField_3(String_t* value)
	{
		___U3CLastEventIdU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLastEventIdU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CInternalRequestU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___U3CInternalRequestU3Ek__BackingField_4)); }
	inline HTTPRequest_t138485887 * get_U3CInternalRequestU3Ek__BackingField_4() const { return ___U3CInternalRequestU3Ek__BackingField_4; }
	inline HTTPRequest_t138485887 ** get_address_of_U3CInternalRequestU3Ek__BackingField_4() { return &___U3CInternalRequestU3Ek__BackingField_4; }
	inline void set_U3CInternalRequestU3Ek__BackingField_4(HTTPRequest_t138485887 * value)
	{
		___U3CInternalRequestU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CInternalRequestU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_OnOpen_5() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnOpen_5)); }
	inline OnGeneralEventDelegate_t2459579164 * get_OnOpen_5() const { return ___OnOpen_5; }
	inline OnGeneralEventDelegate_t2459579164 ** get_address_of_OnOpen_5() { return &___OnOpen_5; }
	inline void set_OnOpen_5(OnGeneralEventDelegate_t2459579164 * value)
	{
		___OnOpen_5 = value;
		Il2CppCodeGenWriteBarrier(&___OnOpen_5, value);
	}

	inline static int32_t get_offset_of_OnMessage_6() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnMessage_6)); }
	inline OnMessageDelegate_t4204746873 * get_OnMessage_6() const { return ___OnMessage_6; }
	inline OnMessageDelegate_t4204746873 ** get_address_of_OnMessage_6() { return &___OnMessage_6; }
	inline void set_OnMessage_6(OnMessageDelegate_t4204746873 * value)
	{
		___OnMessage_6 = value;
		Il2CppCodeGenWriteBarrier(&___OnMessage_6, value);
	}

	inline static int32_t get_offset_of_OnError_7() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnError_7)); }
	inline OnErrorDelegate_t676891988 * get_OnError_7() const { return ___OnError_7; }
	inline OnErrorDelegate_t676891988 ** get_address_of_OnError_7() { return &___OnError_7; }
	inline void set_OnError_7(OnErrorDelegate_t676891988 * value)
	{
		___OnError_7 = value;
		Il2CppCodeGenWriteBarrier(&___OnError_7, value);
	}

	inline static int32_t get_offset_of_OnRetry_8() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnRetry_8)); }
	inline OnRetryDelegate_t1334454456 * get_OnRetry_8() const { return ___OnRetry_8; }
	inline OnRetryDelegate_t1334454456 ** get_address_of_OnRetry_8() { return &___OnRetry_8; }
	inline void set_OnRetry_8(OnRetryDelegate_t1334454456 * value)
	{
		___OnRetry_8 = value;
		Il2CppCodeGenWriteBarrier(&___OnRetry_8, value);
	}

	inline static int32_t get_offset_of_OnClosed_9() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnClosed_9)); }
	inline OnGeneralEventDelegate_t2459579164 * get_OnClosed_9() const { return ___OnClosed_9; }
	inline OnGeneralEventDelegate_t2459579164 ** get_address_of_OnClosed_9() { return &___OnClosed_9; }
	inline void set_OnClosed_9(OnGeneralEventDelegate_t2459579164 * value)
	{
		___OnClosed_9 = value;
		Il2CppCodeGenWriteBarrier(&___OnClosed_9, value);
	}

	inline static int32_t get_offset_of_OnStateChanged_10() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___OnStateChanged_10)); }
	inline OnStateChangedDelegate_t1222973807 * get_OnStateChanged_10() const { return ___OnStateChanged_10; }
	inline OnStateChangedDelegate_t1222973807 ** get_address_of_OnStateChanged_10() { return &___OnStateChanged_10; }
	inline void set_OnStateChanged_10(OnStateChangedDelegate_t1222973807 * value)
	{
		___OnStateChanged_10 = value;
		Il2CppCodeGenWriteBarrier(&___OnStateChanged_10, value);
	}

	inline static int32_t get_offset_of_EventTable_11() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___EventTable_11)); }
	inline Dictionary_2_t2705454032 * get_EventTable_11() const { return ___EventTable_11; }
	inline Dictionary_2_t2705454032 ** get_address_of_EventTable_11() { return &___EventTable_11; }
	inline void set_EventTable_11(Dictionary_2_t2705454032 * value)
	{
		___EventTable_11 = value;
		Il2CppCodeGenWriteBarrier(&___EventTable_11, value);
	}

	inline static int32_t get_offset_of_RetryCount_12() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___RetryCount_12)); }
	inline uint8_t get_RetryCount_12() const { return ___RetryCount_12; }
	inline uint8_t* get_address_of_RetryCount_12() { return &___RetryCount_12; }
	inline void set_RetryCount_12(uint8_t value)
	{
		___RetryCount_12 = value;
	}

	inline static int32_t get_offset_of_RetryCalled_13() { return static_cast<int32_t>(offsetof(EventSource_t3924127377, ___RetryCalled_13)); }
	inline DateTime_t693205669  get_RetryCalled_13() const { return ___RetryCalled_13; }
	inline DateTime_t693205669 * get_address_of_RetryCalled_13() { return &___RetryCalled_13; }
	inline void set_RetryCalled_13(DateTime_t693205669  value)
	{
		___RetryCalled_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
