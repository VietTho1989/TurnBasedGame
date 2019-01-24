#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scrol684070815.h"

// GameManager.Match.Elimination.ChooseBracketContestHolder
struct ChooseBracketContestHolder_t1445954899;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketContestAdapter
struct  ChooseBracketContestAdapter_t1330017456  : public SRIA_2_t684070815
{
public:
	// GameManager.Match.Elimination.ChooseBracketContestHolder GameManager.Match.Elimination.ChooseBracketContestAdapter::holderPrefab
	ChooseBracketContestHolder_t1445954899 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Elimination.ChooseBracketContestAdapter::noBracketContests
	GameObject_t1756533147 * ___noBracketContests_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseBracketContestAdapter_t1330017456, ___holderPrefab_24)); }
	inline ChooseBracketContestHolder_t1445954899 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseBracketContestHolder_t1445954899 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseBracketContestHolder_t1445954899 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noBracketContests_25() { return static_cast<int32_t>(offsetof(ChooseBracketContestAdapter_t1330017456, ___noBracketContests_25)); }
	inline GameObject_t1756533147 * get_noBracketContests_25() const { return ___noBracketContests_25; }
	inline GameObject_t1756533147 ** get_address_of_noBracketContests_25() { return &___noBracketContests_25; }
	inline void set_noBracketContests_25(GameObject_t1756533147 * value)
	{
		___noBracketContests_25 = value;
		Il2CppCodeGenWriteBarrier(&___noBracketContests_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
