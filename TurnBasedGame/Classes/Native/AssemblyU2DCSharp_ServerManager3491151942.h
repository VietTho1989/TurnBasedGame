#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3335581469.h"

// ServerManager/UIData
struct UIData_t2915768511;
// ServerManager
struct ServerManager_t3491151942;
// ManagerUI
struct ManagerUI_t3587488461;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ServerManager
struct  ServerManager_t3491151942  : public NetworkManager_t3335581469
{
public:
	// ServerManager/UIData ServerManager::data
	UIData_t2915768511 * ___data_50;
	// ManagerUI ServerManager::managerUIPrefab
	ManagerUI_t3587488461 * ___managerUIPrefab_52;

public:
	inline static int32_t get_offset_of_data_50() { return static_cast<int32_t>(offsetof(ServerManager_t3491151942, ___data_50)); }
	inline UIData_t2915768511 * get_data_50() const { return ___data_50; }
	inline UIData_t2915768511 ** get_address_of_data_50() { return &___data_50; }
	inline void set_data_50(UIData_t2915768511 * value)
	{
		___data_50 = value;
		Il2CppCodeGenWriteBarrier(&___data_50, value);
	}

	inline static int32_t get_offset_of_managerUIPrefab_52() { return static_cast<int32_t>(offsetof(ServerManager_t3491151942, ___managerUIPrefab_52)); }
	inline ManagerUI_t3587488461 * get_managerUIPrefab_52() const { return ___managerUIPrefab_52; }
	inline ManagerUI_t3587488461 ** get_address_of_managerUIPrefab_52() { return &___managerUIPrefab_52; }
	inline void set_managerUIPrefab_52(ManagerUI_t3587488461 * value)
	{
		___managerUIPrefab_52 = value;
		Il2CppCodeGenWriteBarrier(&___managerUIPrefab_52, value);
	}
};

struct ServerManager_t3491151942_StaticFields
{
public:
	// ServerManager ServerManager::instance
	ServerManager_t3491151942 * ___instance_51;

public:
	inline static int32_t get_offset_of_instance_51() { return static_cast<int32_t>(offsetof(ServerManager_t3491151942_StaticFields, ___instance_51)); }
	inline ServerManager_t3491151942 * get_instance_51() const { return ___instance_51; }
	inline ServerManager_t3491151942 ** get_address_of_instance_51() { return &___instance_51; }
	inline void set_instance_51(ServerManager_t3491151942 * value)
	{
		___instance_51 = value;
		Il2CppCodeGenWriteBarrier(&___instance_51, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
