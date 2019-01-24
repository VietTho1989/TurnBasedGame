#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1347245944.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// GamePlayerUI
struct GamePlayerUI_t880108835;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GamePlayerListUI
struct  GamePlayerListUI_t2987005525  : public UIBehavior_1_t1347245944
{
public:
	// UnityEngine.Transform GamePlayerListUI::content
	Transform_t3275118058 * ___content_6;
	// GamePlayerUI GamePlayerListUI::gamePlayerPrefab
	GamePlayerUI_t880108835 * ___gamePlayerPrefab_7;

public:
	inline static int32_t get_offset_of_content_6() { return static_cast<int32_t>(offsetof(GamePlayerListUI_t2987005525, ___content_6)); }
	inline Transform_t3275118058 * get_content_6() const { return ___content_6; }
	inline Transform_t3275118058 ** get_address_of_content_6() { return &___content_6; }
	inline void set_content_6(Transform_t3275118058 * value)
	{
		___content_6 = value;
		Il2CppCodeGenWriteBarrier(&___content_6, value);
	}

	inline static int32_t get_offset_of_gamePlayerPrefab_7() { return static_cast<int32_t>(offsetof(GamePlayerListUI_t2987005525, ___gamePlayerPrefab_7)); }
	inline GamePlayerUI_t880108835 * get_gamePlayerPrefab_7() const { return ___gamePlayerPrefab_7; }
	inline GamePlayerUI_t880108835 ** get_address_of_gamePlayerPrefab_7() { return &___gamePlayerPrefab_7; }
	inline void set_gamePlayerPrefab_7(GamePlayerUI_t880108835 * value)
	{
		___gamePlayerPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___gamePlayerPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
