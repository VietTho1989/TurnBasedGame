#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3470979764.h"

// GameManager.Match.RoundRobin.ChooseRoundContestAdapter
struct ChooseRoundContestAdapter_t2631031154;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundContestUI
struct  ChooseRoundContestUI_t3563611931  : public UIBehavior_1_t3470979764
{
public:
	// GameManager.Match.RoundRobin.ChooseRoundContestAdapter GameManager.Match.RoundRobin.ChooseRoundContestUI::chooseRoundContestAdapterPrefab
	ChooseRoundContestAdapter_t2631031154 * ___chooseRoundContestAdapterPrefab_6;
	// UnityEngine.Transform GameManager.Match.RoundRobin.ChooseRoundContestUI::chooseRoundContestAdapterContainer
	Transform_t3275118058 * ___chooseRoundContestAdapterContainer_7;

public:
	inline static int32_t get_offset_of_chooseRoundContestAdapterPrefab_6() { return static_cast<int32_t>(offsetof(ChooseRoundContestUI_t3563611931, ___chooseRoundContestAdapterPrefab_6)); }
	inline ChooseRoundContestAdapter_t2631031154 * get_chooseRoundContestAdapterPrefab_6() const { return ___chooseRoundContestAdapterPrefab_6; }
	inline ChooseRoundContestAdapter_t2631031154 ** get_address_of_chooseRoundContestAdapterPrefab_6() { return &___chooseRoundContestAdapterPrefab_6; }
	inline void set_chooseRoundContestAdapterPrefab_6(ChooseRoundContestAdapter_t2631031154 * value)
	{
		___chooseRoundContestAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundContestAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseRoundContestAdapterContainer_7() { return static_cast<int32_t>(offsetof(ChooseRoundContestUI_t3563611931, ___chooseRoundContestAdapterContainer_7)); }
	inline Transform_t3275118058 * get_chooseRoundContestAdapterContainer_7() const { return ___chooseRoundContestAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundContestAdapterContainer_7() { return &___chooseRoundContestAdapterContainer_7; }
	inline void set_chooseRoundContestAdapterContainer_7(Transform_t3275118058 * value)
	{
		___chooseRoundContestAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundContestAdapterContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
