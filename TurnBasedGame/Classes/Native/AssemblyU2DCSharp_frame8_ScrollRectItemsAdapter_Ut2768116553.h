#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Slider
struct Slider_t297367283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithSliderPanel
struct  LabelWithSliderPanel_t2768116553  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Text frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithSliderPanel::labelText
	Text_t356221433 * ___labelText_2;
	// UnityEngine.UI.Text frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithSliderPanel::minLabelText
	Text_t356221433 * ___minLabelText_3;
	// UnityEngine.UI.Text frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithSliderPanel::maxLabelText
	Text_t356221433 * ___maxLabelText_4;
	// UnityEngine.UI.Slider frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithSliderPanel::slider
	Slider_t297367283 * ___slider_5;

public:
	inline static int32_t get_offset_of_labelText_2() { return static_cast<int32_t>(offsetof(LabelWithSliderPanel_t2768116553, ___labelText_2)); }
	inline Text_t356221433 * get_labelText_2() const { return ___labelText_2; }
	inline Text_t356221433 ** get_address_of_labelText_2() { return &___labelText_2; }
	inline void set_labelText_2(Text_t356221433 * value)
	{
		___labelText_2 = value;
		Il2CppCodeGenWriteBarrier(&___labelText_2, value);
	}

	inline static int32_t get_offset_of_minLabelText_3() { return static_cast<int32_t>(offsetof(LabelWithSliderPanel_t2768116553, ___minLabelText_3)); }
	inline Text_t356221433 * get_minLabelText_3() const { return ___minLabelText_3; }
	inline Text_t356221433 ** get_address_of_minLabelText_3() { return &___minLabelText_3; }
	inline void set_minLabelText_3(Text_t356221433 * value)
	{
		___minLabelText_3 = value;
		Il2CppCodeGenWriteBarrier(&___minLabelText_3, value);
	}

	inline static int32_t get_offset_of_maxLabelText_4() { return static_cast<int32_t>(offsetof(LabelWithSliderPanel_t2768116553, ___maxLabelText_4)); }
	inline Text_t356221433 * get_maxLabelText_4() const { return ___maxLabelText_4; }
	inline Text_t356221433 ** get_address_of_maxLabelText_4() { return &___maxLabelText_4; }
	inline void set_maxLabelText_4(Text_t356221433 * value)
	{
		___maxLabelText_4 = value;
		Il2CppCodeGenWriteBarrier(&___maxLabelText_4, value);
	}

	inline static int32_t get_offset_of_slider_5() { return static_cast<int32_t>(offsetof(LabelWithSliderPanel_t2768116553, ___slider_5)); }
	inline Slider_t297367283 * get_slider_5() const { return ___slider_5; }
	inline Slider_t297367283 ** get_address_of_slider_5() { return &___slider_5; }
	inline void set_slider_5(Slider_t297367283 * value)
	{
		___slider_5 = value;
		Il2CppCodeGenWriteBarrier(&___slider_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
