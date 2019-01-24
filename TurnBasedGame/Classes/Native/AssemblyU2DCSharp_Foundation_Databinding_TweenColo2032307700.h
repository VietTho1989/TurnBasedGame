#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.TweenColorBinder
struct  TweenColorBinder_t2032307700  : public BindingBase_t2590300386
{
public:
	// UnityEngine.UI.Image Foundation.Databinding.TweenColorBinder::image
	Image_t2042527209 * ___image_9;
	// System.Boolean Foundation.Databinding.TweenColorBinder::IsInit
	bool ___IsInit_10;
	// UnityEngine.Color Foundation.Databinding.TweenColorBinder::MaxColor
	Color_t2020392075  ___MaxColor_11;
	// UnityEngine.Color Foundation.Databinding.TweenColorBinder::MinColor
	Color_t2020392075  ___MinColor_12;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.TweenColorBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_13;

public:
	inline static int32_t get_offset_of_image_9() { return static_cast<int32_t>(offsetof(TweenColorBinder_t2032307700, ___image_9)); }
	inline Image_t2042527209 * get_image_9() const { return ___image_9; }
	inline Image_t2042527209 ** get_address_of_image_9() { return &___image_9; }
	inline void set_image_9(Image_t2042527209 * value)
	{
		___image_9 = value;
		Il2CppCodeGenWriteBarrier(&___image_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(TweenColorBinder_t2032307700, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_MaxColor_11() { return static_cast<int32_t>(offsetof(TweenColorBinder_t2032307700, ___MaxColor_11)); }
	inline Color_t2020392075  get_MaxColor_11() const { return ___MaxColor_11; }
	inline Color_t2020392075 * get_address_of_MaxColor_11() { return &___MaxColor_11; }
	inline void set_MaxColor_11(Color_t2020392075  value)
	{
		___MaxColor_11 = value;
	}

	inline static int32_t get_offset_of_MinColor_12() { return static_cast<int32_t>(offsetof(TweenColorBinder_t2032307700, ___MinColor_12)); }
	inline Color_t2020392075  get_MinColor_12() const { return ___MinColor_12; }
	inline Color_t2020392075 * get_address_of_MinColor_12() { return &___MinColor_12; }
	inline void set_MinColor_12(Color_t2020392075  value)
	{
		___MinColor_12 = value;
	}

	inline static int32_t get_offset_of_ValueBinding_13() { return static_cast<int32_t>(offsetof(TweenColorBinder_t2032307700, ___ValueBinding_13)); }
	inline BindingInfo_t2210172430 * get_ValueBinding_13() const { return ___ValueBinding_13; }
	inline BindingInfo_t2210172430 ** get_address_of_ValueBinding_13() { return &___ValueBinding_13; }
	inline void set_ValueBinding_13(BindingInfo_t2210172430 * value)
	{
		___ValueBinding_13 = value;
		Il2CppCodeGenWriteBarrier(&___ValueBinding_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
