#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3778049968.h"

// GameManager.Match.RoundRobin.ChooseRoundRobinAdapter
struct ChooseRoundRobinAdapter_t830419094;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.ChooseRoundRobinUI
struct  ChooseRoundRobinUI_t2462047251  : public UIBehavior_1_t3778049968
{
public:
	// GameManager.Match.RoundRobin.ChooseRoundRobinAdapter GameManager.Match.RoundRobin.ChooseRoundRobinUI::chooseRoundRobinAdapterPrefab
	ChooseRoundRobinAdapter_t830419094 * ___chooseRoundRobinAdapterPrefab_6;
	// UnityEngine.Transform GameManager.Match.RoundRobin.ChooseRoundRobinUI::chooseRoundRobinAdapterContainer
	Transform_t3275118058 * ___chooseRoundRobinAdapterContainer_7;

public:
	inline static int32_t get_offset_of_chooseRoundRobinAdapterPrefab_6() { return static_cast<int32_t>(offsetof(ChooseRoundRobinUI_t2462047251, ___chooseRoundRobinAdapterPrefab_6)); }
	inline ChooseRoundRobinAdapter_t830419094 * get_chooseRoundRobinAdapterPrefab_6() const { return ___chooseRoundRobinAdapterPrefab_6; }
	inline ChooseRoundRobinAdapter_t830419094 ** get_address_of_chooseRoundRobinAdapterPrefab_6() { return &___chooseRoundRobinAdapterPrefab_6; }
	inline void set_chooseRoundRobinAdapterPrefab_6(ChooseRoundRobinAdapter_t830419094 * value)
	{
		___chooseRoundRobinAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundRobinAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_chooseRoundRobinAdapterContainer_7() { return static_cast<int32_t>(offsetof(ChooseRoundRobinUI_t2462047251, ___chooseRoundRobinAdapterContainer_7)); }
	inline Transform_t3275118058 * get_chooseRoundRobinAdapterContainer_7() const { return ___chooseRoundRobinAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chooseRoundRobinAdapterContainer_7() { return &___chooseRoundRobinAdapterContainer_7; }
	inline void set_chooseRoundRobinAdapterContainer_7(Transform_t3275118058 * value)
	{
		___chooseRoundRobinAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chooseRoundRobinAdapterContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
