#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1999391813.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// PerspectiveAutoUI
struct PerspectiveAutoUI_t4013228249;
// PerspectiveForceUI
struct PerspectiveForceUI_t705316199;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PerspectiveUI
struct  PerspectiveUI_t3032598240  : public UIBehavior_1_t1999391813
{
public:
	// UnityEngine.UI.Text PerspectiveUI::tvPlayerIndex
	Text_t356221433 * ___tvPlayerIndex_6;
	// PerspectiveAutoUI PerspectiveUI::autoPrefab
	PerspectiveAutoUI_t4013228249 * ___autoPrefab_7;
	// PerspectiveForceUI PerspectiveUI::forcePrefab
	PerspectiveForceUI_t705316199 * ___forcePrefab_8;
	// UnityEngine.Transform PerspectiveUI::subTransform
	Transform_t3275118058 * ___subTransform_9;

public:
	inline static int32_t get_offset_of_tvPlayerIndex_6() { return static_cast<int32_t>(offsetof(PerspectiveUI_t3032598240, ___tvPlayerIndex_6)); }
	inline Text_t356221433 * get_tvPlayerIndex_6() const { return ___tvPlayerIndex_6; }
	inline Text_t356221433 ** get_address_of_tvPlayerIndex_6() { return &___tvPlayerIndex_6; }
	inline void set_tvPlayerIndex_6(Text_t356221433 * value)
	{
		___tvPlayerIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayerIndex_6, value);
	}

	inline static int32_t get_offset_of_autoPrefab_7() { return static_cast<int32_t>(offsetof(PerspectiveUI_t3032598240, ___autoPrefab_7)); }
	inline PerspectiveAutoUI_t4013228249 * get_autoPrefab_7() const { return ___autoPrefab_7; }
	inline PerspectiveAutoUI_t4013228249 ** get_address_of_autoPrefab_7() { return &___autoPrefab_7; }
	inline void set_autoPrefab_7(PerspectiveAutoUI_t4013228249 * value)
	{
		___autoPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___autoPrefab_7, value);
	}

	inline static int32_t get_offset_of_forcePrefab_8() { return static_cast<int32_t>(offsetof(PerspectiveUI_t3032598240, ___forcePrefab_8)); }
	inline PerspectiveForceUI_t705316199 * get_forcePrefab_8() const { return ___forcePrefab_8; }
	inline PerspectiveForceUI_t705316199 ** get_address_of_forcePrefab_8() { return &___forcePrefab_8; }
	inline void set_forcePrefab_8(PerspectiveForceUI_t705316199 * value)
	{
		___forcePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___forcePrefab_8, value);
	}

	inline static int32_t get_offset_of_subTransform_9() { return static_cast<int32_t>(offsetof(PerspectiveUI_t3032598240, ___subTransform_9)); }
	inline Transform_t3275118058 * get_subTransform_9() const { return ___subTransform_9; }
	inline Transform_t3275118058 ** get_address_of_subTransform_9() { return &___subTransform_9; }
	inline void set_subTransform_9(Transform_t3275118058 * value)
	{
		___subTransform_9 = value;
		Il2CppCodeGenWriteBarrier(&___subTransform_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
