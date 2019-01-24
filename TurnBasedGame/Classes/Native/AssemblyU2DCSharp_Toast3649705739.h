#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2138951498.h"

// ToastMessageUI
struct ToastMessageUI_t998381756;
// Toast
struct Toast_t3649705739;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Toast
struct  Toast_t3649705739  : public UIBehavior_1_t2138951498
{
public:
	// ToastMessageUI Toast::toastMessageUI
	ToastMessageUI_t998381756 * ___toastMessageUI_6;

public:
	inline static int32_t get_offset_of_toastMessageUI_6() { return static_cast<int32_t>(offsetof(Toast_t3649705739, ___toastMessageUI_6)); }
	inline ToastMessageUI_t998381756 * get_toastMessageUI_6() const { return ___toastMessageUI_6; }
	inline ToastMessageUI_t998381756 ** get_address_of_toastMessageUI_6() { return &___toastMessageUI_6; }
	inline void set_toastMessageUI_6(ToastMessageUI_t998381756 * value)
	{
		___toastMessageUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___toastMessageUI_6, value);
	}
};

struct Toast_t3649705739_StaticFields
{
public:
	// Toast Toast::instance
	Toast_t3649705739 * ___instance_7;

public:
	inline static int32_t get_offset_of_instance_7() { return static_cast<int32_t>(offsetof(Toast_t3649705739_StaticFields, ___instance_7)); }
	inline Toast_t3649705739 * get_instance_7() const { return ___instance_7; }
	inline Toast_t3649705739 ** get_address_of_instance_7() { return &___instance_7; }
	inline void set_instance_7(Toast_t3649705739 * value)
	{
		___instance_7 = value;
		Il2CppCodeGenWriteBarrier(&___instance_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
