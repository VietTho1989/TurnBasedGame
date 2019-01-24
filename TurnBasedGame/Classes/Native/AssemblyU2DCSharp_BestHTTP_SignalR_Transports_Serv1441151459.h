#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_SignalR_Transports_Post4137891006.h"

// BestHTTP.ServerSentEvents.EventSource
struct EventSource_t3924127377;
// BestHTTP.ServerSentEvents.OnRetryDelegate
struct OnRetryDelegate_t1334454456;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Transports.ServerSentEventsTransport
struct  ServerSentEventsTransport_t1441151459  : public PostSendTransportBase_t4137891006
{
public:
	// BestHTTP.ServerSentEvents.EventSource BestHTTP.SignalR.Transports.ServerSentEventsTransport::EventSource
	EventSource_t3924127377 * ___EventSource_6;

public:
	inline static int32_t get_offset_of_EventSource_6() { return static_cast<int32_t>(offsetof(ServerSentEventsTransport_t1441151459, ___EventSource_6)); }
	inline EventSource_t3924127377 * get_EventSource_6() const { return ___EventSource_6; }
	inline EventSource_t3924127377 ** get_address_of_EventSource_6() { return &___EventSource_6; }
	inline void set_EventSource_6(EventSource_t3924127377 * value)
	{
		___EventSource_6 = value;
		Il2CppCodeGenWriteBarrier(&___EventSource_6, value);
	}
};

struct ServerSentEventsTransport_t1441151459_StaticFields
{
public:
	// BestHTTP.ServerSentEvents.OnRetryDelegate BestHTTP.SignalR.Transports.ServerSentEventsTransport::<>f__am$cache0
	OnRetryDelegate_t1334454456 * ___U3CU3Ef__amU24cache0_7;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(ServerSentEventsTransport_t1441151459_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
	inline OnRetryDelegate_t1334454456 * get_U3CU3Ef__amU24cache0_7() const { return ___U3CU3Ef__amU24cache0_7; }
	inline OnRetryDelegate_t1334454456 ** get_address_of_U3CU3Ef__amU24cache0_7() { return &___U3CU3Ef__amU24cache0_7; }
	inline void set_U3CU3Ef__amU24cache0_7(OnRetryDelegate_t1334454456 * value)
	{
		___U3CU3Ef__amU24cache0_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
