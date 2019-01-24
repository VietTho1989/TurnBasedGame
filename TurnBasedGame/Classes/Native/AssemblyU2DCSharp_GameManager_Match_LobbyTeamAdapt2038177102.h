#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3527360545.h"

// GameManager.Match.LobbyTeamHolder
struct LobbyTeamHolder_t233716569;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyTeamAdapter
struct  LobbyTeamAdapter_t2038177102  : public SRIA_2_t3527360545
{
public:
	// GameManager.Match.LobbyTeamHolder GameManager.Match.LobbyTeamAdapter::holderPrefab
	LobbyTeamHolder_t233716569 * ___holderPrefab_24;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(LobbyTeamAdapter_t2038177102, ___holderPrefab_24)); }
	inline LobbyTeamHolder_t233716569 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline LobbyTeamHolder_t233716569 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(LobbyTeamHolder_t233716569 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
