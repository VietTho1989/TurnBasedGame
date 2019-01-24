#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ToastData>
struct VP_1_t3670531145;
// VP`1<ToastMessageUI/UIData>
struct VP_1_t837080393;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Toast/UIData
struct  UIData_t2854876646  : public Data_t3569509720
{
public:
	// VP`1<ToastData> Toast/UIData::toastData
	VP_1_t3670531145 * ___toastData_5;
	// VP`1<ToastMessageUI/UIData> Toast/UIData::toastMessageUI
	VP_1_t837080393 * ___toastMessageUI_6;

public:
	inline static int32_t get_offset_of_toastData_5() { return static_cast<int32_t>(offsetof(UIData_t2854876646, ___toastData_5)); }
	inline VP_1_t3670531145 * get_toastData_5() const { return ___toastData_5; }
	inline VP_1_t3670531145 ** get_address_of_toastData_5() { return &___toastData_5; }
	inline void set_toastData_5(VP_1_t3670531145 * value)
	{
		___toastData_5 = value;
		Il2CppCodeGenWriteBarrier(&___toastData_5, value);
	}

	inline static int32_t get_offset_of_toastMessageUI_6() { return static_cast<int32_t>(offsetof(UIData_t2854876646, ___toastMessageUI_6)); }
	inline VP_1_t837080393 * get_toastMessageUI_6() const { return ___toastMessageUI_6; }
	inline VP_1_t837080393 ** get_address_of_toastMessageUI_6() { return &___toastMessageUI_6; }
	inline void set_toastMessageUI_6(VP_1_t837080393 * value)
	{
		___toastMessageUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___toastMessageUI_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
