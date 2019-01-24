#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4075042614.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<Chess.NoneRule.ChessCustomSetUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3035396062;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.NoneRule.ChessCustomSetUI
struct  ChessCustomSetUI_t507609497  : public UIBehavior_1_t4075042614
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Chess.NoneRule.ChessCustomSetUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_6;
	// UnityEngine.UI.Image Chess.NoneRule.ChessCustomSetUI::imgHint
	Image_t2042527209 * ___imgHint_7;
	// GameDataBoardCheckPerspectiveChange`1<Chess.NoneRule.ChessCustomSetUI/UIData> Chess.NoneRule.ChessCustomSetUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3035396062 * ___perspectiveChange_8;

public:
	inline static int32_t get_offset_of_lineRenderer_6() { return static_cast<int32_t>(offsetof(ChessCustomSetUI_t507609497, ___lineRenderer_6)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_6() const { return ___lineRenderer_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_6() { return &___lineRenderer_6; }
	inline void set_lineRenderer_6(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_6, value);
	}

	inline static int32_t get_offset_of_imgHint_7() { return static_cast<int32_t>(offsetof(ChessCustomSetUI_t507609497, ___imgHint_7)); }
	inline Image_t2042527209 * get_imgHint_7() const { return ___imgHint_7; }
	inline Image_t2042527209 ** get_address_of_imgHint_7() { return &___imgHint_7; }
	inline void set_imgHint_7(Image_t2042527209 * value)
	{
		___imgHint_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(ChessCustomSetUI_t507609497, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3035396062 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t3035396062 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t3035396062 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
