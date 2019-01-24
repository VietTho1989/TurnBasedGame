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
// UnityEngine.UI.Image
struct Image_t2042527209;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.FillAmmountBinder
struct  FillAmmountBinder_t3861700302  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.FillAmmountBinder::FillValueBinding
	BindingInfo_t2210172430 * ___FillValueBinding_9;
	// System.Boolean Foundation.Databinding.FillAmmountBinder::IsInit
	bool ___IsInit_10;
	// UnityEngine.UI.Image Foundation.Databinding.FillAmmountBinder::Target
	Image_t2042527209 * ___Target_11;

public:
	inline static int32_t get_offset_of_FillValueBinding_9() { return static_cast<int32_t>(offsetof(FillAmmountBinder_t3861700302, ___FillValueBinding_9)); }
	inline BindingInfo_t2210172430 * get_FillValueBinding_9() const { return ___FillValueBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_FillValueBinding_9() { return &___FillValueBinding_9; }
	inline void set_FillValueBinding_9(BindingInfo_t2210172430 * value)
	{
		___FillValueBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___FillValueBinding_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(FillAmmountBinder_t3861700302, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_Target_11() { return static_cast<int32_t>(offsetof(FillAmmountBinder_t3861700302, ___Target_11)); }
	inline Image_t2042527209 * get_Target_11() const { return ___Target_11; }
	inline Image_t2042527209 ** get_address_of_Target_11() { return &___Target_11; }
	inline void set_Target_11(Image_t2042527209 * value)
	{
		___Target_11 = value;
		Il2CppCodeGenWriteBarrier(&___Target_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
