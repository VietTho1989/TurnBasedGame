#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3882349683.h"

// GameManager.Match.ChooseRoundGameHolder
struct ChooseRoundGameHolder_t2942608223;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundGameAdapter
struct  ChooseRoundGameAdapter_t2781301438  : public SRIA_2_t3882349683
{
public:
	// GameManager.Match.ChooseRoundGameHolder GameManager.Match.ChooseRoundGameAdapter::holderPrefab
	ChooseRoundGameHolder_t2942608223 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.ChooseRoundGameAdapter::noRoundGames
	GameObject_t1756533147 * ___noRoundGames_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseRoundGameAdapter_t2781301438, ___holderPrefab_24)); }
	inline ChooseRoundGameHolder_t2942608223 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseRoundGameHolder_t2942608223 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseRoundGameHolder_t2942608223 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noRoundGames_25() { return static_cast<int32_t>(offsetof(ChooseRoundGameAdapter_t2781301438, ___noRoundGames_25)); }
	inline GameObject_t1756533147 * get_noRoundGames_25() const { return ___noRoundGames_25; }
	inline GameObject_t1756533147 ** get_address_of_noRoundGames_25() { return &___noRoundGames_25; }
	inline void set_noRoundGames_25(GameObject_t1756533147 * value)
	{
		___noRoundGames_25 = value;
		Il2CppCodeGenWriteBarrier(&___noRoundGames_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
