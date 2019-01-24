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

// UnityEngine.UI.Extensions.RescaleDragPanel
struct  RescaleDragPanel_t3607722583  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Vector2 UnityEngine.UI.Extensions.RescaleDragPanel::pointerOffset
	Vector2_t2243707579  ___pointerOffset_2;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.RescaleDragPanel::canvasRectTransform
	RectTransform_t3349966182 * ___canvasRectTransform_3;
	// UnityEngine.RectTransform UnityEngine.UI.Extensions.RescaleDragPanel::panelRectTransform
	RectTransform_t3349966182 * ___panelRectTransform_4;
	// UnityEngine.Transform UnityEngine.UI.Extensions.RescaleDragPanel::goTransform
	Transform_t3275118058 * ___goTransform_5;

public:
	inline static int32_t get_offset_of_pointerOffset_2() { return static_cast<int32_t>(offsetof(RescaleDragPanel_t3607722583, ___pointerOffset_2)); }
	inline Vector2_t2243707579  get_pointerOffset_2() const { return ___pointerOffset_2; }
	inline Vector2_t2243707579 * get_address_of_pointerOffset_2() { return &___pointerOffset_2; }
	inline void set_pointerOffset_2(Vector2_t2243707579  value)
	{
		___pointerOffset_2 = value;
	}

	inline static int32_t get_offset_of_canvasRectTransform_3() { return static_cast<int32_t>(offsetof(RescaleDragPanel_t3607722583, ___canvasRectTransform_3)); }
	inline RectTransform_t3349966182 * get_canvasRectTransform_3() const { return ___canvasRectTransform_3; }
	inline RectTransform_t3349966182 ** get_address_of_canvasRectTransform_3() { return &___canvasRectTransform_3; }
	inline void set_canvasRectTransform_3(RectTransform_t3349966182 * value)
	{
		___canvasRectTransform_3 = value;
		Il2CppCodeGenWriteBarrier(&___canvasRectTransform_3, value);
	}

	inline static int32_t get_offset_of_panelRectTransform_4() { return static_cast<int32_t>(offsetof(RescaleDragPanel_t3607722583, ___panelRectTransform_4)); }
	inline RectTransform_t3349966182 * get_panelRectTransform_4() const { return ___panelRectTransform_4; }
	inline RectTransform_t3349966182 ** get_address_of_panelRectTransform_4() { return &___panelRectTransform_4; }
	inline void set_panelRectTransform_4(RectTransform_t3349966182 * value)
	{
		___panelRectTransform_4 = value;
		Il2CppCodeGenWriteBarrier(&___panelRectTransform_4, value);
	}

	inline static int32_t get_offset_of_goTransform_5() { return static_cast<int32_t>(offsetof(RescaleDragPanel_t3607722583, ___goTransform_5)); }
	inline Transform_t3275118058 * get_goTransform_5() const { return ___goTransform_5; }
	inline Transform_t3275118058 ** get_address_of_goTransform_5() { return &___goTransform_5; }
	inline void set_goTransform_5(Transform_t3275118058 * value)
	{
		___goTransform_5 = value;
		Il2CppCodeGenWriteBarrier(&___goTransform_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
