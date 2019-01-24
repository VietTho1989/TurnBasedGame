#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController>
struct List_1_t4277013949;
// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.NetworkSceneId,UnityEngine.Networking.NetworkIdentity>
struct Dictionary_2_t2517038154;
// UnityEngine.Networking.NetworkScene
struct NetworkScene_t2622094906;
// UnityEngine.Networking.NetworkSystem.ObjectSpawnSceneMessage
struct ObjectSpawnSceneMessage_t3027639263;
// UnityEngine.Networking.NetworkSystem.ObjectSpawnFinishedMessage
struct ObjectSpawnFinishedMessage_t3823788215;
// UnityEngine.Networking.NetworkSystem.ObjectDestroyMessage
struct ObjectDestroyMessage_t3106274748;
// UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage
struct ObjectSpawnMessage_t320416085;
// UnityEngine.Networking.NetworkSystem.OwnerMessage
struct OwnerMessage_t225159112;
// UnityEngine.Networking.NetworkSystem.ClientAuthorityMessage
struct ClientAuthorityMessage_t648218179;
// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[]
struct PeerInfoMessageU5BU5D_t2669814294;
// System.Collections.Generic.List`1<UnityEngine.Networking.ClientScene/PendingOwner>
struct List_1_t246940051;
// UnityEngine.Networking.NetworkMessageDelegate
struct NetworkMessageDelegate_t1861659952;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ClientScene
struct  ClientScene_t3650307179  : public Il2CppObject
{
public:

public:
};

struct ClientScene_t3650307179_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.PlayerController> UnityEngine.Networking.ClientScene::s_LocalPlayers
	List_1_t4277013949 * ___s_LocalPlayers_0;
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.ClientScene::s_ReadyConnection
	NetworkConnection_t107267906 * ___s_ReadyConnection_1;
	// System.Collections.Generic.Dictionary`2<UnityEngine.Networking.NetworkSceneId,UnityEngine.Networking.NetworkIdentity> UnityEngine.Networking.ClientScene::s_SpawnableObjects
	Dictionary_2_t2517038154 * ___s_SpawnableObjects_2;
	// System.Boolean UnityEngine.Networking.ClientScene::s_IsReady
	bool ___s_IsReady_3;
	// System.Boolean UnityEngine.Networking.ClientScene::s_IsSpawnFinished
	bool ___s_IsSpawnFinished_4;
	// UnityEngine.Networking.NetworkScene UnityEngine.Networking.ClientScene::s_NetworkScene
	NetworkScene_t2622094906 * ___s_NetworkScene_5;
	// UnityEngine.Networking.NetworkSystem.ObjectSpawnSceneMessage UnityEngine.Networking.ClientScene::s_ObjectSpawnSceneMessage
	ObjectSpawnSceneMessage_t3027639263 * ___s_ObjectSpawnSceneMessage_6;
	// UnityEngine.Networking.NetworkSystem.ObjectSpawnFinishedMessage UnityEngine.Networking.ClientScene::s_ObjectSpawnFinishedMessage
	ObjectSpawnFinishedMessage_t3823788215 * ___s_ObjectSpawnFinishedMessage_7;
	// UnityEngine.Networking.NetworkSystem.ObjectDestroyMessage UnityEngine.Networking.ClientScene::s_ObjectDestroyMessage
	ObjectDestroyMessage_t3106274748 * ___s_ObjectDestroyMessage_8;
	// UnityEngine.Networking.NetworkSystem.ObjectSpawnMessage UnityEngine.Networking.ClientScene::s_ObjectSpawnMessage
	ObjectSpawnMessage_t320416085 * ___s_ObjectSpawnMessage_9;
	// UnityEngine.Networking.NetworkSystem.OwnerMessage UnityEngine.Networking.ClientScene::s_OwnerMessage
	OwnerMessage_t225159112 * ___s_OwnerMessage_10;
	// UnityEngine.Networking.NetworkSystem.ClientAuthorityMessage UnityEngine.Networking.ClientScene::s_ClientAuthorityMessage
	ClientAuthorityMessage_t648218179 * ___s_ClientAuthorityMessage_11;
	// System.Int32 UnityEngine.Networking.ClientScene::s_ReconnectId
	int32_t ___s_ReconnectId_14;
	// UnityEngine.Networking.NetworkSystem.PeerInfoMessage[] UnityEngine.Networking.ClientScene::s_Peers
	PeerInfoMessageU5BU5D_t2669814294* ___s_Peers_15;
	// System.Collections.Generic.List`1<UnityEngine.Networking.ClientScene/PendingOwner> UnityEngine.Networking.ClientScene::s_PendingOwnerIds
	List_1_t246940051 * ___s_PendingOwnerIds_16;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache0
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache0_17;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache1
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache1_18;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache2
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache2_19;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache3
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache3_20;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache4
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache4_21;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache5
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache5_22;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache6
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache6_23;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache7
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache7_24;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache8
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache8_25;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache9
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache9_26;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheA
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheA_27;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheB
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheB_28;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheC
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheC_29;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheD
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheD_30;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheE
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheE_31;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cacheF
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cacheF_32;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache10
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache10_33;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache11
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache11_34;
	// UnityEngine.Networking.NetworkMessageDelegate UnityEngine.Networking.ClientScene::<>f__mg$cache12
	NetworkMessageDelegate_t1861659952 * ___U3CU3Ef__mgU24cache12_35;

public:
	inline static int32_t get_offset_of_s_LocalPlayers_0() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_LocalPlayers_0)); }
	inline List_1_t4277013949 * get_s_LocalPlayers_0() const { return ___s_LocalPlayers_0; }
	inline List_1_t4277013949 ** get_address_of_s_LocalPlayers_0() { return &___s_LocalPlayers_0; }
	inline void set_s_LocalPlayers_0(List_1_t4277013949 * value)
	{
		___s_LocalPlayers_0 = value;
		Il2CppCodeGenWriteBarrier(&___s_LocalPlayers_0, value);
	}

	inline static int32_t get_offset_of_s_ReadyConnection_1() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ReadyConnection_1)); }
	inline NetworkConnection_t107267906 * get_s_ReadyConnection_1() const { return ___s_ReadyConnection_1; }
	inline NetworkConnection_t107267906 ** get_address_of_s_ReadyConnection_1() { return &___s_ReadyConnection_1; }
	inline void set_s_ReadyConnection_1(NetworkConnection_t107267906 * value)
	{
		___s_ReadyConnection_1 = value;
		Il2CppCodeGenWriteBarrier(&___s_ReadyConnection_1, value);
	}

	inline static int32_t get_offset_of_s_SpawnableObjects_2() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_SpawnableObjects_2)); }
	inline Dictionary_2_t2517038154 * get_s_SpawnableObjects_2() const { return ___s_SpawnableObjects_2; }
	inline Dictionary_2_t2517038154 ** get_address_of_s_SpawnableObjects_2() { return &___s_SpawnableObjects_2; }
	inline void set_s_SpawnableObjects_2(Dictionary_2_t2517038154 * value)
	{
		___s_SpawnableObjects_2 = value;
		Il2CppCodeGenWriteBarrier(&___s_SpawnableObjects_2, value);
	}

	inline static int32_t get_offset_of_s_IsReady_3() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_IsReady_3)); }
	inline bool get_s_IsReady_3() const { return ___s_IsReady_3; }
	inline bool* get_address_of_s_IsReady_3() { return &___s_IsReady_3; }
	inline void set_s_IsReady_3(bool value)
	{
		___s_IsReady_3 = value;
	}

	inline static int32_t get_offset_of_s_IsSpawnFinished_4() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_IsSpawnFinished_4)); }
	inline bool get_s_IsSpawnFinished_4() const { return ___s_IsSpawnFinished_4; }
	inline bool* get_address_of_s_IsSpawnFinished_4() { return &___s_IsSpawnFinished_4; }
	inline void set_s_IsSpawnFinished_4(bool value)
	{
		___s_IsSpawnFinished_4 = value;
	}

	inline static int32_t get_offset_of_s_NetworkScene_5() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_NetworkScene_5)); }
	inline NetworkScene_t2622094906 * get_s_NetworkScene_5() const { return ___s_NetworkScene_5; }
	inline NetworkScene_t2622094906 ** get_address_of_s_NetworkScene_5() { return &___s_NetworkScene_5; }
	inline void set_s_NetworkScene_5(NetworkScene_t2622094906 * value)
	{
		___s_NetworkScene_5 = value;
		Il2CppCodeGenWriteBarrier(&___s_NetworkScene_5, value);
	}

	inline static int32_t get_offset_of_s_ObjectSpawnSceneMessage_6() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ObjectSpawnSceneMessage_6)); }
	inline ObjectSpawnSceneMessage_t3027639263 * get_s_ObjectSpawnSceneMessage_6() const { return ___s_ObjectSpawnSceneMessage_6; }
	inline ObjectSpawnSceneMessage_t3027639263 ** get_address_of_s_ObjectSpawnSceneMessage_6() { return &___s_ObjectSpawnSceneMessage_6; }
	inline void set_s_ObjectSpawnSceneMessage_6(ObjectSpawnSceneMessage_t3027639263 * value)
	{
		___s_ObjectSpawnSceneMessage_6 = value;
		Il2CppCodeGenWriteBarrier(&___s_ObjectSpawnSceneMessage_6, value);
	}

	inline static int32_t get_offset_of_s_ObjectSpawnFinishedMessage_7() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ObjectSpawnFinishedMessage_7)); }
	inline ObjectSpawnFinishedMessage_t3823788215 * get_s_ObjectSpawnFinishedMessage_7() const { return ___s_ObjectSpawnFinishedMessage_7; }
	inline ObjectSpawnFinishedMessage_t3823788215 ** get_address_of_s_ObjectSpawnFinishedMessage_7() { return &___s_ObjectSpawnFinishedMessage_7; }
	inline void set_s_ObjectSpawnFinishedMessage_7(ObjectSpawnFinishedMessage_t3823788215 * value)
	{
		___s_ObjectSpawnFinishedMessage_7 = value;
		Il2CppCodeGenWriteBarrier(&___s_ObjectSpawnFinishedMessage_7, value);
	}

	inline static int32_t get_offset_of_s_ObjectDestroyMessage_8() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ObjectDestroyMessage_8)); }
	inline ObjectDestroyMessage_t3106274748 * get_s_ObjectDestroyMessage_8() const { return ___s_ObjectDestroyMessage_8; }
	inline ObjectDestroyMessage_t3106274748 ** get_address_of_s_ObjectDestroyMessage_8() { return &___s_ObjectDestroyMessage_8; }
	inline void set_s_ObjectDestroyMessage_8(ObjectDestroyMessage_t3106274748 * value)
	{
		___s_ObjectDestroyMessage_8 = value;
		Il2CppCodeGenWriteBarrier(&___s_ObjectDestroyMessage_8, value);
	}

	inline static int32_t get_offset_of_s_ObjectSpawnMessage_9() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ObjectSpawnMessage_9)); }
	inline ObjectSpawnMessage_t320416085 * get_s_ObjectSpawnMessage_9() const { return ___s_ObjectSpawnMessage_9; }
	inline ObjectSpawnMessage_t320416085 ** get_address_of_s_ObjectSpawnMessage_9() { return &___s_ObjectSpawnMessage_9; }
	inline void set_s_ObjectSpawnMessage_9(ObjectSpawnMessage_t320416085 * value)
	{
		___s_ObjectSpawnMessage_9 = value;
		Il2CppCodeGenWriteBarrier(&___s_ObjectSpawnMessage_9, value);
	}

	inline static int32_t get_offset_of_s_OwnerMessage_10() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_OwnerMessage_10)); }
	inline OwnerMessage_t225159112 * get_s_OwnerMessage_10() const { return ___s_OwnerMessage_10; }
	inline OwnerMessage_t225159112 ** get_address_of_s_OwnerMessage_10() { return &___s_OwnerMessage_10; }
	inline void set_s_OwnerMessage_10(OwnerMessage_t225159112 * value)
	{
		___s_OwnerMessage_10 = value;
		Il2CppCodeGenWriteBarrier(&___s_OwnerMessage_10, value);
	}

	inline static int32_t get_offset_of_s_ClientAuthorityMessage_11() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ClientAuthorityMessage_11)); }
	inline ClientAuthorityMessage_t648218179 * get_s_ClientAuthorityMessage_11() const { return ___s_ClientAuthorityMessage_11; }
	inline ClientAuthorityMessage_t648218179 ** get_address_of_s_ClientAuthorityMessage_11() { return &___s_ClientAuthorityMessage_11; }
	inline void set_s_ClientAuthorityMessage_11(ClientAuthorityMessage_t648218179 * value)
	{
		___s_ClientAuthorityMessage_11 = value;
		Il2CppCodeGenWriteBarrier(&___s_ClientAuthorityMessage_11, value);
	}

	inline static int32_t get_offset_of_s_ReconnectId_14() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_ReconnectId_14)); }
	inline int32_t get_s_ReconnectId_14() const { return ___s_ReconnectId_14; }
	inline int32_t* get_address_of_s_ReconnectId_14() { return &___s_ReconnectId_14; }
	inline void set_s_ReconnectId_14(int32_t value)
	{
		___s_ReconnectId_14 = value;
	}

	inline static int32_t get_offset_of_s_Peers_15() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_Peers_15)); }
	inline PeerInfoMessageU5BU5D_t2669814294* get_s_Peers_15() const { return ___s_Peers_15; }
	inline PeerInfoMessageU5BU5D_t2669814294** get_address_of_s_Peers_15() { return &___s_Peers_15; }
	inline void set_s_Peers_15(PeerInfoMessageU5BU5D_t2669814294* value)
	{
		___s_Peers_15 = value;
		Il2CppCodeGenWriteBarrier(&___s_Peers_15, value);
	}

	inline static int32_t get_offset_of_s_PendingOwnerIds_16() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___s_PendingOwnerIds_16)); }
	inline List_1_t246940051 * get_s_PendingOwnerIds_16() const { return ___s_PendingOwnerIds_16; }
	inline List_1_t246940051 ** get_address_of_s_PendingOwnerIds_16() { return &___s_PendingOwnerIds_16; }
	inline void set_s_PendingOwnerIds_16(List_1_t246940051 * value)
	{
		___s_PendingOwnerIds_16 = value;
		Il2CppCodeGenWriteBarrier(&___s_PendingOwnerIds_16, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_17() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache0_17)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache0_17() const { return ___U3CU3Ef__mgU24cache0_17; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache0_17() { return &___U3CU3Ef__mgU24cache0_17; }
	inline void set_U3CU3Ef__mgU24cache0_17(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache0_17 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_17, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_18() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache1_18)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache1_18() const { return ___U3CU3Ef__mgU24cache1_18; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache1_18() { return &___U3CU3Ef__mgU24cache1_18; }
	inline void set_U3CU3Ef__mgU24cache1_18(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache1_18 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache1_18, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache2_19() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache2_19)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache2_19() const { return ___U3CU3Ef__mgU24cache2_19; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache2_19() { return &___U3CU3Ef__mgU24cache2_19; }
	inline void set_U3CU3Ef__mgU24cache2_19(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache2_19 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache2_19, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache3_20() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache3_20)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache3_20() const { return ___U3CU3Ef__mgU24cache3_20; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache3_20() { return &___U3CU3Ef__mgU24cache3_20; }
	inline void set_U3CU3Ef__mgU24cache3_20(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache3_20 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache3_20, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache4_21() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache4_21)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache4_21() const { return ___U3CU3Ef__mgU24cache4_21; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache4_21() { return &___U3CU3Ef__mgU24cache4_21; }
	inline void set_U3CU3Ef__mgU24cache4_21(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache4_21 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache4_21, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache5_22() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache5_22)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache5_22() const { return ___U3CU3Ef__mgU24cache5_22; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache5_22() { return &___U3CU3Ef__mgU24cache5_22; }
	inline void set_U3CU3Ef__mgU24cache5_22(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache5_22 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache5_22, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache6_23() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache6_23)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache6_23() const { return ___U3CU3Ef__mgU24cache6_23; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache6_23() { return &___U3CU3Ef__mgU24cache6_23; }
	inline void set_U3CU3Ef__mgU24cache6_23(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache6_23 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache6_23, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache7_24() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache7_24)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache7_24() const { return ___U3CU3Ef__mgU24cache7_24; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache7_24() { return &___U3CU3Ef__mgU24cache7_24; }
	inline void set_U3CU3Ef__mgU24cache7_24(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache7_24 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache7_24, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache8_25() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache8_25)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache8_25() const { return ___U3CU3Ef__mgU24cache8_25; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache8_25() { return &___U3CU3Ef__mgU24cache8_25; }
	inline void set_U3CU3Ef__mgU24cache8_25(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache8_25 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache8_25, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache9_26() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache9_26)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache9_26() const { return ___U3CU3Ef__mgU24cache9_26; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache9_26() { return &___U3CU3Ef__mgU24cache9_26; }
	inline void set_U3CU3Ef__mgU24cache9_26(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache9_26 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache9_26, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheA_27() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheA_27)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheA_27() const { return ___U3CU3Ef__mgU24cacheA_27; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheA_27() { return &___U3CU3Ef__mgU24cacheA_27; }
	inline void set_U3CU3Ef__mgU24cacheA_27(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheA_27 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheA_27, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheB_28() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheB_28)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheB_28() const { return ___U3CU3Ef__mgU24cacheB_28; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheB_28() { return &___U3CU3Ef__mgU24cacheB_28; }
	inline void set_U3CU3Ef__mgU24cacheB_28(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheB_28 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheB_28, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheC_29() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheC_29)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheC_29() const { return ___U3CU3Ef__mgU24cacheC_29; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheC_29() { return &___U3CU3Ef__mgU24cacheC_29; }
	inline void set_U3CU3Ef__mgU24cacheC_29(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheC_29 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheC_29, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheD_30() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheD_30)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheD_30() const { return ___U3CU3Ef__mgU24cacheD_30; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheD_30() { return &___U3CU3Ef__mgU24cacheD_30; }
	inline void set_U3CU3Ef__mgU24cacheD_30(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheD_30 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheD_30, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheE_31() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheE_31)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheE_31() const { return ___U3CU3Ef__mgU24cacheE_31; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheE_31() { return &___U3CU3Ef__mgU24cacheE_31; }
	inline void set_U3CU3Ef__mgU24cacheE_31(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheE_31 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheE_31, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheF_32() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cacheF_32)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cacheF_32() const { return ___U3CU3Ef__mgU24cacheF_32; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cacheF_32() { return &___U3CU3Ef__mgU24cacheF_32; }
	inline void set_U3CU3Ef__mgU24cacheF_32(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cacheF_32 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cacheF_32, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache10_33() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache10_33)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache10_33() const { return ___U3CU3Ef__mgU24cache10_33; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache10_33() { return &___U3CU3Ef__mgU24cache10_33; }
	inline void set_U3CU3Ef__mgU24cache10_33(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache10_33 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache10_33, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache11_34() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache11_34)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache11_34() const { return ___U3CU3Ef__mgU24cache11_34; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache11_34() { return &___U3CU3Ef__mgU24cache11_34; }
	inline void set_U3CU3Ef__mgU24cache11_34(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache11_34 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache11_34, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache12_35() { return static_cast<int32_t>(offsetof(ClientScene_t3650307179_StaticFields, ___U3CU3Ef__mgU24cache12_35)); }
	inline NetworkMessageDelegate_t1861659952 * get_U3CU3Ef__mgU24cache12_35() const { return ___U3CU3Ef__mgU24cache12_35; }
	inline NetworkMessageDelegate_t1861659952 ** get_address_of_U3CU3Ef__mgU24cache12_35() { return &___U3CU3Ef__mgU24cache12_35; }
	inline void set_U3CU3Ef__mgU24cache12_35(NetworkMessageDelegate_t1861659952 * value)
	{
		___U3CU3Ef__mgU24cache12_35 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache12_35, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
