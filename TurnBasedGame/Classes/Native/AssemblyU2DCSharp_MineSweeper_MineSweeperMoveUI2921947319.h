#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen651231328.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<MineSweeper.MineSweeperMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3906552072;
// MineSweeper.MineSweeperGameDataUI/UIData
struct UIData_t1952477953;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.MineSweeperMoveUI
struct  MineSweeperMoveUI_t2921947319  : public UIBehavior_1_t651231328
{
public:
	// UnityEngine.GameObject MineSweeper.MineSweeperMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Extensions.UILineRenderer MineSweeper.MineSweeperMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_7;
	// UnityEngine.UI.Image MineSweeper.MineSweeperMoveUI::imgHint
	Image_t2042527209 * ___imgHint_8;
	// GameDataBoardCheckPerspectiveChange`1<MineSweeper.MineSweeperMoveUI/UIData> MineSweeper.MineSweeperMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3906552072 * ___perspectiveChange_9;
	// MineSweeper.MineSweeperGameDataUI/UIData MineSweeper.MineSweeperMoveUI::mineSweeperGameDataUIData
	UIData_t1952477953 * ___mineSweeperGameDataUIData_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(MineSweeperMoveUI_t2921947319, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_lineRenderer_7() { return static_cast<int32_t>(offsetof(MineSweeperMoveUI_t2921947319, ___lineRenderer_7)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_7() const { return ___lineRenderer_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_7() { return &___lineRenderer_7; }
	inline void set_lineRenderer_7(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_7, value);
	}

	inline static int32_t get_offset_of_imgHint_8() { return static_cast<int32_t>(offsetof(MineSweeperMoveUI_t2921947319, ___imgHint_8)); }
	inline Image_t2042527209 * get_imgHint_8() const { return ___imgHint_8; }
	inline Image_t2042527209 ** get_address_of_imgHint_8() { return &___imgHint_8; }
	inline void set_imgHint_8(Image_t2042527209 * value)
	{
		___imgHint_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(MineSweeperMoveUI_t2921947319, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3906552072 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t3906552072 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t3906552072 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}

	inline static int32_t get_offset_of_mineSweeperGameDataUIData_10() { return static_cast<int32_t>(offsetof(MineSweeperMoveUI_t2921947319, ___mineSweeperGameDataUIData_10)); }
	inline UIData_t1952477953 * get_mineSweeperGameDataUIData_10() const { return ___mineSweeperGameDataUIData_10; }
	inline UIData_t1952477953 ** get_address_of_mineSweeperGameDataUIData_10() { return &___mineSweeperGameDataUIData_10; }
	inline void set_mineSweeperGameDataUIData_10(UIData_t1952477953 * value)
	{
		___mineSweeperGameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperGameDataUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
