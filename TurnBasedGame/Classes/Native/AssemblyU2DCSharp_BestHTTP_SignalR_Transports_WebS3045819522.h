#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_SignalR_Transports_Trans148904526.h"

// BestHTTP.WebSocket.WebSocket
struct WebSocket_t71448861;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Transports.WebSocketTransport
struct  WebSocketTransport_t3045819522  : public TransportBase_t148904526
{
public:
	// BestHTTP.WebSocket.WebSocket BestHTTP.SignalR.Transports.WebSocketTransport::wSocket
	WebSocket_t71448861 * ___wSocket_5;

public:
	inline static int32_t get_offset_of_wSocket_5() { return static_cast<int32_t>(offsetof(WebSocketTransport_t3045819522, ___wSocket_5)); }
	inline WebSocket_t71448861 * get_wSocket_5() const { return ___wSocket_5; }
	inline WebSocket_t71448861 ** get_address_of_wSocket_5() { return &___wSocket_5; }
	inline void set_wSocket_5(WebSocket_t71448861 * value)
	{
		___wSocket_5 = value;
		Il2CppCodeGenWriteBarrier(&___wSocket_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
