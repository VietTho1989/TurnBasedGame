#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4037845535.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ToastMessageUI
struct  ToastMessageUI_t998381756  : public UIBehavior_1_t4037845535
{
public:
	// UnityEngine.GameObject ToastMessageUI::toastMessageContainer
	GameObject_t1756533147 * ___toastMessageContainer_6;
	// UnityEngine.UI.Text ToastMessageUI::tvMessage
	Text_t356221433 * ___tvMessage_7;

public:
	inline static int32_t get_offset_of_toastMessageContainer_6() { return static_cast<int32_t>(offsetof(ToastMessageUI_t998381756, ___toastMessageContainer_6)); }
	inline GameObject_t1756533147 * get_toastMessageContainer_6() const { return ___toastMessageContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_toastMessageContainer_6() { return &___toastMessageContainer_6; }
	inline void set_toastMessageContainer_6(GameObject_t1756533147 * value)
	{
		___toastMessageContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___toastMessageContainer_6, value);
	}

	inline static int32_t get_offset_of_tvMessage_7() { return static_cast<int32_t>(offsetof(ToastMessageUI_t998381756, ___tvMessage_7)); }
	inline Text_t356221433 * get_tvMessage_7() const { return ___tvMessage_7; }
	inline Text_t356221433 ** get_address_of_tvMessage_7() { return &___tvMessage_7; }
	inline void set_tvMessage_7(Text_t356221433 * value)
	{
		___tvMessage_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvMessage_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
