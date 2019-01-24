#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_Networking_UnityEngine_Networking_LogF2308008460.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Play3416202383.h"

// System.String
struct String_t;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t1125654279;
// UnityEngine.Networking.ConnectionConfig
struct ConnectionConfig_t1350910390;
// UnityEngine.Networking.GlobalConfig
struct GlobalConfig_t2977893073;
// System.Collections.Generic.List`1<UnityEngine.Networking.QosType>
struct List_1_t1373013615;
// UnityEngine.Networking.NetworkMigrationManager
struct NetworkMigrationManager_t3750984935;
// System.Net.EndPoint
struct EndPoint_t4156119363;
// UnityEngine.Networking.NetworkClient
struct NetworkClient_t696867603;
// System.Collections.Generic.List`1<UnityEngine.Transform>
struct List_1_t2644239190;
// UnityEngine.Networking.Match.MatchInfo
struct MatchInfo_t668842927;
// UnityEngine.Networking.Match.NetworkMatch
struct NetworkMatch_t259788815;
// System.Collections.Generic.List`1<UnityEngine.Networking.Match.MatchInfoSnapshot>
struct List_1_t2548232039;
// UnityEngine.Networking.NetworkManager
struct NetworkManager_t3335581469;
// UnityEngine.Networking.NetworkSystem.AddPlayerMessage
struct AddPlayerMessage_t4197260945;
// UnityEngine.Networking.NetworkSystem.RemovePlayerMessage
struct RemovePlayerMessage_t3520841950;
// UnityEngine.Networking.NetworkSystem.ErrorMessage
struct ErrorMessage_t775412683;
// UnityEngine.AsyncOperation
struct AsyncOperation_t3814632279;
// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkManager
struct  NetworkManager_t3335581469  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 UnityEngine.Networking.NetworkManager::m_NetworkPort
	int32_t ___m_NetworkPort_2;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_ServerBindToIP
	bool ___m_ServerBindToIP_3;
	// System.String UnityEngine.Networking.NetworkManager::m_ServerBindAddress
	String_t* ___m_ServerBindAddress_4;
	// System.String UnityEngine.Networking.NetworkManager::m_NetworkAddress
	String_t* ___m_NetworkAddress_5;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_DontDestroyOnLoad
	bool ___m_DontDestroyOnLoad_6;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_RunInBackground
	bool ___m_RunInBackground_7;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_ScriptCRCCheck
	bool ___m_ScriptCRCCheck_8;
	// System.Single UnityEngine.Networking.NetworkManager::m_MaxDelay
	float ___m_MaxDelay_9;
	// UnityEngine.Networking.LogFilter/FilterLevel UnityEngine.Networking.NetworkManager::m_LogLevel
	int32_t ___m_LogLevel_10;
	// UnityEngine.GameObject UnityEngine.Networking.NetworkManager::m_PlayerPrefab
	GameObject_t1756533147 * ___m_PlayerPrefab_11;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_AutoCreatePlayer
	bool ___m_AutoCreatePlayer_12;
	// UnityEngine.Networking.PlayerSpawnMethod UnityEngine.Networking.NetworkManager::m_PlayerSpawnMethod
	int32_t ___m_PlayerSpawnMethod_13;
	// System.String UnityEngine.Networking.NetworkManager::m_OfflineScene
	String_t* ___m_OfflineScene_14;
	// System.String UnityEngine.Networking.NetworkManager::m_OnlineScene
	String_t* ___m_OnlineScene_15;
	// System.Collections.Generic.List`1<UnityEngine.GameObject> UnityEngine.Networking.NetworkManager::m_SpawnPrefabs
	List_1_t1125654279 * ___m_SpawnPrefabs_16;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_CustomConfig
	bool ___m_CustomConfig_17;
	// System.Int32 UnityEngine.Networking.NetworkManager::m_MaxConnections
	int32_t ___m_MaxConnections_18;
	// UnityEngine.Networking.ConnectionConfig UnityEngine.Networking.NetworkManager::m_ConnectionConfig
	ConnectionConfig_t1350910390 * ___m_ConnectionConfig_19;
	// UnityEngine.Networking.GlobalConfig UnityEngine.Networking.NetworkManager::m_GlobalConfig
	GlobalConfig_t2977893073 * ___m_GlobalConfig_20;
	// System.Collections.Generic.List`1<UnityEngine.Networking.QosType> UnityEngine.Networking.NetworkManager::m_Channels
	List_1_t1373013615 * ___m_Channels_21;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_UseWebSockets
	bool ___m_UseWebSockets_22;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_UseSimulator
	bool ___m_UseSimulator_23;
	// System.Int32 UnityEngine.Networking.NetworkManager::m_SimulatedLatency
	int32_t ___m_SimulatedLatency_24;
	// System.Single UnityEngine.Networking.NetworkManager::m_PacketLossPercentage
	float ___m_PacketLossPercentage_25;
	// System.Int32 UnityEngine.Networking.NetworkManager::m_MaxBufferedPackets
	int32_t ___m_MaxBufferedPackets_26;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_AllowFragmentation
	bool ___m_AllowFragmentation_27;
	// System.String UnityEngine.Networking.NetworkManager::m_MatchHost
	String_t* ___m_MatchHost_28;
	// System.Int32 UnityEngine.Networking.NetworkManager::m_MatchPort
	int32_t ___m_MatchPort_29;
	// System.String UnityEngine.Networking.NetworkManager::matchName
	String_t* ___matchName_30;
	// System.UInt32 UnityEngine.Networking.NetworkManager::matchSize
	uint32_t ___matchSize_31;
	// UnityEngine.Networking.NetworkMigrationManager UnityEngine.Networking.NetworkManager::m_MigrationManager
	NetworkMigrationManager_t3750984935 * ___m_MigrationManager_32;
	// System.Net.EndPoint UnityEngine.Networking.NetworkManager::m_EndPoint
	EndPoint_t4156119363 * ___m_EndPoint_33;
	// System.Boolean UnityEngine.Networking.NetworkManager::m_ClientLoadedScene
	bool ___m_ClientLoadedScene_34;
	// System.Boolean UnityEngine.Networking.NetworkManager::isNetworkActive
	bool ___isNetworkActive_36;
	// UnityEngine.Networking.NetworkClient UnityEngine.Networking.NetworkManager::client
	NetworkClient_t696867603 * ___client_37;
	// UnityEngine.Networking.Match.MatchInfo UnityEngine.Networking.NetworkManager::matchInfo
	MatchInfo_t668842927 * ___matchInfo_40;
	// UnityEngine.Networking.Match.NetworkMatch UnityEngine.Networking.NetworkManager::matchMaker
	NetworkMatch_t259788815 * ___matchMaker_41;
	// System.Collections.Generic.List`1<UnityEngine.Networking.Match.MatchInfoSnapshot> UnityEngine.Networking.NetworkManager::matches
	List_1_t2548232039 * ___matches_42;

public:
	inline static int32_t get_offset_of_m_NetworkPort_2() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_NetworkPort_2)); }
	inline int32_t get_m_NetworkPort_2() const { return ___m_NetworkPort_2; }
	inline int32_t* get_address_of_m_NetworkPort_2() { return &___m_NetworkPort_2; }
	inline void set_m_NetworkPort_2(int32_t value)
	{
		___m_NetworkPort_2 = value;
	}

	inline static int32_t get_offset_of_m_ServerBindToIP_3() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_ServerBindToIP_3)); }
	inline bool get_m_ServerBindToIP_3() const { return ___m_ServerBindToIP_3; }
	inline bool* get_address_of_m_ServerBindToIP_3() { return &___m_ServerBindToIP_3; }
	inline void set_m_ServerBindToIP_3(bool value)
	{
		___m_ServerBindToIP_3 = value;
	}

	inline static int32_t get_offset_of_m_ServerBindAddress_4() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_ServerBindAddress_4)); }
	inline String_t* get_m_ServerBindAddress_4() const { return ___m_ServerBindAddress_4; }
	inline String_t** get_address_of_m_ServerBindAddress_4() { return &___m_ServerBindAddress_4; }
	inline void set_m_ServerBindAddress_4(String_t* value)
	{
		___m_ServerBindAddress_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_ServerBindAddress_4, value);
	}

	inline static int32_t get_offset_of_m_NetworkAddress_5() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_NetworkAddress_5)); }
	inline String_t* get_m_NetworkAddress_5() const { return ___m_NetworkAddress_5; }
	inline String_t** get_address_of_m_NetworkAddress_5() { return &___m_NetworkAddress_5; }
	inline void set_m_NetworkAddress_5(String_t* value)
	{
		___m_NetworkAddress_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetworkAddress_5, value);
	}

	inline static int32_t get_offset_of_m_DontDestroyOnLoad_6() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_DontDestroyOnLoad_6)); }
	inline bool get_m_DontDestroyOnLoad_6() const { return ___m_DontDestroyOnLoad_6; }
	inline bool* get_address_of_m_DontDestroyOnLoad_6() { return &___m_DontDestroyOnLoad_6; }
	inline void set_m_DontDestroyOnLoad_6(bool value)
	{
		___m_DontDestroyOnLoad_6 = value;
	}

	inline static int32_t get_offset_of_m_RunInBackground_7() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_RunInBackground_7)); }
	inline bool get_m_RunInBackground_7() const { return ___m_RunInBackground_7; }
	inline bool* get_address_of_m_RunInBackground_7() { return &___m_RunInBackground_7; }
	inline void set_m_RunInBackground_7(bool value)
	{
		___m_RunInBackground_7 = value;
	}

	inline static int32_t get_offset_of_m_ScriptCRCCheck_8() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_ScriptCRCCheck_8)); }
	inline bool get_m_ScriptCRCCheck_8() const { return ___m_ScriptCRCCheck_8; }
	inline bool* get_address_of_m_ScriptCRCCheck_8() { return &___m_ScriptCRCCheck_8; }
	inline void set_m_ScriptCRCCheck_8(bool value)
	{
		___m_ScriptCRCCheck_8 = value;
	}

	inline static int32_t get_offset_of_m_MaxDelay_9() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MaxDelay_9)); }
	inline float get_m_MaxDelay_9() const { return ___m_MaxDelay_9; }
	inline float* get_address_of_m_MaxDelay_9() { return &___m_MaxDelay_9; }
	inline void set_m_MaxDelay_9(float value)
	{
		___m_MaxDelay_9 = value;
	}

	inline static int32_t get_offset_of_m_LogLevel_10() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_LogLevel_10)); }
	inline int32_t get_m_LogLevel_10() const { return ___m_LogLevel_10; }
	inline int32_t* get_address_of_m_LogLevel_10() { return &___m_LogLevel_10; }
	inline void set_m_LogLevel_10(int32_t value)
	{
		___m_LogLevel_10 = value;
	}

	inline static int32_t get_offset_of_m_PlayerPrefab_11() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_PlayerPrefab_11)); }
	inline GameObject_t1756533147 * get_m_PlayerPrefab_11() const { return ___m_PlayerPrefab_11; }
	inline GameObject_t1756533147 ** get_address_of_m_PlayerPrefab_11() { return &___m_PlayerPrefab_11; }
	inline void set_m_PlayerPrefab_11(GameObject_t1756533147 * value)
	{
		___m_PlayerPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_PlayerPrefab_11, value);
	}

	inline static int32_t get_offset_of_m_AutoCreatePlayer_12() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_AutoCreatePlayer_12)); }
	inline bool get_m_AutoCreatePlayer_12() const { return ___m_AutoCreatePlayer_12; }
	inline bool* get_address_of_m_AutoCreatePlayer_12() { return &___m_AutoCreatePlayer_12; }
	inline void set_m_AutoCreatePlayer_12(bool value)
	{
		___m_AutoCreatePlayer_12 = value;
	}

	inline static int32_t get_offset_of_m_PlayerSpawnMethod_13() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_PlayerSpawnMethod_13)); }
	inline int32_t get_m_PlayerSpawnMethod_13() const { return ___m_PlayerSpawnMethod_13; }
	inline int32_t* get_address_of_m_PlayerSpawnMethod_13() { return &___m_PlayerSpawnMethod_13; }
	inline void set_m_PlayerSpawnMethod_13(int32_t value)
	{
		___m_PlayerSpawnMethod_13 = value;
	}

	inline static int32_t get_offset_of_m_OfflineScene_14() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_OfflineScene_14)); }
	inline String_t* get_m_OfflineScene_14() const { return ___m_OfflineScene_14; }
	inline String_t** get_address_of_m_OfflineScene_14() { return &___m_OfflineScene_14; }
	inline void set_m_OfflineScene_14(String_t* value)
	{
		___m_OfflineScene_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_OfflineScene_14, value);
	}

	inline static int32_t get_offset_of_m_OnlineScene_15() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_OnlineScene_15)); }
	inline String_t* get_m_OnlineScene_15() const { return ___m_OnlineScene_15; }
	inline String_t** get_address_of_m_OnlineScene_15() { return &___m_OnlineScene_15; }
	inline void set_m_OnlineScene_15(String_t* value)
	{
		___m_OnlineScene_15 = value;
		Il2CppCodeGenWriteBarrier(&___m_OnlineScene_15, value);
	}

	inline static int32_t get_offset_of_m_SpawnPrefabs_16() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_SpawnPrefabs_16)); }
	inline List_1_t1125654279 * get_m_SpawnPrefabs_16() const { return ___m_SpawnPrefabs_16; }
	inline List_1_t1125654279 ** get_address_of_m_SpawnPrefabs_16() { return &___m_SpawnPrefabs_16; }
	inline void set_m_SpawnPrefabs_16(List_1_t1125654279 * value)
	{
		___m_SpawnPrefabs_16 = value;
		Il2CppCodeGenWriteBarrier(&___m_SpawnPrefabs_16, value);
	}

	inline static int32_t get_offset_of_m_CustomConfig_17() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_CustomConfig_17)); }
	inline bool get_m_CustomConfig_17() const { return ___m_CustomConfig_17; }
	inline bool* get_address_of_m_CustomConfig_17() { return &___m_CustomConfig_17; }
	inline void set_m_CustomConfig_17(bool value)
	{
		___m_CustomConfig_17 = value;
	}

	inline static int32_t get_offset_of_m_MaxConnections_18() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MaxConnections_18)); }
	inline int32_t get_m_MaxConnections_18() const { return ___m_MaxConnections_18; }
	inline int32_t* get_address_of_m_MaxConnections_18() { return &___m_MaxConnections_18; }
	inline void set_m_MaxConnections_18(int32_t value)
	{
		___m_MaxConnections_18 = value;
	}

	inline static int32_t get_offset_of_m_ConnectionConfig_19() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_ConnectionConfig_19)); }
	inline ConnectionConfig_t1350910390 * get_m_ConnectionConfig_19() const { return ___m_ConnectionConfig_19; }
	inline ConnectionConfig_t1350910390 ** get_address_of_m_ConnectionConfig_19() { return &___m_ConnectionConfig_19; }
	inline void set_m_ConnectionConfig_19(ConnectionConfig_t1350910390 * value)
	{
		___m_ConnectionConfig_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_ConnectionConfig_19, value);
	}

	inline static int32_t get_offset_of_m_GlobalConfig_20() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_GlobalConfig_20)); }
	inline GlobalConfig_t2977893073 * get_m_GlobalConfig_20() const { return ___m_GlobalConfig_20; }
	inline GlobalConfig_t2977893073 ** get_address_of_m_GlobalConfig_20() { return &___m_GlobalConfig_20; }
	inline void set_m_GlobalConfig_20(GlobalConfig_t2977893073 * value)
	{
		___m_GlobalConfig_20 = value;
		Il2CppCodeGenWriteBarrier(&___m_GlobalConfig_20, value);
	}

	inline static int32_t get_offset_of_m_Channels_21() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_Channels_21)); }
	inline List_1_t1373013615 * get_m_Channels_21() const { return ___m_Channels_21; }
	inline List_1_t1373013615 ** get_address_of_m_Channels_21() { return &___m_Channels_21; }
	inline void set_m_Channels_21(List_1_t1373013615 * value)
	{
		___m_Channels_21 = value;
		Il2CppCodeGenWriteBarrier(&___m_Channels_21, value);
	}

	inline static int32_t get_offset_of_m_UseWebSockets_22() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_UseWebSockets_22)); }
	inline bool get_m_UseWebSockets_22() const { return ___m_UseWebSockets_22; }
	inline bool* get_address_of_m_UseWebSockets_22() { return &___m_UseWebSockets_22; }
	inline void set_m_UseWebSockets_22(bool value)
	{
		___m_UseWebSockets_22 = value;
	}

	inline static int32_t get_offset_of_m_UseSimulator_23() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_UseSimulator_23)); }
	inline bool get_m_UseSimulator_23() const { return ___m_UseSimulator_23; }
	inline bool* get_address_of_m_UseSimulator_23() { return &___m_UseSimulator_23; }
	inline void set_m_UseSimulator_23(bool value)
	{
		___m_UseSimulator_23 = value;
	}

	inline static int32_t get_offset_of_m_SimulatedLatency_24() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_SimulatedLatency_24)); }
	inline int32_t get_m_SimulatedLatency_24() const { return ___m_SimulatedLatency_24; }
	inline int32_t* get_address_of_m_SimulatedLatency_24() { return &___m_SimulatedLatency_24; }
	inline void set_m_SimulatedLatency_24(int32_t value)
	{
		___m_SimulatedLatency_24 = value;
	}

	inline static int32_t get_offset_of_m_PacketLossPercentage_25() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_PacketLossPercentage_25)); }
	inline float get_m_PacketLossPercentage_25() const { return ___m_PacketLossPercentage_25; }
	inline float* get_address_of_m_PacketLossPercentage_25() { return &___m_PacketLossPercentage_25; }
	inline void set_m_PacketLossPercentage_25(float value)
	{
		___m_PacketLossPercentage_25 = value;
	}

	inline static int32_t get_offset_of_m_MaxBufferedPackets_26() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MaxBufferedPackets_26)); }
	inline int32_t get_m_MaxBufferedPackets_26() const { return ___m_MaxBufferedPackets_26; }
	inline int32_t* get_address_of_m_MaxBufferedPackets_26() { return &___m_MaxBufferedPackets_26; }
	inline void set_m_MaxBufferedPackets_26(int32_t value)
	{
		___m_MaxBufferedPackets_26 = value;
	}

	inline static int32_t get_offset_of_m_AllowFragmentation_27() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_AllowFragmentation_27)); }
	inline bool get_m_AllowFragmentation_27() const { return ___m_AllowFragmentation_27; }
	inline bool* get_address_of_m_AllowFragmentation_27() { return &___m_AllowFragmentation_27; }
	inline void set_m_AllowFragmentation_27(bool value)
	{
		___m_AllowFragmentation_27 = value;
	}

	inline static int32_t get_offset_of_m_MatchHost_28() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MatchHost_28)); }
	inline String_t* get_m_MatchHost_28() const { return ___m_MatchHost_28; }
	inline String_t** get_address_of_m_MatchHost_28() { return &___m_MatchHost_28; }
	inline void set_m_MatchHost_28(String_t* value)
	{
		___m_MatchHost_28 = value;
		Il2CppCodeGenWriteBarrier(&___m_MatchHost_28, value);
	}

	inline static int32_t get_offset_of_m_MatchPort_29() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MatchPort_29)); }
	inline int32_t get_m_MatchPort_29() const { return ___m_MatchPort_29; }
	inline int32_t* get_address_of_m_MatchPort_29() { return &___m_MatchPort_29; }
	inline void set_m_MatchPort_29(int32_t value)
	{
		___m_MatchPort_29 = value;
	}

	inline static int32_t get_offset_of_matchName_30() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___matchName_30)); }
	inline String_t* get_matchName_30() const { return ___matchName_30; }
	inline String_t** get_address_of_matchName_30() { return &___matchName_30; }
	inline void set_matchName_30(String_t* value)
	{
		___matchName_30 = value;
		Il2CppCodeGenWriteBarrier(&___matchName_30, value);
	}

	inline static int32_t get_offset_of_matchSize_31() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___matchSize_31)); }
	inline uint32_t get_matchSize_31() const { return ___matchSize_31; }
	inline uint32_t* get_address_of_matchSize_31() { return &___matchSize_31; }
	inline void set_matchSize_31(uint32_t value)
	{
		___matchSize_31 = value;
	}

	inline static int32_t get_offset_of_m_MigrationManager_32() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_MigrationManager_32)); }
	inline NetworkMigrationManager_t3750984935 * get_m_MigrationManager_32() const { return ___m_MigrationManager_32; }
	inline NetworkMigrationManager_t3750984935 ** get_address_of_m_MigrationManager_32() { return &___m_MigrationManager_32; }
	inline void set_m_MigrationManager_32(NetworkMigrationManager_t3750984935 * value)
	{
		___m_MigrationManager_32 = value;
		Il2CppCodeGenWriteBarrier(&___m_MigrationManager_32, value);
	}

	inline static int32_t get_offset_of_m_EndPoint_33() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_EndPoint_33)); }
	inline EndPoint_t4156119363 * get_m_EndPoint_33() const { return ___m_EndPoint_33; }
	inline EndPoint_t4156119363 ** get_address_of_m_EndPoint_33() { return &___m_EndPoint_33; }
	inline void set_m_EndPoint_33(EndPoint_t4156119363 * value)
	{
		___m_EndPoint_33 = value;
		Il2CppCodeGenWriteBarrier(&___m_EndPoint_33, value);
	}

	inline static int32_t get_offset_of_m_ClientLoadedScene_34() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___m_ClientLoadedScene_34)); }
	inline bool get_m_ClientLoadedScene_34() const { return ___m_ClientLoadedScene_34; }
	inline bool* get_address_of_m_ClientLoadedScene_34() { return &___m_ClientLoadedScene_34; }
	inline void set_m_ClientLoadedScene_34(bool value)
	{
		___m_ClientLoadedScene_34 = value;
	}

	inline static int32_t get_offset_of_isNetworkActive_36() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___isNetworkActive_36)); }
	inline bool get_isNetworkActive_36() const { return ___isNetworkActive_36; }
	inline bool* get_address_of_isNetworkActive_36() { return &___isNetworkActive_36; }
	inline void set_isNetworkActive_36(bool value)
	{
		___isNetworkActive_36 = value;
	}

	inline static int32_t get_offset_of_client_37() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___client_37)); }
	inline NetworkClient_t696867603 * get_client_37() const { return ___client_37; }
	inline NetworkClient_t696867603 ** get_address_of_client_37() { return &___client_37; }
	inline void set_client_37(NetworkClient_t696867603 * value)
	{
		___client_37 = value;
		Il2CppCodeGenWriteBarrier(&___client_37, value);
	}

	inline static int32_t get_offset_of_matchInfo_40() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___matchInfo_40)); }
	inline MatchInfo_t668842927 * get_matchInfo_40() const { return ___matchInfo_40; }
	inline MatchInfo_t668842927 ** get_address_of_matchInfo_40() { return &___matchInfo_40; }
	inline void set_matchInfo_40(MatchInfo_t668842927 * value)
	{
		___matchInfo_40 = value;
		Il2CppCodeGenWriteBarrier(&___matchInfo_40, value);
	}

	inline static int32_t get_offset_of_matchMaker_41() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___matchMaker_41)); }
	inline NetworkMatch_t259788815 * get_matchMaker_41() const { return ___matchMaker_41; }
	inline NetworkMatch_t259788815 ** get_address_of_matchMaker_41() { return &___matchMaker_41; }
	inline void set_matchMaker_41(NetworkMatch_t259788815 * value)
	{
		___matchMaker_41 = value;
		Il2CppCodeGenWriteBarrier(&___matchMaker_41, value);
	}

	inline static int32_t get_offset_of_matches_42() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469, ___matches_42)); }
	inline List_1_t2548232039 * get_matches_42() const { return ___matches_42; }
	inline List_1_t2548232039 ** get_address_of_matches_42() { return &___matches_42; }
	inline void set_matches_42(List_1_t2548232039 * value)
	{
		___matches_42 = value;
		Il2CppCodeGenWriteBarrier(&___matches_42, value);
	}
};

struct NetworkManager_t3335581469_StaticFields
{
public:
	// System.String UnityEngine.Networking.NetworkManager::networkSceneName
	String_t* ___networkSceneName_35;
	// System.Collections.Generic.List`1<UnityEngine.Transform> UnityEngine.Networking.NetworkManager::s_StartPositions
	List_1_t2644239190 * ___s_StartPositions_38;
	// System.Int32 UnityEngine.Networking.NetworkManager::s_StartPositionIndex
	int32_t ___s_StartPositionIndex_39;
	// UnityEngine.Networking.NetworkManager UnityEngine.Networking.NetworkManager::singleton
	NetworkManager_t3335581469 * ___singleton_43;
	// UnityEngine.Networking.NetworkSystem.AddPlayerMessage UnityEngine.Networking.NetworkManager::s_AddPlayerMessage
	AddPlayerMessage_t4197260945 * ___s_AddPlayerMessage_44;
	// UnityEngine.Networking.NetworkSystem.RemovePlayerMessage UnityEngine.Networking.NetworkManager::s_RemovePlayerMessage
	RemovePlayerMessage_t3520841950 * ___s_RemovePlayerMessage_45;
	// UnityEngine.Networking.NetworkSystem.ErrorMessage UnityEngine.Networking.NetworkManager::s_ErrorMessage
	ErrorMessage_t775412683 * ___s_ErrorMessage_46;
	// UnityEngine.AsyncOperation UnityEngine.Networking.NetworkManager::s_LoadingSceneAsync
	AsyncOperation_t3814632279 * ___s_LoadingSceneAsync_47;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkManager::s_ClientReadyConnection
	NetworkConnection_t107267906 * ___s_ClientReadyConnection_48;
	// System.String UnityEngine.Networking.NetworkManager::s_Address
	String_t* ___s_Address_49;

public:
	inline static int32_t get_offset_of_networkSceneName_35() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___networkSceneName_35)); }
	inline String_t* get_networkSceneName_35() const { return ___networkSceneName_35; }
	inline String_t** get_address_of_networkSceneName_35() { return &___networkSceneName_35; }
	inline void set_networkSceneName_35(String_t* value)
	{
		___networkSceneName_35 = value;
		Il2CppCodeGenWriteBarrier(&___networkSceneName_35, value);
	}

	inline static int32_t get_offset_of_s_StartPositions_38() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_StartPositions_38)); }
	inline List_1_t2644239190 * get_s_StartPositions_38() const { return ___s_StartPositions_38; }
	inline List_1_t2644239190 ** get_address_of_s_StartPositions_38() { return &___s_StartPositions_38; }
	inline void set_s_StartPositions_38(List_1_t2644239190 * value)
	{
		___s_StartPositions_38 = value;
		Il2CppCodeGenWriteBarrier(&___s_StartPositions_38, value);
	}

	inline static int32_t get_offset_of_s_StartPositionIndex_39() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_StartPositionIndex_39)); }
	inline int32_t get_s_StartPositionIndex_39() const { return ___s_StartPositionIndex_39; }
	inline int32_t* get_address_of_s_StartPositionIndex_39() { return &___s_StartPositionIndex_39; }
	inline void set_s_StartPositionIndex_39(int32_t value)
	{
		___s_StartPositionIndex_39 = value;
	}

	inline static int32_t get_offset_of_singleton_43() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___singleton_43)); }
	inline NetworkManager_t3335581469 * get_singleton_43() const { return ___singleton_43; }
	inline NetworkManager_t3335581469 ** get_address_of_singleton_43() { return &___singleton_43; }
	inline void set_singleton_43(NetworkManager_t3335581469 * value)
	{
		___singleton_43 = value;
		Il2CppCodeGenWriteBarrier(&___singleton_43, value);
	}

	inline static int32_t get_offset_of_s_AddPlayerMessage_44() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_AddPlayerMessage_44)); }
	inline AddPlayerMessage_t4197260945 * get_s_AddPlayerMessage_44() const { return ___s_AddPlayerMessage_44; }
	inline AddPlayerMessage_t4197260945 ** get_address_of_s_AddPlayerMessage_44() { return &___s_AddPlayerMessage_44; }
	inline void set_s_AddPlayerMessage_44(AddPlayerMessage_t4197260945 * value)
	{
		___s_AddPlayerMessage_44 = value;
		Il2CppCodeGenWriteBarrier(&___s_AddPlayerMessage_44, value);
	}

	inline static int32_t get_offset_of_s_RemovePlayerMessage_45() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_RemovePlayerMessage_45)); }
	inline RemovePlayerMessage_t3520841950 * get_s_RemovePlayerMessage_45() const { return ___s_RemovePlayerMessage_45; }
	inline RemovePlayerMessage_t3520841950 ** get_address_of_s_RemovePlayerMessage_45() { return &___s_RemovePlayerMessage_45; }
	inline void set_s_RemovePlayerMessage_45(RemovePlayerMessage_t3520841950 * value)
	{
		___s_RemovePlayerMessage_45 = value;
		Il2CppCodeGenWriteBarrier(&___s_RemovePlayerMessage_45, value);
	}

	inline static int32_t get_offset_of_s_ErrorMessage_46() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_ErrorMessage_46)); }
	inline ErrorMessage_t775412683 * get_s_ErrorMessage_46() const { return ___s_ErrorMessage_46; }
	inline ErrorMessage_t775412683 ** get_address_of_s_ErrorMessage_46() { return &___s_ErrorMessage_46; }
	inline void set_s_ErrorMessage_46(ErrorMessage_t775412683 * value)
	{
		___s_ErrorMessage_46 = value;
		Il2CppCodeGenWriteBarrier(&___s_ErrorMessage_46, value);
	}

	inline static int32_t get_offset_of_s_LoadingSceneAsync_47() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_LoadingSceneAsync_47)); }
	inline AsyncOperation_t3814632279 * get_s_LoadingSceneAsync_47() const { return ___s_LoadingSceneAsync_47; }
	inline AsyncOperation_t3814632279 ** get_address_of_s_LoadingSceneAsync_47() { return &___s_LoadingSceneAsync_47; }
	inline void set_s_LoadingSceneAsync_47(AsyncOperation_t3814632279 * value)
	{
		___s_LoadingSceneAsync_47 = value;
		Il2CppCodeGenWriteBarrier(&___s_LoadingSceneAsync_47, value);
	}

	inline static int32_t get_offset_of_s_ClientReadyConnection_48() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_ClientReadyConnection_48)); }
	inline NetworkConnection_t107267906 * get_s_ClientReadyConnection_48() const { return ___s_ClientReadyConnection_48; }
	inline NetworkConnection_t107267906 ** get_address_of_s_ClientReadyConnection_48() { return &___s_ClientReadyConnection_48; }
	inline void set_s_ClientReadyConnection_48(NetworkConnection_t107267906 * value)
	{
		___s_ClientReadyConnection_48 = value;
		Il2CppCodeGenWriteBarrier(&___s_ClientReadyConnection_48, value);
	}

	inline static int32_t get_offset_of_s_Address_49() { return static_cast<int32_t>(offsetof(NetworkManager_t3335581469_StaticFields, ___s_Address_49)); }
	inline String_t* get_s_Address_49() const { return ___s_Address_49; }
	inline String_t** get_address_of_s_Address_49() { return &___s_Address_49; }
	inline void set_s_Address_49(String_t* value)
	{
		___s_Address_49 = value;
		Il2CppCodeGenWriteBarrier(&___s_Address_49, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
