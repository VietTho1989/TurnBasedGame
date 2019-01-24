#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen118271752.h"

// GameUI
struct GameUI_t4016257260;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewGameRecordUI
struct  ViewGameRecordUI_t1449677176  : public UIBehavior_1_t118271752
{
public:
	// GameUI Record.ViewGameRecordUI::gameUIPrefab
	GameUI_t4016257260 * ___gameUIPrefab_6;
	// UnityEngine.Transform Record.ViewGameRecordUI::gameUIContainer
	Transform_t3275118058 * ___gameUIContainer_7;

public:
	inline static int32_t get_offset_of_gameUIPrefab_6() { return static_cast<int32_t>(offsetof(ViewGameRecordUI_t1449677176, ___gameUIPrefab_6)); }
	inline GameUI_t4016257260 * get_gameUIPrefab_6() const { return ___gameUIPrefab_6; }
	inline GameUI_t4016257260 ** get_address_of_gameUIPrefab_6() { return &___gameUIPrefab_6; }
	inline void set_gameUIPrefab_6(GameUI_t4016257260 * value)
	{
		___gameUIPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameUIPrefab_6, value);
	}

	inline static int32_t get_offset_of_gameUIContainer_7() { return static_cast<int32_t>(offsetof(ViewGameRecordUI_t1449677176, ___gameUIContainer_7)); }
	inline Transform_t3275118058 * get_gameUIContainer_7() const { return ___gameUIContainer_7; }
	inline Transform_t3275118058 ** get_address_of_gameUIContainer_7() { return &___gameUIContainer_7; }
	inline void set_gameUIContainer_7(Transform_t3275118058 * value)
	{
		___gameUIContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameUIContainer_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
