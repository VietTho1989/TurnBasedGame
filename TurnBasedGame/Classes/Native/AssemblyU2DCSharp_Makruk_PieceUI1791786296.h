#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3696297908.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameDataBoardCheckPerspectiveChange`1<Makruk.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2656651356;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.PieceUI
struct  PieceUI_t1791786296  : public UIBehavior_1_t3696297908
{
public:
	// UnityEngine.UI.Image Makruk.PieceUI::image
	Image_t2042527209 * ___image_6;
	// UnityEngine.GameObject Makruk.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;
	// GameDataBoardCheckPerspectiveChange`1<Makruk.PieceUI/UIData> Makruk.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2656651356 * ___perspectiveChange_8;

public:
	inline static int32_t get_offset_of_image_6() { return static_cast<int32_t>(offsetof(PieceUI_t1791786296, ___image_6)); }
	inline Image_t2042527209 * get_image_6() const { return ___image_6; }
	inline Image_t2042527209 ** get_address_of_image_6() { return &___image_6; }
	inline void set_image_6(Image_t2042527209 * value)
	{
		___image_6 = value;
		Il2CppCodeGenWriteBarrier(&___image_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(PieceUI_t1791786296, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(PieceUI_t1791786296, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2656651356 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t2656651356 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t2656651356 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
