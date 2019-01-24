#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netw2931030083.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Netwo835211239.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Networ33998832.h"

// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// UnityEngine.Networking.NetworkBehaviour[]
struct NetworkBehaviourU5BU5D_t2137248684;
// System.Collections.Generic.HashSet`1<System.Int32>
struct HashSet_1_t405338302;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection>
struct List_1_t3771356334;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;
// UnityEngine.Networking.NetworkIdentity/ClientAuthorityCallback
struct ClientAuthorityCallback_t482382839;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkIdentity
struct  NetworkIdentity_t1766639790  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Networking.NetworkSceneId UnityEngine.Networking.NetworkIdentity::m_SceneId
	NetworkSceneId_t2931030083  ___m_SceneId_2;
	// UnityEngine.Networking.NetworkHash128 UnityEngine.Networking.NetworkIdentity::m_AssetId
	NetworkHash128_t835211239  ___m_AssetId_3;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_ServerOnly
	bool ___m_ServerOnly_4;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_LocalPlayerAuthority
	bool ___m_LocalPlayerAuthority_5;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsClient
	bool ___m_IsClient_6;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsServer
	bool ___m_IsServer_7;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_HasAuthority
	bool ___m_HasAuthority_8;
	// UnityEngine.Networking.NetworkInstanceId UnityEngine.Networking.NetworkIdentity::m_NetId
	NetworkInstanceId_t33998832  ___m_NetId_9;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_IsLocalPlayer
	bool ___m_IsLocalPlayer_10;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ConnectionToServer
	NetworkConnection_t107267906 * ___m_ConnectionToServer_11;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ConnectionToClient
	NetworkConnection_t107267906 * ___m_ConnectionToClient_12;
	// System.Int16 UnityEngine.Networking.NetworkIdentity::m_PlayerId
	int16_t ___m_PlayerId_13;
	// UnityEngine.Networking.NetworkBehaviour[] UnityEngine.Networking.NetworkIdentity::m_NetworkBehaviours
	NetworkBehaviourU5BU5D_t2137248684* ___m_NetworkBehaviours_14;
	// System.Collections.Generic.HashSet`1<System.Int32> UnityEngine.Networking.NetworkIdentity::m_ObserverConnections
	HashSet_1_t405338302 * ___m_ObserverConnections_15;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.NetworkIdentity::m_Observers
	List_1_t3771356334 * ___m_Observers_16;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.NetworkIdentity::m_ClientAuthorityOwner
	NetworkConnection_t107267906 * ___m_ClientAuthorityOwner_17;
	// System.Boolean UnityEngine.Networking.NetworkIdentity::m_Reset
	bool ___m_Reset_18;

public:
	inline static int32_t get_offset_of_m_SceneId_2() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_SceneId_2)); }
	inline NetworkSceneId_t2931030083  get_m_SceneId_2() const { return ___m_SceneId_2; }
	inline NetworkSceneId_t2931030083 * get_address_of_m_SceneId_2() { return &___m_SceneId_2; }
	inline void set_m_SceneId_2(NetworkSceneId_t2931030083  value)
	{
		___m_SceneId_2 = value;
	}

	inline static int32_t get_offset_of_m_AssetId_3() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_AssetId_3)); }
	inline NetworkHash128_t835211239  get_m_AssetId_3() const { return ___m_AssetId_3; }
	inline NetworkHash128_t835211239 * get_address_of_m_AssetId_3() { return &___m_AssetId_3; }
	inline void set_m_AssetId_3(NetworkHash128_t835211239  value)
	{
		___m_AssetId_3 = value;
	}

	inline static int32_t get_offset_of_m_ServerOnly_4() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_ServerOnly_4)); }
	inline bool get_m_ServerOnly_4() const { return ___m_ServerOnly_4; }
	inline bool* get_address_of_m_ServerOnly_4() { return &___m_ServerOnly_4; }
	inline void set_m_ServerOnly_4(bool value)
	{
		___m_ServerOnly_4 = value;
	}

	inline static int32_t get_offset_of_m_LocalPlayerAuthority_5() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_LocalPlayerAuthority_5)); }
	inline bool get_m_LocalPlayerAuthority_5() const { return ___m_LocalPlayerAuthority_5; }
	inline bool* get_address_of_m_LocalPlayerAuthority_5() { return &___m_LocalPlayerAuthority_5; }
	inline void set_m_LocalPlayerAuthority_5(bool value)
	{
		___m_LocalPlayerAuthority_5 = value;
	}

	inline static int32_t get_offset_of_m_IsClient_6() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_IsClient_6)); }
	inline bool get_m_IsClient_6() const { return ___m_IsClient_6; }
	inline bool* get_address_of_m_IsClient_6() { return &___m_IsClient_6; }
	inline void set_m_IsClient_6(bool value)
	{
		___m_IsClient_6 = value;
	}

	inline static int32_t get_offset_of_m_IsServer_7() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_IsServer_7)); }
	inline bool get_m_IsServer_7() const { return ___m_IsServer_7; }
	inline bool* get_address_of_m_IsServer_7() { return &___m_IsServer_7; }
	inline void set_m_IsServer_7(bool value)
	{
		___m_IsServer_7 = value;
	}

	inline static int32_t get_offset_of_m_HasAuthority_8() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_HasAuthority_8)); }
	inline bool get_m_HasAuthority_8() const { return ___m_HasAuthority_8; }
	inline bool* get_address_of_m_HasAuthority_8() { return &___m_HasAuthority_8; }
	inline void set_m_HasAuthority_8(bool value)
	{
		___m_HasAuthority_8 = value;
	}

	inline static int32_t get_offset_of_m_NetId_9() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_NetId_9)); }
	inline NetworkInstanceId_t33998832  get_m_NetId_9() const { return ___m_NetId_9; }
	inline NetworkInstanceId_t33998832 * get_address_of_m_NetId_9() { return &___m_NetId_9; }
	inline void set_m_NetId_9(NetworkInstanceId_t33998832  value)
	{
		___m_NetId_9 = value;
	}

	inline static int32_t get_offset_of_m_IsLocalPlayer_10() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_IsLocalPlayer_10)); }
	inline bool get_m_IsLocalPlayer_10() const { return ___m_IsLocalPlayer_10; }
	inline bool* get_address_of_m_IsLocalPlayer_10() { return &___m_IsLocalPlayer_10; }
	inline void set_m_IsLocalPlayer_10(bool value)
	{
		___m_IsLocalPlayer_10 = value;
	}

	inline static int32_t get_offset_of_m_ConnectionToServer_11() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_ConnectionToServer_11)); }
	inline NetworkConnection_t107267906 * get_m_ConnectionToServer_11() const { return ___m_ConnectionToServer_11; }
	inline NetworkConnection_t107267906 ** get_address_of_m_ConnectionToServer_11() { return &___m_ConnectionToServer_11; }
	inline void set_m_ConnectionToServer_11(NetworkConnection_t107267906 * value)
	{
		___m_ConnectionToServer_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_ConnectionToServer_11, value);
	}

	inline static int32_t get_offset_of_m_ConnectionToClient_12() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_ConnectionToClient_12)); }
	inline NetworkConnection_t107267906 * get_m_ConnectionToClient_12() const { return ___m_ConnectionToClient_12; }
	inline NetworkConnection_t107267906 ** get_address_of_m_ConnectionToClient_12() { return &___m_ConnectionToClient_12; }
	inline void set_m_ConnectionToClient_12(NetworkConnection_t107267906 * value)
	{
		___m_ConnectionToClient_12 = value;
		Il2CppCodeGenWriteBarrier(&___m_ConnectionToClient_12, value);
	}

	inline static int32_t get_offset_of_m_PlayerId_13() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_PlayerId_13)); }
	inline int16_t get_m_PlayerId_13() const { return ___m_PlayerId_13; }
	inline int16_t* get_address_of_m_PlayerId_13() { return &___m_PlayerId_13; }
	inline void set_m_PlayerId_13(int16_t value)
	{
		___m_PlayerId_13 = value;
	}

	inline static int32_t get_offset_of_m_NetworkBehaviours_14() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_NetworkBehaviours_14)); }
	inline NetworkBehaviourU5BU5D_t2137248684* get_m_NetworkBehaviours_14() const { return ___m_NetworkBehaviours_14; }
	inline NetworkBehaviourU5BU5D_t2137248684** get_address_of_m_NetworkBehaviours_14() { return &___m_NetworkBehaviours_14; }
	inline void set_m_NetworkBehaviours_14(NetworkBehaviourU5BU5D_t2137248684* value)
	{
		___m_NetworkBehaviours_14 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetworkBehaviours_14, value);
	}

	inline static int32_t get_offset_of_m_ObserverConnections_15() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_ObserverConnections_15)); }
	inline HashSet_1_t405338302 * get_m_ObserverConnections_15() const { return ___m_ObserverConnections_15; }
	inline HashSet_1_t405338302 ** get_address_of_m_ObserverConnections_15() { return &___m_ObserverConnections_15; }
	inline void set_m_ObserverConnections_15(HashSet_1_t405338302 * value)
	{
		___m_ObserverConnections_15 = value;
		Il2CppCodeGenWriteBarrier(&___m_ObserverConnections_15, value);
	}

	inline static int32_t get_offset_of_m_Observers_16() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_Observers_16)); }
	inline List_1_t3771356334 * get_m_Observers_16() const { return ___m_Observers_16; }
	inline List_1_t3771356334 ** get_address_of_m_Observers_16() { return &___m_Observers_16; }
	inline void set_m_Observers_16(List_1_t3771356334 * value)
	{
		___m_Observers_16 = value;
		Il2CppCodeGenWriteBarrier(&___m_Observers_16, value);
	}

	inline static int32_t get_offset_of_m_ClientAuthorityOwner_17() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_ClientAuthorityOwner_17)); }
	inline NetworkConnection_t107267906 * get_m_ClientAuthorityOwner_17() const { return ___m_ClientAuthorityOwner_17; }
	inline NetworkConnection_t107267906 ** get_address_of_m_ClientAuthorityOwner_17() { return &___m_ClientAuthorityOwner_17; }
	inline void set_m_ClientAuthorityOwner_17(NetworkConnection_t107267906 * value)
	{
		___m_ClientAuthorityOwner_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_ClientAuthorityOwner_17, value);
	}

	inline static int32_t get_offset_of_m_Reset_18() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790, ___m_Reset_18)); }
	inline bool get_m_Reset_18() const { return ___m_Reset_18; }
	inline bool* get_address_of_m_Reset_18() { return &___m_Reset_18; }
	inline void set_m_Reset_18(bool value)
	{
		___m_Reset_18 = value;
	}
};

struct NetworkIdentity_t1766639790_StaticFields
{
public:
	// System.UInt32 UnityEngine.Networking.NetworkIdentity::s_NextNetworkId
	uint32_t ___s_NextNetworkId_19;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkIdentity::s_UpdateWriter
	NetworkWriter_t560143343 * ___s_UpdateWriter_20;
	// UnityEngine.Networking.NetworkIdentity/ClientAuthorityCallback UnityEngine.Networking.NetworkIdentity::clientAuthorityCallback
	ClientAuthorityCallback_t482382839 * ___clientAuthorityCallback_21;

public:
	inline static int32_t get_offset_of_s_NextNetworkId_19() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790_StaticFields, ___s_NextNetworkId_19)); }
	inline uint32_t get_s_NextNetworkId_19() const { return ___s_NextNetworkId_19; }
	inline uint32_t* get_address_of_s_NextNetworkId_19() { return &___s_NextNetworkId_19; }
	inline void set_s_NextNetworkId_19(uint32_t value)
	{
		___s_NextNetworkId_19 = value;
	}

	inline static int32_t get_offset_of_s_UpdateWriter_20() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790_StaticFields, ___s_UpdateWriter_20)); }
	inline NetworkWriter_t560143343 * get_s_UpdateWriter_20() const { return ___s_UpdateWriter_20; }
	inline NetworkWriter_t560143343 ** get_address_of_s_UpdateWriter_20() { return &___s_UpdateWriter_20; }
	inline void set_s_UpdateWriter_20(NetworkWriter_t560143343 * value)
	{
		___s_UpdateWriter_20 = value;
		Il2CppCodeGenWriteBarrier(&___s_UpdateWriter_20, value);
	}

	inline static int32_t get_offset_of_clientAuthorityCallback_21() { return static_cast<int32_t>(offsetof(NetworkIdentity_t1766639790_StaticFields, ___clientAuthorityCallback_21)); }
	inline ClientAuthorityCallback_t482382839 * get_clientAuthorityCallback_21() const { return ___clientAuthorityCallback_21; }
	inline ClientAuthorityCallback_t482382839 ** get_address_of_clientAuthorityCallback_21() { return &___clientAuthorityCallback_21; }
	inline void set_clientAuthorityCallback_21(ClientAuthorityCallback_t482382839 * value)
	{
		___clientAuthorityCallback_21 = value;
		Il2CppCodeGenWriteBarrier(&___clientAuthorityCallback_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
