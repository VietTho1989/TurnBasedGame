#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2566084061.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// ViewSaveGameUI
struct ViewSaveGameUI_t3668528880;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ViewSaveDataUI
struct  ViewSaveDataUI_t4233183598  : public UIBehavior_1_t2566084061
{
public:
	// UnityEngine.GameObject ViewSaveDataUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// ViewSaveGameUI ViewSaveDataUI::viewSaveGamePrefab
	ViewSaveGameUI_t3668528880 * ___viewSaveGamePrefab_7;
	// UnityEngine.Transform ViewSaveDataUI::subContainer
	Transform_t3275118058 * ___subContainer_8;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(ViewSaveDataUI_t4233183598, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_viewSaveGamePrefab_7() { return static_cast<int32_t>(offsetof(ViewSaveDataUI_t4233183598, ___viewSaveGamePrefab_7)); }
	inline ViewSaveGameUI_t3668528880 * get_viewSaveGamePrefab_7() const { return ___viewSaveGamePrefab_7; }
	inline ViewSaveGameUI_t3668528880 ** get_address_of_viewSaveGamePrefab_7() { return &___viewSaveGamePrefab_7; }
	inline void set_viewSaveGamePrefab_7(ViewSaveGameUI_t3668528880 * value)
	{
		___viewSaveGamePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___viewSaveGamePrefab_7, value);
	}

	inline static int32_t get_offset_of_subContainer_8() { return static_cast<int32_t>(offsetof(ViewSaveDataUI_t4233183598, ___subContainer_8)); }
	inline Transform_t3275118058 * get_subContainer_8() const { return ___subContainer_8; }
	inline Transform_t3275118058 ** get_address_of_subContainer_8() { return &___subContainer_8; }
	inline void set_subContainer_8(Transform_t3275118058 * value)
	{
		___subContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
