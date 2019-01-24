#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen990701263.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// Gomoku.GomokuGameDataUI/UIData
struct UIData_t2272016985;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.NoneRule.GomokuCustomMoveUI
struct  GomokuCustomMoveUI_t845601140  : public UIBehavior_1_t990701263
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Gomoku.NoneRule.GomokuCustomMoveUI::lineRendererFrom
	UILineRenderer_t3031355003 * ___lineRendererFrom_6;
	// UnityEngine.UI.Extensions.UILineRenderer Gomoku.NoneRule.GomokuCustomMoveUI::lineRendererDest
	UILineRenderer_t3031355003 * ___lineRendererDest_7;
	// Gomoku.GomokuGameDataUI/UIData Gomoku.NoneRule.GomokuCustomMoveUI::gomokuGameDataUIData
	UIData_t2272016985 * ___gomokuGameDataUIData_8;

public:
	inline static int32_t get_offset_of_lineRendererFrom_6() { return static_cast<int32_t>(offsetof(GomokuCustomMoveUI_t845601140, ___lineRendererFrom_6)); }
	inline UILineRenderer_t3031355003 * get_lineRendererFrom_6() const { return ___lineRendererFrom_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererFrom_6() { return &___lineRendererFrom_6; }
	inline void set_lineRendererFrom_6(UILineRenderer_t3031355003 * value)
	{
		___lineRendererFrom_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererFrom_6, value);
	}

	inline static int32_t get_offset_of_lineRendererDest_7() { return static_cast<int32_t>(offsetof(GomokuCustomMoveUI_t845601140, ___lineRendererDest_7)); }
	inline UILineRenderer_t3031355003 * get_lineRendererDest_7() const { return ___lineRendererDest_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererDest_7() { return &___lineRendererDest_7; }
	inline void set_lineRendererDest_7(UILineRenderer_t3031355003 * value)
	{
		___lineRendererDest_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererDest_7, value);
	}

	inline static int32_t get_offset_of_gomokuGameDataUIData_8() { return static_cast<int32_t>(offsetof(GomokuCustomMoveUI_t845601140, ___gomokuGameDataUIData_8)); }
	inline UIData_t2272016985 * get_gomokuGameDataUIData_8() const { return ___gomokuGameDataUIData_8; }
	inline UIData_t2272016985 ** get_address_of_gomokuGameDataUIData_8() { return &___gomokuGameDataUIData_8; }
	inline void set_gomokuGameDataUIData_8(UIData_t2272016985 * value)
	{
		___gomokuGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
