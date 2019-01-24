#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.EventSystems.EventSystem
struct EventSystem_t3466835263;
// UnityEngine.UI.Button
struct Button_t2872111280;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.ReturnKeyTriggersButton
struct  ReturnKeyTriggersButton_t1668641634  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.EventSystems.EventSystem UnityEngine.UI.ReturnKeyTriggersButton::_system
	EventSystem_t3466835263 * ____system_2;
	// UnityEngine.UI.Button UnityEngine.UI.ReturnKeyTriggersButton::button
	Button_t2872111280 * ___button_3;
	// System.Boolean UnityEngine.UI.ReturnKeyTriggersButton::highlight
	bool ___highlight_4;
	// System.Single UnityEngine.UI.ReturnKeyTriggersButton::highlightDuration
	float ___highlightDuration_5;

public:
	inline static int32_t get_offset_of__system_2() { return static_cast<int32_t>(offsetof(ReturnKeyTriggersButton_t1668641634, ____system_2)); }
	inline EventSystem_t3466835263 * get__system_2() const { return ____system_2; }
	inline EventSystem_t3466835263 ** get_address_of__system_2() { return &____system_2; }
	inline void set__system_2(EventSystem_t3466835263 * value)
	{
		____system_2 = value;
		Il2CppCodeGenWriteBarrier(&____system_2, value);
	}

	inline static int32_t get_offset_of_button_3() { return static_cast<int32_t>(offsetof(ReturnKeyTriggersButton_t1668641634, ___button_3)); }
	inline Button_t2872111280 * get_button_3() const { return ___button_3; }
	inline Button_t2872111280 ** get_address_of_button_3() { return &___button_3; }
	inline void set_button_3(Button_t2872111280 * value)
	{
		___button_3 = value;
		Il2CppCodeGenWriteBarrier(&___button_3, value);
	}

	inline static int32_t get_offset_of_highlight_4() { return static_cast<int32_t>(offsetof(ReturnKeyTriggersButton_t1668641634, ___highlight_4)); }
	inline bool get_highlight_4() const { return ___highlight_4; }
	inline bool* get_address_of_highlight_4() { return &___highlight_4; }
	inline void set_highlight_4(bool value)
	{
		___highlight_4 = value;
	}

	inline static int32_t get_offset_of_highlightDuration_5() { return static_cast<int32_t>(offsetof(ReturnKeyTriggersButton_t1668641634, ___highlightDuration_5)); }
	inline float get_highlightDuration_5() const { return ___highlightDuration_5; }
	inline float* get_address_of_highlightDuration_5() { return &___highlightDuration_5; }
	inline void set_highlightDuration_5(float value)
	{
		___highlightDuration_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
