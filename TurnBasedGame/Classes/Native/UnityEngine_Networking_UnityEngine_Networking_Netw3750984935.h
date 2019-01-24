#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Networking.NetworkClient
struct NetworkClient_t696867603;
// UnityEngine.Networking.Match.MatchInfo
struct MatchInfo_t668842927;
// System.String
struct String_t;
// UnityEngine.Networking.NetworkSystem.PeerInfoMessage
struct PeerInfoMessage_t4070066639;
// UnityEngine.Networking.NetworkSystem.PeerListMessage
struct PeerListMessage_t297244123;
// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[]
struct PeerInfoMessageU5BU5D_t2669814294;
// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers>
struct Dictionary_2_t3215677535;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkMigrationManager
struct  NetworkMigrationManager_t3750984935  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_HostMigration
	bool ___m_HostMigration_2;
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_ShowGUI
	bool ___m_ShowGUI_3;
	// System.Int32 UnityEngine.Networking.NetworkMigrationManager::m_OffsetX
	int32_t ___m_OffsetX_4;
	// System.Int32 UnityEngine.Networking.NetworkMigrationManager::m_OffsetY
	int32_t ___m_OffsetY_5;
	// UnityEngine.Networking.NetworkClient UnityEngine.Networking.NetworkMigrationManager::m_Client
	NetworkClient_t696867603 * ___m_Client_6;
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_WaitingToBecomeNewHost
	bool ___m_WaitingToBecomeNewHost_7;
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_WaitingReconnectToNewHost
	bool ___m_WaitingReconnectToNewHost_8;
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_DisconnectedFromHost
	bool ___m_DisconnectedFromHost_9;
	// System.Boolean UnityEngine.Networking.NetworkMigrationManager::m_HostWasShutdown
	bool ___m_HostWasShutdown_10;
	// UnityEngine.Networking.Match.MatchInfo UnityEngine.Networking.NetworkMigrationManager::m_MatchInfo
	MatchInfo_t668842927 * ___m_MatchInfo_11;
	// System.Int32 UnityEngine.Networking.NetworkMigrationManager::m_OldServerConnectionId
	int32_t ___m_OldServerConnectionId_12;
	// System.String UnityEngine.Networking.NetworkMigrationManager::m_NewHostAddress
	String_t* ___m_NewHostAddress_13;
	// UnityEngine.Networking.NetworkSystem.PeerInfoMessage UnityEngine.Networking.NetworkMigrationManager::m_NewHostInfo
	PeerInfoMessage_t4070066639 * ___m_NewHostInfo_14;
	// UnityEngine.Networking.NetworkSystem.PeerListMessage UnityEngine.Networking.NetworkMigrationManager::m_PeerListMessage
	PeerListMessage_t297244123 * ___m_PeerListMessage_15;
	// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[] UnityEngine.Networking.NetworkMigrationManager::m_Peers
	PeerInfoMessageU5BU5D_t2669814294* ___m_Peers_16;
	// System.Collections.Generic.Dictionary`2<System.Int32,UnityEngine.Networking.NetworkMigrationManager/ConnectionPendingPlayers> UnityEngine.Networking.NetworkMigrationManager::m_PendingPlayers
	Dictionary_2_t3215677535 * ___m_PendingPlayers_17;

public:
	inline static int32_t get_offset_of_m_HostMigration_2() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_HostMigration_2)); }
	inline bool get_m_HostMigration_2() const { return ___m_HostMigration_2; }
	inline bool* get_address_of_m_HostMigration_2() { return &___m_HostMigration_2; }
	inline void set_m_HostMigration_2(bool value)
	{
		___m_HostMigration_2 = value;
	}

	inline static int32_t get_offset_of_m_ShowGUI_3() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_ShowGUI_3)); }
	inline bool get_m_ShowGUI_3() const { return ___m_ShowGUI_3; }
	inline bool* get_address_of_m_ShowGUI_3() { return &___m_ShowGUI_3; }
	inline void set_m_ShowGUI_3(bool value)
	{
		___m_ShowGUI_3 = value;
	}

	inline static int32_t get_offset_of_m_OffsetX_4() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_OffsetX_4)); }
	inline int32_t get_m_OffsetX_4() const { return ___m_OffsetX_4; }
	inline int32_t* get_address_of_m_OffsetX_4() { return &___m_OffsetX_4; }
	inline void set_m_OffsetX_4(int32_t value)
	{
		___m_OffsetX_4 = value;
	}

	inline static int32_t get_offset_of_m_OffsetY_5() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_OffsetY_5)); }
	inline int32_t get_m_OffsetY_5() const { return ___m_OffsetY_5; }
	inline int32_t* get_address_of_m_OffsetY_5() { return &___m_OffsetY_5; }
	inline void set_m_OffsetY_5(int32_t value)
	{
		___m_OffsetY_5 = value;
	}

	inline static int32_t get_offset_of_m_Client_6() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_Client_6)); }
	inline NetworkClient_t696867603 * get_m_Client_6() const { return ___m_Client_6; }
	inline NetworkClient_t696867603 ** get_address_of_m_Client_6() { return &___m_Client_6; }
	inline void set_m_Client_6(NetworkClient_t696867603 * value)
	{
		___m_Client_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_Client_6, value);
	}

	inline static int32_t get_offset_of_m_WaitingToBecomeNewHost_7() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_WaitingToBecomeNewHost_7)); }
	inline bool get_m_WaitingToBecomeNewHost_7() const { return ___m_WaitingToBecomeNewHost_7; }
	inline bool* get_address_of_m_WaitingToBecomeNewHost_7() { return &___m_WaitingToBecomeNewHost_7; }
	inline void set_m_WaitingToBecomeNewHost_7(bool value)
	{
		___m_WaitingToBecomeNewHost_7 = value;
	}

	inline static int32_t get_offset_of_m_WaitingReconnectToNewHost_8() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_WaitingReconnectToNewHost_8)); }
	inline bool get_m_WaitingReconnectToNewHost_8() const { return ___m_WaitingReconnectToNewHost_8; }
	inline bool* get_address_of_m_WaitingReconnectToNewHost_8() { return &___m_WaitingReconnectToNewHost_8; }
	inline void set_m_WaitingReconnectToNewHost_8(bool value)
	{
		___m_WaitingReconnectToNewHost_8 = value;
	}

	inline static int32_t get_offset_of_m_DisconnectedFromHost_9() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_DisconnectedFromHost_9)); }
	inline bool get_m_DisconnectedFromHost_9() const { return ___m_DisconnectedFromHost_9; }
	inline bool* get_address_of_m_DisconnectedFromHost_9() { return &___m_DisconnectedFromHost_9; }
	inline void set_m_DisconnectedFromHost_9(bool value)
	{
		___m_DisconnectedFromHost_9 = value;
	}

	inline static int32_t get_offset_of_m_HostWasShutdown_10() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_HostWasShutdown_10)); }
	inline bool get_m_HostWasShutdown_10() const { return ___m_HostWasShutdown_10; }
	inline bool* get_address_of_m_HostWasShutdown_10() { return &___m_HostWasShutdown_10; }
	inline void set_m_HostWasShutdown_10(bool value)
	{
		___m_HostWasShutdown_10 = value;
	}

	inline static int32_t get_offset_of_m_MatchInfo_11() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_MatchInfo_11)); }
	inline MatchInfo_t668842927 * get_m_MatchInfo_11() const { return ___m_MatchInfo_11; }
	inline MatchInfo_t668842927 ** get_address_of_m_MatchInfo_11() { return &___m_MatchInfo_11; }
	inline void set_m_MatchInfo_11(MatchInfo_t668842927 * value)
	{
		___m_MatchInfo_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_MatchInfo_11, value);
	}

	inline static int32_t get_offset_of_m_OldServerConnectionId_12() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_OldServerConnectionId_12)); }
	inline int32_t get_m_OldServerConnectionId_12() const { return ___m_OldServerConnectionId_12; }
	inline int32_t* get_address_of_m_OldServerConnectionId_12() { return &___m_OldServerConnectionId_12; }
	inline void set_m_OldServerConnectionId_12(int32_t value)
	{
		___m_OldServerConnectionId_12 = value;
	}

	inline static int32_t get_offset_of_m_NewHostAddress_13() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_NewHostAddress_13)); }
	inline String_t* get_m_NewHostAddress_13() const { return ___m_NewHostAddress_13; }
	inline String_t** get_address_of_m_NewHostAddress_13() { return &___m_NewHostAddress_13; }
	inline void set_m_NewHostAddress_13(String_t* value)
	{
		___m_NewHostAddress_13 = value;
		Il2CppCodeGenWriteBarrier(&___m_NewHostAddress_13, value);
	}

	inline static int32_t get_offset_of_m_NewHostInfo_14() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_NewHostInfo_14)); }
	inline PeerInfoMessage_t4070066639 * get_m_NewHostInfo_14() const { return ___m_NewHostInfo_14; }
	inline PeerInfoMessage_t4070066639 ** get_address_of_m_NewHostInfo_14() { return &___m_NewHostInfo_14; }
	inline void set_m_NewHostInfo_14(PeerInfoMessage_t4070066639 * value)
	{
		___m_NewHostInfo_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_NewHostInfo_14, value);
	}

	inline static int32_t get_offset_of_m_PeerListMessage_15() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_PeerListMessage_15)); }
	inline PeerListMessage_t297244123 * get_m_PeerListMessage_15() const { return ___m_PeerListMessage_15; }
	inline PeerListMessage_t297244123 ** get_address_of_m_PeerListMessage_15() { return &___m_PeerListMessage_15; }
	inline void set_m_PeerListMessage_15(PeerListMessage_t297244123 * value)
	{
		___m_PeerListMessage_15 = value;
		Il2CppCodeGenWriteBarrier(&___m_PeerListMessage_15, value);
	}

	inline static int32_t get_offset_of_m_Peers_16() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_Peers_16)); }
	inline PeerInfoMessageU5BU5D_t2669814294* get_m_Peers_16() const { return ___m_Peers_16; }
	inline PeerInfoMessageU5BU5D_t2669814294** get_address_of_m_Peers_16() { return &___m_Peers_16; }
	inline void set_m_Peers_16(PeerInfoMessageU5BU5D_t2669814294* value)
	{
		___m_Peers_16 = value;
		Il2CppCodeGenWriteBarrier(&___m_Peers_16, value);
	}

	inline static int32_t get_offset_of_m_PendingPlayers_17() { return static_cast<int32_t>(offsetof(NetworkMigrationManager_t3750984935, ___m_PendingPlayers_17)); }
	inline Dictionary_2_t3215677535 * get_m_PendingPlayers_17() const { return ___m_PendingPlayers_17; }
	inline Dictionary_2_t3215677535 ** get_address_of_m_PendingPlayers_17() { return &___m_PendingPlayers_17; }
	inline void set_m_PendingPlayers_17(Dictionary_2_t3215677535 * value)
	{
		___m_PendingPlayers_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_PendingPlayers_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
