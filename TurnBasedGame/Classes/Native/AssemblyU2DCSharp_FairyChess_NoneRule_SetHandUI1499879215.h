#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen538485935.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// GameDataBoardCheckPerspectiveChange`1<FairyChess.NoneRule.SetHandUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3793806679;
// FairyChess.NoneRule.SetHandAdapter
struct SetHandAdapter_t3379902588;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.SetHandUI
struct  SetHandUI_t1499879215  : public UIBehavior_1_t538485935
{
public:
	// UnityEngine.Transform FairyChess.NoneRule.SetHandUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// UnityEngine.UI.InputField FairyChess.NoneRule.SetHandUI::edtPieceCount
	InputField_t1631627530 * ___edtPieceCount_7;
	// GameDataBoardCheckPerspectiveChange`1<FairyChess.NoneRule.SetHandUI/UIData> FairyChess.NoneRule.SetHandUI::checkPerspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3793806679 * ___checkPerspectiveChange_8;
	// FairyChess.NoneRule.SetHandAdapter FairyChess.NoneRule.SetHandUI::setHandAdapterPrefab
	SetHandAdapter_t3379902588 * ___setHandAdapterPrefab_9;
	// UnityEngine.Transform FairyChess.NoneRule.SetHandUI::setHandAdapterContainer
	Transform_t3275118058 * ___setHandAdapterContainer_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(SetHandUI_t1499879215, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_edtPieceCount_7() { return static_cast<int32_t>(offsetof(SetHandUI_t1499879215, ___edtPieceCount_7)); }
	inline InputField_t1631627530 * get_edtPieceCount_7() const { return ___edtPieceCount_7; }
	inline InputField_t1631627530 ** get_address_of_edtPieceCount_7() { return &___edtPieceCount_7; }
	inline void set_edtPieceCount_7(InputField_t1631627530 * value)
	{
		___edtPieceCount_7 = value;
		Il2CppCodeGenWriteBarrier(&___edtPieceCount_7, value);
	}

	inline static int32_t get_offset_of_checkPerspectiveChange_8() { return static_cast<int32_t>(offsetof(SetHandUI_t1499879215, ___checkPerspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3793806679 * get_checkPerspectiveChange_8() const { return ___checkPerspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t3793806679 ** get_address_of_checkPerspectiveChange_8() { return &___checkPerspectiveChange_8; }
	inline void set_checkPerspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t3793806679 * value)
	{
		___checkPerspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___checkPerspectiveChange_8, value);
	}

	inline static int32_t get_offset_of_setHandAdapterPrefab_9() { return static_cast<int32_t>(offsetof(SetHandUI_t1499879215, ___setHandAdapterPrefab_9)); }
	inline SetHandAdapter_t3379902588 * get_setHandAdapterPrefab_9() const { return ___setHandAdapterPrefab_9; }
	inline SetHandAdapter_t3379902588 ** get_address_of_setHandAdapterPrefab_9() { return &___setHandAdapterPrefab_9; }
	inline void set_setHandAdapterPrefab_9(SetHandAdapter_t3379902588 * value)
	{
		___setHandAdapterPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___setHandAdapterPrefab_9, value);
	}

	inline static int32_t get_offset_of_setHandAdapterContainer_10() { return static_cast<int32_t>(offsetof(SetHandUI_t1499879215, ___setHandAdapterContainer_10)); }
	inline Transform_t3275118058 * get_setHandAdapterContainer_10() const { return ___setHandAdapterContainer_10; }
	inline Transform_t3275118058 ** get_address_of_setHandAdapterContainer_10() { return &___setHandAdapterContainer_10; }
	inline void set_setHandAdapterContainer_10(Transform_t3275118058 * value)
	{
		___setHandAdapterContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___setHandAdapterContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
