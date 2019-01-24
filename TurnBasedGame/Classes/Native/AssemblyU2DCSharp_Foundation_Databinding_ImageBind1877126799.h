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
// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.UI.Image
struct Image_t2042527209;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ImageBinder
struct  ImageBinder_t1877126799  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ImageBinder::ColorBinding
	BindingInfo_t2210172430 * ___ColorBinding_9;
	// System.Boolean Foundation.Databinding.ImageBinder::IsInit
	bool ___IsInit_10;
	// UnityEngine.Sprite Foundation.Databinding.ImageBinder::original
	Sprite_t309593783 * ___original_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ImageBinder::SpriteBinding
	BindingInfo_t2210172430 * ___SpriteBinding_12;
	// UnityEngine.UI.Image Foundation.Databinding.ImageBinder::Target
	Image_t2042527209 * ___Target_13;

public:
	inline static int32_t get_offset_of_ColorBinding_9() { return static_cast<int32_t>(offsetof(ImageBinder_t1877126799, ___ColorBinding_9)); }
	inline BindingInfo_t2210172430 * get_ColorBinding_9() const { return ___ColorBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_ColorBinding_9() { return &___ColorBinding_9; }
	inline void set_ColorBinding_9(BindingInfo_t2210172430 * value)
	{
		___ColorBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___ColorBinding_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(ImageBinder_t1877126799, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_original_11() { return static_cast<int32_t>(offsetof(ImageBinder_t1877126799, ___original_11)); }
	inline Sprite_t309593783 * get_original_11() const { return ___original_11; }
	inline Sprite_t309593783 ** get_address_of_original_11() { return &___original_11; }
	inline void set_original_11(Sprite_t309593783 * value)
	{
		___original_11 = value;
		Il2CppCodeGenWriteBarrier(&___original_11, value);
	}

	inline static int32_t get_offset_of_SpriteBinding_12() { return static_cast<int32_t>(offsetof(ImageBinder_t1877126799, ___SpriteBinding_12)); }
	inline BindingInfo_t2210172430 * get_SpriteBinding_12() const { return ___SpriteBinding_12; }
	inline BindingInfo_t2210172430 ** get_address_of_SpriteBinding_12() { return &___SpriteBinding_12; }
	inline void set_SpriteBinding_12(BindingInfo_t2210172430 * value)
	{
		___SpriteBinding_12 = value;
		Il2CppCodeGenWriteBarrier(&___SpriteBinding_12, value);
	}

	inline static int32_t get_offset_of_Target_13() { return static_cast<int32_t>(offsetof(ImageBinder_t1877126799, ___Target_13)); }
	inline Image_t2042527209 * get_Target_13() const { return ___Target_13; }
	inline Image_t2042527209 ** get_address_of_Target_13() { return &___Target_13; }
	inline void set_Target_13(Image_t2042527209 * value)
	{
		___Target_13 = value;
		Il2CppCodeGenWriteBarrier(&___Target_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
