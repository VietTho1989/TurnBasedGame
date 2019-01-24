#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1044175241.h"

// StateOfflineUI
struct StateOfflineUI_t3286191130;
// StateConnectUI
struct StateConnectUI_t2335566079;
// StateDisconnectUI
struct StateDisconnectUI_t3770981713;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalStateUI
struct  GlobalStateUI_t3007709718  : public UIBehavior_1_t1044175241
{
public:
	// StateOfflineUI GlobalStateUI::stateOfflinePrefab
	StateOfflineUI_t3286191130 * ___stateOfflinePrefab_6;
	// StateConnectUI GlobalStateUI::stateConnectPrefab
	StateConnectUI_t2335566079 * ___stateConnectPrefab_7;
	// StateDisconnectUI GlobalStateUI::stateDisconnectPrefab
	StateDisconnectUI_t3770981713 * ___stateDisconnectPrefab_8;

public:
	inline static int32_t get_offset_of_stateOfflinePrefab_6() { return static_cast<int32_t>(offsetof(GlobalStateUI_t3007709718, ___stateOfflinePrefab_6)); }
	inline StateOfflineUI_t3286191130 * get_stateOfflinePrefab_6() const { return ___stateOfflinePrefab_6; }
	inline StateOfflineUI_t3286191130 ** get_address_of_stateOfflinePrefab_6() { return &___stateOfflinePrefab_6; }
	inline void set_stateOfflinePrefab_6(StateOfflineUI_t3286191130 * value)
	{
		___stateOfflinePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___stateOfflinePrefab_6, value);
	}

	inline static int32_t get_offset_of_stateConnectPrefab_7() { return static_cast<int32_t>(offsetof(GlobalStateUI_t3007709718, ___stateConnectPrefab_7)); }
	inline StateConnectUI_t2335566079 * get_stateConnectPrefab_7() const { return ___stateConnectPrefab_7; }
	inline StateConnectUI_t2335566079 ** get_address_of_stateConnectPrefab_7() { return &___stateConnectPrefab_7; }
	inline void set_stateConnectPrefab_7(StateConnectUI_t2335566079 * value)
	{
		___stateConnectPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___stateConnectPrefab_7, value);
	}

	inline static int32_t get_offset_of_stateDisconnectPrefab_8() { return static_cast<int32_t>(offsetof(GlobalStateUI_t3007709718, ___stateDisconnectPrefab_8)); }
	inline StateDisconnectUI_t3770981713 * get_stateDisconnectPrefab_8() const { return ___stateDisconnectPrefab_8; }
	inline StateDisconnectUI_t3770981713 ** get_address_of_stateDisconnectPrefab_8() { return &___stateDisconnectPrefab_8; }
	inline void set_stateDisconnectPrefab_8(StateDisconnectUI_t3770981713 * value)
	{
		___stateDisconnectPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___stateDisconnectPrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
