#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen611413386.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// GameDataBoardCheckPerspectiveChange`1<Seirawan.NoneRule.SetHandUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3866734130;
// Seirawan.NoneRule.SetHandAdapter
struct SetHandAdapter_t2032970826;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SetHandUI
struct  SetHandUI_t4139706397  : public UIBehavior_1_t611413386
{
public:
	// UnityEngine.Transform Seirawan.NoneRule.SetHandUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// GameDataBoardCheckPerspectiveChange`1<Seirawan.NoneRule.SetHandUI/UIData> Seirawan.NoneRule.SetHandUI::checkPerspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3866734130 * ___checkPerspectiveChange_7;
	// Seirawan.NoneRule.SetHandAdapter Seirawan.NoneRule.SetHandUI::setHandAdapterPrefab
	SetHandAdapter_t2032970826 * ___setHandAdapterPrefab_8;
	// UnityEngine.Transform Seirawan.NoneRule.SetHandUI::setHandAdapterContainer
	Transform_t3275118058 * ___setHandAdapterContainer_9;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(SetHandUI_t4139706397, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_checkPerspectiveChange_7() { return static_cast<int32_t>(offsetof(SetHandUI_t4139706397, ___checkPerspectiveChange_7)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3866734130 * get_checkPerspectiveChange_7() const { return ___checkPerspectiveChange_7; }
	inline GameDataBoardCheckPerspectiveChange_1_t3866734130 ** get_address_of_checkPerspectiveChange_7() { return &___checkPerspectiveChange_7; }
	inline void set_checkPerspectiveChange_7(GameDataBoardCheckPerspectiveChange_1_t3866734130 * value)
	{
		___checkPerspectiveChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___checkPerspectiveChange_7, value);
	}

	inline static int32_t get_offset_of_setHandAdapterPrefab_8() { return static_cast<int32_t>(offsetof(SetHandUI_t4139706397, ___setHandAdapterPrefab_8)); }
	inline SetHandAdapter_t2032970826 * get_setHandAdapterPrefab_8() const { return ___setHandAdapterPrefab_8; }
	inline SetHandAdapter_t2032970826 ** get_address_of_setHandAdapterPrefab_8() { return &___setHandAdapterPrefab_8; }
	inline void set_setHandAdapterPrefab_8(SetHandAdapter_t2032970826 * value)
	{
		___setHandAdapterPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___setHandAdapterPrefab_8, value);
	}

	inline static int32_t get_offset_of_setHandAdapterContainer_9() { return static_cast<int32_t>(offsetof(SetHandUI_t4139706397, ___setHandAdapterContainer_9)); }
	inline Transform_t3275118058 * get_setHandAdapterContainer_9() const { return ___setHandAdapterContainer_9; }
	inline Transform_t3275118058 ** get_address_of_setHandAdapterContainer_9() { return &___setHandAdapterContainer_9; }
	inline void set_setHandAdapterContainer_9(Transform_t3275118058 * value)
	{
		___setHandAdapterContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___setHandAdapterContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
