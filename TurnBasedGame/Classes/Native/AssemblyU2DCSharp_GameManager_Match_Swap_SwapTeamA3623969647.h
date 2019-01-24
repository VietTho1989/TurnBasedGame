#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol772652097.h"

// GameManager.Match.Swap.SwapTeamHolder
struct SwapTeamHolder_t620033514;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapTeamAdapter
struct  SwapTeamAdapter_t3623969647  : public SRIA_2_t772652097
{
public:
	// GameManager.Match.Swap.SwapTeamHolder GameManager.Match.Swap.SwapTeamAdapter::holderPrefab
	SwapTeamHolder_t620033514 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Swap.SwapTeamAdapter::noTeams
	GameObject_t1756533147 * ___noTeams_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(SwapTeamAdapter_t3623969647, ___holderPrefab_24)); }
	inline SwapTeamHolder_t620033514 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline SwapTeamHolder_t620033514 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(SwapTeamHolder_t620033514 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noTeams_25() { return static_cast<int32_t>(offsetof(SwapTeamAdapter_t3623969647, ___noTeams_25)); }
	inline GameObject_t1756533147 * get_noTeams_25() const { return ___noTeams_25; }
	inline GameObject_t1756533147 ** get_address_of_noTeams_25() { return &___noTeams_25; }
	inline void set_noTeams_25(GameObject_t1756533147 * value)
	{
		___noTeams_25 = value;
		Il2CppCodeGenWriteBarrier(&___noTeams_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
