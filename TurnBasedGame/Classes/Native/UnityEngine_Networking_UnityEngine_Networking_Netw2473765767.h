#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3335581469.h"

// UnityEngine.Networking.NetworkLobbyPlayer
struct NetworkLobbyPlayer_t2123032571;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.String
struct String_t;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkLobbyManager/PendingPlayer>
struct List_1_t886216149;
// UnityEngine.Networking.NetworkLobbyPlayer[]
struct NetworkLobbyPlayerU5BU5D_t650070458;
// UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage
struct LobbyReadyToBeginMessage_t3495336496;
// UnityEngine.Networking.NetworkSystem.IntegerMessage
struct IntegerMessage_t2422550789;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkLobbyManager
struct  NetworkLobbyManager_t2473765767  : public NetworkManager_t3335581469
{
public:
	// System.Boolean UnityEngine.Networking.NetworkLobbyManager::m_ShowLobbyGUI
	bool ___m_ShowLobbyGUI_50;
	// System.Int32 UnityEngine.Networking.NetworkLobbyManager::m_MaxPlayers
	int32_t ___m_MaxPlayers_51;
	// System.Int32 UnityEngine.Networking.NetworkLobbyManager::m_MaxPlayersPerConnection
	int32_t ___m_MaxPlayersPerConnection_52;
	// System.Int32 UnityEngine.Networking.NetworkLobbyManager::m_MinPlayers
	int32_t ___m_MinPlayers_53;
	// UnityEngine.Networking.NetworkLobbyPlayer UnityEngine.Networking.NetworkLobbyManager::m_LobbyPlayerPrefab
	NetworkLobbyPlayer_t2123032571 * ___m_LobbyPlayerPrefab_54;
	// UnityEngine.GameObject UnityEngine.Networking.NetworkLobbyManager::m_GamePlayerPrefab
	GameObject_t1756533147 * ___m_GamePlayerPrefab_55;
	// System.String UnityEngine.Networking.NetworkLobbyManager::m_LobbyScene
	String_t* ___m_LobbyScene_56;
	// System.String UnityEngine.Networking.NetworkLobbyManager::m_PlayScene
	String_t* ___m_PlayScene_57;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkLobbyManager/PendingPlayer> UnityEngine.Networking.NetworkLobbyManager::m_PendingPlayers
	List_1_t886216149 * ___m_PendingPlayers_58;
	// UnityEngine.Networking.NetworkLobbyPlayer[] UnityEngine.Networking.NetworkLobbyManager::lobbySlots
	NetworkLobbyPlayerU5BU5D_t650070458* ___lobbySlots_59;

public:
	inline static int32_t get_offset_of_m_ShowLobbyGUI_50() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_ShowLobbyGUI_50)); }
	inline bool get_m_ShowLobbyGUI_50() const { return ___m_ShowLobbyGUI_50; }
	inline bool* get_address_of_m_ShowLobbyGUI_50() { return &___m_ShowLobbyGUI_50; }
	inline void set_m_ShowLobbyGUI_50(bool value)
	{
		___m_ShowLobbyGUI_50 = value;
	}

	inline static int32_t get_offset_of_m_MaxPlayers_51() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_MaxPlayers_51)); }
	inline int32_t get_m_MaxPlayers_51() const { return ___m_MaxPlayers_51; }
	inline int32_t* get_address_of_m_MaxPlayers_51() { return &___m_MaxPlayers_51; }
	inline void set_m_MaxPlayers_51(int32_t value)
	{
		___m_MaxPlayers_51 = value;
	}

	inline static int32_t get_offset_of_m_MaxPlayersPerConnection_52() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_MaxPlayersPerConnection_52)); }
	inline int32_t get_m_MaxPlayersPerConnection_52() const { return ___m_MaxPlayersPerConnection_52; }
	inline int32_t* get_address_of_m_MaxPlayersPerConnection_52() { return &___m_MaxPlayersPerConnection_52; }
	inline void set_m_MaxPlayersPerConnection_52(int32_t value)
	{
		___m_MaxPlayersPerConnection_52 = value;
	}

	inline static int32_t get_offset_of_m_MinPlayers_53() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_MinPlayers_53)); }
	inline int32_t get_m_MinPlayers_53() const { return ___m_MinPlayers_53; }
	inline int32_t* get_address_of_m_MinPlayers_53() { return &___m_MinPlayers_53; }
	inline void set_m_MinPlayers_53(int32_t value)
	{
		___m_MinPlayers_53 = value;
	}

	inline static int32_t get_offset_of_m_LobbyPlayerPrefab_54() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_LobbyPlayerPrefab_54)); }
	inline NetworkLobbyPlayer_t2123032571 * get_m_LobbyPlayerPrefab_54() const { return ___m_LobbyPlayerPrefab_54; }
	inline NetworkLobbyPlayer_t2123032571 ** get_address_of_m_LobbyPlayerPrefab_54() { return &___m_LobbyPlayerPrefab_54; }
	inline void set_m_LobbyPlayerPrefab_54(NetworkLobbyPlayer_t2123032571 * value)
	{
		___m_LobbyPlayerPrefab_54 = value;
		Il2CppCodeGenWriteBarrier(&___m_LobbyPlayerPrefab_54, value);
	}

	inline static int32_t get_offset_of_m_GamePlayerPrefab_55() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_GamePlayerPrefab_55)); }
	inline GameObject_t1756533147 * get_m_GamePlayerPrefab_55() const { return ___m_GamePlayerPrefab_55; }
	inline GameObject_t1756533147 ** get_address_of_m_GamePlayerPrefab_55() { return &___m_GamePlayerPrefab_55; }
	inline void set_m_GamePlayerPrefab_55(GameObject_t1756533147 * value)
	{
		___m_GamePlayerPrefab_55 = value;
		Il2CppCodeGenWriteBarrier(&___m_GamePlayerPrefab_55, value);
	}

	inline static int32_t get_offset_of_m_LobbyScene_56() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_LobbyScene_56)); }
	inline String_t* get_m_LobbyScene_56() const { return ___m_LobbyScene_56; }
	inline String_t** get_address_of_m_LobbyScene_56() { return &___m_LobbyScene_56; }
	inline void set_m_LobbyScene_56(String_t* value)
	{
		___m_LobbyScene_56 = value;
		Il2CppCodeGenWriteBarrier(&___m_LobbyScene_56, value);
	}

	inline static int32_t get_offset_of_m_PlayScene_57() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_PlayScene_57)); }
	inline String_t* get_m_PlayScene_57() const { return ___m_PlayScene_57; }
	inline String_t** get_address_of_m_PlayScene_57() { return &___m_PlayScene_57; }
	inline void set_m_PlayScene_57(String_t* value)
	{
		___m_PlayScene_57 = value;
		Il2CppCodeGenWriteBarrier(&___m_PlayScene_57, value);
	}

	inline static int32_t get_offset_of_m_PendingPlayers_58() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___m_PendingPlayers_58)); }
	inline List_1_t886216149 * get_m_PendingPlayers_58() const { return ___m_PendingPlayers_58; }
	inline List_1_t886216149 ** get_address_of_m_PendingPlayers_58() { return &___m_PendingPlayers_58; }
	inline void set_m_PendingPlayers_58(List_1_t886216149 * value)
	{
		___m_PendingPlayers_58 = value;
		Il2CppCodeGenWriteBarrier(&___m_PendingPlayers_58, value);
	}

	inline static int32_t get_offset_of_lobbySlots_59() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767, ___lobbySlots_59)); }
	inline NetworkLobbyPlayerU5BU5D_t650070458* get_lobbySlots_59() const { return ___lobbySlots_59; }
	inline NetworkLobbyPlayerU5BU5D_t650070458** get_address_of_lobbySlots_59() { return &___lobbySlots_59; }
	inline void set_lobbySlots_59(NetworkLobbyPlayerU5BU5D_t650070458* value)
	{
		___lobbySlots_59 = value;
		Il2CppCodeGenWriteBarrier(&___lobbySlots_59, value);
	}
};

struct NetworkLobbyManager_t2473765767_StaticFields
{
public:
	// UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage UnityEngine.Networking.NetworkLobbyManager::s_ReadyToBeginMessage
	LobbyReadyToBeginMessage_t3495336496 * ___s_ReadyToBeginMessage_60;
	// UnityEngine.Networking.NetworkSystem.IntegerMessage UnityEngine.Networking.NetworkLobbyManager::s_SceneLoadedMessage
	IntegerMessage_t2422550789 * ___s_SceneLoadedMessage_61;
	// UnityEngine.Networking.NetworkSystem.LobbyReadyToBeginMessage UnityEngine.Networking.NetworkLobbyManager::s_LobbyReadyToBeginMessage
	LobbyReadyToBeginMessage_t3495336496 * ___s_LobbyReadyToBeginMessage_62;

public:
	inline static int32_t get_offset_of_s_ReadyToBeginMessage_60() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767_StaticFields, ___s_ReadyToBeginMessage_60)); }
	inline LobbyReadyToBeginMessage_t3495336496 * get_s_ReadyToBeginMessage_60() const { return ___s_ReadyToBeginMessage_60; }
	inline LobbyReadyToBeginMessage_t3495336496 ** get_address_of_s_ReadyToBeginMessage_60() { return &___s_ReadyToBeginMessage_60; }
	inline void set_s_ReadyToBeginMessage_60(LobbyReadyToBeginMessage_t3495336496 * value)
	{
		___s_ReadyToBeginMessage_60 = value;
		Il2CppCodeGenWriteBarrier(&___s_ReadyToBeginMessage_60, value);
	}

	inline static int32_t get_offset_of_s_SceneLoadedMessage_61() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767_StaticFields, ___s_SceneLoadedMessage_61)); }
	inline IntegerMessage_t2422550789 * get_s_SceneLoadedMessage_61() const { return ___s_SceneLoadedMessage_61; }
	inline IntegerMessage_t2422550789 ** get_address_of_s_SceneLoadedMessage_61() { return &___s_SceneLoadedMessage_61; }
	inline void set_s_SceneLoadedMessage_61(IntegerMessage_t2422550789 * value)
	{
		___s_SceneLoadedMessage_61 = value;
		Il2CppCodeGenWriteBarrier(&___s_SceneLoadedMessage_61, value);
	}

	inline static int32_t get_offset_of_s_LobbyReadyToBeginMessage_62() { return static_cast<int32_t>(offsetof(NetworkLobbyManager_t2473765767_StaticFields, ___s_LobbyReadyToBeginMessage_62)); }
	inline LobbyReadyToBeginMessage_t3495336496 * get_s_LobbyReadyToBeginMessage_62() const { return ___s_LobbyReadyToBeginMessage_62; }
	inline LobbyReadyToBeginMessage_t3495336496 ** get_address_of_s_LobbyReadyToBeginMessage_62() { return &___s_LobbyReadyToBeginMessage_62; }
	inline void set_s_LobbyReadyToBeginMessage_62(LobbyReadyToBeginMessage_t3495336496 * value)
	{
		___s_LobbyReadyToBeginMessage_62 = value;
		Il2CppCodeGenWriteBarrier(&___s_LobbyReadyToBeginMessage_62, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
