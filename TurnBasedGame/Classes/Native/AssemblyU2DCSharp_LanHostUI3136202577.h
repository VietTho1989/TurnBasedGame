#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4019234906.h"

// UnityEngine.UI.InputField
struct InputField_t1631627530;
// ServerManager
struct ServerManager_t3491151942;
// HostNetworkDiscovery
struct HostNetworkDiscovery_t1395666554;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LanHostUI
struct  LanHostUI_t3136202577  : public UIBehavior_1_t4019234906
{
public:
	// UnityEngine.UI.InputField LanHostUI::edtPort
	InputField_t1631627530 * ___edtPort_7;
	// ServerManager LanHostUI::serverManagerPrefab
	ServerManager_t3491151942 * ___serverManagerPrefab_8;
	// HostNetworkDiscovery LanHostUI::hostNetworkDiscoveryPrefab
	HostNetworkDiscovery_t1395666554 * ___hostNetworkDiscoveryPrefab_9;

public:
	inline static int32_t get_offset_of_edtPort_7() { return static_cast<int32_t>(offsetof(LanHostUI_t3136202577, ___edtPort_7)); }
	inline InputField_t1631627530 * get_edtPort_7() const { return ___edtPort_7; }
	inline InputField_t1631627530 ** get_address_of_edtPort_7() { return &___edtPort_7; }
	inline void set_edtPort_7(InputField_t1631627530 * value)
	{
		___edtPort_7 = value;
		Il2CppCodeGenWriteBarrier(&___edtPort_7, value);
	}

	inline static int32_t get_offset_of_serverManagerPrefab_8() { return static_cast<int32_t>(offsetof(LanHostUI_t3136202577, ___serverManagerPrefab_8)); }
	inline ServerManager_t3491151942 * get_serverManagerPrefab_8() const { return ___serverManagerPrefab_8; }
	inline ServerManager_t3491151942 ** get_address_of_serverManagerPrefab_8() { return &___serverManagerPrefab_8; }
	inline void set_serverManagerPrefab_8(ServerManager_t3491151942 * value)
	{
		___serverManagerPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___serverManagerPrefab_8, value);
	}

	inline static int32_t get_offset_of_hostNetworkDiscoveryPrefab_9() { return static_cast<int32_t>(offsetof(LanHostUI_t3136202577, ___hostNetworkDiscoveryPrefab_9)); }
	inline HostNetworkDiscovery_t1395666554 * get_hostNetworkDiscoveryPrefab_9() const { return ___hostNetworkDiscoveryPrefab_9; }
	inline HostNetworkDiscovery_t1395666554 ** get_address_of_hostNetworkDiscoveryPrefab_9() { return &___hostNetworkDiscoveryPrefab_9; }
	inline void set_hostNetworkDiscoveryPrefab_9(HostNetworkDiscovery_t1395666554 * value)
	{
		___hostNetworkDiscoveryPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___hostNetworkDiscoveryPrefab_9, value);
	}
};

struct LanHostUI_t3136202577_StaticFields
{
public:
	// System.Boolean LanHostUI::log
	bool ___log_6;

public:
	inline static int32_t get_offset_of_log_6() { return static_cast<int32_t>(offsetof(LanHostUI_t3136202577_StaticFields, ___log_6)); }
	inline bool get_log_6() const { return ___log_6; }
	inline bool* get_address_of_log_6() { return &___log_6; }
	inline void set_log_6(bool value)
	{
		___log_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
