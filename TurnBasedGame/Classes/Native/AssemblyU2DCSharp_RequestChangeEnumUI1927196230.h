#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2756673481.h"

// UnityEngine.UI.Dropdown
struct Dropdown_t1985816271;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeEnumUI
struct  RequestChangeEnumUI_t1927196230  : public UIBehavior_1_t2756673481
{
public:
	// UnityEngine.UI.Dropdown RequestChangeEnumUI::drValues
	Dropdown_t1985816271 * ___drValues_6;
	// UnityEngine.UI.Text RequestChangeEnumUI::tvState
	Text_t356221433 * ___tvState_7;
	// UnityEngine.GameObject RequestChangeEnumUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;

public:
	inline static int32_t get_offset_of_drValues_6() { return static_cast<int32_t>(offsetof(RequestChangeEnumUI_t1927196230, ___drValues_6)); }
	inline Dropdown_t1985816271 * get_drValues_6() const { return ___drValues_6; }
	inline Dropdown_t1985816271 ** get_address_of_drValues_6() { return &___drValues_6; }
	inline void set_drValues_6(Dropdown_t1985816271 * value)
	{
		___drValues_6 = value;
		Il2CppCodeGenWriteBarrier(&___drValues_6, value);
	}

	inline static int32_t get_offset_of_tvState_7() { return static_cast<int32_t>(offsetof(RequestChangeEnumUI_t1927196230, ___tvState_7)); }
	inline Text_t356221433 * get_tvState_7() const { return ___tvState_7; }
	inline Text_t356221433 ** get_address_of_tvState_7() { return &___tvState_7; }
	inline void set_tvState_7(Text_t356221433 * value)
	{
		___tvState_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvState_7, value);
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(RequestChangeEnumUI_t1927196230, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
