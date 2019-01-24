#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_BestHTTP_SignalR_Transports_Trans148904526.h"

// System.Collections.Generic.List`1<BestHTTP.HTTPRequest>
struct List_1_t3802574315;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SignalR.Transports.PostSendTransportBase
struct  PostSendTransportBase_t4137891006  : public TransportBase_t148904526
{
public:
	// System.Collections.Generic.List`1<BestHTTP.HTTPRequest> BestHTTP.SignalR.Transports.PostSendTransportBase::sendRequestQueue
	List_1_t3802574315 * ___sendRequestQueue_5;

public:
	inline static int32_t get_offset_of_sendRequestQueue_5() { return static_cast<int32_t>(offsetof(PostSendTransportBase_t4137891006, ___sendRequestQueue_5)); }
	inline List_1_t3802574315 * get_sendRequestQueue_5() const { return ___sendRequestQueue_5; }
	inline List_1_t3802574315 ** get_address_of_sendRequestQueue_5() { return &___sendRequestQueue_5; }
	inline void set_sendRequestQueue_5(List_1_t3802574315 * value)
	{
		___sendRequestQueue_5 = value;
		Il2CppCodeGenWriteBarrier(&___sendRequestQueue_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
