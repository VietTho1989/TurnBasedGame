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
// UnityEngine.UI.Toggle
struct Toggle_t3976754468;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithToggle
struct  LabelWithToggle_t2839074620  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Text frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithToggle::labelText
	Text_t356221433 * ___labelText_2;
	// UnityEngine.UI.Toggle frame8.ScrollRectItemsAdapter.Util.Drawer.LabelWithToggle::toggle
	Toggle_t3976754468 * ___toggle_3;

public:
	inline static int32_t get_offset_of_labelText_2() { return static_cast<int32_t>(offsetof(LabelWithToggle_t2839074620, ___labelText_2)); }
	inline Text_t356221433 * get_labelText_2() const { return ___labelText_2; }
	inline Text_t356221433 ** get_address_of_labelText_2() { return &___labelText_2; }
	inline void set_labelText_2(Text_t356221433 * value)
	{
		___labelText_2 = value;
		Il2CppCodeGenWriteBarrier(&___labelText_2, value);
	}

	inline static int32_t get_offset_of_toggle_3() { return static_cast<int32_t>(offsetof(LabelWithToggle_t2839074620, ___toggle_3)); }
	inline Toggle_t3976754468 * get_toggle_3() const { return ___toggle_3; }
	inline Toggle_t3976754468 ** get_address_of_toggle_3() { return &___toggle_3; }
	inline void set_toggle_3(Toggle_t3976754468 * value)
	{
		___toggle_3 = value;
		Il2CppCodeGenWriteBarrier(&___toggle_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
