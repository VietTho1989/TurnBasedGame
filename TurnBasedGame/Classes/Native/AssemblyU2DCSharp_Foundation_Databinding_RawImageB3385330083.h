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
// UnityEngine.UI.RawImage
struct RawImage_t2749640213;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.RawImageBinder
struct  RawImageBinder_t3385330083  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.RawImageBinder::ColorBinding
	BindingInfo_t2210172430 * ___ColorBinding_9;
	// System.Boolean Foundation.Databinding.RawImageBinder::IsInit
	bool ___IsInit_10;
	// System.Boolean Foundation.Databinding.RawImageBinder::SetNativeSize
	bool ___SetNativeSize_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.RawImageBinder::SpriteBinding
	BindingInfo_t2210172430 * ___SpriteBinding_12;
	// UnityEngine.UI.RawImage Foundation.Databinding.RawImageBinder::Target
	RawImage_t2749640213 * ___Target_13;

public:
	inline static int32_t get_offset_of_ColorBinding_9() { return static_cast<int32_t>(offsetof(RawImageBinder_t3385330083, ___ColorBinding_9)); }
	inline BindingInfo_t2210172430 * get_ColorBinding_9() const { return ___ColorBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_ColorBinding_9() { return &___ColorBinding_9; }
	inline void set_ColorBinding_9(BindingInfo_t2210172430 * value)
	{
		___ColorBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___ColorBinding_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(RawImageBinder_t3385330083, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_SetNativeSize_11() { return static_cast<int32_t>(offsetof(RawImageBinder_t3385330083, ___SetNativeSize_11)); }
	inline bool get_SetNativeSize_11() const { return ___SetNativeSize_11; }
	inline bool* get_address_of_SetNativeSize_11() { return &___SetNativeSize_11; }
	inline void set_SetNativeSize_11(bool value)
	{
		___SetNativeSize_11 = value;
	}

	inline static int32_t get_offset_of_SpriteBinding_12() { return static_cast<int32_t>(offsetof(RawImageBinder_t3385330083, ___SpriteBinding_12)); }
	inline BindingInfo_t2210172430 * get_SpriteBinding_12() const { return ___SpriteBinding_12; }
	inline BindingInfo_t2210172430 ** get_address_of_SpriteBinding_12() { return &___SpriteBinding_12; }
	inline void set_SpriteBinding_12(BindingInfo_t2210172430 * value)
	{
		___SpriteBinding_12 = value;
		Il2CppCodeGenWriteBarrier(&___SpriteBinding_12, value);
	}

	inline static int32_t get_offset_of_Target_13() { return static_cast<int32_t>(offsetof(RawImageBinder_t3385330083, ___Target_13)); }
	inline RawImage_t2749640213 * get_Target_13() const { return ___Target_13; }
	inline RawImage_t2749640213 ** get_address_of_Target_13() { return &___Target_13; }
	inline void set_Target_13(RawImage_t2749640213 * value)
	{
		___Target_13 = value;
		Il2CppCodeGenWriteBarrier(&___Target_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
