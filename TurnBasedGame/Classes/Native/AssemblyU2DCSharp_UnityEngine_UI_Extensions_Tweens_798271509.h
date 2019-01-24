#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.UI.Extensions.Tweens.FloatTween/FloatTweenCallback
struct FloatTweenCallback_t420310625;
// UnityEngine.UI.Extensions.Tweens.FloatTween/FloatFinishCallback
struct FloatFinishCallback_t26767115;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.Tweens.FloatTween
struct  FloatTween_t798271509 
{
public:
	// System.Single UnityEngine.UI.Extensions.Tweens.FloatTween::m_StartFloat
	float ___m_StartFloat_0;
	// System.Single UnityEngine.UI.Extensions.Tweens.FloatTween::m_TargetFloat
	float ___m_TargetFloat_1;
	// System.Single UnityEngine.UI.Extensions.Tweens.FloatTween::m_Duration
	float ___m_Duration_2;
	// System.Boolean UnityEngine.UI.Extensions.Tweens.FloatTween::m_IgnoreTimeScale
	bool ___m_IgnoreTimeScale_3;
	// UnityEngine.UI.Extensions.Tweens.FloatTween/FloatTweenCallback UnityEngine.UI.Extensions.Tweens.FloatTween::m_Target
	FloatTweenCallback_t420310625 * ___m_Target_4;
	// UnityEngine.UI.Extensions.Tweens.FloatTween/FloatFinishCallback UnityEngine.UI.Extensions.Tweens.FloatTween::m_Finish
	FloatFinishCallback_t26767115 * ___m_Finish_5;

public:
	inline static int32_t get_offset_of_m_StartFloat_0() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_StartFloat_0)); }
	inline float get_m_StartFloat_0() const { return ___m_StartFloat_0; }
	inline float* get_address_of_m_StartFloat_0() { return &___m_StartFloat_0; }
	inline void set_m_StartFloat_0(float value)
	{
		___m_StartFloat_0 = value;
	}

	inline static int32_t get_offset_of_m_TargetFloat_1() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_TargetFloat_1)); }
	inline float get_m_TargetFloat_1() const { return ___m_TargetFloat_1; }
	inline float* get_address_of_m_TargetFloat_1() { return &___m_TargetFloat_1; }
	inline void set_m_TargetFloat_1(float value)
	{
		___m_TargetFloat_1 = value;
	}

	inline static int32_t get_offset_of_m_Duration_2() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_Duration_2)); }
	inline float get_m_Duration_2() const { return ___m_Duration_2; }
	inline float* get_address_of_m_Duration_2() { return &___m_Duration_2; }
	inline void set_m_Duration_2(float value)
	{
		___m_Duration_2 = value;
	}

	inline static int32_t get_offset_of_m_IgnoreTimeScale_3() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_IgnoreTimeScale_3)); }
	inline bool get_m_IgnoreTimeScale_3() const { return ___m_IgnoreTimeScale_3; }
	inline bool* get_address_of_m_IgnoreTimeScale_3() { return &___m_IgnoreTimeScale_3; }
	inline void set_m_IgnoreTimeScale_3(bool value)
	{
		___m_IgnoreTimeScale_3 = value;
	}

	inline static int32_t get_offset_of_m_Target_4() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_Target_4)); }
	inline FloatTweenCallback_t420310625 * get_m_Target_4() const { return ___m_Target_4; }
	inline FloatTweenCallback_t420310625 ** get_address_of_m_Target_4() { return &___m_Target_4; }
	inline void set_m_Target_4(FloatTweenCallback_t420310625 * value)
	{
		___m_Target_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_Target_4, value);
	}

	inline static int32_t get_offset_of_m_Finish_5() { return static_cast<int32_t>(offsetof(FloatTween_t798271509, ___m_Finish_5)); }
	inline FloatFinishCallback_t26767115 * get_m_Finish_5() const { return ___m_Finish_5; }
	inline FloatFinishCallback_t26767115 ** get_address_of_m_Finish_5() { return &___m_Finish_5; }
	inline void set_m_Finish_5(FloatFinishCallback_t26767115 * value)
	{
		___m_Finish_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_Finish_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.UI.Extensions.Tweens.FloatTween
struct FloatTween_t798271509_marshaled_pinvoke
{
	float ___m_StartFloat_0;
	float ___m_TargetFloat_1;
	float ___m_Duration_2;
	int32_t ___m_IgnoreTimeScale_3;
	FloatTweenCallback_t420310625 * ___m_Target_4;
	FloatFinishCallback_t26767115 * ___m_Finish_5;
};
// Native definition for COM marshalling of UnityEngine.UI.Extensions.Tweens.FloatTween
struct FloatTween_t798271509_marshaled_com
{
	float ___m_StartFloat_0;
	float ___m_TargetFloat_1;
	float ___m_Duration_2;
	int32_t ___m_IgnoreTimeScale_3;
	FloatTweenCallback_t420310625 * ___m_Target_4;
	FloatFinishCallback_t26767115 * ___m_Finish_5;
};
