#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.SpriteRenderer
struct SpriteRenderer_t1209076198;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ExampleSelectable
struct  ExampleSelectable_t2153456088  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityEngine.UI.Extensions.ExampleSelectable::_selected
	bool ____selected_2;
	// System.Boolean UnityEngine.UI.Extensions.ExampleSelectable::_preSelected
	bool ____preSelected_3;
	// UnityEngine.SpriteRenderer UnityEngine.UI.Extensions.ExampleSelectable::spriteRenderer
	SpriteRenderer_t1209076198 * ___spriteRenderer_4;
	// UnityEngine.UI.Image UnityEngine.UI.Extensions.ExampleSelectable::image
	Image_t2042527209 * ___image_5;
	// UnityEngine.UI.Text UnityEngine.UI.Extensions.ExampleSelectable::text
	Text_t356221433 * ___text_6;

public:
	inline static int32_t get_offset_of__selected_2() { return static_cast<int32_t>(offsetof(ExampleSelectable_t2153456088, ____selected_2)); }
	inline bool get__selected_2() const { return ____selected_2; }
	inline bool* get_address_of__selected_2() { return &____selected_2; }
	inline void set__selected_2(bool value)
	{
		____selected_2 = value;
	}

	inline static int32_t get_offset_of__preSelected_3() { return static_cast<int32_t>(offsetof(ExampleSelectable_t2153456088, ____preSelected_3)); }
	inline bool get__preSelected_3() const { return ____preSelected_3; }
	inline bool* get_address_of__preSelected_3() { return &____preSelected_3; }
	inline void set__preSelected_3(bool value)
	{
		____preSelected_3 = value;
	}

	inline static int32_t get_offset_of_spriteRenderer_4() { return static_cast<int32_t>(offsetof(ExampleSelectable_t2153456088, ___spriteRenderer_4)); }
	inline SpriteRenderer_t1209076198 * get_spriteRenderer_4() const { return ___spriteRenderer_4; }
	inline SpriteRenderer_t1209076198 ** get_address_of_spriteRenderer_4() { return &___spriteRenderer_4; }
	inline void set_spriteRenderer_4(SpriteRenderer_t1209076198 * value)
	{
		___spriteRenderer_4 = value;
		Il2CppCodeGenWriteBarrier(&___spriteRenderer_4, value);
	}

	inline static int32_t get_offset_of_image_5() { return static_cast<int32_t>(offsetof(ExampleSelectable_t2153456088, ___image_5)); }
	inline Image_t2042527209 * get_image_5() const { return ___image_5; }
	inline Image_t2042527209 ** get_address_of_image_5() { return &___image_5; }
	inline void set_image_5(Image_t2042527209 * value)
	{
		___image_5 = value;
		Il2CppCodeGenWriteBarrier(&___image_5, value);
	}

	inline static int32_t get_offset_of_text_6() { return static_cast<int32_t>(offsetof(ExampleSelectable_t2153456088, ___text_6)); }
	inline Text_t356221433 * get_text_6() const { return ___text_6; }
	inline Text_t356221433 ** get_address_of_text_6() { return &___text_6; }
	inline void set_text_6(Text_t356221433 * value)
	{
		___text_6 = value;
		Il2CppCodeGenWriteBarrier(&___text_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
