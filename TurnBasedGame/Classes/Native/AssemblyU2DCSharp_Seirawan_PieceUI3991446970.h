#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1720692617.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameDataBoardCheckPerspectiveChange`1<Seirawan.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t681046065;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.PieceUI
struct  PieceUI_t3991446970  : public UIBehavior_1_t1720692617
{
public:
	// UnityEngine.UI.Image Seirawan.PieceUI::image
	Image_t2042527209 * ___image_6;
	// UnityEngine.GameObject Seirawan.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;
	// UnityEngine.UI.Image Seirawan.PieceUI::imgSeirawan
	Image_t2042527209 * ___imgSeirawan_8;
	// UnityEngine.Color Seirawan.PieceUI::EnPassantColor
	Color_t2020392075  ___EnPassantColor_9;
	// GameDataBoardCheckPerspectiveChange`1<Seirawan.PieceUI/UIData> Seirawan.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t681046065 * ___perspectiveChange_10;

public:
	inline static int32_t get_offset_of_image_6() { return static_cast<int32_t>(offsetof(PieceUI_t3991446970, ___image_6)); }
	inline Image_t2042527209 * get_image_6() const { return ___image_6; }
	inline Image_t2042527209 ** get_address_of_image_6() { return &___image_6; }
	inline void set_image_6(Image_t2042527209 * value)
	{
		___image_6 = value;
		Il2CppCodeGenWriteBarrier(&___image_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(PieceUI_t3991446970, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_imgSeirawan_8() { return static_cast<int32_t>(offsetof(PieceUI_t3991446970, ___imgSeirawan_8)); }
	inline Image_t2042527209 * get_imgSeirawan_8() const { return ___imgSeirawan_8; }
	inline Image_t2042527209 ** get_address_of_imgSeirawan_8() { return &___imgSeirawan_8; }
	inline void set_imgSeirawan_8(Image_t2042527209 * value)
	{
		___imgSeirawan_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgSeirawan_8, value);
	}

	inline static int32_t get_offset_of_EnPassantColor_9() { return static_cast<int32_t>(offsetof(PieceUI_t3991446970, ___EnPassantColor_9)); }
	inline Color_t2020392075  get_EnPassantColor_9() const { return ___EnPassantColor_9; }
	inline Color_t2020392075 * get_address_of_EnPassantColor_9() { return &___EnPassantColor_9; }
	inline void set_EnPassantColor_9(Color_t2020392075  value)
	{
		___EnPassantColor_9 = value;
	}

	inline static int32_t get_offset_of_perspectiveChange_10() { return static_cast<int32_t>(offsetof(PieceUI_t3991446970, ___perspectiveChange_10)); }
	inline GameDataBoardCheckPerspectiveChange_1_t681046065 * get_perspectiveChange_10() const { return ___perspectiveChange_10; }
	inline GameDataBoardCheckPerspectiveChange_1_t681046065 ** get_address_of_perspectiveChange_10() { return &___perspectiveChange_10; }
	inline void set_perspectiveChange_10(GameDataBoardCheckPerspectiveChange_1_t681046065 * value)
	{
		___perspectiveChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
