#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2707900634.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Toggle
struct Toggle_t3976754468;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeBoolUI
struct  RequestChangeBoolUI_t2618169711  : public UIBehavior_1_t2707900634
{
public:
	// UnityEngine.UI.Button RequestChangeBoolUI::btnValue
	Button_t2872111280 * ___btnValue_6;
	// UnityEngine.UI.Toggle RequestChangeBoolUI::tgValue
	Toggle_t3976754468 * ___tgValue_7;
	// UnityEngine.UI.Text RequestChangeBoolUI::tvState
	Text_t356221433 * ___tvState_8;
	// UnityEngine.GameObject RequestChangeBoolUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_9;

public:
	inline static int32_t get_offset_of_btnValue_6() { return static_cast<int32_t>(offsetof(RequestChangeBoolUI_t2618169711, ___btnValue_6)); }
	inline Button_t2872111280 * get_btnValue_6() const { return ___btnValue_6; }
	inline Button_t2872111280 ** get_address_of_btnValue_6() { return &___btnValue_6; }
	inline void set_btnValue_6(Button_t2872111280 * value)
	{
		___btnValue_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnValue_6, value);
	}

	inline static int32_t get_offset_of_tgValue_7() { return static_cast<int32_t>(offsetof(RequestChangeBoolUI_t2618169711, ___tgValue_7)); }
	inline Toggle_t3976754468 * get_tgValue_7() const { return ___tgValue_7; }
	inline Toggle_t3976754468 ** get_address_of_tgValue_7() { return &___tgValue_7; }
	inline void set_tgValue_7(Toggle_t3976754468 * value)
	{
		___tgValue_7 = value;
		Il2CppCodeGenWriteBarrier(&___tgValue_7, value);
	}

	inline static int32_t get_offset_of_tvState_8() { return static_cast<int32_t>(offsetof(RequestChangeBoolUI_t2618169711, ___tvState_8)); }
	inline Text_t356221433 * get_tvState_8() const { return ___tvState_8; }
	inline Text_t356221433 ** get_address_of_tvState_8() { return &___tvState_8; }
	inline void set_tvState_8(Text_t356221433 * value)
	{
		___tvState_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_8, value);
	}

	inline static int32_t get_offset_of_differentIndicator_9() { return static_cast<int32_t>(offsetof(RequestChangeBoolUI_t2618169711, ___differentIndicator_9)); }
	inline GameObject_t1756533147 * get_differentIndicator_9() const { return ___differentIndicator_9; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_9() { return &___differentIndicator_9; }
	inline void set_differentIndicator_9(GameObject_t1756533147 * value)
	{
		___differentIndicator_9 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
