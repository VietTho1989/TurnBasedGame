#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1375698667.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// HEX.HexGameDataUI/UIData
struct UIData_t3485590849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.NoneRule.HexCustomMoveUI
struct  HexCustomMoveUI_t2846194653  : public UIBehavior_1_t1375698667
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer HEX.NoneRule.HexCustomMoveUI::lineRendererFrom
	UILineRenderer_t3031355003 * ___lineRendererFrom_6;
	// UnityEngine.UI.Extensions.UILineRenderer HEX.NoneRule.HexCustomMoveUI::lineRendererDest
	UILineRenderer_t3031355003 * ___lineRendererDest_7;
	// HEX.HexGameDataUI/UIData HEX.NoneRule.HexCustomMoveUI::hexGameDataUIData
	UIData_t3485590849 * ___hexGameDataUIData_8;

public:
	inline static int32_t get_offset_of_lineRendererFrom_6() { return static_cast<int32_t>(offsetof(HexCustomMoveUI_t2846194653, ___lineRendererFrom_6)); }
	inline UILineRenderer_t3031355003 * get_lineRendererFrom_6() const { return ___lineRendererFrom_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererFrom_6() { return &___lineRendererFrom_6; }
	inline void set_lineRendererFrom_6(UILineRenderer_t3031355003 * value)
	{
		___lineRendererFrom_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererFrom_6, value);
	}

	inline static int32_t get_offset_of_lineRendererDest_7() { return static_cast<int32_t>(offsetof(HexCustomMoveUI_t2846194653, ___lineRendererDest_7)); }
	inline UILineRenderer_t3031355003 * get_lineRendererDest_7() const { return ___lineRendererDest_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererDest_7() { return &___lineRendererDest_7; }
	inline void set_lineRendererDest_7(UILineRenderer_t3031355003 * value)
	{
		___lineRendererDest_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererDest_7, value);
	}

	inline static int32_t get_offset_of_hexGameDataUIData_8() { return static_cast<int32_t>(offsetof(HexCustomMoveUI_t2846194653, ___hexGameDataUIData_8)); }
	inline UIData_t3485590849 * get_hexGameDataUIData_8() const { return ___hexGameDataUIData_8; }
	inline UIData_t3485590849 ** get_address_of_hexGameDataUIData_8() { return &___hexGameDataUIData_8; }
	inline void set_hexGameDataUIData_8(UIData_t3485590849 * value)
	{
		___hexGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___hexGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
