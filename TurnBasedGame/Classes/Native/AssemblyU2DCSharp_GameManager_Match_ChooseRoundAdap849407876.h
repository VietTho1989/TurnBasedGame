#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1407219387.h"

// GameManager.Match.ChooseRoundHolder
struct ChooseRoundHolder_t1693867089;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundAdapter
struct  ChooseRoundAdapter_t849407876  : public SRIA_2_t1407219387
{
public:
	// GameManager.Match.ChooseRoundHolder GameManager.Match.ChooseRoundAdapter::holderPrefab
	ChooseRoundHolder_t1693867089 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.ChooseRoundAdapter::noRounds
	GameObject_t1756533147 * ___noRounds_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseRoundAdapter_t849407876, ___holderPrefab_24)); }
	inline ChooseRoundHolder_t1693867089 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseRoundHolder_t1693867089 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseRoundHolder_t1693867089 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noRounds_25() { return static_cast<int32_t>(offsetof(ChooseRoundAdapter_t849407876, ___noRounds_25)); }
	inline GameObject_t1756533147 * get_noRounds_25() const { return ___noRounds_25; }
	inline GameObject_t1756533147 ** get_address_of_noRounds_25() { return &___noRounds_25; }
	inline void set_noRounds_25(GameObject_t1756533147 * value)
	{
		___noRounds_25 = value;
		Il2CppCodeGenWriteBarrier(&___noRounds_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
