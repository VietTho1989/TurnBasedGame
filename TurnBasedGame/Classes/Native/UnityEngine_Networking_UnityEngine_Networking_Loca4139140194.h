#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netwo696867603.h"

// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient/InternalMsg>
struct List_1_t346742854;
// System.Collections.Generic.Stack`1<UnityEngine.Networking.LocalClient/InternalMsg>
struct Stack_1_t2065349876;
// UnityEngine.Networking.NetworkServer
struct NetworkServer_t3779449791;
// UnityEngine.Networking.NetworkMessage
struct NetworkMessage_t2339216573;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.LocalClient
struct  LocalClient_t4139140194  : public NetworkClient_t696867603
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient/InternalMsg> UnityEngine.Networking.LocalClient::m_InternalMsgs
	List_1_t346742854 * ___m_InternalMsgs_25;
	// System.Collections.Generic.List`1<UnityEngine.Networking.LocalClient/InternalMsg> UnityEngine.Networking.LocalClient::m_InternalMsgs2
	List_1_t346742854 * ___m_InternalMsgs2_26;
	// System.Collections.Generic.Stack`1<UnityEngine.Networking.LocalClient/InternalMsg> UnityEngine.Networking.LocalClient::m_FreeMessages
	Stack_1_t2065349876 * ___m_FreeMessages_27;
	// UnityEngine.Networking.NetworkServer UnityEngine.Networking.LocalClient::m_LocalServer
	NetworkServer_t3779449791 * ___m_LocalServer_28;
	// System.Boolean UnityEngine.Networking.LocalClient::m_Connected
	bool ___m_Connected_29;
	// UnityEngine.Networking.NetworkMessage UnityEngine.Networking.LocalClient::s_InternalMessage
	NetworkMessage_t2339216573 * ___s_InternalMessage_30;

public:
	inline static int32_t get_offset_of_m_InternalMsgs_25() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___m_InternalMsgs_25)); }
	inline List_1_t346742854 * get_m_InternalMsgs_25() const { return ___m_InternalMsgs_25; }
	inline List_1_t346742854 ** get_address_of_m_InternalMsgs_25() { return &___m_InternalMsgs_25; }
	inline void set_m_InternalMsgs_25(List_1_t346742854 * value)
	{
		___m_InternalMsgs_25 = value;
		Il2CppCodeGenWriteBarrier(&___m_InternalMsgs_25, value);
	}

	inline static int32_t get_offset_of_m_InternalMsgs2_26() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___m_InternalMsgs2_26)); }
	inline List_1_t346742854 * get_m_InternalMsgs2_26() const { return ___m_InternalMsgs2_26; }
	inline List_1_t346742854 ** get_address_of_m_InternalMsgs2_26() { return &___m_InternalMsgs2_26; }
	inline void set_m_InternalMsgs2_26(List_1_t346742854 * value)
	{
		___m_InternalMsgs2_26 = value;
		Il2CppCodeGenWriteBarrier(&___m_InternalMsgs2_26, value);
	}

	inline static int32_t get_offset_of_m_FreeMessages_27() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___m_FreeMessages_27)); }
	inline Stack_1_t2065349876 * get_m_FreeMessages_27() const { return ___m_FreeMessages_27; }
	inline Stack_1_t2065349876 ** get_address_of_m_FreeMessages_27() { return &___m_FreeMessages_27; }
	inline void set_m_FreeMessages_27(Stack_1_t2065349876 * value)
	{
		___m_FreeMessages_27 = value;
		Il2CppCodeGenWriteBarrier(&___m_FreeMessages_27, value);
	}

	inline static int32_t get_offset_of_m_LocalServer_28() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___m_LocalServer_28)); }
	inline NetworkServer_t3779449791 * get_m_LocalServer_28() const { return ___m_LocalServer_28; }
	inline NetworkServer_t3779449791 ** get_address_of_m_LocalServer_28() { return &___m_LocalServer_28; }
	inline void set_m_LocalServer_28(NetworkServer_t3779449791 * value)
	{
		___m_LocalServer_28 = value;
		Il2CppCodeGenWriteBarrier(&___m_LocalServer_28, value);
	}

	inline static int32_t get_offset_of_m_Connected_29() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___m_Connected_29)); }
	inline bool get_m_Connected_29() const { return ___m_Connected_29; }
	inline bool* get_address_of_m_Connected_29() { return &___m_Connected_29; }
	inline void set_m_Connected_29(bool value)
	{
		___m_Connected_29 = value;
	}

	inline static int32_t get_offset_of_s_InternalMessage_30() { return static_cast<int32_t>(offsetof(LocalClient_t4139140194, ___s_InternalMessage_30)); }
	inline NetworkMessage_t2339216573 * get_s_InternalMessage_30() const { return ___s_InternalMessage_30; }
	inline NetworkMessage_t2339216573 ** get_address_of_s_InternalMessage_30() { return &___s_InternalMessage_30; }
	inline void set_s_InternalMessage_30(NetworkMessage_t2339216573 * value)
	{
		___s_InternalMessage_30 = value;
		Il2CppCodeGenWriteBarrier(&___s_InternalMessage_30, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
