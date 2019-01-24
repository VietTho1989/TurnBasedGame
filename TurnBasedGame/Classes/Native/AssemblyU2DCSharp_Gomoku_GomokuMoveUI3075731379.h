#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2889802564.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// Gomoku.GomokuGameDataUI/UIData
struct UIData_t2272016985;
// GameDataBoardCheckPerspectiveChange`1<Gomoku.GomokuMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t1850156012;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuMoveUI
struct  GomokuMoveUI_t3075731379  : public UIBehavior_1_t2889802564
{
public:
	// UnityEngine.GameObject Gomoku.GomokuMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Extensions.UILineRenderer Gomoku.GomokuMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_7;
	// UnityEngine.UI.Image Gomoku.GomokuMoveUI::imgHint
	Image_t2042527209 * ___imgHint_8;
	// Gomoku.GomokuGameDataUI/UIData Gomoku.GomokuMoveUI::gomokuGameDataUIData
	UIData_t2272016985 * ___gomokuGameDataUIData_9;
	// GameDataBoardCheckPerspectiveChange`1<Gomoku.GomokuMoveUI/UIData> Gomoku.GomokuMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t1850156012 * ___perspectiveChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(GomokuMoveUI_t3075731379, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_lineRenderer_7() { return static_cast<int32_t>(offsetof(GomokuMoveUI_t3075731379, ___lineRenderer_7)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_7() const { return ___lineRenderer_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_7() { return &___lineRenderer_7; }
	inline void set_lineRenderer_7(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_7, value);
	}

	inline static int32_t get_offset_of_imgHint_8() { return static_cast<int32_t>(offsetof(GomokuMoveUI_t3075731379, ___imgHint_8)); }
	inline Image_t2042527209 * get_imgHint_8() const { return ___imgHint_8; }
	inline Image_t2042527209 ** get_address_of_imgHint_8() { return &___imgHint_8; }
	inline void set_imgHint_8(Image_t2042527209 * value)
	{
		___imgHint_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_8, value);
	}

	inline static int32_t get_offset_of_gomokuGameDataUIData_9() { return static_cast<int32_t>(offsetof(GomokuMoveUI_t3075731379, ___gomokuGameDataUIData_9)); }
	inline UIData_t2272016985 * get_gomokuGameDataUIData_9() const { return ___gomokuGameDataUIData_9; }
	inline UIData_t2272016985 ** get_address_of_gomokuGameDataUIData_9() { return &___gomokuGameDataUIData_9; }
	inline void set_gomokuGameDataUIData_9(UIData_t2272016985 * value)
	{
		___gomokuGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_10() { return static_cast<int32_t>(offsetof(GomokuMoveUI_t3075731379, ___perspectiveChange_10)); }
	inline GameDataBoardCheckPerspectiveChange_1_t1850156012 * get_perspectiveChange_10() const { return ___perspectiveChange_10; }
	inline GameDataBoardCheckPerspectiveChange_1_t1850156012 ** get_address_of_perspectiveChange_10() { return &___perspectiveChange_10; }
	inline void set_perspectiveChange_10(GameDataBoardCheckPerspectiveChange_1_t1850156012 * value)
	{
		___perspectiveChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
