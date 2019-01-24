#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro2933420599.h"

// GameManager.Match.RoundRobin.ChooseRoundRobinHolder
struct ChooseRoundRobinHolder_t3226680383;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundRobinAdapter
struct  ChooseRoundRobinAdapter_t830419094  : public SRIA_2_t2933420599
{
public:
	// GameManager.Match.RoundRobin.ChooseRoundRobinHolder GameManager.Match.RoundRobin.ChooseRoundRobinAdapter::holderPrefab
	ChooseRoundRobinHolder_t3226680383 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.RoundRobin.ChooseRoundRobinAdapter::noRoundRobins
	GameObject_t1756533147 * ___noRoundRobins_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseRoundRobinAdapter_t830419094, ___holderPrefab_24)); }
	inline ChooseRoundRobinHolder_t3226680383 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseRoundRobinHolder_t3226680383 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseRoundRobinHolder_t3226680383 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noRoundRobins_25() { return static_cast<int32_t>(offsetof(ChooseRoundRobinAdapter_t830419094, ___noRoundRobins_25)); }
	inline GameObject_t1756533147 * get_noRoundRobins_25() const { return ___noRoundRobins_25; }
	inline GameObject_t1756533147 ** get_address_of_noRoundRobins_25() { return &___noRoundRobins_25; }
	inline void set_noRoundRobins_25(GameObject_t1756533147 * value)
	{
		___noRoundRobins_25 = value;
		Il2CppCodeGenWriteBarrier(&___noRoundRobins_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
