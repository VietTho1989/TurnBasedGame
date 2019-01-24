#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3557416637.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiPieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2517770085;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiPieceUI
struct  ReversiPieceUI_t964963564  : public UIBehavior_1_t3557416637
{
public:
	// UnityEngine.UI.Image Reversi.ReversiPieceUI::imgPiece
	Image_t2042527209 * ___imgPiece_6;
	// UnityEngine.Color Reversi.ReversiPieceUI::lastMoveColor
	Color_t2020392075  ___lastMoveColor_7;
	// UnityEngine.Color Reversi.ReversiPieceUI::flipColor
	Color_t2020392075  ___flipColor_8;
	// UnityEngine.UI.Extensions.UILineRenderer Reversi.ReversiPieceUI::flip
	UILineRenderer_t3031355003 * ___flip_9;
	// UnityEngine.GameObject Reversi.ReversiPieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_10;
	// GameDataBoardCheckPerspectiveChange`1<Reversi.ReversiPieceUI/UIData> Reversi.ReversiPieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2517770085 * ___perspectiveChange_11;

public:
	inline static int32_t get_offset_of_imgPiece_6() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___imgPiece_6)); }
	inline Image_t2042527209 * get_imgPiece_6() const { return ___imgPiece_6; }
	inline Image_t2042527209 ** get_address_of_imgPiece_6() { return &___imgPiece_6; }
	inline void set_imgPiece_6(Image_t2042527209 * value)
	{
		___imgPiece_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_6, value);
	}

	inline static int32_t get_offset_of_lastMoveColor_7() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___lastMoveColor_7)); }
	inline Color_t2020392075  get_lastMoveColor_7() const { return ___lastMoveColor_7; }
	inline Color_t2020392075 * get_address_of_lastMoveColor_7() { return &___lastMoveColor_7; }
	inline void set_lastMoveColor_7(Color_t2020392075  value)
	{
		___lastMoveColor_7 = value;
	}

	inline static int32_t get_offset_of_flipColor_8() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___flipColor_8)); }
	inline Color_t2020392075  get_flipColor_8() const { return ___flipColor_8; }
	inline Color_t2020392075 * get_address_of_flipColor_8() { return &___flipColor_8; }
	inline void set_flipColor_8(Color_t2020392075  value)
	{
		___flipColor_8 = value;
	}

	inline static int32_t get_offset_of_flip_9() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___flip_9)); }
	inline UILineRenderer_t3031355003 * get_flip_9() const { return ___flip_9; }
	inline UILineRenderer_t3031355003 ** get_address_of_flip_9() { return &___flip_9; }
	inline void set_flip_9(UILineRenderer_t3031355003 * value)
	{
		___flip_9 = value;
		Il2CppCodeGenWriteBarrier(&___flip_9, value);
	}

	inline static int32_t get_offset_of_contentContainer_10() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___contentContainer_10)); }
	inline GameObject_t1756533147 * get_contentContainer_10() const { return ___contentContainer_10; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_10() { return &___contentContainer_10; }
	inline void set_contentContainer_10(GameObject_t1756533147 * value)
	{
		___contentContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_10, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_11() { return static_cast<int32_t>(offsetof(ReversiPieceUI_t964963564, ___perspectiveChange_11)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2517770085 * get_perspectiveChange_11() const { return ___perspectiveChange_11; }
	inline GameDataBoardCheckPerspectiveChange_1_t2517770085 ** get_address_of_perspectiveChange_11() { return &___perspectiveChange_11; }
	inline void set_perspectiveChange_11(GameDataBoardCheckPerspectiveChange_1_t2517770085 * value)
	{
		___perspectiveChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
