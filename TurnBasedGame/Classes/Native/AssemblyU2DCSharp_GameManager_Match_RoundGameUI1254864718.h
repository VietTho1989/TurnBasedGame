#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3723491079.h"

// GameUI
struct GameUI_t4016257260;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGameUI
struct  RoundGameUI_t1254864718  : public UIBehavior_1_t3723491079
{
public:
	// GameUI GameManager.Match.RoundGameUI::gamePrefab
	GameUI_t4016257260 * ___gamePrefab_6;
	// UnityEngine.Transform GameManager.Match.RoundGameUI::gameContainer
	Transform_t3275118058 * ___gameContainer_7;

public:
	inline static int32_t get_offset_of_gamePrefab_6() { return static_cast<int32_t>(offsetof(RoundGameUI_t1254864718, ___gamePrefab_6)); }
	inline GameUI_t4016257260 * get_gamePrefab_6() const { return ___gamePrefab_6; }
	inline GameUI_t4016257260 ** get_address_of_gamePrefab_6() { return &___gamePrefab_6; }
	inline void set_gamePrefab_6(GameUI_t4016257260 * value)
	{
		___gamePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___gamePrefab_6, value);
	}

	inline static int32_t get_offset_of_gameContainer_7() { return static_cast<int32_t>(offsetof(RoundGameUI_t1254864718, ___gameContainer_7)); }
	inline Transform_t3275118058 * get_gameContainer_7() const { return ___gameContainer_7; }
	inline Transform_t3275118058 ** get_address_of_gameContainer_7() { return &___gameContainer_7; }
	inline void set_gameContainer_7(Transform_t3275118058 * value)
	{
		___gameContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
