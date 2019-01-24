﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2339105150.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<Gomoku.NoneRule.GomokuCustomSetUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t1299458598;
// Gomoku.GomokuGameDataUI/UIData
struct UIData_t2272016985;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.NoneRule.GomokuCustomSetUI
struct  GomokuCustomSetUI_t2266270591  : public UIBehavior_1_t2339105150
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Gomoku.NoneRule.GomokuCustomSetUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_6;
	// UnityEngine.UI.Image Gomoku.NoneRule.GomokuCustomSetUI::imgHint
	Image_t2042527209 * ___imgHint_7;
	// GameDataBoardCheckPerspectiveChange`1<Gomoku.NoneRule.GomokuCustomSetUI/UIData> Gomoku.NoneRule.GomokuCustomSetUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t1299458598 * ___perspectiveChange_8;
	// Gomoku.GomokuGameDataUI/UIData Gomoku.NoneRule.GomokuCustomSetUI::gomokuGameDataUIData
	UIData_t2272016985 * ___gomokuGameDataUIData_9;

public:
	inline static int32_t get_offset_of_lineRenderer_6() { return static_cast<int32_t>(offsetof(GomokuCustomSetUI_t2266270591, ___lineRenderer_6)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_6() const { return ___lineRenderer_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_6() { return &___lineRenderer_6; }
	inline void set_lineRenderer_6(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_6, value);
	}

	inline static int32_t get_offset_of_imgHint_7() { return static_cast<int32_t>(offsetof(GomokuCustomSetUI_t2266270591, ___imgHint_7)); }
	inline Image_t2042527209 * get_imgHint_7() const { return ___imgHint_7; }
	inline Image_t2042527209 ** get_address_of_imgHint_7() { return &___imgHint_7; }
	inline void set_imgHint_7(Image_t2042527209 * value)
	{
		___imgHint_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(GomokuCustomSetUI_t2266270591, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t1299458598 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t1299458598 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t1299458598 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}

	inline static int32_t get_offset_of_gomokuGameDataUIData_9() { return static_cast<int32_t>(offsetof(GomokuCustomSetUI_t2266270591, ___gomokuGameDataUIData_9)); }
	inline UIData_t2272016985 * get_gomokuGameDataUIData_9() const { return ___gomokuGameDataUIData_9; }
	inline UIData_t2272016985 ** get_address_of_gomokuGameDataUIData_9() { return &___gomokuGameDataUIData_9; }
	inline void set_gomokuGameDataUIData_9(UIData_t2272016985 * value)
	{
		___gomokuGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuGameDataUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
