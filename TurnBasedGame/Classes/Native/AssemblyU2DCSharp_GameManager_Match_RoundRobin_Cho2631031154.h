#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro4153906411.h"

// GameManager.Match.RoundRobin.ChooseRoundContestHolder
struct ChooseRoundContestHolder_t4290171439;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestAdapter
struct  ChooseRoundContestAdapter_t2631031154  : public SRIA_2_t4153906411
{
public:
	// GameManager.Match.RoundRobin.ChooseRoundContestHolder GameManager.Match.RoundRobin.ChooseRoundContestAdapter::holderPrefab
	ChooseRoundContestHolder_t4290171439 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.RoundRobin.ChooseRoundContestAdapter::noRoundContests
	GameObject_t1756533147 * ___noRoundContests_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseRoundContestAdapter_t2631031154, ___holderPrefab_24)); }
	inline ChooseRoundContestHolder_t4290171439 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseRoundContestHolder_t4290171439 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseRoundContestHolder_t4290171439 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noRoundContests_25() { return static_cast<int32_t>(offsetof(ChooseRoundContestAdapter_t2631031154, ___noRoundContests_25)); }
	inline GameObject_t1756533147 * get_noRoundContests_25() const { return ___noRoundContests_25; }
	inline GameObject_t1756533147 ** get_address_of_noRoundContests_25() { return &___noRoundContests_25; }
	inline void set_noRoundContests_25(GameObject_t1756533147 * value)
	{
		___noRoundContests_25 = value;
		Il2CppCodeGenWriteBarrier(&___noRoundContests_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
