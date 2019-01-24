#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_BindingBa2590300386.h"

// UnityEngine.AudioClip
struct AudioClip_t1932558630;
// Foundation.Databinding.BindingBase/BindingInfo
struct BindingInfo_t2210172430;
// System.String
struct String_t;
// UnityEngine.UI.Toggle
struct Toggle_t3976754468;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ToggleBinder
struct  ToggleBinder_t3702183794  : public BindingBase_t2590300386
{
public:
	// UnityEngine.AudioClip Foundation.Databinding.ToggleBinder::ClickSound
	AudioClip_t1932558630 * ___ClickSound_9;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ToggleBinder::EnabledBinding
	BindingInfo_t2210172430 * ___EnabledBinding_10;
	// System.Boolean Foundation.Databinding.ToggleBinder::IsInit
	bool ___IsInit_11;
	// System.Single Foundation.Databinding.ToggleBinder::NextSound
	float ___NextSound_12;
	// System.Single Foundation.Databinding.ToggleBinder::SoundLag
	float ___SoundLag_13;
	// System.String Foundation.Databinding.ToggleBinder::StaticValue
	String_t* ___StaticValue_14;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ToggleBinder::StaticValueBinding
	BindingInfo_t2210172430 * ___StaticValueBinding_15;
	// UnityEngine.UI.Toggle Foundation.Databinding.ToggleBinder::Target
	Toggle_t3976754468 * ___Target_16;
	// System.Boolean Foundation.Databinding.ToggleBinder::UseStaticValue
	bool ___UseStaticValue_17;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.ToggleBinder::ValueBinding
	BindingInfo_t2210172430 * ___ValueBinding_18;

public:
	inline static int32_t get_offset_of_ClickSound_9() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___ClickSound_9)); }
	inline AudioClip_t1932558630 * get_ClickSound_9() const { return ___ClickSound_9; }
	inline AudioClip_t1932558630 ** get_address_of_ClickSound_9() { return &___ClickSound_9; }
	inline void set_ClickSound_9(AudioClip_t1932558630 * value)
	{
		___ClickSound_9 = value;
		Il2CppCodeGenWriteBarrier(&___ClickSound_9, value);
	}

	inline static int32_t get_offset_of_EnabledBinding_10() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___EnabledBinding_10)); }
	inline BindingInfo_t2210172430 * get_EnabledBinding_10() const { return ___EnabledBinding_10; }
	inline BindingInfo_t2210172430 ** get_address_of_EnabledBinding_10() { return &___EnabledBinding_10; }
	inline void set_EnabledBinding_10(BindingInfo_t2210172430 * value)
	{
		___EnabledBinding_10 = value;
		Il2CppCodeGenWriteBarrier(&___EnabledBinding_10, value);
	}

	inline static int32_t get_offset_of_IsInit_11() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___IsInit_11)); }
	inline bool get_IsInit_11() const { return ___IsInit_11; }
	inline bool* get_address_of_IsInit_11() { return &___IsInit_11; }
	inline void set_IsInit_11(bool value)
	{
		___IsInit_11 = value;
	}

	inline static int32_t get_offset_of_NextSound_12() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___NextSound_12)); }
	inline float get_NextSound_12() const { return ___NextSound_12; }
	inline float* get_address_of_NextSound_12() { return &___NextSound_12; }
	inline void set_NextSound_12(float value)
	{
		___NextSound_12 = value;
	}

	inline static int32_t get_offset_of_SoundLag_13() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___SoundLag_13)); }
	inline float get_SoundLag_13() const { return ___SoundLag_13; }
	inline float* get_address_of_SoundLag_13() { return &___SoundLag_13; }
	inline void set_SoundLag_13(float value)
	{
		___SoundLag_13 = value;
	}

	inline static int32_t get_offset_of_StaticValue_14() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___StaticValue_14)); }
	inline String_t* get_StaticValue_14() const { return ___StaticValue_14; }
	inline String_t** get_address_of_StaticValue_14() { return &___StaticValue_14; }
	inline void set_StaticValue_14(String_t* value)
	{
		___StaticValue_14 = value;
		Il2CppCodeGenWriteBarrier(&___StaticValue_14, value);
	}

	inline static int32_t get_offset_of_StaticValueBinding_15() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___StaticValueBinding_15)); }
	inline BindingInfo_t2210172430 * get_StaticValueBinding_15() const { return ___StaticValueBinding_15; }
	inline BindingInfo_t2210172430 ** get_address_of_StaticValueBinding_15() { return &___StaticValueBinding_15; }
	inline void set_StaticValueBinding_15(BindingInfo_t2210172430 * value)
	{
		___StaticValueBinding_15 = value;
		Il2CppCodeGenWriteBarrier(&___StaticValueBinding_15, value);
	}

	inline static int32_t get_offset_of_Target_16() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___Target_16)); }
	inline Toggle_t3976754468 * get_Target_16() const { return ___Target_16; }
	inline Toggle_t3976754468 ** get_address_of_Target_16() { return &___Target_16; }
	inline void set_Target_16(Toggle_t3976754468 * value)
	{
		___Target_16 = value;
		Il2CppCodeGenWriteBarrier(&___Target_16, value);
	}

	inline static int32_t get_offset_of_UseStaticValue_17() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___UseStaticValue_17)); }
	inline bool get_UseStaticValue_17() const { return ___UseStaticValue_17; }
	inline bool* get_address_of_UseStaticValue_17() { return &___UseStaticValue_17; }
	inline void set_UseStaticValue_17(bool value)
	{
		___UseStaticValue_17 = value;
	}

	inline static int32_t get_offset_of_ValueBinding_18() { return static_cast<int32_t>(offsetof(ToggleBinder_t3702183794, ___ValueBinding_18)); }
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
