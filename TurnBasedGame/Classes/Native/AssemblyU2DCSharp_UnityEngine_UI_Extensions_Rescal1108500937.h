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
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.RescalePanel
struct  RescalePanel_t1108500937  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescalePanel::minSize
	Vector2_t2243707579  ___minSize_2;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescalePanel::maxSize
	Vector2_t2243707579  ___maxSize_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.RescalePanel::rectTransform
	RectTransform_t3349966182 * ___rectTransform_4;
	// UnityEngine.Transform UnityEngine.UI.Extensions.RescalePanel::goTransform
	Transform_t3275118058 * ___goTransform_5;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescalePanel::currentPointerPosition
	Vector2_t2243707579  ___currentPointerPosition_6;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescalePanel::previousPointerPosition
	Vector2_t2243707579  ___previousPointerPosition_7;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.RescalePanel::thisRectTransform
	RectTransform_t3349966182 * ___thisRectTransform_8;
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescalePanel::sizeDelta
	Vector2_t2243707579  ___sizeDelta_9;

public:
	inline static int32_t get_offset_of_minSize_2() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___minSize_2)); }
	inline Vector2_t2243707579  get_minSize_2() const { return ___minSize_2; }
	inline Vector2_t2243707579 * get_address_of_minSize_2() { return &___minSize_2; }
	inline void set_minSize_2(Vector2_t2243707579  value)
	{
		___minSize_2 = value;
	}

	inline static int32_t get_offset_of_maxSize_3() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___maxSize_3)); }
	inline Vector2_t2243707579  get_maxSize_3() const { return ___maxSize_3; }
	inline Vector2_t2243707579 * get_address_of_maxSize_3() { return &___maxSize_3; }
	inline void set_maxSize_3(Vector2_t2243707579  value)
	{
		___maxSize_3 = value;
	}

	inline static int32_t get_offset_of_rectTransform_4() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___rectTransform_4)); }
	inline RectTransform_t3349966182 * get_rectTransform_4() const { return ___rectTransform_4; }
	inline RectTransform_t3349966182 ** get_address_of_rectTransform_4() { return &___rectTransform_4; }
	inline void set_rectTransform_4(RectTransform_t3349966182 * value)
	{
		___rectTransform_4 = value;
		Il2CppCodeGenWriteBarrier(&___rectTransform_4, value);
	}

	inline static int32_t get_offset_of_goTransform_5() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___goTransform_5)); }
	inline Transform_t3275118058 * get_goTransform_5() const { return ___goTransform_5; }
	inline Transform_t3275118058 ** get_address_of_goTransform_5() { return &___goTransform_5; }
	inline void set_goTransform_5(Transform_t3275118058 * value)
	{
		___goTransform_5 = value;
		Il2CppCodeGenWriteBarrier(&___goTransform_5, value);
	}

	inline static int32_t get_offset_of_currentPointerPosition_6() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___currentPointerPosition_6)); }
	inline Vector2_t2243707579  get_currentPointerPosition_6() const { return ___currentPointerPosition_6; }
	inline Vector2_t2243707579 * get_address_of_currentPointerPosition_6() { return &___currentPointerPosition_6; }
	inline void set_currentPointerPosition_6(Vector2_t2243707579  value)
	{
		___currentPointerPosition_6 = value;
	}

	inline static int32_t get_offset_of_previousPointerPosition_7() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___previousPointerPosition_7)); }
	inline Vector2_t2243707579  get_previousPointerPosition_7() const { return ___previousPointerPosition_7; }
	inline Vector2_t2243707579 * get_address_of_previousPointerPosition_7() { return &___previousPointerPosition_7; }
	inline void set_previousPointerPosition_7(Vector2_t2243707579  value)
	{
		___previousPointerPosition_7 = value;
	}

	inline static int32_t get_offset_of_thisRectTransform_8() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___thisRectTransform_8)); }
	inline RectTransform_t3349966182 * get_thisRectTransform_8() const { return ___thisRectTransform_8; }
	inline RectTransform_t3349966182 ** get_address_of_thisRectTransform_8() { return &___thisRectTransform_8; }
	inline void set_thisRectTransform_8(RectTransform_t3349966182 * value)
	{
		___thisRectTransform_8 = value;
		Il2CppCodeGenWriteBarrier(&___thisRectTransform_8, value);
	}

	inline static int32_t get_offset_of_sizeDelta_9() { return static_cast<int32_t>(offsetof(RescalePanel_t1108500937, ___sizeDelta_9)); }
	inline Vector2_t2243707579  get_sizeDelta_9() const { return ___sizeDelta_9; }
	inline Vector2_t2243707579 * get_address_of_sizeDelta_9() { return &___sizeDelta_9; }
	inline void set_sizeDelta_9(Vector2_t2243707579  value)
	{
		___sizeDelta_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
