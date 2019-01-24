#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3379550117.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameDataBoardCheckPerspectiveChange`1<RussianDraught.NoneRule.SetPieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2339903565;
// RussianDraught.NoneRule.ChoosePieceAdapter
struct ChoosePieceAdapter_t2250380646;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.NoneRule.SetPieceUI
struct  SetPieceUI_t2290859942  : public UIBehavior_1_t3379550117
{
public:
	// UnityEngine.UI.Image RussianDraught.NoneRule.SetPieceUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// UnityEngine.Transform RussianDraught.NoneRule.SetPieceUI::contentContainer
	Transform_t3275118058 * ___contentContainer_7;
	// GameDataBoardCheckPerspectiveChange`1<RussianDraught.NoneRule.SetPieceUI/UIData> RussianDraught.NoneRule.SetPieceUI::checkPerspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2339903565 * ___checkPerspectiveChange_8;
	// RussianDraught.NoneRule.ChoosePieceAdapter RussianDraught.NoneRule.SetPieceUI::choosePieceAdapterPrefab
	ChoosePieceAdapter_t2250380646 * ___choosePieceAdapterPrefab_9;
	// UnityEngine.Transform RussianDraught.NoneRule.SetPieceUI::choosePieceAdapterContainer
	Transform_t3275118058 * ___choosePieceAdapterContainer_10;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(SetPieceUI_t2290859942, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(SetPieceUI_t2290859942, ___contentContainer_7)); }
	inline Transform_t3275118058 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(Transform_t3275118058 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_checkPerspectiveChange_8() { return static_cast<int32_t>(offsetof(SetPieceUI_t2290859942, ___checkPerspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2339903565 * get_checkPerspectiveChange_8() const { return ___checkPerspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t2339903565 ** get_address_of_checkPerspectiveChange_8() { return &___checkPerspectiveChange_8; }
	inline void set_checkPerspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t2339903565 * value)
	{
		___checkPerspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___checkPerspectiveChange_8, value);
	}

	inline static int32_t get_offset_of_choosePieceAdapterPrefab_9() { return static_cast<int32_t>(offsetof(SetPieceUI_t2290859942, ___choosePieceAdapterPrefab_9)); }
	inline ChoosePieceAdapter_t2250380646 * get_choosePieceAdapterPrefab_9() const { return ___choosePieceAdapterPrefab_9; }
	inline ChoosePieceAdapter_t2250380646 ** get_address_of_choosePieceAdapterPrefab_9() { return &___choosePieceAdapterPrefab_9; }
	inline void set_choosePieceAdapterPrefab_9(ChoosePieceAdapter_t2250380646 * value)
	{
		___choosePieceAdapterPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___choosePieceAdapterPrefab_9, value);
	}

	inline static int32_t get_offset_of_choosePieceAdapterContainer_10() { return static_cast<int32_t>(offsetof(SetPieceUI_t2290859942, ___choosePieceAdapterContainer_10)); }
	inline Transform_t3275118058 * get_choosePieceAdapterContainer_10() const { return ___choosePieceAdapterContainer_10; }
	inline Transform_t3275118058 ** get_address_of_choosePieceAdapterContainer_10() { return &___choosePieceAdapterContainer_10; }
	inline void set_choosePieceAdapterContainer_10(Transform_t3275118058 * value)
	{
		___choosePieceAdapterContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___choosePieceAdapterContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
