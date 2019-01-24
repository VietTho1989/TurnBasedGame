#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// UnityEngine.Networking.HostTopology
struct HostTopology_t3602650143;
// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.Networking.NetworkBroadcastResult>
struct Dictionary_2_t2561097244;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkDiscovery
struct  NetworkDiscovery_t3838653650  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_BroadcastPort
	int32_t ___m_BroadcastPort_3;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_BroadcastKey
	int32_t ___m_BroadcastKey_4;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_BroadcastVersion
	int32_t ___m_BroadcastVersion_5;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_BroadcastSubVersion
	int32_t ___m_BroadcastSubVersion_6;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_BroadcastInterval
	int32_t ___m_BroadcastInterval_7;
	// System.Boolean UnityEngine.Networking.NetworkDiscovery::m_UseNetworkManager
	bool ___m_UseNetworkManager_8;
	// System.String UnityEngine.Networking.NetworkDiscovery::m_BroadcastData
	String_t* ___m_BroadcastData_9;
	// System.Boolean UnityEngine.Networking.NetworkDiscovery::m_ShowGUI
	bool ___m_ShowGUI_10;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_OffsetX
	int32_t ___m_OffsetX_11;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_OffsetY
	int32_t ___m_OffsetY_12;
	// System.Int32 UnityEngine.Networking.NetworkDiscovery::m_HostId
	int32_t ___m_HostId_13;
	// System.Boolean UnityEngine.Networking.NetworkDiscovery::m_Running
	bool ___m_Running_14;
	// System.Boolean UnityEngine.Networking.NetworkDiscovery::m_IsServer
	bool ___m_IsServer_15;
	// System.Boolean UnityEngine.Networking.NetworkDiscovery::m_IsClient
	bool ___m_IsClient_16;
	// System.Byte[] UnityEngine.Networking.NetworkDiscovery::m_MsgOutBuffer
	ByteU5BU5D_t3397334013* ___m_MsgOutBuffer_17;
	// System.Byte[] UnityEngine.Networking.NetworkDiscovery::m_MsgInBuffer
	ByteU5BU5D_t3397334013* ___m_MsgInBuffer_18;
	// UnityEngine.Networking.HostTopology UnityEngine.Networking.NetworkDiscovery::m_DefaultTopology
	HostTopology_t3602650143 * ___m_DefaultTopology_19;
	// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.Networking.NetworkBroadcastResult> UnityEngine.Networking.NetworkDiscovery::m_BroadcastsReceived
	Dictionary_2_t2561097244 * ___m_BroadcastsReceived_20;

public:
	inline static int32_t get_offset_of_m_BroadcastPort_3() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastPort_3)); }
	inline int32_t get_m_BroadcastPort_3() const { return ___m_BroadcastPort_3; }
	inline int32_t* get_address_of_m_BroadcastPort_3() { return &___m_BroadcastPort_3; }
	inline void set_m_BroadcastPort_3(int32_t value)
	{
		___m_BroadcastPort_3 = value;
	}

	inline static int32_t get_offset_of_m_BroadcastKey_4() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastKey_4)); }
	inline int32_t get_m_BroadcastKey_4() const { return ___m_BroadcastKey_4; }
	inline int32_t* get_address_of_m_BroadcastKey_4() { return &___m_BroadcastKey_4; }
	inline void set_m_BroadcastKey_4(int32_t value)
	{
		___m_BroadcastKey_4 = value;
	}

	inline static int32_t get_offset_of_m_BroadcastVersion_5() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastVersion_5)); }
	inline int32_t get_m_BroadcastVersion_5() const { return ___m_BroadcastVersion_5; }
	inline int32_t* get_address_of_m_BroadcastVersion_5() { return &___m_BroadcastVersion_5; }
	inline void set_m_BroadcastVersion_5(int32_t value)
	{
		___m_BroadcastVersion_5 = value;
	}

	inline static int32_t get_offset_of_m_BroadcastSubVersion_6() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastSubVersion_6)); }
	inline int32_t get_m_BroadcastSubVersion_6() const { return ___m_BroadcastSubVersion_6; }
	inline int32_t* get_address_of_m_BroadcastSubVersion_6() { return &___m_BroadcastSubVersion_6; }
	inline void set_m_BroadcastSubVersion_6(int32_t value)
	{
		___m_BroadcastSubVersion_6 = value;
	}

	inline static int32_t get_offset_of_m_BroadcastInterval_7() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastInterval_7)); }
	inline int32_t get_m_BroadcastInterval_7() const { return ___m_BroadcastInterval_7; }
	inline int32_t* get_address_of_m_BroadcastInterval_7() { return &___m_BroadcastInterval_7; }
	inline void set_m_BroadcastInterval_7(int32_t value)
	{
		___m_BroadcastInterval_7 = value;
	}

	inline static int32_t get_offset_of_m_UseNetworkManager_8() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_UseNetworkManager_8)); }
	inline bool get_m_UseNetworkManager_8() const { return ___m_UseNetworkManager_8; }
	inline bool* get_address_of_m_UseNetworkManager_8() { return &___m_UseNetworkManager_8; }
	inline void set_m_UseNetworkManager_8(bool value)
	{
		___m_UseNetworkManager_8 = value;
	}

	inline static int32_t get_offset_of_m_BroadcastData_9() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastData_9)); }
	inline String_t* get_m_BroadcastData_9() const { return ___m_BroadcastData_9; }
	inline String_t** get_address_of_m_BroadcastData_9() { return &___m_BroadcastData_9; }
	inline void set_m_BroadcastData_9(String_t* value)
	{
		___m_BroadcastData_9 = value;
		Il2CppCodeGenWriteBarrier(&___m_BroadcastData_9, value);
	}

	inline static int32_t get_offset_of_m_ShowGUI_10() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_ShowGUI_10)); }
	inline bool get_m_ShowGUI_10() const { return ___m_ShowGUI_10; }
	inline bool* get_address_of_m_ShowGUI_10() { return &___m_ShowGUI_10; }
	inline void set_m_ShowGUI_10(bool value)
	{
		___m_ShowGUI_10 = value;
	}

	inline static int32_t get_offset_of_m_OffsetX_11() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_OffsetX_11)); }
	inline int32_t get_m_OffsetX_11() const { return ___m_OffsetX_11; }
	inline int32_t* get_address_of_m_OffsetX_11() { return &___m_OffsetX_11; }
	inline void set_m_OffsetX_11(int32_t value)
	{
		___m_OffsetX_11 = value;
	}

	inline static int32_t get_offset_of_m_OffsetY_12() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_OffsetY_12)); }
	inline int32_t get_m_OffsetY_12() const { return ___m_OffsetY_12; }
	inline int32_t* get_address_of_m_OffsetY_12() { return &___m_OffsetY_12; }
	inline void set_m_OffsetY_12(int32_t value)
	{
		___m_OffsetY_12 = value;
	}

	inline static int32_t get_offset_of_m_HostId_13() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_HostId_13)); }
	inline int32_t get_m_HostId_13() const { return ___m_HostId_13; }
	inline int32_t* get_address_of_m_HostId_13() { return &___m_HostId_13; }
	inline void set_m_HostId_13(int32_t value)
	{
		___m_HostId_13 = value;
	}

	inline static int32_t get_offset_of_m_Running_14() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_Running_14)); }
	inline bool get_m_Running_14() const { return ___m_Running_14; }
	inline bool* get_address_of_m_Running_14() { return &___m_Running_14; }
	inline void set_m_Running_14(bool value)
	{
		___m_Running_14 = value;
	}

	inline static int32_t get_offset_of_m_IsServer_15() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_IsServer_15)); }
	inline bool get_m_IsServer_15() const { return ___m_IsServer_15; }
	inline bool* get_address_of_m_IsServer_15() { return &___m_IsServer_15; }
	inline void set_m_IsServer_15(bool value)
	{
		___m_IsServer_15 = value;
	}

	inline static int32_t get_offset_of_m_IsClient_16() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_IsClient_16)); }
	inline bool get_m_IsClient_16() const { return ___m_IsClient_16; }
	inline bool* get_address_of_m_IsClient_16() { return &___m_IsClient_16; }
	inline void set_m_IsClient_16(bool value)
	{
		___m_IsClient_16 = value;
	}

	inline static int32_t get_offset_of_m_MsgOutBuffer_17() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_MsgOutBuffer_17)); }
	inline ByteU5BU5D_t3397334013* get_m_MsgOutBuffer_17() const { return ___m_MsgOutBuffer_17; }
	inline ByteU5BU5D_t3397334013** get_address_of_m_MsgOutBuffer_17() { return &___m_MsgOutBuffer_17; }
	inline void set_m_MsgOutBuffer_17(ByteU5BU5D_t3397334013* value)
	{
		___m_MsgOutBuffer_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgOutBuffer_17, value);
	}

	inline static int32_t get_offset_of_m_MsgInBuffer_18() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_MsgInBuffer_18)); }
	inline ByteU5BU5D_t3397334013* get_m_MsgInBuffer_18() const { return ___m_MsgInBuffer_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_m_MsgInBuffer_18() { return &___m_MsgInBuffer_18; }
	inline void set_m_MsgInBuffer_18(ByteU5BU5D_t3397334013* value)
	{
		___m_MsgInBuffer_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_MsgInBuffer_18, value);
	}

	inline static int32_t get_offset_of_m_DefaultTopology_19() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_DefaultTopology_19)); }
	inline HostTopology_t3602650143 * get_m_DefaultTopology_19() const { return ___m_DefaultTopology_19; }
	inline HostTopology_t3602650143 ** get_address_of_m_DefaultTopology_19() { return &___m_DefaultTopology_19; }
	inline void set_m_DefaultTopology_19(HostTopology_t3602650143 * value)
	{
		___m_DefaultTopology_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_DefaultTopology_19, value);
	}

	inline static int32_t get_offset_of_m_BroadcastsReceived_20() { return static_cast<int32_t>(offsetof(NetworkDiscovery_t3838653650, ___m_BroadcastsReceived_20)); }
	inline Dictionary_2_t2561097244 * get_m_BroadcastsReceived_20() const { return ___m_BroadcastsReceived_20; }
	inline Dictionary_2_t2561097244 ** get_address_of_m_BroadcastsReceived_20() { return &___m_BroadcastsReceived_20; }
	inline void set_m_BroadcastsReceived_20(Dictionary_2_t2561097244 * value)
	{
		___m_BroadcastsReceived_20 = value;
		Il2CppCodeGenWriteBarrier(&___m_BroadcastsReceived_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
