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
// UnityEngine.UI.InputField
struct InputField_t1631627530;
// UnityEngine.AudioClip
struct AudioClip_t1932558630;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.InputFieldBinder
struct  InputFieldBinder_t497308858  : public BindingBase_t2590300386
{
public:
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.InputFieldBinder::EnabledBinding
	BindingInfo_t2210172430 * ___EnabledBinding_9;
	// System.Boolean Foundation.Databinding.InputFieldBinder::IsInit
	bool ___IsInit_10;
	// System.Single Foundation.Databinding.InputFieldBinder::NextSound
	float ___NextSound_11;
	// System.String Foundation.Databinding.InputFieldBinder::oldText
	String_t* ___oldText_12;
	// System.Single Foundation.Databinding.InputFieldBinder::SoundLag
	float ___SoundLag_13;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.InputFieldBinder::SubmitBinding
	BindingInfo_t2210172430 * ___SubmitBinding_14;
	// UnityEngine.UI.InputField Foundation.Databinding.InputFieldBinder::Target
	InputField_t1631627530 * ___Target_15;
	// Foundation.Databinding.BindingBase/BindingInfo Foundation.Databinding.InputFieldBinder::TextBinding
	BindingInfo_t2210172430 * ___TextBinding_16;
	// UnityEngine.AudioClip Foundation.Databinding.InputFieldBinder::TypeSound
	AudioClip_t1932558630 * ___TypeSound_17;

public:
	inline static int32_t get_offset_of_EnabledBinding_9() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___EnabledBinding_9)); }
	inline BindingInfo_t2210172430 * get_EnabledBinding_9() const { return ___EnabledBinding_9; }
	inline BindingInfo_t2210172430 ** get_address_of_EnabledBinding_9() { return &___EnabledBinding_9; }
	inline void set_EnabledBinding_9(BindingInfo_t2210172430 * value)
	{
		___EnabledBinding_9 = value;
		Il2CppCodeGenWriteBarrier(&___EnabledBinding_9, value);
	}

	inline static int32_t get_offset_of_IsInit_10() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___IsInit_10)); }
	inline bool get_IsInit_10() const { return ___IsInit_10; }
	inline bool* get_address_of_IsInit_10() { return &___IsInit_10; }
	inline void set_IsInit_10(bool value)
	{
		___IsInit_10 = value;
	}

	inline static int32_t get_offset_of_NextSound_11() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___NextSound_11)); }
	inline float get_NextSound_11() const { return ___NextSound_11; }
	inline float* get_address_of_NextSound_11() { return &___NextSound_11; }
	inline void set_NextSound_11(float value)
	{
		___NextSound_11 = value;
	}

	inline static int32_t get_offset_of_oldText_12() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___oldText_12)); }
	inline String_t* get_oldText_12() const { return ___oldText_12; }
	inline String_t** get_address_of_oldText_12() { return &___oldText_12; }
	inline void set_oldText_12(String_t* value)
	{
		___oldText_12 = value;
		Il2CppCodeGenWriteBarrier(&___oldText_12, value);
	}

	inline static int32_t get_offset_of_SoundLag_13() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___SoundLag_13)); }
	inline float get_SoundLag_13() const { return ___SoundLag_13; }
	inline float* get_address_of_SoundLag_13() { return &___SoundLag_13; }
	inline void set_SoundLag_13(float value)
	{
		___SoundLag_13 = value;
	}

	inline static int32_t get_offset_of_SubmitBinding_14() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___SubmitBinding_14)); }
	inline BindingInfo_t2210172430 * get_SubmitBinding_14() const { return ___SubmitBinding_14; }
	inline BindingInfo_t2210172430 ** get_address_of_SubmitBinding_14() { return &___SubmitBinding_14; }
	inline void set_SubmitBinding_14(BindingInfo_t2210172430 * value)
	{
		___SubmitBinding_14 = value;
		Il2CppCodeGenWriteBarrier(&___SubmitBinding_14, value);
	}

	inline static int32_t get_offset_of_Target_15() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___Target_15)); }
	inline InputField_t1631627530 * get_Target_15() const { return ___Target_15; }
	inline InputField_t1631627530 ** get_address_of_Target_15() { return &___Target_15; }
	inline void set_Target_15(InputField_t1631627530 * value)
	{
		___Target_15 = value;
		Il2CppCodeGenWriteBarrier(&___Target_15, value);
	}

	inline static int32_t get_offset_of_TextBinding_16() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___TextBinding_16)); }
	inline BindingInfo_t2210172430 * get_TextBinding_16() const { return ___TextBinding_16; }
	inline BindingInfo_t2210172430 ** get_address_of_TextBinding_16() { return &___TextBinding_16; }
	inline void set_TextBinding_16(BindingInfo_t2210172430 * value)
	{
		___TextBinding_16 = value;
		Il2CppCodeGenWriteBarrier(&___TextBinding_16, value);
	}

	inline static int32_t get_offset_of_TypeSound_17() { return static_cast<int32_t>(offsetof(InputFieldBinder_t497308858, ___TypeSound_17)); }
	inline AudioClip_t1932558630 * get_TypeSound_17() const { return ___TypeSound_17; }
	inline AudioClip_t1932558630 ** get_address_of_TypeSound_17() { return &___TypeSound_17; }
	inline void set_TypeSound_17(AudioClip_t1932558630 * value)
	{
		___TypeSound_17 = value;
		Il2CppCodeGenWriteBarrier(&___TypeSound_17, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
