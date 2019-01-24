#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_Foundation_Databinding_AudioLaye2466824707.h"

// UnityEngine.AudioClip
struct AudioClip_t1932558630;
// UnityEngine.AudioSource
struct AudioSource_t1135106623;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.Audio2DSource
struct  Audio2DSource_t3393070043  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.AudioClip Foundation.Databinding.Audio2DSource::Clip
	AudioClip_t1932558630 * ___Clip_2;
	// System.Int32 Foundation.Databinding.Audio2DSource::Delay
	int32_t ___Delay_3;
	// System.Boolean Foundation.Databinding.Audio2DSource::FirstTime
	bool ___FirstTime_4;
	// Foundation.Databinding.AudioLayer Foundation.Databinding.Audio2DSource::Layer
	int32_t ___Layer_5;
	// System.Boolean Foundation.Databinding.Audio2DSource::Loop
	bool ___Loop_6;
	// System.Single Foundation.Databinding.Audio2DSource::Pitch
	float ___Pitch_7;
	// System.Boolean Foundation.Databinding.Audio2DSource::PlayOnEnable
	bool ___PlayOnEnable_8;
	// System.Single Foundation.Databinding.Audio2DSource::Volume
	float ___Volume_9;
	// System.Boolean Foundation.Databinding.Audio2DSource::<IsPlaying>k__BackingField
	bool ___U3CIsPlayingU3Ek__BackingField_10;
	// UnityEngine.AudioSource Foundation.Databinding.Audio2DSource::<Source>k__BackingField
	AudioSource_t1135106623 * ___U3CSourceU3Ek__BackingField_11;

public:
	inline static int32_t get_offset_of_Clip_2() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Clip_2)); }
	inline AudioClip_t1932558630 * get_Clip_2() const { return ___Clip_2; }
	inline AudioClip_t1932558630 ** get_address_of_Clip_2() { return &___Clip_2; }
	inline void set_Clip_2(AudioClip_t1932558630 * value)
	{
		___Clip_2 = value;
		Il2CppCodeGenWriteBarrier(&___Clip_2, value);
	}

	inline static int32_t get_offset_of_Delay_3() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Delay_3)); }
	inline int32_t get_Delay_3() const { return ___Delay_3; }
	inline int32_t* get_address_of_Delay_3() { return &___Delay_3; }
	inline void set_Delay_3(int32_t value)
	{
		___Delay_3 = value;
	}

	inline static int32_t get_offset_of_FirstTime_4() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___FirstTime_4)); }
	inline bool get_FirstTime_4() const { return ___FirstTime_4; }
	inline bool* get_address_of_FirstTime_4() { return &___FirstTime_4; }
	inline void set_FirstTime_4(bool value)
	{
		___FirstTime_4 = value;
	}

	inline static int32_t get_offset_of_Layer_5() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Layer_5)); }
	inline int32_t get_Layer_5() const { return ___Layer_5; }
	inline int32_t* get_address_of_Layer_5() { return &___Layer_5; }
	inline void set_Layer_5(int32_t value)
	{
		___Layer_5 = value;
	}

	inline static int32_t get_offset_of_Loop_6() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Loop_6)); }
	inline bool get_Loop_6() const { return ___Loop_6; }
	inline bool* get_address_of_Loop_6() { return &___Loop_6; }
	inline void set_Loop_6(bool value)
	{
		___Loop_6 = value;
	}

	inline static int32_t get_offset_of_Pitch_7() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Pitch_7)); }
	inline float get_Pitch_7() const { return ___Pitch_7; }
	inline float* get_address_of_Pitch_7() { return &___Pitch_7; }
	inline void set_Pitch_7(float value)
	{
		___Pitch_7 = value;
	}

	inline static int32_t get_offset_of_PlayOnEnable_8() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___PlayOnEnable_8)); }
	inline bool get_PlayOnEnable_8() const { return ___PlayOnEnable_8; }
	inline bool* get_address_of_PlayOnEnable_8() { return &___PlayOnEnable_8; }
	inline void set_PlayOnEnable_8(bool value)
	{
		___PlayOnEnable_8 = value;
	}

	inline static int32_t get_offset_of_Volume_9() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___Volume_9)); }
	inline float get_Volume_9() const { return ___Volume_9; }
	inline float* get_address_of_Volume_9() { return &___Volume_9; }
	inline void set_Volume_9(float value)
	{
		___Volume_9 = value;
	}

	inline static int32_t get_offset_of_U3CIsPlayingU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___U3CIsPlayingU3Ek__BackingField_10)); }
	inline bool get_U3CIsPlayingU3Ek__BackingField_10() const { return ___U3CIsPlayingU3Ek__BackingField_10; }
	inline bool* get_address_of_U3CIsPlayingU3Ek__BackingField_10() { return &___U3CIsPlayingU3Ek__BackingField_10; }
	inline void set_U3CIsPlayingU3Ek__BackingField_10(bool value)
	{
		___U3CIsPlayingU3Ek__BackingField_10 = value;
	}

	inline static int32_t get_offset_of_U3CSourceU3Ek__BackingField_11() { return static_cast<int32_t>(offsetof(Audio2DSource_t3393070043, ___U3CSourceU3Ek__BackingField_11)); }
	inline AudioSource_t1135106623 * get_U3CSourceU3Ek__BackingField_11() const { return ___U3CSourceU3Ek__BackingField_11; }
	inline AudioSource_t1135106623 ** get_address_of_U3CSourceU3Ek__BackingField_11() { return &___U3CSourceU3Ek__BackingField_11; }
	inline void set_U3CSourceU3Ek__BackingField_11(AudioSource_t1135106623 * value)
	{
		___U3CSourceU3Ek__BackingField_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSourceU3Ek__BackingField_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
