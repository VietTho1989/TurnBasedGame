#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Networking_NetworkError2010663956.h"

// UnityEngine.Networking.ChannelBuffer[]
struct ChannelBufferU5BU5D_t3955402482;
// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController>
struct List_1_t4277013949;
// UnityEngine.Networking.NetworkMessage
struct NetworkMessage_t2339216573;
// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkIdentity>
struct HashSet_1_t100100644;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;
// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkMessageDelegate>
struct Dictionary_2_t943369209;
// UnityEngine.Networking.NetworkMessageHandlers
struct NetworkMessageHandlers_t1208103348;
// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkInstanceId>
struct HashSet_1_t2662426982;
// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkConnection/PacketStat>
struct Dictionary_2_t4068020013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkConnection
struct  NetworkConnection_t107267906  : public Il2CppObject
{
public:
	// UnityEngine.Networking.ChannelBuffer[] UnityEngine.Networking.NetworkConnection::m_Channels
	ChannelBufferU5BU5D_t3955402482* ___m_Channels_0;
	// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController> UnityEngine.Networking.NetworkConnection::m_PlayerControllers
	List_1_t4277013949 * ___m_PlayerControllers_1;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.NetworkConnection::m_NetMsg
	NetworkMessage_t2339216573 * ___m_NetMsg_2;
	// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkIdentity> UnityEngine.Networking.NetworkConnection::m_VisList
	HashSet_1_t100100644 * ___m_VisList_3;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkConnection::m_Writer
	NetworkWriter_t560143343 * ___m_Writer_4;
	// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkMessageDelegate> UnityEngine.Networking.NetworkConnection::m_MessageHandlersDict
	Dictionary_2_t943369209 * ___m_MessageHandlersDict_5;
	// UnityEngine.Networking.NetworkMessageHandlers UnityEngine.Networking.NetworkConnection::m_MessageHandlers
	NetworkMessageHandlers_t1208103348 * ___m_MessageHandlers_6;
	// System.Collections.Generic.HashSet`1<UnityEngine.Networking.NetworkInstanceId> UnityEngine.Networking.NetworkConnection::m_ClientOwnedObjects
	HashSet_1_t2662426982 * ___m_ClientOwnedObjects_7;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.NetworkConnection::m_MessageInfo
	NetworkMessage_t2339216573 * ___m_MessageInfo_8;
	// UnityEngine.Networking.NetworkError UnityEngine.Networking.NetworkConnection::error
	int32_t ___error_10;
	// System.Int32 UnityEngine.Networking.NetworkConnection::hostId
	int32_t ___hostId_11;
	// System.Int32 UnityEngine.Networking.NetworkConnection::connectionId
	int32_t ___connectionId_12;
	// System.Boolean UnityEngine.Networking.NetworkConnection::isReady
	bool ___isReady_13;
	// System.String UnityEngine.Networking.NetworkConnection::address
	String_t* ___address_14;
	// System.Single UnityEngine.Networking.NetworkConnection::lastMessageTime
	float ___lastMessageTime_15;
	// System.Boolean UnityEngine.Networking.NetworkConnection::logNetworkMessages
	bool ___logNetworkMessages_16;
	// System.Collections.Generic.Dictionary`2<System.Int16,UnityEngine.Networking.NetworkConnection/PacketStat> UnityEngine.Networking.NetworkConnection::m_PacketStats
	Dictionary_2_t4068020013 * ___m_PacketStats_17;
	// System.Boolean UnityEngine.Networking.NetworkConnection::m_Disposed
	bool ___m_Disposed_18;

public:
	inline static int32_t get_offset_of_m_Channels_0() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_Channels_0)); }
	inline ChannelBufferU5BU5D_t3955402482* get_m_Channels_0() const { return ___m_Channels_0; }
	inline ChannelBufferU5BU5D_t3955402482** get_address_of_m_Channels_0() { return &___m_Channels_0; }
	inline void set_m_Channels_0(ChannelBufferU5BU5D_t3955402482* value)
	{
		___m_Channels_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Channels_0, value);
	}

	inline static int32_t get_offset_of_m_PlayerControllers_1() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_PlayerControllers_1)); }
	inline List_1_t4277013949 * get_m_PlayerControllers_1() const { return ___m_PlayerControllers_1; }
	inline List_1_t4277013949 ** get_address_of_m_PlayerControllers_1() { return &___m_PlayerControllers_1; }
	inline void set_m_PlayerControllers_1(List_1_t4277013949 * value)
	{
		___m_PlayerControllers_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_PlayerControllers_1, value);
	}

	inline static int32_t get_offset_of_m_NetMsg_2() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_NetMsg_2)); }
	inline NetworkMessage_t2339216573 * get_m_NetMsg_2() const { return ___m_NetMsg_2; }
	inline NetworkMessage_t2339216573 ** get_address_of_m_NetMsg_2() { return &___m_NetMsg_2; }
	inline void set_m_NetMsg_2(NetworkMessage_t2339216573 * value)
	{
		___m_NetMsg_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetMsg_2, value);
	}

	inline static int32_t get_offset_of_m_VisList_3() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_VisList_3)); }
	inline HashSet_1_t100100644 * get_m_VisList_3() const { return ___m_VisList_3; }
	inline HashSet_1_t100100644 ** get_address_of_m_VisList_3() { return &___m_VisList_3; }
	inline void set_m_VisList_3(HashSet_1_t100100644 * value)
	{
		___m_VisList_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_VisList_3, value);
	}

	inline static int32_t get_offset_of_m_Writer_4() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_Writer_4)); }
	inline NetworkWriter_t560143343 * get_m_Writer_4() const { return ___m_Writer_4; }
	inline NetworkWriter_t560143343 ** get_address_of_m_Writer_4() { return &___m_Writer_4; }
	inline void set_m_Writer_4(NetworkWriter_t560143343 * value)
	{
		___m_Writer_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_Writer_4, value);
	}

	inline static int32_t get_offset_of_m_MessageHandlersDict_5() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_MessageHandlersDict_5)); }
	inline Dictionary_2_t943369209 * get_m_MessageHandlersDict_5() const { return ___m_MessageHandlersDict_5; }
	inline Dictionary_2_t943369209 ** get_address_of_m_MessageHandlersDict_5() { return &___m_MessageHandlersDict_5; }
	inline void set_m_MessageHandlersDict_5(Dictionary_2_t943369209 * value)
	{
		___m_MessageHandlersDict_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_MessageHandlersDict_5, value);
	}

	inline static int32_t get_offset_of_m_MessageHandlers_6() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_MessageHandlers_6)); }
	inline NetworkMessageHandlers_t1208103348 * get_m_MessageHandlers_6() const { return ___m_MessageHandlers_6; }
	inline NetworkMessageHandlers_t1208103348 ** get_address_of_m_MessageHandlers_6() { return &___m_MessageHandlers_6; }
	inline void set_m_MessageHandlers_6(NetworkMessageHandlers_t1208103348 * value)
	{
		___m_MessageHandlers_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_MessageHandlers_6, value);
	}

	inline static int32_t get_offset_of_m_ClientOwnedObjects_7() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_ClientOwnedObjects_7)); }
	inline HashSet_1_t2662426982 * get_m_ClientOwnedObjects_7() const { return ___m_ClientOwnedObjects_7; }
	inline HashSet_1_t2662426982 ** get_address_of_m_ClientOwnedObjects_7() { return &___m_ClientOwnedObjects_7; }
	inline void set_m_ClientOwnedObjects_7(HashSet_1_t2662426982 * value)
	{
		___m_ClientOwnedObjects_7 = value;
		Il2CppCodeGenWriteBarrier(&___m_ClientOwnedObjects_7, value);
	}

	inline static int32_t get_offset_of_m_MessageInfo_8() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_MessageInfo_8)); }
	inline NetworkMessage_t2339216573 * get_m_MessageInfo_8() const { return ___m_MessageInfo_8; }
	inline NetworkMessage_t2339216573 ** get_address_of_m_MessageInfo_8() { return &___m_MessageInfo_8; }
	inline void set_m_MessageInfo_8(NetworkMessage_t2339216573 * value)
	{
		___m_MessageInfo_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_MessageInfo_8, value);
	}

	inline static int32_t get_offset_of_error_10() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___error_10)); }
	inline int32_t get_error_10() const { return ___error_10; }
	inline int32_t* get_address_of_error_10() { return &___error_10; }
	inline void set_error_10(int32_t value)
	{
		___error_10 = value;
	}

	inline static int32_t get_offset_of_hostId_11() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___hostId_11)); }
	inline int32_t get_hostId_11() const { return ___hostId_11; }
	inline int32_t* get_address_of_hostId_11() { return &___hostId_11; }
	inline void set_hostId_11(int32_t value)
	{
		___hostId_11 = value;
	}

	inline static int32_t get_offset_of_connectionId_12() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___connectionId_12)); }
	inline int32_t get_connectionId_12() const { return ___connectionId_12; }
	inline int32_t* get_address_of_connectionId_12() { return &___connectionId_12; }
	inline void set_connectionId_12(int32_t value)
	{
		___connectionId_12 = value;
	}

	inline static int32_t get_offset_of_isReady_13() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___isReady_13)); }
	inline bool get_isReady_13() const { return ___isReady_13; }
	inline bool* get_address_of_isReady_13() { return &___isReady_13; }
	inline void set_isReady_13(bool value)
	{
		___isReady_13 = value;
	}

	inline static int32_t get_offset_of_address_14() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___address_14)); }
	inline String_t* get_address_14() const { return ___address_14; }
	inline String_t** get_address_of_address_14() { return &___address_14; }
	inline void set_address_14(String_t* value)
	{
		___address_14 = value;
		Il2CppCodeGenWriteBarrier(&___address_14, value);
	}

	inline static int32_t get_offset_of_lastMessageTime_15() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___lastMessageTime_15)); }
	inline float get_lastMessageTime_15() const { return ___lastMessageTime_15; }
	inline float* get_address_of_lastMessageTime_15() { return &___lastMessageTime_15; }
	inline void set_lastMessageTime_15(float value)
	{
		___lastMessageTime_15 = value;
	}

	inline static int32_t get_offset_of_logNetworkMessages_16() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___logNetworkMessages_16)); }
	inline bool get_logNetworkMessages_16() const { return ___logNetworkMessages_16; }
	inline bool* get_address_of_logNetworkMessages_16() { return &___logNetworkMessages_16; }
	inline void set_logNetworkMessages_16(bool value)
	{
		___logNetworkMessages_16 = value;
	}

	inline static int32_t get_offset_of_m_PacketStats_17() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_PacketStats_17)); }
	inline Dictionary_2_t4068020013 * get_m_PacketStats_17() const { return ___m_PacketStats_17; }
	inline Dictionary_2_t4068020013 ** get_address_of_m_PacketStats_17() { return &___m_PacketStats_17; }
	inline void set_m_PacketStats_17(Dictionary_2_t4068020013 * value)
	{
		___m_PacketStats_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_PacketStats_17, value);
	}

	inline static int32_t get_offset_of_m_Disposed_18() { return static_cast<int32_t>(offsetof(NetworkConnection_t107267906, ___m_Disposed_18)); }
	inline bool get_m_Disposed_18() const { return ___m_Disposed_18; }
	inline bool* get_address_of_m_Disposed_18() { return &___m_Disposed_18; }
	inline void set_m_Disposed_18(bool value)
	{
		___m_Disposed_18 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
