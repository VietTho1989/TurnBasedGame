#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_SocketIO_Transports_Tra1004880669.h"

// BestHTTP.SocketIO.SocketManager
struct SocketManager_t3470268644;
// BestHTTP.HTTPRequest
struct HTTPRequest_t138485887;
// BestHTTP.SocketIO.Packet
struct Packet_t1309324146;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Transports.PollingTransport
struct  PollingTransport_t2868132702  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.Transports.TransportStates BestHTTP.SocketIO.Transports.PollingTransport::<State>k__BackingField
	int32_t ___U3CStateU3Ek__BackingField_0;
	// BestHTTP.SocketIO.SocketManager BestHTTP.SocketIO.Transports.PollingTransport::<Manager>k__BackingField
	SocketManager_t3470268644 * ___U3CManagerU3Ek__BackingField_1;
	// BestHTTP.HTTPRequest BestHTTP.SocketIO.Transports.PollingTransport::LastRequest
	HTTPRequest_t138485887 * ___LastRequest_2;
	// BestHTTP.HTTPRequest BestHTTP.SocketIO.Transports.PollingTransport::PollRequest
	HTTPRequest_t138485887 * ___PollRequest_3;
	// BestHTTP.SocketIO.Packet BestHTTP.SocketIO.Transports.PollingTransport::PacketWithAttachment
	Packet_t1309324146 * ___PacketWithAttachment_4;

public:
	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(PollingTransport_t2868132702, ___U3CStateU3Ek__BackingField_0)); }
	inline int32_t get_U3CStateU3Ek__BackingField_0() const { return ___U3CStateU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CStateU3Ek__BackingField_0() { return &___U3CStateU3Ek__BackingField_0; }
	inline void set_U3CStateU3Ek__BackingField_0(int32_t value)
	{
		___U3CStateU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CManagerU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(PollingTransport_t2868132702, ___U3CManagerU3Ek__BackingField_1)); }
	inline SocketManager_t3470268644 * get_U3CManagerU3Ek__BackingField_1() const { return ___U3CManagerU3Ek__BackingField_1; }
	inline SocketManager_t3470268644 ** get_address_of_U3CManagerU3Ek__BackingField_1() { return &___U3CManagerU3Ek__BackingField_1; }
	inline void set_U3CManagerU3Ek__BackingField_1(SocketManager_t3470268644 * value)
	{
		___U3CManagerU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CManagerU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_LastRequest_2() { return static_cast<int32_t>(offsetof(PollingTransport_t2868132702, ___LastRequest_2)); }
	inline HTTPRequest_t138485887 * get_LastRequest_2() const { return ___LastRequest_2; }
	inline HTTPRequest_t138485887 ** get_address_of_LastRequest_2() { return &___LastRequest_2; }
	inline void set_LastRequest_2(HTTPRequest_t138485887 * value)
	{
		___LastRequest_2 = value;
		Il2CppCodeGenWriteBarrier(&___LastRequest_2, value);
	}

	inline static int32_t get_offset_of_PollRequest_3() { return static_cast<int32_t>(offsetof(PollingTransport_t2868132702, ___PollRequest_3)); }
	inline HTTPRequest_t138485887 * get_PollRequest_3() const { return ___PollRequest_3; }
	inline HTTPRequest_t138485887 ** get_address_of_PollRequest_3() { return &___PollRequest_3; }
	inline void set_PollRequest_3(HTTPRequest_t138485887 * value)
	{
		___PollRequest_3 = value;
		Il2CppCodeGenWriteBarrier(&___PollRequest_3, value);
	}

	inline static int32_t get_offset_of_PacketWithAttachment_4() { return static_cast<int32_t>(offsetof(PollingTransport_t2868132702, ___PacketWithAttachment_4)); }
	inline Packet_t1309324146 * get_PacketWithAttachment_4() const { return ___PacketWithAttachment_4; }
	inline Packet_t1309324146 ** get_address_of_PacketWithAttachment_4() { return &___PacketWithAttachment_4; }
	inline void set_PacketWithAttachment_4(Packet_t1309324146 * value)
	{
		___PacketWithAttachment_4 = value;
		Il2CppCodeGenWriteBarrier(&___PacketWithAttachment_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
