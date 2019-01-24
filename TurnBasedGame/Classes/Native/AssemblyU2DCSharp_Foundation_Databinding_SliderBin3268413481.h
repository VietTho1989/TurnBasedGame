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
// UnityEngine.AudioClip
struct AudioClip_t1932558630;
// UnityEngine.UI.Slider
struct Slider_t297367283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.SliderBinder
struct  SliderBinder_t3268413481  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.SliderBinder::EnabledBinding
	BindingInfo_t2210172430 * ___EnabledBinding_9;
	// System.Boolean Foundation.Databinding.SliderBinder::IsInit
	bool ___IsInit_10;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.SliderBinder::MaxValue
	BindingInfo_t2210172430 * ___MaxValue_11;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.SliderBinder::MinValue
	BindingInfo_t2210172430 * ___MinValue_12;
	// System.Single Foundation.Databinding.SliderBinder::NextSwipe
	float ___NextSwipe_13;
	// System.Boolean Foundation.Databinding.SliderBinder::ReadOnly
	bool ___ReadOnly_14;
	// System.Single Foundation.Databinding.SliderBinder::SoundLag
	float ___SoundLag_15;
	// UnityEngine.AudioClip Foundation.Databinding.SliderBinder::SwipeSound
	AudioClip_t1932558630 * ___SwipeSound_16;
	// UnityEngine.UI.Slider Foundation.Databinding.SliderBinder::Target
	Slider_t297367283 * ___Target_17;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.SliderBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_18;

public:
	inline static int32_t get_offset_of_EnabledBinding_9() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___EnabledBinding_9)); }
	inline BindingInfo_t2210172430 * get_EnabledBinding_9() const { return ___EnabledBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_EnabledBinding_9() { return &___EnabledBinding_9; }
	inline void set_EnabledBinding_9(BindingInfo_t2210172430 * value)
	{
		___EnabledBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___EnabledBinding_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_MaxValue_11() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___MaxValue_11)); }
	inline BindingInfo_t2210172430 * get_MaxValue_11() const { return ___MaxValue_11; }
	inline BindingInfo_t2210172430 ** get_address_of_MaxValue_11() { return &___MaxValue_11; }
	inline void set_MaxValue_11(BindingInfo_t2210172430 * value)
	{
		___MaxValue_11 = value;
		Il2CppCodeGenWriteBarrier(&___MaxValue_11, value);
	}

	inline static int32_t get_offset_of_MinValue_12() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___MinValue_12)); }
	inline BindingInfo_t2210172430 * get_MinValue_12() const { return ___MinValue_12; }
	inline BindingInfo_t2210172430 ** get_address_of_MinValue_12() { return &___MinValue_12; }
	inline void set_MinValue_12(BindingInfo_t2210172430 * value)
	{
		___MinValue_12 = value;
		Il2CppCodeGenWriteBarrier(&___MinValue_12, value);
	}

	inline static int32_t get_offset_of_NextSwipe_13() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___NextSwipe_13)); }
	inline float get_NextSwipe_13() const { return ___NextSwipe_13; }
	inline float* get_address_of_NextSwipe_13() { return &___NextSwipe_13; }
	inline void set_NextSwipe_13(float value)
	{
		___NextSwipe_13 = value;
	}

	inline static int32_t get_offset_of_ReadOnly_14() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___ReadOnly_14)); }
	inline bool get_ReadOnly_14() const { return ___ReadOnly_14; }
	inline bool* get_address_of_ReadOnly_14() { return &___ReadOnly_14; }
	inline void set_ReadOnly_14(bool value)
	{
		___ReadOnly_14 = value;
	}

	inline static int32_t get_offset_of_SoundLag_15() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___SoundLag_15)); }
	inline float get_SoundLag_15() const { return ___SoundLag_15; }
	inline float* get_address_of_SoundLag_15() { return &___SoundLag_15; }
	inline void set_SoundLag_15(float value)
	{
		___SoundLag_15 = value;
	}

	inline static int32_t get_offset_of_SwipeSound_16() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___SwipeSound_16)); }
	inline AudioClip_t1932558630 * get_SwipeSound_16() const { return ___SwipeSound_16; }
	inline AudioClip_t1932558630 ** get_address_of_SwipeSound_16() { return &___SwipeSound_16; }
	inline void set_SwipeSound_16(AudioClip_t1932558630 * value)
	{
		___SwipeSound_16 = value;
		Il2CppCodeGenWriteBarrier(&___SwipeSound_16, value);
	}

	inline static int32_t get_offset_of_Target_17() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___Target_17)); }
	inline Slider_t297367283 * get_Target_17() const { return ___Target_17; }
	inline Slider_t297367283 ** get_address_of_Target_17() { return &___Target_17; }
	inline void set_Target_17(Slider_t297367283 * value)
	{
		___Target_17 = value;
		Il2CppCodeGenWriteBarrier(&___Target_17, value);
	}

	inline static int32_t get_offset_of_ValueBinding_18() { return static_cast<int32_t>(offsetof(SliderBinder_t3268413481, ___ValueBinding_18)); }
	inline BindingInfo_t2210172430 * get_ValueBinding_18() const { return ___ValueBinding_18; }
	inline BindingInfo_t2210172430 ** get_address_of_ValueBinding_18() { return &___ValueBinding_18; }
	inline void set_ValueBinding_18(BindingInfo_t2210172430 * value)
	{
		___ValueBinding_18 = value;
		Il2CppCodeGenWriteBarrier(&___ValueBinding_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
