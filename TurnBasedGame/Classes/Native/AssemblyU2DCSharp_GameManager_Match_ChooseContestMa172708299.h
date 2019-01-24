#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2233420646.h"

// GameManager.Match.ChooseContestManagerTeamUI
struct ChooseContestManagerTeamUI_t4165925413;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerStatePlayUI
struct  ChooseContestManagerStatePlayUI_t172708299  : public UIBehavior_1_t2233420646
{
public:
	// GameManager.Match.ChooseContestManagerTeamUI GameManager.Match.ChooseContestManagerStatePlayUI::teamPrefab
	ChooseContestManagerTeamUI_t4165925413 * ___teamPrefab_6;
	// UnityEngine.Transform GameManager.Match.ChooseContestManagerStatePlayUI::teamContainer
	Transform_t3275118058 * ___teamContainer_7;

public:
	inline static int32_t get_offset_of_teamPrefab_6() { return static_cast<int32_t>(offsetof(ChooseContestManagerStatePlayUI_t172708299, ___teamPrefab_6)); }
	inline ChooseContestManagerTeamUI_t4165925413 * get_teamPrefab_6() const { return ___teamPrefab_6; }
	inline ChooseContestManagerTeamUI_t4165925413 ** get_address_of_teamPrefab_6() { return &___teamPrefab_6; }
	inline void set_teamPrefab_6(ChooseContestManagerTeamUI_t4165925413 * value)
	{
		___teamPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamPrefab_6, value);
	}

	inline static int32_t get_offset_of_teamContainer_7() { return static_cast<int32_t>(offsetof(ChooseContestManagerStatePlayUI_t172708299, ___teamContainer_7)); }
	inline Transform_t3275118058 * get_teamContainer_7() const { return ___teamContainer_7; }
	inline Transform_t3275118058 ** get_address_of_teamContainer_7() { return &___teamContainer_7; }
	inline void set_teamContainer_7(Transform_t3275118058 * value)
	{
		___teamContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___teamContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
