#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1461652760.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<HEX.NoneRule.HexCustomSetUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t422006208;
// HEX.HexGameDataUI/UIData
struct UIData_t3485590849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.NoneRule.HexCustomSetUI
struct  HexCustomSetUI_t290838366  : public UIBehavior_1_t1461652760
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer HEX.NoneRule.HexCustomSetUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_6;
	// UnityEngine.UI.Image HEX.NoneRule.HexCustomSetUI::imgHint
	Image_t2042527209 * ___imgHint_7;
	// GameDataBoardCheckPerspectiveChange`1<HEX.NoneRule.HexCustomSetUI/UIData> HEX.NoneRule.HexCustomSetUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t422006208 * ___perspectiveChange_8;
	// HEX.HexGameDataUI/UIData HEX.NoneRule.HexCustomSetUI::hexGameDataUIData
	UIData_t3485590849 * ___hexGameDataUIData_9;

public:
	inline static int32_t get_offset_of_lineRenderer_6() { return static_cast<int32_t>(offsetof(HexCustomSetUI_t290838366, ___lineRenderer_6)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_6() const { return ___lineRenderer_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_6() { return &___lineRenderer_6; }
	inline void set_lineRenderer_6(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_6, value);
	}

	inline static int32_t get_offset_of_imgHint_7() { return static_cast<int32_t>(offsetof(HexCustomSetUI_t290838366, ___imgHint_7)); }
	inline Image_t2042527209 * get_imgHint_7() const { return ___imgHint_7; }
	inline Image_t2042527209 ** get_address_of_imgHint_7() { return &___imgHint_7; }
	inline void set_imgHint_7(Image_t2042527209 * value)
	{
		___imgHint_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(HexCustomSetUI_t290838366, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t422006208 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t422006208 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t422006208 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}

	inline static int32_t get_offset_of_hexGameDataUIData_9() { return static_cast<int32_t>(offsetof(HexCustomSetUI_t290838366, ___hexGameDataUIData_9)); }
	inline UIData_t3485590849 * get_hexGameDataUIData_9() const { return ___hexGameDataUIData_9; }
	inline UIData_t3485590849 ** get_address_of_hexGameDataUIData_9() { return &___hexGameDataUIData_9; }
	inline void set_hexGameDataUIData_9(UIData_t3485590849 * value)
	{
		___hexGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___hexGameDataUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
