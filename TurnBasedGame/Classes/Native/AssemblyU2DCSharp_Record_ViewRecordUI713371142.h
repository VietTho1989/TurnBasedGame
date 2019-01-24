#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2662729802.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// Record.ViewGameRecordUI
struct ViewGameRecordUI_t1449677176;
// UnityEngine.Transform
struct Transform_t3275118058;
// Record.ViewRecordControllerUI
struct ViewRecordControllerUI_t4200726210;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewRecordUI
struct  ViewRecordUI_t713371142  : public UIBehavior_1_t2662729802
{
public:
	// UnityEngine.GameObject Record.ViewRecordUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// Record.ViewGameRecordUI Record.ViewRecordUI::viewGameRecordPrefab
	ViewGameRecordUI_t1449677176 * ___viewGameRecordPrefab_7;
	// UnityEngine.Transform Record.ViewRecordUI::subContainer
	Transform_t3275118058 * ___subContainer_8;
	// Record.ViewRecordControllerUI Record.ViewRecordUI::viewRecordControllerPrefab
	ViewRecordControllerUI_t4200726210 * ___viewRecordControllerPrefab_9;
	// UnityEngine.Transform Record.ViewRecordUI::viewRecordControllerContainer
	Transform_t3275118058 * ___viewRecordControllerContainer_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(ViewRecordUI_t713371142, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_viewGameRecordPrefab_7() { return static_cast<int32_t>(offsetof(ViewRecordUI_t713371142, ___viewGameRecordPrefab_7)); }
	inline ViewGameRecordUI_t1449677176 * get_viewGameRecordPrefab_7() const { return ___viewGameRecordPrefab_7; }
	inline ViewGameRecordUI_t1449677176 ** get_address_of_viewGameRecordPrefab_7() { return &___viewGameRecordPrefab_7; }
	inline void set_viewGameRecordPrefab_7(ViewGameRecordUI_t1449677176 * value)
	{
		___viewGameRecordPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___viewGameRecordPrefab_7, value);
	}

	inline static int32_t get_offset_of_subContainer_8() { return static_cast<int32_t>(offsetof(ViewRecordUI_t713371142, ___subContainer_8)); }
	inline Transform_t3275118058 * get_subContainer_8() const { return ___subContainer_8; }
	inline Transform_t3275118058 ** get_address_of_subContainer_8() { return &___subContainer_8; }
	inline void set_subContainer_8(Transform_t3275118058 * value)
	{
		___subContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_8, value);
	}

	inline static int32_t get_offset_of_viewRecordControllerPrefab_9() { return static_cast<int32_t>(offsetof(ViewRecordUI_t713371142, ___viewRecordControllerPrefab_9)); }
	inline ViewRecordControllerUI_t4200726210 * get_viewRecordControllerPrefab_9() const { return ___viewRecordControllerPrefab_9; }
	inline ViewRecordControllerUI_t4200726210 ** get_address_of_viewRecordControllerPrefab_9() { return &___viewRecordControllerPrefab_9; }
	inline void set_viewRecordControllerPrefab_9(ViewRecordControllerUI_t4200726210 * value)
	{
		___viewRecordControllerPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___viewRecordControllerPrefab_9, value);
	}

	inline static int32_t get_offset_of_viewRecordControllerContainer_10() { return static_cast<int32_t>(offsetof(ViewRecordUI_t713371142, ___viewRecordControllerContainer_10)); }
	inline Transform_t3275118058 * get_viewRecordControllerContainer_10() const { return ___viewRecordControllerContainer_10; }
	inline Transform_t3275118058 ** get_address_of_viewRecordControllerContainer_10() { return &___viewRecordControllerContainer_10; }
	inline void set_viewRecordControllerContainer_10(Transform_t3275118058 * value)
	{
		___viewRecordControllerContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___viewRecordControllerContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
