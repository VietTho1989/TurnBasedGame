#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen550704460.h"

// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardBackgroundUI
struct  BoardBackgroundUI_t4184703426  : public UIBehavior_1_t550704460
{
public:
	// UnityEngine.Sprite Weiqi.BoardBackgroundUI::BoardSprite
	Sprite_t309593783 * ___BoardSprite_6;
	// UnityEngine.Sprite Weiqi.BoardBackgroundUI::EmptySprite
	Sprite_t309593783 * ___EmptySprite_7;
	// UnityEngine.UI.Image Weiqi.BoardBackgroundUI::image
	Image_t2042527209 * ___image_8;
	// UnityEngine.UI.Extensions.UILineRenderer Weiqi.BoardBackgroundUI::uiLineRender
	UILineRenderer_t3031355003 * ___uiLineRender_9;

public:
	inline static int32_t get_offset_of_BoardSprite_6() { return static_cast<int32_t>(offsetof(BoardBackgroundUI_t4184703426, ___BoardSprite_6)); }
	inline Sprite_t309593783 * get_BoardSprite_6() const { return ___BoardSprite_6; }
	inline Sprite_t309593783 ** get_address_of_BoardSprite_6() { return &___BoardSprite_6; }
	inline void set_BoardSprite_6(Sprite_t309593783 * value)
	{
		___BoardSprite_6 = value;
		Il2CppCodeGenWriteBarrier(&___BoardSprite_6, value);
	}

	inline static int32_t get_offset_of_EmptySprite_7() { return static_cast<int32_t>(offsetof(BoardBackgroundUI_t4184703426, ___EmptySprite_7)); }
	inline Sprite_t309593783 * get_EmptySprite_7() const { return ___EmptySprite_7; }
	inline Sprite_t309593783 ** get_address_of_EmptySprite_7() { return &___EmptySprite_7; }
	inline void set_EmptySprite_7(Sprite_t309593783 * value)
	{
		___EmptySprite_7 = value;
		Il2CppCodeGenWriteBarrier(&___EmptySprite_7, value);
	}

	inline static int32_t get_offset_of_image_8() { return static_cast<int32_t>(offsetof(BoardBackgroundUI_t4184703426, ___image_8)); }
	inline Image_t2042527209 * get_image_8() const { return ___image_8; }
	inline Image_t2042527209 ** get_address_of_image_8() { return &___image_8; }
	inline void set_image_8(Image_t2042527209 * value)
	{
		___image_8 = value;
		Il2CppCodeGenWriteBarrier(&___image_8, value);
	}

	inline static int32_t get_offset_of_uiLineRender_9() { return static_cast<int32_t>(offsetof(BoardBackgroundUI_t4184703426, ___uiLineRender_9)); }
	inline UILineRenderer_t3031355003 * get_uiLineRender_9() const { return ___uiLineRender_9; }
	inline UILineRenderer_t3031355003 ** get_address_of_uiLineRender_9() { return &___uiLineRender_9; }
	inline void set_uiLineRender_9(UILineRenderer_t3031355003 * value)
	{
		___uiLineRender_9 = value;
		Il2CppCodeGenWriteBarrier(&___uiLineRender_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
