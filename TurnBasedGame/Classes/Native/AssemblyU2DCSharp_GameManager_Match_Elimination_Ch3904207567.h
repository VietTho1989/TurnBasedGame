#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol820034865.h"

// GameManager.Match.Elimination.ChooseEliminationRoundHolder
struct ChooseEliminationRoundHolder_t2123455086;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseEliminationRoundAdapter
struct  ChooseEliminationRoundAdapter_t3904207567  : public SRIA_2_t820034865
{
public:
	// GameManager.Match.Elimination.ChooseEliminationRoundHolder GameManager.Match.Elimination.ChooseEliminationRoundAdapter::holderPrefab
	ChooseEliminationRoundHolder_t2123455086 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Elimination.ChooseEliminationRoundAdapter::noEliminationRounds
	GameObject_t1756533147 * ___noEliminationRounds_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundAdapter_t3904207567, ___holderPrefab_24)); }
	inline ChooseEliminationRoundHolder_t2123455086 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseEliminationRoundHolder_t2123455086 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseEliminationRoundHolder_t2123455086 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noEliminationRounds_25() { return static_cast<int32_t>(offsetof(ChooseEliminationRoundAdapter_t3904207567, ___noEliminationRounds_25)); }
	inline GameObject_t1756533147 * get_noEliminationRounds_25() const { return ___noEliminationRounds_25; }
	inline GameObject_t1756533147 ** get_address_of_noEliminationRounds_25() { return &___noEliminationRounds_25; }
	inline void set_noEliminationRounds_25(GameObject_t1756533147 * value)
	{
		___noEliminationRounds_25 = value;
		Il2CppCodeGenWriteBarrier(&___noEliminationRounds_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
