#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen975130434.h"

// GameState.StartNormalUI
struct StartNormalUI_t2624072109;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.StartUI
struct  StartUI_t403700626  : public UIBehavior_1_t975130434
{
public:
	// GameState.StartNormalUI GameState.StartUI::startNormalPrefab
	StartNormalUI_t2624072109 * ___startNormalPrefab_6;
	// UnityEngine.Transform GameState.StartUI::subContainer
	Transform_t3275118058 * ___subContainer_7;

public:
	inline static int32_t get_offset_of_startNormalPrefab_6() { return static_cast<int32_t>(offsetof(StartUI_t403700626, ___startNormalPrefab_6)); }
	inline StartNormalUI_t2624072109 * get_startNormalPrefab_6() const { return ___startNormalPrefab_6; }
	inline StartNormalUI_t2624072109 ** get_address_of_startNormalPrefab_6() { return &___startNormalPrefab_6; }
	inline void set_startNormalPrefab_6(StartNormalUI_t2624072109 * value)
	{
		___startNormalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___startNormalPrefab_6, value);
	}

	inline static int32_t get_offset_of_subContainer_7() { return static_cast<int32_t>(offsetof(StartUI_t403700626, ___subContainer_7)); }
	inline Transform_t3275118058 * get_subContainer_7() const { return ___subContainer_7; }
	inline Transform_t3275118058 ** get_address_of_subContainer_7() { return &___subContainer_7; }
	inline void set_subContainer_7(Transform_t3275118058 * value)
	{
		___subContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
