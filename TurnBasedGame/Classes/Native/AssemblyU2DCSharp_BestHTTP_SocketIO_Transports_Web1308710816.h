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
// BestHTTP.WebSocket.WebSocket
struct WebSocket_t71448861;
// BestHTTP.SocketIO.Packet
struct Packet_t1309324146;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.Transports.WebSocketTransport
struct  WebSocketTransport_t1308710816  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.Transports.TransportStates BestHTTP.SocketIO.Transports.WebSocketTransport::<State>k__BackingField
	int32_t ___U3CStateU3Ek__BackingField_0;
	// BestHTTP.SocketIO.SocketManager BestHTTP.SocketIO.Transports.WebSocketTransport::<Manager>k__BackingField
	SocketManager_t3470268644 * ___U3CManagerU3Ek__BackingField_1;
	// System.Boolean BestHTTP.SocketIO.Transports.WebSocketTransport::<IsRequestInProgress>k__BackingField
	bool ___U3CIsRequestInProgressU3Ek__BackingField_2;
	// BestHTTP.WebSocket.WebSocket BestHTTP.SocketIO.Transports.WebSocketTransport::<Implementation>k__BackingField
	WebSocket_t71448861 * ___U3CImplementationU3Ek__BackingField_3;
	// BestHTTP.SocketIO.Packet BestHTTP.SocketIO.Transports.WebSocketTransport::PacketWithAttachment
	Packet_t1309324146 * ___PacketWithAttachment_4;
	// System.Byte[] BestHTTP.SocketIO.Transports.WebSocketTransport::Buffer
	ByteU5BU5D_t3397334013* ___Buffer_5;

public:
	inline static int32_t get_offset_of_U3CStateU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___U3CStateU3Ek__BackingField_0)); }
	inline int32_t get_U3CStateU3Ek__BackingField_0() const { return ___U3CStateU3Ek__BackingField_0; }
	inline int32_t* get_address_of_U3CStateU3Ek__BackingField_0() { return &___U3CStateU3Ek__BackingField_0; }
	inline void set_U3CStateU3Ek__BackingField_0(int32_t value)
	{
		___U3CStateU3Ek__BackingField_0 = value;
	}

	inline static int32_t get_offset_of_U3CManagerU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___U3CManagerU3Ek__BackingField_1)); }
	inline SocketManager_t3470268644 * get_U3CManagerU3Ek__BackingField_1() const { return ___U3CManagerU3Ek__BackingField_1; }
	inline SocketManager_t3470268644 ** get_address_of_U3CManagerU3Ek__BackingField_1() { return &___U3CManagerU3Ek__BackingField_1; }
	inline void set_U3CManagerU3Ek__BackingField_1(SocketManager_t3470268644 * value)
	{
		___U3CManagerU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CManagerU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CIsRequestInProgressU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___U3CIsRequestInProgressU3Ek__BackingField_2)); }
	inline bool get_U3CIsRequestInProgressU3Ek__BackingField_2() const { return ___U3CIsRequestInProgressU3Ek__BackingField_2; }
	inline bool* get_address_of_U3CIsRequestInProgressU3Ek__BackingField_2() { return &___U3CIsRequestInProgressU3Ek__BackingField_2; }
	inline void set_U3CIsRequestInProgressU3Ek__BackingField_2(bool value)
	{
		___U3CIsRequestInProgressU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CImplementationU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___U3CImplementationU3Ek__BackingField_3)); }
	inline WebSocket_t71448861 * get_U3CImplementationU3Ek__BackingField_3() const { return ___U3CImplementationU3Ek__BackingField_3; }
	inline WebSocket_t71448861 ** get_address_of_U3CImplementationU3Ek__BackingField_3() { return &___U3CImplementationU3Ek__BackingField_3; }
	inline void set_U3CImplementationU3Ek__BackingField_3(WebSocket_t71448861 * value)
	{
		___U3CImplementationU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CImplementationU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_PacketWithAttachment_4() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___PacketWithAttachment_4)); }
	inline Packet_t1309324146 * get_PacketWithAttachment_4() const { return ___PacketWithAttachment_4; }
	inline Packet_t1309324146 ** get_address_of_PacketWithAttachment_4() { return &___PacketWithAttachment_4; }
	inline void set_PacketWithAttachment_4(Packet_t1309324146 * value)
	{
		___PacketWithAttachment_4 = value;
		Il2CppCodeGenWriteBarrier(&___PacketWithAttachment_4, value);
	}

	inline static int32_t get_offset_of_Buffer_5() { return static_cast<int32_t>(offsetof(WebSocketTransport_t1308710816, ___Buffer_5)); }
	inline ByteU5BU5D_t3397334013* get_Buffer_5() const { return ___Buffer_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_Buffer_5() { return &___Buffer_5; }
	inline void set_Buffer_5(ByteU5BU5D_t3397334013* value)
	{
		___Buffer_5 = value;
		Il2CppCodeGenWriteBarrier(&___Buffer_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
