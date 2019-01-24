#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol820289647.h"

// GameManager.Match.ChooseContestManagerHolder
struct ChooseContestManagerHolder_t2456074030;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerAdapter
struct  ChooseContestManagerAdapter_t324860687  : public SRIA_2_t820289647
{
public:
	// GameManager.Match.ChooseContestManagerHolder GameManager.Match.ChooseContestManagerAdapter::holderPrefab
	ChooseContestManagerHolder_t2456074030 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.ChooseContestManagerAdapter::noContestManagers
	GameObject_t1756533147 * ___noContestManagers_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseContestManagerAdapter_t324860687, ___holderPrefab_24)); }
	inline ChooseContestManagerHolder_t2456074030 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseContestManagerHolder_t2456074030 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseContestManagerHolder_t2456074030 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noContestManagers_25() { return static_cast<int32_t>(offsetof(ChooseContestManagerAdapter_t324860687, ___noContestManagers_25)); }
	inline GameObject_t1756533147 * get_noContestManagers_25() const { return ___noContestManagers_25; }
	inline GameObject_t1756533147 ** get_address_of_noContestManagers_25() { return &___noContestManagers_25; }
	inline void set_noContestManagers_25(GameObject_t1756533147 * value)
	{
		___noContestManagers_25 = value;
		Il2CppCodeGenWriteBarrier(&___noContestManagers_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
