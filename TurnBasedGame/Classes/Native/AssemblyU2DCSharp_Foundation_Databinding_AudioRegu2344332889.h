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

// UnityEngine.AudioSource
struct AudioSource_t1135106623;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.AudioRegulator
struct  AudioRegulator_t2344332889  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.AudioSource Foundation.Databinding.AudioRegulator::Audio
	AudioSource_t1135106623 * ___Audio_2;
	// Foundation.Databinding.AudioLayer Foundation.Databinding.AudioRegulator::Layer
	int32_t ___Layer_3;
	// System.Single Foundation.Databinding.AudioRegulator::<LocalVolume>k__BackingField
	float ___U3CLocalVolumeU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_Audio_2() { return static_cast<int32_t>(offsetof(AudioRegulator_t2344332889, ___Audio_2)); }
	inline AudioSource_t1135106623 * get_Audio_2() const { return ___Audio_2; }
	inline AudioSource_t1135106623 ** get_address_of_Audio_2() { return &___Audio_2; }
	inline void set_Audio_2(AudioSource_t1135106623 * value)
	{
		___Audio_2 = value;
		Il2CppCodeGenWriteBarrier(&___Audio_2, value);
	}

	inline static int32_t get_offset_of_Layer_3() { return static_cast<int32_t>(offsetof(AudioRegulator_t2344332889, ___Layer_3)); }
	inline int32_t get_Layer_3() const { return ___Layer_3; }
	inline int32_t* get_address_of_Layer_3() { return &___Layer_3; }
	inline void set_Layer_3(int32_t value)
	{
		___Layer_3 = value;
	}

	inline static int32_t get_offset_of_U3CLocalVolumeU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(AudioRegulator_t2344332889, ___U3CLocalVolumeU3Ek__BackingField_4)); }
	inline float get_U3CLocalVolumeU3Ek__BackingField_4() const { return ___U3CLocalVolumeU3Ek__BackingField_4; }
	inline float* get_address_of_U3CLocalVolumeU3Ek__BackingField_4() { return &___U3CLocalVolumeU3Ek__BackingField_4; }
	inline void set_U3CLocalVolumeU3Ek__BackingField_4(float value)
	{
		___U3CLocalVolumeU3Ek__BackingField_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
