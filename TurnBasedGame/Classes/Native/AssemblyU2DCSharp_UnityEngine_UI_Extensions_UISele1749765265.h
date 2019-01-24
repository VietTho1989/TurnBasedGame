#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Extensions.UISelectableExtension/UIButtonEvent
struct UIButtonEvent_t1812119617;
// UnityEngine.EventSystems.PointerEventData
struct PointerEventData_t1599784723;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.UISelectableExtension
struct  UISelectableExtension_t1749765265  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.Extensions.UISelectableExtension/UIButtonEvent UnityEngine.UI.Extensions.UISelectableExtension::OnButtonPress
	UIButtonEvent_t1812119617 * ___OnButtonPress_2;
	// UnityEngine.UI.Extensions.UISelectableExtension/UIButtonEvent UnityEngine.UI.Extensions.UISelectableExtension::OnButtonRelease
	UIButtonEvent_t1812119617 * ___OnButtonRelease_3;
	// UnityEngine.UI.Extensions.UISelectableExtension/UIButtonEvent UnityEngine.UI.Extensions.UISelectableExtension::OnButtonHeld
	UIButtonEvent_t1812119617 * ___OnButtonHeld_4;
	// System.Boolean UnityEngine.UI.Extensions.UISelectableExtension::_pressed
	bool ____pressed_5;
	// UnityEngine.EventSystems.PointerEventData UnityEngine.UI.Extensions.UISelectableExtension::_heldEventData
	PointerEventData_t1599784723 * ____heldEventData_6;

public:
	inline static int32_t get_offset_of_OnButtonPress_2() { return static_cast<int32_t>(offsetof(UISelectableExtension_t1749765265, ___OnButtonPress_2)); }
	inline UIButtonEvent_t1812119617 * get_OnButtonPress_2() const { return ___OnButtonPress_2; }
	inline UIButtonEvent_t1812119617 ** get_address_of_OnButtonPress_2() { return &___OnButtonPress_2; }
	inline void set_OnButtonPress_2(UIButtonEvent_t1812119617 * value)
	{
		___OnButtonPress_2 = value;
		Il2CppCodeGenWriteBarrier(&___OnButtonPress_2, value);
	}

	inline static int32_t get_offset_of_OnButtonRelease_3() { return static_cast<int32_t>(offsetof(UISelectableExtension_t1749765265, ___OnButtonRelease_3)); }
	inline UIButtonEvent_t1812119617 * get_OnButtonRelease_3() const { return ___OnButtonRelease_3; }
	inline UIButtonEvent_t1812119617 ** get_address_of_OnButtonRelease_3() { return &___OnButtonRelease_3; }
	inline void set_OnButtonRelease_3(UIButtonEvent_t1812119617 * value)
	{
		___OnButtonRelease_3 = value;
		Il2CppCodeGenWriteBarrier(&___OnButtonRelease_3, value);
	}

	inline static int32_t get_offset_of_OnButtonHeld_4() { return static_cast<int32_t>(offsetof(UISelectableExtension_t1749765265, ___OnButtonHeld_4)); }
	inline UIButtonEvent_t1812119617 * get_OnButtonHeld_4() const { return ___OnButtonHeld_4; }
	inline UIButtonEvent_t1812119617 ** get_address_of_OnButtonHeld_4() { return &___OnButtonHeld_4; }
	inline void set_OnButtonHeld_4(UIButtonEvent_t1812119617 * value)
	{
		___OnButtonHeld_4 = value;
		Il2CppCodeGenWriteBarrier(&___OnButtonHeld_4, value);
	}

	inline static int32_t get_offset_of__pressed_5() { return static_cast<int32_t>(offsetof(UISelectableExtension_t1749765265, ____pressed_5)); }
	inline bool get__pressed_5() const { return ____pressed_5; }
	inline bool* get_address_of__pressed_5() { return &____pressed_5; }
	inline void set__pressed_5(bool value)
	{
		____pressed_5 = value;
	}

	inline static int32_t get_offset_of__heldEventData_6() { return static_cast<int32_t>(offsetof(UISelectableExtension_t1749765265, ____heldEventData_6)); }
	inline PointerEventData_t1599784723 * get__heldEventData_6() const { return ____heldEventData_6; }
	inline PointerEventData_t1599784723 ** get_address_of__heldEventData_6() { return &____heldEventData_6; }
	inline void set__heldEventData_6(PointerEventData_t1599784723 * value)
	{
		____heldEventData_6 = value;
		Il2CppCodeGenWriteBarrier(&____heldEventData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
