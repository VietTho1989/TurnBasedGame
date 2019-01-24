﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;
// Foundation.Databinding.ButtonParamater
struct ButtonParamater_t2709481597;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ButtonBinder
struct  ButtonBinder_t1870671702  : public BindingBase_t2590300386
{
public:
	// UnityEngine.UI.Button Foundation.Databinding.ButtonBinder::Button
	Button_t2872111280 * ___Button_9;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ButtonBinder::EnabledBinding
	BindingInfo_t2210172430 * ___EnabledBinding_10;
	// System.Boolean Foundation.Databinding.ButtonBinder::IsInit
	bool ___IsInit_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ButtonBinder::OnClickBinding
	BindingInfo_t2210172430 * ___OnClickBinding_12;
	// Foundation.Databinding.ButtonParamater Foundation.Databinding.ButtonBinder::Paramater
	ButtonParamater_t2709481597 * ___Paramater_13;

public:
	inline static int32_t get_offset_of_Button_9() { return static_cast<int32_t>(offsetof(ButtonBinder_t1870671702, ___Button_9)); }
	inline Button_t2872111280 * get_Button_9() const { return ___Button_9; }
	inline Button_t2872111280 ** get_address_of_Button_9() { return &___Button_9; }
	inline void set_Button_9(Button_t2872111280 * value)
	{
		___Button_9 = value;
		Il2CppCodeGenWriteBarrier(&___Button_9, value);
	}

	inline static int32_t get_offset_of_EnabledBinding_10() { return static_cast<int32_t>(offsetof(ButtonBinder_t1870671702, ___EnabledBinding_10)); }
	inline BindingInfo_t2210172430 * get_EnabledBinding_10() const { return ___EnabledBinding_10; }
	inline BindingInfo_t2210172430 ** get_address_of_EnabledBinding_10() { return &___EnabledBinding_10; }
	inline void set_EnabledBinding_10(BindingInfo_t2210172430 * value)
	{
		___EnabledBinding_10 = value;
		Il2CppCodeGenWriteBarrier(&___EnabledBinding_10, value);
	}

	inline static int32_t get_offset_of_IsInit_11() { return static_cast<int32_t>(offsetof(ButtonBinder_t1870671702, ___IsInit_11)); }
	inline bool get_IsInit_11() const { return ___IsInit_11; }
	inline bool* get_address_of_IsInit_11() { return &___IsInit_11; }
	inline void set_IsInit_11(bool value)
	{
		___IsInit_11 = value;
	}

	inline static int32_t get_offset_of_OnClickBinding_12() { return static_cast<int32_t>(offsetof(ButtonBinder_t1870671702, ___OnClickBinding_12)); }
	inline BindingInfo_t2210172430 * get_OnClickBinding_12() const { return ___OnClickBinding_12; }
	inline BindingInfo_t2210172430 ** get_address_of_OnClickBinding_12() { return &___OnClickBinding_12; }
	inline void set_OnClickBinding_12(BindingInfo_t2210172430 * value)
	{
		___OnClickBinding_12 = value;
		Il2CppCodeGenWriteBarrier(&___OnClickBinding_12, value);
	}

	inline static int32_t get_offset_of_Paramater_13() { return static_cast<int32_t>(offsetof(ButtonBinder_t1870671702, ___Paramater_13)); }
	inline ButtonParamater_t2709481597 * get_Paramater_13() const { return ___Paramater_13; }
	inline ButtonParamater_t2709481597 ** get_address_of_Paramater_13() { return &___Paramater_13; }
	inline void set_Paramater_13(ButtonParamater_t2709481597 * value)
	{
		___Paramater_13 = value;
		Il2CppCodeGenWriteBarrier(&___Paramater_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
