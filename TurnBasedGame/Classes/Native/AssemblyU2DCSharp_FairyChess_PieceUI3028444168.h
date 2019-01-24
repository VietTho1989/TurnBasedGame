#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1571877160.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<FairyChess.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t532230608;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.PieceUI
struct  PieceUI_t3028444168  : public UIBehavior_1_t1571877160
{
public:
	// UnityEngine.GameObject FairyChess.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Image FairyChess.PieceUI::image
	Image_t2042527209 * ___image_7;
	// UnityEngine.Color FairyChess.PieceUI::EnPassantColor
	Color_t2020392075  ___EnPassantColor_8;
	// GameDataBoardCheckPerspectiveChange`1<FairyChess.PieceUI/UIData> FairyChess.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t532230608 * ___perspectiveChange_9;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(PieceUI_t3028444168, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_image_7() { return static_cast<int32_t>(offsetof(PieceUI_t3028444168, ___image_7)); }
	inline Image_t2042527209 * get_image_7() const { return ___image_7; }
	inline Image_t2042527209 ** get_address_of_image_7() { return &___image_7; }
	inline void set_image_7(Image_t2042527209 * value)
	{
		___image_7 = value;
		Il2CppCodeGenWriteBarrier(&___image_7, value);
	}

	inline static int32_t get_offset_of_EnPassantColor_8() { return static_cast<int32_t>(offsetof(PieceUI_t3028444168, ___EnPassantColor_8)); }
	inline Color_t2020392075  get_EnPassantColor_8() const { return ___EnPassantColor_8; }
	inline Color_t2020392075 * get_address_of_EnPassantColor_8() { return &___EnPassantColor_8; }
	inline void set_EnPassantColor_8(Color_t2020392075  value)
	{
		___EnPassantColor_8 = value;
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(PieceUI_t3028444168, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t532230608 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t532230608 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t532230608 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
