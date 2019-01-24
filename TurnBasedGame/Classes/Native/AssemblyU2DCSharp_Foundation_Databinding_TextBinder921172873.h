#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;
// System.String
struct String_t;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.TextBinder
struct  TextBinder_t921172873  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TextBinder::ColorBinding
	BindingInfo_t2210172430 * ___ColorBinding_9;
	// System.String Foundation.Databinding.TextBinder::FormatString
	String_t* ___FormatString_10;
	// System.Boolean Foundation.Databinding.TextBinder::IsInit
	bool ___IsInit_11;
	// UnityEngine.UI.Text Foundation.Databinding.TextBinder::Label
	Text_t356221433 * ___Label_12;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TextBinder::LabelBinding
	BindingInfo_t2210172430 * ___LabelBinding_13;

public:
	inline static int32_t get_offset_of_ColorBinding_9() { return static_cast<int32_t>(offsetof(TextBinder_t921172873, ___ColorBinding_9)); }
	inline BindingInfo_t2210172430 * get_ColorBinding_9() const { return ___ColorBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_ColorBinding_9() { return &___ColorBinding_9; }
	inline void set_ColorBinding_9(BindingInfo_t2210172430 * value)
	{
		___ColorBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___ColorBinding_9, value);
	}

	inline static int32_t get_offset_of_FormatString_10() { return static_cast<int32_t>(offsetof(TextBinder_t921172873, ___FormatString_10)); }
	inline String_t* get_FormatString_10() const { return ___FormatString_10; }
	inline String_t** get_address_of_FormatString_10() { return &___FormatString_10; }
	inline void set_FormatString_10(String_t* value)
	{
		___FormatString_10 = value;
		Il2CppCodeGenWriteBarrier(&___FormatString_10, value);
	}

	inline static int32_t get_offset_of_IsInit_11() { return static_cast<int32_t>(offsetof(TextBinder_t921172873, ___IsInit_11)); }
	inline bool get_IsInit_11() const { return ___IsInit_11; }
	inline bool* get_address_of_IsInit_11() { return &___IsInit_11; }
	inline void set_IsInit_11(bool value)
	{
		___IsInit_11 = value;
	}

	inline static int32_t get_offset_of_Label_12() { return static_cast<int32_t>(offsetof(TextBinder_t921172873, ___Label_12)); }
	inline Text_t356221433 * get_Label_12() const { return ___Label_12; }
	inline Text_t356221433 ** get_address_of_Label_12() { return &___Label_12; }
	inline void set_Label_12(Text_t356221433 * value)
	{
		___Label_12 = value;
		Il2CppCodeGenWriteBarrier(&___Label_12, value);
	}

	inline static int32_t get_offset_of_LabelBinding_13() { return static_cast<int32_t>(offsetof(TextBinder_t921172873, ___LabelBinding_13)); }
	inline BindingInfo_t2210172430 * get_LabelBinding_13() const { return ___LabelBinding_13; }
	inline BindingInfo_t2210172430 ** get_address_of_LabelBinding_13() { return &___LabelBinding_13; }
	inline void set_LabelBinding_13(BindingInfo_t2210172430 * value)
	{
		___LabelBinding_13 = value;
		Il2CppCodeGenWriteBarrier(&___LabelBinding_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
