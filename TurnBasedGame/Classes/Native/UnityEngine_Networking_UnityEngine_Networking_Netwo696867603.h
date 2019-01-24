#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw2530234696.h"

// System.Type
struct Type_t;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkClient>
struct List_1_t65988735;
// UnityEngine.Networking.HostTopology
struct HostTopology_t3602650143;
// System.String
struct String_t;
// System.Net.EndPoint
struct EndPoint_t4156119363;
// UnityEngine.Networking.NetworkSystem.CRCMessage
struct CRCMessage_t1549987785;
// UnityEngine.Networking.NetworkMessageHandlers
struct NetworkMessageHandlers_t1208103348;
// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// UnityEngine.Networking.NetworkReader
struct NetworkReader_t3187690923;
// System.AsyncCallback
struct AsyncCallback_t163412349;
// UnityEngine.Networking.NetworkMessageDelegate
struct NetworkMessageDelegate_t1861659952;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkClient
struct  NetworkClient_t696867603  : public Il2CppObject
{
public:
	// System.Type UnityEngine.Networking.NetworkClient::m_NetworkConnectionClass
	Type_t * ___m_NetworkConnectionClass_0;
	// UnityEngine.Networking.HostTopology UnityEngine.Networking.NetworkClient::m_HostTopology
	HostTopology_t3602650143 * ___m_HostTopology_4;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_HostPort
	int32_t ___m_HostPort_5;
	// System.Boolean UnityEngine.Networking.NetworkClient::m_UseSimulator
	bool ___m_UseSimulator_6;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_SimulatedLatency
	int32_t ___m_SimulatedLatency_7;
	// System.Single UnityEngine.Networking.NetworkClient::m_PacketLoss
	float ___m_PacketLoss_8;
	// System.String UnityEngine.Networking.NetworkClient::m_ServerIp
	String_t* ___m_ServerIp_9;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ServerPort
	int32_t ___m_ServerPort_10;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ClientId
	int32_t ___m_ClientId_11;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_ClientConnectionId
	int32_t ___m_ClientConnectionId_12;
	// System.Int32 UnityEngine.Networking.NetworkClient::m_StatResetTime
	int32_t ___m_StatResetTime_13;
	// System.Net.EndPoint UnityEngine.Networking.NetworkClient::m_RemoteEndPoint
	EndPoint_t4156119363 * ___m_RemoteEndPoint_14;
	// UnityEngine.Networking.NetworkMessageHandlers UnityEngine.Networking.NetworkClient::m_MessageHandlers
	NetworkMessageHandlers_t1208103348 * ___m_MessageHandlers_16;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkClient::m_Connection
	NetworkConnection_t107267906 * ___m_Connection_17;
	// System.Byte[] UnityEngine.Networking.NetworkClient::m_MsgBuffer
	ByteU5BU5D_t3397334013* ___m_MsgBuffer_18;
	// UnityEngine.Networking.NetworkReader UnityEngine.Networking.NetworkClient::m_MsgReader
	NetworkReader_t3187690923 * ___m_MsgReader_19;
	// UnityEngine.Networking.NetworkClient/ConnectState UnityEngine.Networking.NetworkClient::m_AsyncConnect
	int32_t ___m_AsyncConnect_20;
	// System.String UnityEngine.Networking.NetworkClient::m_RequestedServerHost
	String_t* ___m_RequestedServerHost_21;

public:
	inline static int32_t get_offset_of_m_NetworkConnectionClass_0() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_NetworkConnectionClass_0)); }
	inline Type_t * get_m_NetworkConnectionClass_0() const { return ___m_NetworkConnectionClass_0; }
	inline Type_t ** get_address_of_m_NetworkConnectionClass_0() { return &___m_NetworkConnectionClass_0; }
	inline void set_m_NetworkConnectionClass_0(Type_t * value)
	{
		___m_NetworkConnectionClass_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetworkConnectionClass_0, value);
	}

	inline static int32_t get_offset_of_m_HostTopology_4() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_HostTopology_4)); }
	inline HostTopology_t3602650143 * get_m_HostTopology_4() const { return ___m_HostTopology_4; }
	inline HostTopology_t3602650143 ** get_address_of_m_HostTopology_4() { return &___m_HostTopology_4; }
	inline void set_m_HostTopology_4(HostTopology_t3602650143 * value)
	{
		___m_HostTopology_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_HostTopology_4, value);
	}

	inline static int32_t get_offset_of_m_HostPort_5() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_HostPort_5)); }
	inline int32_t get_m_HostPort_5() const { return ___m_HostPort_5; }
	inline int32_t* get_address_of_m_HostPort_5() { return &___m_HostPort_5; }
	inline void set_m_HostPort_5(int32_t value)
	{
		___m_HostPort_5 = value;
	}

	inline static int32_t get_offset_of_m_UseSimulator_6() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_UseSimulator_6)); }
	inline bool get_m_UseSimulator_6() const { return ___m_UseSimulator_6; }
	inline bool* get_address_of_m_UseSimulator_6() { return &___m_UseSimulator_6; }
	inline void set_m_UseSimulator_6(bool value)
	{
		___m_UseSimulator_6 = value;
	}

	inline static int32_t get_offset_of_m_SimulatedLatency_7() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_SimulatedLatency_7)); }
	inline int32_t get_m_SimulatedLatency_7() const { return ___m_SimulatedLatency_7; }
	inline int32_t* get_address_of_m_SimulatedLatency_7() { return &___m_SimulatedLatency_7; }
	inline void set_m_SimulatedLatency_7(int32_t value)
	{
		___m_SimulatedLatency_7 = value;
	}

	inline static int32_t get_offset_of_m_PacketLoss_8() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_PacketLoss_8)); }
	inline float get_m_PacketLoss_8() const { return ___m_PacketLoss_8; }
	inline float* get_address_of_m_PacketLoss_8() { return &___m_PacketLoss_8; }
	inline void set_m_PacketLoss_8(float value)
	{
		___m_PacketLoss_8 = value;
	}

	inline static int32_t get_offset_of_m_ServerIp_9() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_ServerIp_9)); }
	inline String_t* get_m_ServerIp_9() const { return ___m_ServerIp_9; }
	inline String_t** get_address_of_m_ServerIp_9() { return &___m_ServerIp_9; }
	inline void set_m_ServerIp_9(String_t* value)
	{
		___m_ServerIp_9 = value;
		Il2CppCodeGenWriteBarrier(&___m_ServerIp_9, value);
	}

	inline static int32_t get_offset_of_m_ServerPort_10() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_ServerPort_10)); }
	inline int32_t get_m_ServerPort_10() const { return ___m_ServerPort_10; }
	inline int32_t* get_address_of_m_ServerPort_10() { return &___m_ServerPort_10; }
	inline void set_m_ServerPort_10(int32_t value)
	{
		___m_ServerPort_10 = value;
	}

	inline static int32_t get_offset_of_m_ClientId_11() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_ClientId_11)); }
	inline int32_t get_m_ClientId_11() const { return ___m_ClientId_11; }
	inline int32_t* get_address_of_m_ClientId_11() { return &___m_ClientId_11; }
	inline void set_m_ClientId_11(int32_t value)
	{
		___m_ClientId_11 = value;
	}

	inline static int32_t get_offset_of_m_ClientConnectionId_12() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_ClientConnectionId_12)); }
	inline int32_t get_m_ClientConnectionId_12() const { return ___m_ClientConnectionId_12; }
	inline int32_t* get_address_of_m_ClientConnectionId_12() { return &___m_ClientConnectionId_12; }
	inline void set_m_ClientConnectionId_12(int32_t value)
	{
		___m_ClientConnectionId_12 = value;
	}

	inline static int32_t get_offset_of_m_StatResetTime_13() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_StatResetTime_13)); }
	inline int32_t get_m_StatResetTime_13() const { return ___m_StatResetTime_13; }
	inline int32_t* get_address_of_m_StatResetTime_13() { return &___m_StatResetTime_13; }
	inline void set_m_StatResetTime_13(int32_t value)
	{
		___m_StatResetTime_13 = value;
	}

	inline static int32_t get_offset_of_m_RemoteEndPoint_14() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_RemoteEndPoint_14)); }
	inline EndPoint_t4156119363 * get_m_RemoteEndPoint_14() const { return ___m_RemoteEndPoint_14; }
	inline EndPoint_t4156119363 ** get_address_of_m_RemoteEndPoint_14() { return &___m_RemoteEndPoint_14; }
	inline void set_m_RemoteEndPoint_14(EndPoint_t4156119363 * value)
	{
		___m_RemoteEndPoint_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_RemoteEndPoint_14, value);
	}

	inline static int32_t get_offset_of_m_MessageHandlers_16() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_MessageHandlers_16)); }
	inline NetworkMessageHandlers_t1208103348 * get_m_MessageHandlers_16() const { return ___m_MessageHandlers_16; }
	inline NetworkMessageHandlers_t1208103348 ** get_address_of_m_MessageHandlers_16() { return &___m_MessageHandlers_16; }
	inline void set_m_MessageHandlers_16(NetworkMessageHandlers_t1208103348 * value)
	{
		___m_MessageHandlers_16 = value;
		Il2CppCodeGenWriteBarrier(&___m_MessageHandlers_16, value);
	}

	inline static int32_t get_offset_of_m_Connection_17() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_Connection_17)); }
	inline NetworkConnection_t107267906 * get_m_Connection_17() const { return ___m_Connection_17; }
	inline NetworkConnection_t107267906 ** get_address_of_m_Connection_17() { return &___m_Connection_17; }
	inline void set_m_Connection_17(NetworkConnection_t107267906 * value)
	{
		___m_Connection_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_Connection_17, value);
	}

	inline static int32_t get_offset_of_m_MsgBuffer_18() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_MsgBuffer_18)); }
	inline ByteU5BU5D_t3397334013* get_m_MsgBuffer_18() const { return ___m_MsgBuffer_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_m_MsgBuffer_18() { return &___m_MsgBuffer_18; }
	inline void set_m_MsgBuffer_18(ByteU5BU5D_t3397334013* value)
	{
		___m_MsgBuffer_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgBuffer_18, value);
	}

	inline static int32_t get_offset_of_m_MsgReader_19() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_MsgReader_19)); }
	inline NetworkReader_t3187690923 * get_m_MsgReader_19() const { return ___m_MsgReader_19; }
	inline NetworkReader_t3187690923 ** get_address_of_m_MsgReader_19() { return &___m_MsgReader_19; }
	inline void set_m_MsgReader_19(NetworkReader_t3187690923 * value)
	{
		___m_MsgReader_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgReader_19, value);
	}

	inline static int32_t get_offset_of_m_AsyncConnect_20() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_AsyncConnect_20)); }
	inline int32_t get_m_AsyncConnect_20() const { return ___m_AsyncConnect_20; }
	inline int32_t* get_address_of_m_AsyncConnect_20() { return &___m_AsyncConnect_20; }
	inline void set_m_AsyncConnect_20(int32_t value)
	{
		___m_AsyncConnect_20 = value;
	}

	inline static int32_t get_offset_of_m_RequestedServerHost_21() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603, ___m_RequestedServerHost_21)); }
	inline String_t* get_m_RequestedServerHost_21() const { return ___m_RequestedServerHost_21; }
	inline String_t** get_address_of_m_RequestedServerHost_21() { return &___m_RequestedServerHost_21; }
	inline void set_m_RequestedServerHost_21(String_t* value)
	{
		___m_RequestedServerHost_21 = value;
		Il2CppCodeGenWriteBarrier(&___m_RequestedServerHost_21, value);
	}
};

struct NetworkClient_t696867603_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkClient> UnityEngine.Networking.NetworkClient::s_Clients
	List_1_t65988735 * ___s_Clients_2;
	// System.Boolean UnityEngine.Networking.NetworkClient::s_IsActive
	bool ___s_IsActive_3;
	// UnityEngine.Networking.NetworkSystem.CRCMessage UnityEngine.Networking.NetworkClient::s_CRCMessage
	CRCMessage_t1549987785 * ___s_CRCMessage_15;
	// System.AsyncCallback UnityEngine.Networking.NetworkClient::<>f__mg$cache0
	AsyncCallback_t163412349 * ___U3CU3Ef__mgU24cache0_22;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.NetworkClient::<>f__mg$cache1
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache1_23;

public:
	inline static int32_t get_offset_of_s_Clients_2() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603_StaticFields, ___s_Clients_2)); }
	inline List_1_t65988735 * get_s_Clients_2() const { return ___s_Clients_2; }
	inline List_1_t65988735 ** get_address_of_s_Clients_2() { return &___s_Clients_2; }
	inline void set_s_Clients_2(List_1_t65988735 * value)
	{
		___s_Clients_2 = value;
		Il2CppCodeGenWriteBarrier(&___s_Clients_2, value);
	}

	inline static int32_t get_offset_of_s_IsActive_3() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603_StaticFields, ___s_IsActive_3)); }
	inline bool get_s_IsActive_3() const { return ___s_IsActive_3; }
	inline bool* get_address_of_s_IsActive_3() { return &___s_IsActive_3; }
	inline void set_s_IsActive_3(bool value)
	{
		___s_IsActive_3 = value;
	}

	inline static int32_t get_offset_of_s_CRCMessage_15() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603_StaticFields, ___s_CRCMessage_15)); }
	inline CRCMessage_t1549987785 * get_s_CRCMessage_15() const { return ___s_CRCMessage_15; }
	inline CRCMessage_t1549987785 ** get_address_of_s_CRCMessage_15() { return &___s_CRCMessage_15; }
	inline void set_s_CRCMessage_15(CRCMessage_t1549987785 * value)
	{
		___s_CRCMessage_15 = value;
		Il2CppCodeGenWriteBarrier(&___s_CRCMessage_15, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_22() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603_StaticFields, ___U3CU3Ef__mgU24cache0_22)); }
	inline AsyncCallback_t163412349 * get_U3CU3Ef__mgU24cache0_22() const { return ___U3CU3Ef__mgU24cache0_22; }
	inline AsyncCallback_t163412349 ** get_address_of_U3CU3Ef__mgU24cache0_22() { return &___U3CU3Ef__mgU24cache0_22; }
	inline void set_U3CU3Ef__mgU24cache0_22(AsyncCallback_t163412349 * value)
	{
		___U3CU3Ef__mgU24cache0_22 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_22, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_23() { return static_cast<int32_t>(offsetof(NetworkClient_t696867603_StaticFields, ___U3CU3Ef__mgU24cache1_23)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache1_23() const { return ___U3CU3Ef__mgU24cache1_23; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache1_23() { return &___U3CU3Ef__mgU24cache1_23; }
	inline void set_U3CU3Ef__mgU24cache1_23(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache1_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache1_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
