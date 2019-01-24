#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1963061684.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<MineSweeper.NoneRule.ClickMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t923415132;
// MineSweeper.MineSweeperGameDataUI/UIData
struct UIData_t1952477953;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.NoneRule.ClickMoveUI
struct  ClickMoveUI_t2632056757  : public UIBehavior_1_t1963061684
{
public:
	// UnityEngine.UI.Image MineSweeper.NoneRule.ClickMoveUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// GameDataBoardCheckPerspectiveChange`1<MineSweeper.NoneRule.ClickMoveUI/UIData> MineSweeper.NoneRule.ClickMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t923415132 * ___perspectiveChange_7;
	// MineSweeper.MineSweeperGameDataUI/UIData MineSweeper.NoneRule.ClickMoveUI::mineSweeperGameDataUIData
	UIData_t1952477953 * ___mineSweeperGameDataUIData_8;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickMoveUI_t2632056757, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_7() { return static_cast<int32_t>(offsetof(ClickMoveUI_t2632056757, ___perspectiveChange_7)); }
	inline GameDataBoardCheckPerspectiveChange_1_t923415132 * get_perspectiveChange_7() const { return ___perspectiveChange_7; }
	inline GameDataBoardCheckPerspectiveChange_1_t923415132 ** get_address_of_perspectiveChange_7() { return &___perspectiveChange_7; }
	inline void set_perspectiveChange_7(GameDataBoardCheckPerspectiveChange_1_t923415132 * value)
	{
		___perspectiveChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_7, value);
	}

	inline static int32_t get_offset_of_mineSweeperGameDataUIData_8() { return static_cast<int32_t>(offsetof(ClickMoveUI_t2632056757, ___mineSweeperGameDataUIData_8)); }
	inline UIData_t1952477953 * get_mineSweeperGameDataUIData_8() const { return ___mineSweeperGameDataUIData_8; }
	inline UIData_t1952477953 ** get_address_of_mineSweeperGameDataUIData_8() { return &___mineSweeperGameDataUIData_8; }
	inline void set_mineSweeperGameDataUIData_8(UIData_t1952477953 * value)
	{
		___mineSweeperGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
