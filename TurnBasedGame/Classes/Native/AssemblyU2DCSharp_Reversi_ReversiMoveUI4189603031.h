#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3991996960.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// Reversi.ReversiGameDataUI/UIData
struct UIData_t1808669889;
// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2952350408;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiMoveUI
struct  ReversiMoveUI_t4189603031  : public UIBehavior_1_t3991996960
{
public:
	// UnityEngine.GameObject Reversi.ReversiMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Extensions.UILineRenderer Reversi.ReversiMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_7;
	// UnityEngine.UI.Image Reversi.ReversiMoveUI::imgHint
	Image_t2042527209 * ___imgHint_8;
	// Reversi.ReversiGameDataUI/UIData Reversi.ReversiMoveUI::reversiGameDataUIData
	UIData_t1808669889 * ___reversiGameDataUIData_9;
	// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiMoveUI/UIData> Reversi.ReversiMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2952350408 * ___perspectiveChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(ReversiMoveUI_t4189603031, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_lineRenderer_7() { return static_cast<int32_t>(offsetof(ReversiMoveUI_t4189603031, ___lineRenderer_7)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_7() const { return ___lineRenderer_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_7() { return &___lineRenderer_7; }
	inline void set_lineRenderer_7(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_7, value);
	}

	inline static int32_t get_offset_of_imgHint_8() { return static_cast<int32_t>(offsetof(ReversiMoveUI_t4189603031, ___imgHint_8)); }
	inline Image_t2042527209 * get_imgHint_8() const { return ___imgHint_8; }
	inline Image_t2042527209 ** get_address_of_imgHint_8() { return &___imgHint_8; }
	inline void set_imgHint_8(Image_t2042527209 * value)
	{
		___imgHint_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_8, value);
	}

	inline static int32_t get_offset_of_reversiGameDataUIData_9() { return static_cast<int32_t>(offsetof(ReversiMoveUI_t4189603031, ___reversiGameDataUIData_9)); }
	inline UIData_t1808669889 * get_reversiGameDataUIData_9() const { return ___reversiGameDataUIData_9; }
	inline UIData_t1808669889 ** get_address_of_reversiGameDataUIData_9() { return &___reversiGameDataUIData_9; }
	inline void set_reversiGameDataUIData_9(UIData_t1808669889 * value)
	{
		___reversiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___reversiGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_10() { return static_cast<int32_t>(offsetof(ReversiMoveUI_t4189603031, ___perspectiveChange_10)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2952350408 * get_perspectiveChange_10() const { return ___perspectiveChange_10; }
	inline GameDataBoardCheckPerspectiveChange_1_t2952350408 ** get_address_of_perspectiveChange_10() { return &___perspectiveChange_10; }
	inline void set_perspectiveChange_10(GameDataBoardCheckPerspectiveChange_1_t2952350408 * value)
	{
		___perspectiveChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
