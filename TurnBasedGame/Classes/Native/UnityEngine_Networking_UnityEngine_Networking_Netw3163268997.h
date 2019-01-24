#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// UnityEngine.Networking.NetworkReader
struct NetworkReader_t3187690923;
// System.Type
struct Type_t;
// UnityEngine.Networking.HostTopology
struct HostTopology_t3602650143;
// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection>
struct List_1_t3771356334;
// System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Networking.NetworkConnection>
struct ReadOnlyCollection_1_t293053598;
// UnityEngine.Networking.NetworkMessageHandlers
struct NetworkMessageHandlers_t1208103348;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkServerSimple
struct  NetworkServerSimple_t3163268997  : public Il2CppObject
{
public:
	// System.Boolean UnityEngine.Networking.NetworkServerSimple::m_Initialized
	bool ___m_Initialized_0;
	// System.Int32 UnityEngine.Networking.NetworkServerSimple::m_ListenPort
	int32_t ___m_ListenPort_1;
	// System.Int32 UnityEngine.Networking.NetworkServerSimple::m_ServerHostId
	int32_t ___m_ServerHostId_2;
	// System.Int32 UnityEngine.Networking.NetworkServerSimple::m_RelaySlotId
	int32_t ___m_RelaySlotId_3;
	// System.Boolean UnityEngine.Networking.NetworkServerSimple::m_UseWebSockets
	bool ___m_UseWebSockets_4;
	// System.Byte[] UnityEngine.Networking.NetworkServerSimple::m_MsgBuffer
	ByteU5BU5D_t3397334013* ___m_MsgBuffer_5;
	// UnityEngine.Networking.NetworkReader UnityEngine.Networking.NetworkServerSimple::m_MsgReader
	NetworkReader_t3187690923 * ___m_MsgReader_6;
	// System.Type UnityEngine.Networking.NetworkServerSimple::m_NetworkConnectionClass
	Type_t * ___m_NetworkConnectionClass_7;
	// UnityEngine.Networking.HostTopology UnityEngine.Networking.NetworkServerSimple::m_HostTopology
	HostTopology_t3602650143 * ___m_HostTopology_8;
	// System.Collections.Generic.List`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.NetworkServerSimple::m_Connections
	List_1_t3771356334 * ___m_Connections_9;
	// System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Networking.NetworkConnection> UnityEngine.Networking.NetworkServerSimple::m_ConnectionsReadOnly
	ReadOnlyCollection_1_t293053598 * ___m_ConnectionsReadOnly_10;
	// UnityEngine.Networking.NetworkMessageHandlers UnityEngine.Networking.NetworkServerSimple::m_MessageHandlers
	NetworkMessageHandlers_t1208103348 * ___m_MessageHandlers_11;

public:
	inline static int32_t get_offset_of_m_Initialized_0() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_Initialized_0)); }
	inline bool get_m_Initialized_0() const { return ___m_Initialized_0; }
	inline bool* get_address_of_m_Initialized_0() { return &___m_Initialized_0; }
	inline void set_m_Initialized_0(bool value)
	{
		___m_Initialized_0 = value;
	}

	inline static int32_t get_offset_of_m_ListenPort_1() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_ListenPort_1)); }
	inline int32_t get_m_ListenPort_1() const { return ___m_ListenPort_1; }
	inline int32_t* get_address_of_m_ListenPort_1() { return &___m_ListenPort_1; }
	inline void set_m_ListenPort_1(int32_t value)
	{
		___m_ListenPort_1 = value;
	}

	inline static int32_t get_offset_of_m_ServerHostId_2() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_ServerHostId_2)); }
	inline int32_t get_m_ServerHostId_2() const { return ___m_ServerHostId_2; }
	inline int32_t* get_address_of_m_ServerHostId_2() { return &___m_ServerHostId_2; }
	inline void set_m_ServerHostId_2(int32_t value)
	{
		___m_ServerHostId_2 = value;
	}

	inline static int32_t get_offset_of_m_RelaySlotId_3() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_RelaySlotId_3)); }
	inline int32_t get_m_RelaySlotId_3() const { return ___m_RelaySlotId_3; }
	inline int32_t* get_address_of_m_RelaySlotId_3() { return &___m_RelaySlotId_3; }
	inline void set_m_RelaySlotId_3(int32_t value)
	{
		___m_RelaySlotId_3 = value;
	}

	inline static int32_t get_offset_of_m_UseWebSockets_4() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_UseWebSockets_4)); }
	inline bool get_m_UseWebSockets_4() const { return ___m_UseWebSockets_4; }
	inline bool* get_address_of_m_UseWebSockets_4() { return &___m_UseWebSockets_4; }
	inline void set_m_UseWebSockets_4(bool value)
	{
		___m_UseWebSockets_4 = value;
	}

	inline static int32_t get_offset_of_m_MsgBuffer_5() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_MsgBuffer_5)); }
	inline ByteU5BU5D_t3397334013* get_m_MsgBuffer_5() const { return ___m_MsgBuffer_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_m_MsgBuffer_5() { return &___m_MsgBuffer_5; }
	inline void set_m_MsgBuffer_5(ByteU5BU5D_t3397334013* value)
	{
		___m_MsgBuffer_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgBuffer_5, value);
	}

	inline static int32_t get_offset_of_m_MsgReader_6() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_MsgReader_6)); }
	inline NetworkReader_t3187690923 * get_m_MsgReader_6() const { return ___m_MsgReader_6; }
	inline NetworkReader_t3187690923 ** get_address_of_m_MsgReader_6() { return &___m_MsgReader_6; }
	inline void set_m_MsgReader_6(NetworkReader_t3187690923 * value)
	{
		___m_MsgReader_6 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgReader_6, value);
	}

	inline static int32_t get_offset_of_m_NetworkConnectionClass_7() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_NetworkConnectionClass_7)); }
	inline Type_t * get_m_NetworkConnectionClass_7() const { return ___m_NetworkConnectionClass_7; }
	inline Type_t ** get_address_of_m_NetworkConnectionClass_7() { return &___m_NetworkConnectionClass_7; }
	inline void set_m_NetworkConnectionClass_7(Type_t * value)
	{
		___m_NetworkConnectionClass_7 = value;
		Il2CppCodeGenWriteBarrier(&___m_NetworkConnectionClass_7, value);
	}

	inline static int32_t get_offset_of_m_HostTopology_8() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_HostTopology_8)); }
	inline HostTopology_t3602650143 * get_m_HostTopology_8() const { return ___m_HostTopology_8; }
	inline HostTopology_t3602650143 ** get_address_of_m_HostTopology_8() { return &___m_HostTopology_8; }
	inline void set_m_HostTopology_8(HostTopology_t3602650143 * value)
	{
		___m_HostTopology_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_HostTopology_8, value);
	}

	inline static int32_t get_offset_of_m_Connections_9() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_Connections_9)); }
	inline List_1_t3771356334 * get_m_Connections_9() const { return ___m_Connections_9; }
	inline List_1_t3771356334 ** get_address_of_m_Connections_9() { return &___m_Connections_9; }
	inline void set_m_Connections_9(List_1_t3771356334 * value)
	{
		___m_Connections_9 = value;
		Il2CppCodeGenWriteBarrier(&___m_Connections_9, value);
	}

	inline static int32_t get_offset_of_m_ConnectionsReadOnly_10() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_ConnectionsReadOnly_10)); }
	inline ReadOnlyCollection_1_t293053598 * get_m_ConnectionsReadOnly_10() const { return ___m_ConnectionsReadOnly_10; }
	inline ReadOnlyCollection_1_t293053598 ** get_address_of_m_ConnectionsReadOnly_10() { return &___m_ConnectionsReadOnly_10; }
	inline void set_m_ConnectionsReadOnly_10(ReadOnlyCollection_1_t293053598 * value)
	{
		___m_ConnectionsReadOnly_10 = value;
		Il2CppCodeGenWriteBarrier(&___m_ConnectionsReadOnly_10, value);
	}

	inline static int32_t get_offset_of_m_MessageHandlers_11() { return static_cast<int32_t>(offsetof(NetworkServerSimple_t3163268997, ___m_MessageHandlers_11)); }
	inline NetworkMessageHandlers_t1208103348 * get_m_MessageHandlers_11() const { return ___m_MessageHandlers_11; }
	inline NetworkMessageHandlers_t1208103348 ** get_address_of_m_MessageHandlers_11() { return &___m_MessageHandlers_11; }
	inline void set_m_MessageHandlers_11(NetworkMessageHandlers_t1208103348 * value)
	{
		___m_MessageHandlers_11 = value;
		Il2CppCodeGenWriteBarrier(&___m_MessageHandlers_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
