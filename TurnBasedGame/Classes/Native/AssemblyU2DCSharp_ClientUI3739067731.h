#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1800833732.h"

// ServerManager
struct ServerManager_t3491151942;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientUI
struct  ClientUI_t3739067731  : public UIBehavior_1_t1800833732
{
public:
	// ServerManager ClientUI::serverPrefab
	ServerManager_t3491151942 * ___serverPrefab_6;

public:
	inline static int32_t get_offset_of_serverPrefab_6() { return static_cast<int32_t>(offsetof(ClientUI_t3739067731, ___serverPrefab_6)); }
	inline ServerManager_t3491151942 * get_serverPrefab_6() const { return ___serverPrefab_6; }
	inline ServerManager_t3491151942 ** get_address_of_serverPrefab_6() { return &___serverPrefab_6; }
	inline void set_serverPrefab_6(ServerManager_t3491151942 * value)
	{
		___serverPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___serverPrefab_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
