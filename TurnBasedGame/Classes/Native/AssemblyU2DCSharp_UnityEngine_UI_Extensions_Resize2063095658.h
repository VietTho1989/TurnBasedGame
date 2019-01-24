#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ResizePanel
struct  ResizePanel_t2063095658  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ResizePanel::minSize
	Vector2_t2243707579  ___minSize_2;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ResizePanel::maxSize
	Vector2_t2243707579  ___maxSize_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.ResizePanel::rectTransform
	RectTransform_t3349966182 * ___rectTransform_4;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ResizePanel::currentPointerPosition
	Vector2_t2243707579  ___currentPointerPosition_5;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.ResizePanel::previousPointerPosition
	Vector2_t2243707579  ___previousPointerPosition_6;
	// System.Single UnityEngine.UI.Extensions.ResizePanel::ratio
	float ___ratio_7;

public:
	inline static int32_t get_offset_of_minSize_2() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___minSize_2)); }
	inline Vector2_t2243707579  get_minSize_2() const { return ___minSize_2; }
	inline Vector2_t2243707579 * get_address_of_minSize_2() { return &___minSize_2; }
	inline void set_minSize_2(Vector2_t2243707579  value)
	{
		___minSize_2 = value;
	}

	inline static int32_t get_offset_of_maxSize_3() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___maxSize_3)); }
	inline Vector2_t2243707579  get_maxSize_3() const { return ___maxSize_3; }
	inline Vector2_t2243707579 * get_address_of_maxSize_3() { return &___maxSize_3; }
	inline void set_maxSize_3(Vector2_t2243707579  value)
	{
		___maxSize_3 = value;
	}

	inline static int32_t get_offset_of_rectTransform_4() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___rectTransform_4)); }
	inline RectTransform_t3349966182 * get_rectTransform_4() const { return ___rectTransform_4; }
	inline RectTransform_t3349966182 ** get_address_of_rectTransform_4() { return &___rectTransform_4; }
	inline void set_rectTransform_4(RectTransform_t3349966182 * value)
	{
		___rectTransform_4 = value;
		Il2CppCodeGenWriteBarrier(&___rectTransform_4, value);
	}

	inline static int32_t get_offset_of_currentPointerPosition_5() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___currentPointerPosition_5)); }
	inline Vector2_t2243707579  get_currentPointerPosition_5() const { return ___currentPointerPosition_5; }
	inline Vector2_t2243707579 * get_address_of_currentPointerPosition_5() { return &___currentPointerPosition_5; }
	inline void set_currentPointerPosition_5(Vector2_t2243707579  value)
	{
		___currentPointerPosition_5 = value;
	}

	inline static int32_t get_offset_of_previousPointerPosition_6() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___previousPointerPosition_6)); }
	inline Vector2_t2243707579  get_previousPointerPosition_6() const { return ___previousPointerPosition_6; }
	inline Vector2_t2243707579 * get_address_of_previousPointerPosition_6() { return &___previousPointerPosition_6; }
	inline void set_previousPointerPosition_6(Vector2_t2243707579  value)
	{
		___previousPointerPosition_6 = value;
	}

	inline static int32_t get_offset_of_ratio_7() { return static_cast<int32_t>(offsetof(ResizePanel_t2063095658, ___ratio_7)); }
	inline float get_ratio_7() const { return ___ratio_7; }
	inline float* get_address_of_ratio_7() { return &___ratio_7; }
	inline void set_ratio_7(float value)
	{
		___ratio_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
