#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2162806471.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// InternationalDraught.InternationalDraughtMoveUI
struct InternationalDraughtMoveUI_t3339962940;
// InternationalDraught.NoneRule.InternationalDraughtCustomSetUI
struct InternationalDraughtCustomSetUI_t2647599812;
// InternationalDraught.NoneRule.InternationalDraughtCustomMoveUI
struct InternationalDraughtCustomMoveUI_t1922190969;
// LastMoveCheckChange`1<InternationalDraught.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t1766174388;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.LastMoveUI
struct  LastMoveUI_t15647441  : public UIBehavior_1_t2162806471
{
public:
	// UnityEngine.Transform InternationalDraught.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// InternationalDraught.InternationalDraughtMoveUI InternationalDraught.LastMoveUI::internationalDraughtMovePrefab
	InternationalDraughtMoveUI_t3339962940 * ___internationalDraughtMovePrefab_7;
	// InternationalDraught.NoneRule.InternationalDraughtCustomSetUI InternationalDraught.LastMoveUI::internationalDraughtCustomSetPrefab
	InternationalDraughtCustomSetUI_t2647599812 * ___internationalDraughtCustomSetPrefab_8;
	// InternationalDraught.NoneRule.InternationalDraughtCustomMoveUI InternationalDraught.LastMoveUI::internationalDraughtCustomMovePrefab
	InternationalDraughtCustomMoveUI_t1922190969 * ___internationalDraughtCustomMovePrefab_9;
	// LastMoveCheckChange`1<InternationalDraught.LastMoveUI/UIData> InternationalDraught.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t1766174388 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t15647441, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_internationalDraughtMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t15647441, ___internationalDraughtMovePrefab_7)); }
	inline InternationalDraughtMoveUI_t3339962940 * get_internationalDraughtMovePrefab_7() const { return ___internationalDraughtMovePrefab_7; }
	inline InternationalDraughtMoveUI_t3339962940 ** get_address_of_internationalDraughtMovePrefab_7() { return &___internationalDraughtMovePrefab_7; }
	inline void set_internationalDraughtMovePrefab_7(InternationalDraughtMoveUI_t3339962940 * value)
	{
		___internationalDraughtMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_internationalDraughtCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t15647441, ___internationalDraughtCustomSetPrefab_8)); }
	inline InternationalDraughtCustomSetUI_t2647599812 * get_internationalDraughtCustomSetPrefab_8() const { return ___internationalDraughtCustomSetPrefab_8; }
	inline InternationalDraughtCustomSetUI_t2647599812 ** get_address_of_internationalDraughtCustomSetPrefab_8() { return &___internationalDraughtCustomSetPrefab_8; }
	inline void set_internationalDraughtCustomSetPrefab_8(InternationalDraughtCustomSetUI_t2647599812 * value)
	{
		___internationalDraughtCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_internationalDraughtCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t15647441, ___internationalDraughtCustomMovePrefab_9)); }
	inline InternationalDraughtCustomMoveUI_t1922190969 * get_internationalDraughtCustomMovePrefab_9() const { return ___internationalDraughtCustomMovePrefab_9; }
	inline InternationalDraughtCustomMoveUI_t1922190969 ** get_address_of_internationalDraughtCustomMovePrefab_9() { return &___internationalDraughtCustomMovePrefab_9; }
	inline void set_internationalDraughtCustomMovePrefab_9(InternationalDraughtCustomMoveUI_t1922190969 * value)
	{
		___internationalDraughtCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t15647441, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t1766174388 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t1766174388 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t1766174388 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
