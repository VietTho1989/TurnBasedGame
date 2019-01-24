#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_SocketIO_SocketManager_3533834126.h"
#include "mscorlib_System_DateTime693205669.h"

// BestHTTP.SocketIO.JsonEncoders.IJsonEncoder
struct IJsonEncoder_t3088637035;
// BestHTTP.SocketIO.SocketOptions
struct SocketOptions_t3023631931;
// System.Uri
struct Uri_t19570940;
// BestHTTP.SocketIO.HandshakeData
struct HandshakeData_t1703965475;
// BestHTTP.SocketIO.Transports.ITransport
struct ITransport_t4255542980;
// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.SocketIO.Socket>
struct Dictionary_2_t336436667;
// System.Collections.Generic.List`1<BestHTTP.SocketIO.Socket>
struct List_1_t2085745833;
// System.Collections.Generic.List`1<BestHTTP.SocketIO.Packet>
struct List_1_t678445278;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.SocketIO.SocketManager
struct  SocketManager_t3470268644  : public Il2CppObject
{
public:
	// BestHTTP.SocketIO.SocketManager/States BestHTTP.SocketIO.SocketManager::state
	int32_t ___state_2;
	// BestHTTP.SocketIO.SocketOptions BestHTTP.SocketIO.SocketManager::<Options>k__BackingField
	SocketOptions_t3023631931 * ___U3COptionsU3Ek__BackingField_3;
	// System.Uri BestHTTP.SocketIO.SocketManager::<Uri>k__BackingField
	Uri_t19570940 * ___U3CUriU3Ek__BackingField_4;
	// BestHTTP.SocketIO.HandshakeData BestHTTP.SocketIO.SocketManager::<Handshake>k__BackingField
	HandshakeData_t1703965475 * ___U3CHandshakeU3Ek__BackingField_5;
	// BestHTTP.SocketIO.Transports.ITransport BestHTTP.SocketIO.SocketManager::<Transport>k__BackingField
	Il2CppObject * ___U3CTransportU3Ek__BackingField_6;
	// System.UInt64 BestHTTP.SocketIO.SocketManager::<RequestCounter>k__BackingField
	uint64_t ___U3CRequestCounterU3Ek__BackingField_7;
	// System.Int32 BestHTTP.SocketIO.SocketManager::<ReconnectAttempts>k__BackingField
	int32_t ___U3CReconnectAttemptsU3Ek__BackingField_8;
	// BestHTTP.SocketIO.JsonEncoders.IJsonEncoder BestHTTP.SocketIO.SocketManager::<Encoder>k__BackingField
	Il2CppObject * ___U3CEncoderU3Ek__BackingField_9;
	// System.Int32 BestHTTP.SocketIO.SocketManager::nextAckId
	int32_t ___nextAckId_10;
	// BestHTTP.SocketIO.SocketManager/States BestHTTP.SocketIO.SocketManager::<PreviousState>k__BackingField
	int32_t ___U3CPreviousStateU3Ek__BackingField_11;
	// System.Collections.Generic.Dictionary`2<System.String,BestHTTP.SocketIO.Socket> BestHTTP.SocketIO.SocketManager::Namespaces
	Dictionary_2_t336436667 * ___Namespaces_12;
	// System.Collections.Generic.List`1<BestHTTP.SocketIO.Socket> BestHTTP.SocketIO.SocketManager::Sockets
	List_1_t2085745833 * ___Sockets_13;
	// System.Collections.Generic.List`1<BestHTTP.SocketIO.Packet> BestHTTP.SocketIO.SocketManager::OfflinePackets
	List_1_t678445278 * ___OfflinePackets_14;
	// System.DateTime BestHTTP.SocketIO.SocketManager::LastHeartbeat
	DateTime_t693205669  ___LastHeartbeat_15;
	// System.DateTime BestHTTP.SocketIO.SocketManager::LastPongReceived
	DateTime_t693205669  ___LastPongReceived_16;
	// System.DateTime BestHTTP.SocketIO.SocketManager::ReconnectAt
	DateTime_t693205669  ___ReconnectAt_17;
	// System.DateTime BestHTTP.SocketIO.SocketManager::ConnectionStarted
	DateTime_t693205669  ___ConnectionStarted_18;
	// System.Boolean BestHTTP.SocketIO.SocketManager::closing
	bool ___closing_19;

public:
	inline static int32_t get_offset_of_state_2() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___state_2)); }
	inline int32_t get_state_2() const { return ___state_2; }
	inline int32_t* get_address_of_state_2() { return &___state_2; }
	inline void set_state_2(int32_t value)
	{
		___state_2 = value;
	}

	inline static int32_t get_offset_of_U3COptionsU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3COptionsU3Ek__BackingField_3)); }
	inline SocketOptions_t3023631931 * get_U3COptionsU3Ek__BackingField_3() const { return ___U3COptionsU3Ek__BackingField_3; }
	inline SocketOptions_t3023631931 ** get_address_of_U3COptionsU3Ek__BackingField_3() { return &___U3COptionsU3Ek__BackingField_3; }
	inline void set_U3COptionsU3Ek__BackingField_3(SocketOptions_t3023631931 * value)
	{
		___U3COptionsU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3COptionsU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CUriU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CUriU3Ek__BackingField_4)); }
	inline Uri_t19570940 * get_U3CUriU3Ek__BackingField_4() const { return ___U3CUriU3Ek__BackingField_4; }
	inline Uri_t19570940 ** get_address_of_U3CUriU3Ek__BackingField_4() { return &___U3CUriU3Ek__BackingField_4; }
	inline void set_U3CUriU3Ek__BackingField_4(Uri_t19570940 * value)
	{
		___U3CUriU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUriU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CHandshakeU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CHandshakeU3Ek__BackingField_5)); }
	inline HandshakeData_t1703965475 * get_U3CHandshakeU3Ek__BackingField_5() const { return ___U3CHandshakeU3Ek__BackingField_5; }
	inline HandshakeData_t1703965475 ** get_address_of_U3CHandshakeU3Ek__BackingField_5() { return &___U3CHandshakeU3Ek__BackingField_5; }
	inline void set_U3CHandshakeU3Ek__BackingField_5(HandshakeData_t1703965475 * value)
	{
		___U3CHandshakeU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHandshakeU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CTransportU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CTransportU3Ek__BackingField_6)); }
	inline Il2CppObject * get_U3CTransportU3Ek__BackingField_6() const { return ___U3CTransportU3Ek__BackingField_6; }
	inline Il2CppObject ** get_address_of_U3CTransportU3Ek__BackingField_6() { return &___U3CTransportU3Ek__BackingField_6; }
	inline void set_U3CTransportU3Ek__BackingField_6(Il2CppObject * value)
	{
		___U3CTransportU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTransportU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CRequestCounterU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CRequestCounterU3Ek__BackingField_7)); }
	inline uint64_t get_U3CRequestCounterU3Ek__BackingField_7() const { return ___U3CRequestCounterU3Ek__BackingField_7; }
	inline uint64_t* get_address_of_U3CRequestCounterU3Ek__BackingField_7() { return &___U3CRequestCounterU3Ek__BackingField_7; }
	inline void set_U3CRequestCounterU3Ek__BackingField_7(uint64_t value)
	{
		___U3CRequestCounterU3Ek__BackingField_7 = value;
	}

	inline static int32_t get_offset_of_U3CReconnectAttemptsU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CReconnectAttemptsU3Ek__BackingField_8)); }
	inline int32_t get_U3CReconnectAttemptsU3Ek__BackingField_8() const { return ___U3CReconnectAttemptsU3Ek__BackingField_8; }
	inline int32_t* get_address_of_U3CReconnectAttemptsU3Ek__BackingField_8() { return &___U3CReconnectAttemptsU3Ek__BackingField_8; }
	inline void set_U3CReconnectAttemptsU3Ek__BackingField_8(int32_t value)
	{
		___U3CReconnectAttemptsU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_U3CEncoderU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CEncoderU3Ek__BackingField_9)); }
	inline Il2CppObject * get_U3CEncoderU3Ek__BackingField_9() const { return ___U3CEncoderU3Ek__BackingField_9; }
	inline Il2CppObject ** get_address_of_U3CEncoderU3Ek__BackingField_9() { return &___U3CEncoderU3Ek__BackingField_9; }
	inline void set_U3CEncoderU3Ek__BackingField_9(Il2CppObject * value)
	{
		___U3CEncoderU3Ek__BackingField_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CEncoderU3Ek__BackingField_9, value);
	}

	inline static int32_t get_offset_of_nextAckId_10() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___nextAckId_10)); }
	inline int32_t get_nextAckId_10() const { return ___nextAckId_10; }
	inline int32_t* get_address_of_nextAckId_10() { return &___nextAckId_10; }
	inline void set_nextAckId_10(int32_t value)
	{
		___nextAckId_10 = value;
	}

	inline static int32_t get_offset_of_U3CPreviousStateU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___U3CPreviousStateU3Ek__BackingField_11)); }
	inline int32_t get_U3CPreviousStateU3Ek__BackingField_11() const { return ___U3CPreviousStateU3Ek__BackingField_11; }
	inline int32_t* get_address_of_U3CPreviousStateU3Ek__BackingField_11() { return &___U3CPreviousStateU3Ek__BackingField_11; }
	inline void set_U3CPreviousStateU3Ek__BackingField_11(int32_t value)
	{
		___U3CPreviousStateU3Ek__BackingField_11 = value;
	}

	inline static int32_t get_offset_of_Namespaces_12() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___Namespaces_12)); }
	inline Dictionary_2_t336436667 * get_Namespaces_12() const { return ___Namespaces_12; }
	inline Dictionary_2_t336436667 ** get_address_of_Namespaces_12() { return &___Namespaces_12; }
	inline void set_Namespaces_12(Dictionary_2_t336436667 * value)
	{
		___Namespaces_12 = value;
		Il2CppCodeGenWriteBarrier(&___Namespaces_12, value);
	}

	inline static int32_t get_offset_of_Sockets_13() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___Sockets_13)); }
	inline List_1_t2085745833 * get_Sockets_13() const { return ___Sockets_13; }
	inline List_1_t2085745833 ** get_address_of_Sockets_13() { return &___Sockets_13; }
	inline void set_Sockets_13(List_1_t2085745833 * value)
	{
		___Sockets_13 = value;
		Il2CppCodeGenWriteBarrier(&___Sockets_13, value);
	}

	inline static int32_t get_offset_of_OfflinePackets_14() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___OfflinePackets_14)); }
	inline List_1_t678445278 * get_OfflinePackets_14() const { return ___OfflinePackets_14; }
	inline List_1_t678445278 ** get_address_of_OfflinePackets_14() { return &___OfflinePackets_14; }
	inline void set_OfflinePackets_14(List_1_t678445278 * value)
	{
		___OfflinePackets_14 = value;
		Il2CppCodeGenWriteBarrier(&___OfflinePackets_14, value);
	}

	inline static int32_t get_offset_of_LastHeartbeat_15() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___LastHeartbeat_15)); }
	inline DateTime_t693205669  get_LastHeartbeat_15() const { return ___LastHeartbeat_15; }
	inline DateTime_t693205669 * get_address_of_LastHeartbeat_15() { return &___LastHeartbeat_15; }
	inline void set_LastHeartbeat_15(DateTime_t693205669  value)
	{
		___LastHeartbeat_15 = value;
	}

	inline static int32_t get_offset_of_LastPongReceived_16() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___LastPongReceived_16)); }
	inline DateTime_t693205669  get_LastPongReceived_16() const { return ___LastPongReceived_16; }
	inline DateTime_t693205669 * get_address_of_LastPongReceived_16() { return &___LastPongReceived_16; }
	inline void set_LastPongReceived_16(DateTime_t693205669  value)
	{
		___LastPongReceived_16 = value;
	}

	inline static int32_t get_offset_of_ReconnectAt_17() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___ReconnectAt_17)); }
	inline DateTime_t693205669  get_ReconnectAt_17() const { return ___ReconnectAt_17; }
	inline DateTime_t693205669 * get_address_of_ReconnectAt_17() { return &___ReconnectAt_17; }
	inline void set_ReconnectAt_17(DateTime_t693205669  value)
	{
		___ReconnectAt_17 = value;
	}

	inline static int32_t get_offset_of_ConnectionStarted_18() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___ConnectionStarted_18)); }
	inline DateTime_t693205669  get_ConnectionStarted_18() const { return ___ConnectionStarted_18; }
	inline DateTime_t693205669 * get_address_of_ConnectionStarted_18() { return &___ConnectionStarted_18; }
	inline void set_ConnectionStarted_18(DateTime_t693205669  value)
	{
		___ConnectionStarted_18 = value;
	}

	inline static int32_t get_offset_of_closing_19() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644, ___closing_19)); }
	inline bool get_closing_19() const { return ___closing_19; }
	inline bool* get_address_of_closing_19() { return &___closing_19; }
	inline void set_closing_19(bool value)
	{
		___closing_19 = value;
	}
};

struct SocketManager_t3470268644_StaticFields
{
public:
	// BestHTTP.SocketIO.JsonEncoders.IJsonEncoder BestHTTP.SocketIO.SocketManager::DefaultEncoder
	Il2CppObject * ___DefaultEncoder_0;

public:
	inline static int32_t get_offset_of_DefaultEncoder_0() { return static_cast<int32_t>(offsetof(SocketManager_t3470268644_StaticFields, ___DefaultEncoder_0)); }
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
